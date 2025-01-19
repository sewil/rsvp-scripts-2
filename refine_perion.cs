using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Craft1(int index, string makeItem, string needItem, int unitPrice)
	{
		int amount = AskInteger(1, 1, 100, $"To make a(n) {makeItem}, I need the following materials. How many would you like to make?\r\n\r\n#b10 {needItem}\r\n{unitPrice} mesos#k");
		
		int nPrice = unitPrice * amount;
		int nAllNum = amount * 10;
		
		bool askBuy = AskYesNo($"To make #b{amount} {makeItem}(s)#k, I need the following materials. Are you sure you want to make these?\r\n\r\n#b{nAllNum} {needItem}\r\n{nPrice} mesos#k");
		
		if (!askBuy)
		{
			self.say("We have all kinds of items, so don't fret, just choose the one you want to buy...");
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
		
		if (!trade)
		{
			self.say("Please check carefully that you have all the items you need, and if your etc. inventory is full or not.");
			return;
		}
		
		self.say($"Hey! Here, take the {amount} {makeItem}(s). This came out better than expected... an expertly refined item like this, I don't think you'll find it anywhere else!! Please come back again~");
	}
	
	private void Craft2(int index, string makeItem, string needItem)
	{
		bool askBuy = AskYesNo($"To make a(n) {makeItem}, I'll need the following materials. Make sure you're not using an item that's needed as a material. What do you think? Do you want it?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("Really? Sorry to hear that. Come back when you need me.");
			return;
		}
		
		bool trade = false;
		
		if (index == 1) trade = Exchange(-300, 1002001, -1, 4021006, -1, 1002041, 1);
		else if (index == 2) trade = Exchange(-500, 1002001, -1, 4011002, -1, 1002042, 1);
		else if (index == 3) trade = Exchange(-500, 1002043, -1, 4011001, -1, 1002002, 1);
		else if (index == 4) trade = Exchange(-800, 1002043, -1, 4011002, -1, 1002044, 1);
		else if (index == 5) trade = Exchange(-500, 1002039, -1, 4011001, -1, 1002003, 1);
		else if (index == 6) trade = Exchange(-800, 1002039, -1, 4011002, -1, 1002040, 1);
		else if (index == 7) trade = Exchange(-1000, 1002051, -1, 4011001, -2, 1002007, 1);
		else if (index == 8) trade = Exchange(-1500, 1002051, -1, 4011002, -2, 1002052, 1);
		else if (index == 9) trade = Exchange(-1500, 1002059, -1, 4011001, -3, 1002011, 1);
		else if (index == 10) trade = Exchange(-2000, 1002059, -1, 4011002, -3, 1002058, 1);
		else if (index == 11) trade = Exchange(-1500, 1002055, -1, 4011001, -3, 1002009, 1);
		else if (index == 12) trade = Exchange(-2000, 1002055, -1, 4011002, -3, 1002056, 1);
		else if (index == 13) trade = Exchange(-2000, 1002027, -1, 4011002, -4, 1002087, 1);
		else if (index == 14) trade = Exchange(-4000, 1002027, -1, 4011006, -4, 1002088, 1);
		else if (index == 15) trade = Exchange(-4000, 1002005, -1, 4011006, -5, 1002049, 1);
		else if (index == 16) trade = Exchange(-5000, 1002005, -1, 4011005, -5, 1002050, 1);
		else if (index == 17) trade = Exchange(-8000, 1002004, -1, 4021000, -3, 1002047, 1);
		else if (index == 18) trade = Exchange(-10000, 1002004, -1, 4021005, -3, 1002048, 1);
		else if (index == 19) trade = Exchange(-12000, 1002021, -1, 4011002, -5, 1002099, 1);
		else if (index == 20) trade = Exchange(-15000, 1002021, -1, 4011006, -6, 1002098, 1);
		else if (index == 21) trade = Exchange(-20000, 1002086, -1, 4011002, -5, 1002085, 1);
		else if (index == 22) trade = Exchange(-25000, 1002086, -1, 4011004, -4, 1002028, 1);
		
		
		if (!trade)
		{
			self.say("Please make sure you have all the items you need, and that there's room in your equip. inventory.");
			return;
		}
		
		self.say($"Hey! Here, take the {makeItem}. Man, I'm good... have you ever seen an item refined like this before? Please come back soon~");
	}
	
	private void Craft3(int index, string makeItem, string needItem, string itemOption)
	{
		bool askBuy = AskYesNo($"To upgrade a(n) {makeItem}, I'll need the following materials. This item improves {itemOption}. Make sure you're not using an item that's needed as a material. What do you think? Do you want one?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("Really? Sorry to hear that. Come back when you need me.");
			return;
		}
		
		bool trade = false;
		
		if (index == 1) trade = Exchange(-100000, 1092012, -1, 4011002, -10, 1092013, 1);
		else if (index == 2) trade = Exchange(-100000, 1092012, -1, 4011003, -10, 1092014, 1);
		else if (index == 3) trade = Exchange(-120000, 1092009, -1, 4011007, -1, 4011004, -15, 1092010, 1);
		else if (index == 4) trade = Exchange(-120000, 1092009, -1, 4011007, -1, 4011003, -15, 1092011, 1);
		else if (index == 100) trade = Exchange(-30000, 1002100, -1, 4011007, -1, 4011001, -7, 1002022, 1);
		else if (index == 101) trade = Exchange(-30000, 1002100, -1, 4011007, -1, 4011002, -7, 1002101, 1);
		
		if (!trade)
		{
			self.say("Please make sure you have all the items you need, and that there's room in your equip. inventory.");
			return;
		}
		
		self.say($"Hey! Here, take the {makeItem}. Man, I'm good... have you ever seen an item refined like this before? Please come back soon~");
	}
	
	public override void Run()
	{
		bool askStart = AskYesNo("Wait, do you have the ore of either a jewel or a mineral? With a little service fee, I can turn them into materials needed to create weapons or shields. Not only that, I can also upgrade an item with it to make an even better item. What do you think? Do you want to do it?");
		
		if (!askStart)
		{
			self.say("Really? Sorry to hear that. If you don't, well... if you collect lots of ores in the future, just come and find me. I'll make something that only I can make.");
			return;
		}
		
		int craftType = AskMenu("Alright, with the ore and a small service fee, I can refine it into something you can use. Make sure you have space in your etc. inventory. Now... what do you want me to make?#b",
			(0, " Refine the raw ore of a mineral"),
			(1, " Refine a jewel"),
			(2, " Upgrade a helmet"),
			(3, " Upgrade a shield"));
		
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
			self.say("So, you want to upgrade a helmet? Ok then. Let me give you some advice: All the items that are used in the upgrade will disappear, and if you use an item that has been #renhanced#k with a scroll, the upgrade will not transfer to the new item. Keep that in mind when making your decision, alright?");
			
			int craftSelect = AskMenu("Now... what kind of helmet do you want to upgrade or create?",
				(0, "#b#t1002041##k(level limit: 15, common)"),
				(1, "#b#t1002042##k(level limit: 15, common)"),
				(2, "#b#t1002002##k(level limit: 10, warrior)"),
				(3, "#b#t1002044##k(level limit: 10, warrior)"),
				(4, "#b#t1002003##k(level limit: 12, warrior)"),
				(5, "#b#t1002040##k(level limit: 12, warrior)"),
				(6, "#b#t1002007##k(level limit: 15, warrior)"),
				(7, "#b#t1002052##k(level limit: 15, warrior)"),
				(8, "#b#t1002011##k(level limit: 20, warrior)"),
				(9, "#b#t1002058##k(level limit: 20, warrior)"),
				(10, "#b#t1002009##k(level limit: 20, warrior)"),
				(11, "#b#t1002056##k(level limit: 20, warrior)"),
				(12, "#b#t1002087##k(level limit: 22, warrior)"),
				(13, "#b#t1002088##k(level limit: 22, warrior)"),
				(14, "#b#t1002049##k(level limit: 25, warrior)"),
				(15, "#b#t1002050##k(level limit: 25, warrior)"),
				(16, "#b#t1002047##k(level limit: 35, warrior)"),
				(17, "#b#t1002048##k(level limit: 35, warrior)"),
				(18, "#b#t1002099##k(level limit: 40, warrior)"),
				(19, "#b#t1002098##k(level limit: 40, warrior)"),
				(20, "#b#t1002085##k(level limit: 50, warrior)"),
				(21, "#b#t1002028##k(level limit: 50, warrior)"),
				(22, "#b#t1002022##k(level limit: 55, warrior)"),
				(23, "#b#t1002101##k(level limit: 55, warrior)"));
				
			if (craftSelect == 0) Craft2(1, "#t1002041#", "#v1002001# #t1002001# \r\n#v4021006# #t4021006# \r\n300 mesos");
			else if (craftSelect == 1) Craft2(2, "#t1002042#", "#v1002001# #t1002001# \r\n#v4011002# #t4011002# \r\n500 mesos");
			else if (craftSelect == 2) Craft2(3, "#t1002002#", "#v1002043# #t1002043# \r\n#v4011001# #t4011001# \r\n500 mesos");
			else if (craftSelect == 3) Craft2(4, "#t1002044#", "#v1002043# #t1002043# \r\n#v4011002# #t4011002# \r\n800 mesos");
			else if (craftSelect == 4) Craft2(5, "#t1002003#", "#v1002039# #t1002039# \r\n#v4011001# #t4011001# \r\n500 mesos");
			else if (craftSelect == 5) Craft2(6, "#t1002040#", "#v1002039# #t1002039# \r\n#v4011002# #t4011002# \r\n800 mesos");
			else if (craftSelect == 6) Craft2(7, "#t1002007#", "#v1002051# #t1002051# \r\n#v4011001# 2 #t4011001#s \r\n1,000 mesos");
			else if (craftSelect == 7) Craft2(8, "#t1002052#", "#v1002051# #t1002051# \r\n#v4011002# 2 #t4011002#s \r\n1,500 mesos");
			else if (craftSelect == 8) Craft2(9, "#t1002011#", "#v1002059# #t1002059# \r\n#v4011001# 3 #t4011001#s \r\n1,500 mesos");
			else if (craftSelect == 9) Craft2(10, "#t1002058#", "#v1002059# #t1002059# \r\n#v4011002# 3 #t4011002#s \r\n2,000 mesos");
			else if (craftSelect == 10) Craft2(11, "#t1002009#", "#v1002055# #t1002055# \r\n#v4011001# 3 #t4011001#s \r\n1,500 mesos");
			else if (craftSelect == 11) Craft2(12, "#t1002056#", "#v1002055# #t1002055# \r\n#v4011002# 3 #t4011002#s \r\n2,000 mesos");
			else if (craftSelect == 12) Craft2(13, "#t1002087#", "#v1002027# #t1002027# \r\n#v4011002# 4 #t4011002#s \r\n2,000 mesos");
			else if (craftSelect == 13) Craft2(14, "#t1002088#", "#v1002027# #t1002027# \r\n#v4011006# 4 #t4011006#s \r\n4,000 mesos");
			else if (craftSelect == 14) Craft2(15, "#t1002049#", "#v1002005# #t1002005# \r\n#v4011006# 5 #t4011006#s \r\n4,000 mesos");
			else if (craftSelect == 15) Craft2(16, "#t1002050#", "#v1002005# #t1002005# \r\n#v4011005# 5 #t4011005#s \r\n5,000 mesos");
			else if (craftSelect == 16) Craft2(17, "#t1002047#", "#v1002004# #t1002004# \r\n#v4021000# 3 #t4021000#s \r\n8,000 mesos");
			else if (craftSelect == 17) Craft2(18, "#t1002048#", "#v1002004# #t1002004# \r\n#v4021005# 3 #t4021005#s \r\n10,000 mesos");
			else if (craftSelect == 18) Craft2(19, "#t1002099#", "#v1002021# #t1002021# \r\n#v4011002# 5 #t4011002#s \r\n12,000 mesos");
			else if (craftSelect == 19) Craft2(20, "#t1002098#", "#v1002021# #t1002021# \r\n#v4011006# 6 #t4011006#s \r\n15,000 mesos");
			else if (craftSelect == 20) Craft2(21, "#t1002085#", "#v1002086# #t1002086# \r\n#v4011002# 5 #t4011002#s \r\n20,000 mesos");
			else if (craftSelect == 21) Craft2(22, "#t1002028#", "#v1002086# #t1002086# \r\n#v4011004# 4 #t4011004#s \r\n25,000 mesos");
			else if (craftSelect == 22) Craft3(100, "#t1002022#", "#v1002100# #t1002100# \r\n#v4011007# #t4011007# \r\n#v4011001# 7 #t4011001#s \r\n30,000 mesos", "DEX +1, MP +30");
			else if (craftSelect == 23) Craft3(101, "#t1002101#", "#v1002100# #t1002100# \r\n#v4011007# #t4011007# \r\n#v4011002# 7 #t4011002#s \r\n30,000 mesos", "STR +1, MP +30");
		}
		else if (craftType == 3)
		{
			self.say("So, you want to upgrade a shield? Ok then. Let me give you some advice: All the items that are used in the upgrade will disappear, and if you use an item that has been #renhanced#k with a scroll, the upgrade will not transfer to the new item. Keep that in mind when making your decision, alright?");
			
			int craftSelect = AskMenu("So~~ what kind of shield do you want to upgrade or create?",
				(0, " #b#t1092013##k(level limit: 40, warrior)"),
				(1, " #b#t1092014##k(level limit: 40, warrior)"),
				(2, " #b#t1092010##k(level limit: 60, warrior)"),
				(3, " #b#t1092011##k(level limit: 60, warrior)"));
				
			if (craftSelect == 0) Craft3(1, "#t1092013#", "#v1092012# #t1092012# \r\n#v4011002# 10 #t4011002#s \r\n100,000 mesos", "STR +2");
			else if (craftSelect == 1) Craft3(2, "#t1092014#", "#v1092012# #t1092012# \r\n#v4011003# #t4011003# \r\n100,000 mesos", "DEX +2");
			else if (craftSelect == 2) Craft3(3, "#t1092010#", "#v1092009# #t1092009# \r\n#v4011007# #t4011007# \r\n#v4011004# 15 #t4011004#s \r\n120,000 mesos", "DEX +2");
			else if (craftSelect == 3) Craft3(4, "#t1092011#", "#v1092009# #t1092009# \r\n#v4011007# #t4011007# \r\n#v4011003# 15 #t4011003#s \r\n120,000 mesos", "STR +2");
		}
	}
}