using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	#region Crafting
	private void Craft1(int index, string makeItem, string needItem, int unitPrice)
	{
		int amount = AskInteger(1, 1, 100, $"To make one {makeItem}, I need the following items... How many would you like to make?\r\n\r\n#b10 {needItem}s \r\n{unitPrice:n0} mesos#k");
		
		int nPrice = unitPrice * amount;
		int nAllNum = amount * 10;
		
		bool askBuy = AskYesNo($"To make #b{amount} {makeItem}#k, I need the following materials. What do you think? Want to do it?\r\n\r\n#b{nAllNum:n0} {needItem}s\r\n{nPrice:n0} mesos#k");
		
		if (!askBuy)
		{
			self.say("It's not only minerals and jewels that I can refine, but also rare and valuable shoes... think about it some more and come back.");
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
		
		self.say($"There you go. Take the {amount} {makeItem}(s). What do you think? You won't find a product like this anywhere else...");
	}
	
	private void Craft2(int index, string makeItem, string needItem, int reqLevel, string itemOption)
	{
	bool askBuy = AskYesNo($"To make one {makeItem}, I'll need the following materials. There is also an improvement of #r{itemOption}#k on the item, and the level limit is {reqLevel}. What do you think? Want to make one? \r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("It's not only minerals and jewels that I can refine, but also rare and valuable shoes... think about it some more and come back.");
			return;
		}
		
		bool trade = false;
		
		// Warrior Shoes
		if (index == 1) trade = Exchange(-10000, 4011004, -2, 4011001, -1, 4000021, -15, 4003000, -10, 1072051, 1);
		else if (index == 2) trade = Exchange(-10000, 4011006, -2, 4011001, -1, 4000021, -15, 4003000, -10, 1072053, 1);
		else if (index == 3) trade = Exchange(-12000, 4021008, -1, 4011001, -2, 4000021, -20, 4003000, -10, 1072052, 1);
		else if (index == 4) trade = Exchange(-20000, 4021003, -4, 4011001, -2, 4000021, -45, 4003000, -15, 1072003, 1);
		else if (index == 5) trade = Exchange(-20000, 4011002, -4, 4011001, -2, 4000021, -45, 4003000, -15, 1072039, 1);
		else if (index == 6) trade = Exchange(-20000, 4011004, -4, 4011001, -2, 4000021, -45, 4003000, -15, 1072040, 1);
		else if (index == 7) trade = Exchange(-20000, 4021000, -4, 4011001, -2, 4000021, -45, 4003000, -15, 1072041, 1);
		else if (index == 8) trade = Exchange(-22000, 4011001, -3, 4021004, -1, 4000021, -30, 4000030, -20, 4003000, -25, 1072002, 1);
		else if (index == 9) trade = Exchange(-22000, 4011002, -3, 4021004, -1, 4000021, -30, 4000030, -20, 4003000, -25, 1072112, 1);
		else if (index == 10) trade = Exchange(-25000, 4021008, -2, 4021004, -1, 4000021, -30, 4000030, -20, 4003000, -25, 1072113, 1);
		else if (index == 11) trade = Exchange(-38000, 4011003, -4, 4000021, -100, 4000030, -40, 4003000, -30, 4000033, -100, 1072000, 1);
		else if (index == 12) trade = Exchange(-38000, 4011005, -4, 4021007, -1, 4000030, -40, 4003000, -30, 4000042, -250, 1072126, 1);
		else if (index == 13) trade = Exchange(-38000, 4011002, -4, 4021007, -1, 4000030, -40, 4003000, -30, 4000041, -120, 1072127, 1);
		else if (index == 14) trade = Exchange(-50000, 4021008, -1, 4011001, -3, 4021003, -6, 4000030, -65, 4003000, -45, 1072132, 1);
		else if (index == 15) trade = Exchange(-50000, 4021008, -1, 4011001, -3, 4011002, -6, 4000030, -65, 4003000, -45, 1072133, 1);
		else if (index == 16) trade = Exchange(-50000, 4021008, -1, 4011001, -3, 4011005, -6, 4000030, -65, 4003000, -45, 1072134, 1);
		else if (index == 17) trade = Exchange(-50000, 4021008, -1, 4011001, -3, 4011006, -6, 4000030, -65, 4003000, -45, 1072135, 1);
		else if (index == 18) trade = Exchange(-60000, 4021008, -1, 4011007, -1, 4021005, -8, 4000030, -80, 4003000, -55, 1072147, 1);
		else if (index == 19) trade = Exchange(-60000, 4021008, -1, 4011007, -1, 4011005, -8, 4000030, -80, 4003000, -55, 1072148, 1);
		else if (index == 20) trade = Exchange(-60000, 4021008, -1, 4011007, -1, 4021000, -8, 4000030, -80, 4003000, -55, 1072149, 1);
		
		// Magician Shoes
		else if (index == 100) trade = Exchange(-3000, 4021005, -1, 4000021, -30, 4003000, -5, 1072019, 1);
		else if (index == 101) trade = Exchange(-3000, 4021001, -1, 4000021, -30, 4003000, -5, 1072020, 1);
		else if (index == 102) trade = Exchange(-3000, 4021000, -1, 4000021, -30, 4003000, -5, 1072021, 1);
		else if (index == 103) trade = Exchange(-8000, 4011004, -1, 4000021, -35, 4003000, -10, 1072072, 1);
		else if (index == 104) trade = Exchange(-8000, 4021006, -1, 4000021, -35, 4003000, -10, 1072073, 1);
		else if (index == 105) trade = Exchange(-8000, 4021004, -1, 4000021, -35, 4003000, -10, 1072074, 1);
		else if (index == 106) trade = Exchange(-18000, 4021000, -2, 4000021, -50, 4003000, -15, 1072075, 1);
		else if (index == 107) trade = Exchange(-18000, 4021002, -2, 4000021, -50, 4003000, -15, 1072076, 1);
		else if (index == 108) trade = Exchange(-18000, 4011004, -2, 4000021, -50, 4003000, -15, 1072077, 1);
		else if (index == 109) trade = Exchange(-18000, 4021008, -1, 4000021, -50, 4003000, -15, 1072078, 1);
		else if (index == 110) trade = Exchange(-20000, 4021001, -3, 4021006, -1, 4000021, -30, 4000030, -15, 4003000, -20, 1072089, 1);
		else if (index == 111) trade = Exchange(-20000, 4021000, -3, 4021006, -1, 4000021, -30, 4000030, -15, 4003000, -20, 1072090, 1);
		else if (index == 112) trade = Exchange(-22000, 4021008, -2, 4021006, -1, 4000021, -40, 4000030, -25, 4003000, -20, 1072091, 1);
		else if (index == 113) trade = Exchange(-30000, 4021000, -4, 4000030, -40, 4000043, -35, 4003000, -25, 1072114, 1);
		else if (index == 114) trade = Exchange(-30000, 4021005, -4, 4000030, -40, 4000037, -70, 4003000, -25, 1072115, 1);
		else if (index == 115) trade = Exchange(-35000, 4011006, -2, 4021007, -1, 4000030, -40, 4000027, -20, 4003000, -25, 1072116, 1);
		else if (index == 116) trade = Exchange(-40000, 4021008, -2, 4021007, -1, 4000030, -40, 4000014, -30, 4003000, -30, 1072117, 1);
		else if (index == 117) trade = Exchange(-50000, 4021009, -1, 4011006, -3, 4021000, -3, 4000030, -60, 4003000, -40, 1072140, 1);
		else if (index == 118) trade = Exchange(-50000, 4021009, -1, 4011006, -3, 4021005, -3, 4000030, -60, 4003000, -40, 1072141, 1);
		else if (index == 119) trade = Exchange(-50000, 4021009, -1, 4011006, -3, 4021001, -3, 4000030, -60, 4003000, -40, 1072142, 1);
		else if (index == 120) trade = Exchange(-50000, 4021009, -1, 4011006, -3, 4021003, -3, 4000030, -60, 4003000, -40, 1072143, 1);
		else if (index == 121) trade = Exchange(-60000, 4021009, -1, 4011006, -4, 4011005, -5, 4000030, -70, 4003000, -50, 1072136, 1);
		else if (index == 122) trade = Exchange(-60000, 4021009, -1, 4011006, -4, 4021003, -5, 4000030, -70, 4003000, -50, 1072137, 1);
		else if (index == 123) trade = Exchange(-60000, 4021009, -1, 4011006, -4, 4011003, -5, 4000030, -70, 4003000, -50, 1072138, 1);
		else if (index == 124) trade = Exchange(-60000, 4021009, -1, 4011006, -4, 4021002, -5, 4000030, -70, 4003000, -50, 1072139, 1);
		
		// Bowman Shoes
		else if (index == 200) trade = Exchange(-9000, 4011000, -3, 4000021, -35, 4003000, -10, 1072027, 1);
		else if (index == 201) trade = Exchange(-9000, 4021003, -1, 4000021, -35, 4003000, -10, 1072034, 1);
		else if (index == 202) trade = Exchange(-9000, 4021000, -1, 4000021, -35, 4003000, -10, 1072069, 1);
		else if (index == 203) trade = Exchange(-19000, 4021000, -2, 4000021, -50, 4003000, -15, 1072079, 1);
		else if (index == 204) trade = Exchange(-19000, 4021005, -2, 4000021, -50, 4003000, -15, 1072080, 1);
		else if (index == 205) trade = Exchange(-19000, 4021003, -2, 4000021, -50, 4003000, -15, 1072081, 1);
		else if (index == 206) trade = Exchange(-19000, 4021004, -2, 4000021, -50, 4003000, -15, 1072082, 1);
		else if (index == 207) trade = Exchange(-19000, 4021006, -2, 4000021, -50, 4003000, -15, 1072083, 1);
		else if (index == 208) trade = Exchange(-20000, 4021002, -3, 4021006, -1, 4000021, -30, 4000030, -15, 4003000, -20, 1072101, 1);
		else if (index == 209) trade = Exchange(-20000, 4021003, -3, 4021006, -1, 4000021, -30, 4000030, -15, 4003000, -20, 1072102, 1);
		else if (index == 210) trade = Exchange(-20000, 4021000, -3, 4021006, -1, 4000021, -30, 4000030, -15, 4003000, -20, 1072103, 1);
		else if (index == 211) trade = Exchange(-32000, 4021000, -4, 4000030, -45, 4000024, -40, 4003000, -30, 1072118, 1);
		else if (index == 212) trade = Exchange(-32000, 4021006, -4, 4000030, -45, 4000027, -20, 4003000, -30, 1072119, 1);
		else if (index == 213) trade = Exchange(-40000, 4011003, -5, 4000030, -45, 4000044, -40, 4003000, -30, 1072120, 1);
		else if (index == 214) trade = Exchange(-40000, 4021002, -5, 4000030, -45, 4000009, -120, 4003000, -30, 1072121, 1);
		else if (index == 215) trade = Exchange(-50000, 4021008, -1, 4011001, -3, 4021006, -3, 4000030, -60, 4000033, -80, 4003000, -35, 1072122, 1);
		else if (index == 216) trade = Exchange(-50000, 4021008, -1, 4011001, -3, 4021006, -3, 4000030, -60, 4000032, -150, 4003000, -35, 1072123, 1);
		else if (index == 217) trade = Exchange(-50000, 4021008, -1, 4011001, -3, 4021006, -3, 4000030, -60, 4000041, -100, 4003000, -35, 1072124, 1);
		else if (index == 218) trade = Exchange(-50000, 4021008, -1, 4011001, -3, 4021006, -3, 4000030, -60, 4000042, -250, 4003000, -35, 1072125, 1);
		else if (index == 219) trade = Exchange(-60000, 4021007, -1, 4011006, -5, 4021000, -8, 4000030, -75, 4003000, -50, 1072144, 1);
		else if (index == 220) trade = Exchange(-60000, 4021007, -1, 4011006, -5, 4021005, -8, 4000030, -75, 4003000, -50, 1072145, 1);
		else if (index == 221) trade = Exchange(-60000, 4021007, -1, 4011006, -5, 4021003, -8, 4000030, -75, 4003000, -50, 1072146, 1);
		
		// Thief Shoes
		else if (index == 300) trade = Exchange(-9000, 4021005, -1, 4000021, -35, 4003000, -10, 1072084, 1);
		else if (index == 301) trade = Exchange(-9000, 4021000, -1, 4000021, -35, 4003000, -10, 1072085, 1);
		else if (index == 302) trade = Exchange(-9000, 4021003, -1, 4000021, -35, 4003000, -10, 1072086, 1);
		else if (index == 303) trade = Exchange(-9000, 4021004, -1, 4000021, -35, 4003000, -10, 1072087, 1);
		else if (index == 304) trade = Exchange(-19000, 4011000, -3, 4000021, -50, 4003000, -15, 1072032, 1);
		else if (index == 305) trade = Exchange(-19000, 4011001, -3, 4000021, -50, 4003000, -15, 1072033, 1);
		else if (index == 306) trade = Exchange(-19000, 4011004, -2, 4000021, -50, 4003000, -15, 1072035, 1);
		else if (index == 307) trade = Exchange(-21000, 4011006, -2, 4000021, -50, 4003000, -15, 1072036, 1);
		else if (index == 308) trade = Exchange(-20000, 4021000, -3, 4021004, -1, 4000021, -30, 4000030, -15, 4003000, -20, 1072104, 1);
		else if (index == 309) trade = Exchange(-20000, 4021003, -3, 4021004, -1, 4000021, -30, 4000030, -15, 4003000, -20, 1072105, 1);
		else if (index == 310) trade = Exchange(-20000, 4021002, -3, 4021004, -1, 4000021, -30, 4000030, -15, 4003000, -20, 1072106, 1);
		else if (index == 311) trade = Exchange(-32000, 4021003, -4, 4000030, -45, 4000032, -30, 4003000, -30, 1072108, 1);
		else if (index == 312) trade = Exchange(-35000, 4021006, -4, 4000030, -45, 4000040, -3, 4003000, -30, 1072109, 1);
		else if (index == 313) trade = Exchange(-35000, 4021005, -4, 4000030, -45, 4000037, -70, 4003000, -30, 1072110, 1);
		else if (index == 314) trade = Exchange(-40000, 4021000, -5, 4000030, -45, 4000033, -50, 4003000, -30, 1072107, 1);
		else if (index == 315) trade = Exchange(-50000, 4011007, -2, 4021005, -3, 4000030, -50, 4000037, -200, 4003000, -35, 1072128, 1);
		else if (index == 316) trade = Exchange(-50000, 4011007, -2, 4021003, -3, 4000030, -50, 4000045, -80, 4003000, -35, 1072129, 1);
		else if (index == 317) trade = Exchange(-50000, 4011007, -2, 4021000, -3, 4000030, -50, 4000043, -150, 4003000, -35, 1072130, 1);
		else if (index == 318) trade = Exchange(-50000, 4011007, -2, 4021001, -3, 4000030, -50, 4000036, -80, 4003000, -35, 1072131, 1);
		else if (index == 319) trade = Exchange(-60000, 4021007, -1, 4011007, -1, 4021000, -8, 4000030, -75, 4003000, -50, 1072150, 1);
		else if (index == 320) trade = Exchange(-60000, 4021007, -1, 4011007, -1, 4011006, -5, 4000030, -75, 4003000, -50, 1072151, 1);
		else if (index == 321) trade = Exchange(-60000, 4021007, -1, 4011007, -1, 4021008, -1, 4000030, -75, 4003000, -50, 1072152, 1);
		
		if (!trade)
		{
			self.say("Please check carefully that you have all of the items you need, and if your equip. inventory is full or not.");
			return;
		}
			
		self.say($"There you go. Take the {makeItem} you asked for. What do you think? You won't find a product like this anywhere else...");
	}
	
	private void StartRefine()
	{
		int craftType = AskMenu("Make sure you have an empty space in your etc. inventory before refining a raw ore or creating an item. Let's see... what do you want to make?#b",
			(0, " Refine the raw ore of a mineral"),
			(1, " Refine the ore of a jewel"),
			(2, " Create warrior shoes"),
			(3, " Create magician shoes"),
			(4, " Create bowman shoes"),
			(5, " Create thief shoes"));
		
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
			int craftSelect = AskMenu("So you want to make warrior shoes. What kind of shoes do you want to make?",
				(0, " #b#t1072051##k(level limit: 25, warrior)"),
				(1, " #b#t1072053##k(level limit: 25, warrior)"),
				(2, " #b#t1072052##k(level limit: 25, warrior)"),
				(3, " #b#t1072003##k(level limit: 30, warrior)"),
				(4, " #b#t1072039##k(level limit: 30, warrior)"),
				(5, " #b#t1072040##k(level limit: 30, warrior)"),
				(6, " #b#t1072041##k(level limit: 30, warrior)"),
				(7, " #b#t1072002##k(level limit: 35, warrior)"),
				(8, " #b#t1072112##k(level limit: 35, warrior)"),
				(9, " #b#t1072113##k(level limit: 35, warrior)"),
				(10, " #b#t1072000##k(level limit: 40, warrior)"),
				(11, " #b#t1072126##k(level limit: 40, warrior)"),
				(12, " #b#t1072127##k(level limit: 40, warrior)"),
				(13, " #b#t1072132##k(level limit: 50, warrior)"),
				(14, " #b#t1072133##k(level limit: 50, warrior)"),
				(15, " #b#t1072134##k(level limit: 50, warrior)"),
				(16, " #b#t1072135##k(level limit: 50, warrior)"),
				(17, " #b#t1072147##k(level limit: 60, warrior)"),
				(18, " #b#t1072148##k(level limit: 60, warrior)"),
				(19, " #b#t1072149##k(level limit: 60, warrior)"));
				
			if (craftSelect == 0) Craft2(1, "#t1072051#", "#v4011004# 2 #t4011004#s \r\n#v4011001# #t4011001# \r\n#v4000021# 15 #t4000021#s \r\n#v4003000# 10 #t4003000#s \r\n10,000 mesos", 25, "DEX +1");
			else if (craftSelect == 1) Craft2(2, "#t1072053#", "#v4011006# 2 #t4011006#s \r\n#v4011001# #t4011001# \r\n#v4000021# 15 #t4000021#s \r\n#v4003000# 10 #t4003000#s \r\n10,000 mesos", 25, "DEX +1");
			else if (craftSelect == 2) Craft2(3, "#t1072052#", "#v4021008# #t4021008# \r\n#v4011001# 2 #t4011001#s \r\n#v4000021# 20 #t4000021#s \r\n#v4003000# 10 #t4003000#s \r\n12,000 mesos", 25, "STR +2");
			else if (craftSelect == 3) Craft2(4, "#t1072003#", "#v4021003# 4 #t4021003#s \r\n#v4011001# 2 #t4011001#s \r\n#v4000021# 45 #t4000021#s \r\n#v4003000# 15 #t4003000#s \r\n20,000 mesos", 30, "STR +1");
			else if (craftSelect == 4) Craft2(5, "#t1072039#", "#v4011002# 4 #t4011002#s \r\n#v4011001# 2 #t4011001#s \r\n#v4000021# 45 #t4000021#s \r\n#v4003000# 15 #t4003000#s \r\n20,000 mesos", 30, "DEX +1");
			else if (craftSelect == 5) Craft2(6, "#t1072040#", "#v4011004# 4 #t4011004#s \r\n#v4011001# 2 #t4011001#s \r\n#v4000021# 45 #t4000021#s \r\n#v4003000# 15 #t4003000#s \r\n20,000 mesos", 30, "STR +1");
			else if (craftSelect == 6) Craft2(7, "#t1072041#", "#v4021000# 4 #t4021000#s \r\n#v4011001# 2 #t4011001#s \r\n#v4000021# 45 #t4000021#s \r\n#v4003000# 15 #t4003000#s \r\n20,000 mesos", 30, "DEX +1");
			else if (craftSelect == 7) Craft2(8, "#t1072002#", "#v4011001# 3 #t4011001#s \r\n#v4021004# #t4021004# \r\n#v4000021# 30 #t4000021#s \r\n#v4000030# 20 #t4000030#s \r\n#v4003000# 25 #t4003000#s \r\n22,000 mesos", 35, "STR +1, MP +10");
			else if (craftSelect == 8) Craft2(9, "#t1072112#", "#v4011002# 3 #t4011002#s \r\n#v4021004# #t4021004# \r\n#v4000021# 30 #t4000021#s \r\n#v4000030# 20 #t4000030#s \r\n#v4003000# 25 #t4003000#s \r\n22,000 mesos", 35, "DEX +1, MP +10");
			else if (craftSelect == 9) Craft2(10, "#t1072113#", "#v4021008# 2 #t4021008#s \r\n#v4021004# #t4021004# \r\n#v4000021# 30 #t4000021#s \r\n#v4000030# 20 #t4000030#s \r\n#v4003000# 25 #t4003000#s \r\n25,000 mesos", 35, "STR +1, DEX +1, MP +10");
			else if (craftSelect == 10) Craft2(11, "#t1072000#", "#v4011003# 4 #t4011003#s \r\n#v4000021# 100 #t4000021#s \r\n#v4000030# 40 #t4000030#s \r\n#v4003000# 30 #t4003000#s \r\n#v4000033# 100 #t4000033#s \r\n38,000 mesos", 40, "DEX +2, MP +20");
			else if (craftSelect == 11) Craft2(12, "#t1072126#", "#v4011005# 4 #t4011005#s \r\n#v4021007# #t4021007# \r\n#v4000030# 40 #t4000030#s \r\n#v4003000# 30 #t4003000#s \r\n#v4000042# 250 #t4000042#s \r\n38,000 mesos", 40, "STR +1, DEX +1, MP +20");
			else if (craftSelect == 12) Craft2(13, "#t1072127#", "#v4011002# 4 #t4011002#s \r\n#v4021007# #t4021007# \r\n#v4000030# 40 #t4000030#s \r\n#v4003000# 30 #t4003000#s \r\n#v4000041# 120 #t4000041#s \r\n38,000 mesos", 40, "STR +2, MP +20");
			else if (craftSelect == 13) Craft2(14, "#t1072132#", "#v4021008# #t4021008# \r\n#v4011001# 3 #t4011001#s \r\n#v4021003# 6 #t4021003#s \r\n#v4000030# 65 #t4000030#s \r\n#v4003000# 45 #t4003000#s \r\n50,000 mesos", 50, "DEX +3");
			else if (craftSelect == 14) Craft2(15, "#t1072133#", "#v4021008# #t4021008# \r\n#v4011001# 3 #t4011001#s \r\n#v4011002# 6 #t4011002#s \r\n#v4000030# 65 #t4000030#s \r\n#v4003000# 45 #t4003000#s \r\n50,000 mesos", 50, "DEX +2, STR +1");
			else if (craftSelect == 15) Craft2(16, "#t1072134#", "#v4021008# #t4021008# \r\n#v4011001# 3 #t4011001#s \r\n#v4011005# 6 #t4011005#s \r\n#v4000030# 65 #t4000030#s \r\n#v4003000# 45 #t4003000#s \r\n50,000 mesos", 50, "DEX +1, STR +2");
			else if (craftSelect == 16) Craft2(17, "#t1072135#", "#v4021008# #t4021008# \r\n#v4011001# 3 #t4011001#s \r\n#v4011006# 6 #t4011006#s \r\n#v4000030# 65 #t4000030#s \r\n#v4003000# 45 #t4003000#s \r\n50,000 mesos", 50, "STR +3");
			else if (craftSelect == 17) Craft2(18, "#t1072147#", "#v4021008# #t4021008# \r\n#v4011007# #t4011007# \r\n#v4021005# 8 #t4021005#s \r\n#v4000030# 80 #t4000030#s \r\n#v4003000# 55 #t4003000#s \r\n60,000 mesos", 60, "STR +1, DEX +3");
			else if (craftSelect == 18) Craft2(19, "#t1072148#", "#v4021008# #t4021008# \r\n#v4011007# #t4011007# \r\n#v4011005# 8 #t4011005#s \r\n#v4000030# 80 #t4000030#s \r\n#v4003000# 55 #t4003000#s \r\n60,000 mesos", 60, "STR +2, DEX +2");
			else if (craftSelect == 19) Craft2(20, "#t1072149#", "#v4021008# #t4021008# \r\n#v4011007# #t4011007# \r\n#v4021000# 8 #t4021000#s \r\n#v4000030# 80 #t4000030#s \r\n#v4003000# 55 #t4003000#s \r\n60,000 mesos", 60, "STR +3, DEX +1");
		}
		else if (craftType == 3)
		{
			int craftSelect = AskMenu("So you want to make magician shoes. What kind of shoes do you want to make?",
				(0, " #b#t1072019##k(level limit: 20, magician)"),
				(1, " #b#t1072020##k(level limit: 20, magician)"),
				(2, " #b#t1072021##k(level limit: 20, magician)"),
				(3, " #b#t1072072##k(level limit: 25, magician)"),
				(4, " #b#t1072073##k(level limit: 25, magician)"),
				(5, " #b#t1072074##k(level limit: 25, magician)"),
				(6, " #b#t1072075##k(level limit: 30, magician)"),
				(7, " #b#t1072076##k(level limit: 30, magician)"),
				(8, " #b#t1072077##k(level limit: 30, magician)"),
				(9, " #b#t1072078##k(level limit: 30, magician)"),
				(10, " #b#t1072089##k(level limit: 35, magician)"),
				(11, " #b#t1072090##k(level limit: 35, magician)"),
				(12, " #b#t1072091##k(level limit: 35, magician)"),
				(13, " #b#t1072114##k(level limit: 40, magician)"),
				(14, " #b#t1072115##k(level limit: 40, magician)"),
				(15, " #b#t1072116##k(level limit: 40, magician)"),
				(16, " #b#t1072117##k(level limit: 40, magician)"),
				(17, " #b#t1072140##k(level limit: 50, magician)"),
				(18, " #b#t1072141##k(level limit: 50, magician)"),
				(19, " #b#t1072142##k(level limit: 50, magician)"),
				(20, " #b#t1072143##k(level limit: 50, magician)"),
				(21, " #b#t1072136##k(level limit: 60, magician)"),
				(22, " #b#t1072137##k(level limit: 60, magician)"),
				(23, " #b#t1072138##k(level limit: 60, magician)"),
				(24, " #b#t1072139##k(level limit: 60, magician)"));
				
			if (craftSelect == 0) Craft2(100, "#t1072019#", "#v4021005# #t4021005# \r\n#v4000021# 30 #t4000021#s \r\n#v4003000# 5 #t4003000#s \r\n3,000 mesos", 20, "INT +1");
			else if (craftSelect == 1) Craft2(101, "#t1072020#", "#v4021001# #t4021001# \r\n#v4000021# 30 #t4000021#s \r\n#v4003000# 5 #t4003000#s \r\n3,000 mesos", 20, "INT +1");
			else if (craftSelect == 2) Craft2(102, "#t1072021#", "#v4021000# #t4021000# \r\n#v4000021# 30 #t4000021#s \r\n#v4003000# 5 #t4003000#s \r\n3,000 mesos", 20, "INT +1");
			else if (craftSelect == 3) Craft2(103, "#t1072072#", "#v4011004# #t4011004# \r\n#v4000021# 35 #t4000021#s \r\n#v4003000# 10 #t4003000#s \r\n8,000 mesos", 25, "INT +1");
			else if (craftSelect == 4) Craft2(104, "#t1072073#", "#v4021006# #t4021006# \r\n#v4000021# 35 #t4000021#s \r\n#v4003000# 10 #t4003000#s \r\n8,000 mesos", 25, "INT +1");
			else if (craftSelect == 5) Craft2(105, "#t1072074#", "#v4021004# #t4021004# \r\n#v4000021# 35 #t4000021#s \r\n#v4003000# 10 #t4003000#s \r\n8,000 mesos", 25, "INT +1");
			else if (craftSelect == 6) Craft2(106, "#t1072075#", "#v4021000# 2 #t4021000#s \r\n#v4000021# 50 #t4000021#s \r\n#v4003000# 15 #t4003000#s \r\n18,000 mesos", 30, "INT +1");
			else if (craftSelect == 7) Craft2(107, "#t1072076#", "#v4021002# 2 #t4021002#s \r\n#v4000021# 50 #t4000021#s \r\n#v4003000# 15 #t4003000#s \r\n18,000 mesos", 30, "INT +1");
			else if (craftSelect == 8) Craft2(108, "#t1072077#", "#v4011004# 2 #t4011004#s \r\n#v4000021# 50 #t4000021#s \r\n#v4003000# 15 #t4003000#s \r\n18,000 mesos", 30, "INT +1");
			else if (craftSelect == 9) Craft2(109, "#t1072078#", "#v4021008# #t4021008# \r\n#v4000021# 50 #t4000021#s \r\n#v4003000# 15 #t4003000#s \r\n18,000 mesos", 30, "INT +2");
			else if (craftSelect == 10) Craft2(110, "#t1072089#", "#v4021001# 3 #t4021001#s \r\n#v4021006# #t4021006# \r\n#v4000021# 30 #t4000021#s \r\n#v4000030# 15 #t4000030#s \r\n#v4003000# 20 #t4003000#s \r\n20,000 mesos", 35, "LUK +1, MP +10");
			else if (craftSelect == 11) Craft2(111, "#t1072090#", "#v4021000# 3 #t4021000#s \r\n#v4021006# #t4021006# \r\n#v4000021# 30 #t4000021#s \r\n#v4000030# 15 #t4000030#s \r\n#v4003000# 20 #t4003000#s \r\n20,000 mesos", 35, "INT +1, MP +10");
			else if (craftSelect == 12) Craft2(112, "#t1072091#", "#v4021008# 2 #t4021008#s \r\n#v4021006# #t4021006# \r\n#v4000021# 40 #t4000021#s \r\n#v4000030# 25 #t4000030#s \r\n#v4003000# 20 #t4003000#s \r\n22,000 mesos", 35, "INT +1, LUK +1");
			else if (craftSelect == 13) Craft2(113, "#t1072114#", "#v4021000# 4 #t4021000#s \r\n#v4000030# 40 #t4000030#s \r\n#v4000043# 35 #t4000043#s \r\n#v4003000# 25 #t4003000#s \r\n30,000 mesos", 40, "LUK +2, MP +5");
			else if (craftSelect == 14) Craft2(114, "#t1072115#", "#v4021005# 4 #t4021005#s \r\n#v4000030# 40 #t4000030#s \r\n#v4000037# 70 #t4000037#s \r\n#v4003000# 25 #t4003000#s \r\n30,000 mesos", 40, "LUK +2, MP +5");
			else if (craftSelect == 15) Craft2(115, "#t1072116#", "#v4011006# 2 #t4011006#s \r\n#v4021007# #t4021007# \r\n#v4000030# 40 #t4000030#s \r\n#v4000027# 20 #t4000027#s \r\n#v4003000# 25 #t4003000#s \r\n35,000 mesos", 40, "INT +2, MP +5");
			else if (craftSelect == 16) Craft2(116, "#t1072117#", "#v4021008# 2 #t4021008#s \r\n#v4021007# #t4021007# \r\n#v4000030# 40 #t4000030#s \r\n#v4000014# 30 #t4000014#s \r\n#v4003000# 30 #t4003000#s \r\n40,000 mesos", 40, "INT +2, LUK +1, MP +10");
			else if (craftSelect == 17) Craft2(117, "#t1072140#", "#v4021009# #t4021009# \r\n#v4011006# 3 #t4011006#s \r\n#v4021000# 3 #t4021000#s \r\n#v4000030# 60 #t4000030#s \r\n#v4003000# 40 #t4003000#s \r\n50,000 mesos", 50, "LUK +3");
			else if (craftSelect == 18) Craft2(118, "#t1072141#", "#v4021009# #t4021009# \r\n#v4011006# 3 #t4011006#s \r\n#v4021005# 3 #t4021005#s \r\n#v4000030# 60 #t4000030#s \r\n#v4003000# 40 #t4003000#s \r\n50,000 mesos", 50, "INT +1, LUK +2");
			else if (craftSelect == 19) Craft2(119, "#t1072142#", "#v4021009# #t4021009# \r\n#v4011006# 3 #t4011006#s \r\n#v4021001# 3 #t4021001#s \r\n#v4000030# 60 #t4000030#s \r\n#v4003000# 40 #t4003000#s \r\n50,000 mesos", 50, "INT +2, LUK +1");
			else if (craftSelect == 20) Craft2(120, "#t1072143#", "#v4021009# #t4021009# \r\n#v4011006# 3 #t4011006#s \r\n#v4021003# 3 #t4021003#s \r\n#v4000030# 60 #t4000030#s \r\n#v4003000# 40 #t4003000#s \r\n50,000 mesos", 50, "INT +3");
			else if (craftSelect == 21) Craft2(121, "#t1072136#", "#v4021009# #t4021009# \r\n#v4011006# 4 #t4011006#s \r\n#v4011005# 5 #t4011005#s \r\n#v4000030# 70 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n60,000 mesos", 60, "INT +1, LUK +3");
			else if (craftSelect == 22) Craft2(122, "#t1072137#", "#v4021009# #t4021009# \r\n#v4011006# 4 #t4011006#s \r\n#v4021003# 5 #t4021003#s \r\n#v4000030# 70 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n60,000 mesos", 60, "INT +2, LUK +2");
			else if (craftSelect == 23) Craft2(123, "#t1072138#", "#v4021009# #t4021009# \r\n#v4011006# 4 #t4011006#s \r\n#v4011003# 5 #t4011003#s \r\n#v4000030# 70 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n60,000 mesos", 60, "INT +3, LUK +1");
			else if (craftSelect == 24) Craft2(124, "#t1072139#", "#v4021009# #t4021009# \r\n#v4011006# 4 #t4011006#s \r\n#v4021002# 5 #t4021002#s \r\n#v4000030# 70 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n60,000 mesos", 60, "INT +3, LUK +1");
		}
		else if (craftType == 4)
		{
			int craftSelect = AskMenu("So, you want to make bowman shoes. What kind of shoes do you want to make?",
				(0, " #b#t1072027##k(level limit: 25, bowman)"),
				(1, " #b#t1072034##k(level limit: 25, bowman)"),
				(2, " #b#t1072069##k(level limit: 25, bowman)"),
				(3, " #b#t1072079##k(level limit: 30, bowman)"),
				(4, " #b#t1072080##k(level limit: 30, bowman)"),
				(5, " #b#t1072081##k(level limit: 30, bowman)"),
				(6, " #b#t1072082##k(level limit: 30, bowman)"),
				(7, " #b#t1072083##k(level limit: 30, bowman)"),
				(8, " #b#t1072101##k(level limit: 35, bowman)"),
				(9, " #b#t1072102##k(level limit: 35, bowman)"),
				(10, " #b#t1072103##k(level limit: 35, bowman)"),
				(11, " #b#t1072118##k(level limit: 40, bowman)"),
				(12, " #b#t1072119##k(level limit: 40, bowman)"),
				(13, " #b#t1072120##k(level limit: 40, bowman)"),
				(14, " #b#t1072121##k(level limit: 40, bowman)"),
				(15, " #b#t1072122##k(level limit: 50, bowman)"),
				(16, " #b#t1072123##k(level limit: 50, bowman)"),
				(17, " #b#t1072124##k(level limit: 50, bowman)"),
				(18, " #b#t1072125##k(level limit: 50, bowman)"),
				(19, " #b#t1072144##k(level limit: 60, bowman)"),
				(20, " #b#t1072145##k(level limit: 60, bowman)"),
				(21, " #b#t1072146##k(level limit: 60, bowman)"));
			
			if (craftSelect == 0) Craft2(200, "#t1072027#", "#v4011000# 3 #t4011000#s \r\n#v4000021# 35 #t4000021#s \r\n#v4003000# 10 #t4003000#s \r\n9,000 mesos", 25, "DEX +1");
			else if (craftSelect == 1) Craft2(201, "#t1072034#", "#v4021003# #t4021003# \r\n#v4000021# 35 #t4000021#s \r\n#v4003000# 10 #t4003000#s \r\n9,000 mesos", 25, "DEX +1");
			else if (craftSelect == 2) Craft2(202, "#t1072069#", "#v4021000# #t4021000# \r\n#v4000021# 35 #t4000021#s \r\n#v4003000# 10 #t4003000#s \r\n9,000 mesos", 25, "DEX +1");
			else if (craftSelect == 3) Craft2(203, "#t1072079#", "#v4021000# 2 #t4021000#s \r\n#v4000021# 50 #t4000021#s \r\n#v4003000# 15 #t4003000#s \r\n19,000 mesos", 30, "DEX +1");
			else if (craftSelect == 4) Craft2(204, "#t1072080#", "#v4021005# 2 #t4021005#s \r\n#v4000021# 50 #t4000021#s \r\n#v4003000# 15 #t4003000#s \r\n19,000 mesos", 30, "STR +1");
			else if (craftSelect == 5) Craft2(205, "#t1072081#", "#v4021003# 2 #t4021003#s \r\n#v4000021# 50 #t4000021#s \r\n#v4003000# 15 #t4003000#s \r\n19,000 mesos", 30, "DEX +1");
			else if (craftSelect == 6) Craft2(206, "#t1072082#", "#v4021004# 2 #t4021004#s \r\n#v4000021# 50 #t4000021#s \r\n#v4003000# 15 #t4003000#s \r\n19,000 mesos", 30, "DEX +1");
			else if (craftSelect == 7) Craft2(207, "#t1072083#", "#v4021006# 2 #t4021006#s \r\n#v4000021# 50 #t4000021#s \r\n#v4003000# 15 #t4003000#s \r\n19,000 mesos", 30, "STR +1");
			else if (craftSelect == 8) Craft2(208, "#t1072101#", "#v4021002# 3 #t4021002#s \r\n#v4021006# #t4021006# \r\n#v4000021# 30 #t4000021#s \r\n#v4000030# 15 #t4000030#s \r\n#v4003000# 20 #t4003000#s \r\n20,000 mesos", 35, "STR +2");
			else if (craftSelect == 9) Craft2(209, "#t1072102#", "#v4021003# 3 #t4021003#s \r\n#v4021006# #t4021006# \r\n#v4000021# 30 #t4000021#s \r\n#v4000030# 15 #t4000030#s \r\n#v4003000# 20 #t4003000#s \r\n20,000 mesos", 35, "DEX +2");
			else if (craftSelect == 10) Craft2(210, "#t1072103#", "#v4021000# 3 #t4021000#s \r\n#v4021006# #t4021006# \r\n#v4000021# 30 #t4000021#s \r\n#v4000030# 15 #t4000030#s \r\n#v4003000# 20 #t4003000#s \r\n20,000 mesos", 35, "STR +1, DEX +1");
			else if (craftSelect == 11) Craft2(211, "#t1072118#", "#v4021000# 4 #t4021000#s \r\n#v4000030# 45 #t4000030#s \r\n#v4000024# 40 #t4000024#s \r\n#v4003000# 30 #t4003000#s \r\n32,000 mesos", 40, "STR +2, MP +5");
			else if (craftSelect == 12) Craft2(212, "#t1072119#", "#v4021006# 4 #t4021006#s \r\n#v4000030# 45 #t4000030#s \r\n#v4000027# 20 #t4000027#s \r\n#v4003000# 30 #t4003000#s \r\n32,000 mesos", 40, "DEX +1, STR +1, MP +5");
			else if (craftSelect == 13) Craft2(213, "#t1072120#", "#v4011003# 5 #t4011003#s \r\n#v4000030# 45 #t4000030#s \r\n#v4000044# 40 #t4000044#s \r\n#v4003000# 30 #t4003000#s \r\n40,000 mesos", 40, "DEX +2, MP +5");
			else if (craftSelect == 14) Craft2(214, "#t1072121#", "#v4021002# 5 #t4021002#s \r\n#v4000030# 45 #t4000030#s \r\n#v4000009# 120 #t4000009#s \r\n#v4003000# 30 #t4003000#s \r\n40,000 mesos", 40, "DEX +2, MP +5");
			else if (craftSelect == 15) Craft2(215, "#t1072122#", "#v4021008# #t4021008# \r\n#v4011001# 3 #t4011001#s \r\n#v4021006# 3 #t4021006#s \r\n#v4000030# 60 #t4000030#s \r\n#v4000033# 80 #t4000033#s \r\n#v4003000# 35 #t4003000#s \r\n50,000 mesos", 50, "STR +3");
			else if (craftSelect == 16) Craft2(216, "#t1072123#", "#v4021008# #t4021008# \r\n#v4011001# 3 #t4011001#s \r\n#v4021006# 3 #t4021006#s \r\n#v4000030# 60 #t4000030#s \r\n#v4000032# 150 #t4000032#s \r\n#v4003000# 35 #t4003000#s \r\n50,000 mesos", 50, "DEX +1, STR +2");
			else if (craftSelect == 17) Craft2(217, "#t1072124#", "#v4021008# #t4021008# \r\n#v4011001# 3 #t4011001#s \r\n#v4021006# 3 #t4021006#s \r\n#v4000030# 60 #t4000030#s \r\n#v4000041# 100 #t4000041#s \r\n#v4003000# 35 #t4003000#s \r\n50,000 mesos", 50, "DEX +2, STR +1");
			else if (craftSelect == 18) Craft2(218, "#t1072125#", "#v4021008# #t4021008# \r\n#v4011001# 3 #t4011001#s \r\n#v4021006# 3 #t4021006#s \r\n#v4000030# 60 #t4000030#s \r\n#v4000042# 250 #t4000042#s \r\n#v4003000# 35 #t4003000#s \r\n50,000 mesos", 50, "DEX +3");
			else if (craftSelect == 19) Craft2(219, "#t1072144#", "#v4021007# #t4021007# \r\n#v4011006# 5 #t4011006#s \r\n#v4021000# 8 #t4021000#s \r\n#v4000030# 75 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n60,000 mesos", 60, "DEX +1, STR +3");
			else if (craftSelect == 20) Craft2(220, "#t1072145#", "#v4021007# #t4021007# \r\n#v4011006# 5 #t4011006#s \r\n#v4021005# 8 #t4021005#s \r\n#v4000030# 75 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n60,000 mesos", 60, "DEX +2, STR +2");
			else if (craftSelect == 21) Craft2(221, "#t1072146#", "#v4021007# #t4021007# \r\n#v4011006# 5 #t4011006#s \r\n#v4021003# 8 #t4021003#s \r\n#v4000030# 75 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n60,000 mesos", 60, "DEX +3, STR +1");
		}
		else if (craftType == 5)
		{
			int craftSelect = AskMenu("So, you want to make thief shoes. What kind of shoes do you want to make?",
				(0, " #b#t1072084##k(level limit: 25, thief)"),
				(1, " #b#t1072085##k(level limit: 25, thief)"),
				(2, " #b#t1072086##k(level limit: 25, thief)"),
				(3, " #b#t1072087##k(level limit: 25, thief)"),
				(4, " #b#t1072032##k(level limit: 30, thief)"),
				(5, " #b#t1072033##k(level limit: 30, thief)"),
				(6, " #b#t1072035##k(level limit: 30, thief)"),
				(7, " #b#t1072036##k(level limit: 30, thief)"),
				(8, " #b#t1072104##k(level limit: 35, thief)"),
				(9, " #b#t1072105##k(level limit: 35, thief)"),
				(10, " #b#t1072106##k(level limit: 35, thief)"),
				(11, " #b#t1072108##k(level limit: 40, thief)"),
				(12, " #b#t1072109##k(level limit: 40, thief)"),
				(13, " #b#t1072110##k(level limit: 40, thief)"),
				(14, " #b#t1072107##k(level limit: 40, thief)"),
				(15, " #b#t1072128##k(level limit: 50, thief)"),
				(16, " #b#t1072129##k(level limit: 50, thief)"),
				(17, " #b#t1072130##k(level limit: 50, thief)"),
				(18, " #b#t1072131##k(level limit: 50, thief)"),
				(19, " #b#t1072150##k(level limit: 60, thief)"),
				(20, " #b#t1072151##k(level limit: 60, thief)"),
				(21, " #b#t1072152##k(level limit: 60, thief)"));
				
			if (craftSelect == 0) Craft2(300, "#t1072084#", "#v4021005# #t4021005# \r\n#v4000021# 35 #t4000021#s \r\n#v4003000# 10 #t4003000#s \r\n9,000 mesos", 25, "LUK +1");
			else if (craftSelect == 1) Craft2(301, "#t1072085#", "#v4021000# #t4021000# \r\n#v4000021# 35 #t4000021#s \r\n#v4003000# 10 #t4003000#s \r\n9,000 mesos", 25, "LUK +1");
			else if (craftSelect == 2) Craft2(302, "#t1072086#", "#v4021003# #t4021003# \r\n#v4000021# 35 #t4000021#s \r\n#v4003000# 10 #t4003000#s \r\n9,000 mesos", 25, "LUK +1");
			else if (craftSelect == 3) Craft2(303, "#t1072087#", "#v4021004# #t4021004# \r\n#v4000021# 35 #t4000021#s \r\n#v4003000# 10 #t4003000#s \r\n9,000 mesos", 25, "LUK +1");
			else if (craftSelect == 4) Craft2(304, "#t1072032#", "#v4011000# 3 #t4011000#s \r\n#v4000021# 50 #t4000021#s \r\n#v4003000# 15 #t4003000#s \r\n19,000 mesos", 30, "DEX +1");
			else if (craftSelect == 5) Craft2(305, "#t1072033#", "#v4011001# 3 #t4011001#s \r\n#v4000021# 50 #t4000021#s \r\n#v4003000# 15 #t4003000#s \r\n19,000 mesos", 30, "LUK +1");
			else if (craftSelect == 6) Craft2(306, "#t1072035#", "#v4011004# 2 #t4011004#s \r\n#v4000021# 50 #t4000021#s \r\n#v4003000# 15 #t4003000#s \r\n19,000 mesos", 30, "LUK +1");
			else if (craftSelect == 7) Craft2(307, "#t1072036#", "#v4011006# 2 #t4011006#s \r\n#v4000021# 50 #t4000021#s \r\n#v4003000# 15 #t4003000#s \r\n21,000 mesos", 30, "DEX +2");
			else if (craftSelect == 8) Craft2(308, "#t1072104#", "#v4021000# 3 #t4021000#s \r\n#v4021004# #t4021004# \r\n#v4000021# 30 #t4000021#s \r\n#v4000030# 15 #t4000030#s \r\n#v4003000# 20 #t4003000#s \r\n20,000 mesos", 35, "LUK +2");
			else if (craftSelect == 9) Craft2(309, "#t1072105#", "#v4021003# 3 #t4021003#s \r\n#v4021004# #t4021004# \r\n#v4000021# 30 #t4000021#s \r\n#v4000030# 15 #t4000030#s \r\n#v4003000# 20 #t4003000#s \r\n20,000 mesos", 35, "DEX +2");
			else if (craftSelect == 10) Craft2(310, "#t1072106#", "#v4021002# 3 #t4021002#s \r\n#v4021004# #t4021004# \r\n#v4000021# 30 #t4000021#s \r\n#v4000030# 15 #t4000030#s \r\n#v4003000# 20 #t4003000#s \r\n20,000 mesos", 35, "LUK +1, DEX +1");
			else if (craftSelect == 11) Craft2(311, "#t1072108#", "#v4021003# 4 #t4021003#s \r\n#v4000030# 45 #t4000030#s \r\n#v4000032# 30 #t4000032#s \r\n#v4003000# 30 #t4003000#s \r\n32,000 mesos", 40, "DEX +2, MP +5");
			else if (craftSelect == 12) Craft2(312, "#t1072109#", "#v4021006# 4 #t4021006#s \r\n#v4000030# 45 #t4000030#s \r\n#v4000040# 3 #t4000040#s \r\n#v4003000# 30 #t4003000#s \r\n35,000 mesos", 40, "LUK +1, STR +1, MP +5");
			else if (craftSelect == 13) Craft2(313, "#t1072110#", "#v4021005# 4 #t4021005#s \r\n#v4000030# 45 #t4000030#s \r\n#v4000037# 70 #t4000037#s \r\n#v4003000# 30 #t4003000#s \r\n35,000 mesos", 40, "LUK +1, DEX +1, MP +5");
			else if (craftSelect == 14) Craft2(314, "#t1072107#", "#v4021000# 5 #t4021000#s \r\n#v4000030# 45 #t4000030#s \r\n#v4000033# 50 #t4000033#s \r\n#v4003000# 30 #t4003000#s \r\n40,000 mesos", 40, "LUK +2, MP +5");
			else if (craftSelect == 15) Craft2(315, "#t1072128#", "#v4011007# 2 #t4011007#s \r\n#v4021005# 3 #t4021005#s \r\n#v4000030# 50 #t4000030#s \r\n#v4000037# 200 #t4000037#s \r\n#v4003000# 35 #t4003000#s \r\n50,000 mesos", 50, "STR +3");
			else if (craftSelect == 16) Craft2(316, "#t1072129#", "#v4011007# 2 #t4011007#s \r\n#v4021003# 3 #t4021003#s \r\n#v4000030# 50 #t4000030#s \r\n#v4000045# 80 #t4000045#s \r\n#v4003000# 35 #t4003000#s \r\n50,000 mesos", 50, "DEX +3");
			else if (craftSelect == 17) Craft2(317, "#t1072130#", "#v4011007# 2 #t4011007#s \r\n#v4021000# 3 #t4021000#s \r\n#v4000030# 50 #t4000030#s \r\n#v4000043# 150 #t4000043#s \r\n#v4003000# 35 #t4003000#s \r\n50,000 mesos", 50, "LUK +3");
			else if (craftSelect == 18) Craft2(318, "#t1072131#", "#v4011007# 2 #t4011007#s \r\n#v4021001# 3 #t4021001#s \r\n#v4000030# 50 #t4000030#s \r\n#v4000036# 80 #t4000036#s \r\n#v4003000# 35 #t4003000#s \r\n50,000 mesos", 50, "LUK +2, DEX +1");
			else if (craftSelect == 19) Craft2(319, "#t1072150#", "#v4021007# #t4021007# \r\n#v4011007# #t4011007# \r\n#v4021000# 8 #t4021000#s \r\n#v4000030# 75 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n60,000 mesos", 60, "LUK +1, STR +3");
			else if (craftSelect == 20) Craft2(320, "#t1072151#", "#v4021007# #t4021007# \r\n#v4011007# #t4011007# \r\n#v4011006# 5 #t4011006#s \r\n#v4000030# 75 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n60,000 mesos", 60, "STR +1, DEX +3");
			else if (craftSelect == 21) Craft2(321, "#t1072152#", "#v4021007# #t4021007# \r\n#v4011007# #t4011007# \r\n#v4021008# #t4021008# \r\n#v4000030# 75 #t4000030# \r\n#v4003000# 50 #t4003000# \r\n60,000 mesos", 60, "DEX +1, LUK +3");
		}
	}
	#endregion
	
	private void RaggedGladius()
	{
		string quest = GetQuestData(1000201);
		
		if (quest == "ms")
		{
			self.say("#b#t1302014##k ... A few decades ago, when I found out that Tristan had passed away, I couldn't believe my ears. I was the one that made the #b#t1302014##k for him. I thought anyone worthy of possessing that sword would have been indestructible. I heard that the sword has since gone bad ... has it gone old and rusty?");
			self.say("So you want to reawaken this sword. It's not an easy task, though. You'll need to not only gather up hard-to-find materials, you'll also need a rare scroll for it. But if you still want to go along with it ... then I want you to gather up the materials I'm about to tell you. I don't know if you can do it, but ...");
			
			SetQuestData(1000201, "mc");
			self.say("I'll need #b1 #t4021009##k, #b1 #t4003002##k, #b1 #t4001005##k, and #b1 \r\n#t4001006##k ... To find these, you will need to talk to someone who knows a lot about the island ... I think #b#p1040001##k, the one guarding the entrance to the dungeon, will know how to get them ...");
		}
		else if (quest == "mc")
		{
			if (ItemCount(4001006) < 1 || ItemCount(4003002) < 1 || ItemCount(4021009) < 1 || ItemCount(4001005) < 1)
			{
				self.say("I may have gone old and gray, but my eyes cannot be deceived. Please gather up #b1 #t4021009##k, #b1 #t4003002##k, #b1 \r\n#t4001005##k, and #b1 #t4001006##k, because I don't think you have them all yet.");
				return;
			}
			
			self.say("My goodness!!! You did collect #b1 #t4021009##k, #b1 #t4003002##k, #b1 #t4001005##k, and #b1 #t4001006##k!!! Alright, then. Hold on one second. I haven't done this in ages, but ... with these materials, I may be able to pull off the magic and reawaken the #b#t1302014##k.");
			
			if (!Exchange(0, 4021009, -1, 4003002, -1, 4001005, -1, 4001006, -1, 1302014, -1, 1302015, 1))
			{
				self.say("Hmm... are you sure you brought all of the necessary materials and the #b#t1302014##k? If so, make sure there's an empty space in your equip. inventory.");
				return;
			}
			
			AddEXP(1000);
			SetQuestData(1000201, "mh");
			self.say("Incredible ... Tristan's sword ... I didn't think I'd live to see this again. I don't know who left you with this, but please tell that person that this sword is meant to be used the right way. My work is done. So long ...");
		}
	}
	
	public override void Run()
	{
		string quest = GetQuestData(1000201);
		
		if (quest == "ms" || quest == "mc")
		{
			AskMenuCallback("You need something...?#b",
				(" Manji's Ragged Gladius", RaggedGladius),
				(" I heard you can make shoes...", StartRefine));
		}
		else
		{
			StartRefine();
		}
	}
}