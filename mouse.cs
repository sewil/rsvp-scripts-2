using System;
using WvsBeta.Game;
using System.Collections.Generic;
using WvsBeta.Common;
using System.Linq;

public class NpcScript : IScriptV2
{
	class RedeemableCredit
	{
		public double Rate;
		public RateCredits.Type Type;
		public TimeSpan Duration;
		public string Comment;
		public int QuestID;
		public DateTime EndDate;
		
		public RedeemableCredit(double rate, RateCredits.Type type, TimeSpan duration, string comment, int questID, DateTime endDate)
		{
			Rate = rate;
			Type = type;
			Duration = duration;
			Comment = comment;
			QuestID = questID;
			EndDate = endDate;
		}
	}
	
	private bool CreditIsAvailable(int quest)
	{
		string savedDate = GetQuestData(quest, "2021-05-28");
		
		var today = DateTime.UtcNow;;
		var creditDate = DateTime.Parse(savedDate);
				
		return today > creditDate;
	}
	public override void Run()
	{
		string points = GetQuestData(1001300);
		
		if (points == "")
		{
			self.say("Welcome, welcome~ Our Internet Cafe is famous for its incredible computers. Oh, what? Your computer doesn't have a #t4000047#? Hmmm... that's a problem... well, recently some strange-looking guys came here and stole every #t4000047# available... what should I do...");
			bool askStart = AskYesNo("Oh yes! Oh yes! Can you find them for me? If you can, I'll register you as an exclusive member of our Internet Cafe and I'll even save your points for you. Once you have accumulated enough points, you'll be able to exchange them for the many materials we have available here. What do you think? Do you accept?");
			
			if (!askStart)
			{
				self.say("Hmmm... you must be busy right now. It'll definitely benefit you, but, if you change your mind, just come back to our Internet Cafe~");
				return;
			}
			
			SetQuestData(1001300, "0");
			self.say("Alright! Now you are officially a member of our Internet Cafe! Do you see those computers over there? If you have a #bticket#k, you can enter the Dungeon through them. In there, while #bhunting monsters#k or #bcompleting challenges#k, you might obtain a #t4000047# along the way.");
			self.say("There are many lost #t4000047#s and you might need to work hard to collect them. I'll give you a premium 10 points for each #t4000047# that you recover. If you want to check your total points or exchange them for materials, just talk to me. I'll be here all day.");
			self.say("Ah yes! If collecting #t4000047#s is difficult for you, feel free to bring some friends along. You can bring up to 6 people with you in your party, and each #t4000047# you recover while inside will be an additional 10 points for everyone in the party. Don't forget, though, each player can only enter twice a day. Well, it was nice to meet you~");
		}
		else
		{
			int pointNum = Int32.Parse(points);
			
			int options = AskMenu("This is for members only. Choose an option~#b",
				(0, " Information about points"),
				(1, " Check my total points"),
				(2, " Exchange for goods"));
				
			if (options == 0)
			{
				self.say("I'll explain more about our Cafe Points. We'll give you 10 points for each lost #b#t4000047##k from our Internet Cafe that you find. Once you have accumulated enough points, you'll be able to exchange them for the materials that we offer here. Some are incredible. I suggest that you start collecting them soon!");
				self.say("A #t4000047# can be obtained through the Dungeon, which you can enter #btwice per day#k through one of the computers. You can find them either by #beliminating monsters#k or by #bcompleting challenges#k. There are so many #t4000047#s missing that if you continue searching, you can easily gain several points.");
				self.say("You don't have to collect them all by yourself, though. You can bring a party of up to 6 with you. While in a party, every #t4000047# you find is an additional 10 cafe points for everyone there! Don't forget, you can only enter the Dungeon twice per day.");
				self.say("When you move to the dungeon, your time will start ticking down right away, so come prepared. Does that all make sense?");
			}
			else if (options == 1)
			{
				self.say($"I'll check the points for you. #b{chr.Name}#k, you currently have #r{points} points#k. Those points can be exchanged for the materials we have here at our Internet Cafe, so keep collecting~");
			}
			else if (options == 2)
			{
				self.say($"Currently, you have #r{points} points#k in our Internet Cafe. Choose the materials that you want to exchange for. Before I forget, some of the materials chosen for the exchange may be worthless items, so be careful before deciding~");
				
				var shoptions = new List<(int, string)> {
					(0, " 1,000 Cash (Trade 1000 pts)"),
					(1, " 5,000 Cash (Trade 4800 pts)\r\n"),
					(2, " 10 random potions (Trade 150 pts)"),
					(3, " 10 random foods (Trade 300 pts)"),
					(4, " 10 random town scrolls (Trade 500 pts)"),
					(5, " 10 power-up items (Trade 1000 pts)"),
					(6, " 10 random summer foods (Trade 2300 pts)\r\n"),
					(7, " 1 random refined ore (Trade 1500 pts)"),
					(8, " 1 random refined jewel (Trade 1800 pts)"),
					(9, " 10 #t4003000#s (Trade 2000 pts)"),
					(10, " 1 random stimulator (Trade 2200 pts)"),
					(11, " 1 random forging manual (Trade 2500 pts)\r\n"),
				};
				
				bool mesoCredit = CreditIsAvailable(1001391);
				bool dropCredit = CreditIsAvailable(1001390);
				
				if (mesoCredit)
					shoptions.Add((12, " 2-hour 1.5x meso credit (Trade 25000 pts)"));
				else
					shoptions.Add((12, " #r2-hour 1.5x meso credit (Currently unavailable)#b"));
				
				if (dropCredit)
					shoptions.Add((13, " 2-hour 1.5x drop credit (Trade 25000 pts)"));
				else
					shoptions.Add((13, " #r2-hour 1.5x drop credit (Currently unavailable)"));
				
				int tradeOption = AskMenu($"Currently, you have: {points} points#b", shoptions.ToArray());
				
				var rnd = new Random();
				
				if (tradeOption == 0)
				{
					int needPoint = 1000;
					
					if (pointNum < needPoint)
					{
						self.say("You don't have enough points. To exchange for #b1,000 Cash#k, you need at least 1000 points.");
						return;
					}
					
					if (!AskYesNo("Are you sure you want to exchange your #r1000 points#k for \r\n#b1,000 Cash#k?"))
					{
						return;
					}
					
					int newPoints = pointNum - needPoint;
					
					chr.AddCash(1000);
					Message("You have gained 1,000 Cash.");
					SetQuestData(1001300, newPoints.ToString());
					self.say($"You exchanged your #r1000 points#k for #b1,000 Cash#k. Now you have #r{newPoints} points#k remaining. Are you satisfied with what I gave you? Come back later~");
				}
				else if (tradeOption == 1)
				{
					int needPoint = 4800;
					
					if (pointNum < needPoint)
					{
						self.say("You don't have enough points. To exchange for #b5,000 Cash#k, you need at least 4800 points.");
						return;
					}
					
					if (!AskYesNo("Are you sure you want to exchange your #r4800 points#k for \r\n#b5,000 Cash#k?"))
					{
						return;
					}
					
					int newPoints = pointNum - needPoint;
					
					chr.AddCash(5000);
					Message("You have gained 5,000 Cash.");
					SetQuestData(1001300, newPoints.ToString());
					self.say($"You exchanged your #r4800 points#k for #b5,000 Cash#k. Now you have #r{newPoints} points#k remaining. Are you satisfied with what I gave you? Come back later~");
				}
				else if (tradeOption == 2)
				{
					int needPoint = 150;
					
					if (pointNum < needPoint)
					{
						self.say("You don't have enough points. To exchange for #b10 random potions#k, you need at least 150 points.");
						return;
					}
					
					if (!AskYesNo("Are you sure you want to exchange your #r150 points#k for 10 #brandom potions#k? You will receive 10 of one of these : #t2000000#, #t2000001#, #t2000002#, or #t2000003#. Please check if your inventory has enough space before making the exchange."))
					{
						return;
					}
					
					if (SlotCount(2) < 1)
					{
						self.say("Your inventory seems to be full. Please free up space and try again.");
						return;
					}
					
					int[] items = {2000000, 2000001, 2000002, 2000003};
					
					int itemID = items[rnd.Next(items.Length)];
					
					if (!Exchange(0, itemID, 10))
					{
						self.say("Please check if you have at least #r150 points#k or if your inventory has space available~");
						return;
					}
					
					int newPoints = pointNum - needPoint;
					
					SetQuestData(1001300, newPoints.ToString());
					self.say($"You exchanged your #r150 points#k for 10 #brandom potions#k, receiving #b10 #t{itemID}#s#k in the process. Now you have #r{newPoints} points#k remaining. Are you satisfied with what I gave you? Come back later~");
				}
				else if (tradeOption == 3)
				{
					int needPoint = 300;
					
					if (pointNum < needPoint)
					{
						self.say("You don't have enough points. To exchange for #b10 random foods#k, you need at least 300 points.");
						return;
					}
					
					if (!AskYesNo("Are you sure you want to exchange your #r300 points#k for #b10 random foods#k? You will receive 10 of any of these : #t2020000#, #t2020001#, #t2020002#, #t2020003#, #t2020004#, #t2020005#, #t2020006#, or #t2020007#. Please check if your inventory has enough space before making the exchange."))
					{
						return;
					}
					
					if (SlotCount(2) < 1)
					{
						self.say("Your inventory seems to be full. Please free up space in your inventory before you come talk to me~");
						return;
					}
					
					int[] items = {2020000, 2020001, 2020002, 2020003, 2020004, 2020005, 2020006, 2020007};
					
					int itemID = items[rnd.Next(items.Length)];
					
					if (!Exchange(0, itemID, 10))
					{
						self.say("Please check if you have at least #r300 points#k or if your inventory has space for the items.");
						return;
					}
					
					int newPoints = pointNum - needPoint;
					
					SetQuestData(1001300, newPoints.ToString());
					self.say($"You exchanged your #r300 points#k for #b10 random foods#k, receiving #b10 #t{itemID}#s#k in the process. Now you have #r{newPoints} points#k remaining. Are you satisfied with what I gave you? Come back later~");
				}
				else if (tradeOption == 4)
				{
					int needPoint = 500;
					
					if (pointNum < needPoint)
					{
						self.say("You don't have enough points. To exchange for #b10 town scrolls#k, you need at least 500 points.");
						return;
					}
					
					if (!AskYesNo("Are you sure you want to exchange your #r500 points#k for #b10 random town scrolls#k? You will randomly receive 10 return scrolls for any of these places: #t2030000#, #t2030001#, #t2030002#, #t2030003#, #t2030004#, #t2030005#, or #t2030006#. Please check if your inventory has enough space before making the exchange."))
					{
						return;
					}
					
					if (SlotCount(2) < 1)
					{
						self.say("Your inventory seems to be full. Please free up space in your inventory before you come talk to me~");
						return;
					}
					
					int[] items = {2030000, 2030001, 2030002, 2030003, 2030004, 2030005, 2030006};
					
					int itemID = items[rnd.Next(items.Length)];
					
					if (!Exchange(0, itemID, 10))
					{
						self.say("Please check if you have at least #r500 points#k or if your inventory has space available~");
						return;
					}
					
					int newPoints = pointNum - needPoint;
					
					SetQuestData(1001300, newPoints.ToString());
					self.say($"You exchanged your #r500 points#k for #b10 random town scrolls#k, receiving #b10 #t{itemID}##k in the process. Now you have #r{newPoints} points#k remaining. Are you satisfied with what I gave you? Come back later~");
				}
				else if (tradeOption == 5)
				{
					int needPoint = 1000;
					
					if (pointNum < needPoint)
					{
						self.say("You don't have enough points. To exchange for #b10 random power-up items#k, you need at least 1000 points.");
						return;
					}
					
					if (!AskYesNo("Are you sure you want to exchange your #r1000 points#k for 10 #brandom power-up items#k? You will randomly receive 10 of one of these: #t2012000#, #t2012001#, #t2012002#, or #t2012003#. Please check if your inventory has enough space before making the exchange."))
					{
						return;
					}
					
					if (SlotCount(2) < 1)
					{
						self.say("Your inventory seems to be full. Please free up space in your inventory before you come talk to me~");
						return;
					}
					
					int[] items = {2012000, 2012001, 2012002, 2012003};
					
					int itemID = items[rnd.Next(items.Length)];
					
					if (!Exchange(0, itemID, 10))
					{
						self.say("Please check if you have at least #r1000 points#k or if your inventory has space available~");
						return;
					}
					
					int newPoints = pointNum - needPoint;
					
					SetQuestData(1001300, newPoints.ToString());
					self.say($"You exchanged your #r1000 points#k for 10 #bpower-up items#k, receiving #b10 #t{itemID}#s#k. Now you have #r{newPoints} points#k remaining. Are you satisfied with what I gave you? Come back later~");
				}
				else if (tradeOption == 6)
				{
					int needPoint = 2300;
					
					if (pointNum < needPoint)
					{
						self.say("You don't have enough points. To exchange for #b10 random summer foods#k, you need at least 2300 points.");
						return;
					}
					
					if (!AskYesNo("Are you sure you want to exchange #r2300 points#k for #b10 random summer foods#k? You will randomly receive 10 of #t2001000#, #t2001001#, or #t2001002#. Check if you have a slot available in your use inventory before making the exchange."))
					{
						return;
					}
					
					if (SlotCount(2) < 1)
					{
						self.say("Your use. inventory seems to be full. Please free up a slot in your use inventory and try again~");
						return;
					}
					
					int[] items = {2001000, 2001001, 2001002};
					
					int itemID = items[rnd.Next(items.Length)];
					
					if (!Exchange(0, itemID, 10))
					{
						self.say("Please make sure your points exceed #r2300 points#k or if you have some free space in your use inventory~");
						return;
					}
					
					int newPoints = pointNum - needPoint;
					
					SetQuestData(1001300, newPoints.ToString());
					self.say($"For your #r2300 points#k, I traded you #b10 random summer foods#k, giving #b10 #t{itemID}##k. Now you have #r{newPoints} points#k remaining. Did you like what I gave you? Come back later~");
				}
				else if (tradeOption == 7)
				{
					int needPoint = 1500;
					
					if (pointNum < needPoint)
					{
						self.say("You don't have enough points. To exchange for #b1 random refined mineral#k, you need at least 1500 points.");
						return;
					}
					
					if (!AskYesNo("Are you sure you want to exchange your #r1500 points#k for #b1 random refined mineral#k? You will randomly receive any of these: #t4011000#, #t4011001#, #t4011002#, #t4011003#, #t4011004#, #t4011005#, or #t4011006#. Check if you have a free slot available in your etc. inventory before making the exchange."))
					{
						return;
					}
					
					if (SlotCount(4) < 1)
					{
						self.say("Your etc. inventory seems to be full. Please free up space in your etc. inventory before you come talk to me~");
						return;
					}
					
					int[] items = {4011000, 4011001, 4011002, 4011003, 4011004, 4011005, 4011006};
					
					int itemID = items[rnd.Next(items.Length)];
					
					if (!Exchange(0, itemID, 1))
					{
						self.say("Please check if you have at least #r1500 points#k or if your etc. inventory has slots available~");
						return;
					}
					
					int newPoints = pointNum - needPoint;
					
					SetQuestData(1001300, newPoints.ToString());
					self.say($"I gave you #b1 random refined mineral#k for #r1500 points#k, giving #b1 #t{itemID}##k. Now you have #r{newPoints} points#k remaining. Are you satisfied with what I gave you? Come back later~");
				}
				else if (tradeOption == 8)
				{
					int needPoint = 1800;
					
					if (pointNum < needPoint)
					{
						self.say("You don't have enough points. To exchange for #b1 random refined jewel#k, you need at least 1800 points.");
						return;
					}
					
					if (!AskYesNo("Are you sure you want to exchange your #r1800 points#k for #b1 random refined jewel#k? You will randomly receive one of these refined jewels: #t4021000#, #t4021001#, #t4021002, #t4021003#, #t4021004#, #t4021005#, #t4021006#, or #t4021007#. Check if you have a free space in your etc. inventory before making the exchange."))
					{
						return;
					}
					
					if (SlotCount(4) < 1)
					{
						self.say("Your etc. inventory seems to be full. Please free up space before you come talk to me~");
						return;
					}
					
					int[] items = {4021000, 4021001, 4021002, 4021003, 4021004, 4021005, 4021006, 4021007};
					
					int itemID = items[rnd.Next(items.Length)];
					
					if (!Exchange(0, itemID, 1))
					{
						self.say("Please check if you have at least #r1800 points#k or if your etc. inventory has space available~");
						return;
					}
					
					int newPoints = pointNum - needPoint;
					
					SetQuestData(1001300, newPoints.ToString());
					self.say($"You exchanged your #r1800 points#k for #b1 random refined jewel#k, giving #b1 #t{itemID}##k. Now you have #r{newPoints} points#k remaining. Are you satisfied with what I gave you? Come back later~");
				}
				else if (tradeOption == 9)
				{
					int needPoint = 2000;
					
					if (pointNum < needPoint)
					{
						self.say("You don't have enough points. To get #b10 screws#k, you need at least 2000 points.");
						return;
					}
					
					if (!AskYesNo("Do you really want to use #r2000 points#k to obtain #b10 screws#k? Please check if your etc. inventory has enough space before making the exchange."))
					{
						return;
					}
					
					if (!Exchange(0, 4003000, 10))
					{
						self.say("Please check if you have at least #r2000 points#k or if your etc. inventory has space available~");
						return;
					}
					
					int newPoints = pointNum - needPoint;
					
					SetQuestData(1001300, newPoints.ToString());
					self.say($"I traded my #b10 #t4003000#s#k for your #r2000 points#k, giving #b10 #t4003000#s#k. Now you have #r{newPoints} points#k remaining. Are you satisfied with what I gave you? Come back later~");
				}
				else if (tradeOption == 10)
				{
					int needPoint = 2200;
					
					if (pointNum < needPoint)
					{
						self.say("You don't have enough points. To exchange for #b1 random stimulator#k, you need at least 2200 points.");
						return;
					}
					
					if (!AskYesNo("Are you sure you want to exchange your #r2200 points#k for #b1 random stimulator#k? You will randomly receive a stimulator used for crafting in Ludibrium. Check if you have a free space in your etc. inventory before making the exchange."))
					{
						return;
					}
					
					if (SlotCount(4) < 1)
					{
						self.say("Your etc. inventory seems to be full. Please free up space before you come talk to me~");
						return;
					}
					
					int[] items = {4130000, 4130001, 4130002, 4130003, 4130004, 4130005, 4130006, 4130007, 4130008, 4130009, 4130010, 4130011, 4130012, 4130013, 4130014, 4130015};
					
					int itemID = items[rnd.Next(items.Length)];
					
					if (!Exchange(0, itemID, 1))
					{
						self.say("Please check if you have at least #r2200 points#k or if your etc. inventory has space available~");
						return;
					}
					
					int newPoints = pointNum - needPoint;
					
					SetQuestData(1001300, newPoints.ToString());
					self.say($"You exchanged your #r2200 points#k for #b1 random stimulator#k, giving #b1 #t{itemID}##k. Now you have #r{newPoints} points#k remaining. Are you satisfied with what I gave you? Come back later~");
				}
				else if (tradeOption == 11)
				{
					int needPoint = 2500;
					
					if (pointNum < needPoint)
					{
						self.say("You don't have enough points. To exchange for #b1 random forging manual#k, you need at least 2500 points.");
						return;
					}
					
					if (!AskYesNo("Are you sure you want to exchange your #r2500 points#k for #b1 random forging manual#k? You will randomly receive a forging manual used for crafting in Ludibrium. Check if you have a free space in your etc. inventory before making the exchange."))
					{
						return;
					}
					
					if (SlotCount(4) < 1)
					{
						self.say("Your etc. inventory seems to be full. Please free up space before you come talk to me~");
						return;
					}
					
					int[] items = {4131000, 4131001, 4131002, 4131003, 4131004, 4131005, 4131006, 4131007, 4131008, 4131009, 4131010, 4131011, 4131012, 4131013};
					
					int itemID = items[rnd.Next(items.Length)];
					
					if (!Exchange(0, itemID, 1))
					{
						self.say("Please check if you have at least #r2500 points#k or if your etc. inventory has space available~");
						return;
					}
					
					int newPoints = pointNum - needPoint;
					
					SetQuestData(1001300, newPoints.ToString());
					self.say($"You exchanged your #r2500 points#k for #b1 random forging manual#k, giving #b1 #t{itemID}##k. Now you have #r{newPoints} points#k remaining. Are you satisfied with what I gave you? Come back later~");
				}
				else if (tradeOption == 12)
				{
					if (!mesoCredit)
					{
						self.say("Sorry, you have already redeemed the 1.5x meso credit this week. Please come back again later.");
						return;
					}
					
					int needPoint = 25000;
					
					if (pointNum < needPoint)
					{
						self.say("You don't have enough points. To exchange for a #b2-hour 1.5x meso credit#k, you need at least 25000 points.");
						return;
					}
					
					if (!AskYesNo("Are you sure you want to exchange #r25000 points#k for a \r\n#b2-hour 1.5x meso credit#k?"))
					{
						return;
					}
					
					var rc = chr.RateCredits;
					int questNum = 0;
					
					for (int i = 997000; i < 998000; i++)
					{
						if (GetQuestData(i) == "")
						{
							questNum = i;
							break;
						}
					}
					
					int newPoints = pointNum - needPoint;
					
					SetQuestData(1001300, newPoints.ToString());
					SetQuestData(1001391, DateTime.UtcNow.AddDays(7).ToString("yyyy-MM-dd"));
					SetQuestData(questNum, "1");
					rc.AddTimedCredits(RateCredits.Type.Mesos, TimeSpan.FromHours(2), 1.5, $"Internet Cafe Mesos Credit {questNum - 996999}");
					self.say($"For your #r25000 points#k, I awarded you a #b1.5x meso rate credit#k. You can activate it by talking to the Maple Administrator in town. Now you have #r{newPoints} points#k remaining. Did you like what I gave you? Come back later~");
				}
				else if (tradeOption == 13)
				{
					if (!dropCredit)
					{
						self.say("Sorry, you have already redeemed the 1.5x drop credit this week. Please come back again later.");
						return;
					}
					
					int needPoint = 25000;
					
					if (pointNum < needPoint)
					{
						self.say("You don't have enough points. To exchange for a #b2-hour 1.5x drop credit#k, you need at least 25000 points.");
						return;
					}
					
					if (!AskYesNo("Are you sure you want to exchange #r25000 points#k for a \r\n#b2-hour 1.5x drop credit#k?"))
					{
						return;
					}
					
					var rc = chr.RateCredits;
					int questNum = 0;
					
					for (int i = 998000; i < 999000; i++)
					{
						if (GetQuestData(i) == "")
						{
							questNum = i;
							break;
						}
					}
					
					int newPoints = pointNum - needPoint;
					
					SetQuestData(1001300, newPoints.ToString());
					SetQuestData(1001390, DateTime.UtcNow.AddDays(7).ToString("yyyy-MM-dd"));
					SetQuestData(questNum, "1");
					rc.AddTimedCredits(RateCredits.Type.Drop, TimeSpan.FromHours(2), 1.5, $"Internet Cafe Drop Credit {questNum - 997999}");
					self.say($"For your #r25000 points#k, I awarded you a #b1.5x drop rate credit#k. You can activate it by talking to the Maple Administrator in town. Now you have #r{newPoints} points#k remaining. Did you like what I gave you? Come back later~");
				}
			}
		}
	}
}