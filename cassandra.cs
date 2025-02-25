using System;
using System.Collections.Generic;
using System.Linq;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private static readonly int globalLeafGoal = 6000000;
	private static readonly int[] rewardNumbers = {750, 1500, 2250, 3000, 3750, 4500, 5250, 6000, 6750, 7500, 8250, 9000};
	private static readonly int[] rewardIcons = {2000000, 1012098, 2000004, 2040151, 2000004, 2043050, 2000005, 2040151, 2000005, 2043051, 2000005, 1032040};
	private static readonly string[] rewardNames = {
		"100 Random Potions",
		"Maple Leaf Accessory #e(temporary)#n",
		"25 Elixirs",
		"Maple Leaf Scroll #e(temporary)#n",
		"50 Elixirs",
		"Event Weapon Scroll",
		"10 Power Elixirs",
		"Maple Leaf Scroll #e(temporary)#n",
		"25 Power Elixirs",
		"Event Weapon Scroll",
		"50 Power Elixirs",
		"Maple Leaf Earrings",
	};
	
	private bool RewardAvailable(int level, int leafCount)
	{
		if (level < 12)
			return leafCount >= rewardNumbers[level];
		
		return false;
	}
	
	private string RewardString(int level)
	{
		string reward = "";
		
		for (int i = 0; i < rewardNames.Length; i++)
		{
			int rewardNumber = rewardNumbers[i];
			int rewardIcon = rewardIcons[i];
			string rewardName = rewardNames[i];
			
			if (level <= i)
				reward += $"#v{rewardIcon}#  {rewardName} #r({rewardNumber:n0} leaves)#k\r\n";
			else
				reward += $"#v{rewardIcon}#  {rewardName} #b(completed)#k\r\n";
		}
		
		return reward;
	}
	
	int[] scrollsLvl5 = {2043050, 2044050, 2043150, 2044150, 2043250, 2044250, 2044350, 2044450, 2043750, 2043850, 2044550, 2044650, 2043350, 2044750};
	int[] scrollsLvl9 = {2043051, 2044051, 2043151, 2044151, 2043251, 2044251, 2044351, 2044451, 2043751, 2043851, 2044551, 2044651, 2043351, 2044751};
						
	
	public override void Run()
	{
		if (!eventActive("fall") && !eventDone("fall"))
		{
			self.say("It looks like the event hasn't started yet. Please come and see me again soon!");
			return;
		}
		
		if (eventDone("fall"))
		{
			self.say("Aw, it looks like autumn is finally over~ Oh well, comes back again soon and I'll have more goodies for you!");
			return;
		}
		
		string quest = GetQuestData(8020056);
		
		if (quest == "")
		{
			self.say($"Hey there {chr.Name}~ Have you noticed the seasons changing? That's right, it's finally autumn! Nothing is more beautiful to me than the auburn leaves and cool autumn nights. You must have seen lots of #bmaple leaves#k around here, right? I'd love if you could collect some for me.");
			bool start = AskYesNo($"In fact, I'm asking everyone around the Maple World to help collect leaves for me. There's something in it for all of you if you can bring me #b{globalLeafGoal:n0} leaves#k before the end of fall! What do you think, do you want to participate in this awesome autumn event?");
			
			if (!start)
			{
				self.say("Oh~ I'll ask someone else, then. If you change your mind, you know where to find me!");
				return;
			}
			
			SetQuestData(8020056, "0");
			SetQuestData(8020057, "0");
			self.say("Wonderful~ Maple leaves can be found from monsters around Maple World; bring me as many as you can!");
			self.say("If you bring me enough of them, I'll reward you greatly. What are you waiting for, go gather maple leaves!");
		}
		else
		{
			string dialogue = $"Welcome back {chr.Name}~ What would you like to do?\r\n";
			
			while(true)
			{
				string rewardLevel = GetQuestData(8020056, "0");
				var rewardLevelInt = int.Parse(rewardLevel);
				string globalReward = GetQuestData(8020058);
				int leafCount = int.Parse(GetQuestData(8020057, "0"));
				int globalLeafCount = int.Parse(GetNpcVar(180000000, 9900000, "leafCount", "0"));
				const int lvl5ScrollQuestID = 8020059;
				const int lvl9ScrollQuestID = 8020060;
				var replacedLvl5Scroll = GetQuestData(lvl5ScrollQuestID, "0") == "1";
				var replacedLvl9Scroll = GetQuestData(lvl9ScrollQuestID, "0") == "1";

				var options = new List<(int, string)>();
				
				if (RewardAvailable(rewardLevelInt, leafCount))
					options.Add((4, " Claim a reward\r\n"));
				
				if (globalLeafCount >= globalLeafGoal && globalReward == "" && leafCount >= 1)
					options.Add((5, " Claim the global reward"));
				
				options.Add((1, " Turn in maple leaves"));
				options.Add((2, " See the rewards"));
				options.Add((3, " Check the global leaf count"));
				options.Add((0, " Explain the event again"));
				
				if (rewardLevelInt > 5 && !replacedLvl5Scroll) {
					options.Add((100, " #rI want to trade in my 65% event scroll#b"));
				}
				if (rewardLevelInt > 9 && !replacedLvl9Scroll) {
					options.Add((101, " #rI want to trade in my 15% event scroll#b"));
				}
				
				
				int start = AskMenu($"{dialogue}Leaves collected : #r{leafCount:n0}#b", options.ToArray());
				
				if (start == 0)
				{
					self.say("For the duration of the autumn season you'll find #bmaple leaves#k from monsters around Maple World. I want you to collect them and bring them back to me. If you bring me enough of them I'll give you a reward!");
					self.say($"I'm not just counting the leaves you bring me, though. I'll be adding the leaves everyone brings me together too. If you all can bring me #b{globalLeafGoal:n0} leaves#k before the end of fall, I'll award everyone a special #bcommemorative item#k!");
					self.say("Don't forget, you only have until the end of fall, #rDecember 21st#k to turn in your leaves!");
				}
				else if (start == 1)
				{
					int haveleaves = ItemCount(4001126);
					
					if (haveleaves < 1)
					{
						self.say("Sorry, it looks like you don't have any leaves to trade in right now.");
					}
					else
					{
						// Don't allow for turning in more than 1,000 leaves at a time
						int amount = AskInteger(Math.Min(haveleaves, 1000), 1, Math.Min(haveleaves, 1000), "You want to turn in some maple leaves? How many would you like to give me?");
						
						int total = amount + leafCount;
						
						string modifier = "leaves";
						
						if (amount == 1)
							modifier = "leaf";
						
						bool exchange = AskYesNo($"So you want to turn in #b{amount:n0}#k maple {modifier}? That will bring your total leaves to #r{total:n0}#k.");
						
						if (!exchange)
						{
							self.say("No worries, just come back and talk to me when you're ready.");
							return;
						}
						
						if (!Exchange(0, 4001126, -amount))
						{
							self.say($"Are you sure you have #b{amount}#k maple {modifier}?");
							return;
						}
						
						globalLeafCount = int.Parse(GetNpcVar(180000000, 9900000, "leafCount", "0"));
						
						int newGlobalLeafCount = globalLeafCount + amount;
						
						if (globalLeafCount < globalLeafGoal && newGlobalLeafCount >= globalLeafGoal)
						{
							Notice("Thanks to the amazing efforts of everyone in the Maple World, Cassandra has reached her goal of collecting 6,000,000 maple leaves! Congratulations!!");
							StartWeather(2090008, 25);
						}
						
						var rnd = new Random();
						
						if (rnd.Next(0, 100) == 0)
							StartWeather(2090008, 10);
						
						SetNpcVar(180000000, 9900000, "leafCount", newGlobalLeafCount.ToString());
						SetQuestData(8020057, total.ToString());
						self.say($"Thanks, {chr.Name}~ I'll hold onto these.");
					}
				}
				else if (start == 2)
				{
					string rewards = RewardString(rewardLevelInt);
					
					self.say($"Here are my autumn event rewards. The reward I can give you depends on how many leaves you've turned in.\r\n\r\n{rewards}");
				}
				else if (start == 3)
				{
					globalLeafCount = int.Parse(GetNpcVar(180000000, 9900000, "leafCount", "0"));
					
					double totalPercent = Math.Round((double)globalLeafCount / globalLeafGoal * 100, 2);
					double playerPercent = Math.Round((double)leafCount / globalLeafCount * 100, 2);
					
					if (globalLeafCount == 0)
						playerPercent = 0;
					
					dialogue = $"We are #r{totalPercent}%#k of the way to the #b{globalLeafGoal:n0}#k maple leaf goal.";
					
					if (globalLeafCount >= globalLeafGoal)
						dialogue = "We reached our goal of 6,000,000 leaves. Be sure to claim your #bMaple World Bandana#k!";
					
					self.say($"In total, everyone has turned in #b{globalLeafCount:n0}#k maple leaves!\r\n\r\n{dialogue}\r\nYou have contributed #r{playerPercent}%#k of the total donated leaves!");
				}
				else if (start == 4)
				{
					var rnd = new Random();
					
					if (rewardLevel == "0")
					{
						bool trade = AskYesNo($"Are you ready to claim your #b100 random potions#k reward? Make sure to leave room in your use inventory.");
						
						if (!trade)
						{
							self.say("No problem, just talk to me when you're ready.");
							return;
						}
						
						if (SlotCount(2) < 1)
						{
							self.say("Your inventory seems to be full. Please free up space in your use inventory before you take my reward.");
							return;
						}
						
						int[] items = {2000000, 2000001, 2000002, 2000003};
						
						int itemID = items[rnd.Next(items.Length)];
						
						if (!Exchange(0, itemID, 100))
						{
							self.say("Please check if you have an empty space in your use inventory.");
							return;
						}
						
						SetQuestData(8020056, "1");
					}
					else if (rewardLevel == "1")
					{
						bool trade = AskYesNo($"Are you ready to claim your #bmaple leaf accessory#k reward? Make sure to leave room in your equip. inventory.");
						
						if (!trade)
						{
							self.say("No problem, just talk to me when you're ready.");
							return;
						}
						
						if (!ExchangeEx(0, "1012098,DateExpire:2022122100", 1))
						{
							self.say("Please check if you have an empty space in your equip. inventory.");
							return;
						}
						
						SetQuestData(8020056, "2");
					}
					else if (rewardLevel == "2")
					{
						bool trade = AskYesNo($"Are you ready to claim your #b25 Elixirs#k reward? Make sure to leave room in your use inventory.");
						
						if (!trade)
						{
							self.say("No problem, just talk to me when you're ready.");
							return;
						}
						
						if (!Exchange(0, 2000004, 25))
						{
							self.say("Please check if you have an empty space in your use inventory.");
							return;
						}
						
						SetQuestData(8020056, "3");
					}
					else if (rewardLevel == "3")
					{
						bool trade = AskYesNo($"Are you ready to claim your #bMaple Leaf Accessory Scroll#k reward? Make sure to leave room in your use inventory.");
						
						if (!trade)
						{
							self.say("No problem, just talk to me when you're ready.");
							return;
						}
						
						if (!ExchangeEx(0, "2040151,DateExpire:2022122100", 1))
						{
							self.say("Please check if you have an empty space in your use inventory.");
							return;
						}
						
						SetQuestData(8020056, "4");
					}
					else if (rewardLevel == "4")
					{
						bool trade = AskYesNo($"Are you ready to claim your #b50 Elixirs#k reward? Make sure to leave room in your use inventory.");
						
						if (!trade)
						{
							self.say("No problem, just talk to me when you're ready.");
							return;
						}
						
						if (!Exchange(0, 2000004, 50))
						{
							self.say("Please check if you have an empty space in your use inventory.");
							return;
						}
						
						SetQuestData(8020056, "5");
					}
					else if (rewardLevel == "5")
					{
						bool trade = AskYesNo($"Are you ready to claim your #bEvent Weapon Scroll#k reward? Make sure to leave room in your use inventory.");
						
						if (!trade)
						{
							self.say("No problem, just talk to me when you're ready.");
							return;
						}
						
						
						var scrollID = AskMenu("Which scroll would you like?#b",
							scrollsLvl5.Select(scroll => (scroll, $"#v{scroll}#  #t{scroll}#")).ToArray()
						);
						
						if (!AskYesNo($"Are you sure you want to claim #b#v{scrollID}# #t{scrollID}##k?"))
						{
							self.say("No problem, just talk to me when you're ready.");
							return;
						}
						
						if (!Exchange(0, scrollID, 1))
						{
							self.say("Please check if you have an empty space in your use inventory.");
							return;
						}
						
						SetQuestData(8020056, "6");
					}
					else if (rewardLevel == "6")
					{
						bool trade = AskYesNo($"Are you ready to claim your #b10 Power Elixirs#k reward? Make sure to leave room in your use inventory.");
						
						if (!trade)
						{
							self.say("No problem, just talk to me when you're ready.");
							return;
						}
						
						if (!Exchange(0, 2000005, 10))
						{
							self.say("Please check if you have an empty space in your use inventory.");
							return;
						}
						
						SetQuestData(8020056, "7");
					}
					else if (rewardLevel == "7")
					{
						bool trade = AskYesNo($"Are you ready to claim your #bMaple Leaf Accessory Scroll#k reward? Make sure to leave room in your use inventory.");
						
						if (!trade)
						{
							self.say("No problem, just talk to me when you're ready.");
							return;
						}
						
						if (!ExchangeEx(0, "2040151,DateExpire:2022122100", 1))
						{
							self.say("Please check if you have an empty space in your use inventory.");
							return;
						}
						
						SetQuestData(8020056, "8");
					}
					else if (rewardLevel == "8")
					{
						bool trade = AskYesNo($"Are you ready to claim your #b25 Power Elixirs#k reward? Make sure to leave room in your use inventory.");
						
						if (!trade)
						{
							self.say("No problem, just talk to me when you're ready.");
							return;
						}
						
						if (!Exchange(0, 2000005, 25))
						{
							self.say("Please check if you have an empty space in your use inventory.");
							return;
						}
						
						SetQuestData(8020056, "9");
					}
					else if (rewardLevel == "9")
					{
						bool trade = AskYesNo($"Are you ready to claim your #bEvent Weapon Scroll#k reward? Make sure to leave room in your use inventory.");
						
						if (!trade)
						{
							self.say("No problem, just talk to me when you're ready.");
							return;
						}
						
						
						var scrollID = AskMenu("Which scroll would you like?#b",
							scrollsLvl9.Select(scroll => (scroll, $"#v{scroll}#  #t{scroll}#")).ToArray()
						);
						
						if (!AskYesNo($"Are you sure you want to claim #b#v{scrollID}# #t{scrollID}##k?"))
						{
							self.say("No problem, just talk to me when you're ready.");
							return;
						}
						
						if (!Exchange(0, scrollID, 1))
						{
							self.say("Please check if you have an empty space in your use inventory.");
							return;
						}
						
						SetQuestData(8020056, "10");
					}
					else if (rewardLevel == "10")
					{
						bool trade = AskYesNo($"Are you ready to claim your #b50 Power Elixirs#k reward? Make sure to leave room in your use inventory.");
						
						if (!trade)
						{
							self.say("No problem, just talk to me when you're ready.");
							return;
						}
						
						if (!Exchange(0, 2000005, 50))
						{
							self.say("Please check if you have an empty space in your use inventory.");
							return;
						}
						
						SetQuestData(8020056, "11");
					}
					else if (rewardLevel == "11")
					{
						bool trade = AskYesNo($"Are you ready to claim your #bMaple Leaf Earrings#k reward? Make sure to leave room in your equip. inventory.");
						
						if (!trade)
						{
							self.say("No problem, just talk to me when you're ready.");
							return;
						}
						
						if (!Exchange(0, 1032040, 1))
						{
							self.say("Please check if you have an empty space in your equip. inventory.");
							return;
						}
						
						SetQuestData(8020056, "12");
					}
					
					self.say($"There you go, {chr.Name}, I hope you enjoy. When you find more leaves please come and see me again~!");
				}
				else if (start == 5)
				{
					self.say("Wow... thanks to everyone we reached our goal! You all did so well in collecting leaves this year. For contributing to the event I'll award you a #bMaple World Bandana#k. Here, take it!");
					
					if (!Exchange(0, 1002535, 1))
					{
						self.say("Please check if you have an empty space in your equip. inventory.");
						return;
					}
					
					SetQuestData(8020058, "e");
					self.say("Enjoy your new bandana and happy mapling~!");
				}
				else if (start == 100 || start == 101)
				{
					var tradeLvl5Scroll = start == 100;
					
					var expectedScrolls = tradeLvl5Scroll ? scrollsLvl5 : scrollsLvl9;
					
					// See if user has any of the scroll
					var scrollsInInventory = expectedScrolls.Where(x => ItemCount(x) > 0).ToArray();
					
					if (scrollsInInventory.Length == 0)
					{
						self.say("You do not have any event scrolls to trade.");
						return;
					}
					
					var sourceScrollID = AskMenu("Which scroll do you want to trade in?#b",
						scrollsInInventory.Select(scroll => (scroll, $"#v{scroll}#  #t{scroll}#")).ToArray()
					);
					
					var newScrollID = AskMenu($"Which scroll do you want to get back for your #b#v{sourceScrollID}#  #t{sourceScrollID}##k?#b",
						expectedScrolls.Where(x => x != sourceScrollID).Select(scroll => (scroll, $"#v{scroll}#  #t{scroll}#")).ToArray()
					);
					
					if (!AskYesNo($"Are you sure you want to do the following trade? It can only be done once!\r\n#b#v{sourceScrollID}# #t{sourceScrollID}#\r\n#kwill be replaced with\r\n#b#v{newScrollID}# #t{newScrollID}#"))
					{
						self.say("No problem, just talk to me when you're ready.");
						return;
					}
					
					if (!Exchange(0, sourceScrollID, -1, newScrollID, 1))
					{
						self.say("Please check if you have an empty space in your use inventory.");
						return;
					}
					
					SetQuestData(tradeLvl5Scroll ? lvl5ScrollQuestID : lvl9ScrollQuestID, "1");
					self.say("Alright! Good luck with passing that scroll on your equipment!");
				}
				
				dialogue = "What would you like to do?\r\n";
			}
		}
	}
}