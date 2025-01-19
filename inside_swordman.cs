using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (Job == 100 && Level >= 30)
		{
			if (ItemCount(4031013) >= 30)
			{
				self.say("Ohhhhh... you collected all 30 #t4031013#s!! It should have been difficult... just incredible! Alright. You've passed the test and for that, I'll reward you #b#t4031012##k. Take that and go back to #m102000000#.");
				
				int marble = ItemCount(4031013);
				
				if (!Exchange(0, 4031013, -marble, 4031008, -1, 4031012, 1))
				{
					self.say("Something's not right... please check and see if you 30 #t4031013#s, the letter from #b#p1022000##k, and if you have an empty slot on your Etc. inventory.");
					return;
				}
			}
			else
			{
				bool askExit = AskYesNo("What's going on? Doesn't look like you have collected 30 #b#t4031013#s#k yet... If you're having problems with it, you can leave, come back and try it again. So... wanna give up and get out of here?");
				
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
		
		ChangeMap(102020300);
	}
}