using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Craft1(int index, string makeItem, string needItem, int unitPrice)
	{
		int amount = AskInteger(1, 1, 100, $"You want to make a(n) {makeItem}? To make it, you'll need the materials listed below. How many would you like to make?\r\n\r\n#b10 {needItem}\r\n{unitPrice:n0} mesos#k");
		
		int nPrice = amount * unitPrice;
		int nAllNum = amount * 10;
		
		bool askBuy = AskYesNo($"To make #b{amount} {makeItem}#k, you will need the items listed below. Do you really want to make it?\r\n\r\n#b{nAllNum:n0} {needItem}\r\n{nPrice:n0} mesos#k");
		
		if (!askBuy)
		{
			self.say("I can refine other minerals and jewels, so you can think about it, ok?");
			return;
		}
		
		bool trade = false;
		
		// mineral
		if (index == 1) trade = Exchange(-nPrice, 4010000, -nAllNum, 4011000, amount);
		else if (index == 2) trade = Exchange(-nPrice, 4010001, -nAllNum, 4011001, amount);
		else if (index == 3) trade = Exchange(-nPrice, 4010002, -nAllNum, 4011002, amount);
		else if (index == 4) trade = Exchange(-nPrice, 4010003, -nAllNum, 4011003, amount);
		else if (index == 5) trade = Exchange(-nPrice, 4010004, -nAllNum, 4011004, amount);
		else if (index == 6) trade = Exchange(-nPrice, 4010005, -nAllNum, 4011005, amount);
		else if (index == 7) trade = Exchange(-nPrice, 4010006, -nAllNum, 4011006, amount);
		
		// jewel
		else if (index == 100) trade = Exchange(-nPrice, 4020000, -nAllNum, 4021000, amount);
		else if (index == 101) trade = Exchange(-nPrice, 4020001, -nAllNum, 4021001, amount);
		else if (index == 102) trade = Exchange(-nPrice, 4020002, -nAllNum, 4021002, amount);
		else if (index == 103) trade = Exchange(-nPrice, 4020003, -nAllNum, 4021003, amount);
		else if (index == 104) trade = Exchange(-nPrice, 4020004, -nAllNum, 4021004, amount);
		else if (index == 105) trade = Exchange(-nPrice, 4020005, -nAllNum, 4021005, amount);
		else if (index == 106) trade = Exchange(-nPrice, 4020006, -nAllNum, 4021006, amount);
		else if (index == 107) trade = Exchange(-nPrice, 4020007, -nAllNum, 4021007, amount);
		else if (index == 108) trade = Exchange(-nPrice, 4020008, -nAllNum, 4021008, amount);
		
		if (!trade)
		{
			self.say($"Please see if you have {needItem}, or if your etc. inventory is full or not.");
			return;
		}
		
		self.say($"Here, take the {amount} {makeItem}(s). What do you think? Well refined, huh? Hahaha ... Finally, all those days spent studying refining skills were worth it. Please come back another time!");
	}
	
	private void Craft2(int index, string makeItem, string needItem, int reqLevel, string itemOption, int pad)
	{
		bool askBuy = AskYesNo($"You want to upgrade {makeItem}? To make it, you'll need the materials listed below. The item will have #r{itemOption}#k embedded in it, with a level limit of {reqLevel} and the attack ability of #r{pad}#k. Make sure you don't use an upgraded item as a material for the upgrade. Do you want to make it?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("I can refine other minerals and jewels, so you can think about it, ok?");
			return;
		}
		
		bool trade = false;
		
		// Claws
		if (index == 1) trade = Exchange(-80000, 1472022, -1, 4011007, -1, 4021000, -8, 2012000, -10, 1472023, 1);
		else if (index == 2) trade = Exchange(-80000, 1472022, -1, 4011007, -1, 4021005, -8, 2012002, -10, 1472024, 1);
		else if (index == 3) trade = Exchange(-100000, 1472022, -1, 4011007, -1, 4021008, -3, 4000046, -5, 1472025, 1);
		
		if (!trade)
		{
			self.say("Please check if you have all the items that you need, or if your equip. inventory is full or not.");
			return;
		}
		
		self.say($"Here, take the {makeItem}. What do you think? Well made, huh? Hahaha ... Finally, all those days spent studying the art of upgrading were worth it. Please come back another time!");
	}
	
	public override void Run()
	{
		bool askStart = AskYesNo("What's up? Everything good? Don't you have a rare ore or a jewel? With a small service fee, I can transform those into useful materials for a weapon or armor. I learned how to refine while working on repairing items... What do you think? Want to let me do it?");
		
		if (!askStart)
		{
			self.say("I understand... but I'm sure that one day you will need my help... and when that day comes you can come back and talk to me, alright?");
			return;
		}
		
		int craftType = AskMenu("OK! With the ore and a small service fee, I can refine it so that you can use it. Before that, make sure you have a slot available in your etc. inventory. Now... what do you want me to do?#b",
			(0, " Refine the ore of a mineral"),
			(1, " Refine the ore of a jewel"),
			(2, " I have #t4000039#..."),
			(3, " I want to upgrade a Claw..."));
		
		if (craftType == 0)
		{
			int craftSelect = AskMenu("What kind of mineral do you want to make?#b",
				(0, " #t4011000#"),
				(1, " #t4011001#"),
				(2, " #t4011002#"),
				(3, " #t4011003#"),
				(4, " #t4011004#"),
				(5, " #t4011005#"),
				(6, " #t4011006#"));
				
			if (craftSelect == 0) Craft1(1, "#t4011000#", "#t4010000#s", 250);
			else if (craftSelect == 1) Craft1(2, "#t4011001#", "#t4010001#s", 250);
			else if (craftSelect == 2) Craft1(3, "#t4011002#", "#t4010002#s", 250);
			else if (craftSelect == 3) Craft1(4, "#t4011003#", "#t4010003#s", 450);
			else if (craftSelect == 4) Craft1(5, "#t4011004#", "#t4010004#s", 450);
			else if (craftSelect == 5) Craft1(6, "#t4011005#", "#t4010005#s", 450);
			else if (craftSelect == 6) Craft1(7, "#t4011006#", "#t4010006#s", 750);
		}
		else if (craftType == 1)
		{
			int craftSelect = AskMenu("What kind of jewel do you want to refine?#b",
				(0, " #t4021000#"),
				(1, " #t4021001#"),
				(2, " #t4021002#"),
				(3, " #t4021003#"),
				(4, " #t4021004#"),
				(5, " #t4021005#"),
				(6, " #t4021006#"),
				(7, " #t4021007#"),
				(8, " #t4021008#"));
				
			if (craftSelect == 0) Craft1(100, "#t4021000#", "#t4020000#s", 450);
			else if (craftSelect == 1) Craft1(101, "#t4021001#", "#t4020001#s", 450);
			else if (craftSelect == 2) Craft1(102, "#t4021002#", "#t4020002#s", 450);
			else if (craftSelect == 3) Craft1(103, "#t4021003#", "#t4020003#s", 450);
			else if (craftSelect == 4) Craft1(104, "#t4021004#", "#t4020004#s", 450);
			else if (craftSelect == 5) Craft1(105, "#t4021005#", "#t4020005#s", 450);
			else if (craftSelect == 6) Craft1(106, "#t4021006#", "#t4020006#s", 450);
			else if (craftSelect == 7) Craft1(107, "#t4021007#", "#t4020007#s", 950);
			else if (craftSelect == 8) Craft1(108, "#t4021008#", "#t4020008#s", 2900);
		}
		else if (craftType == 2)
		{
			bool askCraft = AskYesNo("You have #t4000039#? Hmm... with that I can try to make #t4011001#. If you give me #b100 of #b#t4000039##k and #b1,000 mesos#k, I can make a #brefined #t4011001##k. What do you think? Do you want to try it?");
			
			if (!askCraft)
			{
				self.say("I can refine other minerals and jewels besides these, so you can think about it...");
				return;
			}
			
			if (!Exchange(-1000, 4000039, -100, 4011001, 1))
			{
				self.say("Maybe you're lacking money... make sure you have 100 #t4000039#s and 1,000 mesos, and a free slot in your etc. inventory.");
				return;
			}
			
			self.say("Well ... here's the #b#t4011001##k. What do you think? Pretty refined, huh? hahaha... thankfully I studied a lot for my refining skills... come back anytime you want~!");
		}
		else if (craftType == 3)
		{
			self.say("So, do you want to upgrade a claw? Be careful! All the items used for the upgrade will disappear, and if you use an item that has been #renhanced#k with a scroll, the effect will disappear when upgraded, so it's better you think well before making your decision...");
			
			int craftSelect = AskMenu("Now ... What kind of Claw do you want to upgrade?",
				(0, " #b#t1472023##k(level limit: 60, thief)"),
				(1, " #b#t1472024##k(level limit: 60, thief)"),
				(2, " #b#t1472025##k(level limit: 60, thief)"));
				
			if (craftSelect == 0) Craft2(1, "#t1472023#", "#v1472022# #t1472022#\r\n#v4011007# #t4011007#\r\n#v4021000# 8 #t4021000#s\r\n#v2012000# 10 #t2012000#s\r\n80,000 mesos", 60, "DEX +4, avoid. +3", 30);
			else if (craftSelect == 1) Craft2(2, "#t1472024#", "#v1472022# #t1472022#\r\n#v4011007# #t4011007#\r\n#v4021005# 8 #t4021005#s\r\n#v2012002# 10 #t2012002#s\r\n80,000 mesos", 60, "LUK +4, avoid. +3", 30);
			else if (craftSelect == 2) Craft2(3, "#t1472025#", "#v1472022# #t1472022#\r\n#v4011007# #t4011007#\r\n#v4021008# 3 #t4021008#s\r\n#v4000046# 5 #t4000046#s\r\n100,000 mesos", 60, "LUK +5, avoid. +4", 30);
		}
	}
}