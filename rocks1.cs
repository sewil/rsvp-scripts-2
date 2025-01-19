using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (!CharacterInArea(chr, "end"))
		{
			Message("I'm too far away to reach it.");
			return;
		}
		
		string quest = GetQuestData(1000103);
		
		if (quest == "")
		{
			self.say("It's a pile of rocks. You search around inside but you don't find anything.");
		}
		else if (quest == "e")
		{
			if (SlotCount(4) >= 1)
			{
				Random rnd = new Random();
				int[] reward = {4010006, 4020007, 4020008};
				
				int itemID = reward[rnd.Next(reward.Length)];
				
				if (!Exchange(0, itemID, 3))
				{
					self.say("Your etc. inventory is full, so you can't pick up any more items here. Please leave at least one slot empty.");
					return;
				}
				
				ChangeMap(102000000);				
			}
		}
		else
		{
			var rnd = new Random();
			
			int count = rnd.Next(1, 11);
			
			if (!Exchange(0, 4031142, count))
			{
				self.say("Sorry, but your etc. inventory is full, so you can't pick up anything here.");
				return;
			}
			
			ChangeMap(102000000);
		}
	}
}