# ffxivDiscordBot
ffxivDiscordBot is a Discord bot developed in .NET intended for use by FFXIV players. It is licensed under the GNU General Public License.

## Current Features
* Connects to Discord and sits in a chat channel responding to player commands
* Can query data from FFLogs to show DPS/HPS parses and player rankings

## Current Command List
All commands must be prefaced by the command trigger which can be changed in the settings panel. All commands may be triggered by sending a message in the chat channel the bot is currently in.

### encounter \<encounter\> \<optional: server> \<optional: metric\> \<optional: class\> \<optional: amount\>
Prints the top parses for the encounter given from FFLogs to Discord.

* **encounter**: Which fight to get parses from. eg: a12s
* **server**: What server to get parses from. If no server is given, all servers will be queried. "all" may also be supplied as a server if you wish to use the other arguments after this but want parses from all servers.
* **metric**: Which metric you wish to query for. If no metric is given, dps is the default. Valid metrics are 'dps', 'hps', or 'speed'.
* **class**: Which job you wish to see parses for. eg. 'whm'. If you wish to see parses for all jobs, "all" may be supplied.
* **amount**: How many rankings you wish to return. If none is given, the top 10 will be returned.

### ranking \<first name\> \<last name\> \<server\> \<optional: metric\> 
Returns the ranking from the current raid tier for a specific character.

* **first name**: The first name of the character.
* **last name**: The last name of the character.
* **server**: The server the character is from.
* **metric**: Which metric you wish to see the ranking for. If none is specified, dps is the default. Valid metrics are 'dps' and 'hps'.
