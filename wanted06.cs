using System;
using WvsBeta.Game;

// 1063009 Wanted : Jr. Boogie
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1008300);
		
		if (Level >= 33)
		{
			if (quest == "")
			{
				bool start = AskYesNo("Eliminate these and then bring 10 horns back here with you. To me... \n#rThe Rememberer#k");
				
				if (start)
				{
					SetQuestData(1008300, "s");
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