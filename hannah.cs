using System;
using System.Collections.Generic;
using WvsBeta.Game;
using WvsBeta.Common;

public class NpcScript : IScriptV2
{
	private void Festival(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("Greetings, traveler. My name is Hannah and I'm currently organizing a Festival of Lights for the Holidays. If you could help me out, I'd greatly appreciate it!");
			
			if (!start)
			{
				self.say("Truly a shame, I suppose that I will have to find another good soul to assist me...Fare thee well!");
				return;
			}
			
			SetQuestData(8020021, "s");
			self.say("Excellent. I'd like to build an altar for the festival, so we'll need 25 Altar Pieces. Some others attempted to help me, but their axes got stuck in the wood. Fighting those monsters should give you the needed pieces. Thank you and hurry back!");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031445) < 25)
			{
				self.say("Oh my, it looks like you don't have enough pieces to build the altar yet. Be sure to hurry back when you do!");
				return;
			}
			
			self.say("Wonderful! These should be enough pieces to build the Altar. Thanks for your help! I've got one other thing for you when you get a chance...");
			
			if (!Exchange(0, 4031445, -25, 2022121, 2))
			{
				self.say("Please leave a slot available in your use inventory first.");
				return;
			}
			
			AddEXP(800);
			SetQuestData(8020021, "1");
			self.say("Ok, I'll start building the Altar. In the meantime, I'll need you to gather 9 Sabbath Candles so we can officially start the festival. They can be found on those strange horned mushroom creatures.");
		}
		else if (quest == "1")
		{
			if (ItemCount(4031444) < 9)
			{
				self.say("Ah, you've returned...with not enough candles, I see. I'll need 9 to start the Festival. See you when you get them!");
				return;
			}
			
			self.say("Great job! I think these candles will be enough to being the Festival of Lights! Thanks for your hard work, please take this present as a token of my appreciation.");
			
			if (!Exchange(0, 4031444, -9, 4031521, 1))
			{
				self.say("Please leave a slot available in your etc. inventory first.");
				return;
			}
			
			SetQuestData(8020021, "e");
			SetQuestData(8020022, DateTime.UtcNow.AddDays(1).ToString());
			self.say("Thanks again! If you want to open this present box, then would you like me to help you open up the present?");
		}
		else if (quest == "e")
		{
			bool start = AskYesNo("I'll start building the Altar. In the meantime, I'll need you to gather 9 Sabbath Candles so we can officially start the festival. If you could help me out, I'd greatly appreciate it!");
			
			if (!start)
			{
				self.say("Alright. I still need your help, though, so be sure to come back!");
				return;
			}
			
			SetQuestData(8020021, "1");
			self.say("Glad to hear it. Ok, They can be found on those strange horned mushroom creatures. Come back here when you've got 9!");
		}
	}
	
	private void Altar()
	{
		self.say("Traveler, for your kindness and hard work I would like to give you the #bMenorah#k that you helped me make.");
		
		if (!Exchange(0, 3995000, 1))
		{
			self.say("Sorry, it looks like your set-up inventory is full right now. Make some room first and speak with me again.");
			return;
		}
		
		self.say($"Happy Hannukah {chr.Name}!");
	}
	
	private void Present()
	{
		bool open = AskYesNo("No one knows what's inside this Hanukkah Present Box. Would you like to find out for yourself?");
		
		if (!open)
		{
			self.say("You shall know that this box has an expiration date, and it should be opened before then. Please reconsider.");
			return;
		}
		
		if (SlotCount(1) < 1 || SlotCount(2) < 1 || SlotCount(4) < 1)
		{
			self.say("Sorry, I can't open the present for you until you have at least one empty slot in your equip. use, and etc. inventories.");
			return;
		}
		
		self.say("I shall open the box for you. You will be blessed with an item that should fit your need.");
		
		var rewards = new List<(int, int, int)> {
			(2060000, 100, 100000),
			(2061000, 100, 100000),
			(2000000, 25, 70000),
			(2000003, 25, 70000),
			(4010004, 2, 60000),
			(1322000, 1, 50000),
			(2000006, 5, 50000),
			(2000001, 10, 50000),
			(4010003, 2, 50000),
			(4010005, 1, 50000),
			(2000002, 5, 50000),
			(2002010, 1, 50000),
			(4010006, 2, 50000),
			(2002004, 1, 50000),
			(4020003, 10, 30000),
			(4011006, 1, 20000),
			(4004000, 1, 20000),
			(1002138, 1, 13929),
			(1040022, 1, 10000),
			(1060031, 1, 10000),
			(2050004, 3, 10000),
			(2000004, 2, 10000),
			(1040044, 1, 10000),
			(1002143, 1, 5000),
			(2022121, 5, 5000),
			(2000005, 3, 5000),
			(1072103, 1, 1000),
			(1432005, 1, 30),
			(2041013, 1, 10),
			(2041016, 1, 10),
			(2041019, 1, 10),
			(2041022, 1, 10),
			(2048000, 1, 1)
		};
		
		var item = rewards.RandomElementByWeight(tuple => tuple.Item3);
		
		if (item == default)
			return;
		
		int itemID = item.Item1;
		int itemNum = item.Item2;
		
		if (!Exchange(0, 4031521, -1, itemID, itemNum))
		{
			self.say("Hmm... are you sure you brought with you the #t4031521#? If so, please make sure you have room in your inventory first.");
			return;
		}
		
		self.say($"The #b{itemNum} #t{itemID}#s#k you have received shall help thee on thy journey down the road. Happy Hanukkah, and Happy New Year!");
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 8020021)
		{
			var questTime = DateTime.Parse(GetQuestData(8020022, "2021-12-20"));
			
			if ((info == "" && Level >= 23) || info == "s")
				return " Building the Altar";
			
			else if (info == "1" || (info == "e" && DateTime.UtcNow > questTime))
				return " Blessing the Festival";
		}
		else if (quest == 8020032)
		{
			string lights = GetQuestData(8020021);
			
			if (info != "e" && lights == "e" && ItemCount(3995000) < 1)
				return " The Finished Altar";
		}
		
		return null;
	}
	
	public override void Run()
	{
		if (!eventActive("hanukkah2022") && !eventDone("hanukkah2022"))
		{
			self.say("The festival of lights has not begun just yet. Come and see me later, okay?");
			return;
		}
		
		if (eventDone("hanukkah2022"))
		{
			self.say("The festival of lights has ended. Come back again next year and I may need your help again!");
			return;
		}
		
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {8020021, 8020032};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		if (ItemCount(4031521) >= 1)
			options.Add((2, " Open the Present"));
		
		string dialogue = "I have to get ready for the Festival of Lights! I just need some help with preparations!";
		
		if (GetQuestData(8020021) == "e")
			dialogue = "I've started building the Altar. If you would like to help me with the final preparations for the ceremony, please let me know.";
		
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
			case 0: Festival(GetQuestData(8020021)); break;
			case 1: Altar(); break;
			case 2: Present(); break;
		}
	}
}