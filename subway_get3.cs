using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string shumi3 = GetQuestData(1001202);
		
		if (ItemCount(4031041) >= 1)
		{
			self.say("You already have the sack of cash. You search some more and can't find anything.");
			
			ChangeMap(103000100);
			return;
		}
		
		if (shumi3 == "s" || shumi3 == "g")
		{
			if (!Exchange(0, 4031041, 1))
			{
				self.say("Looking carefully into #p1052008#, there seems to be a shiny object inside but since your etc. inventory is full, that item is unattainable.");
				return;
			}
			
			if (shumi3 == "s") SetQuestData(1001202, "g");
			self.say("Looking carefully into #p1052008#, there seems to be a bag of something that contains a shiny object. Reached in it with a hand and got a heavy sack of cash.");
			
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
			
			if (shumi3 == "end") itemNum = 2;
			else itemNum = 1;
			
			Random rnd = new Random();
			int[] ores = {4010006, 4020007, 4020008};
			
			int itemID = ores[rnd.Next(ores.Length)];
			
			if (!Exchange(0, itemID, itemNum))
			{
				self.say("Looking carefully into #p1052008#, there seems to be something there but since your etc. inventory is full, that item is unattainable. Free up space for the item and come back.");
				return;
			}
			
			ChangeMap(103000100);
		}
	}
}