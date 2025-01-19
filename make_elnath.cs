using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Craft(int index, string makeItem, string needItem, int reqLevel, string itemOption)
	{
		bool askBuy = AskYesNo($"You want to make {makeItem}? If so, I'll need the following materials. There's a #r{itemOption}#k improvement on the item. The level limit is {reqLevel}. What do you think? Do you want to make it?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("I understand. Is the service fee too high for you? But understand that I will be in this town for a long time, so if some day you want to refine anything, just bring it to me.");
			return;
		}
		
		bool trade = false;
		
		// Warrior shoes
		if (index == 0) trade = Exchange(-60000, 4021008, -1, 4011007, -1, 4021005, -8, 4000030, -80, 4003000, -55, 1072147, 1);
		else if (index == 1) trade = Exchange(-60000, 4021008, -1, 4011007, -1, 4011005, -8, 4000030, -80, 4003000, -55, 1072148, 1);
		else if (index == 2) trade = Exchange(-60000, 4021008, -1, 4011007, -1, 4021000, -8, 4000030, -80, 4003000, -55, 1072149, 1);
		else if (index == 3) trade = Exchange(-70000, 4005000, -1, 4005002, -3, 4011002, -5, 4000048, -100, 4003000, -60, 1072154, 1);
		else if (index == 4) trade = Exchange(-70000, 4005000, -2, 4005002, -2, 4011005, -5, 4000048, -100, 4003000, -60, 1072155, 1);
		else if (index == 5) trade = Exchange(-70000, 4005000, -3, 4005002, -1, 4021008, -1, 4000048, -100, 4003000, -60, 1072156, 1);
		else if (index == 6) trade = Exchange(-80000, 4005000, -2, 4005002, -3, 4021000, -7, 4000030, -90, 4003000, -65, 1072210, 1);
		else if (index == 7) trade = Exchange(-80000, 4005000, -3, 4005002, -2, 4021002, -7, 4000030, -90, 4003000, -65, 1072211, 1);
		else if (index == 8) trade = Exchange(-80000, 4005000, -4, 4005002, -1, 4021008, -2, 4000030, -90, 4003000, -65, 1072212, 1);
		
		// Magician shoes
		else if (index == 100) trade = Exchange(-60000, 4021009, -1, 4011006, -4, 4011005, -5, 4000030, -70, 4003000, -50, 1072136, 1);
		else if (index == 101) trade = Exchange(-60000, 4021009, -1, 4011006, -4, 4021003, -5, 4000030, -70, 4003000, -50, 1072137, 1);
		else if (index == 102) trade = Exchange(-60000, 4021009, -1, 4011006, -4, 4011003, -5, 4000030, -70, 4003000, -50, 1072138, 1);
		else if (index == 103) trade = Exchange(-60000, 4021009, -1, 4011006, -4, 4021002, -5, 4000030, -70, 4003000, -50, 1072139, 1);
		else if (index == 104) trade = Exchange(-70000, 4005001, -1, 4005003, -3, 4021002, -5, 4000051, -100, 4003000, -55, 1072157, 1);
		else if (index == 105) trade = Exchange(-70000, 4005001, -2, 4005003, -2, 4021000, -5, 4000051, -100, 4003000, -55, 1072158, 1);
		else if (index == 106) trade = Exchange(-70000, 4005001, -3, 4005003, -1, 4011003, -5, 4000051, -100, 4003000, -55, 1072159, 1);
		else if (index == 107) trade = Exchange(-70000, 4005001, -3, 4005003, -1, 4011006, -3, 4000051, -100, 4003000, -55, 1072160, 1);
		else if (index == 108) trade = Exchange(-80000, 4005001, -2, 4005003, -3, 4021003, -7, 4000030, -85, 4003000, -60, 1072177, 1);
		else if (index == 109) trade = Exchange(-80000, 4005001, -3, 4005003, -2, 4021001, -7, 4000030, -85, 4003000, -60, 1072178, 1);
		else if (index == 110) trade = Exchange(-80000, 4005001, -4, 4005003, -1, 4021008, -2, 4000030, -85, 4003000, -60, 1072179, 1);
		
		// Bowman shoes
		else if (index == 200) trade = Exchange(-60000, 4021007, -1, 4011006, -5, 4021000, -8, 4000030, -75, 4003000, -50, 1072144, 1);
		else if (index == 201) trade = Exchange(-60000, 4021007, -1, 4011006, -5, 4021005, -8, 4000030, -75, 4003000, -50, 1072145, 1);
		else if (index == 202) trade = Exchange(-60000, 4021007, -1, 4011006, -5, 4021003, -8, 4000030, -75, 4003000, -50, 1072146, 1);
		else if (index == 203) trade = Exchange(-70000, 4005002, -1, 4005000, -3, 4021005, -5, 4000055, -100, 4003000, -55, 1072164, 1);
		else if (index == 204) trade = Exchange(-70000, 4005002, -2, 4005000, -2, 4021004, -5, 4000055, -100, 4003000, -55, 1072165, 1);
		else if (index == 205) trade = Exchange(-70000, 4005002, -2, 4005000, -2, 4021003, -5, 4000055, -100, 4003000, -55, 1072166, 1);
		else if (index == 206) trade = Exchange(-70000, 4005002, -3, 4005000, -1, 4021008, -1, 4000055, -100, 4003000, -55, 1072167, 1);
		else if (index == 207) trade = Exchange(-80000, 4005002, -2, 4005000, -3, 4021002, -7, 4000030, -90, 4003000, -60, 1072182, 1);
		else if (index == 208) trade = Exchange(-80000, 4005002, -3, 4005000, -2, 4021000, -7, 4000030, -90, 4003000, -60, 1072183, 1);
		else if (index == 209) trade = Exchange(-80000, 4005002, -4, 4005000, -1, 4021003, -7, 4000030, -90, 4003000, -60, 1072184, 1);
		else if (index == 210) trade = Exchange(-80000, 4005002, -5, 4021008, -2, 4000030, -90, 4003000, -60, 1072185, 1);
		
		// Thief shoes
		else if (index == 300) trade = Exchange(-60000, 4021007, -1, 4011007, -1, 4021000, -8, 4000030, -75, 4003000, -50, 1072150, 1);
		else if (index == 301) trade = Exchange(-60000, 4021007, -1, 4011007, -1, 4011006, -5, 4000030, -75, 4003000, -50, 1072151, 1);
		else if (index == 302) trade = Exchange(-60000, 4021007, -1, 4011007, -1, 4021008, -1, 4000030, -75, 4003000, -50, 1072152, 1);
		else if (index == 303) trade = Exchange(-70000, 4005003, -1, 4005000, -3, 4021001, -5, 4000051, -100, 4003000, -55, 1072161, 1);
		else if (index == 304) trade = Exchange(-70000, 4005000, -1, 4005002, -3, 4021005, -5, 4000051, -100, 4003000, -55, 1072162, 1);
		else if (index == 305) trade = Exchange(-70000, 4005002, -1, 4005003, -3, 4021000, -5, 4000051, -100, 4003000, -55, 1072163, 1);
		else if (index == 306) trade = Exchange(-80000, 4005000, -3, 4005003, -2, 4021003, -7, 4000030, -90, 4003000, -60, 1072172, 1);
		else if (index == 307) trade = Exchange(-80000, 4005002, -3, 4005003, -2, 4021000, -7, 4000030, -90, 4003000, -60, 1072173, 1);
		else if (index == 308) trade = Exchange(-80000, 4005003, -3, 4005002, -2, 4021008, -7, 4000030, -90, 4003000, -60, 1072174, 1);
		
		if (!trade)
		{
			self.say("Yes, yes, yes... Please make sure that you have all the necessary materials, and that there's a free space in your inventory.");
			return;
		}
			
		self.say($"Here, take the {makeItem}! What do you think? With these beauties it looks like you won't have any problems walking around, right?");
	}
	
	public override void Run()
	{
		int craftType = AskMenu("Here is a town where it's easy to obtain the materials necessary for creating high quality shoes. The leather and skin of the monsters that roam around here make perfect materials for shoes. They are a little dangerous, but you won't have any problems... Are you looking for someone to make a perfect pair of shoes for you? If so, I can do the job... What kind of shoes do you want me to make?#b",
			(0, " Create warrior shoes"),
			(1, " Create magician shoes"),
			(2, " Create bowman shoes"),
			(3, " Create thief shoes"));
		
		if (craftType == 0)
		{
			int craftSelect = AskMenu("So, you want shoes only for warriors? What kind of shoes do you want to make?",
				(0, " #b#t1072147##k(level limit: 60, warrior)"),
				(1, " #b#t1072148##k(level limit: 60, warrior)"),
				(2, " #b#t1072149##k(level limit: 60, warrior)"),
				(3, " #b#t1072154##k(level limit: 70, warrior)"),
				(4, " #b#t1072155##k(level limit: 70, warrior)"),
				(5, " #b#t1072156##k(level limit: 70, warrior)"),
				(6, " #b#t1072210##k(level limit: 80, warrior)"),
				(7, " #b#t1072211##k(level limit: 80, warrior)"),
				(8, " #b#t1072212##k(level limit: 80, warrior)"));
				
			if (craftSelect == 0) Craft(0, "#t1072147#", "#v4021008# #t4021008# \r\n#v4011007# #t4011007# \r\n#v4021005# 8 #t4021005#s \r\n#v4000030# 80 #t4000030#s \r\n#v4003000# 55 #t4003000#s \r\n60000 mesos", 60, "STR +1, DEX +3");
			else if (craftSelect == 1) Craft(1, "#t1072148#", "#v4021008# #t4021008# \r\n#v4011007# #t4011007# \r\n#v4011005# 8 #t4011005#s \r\n#v4000030# 80 #t4000030#s \r\n#v4003000# 55 #t4003000#s \r\n60000 mesos", 60, "STR +2, DEX +2");
			else if (craftSelect == 2) Craft(2, "#t1072149#", "#v4021008# #t4021008# \r\n#v4011007# #t4011007# \r\n#v4021000# 8 #t4021000#s \r\n#v4000030# 80 #t4000030#s \r\n#v4003000# 55 #t4003000#s \r\n60000 mesos", 60, "STR +3, DEX +1");
			else if (craftSelect == 3) Craft(3, "#t1072154#", "#v4005000# #t4005000# \r\n#v4005002# 3 #t4005002#s \r\n#v4011002# 5 #t4011002#s \r\n#v4000048# 100 #t4000048#s \r\n#v4003000# 60 #t4003000#s \r\n70000 mesos", 70, "STR +1, DEX +3, Accuracy +1");
			else if (craftSelect == 4) Craft(4, "#t1072155#", "#v4005000# 2 #t4005000#s \r\n#v4005002# 2 #t4005002#s \r\n#v4011005# 5 #t4011005#s \r\n#v4000048# 100 #t4000048#s \r\n#v4003000# 60 #t4003000#s \r\n70000 mesos", 70, "STR +2, DEX +2, Accuracy +1");
			else if (craftSelect == 5) Craft(5, "#t1072156#", "#v4005000# 3 #t4005000#s \r\n#v4005002# #t4005002# \r\n#v4021008# #t4021008# \r\n#v4000048# 100 #t4000048#s \r\n#v4003000# 60 #t4003000#s \r\n70000 mesos", 70, "STR +3, DEX +1, Accuracy +1");
			else if (craftSelect == 6) Craft(6, "#t1072210#", "#v4005000# 2 #t4005000#s \r\n#v4005002# 3 #t4005002#s \r\n#v4021000# 7 #t4021000#s \r\n#v4000030# 90 #t4000030#s \r\n#v4003000# 65 #t4003000#s \r\n80000 mesos", 80, "STR +2, DEX +3");
			else if (craftSelect == 7) Craft(7, "#t1072211#", "#v4005000# 3 #t4005000#s \r\n#v4005002# 2 #t4005002#s \r\n#v4021002# 7 #t4021002#s \r\n#v4000030# 90 #t4000030#s \r\n#v4003000# 65 #t4003000#s \r\n80000 mesos", 80, "STR +3, DEX +2");
			else if (craftSelect == 8) Craft(8, "#t1072212#", "#v4005000# 4 #t4005000#s \r\n#v4005002# #t4005002# \r\n#v4021008# 2 #t4021008#s \r\n#v4000030# 90 #t4000030#s \r\n#v4003000# 65 #t4003000#s \r\n80000 mesos", 80, "STR +4, DEX +1");
		}
		else if (craftType == 1)
		{
			int craftSelect = AskMenu("So, you want shoes only for magicians? So, what kind of shoes do you want to make?",
				(0, " #b#t1072136##k(level limit: 60, magician)"),
				(1, " #b#t1072137##k(level limit: 60, magician)"),
				(2, " #b#t1072138##k(level limit: 60, magician)"),
				(3, " #b#t1072139##k(level limit: 60, magician)"),
				(4, " #b#t1072157##k(level limit: 70, magician)"),
				(5, " #b#t1072158##k(level limit: 70, magician)"),
				(6, " #b#t1072159##k(level limit: 70, magician)"),
				(7, " #b#t1072160##k(level limit: 70, magician)"),
				(8, " #b#t1072177##k(level limit: 80, magician)"),
				(9, " #b#t1072178##k(level limit: 80, magician)"),
				(10, " #b#t1072179##k(level limit: 80, magician)"));
				
			if (craftSelect == 0) Craft(100, "#t1072136#", "#v4021009# #t4021009#\r\n#v4011006# 4 #t4011006#s\r\n#v4011005# 5 #t4011005#s\r\n#v4000030# 70 #t4000030#s\r\n#v4003000# 50 #t4003000#s\r\n60000 mesos", 60, "INT +1, LUK +3");
			else if (craftSelect == 1) Craft(101, "#t1072137#", "#v4021009# #t4021009# \r\n#v4011006# 4 #t4011006#s \r\n#v4021003# 5 #t4021003#s \r\n#v4000030# 70 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n60000 mesos", 60, "INT +2, LUK +2");
			else if (craftSelect == 2) Craft(102, "#t1072138#", "#v4021009# #t4021009# \r\n#v4011006# 4 #t4011006#s \r\n#v4011003# 5 #t4011003#s \r\n#v4000030# 70 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n60000 mesos", 60, "INT +3, LUK +1");
			else if (craftSelect == 3) Craft(103, "#t1072139#", "#v4021009# #t4021009# \r\n#v4011006# 4 #t4011006#s \r\n#v4021002# 5 #t4021002#s \r\n#v4000030# 70 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n60000 mesos", 60, "INT +3, LUK +1");
			else if (craftSelect == 4) Craft(104, "#t1072157#", "#v4005001# #t4005001# \r\n#v4005003# 3 #t4005003#s \r\n#v4021002# 5 #t4021002#s \r\n#v4000051# 100 #t4000051#s \r\n#v4003000# 55 #t4003000#s \r\n70000 mesos", 70, "INT +1, LUK +3, Magic Atk. +1");
			else if (craftSelect == 5) Craft(105, "#t1072158#", "#v4005001# 2 #t4005001#s \r\n#v4005003# 2 #t4005003#s \r\n#v4021000# 5 #t4021000#s \r\n#v4000051# 100 #t4000051#s \r\n#v4003000# 55 #t4003000#s \r\n70000 mesos", 70, "INT +2, LUK +2, Magic Atk. +1");
			else if (craftSelect == 6) Craft(106, "#t1072159#", "#v4005001# 3 #t4005001#s \r\n#v4005003# #t4005003# \r\n#v4011003# 5 #t4011003#s \r\n#v4000051# 100 #t4000051#s \r\n#v4003000# 55 #t4003000#s \r\n70000 mesos", 70, "INT +3, LUK +1, Magic Atk. +1");
			else if (craftSelect == 7) Craft(107, "#t1072160#", "#v4005001# 3 #t4005001#s \r\n#v4005003# #t4005003# \r\n#v4011006# 3 #t4011006#s \r\n#v4000051# 100 #t4000051#s \r\n#v4003000# 55 #t4003000#s \r\n70000 mesos", 70, "INT +3, LUK +1, Magic Atk. +1");
			else if (craftSelect == 8) Craft(108, "#t1072177#", "#v4005001# 2 #t4005001#s \r\n#v4005003# 3 #t4005003#s \r\n#v4021003# 7 #t4021003#s \r\n#v4000030# 85 #t4000030#s \r\n#v4003000# 60 #t4003000#s \r\n80000 mesos", 80, "INT +2, LUK +3");
			else if (craftSelect == 9) Craft(109, "#t1072178#", "#v4005001# 3 #t4005001#s \r\n#v4005003# 2 #t4005003#s \r\n#v4021001# 7 #t4021001#s \r\n#v4000030# 85 #t4000030#s \r\n#v4003000# 60 #t4003000#s \r\n80000 mesos", 80, "INT +3, LUK +2");
			else if (craftSelect == 10) Craft(110, "#t1072179#", "#v4005001# 4 #t4005001#s \r\n#v4005003# #t4005003# \r\n#v4021008# 2 #t4021008#s \r\n#v4000030# 85 #t4000030#s \r\n#v4003000# 60 #t4003000#s \r\n80000 mesos", 80, "INT +4, LUK +1");
		}
		else if (craftType == 2)
		{
			int craftSelect = AskMenu("So, you want shoes only for bowmen? So, what kind of shoes do you want to make?",
				(0, " #b#t1072144##k(level limit: 60, bowman)"),
				(1, " #b#t1072145##k(level limit: 60, bowman)"),
				(2, " #b#t1072146##k(level limit: 60, bowman)"),
				(3, " #b#t1072164##k(level limit: 70, bowman)"),
				(4, " #b#t1072165##k(level limit: 70, bowman)"),
				(5, " #b#t1072166##k(level limit: 70, bowman)"),
				(6, " #b#t1072167##k(level limit: 70, bowman)"),
				(7, " #b#t1072182##k(level limit: 80, bowman)"),
				(8, " #b#t1072183##k(level limit: 80, bowman)"),
				(9, " #b#t1072184##k(level limit: 80, bowman)"),
				(10, " #b#t1072185##k(level limit: 80, bowman)"));
				
			if (craftSelect == 0) Craft(200, "#t1072144#", "#v4021007# #t4021007#s\r\n#v4011006# 5 #t4011006#s\r\n#v4021000# 8 #t4021000#s\r\n#v4000030# 75 #t4000030#s\r\n#v4003000# 50 #t4003000#s \r\n60000 mesos", 60, "DEX +1, STR +3");
			else if (craftSelect == 1) Craft(201, "#t1072145#", "#v4021007# #t4021007# \r\n#v4011006# 5 #t4011006#s \r\n#v4021005# 8 #t4021005#s \r\n#v4000030# 75 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n60000 mesos", 60, "DEX +1, STR +3");
			else if (craftSelect == 2) Craft(202, "#t1072146#", "#v4021007# #t4021007# \r\n#v4011006# 5 #t4011006#s \r\n#v4021003# 8 #t4021003#s \r\n#v4000030# 75 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n60000 mesos", 60, "DEX +1, STR +3");
			else if (craftSelect == 3) Craft(203, "#t1072164#", "#v4005002# #t4005002# \r\n#v4005000# 3 #t4005000#s \r\n#v4021005# 5 #t4021005#s \r\n#v4000055# 100 #t4000055#s \r\n#v4003000# 55 #t4003000#s \r\n70000 mesos", 70, "DEX +1, STR +3, Avoid. +1");
			else if (craftSelect == 4) Craft(204, "#t1072165#", "#v4005002# 2 #t4005002#s \r\n#v4005000# 2 #t4005000#s \r\n#v4021004# 5 #t4021004#s \r\n#v4000055# 100 #t4000055#s \r\n#v4003000# 55 #t4003000#s \r\n70000 mesos", 70, "DEX +2, STR +2, Avoid. +1");
			else if (craftSelect == 5) Craft(205, "#t1072166#", "#v4005002# 2 #t4005002#s \r\n#v4005000# 2 #t4005000#s \r\n#v4021003# 5 #t4021003#s \r\n#v4000055# 100 #t4000055#s \r\n#v4003000# 55 #t4003000#s \r\n70000 mesos", 70, "DEX +2, STR +2, Avoid. +1");
			else if (craftSelect == 6) Craft(206, "#t1072167#", "#v4005002# 3 #t4005002#s \r\n#v4005000# #t4005000# \r\n#v4021008# #t4021008# \r\n#v4000055# 100 #t4000055#s \r\n#v4003000# 55 #t4003000#s \r\n70000 mesos", 70, "DEX +3, STR +1, Avoid. +1");
			else if (craftSelect == 7) Craft(207, "#t1072182#", "#v4005002# 2 #t4005002#s \r\n#v4005000# 3#t4005000#s \r\n#v4021002# 7 #t4021002#s \r\n#v4000030# 90 #t4000030#s \r\n#v4003000# 60 #t4003000#s \r\n80000 mesos", 80, "DEX +2, STR +3");
			else if (craftSelect == 8) Craft(208, "#t1072183#", "#v4005002# 3 #t4005002#s \r\n#v4005000# 2#t4005000#s \r\n#v4021000# 7 #t4021000#s \r\n#v4000030# 90 #t4000030#s \r\n#v4003000# 60 #t4003000#s \r\n80000 mesos", 80, "DEX +3, STR +2");
			else if (craftSelect == 9) Craft(209, "#t1072184#", "#v4005002# 4 #t4005002#s \r\n#v4005000# #t4005000# \r\n#v4021003# 7 #t4021003#s \r\n#v4000030# 90 #t4000030#s \r\n#v4003000# 60 #t4003000#s \r\n80000 mesos", 80, "DEX +4, STR +1");
			else if (craftSelect == 10) Craft(210, "#t1072185#", "#v4005002# 5 #t4005002#s \r\n#v4021008# 2 #t4021008#s \r\n#v4000030# 90 #t4000030#s \r\n#v4003000# 60 #t4003000#s \r\n80000 mesos", 80, "DEX +5");
		}
		else if (craftType == 3)
		{
			int craftSelect = AskMenu("So, you want shoes only for thieves? So, what kind of shoes do you want to make?",
				(0, " #b#t1072150##k(level limit: 60, thief)"),
				(1, " #b#t1072151##k(level limit: 60, thief)"),
				(2, " #b#t1072152##k(level limit: 60, thief)"),
				(3, " #b#t1072161##k(level limit: 70, thief)"),
				(4, " #b#t1072162##k(level limit: 70, thief)"),
				(5, " #b#t1072163##k(level limit: 70, thief)"),
				(6, " #b#t1072172##k(level limit: 80, thief)"),
				(7, " #b#t1072173##k(level limit: 80, thief)"),
				(8, " #b#t1072174##k(level limit: 80, thief)"));
				
			if (craftSelect == 0) Craft(300, "#t1072150#", "#v4021007# #t4021007# \r\n#v4011007# #t4011007# \r\n#v4021000# 8 #t4021000#s \r\n#v4000030# 75 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n60000 mesos", 60, "LUK +1, STR +3");
			else if (craftSelect == 1) Craft(301, "#t1072151#", "#v4021007# #t4021007# \r\n#v4011007# #t4011007# \r\n#v4011006# 5 #t4011006#s \r\n#v4000030# 75 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n60000 mesos", 60, "STR +1, DEX +3");
			else if (craftSelect == 2) Craft(302, "#t1072152#", "#v4021007# #t4021007# \r\n#v4011007# #t4011007# \r\n#v4021008# #t4021008# \r\n#v4000030# 75 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n60000 mesos", 60, "DEX +1, LUK +3");
			else if (craftSelect == 3) Craft(303, "#t1072161#", "#v4005003# #t4005003# \r\n#v4005000# 3 #t4005000#s \r\n#v4021001# 5 #t4021001#s \r\n#v4000051# 100 #t4000051#s \r\n#v4003000# 55 #t4003000#s \r\n70000 mesos", 70, "LUK +1, STR +3, Avoid. +1");
			else if (craftSelect == 4) Craft(304, "#t1072162#", "#v4005000# #t4005000# \r\n#v4005002# 3 #t4005002#s \r\n#v4021005# 5 #t4021005#s \r\n#v4000051# 100 #t4000051#s \r\n#v4003000# 55 #t4003000#s \r\n70000 mesos", 70, "STR +1, DEX +3, Avoid. +1");
			else if (craftSelect == 5) Craft(305, "#t1072163#", "#v4005002# #t4005002# \r\n#v4005003# 3 #t4005003#s \r\n#v4021000# 5 #t4021000#s \r\n#v4000051# 100 #t4000051#s \r\n#v4003000# 55 #t4003000#s \r\n70000 mesos", 70, "DEX +1, LUK +3, Avoid. +1");
			else if (craftSelect == 6) Craft(306, "#t1072172#", "#v4005000# 3 #t4005000#s \r\n#v4005003# 2 #t4005003#s \r\n#v4021003# 7 #t4021003#s \r\n#v4000030# 90 #t4000030#s \r\n#v4003000# 60 #t4003000#s \r\n80000 mesos", 80, "STR +3, LUK +2");
			else if (craftSelect == 7) Craft(307, "#t1072173#", "#v4005002# 3 #t4005002#s \r\n#v4005003# 2 #t4005003#s \r\n#v4021000# 7 #t4021000#s \r\n#v4000030# 90 #t4000030#s \r\n#v4003000# 60 #t4003000#s \r\n80000 mesos", 80, "DEX +3, LUK +2");
			else if (craftSelect == 8) Craft(308, "#t1072174#", "#v4005003# 3 #t4005003#s \r\n#v4005002# 2 #t4005002#s \r\n#v4021008# 7 #t4021008#s \r\n#v4000030# 90 #t4000030#s \r\n#v4003000# 60 #t4003000#s \r\n80000 mesos", 80, "LUK +3, DEX +2");
		}
	}
}