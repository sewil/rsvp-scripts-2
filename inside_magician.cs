using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (Job == 200 && Level >= 30)
		{
			if (ItemCount(4031013) >= 30)
			{
				self.say("Ohhhhh... you collected all 30 #t4031013#s!! Should have been difficult... incredible. Alright. You've passed the test and for that, I'll reward you with #b#t4031012##k. Take that item and go back to #m101000000#.");
				
				int marble = ItemCount(4031013);
				
				if (!Exchange(0, 4031013, -marble, 4031009, -1, 4031012, 1))
				{
					self.say("Hmmm... please check and see if you 30 #t4031013#s, the letter from #b#p1032001##k, and if you have an empty slot on your Etc. inventory.");
					return;
				}
			}
			else
			{
				bool askExit = AskYesNo("Hmmm... what's going on? Doesn't look like you have collected 30 #b#t4031013#s#k yet... If you're having problems with it, you can leave, come back and try it again. So... wanna give up and get out of here?");
				
				if (!askExit)
				{
					self.say("That's right! Stop complaining and start collecting the marbles. Come talk to me when you have collected 30 #b#t4031013#s#k.");
					return;
				}
				
				self.say("Really... alright, I'll let you out. Please don't give up, though. You can always try again, so do not give up. Until then, bye...");
			}
		}
		else
		{
			self.say("What? How did you get here..? How strange... well, I'll let you out. This is a very dangerous place. Leave or you'll be at risk.");
		}
		
		ChangeMap(101020000);
	}
}