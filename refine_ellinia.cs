using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Craft1(int index, string makeItem, string needItem, int reqLevel)
	{
		bool askBuy = AskYesNo($"To make one {makeItem}, you'll need these items below. The level limit for the item will be {reqLevel} so please check and see if you really need the item, first of all. Are you sure you want to make one?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("Really? You must not have all the materials. Try to get all of them in town. Fortunately, it seems that the monsters around the forest have the most diverse kinds of materials with them.");
			return;
		}
		
		bool trade = false;
		
		// magic wand
		if (index == 1) trade = Exchange(-1000, 4003001, -5, 1372005, 1);
		else if (index == 2) trade = Exchange(-3000, 4003001, -10, 4000001, -50, 1372006, 1);
		else if (index == 3) trade = Exchange(-5000, 4011001, -1, 4000009, -30, 4003000, -5, 1372002, 1);
		else if (index == 4) trade = Exchange(-12000, 4011002, -2, 4003002, -1, 4003000, -10, 1372004, 1);
		else if (index == 5) trade = Exchange(-30000, 4011002, -3, 4021002, -1, 4003000, -10, 1372003, 1);
		else if (index == 6) trade = Exchange(-60000, 4021006, -5, 4011002, -3, 4011001, -1, 4003000, -15, 1372001, 1);
		else if (index == 7) trade = Exchange(-120000, 4021006, -5, 4021005, -5, 4021007, -1, 4003003, -1, 4003000, -20, 1372000, 1);
		else if (index == 8) trade = Exchange(-200000, 4011006, -4, 4021003, -3, 4021007, -2, 4021002, -1, 4003002, -1, 4003000, -30, 1372007, 1);
		
		// staff
		else if (index == 100) trade = Exchange(-2000, 4003001, -5, 1382000, 1);
		else if (index == 101) trade = Exchange(-2000, 4021005, -1, 4011001, -1, 4003000, -5, 1382003, 1);
		else if (index == 102) trade = Exchange(-2000, 4021003, -1, 4011001, -1, 4003000, -5, 1382005, 1);
		else if (index == 103) trade = Exchange(-5000, 4003001, -50, 4011001, -1, 4003000, -10, 1382004, 1);
		else if (index == 104) trade = Exchange(-12000, 4021006, -2, 4021001, -1, 4011001, -1, 4003000, -15, 1382002, 1);
		else if (index == 105) trade = Exchange(-180000, 4011001, -3, 4021001, -5, 4021006, -5, 4021005, -5, 4003003, -1, 4000010, -50, 4003000, -30, 1382001, 1);
		
		// glove
		else if (index == 200) trade = Exchange(-7000, 4000021, -15, 1082019, 1);
		else if (index == 201) trade = Exchange(-15000, 4000021, -30, 4011001, -1, 1082020, 1);
		else if (index == 202) trade = Exchange(-20000, 4000021, -50, 4011006, -2, 1082026, 1);
		else if (index == 203) trade = Exchange(-25000, 4000021, -60, 4021006, -1, 4021000, -2, 1082051, 1);
		else if (index == 204) trade = Exchange(-30000, 4000021, -70, 4011006, -1, 4011001, -3, 4021000, -2, 1082054, 1);
		else if (index == 205) trade = Exchange(-40000, 4000021, -80, 4021000, -3, 4021006, -3, 4003000, -30, 1082062, 1);
		else if (index == 206) trade = Exchange(-50000, 4021000, -3, 4011006, -2, 4000030, -35, 4003000, -40, 1082081, 1);
		else if (index == 207) trade = Exchange(-70000, 4011007, -1, 4011001, -8, 4021007, -1, 4000030, -50, 4003000, -50, 1082086, 1);
		
		// hat
		else if (index == 300) trade = Exchange(-500, 4011002, -1, 1002017, -1, 1002074, 1);
		else if (index == 301) trade = Exchange(-500, 4011000, -1, 1002017, -1, 1002075, 1);
		else if (index == 302) trade = Exchange(-1600, 4021005, -2, 1002016, -1, 1002072, 1);
		else if (index == 303) trade = Exchange(-1600, 4021000, -2, 1002016, -1, 1002073, 1);
		
		if (!trade)
		{
			self.say("Please check if you have all the items that you need, or if your equip. inventory is full or not.");
			return;
		}
		
		self.say($"Here, take the {makeItem}. The more I look at it, the more perfect it seems. Hahah, it doesn't bother me to think that other magicians are afraid of my abilities ...");
	}
	
	private void Craft2(int index, string makeItem, string needItem, int reqLevel, string itemOption)
	{
		bool askBuy = AskYesNo($"To upgrade one {makeItem}, you'll need these items below. The level limit for the item is {reqLevel}, with the option of #r{itemOption}#k embedded in it, so please see if you really need it. Oh! And there's one more thing. Please make sure NOT to use an upgraded item as material for the upgrade. Are you really sure you want to create this item?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("Really? You must not have all the materials. Try to get all of them in town. Fortunately, it seems that the monsters around the forest have the most diverse kinds of materials with them.");
			return;
		}
		
		bool trade = false;
		
		// Glove
		if (index == 1) trade = Exchange(-20000, 1082020, -1, 4021003, -1, 1082021, 1);
		else if (index == 2) trade = Exchange(-25000, 1082020, -1, 4021001, -2, 1082022, 1);
		else if (index == 3) trade = Exchange(-30000, 1082026, -1, 4021000, -3, 1082027, 1);
		else if (index == 4) trade = Exchange(-40000, 1082026, -1, 4021008, -1, 1082028, 1);
		else if (index == 5) trade = Exchange(-35000, 1082051, -1, 4021005, -3, 1082052, 1);
		else if (index == 6) trade = Exchange(-40000, 1082051, -1, 4021008, -1, 1082053, 1);
		else if (index == 7) trade = Exchange(-40000, 1082054, -1, 4021005, -3, 1082055, 1);
		else if (index == 8) trade = Exchange(-45000, 1082054, -1, 4021008, -1, 1082056, 1);
		else if (index == 9) trade = Exchange(-45000, 1082062, -1, 4021002, -4, 1082063, 1);
		else if (index == 10) trade = Exchange(-50000, 1082062, -1, 4021008, -2, 1082064, 1);
		else if (index == 11) trade = Exchange(-55000, 1082081, -1, 4021002, -5, 1082082, 1);
		else if (index == 12) trade = Exchange(-60000, 1082081, -1, 4021008, -3, 1082080, 1);
		else if (index == 13) trade = Exchange(-70000, 1082086, -1, 4011004, -3, 4011006, -5, 1082087, 1);
		else if (index == 14) trade = Exchange(-80000, 1082086, -1, 4021008, -2, 4011006, -3, 1082088, 1);
		
		// Hat
		else if (index == 100) trade = Exchange(-40000, 1002064, -1, 4011001, -3, 1002065, 1);
		else if (index == 101) trade = Exchange(-50000, 1002064, -1, 4011006, -3, 1002013, 1);
		
		if (!trade)
		{
			self.say("Please check if you have all the items that you need, or if your equip. inventory is full or not");
			return;
		}
		
		self.say($"Here, take the {makeItem}... The more I look at it, the more perfect it seems... I wouldn't be surprised to see other magicians think that I'm dangerous just because of my abilities...");
	}
	
	public override void Run()
	{
		bool askStart = AskYesNo("Do you want to take a look at some items? Well... any thought of making one? I'm actually a wizard that was banished from the town because I casted an illegal magic. Because of that I've been hiding, doing some business \r\nhere... well, that's not really the point. Do you want to do some business with me?");
		
		if (!askStart)
		{
			self.say("I think that you don't trust in my skills... hahaha... because you know I was a great wizard. You still don't believe in my skills... hmm.. but remember that I used to be a great magician...");
			return;
		}
		
		int craftType = AskMenu("Alright... it's for both of our own good, right? Choose what you want to do...#b",
			(0, " Make a wand"),
			(1, " Make a staff"),
			(2, " Make a glove"),
			(3, " Upgrade a glove"),
			(4, " Upgrade a hat"));
		
		if (craftType == 0)
		{
			int craftSelect = AskMenu("If you gather up the materials for me, I'll make a wand for you using my magical powers. Now... what kind of wand do you want me to make?",
				(0, " #b#t1372005##k(level limit: 8, common)"),
				(1, " #b#t1372006##k(level limit: 13, common)"),
				(2, " #b#t1372002##k(level limit: 18, common)"),
				(3, " #b#t1372004##k(level limit: 23, magician)"),
				(4, " #b#t1372003##k(level limit: 28, magician)"),
				(5, " #b#t1372001##k(level limit: 33, magician)"),
				(6, " #b#t1372000##k(level limit: 38, magician)"),
				(7, " #b#t1372007##k(level limit: 48, magician)"));
				
			if (craftSelect == 0) Craft1(1, "#t1372005#", "#v4003001# 5 #t4003001#s\r\n1,000 mesos", 8);
			else if (craftSelect == 1) Craft1(2, "#t1372006#", "#v4003001# 10 #t4003001#s\r\n#v4000001# 50 #t4000001#s\r\n3,000 mesos", 13);
			else if (craftSelect == 2) Craft1(3, "#t1372002#", "#v4011001# #t4011001#\r\n#v4000009# 30 #t4000009#s\r\n#v4003000# 5 #t4003000#s\r\n5,000 mesos", 18);
			else if (craftSelect == 3) Craft1(4, "#t1372004#", "#v4011002# 2 #t4011002#s\r\n#v4003002# #t4003002#\r\n#v4003000# 10 #t4003000#s\r\n12,000 mesos", 23);
			else if (craftSelect == 4) Craft1(5, "#t1372003#", "#v4011002# 3 #t4011002#s\r\n#v4021002# #t4021002#\r\n#v4003000# 10 #t4003000#s\r\n30,000 mesos", 28);
			else if (craftSelect == 5) Craft1(6, "#t1372001#", "#v4021006# 5 #t4021006#s\r\n#v4011002# 3 #t4011002#s\r\n#v4011001# #t4011001#\r\n#v4003000# 15 #t4003000#s\r\n60,000 mesos", 33);
			else if (craftSelect == 6) Craft1(7, "#t1372000#", "#v4021006# 5 #t4021006#s\r\n#v4021005# 5 #t4021005#s\r\n#v4021007# #t4021007#\r\n#v4003003# #t4003003#\r\n#v4003000# 20 #t4003000#s\r\n120,000 mesos", 38);
			else if (craftSelect == 7) Craft1(8, "#t1372007#", "#v4011006# 4 #t4011006#s\r\n#v4021003# 3 #t4021003#s\r\n#v4021007# 2 #t4021007#s\r\n#v4021002# #t4021002#\r\n#v4003002# #t4003002#\r\n#v4003000# 30 #t4003000#s\r\n200,000 mesos", 48);
		}
		else if (craftType == 1)
		{
			int craftSelect = AskMenu("If you gather up the materials for me, I'll make you a staff for you using my magical powers. Now... what kind of staff do you want me to make?",
				(0, " #b#t1382000##k(level limit: 10, magician)"),
				(1, " #b#t1382003##k(level limit: 15, magician)"),
				(2, " #b#t1382005##k(level limit: 15, magician)"),
				(3, " #b#t1382004##k(level limit: 20, magician)"),
				(4, " #b#t1382002##k(level limit: 25, magician)"),
				(5, " #b#t1382001##k(level limit: 45, magician)"));
				
			if (craftSelect == 0) Craft1(100, "#t1382000#", "#v4003001# 5 #t4003001#s\r\n2,000 mesos", 10);
			else if (craftSelect == 1) Craft1(101, "#t1382003#", "#v4021005# #t4021005#\r\n#v4011001# #t4011001#\r\n#v4003000# 5 #t4003000#s\r\n2,000 mesos", 15);
			else if (craftSelect == 2) Craft1(102, "#t1382005#", "#v4021003# #t4021003#\r\n#v4011001# #t4011001#\r\n#v4003000# 5 #t4003000#s\r\n2,000 mesos", 15);
			else if (craftSelect == 3) Craft1(103, "#t1382004#", "#v4003001# 50 #t4003001#s\r\n#v4011001# #t4011001#\r\n#v4003000# 10 #t4003000#s\r\n5,000 mesos", 20);
			else if (craftSelect == 4) Craft1(104, "#t1382002#", "#v4021006# 2 #t4021006#s\r\n#v4021001# #t4021001#\r\n#v4011001# #t4011001#\r\n#v4003000# 15 #t4003000#s\r\n12,000 mesos", 25);
			else if (craftSelect == 5) Craft1(105, "#t1382001#", "#v4011001# 3 #t4011001#s\r\n#v4021001# 5 #t4021001#s\r\n#v4021006# 5 #t4021006#s\r\n#v4021005# 5 #t4021005#s\r\n#v4003003# #t4003003#\r\n#v4000010# 50 #t4000010#s\r\n#v4003000# 30 #t4003000#s\r\n180,000 mesos", 45);
		}
		else if (craftType == 2)
		{
			int craftSelect = AskMenu("If you gather up the materials for me, I'll make a glove for you using my magical powers. Now... what kind of glove do you want me to make?",
				(0, " #b#t1082019##k(level limit: 15, magician)"),
				(1, " #b#t1082020##k(level limit: 20, magician)"),
				(2, " #b#t1082026##k(level limit: 25, magician)"),
				(3, " #b#t1082051##k(level limit: 30, magician)"),
				(4, " #b#t1082054##k(level limit: 35, magician)"),
				(5, " #b#t1082062##k(level limit: 40, magician)"),
				(6, " #b#t1082081##k(level limit: 50, magician)"),
				(7, " #b#t1082086##k(level limit: 60, magician)"));
				
			if (craftSelect == 0) Craft1(200, "#t1082019#", "#v4000021# 15 #t4000021#s\r\n7,000 mesos", 15);
			else if (craftSelect == 1) Craft1(201, "#t1082020#", "#v4000021# 30 #t4000021#s\r\n#v4011001# #t4011001#\r\n15,000 mesos", 20);
			else if (craftSelect == 2) Craft1(202, "#t1082026#", "#v4000021# 50 #t4000021#s\r\n#v4011006# 2 #t4011006#s\r\n20,000 mesos", 25);
			else if (craftSelect == 3) Craft1(203, "#t1082051#", "#v4000021# 60 #t4000021#s\r\n#v4021006# #t4021006#\r\n#v4021000# 2 #t4021000#s\r\n25,000 mesos", 30);
			else if (craftSelect == 4) Craft1(204, "#t1082054#", "#v4000021# 70 #t4000021#s\r\n#v4011006# #t4011006#\r\n#v4011001# 3 #t4011001#s\r\n#v4021000# 2 #t4021000#s\r\n30,000 mesos", 35);
			else if (craftSelect == 5) Craft1(205, "#t1082062#", "#v4000021# 80 #t4000021#s\r\n#v4021000# 3 #t4021000#s\r\n#v4021006# 3 #t4021006#s\r\n#v4003000# 30 #t4003000#s\r\n40,000 mesos", 40);
			else if (craftSelect == 6) Craft1(206, "#t1082081#", "#v4021000# 3 #t4021000#s\r\n#v4011006# 2 #t4011006#s\r\n#v4000030# 35 #t4000030#s\r\n#v4003000# 40 #t4003000#s\r\n50,000 mesos", 50);
			else if (craftSelect == 7) Craft1(207, "#t1082086#", "#v4011007# #t4011007#\r\n#v4011001# 8 #t4011001#s\r\n#v4021007# #t4021007#\r\n#v4000030# 50 #t4000030#s\r\n#v4003000# 50 #t4003000#s\r\n70,000 mesos", 60);
		}
		else if (craftType == 3)
		{
			self.say("You want to upgrade a glove? Be careful! All the items used for the upgrade will disappear, and if you use an item that has been #renhanced#k with a scroll, the effect will disappear when upgraded, so it's better you think well before making your decision ...");
			
			int craftSelect = AskMenu("Now... which glove do you want to upgrade??",
				(0, " #b#t1082021##k(level limit: 20, magician)"),
				(1, " #b#t1082022##k(level limit: 20, magician)"),
				(2, " #b#t1082027##k(level limit: 25, magician)"),
				(3, " #b#t1082028##k(level limit: 25, magician)"),
				(4, " #b#t1082052##k(level limit: 30, magician)"),
				(5, " #b#t1082053##k(level limit: 30, magician)"),
				(6, " #b#t1082055##k(level limit: 35, magician)"),
				(7, " #b#t1082056##k(level limit: 35, magician)"),
				(8, " #b#t1082063##k(level limit: 40, magician)"),
				(9, " #b#t1082064##k(level limit: 40, magician)"),
				(10, " #b#t1082082##k(level limit: 50, magician)"),
				(11, " #b#t1082080##k(level limit: 50, magician)"),
				(12, " #b#t1082087##k(level limit: 60, magician)"),
				(13, " #b#t1082088##k(level limit: 60, magician)"));
				
			if (craftSelect == 0) Craft2(1, "#t1082021#", "#v1082020# #t1082020#\r\n#t4021003#\r\n20,000 mesos", 20, "INT +1");
			else if (craftSelect == 1) Craft2(2, "#t1082022#", "#v1082020# #t1082020#\r\n#v4021001# 2 #t4021001#s\r\n25,000 mesos", 20, "INT +2");
			else if (craftSelect == 2) Craft2(3, "#t1082027#", "#v1082026# #t1082026#\r\n#v4021000# 3 #t4021000#s\r\n30,000 mesos", 25, "INT +1");
			else if (craftSelect == 3) Craft2(4, "#t1082028#", "#v1082026# #t1082026#\r\n#v4021008# #t4021008#\r\n40,000 mesos", 25, "INT +2");
			else if (craftSelect == 4) Craft2(5, "#t1082052#", "#v1082051# #t1082051#\r\n#v4021005# 3 #t4021005#s\r\n35,000 mesos", 30, "INT +1");
			else if (craftSelect == 5) Craft2(6, "#t1082053#", "#v1082051# #t1082051#\r\n#v4021008# #t4021008#s\r\n40,000 mesos", 30, "INT +2");
			else if (craftSelect == 6) Craft2(7, "#t1082055#", "#v1082054# #t1082054#\r\n#v4021005# 3 #t4021005#s\r\n40,000 mesos", 35, "INT +1");
			else if (craftSelect == 7) Craft2(8, "#t1082056#", "#v1082054# #t1082054#\r\n#v4021008# #t4021008#s\r\n45,000 mesos", 35, "INT +2");
			else if (craftSelect == 8) Craft2(9, "#t1082063#", "#v1082062# #t1082062#\r\n#v4021002# 4 #t4021002#s\r\n45,000 mesos", 40, "INT +2");
			else if (craftSelect == 9) Craft2(10, "#t1082064#", "#v1082062# #t1082062#\r\n#v4021008# 2 #t4021008#s\r\n50,000 mesos", 40, "INT +3");
			else if (craftSelect == 10) Craft2(11, "#t1082082#", "#v1082081# #t1082081#\r\n#v4021002# 5 #t4021002#s\r\n55,000 mesos", 50, "INT +2, MP +15");
			else if (craftSelect == 11) Craft2(12, "#t1082080#", "#v1082081# #t1082081#\r\n#v4021008# 3 #t4021008#s\r\n60,000 mesos", 50, "INT +3, MP +30");
			else if (craftSelect == 12) Craft2(13, "#t1082087#", "#v1082086# #t1082086#\r\n#v4011004# 3 #t4011004#s\r\n#v4011006# 5 #t4011006#s\r\n70,000 mesos", 60, "INT +2, LUK +1, MP +15");
			else if (craftSelect == 13) Craft2(14, "#t1082088#", "#v1082086# #t1082086#\r\n#v4021008# 2 #t4021008#s\r\n#v4011006# 3 #t4011006#s\r\n80,000 mesos", 60, "INT +3, LUK +1, MP +30");
		}
		else if (craftType == 4)
		{
			self.say("So you want to upgrade your hat... Be careful! All the items used for the upgrade will disappear, and if you use an item that has been #renhanced#k with a scroll, the effect will disappear when upgraded, so it's better you think well before making your decision ...");
			
			int craftSelect = AskMenu("Alright... which hat do you want to upgrade?",
				(0, " #b#t1002074##k(level limit: 10, magician)"),
				(1, " #b#t1002075##k(level limit: 10, magician)"),
				(2, " #b#t1002072##k(level limit: 20, magician)"),
				(3, " #b#t1002073##k(level limit: 20, magician)"),
				(4, " #b#t1002065##k(level limit: 30, magician)"),
				(5, " #b#t1002013##k(level limit: 30, magician)"));
				
			if (craftSelect == 0) Craft1(300, "#t1002074#", "#v1002017# #t1002017#\r\n#v4011002# #t4011002#\r\n500 mesos", 10);
			else if (craftSelect == 1) Craft1(301, "#t1002075#", "#v1002017# #t1002017#\r\n#v4011000# #t4011000#\r\n500 mesos", 10);
			else if (craftSelect == 2) Craft1(302, "#t1002072#", "#v1002016# #t1002016#\r\n#v4021005# 2 #t4021005#s\r\n1,500 mesos", 20);
			else if (craftSelect == 3) Craft1(303, "#t1002073#", "#v1002016# #t1002016#\r\n#v4021000# 2 #t4021000#s\r\n1,500 mesos", 20);
			else if (craftSelect == 4) Craft2(100, "#t1002065#", "#v1002064# #t1002064#\r\n#v4011001# 3 #t4011001#s\r\n40,000 mesos", 30, "INT +1");
			else if (craftSelect == 5) Craft2(101, "#t1002013#", "#v1002064# #t1002064#\r\n#v4011006# 3 #t4011006#s\r\n50,000 mesos", 30, "INT +2");
		}
	}
}