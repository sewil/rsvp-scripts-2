using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string warp = GetQuestData(9000200);
		
		if (warp == "0")
		{
			bool askExit = AskYesNo("You don't have anything else to do here, huh? Do you wish to go back to #m101000000# of Victoria Island? If so, I can send you back to #m101000000# right this minute. What do you think? Do you want to go back?");
			
			if (!askExit)
			{
				self.say("You still have some business to take care of here, right? It's not bad of an idea to chill around this area and regain full strength before going back out there.");
				return;
			}
		}
		else if (warp == "1")
		{
			bool askExit = AskYesNo("You don't have anything else to do here, huh? Do you wish to go back to #m211000000# of Ossyria? If so, I can send you back to #m211000000# right this minute. What do you think? Do you want to go back?");
			
			if (!askExit)
			{
				self.say("You still have some business to take care of here, right? It's not bad of an idea to chill around this area and regain full strength before going back out there.");
				return;
			}
		}
		else if (warp == "2")
		{
			bool askExit = AskYesNo("You don't have anything else to do here, huh? Do you wish to go back to #m220000000# in Ossyria? If so, I can send you back to #m220000000# right this minute. What do you think? Do you want to go back?");
			
			if (!askExit)
			{
				self.say("You still have some business to take care of here, right? It's not bad of an idea to chill around this area and regain full strength before going back out there.");
				return;
			}
		}
		else
		{
			bool askExit = AskYesNo("You don't have anything else to do here, huh? Do you wish to go back to #m100000000# of Victoria Island? If so, I can send you back to #m100000000# right this minute. What do you think? Do you want to go back?");
			
			if (!askExit)
			{
				self.say("You still have some business to take care of here, right? It's not bad of an idea to chill around this area and regain full strength before going back out there.");
				return;
			}
		}
		
		if (warp == "0") ChangeMap(101000000);
		else if (warp == "1") ChangeMap(211000000);
		else if (warp == "2") ChangeMap(220000400);
		else ChangeMap(100000000);
	}
}