using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(1000700);
		string quest2 = GetQuestData(1000701);
		
		if (Level < 50)
		{
			self.say("In the midst of the pile of herbs, you will find roots with a mysterious energy, but a strange aura around them makes it impossible to take them.");
			return;
		}
		
		if (quest2 == "")
		{
			self.say("In the midst of the pile of herbs you will find roots with a mysterious energy, but since there has been no explanation from #b#p1061005##k about them, there is no way to know which root to take...");
		}
		else if (quest2 == "2_00" || quest2 == "2_99")
		{
			if (SlotCount(1) < 1 || SlotCount(4) < 1)
			{
				self.say("You need to create some space for your equipment and etc. inventories so that you can get the items you find in the pile of herbs. Please check again after making the adjustment.");
				return;
			}
			
			Random rnd = new Random();
			
			int rnum = rnd.Next(1, 31);
			
			int newItemID = 0;
			int itemNumber = 0;
			
			if(rnum > 0 && rnum < 11)
			{
				newItemID = 4020007;
				itemNumber = 2;
			}
			else if(rnum > 10 && rnum < 21)
			{
				newItemID = 4020008;
				itemNumber = 2;
			}
			else if(rnum > 20 && rnum < 30)
			{
				newItemID = 4010006;
				itemNumber = 2;
			}
			else if (rnum == 30)
			{
				newItemID = 1032013;
				itemNumber = 1;
			}
			
			if (!Exchange(0, newItemID, itemNumber))
			{
				self.say("Your equipment and etc. inventories are full, which prevents you from accepting the items. You need to free up space in your equip. and etc. inventory.");
				return;
			}
			
			ChangeMap(101000000);
		}
		else
		{
			int herb2 = Int32.Parse(GetQuestData(1101));
			
			int[] herb = {4031029, 4031030, 4031031, 4031032, 4031033};
			string[] info = {"1", "2", "3", "1", "2"};
			
			int askHerb = 0;
			
			if (quest1 == "1_00")
			{
				askHerb = AskMenu("In the midst of the pile of herbs, you find roots with a mysterious energy. Which one would you like to take?#b",
					(3, " #t4031032#"),
					(4, " #t4031033#"));
			}
			else if (quest1 == "1_99")
			{
				askHerb = AskMenu("In the midst of the pile of herbs, you find roots with a mysterious energy. Which one would you like to take?#b",
					(0, " #t4031029#"),
					(1, " #t4031030#"),
					(2, " #t4031031#"));
			}
				
			int item = herb[askHerb];
			
			bool askTake = AskYesNo($"Are you sure you want to take #b#t{item}##k with you?");
			
			if (askTake)
			{
				string newInfo = "";
				
				if (quest1 == "1_00")
				{
					if (item == herb2) newInfo = "2_1" + info[askHerb];
					else newInfo = "2_9" + info[askHerb];
				}
				else if (quest1 == "1_99")
				{
					if (item == herb2) newInfo = "2_6" + info[askHerb];
					else newInfo = "2_8" + info[askHerb];
				}
				
				if (!Exchange(0, item, 1))
				{
					self.say("Your etc. inventory seems to be full. Please free up space to take the item.");
					return;
				}
				
				SetQuestData(1000701, newInfo);
				ChangeMap(101000000);
			}
		}
	}
}