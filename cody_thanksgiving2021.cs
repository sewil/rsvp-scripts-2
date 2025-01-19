using System;
using System.Collections.Generic;
using WvsBeta.Game;
using WvsBeta.Common;

// 9200000 Cody
public class NpcScript : IScriptV2
{
	private void ThanksgivingYellow(string quest)
	{
		if (quest == "s")
		{
			if (ItemCount(4031416) < 1)
			{
				self.say("Hmm, looks like your bag has some lint, but no #bYellow Turkey Eggs#k! Collect some #bYellow Turkey Eggs#k and I'll make it worth your while!");
				return;
			}
			
			self.say("Excellent work! That is a fine Turkey egg you've got...in return, let me dig around in the backpack here...I think I do have something here for you...");
			
			if (SlotCount(2) < 1 || SlotCount(4) < 1)
			{
				self.say("Hey, make sure you have at least one empty slot in your use and etc. inventories!");
				return;
			}
			
			var rewards = new List<(int, int, int)> {
				(4031425, 1, 1),
				(2000004, 1, 25),
				(2020029, 1, 150),
				(2000002, 1, 50),
				(2000001, 1, 50),
				(2020030, 1, 224)
			};
			
			if (ItemCount(4031425) >= 1) rewards.Remove((4031425, 1, 1));
			
			var item = rewards.RandomElementByWeight(tuple => tuple.Item3);
			
			if (item == default)
				return;
			
			int itemID = item.Item1;
			int itemNum = item.Item2;
			
			if (!Exchange(0, 4031416, -1, itemID, itemNum))
			{
				self.say("Are you sure you brought the #bYellow Turkey Egg#k? Please check again.");
				return;
			}
			
			SetQuestData(8020017, "e");
			QuestEndEffect();
			self.say("Take this and I hope it helps out in your travels! Thank you! Find me more eggs and I'll reward you!");
		}
		else
		{
			bool start = AskYesNo("Hello there! You look like you've been out on a few adventures! I'm in dire need of some high-quality Turkey Eggs for a Thanksgiving breakfast I'm cooking. Do you have any Yellow eggs for me?");
			
			if (!start)
			{
				self.say("Oh, ok.  Be sure to come back, because I won't wait forever to get my eggs!");
				return;
			}
			
			SetQuestData(8020017, "s");
			self.say("I'm in dire need of some high-quality Turkey Eggs for a Thanksgiving breakfast I'm cooking. Will you gather some\r\n#bYellow Turkey Eggs#k for me? Yellow Turkey Eggs can be obtained from tamed turkeys. Good luck!");
		}
	}
	
	private void ThanksgivingGreen(string quest)
	{
		if (quest == "s")
		{
			if (ItemCount(4031417) < 1)
			{
				self.say("Hmm, looks like your bag has some lint, but no #bGreen Turkey Eggs#k! Collect some #bGreen Turkey Eggs#k and I'll make it worth your while!");
				return;
			}
			
			self.say("Excellent work! That is a fine Turkey eggs you've got...in return, let me dig around in the backpack here...I think I do have something here for you...!");
			
			if (SlotCount(2) < 1 || SlotCount(4) < 1)
			{
				self.say("Hey, make sure you have at least one empty slot in your use and etc. inventories!");
				return;
			}
			
			var rewards = new List<(int, int, int)> {
				(4031425, 1, 1),
				(2000004, 1, 25),
				(2020029, 1, 150),
				(2000002, 1, 50),
				(2000001, 1, 50),
				(2020030, 1, 224)
			};
			
			if (ItemCount(4031425) >= 1) rewards.Remove((4031425, 1, 1));
			
			var item = rewards.RandomElementByWeight(tuple => tuple.Item3);
			
			if (item == default)
				return;
			
			int itemID = item.Item1;
			int itemNum = item.Item2;
			
			if (!Exchange(0, 4031417, -1, itemID, itemNum))
			{
				self.say("Are you sure you brought the #bGreen Turkey Egg#k? Please check again.");
				return;
			}
			
			SetQuestData(8020018, "e");
			QuestEndEffect();
			self.say("Take this and I hope it helps out in your travels! Thank you! Find me more eggs and I'll reward you!");
		}
		else
		{
			bool start = AskYesNo("Hello there! You look like you've been out on a few adventures! I'm in dire need of some high-quality Turkey Eggs for a Thanksgiving breakfast I'm cooking. Do you have any Green eggs for me?");
			
			if (!start)
			{
				self.say("Oh, ok.  Be sure to come back, because I won't wait forever to get my eggs!");
				return;
			}
			
			SetQuestData(8020018, "s");
			self.say("I'm in dire need of some high-quality Turkey Eggs for a Thanksgiving breakfast I'm cooking. Will you gather some\r\n#bGreen Turkey Eggs#k for me?");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 8020017)
		{
			if ((Level >= 15 && Level < 30) || info == "s")
				return " Thanksgiving : Turkey Yellow Egg hunt";
		}
		else if (quest == 8020018)
		{
			if (Level >= 30)
				return " Thanksgiving : Turkey Green Egg hunt";
		}
		
		return null;
	}
	
	public override void Run()
	{
		if (DateTime.UtcNow > DateTime.Parse("2021-12-11"))
		{
			self.say("Sorry, but the Thanksgiving event is over. I'll let you know when a new event appears, alright? See you then!");
			return;
		}
		
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {8020017, 8020018};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "What's going on? I'm Cody, the head programmer of MapleStory~";
		
		if (options.Count == 0)
		{
			self.say(dialogue);
			return;
		}
		
		int choice = -1;
		
		if (options.Count >= 2)
			choice = AskMenu($"{dialogue}#b", options.ToArray());
		else
			choice = options[0].Index;
		
		switch(choice)
		{
			case 0: ThanksgivingYellow(GetQuestData(8020017)); break;
			case 1: ThanksgivingGreen(GetQuestData(8020018)); break;
		}
	}
}