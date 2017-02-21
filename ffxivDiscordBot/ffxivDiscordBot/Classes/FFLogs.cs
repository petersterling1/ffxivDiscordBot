using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffxivDiscordBot
{
    class FFLogs
    {
        private Dictionary<string, int> encounterTable = new Dictionary<string, int>();
        private Dictionary<int, string> classTable = new Dictionary<int, string>();
        private Dictionary<string, string> regionTable = new Dictionary<string, string>();
        private Dictionary<string, int> reverseClassTable = new Dictionary<string, int>();

        private string formatNiceStr(string input)
        {
            if (String.IsNullOrEmpty(input) || input.Length < 2) return input;

            input = input.ToLower();

            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        private String getEncounterName(int id)
        {
            foreach (KeyValuePair<String, int> entry in encounterTable)
            {
                if (entry.Value == id) return entry.Key;
            }

            return "Unknown";
        }

        public string getPlayerRanking(string request)
        {
            string[] parsed = request.Split(' ');

            if (parsed.Count() != 3 && parsed.Count() != 4) return "Invalid number of arguments. Expecting 3";

            string firstName = parsed[0].ToLower();
            string lastName = parsed[1].ToLower();
            string server = parsed[2].ToLower();
            string metric = "";
            string readableMetric = "DPS";

            if(parsed.Count() == 4)
            {
                metric = parsed[3].ToLower();
                if(metric == "dps")
                {
                    readableMetric = "DPS";
                    metric = "&metric=dps";
                }
                else if(metric == "hps")
                {
                    readableMetric = "HPS";
                    metric = "&metric=hps";
                }
                else
                {
                    return "Invalid metric given. Can be either 'dps' or 'hps'";
                }
            }

            if (!regionTable.ContainsKey(server)) return "Invalid server given";

            string url = "https://www.fflogs.com/v1/rankings/character/" + firstName + "%20" + lastName + "/" + server + "/" + regionTable[server.ToLower()] + "?api_key=" + Properties.Settings.Default.fflogsToken + metric;

            Console.WriteLine(url);

            HTTPRequest h = new HTTPRequest();
            string response = h.getRequest(url);
            string returnText = "";

            Console.WriteLine(response);

            try
            {
                JObject jO = JObject.Parse(response);
                if (jO["status"] != null) return (string)jO["error"];
            }
            catch
            {
            }

            List<Dictionary<string, string>> encounters = JsonConvert.DeserializeObject<List<Dictionary<string, string>>> (response);

            if (encounters.Count == 0) return "No parses found for that character in the current raid tier.";

            returnText = formatNiceStr(firstName) + " " + formatNiceStr(lastName) + " (" + formatNiceStr(server) + ")\n";
            returnText += "Showing top parses for current raid tier.\n----------------------------------------\n";

            for(int i=0; i<encounters.Count(); i++)
            {
                returnText += formatNiceStr(getEncounterName(Int32.Parse(encounters[i]["encounter"]))) + " - " + encounters[i]["total"] + " " + readableMetric + " (" + classTable[Int32.Parse(encounters[i]["spec"])] + ") -- Ranked " + encounters[i]["rank"] + " out of " + encounters[i]["outOf"] + "\n";
            }

            return returnText;
        }

        public string getEncounterLeaderboard(string request)
        {
            string[] parsed = request.Split(' ');

            string regionData = "";
            string regionReadable = "";
            string limit = "10";
            string metric = "";
            string metricReadable = "DPS";
            string parsecheck = "";
            string classpecific = "";

            if (parsed.Count() == 5)
            {
                int result;
                limit = parsed[4];
                if (!Int32.TryParse(limit, out result)) return "Invalid number of results given";
            }

            if (parsed.Count() >= 4 && parsed[3].ToLower() != "all")
            {

                if (!reverseClassTable.ContainsKey(parsed[3].ToLower())) return "Invalid class given.";

                classpecific = "&spec=" + reverseClassTable[parsed[3].ToLower()];
            }

            if(parsed.Count() >= 3)
            {
                parsecheck = parsed[2].ToLower();
                if(parsecheck == "dps")
                {
                    metricReadable = "DPS";
                    metric = "&metric=dps";
                }
                else if(parsecheck == "hps")
                {
                    metricReadable = "HPS";
                    metric = "&metric=hps";
                }
                else if(parsecheck == "speed")
                {
                    metricReadable = "seconds";
                    metric = "&metric=speed";
                }else
                {
                    return "Invalid player metric given. Must be 'dps', 'hps', or 'speed'";
                }

            }

            if(parsed.Count() >= 2 && parsed[1].ToLower() != "all")
            {
                if (!regionTable.ContainsKey(parsed[1].ToLower())) return "Invalid server given";

                regionData = "&server=" + parsed[1].ToLower() + "&region=" + regionTable[parsed[1].ToLower()];
                regionReadable = "(" + formatNiceStr(parsed[1].ToLower()) + ")";
            }else
            {
                regionReadable = "(All Servers)";
            }

            if (!encounterTable.ContainsKey(parsed[0].ToLower())) return "Invalid encounter given";

            string url = "https://www.fflogs.com/v1/rankings/encounter/" + encounterTable[parsed[0]] + "?api_key=" + Properties.Settings.Default.fflogsToken + "&limit=" + limit + regionData + metric + classpecific;

            Console.WriteLine(url);

            HTTPRequest h = new HTTPRequest();
            string response = h.getRequest(url);

            JObject j;

            try
            {
                 j = JObject.Parse(response);
            } catch
            {
                return "Bad response from FFLogs";
            }

            string returnString = "";

            JArray jA = (JArray)j["rankings"];

            returnString = formatNiceStr(parsed[0]) + " - Top " + jA.Count() + " " + regionReadable + "\n";
            returnString += "----------------------------\n";

            for(int i=0; i<jA.Count(); i++)
            {
                if(parsecheck == "speed")
                {
                    TimeSpan t;
                    t = TimeSpan.FromMilliseconds(Double.Parse((string) jA[i]["duration"]));
                    jA[i]["total"] = t.Minutes + "min, " + t.Seconds + "sec";
                    metricReadable = "";
                    returnString += (i + 1) + ". " + jA[i]["guild"] + " (FC) - " + (string)jA[i]["total"] + " " + metricReadable + " (" + (string)jA[i]["server"] + ")\n";
                }
                else
                {
                    returnString += (i + 1) + ". " + jA[i]["name"] + " (" + classTable[(int)jA[i]["spec"]] + ") - " + (float)jA[i]["total"] + " " + metricReadable + " (" + (string)jA[i]["server"] + ")\n";
                }
            }

            return returnString;
        }

        public FFLogs()
        {
            //Initialize region lookup table
            regionTable["adamantoise"] = "NA";
            regionTable["balmung"] = "NA";
            regionTable["behemoth"] = "NA";
            regionTable["brynhildr"] = "NA";
            regionTable["cactuar"] = "NA";
            regionTable["coeurl"] = "NA";
            regionTable["diabolos"] = "NA";
            regionTable["excalibur"] = "NA";
            regionTable["exodus"] = "NA";
            regionTable["faerie"] = "NA";
            regionTable["famfrit"] = "NA";
            regionTable["gilgamesh"] = "NA";
            regionTable["goblin"] = "NA";
            regionTable["hyperion"] = "NA";
            regionTable["jenova"] = "NA";
            regionTable["lamia"] = "NA";
            regionTable["leviathan"] = "NA";
            regionTable["malboro"] = "NA";
            regionTable["mateus"] = "NA";
            regionTable["midgardsormr"] = "NA";
            regionTable["sargatanas"] = "NA";
            regionTable["siren"] = "NA";
            regionTable["ultros"] = "NA";
            regionTable["zalera"] = "NA";

            //Initialize encounter IDs
            encounterTable["cetus"] = 2000;
            encounterTable["irminsul"] = 2001;
            encounterTable["cuchulainn"] = 2002;
            encounterTable["echidna"] = 2003;
            encounterTable["arachne"] = 2004;
            encounterTable["forgall"] = 2005;
            encounterTable["ozma"] = 2006;
            encounterTable["calofisteri"] = 2007;

            encounterTable["bismarck"] = 1027;
            encounterTable["ravana"] = 1028;
            encounterTable["thordan"] = 1029;
            encounterTable["sephirot"] = 1031;
            encounterTable["sephiroth"] = 1031;
            encounterTable["nidhogg"] = 1033;
            encounterTable["sophia"] = 1034;
            encounterTable["zurvan"] = 1035;

            encounterTable["a1"] = 14;
            encounterTable["a2"] = 15;
            encounterTable["a3"] = 16;
            encounterTable["a4"] = 17;
            encounterTable["a1s"] = 18;
            encounterTable["a2s"] = 19;
            encounterTable["a3s"] = 20;
            encounterTable["a4s"] = 21;
            encounterTable["a5"] = 22;
            encounterTable["a6"] = 23;
            encounterTable["a7"] = 24;
            encounterTable["a8"] = 25;
            encounterTable["a5s"] = 26;
            encounterTable["a6s"] = 27;
            encounterTable["a7s"] = 28;
            encounterTable["a8s"] = 29;
            encounterTable["a9"] = 30;
            encounterTable["a10"] = 31;
            encounterTable["a11"] = 32;
            encounterTable["a12"] = 33;
            encounterTable["a9s"] = 34;
            encounterTable["a10s"] = 35;
            encounterTable["a11s"] = 36;
            encounterTable["a12s"] = 37;
            encounterTable["faustz"] = 5008;

            //Initialize class IDs
            classTable[1] = "Astrologian";
            classTable[2] = "Bard";
            classTable[3] = "Black Mage";
            classTable[4] = "Dark Knight";
            classTable[5] = "Dragoon";
            classTable[6] = "Machinist";
            classTable[7] = "Monk";
            classTable[8] = "Ninja";
            classTable[9] = "Paladin";
            classTable[10] = "Scholar";
            classTable[11] = "Summoner";
            classTable[12] = "Warrior";
            classTable[13] = "White Mage";

            //Intialize reverse class lookup
            reverseClassTable["astrologian"] = 1;
            reverseClassTable["astro"] = 1;
            reverseClassTable["bard"] = 2;
            reverseClassTable["brd"] = 2;
            reverseClassTable["blackmage"] = 3;
            reverseClassTable["blm"] = 3;
            reverseClassTable["drk"] = 4;
            reverseClassTable["darkknight"] = 4;
            reverseClassTable["drg"] = 5;
            reverseClassTable["dragoon"] = 5;
            reverseClassTable["machinist"] = 6;
            reverseClassTable["mch"] = 6;
            reverseClassTable["mnk"] = 7;
            reverseClassTable["monk"] = 7;
            reverseClassTable["nin"] = 8;
            reverseClassTable["ninja"] = 8;
            reverseClassTable["pld"] = 9;
            reverseClassTable["paladin"] = 9;
            reverseClassTable["scholar"] = 10;
            reverseClassTable["sch"] = 10;
            reverseClassTable["smn"] = 11;
            reverseClassTable["summoner"] = 11;
            reverseClassTable["war"] = 12;
            reverseClassTable["warrior"] = 12;
            reverseClassTable["whm"] = 13;
            reverseClassTable["whitemage"] = 13;
        }



    }
    
}
