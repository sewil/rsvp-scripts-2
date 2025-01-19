using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1000901);
		
		if (quest == "")
		{
			self.say("Many flowers are blooming around here, except for the #b#t4031026##k");
		}
		else if (quest == "end")
		{
			if (SlotCount(4) >= 1)
			{
				Random rnd = new Random();
				int[] reward = {4020000, 4020001, 4020002, 4020003, 4020004, 4020005, 4020006};
				
				int itemID = reward[rnd.Next(reward.Length)];
				
				if (!Exchange(0, itemID, 2))
				{
					self.say("Your etc. inventory is full, so you can't pick up any more items here. Please leave at least one slot empty.");
					return;
				}
				
				ChangeMap(105040300);				
			}
		}
		else
		{
			if (ItemCount(4031026) > 0)
			{
				self.say("Many #b#t4031026#s#k are blooming, but you already have some, so you can't take any more. You need to take the flowers to John of #m104000000#.");
				return;
			}
			
			Random rnd = new Random();
			
			int count = rnd.Next(1, 21);
			
			if (!Exchange(0, 4031026, count))
			{
				self.say("Sorry, but your etc. inventory is full, so you can't pick any flowers. Leave at least one slot empty for the flowers.");
				return;
			}
			
			ChangeMap(105040300);
		}
	}
}