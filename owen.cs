using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void GlassShoe()
	{
		string quest = GetQuestData(1001000);
		
		if (quest == "s")
		{
			if (ItemCount(4001000) < 1)
			{
				self.say("You haven't found my precious glass shoes. Flaming monster living near #m102000000# took my shoes. Please get it back for me.");
				return;
			}
			
			bool askComplete = AskYesNo("Oh...! That shiny thing must be my glass shoes... Would \r\nyou... please give it back to me? It won't be necessary for you.");
			
			if (askComplete)
			{
				Random rnd = new Random();
				int[] reward = {4003002, 4003003};
				
				int itemID = reward[rnd.Next(reward.Length)];
				
				if (!Exchange(0, 4001000, -1, itemID, 1))
				{
					self.say("Please see if you have an empty slot in your etc. inventory first.");
					return;
				}
			
				AddEXP(800);
				SetQuestData(1001000, "end");
				SetQuestData(1001001, DateTime.UtcNow.ToString("yyyyMMdd"));
				QuestEndEffect();
				self.say("We have give you the special items, which our fairies can give. This item is very rare and precious... Please use it well... Farewell...");
			}
		}
		else
		{
			self.say("Few Days ago, on the way going to #m102000000#, I have been attacked by flaming monster and I lost #bGlass Shoe#k... I have kept those for long time...");
			self.say("Fairies do like shiny stuff. Even though you think it is nothing, I really need that thing. I don't want to be helped by \r\nhumans... but please help me");
			SetQuestData(1001000, "s");
		}
	}
	
	private void MakeItem()
	{
		self.say("Yes... I am the head alchemist of the fairies. Only the fairies don't come into contact with human beings for a long period of time... but a strong person like you will be fine. If you get the materials, I'll make you a special item.");
		
		int askMake = AskMenu("What do you want to make?#b",
			(0, " #t4011007#"),
			(1, " #t4021009#"),
			(2, " #t4031042#"));
		
		string itemName = "";
		
		if (askMake == 0)
		{
			bool askBuy = AskYesNo("So you want to make #t4011007#? For this, you need one of each of these refined items: #b#t4011000#, #t4011001#, \r\n#t4011002#, #t4011003#, #t4011004#, #t4011005# and #t4011006##k. Along with 10,000 mesos I'll make it for you.");
			
			if (!askBuy)
			{
				self.say("It's not easy to make #t4011007#. Please get the materials soon.");
				return;
			}
			
			if (!Exchange(-10000, 4011000, -1, 4011001, -1, 4011002, -1, 4011003, -1, 4011004, -1, 4011005, -1, 4011006, -1, 4011007, 1))
			{
				self.say("Are you sure that you have enough money? Please make sure you have a refined #b#t4011000#, #t4011001#, #t4011002#, #t4011003#, #t4011004#, #t4011005# and #t4011006##k, one of each.");
				return;
			}
			
			itemName = "#t4011007#";
		}
		else if (askMake == 1)
		{
			bool askBuy = AskYesNo("So you want to make #t4021009#? For this, you need one each of these refined: #b#t4021000#, #t4021001#, #t4021002#, #t4021003#, \r\n#t4021004#, #t4021005#, #t4021006#, #t4021007# and #t4021008##k. Along with 15,000 mesos I'll make it for you.");
			
			if (!askBuy)
			{
				self.say("It's not easy to make #t4021009#. Please get the materials soon.");
				return;
			}
			
			if (!Exchange(-15000, 4021000, -1, 4021001, -1, 4021002, -1, 4021003, -1, 4021004, -1, 4021005, -1, 4021006, -1, 4021007, -1, 4021008, -1, 4021009, 1))
			{
				self.say("Are you sure that you have enough money? Please make sure you have a refined #b#t4021000#, #t4021001#, #t4021002#, \r\n#t4021003#, #t4021004#, #t4021005#, #t4021006#, #t4021007# and #t4021008##k, one of each.");
				return;
			}
			
			itemName = "#t4021009#";
		}
		else if (askMake == 2)
		{
			bool askBuy = AskYesNo("So you want to make #t4031042#? For this, you need #b1 \r\n#t4001006#, 1 #t4011007# and 1 #t4021008##k. Along with 30,000 mesos I'll make it for you. Ah yes, this feather is a very special item. If by chance you drop it, it will disappear, moreover, you can't pass it on to anyone.");
			
			if (!askBuy)
			{
				self.say("It's not easy to make #t4031042#. Please get the materials soon.");
				return;
			}
			
			if (!Exchange(-30000, 4001006, -1, 4021008, -1, 4011007, -1, 4031042, 1))
			{
				self.say("Are you sure you have enough money? See if you have #b1 \r\n#t4001006#, 1 #t4011007# and 1 #t4021008##k ready for me.");
				return;
			}
			
			itemName = "#t4031042#";
		}
		
		self.say($"Cool, here it is. {itemName}. It's very well made, it's important to use good materials. If a day comes you need my help, count on me, alright?");
	}
	
	public override void Run()
	{
		if (Job == 0 || GetLevel() < 25)
		{
			self.say("I lost a very important item ...");
			return;
		}
		
		string lastDate = GetQuestData(1001001);
		string today = DateTime.UtcNow.ToString("yyyyMMdd");
		
		if (lastDate == today && GetLevel() < 40)
		{
			self.say("You're the one that recovered the glass shoes from the menacing #o3210100# the other day. Thank you so much, and if you need my help, feel free to come talk to me.");
			return;
		}
		
		if (GetLevel() >= 40)
		{
			if (lastDate != today)
			{
				AskMenuCallback("I lost a very important item ...#b",
					(" Arwen and the Glass Shoes", GlassShoe),
					(" I heard that you can make a special item...", MakeItem));
			}
			else
			{
				MakeItem();
			}
		}
		else
		{
			GlassShoe();
		}
	}
}