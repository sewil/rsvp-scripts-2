using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Craft1(int index, string makeItem, string needItem, int reqLevel, string itemOption)
	{
		bool askBuy = AskYesNo($"To upgrade {makeItem} with a stimulator, I'll need the following items. The Level Limit is {reqLevel}, and the basic stats are {itemOption}. Please make sure not to use an enhanced item as a material in the upgrade. If the stimulator is used, the item stats can all be increased, but #bit can also end up worse than it was before, additionally it carries a 10% chance of failure#k, so please be careful. What do you think? Do you want to upgrade the item?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("I understand. When you use a stimulator, you run the risk of failing to create the item, and so you can still waste the materials in the process. I would be careful too, but if you change your mind, feel free.");
			return;
		}
		
		Random rnd = new Random();
		int chance = rnd.Next(1, 11);
		
		bool trade = false;
		// check for mesos first?
		if (chance == 1)
		{
			// warrior glove upgrade - failed
			if (index == 0) trade = Exchange(0, 4130000, -1, 1082007, -1, 4011001, -1);
			else if (index == 1) trade = Exchange(0, 4130000, -1, 1082007, -1, 4011005, -2);
			else if (index == 2) trade = Exchange(0, 4130000, -1, 1082008, -1, 4021006, -3);
			else if (index == 3) trade = Exchange(0, 4130000, -1, 1082008, -1, 4021008, -1);
			else if (index == 4) trade = Exchange(0, 4130000, -1, 1082023, -1, 4011003, -4);
			else if (index == 5) trade = Exchange(0, 4130000, -1, 1082023, -1, 4021008, -2);
			else if (index == 6) trade = Exchange(0, 4130000, -1, 1082009, -1, 4011002, -5);
			else if (index == 7) trade = Exchange(0, 4130000, -1, 1082009, -1, 4011006, -4);
			
			// magician glove upgrade - failed
			else if (index == 100) trade = Exchange(0, 4130000, -1, 1082051, -1, 4021005, -3);
			else if (index == 101) trade = Exchange(0, 4130000, -1, 1082051, -1, 4021008, -1);
			else if (index == 102) trade = Exchange(0, 4130000, -1, 1082054, -1, 4021005, -3);
			else if (index == 103) trade = Exchange(0, 4130000, -1, 1082054, -1, 4021008, -1);
			else if (index == 104) trade = Exchange(0, 4130000, -1, 1082062, -1, 4021002, -4);
			else if (index == 105) trade = Exchange(0, 4130000, -1, 1082062, -1, 4021008, -2);
			else if (index == 106) trade = Exchange(0, 4130000, -1, 1082081, -1, 4021002, -5);
			else if (index == 107) trade = Exchange(0, 4130000, -1, 1082081, -1, 4021008, -3);
			
			// bowman glove upgrade - failed
			else if (index == 200) trade = Exchange(0, 4130000, -1, 1082048, -1, 4021003, -3);
			else if (index == 201) trade = Exchange(0, 4130000, -1, 1082048, -1, 4021008, -1);
			else if (index == 202) trade = Exchange(0, 4130000, -1, 1082068, -1, 4011002, -4);
			else if (index == 203) trade = Exchange(0, 4130000, -1, 1082068, -1, 4011006, -2);
			else if (index == 204) trade = Exchange(0, 4130000, -1, 1082071, -1, 4011006, -4);
			else if (index == 205) trade = Exchange(0, 4130000, -1, 1082071, -1, 4021008, -2);
			else if (index == 206) trade = Exchange(0, 4130000, -1, 1082084, -1, 4021000, -5, 4011000, -1);
			else if (index == 207) trade = Exchange(0, 4130000, -1, 1082084, -1, 4021008, -2, 4011006, -2);
			
			// thief glove upgrade - failed
			else if (index == 300) trade = Exchange(0, 4130000, -1, 1082042, -1, 4011004, -2);
			else if (index == 301) trade = Exchange(0, 4130000, -1, 1082042, -1, 4011006, -1);
			else if (index == 302) trade = Exchange(0, 4130000, -1, 1082046, -1, 4011005, -3);
			else if (index == 303) trade = Exchange(0, 4130000, -1, 1082046, -1, 4011006, -2);
			else if (index == 304) trade = Exchange(0, 4130000, -1, 1082075, -1, 4011006, -4);
			else if (index == 305) trade = Exchange(0, 4130000, -1, 1082075, -1, 4021008, -2);
			else if (index == 306) trade = Exchange(0, 4130000, -1, 1082065, -1, 4021000, -5);
			else if (index == 307) trade = Exchange(0, 4130000, -1, 1082065, -1, 4011006, -2);
			
			if (!trade)
			{
				self.say("Please check if you have all the items you need, or if your equip. inventory is full or not.");
				return;
			}
				
			self.say("Darn... I must have stimulated it too much... All the items are gone now... I'm sorry. I warned you about the possibility of this happening, and I hope that you can understand.");
		}
		else
		{
			// warrior glove upgrade - success
			if (index == 0) trade = ExchangeEx(-20000, "4130000", -1, "1082007", -1, "4011001", -1, "1082005,Variation:1", 1);
			else if (index == 1) trade = ExchangeEx(-25000, "4130000", -1, "1082007", -1, "4011005", -2, "1082006,Variation:1", 1);
			else if (index == 2) trade = ExchangeEx(-30000, "4130000", -1, "1082008", -1, "4021006", -3, "1082035,Variation:1", 1);
			else if (index == 3) trade = ExchangeEx(-40000, "4130000", -1, "1082008", -1, "4021008", -1, "1082036,Variation:1", 1);
			else if (index == 4) trade = ExchangeEx(-45000, "4130000", -1, "1082023", -1, "4011003", -4, "1082024,Variation:1", 1);
			else if (index == 5) trade = ExchangeEx(-50000, "4130000", -1, "1082023", -1, "4021008", -2, "1082025,Variation:1", 1);
			else if (index == 6) trade = ExchangeEx(-55000, "4130000", -1, "1082009", -1, "4011002", -5, "1082010,Variation:1", 1);
			else if (index == 7) trade = ExchangeEx(-60000, "4130000", -1, "1082009", -1, "4011006", -4, "1082011,Variation:1", 1);
			
			// magician glove upgrade - success
			else if (index == 100) trade = ExchangeEx(-35000, "4130000", -1, "1082051", -1, "4021005", -3, "1082052,Variation:1", 1);
			else if (index == 101) trade = ExchangeEx(-40000, "4130000", -1, "1082051", -1, "4021008", -1, "1082053,Variation:1", 1);
			else if (index == 102) trade = ExchangeEx(-40000, "4130000", -1, "1082054", -1, "4021005", -3, "1082055,Variation:1", 1);
			else if (index == 103) trade = ExchangeEx(-45000, "4130000", -1, "1082054", -1, "4021008", -1, "1082056,Variation:1", 1);
			else if (index == 104) trade = ExchangeEx(-45000, "4130000", -1, "1082062", -1, "4021002", -4, "1082063,Variation:1", 1);
			else if (index == 105) trade = ExchangeEx(-50000, "4130000", -1, "1082062", -1, "4021008", -2, "1082064,Variation:1", 1);
			else if (index == 106) trade = ExchangeEx(-55000, "4130000", -1, "1082081", -1, "4021002", -5, "1082082,Variation:1", 1);
			else if (index == 107) trade = ExchangeEx(-60000, "4130000", -1, "1082081", -1, "4021008", -3, "1082080,Variation:1", 1);
			
			// bowman glove upgrade - success
			else if (index == 200) trade = ExchangeEx(-15000, "4130000", -1, "1082048", -1, "4021003", -3, "1082049,Variation:1", 1);
			else if (index == 201) trade = ExchangeEx(-20000, "4130000", -1, "1082048", -1, "4021008", -1, "1082050,Variation:1", 1);
			else if (index == 202) trade = ExchangeEx(-22000, "4130000", -1, "1082068", -1, "4011002", -4, "1082069,Variation:1", 1);
			else if (index == 203) trade = ExchangeEx(-25000, "4130000", -1, "1082068", -1, "4011006", -2, "1082070,Variation:1", 1);
			else if (index == 204) trade = ExchangeEx(-30000, "4130000", -1, "1082071", -1, "4011006", -4, "1082072,Variation:1", 1);
			else if (index == 205) trade = ExchangeEx(-40000, "4130000", -1, "1082071", -1, "4021008", -2, "1082073,Variation:1", 1);
			else if (index == 206) trade = ExchangeEx(-55000, "4130000", -1, "1082084", -1, "4021000", -5, "4011000", -1, "1082085,Variation:1", 1);
			else if (index == 207) trade = ExchangeEx(-60000, "4130000", -1, "1082084", -1, "4021008", -2, "4011006", -2, "1082083,Variation:1", 1);
			
			// thief glove upgrade - success
			else if (index == 300) trade = ExchangeEx(-15000, "4130000", -1, "1082042", -1, "4011004", -2, "1082043,Variation:1", 1);
			else if (index == 301) trade = ExchangeEx(-20000, "4130000", -1, "1082042", -1, "4011006", -1, "1082044,Variation:1", 1);
			else if (index == 302) trade = ExchangeEx(-22000, "4130000", -1, "1082046", -1, "4011005", -3, "1082047,Variation:1", 1);
			else if (index == 303) trade = ExchangeEx(-25000, "4130000", -1, "1082046", -1, "4011006", -2, "1082045,Variation:1", 1);
			else if (index == 304) trade = ExchangeEx(-45000, "4130000", -1, "1082075", -1, "4011006", -4, "1082076,Variation:1", 1);
			else if (index == 305) trade = ExchangeEx(-50000, "4130000", -1, "1082075", -1, "4021008", -2, "1082074,Variation:1", 1);
			else if (index == 306) trade = ExchangeEx(-55000, "4130000", -1, "1082065", -1, "4021000", -5, "1082067,Variation:1", 1);
			else if (index == 307) trade = ExchangeEx(-60000, "4130000", -1, "1082065", -1, "4011006", -2, "4021008", -1, "1082066,Variation:1", 1);
			
			if (!trade)
			{
				self.say("Please check if you have all the items you need, or if your equip. inventory is full or not.");
				return;
			}
				
			self.say($"Here! Take the {makeItem}! Everything worked out, and this glove looks much more beautiful than a common glove. Please come again!");
		}
	}
	
	private void Craft2(int index, string makeItem, string needItem, int reqLevel)
	{
		bool askBuy = AskYesNo($"To make a {makeItem}, you will need the following materials. The Level Limit for this item is {reqLevel}, so, make sure that it's something you really need. Do you want me to do it?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("Don't have the materials? Alright. Come back after you have all the materials needed to make the item...");
			return;
		}
		
		bool trade = false;
		
		// creating warrior glove
		if (index == 0) trade = Exchange(-18000, 4011000, -3, 4011001, -2, 4003000, -15, 1082007, 1);
		else if (index == 1) trade = Exchange(-27000, 4011001, -4, 4000021, -30, 4003000, -30, 1082008, 1);
		else if (index == 2) trade = Exchange(-36000, 4011001, -5, 4000021, -50, 4003000, -40, 1082023, 1);
		else if (index == 3) trade = Exchange(-45000, 4011001, -3, 4021007, -2, 4000030, -30, 4003000, -45, 1082009, 1);
		
		// creating magician glove
		else if (index == 100) trade = Exchange(-22500, 4000021, -60, 4021006, -1, 4021000, -2, 1082051, 1);
		else if (index == 101) trade = Exchange(-27000, 4000021, -70, 4011006, -1, 4011001, -3, 4021000, -2, 1082054, 1);
		else if (index == 102) trade = Exchange(-36000, 4000021, -80, 4021000, -3, 4021006, -3, 4003000, -30, 1082062, 1);
		else if (index == 103) trade = Exchange(-45000, 4021000, -3, 4011006, -2, 4000030, -35, 4003000, -40, 1082081, 1);
		
		// creating bowman glove
		else if (index == 200) trade = Exchange(-18000, 4000021, -50, 4021001, -1, 4011006, -2, 1082048, 1);
		else if (index == 201) trade = Exchange(-27000, 4000021, -60, 4011001, -3, 4011000, -1, 4003000, -15, 1082068, 1);
		else if (index == 202) trade = Exchange(-36000, 4000021, -80, 4021002, -3, 4011001, -3, 4021000, -1, 4003000, -25, 1082071, 1);
		else if (index == 203) trade = Exchange(-45000, 4011004, -3, 4021002, -2, 4011006, -1, 4000030, -40, 4003000, -35, 1082084, 1);
		
		// creating thief glove
		else if (index == 300) trade = Exchange(-22500, 4011001, -2, 4000021, -50, 4003000, -10, 1082042, 1);
		else if (index == 301) trade = Exchange(-27000, 4011001, -3, 4011000, -1, 4000021, -60, 4003000, -15, 1082046, 1);
		else if (index == 302) trade = Exchange(-36000, 4000021, -80, 4021000, -3, 4000101, -100, 4003000, -30, 1082075, 1);
		else if (index == 303) trade = Exchange(-45000, 4021005, -3, 4021008, -1, 4000030, -40, 4003000, -30, 1082065, 1);
		
		if (!trade)
		{
			self.say("Please check if you have all the items you need, or if your equip. inventory is full or not.");
			return;
		}
			
		self.say($"Here! Take the {makeItem}! Look at this pretty thing... the stitching is impeccable, a beautiful work of art... isn't this item very well crafted? Please come back again anytime!");
	}
	
	private void Craft3(int index, string makeItem, string needItem, int reqLevel, string itemOption)
	{
		bool askBuy = AskYesNo($"To upgrade a(n) {makeItem}, you will need the following materials. The Level Limit will be {reqLevel}, and the basic stats will be #r{itemOption}#k. Please make sure not to use an enhanced item for the upgrade. What do you think? Do you want to continue with the upgrade?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("Don't have the materials? Alright. Come back after you have all the materials needed to make the item...");
			return;
		}
		
		bool trade = false;
		
		// warrior glove upgrade
		if (index == 0) trade = Exchange(-18000, 1082007, -1, 4011001, -1, 1082005, 1);
		else if (index == 1) trade = Exchange(-22500, 1082007, -1, 4011005, -2, 1082006, 1);
		else if (index == 2) trade = Exchange(-27000, 1082008, -1, 4021006, -3, 1082035, 1);
		else if (index == 3) trade = Exchange(-36000, 1082008, -1, 4021008, -1, 1082036, 1);
		else if (index == 4) trade = Exchange(-40500, 1082023, -1, 4011003, -4, 1082024, 1);
		else if (index == 5) trade = Exchange(-45000, 1082023, -1, 4021008, -2, 1082025, 1);
		else if (index == 6) trade = Exchange(-49500, 1082009, -1, 4011002, -5, 1082010, 1);
		else if (index == 7) trade = Exchange(-54000, 1082009, -1, 4011006, -4, 1082011, 1);
		
		// magician glove upgrade
		else if (index == 100) trade = Exchange(-31500, 1082051, -1, 4021005, -3, 1082052, 1);
		else if (index == 101) trade = Exchange(-36000, 1082051, -1, 4021008, -1, 1082053, 1);
		else if (index == 102) trade = Exchange(-36000, 1082054, -1, 4021005, -3, 1082055, 1);
		else if (index == 103) trade = Exchange(-40500, 1082054, -1, 4021008, -1, 1082056, 1);
		else if (index == 104) trade = Exchange(-40500, 1082062, -1, 4021002, -4, 1082063, 1);
		else if (index == 105) trade = Exchange(-45000, 1082062, -1, 4021008, -2, 1082064, 1);
		else if (index == 106) trade = Exchange(-49500, 1082081, -1, 4021002, -5, 1082082, 1);
		else if (index == 107) trade = Exchange(-54000, 1082081, -1, 4021008, -3, 1082080, 1);
		
		// bowman glove upgrade
		else if (index == 200) trade = Exchange(-13500, 1082048, -1, 4021003, -3, 1082049, 1);
		else if (index == 201) trade = Exchange(-18000, 1082048, -1, 4021008, -1, 1082050, 1);
		else if (index == 202) trade = Exchange(-19800, 1082068, -1, 4011002, -4, 1082069, 1);
		else if (index == 203) trade = Exchange(-22500, 1082068, -1, 4011006, -2, 1082070, 1);
		else if (index == 204) trade = Exchange(-27000, 1082071, -1, 4011006, -4, 1082072, 1);
		else if (index == 205) trade = Exchange(-36000, 1082071, -1, 4021008, -2, 1082073, 1);
		else if (index == 206) trade = Exchange(-49500, 1082084, -1, 4021000, -5, 4011000, -1, 1082085, 1);
		else if (index == 207) trade = Exchange(-54000, 1082084, -1, 4021008, -2, 4011006, -2, 1082083, 1);
		
		// thief glove upgrade
		else if (index == 300) trade = Exchange(-13500, 1082042, -1, 4011004, -2, 1082043, 1);
		else if (index == 301) trade = Exchange(-17000, 1082042, -1, 4011006, -1, 1082044, 1);
		else if (index == 302) trade = Exchange(-19800, 1082046, -1, 4011005, -3, 1082047, 1);
		else if (index == 303) trade = Exchange(-22500, 1082046, -1, 4011006, -2, 1082045, 1);
		else if (index == 304) trade = Exchange(-40500, 1082075, -1, 4011006, -4, 1082076, 1);
		else if (index == 305) trade = Exchange(-45000, 1082075, -1, 4021008, -2, 1082074, 1);
		else if (index == 306) trade = Exchange(-49500, 1082065, -1, 4021000, -5, 1082067, 1);
		else if (index == 307) trade = Exchange(-54000, 1082065, -1, 4011006, -2, 4021008, -1, 1082066, 1);
		
		if (!trade)
		{
			self.say("Please check if you have all the items you need, or if your equip. inventory is full or not.");
			return;
		}
			
		self.say($"Here! Take the {makeItem}! Look at this pretty thing... the stitching is impeccable, the beautiful work of art... isn't this item very well crafted? Please come back again, anytime!~");
	}
	
	public override void Run()
	{
		bool askStart = AskYesNo("Dude... nobody understands how hard it is to make a good glove, But everyone who wears my gloves agrees that they are the best you can find. How about you let me make one for you?");
		
		if (!askStart)
		{
			self.say("Hmm ~ you should never treat me the way that you treat other glove makers. I can do something that no one else can, so if you want to know more about it, come back later and talk to me.");
			return;
		}
		
		int craftType = AskMenu("Alright! The service fee will be very reasonable, no need to worry. What do you want to make?#b",
			(0, " What is a stimulator?"),
			(1, " Upgrade a glove using a stimulator\r\n"),
			(2, " Create a common warrior glove"),
			(3, " Create a common magician glove"),
			(4, " Create a common bowman glove"),
			(5, " Create a common thief glove"),
			(6, " Upgrade a common warrior glove"),
			(7, " Upgrade a common magician glove"),
			(8, " Upgrade a common bowman glove"),
			(9, " Upgrade a common thief glove"));
		
		if (craftType == 0)
		{
			self.say("I told you this is something that only I can do. You want to know more about the #rstimulator#k? It's a mysterious potion that is included in the creation process of a pair of gloves, and, after being used, the gloves will be created with a small variation in the armor's stats, as if you had received the gloves from a monster. The stimulator can then be used not only on gloves, but also on other items. Make sure to carry lots of them with you, because there are different types of stimulators available for different types of gloves.");
			self.say("But you should be aware of some things. If the stimulator is used, it's very likely that the item's stats will be altered, and the problem with that is the result can #bend up being worse#k, much worse than the original. You also run the risk of a \r\n#b10% rate of failure when creating the item#k, which means saying goodbye to the items you used to make the item in question. It sucks, right?");
			self.say("Even with these risks involved, many travelers seek my help to make a perfect glove using the stimulator. The thought of the item being of poor quality, becoming worse than it was, or even disappearing may scare you, but how about trying it anyway? If you're lucky, your item could be a marvel. That's all I can tell you.");
		}
		else if (craftType == 1)
		{
			int craftType2 = AskMenu("You want to upgrade your glove with a stimulator, right? Please choose the occupation for the glove that you'll upgrade!#b",
				(0, " Upgrade a warrior glove with a stimulator"),
				(1, " Upgrade a magician glove with a stimulator"),
				(2, " Upgrade a bowman glove with a stimulator"),
				(3, " Upgrade a thief glove with a stimulator"));
			
			if (craftType2 == 0)
			{
				int craftSelect = AskMenu("Which warrior gloves do you want to upgrade using the stimulator?",
					(0, " #b#t1082005##k(level limit: 30, warrior)"),
					(1, " #b#t1082006##k(level limit: 30, warrior)"),
					(2, " #b#t1082035##k(level limit: 35, warrior)"),
					(3, " #b#t1082036##k(level limit: 35, warrior)"),
					(4, " #b#t1082024##k(level limit: 40, warrior)"),
					(5, " #b#t1082025##k(level limit: 40, warrior)"),
					(6, " #b#t1082010##k(level limit: 50, warrior)"),
					(7, " #b#t1082011##k(level limit: 50, warrior)"));
					
				if (craftSelect == 0) Craft1(0, "#t1082005#", "#v4130000# #t4130000#\r\n#v1082007# #t1082007#\r\n#v4011001# #t4011001#\r\n20,000 mesos", 30, "STR +1");
				else if (craftSelect == 1) Craft1(1, "#t1082006#", "#v4130000# #t4130000#\r\n#v1082007# #t1082007#\r\n#v4011005# 2 #t4011005#s\r\n25,000 mesos", 30, "STR +2");
				else if (craftSelect == 2) Craft1(2, "#t1082035#", "#v4130000# #t4130000#\r\n#v1082008# #t1082008#\r\n#v4021006# 3 #t4021006#s\r\n30,000 mesos", 35, "STR +1");
				else if (craftSelect == 3) Craft1(3, "#t1082036#", "#v4130000# #t4130000#\r\n#v1082008# #t1082008#\r\n#v4021008# #t4021008#\r\n40,000 mesos", 35, "STR +2");
				else if (craftSelect == 4) Craft1(4, "#t1082024#", "#v4130000# #t4130000#\r\n#v1082023# #t1082023#\r\n#v4011003# 4 #t4011003#s\r\n45,000 mesos", 40, "STR +2");
				else if (craftSelect == 5) Craft1(5, "#t1082025#", "#v4130000# #t4130000#\r\n#v1082023# #t1082023#\r\n#v4021008# 2 #t4021008#s\r\n50,000 mesos", 40, "STR +3");
				else if (craftSelect == 6) Craft1(6, "#t1082010#", "#v4130000# #t4130000#\r\n#v1082009# #t1082009#\r\n#v4011002# 5 #t4011002#s\r\n55,000 mesos", 50, "STR +2, DEX +1");
				else if (craftSelect == 7) Craft1(7, "#t1082011#", "#v4130000# #t4130000#\r\n#v1082009# #t1082009#\r\n#v4011006# 4 #t4011006#s\r\n60,000 mesos", 50, "STR +3, Accuracy +1");
			}
			else if (craftType2 == 1)
			{
				int craftSelect = AskMenu("Which magician gloves do you want to upgrade using the stimulator?",
					(0, " #b#t1082052##k(level limit: 30, magician)"),
					(1, " #b#t1082053##k(level limit: 30, magician)"),
					(2, " #b#t1082055##k(level limit: 35, magician)"),
					(3, " #b#t1082056##k(level limit: 35, magician)"),
					(4, " #b#t1082063##k(level limit: 40, magician)"),
					(5, " #b#t1082064##k(level limit: 40, magician)"),
					(6, " #b#t1082082##k(level limit: 50, magician)"),
					(7, " #b#t1082080##k(level limit: 50, magician)"));
					
				if (craftSelect == 0) Craft1(100, "#t1082052#", "#v4130000# #t4130000#\r\n#v1082051# #t1082051#\r\n#v4021005# 3 #t4021005#s\r\n35,000 mesos", 30, "INT +1");
				else if (craftSelect == 1) Craft1(101, "#t1082053#", "#v4130000# #t4130000#\r\n#v1082051# #t1082051#\r\n#v4021008# #t4021008#\r\n40,000 mesos", 30, "INT +2");
				else if (craftSelect == 2) Craft1(102, "#t1082055#", "#v4130000# #t4130000#\r\n#v1082054# #t1082054#\r\n#v4021005# 3 #t4021005#s\r\n40,000 mesos", 35, "INT +1");
				else if (craftSelect == 3) Craft1(103, "#t1082056#", "#v4130000# #t4130000#\r\n#v1082054# #t1082054#\r\n#v4021008# #t4021008#\r\n45,000 mesos", 35, "INT +2");
				else if (craftSelect == 4) Craft1(104, "#t1082063#", "#v4130000# #t4130000#\r\n#v1082062# #t1082062#\r\n#v4021002# 4 #t4021002#s\r\n45,000 mesos", 40, "INT +2");
				else if (craftSelect == 5) Craft1(105, "#t1082064#", "#v4130000# #t4130000#\r\n#v1082062# #t1082062#\r\n#v4021008# 2 #t4021008#s\r\n50,000 mesos", 40, "INT +3");
				else if (craftSelect == 6) Craft1(106, "#t1082082#", "#v4130000# #t4130000#\r\n#v1082081# #t1082081#\r\n#v4021002# 5 #t4021002#s\r\n55,000 mesos", 50, "INT +2, MP +15");
				else if (craftSelect == 7) Craft1(107, "#t1082080#", "#v4130000# #t4130000#\r\n#v1082081# #t1082081#\r\n#v4021008# 3 #t4021008#s\r\n60,000 mesos", 50, "INT +3, MP +30");
			}
			else if (craftType2 == 2)
			{
				int craftSelect = AskMenu("Which bowman gloves do you want to upgrade using the stimulator?",
					(0, " #b#t1082049##k(level limit: 30, bowman)"),
					(1, " #b#t1082050##k(level limit: 30, bowman)"),
					(2, " #b#t1082069##k(level limit: 35, bowman)"),
					(3, " #b#t1082070##k(level limit: 35, bowman)"),
					(4, " #b#t1082072##k(level limit: 40, bowman)"),
					(5, " #b#t1082073##k(level limit: 40, bowman)"),
					(6, " #b#t1082085##k(level limit: 50, bowman)"),
					(7, " #b#t1082083##k(level limit: 50, bowman)"));
				
				if (craftSelect == 0) Craft1(200, "#t1082049#", "#v4130000# #t4130000#\r\n#v1082048# #t1082048#\r\n#v4021003# 3 #t4021003#s\r\n15,000 mesos", 30, "DEX +1");
				else if (craftSelect == 1) Craft1(201, "#t1082050#", "#v4130000# #t4130000#\r\n#v1082048# #t1082048#\r\n#v4021008# #t4021008#\r\n20,000 mesos", 30, "DEX +2");
				else if (craftSelect == 2) Craft1(202, "#t1082069#", "#v4130000# #t4130000#\r\n#v1082068# #t1082068#\r\n#v4011002# 4 #t4011002#s\r\n22,000 mesos", 35, "DEX +1");
				else if (craftSelect == 3) Craft1(203, "#t1082070#", "#v4130000# #t4130000#\r\n#v1082068# #t1082068#\r\n#v4011006# 2 #t4011006#s\r\n25,000 mesos", 35, "DEX +2");
				else if (craftSelect == 4) Craft1(204, "#t1082072#", "#v4130000# #t4130000#\r\n#v1082071# #t1082071#\r\n#v4011006# 4 #t4011006#s\r\n30,000 mesos", 40, "DEX +2");
				else if (craftSelect == 5) Craft1(205, "#t1082073#", "#v4130000# #t4130000#\r\n#v1082071# #t1082071#\r\n#v4021008# 2 #t4021008#s\r\n40,000 mesos", 40, "DEX +3");
				else if (craftSelect == 6) Craft1(206, "#t1082085#", "#v4130000# #t4130000#\r\n#v1082084# #t1082084#\r\n#v4021000# 5 #t4021000#s\r\n#v4011000# #t4011000#\r\n55,000 mesos", 50, "DEX +2, MP +10");
				else if (craftSelect == 7) Craft1(207, "#t1082083#", "#v4130000# #t4130000#\r\n#v1082084# #t1082084#\r\n#v4021008# 2 #t4021008#s\r\n#v4011006# 2 #t4011006#s\r\n60,000 mesos", 50, "DEX +3, MP +20");
			}
			else if (craftType2 == 3)
			{
				int craftSelect = AskMenu("Which thief gloves do you want to upgrade using the stimulator?",
					(0, " #b#t1082043##k(level limit: 30, thief)"),
					(1, " #b#t1082044##k(level limit: 30, thief)"),
					(2, " #b#t1082047##k(level limit: 35, thief)"),
					(3, " #b#t1082045##k(level limit: 35, thief)"),
					(4, " #b#t1082076##k(level limit: 40, thief)"),
					(5, " #b#t1082074##k(level limit: 40, thief)"),
					(6, " #b#t1082067##k(level limit: 50, thief)"),
					(7, " #b#t1082066##k(level limit: 50, thief)"));
				
				if (craftSelect == 0) Craft1(300, "#t1082043#", "#v4130000# #t4130000#\r\n#v1082042# #t1082042#\r\n#v4011004# 2 #t4011004#s\r\n15,000 mesos", 30, "LUK +1");
				else if (craftSelect == 1) Craft1(301, "#t1082044#", "#v4130000# #t4130000#\r\n#v1082042# #t1082042#\r\n#v4011006# #t4011006#\r\n20,000 mesos", 30, "LUK +2");
				else if (craftSelect == 2) Craft1(302, "#t1082047#", "#v4130000# #t4130000#\r\n#v1082046# #t1082046#\r\n#v4011005# 3 #t4011005#s\r\n22,000 mesos", 35, "LUK +1");
				else if (craftSelect == 3) Craft1(303, "#t1082045#", "#v4130000# #t4130000#\r\n#v1082046# #t1082046#\r\n#v4011006# 2 #t4011006#s\r\n25,000 mesos", 35, "LUK +2");
				else if (craftSelect == 4) Craft1(304, "#t1082076#", "#v4130000# #t4130000#\r\n#v1082075# #t1082075#\r\n#v4011006# 4 #t4011006#s\r\n45,000 mesos", 40, "LUK +2");
				else if (craftSelect == 5) Craft1(305, "#t1082074#", "#v4130000# #t4130000#\r\n#v1082075# #t1082075#\r\n#v4021008# 2 #t4021008#s\r\n50,000 mesos", 40, "LUK +3");
				else if (craftSelect == 6) Craft1(306, "#t1082067#", "#v4130000# #t4130000#\r\n#v1082065# #t1082065#\r\n#v4021000# 5 #t4021000#s\r\n55,000 mesos", 50, "LUK +2, DEX +1");
				else if (craftSelect == 7) Craft1(307, "#t1082066#", "#v4130000# #t4130000#\r\n#v1082065# #t1082065#\r\n#v4011006# 2 #t4011006#s\r\n#v4021008# #t4021008#\r\n60,000 mesos", 50, "LUK +3, Avoid. +1");
			}
		}
		else if (craftType == 2)
		{
			int craftSelect = AskMenu("So you want to make a warrior glove? You won't be able to use the stimulator when you're making the glove. Please choose the item that you want to make~",
				(0, " #b#t1082007##k(level limit: 30, warrior)"),
				(1, " #b#t1082008##k(level limit: 35, warrior)"),
				(2, " #b#t1082023##k(level limit: 40, warrior)"),
				(3, " #b#t1082009##k(level limit: 50, warrior)"));
			
			if (craftSelect == 0) Craft2(0, "#t1082007#", "#v4011000# 3 #t4011000#s\r\n#v4011001# 2 #t4011001#s\r\n#v4003000# 15 #t4003000#s\r\n18,000 mesos", 30);
			else if (craftSelect == 1) Craft2(1, "#t1082008#", "#v4000021# 30 #t4000021#s\r\n#v4011001#  4 #t4011001#s\r\n#v4003000# 30 #t4003000#s\r\n27,000 mesos", 35);
			else if (craftSelect == 2) Craft2(2, "#t1082023#", "#v4000021# 50 #t4000021#s\r\n#v4011001# 5 #t4011001#s\r\n#v4003000# 40 #t4003000#s\r\n36,000 mesos", 40);
			else if (craftSelect == 3) Craft2(3, "#t1082009#", "#v4011001# 3 #t4011001#s\r\n#v4021007# 2 #t4021007#s\r\n#v4000030# 30 #t4000030#s\r\n#v4003000# 45 #t4003000#s\r\n45,000 mesos", 50);
		}
		else if (craftType == 3)
		{
			int craftSelect = AskMenu("So you want to make a magician glove? You won't be able to use the stimulator when you're making the glove. Please choose the item that you want to make~",
				(0, " #b#t1082051##k(level limit: 30, magician)"),
				(1, " #b#t1082054##k(level limit: 35, magician)"),
				(2, " #b#t1082062##k(level limit: 40, magician)"),
				(3, " #b#t1082081##k(level limit: 50, magician)"));
			
			if (craftSelect == 0) Craft2(100, "#t1082051#", "#v4000021# 60 #t4000021#s\r\n#v4011006# #t4011006#\r\n#v4021000# 2 #t4021000#s\r\n22,500 mesos", 30);
			else if (craftSelect == 1) Craft2(101, "#t1082054#", "#v4000021# 70 #t4000021#s\r\n#v4011006# #t4011006#\r\n#v4011001# 3 #t4011001#s\r\n#v4021000# 2 #t4021000#s\r\n27,000 mesos", 35);
			else if (craftSelect == 2) Craft2(102, "#t1082062#", "#v4000021# 80 #t4000021#s\r\n#v4021000# 3 #t4021000#s\r\n#v4021006# 3 #t4021006#s\r\n#v4003000# 30 #t4003000#s\r\n36,000 mesos", 40);
			else if (craftSelect == 3) Craft2(103, "#t1082081#", "#v4021000# 3 #t4021000#s\r\n#v4011006# 2 #t4011006#s\r\n#v4000030# 35 #t4000030#s\r\n#v4003000# 40 #t4003000#s\r\n45,000 mesos", 50);
		}
		else if (craftType == 4)
		{
			int craftSelect = AskMenu("So you want to make a bowman glove? You won't be able to use the stimulator when you're making the glove. Please choose the item that you want to make~",
				(0, " #b#t1082048##k(level limit: 30, bowman)"),
				(1, " #b#t1082068##k(level limit: 35, bowman)"),
				(2, " #b#t1082071##k(level limit: 40, bowman)"),
				(3, " #b#t1082084##k(level limit: 50, bowman)"));
			
			if (craftSelect == 0) Craft2(200, "#t1082048#", "#v4000021# 50 #t4000021#s\r\n#v4021001# #t4021001#\r\n#v4011006# 2 #t4011006#s\r\n18,000 mesos", 30);
			else if (craftSelect == 1) Craft2(201, "#t1082068#", "#v4000021# 60 #t4000021#s\r\n#v4011001# 3 #t4011001#s\r\n#v4011000# #t4011000#\r\n#v4003000# 15 #t4003000#s\r\n27,000 mesos", 35);
			else if (craftSelect == 2) Craft2(202, "#t1082071#", "#v4000021# 80 #t4000021#s\r\n#v4021002# 3 #t4021002#s\r\n#v4011001# 3 #t4011001#s\r\n#v4021000# #t4021000#\r\n#v4003000# 25 #t4003000#s\r\n36,000 mesos", 40);
			else if (craftSelect == 3) Craft2(203, "#t1082084#", "#v4011004# 3 #t4011004#s\r\n#v4021002# 2 #t4021002#s\r\n#v4011006# #t4011006#\r\n#v4000030# 40 #t4000030#s\r\n#v4003000# 35 #t4003000#s\r\n45,000 mesos", 50);
		}
		else if (craftType == 5)
		{
			int craftSelect = AskMenu("So you want to make a thief glove? You won't be able to use the stimulator when you're making the glove. Please choose the item that you want to make~",
				(0, " #b#t1082042##k(level limit: 30, thief)"),
				(1, " #b#t1082046##k(level limit: 35, thief)"),
				(2, " #b#t1082075##k(level limit: 40, thief)"),
				(3, " #b#t1082065##k(level limit: 50, thief)"));
			
			if (craftSelect == 0) Craft2(300, "#t1082042#", "#v4011001# 2 #t4011001#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 10 #t4003000#s\r\n22,500 mesos", 30);
			else if (craftSelect == 1) Craft2(301, "#t1082046#", "#v4011001# 3 #t4011001#s\r\n#v4011000# #t4011000#\r\n#v4000021# 60 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n27,000 mesos", 35);
			else if (craftSelect == 2) Craft2(302, "#t1082075#", "#v4021000# 3 #t4021000#s\r\n#v4000101# 100 #t4000101#s\r\n#v4000021# 80 #t4000021#s\r\n#v4003000# 30 #t4003000#s\r\n36,000 mesos", 40);
			else if (craftSelect == 3) Craft2(303, "#t1082065#", "#v4021005# 3 #t4021005#s\r\n#v4021008# #t4021008#\r\n#v4000030# 40 #t4000030#s\r\n#v4003000# 30 #t4003000#s\r\n45,000 mesos", 50);
		}
		else if (craftType == 6)
		{
			int craftSelect = AskMenu("You want to upgrade a common warrior glove? There's no chance of failure since the stimulator will not be used, and the item's stats will be basic. Please choose the item that you want to make~",
				(0, " #b#t1082005##k(level limit: 30, warrior)"),
				(1, " #b#t1082006##k(level limit: 30, warrior)"),
				(2, " #b#t1082035##k(level limit: 35, warrior)"),
				(3, " #b#t1082036##k(level limit: 35, warrior)"),
				(4, " #b#t1082024##k(level limit: 40, warrior)"),
				(5, " #b#t1082025##k(level limit: 40, warrior)"),
				(6, " #b#t1082010##k(level limit: 50, warrior)"),
				(7, " #b#t1082011##k(level limit: 50, warrior)"));
			
			if (craftSelect == 0) Craft3(0, "#t1082005#", "#v1082007# #t1082007#\r\n#v4011001# #t4011001#\r\n18,000 mesos", 30, "STR +1");
			else if (craftSelect == 1) Craft3(1, "#t1082006#", "#v1082007# #t1082007#\r\n#v4011005# 2 #t4011005#s\r\n22,500 mesos", 30, "STR +2");
			else if (craftSelect == 2) Craft3(2, "#t1082035#", "#v1082008# #t1082008#\r\n#v4021006# 3 #t4021006#s\r\n27,000 mesos", 35, "STR +1");
			else if (craftSelect == 3) Craft3(3, "#t1082036#", "#v1082008# #t1082008#\r\n#v4021008# #t4021008#\r\n36,000 mesos", 35, "STR +2");
			else if (craftSelect == 4) Craft3(4, "#t1082024#", "#v1082023# #t1082023#\r\n#v4011003# 4 #t4011003#s\r\n40,500 mesos", 40, "STR +2");
			else if (craftSelect == 5) Craft3(5, "#t1082025#", "#v1082023# #t1082023#\r\n#v4021008# 2 #t4021008#s\r\n45,000 mesos", 40, "STR +3");
			else if (craftSelect == 6) Craft3(6, "#t1082010#", "#v1082009# #t1082009#\r\n#v4011002# 5 #t4011002#s\r\n49,500 mesos", 50, "STR +2, DEX +1");
			else if (craftSelect == 7) Craft3(7, "#t1082011#", "#v1082009# #t1082009#\r\n#v4011006# 4 #t4011006#s\r\n54,000 mesos", 50, "STR +3, Accuracy +1");
		}
		else if (craftType == 7)
		{
			int craftSelect = AskMenu("You want to upgrade a common magician glove? There's no chance of failure since the stimulator will not be used, and the item's stats will be basic. Please choose the item that you want to make~",
				(0, " #b#t1082052##k(level limit: 30, magician)"),
				(1, " #b#t1082053##k(level limit: 30, magician)"),
				(2, " #b#t1082055##k(level limit: 35, magician)"),
				(3, " #b#t1082056##k(level limit: 35, magician)"),
				(4, " #b#t1082063##k(level limit: 40, magician)"),
				(5, " #b#t1082064##k(level limit: 40, magician)"),
				(6, " #b#t1082082##k(level limit: 50, magician)"),
				(7, " #b#t1082080##k(level limit: 50, magician)"));
			
			if (craftSelect == 0) Craft3(100, "#t1082052#", "#v1082051# #t1082051#\r\n#v4021005# 3 #t4021005#s\r\n31,500 mesos", 30, "INT +1");
			else if (craftSelect == 1) Craft3(101, "#t1082053#", "#v1082051# #t1082051#\r\n#v4021008# #t4021008#\r\n36,000 mesos", 30, "INT +2");
			else if (craftSelect == 2) Craft3(102, "#t1082055#", "#v1082054# #t1082054#\r\n#v4021005# 3 #t4021005#s\r\n36,000 mesos", 35, "INT +1");
			else if (craftSelect == 3) Craft3(103, "#t1082056#", "#v1082054# #t1082054#\r\n#v4021008# #t4021008#\r\n40,500 mesos", 35, "INT +2");
			else if (craftSelect == 4) Craft3(104, "#t1082063#", "#v1082062# #t1082062#\r\n#v4021002# 4 #t4021002#s\r\n40,500 mesos", 40, "INT +2");
			else if (craftSelect == 5) Craft3(105, "#t1082064#", "#v1082062# #t1082062#\r\n#v4021008# 2 #t4021008#s\r\n45,000 mesos", 40, "INT +3");
			else if (craftSelect == 6) Craft3(106, "#t1082082#", "#v1082081# #t1082081#\r\n#v4021002# 5 #t4021002#s\r\n49,500 mesos", 50, "INT +2, MP +15");
			else if (craftSelect == 7) Craft3(107, "#t1082080#", "#v1082081# #t1082081#\r\n#v4021008# 3 #t4021008#s\r\n54,000 mesos", 50, "INT +3, MP +30");
		}
		else if (craftType == 8)
		{
			int craftSelect = AskMenu("You want to upgrade a common bowman glove? There's no chance of failure since the stimulator will not be used, and the item's stats will be basic. Please choose the item that you want to make~",
				(0, " #b#t1082049##k(level limit: 30, bowman)"),
				(1, " #b#t1082050##k(level limit: 30, bowman)"),
				(2, " #b#t1082069##k(level limit: 35, bowman)"),
				(3, " #b#t1082070##k(level limit: 35, bowman)"),
				(4, " #b#t1082072##k(level limit: 40, bowman)"),
				(5, " #b#t1082073##k(level limit: 40, bowman)"),
				(6, " #b#t1082085##k(level limit: 50, bowman)"),
				(7, " #b#t1082083##k(level limit: 50, bowman)"));
			
			if (craftSelect == 0) Craft3(200, "#t1082049#", "#v1082048# #t1082048#\r\n#v4021003# 3 #t4021003#s\r\n13,500 mesos", 30, "DEX +1");
			else if (craftSelect == 1) Craft3(201, "#t1082050#", "#v1082048# #t1082048#\r\n#v4021008# #t4021008#\r\n18,000 mesos", 30, "DEX +2");
			else if (craftSelect == 2) Craft3(202, "#t1082069#", "#v1082068# #t1082068#\r\n#v4011002# 4 #t4011002#s\r\n19,800 mesos", 35, "DEX +1");
			else if (craftSelect == 3) Craft3(203, "#t1082070#", "#v1082068# #t1082068#\r\n#v4011006# 2 #t4011006#s\r\n22,500 mesos", 35, "DEX +2");
			else if (craftSelect == 4) Craft3(204, "#t1082072#", "#v1082071# #t1082071#\r\n#v4011006# 4 #t4011006#s\r\n27,000 mesos", 40, "DEX +2");
			else if (craftSelect == 5) Craft3(205, "#t1082073#", "#v1082071# #t1082071#\r\n#v4021008# 2 #t4021008#s\r\n36,000 mesos", 40, "DEX +3");
			else if (craftSelect == 6) Craft3(206, "#t1082085#", "#v1082084# #t1082084#\r\n#v4021000# 5 #t4021000#s\r\n#v4011000# #t4011000#\r\n49,500 mesos", 50, "DEX +2, MP +10");
			else if (craftSelect == 7) Craft3(207, "#t1082083#", "#v1082084# #t1082084#\r\n#v4021008# 2 #t4021008#s\r\n#v4011006# 2 #t4011006#s\r\n54,000 mesos", 50, "DEX +3, MP +20");
		}
		else if (craftType == 9)
		{
			int craftSelect = AskMenu("You want to upgrade a common thief glove? There's no chance of failure since the stimulator will not be used, and the item's stats will be basic. Please choose the item that you want to make~",
				(0, " #b#t1082043##k(level limit: 30, thief)"),
				(1, " #b#t1082044##k(level limit: 30, thief)"),
				(2, " #b#t1082047##k(level limit: 35, thief)"),
				(3, " #b#t1082045##k(level limit: 35, thief)"),
				(4, " #b#t1082076##k(level limit: 40, thief)"),
				(5, " #b#t1082074##k(level limit: 40, thief)"),
				(6, " #b#t1082067##k(level limit: 50, thief)"),
				(7, " #b#t1082066##k(level limit: 50, thief)"));
			
			if (craftSelect == 0) Craft3(300, "#t1082043#", "#v1082042# #t1082042#\r\n#v4011004# 2 #t4011004#s\r\n13,500 mesos", 30, "LUK +1");
			else if (craftSelect == 1) Craft3(301, "#t1082044#", "#v1082042# #t1082042#\r\n#v4011006# #t4011006#\r\n17,000 mesos", 30, "LUK +2");
			else if (craftSelect == 2) Craft3(302, "#t1082047#", "#v1082046# #t1082046#\r\n#v4011005# 3 #t4011005#s\r\n19,800 mesos", 35, "LUK +1");
			else if (craftSelect == 3) Craft3(303, "#t1082045#", "#v1082046# #t1082046#\r\n#v4011006# 2 #t4011006#s\r\n22,500 mesos", 35, "LUK +2");
			else if (craftSelect == 4) Craft3(304, "#t1082076#", "#v1082075# #t1082075#\r\n#v4011006# 4 #t4011006#s\r\n40,500 mesos", 40, "LUK +2");
			else if (craftSelect == 5) Craft3(305, "#t1082074#", "#v1082075# #t1082075#\r\n#v4021008# 2 #t4021008#s\r\n45,000 mesos", 40, "LUK +3");
			else if (craftSelect == 6) Craft3(306, "#t1082067#", "#v1082065# #t1082065#\r\n#v4021000# 5 #t4021000#s\r\n49,500 mesos", 50, "LUK +2, DEX +1");
			else if (craftSelect == 7) Craft3(307, "#t1082066#", "#v1082065# #t1082065#\r\n#v4011006# 2 #t4011006#s\r\n#v4021008# #t4021008#\r\n54,000 mesos", 50, "LUK +3, Avoid. +1");
		}
	}
}