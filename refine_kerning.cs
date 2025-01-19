using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Craft1(int index, string makeItem, string needItem, int reqLevel)
	{
		bool askBuy = AskYesNo($"To make one {makeItem}, I'll need the following materials. The level limit is {reqLevel}. What do you think? Do you want me to do it??\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("Oh, really? You're lacking some materials, right? Since you're going for a spin around town, go find some of the materials and bring them to me... I'll make a marvelous item for you...");
			return;
		}
		
		bool trade = false;
		
		//Claws
		if (index == 1) trade = Exchange(-2000, 4011001, -1, 4000021, -20, 4003000, -5, 1472001, 1);
		else if (index == 2) trade = Exchange(-3000, 4011000, -2, 4011001, -1, 4000021, -30, 4003000, -10, 1472004, 1);
		else if (index == 3) trade = Exchange(-15000, 4011000, -3, 4011001, -2, 4000021, -50, 4003000, -20, 1472008, 1);
		else if (index == 4) trade = Exchange(-30000, 4011000, -4, 4011001, -3, 4000021, -80, 4003000, -25, 1472011, 1);
		else if (index == 5) trade = Exchange(-40000, 4011000, -3, 4011001, -4, 4000021, -100, 4003000, -30, 1472014, 1);
		else if (index == 6) trade = Exchange(-50000, 4011000, -4, 4011001, -5, 4000030, -40, 4003000, -35, 1472018, 1);
		
		//Gloves
		else if (index == 100) trade = Exchange(-1000, 4000021, -15, 1082002, 1);
		else if (index == 101) trade = Exchange(-7000, 4000021, -30, 4000018, -20, 1082029, 1);
		else if (index == 102) trade = Exchange(-7000, 4000021, -30, 4000015, -20, 1082030, 1);
		else if (index == 103) trade = Exchange(-7000, 4000021, -30, 4000020, -20, 1082031, 1);
		else if (index == 104) trade = Exchange(-10000, 4011000, -2, 4000021, -40, 1082032, 1);
		else if (index == 105) trade = Exchange(-15000, 4011000, -2, 4011001, -1, 4000021, -10, 1082037, 1);
		else if (index == 106) trade = Exchange(-25000, 4011001, -2, 4000021, -50, 4003000, -10, 1082042, 1);
		else if (index == 107) trade = Exchange(-30000, 4011001, -3, 4011000, -1, 4000021, -60, 4003000, -15, 1082046, 1);
		else if (index == 108) trade = Exchange(-40000, 4000021, -80, 4021000, -3, 4000014, -200, 4003000, -30, 1082075, 1);
		else if (index == 109) trade = Exchange(-50000, 4021005, -3, 4021008, -1, 4000030, -40, 4003000, -30, 1082065, 1);
		else if (index == 110) trade = Exchange(-70000, 4011007, -1, 4011000, -8, 4021007, -1, 4000030, -50, 4003000, -50, 1082092, 1);
		
		if (!trade)
		{
			self.say("Please check carefully that you have everything you need, and that there is a free space in your equip. inventory.");
			return;
		}
		
		self.say($"Here! Take the {makeItem}. What do you think? Isn't it really cool? It's not every day that you see one of these beauties!");
	}
	
	private void Craft2(int index, string makeItem, string needItem)
	{
		bool askBuy = AskYesNo($"To upgrade a(n) {makeItem}, I'll need the following materials. Oh, and please make sure you don't use an item that has already been improved to do the new upgrade. What do you think? Do you want me to do it??\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("Oh, really? You're lacking some materials, right? Since you're going to stay in town, go find some of the materials and bring them to me... I'll make a marvelous item for you...");
			return;
		}
		
		bool trade = false;
		
		// Upgrading a claw
		if (index == 1) trade = Exchange(-1000, 1472001, -1, 4011002, -1, 1472002, 1);
		else if (index == 2) trade = Exchange(-2000, 1472001, -1, 4011006, -1, 1472003, 1);
		else if (index == 3) trade = Exchange(-3000, 1472004, -1, 4011001, -2, 1472005, 1);
		else if (index == 4) trade = Exchange(-5000, 1472004, -1, 4011003, -2, 1472006, 1);
		else if (index == 5) trade = Exchange(-5000, 1472000, -1, 4011001, -3, 4000021, -20, 4003001, -30, 1472007, 1);
		else if (index == 6) trade = Exchange(-10000, 1472008, -1, 4011002, -3, 1472009, 1);
		else if (index == 7) trade = Exchange(-15000, 1472008, -1, 4011003, -3, 1472010, 1);
		else if (index == 8) trade = Exchange(-20000, 1472011, -1, 4011004, -4, 1472012, 1);
		else if (index == 9) trade = Exchange(-25000, 1472011, -1, 4021008, -1, 1472013, 1);
		
		// Upgrading a glove
		else if (index == 100) trade = Exchange(-5000, 1082032, -1, 4011002, -1, 1082033, 1);
		else if (index == 101) trade = Exchange(-7000, 1082032, -1, 4021004, -1, 1082034, 1);
		else if (index == 102) trade = Exchange(-10000, 1082037, -1, 4011002, -2, 1082038, 1);
		else if (index == 103) trade = Exchange(-12000, 1082037, -1, 4021004, -2, 1082039, 1);
		else if (index == 104) trade = Exchange(-15000, 1082042, -1, 4011004, -2, 1082043, 1);
		else if (index == 105) trade = Exchange(-20000, 1082042, -1, 4011006, -1, 1082044, 1);
		else if (index == 106) trade = Exchange(-22000, 1082046, -1, 4011005, -3, 1082047, 1);
		else if (index == 107) trade = Exchange(-25000, 1082046, -1, 4011006, -2, 1082045, 1);
		else if (index == 108) trade = Exchange(-45000, 1082075, -1, 4011006, -4, 1082076, 1);
		else if (index == 109) trade = Exchange(-50000, 1082075, -1, 4021008, -2, 1082074, 1);
		else if (index == 110) trade = Exchange(-55000, 1082065, -1, 4021000, -5, 1082067, 1);
		else if (index == 111) trade = Exchange(-60000, 1082065, -1, 4011006, -2, 4021008, -1, 1082066, 1);
		else if (index == 112) trade = Exchange(-70000, 1082092, -1, 4011001, -7, 4000014, -200, 1082093, 1);
		else if (index == 113) trade = Exchange(-80000, 1082092, -1, 4011006, -7, 4000027, -150, 1082094, 1);
		
		if (!trade)
		{
			self.say("Please check carefully that you have everything you need, and that there is a free space in your equip. inventory.");
			return;
		}
		
		self.say($"Here! Take the {makeItem}. What do you think? Isn't it really cool? It's not every day that you see one of these beauties!");
	}
	
	private void Craft3(int index, string makeItem, string needItem, string itemOption)
	{
		bool askBuy = AskYesNo($"To upgrade a(n) {makeItem}, I'll need the following materials. There is also an improvement of #r{itemOption}#k on the item. Make sure you don't use an item that has already been improved as part of the new upgrade. What do you think? Você quer fazê-lo?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("Oh, really? You're lacking some materials, right? Since you're going to stay in town, go find some of the materials and bring them to me... I'll make a marvelous item for you...");
			return;
		}
		
		bool trade = false;
		
		if (index == 1) trade = Exchange(-30000, 1472014, -1, 4021000, -5, 1472015, 1);
		else if (index == 2) trade = Exchange(-30000, 1472014, -1, 4011003, -5, 1472016, 1);
		else if (index == 3) trade = Exchange(-35000, 1472014, -1, 4021008, -2, 1472017, 1);
		else if (index == 4) trade = Exchange(-40000, 1472018, -1, 4021000, -6, 1472019, 1);
		else if (index == 5) trade = Exchange(-40000, 1472018, -1, 4021005, -6, 1472020, 1);
		
		if (!trade)
		{
			self.say("Please check carefully that you have everything you need, and that there is a free space in your equip. inventory.");
			return;
		}
		
		self.say($"Here! Take the {makeItem}. What do you think? Isn't it really cool? It's not every day that you see one of these beauties!");
	}
	
	private void Craft4(int index, string makeItem, string needItem, int needNumber, int itemNumber)
	{
		int amount = AskInteger(1, 1, 100, $"With #b{needNumber} {needItem}#k, I can make {itemNumber} {makeItem}. Be glad because this one's on me. What do you think? How many would you like to make?");
		
		int nNeedNum = amount * needNumber;
		int nAllNum = amount * itemNumber;
		
		bool askBuy = AskYesNo($"You want to make #b{makeItem} {amount} times#k? I'll need #r{nNeedNum} {needItem}#k to make it.");
		
		if (!askBuy)
		{
			self.say("It seems that you don't have all the items needed for this. Since you're going to stay in town, go find some of the materials and bring them to me... I'll make a marvelous item for you...");
			return;
		}
		
		bool trade = false;
		
		if (index == 1) trade = Exchange(0, 4000003, -nNeedNum, 4003001, nAllNum);
		else if (index == 2) trade = Exchange(0, 4000018, -nNeedNum, 4003001, nAllNum);
		else if (index == 3) trade = Exchange(0, 4011001, -nNeedNum, 4011000, -nNeedNum, 4003000, nAllNum);
		
		if (!trade)
		{
			self.say("Please check carefully that you have everything you need, and that there is a free space in your etc. inventory.");
			return;
		}
		
		self.say($"Here! Take {nAllNum} {makeItem}. What do you think? Isn't it really cool? It's not every day that you see one of these beauties!");
	}
	
	public override void Run()
	{
		bool askStart = AskYesNo("Do you have a mineral or a #t4000021# by any chance? For a fee, I can make the perfect thief equipment for you. Oh yeah! Don't tell anybody about my business here in this town. So, do you really want to?");
		
		if (!askStart)
		{
			self.say("Really? You won't regret it one bit if you let me do this... if you change your mind just look for me and we'll do business...");
			return;
		}
		
		int craftType = AskMenu("Good, the fee will be reasonable, no need to worry. What do you want to make?#b",
			(0, " Make a claw"),
			(1, " Make a glove"),
			(2, " Upgrade a claw"),
			(3, " Upgrade a glove"),
			(4, " Create materials"));
		
		if (craftType == 0)
		{
			int craftSelect = AskMenu("A claw is the glove that you put on to throw shurikens. But it's useless for thieves who use daggers. Now, what kind of claw do you want me to make?",
				(0, " #b#t1472001##k(level limit: 15, thief)"),
				(1, " #b#t1472004##k(level limit: 20, thief)"),
				(2, " #b#t1472008##k(level limit: 30, thief)"),
				(3, " #b#t1472011##k(level limit: 35, thief)"),
				(4, " #b#t1472014##k(level limit: 40, thief)"),
				(5, " #b#t1472018##k(level limit: 50, thief)"));
				
			if (craftSelect == 0) Craft1(1, "#t1472001#", "#v4011001# #t4011001# \r\n#v4000021# 20 #t4000021#s \r\n#v4003000# 5 #t4003000#s \r\n2000 mesos", 15);
			else if (craftSelect == 1) Craft1(2, "#t1472004#", "#v4011000# 2 #t4011000#s \r\n#v4011001# #t4011001# \r\n#v4000021# 30 #t4000021#s \r\n#v4003000# 10 #t4003000#s \r\n3000 mesos", 20);
			else if (craftSelect == 2) Craft1(3, "#t1472008#", "#v4011000# 3 #t4011000#s \r\n#v4011001# 2 #t4011001#s \r\n#v4000021# 50 #t4000021#s \r\n#v4003000# 20 #t4003000#s \r\n15000 mesos", 30);
			else if (craftSelect == 3) Craft1(4, "#t1472011#", "#v4011000# 4 #t4011000#s \r\n#v4011001# 3 #t4011001#s \r\n#v4000021# 80#t4000021#s \r\n#v4003000# 25 #t4003000#s \r\n30000 mesos", 35);
			else if (craftSelect == 4) Craft1(5, "#t1472014#", "#v4011000# 3 #t4011000#s \r\n#v4011001# 4 #t4011001#s \r\n#v4000021# 100 #t4000021#s \r\n#v4003000# 30 #t4003000#s \r\n40000 mesos", 40);
			else if (craftSelect == 5) Craft1(6, "#t1472018#", "#v4011000# 4 #t4011000#s \r\n#v4011001# 5 #t4011001#s \r\n#v4000030# 40 #t4000030#s \r\n#v4003000# 35 #t4003000#s \r\n50000 mesos", 50);
		}
		else if (craftType == 1)
		{
			int craftSelect = AskMenu("Now... what kind of glove do you want me to make?",
				(0, " #b#t1082002##k(level limit: 10, common)"),
				(1, " #b#t1082029##k(level limit: 15, thief)"),
				(2, " #b#t1082030##k(level limit: 15, thief)"),
				(3, " #b#t1082031##k(level limit: 15, thief)"),
				(4, " #b#t1082032##k(level limit: 20, thief)"),
				(5, " #b#t1082037##k(level limit: 25, thief)"),
				(6, " #b#t1082042##k(level limit: 30, thief)"),
				(7, " #b#t1082046##k(level limit: 35, thief)"),
				(8, " #b#t1082075##k(level limit: 40, thief)"),
				(9, " #b#t1082065##k(level limit: 50, thief)"),
				(10, " #b#t1082092##k(level limit: 60, thief)"));
				
			if (craftSelect == 0) Craft1(100, "#t1082002#", "#v4000021# 15 #t4000021#s \r\n1,000 mesos", 10);
			else if (craftSelect == 1) Craft1(101, "#t1082029#", "#v4000021# 30 #t4000021#s \r\n#v4000018# 20 #t4000018#s \r\n7,000 mesos", 15);	
			else if (craftSelect == 2) Craft1(102, "#t1082030#", "#v4000021# 30 #t4000021#s \r\n#v4000015# 20 #t4000015#s \r\n7,000 mesos", 15);
			else if (craftSelect == 3) Craft1(103, "#t1082031#", "#v4000021# 30 #t4000021#s \r\n#v4000020# 20 #t4000020#s \r\n7,000 mesos", 15);
			else if (craftSelect == 4) Craft1(104, "#t1082032#", "#v4011000# 2 #t4011000#s \r\n#v4000021# 40 #t4000021#s \r\n10,000 mesos", 20);
			else if (craftSelect == 5) Craft1(105, "#t1082037#", "#v4011000# 2 #t4011000#s \r\n#v4011001# #t4011001# \r\n#v4000021# 10 #t4000021#s \r\n15,000 mesos", 25);
			else if (craftSelect == 6) Craft1(106, "#t1082042#", "#v4011001# 2 #t4011001#s \r\n#v4000021# 50 #t4000021#s \r\n#v4003000# 10 #t4003000#s \r\n25,000 mesos", 30);
			else if (craftSelect == 7) Craft1(107, "#t1082046#", "#v4011001# 3 #t4011001#s \r\n#v4011000# #t4011000# \r\n#v4000021# 60 #t4000021#s \r\n#v4003000# 15 #t4003000#s \r\n30,000 mesos", 35);
			else if (craftSelect == 8) Craft1(108, "#t1082075#", "#v4021000# 3 #t4021000#s \r\n#v4000014# 200 #t4000014#s \r\n#v4000021# 80 #t4000021#s \r\n#v4003000# 30 #t4003000#s \r\n40,000 mesos", 40);
			else if (craftSelect == 9) Craft1(109, "#t1082065#", "#v4021005# 3 #t4021005#s \r\n#v4021008# #t4021008# \r\n#v4000030# 40 #t4000030#s \r\n#v4003000# 30 #t4003000#s \r\n50,000 mesos", 50);
			else if (craftSelect == 10) Craft1(110, "#t1082092#", "#v4011007# #t4011007# \r\n#v4011000# 8 #t4011000#s \r\n#v4021007# #t4021007# \r\n#v4000030# 50 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n70,000 mesos", 60);
		}
		else if (craftType == 2)
		{
			self.say("You want to upgrade a claw? Ok then. But I'll give you some advice: All the items that will be used for the upgrade will disappear, and if you're using an item that has already been #renhanced#k with a scroll, there will be no effect when upgraded. Take this into consideration when making your decision, alright?");
			
			int craftSelect = AskMenu("A claw is the equipment that you wear to throw shurikens. But it's useless for thieves who use daggers. Well, what kind of Claw do you want to make?",
				(0, " #b#t1472002##k(level limit: 15, thief)"),
				(1, " #b#t1472003##k(level limit: 15, thief)"),
				(2, " #b#t1472005##k(level limit: 20, thief)"),
				(3, " #b#t1472006##k(level limit: 20, thief)"),
				(4, " #b#t1472007##k(level limit: 25, thief)"),
				(5, " #b#t1472009##k(level limit: 30, thief)"),
				(6, " #b#t1472010##k(level limit: 30, thief)"),
				(7, " #b#t1472012##k(level limit: 35, thief)"),
				(8, " #b#t1472013##k(level limit: 35, thief)"),
				(9, " #b#t1472015##k(level limit: 40, thief)"),
				(10, " #b#t1472016##k(level limit: 40, thief)"),
				(11, " #b#t1472017##k(level limit: 40, thief)"),
				(12, " #b#t1472019##k(level limit: 50, thief)"),
				(13, " #b#t1472020##k(level limit: 50, thief)"));
				
			if (craftSelect == 0) Craft2(1, "#t1472002#", "#v1472001# #t1472001# \r\n#v4011002# #t4011002# \r\n1,000 mesos");
			else if (craftSelect == 1) Craft2(2, "#t1472003#", "#v1472001# #t1472001# \r\n#v4011006# #t4011006# \r\n2,000 mesos");
			else if (craftSelect == 2) Craft2(3, "#t1472005#", "#v1472004# #t1472004# \r\n#v4011001# 2 #t4011001#s \r\n3,000 mesos");
			else if (craftSelect == 3) Craft2(4, "#t1472006#", "#v1472004# #t1472004# \r\n#v4011003# 2 #t4011003#s \r\n5,000 mesos");
			else if (craftSelect == 4) Craft2(5, "#t1472007#", "#v1472000# #t1472000# \r\n#v4011001# 3 #t4011001#s \r\n#v4000021# 20 #t4000021#s \r\n#v4003001# 30 #t4003001#s \r\n5,000 mesos");
			else if (craftSelect == 5) Craft2(6, "#t1472009#", "#v1472008# #t1472008# \r\n#v4011002# 3 #t4011002#s \r\n10,000 mesos");
			else if (craftSelect == 6) Craft2(7, "#t1472010#", "#v1472008# #t1472008# \r\n#v4011003# 3 #t4011003#s \r\n15,000 mesos");
			else if (craftSelect == 7) Craft2(8, "#t1472012#", "#v1472011# #t1472011# \r\n#v4011004# 4 #t4011004#s \r\n20,000 mesos");
			else if (craftSelect == 8) Craft2(9, "#t1472013#", "#v1472011# #t1472011# \r\n#v4021008# #t4021008# \r\n25,000 mesos");
			else if (craftSelect == 9) Craft3(1, "#t1472015#", "#v1472014# #t1472014# \r\n#v4021000# 5 #t4021000#s \r\n30,000 mesos", "DEX +2");
			else if (craftSelect == 10) Craft3(2, "#t1472016#", "#v1472014# #t1472014# \r\n#v4011003# 5 #t4011003#s \r\n30,000 mesos", "LUK +2");
			else if (craftSelect == 11) Craft3(3, "#t1472017#", "#v1472014# #t1472014# \r\n#v4021008# 2 #t4021008#s \r\n35,000 mesos", "LUK +3");
			else if (craftSelect == 12) Craft3(4, "#t1472019#", "#v1472018# #t1472018# \r\n#v4021000# 6 #t4021000#s \r\n40,000 mesos", "DEX +3");
			else if (craftSelect == 13) Craft3(5, "#t1472020#", "#v1472018# #t1472018# \r\n#v4021005# 6 #t4021005#s \r\n40,000 mesos", "LUK +3");
		}
		else if (craftType == 3)
		{
			self.say("You want to upgrade a glove? Ok then. But I'll give you some advice: All the items that will be used for the upgrade will disappear, and if you're using an item that has already been #renhanced#k with a scroll, there will be no effect when upgraded. Take this into consideration when making your decision, alright?");
			
			int craftSelect = AskMenu("So... what kind of glove do you want to upgrade?",
				(0, " #b#t1082033##k(level limit: 20, thief"),
				(1, " #b#t1082034##k(level limit: 20, thief"),
				(2, " #b#t1082038##k(level limit: 25, thief"),
				(3, " #b#t1082039##k(level limit: 25, thief"),
				(4, " #b#t1082043##k(level limit: 30, thief"),
				(5, " #b#t1082044##k(level limit: 30, thief"),
				(6, " #b#t1082047##k(level limit: 35, thief"),
				(7, " #b#t1082045##k(level limit: 35, thief"),
				(8, " #b#t1082076##k(level limit: 40, thief"),
				(9, " #b#t1082074##k(level limit: 40, thief"),
				(10, " #b#t1082067##k(level limit: 50, thief"),
				(11, " #b#t1082066##k(level limit: 50, thief"),
				(12, " #b#t1082093##k(level limit: 60, thief"),
				(13, " #b#t1082094##k(level limit: 60, thief"));
				
			if (craftSelect == 0) Craft2(100, "#t1082033#", "#v1082032# #t1082032# \r\n#v4011002# #t4011002# \r\n5,000 mesos");
			else if (craftSelect == 1) Craft2(101, "#t1082034#", "#v1082032# #t1082032# \r\n#v4021004# #t4021004# \r\n7,000 mesos");
			else if (craftSelect == 2) Craft2(102, "#t1082038#", "#v1082037# #t1082037# \r\n#v4011002# 2 #t4011002#s \r\n10,000 mesos");
			else if (craftSelect == 3) Craft2(103, "#t1082039#", "#v1082037# #t1082037# \r\n#v4021004# 2 #t4021004#s \r\n12,000 mesos");
			else if (craftSelect == 4) Craft2(104, "#t1082043#", "#v1082042# #t1082042# \r\n#v4011004# 2 #t4011004#s \r\n15,000 mesos");
			else if (craftSelect == 5) Craft2(105, "#t1082044#", "#v1082042# #t1082042# \r\n#v4011006# #t4011006# \r\n20,000 mesos");
			else if (craftSelect == 6) Craft2(106, "#t1082047#", "#v1082046# #t1082046# \r\n#v4011005# 3 #t4011005#s \r\n22,000 mesos");
			else if (craftSelect == 7) Craft2(107, "#t1082045#", "#v1082046# #t1082046# \r\n#v4011006# 2 #t4011006#s \r\n25,000 mesos");
			else if (craftSelect == 8) Craft2(108, "#t1082076#", "#v1082075# #t1082075# \r\n#v4011006# 4 #t4011006#s \r\n45,000 mesos");
			else if (craftSelect == 9) Craft2(109, "#t1082074#", "#v1082075# #t1082075# \r\n#v4021008# 2 #t4021008#s \r\n50,000 mesos");
			else if (craftSelect == 10) Craft2(110, "#t1082067#", "#v1082065# #t1082065# \r\n#v4021000# 5 #t4021000#s \r\n55,000 mesos");
			else if (craftSelect == 11) Craft2(111, "#t1082066#", "#v1082065# #t1082065# \r\n#v4011006# 2 #t4011006#s \r\n#v4021008# #t4021008# \r\n60,000 mesos");
			else if (craftSelect == 12) Craft2(112, "#t1082093#", "#v1082092# #t1082092# \r\n#v4011001# 7 #t4011001#s \r\n#v4000014# 200 #t4000014#s \r\n70,000 mesos");
			else if (craftSelect == 13) Craft2(113, "#t1082094#", "#v1082092# #t1082092# \r\n#v4011006# 7 #t4011006#s \r\n#v4000027# 150 #t4000027#s \r\n80,000 mesos");
		}
		else if (craftType == 4)
		{
			int craftSelect = AskMenu("Did you say you want to create a material? Very well... what kind?#b",
				(0, " Create #t4003001# with #t4000003#"),
				(1, " Create #t4003001# with #t4000018#"),
				(2, " Create #t4003000#s"));
				
			if (craftSelect == 0) Craft4(1, "#t4003001#(s)", "#t4000003#es", 10, 1);
			else if (craftSelect == 1) Craft4(2, "#t4003001#(s)", "#t4000018#s", 5, 1);
			else if (craftSelect == 2) Craft4(3, "#t4003000#s", "#t4011001# and #t4011000# each", 1, 15);
		}
	}
}