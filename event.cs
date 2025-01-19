using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private static readonly string[] EventNames = {"Ola Ola 1", "Ola Ola 2", "Ola Ola 3", "Ola Ola 4", "Ola Ola 5", "MapleStory Physical Fitness Test", "OX Quiz", "Coconut Harvest 1", "Coconut Harvest 2", "Coconut Harvest 3", "Cokeplay Harvest 1", "Cokeplay Harvest 2", "Cokeplay Harvest 3", "Snowball", "Treasure Hunt", "Toy Castle Climb", "Alien Hunt", "Halloween Hunt (Halloween only)"};
	private static readonly int[] EventMaps = {109030001, 109030101, 109030201, 109030301, 109030401, 109040000, 109020001, 109080000, 109080001, 109080002, 109080010, 109080011, 109080012, 109060001, 109010000, 109090000, 109100001, 109110001};
	private static readonly int[] EventCounts = {80, 80, 80, 80, 80, 70, 90, 60, 60, 60, 60, 60, 60, 80, 60, 70, 60, 60};
	
	public override void Run()
	{
		NpcID = 9010000;
		
		string EventName = GetNpcVar(180000000, 9900000, "event", "none");
		string EventMap = GetNpcVar(180000000, 9900000, "map", "-1");
		string EventCount = GetNpcVar(180000000, 9900000, "count", "0");
		
		int start = -1;
		
		if (EventName == "none")
		{
			start = AskMenu("Hi GM! No events are currently enabled. What would you like to do?#b",
				(5, " Start field event"),
				(0, " Enable an event map"),
				(4, " Please tell me how to host an event"));
		}
		else
		{
			start = AskMenu($"Hi GM! #b{EventName}#k is currently enabled in map {EventMap}. What would you like to do?",
				(1, " #rDisable event entry#b\r\n"),
				(2, " Go to the event map"),
				(3, " Check the number of users in the event map"),
				(4, " Please tell me how to host an event"));
		}
		
		if (start == 0)
		{
			int selectEvent = AskMenu("Select an event.#b",
				(0, " Ola Ola 1 ( 109030001 )"),
				(1, " Ola Ola 2 ( 109030101 )"),
				(2, " Ola Ola 3 ( 109030201 )"),
				(3, " Ola Ola 4 ( 109030301 )"),
				(4, " Ola Ola 5 ( 109030401 )"),
				(5, " MapleStory Physical Fitness Test ( 109040000 )"),
				(6, " OX Quiz ( 109020001 )"),
				(7, " Coconut Harvest 1 ( 109080000 )"),
				(8, " Coconut Harvest 2 ( 109080001 )"),
				(9, " Coconut Harvest 3 ( 109080002 )"),
				(10, " Cokeplay Harvest 1 ( 109080010 )"),
				(11, " Cokeplay Harvest 2 ( 109080011 )"),
				(12, " Cokeplay Harvest 3 ( 109080012 )"),
				(13, " Snowball ( 109060001 )"),
				(14, " Treasure Hunt ( 109010000 )"),
				(15, " Toy Castle Climb ( 109090000 )"),
				(16, " Alien Hunt ( 109100001 )"),
				(17, " Halloween Hunt ( 109110001 )"));
			
			string Event = EventNames[selectEvent];
			string Map = EventMaps[selectEvent].ToString();
			string Count = EventCounts[selectEvent].ToString();
			
			bool chooseEvent = AskYesNo($"#b{Event}#k will be enabled and a notice will be sent to the channel.\r\nAre you sure you want to enable #b{Event}#k?");
			
			if (chooseEvent)
			{
				SetNpcVar(180000000, 9900000, "event", Event);
				SetNpcVar(180000000, 9900000, "map", Map);
				SetNpcVar(180000000, 9900000, "count", Count);
				
				Notice("The event is open. Please click the Event NPC to enter the Event Map.");
				
				if (AskYesNo($"{Event} is now enabled! Don't forget to disable entry before starting the event. Would you like to warp to #b#m{Map}##k?"))
				{
					ChangeMap(Int32.Parse(Map));
				}
			}
		}
		else if (start == 1)
		{
			if (AskYesNo($"Are you sure you want to disable entry to {EventName}?"))
			{
				SetNpcVar(180000000, 9900000, "event", "none");
				SetNpcVar(180000000, 9900000, "map", "-1");
				SetNpcVar(180000000, 9900000, "count", "0");
				self.say("Event entry is disabled. You can proceed with the event using the following commands:\r\n#e/eventdesc#n - Send Event description to the map\r\n#e/start#n - Start the event!");
			}
		}
		else if (start == 2)
		{
			if (AskYesNo($"Would you like to warp to #b#m{EventMap}##k?"))
			{
				ChangeMap(Int32.Parse(EventMap));
			}
		}
		else if (start == 3)
		{
			int MapCount = UserCount(Int32.Parse(EventMap));
				
			self.say($"There are currently #r{MapCount}#k players in the event map, the recommended amount is #b{EventCount}#k.");
		}
		else if (start == 4)
		{
			self.say("If you want to run an event, select [Enable an event map]. This will allow entry to the event map of your choice and it will notify all players they are able to enter. Select [Disable event entry] to stop players from joining the event.");
			self.say("You can check the number of players in the event map and how many are recommended for the event by selecting [Check the number of users in the event map].");
			self.say("When you've disabled event entry be sure to use #b/eventdesc#k to give the players instructions on how to play. After a couple seconds you can start the event with another command...");
			self.say("For #bSnowball#k and #bAlien Hunt#k, you can separate the players into teams using #b/divideteam#k, when teams have been divided and sent to the new map you can use #b/start#k to start the event. In all other events you will use #b/start#k to start the event right away.");
		}
		else if (start == 5)
		{
			if (AskYesNo($"Are you sure you want to enable a field event? This will allow instant transporation across continents. #r#eDo not#n#k forget to disable this after the event!"))
			{
				SetNpcVar(180000000, 9900000, "event", "Field Event");
				SetNpcVar(180000000, 9900000, "map", MapID.ToString());
				SetNpcVar(180000000, 9900000, "count", "any amount of");
				self.say("Field event has been started!");
			}
		}
	}
}