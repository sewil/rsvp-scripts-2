using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Craft(int index, string makeItem, string needItem, int reqLevel, string itemOption)
	{
		bool askBuy = AskYesNo($"You want to make {makeItem}? To make this, you'll need the following materials. There's an improvement of #r{itemOption}#k on the item, and the level limit is: {reqLevel}. What do you think? You want to make one?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("I don't just make gloves, but I can also upgrade gloves, so after thinking on it, just come back and talk to me...");
			return;
		}
		
		bool trade = false;
		
		// Make warrior gloves
		if (index == 0) trade = Exchange(-70000, 4011007, -1, 4011000, -8, 4011006, -2, 4000030, -50, 4003000, -50, 1082059, 1);
		else if (index == 1) trade = Exchange(-90000, 4005000, -2, 4011000, -8, 4011006, -3, 4000030, -70, 4003000, -55, 1082103, 1);
		else if (index == 2) trade = Exchange(-100000, 4005000, -2, 4005002, -1, 4021005, -8, 4000030, -90, 4003000, -60, 1082114, 1);
		
		// Make magician gloves
		else if (index == 100) trade = Exchange(-70000, 4011007, -1, 4011001, -8, 4021007, -1, 4000030, -50, 4003000, -50, 1082086, 1);
		else if (index == 101) trade = Exchange(-90000, 4005001, -2, 4011000, -6, 4011004, -6, 4000030, -70, 4003000, -55, 1082098, 1);
		else if (index == 102) trade = Exchange(-100000, 4005001, -2, 4005003, -1, 4021003, -8, 4000030, -90, 4003000, -60, 1082121, 1);
		
		// Make bowman gloves
		else if (index == 200) trade = Exchange(-70000, 4011007, -1, 4021006, -8, 4011006, -2, 4000030, -50, 4003000, -50, 1082089, 1);
		else if (index == 201) trade = Exchange(-90000, 4005002, -2, 4021005, -8, 4011004, -3, 4000030, -70, 4003000, -55, 1082106, 1);
		else if (index == 202) trade = Exchange(-100000, 4005002, -2, 4005000, -1, 4021000, -8, 4000030, -90, 4003000, -60, 1082109, 1);
		
		// Make thief gloves
		else if (index == 300) trade = Exchange(-70000, 4011007, -1, 4011000, -8, 4021007, -1, 4000030, -50, 4003000, -50, 1082092, 1);
		else if (index == 301) trade = Exchange(-90000, 4005003, -2, 4011000, -6, 4011003, -6, 4000030, -70, 4003000, -55, 1082095, 1);
		else if (index == 302) trade = Exchange(-100000, 4005003, -2, 4005002, -1, 4011002, -8, 4000030, -90, 4003000, -60, 1082118, 1);
		
		// Upgrade warrior gloves
		else if (index == 400) trade = Exchange(-70000, 1082059, -1, 4011002, -3, 4021005, -5, 1082060, 1);
		else if (index == 401) trade = Exchange(-80000, 1082059, -1, 4021007, -2, 4021008, -2, 1082061, 1);
		else if (index == 402) trade = Exchange(-90000, 1082103, -1, 4011002, -6, 4021006, -4, 1082104, 1);
		else if (index == 403) trade = Exchange(-100000, 1082103, -1, 4021006, -8, 4021008, -3, 1082105, 1);
		else if (index == 404) trade = Exchange(-110000, 1082114, -1, 4005000, -1, 4005002, -1, 4021003, -7, 1082115, 1);
		else if (index == 405) trade = Exchange(-120000, 1082114, -1, 4005002, -3, 4021000, -8, 1082116, 1);
		else if (index == 406) trade = Exchange(-120000, 1082114, -1, 4005000, -2, 4005002, -1, 4021008, -4, 1082117, 1);
		
		// Upgrade magician gloves
		else if (index == 500) trade = Exchange(-70000, 1082086, -1, 4011004, -3, 4011006, -5, 1082087, 1);
		else if (index == 501) trade = Exchange(-80000, 1082086, -1, 4021008, -2, 4011006, -3, 1082088, 1);
		else if (index == 502) trade = Exchange(-90000, 1082098, -1, 4021002, -6, 4021007, -2, 1082099, 1);
		else if (index == 503) trade = Exchange(-100000, 1082098, -1, 4021008, -3, 4011006, -3, 1082100, 1);
		else if (index == 504) trade = Exchange(-110000, 1082121, -1, 4005001, -1, 4005003, -1, 4021005, -7, 1082122, 1);
		else if (index == 505) trade = Exchange(-120000, 1082121, -1, 4005001, -2, 4005003, -1, 4021008, -4, 1082123, 1);
		
		// Upgrade bowman gloves
		else if (index == 600) trade = Exchange(-70000, 1082089, -1, 4021007, -1, 4021000, -5, 1082090, 1);
		else if (index == 601) trade = Exchange(-80000, 1082089, -1, 4021007, -2, 4021008, -2, 1082091, 1);
		else if (index == 602) trade = Exchange(-90000, 1082106, -1, 4021006, -5, 4011006, -3, 1082107, 1);
		else if (index == 603) trade = Exchange(-100000, 1082106, -1, 4021007, -2, 4021008, -3, 1082108, 1);
		else if (index == 604) trade = Exchange(-110000, 1082109, -1, 4005002, -1, 4005000, -1, 4021005, -7, 1082110, 1);
		else if (index == 605) trade = Exchange(-110000, 1082109, -1, 4005002, -1, 4005000, -1, 4021003, -7, 1082111, 1);
		else if (index == 606) trade = Exchange(-120000, 1082109, -1, 4005002, -2, 4005000, -1, 4021008, -4, 1082112, 1);
		
		// Upgrade thief gloves
		else if (index == 700) trade = Exchange(-70000, 1082092, -1, 4011001, -7, 4000014, -200, 1082093, 1);
		else if (index == 701) trade = Exchange(-80000, 1082092, -1, 4011006, -7, 4000027, -150, 1082094, 1);
		else if (index == 702) trade = Exchange(-90000, 1082095, -1, 4011004, -6, 4021007, -2, 1082096, 1);
		else if (index == 703) trade = Exchange(-100000, 1082095, -1, 4021007, -3, 4011006, -3, 1082097, 1);
		else if (index == 704) trade = Exchange(-110000, 1082118, -1, 4005003, -1, 4005002, -1, 4021001, -7, 1082119, 1);
		else if (index == 705) trade = Exchange(-120000, 1082118, -1, 4005003, -2, 4005002, -1, 4021000, -8, 1082120, 1);
		
		if (!trade)
		{
			self.say("Please make sure that you have all the items ready, or if your equip. inventory has enough space.");
			return;
		}
			
		self.say($"Here ... here is the {makeItem} that you asked for. What do you think? You won't find a product as well made as this anywhere! Feel free to come back whenever you want...");
	}
	
	public override void Run()
	{
		int craftType = AskMenu("It seems like people today don't consider gloves to be very important... This is because they don't understand the true value of a good glove. What do you think? If you need one, how about letting me fix that?#b",
			(0, " Create a warrior glove"),
			(1, " Create a magician glove"),
			(2, " Create a bowman glove"),
			(3, " Create a thief glove"),
			(4, " Upgrade a warrior glove"),
			(5, " Upgrade a magician glove"),
			(6, " Upgrade a bowman glove"),
			(7, " Upgrade a thief glove"));
		
		if (craftType == 0)
		{
			int craftSelect = AskMenu("So, you want gloves just for warriors? Choose the one that suits your needs here!",
				(0, " #b#t1082059##k(level limit: 60, warrior)"),
				(1, " #b#t1082103##k(level limit: 70, warrior)"),
				(2, " #b#t1082114##k(level limit: 80, warrior)"));
				
			if (craftSelect == 0) Craft(0, "#t1082059#", "#v4011007# #t4011007# \r\n#v4011000# 8 #t4011000#s \r\n#v4011006# 2 #t4011006#s \r\n#v4000030# 50 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n70000 mesos", 60, "STR +1");
			else if (craftSelect == 1) Craft(1, "#t1082103#", "#v4005000# 2 #t4005000#s \r\n#v4011000# 8 #t4011000#s \r\n#v4011006# 3 #t4011006#s \r\n#v4000030# 70 #t4000030#s \r\n#v4003000# 55 #t4003000#s \r\n90000 mesos", 70, "STR +2");
			else if (craftSelect == 2) Craft(2, "#t1082114#", "#v4005000# 2 #t4005000#s \r\n#v4005002# #t4005002# \r\n#v4021005# 8 #t4021005#s \r\n#v4000030# 90 #t4000030#s \r\n#v4003000# 60 #t4003000#s \r\n100000 mesos", 80, "STR +2, DEX +1, MP +10");
		}
		if (craftType == 1)
		{
			int craftSelect = AskMenu("So, you want gloves just for magicians? Choose the one that suits your needs here!",
				(0, " #b#t1082086##k(level limit: 60, magician)"),
				(1, " #b#t1082098##k(level limit: 70, magician)"),
				(2, " #b#t1082121##k(level limit: 80, magician)"));
				
			if (craftSelect == 0) Craft(100, "#t1082086#", "#v4011007# #t4011007# \r\n#v4011001# 8 #t4011001#s \r\n#v4021007# #t4021007# \r\n#v4000030# 50 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n70000 mesos", 60, "INT +1, LUK +1, MP +30");
			else if (craftSelect == 1) Craft(101, "#t1082098#", "#v4005001# 2 #t4005001#s \r\n#v4011000# 6 #t4011000#s \r\n#v4011004# 6 #t4011004#s \r\n#v4000030# 70 #t4000030#s \r\n#v4003000# 55 #t4003000#s \r\n90000 mesos", 70, "INT +2");
			else if (craftSelect == 2) Craft(102, "#t1082121#", "#v4005001# 2 #t4005001#s \r\n#v4005003# #t4005003# \r\n#v4021003# 8 #t4021003#s \r\n#v4000030# 90 #t4000030#s \r\n#v4003000# 60 #t4003000#s \r\n100000 mesos", 80, "INT +2, LUK +1, MP +10");
		}
		if (craftType == 2)
		{
			int craftSelect = AskMenu("So, you want gloves just for bowmen? Choose the one that suits your needs here!",
				(0, " #b#t1082089##k(level limit: 60, bowman)"),
				(1, " #b#t1082106##k(level limit: 70, bowman)"),
				(2, " #b#t1082109##k(level limit: 80, bowman)"));
				
			if (craftSelect == 0) Craft(200, "#t1082089#", "#v4011007# #t4011007# \r\n#v4021006# 8 #t4021006#s \r\n#v4011006# 2 #t4011006#s \r\n#v4000030# 50 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n70000 mesos", 60, "DEX +1, STR +1");
			else if (craftSelect == 1) Craft(201, "#t1082106#", "#v4005002# 2 #t4005002#s \r\n#v4021005# 8 #t4021005#s \r\n#v4011004# 3 #t4011004#s \r\n#v4000030# 70 #t4000030#s \r\n#v4003000# 55 #t4003000#s \r\n90000 mesos", 70, "DEX +2");
			else if (craftSelect == 2) Craft(202, "#t1082109#", "#v4005002# 2 #t4005002#s \r\n#v4005000# #t4005000# \r\n#v4021000# 8 #t4021000#s \r\n#v4000030# 90 #t4000030#s \r\n#v4003000# 60 #t4003000#s \r\n100000 mesos", 80, "DEX +2, STR +1, MP +10");
		}
		if (craftType == 3)
		{
			int craftSelect = AskMenu("So, you want gloves just for thieves? Choose the one that suits your needs here!",
				(0, " #b#t1082092##k(level limit: 60, thief)"),
				(1, " #b#t1082095##k(level limit: 70, thief)"),
				(2, " #b#t1082118##k(level limit: 80, thief)"));
				
			if (craftSelect == 0) Craft(300, "#t1082092#", "#v4011007# #t4011007# \r\n#v4011000# 8 #t4011000#s \r\n#v4021007# #t4021007# \r\n#v4000030# 50 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n70000 mesos", 60, "LUK +1, DEX +1");
			else if (craftSelect == 1) Craft(301, "#t1082095#", "#v4005003# 2 #t4005003#s \r\n#v4011000# 6 #t4011000#s \r\n#v4011003# 6 #t4011003#s \r\n#v4000030# 70 #t4000030#s \r\n#v4003000# 55 #t4003000#s \r\n90000 mesos", 70, "LUK +2");
			else if (craftSelect == 2) Craft(302, "#t1082118#", "#v4005003# 2 #t4005003#s \r\n#v4005002# #t4005002# \r\n#v4011002# 8 #t4011002#s \r\n#v4000030# 90 #t4000030#s \r\n#v4003000# 60 #t4003000#s \r\n100000 mesos", 80, "LUK +2, DEX +1, MP +10");
		}
		if (craftType == 4)
		{
			int craftSelect = AskMenu("You want to upgrade your warrior gloves, right? Choose what you want to upgrade...",
				(0, " #b#t1082060##k(level limit: 60, warrior)"),
				(1, " #b#t1082061##k(level limit: 60, warrior)"),
				(2, " #b#t1082104##k(level limit: 70, warrior)"),
				(3, " #b#t1082105##k(level limit: 70, warrior)"),
				(4, " #b#t1082115##k(level limit: 80, warrior)"),
				(5, " #b#t1082116##k(level limit: 80, warrior)"),
				(6, " #b#t1082117##k(level limit: 80, warrior)"));
				
			if (craftSelect == 0) Craft(400, "#t1082060#", "#v1082059# #t1082059# \r\n#v4011002# 3 #t4011002#s \r\n#v4021005# 5 #t4021005#s \r\n70000 mesos", 60, "STR +2, Accuracy +1");
			else if (craftSelect == 1) Craft(401, "#t1082061#", "#v1082059# #t1082059# \r\n#v4021007# 2 #t4021007#s \r\n#v4021008# 2 #t4021008#s \r\n80000 mesos", 60, "STR +3, Accuracy +2");
			else if (craftSelect == 2) Craft(402, "#t1082104#", "#v1082103# #t1082103# \r\n#v4011002# 6 #t4011002#s \r\n#v4021006# 4 #t4021006#s \r\n90000 mesos", 70, "STR +3, Accuracy +1");
			else if (craftSelect == 3) Craft(403, "#t1082105#", "#v1082103# #t1082103# \r\n#v4021006# 8 #t4021006#s \r\n#v4021008# 3 #t4021008#s \r\n100000 mesos", 70, "STR +4, Accuracy +1");
			else if (craftSelect == 4) Craft(404, "#t1082115#", "#v1082114# #t1082114# \r\n#v4005000# #t4005000# \r\n#v4005002# #t4005002# \r\n#v4021003# 7 #t4021003#s \r\n110000 mesos", 80, "STR +3, DEX +2, MP +15");
			else if (craftSelect == 5) Craft(405, "#t1082116#", "#v1082114# #t1082114# \r\n#v4005002# 3 #t4005002#s \r\n#v4021000# 8 #t4021000#s \r\n120000 mesos", 80, "DEX +4, STR +2, MP +20");
			else if (craftSelect == 6) Craft(406, "#t1082117#", "#v1082114# #t1082114# \r\n#v4005000# 2 #t4005000#s \r\n#v4005002# #t4005002# \r\n#v4021008# 4 #t4021008#s \r\n120000 mesos", 80, "STR +4, DEX +2, MP +20");
		}
		if (craftType == 5)
		{
			int craftSelect = AskMenu("You want to upgrade your magician gloves, right? Choose what you want to upgrade...",
				(0, " #b#t1082087##k(level limit: 60, magician)"),
				(1, " #b#t1082088##k(level limit: 60, magician)"),
				(2, " #b#t1082099##k(level limit: 70, magician)"),
				(3, " #b#t1082100##k(level limit: 70, magician)"),
				(4, " #b#t1082122##k(level limit: 80, magician)"),
				(5, " #b#t1082123##k(level limit: 80, magician)"));
				
			if (craftSelect == 0) Craft(500, "#t1082087#", "#v1082086# #t1082086# \r\n#v4011004# 3 #t4011004#s \r\n#v4011006# 5 #t4011006#s \r\n70000 mesos", 60, "INT +2, LUK +1, MP +30");
			else if (craftSelect == 1) Craft(501, "#t1082088#", "#v1082086# #t1082086# \r\n#v4021008# 2 #t4021008#s \r\n#v4011006# 3 #t4011006#s \r\n80000 mesos", 60, "INT +3, LUK +1, MP +30");
			else if (craftSelect == 2) Craft(502, "#t1082099#", "#v1082098# #t1082098# \r\n#v4021002# 6 #t4021002#s \r\n#v4021007# 2 #t4021007#s \r\n90000 mesos", 70, "INT +3, LUK +1");
			else if (craftSelect == 3) Craft(503, "#t1082100#", "#v1082098# #t1082098# \r\n#v4021008# 3 #t4021008#s \r\n#v4011006# 3 #t4011006#s \r\n100000 mesos", 70, "INT +4, LUK +1");
			else if (craftSelect == 4) Craft(504, "#t1082122#", "#v1082121# #t1082121# \r\n#v4005001# #t4005001# \r\n#v4005003# #t4005003# \r\n#v4021005# 7 #t4021005#s \r\n110000 mesos", 80, "INT +3, LUK +2, MP +15");
			else if (craftSelect == 5) Craft(505, "#t1082123#", "#v1082121# #t1082121# \r\n#v4005001# 2 #t4005001#s \r\n#v4005003# #t4005003# \r\n#v4021008# 4 #t4021008#s \r\n120000 mesos", 80, "INT +4, LUK +2, MP +30");
		}
		if (craftType == 6)
		{
			int craftSelect = AskMenu("You want to upgrade your bowman gloves, right? Choose what you want to upgrade...",
				(0, " #b#t1082090##k(level limit: 60, bowman)"),
				(1, " #b#t1082091##k(level limit: 60, bowman)"),
				(2, " #b#t1082107##k(level limit: 70, bowman)"),
				(3, " #b#t1082108##k(level limit: 70, bowman)"),
				(4, " #b#t1082110##k(level limit: 80, bowman)"),
				(5, " #b#t1082111##k(level limit: 80, bowman)"),
				(6, " #b#t1082112##k(level limit: 80, bowman)"));
				
			if (craftSelect == 0) Craft(600, "#t1082090#", "#v1082089# #t1082089# \r\n#v4021007# #t4021007# \r\n#v4021000# 5 #t4021000#s \r\n70000 mesos", 60, "DEX +2, STR +1, MP +15");
			else if (craftSelect == 1) Craft(601, "#t1082091#", "#v1082089# #t1082089# \r\n#v4021007# 2 #t4021007#s \r\n#v4021008# 2 #t4021008#s \r\n80000 mesos", 60, "DEX +3, STR +1, MP +30");
			else if (craftSelect == 2) Craft(602, "#t1082107#", "#v1082106# #t1082106# \r\n#v4021006# 5 #t4021006#s \r\n#v4011006# 3 #t4011006#s \r\n90000 mesos", 70, "DEX +3, Avoid. +1");
			else if (craftSelect == 3) Craft(603, "#t1082108#", "#v1082106# #t1082106# \r\n#v4021007# 2 #t4021007#s \r\n#v4021008# 3 #t4021008#s \r\n100000 mesos", 70, "DEX +4, Avoid. +1");
			else if (craftSelect == 4) Craft(604, "#t1082110#", "#v1082109# #t1082109# \r\n#v4005002# #t4005002# \r\n#v4005000# #t4005000# \r\n#v4021005# 7 #t4021005#s \r\n110000 mesos", 80, "DEX +3, STR +2, MP +15");
			else if (craftSelect == 5) Craft(605, "#t1082111#", "#v1082109# #t1082109# \r\n#v4005002# #t4005002# \r\n#v4005000# #t4005000# \r\n#v4021003# 7 #t4021003#s \r\n110000 mesos", 80, "DEX +3, STR +2, MP +15");
			else if (craftSelect == 6) Craft(606, "#t1082112#", "#v1082109# #t1082109# \r\n#v4005002# 2 #t4005002#s \r\n#v4005000# #t4005000# \r\n#v4021008# 4 #t4021008#s \r\n120000 mesos", 80, "DEX +4, STR +2, MP +30");
		}
		if (craftType == 7)
		{
			int craftSelect = AskMenu("You want to upgrade your thief gloves, right? Choose what you want to upgrade...",
				(0, " #b#t1082093##k(level limit: 60, thief)"),
				(1, " #b#t1082094##k(level limit: 60, thief)"),
				(2, " #b#t1082096##k(level limit: 70, thief)"),
				(3, " #b#t1082097##k(level limit: 70, thief)"),
				(4, " #b#t1082119##k(level limit: 80, thief)"),
				(5, " #b#t1082120##k(level limit: 80, thief)"));
				
			if (craftSelect == 0) Craft(700, "#t1082093#", "#v1082092# #t1082092# \r\n#v4011001# #t4011001# \r\n#v4000014# 200 #t4000014#s \r\n70000 mesos", 60, "LUK +2, DEX +1, MP +15");
			else if (craftSelect == 1) Craft(701, "#t1082094#", "#v1082092# #t1082092# \r\n#v4011006# 7 #t4011006#s \r\n#v4000027# 150 #t4000027#s \r\n80000 mesos", 60, "LUK +3, DEX +1, MP +30");
			else if (craftSelect == 2) Craft(702, "#t1082096#", "#v1082095# #t1082095# \r\n#v4011004# 6 #t4011004#s \r\n#v4021007# 2 #t4021007#s \r\n90000 mesos", 70, "LUK +3, Avoid. +1");
			else if (craftSelect == 3) Craft(703, "#t1082097#", "#v1082095# #t1082095# \r\n#v4021007# 3 #t4021007#s \r\n#v4011006# 3 #t4011006#s \r\n100000 mesos", 70, "LUK +4, Avoid. +1");
			else if (craftSelect == 4) Craft(704, "#t1082119#", "#v1082118# #t1082118# \r\n#v4005003# #t4005003# \r\n#v4005002# #t4005002# \r\n#v4021001# 7 #t4021001#s \r\n110000 mesos", 80, "LUK +3, DEX +2, MP +15");
			else if (craftSelect == 5) Craft(705, "#t1082120#", "#v1082118# #t1082118# \r\n#v4005003# 2 #t4005003#s \r\n#v4005002# #t4005002# \r\n#v4021000# 8 #t4021000#s \r\n120000 mesos", 80, "LUK +4, DEX +2, MP +30");
		}
	}
}