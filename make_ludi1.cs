using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Craft1(int index, string makeItem, string needItem, int unitPrice)
	{
		if (index == 200 || index == 201)
		{
			int amount = AskInteger(1, 1, 100, $"To make a rare jewel, you will need materials worthy of it... well, how many #b{makeItem}(s)#k do you want to make?");
			
			int nPrice = unitPrice * amount;
			
			bool askBuy = AskYesNo($"You want #b{amount} {makeItem}(s)#k? If so, you'll need #r{nPrice} mesos and {amount} {needItem}(s) each#k. What do you think? Do you really want me to do it?");
			
			if (!askBuy)
			{
				self.say("I understand... Please come back again, whenever you want! I'll be here, as always, waiting for customers like you!");
				return;
			}
			
			bool trade = false;
			
			//rare jewels
			if (index == 200) trade = Exchange(-nPrice, 4011000, -amount, 4011001, -amount, 4011002, -amount, 4011003, -amount, 4011004, -amount, 4011005, -amount, 4011006, -amount, 4011007, amount);
			else if (index == 201) trade = Exchange(-nPrice, 4021000, -amount, 4021001, -amount, 4021002, -amount, 4021003, -amount, 4021004, -amount, 4021005, -amount, 4021006, -amount, 4021007, -amount, 4021008, -amount, 4021009, amount);
			
			if (!trade)
			{
				self.say("Please check if you have all the items needed with you. If so, check your etc. inventory, it may be full!!");
				return;
			}
			
			self.say($"Here, take #b{amount} {makeItem}(s)#k. I think it's pretty cool. Isn't it beautiful? Anytime!");
		}
		else
		{
			int amount = AskInteger(1, 1, 100, $"To make {makeItem}, I'll need the following materials. How many do you want to make?\r\n\r\n#b10 {needItem}\r\n{unitPrice:n0} mesos#k");
			
			int nPrice = unitPrice * amount;
			int nAllNum = amount * 10;
			
			bool askBuy = AskYesNo($"To make #b{amount} {makeItem}(s)#k, I'll need the following materials. Do you really want to do it?\r\n\r\n#b{nAllNum} {needItem}(s)\r\n{nPrice:n0} mesos#k");
			
			if (!askBuy)
			{
				self.say("I understand... Please come back again, whenever you want! I'll be here, as always, waiting for customers like you!");
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
			else if (index == 8) trade = Exchange(-nPrice, 4010007, -nAllNum, 4011008, amount);
			
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
			
			// crystal
			else if (index == 300) trade = Exchange(-nPrice, 4004000, -nAllNum, 4005000, amount);
			else if (index == 301) trade = Exchange(-nPrice, 4004001, -nAllNum, 4005001, amount);
			else if (index == 302) trade = Exchange(-nPrice, 4004002, -nAllNum, 4005002, amount);
			else if (index == 303) trade = Exchange(-nPrice, 4004003, -nAllNum, 4005003, amount);
			else if (index == 304) trade = Exchange(-nPrice, 4004004, -nAllNum, 4005004, amount);
			
			if (!trade)
			{
				self.say("Please check if you have all the items needed with you. If so, check your etc. inventory, it may be full!!");
				return;
			}
			
			self.say($"Here, take #b{amount} {makeItem}(s). I think it's pretty cool. Isn't it beautiful? Anytime!");
		}
	}
	
	//materials
	private void Craft2(int index, string makeItem, string needItem, int needNumber, int itemNumber)
	{
		int amount = AskInteger(1, 1, 100, $"With #b{needNumber} {needItem}(s)#k, I can make {itemNumber} {makeItem}(s). These I can create for you for free, as long as you have the necessary materials. What do you think? How many of these do you want to create?");
		
		int nNeedNum = amount * needNumber;
		int nAllNum = amount * itemNumber;
		
		bool askBuy = AskYesNo($"You want to make #b{makeItem}#k {amount} times? I need #r{nNeedNum} {needItem}(s)#k, then. Do you really want to make it?");
		
		if (!askBuy)
		{
			self.say("Don't have the materials? You can grab the materials by eliminating the monsters in the area! Go fight them!");
			return;
		}
		
		bool trade = false;
		
		if (index == 1) trade = Exchange(0, 4000003, -nNeedNum, 4003001, nAllNum);
		else if (index == 2) trade = Exchange(0, 4000018, -nNeedNum, 4003001, nAllNum);
		else if (index == 3) trade = Exchange(0, 4011001, -nNeedNum, 4011000, -nNeedNum, 4003000, nAllNum);
		
		
		if (!trade)
		{
			self.say("Please check if you have all the items needed with you. If so, check your etc. inventory, it may be full!!");
			return;
		}
		
		self.say($"Here, take #b{nAllNum} {makeItem}(s). I think it's pretty cool. Isn't it beautiful? Anytime!");
	}
	
	private void Craft3(int index, string makeItem, string needItem, int unitNum, string itemOption)
	{
		bool askBuy;
		
		if (itemOption == "")
		{
			askBuy = AskYesNo($"To make #b{unitNum} {makeItem}(s)#k, I'll need the following materials. If you have the materials, it'll be much better for you to make the item here than to buy it in a shop. Do you really want to make it?\r\n\r\n#b{needItem}");
		}
		else
		{
			askBuy = AskYesNo($"You want to make #b{unitNum} {makeItem}(s)#k?\r\nBring\r\n#b{needItem}#k\r\nand I can make it for you. By the way, this arrow has the item option of #b{itemOption}#k. It's a special type of arrow, so if you have the materials, why not make some? Do you want to?");
		}
		
		if (!askBuy)
		{
			self.say("Don't have the materials? You can grab the materials by eliminating the monsters in the area! Go fight them!");
			return;
		}
		
		bool trade = false;
		
		if (index == 1) trade = Exchange(0, 4003001, -1, 4003004, -1, 2060000, 1000);
		else if (index == 2) trade = Exchange(0, 4003001, -1, 4003004, -1, 2061000, 1000);
		else if (index == 3) trade = Exchange(0, 4011000, -1, 4003001, -3, 4003004, -10, 2060001, 900);
		else if (index == 4) trade = Exchange(0, 4011000, -1, 4003001, -3, 4003004, -10, 2061001, 900);
		else if (index == 5) trade = Exchange(0, 4011001, -1, 4003001, -5, 4003005, -15, 2060002, 800);
		else if (index == 6) trade = Exchange(0, 4011001, -1, 4003001, -5, 4003005, -15, 2061002, 800);
		
		if (!trade)
		{
			self.say("Please check if you have all the items needed with you. If so, check your etc. inventory, it may be full!!");
			return;
		}
		
		self.say($"Here, take #b{unitNum} {makeItem}(s). I think it's pretty cool. Isn't it beautiful? Anytime!");
	}
	
	public override void Run()
	{
		bool askStart = AskYesNo("Do you have the ores of a jewel or mineral? With a small service fee, I can transform them into a materal for weapons and/or armors. I can even create some powerful arrows. Oh! And the service fee is #r10%#k more or less, so feel free when you need it. What do you think?");
		
		if (!askStart)
		{
			self.say("I understand. Well, if you ever find some ore or strange item, just drop by and see me. I'm going to make something for you that only I can make.");
			return;
		}
		
		int craftType = AskMenu("Alright! Before doing this, check if there is any space available in your etc. inventory. Let's see, what would you like to do?#b",
			(0, " Refine a mineral"),
			(1, " Refine a jewel"),
			(2, " Refine a rare jewel"),
			(3, " Refine a crystal"),
			(4, " Create materials"),
			(5, " Make arrows"));
		
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
				
			if (craftSelect == 0) Craft1(1, "#t4011000#", "#t4010000#s", 270);
			else if (craftSelect == 1) Craft1(2, "#t4011001#", "#t4010001#s", 270);
			else if (craftSelect == 2) Craft1(3, "#t4011002#", "#t4010002#s", 270);
			else if (craftSelect == 3) Craft1(4, "#t4011003#", "#t4010003#s", 450);
			else if (craftSelect == 4) Craft1(5, "#t4011004#", "#t4010004#s", 450);
			else if (craftSelect == 5) Craft1(6, "#t4011005#", "#t4010005#s", 450);
			else if (craftSelect == 6) Craft1(7, "#t4011006#", "#t4010006#s", 720);
		}
		else if (craftType == 1)
		{
			int craftSelect = AskMenu("What jewel do you want to refine?#b",
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
			else if (craftSelect == 7) Craft1(107, "#t4021007#", "#t4020007#s", 900);
			else if (craftSelect == 8) Craft1(108, "#t4021008#", "#t4020008#s", 2700);
				
		}
		else if (craftType == 2)
		{
			int craftSelect = AskMenu("Alright, I can refine any mineral or jewel. I just need a lot of material to do this. Which do you want to make?#b",
				(0, " #t4011007#"),
				(1, " #t4021009#"));
				
			if (craftSelect == 0) Craft1(200, "#t4011007#", "#t4011000#, #t4011001#, #t4011002#, #t4011003#, #t4011004#, #t4011005#, #t4011006#", 9000);
			else if (craftSelect == 1) Craft1(201, "#t4021009#", "#t4021000#, #t4021001#, #t4021002#, #t4021003#, #t4021004#, #t4021005#, #t4021006#, #t4021007#, #t4021008#", 13500);
		}
		else if (craftType == 3)
		{
			int craftSelect = AskMenu("Did you have a crystal by any chance? It's been a long time since I last saw one, but... if you have one, I can refine it for you. What crystal do you want to refine?#b",
				(0, " #t4005000#"),
				(1, " #t4005001#"),
				(2, " #t4005002#"),
				(3, " #t4005003#"));
			
			if (craftSelect == 0) Craft1(300, "#t4005000#", "#t4004000#s", 4500);
			else if (craftSelect == 1) Craft1(301, "#t4005001#", "#t4004001#s", 4500);
			else if (craftSelect == 2) Craft1(302, "#t4005002#", "#t4004002#s", 4500);
			else if (craftSelect == 3) Craft1(303, "#t4005003#", "#t4004003#s", 4500);
		}
		else if (craftType == 4)
		{
			int craftSelect = AskMenu("You want to make some materials, right?? Now... what kind of a material do you want to make?#b",
				(0, " Make #t4003001# with #t4000003#"),
				(1, " Make #t4003001# with #t4000018#"),
				(2, " Make #t4003000#"));
				
			if (craftSelect == 0) Craft2(1, "#t4003001#", "#t4000003#", 10, 1);
			else if (craftSelect == 1) Craft2(2, "#t4003001#", "#t4000018#", 5, 1);
			else if (craftSelect == 2) Craft2(3, "#t4003000#s", "#t4011001# and #t4011000# each", 1, 15);
		}
		else if (craftType == 5)
		{
			int craftSelect = AskMenu("You want to make arrows, right? A powerful arrow can help you a lot during combat. Let's see... What kind of arrow do you want to make?#b",
				(0, " #t2060000#"),
				(1, " #t2061000#"),
				(2, " #t2060001#"),
				(3, " #t2061001#"),
				(4, " #t2060002#"),
				(5, " #t2061002#"));
				
			if (craftSelect == 0) Craft3(1, "#t2060000#", "#v4003001# #t4003001#\r\n#v4003004# #t4003004#", 1000, "");
			else if (craftSelect == 1) Craft3(2, "#t2061000#", "#v4003001# #t4003001#\r\n#v4003004# #t4003004#", 1000, "");
			else if (craftSelect == 2) Craft3(3, "#t2060001#", "#v4011000# #t4011000#\r\n#v4003001# 3 #t4003001#s\r\n#v4003004# 10 #t4003004#s", 900, "Attack 1");
			else if (craftSelect == 3) Craft3(4, "#t2061001#", "#v4011000# #t4011000#\r\n#v4003001# 3 #t4003001#s\r\n#v4003004# 10 #t4003004#s", 900, "Attack 1");
			else if (craftSelect == 4) Craft3(5, "#t2060002#", "#v4011001# #t4011001#\r\n#v4003001# 5 #t4003001#s\r\n#v4003005# 15 #t4003005#s", 800, "Attack 2");
			else if (craftSelect == 5) Craft3(6, "#t2061002#", "#v4011001# #t4011001#\r\n#v4003001# 5 #t4003001#s\r\n#v4003005# 15 #t4003005#s", 800, "Attack 2");
		}
	}
}