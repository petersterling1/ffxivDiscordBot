using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace ffxivDiscordBot
{
    class Discord
    {
        private WebSocket client = null;
        private bool reconnect;
        private string sequenceNumber = null;
        private System.Timers.Timer heartBeatTimer = null;
        private string sessionID = null;

        //View (form) to send updates to.
        private mainForm mF = null;

        //TODO: Get the discord gateway dynamically
        private string gateway = "wss://gateway.discord.gg?v=5&encoding=json";

        //Pass connection update event to form
        private void informFormConnectionStatus(string message)
        {
            mF.changeConnectionStatus(client.IsAlive, message);
        }

        private void informFormDiscordMessage(string username, string message)
        {
            mF.addDiscordChatMessage(username, message);
        }

        public Discord(mainForm callingForm)
        {

            this.mF = callingForm;

            client = new WebSocket(gateway);

            client.OnMessage += (s, e) => 
                onMessageRecieved(e.Data);

            client.OnClose += (s, e) =>
                onDisconnect(e.Code, e.Reason);

            client.OnError += (s, e) =>
                onError(e.Message);

            client.OnOpen += (s, e) =>
                onOpen();

            mF = (mainForm)Application.OpenForms["mainForm"];
        }

        private void onError(string message)
        {

        }

        private void onOpen()
        {
            informFormConnectionStatus("Connected to server.");
        }

        private void onMessageRecieved(string message)
        {
            //Discord has sent us data.

            JObject jsonMessage = null;

            try
            {
                jsonMessage = JObject.Parse(message);
            } catch
            {
                //Sent us something that isn't JSON?
                //TODO: Handle this case?? For now, don't attempt to parse it.

                return;
            }

            string eventType = (string) jsonMessage["op"];

            if(eventType != null)
            {
                //This is definitely a discord event!
                discordEvent(eventType, jsonMessage);
            }
        }

        private void discordEvent(string opID, JObject message)
        {
            Console.WriteLine(message);

            //Heartbeat sending requires a resend of information from the last packet receieved if present.
            if ((string)message["s"] != null) sequenceNumber = (string)message["s"];

            switch (opID)
            {
                case "10":
                    //Sent after connecting. A hello message.

                    //How often we're supposed to send a heartbeat (milliseconds).
                    int heartbeat = (int)message["d"]["heartbeat_interval"];

                    authenticate();

                    //Set up a timer to send the heartbeat message
                    heartBeatTimer = new System.Timers.Timer();
                    heartBeatTimer.Interval = heartbeat;
                    heartBeatTimer.Elapsed += timerTick;
                    heartBeatTimer.Start();

                    break;

                case "9":

                    //Attempted to resume connection, but session failed.

                    sessionID = null;
                    authenticate();
                    break;

                case "0":
                    //A discord event update.

                    //This event can have lots of different data in it, send to specific method
                    discordEventUpdate((string)message["t"], (JObject)message["d"]);
                    break;
            }
        }

        private void discordEventUpdate(string type, JObject data)
        {
            switch(type)
            {
                case "READY":
                    //Sent after authorization was successful.
                    string username = (string)data["user"]["username"];

                    //If disconnected, can use this to reestablish current session
                    sessionID = (string)data["session_id"];

                    informFormConnectionStatus("Discord authentication successful.");

                    informFormConnectionStatus("Entered discord as " + username + ". Ready.");

                    break;

                case "MESSAGE_CREATE":
                    //A chat message has arrived.

                    string author = (string)data["author"]["username"];
                    string message = (string)data["content"];

                    informFormDiscordMessage(author, message);


                    break;
            }
        }

        private void timerTick(object sender, EventArgs e)
        {
            //Timer has ticked. Send heartbeat.
            JObject data = new JObject();
            data["op"] = 1;
            data["d"] = Convert.ToInt32(sequenceNumber);

            client.Send(data.ToString(Formatting.None));
        }

        private void authenticate()
        {
            //If there is no sessionID, authenticate normally. Otherwise, send RESUME

            JArray shards;
            JObject data;
            JObject header;

            if (sessionID == null)
            {

                shards = new JArray();
                shards.Add(0);
                shards.Add(1);

                data = new JObject();

                //Fill in the data to send to authenticate.
                data["token"] = Properties.Settings.Default.discordToken;
                data["properties"] = new JObject();

                //Fill in basic properties about the client (not sure if required??)
                data["properties"]["$os"] = "windows";
                data["properties"]["$browser"] = "ffxivDiscordBot";
                data["properties"]["$device"] = "ffxivDiscordBot";
                data["properties"]["$referrer"] = "";
                data["properties"]["$referring_domain"] = "";

                data["compress"] = false; //Send in plain text, do not compress
                data["large_threshold"] = 100;
                data["shard"] = shards;

                //Make the header and insert the data
                header = new JObject();
                header["op"] = 2;
                header["d"] = data;

            } else {

                data = new JObject();
                data["token"] = Properties.Settings.Default.discordToken;
                data["session_id"] = sessionID;
                data["seq"] = Convert.ToInt32(sequenceNumber);

                header = new JObject();
                header["op"] = 6;
                header["d"] = data;

            }


            client.Send(header.ToString(Formatting.None));

        }

        private void onDisconnect(ushort code, string reason)
        {
            informFormConnectionStatus("Disconnected from server (" + code + "): " + reason);

            if (heartBeatTimer != null) heartBeatTimer.Stop();

            if (reconnect) client.Connect();
        }

        public void sendChatMessage(string message, bool tts, string channelID)
        {
            HTTPRequest request = new HTTPRequest();

            string url = "https://discordapp.com/api/channels/" + channelID + "/messages";

            JObject data = new JObject();

            data["content"] = message;
            data["tts"] = tts;

            string authorization = "Bot " + Properties.Settings.Default.discordToken;

            request.postRequest(url, data.ToString(Formatting.None), authorization);
        }

        public void connect()
        {
            informFormConnectionStatus("Connecting...");

            reconnect = Properties.Settings.Default.reconnect;
            client.Connect();
        }

        public void disconnect()
        {
            reconnect = false;
            if (heartBeatTimer != null) heartBeatTimer.Stop();
            sessionID = null;
            client.Close();
        }
    }
}
