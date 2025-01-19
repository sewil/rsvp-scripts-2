using System;
using WvsBeta.Game;

// 1063007 Wanted : Z. Mushroom
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(1008000);
		string quest2 = GetQuestData(1008001);
		string lastDate = GetQuestData(1008002);
		string today = DateTime.UtcNow.ToString("yyyyMMdd");
		
		if (Level >= 22)
		{
			if (quest1 == "")
			{
				bool start = AskYesNo("Eliminate 99 of these! #r - #p1061011# -");
				
				if (start)
				{
					SetQuestData(1008000, "099");
					self.say("Make sure to report to #r#p1061011##k of the result after eliminating the monsters!");
				}
			}
			else if (quest1 == "e")
			{
				if (lastDate != today)
				{
					if (quest2 == "" || quest2 == "e")
					{
						bool start2 = AskYesNo("Eliminate 999 of these! #r - #p1061011# - ");
						
						if (start2)
						{
							SetQuestData(1008001, "999");
							self.say("Once your eliminate the monster with your guild mates, make sure to report this to #r#p1061011##k!");
						}
					}
					else
					{
						self.say("Make sure to report to #rThe Rememberer#k of the result after eliminating the monsters!");
					}
				}
			}
			else
			{
				self.say("Make sure to report to #rThe Rememberer#k of the result after eliminating the monsters!");
			}
		}
	}
}