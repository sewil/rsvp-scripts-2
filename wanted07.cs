using System;
using WvsBeta.Game;

// 1063006 Wanted : Cold Eye
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1008400);
		
		if (Level >= 35)
		{
			if (quest == "")
			{
				bool start = AskYesNo("Eliminate these and then bring 100 tails back here with you. To me... \n#rThe Rememberer#k");
				
				if (start)
				{
					SetQuestData(1008400, "s");
					self.say("Make sure to report to #rThe Rememberer#k of the result after eliminating the monsters!");
				}
			}
			else if (quest == "s")
			{
				self.say("Report your work to #rThe Rememberer#k!");
			}
		}
	}
}