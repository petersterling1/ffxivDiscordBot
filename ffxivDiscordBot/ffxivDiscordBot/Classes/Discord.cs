using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace ffxivDiscordBot
{
    class Discord
    {
        private WebSocket client = null;
        private bool reconnect;
        private string sequenceNumber = null;
        private System.Timers.Timer heartBeatTimer = null;

        //TODO: Get the discord gateway dynamically
        private string gateway = "wss://gateway.discord.gg?v=5&encoding=json";


        public Discord()
        {
            client = new WebSocket(gateway);

            client.OnMessage += (s, e) => 
                onMessageRecieved(e.Data);

            client.OnClose += (s, e) =>
                onDisconnect(e.Code, e.Reason);

            client.OnError += (s, e) =>
                onError(e.Message);

            client.OnOpen += (s, e) =>
                onOpen();
        }

        private void onError(string message)
        {

        }

        private void onOpen()
        {

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

                case "0":
                    //A discord event update.

                    break;
            }
        }

        private void timerTick(object sender, EventArgs e)
        {
            //Timer has ticked. Send heartbeat.
            JObject data = new JObject();
            data["op"] = 1;
            data["d"] = sequenceNumber;

            client.Send(data.ToString(Formatting.None));
        }

        private void authenticate()
        {
            JArray shards = new JArray();
            shards.Add(0);
            shards.Add(1);

            JObject data = new JObject();

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
            JObject header = new JObject();
            header["op"] = 2;
            header["d"] = data;


            client.Send(header.ToString(Formatting.None));

        }

        private void onDisconnect(ushort code, string reason)
        {
            if (heartBeatTimer != null) heartBeatTimer.Stop();
            if (reconnect) client.Connect();
        }

        public void connect()
        {
            reconnect = Properties.Settings.Default.reconnect;
            client.Connect();
        }

        public void disconnect()
        {
            reconnect = false;
            client.Close();
        }
    }
}
