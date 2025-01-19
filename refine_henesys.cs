using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Craft1(int index, string makeItem, string needItem, int reqLevel)
	{
		bool askBuy = AskYesNo($"To make a(n) {makeItem}, I'll need the following materials. The level limit is {reqLevel}, and please make sure that you aren't using an item that is a material in the upgrade. What do you think? Do you want one?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("Oh, really? You don't have the materials? Please come back later. It looks like I'm going to stay here for a while.");
			return;
		}
		
		bool trade = false;
		
		// Making a bow
		if (index == 1) trade = Exchange(-800, 4003001, -5, 4000000, -30, 1452002, 1);
		else if (index == 2) trade = Exchange(-2000, 4011001, -1, 4003000, -3, 1452003, 1);
		else if (index == 3) trade = Exchange(-3000, 4003001, -30, 4000016, -50, 1452001, 1);
		else if (index == 4) trade = Exchange(-5000, 4011001, -2, 4021006, -2, 4003000, -8, 1452000, 1);
		else if (index == 5) trade = Exchange(-30000, 4011001, -5, 4011006, -5, 4021003, -3, 4021006, -2, 4003000, -30, 1452005, 1);
		else if (index == 6) trade = Exchange(-40000, 4011004, -7, 4021000, -6, 4021004, -3, 4003000, -35, 1452006, 1);
		else if (index == 7) trade = Exchange(-80000, 4021008, -1, 4011001, -10, 4011006, -3, 4000014, -50, 4003000, -40, 1452007, 1);
		
		// Making a crossbow
		else if (index == 100) trade = Exchange(-1000, 4003001, -7, 4003000, -2, 1462001, 1);
		else if (index == 101) trade = Exchange(-2000, 4003001, -20, 4011001, -1, 4003000, -5, 1462002, 1);
		else if (index == 102) trade = Exchange(-3000, 4003001, -50, 4011001, -1, 4003000, -8, 1462003, 1);
		else if (index == 103) trade = Exchange(-10000, 4011001, -2, 4021006, -1, 4021002, -1, 4003000, -10, 1462000, 1);
		else if (index == 104) trade = Exchange(-30000, 4011001, -5, 4011005, -5, 4021006, -3, 4003001, -50, 4003000, -15, 1462004, 1);
		else if (index == 105) trade = Exchange(-50000, 4021008, -1, 4011001, -8, 4011006, -4, 4021006, -2, 4003000, -20, 1462005, 1);
		else if (index == 106) trade = Exchange(-80000, 4021008, -2, 4011004, -6, 4003001, -30, 4003000, -30, 1462006, 1);
		else if (index == 107) trade = Exchange(-100000, 4021008, -2, 4011006, -5, 4021006, -3, 4003001, -40, 4003000, -40, 1462007, 1);
		
		// Making a glove
		else if (index == 200) trade = Exchange(-5000, 4000021, -15, 4000009, -20, 1082012, 1);
		else if (index == 201) trade = Exchange(-10000, 4000021, -20, 4000009, -20, 4011001, -2, 1082013, 1);
		else if (index == 202) trade = Exchange(-15000, 4000021, -40, 4000009, -50, 4011006, -2, 1082016, 1);
		else if (index == 203) trade = Exchange(-20000, 4000021, -50, 4021001, -1, 4011006, -2, 1082048, 1);
		else if (index == 204) trade = Exchange(-30000, 4000021, -60, 4011001, -3, 4011000, -1, 4003000, -15, 1082068, 1);
		else if (index == 205) trade = Exchange(-40000, 4000021, -80, 4021002, -3, 4011001, -3, 4021000, -1, 4003000, -25, 1082071, 1);
		else if (index == 206) trade = Exchange(-50000, 4011004, -3, 4021002, -2, 4011006, -1, 4000030, -40, 4003000, -35, 1082084, 1);
		else if (index == 207) trade = Exchange(-70000, 4011007, -1, 4021006, -8, 4011006, -2, 4000030, -50, 4003000, -50, 1082089, 1);
		
		if (!trade)
		{
			self.say("Please check carefully that you have all the items you need, and if your equip. inventory is full or not.");
			return;
		}
		
		self.say($"Hey! Here, take the {makeItem}. It was a little extra work, but.... it turned out marvelously. Please come talk to me again if you need anything else. Until that day comes, see you later..");
	}
	
	private void Craft2(int index, string makeItem, string needItem, int reqLevel)
	{
		bool askBuy = AskYesNo($"To upgrade a(n) {makeItem}, I'll need the following materials. The level limit is {reqLevel} and please make sure that you aren't going to use an item that is a material in the upgrade. What do you think? Do you want one?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("Oh, really? You don't have the materials? Please come back later. It looks like I'm going to stay here for a while.");
			return;
		}
		
		bool trade = false;
		
		// Upgrading a glove
		if (index == 1) trade = Exchange(-5000, 1082013, -1, 4021000, -1, 1082014, 1);
		else if (index == 2) trade = Exchange(-7000, 1082013, -1, 4021003, -2, 1082015, 1);
		else if (index == 3) trade = Exchange(-10000, 1082016, -1, 4021000, -3, 1082017, 1);
		else if (index == 4) trade = Exchange(-12000, 1082016, -1, 4021008, -1, 1082018, 1);
		else if (index == 5) trade = Exchange(-15000, 1082048, -1, 4021003, -3, 1082049, 1);
		else if (index == 6) trade = Exchange(-20000, 1082048, -1, 4021008, -1, 1082050, 1);
		else if (index == 7) trade = Exchange(-22000, 1082068, -1, 4011002, -4, 1082069, 1);
		else if (index == 8) trade = Exchange(-25000, 1082068, -1, 4011006, -2, 1082070, 1);
		else if (index == 9) trade = Exchange(-30000, 1082071, -1, 4011006, -4, 1082072, 1);
		else if (index == 10) trade = Exchange(-40000, 1082071, -1, 4021008, -2, 1082073, 1);
		else if (index == 11) trade = Exchange(-55000, 1082084, -1, 4021000, -5, 4011000, -1, 1082085, 1);
		else if (index == 12) trade = Exchange(-60000, 1082084, -1, 4021008, -2, 4011006, -2, 1082083, 1);
		else if (index == 13) trade = Exchange(-70000, 1082089, -1, 4021007, -1, 4021000, -5, 1082090, 1);
		else if (index == 14) trade = Exchange(-80000, 1082089, -1, 4021007, -2, 4021008, -2, 1082091, 1);
		
		if (!trade)
		{
			self.say("Please check carefully that you have all the items you need, and if your etc. inventory is full or not.");
			return;
		}
		
		self.say($"Hey! Here, take the {makeItem}. It was a little extra work, but.... it turned out marvelously. Please come talk to me again if you need anything else. Until that day comes, see you later..");
	}
	
	private void Craft3(int index, string makeItem, string needItem, int needNumber, int itemNumber)
	{
		int amount = AskInteger(1, 1, 100, $"With #b{needNumber} {needItem}#k, I can create {itemNumber} {makeItem}(s). Bring me the materials and I can make it for you for free. Now... how many would you like me to make?");
		
		int nNeedNum = amount * needNumber;
		int nAllNum = amount * itemNumber;
		
		bool askBuy = AskYesNo($"You want to make #b{makeItem}#k {amount} times? I'll need #r{nNeedNum} {needItem}#k.");
		
		if (!askBuy)
		{
			self.say("Oh, really? You don't have the materials? Please come back later. It looks like I'm going to stay here for a while.");
			return;
		}
		
		bool trade = false;
		
		if (index == 1) trade = Exchange(0, 4000003, -nNeedNum, 4003001, nAllNum);
		else if (index == 2) trade = Exchange(0, 4000018, -nNeedNum, 4003001, nAllNum);
		else if (index == 3) trade = Exchange(0, 4011001, -nNeedNum, 4011000, -nNeedNum, 4003000, nAllNum);
		
		if (!trade)
		{
			self.say("Please check carefully that you have all the items you need, and if your etc. inventory is full or not.");
			return;
		}
		
		self.say($"Hey! Here, take the {nAllNum} {makeItem}(s). It was a little extra work, but.... it turned out marvelously. Please come talk to me again if you need anything else. Until that day comes, see you later..");
	}
	
	private void Craft4(int index, string makeItem, string needItem, int unitNum, string itemOption)
	{
		bool askBuy = false;
		
		if (itemOption == "")
		{
			askBuy = AskYesNo($"To make #b{unitNum} {makeItem}#k(s), I need the following items. If you have the materials, it will be much better for you to create the item here than if you buy it at the shop. Do you really want to?\r\n\r\n#b{needItem}");
		}
		else
		{
			askBuy = AskYesNo($"To make #b{unitNum} {makeItem}#k(s), I need the following items. By the way, this arrow also has an improvement of #b{itemOption}k on it. It's a special type of arrow, so if you have the necessary materials, why not make some? Do you really want me to make them?\r\n\r\n#b{needItem}");
		}
		
		if (!askBuy)
		{
			self.say("I make important items for bowmen and sell them for a reasonable price, so feel free to look around. You know that nothing is free, right?");
			return;
		}
		
		bool trade = false;
		
		// Making an arrow
		if (index == 1) trade = Exchange(0, 4003001, -1, 4003004, -1, 2060000, 1000);
		else if (index == 2) trade = Exchange(0, 4003001, -1, 4003004, -1, 2061000, 1000);
		else if (index == 3) trade = Exchange(0, 4011000, -1, 4003001, -3, 4003004, -10, 2060001, 900);
		else if (index == 4) trade = Exchange(0, 4011000, -1, 4003001, -3, 4003004, -10, 2061001, 900);
		
		if (!trade)
		{
			self.say("Please check carefully that you have all the items you need, and if your use inventory is full or not.");
			return;
		}
		
		self.say($"Hey! Here, take the" + unitNum + " " + makeItem + ". It was a little extra work, but.... it turned out marvelously. Please come talk to me again if you need anything else. Until that day comes, see you later..");
	}
	
	public override void Run()
	{
		bool askStart = AskYesNo("Hey you~ Do you need anything? Well, nothing is free here, but... with a few materials and a small service fee, I can make some items for you. So, what do you think? Want to make a good deal? Just don't let anyone in this town know about it.");
		
		if (!askStart)
		{
			self.say("You don't look very interested. If you need anything later, just come back here. I can make items that you won't find in shops.");
			return;
		}
		
		int craftType = AskMenu("Great~! What can I make for you? Just tell me what you need!#b",
			(0, " #bCreate a bow"),
			(1, " Create a crossbow"),
			(2, " Create a glove"),
			(3, " Upgrade a glove"),
			(4, " Create materials"),
			(5, " Make arrows"));
		
		if (craftType == 0)
		{
			int craftSelect = AskMenu("I'll make a bow if you can get me some materials. What kind of bow do you want?",
				(0, " #b#t1452002##k(level limit: 10, bowman)"),
				(1, " #b#t1452003##k(level limit: 15, bowman)"),
				(2, " #b#t1452001##k(level limit: 20, bowman)"),
				(3, " #b#t1452000##k(level limit: 25, bowman)"),
				(4, " #b#t1452005##k(level limit: 30, bowman)"),
				(5, " #b#t1452006##k(level limit: 35, bowman)"),
				(6, " #b#t1452007##k(level limit: 40, bowman)"));
				
			if (craftSelect == 0) Craft1(1, "#t1452002#", "#v4003001# 5 #t4003001#s \r\n#v4000000# 30 #t4000000#s \r\n800 mesos", 10);
			else if (craftSelect == 1) Craft1(2, "#t1452003#", "#v4011001# #t4011001# \r\n#v4003000# 3 #t4003000#s \r\n2,000 mesos", 15);
			else if (craftSelect == 2) Craft1(3, "#t1452001#", "#v4003001# 30 #t4003001#s \r\n#v4000016# 50 #t4000016#s \r\n3,000 mesos", 20);
			else if (craftSelect == 3) Craft1(4, "#t1452000#", "#v4011001# 2 #t4011001#s \r\n#v4021006# 2 #t4021006#s \r\n#v4003000# 8 #t4003000#s \r\n5,000 mesos", 25);
			else if (craftSelect == 4) Craft1(5, "#t1452005#", "#v4011001# 5 #t4011001#s \r\n#v4011006# 5 #t4011006#s \r\n#v4021003# 3 #t4021003#s \r\n#v4021006# 2 #t4021006#s \r\n#v4003000# 30 #t4003000#s \r\n30,000 mesos", 30);
			else if (craftSelect == 5) Craft1(6, "#t1452006#", "#v4011004# 7 #t4011004#s \r\n#v4021000# 6 #t4021000#s \r\n#v4021004# 3 #t4021004#s \r\n#v4003000# 35 #t4003000#s \r\n40,000 mesos", 35);
			else if (craftSelect == 6) Craft1(7, "#t1452007#", "#v4021008# #t4021008# \r\n#v4011001# 10 #t4011001#s \r\n#v4011006# 3 #t4011006#s \r\n#v4000014# 50 #t4000014#s \r\n#v4003000# 40 #t4003000#s \r\n80,000 mesos", 40);
		}
		else if (craftType == 1)
		{
			int craftSelect = AskMenu("I'll make a crossbow if you can get me some materials. What kind of crossbow do you want?",
				(0, " #b#t1462001##k(level limit: 12, bowman)"),
				(1, " #b#t1462002##k(level limit: 18, bowman)"),
				(2, " #b#t1462003##k(level limit: 22, bowman)"),
				(3, " #b#t1462000##k(level limit: 28, bowman)"),
				(4, " #b#t1462004##k(level limit: 32, bowman)"),
				(5, " #b#t1462005##k(level limit: 38, bowman)"),
				(6, " #b#t1462006##k(level limit: 42, bowman)"),
				(7, " #b#t1462007##k(level limit: 50, bowman)"));
				
			if (craftSelect == 0) Craft1(100, "#t1462001#", "#v4003001# 7 #t4003001#s \r\n#v4003000# 2 #t4003000#s \r\n1,000 mesos", 12);
			else if (craftSelect == 1) Craft1(101, "#t1462002#", "#v4003001# 20 #t4003001#s \r\n#v4011001# #t4011001# \r\n#v4003000# 5 #t4003000#s \r\n2,000 mesos", 18);
			else if (craftSelect == 2) Craft1(102, "#t1462003#", "#v4003001# 50 #t4003001#s \r\n#v4011001# #t4011001# \r\n#v4003000# 8 #t4003000#s \r\n3,000 mesos", 22);
			else if (craftSelect == 3) Craft1(103, "#t1462000#", "#v4011001# 2 #t4011001#s \r\n#v4021006# #t4021006# \r\n#v4021002# #t4021002# \r\n#v4003000# 10 #t4003000#s \r\n10,000 mesos", 28);
			else if (craftSelect == 4) Craft1(104, "#t1462004#", "#v4011001# 5 #t4011001#s \r\n#v4011005# 5 #t4011005#s \r\n#v4021006# 3 #t4021006#s \r\n#v4003001# 50 #t4003001#s \r\n#v4003000# 15 #t4003000#s \r\n30,000 mesos", 32);
			else if (craftSelect == 5) Craft1(105, "#t1462005#", "#v4021008# #t4021008# \r\n#v4011001# 8 #t4011001#s \r\n#v4011006# 4 #t4011006#s \r\n#v4021006# 2 #t4021006#s \r\n#v4003000# 30 #t4003000#s \r\n50,000 mesos", 38);
			else if (craftSelect == 6) Craft1(106, "#t1462006#", "#v4021008# 2 #t4021008#s \r\n#v4011004# 6 #t4011004#s \r\n#v4003001# 30 #t4003001#s \r\n#v4003000# 30 #t4003000#s \r\n80,000 mesos", 42);
			else if (craftSelect == 7) Craft1(107, "#t1462007#", "#v4021008# 2 #t4021008#s \r\n#v4011006# 5 #t4011006#s \r\n#v4021006# 3 #t4021006#s \r\n#v4003001# 40 #t4003001#s \r\n#v4003000# 40 #t4003000#s \r\n100,000 mesos", 50);
		}
		else if (craftType == 2)
		{
			int craftSelect = AskMenu("I'll make a glove if you can get me some materials. What kind of glove do you want?",
				(0, " #b#t1082012##k(level limit: 15, bowman)"),
				(1, " #b#t1082013##k(level limit: 20, bowman)"),
				(2, " #b#t1082016##k(level limit: 25, bowman)"),
				(3, " #b#t1082048##k(level limit: 30, bowman)"),
				(4, " #b#t1082068##k(level limit: 35, bowman)"),
				(5, " #b#t1082071##k(level limit: 40, bowman)"),
				(6, " #b#t1082084##k(level limit: 50, bowman)"),
				(7, " #b#t1082089##k(level limit: 60, bowman)"));
				
			if (craftSelect == 0) Craft1(200, "#t1082012#", "#v4000021# 15 #t4000021#s \r\n#v4000009# 20 #t4000009#s \r\n5,000 mesos", 15);
			else if (craftSelect == 1) Craft1(201, "#t1082013#", "#v4000021# 20 #t4000021#s \r\n#v4000009# 20 #t4000009#s \r\n#v4011001# 2 #t4011001#s \r\n10,000 mesos", 20);
			else if (craftSelect == 2) Craft1(202, "#t1082016#", "#v4000021# 40 #t4000021#s \r\n#v4000009# 50 #t4000009#s \r\n#v4011006# 2 #t4011006#s \r\n15,000 mesos", 25);
			else if (craftSelect == 3) Craft1(203, "#t1082048#", "#v4000021# 50 #t4000021#s \r\n#v4021001# #t4021001# \r\n#v4011006# 2 #t4011006#s \r\n20,000 mesos", 30);
			else if (craftSelect == 4) Craft1(204, "#t1082068#", "#v4000021# 60 #t4000021#s \r\n#v4011001# 3 #t4011001#s \r\n#v4011000# #t4011000# \r\n#v4003000# 15 #t4003000#s \r\n30,000 mesos", 35);
			else if (craftSelect == 5) Craft1(205, "#t1082071#", "#v4000021# 80 #t4000021#s \r\n#v4021002# 3 #t4021002#s \r\n#v4011001# 3 #t4011001#s \r\n#v4021000# #t4021000# \r\n#v4003000# 25 #t4003000#s \r\n40,000 mesos", 40);
			else if (craftSelect == 6) Craft1(206, "#t1082084#", "#v4011004# 3 #t4011004#s \r\n#v4021002# 2 #t4021002#s \r\n#v4011006# #t4011006# \r\n#v4000030# 40 #t4000030#s \r\n#v4003000# 35 #t4003000#s \r\n50,000 mesos", 50);
			else if (craftSelect == 7) Craft1(207, "#t1082089#", "#v4011007# #t4011007# \r\n#v4021006# 8 #t4021006#s \r\n#v4011006# 2 #t4011006#s \r\n#v4000030# 50 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n70,000 mesos", 60);
		}
		else if (craftType == 3)
		{
			self.say("Do you want to upgrade a glove? You better be careful with that. All the items that will be used for the upgrade will disappear, and if you use an item that has already been#r enhanced#k with a scroll, the effect will disappear when upgraded. Think carefully.");
			
			int craftSelect = AskMenu("Let's see, what kind of glove do you want to upgrade?",
				(0, " #b#t1082014##k(level limit: 20, bowman)"),
				(1, " #b#t1082015##k(level limit: 20, bowman)"),
				(2, " #b#t1082017##k(level limit: 25, bowman)"),
				(3, " #b#t1082018##k(level limit: 25, bowman)"),
				(4, " #b#t1082049##k(level limit: 30, bowman)"),
				(5, " #b#t1082050##k(level limit: 30, bowman)"),
				(6, " #b#t1082069##k(level limit: 35, bowman)"),
				(7, " #b#t1082070##k(level limit: 35, bowman)"),
				(8, " #b#t1082072##k(level limit: 40, bowman)"),
				(9, " #b#t1082073##k(level limit: 40, bowman)"),
				(10, " #b#t1082085##k(level limit: 50, bowman)"),
				(11, " #b#t1082083##k(level limit: 50, bowman)"),
				(12, " #b#t1082090##k(level limit: 60, bowman)"),
				(13, " #b#t1082091##k(level limit: 60, bowman)"));
				
			if (craftSelect == 0) Craft2(1, "#t1082014#", "#v1082013# #t1082013# \r\n#v4021000# #t4021000# \r\n5,000 mesos", 20);
			else if (craftSelect == 1) Craft2(2, "#t1082015#", "#v1082013# #t1082013# \r\n#v4021003# 2 #t4021003#s \r\n7,000 mesos", 20);
			else if (craftSelect == 2) Craft2(3, "#t1082017#", "#v1082016# #t1082016# \r\n#v4021000# 3 #t4021000#s \r\n10,000 mesos", 25);
			else if (craftSelect == 3) Craft2(4, "#t1082018#", "#v1082016# #t1082016# \r\n#v4021008# #t4021008# \r\n12,000 mesos", 25);
			else if (craftSelect == 4) Craft2(5, "#t1082049#", "#v1082048# #t1082048# \r\n#v4021003# 3 #t4021003#s \r\n15,000 mesos", 30);
			else if (craftSelect == 5) Craft2(6, "#t1082050#", "#v1082048# #t1082048# \r\n#v4021008# #t4021008# \r\n20,000 mesos", 30);
			else if (craftSelect == 6) Craft2(7, "#t1082069#", "#v1082068# #t1082068# \r\n#v4011002# 4 #t4011002#s \r\n22,000 mesos", 35);
			else if (craftSelect == 7) Craft2(8, "#t1082070#", "#v1082068# #t1082068# \r\n#v4011006# 2 #t4011006#s \r\n25,000 mesos", 35);
			else if (craftSelect == 8) Craft2(9, "#t1082072#", "#v1082071# #t1082071# \r\n#v4011006# 4 #t4011006#s \r\n30,000 mesos", 40);
			else if (craftSelect == 9) Craft2(10, "#t1082073#", "#v1082071# #t1082071# \r\n#v4021008# 2 #t4021008#s \r\n40,000 mesos", 40);
			else if (craftSelect == 10) Craft2(11, "#t1082085#", "#v1082084# #t1082084# \r\n#v4021000# 5 #t4021000#s \r\n#v4011000# #t4011000# \r\n55,000 mesos", 50);
			else if (craftSelect == 11) Craft2(12, "#t1082083#", "#v1082084# #t1082084# \r\n#v4021008# 2 #t4021008#s \r\n#v4011006# 2 #t4011006#s \r\n60,000 mesos", 50);
			else if (craftSelect == 12) Craft2(13, "#t1082090#", "#v1082089# #t1082089# \r\n#v4021007# #t4021007# \r\n#v4021000# 5 #t4021000#s \r\n70,000 mesos", 60);
			else if (craftSelect == 13) Craft2(14, "#t1082091#", "#v1082089# #t1082089# \r\n#v4021007# 2 #t4021007#s \r\n#v4021008# 2 #t4021008#s \r\n80,000 mesos", 60);
		}
		else if (craftType == 4)
		{
			int craftSelect = AskMenu("So, you want to create some materials, right? Very well... what kind?#b",
				(0, " Create #t4003001# with #t4000003#"),
				(1, " Create #t4003001# with #t4000018#"),
				(2, " Create #t4003000#s"));
				
			if (craftSelect == 0) Craft3(1, "#t4003001#", "#t4000003#", 10, 1);
			else if (craftSelect == 1) Craft3(2, "#t4003001#", "#t4000018#(s)", 5, 1);
			else if (craftSelect == 2) Craft3(3, "#t4003000#", "#t4011001#(s) and #t4011000#(s) each", 1, 15);
		}
		else if (craftType == 5)
		{
			int craftSelect = AskMenu("So, you want to create arrows? The better the arrow, the greater the advantage you'll have in battle. Very well, what kind?#b",
				(0, "#t2060000#"),
				(1, "#t2061000#"),
				(2, "#t2060001#"),
				(3, "#t2061001#"));
				
			if (craftSelect == 0) Craft4(1, "#t2060000#", "#v4003001# #t4003001# \r\n#v4003004# #t4003004# ", 1000, "");
			else if (craftSelect == 1) Craft4(2, "#t2061000#", "#v4003001# #t4003001# \r\n#v4003004# #t4003004# ", 1000, "");
			else if (craftSelect == 2) Craft4(3, "#t2060001#", "#v4011000# #t4011000# \r\n#v4003001# 3 #t4003001#s \r\n#v4003004# 10 #t4003004#s ", 900, "Atk. +1");
			else if (craftSelect == 3) Craft4(4, "#t2061001#", "#v4011000# #t4011000# \r\n#v4003001# 3 #t4003001#s \r\n#v4003004# 10 #t4003004#s ", 900, "Atk. +1");
		}
	}
}