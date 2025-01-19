using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Craft1(int index, string makeItem, string needItem, int reqLevel, string itemOption)
	{
		bool askBuy = AskYesNo($"To make a(n) {makeItem} with the stimulator, you'll need the following items. The Level Limit will be {reqLevel}, and the basic attack level is {itemOption}. If the stimulator is used, the item stats can all be increased, but #bit can also end up worse than it was before, additionally it carries a 10% chance of failure, so please be careful#k. What do you think? Do you want to make it?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("I understand. When you use a stimulator, you run the risk of failing to create the item, and you can still waste the items in the process. I would be careful too, but if you change your mind, feel free.");
			return;
		}
		
		Random rnd = new Random();
		int chance = rnd.Next(1, 11);
		
		bool trade = false;
		// check for mesos first?
		if (chance == 1)
		{
			// Failure to create One-Handed Sword
			if (index == 0) trade = Exchange(0, 4131000, -1, 4130002, -1, 4011001, -2, 4011004, -2, 4003000, -30);
			else if (index == 1) trade = Exchange(0, 4131000, -1, 4130002, -1, 4011006, -1, 4011001, -5, 4021006, -3, 4003000, -35);
			else if (index == 2) trade = Exchange(0, 4131000, -1, 4130002, -1, 4011006, -3, 4021000, -5, 4011001, -5, 4003000, -40);
			else if (index == 3) trade = Exchange(0, 4131000, -1, 4130002, -1, 4005000, -1, 4021008, -2, 4011006, -4, 4021003, -10, 4003000, -50);
			
			// Failure to create One-Handed Axe
			else if (index == 100) trade = Exchange(0, 4131001, -1, 4130003, -1, 4011001, -2, 4021000, -2, 4003000, -30);
			else if (index == 101) trade = Exchange(0, 4131001, -1, 4130003, -1, 4011001, -5, 4021000, -5, 4011004, -3, 4003000, -35);
			else if (index == 102) trade = Exchange(0, 4131001, -1, 4130003, -1, 4021005, -7, 4011001, -5, 4021001, -5, 4003000, -40);
			else if (index == 103) trade = Exchange(0, 4131001, -1, 4130003, -1, 4005000, -1, 4021008, -2, 4011004, -8, 4011001, -10, 4003000, -50);
			
			// Failure to create One-Handed Blunt Weapon
			else if (index == 200) trade = Exchange(0, 4131002, -1, 4130004, -1, 4011001, -2, 4011000, -3, 4003000, -30);
			else if (index == 201) trade = Exchange(0, 4131002, -1, 4130004, -1, 4011001, -5, 4011000, -5, 4011003, -3, 4003000, -35);
			else if (index == 202) trade = Exchange(0, 4131002, -1, 4130004, -1, 4011003, -7, 4011001, -5, 4011004, -5, 4003000, -40);
			else if (index == 203) trade = Exchange(0, 4131002, -1, 4130004, -1, 4005000, -1, 4021008, -2, 4011006, -4, 4011001, -10, 4003000, -50);
			
			// Failure to create Dagger
			else if (index == 300) trade = Exchange(0, 4131012, -1, 4130014, -1, 4011002, -2, 4011001, -3, 4003000, -30);
			else if (index == 301) trade = Exchange(0, 4131012, -1, 4130014, -1, 4021005, -2, 4011001, -3, 4003000, -30);
			else if (index == 302) trade = Exchange(0, 4131012, -1, 4130014, -1, 4021005, -1, 4011001, -5, 4011002, -3, 4003000, -35);
			else if (index == 303) trade = Exchange(0, 4131012, -1, 4130014, -1, 4011001, -7, 4011006, -3, 4021006, -6, 4003000, -40);
			else if (index == 304) trade = Exchange(0, 4131012, -1, 4130014, -1, 4005003, -1, 4021008, -2, 4011004, -7, 4011001, -10, 4003000, -50);
			else if (index == 305) trade = Exchange(0, 4131012, -1, 4130014, -1, 4005003, -1, 4021007, -2, 4011006, -5, 4011001, -10, 4003000, -50);
			
			// Failure to create Wand
			else if (index == 400) trade = Exchange(0, 4131008, -1, 4130010, -1, 4011002, -3, 4021002, -1, 4003000, -10);
			else if (index == 401) trade = Exchange(0, 4131008, -1, 4130010, -1, 4021006, -5, 4011002, -3, 4011001, -1, 4003000, -15);
			else if (index == 402) trade = Exchange(0, 4131008, -1, 4130010, -1, 4021006, -5, 4021005, -5, 4021007, -1, 4003003, -1, 4003000, -20);
			else if (index == 403) trade = Exchange(0, 4131008, -1, 4130010, -1, 4011006, -4, 4021003, -3, 4021007, -3, 4021002, -1, 4003000, -30);
			
			// Failure to create Staff
			else if (index == 500) trade = Exchange(0, 4131009, -1, 4130011, -1, 4021006, -2, 4021001, -1, 4011001, -1, 4003000, -15);
			else if (index == 501) trade = Exchange(0, 4131009, -1, 4130011, -1, 4011001, -8, 4021001, -5, 4021006, -5, 4021005, -5, 4003000, -30);
			else if (index == 502) trade = Exchange(0, 4131009, -1, 4130011, -1, 4005001, -2, 4021008, -2, 4011006, -5, 4011004, -10, 4003000, -40);
			
			// Failure to create Two-Handed Sword
			else if (index == 600) trade = Exchange(0, 4131003, -1, 4130005, -1, 4011001, -2, 4021000, -1, 4021004, -2, 4003000, -35);
			else if (index == 601) trade = Exchange(0, 4131003, -1, 4130005, -1, 4011006, -1, 4011001, -5, 4021004, -5, 4003000, -40);
			else if (index == 602) trade = Exchange(0, 4131003, -1, 4130005, -1, 4021003, -7, 4011000, -5, 4011001, -5, 4003000, -45);
			else if (index == 603) trade = Exchange(0, 4131003, -1, 4130005, -1, 4005000, -1, 4021007, -2, 4011006, -4, 4011001, -10, 4003000, -55);
			
			// Failure to create Two-Handed Axe
			else if (index == 700) trade = Exchange(0, 4131004, -1, 4130006, -1, 4021005, -2, 4011001, -2, 4003001, -5, 4003000, -35);
			else if (index == 701) trade = Exchange(0, 4131004, -1, 4130006, -1, 4011004, -5, 4011000, -5, 4021003, -3, 4003000, -40);
			else if (index == 702) trade = Exchange(0, 4131004, -1, 4130006, -1, 4011006, -3, 4011004, -5, 4011001, -5, 4003000, -45);
			else if (index == 703) trade = Exchange(0, 4131004, -1, 4130006, -1, 4005000, -1, 4021007, -2, 4021006, -7, 4011006, -5, 4003000, -55);
			
			// Failure to create Two-Handed Blunt Weapon
			else if (index == 800) trade = Exchange(0, 4131005, -1, 4130007, -1, 4011001, -2, 4011004, -3, 4003000, -35);
			else if (index == 801) trade = Exchange(0, 4131005, -1, 4130007, -1, 4011001, -5, 4011000, -5, 4003001, -10, 4003000, -40);
			else if (index == 802) trade = Exchange(0, 4131005, -1, 4130007, -1, 4011006, -3, 4011004, -5, 4011001, -5, 4003000, -45);
			else if (index == 803) trade = Exchange(0, 4131005, -1, 4130007, -1, 4005000, -1, 4021008, -2, 4021006, -7, 4011006, -5, 4003000, -55);
			
			// Failure to create Spear
			else if (index == 900) trade = Exchange(0, 4131006, -1, 4130008, -1, 4011000, -2, 4011004, -3, 4003000, -40);
			else if (index == 901) trade = Exchange(0, 4131006, -1, 4130008, -1, 4011001, -5, 4011002, -5, 4021000, -3, 4003000, -45);
			else if (index == 902) trade = Exchange(0, 4131006, -1, 4130008, -1, 4011004, -3, 4011001, -5, 4011000, -5, 4003000, -50);
			else if (index == 903) trade = Exchange(0, 4131006, -1, 4130008, -1, 4005000, -1, 4021008, -2, 4011000, -7, 4021000, -5, 4003000, -60);
			
			// Failure to create Pole-Arm
			else if (index == 1000) trade = Exchange(0, 4131006, -1, 4130009, -1, 4011000, -2, 4011002, -3, 4003000, -40);
			else if (index == 1001) trade = Exchange(0, 4131006, -1, 4130009, -1, 4011001, -5, 4011002, -5, 4011000, -3, 4003000, -45);
			else if (index == 1002) trade = Exchange(0, 4131006, -1, 4130009, -1, 4011006, -3, 4011002, -5, 4011001, -5, 4003000, -50);
			else if (index == 1003) trade = Exchange(0, 4131006, -1, 4130009, -1, 4005000, -1, 4021007, -2, 4011001, -7, 4011002, -5, 4003000, -60);
			
			// Failure to create Bow
			else if (index == 1100) trade = Exchange(0, 4131010, -1, 4130012, -1, 4011001, -5, 4011006, -5, 4021003, -3, 4021006, -3, 4003000, -30);
			else if (index == 1101) trade = Exchange(0, 4131010, -1, 4130012, -1, 4011004, -7, 4021000, -6, 4021004, -3, 4003000, -35);
			else if (index == 1102) trade = Exchange(0, 4131010, -1, 4130012, -1, 4021008, -1, 4011001, -10, 4011006, -3, 4003000, -40, 4000112, -100);
			else if (index == 1103) trade = Exchange(0, 4131010, -1, 4130012, -1, 4005002, -1, 4021008, -2, 4011001, -10, 4021005, -6, 4003000, -50);
			
			// Failure to create Crossbow 
			else if (index == 1200) trade = Exchange(0, 4131011, -1, 4130013, -1, 4011001, -5, 4011005, -5, 4021006, -3, 4003001, -50, 4003000, -15);
			else if (index == 1201) trade = Exchange(0, 4131011, -1, 4130013, -1, 4021008, -1, 4011001, -8, 4011006, -4, 4021006, -2, 4003000, -30);
			else if (index == 1202) trade = Exchange(0, 4131011, -1, 4130013, -1, 4021008, -2, 4011004, -6, 4003001, -30, 4003000, -30);
			else if (index == 1203) trade = Exchange(0, 4131011, -1, 4130013, -1, 4021008, -2, 4011006, -5, 4021006, -3, 4003001, -40, 4003000, -40);
			
			// Failure to create Claw
			else if (index == 1300) trade = Exchange(0, 4130015, -1, 1472008, -1, 4011002, -3);
			else if (index == 1301) trade = Exchange(0, 4130015, -1, 1472008, -1, 4011003, -3);
			else if (index == 1302) trade = Exchange(0, 4130015, -1, 1472011, -1, 4011004, -4);
			else if (index == 1303) trade = Exchange(0, 4130015, -1, 1472011, -1, 4021008, -1);
			else if (index == 1304) trade = Exchange(0, 4130015, -1, 1472014, -1, 4021000, -5);
			else if (index == 1305) trade = Exchange(0, 4130015, -1, 1472014, -1, 4011003, -5);
			else if (index == 1306) trade = Exchange(0, 4130015, -1, 1472014, -1, 4021008, -2);
			else if (index == 1307) trade = Exchange(0, 4130015, -1, 1472018, -1, 4021000, -6);
			else if (index == 1308) trade = Exchange(0, 4130015, -1, 1472018, -1, 4021005, -6);
			else if (index == 1309) trade = Exchange(0, 4130015, -1, 1472018, -1, 4005003, -1, 4021008, -3);
			
			if (!trade)
			{
				self.say("Please check if you have all the necessary items with you. If so, please see if your equip. inventory isn't full.");
				return;
			}
				
			self.say("Oh no... I must have stimulated it too much... All the items are gone now... I'm sorry. I warned you about the possibility of this happening, and I hope that you can understand.");
		}
		else
		{
			// successfully creating One-Handed Sword
			if (index == 0) trade = ExchangeEx(-18000, "4131000", -1, "4130002", -1, "4011001", -2, "4011004", -2, "4003000", -30, "1302008,Variation:1", 1);
			else if (index == 1) trade = ExchangeEx(-35000, "4131000", -1, "4130002", -1, "4011006", -1, "4011001", -5, "4021006", -3, "4003000", -35, "1302004,Variation:1", 1);
			else if (index == 2) trade = ExchangeEx(-70000, "4131000", -1, "4130002", -1, "4011006", -3, "4021000", -5, "4011001", -5, "4003000", -40, "1302009,Variation:1", 1);
			else if (index == 3) trade = ExchangeEx(-200000, "4131000", -1, "4130002", -1, "4005000", -1, "4021008", -2, "4011006", -4, "4021003", -10, "4003000", -50, "1302010,Variation:1", 1);
			
			// successfully creating One-Handed Axe
			else if (index == 100) trade = ExchangeEx(-18000, "4131001", -1, "4130003", -1, "4011001", -2, "4021000", -2, "4003000", -30, "1312005,Variation:1", 1);
			else if (index == 101) trade = ExchangeEx(-35000, "4131001", -1, "4130003", -1, "4011001", -5, "4021000", -5, "4011004", -3, "4003000", -35, "1312006,Variation:1", 1);
			else if (index == 102) trade = ExchangeEx(-70000, "4131001", -1, "4130003", -1, "4021005", -7, "4011001", -5, "4021001", -5, "4003000", -40, "1312007,Variation:1", 1);
			else if (index == 103) trade = ExchangeEx(-200000, "4131001", -1, "4130003", -1, "4005000", -1, "4021008", -2, "4011004", -8, "4011001", -10, "4003000", -50, "1312008,Variation:1", 1);
			
			// successfully creating One-Handed Blunt Weapon
			else if (index == 200) trade = ExchangeEx(-18000, "4131002", -1, "4130004", -1, "4011001", -2, "4011000", -3, "4003000", -30, "1322014,Variation:1", 1);
			else if (index == 201) trade = ExchangeEx(-35000, "4131002", -1, "4130004", -1, "4011001", -5, "4011000", -5, "4011003", -3, "4003000", -35, "1322015,Variation:1", 1);
			else if (index == 202) trade = ExchangeEx(-70000, "4131002", -1, "4130004", -1, "4011003", -7, "4011001", -5, "4011004", -5, "4003000", -40, "1322016,Variation:1", 1);
			else if (index == 203) trade = ExchangeEx(-200000, "4131002", -1, "4130004", -1, "4005000", -1, "4021008", -2, "4011006", -4, "4011001", -10, "4003000", -50, "1322017,Variation:1", 1);
			
			// successfully creating Dagger
			else if (index == 300) trade = ExchangeEx(-20000, "4131012", -1, "4130014", -1, "4011002", -2, "4011001", -3, "4003000", -30, "1332012,Variation:1", 1);
			else if (index == 301) trade = ExchangeEx(-20000, "4131012", -1, "4130014", -1, "4021005", -2, "4011001", -3, "4003000", -30, "1332009,Variation:1", 1);
			else if (index == 302) trade = ExchangeEx(-33000, "4131012", -1, "4130014", -1, "4021005", -1, "4011001", -5, "4011002", -3, "4003000", -35, "1332014,Variation:1", 1);
			else if (index == 303) trade = ExchangeEx(-73000, "4131012", -1, "4130014", -1, "4011001", -7, "4011006", -3, "4021006", -6, "4003000", -40, "1332011,Variation:1", 1);
			else if (index == 304) trade = ExchangeEx(-230000, "4131012", -1, "4130014", -1, "4005003", -1, "4021008", -2, "4011004", -7, "4011001", -10, "4003000", -50, "1332016,Variation:1", 1);
			else if (index == 305) trade = ExchangeEx(-230000, "4131012", -1, "4130014", -1, "4005003", -1, "4021007", -2, "4011006", -5, "4011001", -10, "4003000", -50, "1332003,Variation:1", 1);
			
			// successfully creating Wand
			else if (index == 400) trade = ExchangeEx(-15000, "4131008", -1, "4130010", -1, "4011002", -3, "4021002", -1, "4003000", -10, "1372003,Variation:1", 1);
			else if (index == 401) trade = ExchangeEx(-30000, "4131008", -1, "4130010", -1, "4021006", -5, "4011002", -3, "4011001", -1, "4003000", -15, "1372001,Variation:1", 1);
			else if (index == 402) trade = ExchangeEx(-60000, "4131008", -1, "4130010", -1, "4021006", -5, "4021005", -5, "4021007", -1, "4003003", -1, "4003000", -20, "1372000,Variation:1", 1);
			else if (index == 403) trade = ExchangeEx(-100000, "4131008", -1, "4130010", -1, "4011006", -4, "4021003", -3, "4021007", -3, "4021002", -1, "4003000", -30, "1372007,Variation:1", 1);
			
			// successfully creating Staff
			else if (index == 500) trade = ExchangeEx(-10000, "4131009", -1, "4130011", -1, "4021006", -2, "4021001", -1, "4011001", -1, "4003000", -15, "1382002,Variation:1", 1);
			else if (index == 501) trade = ExchangeEx(-80000, "4131009", -1, "4130011", -1, "4011001", -8, "4021001", -5, "4021006", -5, "4021005", -5, "4003000", -30, "1382001,Variation:1", 1);
			else if (index == 502) trade = ExchangeEx(-200000, "4131009", -1, "4130011", -1, "4005001", -2, "4021008", -2, "4011006", -5, "4011004", -10, "4003000", -40, "1382006,Variation:1", 1);
			
			// successfully creating Two-Handed Sword
			else if (index == 600) trade = ExchangeEx(-20000, "4131003", -1, "4130005", -1, "4011001", -2, "4021000", -1, "4021004", -2, "4003000", -35, "1402002,Variation:1", 1);
			else if (index == 601) trade = ExchangeEx(-37000, "4131003", -1, "4130005", -1, "4011006", -1, "4011001", -5, "4021004", -5, "4003000", -40, "1402006,Variation:1", 1);
			else if (index == 602) trade = ExchangeEx(-72000, "4131003", -1, "4130005", -1, "4021003", -7, "4011000", -5, "4011001", -5, "4003000", -45, "1402007,Variation:1", 1);
			else if (index == 603) trade = ExchangeEx(-220000, "4131003", -1, "4130005", -1, "4005000", -1, "4021007", -2, "4011006", -4, "4011001", -10, "4003000", -55, "1402003,Variation:1", 1);
			
			// successfully creating Two-Handed Axe
			else if (index == 700) trade = ExchangeEx(-20000, "4131004", -1, "4130006", -1, "4021005", -2, "4011001", -2, "4003001", -5, "4003000", -35, "1412006,Variation:1", 1);
			else if (index == 701) trade = ExchangeEx(-37000, "4131004", -1, "4130006", -1, "4011004", -5, "4011000", -5, "4021003", -3, "4003000", -40, "1412004,Variation:1", 1);
			else if (index == 702) trade = ExchangeEx(-72000, "4131004", -1, "4130006", -1, "4011006", -3, "4011004", -5, "4011001", -5, "4003000", -45, "1412005,Variation:1", 1);
			else if (index == 703) trade = ExchangeEx(-220000, "4131004", -1, "4130006", -1, "4005000", -1, "4021007", -2, "4021006", -7, "4011006", -5, "4003000", -55, "1412003,Variation:1", 1);
			
			// successfully creating Two-Handed Blunt Weapon
			else if (index == 800) trade = ExchangeEx(-20000, "4131005", -1, "4130007", -1, "4011001", -2, "4011004", -3, "4003000", -35, "1422001,Variation:1", 1);
			else if (index == 801) trade = ExchangeEx(-37000, "4131005", -1, "4130007", -1, "4011001", -5, "4011000", -5, "4003001", -10, "4003000", -40, "1422008,Variation:1", 1);
			else if (index == 802) trade = ExchangeEx(-72000, "4131005", -1, "4130007", -1, "4011006", -3, "4011004", -5, "4011001", -5, "4003000", -45, "1422007,Variation:1", 1);
			else if (index == 803) trade = ExchangeEx(-220000, "4131005", -1, "4130007", -1, "4005000", -1, "4021008", -2, "4021006", -7, "4011006", -5, "4003000", -55, "1422005,Variation:1", 1);
			
			// successfully creating Spear 
			else if (index == 900) trade = ExchangeEx(-22000, "4131006", -1, "4130008", -1, "4011000", -2, "4011004", -3, "4003000", -40, "1432002,Variation:1", 1);
			else if (index == 901) trade = ExchangeEx(-39000, "4131006", -1, "4130008", -1, "4011001", -5, "4011002", -5, "4021000", -3, "4003000", -45, "1432003,Variation:1", 1);
			else if (index == 902) trade = ExchangeEx(-74000, "4131006", -1, "4130008", -1, "4011004", -3, "4011001", -5, "4011000", -5, "4003000", -50, "1432005,Variation:1", 1);
			else if (index == 903) trade = ExchangeEx(-240000, "4131006", -1, "4130008", -1, "4005000", -1, "4021008", -2, "4011000", -7, "4021000", -5, "4003000", -60, "1432004,Variation:1", 1);
			
			// successfully creating Pole-Arm 
			else if (index == 1000) trade = ExchangeEx(-22000, "4131007", -1, "4130009", -1, "4011000", -2, "4011002", -3, "4003000", -40, "1442001,Variation:1", 1);
			else if (index == 1001) trade = ExchangeEx(-39000, "4131007", -1, "4130009", -1, "4011001", -5, "4011002", -5, "4011000", -3, "4003000", -45, "1442003,Variation:1", 1);
			else if (index == 1002) trade = ExchangeEx(-74000, "4131007", -1, "4130009", -1, "4011006", -3, "4011002", -5, "4011001", -5, "4003000", -50, "1442009,Variation:1", 1);
			else if (index == 1003) trade = ExchangeEx(-240000, "4131007", -1, "4130009", -1, "4005000", -1, "4021007", -2, "4011001", -7, "4011002", -5, "4003000", -60, "1442005,Variation:1", 1);
			
			// successfully creating Bow
			else if (index == 1100) trade = ExchangeEx(-15000, "4131010", -1, "4130012", -1, "4011001", -5, "4011006", -5, "4021003", -3, "4021006", -3, "4003000", -30, "1452005,Variation:1", 1);
			else if (index == 1101) trade = ExchangeEx(-20000, "4131010", -1, "4130012", -1, "4011004", -7, "4021000", -6, "4021004", -3, "4003000", -35, "1452006,Variation:1", 1);
			else if (index == 1102) trade = ExchangeEx(-40000, "4131010", -1, "4130012", -1, "4021008", -1, "4011001", -10, "4011006", -3, "4003000", -40, "4000112", -100, "1452007,Variation:1", 1);
			else if (index == 1103) trade = ExchangeEx(-100000, "4131010", -1, "4130012", -1, "4005002", -1, "4021008", -2, "4011001", -10, "4021005", -6, "4003000", -50, "1452008,Variation:1", 1);
			
			// successfully creating Crossbow
			else if (index == 1200) trade = ExchangeEx(-15000, "4131011", -1, "4130013", -1, "4011001", -5, "4011005", -5, "4021006", -3, "4003001", -50, "4003000", -15, "1462004,Variation:1", 1);
			else if (index == 1201) trade = ExchangeEx(-25000, "4131011", -1, "4130013", -1, "4021008", -1, "4011001", -8, "4011006", -4, "4021006", -2, "4003000", -30, "1462005,Variation:1", 1);
			else if (index == 1202) trade = ExchangeEx(-41000, "4131011", -1, "4130013", -1, "4021008", -2, "4011004", -6, "4003001", -30, "4003000", -30, "1462006,Variation:1", 1);
			else if (index == 1203) trade = ExchangeEx(-100000, "4131011", -1, "4130013", -1, "4021008", -2, "4011006", -5, "4021006", -3, "4003001", -40, "4003000", -40, "1462007,Variation:1", 1);
			
			// successfully creating Claw
			else if (index == 1300) trade = ExchangeEx(-10000, "4130015", -1, "1472008", -1, "4011002", -3, "1472009,Variation:1", 1);
			else if (index == 1301) trade = ExchangeEx(-15000, "4130015", -1, "1472008", -1, "4011003", -3, "1472010,Variation:1", 1);
			else if (index == 1302) trade = ExchangeEx(-20000, "4130015", -1, "1472011", -1, "4011004", -4, "1472012,Variation:1", 1);
			else if (index == 1303) trade = ExchangeEx(-25000, "4130015", -1, "1472011", -1, "4021008", -1, "1472013,Variation:1", 1);
			else if (index == 1304) trade = ExchangeEx(-30000, "4130015", -1, "1472014", -1, "4021000", -5, "1472015,Variation:1", 1);
			else if (index == 1305) trade = ExchangeEx(-30000, "4130015", -1, "1472014", -1, "4011003", -5, "1472016,Variation:1", 1);
			else if (index == 1306) trade = ExchangeEx(-35000, "4130015", -1, "1472014", -1, "4021008", -2, "1472017,Variation:1", 1);
			else if (index == 1307) trade = ExchangeEx(-40000, "4130015", -1, "1472018", -1, "4021000", -6, "1472019,Variation:1", 1);
			else if (index == 1308) trade = ExchangeEx(-40000, "4130015", -1, "1472018", -1, "4021005", -6, "1472020,Variation:1", 1);
			else if (index == 1309) trade = ExchangeEx(-50000, "4130015", -1, "1472018", -1, "4005003", -1, "4021008", -3, "1472021,Variation:1", 1);
			
			if (!trade)
			{
				self.say("Please check if you have all the necessary items with you. If so, please see if your equip. inventory isn't full.");
				return;
			}
				
			self.say($"Here, take this, the {makeItem}! Everything worked out, and it's much more powerful than a normal weapon. I hope to see you again!");
		}
	}
	
	private void Craft2(int index, string makeItem, string needItem, int reqLevel, string itemOption)
	{
		bool askBuy = AskYesNo($"To make a(n) {makeItem}, you will need the following materials. The Level Limit will be {reqLevel}, and the basic stats of the item is {itemOption}, so please see if you really need it. So, do you want me to do it?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("Don't have the materials? Alright. I'll stay here waiting for you, continue collecting the materials, and come back and talk to me.");
			return;
		}
		
		bool trade = false;
		
		// creating a One-Handed Sword
		if (index == 0) trade = Exchange(-18000, 4131000, -1, 4011001, -2, 4011004, -2, 4003000, -30, 1302008, 1);
		else if (index == 1) trade = Exchange(-35000, 4131000, -1, 4011006, -1, 4011001, -5, 4021006, -3, 4003000, -35, 1302004, 1);
		else if (index == 2) trade = Exchange(-70000, 4131000, -1, 4011006, -3, 4021000, -5, 4011001, -5, 4003000, -40, 1302009, 1);
		else if (index == 3) trade = Exchange(-200000, 4131000, -1, 4005000, -1, 4021008, -2, 4011006, -4, 4021003, -10, 4003000, -50, 1302010, 1);
		
		// creating a One-Handed Axe
		else if (index == 100) trade = Exchange(-18000, 4131001, -1, 4011001, -2, 4021000, -2, 4003000, -30, 1312005, 1);
		else if (index == 101) trade = Exchange(-35000, 4131001, -1, 4011001, -5, 4021000, -5, 4011004, -3, 4003000, -35, 1312006, 1);
		else if (index == 102) trade = Exchange(-70000, 4131001, -1, 4021005, -7, 4011001, -5, 4021001, -5, 4003000, -40, 1312007, 1);
		else if (index == 103) trade = Exchange(-200000, 4131001, -1, 4005000, -1, 4021008, -2, 4011004, -8, 4011001, -10, 4003000, -50, 1312008, 1);
		
		// creating a One-Handed Blunt Weapon 
		else if (index == 200) trade = Exchange(-18000, 4131002, -1, 4011001, -2, 4011000, -3, 4003000, -30, 1322014, 1);
		else if (index == 201) trade = Exchange(-35000, 4131002, -1, 4011001, -5, 4011000, -5, 4011003, -3, 4003000, -35, 1322015, 1);
		else if (index == 202) trade = Exchange(-70000, 4131002, -1, 4011003, -7, 4011001, -5, 4011004, -5, 4003000, -40, 1322016, 1);
		else if (index == 203) trade = Exchange(-200000, 4131002, -1, 4005000, -1, 4021008, -2, 4011006, -4, 4011001, -10, 4003000, -50, 1322017, 1);
		
		// creating a Dagger
		else if (index == 300) trade = Exchange(-20000, 4131012, -1, 4011002, -2, 4011001, -3, 4003000, -30, 1332012, 1);
		else if (index == 301) trade = Exchange(-20000, 4131012, -1, 4021005, -2, 4011001, -3, 4003000, -30, 1332009, 1);
		else if (index == 302) trade = Exchange(-33000, 4131012, -1, 4021005, -1, 4011001, -5, 4011002, -3, 4003000, -35, 1332014, 1);
		else if (index == 303) trade = Exchange(-73000, 4131012, -1, 4011001, -7, 4011006, -3, 4021006, -6, 4003000, -40, 1332011, 1);
		else if (index == 304) trade = Exchange(-230000, 4131012, -1, 4005003, -1, 4021008, -2, 4011004, -7, 4011001, -10, 4003000, -50, 1332016, 1);
		else if (index == 305) trade = Exchange(-230000, 4131012, -1, 4005003, -1, 4021007, -2, 4011006, -5, 4011001, -10, 4003000, -50, 1332003, 1);
		
		// creating a Wand 
		else if (index == 400) trade = Exchange(-15000, 4131008, -1, 4011002, -3, 4021002, -1, 4003000, -10, 1372003, 1);
		else if (index == 401) trade = Exchange(-30000, 4131008, -1, 4021006, -5, 4011002, -3, 4011001, -1, 4003000, -15, 1372001, 1);
		else if (index == 402) trade = Exchange(-60000, 4131008, -1, 4021006, -5, 4021005, -5, 4021007, -1, 4003003, -1, 4003000, -20, 1372000, 1);
		else if (index == 403) trade = Exchange(-100000, 4131008, -1, 4011006, -4, 4021003, -3, 4021007, -3, 4021002, -1, 4003000, -30, 1372007, 1);
		
		// creating a Staff
		else if (index == 500) trade = Exchange(-10000, 4131009, -1, 4021006, -2, 4021001, -1, 4011001, -1, 4003000, -15, 1382002, 1);
		else if (index == 501) trade = Exchange(-80000, 4131009, -1, 4011001, -8, 4021001, -5, 4021006, -5, 4021005, -5, 4003000, -30, 1382001, 1);
		else if (index == 502) trade = Exchange(-200000, 4131009, -1, 4005001, -2, 4021008, -2, 4011006, -5, 4011004, -10, 4003000, -40, 1382006, 1);
		
		// creating a Two-Handed Sword 
		else if (index == 600) trade = Exchange(-20000, 4131003, -1, 4011001, -2, 4021000, -1, 4021004, -2, 4003000, -35, 1402002, 1);
		else if (index == 601) trade = Exchange(-37000, 4131003, -1, 4011006, -1, 4011001, -5, 4021004, -5, 4003000, -40, 1402006, 1);
		else if (index == 602) trade = Exchange(-72000, 4131003, -1, 4021003, -7, 4011000, -5, 4011001, -5, 4003000, -45, 1402007, 1);
		else if (index == 603) trade = Exchange(-220000, 4131003, -1, 4005000, -1, 4021007, -2, 4011006, -4, 4011001, -10, 4003000, -55, 1402003, 1);
		
		// creating a Two-Handed Axe
		else if (index == 700) trade = Exchange(-20000, 4131004, -1, 4021005, -2, 4011001, -2, 4003001, -5, 4003000, -35, 1412006, 1);
		else if (index == 701) trade = Exchange(-37000, 4131004, -1, 4011004, -5, 4011000, -5, 4021003, -3, 4003000, -40, 1412004, 1);
		else if (index == 702) trade = Exchange(-72000, 4131004, -1, 4011006, -3, 4011004, -5, 4011001, -5, 4003000, -45, 1412005, 1);
		else if (index == 703) trade = Exchange(-220000, 4131004, -1, 4005000, -1, 4021007, -2, 4021006, -7, 4011006, -5, 4003000, -55, 1412003, 1);
		
		// creating a Two-Handed Blunt Weapon 
		else if (index == 800) trade = Exchange(-20000, 4131005, -1, 4011001, -2, 4011004, -3, 4003000, -35, 1422001, 1);
		else if (index == 801) trade = Exchange(-37000, 4131005, -1, 4011001, -5, 4011000, -5, 4003001, -10, 4003000, -40, 1422008, 1);
		else if (index == 802) trade = Exchange(-72000, 4131005, -1, 4011006, -3, 4011004, -5, 4011001, -5, 4003000, -45, 1422007, 1);
		else if (index == 803) trade = Exchange(-220000, 4131005, -1, 4005000, -1, 4021008, -2, 4021006, -7, 4011006, -5, 4003000, -55, 1422005, 1);
		
		// creating a Spear 
		else if (index == 900) trade = Exchange(-22000, 4131006, -1, 4011000, -2, 4011004, -3, 4003000, -40, 1432002, 1);
		else if (index == 901) trade = Exchange(-39000, 4131006, -1, 4011001, -5, 4011002, -5, 4021000, -3, 4003000, -45, 1432003, 1);
		else if (index == 902) trade = Exchange(-74000, 4131006, -1, 4011004, -3, 4011001, -5, 4011000, -5, 4003000, -50, 1432005, 1);
		else if (index == 903) trade = Exchange(-240000, 4131006, -1, 4005000, -1, 4021008, -2, 4011000, -7, 4021000, -5, 4003000, -60, 1432004, 1);
		
		// creating a Pole-Arm
		else if (index == 1000) trade = Exchange(-22000, 4131007, -1, 4011000, -2, 4011002, -3, 4003000, -40, 1442001, 1);
		else if (index == 1001) trade = Exchange(-39000, 4131007, -1, 4011001, -5, 4011002, -5, 4011000, -3, 4003000, -45, 1442003, 1);
		else if (index == 1002) trade = Exchange(-74000, 4131007, -1, 4011006, -3, 4011002, -5, 4011001, -5, 4003000, -50, 1442009, 1);
		else if (index == 1003) trade = Exchange(-240000, 4131007, -1, 4005000, -1, 4021007, -2, 4011001, -7, 4011002, -5, 4003000, -60, 1442005, 1);
		
		// creating a Bow
		else if (index == 1100) trade = Exchange(-15000, 4131010, -1, 4011001, -5, 4011006, -5, 4021003, -3, 4021006, -3, 4003000, -30, 1452005, 1);
		else if (index == 1101) trade = Exchange(-20000, 4131010, -1, 4011004, -7, 4021000, -6, 4021004, -3, 4003000, -35, 1452006, 1);
		else if (index == 1102) trade = Exchange(-40000, 4131010, -1, 4021008, -1, 4011001, -10, 4011006, -3, 4003000, -40, 4000112, -100, 1452007, 1);
		else if (index == 1103) trade = Exchange(-100000, 4131010, -1, 4005002, -1, 4021008, -2, 4011001, -10, 4021005, -6, 4003000, -50, 1452008, 1);
		
		// creating a Crossbow
		else if (index == 1200) trade = Exchange(-15000, 4131011, -1, 4011001, -5, 4011005, -5, 4021006, -3, 4003001, -50, 4003000, -15, 1462004, 1);
		else if (index == 1201) trade = Exchange(-25000, 4131011, -1, 4021008, -1, 4011001, -8, 4011006, -4, 4021006, -2, 4003000, -30, 1462005, 1);
		else if (index == 1202) trade = Exchange(-41000, 4131011, -1, 4021008, -2, 4011004, -6, 4003001, -30, 4003000, -30, 1462006, 1);
		else if (index == 1203) trade = Exchange(-100000, 4131011, -1, 4021008, -2, 4011006, -5, 4021006, -3, 4003001, -40, 4003000, -40, 1462007, 1);
		
		// creating a Claw 
		else if (index == 1300) trade = Exchange(-15000, 4131013, -1, 4011000, -3, 4011001, -2, 4000021, -50, 4003000, -20, 1472008, 1);
		else if (index == 1301) trade = Exchange(-30000, 4131013, -1, 4011000, -4, 4011001, -3, 4000021, -80, 4003000, -25, 1472011, 1);
		else if (index == 1302) trade = Exchange(-40000, 4131013, -1, 4011000, -3, 4011001, -4, 4000021, -100, 4003000, -30, 1472014, 1);
		else if (index == 1303) trade = Exchange(-50000, 4131013, -1, 4011000, -4, 4011001, -5, 4000030, -40, 4003000, -35, 1472018, 1);
		
		if (!trade)
		{
			self.say("Please check if you have all the necessary items with you. If so, please see if your equip. inventory isn't full.");
			return;
		}
			
		self.say($"Here, take the {makeItem}! I just finished it, so it needs to be handled with care. I hope to see you again!");
	}
	
	public override void Run()
	{
		bool askStart = AskYesNo("Man! That's hard! Hmm? Welcome! Are you looking for someone to make a weapon for you? If so, you've come to the perfect place. Want to take a look?");
		
		if (!askStart)
		{
			self.say("I'm a weapon smith like few have seen here. And not only that, but if you happen to have a stimulator, I can create a special weapon with it. Come back and talk to me if you ever change your mind.");
			return;
		}
		
		int craftType = AskMenu("Alright! Just keep in mind that the weapon can't be made without an item called a #bforging manual#k. So, what would you like to make?#b",
			(0, " What is a stimulator?"),
			(1, " What is a forging manual?"),
			(2, " Create a one-handed weapon with a stimulator"),
			(3, " Create a two-handed weapon with a stimulator\r\n"),
			(4, " Create a common one-handed weapon"),
			(5, " Create a common two-handed weapon"));
		
		if (craftType == 0)
		{
			self.say("You must be curious about the #rstimulator#k#k. It's a mysterious potion that is included in the creation process of a weapon, and, after being used, the weapon will be created with a small variation in stats, as if you had received the weapon from a monster. The stimulator can then be used not only on weapons, but also on other items. Make sure to carry lots of them with you, because there are different types of stimulators available for different types of weapons.");
			self.say("But you should be aware of some things. If the stimulator is used, it's very likely that the item's stats will be altered, and the problem with that is the result can #bend up being worse#k, much worse than the original. You also run the risk of a \r\n#b10% rate of failure when creating the item#k, which means that you will lose the items that you used to make the item in question. Pretty dangerous, isn't it?");
			self.say("Even with these risks involved, many travelers seek my help to make the perfect weapon using the stimulator. The thought of the item being of poor quality, becoming worse than it was, or even disappearing may scare you, but how about trying it anyway? If you're lucky, your item could be a marvel. That's all I can tell you.");
		}
		else if (craftType == 1)
		{
			self.say("You must be curious about the #rforging manual#k. Unlike shoes and gloves, to make a weapon, you must have a forging manual for the respective weapon. Like, for example, a forging manual for One-Handed Swords and forging manual for Spears. Forging manuals are available for all the weapon types, but I really don't know how to collect them all. You may find some from the monsters around Ludibrium.");
			self.say("And the forging manual can be used together with the stimulator. For example, if you want to make a One-Handed Sword with the stats altered, you'll need the #bstimulator for One-Handed Sword#k and #bthe One-Handed Sword forging manual#k in addition to the materials needed to create the weapon. What do you think? It's much more simple than you think. That's all I can tell you.");
		}
		else if (craftType == 2)
		{
			int craftType2 = AskMenu("What kind of weapon do you want to create?#b",
				(0, " One-Handed Sword"),
				(1, " One-Handed Axe"),
				(2, " One-Handed Mace"),
				(3, " Dagger"),
				(4, " Wand"),
				(5, " Staff"));
				
			if (craftType2 == 0)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a One-Handed Sword? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1302008#"),
					(1, " #t1302004#"),
					(2, " #t1302009#"),
					(3, " #t1302010#"));
					
				if (craftSelect == 0) Craft1(0, "#t1302008#", "#v4131000# #t4131000#\r\n#v4130002# #t4130002#\r\n#v4011001# 2 #t4011001#s\r\n#v4011004# 2 #t4011004#s\r\n#v4003000# 30 #t4003000#s\r\n18,000 mesos", 30, "Attack 47");
				else if (craftSelect == 1) Craft1(1, "#t1302004#", "#v4131000# #t4131000#\r\n#v4130002# #t4130002#\r\n#v4011006# #t4011006#\r\n#v4011001# 5 #t4011001#s\r\n#v4021006# 3 #t4021006#s\r\n#v4003000# 35 #t4003000#s\r\n35,000 mesos", 35, "Attack 52");
				else if (craftSelect == 2) Craft1(2, "#t1302009#", "#v4131000# #t4131000#\r\n#v4130002# #t4130002#\r\n#v4011006# 3 #t4011006#s\r\n#v4011001# 5 #t4011001#s\r\n#v4021000# 5 #t4021000#s\r\n#v4003000# 40 #t4003000#s\r\n70,000 mesos", 40, "Attack 57");
				else if (craftSelect == 3) Craft1(3, "#t1302010#", "#v4131000# #t4131000#\r\n#v4130002# #t4130002#\r\n#v4005000# #t4005000#\r\n#v4021008# 2 #t4021008#s\r\n#v4011006# 4 #t4011006#s\r\n#v4021003# 10 #t4021003#s\r\n#v4003000# 50 #t4003000#s\r\n200,000 mesos", 50, "Attack 67");
			}
			else if (craftType2 == 1)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create the One-Handed Axe? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1312005#"),
					(1, " #t1312006#"),
					(2, " #t1312007#"),
					(3, " #t1312008#"));
				
				if (craftSelect == 0) Craft1(100, "#t1312005#", "#v4130003# #t4130003#\r\n#v4131001# #t4131001#\r\n#v4011001# 2 #t4011001#s\r\n#v4021000# 2 #t4021000#s\r\n#v4003000# 30 #t4003000#s\r\n18,000 mesos", 30, "Attack 47");
				else if (craftSelect == 1) Craft1(101, "#t1312006#", "#v4130003# #t4130003#\r\n#v4131001# #t4131001#\r\n#v4011001# 5 #t4011001#s\r\n#v4021000# 5 #t4021000#s\r\n#v4011004# 3 #t4011004#s\r\n#v4003000# 35 #t4003000#s\r\n35,000 mesos", 35, "Attack 52");
				else if (craftSelect == 2) Craft1(102, "#t1312007#", "#v4130003# #t4130003#\r\n#v4131001# #t4131001#\r\n#v4021005# 7 #t4021005#s\r\n#v4011001# 5 #t4011001#s\r\n#v4021001# 5 #t4021001#s\r\n#v4003000# 40 #t4003000#s\r\n70,000 mesos", 40, "Attack 57");
				else if (craftSelect == 3) Craft1(103, "#t1312008#", "#v4130003# #t4130003#\r\n#v4131001# #t4131001#\r\n#v4005000# #t4005000#\r\n#v4021008# 2 #t4021008#s\r\n#v4011004# 8 #t4011004#s\r\n#v4011001# 10 #t4011001#s\r\n#v4003000# 50 #t4003000#s\r\n200,000 mesos", 50, "Attack 67");
			}
			else if (craftType2 == 2)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a One-Handed Mace? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1322014#"),
					(1, " #t1322015#"),
					(2, " #t1322016#"),
					(3, " #t1322017#"));
					
				if (craftSelect == 0) Craft1(200, "#t1322014#", "#v4130004# #t4130004#\r\n#v4131002# #t4131002#\r\n#v4011001# 2 #t4011001#s\r\n#v4011000# 3 #t4011000#s\r\n#v4003000# 30 #t4003000#s\r\n18,000 mesos", 30, "Attack 49");
				else if (craftSelect == 1) Craft1(201, "#t1322015#", "#v4130004# #t4130004#\r\n#v4131002# #t4131002#\r\n#v4011001# 5 #t4011001#s\r\n#v4011000# 5 #t4011000#s\r\n#v4011003# 3 #t4011003#s\r\n#v4003000# 35 #t4003000#s\r\n35,000 mesos", 35, "Attack 54");
				else if (craftSelect == 2) Craft1(202, "#t1322016#", "#v4130004# #t4130004#\r\n#v4131002# #t4131002#\r\n#v4011003# 7 #t4011003#s\r\n#v4011001# 5 #t4011001#s\r\n#v4011004# 5 #t4011004#s\r\n#v4003000# 40 #t4003000#s\r\n70,000 mesos", 40, "Attack 59");
				else if (craftSelect == 3) Craft1(203, "#t1322017#", "#v4130004# #t4130004#\r\n#v4131002# #t4131002#\r\n#v4005000# #t4005000#\r\n#v4021008# 2 #t4021008#s\r\n#v4011006# 4 #t4011006#s\r\n#v4011001# 10 #t4011001#s\r\n#v4003000# 50 #t4003000#s\r\n200,000 mesos", 50, "Attack 69");
			}
			else if (craftType2 == 3)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a Dagger? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon would you like to create?#b",
					(0, " #t1332012#"),
					(1, " #t1332009#"),
					(2, " #t1332014#"),
					(3, " #t1332011#"),
					(4, " #t1332016#"),
					(5, " #t1332003#"));
				
				if (craftSelect == 0) Craft1(300, "#t1332012#", "#v4130014# #t4130014#\r\n#v4131012# #t4131012#\r\n#v4011002# 2 #t4011002#s\r\n#v4011001# 3 #t4011001#s\r\n#v4003000# 30 #t4003000#s\r\n20,000 mesos", 30, "Attack 45");
				else if (craftSelect == 1) Craft1(301, "#t1332009#", "#v4130014# #t4130014#\r\n#v4131012# #t4131012#\r\n#v4021005# 2 #t4021005#s\r\n#v4011001# 3 #t4011001#s\r\n#v4003000# 30 #t4003000#s\r\n20,000 mesos", 30, "Attack 45");
				else if (craftSelect == 2) Craft1(302, "#t1332014#", "#v4130014# #t4130014#\r\n#v4131012# #t4131012#\r\n#v4021005# #t4021005#\r\n#v4011001# 5 #t4011001#s\r\n#v4011002# 3 #t4011002#s\r\n#v4003000# 35 #t4003000#s\r\n33,000 mesos", 35, "Attack 50");
				else if (craftSelect == 3) Craft1(303, "#t1332011#", "#v4130014# #t4130014#\r\n#v4131012# #t4131012#\r\n#v4011001# 7 #t4011001#s\r\n#v4011006# 3 #t4011006#s\r\n#v4021006# 6 #t4021006#s\r\n#v4003000# 40 #t4003000#s\r\n73,000 mesos", 40, "Attack 55");
				else if (craftSelect == 4) Craft1(304, "#t1332016#", "#v4130014# #t4130014#\r\n#v4131012# #t4131012#\r\n#v4005003# #t4005003#\r\n#v4021008# 2 #t4021008#s\r\n#v4011004# 7 #t4011004#s\r\n#v4011001# 10 #t4011001#s\r\n#v4003000# 50 #t4003000#s\r\n230,000 mesos", 50, "Attack 65");
				else if (craftSelect == 5) Craft1(305, "#t1332003#", "#v4130014# #t4130014#\r\n#v4131012# #t4131012#\r\n#v4005003# #t4005003#\r\n#v4021007# 2 #t4021007#s\r\n#v4011006# 5 #t4011006#s\r\n#v4011001# 10 #t4011001#s\r\n#v4003000# 50 #t4003000#s\r\n230,000 mesos", 50, "Attack 62");
			}
			else if (craftType2 == 4)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a Wand? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1372003#"),
					(1, " #t1372001#"),
					(2, " #t1372000#"),
					(3, " #t1372007#"));
				
				if (craftSelect == 0) Craft1(400, "#t1372003#", "#v4130010# #t4130010#\r\n#v4131008# #t4131008#\r\n#v4011002# 3 #t4011002#s\r\n#v4021002# #t4021002#\r\n#v4003000# 10 #t4003000#s\r\n15,000 mesos", 28, "Magic Attack 43");
				else if (craftSelect == 1) Craft1(401, "#t1372001#", "#v4130010# #t4130010#\r\n#v4131008# #t4131008#\r\n#v4021006# 5 #t4021006#s\r\n#v4011002# 3 #t4011002#s\r\n#v4011001# #t4011001#\r\n#v4003000# 15 #t4003000#s\r\n30,000 mesos", 33, "Magic Attack 48");
				else if (craftSelect == 2) Craft1(402, "#t1372000#", "#v4130010# #t4130010#\r\n#v4131008# #t4131008#\r\n#v4021006# 5 #t4021006#s\r\n#v4021005# 5 #t4021005#s\r\n#v4021007# #t4021007#\r\n#v4003003# #t4003003#\r\n#v4003000# 20 #t4003000#s\r\n60,000 mesos", 38, "Magic Attack 53");
				else if (craftSelect == 3) Craft1(403, "#t1372007#", "#v4130010# #t4130010#\r\n#v4131008# #t4131008#\r\n#v4011006# 4 #t4011006#s\r\n#v4021003# 3 #t4021003#s\r\n#v4021007# 3 #t4021007#s\r\n#v4021002# #t4021002#\r\n#v4003000# 30 #t4003000#s\r\n100,000 mesos", 48, "Magic Attack 63");
			}
			else if (craftType2 == 5)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a Staff? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1382002#"),
					(1, " #t1382001#"),
					(2, " #t1382006#"));
					
				if (craftSelect == 0) Craft1(500, "#t1382002#", "#v4130011# #t4130011#\r\n#v4131009# #t4131009#\r\n#v4021006# 2 #t4021006#s\r\n#v4021001# #t4021001#\r\n#v4011001# #t4011001#\r\n#v4003000# 15 #t4003000#s\r\n10,000 mesos", 25, "Magic Attack 40");
				else if (craftSelect == 1) Craft1(501, "#t1382001#", "#v4130011# #t4130011#\r\n#v4131009# #t4131009#\r\n#v4011001# 8 #t4011001#s\r\n#v4021001# 5 #t4021001#s\r\n#v4021006# 5 #t4021006#s\r\n#v4021005# 5 #t4021005#s\r\n#v4003000# 30 #t4003000#s\r\n80,000 mesos", 45, "Magic Attack 60");
				else if (craftSelect == 2) Craft1(502, "#t1382006#", "#v4130011# #t4130011#\r\n#v4131009# #t4131009#\r\n#v4005001# 2 #t4005001#s\r\n#v4021008# 2 #t4021008#s\r\n#v4011006# 5 #t4011006#s\r\n#v4011004# 10 #t4011004#s\r\n#v4003000# 40 #t4003000#s\r\n200,000 mesos", 55, "Magic Attack 70");
			}
		}
		else if (craftType == 3)
		{
			int craftType2 = AskMenu("What kind of weapon do you want to create?#b",
				(0, " Two-Handed Sword"),
				(1, " Two-Handed Axe"),
				(2, " Two-Handed Mace"),
				(3, " Spear"),
				(4, " Polearm"),
				(5, " Bow"),
				(6, " Crossbow"),
				(7, " Claw"));
			
			if (craftType2 == 0)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a Two-Handed Sword? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1402002#"),
					(1, " #t1402006#"),
					(2, " #t1402007#"),
					(3, " #t1402003#"));
				
				if (craftSelect == 0) Craft1(600, "#t1402002#", "#v4130005# #t4130005#\r\n#v4131003# #t4131003#\r\n#v4011001# 2 #t4011001#s\r\n#v4021000# #t4021000#\r\n#v4021004# 2 #t4021004#s\r\n#v4003000# 35 #t4003000#s\r\n20,000 mesos", 30, "Attack 50");
				else if (craftSelect == 1) Craft1(601, "#t1402006#", "#v4130005# #t4130005#\r\n#v4131003# #t4131003#\r\n#v4011006# #t4011006#\r\n#v4011001# 5 #t4011001#s\r\n#v4021004# 5 #t4021004#s\r\n#v4003000# 40 #t4003000#s\r\n37,000 mesos", 35, "Attack 55");
				else if (craftSelect == 2) Craft1(602, "#t1402007#", "#v4130005# #t4130005#\r\n#v4131003# #t4131003#\r\n#v4021003# 7 #t4021003#s\r\n#v4011000# 5 #t4011000#s\r\n#v4011001# 5 #t4011001#s\r\n#v4003000# 45 #t4003000#s\r\n72,000 mesos", 40, "Attack 60");
				else if (craftSelect == 3) Craft1(603, "#t1402003#", "#v4130005# #t4130005#\r\n#v4131003# #t4131003#\r\n#v4005000# #t4005000#\r\n#v4021007# 2 #t4021007#s\r\n#v4011006# 4 #t4011006#s\r\n#v4011001# 10 #t4011001#s\r\n#v4003000# 55 #t4003000#s\r\n220,000 mesos", 50, "Attack 70");
			}
			else if (craftType2 == 1)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a Two-Handed Axe? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1412006#"),
					(1, " #t1412004#"),
					(2, " #t1412005#"),
					(3, " #t1412003#"));
				
				if (craftSelect == 0) Craft1(700, "#t1412006#", "#v4130006# #t4130006#\r\n#v4131004# #t4131004#\r\n#v4021005# 2 #t4021005#s\r\n#v4011001# 2 #t4011001#s\r\n#v4003001# 5 #t4003001#s\r\n#v4003000# 35 #t4003000#s\r\n20,000 mesos", 30, "Attack 52");
				else if (craftSelect == 1) Craft1(701, "#t1412004#", "#v4130006# #t4130006#\r\n#v4131004# #t4131004#\r\n#v4011004# 5 #t4011004#s\r\n#v4011000# 5 #t4011000#s\r\n#v4021003# 3 #t4021003#s\r\n#v4003000# 40 #t4003000#s\r\n37,000 mesos", 35, "Attack 57");
				else if (craftSelect == 2) Craft1(702, "#t1412005#", "#v4130006# #t4130006#\r\n#v4131004# #t4131004#\r\n#v4011006# 3 #t4011006#s\r\n#v4011004# 5 #t4011004#s\r\n#v4011001# 5 #t4011001#s\r\n#v4003000# 45 #t4003000#s\r\n72,000 mesos", 40, "Attack 62");
				else if (craftSelect == 3) Craft1(703, "#t1412003#", "#v4130006# #t4130006#\r\n#v4131004# #t4131004#\r\n#v4005000# #t4005000#\r\n#v4021007# 2 #t4021007#s\r\n#v4021006# 7 #t4021006#s\r\n#v4011006# 5 #t4011006#s\r\n#v4003000# 55 #t4003000#s\r\n220,000 mesos", 50, "Attack 72");
			}
			else if (craftType2 == 2)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a Two-Handed Mace? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1422001#"),
					(1, " #t1422008#"),
					(2, " #t1422007#"),
					(3, " #t1422005#"));
				
				if (craftSelect == 0) Craft1(800, "#t1422001#", "#v4130007# #t4130007#\r\n#v4131005# #t4131005#\r\n#v4011001# 2 #t4011001#s\r\n#v4011004# 3 #t4011004#s\r\n#v4003000# 35 #t4003000#s\r\n20,000 mesos", 30, "Attack 52");
				else if (craftSelect == 1) Craft1(801, "#t1422008#", "#v4130007# #t4130007#\r\n#v4131005# #t4131005#\r\n#v4011001# 5 #t4011001#s\r\n#v4011000# 5 #t4011000#s\r\n#v4003001# 10 #t4003001#s\r\n#v4003000# 40 #t4003000#s\r\n37,000 mesos", 35, "Attack 57");
				else if (craftSelect == 2) Craft1(802, "#t1422007#", "#v4130007# #t4130007#\r\n#v4131005# #t4131005#\r\n#v4011006# 3 #t4011006#s\r\n#v4011004# 5 #t4011004#s\r\n#v4011001# 5 #t4011001#s\r\n#v4003000# 45 #t4003000#s\r\n72,000 mesos", 40, "Attack 62");
				else if (craftSelect == 3) Craft1(803, "#t1422005#", "#v4130007# #t4130007#\r\n#v4131005# #t4131005#\r\n#v4005000# #t4005000#\r\n#v4021008# 2 #t4021008#s\r\n#v4021006# 7 #t4021006#s\r\n#v4011006# 5 #t4011006#s\r\n#v4003000# 55 #t4003000#s\r\n220,000 mesos", 50, "Attack 72");
			}
			else if (craftType2 == 3)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a Spear? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1432002#"),
					(1, " #t1432003#"),
					(2, " #t1432005#"),
					(3, " #t1432004#"));
				
				if (craftSelect == 0) Craft1(900, "#t1432002#", "#v4130008# #t4130008#\r\n#v4131006# #t4131006#\r\n#v4011000# 2 #t4011000#s\r\n#v4011004# 3 #t4011004#s\r\n#v4003000# 40 #t4003000#s\r\n22,000 mesos", 30, "Attack 52");
				else if (craftSelect == 1) Craft1(901, "#t1432003#", "#v4130008# #t4130008#\r\n#v4131006# #t4131006#\r\n#v4011001# 5 #t4011001#s\r\n#v4011002# 5 #t4011002#s\r\n#v4021000# 3 #t4021000#s\r\n#v4003000# 45 #t4003000#s\r\n39,000 mesos", 35, "Attack 57");
				else if (craftSelect == 2) Craft1(902, "#t1432005#", "#v4130008# #t4130008#\r\n#v4131006# #t4131006#\r\n#v4011004# 3 #t4011004#s\r\n#v4011001# 5 #t4011001#s\r\n#v4011000# 5 #t4011000#s\r\n#v4003000# 50 #t4003000#s\r\n74,000 mesos", 40, "Attack 62");
				else if (craftSelect == 3) Craft1(903, "#t1432004#", "#v4130008# #t4130008#\r\n#v4131006# #t4131006#\r\n#v4005000# #t4005000#\r\n#v4021008# 2 #t4021008#s\r\n#v4011000# 7 #t4011000#s\r\n#v4021000# 5 #t4021000#s\r\n#v4003000# 60 #t4003000#s\r\n240,000 mesos", 50, "Attack 72");
			}
			else if (craftType2 == 4)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a Polearm? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1442001#"),
					(1, " #t1442003#"),
					(2, " #t1442009#"),
					(3, " #t1442005#"));
				
				if (craftSelect == 0) Craft1(1000, "#t1442001#", "#v4130009# #t4130009#\r\n#v4131007# #t4131007#\r\n#v4011000# 2 #t4011000#s\r\n#v4011002# 3 #t4011002#s\r\n#v4003000# 40 #t4003000#s\r\n22,000 mesos", 30, "Attack 52");
				else if (craftSelect == 1) Craft1(1001, "#t1442003#", "#v4130009# #t4130009#\r\n#v4131007# #t4131007#\r\n#v4011001# 5 #t4011001#s\r\n#v4011002# 5 #t4011002#s\r\n#v4011000# 3 #t4011000#s\r\n#v4003000# 40 #t4003000#s\r\n39,000 mesos", 35, "Attack 57");
				else if (craftSelect == 2) Craft1(1002, "#t1442009#", "#v4130009# #t4130009#\r\n#v4131007# #t4131007#\r\n#v4011006# 3 #t4011006#s\r\n#v4011002# 5 #t4011002#s\r\n#v4011001# 5 #t4011001#s\r\n#v4003000# 50 #t4003000#s\r\n74,000 mesos", 40, "Attack 62");
				else if (craftSelect == 3) Craft1(1003, "#t1442005#", "#v4130009# #t4130009#\r\n#v4131007# #t4131007#\r\n#v4005000# #t4005000#\r\n#v4021007# 2 #t4021007#s\r\n#v4011001# 7 #t4011001#s\r\n#v4011002# 5 #t4011002#s\r\n#v4003000# 60 #t4003000#s\r\n240,000 mesos", 50, "Attack 72");
			}
			else if (craftType2 == 5)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a Bow? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1452005#"),
					(1, " #t1452006#"),
					(2, " #t1452007#"),
					(3, " #t1452008#"));
				
				if (craftSelect == 0) Craft1(1100, "#t1452005#", "#v4130012# #t4130012#\r\n#v4131010# #t4131010#\r\n#v4011001# 5 #t4011001#s\r\n#v4011006# 5 #t4011006#s\r\n#v4021003# 3 #t4021003#s\r\n#v4021006# 3 #t4021006#s\r\n#v4003000# 30 #t4003000#s\r\n15,000 mesos", 30, "Attack 45");
				else if (craftSelect == 1) Craft1(1101, "#t1452006#", "#v4130012# #t4130012#\r\n#v4131010# #t4131010#\r\n#v4011004# 7 #t4011004#s\r\n#v4021000# 6 #t4021000#s\r\n#v4021004# 3 #t4021004#s\r\n#v4003000# 35 #t4003000#s\r\n20,000 mesos", 35, "Attack 50");
				else if (craftSelect == 2) Craft1(1102, "#t1452007#", "#v4130012# #t4130012#\r\n#v4131010# #t4131010#\r\n#v4021008# #t4021008#\r\n#v4011001# 10 #t4011001#s\r\n#v4011006# 3 #t4011006#s\r\n#v4003000# 40 #t4003000#s\r\n#v4000112# 100 #t4000112#s\r\n40,000 mesos", 40, "Attack 55");
				else if (craftSelect == 3) Craft1(1103, "#t1452008#", "#v4130012# #t4130012#\r\n#v4131010# #t4131010#\r\n#v4005002# #t4005002#\r\n#v4021008# 2 #t4021008#s\r\n#v4011001# 10 #t4011001#s\r\n#v4021005# 6 #t4021005#s\r\n#v4003000# 50 #t4003000#s\r\n100,000 mesos", 50, "Attack 65");
			}
			else if (craftType2 == 6)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a Crossbow? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1462004#"),
					(1, " #t1462005#"),
					(2, " #t1462006#"),
					(3, " #t1462007#"));
				
				if (craftSelect == 0) Craft1(1200, "#t1462004#", "#v4130013# #t4130013#\r\n#v4131011# #t4131011#\r\n#v4011001# 5 #t4011001#s\r\n#v4011005# 5 #t4011005#s\r\n#v4021006# 3 #t4021006#s\r\n#v4003001# 50 #t4003001#s\r\n#v4003000# 15 #t4003000#s\r\n15,000 mesos", 32, "Attack 49");
				else if (craftSelect == 1) Craft1(1201, "#t1462005#", "#v4130013# #t4130013#\r\n#v4131011# #t4131011#\r\n#v4021008# #t4021008#\r\n#v4011001# 8 #t4011001#s\r\n#v4011006# 4 #t4011006#s\r\n#v4021006# 2 #t4021006#s\r\n#v4003000# 30 #t4003000#s\r\n25,000 mesos", 38, "Attack 54");
				else if (craftSelect == 2) Craft1(1202, "#t1462006#", "#v4130013# #t4130013#\r\n#v4131011# #t4131011#\r\n#v4021008# 2 #t4021008#s\r\n#v4011004# 6 #t4011004#s\r\n#v4003001# 30 #t4003001#s\r\n#v4003000# 30 #t4003000#s\r\n41,000 mesos", 42, "Attack 59");
				else if (craftSelect == 3) Craft1(1203, "#t1462007#", "#v4130013# #t4130013#\r\n#v4131011# #t4131011#\r\n#v4021008# 2 #t4021008#s\r\n#v4011006# 5 #t4011006#s\r\n#v4021006# 3 #t4021006#s\r\n#v4003001# 40 #t4003001#s\r\n#v4003000# 40 #t4003000#s\r\n100,000 mesos", 50, "Attack 68");
			}
			else if (craftType2 == 7)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a Claw? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1472009#"),
					(1, " #t1472010#"),
					(2, " #t1472012#"),
					(3, " #t1472013#"),
					(4, " #t1472015#"),
					(5, " #t1472016#"),
					(6, " #t1472017#"),
					(7, " #t1472019#"),
					(8, " #t1472020#"),
					(9, " #t1472021#"));
				
				if (craftSelect == 0) Craft1(1300, "#t1472009#", "#v4130015# #t4130015#\r\n#v4131013# #t4131013#\r\n#v1472008# #t1472008#\r\n#v4011002# 3 #t4011002#s\r\n10,000 mesos", 30, "Attack 18");
				else if (craftSelect == 1) Craft1(1301, "#t1472010#", "#v4130015# #t4130015#\r\n#v4131013# #t4131013#\r\n#v1472008# #t1472008#\r\n#v4011003# 3 #t4011003#s\r\n15,000 mesos", 30, "Attack 18");
				else if (craftSelect == 2) Craft1(1302, "#t1472012#", "#v4130015# #t4130015#\r\n#v4131013# #t4131013#\r\n#v1472011# #t1472011#\r\n#v4011004# 4 #t4011004#s\r\n20,000 mesos", 35, "Attack 20");
				else if (craftSelect == 3) Craft1(1303, "#t1472013#", "#v4130015# #t4130015#\r\n#v4131013# #t4131013#\r\n#v1472011# #t1472011#\r\n#v4021008# #t4021008#\r\n25,000 mesos", 35, "Attack 20");
				else if (craftSelect == 4) Craft1(1304, "#t1472015#", "#v4130015# #t4130015#\r\n#v4131013# #t4131013#\r\n#v1472014# #t1472014#\r\n#v4021000# 5 #t4021000#s\r\n30,000 mesos", 40, "Attack 22");
				else if (craftSelect == 5) Craft1(1305, "#t1472016#", "#v4130015# #t4130015#\r\n#v4131013# #t4131013#\r\n#v1472014# #t1472014#\r\n#v4011003# 5 #t4011003#s\r\n30,000 mesos", 40, "Attack 22");
				else if (craftSelect == 6) Craft1(1306, "#t1472017#", "#v4130015# #t4130015#\r\n#v4131013# #t4131013#\r\n#v1472014# #t1472014#\r\n#v4021008# 2 #t4021008#s\r\n35,000 mesos", 40, "Attack 22");
				else if (craftSelect == 7) Craft1(1307, "#t1472019#", "#v4130015# #t4130015#\r\n#v4131013# #t4131013#\r\n#v1472018# #t1472018#\r\n#v4021000# 6 #t4021000#s\r\n40,000 mesos", 50, "Attack 26");
				else if (craftSelect == 8) Craft1(1308, "#t1472020#", "#v4130015# #t4130015#\r\n#v4131013# #t4131013#\r\n#v1472018# #t1472018#\r\n#v4021005# 6 #t4021005#s\r\n40,000 mesos", 50, "Attack 26");
				else if (craftSelect == 9) Craft1(1309, "#t1472021#", "#v4130015# #t4130015#\r\n#v4131013# #t4131013#\r\n#v1472018# #t1472018#\r\n#v4005003# #t4005003#\r\n#v4021008# 3 #t4021008#s\r\n50,000 mesos", 50, "Attack 26");
			}
		}
		else if (craftType == 4)
		{
			int craftType2 = AskMenu("What kind of weapon do you want to create?#b",
				(0, " One-Handed Sword"),
				(1, " One-Handed Axe"),
				(2, " One-Handed Mace"),
				(3, " Dagger"),
				(4, " Wand"),
				(5, " Staff"));
			
			if (craftType2 == 0)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a common One-Handed Sword? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1302008#"),
					(1, " #t1302004#"),
					(2, " #t1302009#"),
					(3, " #t1302010#"));
				
				if (craftSelect == 0) Craft2(0, "#t1302008#", "#v4131000# #t4131000#\r\n#v4011001# 2 #t4011001#s\r\n#v4011004# 2 #t4011004#s\r\n#v4003000# 30 #t4003000#s\r\n18,000 mesos", 30, "Attack 47");
				else if (craftSelect == 1) Craft2(1, "#t1302004#", "#v4131000# #t4131000#\r\n#v4011006# #t4011006#\r\n#v4011001# 5 #t4011001#s\r\n#v4021006# 3 #t4021006#s\r\n#v4003000# 35 #t4003000#s\r\n35,000 mesos", 35, "Attack 52");
				else if (craftSelect == 2) Craft2(2, "#t1302009#", "#v4131000# #t4131000#\r\n#v4011006# 3 #t4011006#s\r\n#v4011001# 5 #t4011001#s\r\n#v4021000# 5 #t4021000#s\r\n#v4003000# 40 #t4003000#s\r\n70,000 mesos", 40, "Attack 57");
				else if (craftSelect == 3) Craft2(3, "#t1302010#", "#v4131000# #t4131000#\r\n#v4005000# #t4005000#\r\n#v4021008# 2 #t4021008#s\r\n#v4011006# 4 #t4011006#s\r\n#v4021003# 10 #t4021003#s\r\n#v4003000# 50 #t4003000#s\r\n200,000 mesos", 50, "Attack 67");
			}
			else if (craftType2 == 1)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a common One-Handed Axe? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1312005#"),
					(1, " #t1312006#"),
					(2, " #t1312007#"),
					(3, " #t1312008#"));
				
				if (craftSelect == 0) Craft2(100, "#t1312005#", "#v4131001# #t4131001#\r\n#v4011001# 2 #t4011001#s\r\n#v4021000# 2 #t4021000#s\r\n#v4003000# 30 #t4003000#s\r\n18,000 mesos", 30, "Attack 47");
				else if (craftSelect == 1) Craft2(101, "#t1312006#", "#v4131001# #t4131001#\r\n#v4011001# 5 #t4011001#s\r\n#v4021000# 5 #t4021000#s\r\n#v4011004# 3 #t4011004#s\r\n#v4003000# 35 #t4003000#s\r\n35,000 mesos", 35, "Attack 52");
				else if (craftSelect == 2) Craft2(102, "#t1312007#", "#v4131001# #t4131001#\r\n#v4021005# 7 #t4021005#s\r\n#v4011001# 5 #t4011001#s\r\n#v4021001# 5 #t4021001#s\r\n#v4003000# 40 #t4003000#s\r\n70,000 mesos", 40, "Attack 57");
				else if (craftSelect == 3) Craft2(103, "#t1312008#", "#v4131001# #t4131001#\r\n#v4005000# #t4005000#\r\n#v4021008# 2 #t4021008#s\r\n#v4011004# 8 #t4011004#s\r\n#v4011001# 10 #t4011001#s\r\n#v4003000# 50 #t4003000#s\r\n200,000 mesos", 50, "Attack 67");
			}
			else if (craftType2 == 2)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a common One-Handed Mace? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1322014#"),
					(1, " #t1322015#"),
					(2, " #t1322016#"),
					(3, " #t1322017#"));
				
				if (craftSelect == 0) Craft2(200, "#t1322014#", "#v4131002# #t4131002#\r\n#v4011001# 2 #t4011001#s\r\n#v4011000# 3 #t4011000#s\r\n#v4003000# 30 #t4003000#s\r\n18,000 mesos", 30, "Attack 49");
				else if (craftSelect == 1) Craft2(201, "#t1322015#", "#v4131002# #t4131002#\r\n#v4011001# 5 #t4011001#s\r\n#v4011000# 5 #t4011000#s\r\n#v4011003# 3 #t4011003#s\r\n#v4003000# 35 #t4003000#s\r\n35,000 mesos", 35, "Attack 54");
				else if (craftSelect == 2) Craft2(202, "#t1322016#", "#v4131002# #t4131002#\r\n#v4011003# 7 #t4011003#s\r\n#v4011001# 5 #t4011001#s\r\n#v4011004# 5 #t4011004#s\r\n#v4003000# 40 #t4003000#s\r\n70,000 mesos", 40, "Attack 59");
				else if (craftSelect == 3) Craft2(203, "#t1322017#", "#v4131002# #t4131002#\r\n#v4005000# #t4005000#\r\n#v4021008# 2 #t4021008#s\r\n#v4011006# 4 #t4011006#s\r\n#v4011001# 10 #t4011001#s\r\n#v4003000# 50 #t4003000#s\r\n200,000 mesos", 50, "Attack 69");
			}
			else if (craftType2 == 3)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a common Dagger? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon would you like to create?#b",
					(0, " #t1332012#"),
					(1, " #t1332009#"),
					(2, " #t1332014#"),
					(3, " #t1332011#"),
					(4, " #t1332016#"),
					(5, " #t1332003#"));
				
				if (craftSelect == 0) Craft2(300, "#t1332012#", "#v4131012# #t4131012#\r\n#v4011002# 2 #t4011002#s\r\n#v4011001# 3 #t4011001#s\r\n#v4003000# 30 #t4003000#s\r\n20,000 mesos", 30, "Attack 45");
				else if (craftSelect == 1) Craft2(301, "#t1332009#", "#v4131012# #t4131012#\r\n#v4021005# 2 #t4021005#s\r\n#v4011001# 3 #t4011001#s\r\n#v4003000# 30 #t4003000#s\r\n20,000 mesos", 30, "Attack 45");
				else if (craftSelect == 2) Craft2(302, "#t1332014#", "#v4131012# #t4131012#\r\n#v4021005# #t4021005#\r\n#v4011001# 5 #t4011001#s\r\n#v4011002# 3 #t4011002#s\r\n#v4003000# 35 #t4003000#s\r\n33,000 mesos", 35, "Attack 50");
				else if (craftSelect == 3) Craft2(303, "#t1332011#", "#v4131012# #t4131012#\r\n#v4011001# 7 #t4011001#s\r\n#v4011006# 3 #t4011006#s\r\n#v4021006# 6 #t4021006#s\r\n#v4003000# 40 #t4003000#s\r\n73,000 mesos", 40, "Attack 55");
				else if (craftSelect == 4) Craft2(304, "#t1332016#", "#v4131012# #t4131012#\r\n#v4005003# #t4005003#\r\n#v4021008# 2 #t4021008#s\r\n#v4011004# 7 #t4011004#s\r\n#v4011001# 10 #t4011001#s\r\n#v4003000# 50 #t4003000#s\r\n230,000 mesos", 50, "Attack 65");
				else if (craftSelect == 5) Craft2(305, "#t1332003#", "#v4131012# #t4131012#\r\n#v4005003# #t4005003#\r\n#v4021007# 2 #t4021007#s\r\n#v4011006# 5 #t4011006#s\r\n#v4011001# 10 #t4011001#s\r\n#v4003000# 50 #t4003000#s\r\n230,000 mesos", 50, "Attack 62");
			}
			else if (craftType2 == 4)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a common Wand? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1372003#"),
					(1, " #t1372001#"),
					(2, " #t1372000#"),
					(3, " #t1372007#"));
				
				if (craftSelect == 0) Craft2(400, "#t1372003#", "#v4131008# #t4131008#\r\n#v4011002# 3 #t4011002#s\r\n#v4021002# #t4021002#\r\n#v4003000# 10 #t4003000#s\r\n15,000 mesos", 28, "Magic Attack 43");
				else if (craftSelect == 1) Craft2(401, "#t1372001#", "#v4131008# #t4131008#\r\n#v4021006# 5 #t4021006#s\r\n#v4011002# 3 #t4011002#s\r\n#v4011001# #t4011001#\r\n#v4003000# 15 #t4003000#s\r\n30,000 mesos", 33, "Magic Attack 48");
				else if (craftSelect == 2) Craft2(402, "#t1372000#", "#v4131008# #t4131008#\r\n#v4021006# 5 #t4021006#s\r\n#v4021005# 5 #t4021005#s\r\n#v4021007# #t4021007#\r\n#v4003003# #t4003003#\r\n#v4003000# 20 #t4003000#s\r\n60,000 mesos", 38, "Magic Attack 53");
				else if (craftSelect == 3) Craft2(403, "#t1372007#", "#v4131008# #t4131008#\r\n#v4011006# 4 #t4011006#s\r\n#v4021003# 3 #t4021003#s\r\n#v4021007# 3 #t4021007#s\r\n#v4021002# #t4021002#\r\n#v4003000# 30 #t4003000#s\r\n100,000 mesos", 48, "Magic Attack 63");
			}
			else if (craftType2 == 5)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a common Staff? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1382002#"),
					(1, " #t1382001#"),
					(2, " #t1382006#"));
				
				if (craftSelect == 0) Craft2(500, "#t1382002#", "#v4131009# #t4131009#\r\n#v4021006# 2 #t4021006#s\r\n#v4021001# #t4021001#\r\n#v4011001# #t4011001#\r\n#v4003000# 15 #t4003000#s\r\n10,000 mesos", 25, "Magic Attack 40");
				else if (craftSelect == 1) Craft2(501, "#t1382001#", "#v4131009# #t4131009#\r\n#v4011001# 8 #t4011001#s\r\n#v4021001# 5 #t4021001#s\r\n#v4021006# 5 #t4021006#s\r\n#v4021005# 5 #t4021005#s\r\n#v4003000# 30 #t4003000#s\r\n80,000 mesos", 45, "Magic Attack 60");
				else if (craftSelect == 2) Craft2(502, "#t1382006#", "#v4131009# #t4131009#\r\n#v4005001# 2 #t4005001#s\r\n#v4021008# 2 #t4021008#s\r\n#v4011006# 5 #t4011006#s\r\n#v4011004# 10 #t4011004#s\r\n#v4003000# 40 #t4003000#s\r\n200,000 mesos", 55, "Magic Attack 70");
			}
		}
		else if (craftType == 5)
		{
			int craftType2 = AskMenu("What kind of weapon do you want to create?#b",
				(0, " Two-Handed Sword"),
				(1, " Two-Handed Axe"),
				(2, " Two-Handed Mace"),
				(3, " Spear"),
				(4, " Polearm"),
				(5, " Bow"),
				(6, " Crossbow"),
				(7, " Claw"));
			
			if (craftType2 == 0)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a common Two-Handed Sword? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1402002#"),
					(1, " #t1402006#"),
					(2, " #t1402007#"),
					(3, " #t1402003#"));
				
				if (craftSelect == 0) Craft2(600, "#t1402002#", "#v4131003# #t4131003#\r\n#v4011001# 2 #t4011001#s\r\n#v4021000# #t4021000#\r\n#v4021004# 2 #t4021004#s\r\n#v4003000# 35 #t4003000#s\r\n20,000 mesos", 30, "Attack 50");
				else if (craftSelect == 1) Craft2(601, "#t1402006#", "#v4131003# #t4131003#\r\n#v4011006# #t4011006#\r\n#v4011001# 5 #t4011001#s\r\n#v4021004# 5 #t4021004#s\r\n#v4003000# 40 #t4003000#s\r\n37,000 mesos", 35, "Attack 55");
				else if (craftSelect == 2) Craft2(602, "#t1402007#", "#v4131003# #t4131003#\r\n#v4021003# 7 #t4021003#s\r\n#v4011000# 5 #t4011000#s\r\n#v4011001# 5 #t4011001#s\r\n#v4003000# 45 #t4003000#s\r\n72,000 mesos", 40, "Attack 60");
				else if (craftSelect == 3) Craft2(603, "#t1402003#", "#v4131003# #t4131003#\r\n#v4005000# #t4005000#\r\n#v4021007# 2 #t4021007#s\r\n#v4011006# 4 #t4011006#s\r\n#v4011001# 10 #t4011001#s\r\n#v4003000# 55 #t4003000#s\r\n220,000 mesos", 50, "Attack 70");
			}
			else if (craftType2 == 1)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a common Two-Handed Axe? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1412006#"),
					(1, " #t1412004#"),
					(2, " #t1412005#"),
					(3, " #t1412003#"));
				
				if (craftSelect == 0) Craft2(700, "#t1412006#", "#v4131004# #t4131004#\r\n#v4021005# 2 #t4021005#s\r\n#v4011001# 2 #t4011001#s\r\n#v40030015 # #t4003001#s\r\n#v4003000# 35 #t4003000#s\r\n20,000 mesos", 30, "Attack 52");
				else if (craftSelect == 1) Craft2(701, "#t1412004#", "#v4131004# #t4131004#\r\n#v4011004# 5 #t4011004#s\r\n#v4011000# 5 #t4011000#s\r\n#v4021003# 3 #t4021003#s\r\n#v4003000# 40 #t4003000#s\r\n37,000 mesos", 35, "Attack 57");
				else if (craftSelect == 2) Craft2(702, "#t1412005#", "#v4131004# #t4131004#\r\n#v4011006# 3 #t4011006#s\r\n#v4011004# 5 #t4011004#s\r\n#v4011001# 5 #t4011001#s\r\n#v4003000# 45 #t4003000#s\r\n72,000 mesos", 40, "Attack 62");
				else if (craftSelect == 3) Craft2(703, "#t1412003#", "#v4131004# #t4131004#\r\n#v4005000# #t4005000#\r\n#v4021007# 2 #t4021007#s\r\n#v4021006# 7 #t4021006#s\r\n#v4011006# 5 #t4011006#s\r\n#v4003000# 55 #t4003000#s\r\n220,000 mesos", 50, "Attack 72");
			}
			else if (craftType2 == 2)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a common Two-Handed Mace? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1422001#"),
					(1, " #t1422008#"),
					(2, " #t1422007#"),
					(3, " #t1422005#"));
				
				if (craftSelect == 0) Craft2(800, "#t1422001#", "#v4131005# #t4131005#\r\n#v4011001# 2 #t4011001#s\r\n#v4011004# 3 #t4011004#s\r\n#v4003000# 35 #t4003000#s\r\n20,000 mesos", 30, "Attack 52");
				else if (craftSelect == 1) Craft2(801, "#t1422008#", "#v4131005# #t4131005#\r\n#v4011001# 5 #t4011001#s\r\n#v4011000# 5 #t4011000#s\r\n#v4003001# 10 #t4003001#s\r\n#v4003000# 40 #t4003000#s\r\n37,000 mesos", 35, "Attack 57");
				else if (craftSelect == 2) Craft2(802, "#t1422007#", "#v4131005# #t4131005#\r\n#v4011006# 3 #t4011006#s\r\n#v4011004# 5 #t4011004#s\r\n#v4011001# 5 #t4011001#s\r\n#v4003000# 45 #t4003000#s\r\n72,000 mesos", 40, "Attack 62");
				else if (craftSelect == 3) Craft2(803, "#t1422005#", "#v4131005# #t4131005#\r\n#v4005000# #t4005000#\r\n#v4021008# 2 #t4021008#s\r\n#v4021006# 7 #t4021006#s\r\n#v4011006# 5 #t4011006#s\r\n#v4003000# 55 #t4003000#s\r\n220,000 mesos", 50, "Attack 72");
			}
			else if (craftType2 == 3)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a common Spear? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1432002#"),
					(1, " #t1432003#"),
					(2, " #t1432005#"),
					(3, " #t1432004#"));
				
				if (craftSelect == 0) Craft2(900, "#t1432002#", "#v4131006# #t4131006#\r\n#v4011000# 2 #t4011000#s\r\n#v4011004# 3 #t4011004#s\r\n#v4003000# 40 #t4003000#s\r\n22,000 mesos", 30, "Attack 52");
				else if (craftSelect == 1) Craft2(901, "#t1432003#", "#v4131006# #t4131006#\r\n#v4011001# 5 #t4011001#s\r\n#v4011002# 5 #t4011002#s\r\n#v4021000# 3 #t4021000#s\r\n#v4003000# 45 #t4003000#s\r\n39,000 mesos", 35, "Attack 57");
				else if (craftSelect == 2) Craft2(902, "#t1432005#", "#v4131006# #t4131006#\r\n#v4011004# 3 #t4011004#s\r\n#v4011001# 5 #t4011001#s\r\n#v4011000# 5 #t4011000#s\r\n#v4003000# 50 #t4003000#s\r\n74,000 mesos", 40, "Attack 62");
				else if (craftSelect == 3) Craft2(903, "#t1432004#", "#v4131006# #t4131006#\r\n#v4005000# #t4005000#\r\n#v4021008# 2 #t4021008#s\r\n#v4011000# 7 #t4011000#s\r\n#v4021000# 5 #t4021000#s\r\n#v4003000# 60 #t4003000#s\r\n240,000 mesos", 50, "Attack 72");
			}
			else if (craftType2 == 4)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a common Polearm? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1442001#"),
					(1, " #t1442003#"),
					(2, " #t1442009#"),
					(3, " #t1442005#"));
				
				if (craftSelect == 0) Craft2(1000, "#t1442001#", "#v4131007# #t4131007#\r\n#v4011000# 2 #t4011000#s\r\n#v4011002# 3 #t4011002#s\r\n#v4003000# 40 #t4003000#s\r\n22,000 mesos", 30, "Attack 52");
				else if (craftSelect == 1) Craft2(1001, "#t1442003#", "#v4131007# #t4131007#\r\n#v4011001# 5 #t4011001#s\r\n#v4011002# 5 #t4011002#s\r\n#v4011000# 3 #t4011000#s\r\n#v4003000# 45 #t4003000#s\r\n39,000 mesos", 35, "Attack 57");
				else if (craftSelect == 2) Craft2(1002, "#t1442009#", "#v4131007# #t4131007#\r\n#v4011006# 3 #t4011006#s\r\n#v4011002# 5 #t4011002#s\r\n#v4011001# 5 #t4011001#s\r\n#v4003000# 50 #t4003000#s\r\n74,000 mesos", 40, "Attack 62");
				else if (craftSelect == 3) Craft2(1003, "#t1442005#", "#v4131007# #t4131007#\r\n#v4005000# #t4005000#\r\n#v4021007# 2 #t4021007#s\r\n#v4011001# 7 #t4011001#s\r\n#v4011002# 5 #t4011002#s\r\n#v4003000# 60 #t4003000#s\r\n240,000 mesos", 50, "Attack 72");
			}
			else if (craftType2 == 5)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a common Bow? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1452005#"),
					(1, " #t1452006#"),
					(2, " #t1452007#"),
					(3, " #t1452008#"));
				
				if (craftSelect == 0) Craft2(1100, "#t1452005#", "#v4131010# #t4131010#\r\n#v4011001# 5 #t4011001#s\r\n#v4011006# 5 #t4011006#s\r\n#v4021003# 3 #t4021003#s\r\n#v4021006# 3 #t4021006#s\r\n#v4003000# 30 #t4003000#s\r\n15,000 mesos", 30, "Attack 45");
				else if (craftSelect == 1) Craft2(1101, "#t1452006#", "#v4131010# #t4131010#\r\n#v4011004# 7 #t4011004#s\r\n#v4021000# 6 #t4021000#s\r\n#v4021004# 3 #t4021004#s\r\n#v4003000# 35 #t4003000#s\r\n20,000 mesos", 35, "Attack 50");
				else if (craftSelect == 2) Craft2(1102, "#t1452007#", "#v4131010# #t4131010#\r\n#v4021008# #t4021008#\r\n#v4011001# 10 #t4011001#s\r\n#v4011006# 3 #t4011006#s\r\n#v4003000# 40 #t4003000#s\r\n#v4000112# 100 #t4000112#s\r\n40,000 mesos", 40, "Attack 55");
				else if (craftSelect == 3) Craft2(1103, "#t1452008#", "#v4131010# #t4131010#\r\n#v4005002# #t4005002#\r\n#v4021008# 2 #t4021008#s\r\n#v4011001# 10 #t4011001#s\r\n#v4021005# 6 #t4021005#s\r\n#v4003000# 50 #t4003000#s\r\n100,000 mesos", 50, "Attack 65");
			}
			else if (craftType2 == 6)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a common Crossbow? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1462004#"),
					(1, " #t1462005#"),
					(2, " #t1462006#"),
					(3, " #t1462007#"));
				
				if (craftSelect == 0) Craft2(1200, "#t1462004#", "#v4131011# #t4131011#\r\n#v4011001# 5 #t4011001#s\r\n#v4011005# 5 #t4011005#s\r\n#v4021006# 3 #t4021006#s\r\n#v4003001# 50 #t4003001#s\r\n#v4003000# 15 #t4003000#s\r\n15,000 mesos", 32, "Attack 49");
				else if (craftSelect == 1) Craft2(1201, "#t1462005#", "#v4131011# #t4131011#\r\n#v4021008# #t4021008#\r\n#v4011001# 8 #t4011001#s\r\n#v4011006# 4 #t4011006#s\r\n#v4021006# 2 #t4021006#s\r\n#v4003000# 30 #t4003000#s\r\n25,000 mesos", 38, "Attack 54");
				else if (craftSelect == 2) Craft2(1202, "#t1462006#", "#v4131011# #t4131011#\r\n#v4021008# 2 #t4021008#s\r\n#v4011004# 6 #t4011004#s\r\n#v4003001# 30 #t4003001#s\r\n#v4003000# 30 #t4003000#s\r\n41,000 mesos", 42, "Attack 59");
				else if (craftSelect == 3) Craft2(1203, "#t1462007#", "#v4131011# #t4131011#\r\n#v4021008# 2 #t4021008#s\r\n#v4011006# 5 #t4011006#s\r\n#v4021006# 3 #t4021006#s\r\n#v4003001# 40 #t4003001#s\r\n#v4003000# 40 #t4003000#s\r\n100,000 mesos", 50, "Attack 68");
			}
			else if (craftType2 == 7)
			{
				int craftSelect = AskMenu("So, you want to use the stimulator to create a common Claw? Keep in mind that the weapon can't be made without an item called #bforging manual#k. Let's see... what kind of weapon do you want to create?#b",
					(0, " #t1472008#"),
					(1, " #t1472011#"),
					(2, " #t1472014#"),
					(3, " #t1472018#"));
				
				if (craftSelect == 0) Craft2(1300, "#t1472008#", "#v4131013# #t4131013#\r\n#v4011000# 3 #t4011000#s\r\n#v4011001# 2 #t4011001#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 20 #t4003000#s\r\n15,000 mesos", 30, "Attack 18");
				else if (craftSelect == 1) Craft2(1301, "#t1472011#", "#v4131013# #t4131013#\r\n#v4011000# 4 #t4011000#s\r\n#v4011001# 2 #t4011001#s\r\n#v4000021# 80 #t4000021#s\r\n#v4003000# 25 #t4003000#s\r\n30,000 mesos", 35, "Attack 20");
				else if (craftSelect == 2) Craft2(1302, "#t1472014#", "#v4131013# #t4131013#\r\n#v4011000# 3 #t4011000#s\r\n#v4011001# 2 #t4011001#s\r\n#v4000021# 100 #t4000021#s\r\n#v4003000# 30 #t4003000#s\r\n40,000 mesos", 40, "Attack 22");
				else if (craftSelect == 3) Craft2(1303, "#t1472018#", "#v4131013# #t4131013#\r\n#v4011000# 4 #t4011000#s\r\n#v4011001# 2 #t4011001#s\r\n#v4000030# 40 #t4000030#s\r\n#v4003000# 35 #t4003000#s\r\n50,000 mesos", 50, "Attack 26");
			}
		}
	}
}