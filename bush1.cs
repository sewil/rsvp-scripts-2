using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1000700);
		
		if (Level < 25)
		{
			self.say("In the midst of these flowers you will find some with a mysterious aura around them. You will not be able to pick them because of the aura that surrounds them.");
			return;
		}
		
		if (quest == "")
		{
			self.say("In the midst of all these flowers you find some with a mysterious aura around them, but you won't be able to take them because you haven't heard the explanation from \r\n#b#p1061005##k about which to pick...");
		}
		else if (quest == "1_00" || quest == "1_99")
		{
			if (SlotCount(4) < 1)
			{
				self.say("You must have at least one slot empty in your etc. inventory to store the item you found in the middle of the flowers. Free up space and then try again.");
				return;
			}
			
			Random rnd = new Random();
			int[] reward = {4010000, 4010001, 4010002, 4010003, 4010004, 4010005, 4020000, 4020001, 4020002, 4020003, 4020004, 4020005, 4020006};
			
			int itemID = reward[rnd.Next(reward.Length)];
			
			if (!Exchange(0, itemID, 2))
			{
				self.say("Your etc. inventory seems to be full. Please free up space to take the item.");
				return;
			}
			
			ChangeMap(101000000);
		}
		else
		{
			int herb1 = Int32.Parse(GetQuestData(1100));
			
			int[] herb = {4031020, 4031021, 4031022, 4031023};
			string[] info = {"1", "2", "3", "4"};
			
			int askHerb = AskMenu("In the midst of all these flowers you find some with a mysterious aura around them. Which one would you like to take?#b",
				(0, " #t4031020#"),
				(1, " #t4031021#"),
				(2, " #t4031022#"),
				(3, " #t4031023#"));
				
			int item = herb[askHerb];
			
			bool askTake = AskYesNo($"Are you sure you want to take #b#t{item}##k with you?");
			
			if (askTake)
			{
				string newInfo;
				
				if (item == herb1) newInfo = "1_1" + info[askHerb];
				else newInfo = "1_9" + info[askHerb];
				
				if (!Exchange(0, item, 1))
				{
					self.say("Your etc. inventory seems to be full. Please free up space to take the item.");
					return;
				}
				
				SetQuestData(1000700, newInfo);
				ChangeMap(101000000);
			}
		}
	}
}