using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		self.say("Welcome hah. I can pick anything in the world that can be picked, hah. If you don't have a key to open something that's locked away, bring it all to me, hah.");
		
		if (ItemCount(4031017) >= 1)
		{
			self.say("Oh so incredible, hah. How in the world did you get something so rare like this, hah? But this is locked away in such an intricate manner that I may need a lot of materials to open this up, hah.");
			int askOpen = AskMenu("I have everything else except 1 #t4021005# and 5 #t4000010#s... get me those and I will open it for you for free, hah.",
				(0, " #e1. #n#bGet him the materials.#k"),
				(1, " #e2. #n#bJust pay him#k"));
				
			if (SlotCount(1) < 1 || SlotCount(2) < 1 || SlotCount(4) < 1)
			{
				self.say("You need at least one free space in your use, etc. and equipment inventories, hah. Free space and then talk to me, hah.");
				return;
			}
			
			Random rnd = new Random();
			
			int index = 0;
			int newItemID = 0;
			int newItemNum = 0;
			int rn1 = rnd.Next(0, 106);
			
			if (rn1 < 6) index = 1;
 			else if (rn1 > 5 && rn1 < 11) index = 2;
 			else if (rn1 > 10 && rn1 < 16) index = 3;
 			else if (rn1 > 15 && rn1 < 21) index = 4;
 			else if (rn1 > 20 && rn1 < 26) index = 5;
 			else if (rn1 > 25 && rn1 < 31) index = 6;
 			else if (rn1 > 30 && rn1 < 36) index = 7;
 			else if (rn1 > 35 && rn1 < 41) index = 8; // Originally was (rn1 > 35 && rn1 < 40), but this caused '40' to be unhandled!
 			else if (rn1 > 40 && rn1 < 71) index = 9;
 			else if (rn1 > 70 && rn1 < 101) index = 10;
			else if (rn1 > 100 && rn1 < 106) index = 11;
			
			if (index == 1)
			{
				int[] items = {1002086, 1002218, 1002214, 1002210, 1032013, 1072135, 1072143, 1072125, 1072130, 1082009, 1082081, 1082084, 1082065};
				newItemID = items[rnd.Next(items.Length)];
				newItemNum = 1;
			}
			else if (index == 2)
			{
				int[] items = {1032015, 1092009, 1302011, 1312009, 1322018, 1332015, 1332017, 1372007, 1382006, 1402011, 1412007, 1422009, 1432006, 1442010, 1452004, 1462008, 1472022, 2070005};
				newItemID = items[rnd.Next(items.Length)];
				newItemNum = 1;
			}
			else if (index == 3)
			{
				int rn2 = rnd.Next(0, 4);
				
				if (rn2 >= 0 && rn2 <= 2)
				{ 
					newItemNum = 5;
					newItemID = 4003000;
				}
				else if (rn2 == 3)
				{
					newItemNum = 1;
					newItemID = 2100000;
				}
			}
			else if (index == 4)
			{
				int[] items = {2040704, 2040501, 2040401, 2040601, 2040705, 2040502, 2040402, 2040602, 2040301, 2040302, 2040707, 2040708, 2040804, 2040805, 2040901, 2040902, 2041001, 2041002, 2041004, 2041005, 2041007, 2041008, 2041010, 2041011, 2043001, 2043002, 2043101, 2043102, 2043201, 2043202, 2043301, 2043302, 2043701, 2043702, 2043801, 2043802, 2044001, 2044002, 2044101, 2044102, 2044201, 2044202, 2044301, 2044302, 2044401, 2044402, 2044501, 2044502, 2044601, 2044602, 2044701, 2044702};
				newItemID = items[rnd.Next(items.Length)];
				newItemNum = 1;
			}
			else if (index == 5)
			{
				int[] items = {4010006, 4020007, 4020008};
				newItemID = items[rnd.Next(items.Length)];
				newItemNum = 10;
			}
			else if (index == 6)
			{
				//LUK Crystal Ore was excluded by accident in the official script so the same will be done here.
				
				int[] items = {4004000, 4004001, 4004002};
				newItemID = items[rnd.Next(items.Length)];
				newItemNum = 4;
			}
			else if (index == 7)
			{
				int rn2 = rnd.Next(0, 4); 
				
				if (rn2 == 0)
				{
					newItemNum = 30;
					newItemID = 2000004;
				}
				else if (rn2 >= 1 && rn2 <= 3)
				{
					newItemNum = 100;
					newItemID = 2022000;
				}
			}
			else if (index == 8)
			{
				int[] items = {2020012, 2020013, 2020014, 2020015};
				newItemID = items[rnd.Next(items.Length)];
				newItemNum = 50;
			}
			else if (index == 9)
			{
				int[] items = {4010000, 4010001, 4010002, 4010003, 4010004, 4010005, 4020000, 4020001, 4020002, 4020003, 4020004, 4020005, 4020006};
				newItemID = items[rnd.Next(items.Length)];
				newItemNum = 15;
			}
			else if (index == 10)
			{
				int[] items = {2001000, 2001002, 2001001};
				newItemID = items[rnd.Next(items.Length)];
				newItemNum = 100;
			}
			else if (index == 11)
			{
				int[] items = {4030017, 4132000, 4132001, 4132002};
				newItemID = items[rnd.Next(items.Length)];
				newItemNum = 3;
			}
			
			if (askOpen == 0)
			{
				if (ItemCount(4021005) < 1 || ItemCount(4000010) < 5)
				{
					self.say("Then get me #b1 #t4021005##k and #b5 #t4000010#s#k, hah. I open it for free, hah.");
					return;
				}
				
				if (!Exchange(0, 4031017, -1, 4021005, -1, 4000010, -5, newItemID, newItemNum))
				{
					self.say("Are you 100% sure you have 1 #t4021005# and 5 #t4000010#s, hah? You may have to check, hah.");
					return;
				}
				
				self.say("I opened it for free, hah. I'll see you around, hah.");
			}
			else if (askOpen == 1)
			{
				bool askBuy = AskYesNo("I need to use expensive materials for this. This will cost you dearly, hah. #b10,000 mesos#k! Are you still going to do this, hah?");
				
				if (!askBuy)
				{
					self.say("10,000 mesos is very expensive, hah. There is a way to gather them together so come back again, hah.");
					return;
				}
				
				if (!Exchange(-10000, 4031017, -1, newItemID, newItemNum))
				{
					self.say("You don't have enough mesos, hah. #b10000 mesos#k, hah.");
					return;
				}
				
				self.say("I got the money, I opened it for you, I'll see you later, hah.");
			}
		}
	}
}
