using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string shumi2 = GetQuestData(1001201);
		
		if (ItemCount(4031040) >= 1)
		{
			self.say("You already have the stack of cash. You search some more and can't find anything.");
			
			ChangeMap(103000100);
			return;
		}
		
		if (shumi2 == "s" || shumi2 == "g")
		{
			if (!Exchange(0, 4031040, 1))
			{
				self.say("Looking carefully into #p1052008#, there seems to be a stack of papers inside but since your etc. inventory is full, that item is unattainable.");
				return;
			}
			
			if (shumi2 == "s") SetQuestData(1001201, "g");
			self.say("Looking carefully into #p1052008#, there seems to be a stack of papers inside. Reached in it with a hand and... aha! A huge pile of cash.");
			
			ChangeMap(103000100);
		}
		else
		{
			if (SlotCount(4) < 1)
			{
				self.say("You can't take the item you found because your etc. inventory is full. Free up space for the item and come back.");
				return;
			}
			
			int itemNum = 0;
			
			if (shumi2 == "end") itemNum = 2;
			else itemNum = 1;
			
			Random rnd = new Random();
			int[] ores = {4020000, 4020001, 4020002, 4020003, 4020004, 4020005, 4020006};
			
			int itemID = ores[rnd.Next(ores.Length)];
			
			if (!Exchange(0, itemID, itemNum))
			{
				self.say("Looking carefully into #p1052008#, there seems to be a shiny object but since your etc. inventory is full, that item is unattainable. Free up space in your etc. inventory and come back.");
				return;
			}
			
			ChangeMap(103000100);
		}
	}
}