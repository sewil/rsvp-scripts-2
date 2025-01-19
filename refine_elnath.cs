using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	//refine
	private void Craft1(int index, string makeItem, string needItem, int unitPrice)
	{
		if (index == 200 || index == 201)
		{
			int amount = AskInteger(1, 1, 100, $"Very well, very well ... how many #b{makeItem}s#k do you want to make?");
			
			int nPrice = unitPrice * amount;
			
			bool askBuy = AskYesNo($"Okay, do you want to make #b{amount} {makeItem}#k(s)?? Then you'll need#r {nPrice} mesos and {amount} {needItem}#k each. What do you think? Do you really want to make it?");
			
			if (!askBuy)
			{
				self.say("I understand. Is the service fee too high for you? Know that I will be in this town for a long time, so if some day you want to refine anything just bring it to me.");
				return;
			}
			
			bool trade = false;
			
			//rare jewels
			if (index == 200) trade = Exchange(-nPrice, 4011000, -amount, 4011001, -amount, 4011002, -amount, 4011003, -amount, 4011004, -amount, 4011005, -amount, 4011006, -amount, 4011007, amount);
			else if (index == 201) trade = Exchange(-nPrice, 4021000, -amount, 4021001, -amount, 4021002, -amount, 4021003, -amount, 4021004, -amount, 4021005, -amount, 4021006, -amount, 4021007, -amount, 4021008, -amount, 4021009, amount);
			
			if (!trade)
			{
				self.say("Hmm... Please make sure you have all the necessary materials, and that there's a free space in your etc. inventory.");
				return;
			}
			
			self.say($"Here! Take #b{amount} {makeItem}#k(s). It's been 50 years, but I still have skills. If you need my help in the near future, feel free to stop by.");
		}
		else
		{
			int amount = AskInteger(1, 1, 100, $"To make a(n) {makeItem}, I need the following materials. How many would you like to make?\r\n\r\n#b{needItem}\r\n{unitPrice} mesos#k");
			
			int nPrice = unitPrice * amount;
			int nAllNum = amount * 10;
			
			bool askBuy = AskYesNo($"Do you want to make #b{amount} {makeItem}(s)#k?? Then you'll need#r {nPrice} mesos and {nAllNum} {needItem}#k(s). What do you think? Do you want to make it?");
			
			if (!askBuy)
			{
				self.say("I see... Is the service fee too high for you? Know that I will be in this town for a long time, so if some day you want to refine anything just bring it to me.");
				return;
			}
			
			bool trade = false;
			
			//minerals
			if (index == 1) trade = Exchange(-nPrice, 4010000, -nAllNum, 4011000, amount);
			else if (index == 2) trade = Exchange(-nPrice, 4010001, -nAllNum, 4011001, amount);
			else if (index == 3) trade = Exchange(-nPrice, 4010002, -nAllNum, 4011002, amount);
			else if (index == 4) trade = Exchange(-nPrice, 4010003, -nAllNum, 4011003, amount);
			else if (index == 5) trade = Exchange(-nPrice, 4010004, -nAllNum, 4011004, amount);
			else if (index == 6) trade = Exchange(-nPrice, 4010005, -nAllNum, 4011005, amount);
			else if (index == 7) trade = Exchange(-nPrice, 4010006, -nAllNum, 4011006, amount);
			//jewels
			else if (index == 100) trade = Exchange(-nPrice, 4020000, -nAllNum, 4021000, amount);
			else if (index == 101) trade = Exchange(-nPrice, 4020001, -nAllNum, 4021001, amount);
			else if (index == 102) trade = Exchange(-nPrice, 4020002, -nAllNum, 4021002, amount);
			else if (index == 103) trade = Exchange(-nPrice, 4020003, -nAllNum, 4021003, amount);
			else if (index == 104) trade = Exchange(-nPrice, 4020004, -nAllNum, 4021004, amount);
			else if (index == 105) trade = Exchange(-nPrice, 4020005, -nAllNum, 4021005, amount);
			else if (index == 106) trade = Exchange(-nPrice, 4020006, -nAllNum, 4021006, amount);
			else if (index == 107) trade = Exchange(-nPrice, 4020007, -nAllNum, 4021007, amount);
			else if (index == 108) trade = Exchange(-nPrice, 4020008, -nAllNum, 4021008, amount);
			//crystals
			else if (index == 300) trade = Exchange(-nPrice, 4004000, -nAllNum, 4005000, amount);
			else if (index == 301) trade = Exchange(-nPrice, 4004001, -nAllNum, 4005001, amount);
			else if (index == 302) trade = Exchange(-nPrice, 4004002, -nAllNum, 4005002, amount);
			else if (index == 303) trade = Exchange(-nPrice, 4004003, -nAllNum, 4005003, amount);
			else if (index == 304) trade = Exchange(-nPrice, 4004004, -nAllNum, 4005004, amount);
			
			if (!trade)
			{
				self.say("Hmm... Please make sure you have all the necessary materials, and that there's a free space in your etc. inventory.");
				return;
			}
			
			self.say($"Here! Take #b{amount} {makeItem}(s)#k. It's been 50 years, but I still have skills. If you need my help in the near future, feel free to stop by.");
		}
	}
	
	//materials
	private void Craft2(int index, string makeItem, string needItem, int needNumber, int itemNumber)
	{
		int amount = AskInteger(1, 1, 100, $"I can make #b{itemNumber} {makeItem}(s) with {needNumber} {needItem}#k. This one is free, as long as you have the necessary materiais, so you can be happy. What do you think? How many do you want to make?");
		
		int nNeedNum = amount * needNumber;
		int nAllNum = amount * itemNumber;
		
		bool askBuy = AskYesNo($"Okay, do you want to make #b{makeItem}#k {amount} times? I'll need #r{nNeedNum} {needItem}(s)#k to make it. Do you still want me to do it?");
		
		if (!askBuy)
		{
			self.say("Don't have the materials? You can obtain some by eliminating the monsters around here, so work hard on the task...");
			return;
		}
		
		bool trade = false;
		
		if (index == 1) trade = Exchange(0, 4000003, -nNeedNum, 4003001, nAllNum);
		else if (index == 2) trade = Exchange(0, 4000018, -nNeedNum, 4003001, nAllNum);
		else if (index == 3) trade = Exchange(0, 4011001, -nNeedNum, 4011000, -nNeedNum, 4003000, nAllNum);
		
		
		if (!trade)
		{
			self.say("Hmm... Please make sure you have all the necessary materials, and that there's a free space in your etc. inventory.");
			return;
		}
		
		self.say($"Here! Take #b{nAllNum} {makeItem}#k! It's been 50 years, but I still have skills. If you need my help in the near future, feel free to stop by.");
	}
	
	private void Craft3(int index, string makeItem, string needItem, int unitNum, string itemOption)
	{
		bool askBuy;
		
		if (itemOption == "")
		{
			askBuy = AskYesNo($"To make #b{unitNum} {makeItem}#k, I need the following materials. If you have the materials, it will be much better if you create the item here than if you buy it at a shop. So, do you want to make the item?\r\n\r\n#b{needItem}");
		}
		else
		{
			askBuy = AskYesNo($"Do you want to make #b{unitNum} {makeItem}#k? Bring me the following items and I'll make it for you. By the way, this arrow has an improvement of #r{itemOption}#k on it. It's a special kind of arrow, so it wouldn't be a bad idea if you have the materials. Do you want to do it?\r\n\r\n#b{needItem}");
		}
		
		if (!askBuy)
		{
			self.say("We take items that are important to bowmen and make them at a low price, so take a good look around. You also know that nothing is FREE, right?");
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
			self.say("Please make sure you have all the items you need, and that there's room in your equip. inventory.");
			return;
		}
		
		self.say($"Hey! Here, take the {unitNum} {makeItem}. It's been 50 years, but I still have skills. If you need my help in the near future, feel free to stop by.");
	}
	
	public override void Run()
	{
		bool askStart = AskYesNo("You seem to have quite a few ores and jewels with you. With a little service fee, I can refine those into materials you need to create weapons or shields. I've been doing that for 50 years so it's a piece of cake. What do you think? Do you want me to do it?");
		
		if (!askStart)
		{
			self.say("I understand. Is the service fee too high for you? But understand that I will be in this town for a long time, so if some day you want to refine anything, just bring it to me.");
			return;
		}
		
		int craftType = AskMenu("Good choice! Give me the ores and the service fee, which I can refine so that they will be of some use. Before doing this, don't forget to check your etc. inventory to see if you have enough space for new items. Let's see, what would you like me to do?#b",
			(0, " Refine the ore of a mineral"),
			(1, " Refine the ore of a jewel"),
			(2, " Refine a rare jewel"),
			(3, " Refine a crystal"),
			(4, " Create materials"),
			(5, " Make arrows"));
		
		if (craftType == 0)
		{
			int craftSelect = AskMenu("Which of these minerals would you like to make?#b",
				(0, " #t4011000#"),
				(1, " #t4011001#"),
				(2, " #t4011002#"),
				(3, " #t4011003#"),
				(4, " #t4011004#"),
				(5, " #t4011005#"),
				(6, " #t4011006#"));
				
			if (craftSelect == 0) Craft1(1, "#t4011000#", "#t4010000#s", 300);
			else if (craftSelect == 1) Craft1(2, "#t4011001#", "#t4010001#s", 300);
			else if (craftSelect == 2) Craft1(3, "#t4011002#", "#t4010002#s", 300);
			else if (craftSelect == 3) Craft1(4, "#t4011003#", "#t4010003#s", 500);
			else if (craftSelect == 4) Craft1(5, "#t4011004#", "#t4010004#s", 500);
			else if (craftSelect == 5) Craft1(6, "#t4011005#", "#t4010005#s", 500);
			else if (craftSelect == 6) Craft1(7, "#t4011006#", "#t4010006#s", 800);
		}
		else if (craftType == 1)
		{
			int craftSelect = AskMenu("Which jewel would you like to refine?#b",
				(0, " #t4021000#"),
				(1, " #t4021001#"),
				(2, " #t4021002#"),
				(3, " #t4021003#"),
				(4, " #t4021004#"),
				(5, " #t4021005#"),
				(6, " #t4021006#"),
				(7, " #t4021007#"),
				(8, " #t4021008#"));
				
			if (craftSelect == 0) Craft1(100, "#t4021000#", "#t4020000#s", 500);
			else if (craftSelect == 1) Craft1(101, "#t4021001#", "#t4020001#s", 500);	
			else if (craftSelect == 2) Craft1(102, "#t4021002#", "#t4020002#s", 500);
			else if (craftSelect == 3) Craft1(103, "#t4021003#", "#t4020003#s", 500);
			else if (craftSelect == 4) Craft1(104, "#t4021004#", "#t4020004#s", 500);
			else if (craftSelect == 5) Craft1(105, "#t4021005#", "#t4020005#s", 500);
			else if (craftSelect == 6) Craft1(106, "#t4021006#", "#t4020006#s", 500);
			else if (craftSelect == 7) Craft1(107, "#t4021007#", "#t4020007#s", 1000);
			else if (craftSelect == 8) Craft1(108, "#t4021008#", "#t4020008#s", 3000);
				
		}
		else if (craftType == 2)
		{
			int craftSelect = AskMenu("Yes, I can even refine rare jewels. I may need a lot of material to do this. But it is possible. What jewel would you like to refine?#b",
				(0, " #t4011007#"),
				(1, " #t4021009#"));
				
			if (craftSelect == 0) Craft1(200, "#t4011007#", "refinado #t4011000#, #t4011001#, #t4011002#, #t4011003#, #t4011004#, #t4011005#, #t4011006#", 10000);
			else if (craftSelect == 1) Craft1(201, "#t4021009#", "refinado #t4021000#, #t4021001#, #t4021002#, #t4021003#, #t4021004#, #t4021005#, #t4021006#, #t4021007#, #t4021008#", 15000);
		}
		else if (craftType == 3)
		{
			int craftSelect = AskMenu("Hmmm... Do you really have the crystal? I haven't seen those in a while so I don't believe you, but if you do have them, I can refine it so it can become something useful. So, what crystal would you like to refine?#b",
				(0, " #t4005000#"),
				(1, " #t4005001#"),
				(2, " #t4005002#"),
				(3, " #t4005003#"),
				(4, " #t4005004#"));
			
			if (craftSelect == 0) Craft1(300, "#t4005000#", "#t4004000#", 5000);
			else if (craftSelect == 1) Craft1(301, "#t4005001#", "#t4004001#", 5000);
			else if (craftSelect == 2) Craft1(302, "#t4005002#", "#t4004002#", 5000);
			else if (craftSelect == 3) Craft1(303, "#t4005003#", "#t4004003#", 5000);
			else if (craftSelect == 4) Craft1(304, "#t4005004#", "#t4004004#", 100000);
		}
		else if (craftType == 4)
		{
			int craftSelect = AskMenu("So, you want to create materials! Let's see, what kind of material would you like to make?#b",
				(0, " Create #t4003001# with #t4000003#es"),
				(1, " Create #t4003001# with #t4000018#s"),
				(2, " Create #t4003000#s"));
				
			if (craftSelect == 0) Craft2(1, "#t4003001#", "#t4000003#", 10, 1);
			else if (craftSelect == 1) Craft2(2, "#t4003001#", "#t4000018#s", 5, 1);
			else if (craftSelect == 2) Craft2(3, "#t4003000#s", "#t4011001#(s) and #t4011000#(s) each", 1, 15);
		}
		else if (craftType == 5)
		{
			int craftSelect = AskMenu("So, you want to make arrows! The better the arrow, the more advantages you will have in battle. Let's see, what kind of arrow would you like me to make?#b",
				(0, " #t2060000#"),
				(1, " #t2061000#"),
				(2, " #t2060001#"),
				(3, " #t2061001#"),
				(4, " #t2060002#"),
				(5, " #t2061002#"));
				
			if (craftSelect == 0) Craft3(1, "#t2060000#", "#v4003001# #t4003001# \r\n#v4003004# #t4003004# ", 1000, "");
			else if (craftSelect == 1) Craft3(2, "#t2061000#", "#v4003001# #t4003001# \r\n#v4003004# #t4003004# ", 1000, "");
			else if (craftSelect == 2) Craft3(3, "#t2060001#", "#v4011000# #t4011000# \r\n#v4003001# 3 #t4003001#s \r\n#v4003004# 10 #t4003004#s ", 900, "Atk. +1");
			else if (craftSelect == 3) Craft3(4, "#t2061001#", "#v4011000# #t4011000# \r\n#v4003001# 3 #t4003001#s \r\n#v4003004# 10 #t4003004#s ", 900, "Atk. +1");
			else if (craftSelect == 4) Craft3(5, "#t2060002#", "#v4011001# #t4011001# \r\n#v4003001# 5 #t4003001#s \r\n#v4003005# 15 #t4003005#s ", 800, "Atk. +2");
			else if (craftSelect == 5) Craft3(6, "#t2061002#", "#v4011001# #t4011001# \r\n#v4003001# 5 #t4003001#s \r\n#v4003005# 15 #t4003005#s ", 800, "Atk. +2");
		}
	}
}