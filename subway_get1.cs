using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string shumi1 = GetQuestData(1001200);
		
		if (ItemCount(4031039) >= 1)
		{
			self.say("You already have the coin. You search some more and can't find anything.");
			
			ChangeMap(103000100);
			return;
		}
		
		if (shumi1 == "s" || shumi1 == "g")
		{
			if (!Exchange(0, 4031039, 1))
			{
				self.say("Looking carefully into #p1052008#, there seems to be a shiny object inside but since your etc. inventory is full, that item is unattainable.");
				return;
			}
			
			if (shumi1 == "s") SetQuestData(1001200, "g");
			self.say("Looking carefully into #p1052008#, there seems to be a shiny object inside. Reached in it with a hand and was able to attain a small coin.");
			
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
			
			if (shumi1 == "end") itemNum = 2;
			else itemNum = 1;
			
			Random rnd = new Random();
			int[] ores = {4010000, 4010001, 4010002, 4010003, 4010004, 4010005};
			
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