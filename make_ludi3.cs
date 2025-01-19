using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Craft1(int index, string makeItem, string needItem, int reqLevel, string itemOption)
	{
		bool askBuy = AskYesNo($"To make a(n) {makeItem} with the stimulator, you'll need the following items. The level limit will be {reqLevel}, and the basic attack level is {itemOption}. If the stimulator is used, the item stats can all be increased, but #bit can also end up worse than it was before, additionally it carries a 10% chance of failure, so please be careful#k. What do you think? Do you want to make it?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("I understand. When you use a stimulator, you run the risk of failing to create the item and so you can still waste the materials in the process. I would be careful too, but, if you change your mind, feel free.");
			return;
		}
		
		Random rnd = new Random();
		int chance = rnd.Next(1, 11);
		
		bool trade = false;
		// check for mesos first?
		if (chance == 1)
		{
			// failure to create warrior shoes
			if (index == 0) trade = Exchange(0, 4130001, -1, 4021003, -4, 4011001, -2, 4000021, -45, 4003000, -15);
			else if (index == 1) trade = Exchange(0, 4130001, -1, 4011002, -4, 4011001, -2, 4000021, -45, 4003000, -15);
			else if (index == 2) trade = Exchange(0, 4130001, -1, 4011004, -4, 4011001, -2, 4000021, -45, 4003000, -15);
			else if (index == 3) trade = Exchange(0, 4130001, -1, 4021000, -4, 4011001, -2, 4000021, -45, 4003000, -15);
			else if (index == 4) trade = Exchange(0, 4130001, -1, 4011001, -3, 4021004, -1, 4000021, -30, 4000030, -20, 4003000, -25);
			else if (index == 5) trade = Exchange(0, 4130001, -1, 4011002, -3, 4021004, -1, 4000021, -30, 4000030, -20, 4003000, -25);
			else if (index == 6) trade = Exchange(0, 4130001, -1, 4021008, -2, 4021004, -1, 4000021, -30, 4000030, -20, 4003000, -25);
			else if (index == 7) trade = Exchange(0, 4130001, -1, 4011003, -4, 4000021, -100, 4000030, -40, 4003000, -30, 4000033, -100);
			else if (index == 8) trade = Exchange(0, 4130001, -1, 4011005, -4, 4021007, -1, 4000030, -40, 4003000, -30, 4000042, -250);
			else if (index == 9) trade = Exchange(0, 4130001, -1, 4011002, -4, 4021007, -1, 4000030, -40, 4003000, -30, 4000041, -120);
			else if (index == 10) trade = Exchange(0, 4130001, -1, 4021008, -1, 4011001, -3, 4021003, -6, 4000030, -65, 4003000, -45);
			else if (index == 11) trade = Exchange(0, 4130001, -1, 4021008, -1, 4011001, -3, 4011002, -6, 4000030, -65, 4003000, -45);
			else if (index == 12) trade = Exchange(0, 4130001, -1, 4021008, -1, 4011001, -3, 4011005, -6, 4000030, -65, 4003000, -45);
			else if (index == 13) trade = Exchange(0, 4130001, -1, 4021008, -1, 4011001, -3, 4011006, -6, 4000030, -65, 4003000, -45);
			
			// failure to create magician shoes
			else if (index == 100) trade = Exchange(0, 4130001, -1, 4021000, -2, 4000021, -50, 4003000, -15);
			else if (index == 101) trade = Exchange(0, 4130001, -1, 4021002, -2, 4000021, -50, 4003000, -15);
			else if (index == 102) trade = Exchange(0, 4130001, -1, 4011004, -2, 4000021, -50, 4003000, -15);
			else if (index == 103) trade = Exchange(0, 4130001, -1, 4021008, -1, 4000021, -50, 4003000, -15);
			else if (index == 104) trade = Exchange(0, 4130001, -1, 4021001, -3, 4021006, -1, 4000021, -30, 4000030, -15, 4003000, -20);
			else if (index == 105) trade = Exchange(0, 4130001, -1, 4021000, -3, 4021006, -1, 4000021, -30, 4000030, -15, 4003000, -20);
			else if (index == 106) trade = Exchange(0, 4130001, -1, 4021008, -2, 4021006, -1, 4000021, -40, 4000030, -25, 4003000, -20);
			else if (index == 107) trade = Exchange(0, 4130001, -1, 4021000, -4, 4000030, -40, 4000043, -35, 4003000, -25);
			else if (index == 108) trade = Exchange(0, 4130001, -1, 4021005, -4, 4000030, -40, 4000037, -70, 4003000, -25);
			else if (index == 109) trade = Exchange(0, 4130001, -1, 4011006, -2, 4021007, -1, 4000030, -40, 4000027, -20, 4003000, -25);
			else if (index == 110) trade = Exchange(0, 4130001, -1, 4021008, -2, 4021007, -1, 4000030, -40, 4000014, -30, 4003000, -30);
			else if (index == 111) trade = Exchange(0, 4130001, -1, 4021009, -1, 4011006, -3, 4021000, -3, 4000030, -60, 4003000, -40);
			else if (index == 112) trade = Exchange(0, 4130001, -1, 4021009, -1, 4011006, -3, 4021005, -3, 4000030, -60, 4003000, -40);
			else if (index == 113) trade = Exchange(0, 4130001, -1, 4021009, -1, 4011006, -3, 4021001, -3, 4000030, -60, 4003000, -40);
			else if (index == 114) trade = Exchange(0, 4130001, -1, 4021009, -1, 4011006, -3, 4021003, -3, 4000030, -60, 4003000, -40);
			
			// failure to create bowman shoes
			else if (index == 200) trade = Exchange(0, 4130001, -1, 4021000, -2, 4000021, -50, 4003000, -15);
			else if (index == 201) trade = Exchange(0, 4130001, -1, 4021005, -2, 4000021, -50, 4003000, -15);
			else if (index == 202) trade = Exchange(0, 4130001, -1, 4021003, -2, 4000021, -50, 4003000, -15);
			else if (index == 203) trade = Exchange(0, 4130001, -1, 4021004, -2, 4000021, -50, 4003000, -15);
			else if (index == 204) trade = Exchange(0, 4130001, -1, 4021006, -2, 4000021, -50, 4003000, -15);
			else if (index == 205) trade = Exchange(0, 4130001, -1, 4021002, -3, 4021006, -1, 4000021, -30, 4000030, -15, 4003000, -20);
			else if (index == 206) trade = Exchange(0, 4130001, -1, 4021003, -3, 4021006, -1, 4000021, -30, 4000030, -15, 4003000, -20);
			else if (index == 207) trade = Exchange(0, 4130001, -1, 4021000, -3, 4021006, -1, 4000021, -30, 4000030, -15, 4003000, -20);
			else if (index == 208) trade = Exchange(0, 4130001, -1, 4021000, -4, 4000030, -45, 4000024, -40, 4003000, -30);
			else if (index == 209) trade = Exchange(0, 4130001, -1, 4021006, -4, 4000030, -45, 4000027, -20, 4003000, -30);
			else if (index == 210) trade = Exchange(0, 4130001, -1, 4011003, -5, 4000030, -45, 4000044, -40, 4003000, -30);
			else if (index == 211) trade = Exchange(0, 4130001, -1, 4021002, -5, 4000030, -45, 4000009, -120, 4003000, -30);
			else if (index == 212) trade = Exchange(0, 4130001, -1, 4021008, -1, 4011001, -3, 4021006, -3, 4000030, -60, 4000033, -80, 4003000, -35);
			else if (index == 213) trade = Exchange(0, 4130001, -1, 4021008, -1, 4011001, -3, 4021006, -3, 4000030, -60, 4000032, -150, 4003000, -35);
			else if (index == 214) trade = Exchange(0, 4130001, -1, 4021008, -1, 4011001, -3, 4021006, -3, 4000030, -60, 4000041, -100, 4003000, -35);
			else if (index == 215) trade = Exchange(0, 4130001, -1, 4021008, -1, 4011001, -3, 4021006, -3, 4000030, -60, 4000042, -250, 4003000, -35);
			
			// failure to create thief shoes
			else if (index == 300) trade = Exchange(0, 4130001, -1, 4011000, -3, 4000021, -50, 4003000, -15);
			else if (index == 301) trade = Exchange(0, 4130001, -1, 4011001, -3, 4000021, -50, 4003000, -15);
			else if (index == 302) trade = Exchange(0, 4130001, -1, 4011004, -2, 4000021, -50, 4003000, -15);
			else if (index == 303) trade = Exchange(0, 4130001, -1, 4011006, -2, 4000021, -50, 4003000, -15);
			else if (index == 304) trade = Exchange(0, 4130001, -1, 4021000, -3, 4021004, -1, 4000021, -30, 4000030, -15, 4003000, -20);
			else if (index == 305) trade = Exchange(0, 4130001, -1, 4021003, -3, 4021004, -1, 4000021, -30, 4000030, -15, 4003000, -20);
			else if (index == 306) trade = Exchange(0, 4130001, -1, 4021002, -3, 4021004, -1, 4000021, -30, 4000030, -15, 4003000, -20);
			else if (index == 307) trade = Exchange(0, 4130001, -1, 4021003, -4, 4000030, -45, 4000032, -30, 4003000, -30);
			else if (index == 308) trade = Exchange(0, 4130001, -1, 4021006, -4, 4000030, -45, 4000040, -3, 4003000, -30);
			else if (index == 309) trade = Exchange(0, 4130001, -1, 4021005, -4, 4000030, -45, 4000037, -70, 4003000, -30);
			else if (index == 310) trade = Exchange(0, 4130001, -1, 4021000, -5, 4000030, -45, 4000033, -50, 4003000, -30);
			else if (index == 311) trade = Exchange(0, 4130001, -1, 4011007, -2, 4021005, -3, 4000030, -50, 4000037, -200, 4003000, -35);
			else if (index == 312) trade = Exchange(0, 4130001, -1, 4011007, -2, 4021003, -3, 4000030, -50, 4000045, -80, 4003000, -35);
			else if (index == 313) trade = Exchange(0, 4130001, -1, 4011007, -2, 4021000, -3, 4000030, -50, 4000043, -150, 4003000, -35);
			else if (index == 314) trade = Exchange(0, 4130001, -1, 4011007, -2, 4021001, -3, 4000030, -50, 4000036, -80, 4003000, -35);
			
			if (!trade)
			{
				self.say("Please check if you have all the necessary items with you. If so, check your Equip. inventory, it may be full.");
				return;
			}
				
			self.say("Darn... I must have stimulated it too much... All the items are gone now... I'm sorry. I warned you about the possibility of this happening and I hope that you can understand.");
		}
		else
		{
			// successfully creating warrior shoes
			if (index == 0) trade = ExchangeEx(-20000, "4130001", -1, "4021003", -4, "4011001", -2, "4000021", -45, "4003000", -15, "1072003,Variation:1", 1);
			else if (index == 1) trade = ExchangeEx(-20000, "4130001", -1, "4011002", -4, "4011001", -2, "4000021", -45, "4003000", -15, "1072039,Variation:1", 1);
			else if (index == 2) trade = ExchangeEx(-20000, "4130001", -1, "4011004", -4, "4011001", -2, "4000021", -45, "4003000", -15, "1072040,Variation:1", 1);
			else if (index == 3) trade = ExchangeEx(-20000, "4130001", -1, "4021000", -4, "4011001", -2, "4000021", -45, "4003000", -15, "1072041,Variation:1", 1);
			else if (index == 4) trade = ExchangeEx(-22000, "4130001", -1, "4011001", -3, "4021004", -1, "4000021", -30, "4000030", -20, "4003000", -25, "1072002,Variation:1", 1);
			else if (index == 5) trade = ExchangeEx(-22000, "4130001", -1, "4011002", -3, "4021004", -1, "4000021", -30, "4000030", -20, "4003000", -25, "1072112,Variation:1", 1);
			else if (index == 6) trade = ExchangeEx(-25000, "4130001", -1, "4021008", -2, "4021004", -1, "4000021", -30, "4000030", -20, "4003000", -25, "1072113,Variation:1", 1);
			else if (index == 7) trade = ExchangeEx(-38000, "4130001", -1, "4011003", -4, "4000021", -100, "4000030", -40, "4003000", -30, "4000103", -100, "1072000,Variation:1", 1);
			else if (index == 8) trade = ExchangeEx(-38000, "4130001", -1, "4011005", -4, "4021007", -1, "4000030", -40, "4003000", -30, "4000104", -100, "1072126,Variation:1", 1);
			else if (index == 9) trade = ExchangeEx(-38000, "4130001", -1, "4011002", -4, "4021007", -1, "4000030", -40, "4003000", -30, "4000105", -100, "1072127,Variation:1", 1);
			else if (index == 10) trade = ExchangeEx(-50000, "4130001", -1, "4021008", -1, "4011001", -3, "4021003", -6, "4000030", -65, "4003000", -45, "1072132,Variation:1", 1);
			else if (index == 11) trade = ExchangeEx(-50000, "4130001", -1, "4021008", -1, "4011001", -3, "4011002", -6, "4000030", -65, "4003000", -45, "1072133,Variation:1", 1);
			else if (index == 12) trade = ExchangeEx(-50000, "4130001", -1, "4021008", -1, "4011001", -3, "4011005", -6, "4000030", -65, "4003000", -45, "1072134,Variation:1", 1);
			else if (index == 13) trade = ExchangeEx(-50000, "4130001", -1, "4021008", -1, "4011001", -3, "4011006", -6, "4000030", -65, "4003000", -45, "1072135,Variation:1", 1);
			
			// successfully creating  magician shoes
			else if (index == 100) trade = ExchangeEx(-18000, "4130001", -1, "4021000", -2, "4000021", -50, "4003000", -15, "1072075,Variation:1", 1);
			else if (index == 101) trade = ExchangeEx(-18000, "4130001", -1, "4021002", -2, "4000021", -50, "4003000", -15, "1072076,Variation:1", 1);
			else if (index == 102) trade = ExchangeEx(-18000, "4130001", -1, "4011004", -2, "4000021", -50, "4003000", -15, "1072077,Variation:1", 1);
			else if (index == 103) trade = ExchangeEx(-18000, "4130001", -1, "4021008", -1, "4000021", -50, "4003000", -15, "1072078,Variation:1", 1);
			else if (index == 104) trade = ExchangeEx(-20000, "4130001", -1, "4021001", -3, "4021006", -1, "4000021", -30, "4000030", -15, "4003000", -20, "1072089,Variation:1", 1);
			else if (index == 105) trade = ExchangeEx(-20000, "4130001", -1, "4021000", -3, "4021006", -1, "4000021", -30, "4000030", -15, "4003000", -20, "1072090,Variation:1", 1);
			else if (index == 106) trade = ExchangeEx(-22000, "4130001", -1, "4021008", -2, "4021006", -1, "4000021", -40, "4000030", -25, "4003000", -20, "1072091,Variation:1", 1);
			else if (index == 107) trade = ExchangeEx(-30000, "4130001", -1, "4021000", -4, "4000030", -40, "4000110", -100, "4003000", -25, "1072114,Variation:1", 1);
			else if (index == 108) trade = ExchangeEx(-30000, "4130001", -1, "4021005", -4, "4000030", -40, "4000111", -100, "4003000", -25, "1072115,Variation:1", 1);
			else if (index == 109) trade = ExchangeEx(-35000, "4130001", -1, "4011006", -2, "4021007", -1, "4000030", -40, "4000100", -100, "4003000", -25, "1072116,Variation:1", 1);
			else if (index == 110) trade = ExchangeEx(-40000, "4130001", -1, "4021008", -2, "4021007", -1, "4000030", -40, "4000112", -100, "4003000", -30, "1072117,Variation:1", 1);
			else if (index == 111) trade = ExchangeEx(-50000, "4130001", -1, "4021009", -1, "4011006", -3, "4021000", -3, "4000030", -60, "4003000", -40, "1072140,Variation:1", 1);
			else if (index == 112) trade = ExchangeEx(-50000, "4130001", -1, "4021009", -1, "4011006", -3, "4021005", -3, "4000030", -60, "4003000", -40, "1072141,Variation:1", 1);
			else if (index == 113) trade = ExchangeEx(-50000, "4130001", -1, "4021009", -1, "4011006", -3, "4021001", -3, "4000030", -60, "4003000", -40, "1072142,Variation:1", 1);
			else if (index == 114) trade = ExchangeEx(-50000, "4130001", -1, "4021009", -1, "4011006", -3, "4021003", -3, "4000030", -60, "4003000", -40, "1072143,Variation:1", 1);
			
			// successfully creating bowman shoes
			else if (index == 200) trade = ExchangeEx(-19000, "4130001", -1, "4021000", -2, "4000021", -50, "4003000", -15, "1072079,Variation:1", 1);
			else if (index == 201) trade = ExchangeEx(-19000, "4130001", -1, "4021005", -2, "4000021", -50, "4003000", -15, "1072080,Variation:1", 1);
			else if (index == 202) trade = ExchangeEx(-19000, "4130001", -1, "4021003", -2, "4000021", -50, "4003000", -15, "1072081,Variation:1", 1);
			else if (index == 203) trade = ExchangeEx(-19000, "4130001", -1, "4021004", -2, "4000021", -50, "4003000", -15, "1072082,Variation:1", 1);
			else if (index == 204) trade = ExchangeEx(-19000, "4130001", -1, "4021006", -2, "4000021", -50, "4003000", -15, "1072083,Variation:1", 1);
			else if (index == 205) trade = ExchangeEx(-20000, "4130001", -1, "4021002", -3, "4021006", -1, "4000021", -30, "4000030", -15, "4003000", -20, "1072101,Variation:1", 1);
			else if (index == 206) trade = ExchangeEx(-20000, "4130001", -1, "4021003", -3, "4021006", -1, "4000021", -30, "4000030", -15, "4003000", -20, "1072102,Variation:1", 1);
			else if (index == 207) trade = ExchangeEx(-20000, "4130001", -1, "4021000", -3, "4021006", -1, "4000021", -30, "4000030", -15, "4003000", -20, "1072103,Variation:1", 1);
			else if (index == 208) trade = ExchangeEx(-32000, "4130001", -1, "4021000", -4, "4000030", -45, "4000106", -100, "4003000", -30, "1072118,Variation:1", 1);
			else if (index == 209) trade = ExchangeEx(-32000, "4130001", -1, "4021006", -4, "4000030", -45, "4000107", -100, "4003000", -30, "1072119,Variation:1", 1);
			else if (index == 210) trade = ExchangeEx(-40000, "4130001", -1, "4011003", -5, "4000030", -45, "4000108", -100, "4003000", -30, "1072120,Variation:1", 1);
			else if (index == 211) trade = ExchangeEx(-40000, "4130001", -1, "4021002", -5, "4000030", -45, "4000099", -100, "4003000", -30, "1072121,Variation:1", 1);
			else if (index == 212) trade = ExchangeEx(-50000, "4130001", -1, "4021008", -1, "4011001", -3, "4021006", -3, "4000030", -60, "4000033", -80, "4003000", -35, "1072122,Variation:1", 1);
			else if (index == 213) trade = ExchangeEx(-50000, "4130001", -1, "4021008", -1, "4011001", -3, "4021006", -3, "4000030", -60, "4000032", -150, "4003000", -35, "1072123,Variation:1", 1);
			else if (index == 214) trade = ExchangeEx(-50000, "4130001", -1, "4021008", -1, "4011001", -3, "4021006", -3, "4000030", -60, "4000041", -100, "4003000", -35, "1072124,Variation:1", 1);
			else if (index == 215) trade = ExchangeEx(-50000, "4130001", -1, "4021008", -1, "4011001", -3, "4021006", -3, "4000030", -60, "4000042", -250, "4003000", -35, "1072125,Variation:1", 1);
			
			// successfully creating thief shoes 
			else if (index == 300) trade = ExchangeEx(-19000, "4130001", -1, "4011000", -3, "4000021", -50, "4003000", -15, "1072032,Variation:1", 1);
			else if (index == 301) trade = ExchangeEx(-19000, "4130001", -1, "4011001", -3, "4000021", -50, "4003000", -15, "1072033,Variation:1", 1);
			else if (index == 302) trade = ExchangeEx(-19000, "4130001", -1, "4011004", -2, "4000021", -50, "4003000", -15, "1072035,Variation:1", 1);
			else if (index == 303) trade = ExchangeEx(-21000, "4130001", -1, "4011006", -2, "4000021", -50, "4003000", -15, "1072036,Variation:1", 1);
			else if (index == 304) trade = ExchangeEx(-20000, "4130001", -1, "4021000", -3, "4021004", -1, "4000021", -30, "4000030", -15, "4003000", -20, "1072104,Variation:1", 1);
			else if (index == 305) trade = ExchangeEx(-20000, "4130001", -1, "4021003", -3, "4021004", -1, "4000021", -30, "4000030", -15, "4003000", -20, "1072105,Variation:1", 1);
			else if (index == 306) trade = ExchangeEx(-20000, "4130001", -1, "4021002", -3, "4021004", -1, "4000021", -30, "4000030", -15, "4003000", -20, "1072106,Variation:1", 1);
			else if (index == 307) trade = ExchangeEx(-32000, "4130001", -1, "4021003", -4, "4000030", -45, "4000095", -100, "4003000", -30, "1072108,Variation:1", 1);
			else if (index == 308) trade = ExchangeEx(-35000, "4130001", -1, "4021006", -4, "4000030", -45, "4000096", -100, "4003000", -30, "1072109,Variation:1", 1);
			else if (index == 309) trade = ExchangeEx(-35000, "4130001", -1, "4021005", -4, "4000030", -45, "4000097", -100, "4003000", -30, "1072110,Variation:1", 1);
			else if (index == 310) trade = ExchangeEx(-40000, "4130001", -1, "4021000", -5, "4000030", -45, "4000113", -100, "4003000", -30, "1072107,Variation:1", 1);
			else if (index == 311) trade = ExchangeEx(-50000, "4130001", -1, "4011007", -2, "4021005", -3, "4000030", -50, "4000114", -100, "4003000", -35, "1072128,Variation:1", 1);
			else if (index == 312) trade = ExchangeEx(-50000, "4130001", -1, "4011007", -2, "4021003", -3, "4000030", -50, "4000109", -100, "4003000", -35, "1072129,Variation:1", 1);
			else if (index == 313) trade = ExchangeEx(-50000, "4130001", -1, "4011007", -2, "4021000", -3, "4000030", -50, "4000115", -100, "4003000", -35, "1072130,Variation:1", 1);
			else if (index == 314) trade = ExchangeEx(-50000, "4130001", -1, "4011007", -2, "4021001", -3, "4000030", -50, "4000036", -80, "4003000", -35, "1072131,Variation:1", 1);
			
			if (!trade)
			{
				self.say("Please check if you have all the necessary items with you. If so, check your equip. inventory, it may be full.");
				return;
			}
				
			self.say($"Here, take this, the {makeItem}! Everything worked out, it's much more powerful than a normal pair of shoes. I hope to see you again~");
		}
	}
	
	private void Craft2(int index, string makeItem, string needItem, int reqLevel, string itemOption)
	{
		bool askBuy = AskYesNo($"To make a(n) {makeItem}, you will need the following materials. The level limit will be {reqLevel}, so please see if you really need this item. Do you want me to do it?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("I understand. If you want to catch the item of the hour, just stop by here! I'll be here waiting!");
			return;
		}
		
		bool trade = false;
		
		// warrior shoes
		if (index == 0) trade = Exchange(-18000, 4021003, -4, 4011001, -2, 4000021, -45, 4003000, -15, 1072003, 1);
		else if (index == 1) trade = Exchange(-18000, 4011002, -4, 4011001, -2, 4000021, -45, 4003000, -15, 1072039, 1);
		else if (index == 2) trade = Exchange(-18000, 4011004, -4, 4011001, -2, 4000021, -45, 4003000, -15, 1072040, 1);
		else if (index == 3) trade = Exchange(-18000, 4021000, -4, 4011001, -2, 4000021, -45, 4003000, -15, 1072041, 1);
		else if (index == 4) trade = Exchange(-19800, 4011001, -3, 4021004, -1, 4000021, -30, 4000030, -20, 4003000, -25, 1072002, 1);
		else if (index == 5) trade = Exchange(-19800, 4011002, -3, 4021004, -1, 4000021, -30, 4000030, -20, 4003000, -25, 1072112, 1);
		else if (index == 6) trade = Exchange(-22500, 4021008, -2, 4021004, -1, 4000021, -30, 4000030, -20, 4003000, -25, 1072113, 1);
		else if (index == 7) trade = Exchange(-34200, 4011003, -4, 4000021, -100, 4000030, -40, 4003000, -30, 4000103, -100, 1072000, 1);
		else if (index == 8) trade = Exchange(-34200, 4011005, -4, 4021007, -1, 4000030, -40, 4003000, -30, 4000104, -100, 1072126, 1);
		else if (index == 9) trade = Exchange(-34200, 4011002, -4, 4021007, -1, 4000030, -40, 4003000, -30, 4000105, -100, 1072127, 1);
		else if (index == 10) trade = Exchange(-45000, 4021008, -1, 4011001, -3, 4021003, -6, 4000030, -65, 4003000, -45, 1072132, 1);
		else if (index == 11) trade = Exchange(-45000, 4021008, -1, 4011001, -3, 4011002, -6, 4000030, -65, 4003000, -45, 1072133, 1);
		else if (index == 12) trade = Exchange(-45000, 4021008, -1, 4011001, -3, 4011005, -6, 4000030, -65, 4003000, -45, 1072134, 1);
		else if (index == 13) trade = Exchange(-45000, 4021008, -1, 4011001, -3, 4011006, -6, 4000030, -65, 4003000, -45, 1072135, 1);
		
		// magician shoes
		else if (index == 100) trade = Exchange(-16200, 4021000, -2, 4000021, -50, 4003000, -15, 1072075, 1);
		else if (index == 101) trade = Exchange(-16200, 4021002, -2, 4000021, -50, 4003000, -15, 1072076, 1);
		else if (index == 102) trade = Exchange(-16200, 4011004, -2, 4000021, -50, 4003000, -15, 1072077, 1);
		else if (index == 103) trade = Exchange(-16200, 4021008, -1, 4000021, -50, 4003000, -15, 1072078, 1);
		else if (index == 104) trade = Exchange(-18000, 4021001, -3, 4021006, -1, 4000021, -30, 4000030, -15, 4003000, -20, 1072089, 1);
		else if (index == 105) trade = Exchange(-18000, 4021000, -3, 4021006, -1, 4000021, -30, 4000030, -15, 4003000, -20, 1072090, 1);
		else if (index == 106) trade = Exchange(-19800, 4021008, -2, 4021006, -1, 4000021, -40, 4000030, -25, 4003000, -20, 1072091, 1);
		else if (index == 107) trade = Exchange(-27000, 4021000, -4, 4000030, -40, 4000110, -100, 4003000, -25, 1072114, 1);
		else if (index == 108) trade = Exchange(-27000, 4021005, -4, 4000030, -40, 4000111, -100, 4003000, -25, 1072115, 1);
		else if (index == 109) trade = Exchange(-31500, 4011006, -2, 4021007, -1, 4000030, -40, 4000100, -100, 4003000, -25, 1072116, 1);
		else if (index == 110) trade = Exchange(-36000, 4021008, -2, 4021007, -1, 4000030, -40, 4000112, -100, 4003000, -30, 1072117, 1);
		else if (index == 111) trade = Exchange(-45000, 4021009, -1, 4011006, -3, 4021000, -3, 4000030, -60, 4003000, -40, 1072140, 1);
		else if (index == 112) trade = Exchange(-45000, 4021009, -1, 4011006, -3, 4021005, -3, 4000030, -60, 4003000, -40, 1072141, 1);
		else if (index == 113) trade = Exchange(-45000, 4021009, -1, 4011006, -3, 4021001, -3, 4000030, -60, 4003000, -40, 1072142, 1);
		else if (index == 114) trade = Exchange(-45000, 4021009, -1, 4011006, -3, 4021003, -3, 4000030, -60, 4003000, -40, 1072143, 1);
		
		// bowman shoes
		else if (index == 200) trade = Exchange(-17100, 4021000, -2, 4000021, -50, 4003000, -15, 1072079, 1);
		else if (index == 201) trade = Exchange(-17100, 4021005, -2, 4000021, -50, 4003000, -15, 1072080, 1);
		else if (index == 202) trade = Exchange(-17100, 4021003, -2, 4000021, -50, 4003000, -15, 1072081, 1);
		else if (index == 203) trade = Exchange(-17100, 4021004, -2, 4000021, -50, 4003000, -15, 1072082, 1);
		else if (index == 204) trade = Exchange(-17100, 4021006, -2, 4000021, -50, 4003000, -15, 1072083, 1);
		else if (index == 205) trade = Exchange(-18000, 4021002, -3, 4021006, -1, 4000021, -30, 4000030, -15, 4003000, -20, 1072101, 1);
		else if (index == 206) trade = Exchange(-18000, 4021003, -3, 4021006, -1, 4000021, -30, 4000030, -15, 4003000, -20, 1072102, 1);
		else if (index == 207) trade = Exchange(-18000, 4021000, -3, 4021006, -1, 4000021, -30, 4000030, -15, 4003000, -20, 1072103, 1);
		else if (index == 208) trade = Exchange(-28800, 4021000, -4, 4000030, -45, 4000106, -100, 4003000, -30, 1072118, 1);
		else if (index == 209) trade = Exchange(-28800, 4021006, -4, 4000030, -45, 4000107, -100, 4003000, -30, 1072119, 1);
		else if (index == 210) trade = Exchange(-36000, 4011003, -5, 4000030, -45, 4000108, -100, 4003000, -30, 1072120, 1);
		else if (index == 211) trade = Exchange(-36000, 4021002, -5, 4000030, -45, 4000099, -100, 4003000, -30, 1072121, 1);
		else if (index == 212) trade = Exchange(-45000, 4021008, -1, 4011001, -3, 4021006, -3, 4000030, -60, 4000033, -80, 4003000, -35, 1072122, 1);
		else if (index == 213) trade = Exchange(-45000, 4021008, -1, 4011001, -3, 4021006, -3, 4000030, -60, 4000032, -150, 4003000, -35, 1072123, 1);
		else if (index == 214) trade = Exchange(-45000, 4021008, -1, 4011001, -3, 4021006, -3, 4000030, -60, 4000041, -100, 4003000, -35, 1072124, 1);
		else if (index == 215) trade = Exchange(-45000, 4021008, -1, 4011001, -3, 4021006, -3, 4000030, -60, 4000042, -250, 4003000, -35, 1072125, 1);
		
		// thief shoes
		else if (index == 300) trade = Exchange(-17100, 4011000, -3, 4000021, -50, 4003000, -15, 1072032, 1);
		else if (index == 301) trade = Exchange(-17100, 4011001, -3, 4000021, -50, 4003000, -15, 1072033, 1);
		else if (index == 302) trade = Exchange(-17100, 4011004, -2, 4000021, -50, 4003000, -15, 1072035, 1);
		else if (index == 303) trade = Exchange(-18900, 4011006, -2, 4000021, -50, 4003000, -15, 1072036, 1);
		else if (index == 304) trade = Exchange(-18000, 4021000, -3, 4021004, -1, 4000021, -30, 4000030, -15, 4003000, -20, 1072104, 1);
		else if (index == 305) trade = Exchange(-18000, 4021003, -3, 4021004, -1, 4000021, -30, 4000030, -15, 4003000, -20, 1072105, 1);
		else if (index == 306) trade = Exchange(-18000, 4021002, -3, 4021004, -1, 4000021, -30, 4000030, -15, 4003000, -20, 1072106, 1);
		else if (index == 307) trade = Exchange(-28800, 4021003, -4, 4000030, -45, 4000095, -100, 4003000, -30, 1072108, 1);
		else if (index == 308) trade = Exchange(-31500, 4021006, -4, 4000030, -45, 4000096, -100, 4003000, -30, 1072109, 1);
		else if (index == 309) trade = Exchange(-31500, 4021005, -4, 4000030, -45, 4000097, -100, 4003000, -30, 1072110, 1);
		else if (index == 310) trade = Exchange(-36000, 4021000, -5, 4000030, -45, 4000113, -100, 4003000, -30, 1072107, 1);
		else if (index == 311) trade = Exchange(-45000, 4011007, -2, 4021005, -3, 4000030, -50, 4000114, -100, 4003000, -35, 1072128, 1);
		else if (index == 312) trade = Exchange(-45000, 4011007, -2, 4021003, -3, 4000030, -50, 4000109, -100, 4003000, -35, 1072129, 1);
		else if (index == 313) trade = Exchange(-45000, 4011007, -2, 4021000, -3, 4000030, -50, 4000115, -100, 4003000, -35, 1072130, 1);
		else if (index == 314) trade = Exchange(-45000, 4011007, -2, 4021001, -3, 4000030, -50, 4000036, -80, 4003000, -35, 1072131, 1);
		
		if (!trade)
		{
			self.say("Please check if you have all the necessary items with you. If so, check your equip. inventory, it may be full.");
			return;
		}
			
		self.say($"Here, take the item you ordered {makeItem}. I think it turned out pretty cool!! Don't you think so too? Please come back again whenever you want!");
	}
	
	public override void Run()
	{
		bool askStart = AskYesNo("Well, well. Hi! I've been working all day, haven't even had lunch yet, just to make these shoes. I'm dying of hunger, but my business is doing well, so I can't even complain. If you're searching for a good pair of shoes, you came to the perfect place. How about you let me make a pair for you?");
		
		if (!askStart)
		{
			self.say("I'm different from all the shoemakers in the area. The special shoes that I make, only I can make. If you change your mind, just stop by.");
			return;
		}
		
		int craftType = AskMenu("Oh, it can be a little expensive, but I'm sure you understand. What do you want to make?#b",
			(0, " What is a stimulator?"),
			(1, " Create warrior shoes with a stimulator"),
			(2, " Create magician shoes with a stimulator"),
			(3, " Create bowman shoes with a stimulator"),
			(4, " Create thief shoes with a stimulator\r\n"),
			(5, " Create normal warrior shoes"),
			(6, " Create normal magician shoes"),
			(7, " Create normal bowman shoes"),
			(8, " Create normal thief shoes"));
		
		if (craftType == 0)
		{
			self.say("In Ludibrium, many items can be made using a #bstimulator#k. It's a mysterious potion that is included in the process of creating a pair of shoes, and after being used, the shoes will be created with a small variation in the armor's stats, as if you had received the shoes from a monster. The stimulator can then be used not only on shoes, but also on other items. Make sure to carry lots of them with you, because there are different types of stimulators available for different types of shoes.");
			self.say("But you should be aware of some things. If the stimulator is used, it's very likely that the item's stats will be altered, and the problem with that is the result can #bend up being worse#k, much worse than the original. You also run the risk of a \r\n#b10% rate of failure when creating the item#k, which means saying goodbye to the items you used to make the item in question. It sucks, right?");
			self.say("Even with these risks involved, many travelers seek my help to make the perfect pairs of shoes using the stimulator. The thought of the item being of poor quality, becoming worse than it was or even disappearing may scare you, but how about trying it anyway? If you're lucky, your item could be a marvel. That's all I can tell you.");
		}
		else if (craftType == 1)
		{
			int craftSelect = AskMenu("Which pair of warrior shoes do you want to upgrade using the stimulator?",
				(0, " #b#t1072003##k(level limit: 30, warrior)"),
				(1, " #b#t1072039##k(level limit: 30, warrior)"),
				(2, " #b#t1072040##k(level limit: 30, warrior)"),
				(3, " #b#t1072041##k(level limit: 30, warrior)"),
				(4, " #b#t1072002##k(level limit: 35, warrior)"),
				(5, " #b#t1072112##k(level limit: 35, warrior)"),
				(6, " #b#t1072113##k(level limit: 35, warrior)"),
				(7, " #b#t1072000##k(level limit: 40, warrior)"),
				(8, " #b#t1072126##k(level limit: 40, warrior)"),
				(9, " #b#t1072127##k(level limit: 40, warrior)"),
				(10, " #b#t1072132##k(level limit: 50, warrior)"),
				(11, " #b#t1072133##k(level limit: 50, warrior)"),
				(12, " #b#t1072134##k(level limit: 50, warrior)"),
				(13, " #b#t1072135##k(level limit: 50, warrior)"));
				
			if (craftSelect == 0) Craft1(0, "#t1072003#", "#v4130001# #t4130001#\r\n#v4021003# 4 #t4021003#s\r\n#v4011001# 2 #t4011001#s\r\n#v4000021# 45 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n20000 mesos", 30, "STR +1");
			else if (craftSelect == 1) Craft1(1, "#t1072039#", "#v4130001# #t4130001#\r\n#v4011002# 4 #t4011002#s\r\n#v4011001# 2 #t4011001#s\r\n#v4000021# 45 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n20000 mesos", 30, "DEX +1");
			else if (craftSelect == 2) Craft1(2, "#t1072040#", "#v4130001# #t4130001#\r\n#v4011004# 4 #t4011004#s\r\n#v4011001# 2 #t4011001#s\r\n#v4000021# 45 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n20000 mesos", 30, "STR +1");
			else if (craftSelect == 3) Craft1(3, "#t1072041#", "#v4130001# #t4130001#\r\n#v4021000# 4 #t4021000#s\r\n#v4011001# 2 #t4011001#s\r\n#v4000021# 45 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n20000 mesos", 30, "DEX +1");
			else if (craftSelect == 4) Craft1(4, "#t1072002#", "#v4130001# #t4130001#\r\n#v4011001# 3 #t4011001#s\r\n#v4021004# #t4021004#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 20 #t4000030#s\r\n#v4003000# 25 #t4003000#s\r\n22000 mesos", 35, "STR +1, MP +10");
			else if (craftSelect == 5) Craft1(5, "#t1072112#", "#v4130001# #t4130001#\r\n#v4011002# 3 #t4011002#s\r\n#v4021004# #t4021004#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 20 #t4000030#s\r\n#v4003000# 25 #t4003000#s\r\n22000 mesos", 35, "DEX +1, MP +10");
			else if (craftSelect == 6) Craft1(6, "#t1072113#", "#v4130001# #t4130001#\r\n#v4021008# 2 #t4021008#s\r\n#v4021004# #t4021004#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 20 #t4000030#s\r\n#v4003000# 25 #t4003000#s\r\n25000 mesos", 35, "STR +1, DEX +1, MP +10");
			else if (craftSelect == 7) Craft1(7, "#t1072000#", "#v4130001# #t4130001#\r\n#v4011003# 4 #t4011003#s\r\n#v4000021# 100 #t4000021#s\r\n#v4000030# 40 #t4000030#s\r\n#v4003000# 30 #t4003000#s\r\n#v4000103# 100 #t4000103#s\r\n38000 mesos", 40, "DEX +2, MP +20");
			else if (craftSelect == 8) Craft1(8, "#t1072126#", "#v4130001# #t4130001#\r\n#v4011005# 4 #t4011005#s\r\n#v4021007# #t4021007#\r\n#v4000030# 40 #t4000030#s\r\n#v4003000# 30 #t4003000#s\r\n#v4000104# 100 #t4000104#s\r\n38000 mesos", 40, "STR +1, DEX +1, MP +20");
			else if (craftSelect == 9) Craft1(9, "#t1072127#", "#v4130001# #t4130001#\r\n#v4011002# 4 #t4011002#s\r\n#v4021007# #t4021007#\r\n#v4000030# 40 #t4000030#s\r\n#v4003000# 30 #t4003000#s\r\n#v4000105# 100 #t4000105#s\r\n38000 mesos", 40, "STR +2, MP +20");
			else if (craftSelect == 10) Craft1(10, "#t1072132#", "#v4130001# #t4130001#\r\n#v4021008# #t4021008#\r\n#v4011001# 3 #t4011001#s\r\n#v4021003# 6 #t4021003#s\r\n#v4000030# 65 #t4000030#s\r\n#v4003000# 45 #t4003000#s\r\n50000 mesos", 50, "DEX +3");
			else if (craftSelect == 11) Craft1(11, "#t1072133#", "#v4130001# #t4130001#\r\n#v4021008# #t4021008#\r\n#v4011001# 3 #t4011001#s\r\n#v4011002# 6 #t4011002#s\r\n#v4000030# 65 #t4000030#s\r\n#v4003000# 45 #t4003000#s\r\n50000 mesos", 50, "DEX + 2, STR + 1");
			else if (craftSelect == 12) Craft1(12, "#t1072134#", "#v4130001# #t4130001#\r\n#v4021008# #t4021008#\r\n#v4011001# 3 #t4011001#s\r\n#v4011005# 6 #t4011005#s\r\n#v4000030# 65 #t4000030#s\r\n#v4003000# 45 #t4003000#s\r\n50000 mesos", 50, "DEX + 1, STR + 2");
			else if (craftSelect == 13) Craft1(13, "#t1072135#", "#v4130001# #t4130001#\r\n#v4021008# #t4021008#\r\n#v4011001# 3 #t4011001#s\r\n#v4011006# 6 #t4011006#s\r\n#v4000030# 65 #t4000030#s\r\n#v4003000# 45 #t4003000#s\r\n50000 mesos", 50, "STR +3");
		}
		else if (craftType == 2)
		{
			int craftSelect = AskMenu("Which pair of magician shoes do you want to upgrade using the stimulator?",
				(0, " #b#t1072075##k(level limit: 30, magician)"),
				(1, " #b#t1072076##k(level limit: 30, magician)"),
				(2, " #b#t1072077##k(level limit: 30, magician)"),
				(3, " #b#t1072078##k(level limit: 30, magician)"),
				(4, " #b#t1072089##k(level limit: 35, magician)"),
				(5, " #b#t1072090##k(level limit: 35, magician)"),
				(6, " #b#t1072091##k(level limit: 35, magician)"),
				(7, " #b#t1072114##k(level limit: 40, magician)"),
				(8, " #b#t1072115##k(level limit: 40, magician)"),
				(9, " #b#t1072116##k(level limit: 40, magician)"),
				(10, " #b#t1072117##k(level limit: 40, magician)"),
				(11, " #b#t1072140##k(level limit: 50, magician)"),
				(12, " #b#t1072141##k(level limit: 50, magician)"),
				(13, " #b#t1072142##k(level limit: 50, magician)"),
				(14, " #b#t1072143##k(level limit: 50, magician)"));
				
			if (craftSelect == 0) Craft1(100, "#t1072075#", "#v4130001# #t4130001#\r\n#v4021000# 2 #t4021000#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n18000 mesos", 30, "INT +1");
			else if (craftSelect == 1) Craft1(101, "#t1072076#", "#v4130001# #t4130001#\r\n#v4021002# 2 #t4021002#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n18000 mesos", 30, "INT +1");
			else if (craftSelect == 2) Craft1(102, "#t1072077#", "#v4130001# #t4130001#\r\n#v4011004# 2 #t4011004#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n18000 mesos", 30, "INT +1");
			else if (craftSelect == 3) Craft1(103, "#t1072078#", "#v4130001# #t4130001#\r\n#v4021008# #t4021008#\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n18000 mesos", 30, "INT +2");
			else if (craftSelect == 4) Craft1(104, "#t1072089#", "#v4130001# #t4130001#\r\n#v4021001# 3 #t4021001#s\r\n#v4021006# #t4021006#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 15 #t4000030#s\r\n#v4003000 20 #t4003000#s\r\n20000 mesos", 35, "LUK +1, MP +10");
			else if (craftSelect == 5) Craft1(105, "#t1072090#", "#v4130001# #t4130001#\r\n#v4021000# 3 #t4021000#s\r\n#v4021006# #t4021006#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 15 #t4000030#s\r\n#v4003000# 20 #t4003000#s\r\n20000 mesos", 35, "INT +1, MP +10");
			else if (craftSelect == 6) Craft1(106, "#t1072091#", "#v4130001# #t4130001#\r\n#v4021008# 2 #t4021008#s\r\n#v4021006# #t4021006#\r\n#v4000021# 40 #t4000021#s\r\n#v4000030# 25 #t4000030#s\r\n#v4003000# 20 #t4003000#s\r\n22000 mesos", 35, "INT +1, LUK +1");
			else if (craftSelect == 7) Craft1(107, "#t1072114#", "#v4130001# #t4130001#\r\n#v4021000# 4 #t4021000#s\r\n#v4000030# 40 #t4000030#s\r\n#v4000110# 100 #t4000110#s\r\n#v4003000# 25 #t4003000#s\r\n30000 mesos", 40, "LUK +2, MP +5");
			else if (craftSelect == 8) Craft1(108, "#t1072115#", "#v4130001# #t4130001#\r\n#v4021005# 4 #t4021005#s\r\n#v4000030# 40 #t4000030#s\r\n#v4000111# 100 #t4000111#s\r\n#v4003000# 25 #t4003000#s\r\n30000 mesos", 40, "LUK +2, MP +5");
			else if (craftSelect == 9) Craft1(109, "#t1072116#", "#v4130001# #t4130001#\r\n#v4011006# 2 #t4011006#s\r\n#v4021007# #t4021007#\r\n#v4000030# 40 #t4000030#s\r\n#v4000100# 100 #t4000100#s\r\n#v4003000# 25 #t4003000#s\r\n35000 mesos", 40, "INT +2, MP +5");
			else if (craftSelect == 10) Craft1(110, "#t1072117#", "#v4130001# #t4130001#\r\n#v4021008# 2 #t4021008#s\r\n#v4021007# #t4021007#\r\n#v4000030# 40 #t4000030#s\r\n#v4000112# 100 #t4000112#s\r\n#v4003000# 30 #t4003000#s\r\n40000 mesos", 40, "INT +2, LUK +1, MP +10");
			else if (craftSelect == 11) Craft1(111, "#t1072140#", "#v4130001# #t4130001#\r\n#v4021009# #t4021009#\r\n#v4011006# 3 #t4011006#s\r\n#v4021000# 3 #t4021000#s\r\n#v4000030# 60 #t4000030#s\r\n#v4003000# 40 #t4003000#s\r\n50000 mesos", 50, "LUK +3");
			else if (craftSelect == 12) Craft1(112, "#t1072141#", "#v4130001# #t4130001#\r\n#v4021009# #t4021009#\r\n#v4011006# 3 #t4011006#s\r\n#v4021005# 3 #t4021005#s\r\n#v4000030# 60 #t4000030#s\r\n#v4003000# 40 #t4003000#s\r\n50000 mesos", 50, "INT +1, LUK +2");
			else if (craftSelect == 13) Craft1(113, "#t1072142#", "#v4130001# #t4130001#\r\n#v4021009# #t4021009#\r\n#v4011006# 3 #t4011006#s\r\n#v4021001# 3 #t4021001#s\r\n#v4000030# 60 #t4000030#s\r\n#v4003000# 40 #t4003000#s\r\n50000 mesos", 50, "INT +2, LUK +1");
			else if (craftSelect == 14) Craft1(114, "#t1072143#", "#v4130001# #t4130001#\r\n#v4021009# #t4021009#\r\n#v4011006# 3 #t4011006#s\r\n#v4021003# 3 #t4021003#s\r\n#v4000030# 60 #t4000030#s\r\n#v4003000# 40 #t4003000#s\r\n50000 mesos", 50, "INT +3");
		}
		else if (craftType == 3)
		{
			int craftSelect = AskMenu("Which pair of bowman shoes do you want to upgrade using the stimulator?",
				(0, " #b#t1072079##k(level limit: 30, bowman)"),
				(1, " #b#t1072080##k(level limit: 30, bowman)"),
				(2, " #b#t1072081##k(level limit: 30, bowman)"),
				(3, " #b#t1072082##k(level limit: 30, bowman)"),
				(4, " #b#t1072083##k(level limit: 30, bowman)"),
				(5, " #b#t1072101##k(level limit: 35, bowman)"),
				(6, " #b#t1072102##k(level limit: 35, bowman)"),
				(7, " #b#t1072103##k(level limit: 35, bowman)"),
				(8, " #b#t1072118##k(level limit: 40, bowman)"),
				(9, " #b#t1072119##k(level limit: 40, bowman)"),
				(10, " #b#t1072120##k(level limit: 40, bowman)"),
				(11, " #b#t1072121##k(level limit: 40, bowman)"),
				(12, " #b#t1072122##k(level limit: 50, bowman)"),
				(13, " #b#t1072123##k(level limit: 50, bowman)"),
				(14, " #b#t1072124##k(level limit: 50, bowman)"),
				(15, " #b#t1072125##k(level limit: 50, bowman)"));
				
			if (craftSelect == 0) Craft1(200, "#t1072079#", "#v4130001# #t4130001#\r\n#v4021000# 2 #t4021000#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n19000 mesos", 30, "DEX +1");
			else if (craftSelect == 1) Craft1(201, "#t1072080#", "#v4130001# #t4130001#\r\n#v4021005# 2 #t4021005#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n19000 mesos", 30, "STR +1");
			else if (craftSelect == 2) Craft1(202, "#t1072081#", "#v4130001# #t4130001#\r\n#v4021003# 2 #t4021003#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n19000 mesos", 30, "DEX +1");
			else if (craftSelect == 3) Craft1(203, "#t1072082#", "#v4130001# #t4130001#\r\n#v4021004# 2 #t4021004#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n19000 mesos", 30, "DEX +1");
			else if (craftSelect == 4) Craft1(204, "#t1072083#", "#v4130001# #t4130001#\r\n#v4021006# 2 #t4021006#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n19000 mesos", 30, "STR +1");
			else if (craftSelect == 5) Craft1(205, "#t1072101#", "#v4130001# #t4130001#\r\n#v4021002# 3 #t4021002#s\r\n#v4021006# #t4021006#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 15 #t4000030#s\r\n#v4003000# 20 #t4003000#s\r\n20000 mesos", 35, "STR +2");
			else if (craftSelect == 6) Craft1(206, "#t1072102#", "#v4130001# #t4130001#\r\n#v4021003# 3 #t4021003#s\r\n#v4021006# #t4021006#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 15 #t4000030#s\r\n#v4003000# 20 #t4003000#s\r\n20000 mesos", 35, "DEX +2");
			else if (craftSelect == 7) Craft1(207, "#t1072103#", "#v4130001# #t4130001#\r\n#v4021000# 3 #t4021000#s\r\n#v4021006# #t4021006#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 15 #t4000030#s\r\n#v4003000# 20 #t4003000#s\r\n20000 mesos", 35, "STR +1, DEX +1");
			else if (craftSelect == 8) Craft1(208, "#t1072118#", "#v4130001# #t4130001#\r\n#v4021000# 4 #t4021000#s\r\n#v4000030# 45 #t4000030#s\r\n#v4000106# 100 #t4000106#s\r\n#v4003000# 30 #t4003000#s\r\n32000 mesos", 40, "STR +2, MP +5");
			else if (craftSelect == 9) Craft1(209, "#t1072119#", "#v4130001# #t4130001#\r\n#v4021006# 4 #t4021006#s\r\n#v4000030# 45 #t4000030#s\r\n#v4000107# 100 #t4000107#s\r\n#v4003000# 30 #t4003000#s\r\n32000 mesos", 40, "DEX +1, STR +1, MP +5");
			else if (craftSelect == 10) Craft1(210, "#t1072120#", "#v4130001# #t4130001#\r\n#v4011003# 5 #t4011003#s\r\n#v4000030# 45 #t4000030#s\r\n#v4000108# 100 #t4000108#s\r\n#v4003000# 30 #t4003000#s\r\n40000 mesos", 40, "DEX +2, MP +5");
			else if (craftSelect == 11) Craft1(211, "#t1072121#", "#v4130001# #t4130001#\r\n#v4021002# 5 #t4021002#s\r\n#v4000030# 45 #t4000030#s\r\n#v4000099# 100 #t4000099#s\r\n#v4003000# 30 #t4003000#s\r\n40000 mesos", 40, "DEX +2, MP +5");
			else if (craftSelect == 12) Craft1(212, "#t1072122#", "#v4130001# #t4130001#\r\n#v4021008# #t4021008#\r\n#v4011001# 3 #t4011001#s\r\n#v4021006# 3 #t4021006#s\r\n#v4000030# 60 #t4000030#s\r\n#v4000033# 80 #t4000033#s\r\n#v4003000# 35 #t4003000#s\r\n50000 mesos", 50, "STR +3");
			else if (craftSelect == 13) Craft1(213, "#t1072123#", "#v4130001# #t4130001#\r\n#v4021008# #t4021008#\r\n#v4011001# 3 #t4011001#s\r\n#v4021006# 3 #t4021006#s\r\n#v4000030# 60 #t4000030#s\r\n#v4000032# 150 #t4000032#s\r\n#v4003000# 35 #t4003000#s\r\n50000 mesos", 50, "DEX +1, STR +2");
			else if (craftSelect == 14) Craft1(214, "#t1072124#", "#v4130001# #t4130001#\r\n#v4021008# #t4021008#\r\n#v4011001# 3 #t4011001#s\r\n#v4021006# 3 #t4021006#s\r\n#v4000030# 60 #t4000030#s\r\n#v4000041# 100 #t4000041#s\r\n#v4003000# 35 #t4003000#s\r\n50000 mesos", 50, "DEX +2, STR +1");
			else if (craftSelect == 15) Craft1(215, "#t1072125#", "#v4130001# #t4130001#\r\n#v4021008# #t4021008#\r\n#v4011001# 3 #t4011001#s\r\n#v4021006# 3 #t4021006#s\r\n#v4000030# 60 #t4000030#s\r\n#v4000042# 250 #t4000042#s\r\n#v4003000# 35 #t4003000#s\r\n50000 mesos", 50, "DEX +3");
		}
		else if (craftType == 4)
		{
			int craftSelect = AskMenu("Which pair of thief shoes do you want to upgrade using the stimulator?",
				(0, " #b#t1072032##k(level limit: 30, thief)"),
				(1, " #b#t1072033##k(level limit: 30, thief)"),
				(2, " #b#t1072035##k(level limit: 30, thief)"),
				(3, " #b#t1072036##k(level limit: 30, thief)"),
				(4, " #b#t1072104##k(level limit: 35, thief)"),
				(5, " #b#t1072105##k(level limit: 35, thief)"),
				(6, " #b#t1072106##k(level limit: 35, thief)"),
				(7, " #b#t1072108##k(level limit: 40, thief)"),
				(8, " #b#t1072109##k(level limit: 40, thief)"),
				(9, " #b#t1072110##k(level limit: 40, thief)"),
				(10, " #b#t1072107##k(level limit: 40, thief)"),
				(11, " #b#t1072128##k(level limit: 50, thief)"),
				(12, " #b#t1072129##k(level limit: 50, thief)"),
				(13, " #b#t1072130##k(level limit: 50, thief)"),
				(14, " #b#t1072131##k(level limit: 50, thief)"));
				
			if (craftSelect == 0) Craft1(300, "#t1072032#", "#v4130001# #t4130001#\r\n#v4011000# 3 #t4011000#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n19000 mesos", 30, "DEX +1");
			else if (craftSelect == 1) Craft1(301, "#t1072033#", "#v4130001# #t4130001#\r\n#v4011001# 3 #t4011001#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n19000 mesos", 30, "LUK +1");
			else if (craftSelect == 2) Craft1(302, "#t1072035#", "#v4130001# #t4130001#\r\n#v4011004# 2 #t4011004#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n19000 mesos", 30, "LUK +1");
			else if (craftSelect == 3) Craft1(303, "#t1072036#", "#v4130001# #t4130001#\r\n#v4011006# 2 #t4011006#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n21000 mesos", 30, "DEX +2");
			else if (craftSelect == 4) Craft1(304, "#t1072104#", "#v4130001# #t4130001#\r\n#v4021000# 3 #t4021000#s\r\n#v4021004# #t4021004#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 15 #t4000030#s\r\n#v4003000# 20 #t4003000#s\r\n20000 mesos", 35, "LUK +2");
			else if (craftSelect == 5) Craft1(305, "#t1072105#", "#v4130001# #t4130001#\r\n#v4021003# 3 #t4021003#s\r\n#v4021004# #t4021004#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 15 #t4000030#s\r\n#v4003000# 20 #t4003000#s\r\n20000 mesos", 35, "DEX +2");
			else if (craftSelect == 6) Craft1(306, "#t1072106#", "#v4130001# #t4130001#\r\n#v4021002# 3 #t4021002#s\r\n#v4021004# #t4021004#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 15 #t4000030#s\r\n#v4003000# 20 #t4003000#s\r\n20000 mesos", 35, "LUK +1, DEX +1");
			else if (craftSelect == 7) Craft1(307, "#t1072108#", "#v4130001# #t4130001#\r\n#v4021003# 4 #t4021003#s\r\n#v4000030# 45 #t4000030#s\r\n#v4000095# 100 #t4000095#s\r\n#v4003000# 30 #t4003000#s\r\n32000 mesos", 40, "DEX +2, MP +5");
			else if (craftSelect == 8) Craft1(308, "#t1072109#", "#v4130001# #t4130001#\r\n#v4021006# 4 #t4021006#s\r\n#v4000030# 45 #t4000030#s\r\n#v4000096# 100 #t4000096#s\r\n#v4003000# 30 #t4003000#s\r\n35000 mesos", 40, "LUK +1, STR +1, MP +5");
			else if (craftSelect == 9) Craft1(309, "#t1072110#", "#v4130001# #t4130001#\r\n#v4021005# 4 #t4021005#s\r\n#v4000030# 45 #t4000030#s\r\n#v4000097# 100 #t4000097#s\r\n#v4003000# 30 #t4003000#s\r\n35000 mesos", 40, "LUK +1, DEX +1, MP +5");
			else if (craftSelect == 10) Craft1(310, "#t1072107#", "#v4130001# #t4130001#\r\n#v4021000# 5 #t4021000#s\r\n#v4000030# 45 #t4000030#s\r\n#v4000113# 100 #t4000113#s\r\n#v4003000# 30 #t4003000#s\r\n40000 mesos", 40, "LUK +2, MP +5");
			else if (craftSelect == 11) Craft1(311, "#t1072128#", "#v4130001# #t4130001#\r\n#v4011007# 2 #t4011007#s\r\n#v4021005# 3 #t4021005#s\r\n#v4000030# 50 #t4000030#s\r\n#v4000114# 100 #t4000114#s\r\n#v4003000# 35 #t4003000#s\r\n50000 mesos", 50, "STR +3");
			else if (craftSelect == 12) Craft1(312, "#t1072129#", "#v4130001# #t4130001#\r\n#v4011007# 2 #t4011007#s\r\n#v4021003# 3 #t4021003#s\r\n#v4000030# 50 #t4000030#s\r\n#v4000109# 100 #t4000109#s\r\n#v4003000# 35 #t4003000#s\r\n50000 mesos", 50, "DEX +3");
			else if (craftSelect == 13) Craft1(313, "#t1072130#", "#v4130001# #t4130001#\r\n#v4011007# 2 #t4011007#s\r\n#v4021000# 3 #t4021000#s\r\n#v4000030# 50 #t4000030#s\r\n#v4000115# 100 #t4000115#s\r\n#v4003000# 35 #t4003000#s\r\n50000 mesos", 50, "LUK +3");
			else if (craftSelect == 14) Craft1(314, "#t1072131#", "#v4130001# #t4130001#\r\n#v4011007# 2 #t4011007#s\r\n#v4021001# 3 #t4021001#s\r\n#v4000030# 50 #t4000030#s\r\n#v4000036# 80 #t4000036#s\r\n#v4003000# 35 #t4003000#s\r\n50000 mesos", 50, "LUK +2, DEX +1");
		}
		else if (craftType == 5)
		{
			int craftSelect = AskMenu("You want to upgrade a normal pair of warrior shoes? There's no chance of failure, since the stimulator will not be used and the item's stats will be basic. Please choose the item that you want to make!",
				(0, " #b#t1072003##k(level limit: 30, warrior)"),
				(1, " #b#t1072039##k(level limit: 30, warrior)"),
				(2, " #b#t1072040##k(level limit: 30, warrior)"),
				(3, " #b#t1072041##k(level limit: 30, warrior)"),
				(4, " #b#t1072002##k(level limit: 35, warrior)"),
				(5, " #b#t1072112##k(level limit: 35, warrior)"),
				(6, " #b#t1072113##k(level limit: 35, warrior)"),
				(7, " #b#t1072000##k(level limit: 40, warrior)"),
				(8, " #b#t1072126##k(level limit: 40, warrior)"),
				(9, " #b#t1072127##k(level limit: 40, warrior)"),
				(10, " #b#t1072132##k(level limit: 50, warrior)"),
				(11, " #b#t1072133##k(level limit: 50, warrior)"),
				(12, " #b#t1072134##k(level limit: 50, warrior)"),
				(13, " #b#t1072135##k(level limit: 50, warrior)"));
				
			if (craftSelect == 0) Craft2(0, "#t1072003#", "#v4021003# 4 #t4021003#s\r\n#v4011001# 2 #t4011001#s\r\n#v4000021# 45 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n18000 mesos", 30, "STR +1");
			else if (craftSelect == 1) Craft2(1, "#t1072039#", "#v4011002# 4 #t4011002#s\r\n#v4011001# 2 #t4011001#s\r\n#v4000021# 45 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n18000 mesos", 30, "DEX +1");
			else if (craftSelect == 2) Craft2(2, "#t1072040#", "#v4011004# 4 #t4011004#s\r\n#v4011001# 2 #t4011001#s\r\n#v4000021# 45 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n18000 mesos", 30, "STR +1");
			else if (craftSelect == 3) Craft2(3, "#t1072041#", "#v4021000# 4 #t4021000#s\r\n#v4011001# 2 #t4011001#s\r\n#v4000021# 45 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n18000 mesos", 30, "DEX +1");
			else if (craftSelect == 4) Craft2(4, "#t1072002#", "#v4011001# 3 #t4011001#s\r\n#v4021004# #t4021004#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 20 #t4000030#s\r\n#v4003000# 25 #t4003000#s\r\n19800 mesos", 35, "STR +1, MP +10");
			else if (craftSelect == 5) Craft2(5, "#t1072112#", "#v4011002# 3 #t4011002#s\r\n#v4021004# #t4021004#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 20 #t4000030#s\r\n#v4003000# 25 #t4003000#s\r\n19800 mesos", 35, "DEX +1, MP +10");
			else if (craftSelect == 6) Craft2(6, "#t1072113#", "#v4021008# 2 #t4021008#s\r\n#v4021004# #t4021004#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 20 #t4000030#s\r\n#v4003000# 25 #t4003000#s\r\n22500 mesos", 35, "STR +1, DEX +1, MP +10");
			else if (craftSelect == 7) Craft2(7, "#t1072000#", "#v4011003# 4 #t4011003#s\r\n#v4000021# 100 #t4000021#s\r\n#v4000030# 40 #t4000030#s\r\n#v4003000# 30 #t4003000#s\r\n#v4000103# 100 #t4000103#s\r\n34200 mesos", 40, "DEX +2, MP +20");
			else if (craftSelect == 8) Craft2(8, "#t1072126#", "#v4011005# 4 #t4011005#s\r\n#v4021007# #t4021007#\r\n#v4000030# 40 #t4000030#s\r\n#v4003000# 30 #t4003000#s\r\n#v4000104# 100 #t4000104#s\r\n34200 mesos", 40, "STR +1, DEX +1, MP +20");
			else if (craftSelect == 9) Craft2(9, "#t1072127#", "#v4011002# 4 #t4011002#s\r\n#v4021007# #t4021007#\r\n#v4000030# 40 #t4000030#s\r\n#v4003000# 30 #t4003000#s\r\n#v4000105# 100 #t4000105#s\r\n34200 mesos", 40, "STR +2, MP +20");
			else if (craftSelect == 10) Craft2(10, "#t1072132#", "#v4021008# #t4021008#\r\n#v4011001# 3 #t4011001#s\r\n#v4021003# 6#t4021003#s\r\n#v4000030# 65 #t4000030#s\r\n#v4003000# 45 #t4003000#s\r\n45000 mesos", 50, "DEX +3");
			else if (craftSelect == 11) Craft2(11, "#t1072133#", "#v4021008# #t4021008#\r\n#v4011001# 3 #t4011001#s\r\n#v4011002# 6 #t4011002#s\r\n#v4000030# 65 #t4000030#s\r\n#v4003000# 45 #t4003000#s\r\n45000 mesos", 50, "DEX +2, STR +1");
			else if (craftSelect == 12) Craft2(12, "#t1072134#", "#v4021008# #t4021008#\r\n#v4011001# 3 #t4011001#s\r\n#v4011005# 6 #t4011005#s\r\n#v4000030# 65 #t4000030#s\r\n#v4003000# 45 #t4003000#s\r\n45000 mesos", 50, "DEX +1, STR +2");
			else if (craftSelect == 13) Craft2(13, "#t1072135#", "#v4021008# #t4021008#\r\n#v4011001# 3 #t4011001#s\r\n#v4011006# 6 #t4011006#s\r\n#v4000030# 65 #t4000030#s\r\n#v4003000# 45 #t4003000#s\r\n45000 mesos", 50, "STR +3");
		}
		else if (craftType == 6)
		{
			int craftSelect = AskMenu("You want to upgrade a normal pair of magician shoes? There's no chance of failure, since the stimulator will not be used and the item's stats will be basic. Please choose what you want to make~",
				(0, " #b#t1072075##k(level limit: 30, magician)"),
				(1, " #b#t1072076##k(level limit: 30, magician)"),
				(2, " #b#t1072077##k(level limit: 30, magician)"),
				(3, " #b#t1072078##k(level limit: 30, magician)"),
				(4, " #b#t1072089##k(level limit: 35, magician)"),
				(5, " #b#t1072090##k(level limit: 35, magician)"),
				(6, " #b#t1072091##k(level limit: 35, magician)"),
				(7, " #b#t1072114##k(level limit: 40, magician)"),
				(8, " #b#t1072115##k(level limit: 40, magician)"),
				(9, " #b#t1072116##k(level limit: 40, magician)"),
				(10, " #b#t1072117##k(level limit: 40, magician)"),
				(11, " #b#t1072140##k(level limit: 50, magician)"),
				(12, " #b#t1072141##k(level limit: 50, magician)"),
				(13, " #b#t1072142##k(level limit: 50, magician)"),
				(14, " #b#t1072143##k(level limit: 50, magician)"));
				
			if (craftSelect == 0) Craft2(100, "#t1072075#", "#v4021000# 2 #t4021000#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n16200 mesos", 30, "INT +1");
			else if (craftSelect == 1) Craft2(101, "#t1072076#", "#v4021002# 2 #t4021002#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n16200 mesos", 30, "INT +1");
			else if (craftSelect == 2) Craft2(102, "#t1072077#", "#v4011004# 2 #t4011004#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n16200 mesos", 30, "INT +1");
			else if (craftSelect == 3) Craft2(103, "#t1072078#", "#v4021008# #t4021008#\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n16200 mesos", 30, "INT +2");
			else if (craftSelect == 4) Craft2(104, "#t1072089#", "#v4021001# 3 #t4021001#s\r\n#v4021006# #t4021006#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 15 #t4000030#s\r\n#v4003000# 20 #t4003000#s\r\n18000 mesos", 35, "LUK +1, MP +10");
			else if (craftSelect == 5) Craft2(105, "#t1072090#", "#v4021000# 3 #t4021000#s\r\n#v4021006# #t4021006#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 15 #t4000030#s\r\n#v4003000# 20 #t4003000#s\r\n18000 mesos", 35, "INT +1, MP +10");
			else if (craftSelect == 6) Craft2(106, "#t1072091#", "#v4021008# 2 #t4021008#s\r\n#v4021006# #t4021006#\r\n#v4000021# 40 #t4000021#s\r\n#v4000030# 25 #t4000030#s\r\n#v4003000# 20 #t4003000#s\r\n19800 mesos", 35, "INT +1, LUK +1");
			else if (craftSelect == 7) Craft2(107, "#t1072114#", "#v4021000# 4 #t4021000#s\r\n#v4000030# 40 #t4000030#s\r\n#v4000110# 100 #t4000110#s\r\n#v4003000# 25 #t4003000#s\r\n27000 mesos", 40, "LUK +2, MP +5");
			else if (craftSelect == 8) Craft2(108, "#t1072115#", "#v4021005# 4 #t4021005#s\r\n#v4000030# 40 #t4000030#s\r\n#v4000111# 100 #t4000111#s\r\n#v4003000# 25 #t4003000#s\r\n27000 mesos", 40, "LUK +2, MP +5");
			else if (craftSelect == 9) Craft2(109, "#t1072116#", "#v4011006# 2 #t4011006#s\r\n#v4021007# #t4021007#\r\n#v4000030# 40 #t4000030#s\r\n#v4000100# 100 #t4000100#s\r\n#v4003000# 25 #t4003000#s\r\n31500 mesos", 40, "INT +2, MP +5");
			else if (craftSelect == 10) Craft2(110, "#t1072117#", "#v4021008# 2 #t4021008#s\r\n#v4021007# #t4021007#\r\n#v4000030# 40 #t4000030#s\r\n#v4000112# 100 #t4000112#s\r\n#v4003000# 30 #t4003000#s\r\n36000 mesos", 40, "INT +2, LUK +1, MP +10");
			else if (craftSelect == 11) Craft2(111, "#t1072140#", "#v4021009# #t4021009#\r\n#v4011006# 3 #t4011006#s\r\n#v4021000# 3 #t4021000#s\r\n#v4000030# 60 #t4000030#s\r\n#v4003000# 40 #t4003000#s\r\n45000 mesos", 50, "LUK +3");
			else if (craftSelect == 12) Craft2(112, "#t1072141#", "#v4021009# #t4021009#\r\n#v4011006# 3 #t4011006#s\r\n#v4021005# 3 #t4021005#s\r\n#v4000030# 60 #t4000030#s\r\n#v4003000# 40 #t4003000#s\r\n45000 mesos", 50, "INT +1, LUK +2");
			else if (craftSelect == 13) Craft2(113, "#t1072142#", "#v4021009# #t4021009#\r\n#v4011006# 3 #t4011006#s\r\n#v4021001# 3 #t4021001#s\r\n#v4000030# 60 #t4000030#s\r\n#v4003000# 40 #t4003000#s\r\n45000 mesos", 50, "INT +2, LUK +1");
			else if (craftSelect == 14) Craft2(114, "#t1072143#", "#v4021009# #t4021009#\r\n#v4011006# 3 #t4011006#s\r\n#v4021003# 3 #t4021003#s\r\n#v4000030# 60 #t4000030#s\r\n#v4003000# 40 #t4003000#s\r\n45000 mesos", 50, "INT +3");
		}
		else if (craftType == 7)
		{
			int craftSelect = AskMenu("You want to upgrade a normal pair of bowman shoes? There's no chance of failure, since the stimulator will not be used and the item's stats will be basic. Please choose what you want to make~",
				(0, " #b#t1072079##k(level limit: 30, bowman)"),
				(1, " #b#t1072080##k(level limit: 30, bowman)"),
				(2, " #b#t1072081##k(level limit: 30, bowman)"),
				(3, " #b#t1072082##k(level limit: 30, bowman)"),
				(4, " #b#t1072083##k(level limit: 30, bowman)"),
				(5, " #b#t1072101##k(level limit: 35, bowman)"),
				(6, " #b#t1072102##k(level limit: 35, bowman)"),
				(7, " #b#t1072103##k(level limit: 35, bowman)"),
				(8, " #b#t1072118##k(level limit: 40, bowman)"),
				(9, " #b#t1072119##k(level limit: 40, bowman)"),
				(10, " #b#t1072120##k(level limit: 40, bowman)"),
				(11, " #b#t1072121##k(level limit: 40, bowman)"),
				(12, " #b#t1072122##k(level limit: 50, bowman)"),
				(13, " #b#t1072123##k(level limit: 50, bowman)"),
				(14, " #b#t1072124##k(level limit: 50, bowman)"),
				(15, " #b#t1072125##k(level limit: 50, bowman)"));
				
			if (craftSelect == 0) Craft2(200, "#t1072079#", "#v4021000# 2 #t4021000#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n17100 mesos", 30, "DEX +1");
			else if (craftSelect == 1) Craft2(201, "#t1072080#", "#v4021005# 2 #t4021005#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n17100 mesos", 30, "STR +1");
			else if (craftSelect == 2) Craft2(202, "#t1072081#", "#v4021003# 2 #t4021003#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n17100 mesos", 30, "DEX +1");
			else if (craftSelect == 3) Craft2(203, "#t1072082#", "#v4021004# 2 #t4021004#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n17100 mesos", 30, "DEX +1");
			else if (craftSelect == 4) Craft2(204, "#t1072083#", "#v4021006# 2 #t4021006#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n17100 mesos", 30, "STR +1");
			else if (craftSelect == 5) Craft2(205, "#t1072101#", "#v4021002# 3 #t4021002#s\r\n#v4021006# #t4021006#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 15 #t4000030#s\r\n#v4003000# 20 #t4003000#s\r\n18000 mesos", 35, "STR +2");
			else if (craftSelect == 6) Craft2(206, "#t1072102#", "#v4021003# 3 #t4021003#s\r\n#v4021006# #t4021006#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 15 #t4000030#s\r\n#v4003000# 20 #t4003000#s\r\n18000 mesos", 35, "DEX +2");
			else if (craftSelect == 7) Craft2(207, "#t1072103#", "#v4021000# 3 #t4021000#s\r\n#v4021006# #t4021006#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 15 #t4000030#s\r\n#v4003000# 20 #t4003000#s\r\n18000 mesos", 35, "STR +1, DEX +1");
			else if (craftSelect == 8) Craft2(208, "#t1072118#", "#v4021000# 4 #t4021000#s\r\n#v4000030# 45 #t4000030#s\r\n#v4000106# 100 #t4000106#s\r\n#v4003000# 30 #t4003000#s\r\n28800 mesos", 40, "STR +2, MP +5");
			else if (craftSelect == 9) Craft2(209, "#t1072119#", "#v4021006# 4 #t4021006#s\r\n#v4000030# 45 #t4000030#s\r\n#v4000107# 100 #t4000107#s\r\n#v4003000# 30 #t4003000#s\r\n28800 mesos", 40, "DEX +1, STR +1, MP +5");
			else if (craftSelect == 10) Craft2(210, "#t1072120#", "#v4011003# 5 #t4011003#s\r\n#v4000030# 45 #t4000030#s\r\n#v4000108# 100 #t4000108#s\r\n#v4003000# 30 #t4003000#s\r\n36000 mesos", 40, "DEX +2, MP +5");
			else if (craftSelect == 11) Craft2(211, "#t1072121#", "#v4021002# 5 #t4021002#s\r\n#v4000030# 45 #t4000030#s\r\n#v4000099# 100 #t4000099#s\r\n#v4003000# 30 #t4003000#s\r\n36000 mesos", 40, "DEX +2, MP +5");
			else if (craftSelect == 12) Craft2(212, "#t1072122#", "#v4021008# #t4021008#\r\n#v4011001# 3 #t4011001#s\r\n#v4021006# 3 #t4021006#s\r\n#v4000030# 60 #t4000030#s\r\n#v4000033# 80 #t4000033#s\r\n#v4003000# 35 #t4003000#s\r\n45000 mesos", 50, "STR +3");
			else if (craftSelect == 13) Craft2(213, "#t1072123#", "#v4021008# #t4021008#\r\n#v4011001# 3 #t4011001#s\r\n#v4021006# 3 #t4021006#s\r\n#v4000030# 60 #t4000030#s\r\n#v4000032# 150 #t4000032#s\r\n#v4003000# 35 #t4003000#s\r\n45000 mesos", 50, "DEX +1, STR +2");
			else if (craftSelect == 14) Craft2(214, "#t1072124#", "#v4021008# #t4021008#\r\n#v4011001# 3 #t4011001#s\r\n#v4021006# 3 #t4021006#s\r\n#v4000030# 60 #t4000030#s\r\n#v4000041# 100 #t4000041#s\r\n#v4003000# 35 #t4003000#s\r\n45000 mesos", 50, "DEX +2, STR +1");
			else if (craftSelect == 15) Craft2(215, "#t1072125#", "#v4021008# #t4021008#\r\n#v4011001# 3 #t4011001#s\r\n#v4021006# 3 #t4021006#s\r\n#v4000030# 60 #t4000030#s\r\n#v4000042# 250 #t4000042#s\r\n#v4003000# 35 #t4003000#s\r\n45000 mesos", 50, "DEX +3");
		}
		else if (craftType == 8)
		{
			int craftSelect = AskMenu("You want to upgrade a normal pair of thief shoes? There's no chance of failure, since the stimulator will not be used and the item's stats will be basic. Please choose the item that you want to make~",
				(0, " #b#t1072032##k(level limit: 30, thief)"),
				(1, " #b#t1072033##k(level limit: 30, thief)"),
				(2, " #b#t1072035##k(level limit: 30, thief)"),
				(3, " #b#t1072036##k(level limit: 30, thief)"),
				(4, " #b#t1072104##k(level limit: 35, thief)"),
				(5, " #b#t1072105##k(level limit: 35, thief)"),
				(6, " #b#t1072106##k(level limit: 35, thief)"),
				(7, " #b#t1072108##k(level limit: 40, thief)"),
				(8, " #b#t1072109##k(level limit: 40, thief)"),
				(9, " #b#t1072110##k(level limit: 40, thief)"),
				(10, " #b#t1072107##k(level limit: 40, thief)"),
				(11, " #b#t1072128##k(level limit: 50, thief)"),
				(12, " #b#t1072129##k(level limit: 50, thief)"),
				(13, " #b#t1072130##k(level limit: 50, thief)"),
				(14, " #b#t1072131##k(level limit: 50, thief)"));
			
			if (craftSelect == 0) Craft2(300, "#t1072032#", "#v4011000# 3 #t4011000#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n17100 mesos", 30, "DEX +1");
			else if (craftSelect == 1) Craft2(301, "#t1072033#", "#v4011001# 3 #t4011001#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n17100 mesos", 30, "LUK +1");
			else if (craftSelect == 2) Craft2(302, "#t1072035#", "#v4011004# 2 #t4011004#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n17100 mesos", 30, "LUK +1");
			else if (craftSelect == 3) Craft2(303, "#t1072036#", "#v4011006# 2 #t4011006#s\r\n#v4000021# 50 #t4000021#s\r\n#v4003000# 15 #t4003000#s\r\n18900 mesos", 30, "DEX +2");
			else if (craftSelect == 4) Craft2(304, "#t1072104#", "#v4021000# 3 #t4021000#s\r\n#v4021004# #t4021004#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 15 #t4000030#s\r\n#v4003000# 20 #t4003000#s\r\n18000 mesos", 35, "LUK +2");
			else if (craftSelect == 5) Craft2(305, "#t1072105#", "#v4021003# 3 #t4021003#s\r\n#v4021004# #t4021004#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 15 #t4000030#s\r\n#v4003000# 20 #t4003000#s\r\n18000 mesos", 35, "DEX +2");
			else if (craftSelect == 6) Craft2(306, "#t1072106#", "#v4021002# 3 #t4021002#s\r\n#v4021004# #t4021004#\r\n#v4000021# 30 #t4000021#s\r\n#v4000030# 15 #t4000030#s\r\n#v4003000# 20 #t4003000#s\r\n18000 mesos", 35, "LUK +1, DEX +1");
			else if (craftSelect == 7) Craft2(307, "#t1072108#", "#v4021003# 4 #t4021003#s\r\n#v4000030# 45 #t4000030#s\r\n#v4000095# 100 #t4000095#s\r\n#v4003000# 30 #t4003000#s\r\n28800 mesos", 40, "DEX +2, MP +5");
			else if (craftSelect == 8) Craft2(308, "#t1072109#", "#v4021006# 4 #t4021006#s\r\n#v4000030# 45 #t4000030#s\r\n#v4000096# 100 #t4000096#s\r\n#v4003000# 30 #t4003000#s\r\n31500 mesos", 40, "LUK +1, STR +1, MP +5");
			else if (craftSelect == 9) Craft2(309, "#t1072110#", "#v4021005# 4 #t4021005#s\r\n#v4000030# 45 #t4000030#s\r\n#v4000097# 100 #t4000097#s\r\n#v4003000# 30 #t4003000#s\r\n31500 mesos", 40, "LUK +1, DEX +1, MP +5");
			else if (craftSelect == 10) Craft2(310, "#t1072107#", "#v4021000# 5 #t4021000#s\r\n#v4000030# 45 #t4000030#s\r\n#v4000113# 100 #t4000113#s\r\n#v4003000# 30 #t4003000#s\r\n36000 mesos", 40, "LUK +2, MP +5");
			else if (craftSelect == 11) Craft2(311, "#t1072128#", "#v4011007# 2 #t4011007#s\r\n#v4021005# 3 #t4021005#s\r\n#v4000030# 50 #t4000030#s\r\n#v4000114# 100 #t4000114#s\r\n#v4003000# 35 #t4003000#s\r\n45000 mesos", 50, "STR +3");
			else if (craftSelect == 12) Craft2(312, "#t1072129#", "#v4011007# 2 #t4011007#s\r\n#v4021003# 3 #t4021003#s\r\n#v4000030# 50 #t4000030#s\r\n#v4000109# 100 #t4000109#s\r\n#v4003000# 35 #t4003000#s\r\n45000 mesos", 50, "DEX +3");
			else if (craftSelect == 13) Craft2(313, "#t1072130#", "#v4011007# 2 #t4011007#s\r\n#v4021000# 3 #t4021000#s\r\n#v4000030# 50 #t4000030#s\r\n#v4000115# 100 #t4000115#s\r\n#v4003000# 35 #t4003000#s\r\n45000 mesos", 50, "LUK +3");
			else if (craftSelect == 14) Craft2(314, "#t1072131#", "#v4011007# 2 #t4011007#s\r\n#v4021001# 3 #t4021001#s\r\n#v4000030# 50 #t4000030#s\r\n#v4000036# 80 #t4000036#s\r\n#v4003000# 35 #t4003000#s\r\n45000 mesos", 50, "LUK +2, DEX +1");
		}
	}
}