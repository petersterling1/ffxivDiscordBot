using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ffxivDiscordBot
{
    class HTTPRequest
    {
        public HTTPRequest()
        {

        }

        public String postRequest(string url, string json, string authorization = null, Dictionary<string, string> customHeaders = null)
        {
            WebRequest wr = WebRequest.Create(url);

            if(authorization != null)
                wr.Headers[HttpRequestHeader.Authorization] = authorization;

            if (customHeaders != null)
            {
                foreach (KeyValuePair<string, string> header in customHeaders)
                {
                    wr.Headers[header.Key] = header.Value;
                }
            }

            wr.ContentType = "application/json; charset=utf-8";
            wr.Method = "POST";

            using (StreamWriter sW = new StreamWriter(wr.GetRequestStream()))
            {
                sW.Write(json);
            }

            string result = "";

            try
            {
                var httpResponse = (HttpWebResponse)wr.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            } catch {
                return null;
            }

            return result;
        }

        public string getRequest(string url, string authorization = null, Dictionary<string, string> customHeaders = null)
        {
            WebRequest wr;
            Stream stream;
            StreamReader reader;

            try
            {
                wr = WebRequest.Create(url);

                if (authorization != null)
                    wr.Headers[HttpRequestHeader.Authorization] = authorization;

                if(customHeaders != null)
                {
                    foreach(KeyValuePair<string, string> header in customHeaders)
                    {
                        wr.Headers[header.Key] = header.Value;
                    }
                }

                stream = wr.GetResponse().GetResponseStream();
                reader = new StreamReader(stream);

            } catch(WebException e) {

                string response = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
                return response;

            }

            string line = "";
            string returnText = "";

            while(line != null)
            {
                line = reader.ReadLine();
                if(line != null)
                {
                    returnText += line;
                }
            }

            return returnText;
        }
    }
}
