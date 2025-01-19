using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(9000004);
		
		if (ItemCount(4031017) >= 1)
		{
			if (quest != "s")
			{
				SetQuestData(9000004, "s");
				self.say("Alright! I'll have to request it immediately! By the way, do you know how to open the #b#t4031017##k? You'll need an item called #b#t4031072##k in order to open that box. I used to have it, only to lose it one day at a place where monsters were aplenty.");
				self.say("Please defeat #b#o2230103##k, which can be found at Eos Tower en route to Ludibrium, and bring back the #b#t4031072##k with you. I'll open the #b#t4031017##k for you if you bring me that. I'll be here awaiting good news~");
				return;
			}
			
			if (ItemCount(4031072) < 1)
			{
				self.say("I don't think you have found #b#t4031072##k, yet. I lost the #b#t4031072##k a while ago at Eos Tower near Ludibrium. Please defeat #b#o2230103##k, a spider look-alike monster, and bring the key back so I can open the box for you~");
				return;
			}
			
			bool open = AskYesNo("You really did bring #b#t4031072##k! Now I can open #b#t4031017##k with ease. What do you think? Do you want me to open this for you right now?");
			
			if (open)
			{
				if (SlotCount(1) < 1 || SlotCount(2) < 1 || SlotCount(4) < 1)
				{
					self.say("You need at least one free space in your use, etc. and equipment inventories. Free space and then talk to me.");
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
				else if (rn1 > 35 && rn1 < 41) index = 8;
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
					newItemNum = 1;
					newItemID = 2100000;
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
					newItemNum = 30;
					newItemID = 2000004;
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
				
				if (!Exchange(0, 4031017, -1, 4031072, -1, newItemID, newItemNum))
				{
					self.say("Hey... are you sure you have the #b#t4031072##k and a free spot in your inventory?");
					return;
				}
				
				RemoveQuest(9000004);
				self.say($"Do you like the #b{newItemNum} #t{newItemID}#(s)#k you got from this box? Alright, if you ever find #b#t4031019##k again, please come talk to me~!");
			}
		}
		else if (ItemCount(4031019) >= 1)
		{
			self.say("Hey... isn't this #b#t4031019##k? Hmmm... I have to say, I know a thing or two about this item. This is a scroll that contains parts of the force of evil that's been sealed to it. It is a dangerous item indeed, and something horrific may happen if anyone tries to open this and use it without supervision.");
			bool start = AskYesNo("If you give me the #b#t4031019##k, then I'll request it for deciphering to the Omega Sector. I'll give you #b#t4031017##k in return. It's a mysterious box that contains an item, and no one knows what's inside. What do you think? Will you give me that scroll?");
			
			if (!start)
			{
				self.say("Hmmm... I can assure you that keeping the scroll won't do much for you. Talk to me if you want to change your mind!");
				return;
			}
			
			if (!ExchangeEx(0, "4031019", -1, "4031017,Period:21600", 1))
			{
				self.say("Hmmm... are you sure you have room in your inventory to take the #b#t4031017##k?");
				return;
			}
			
			SetQuestData(9000004, "s");
			self.say("Alright! I'll have to request it immediately! By the way, do you know how to open the #b#t4031017##k? You'll need an item called #b#t4031072##k in order to open that box. I used to have it, only to lose it one day at a place where monsters were aplenty.");
			self.say("Please defeat #b#o2230103##k, which can be found at Eos Tower en route to Ludibrium, and bring back the #b#t4031072##k with you. I'll open the #b#t4031017##k for you if you bring me that. I'll be here awaiting good news~");
		}
		else
		{
			RemoveQuest(9000004);
			self.say("If you have the Scroll of Secrets, give it to me~");
		}
	}
}