using System;
using System.Collections.Generic;
using WvsBeta.Game;
using WvsBeta.Common;

// 1061011 The Rememberer
public class NpcScript : IScriptV2
{
	// Green Mushroom - Lv 15
	private void Wanted1(string quest, int step)
	{
		if (quest != "000")
		{
			self.say("Phew... I've been quietly meditating here, and you almost ended it. Please talk in whispers. Ah, so you're having a hard time understanding the notice I put up on the notice board. Please eliminate #bGreen Mushrooms#k, then come back here.");
			return;
		}
		
		if (step == 1)
		{
			self.say("It must be something important for you to talk to me here... oh hey there! You did manage to eliminate #b99 #o1110100#s#k. I can see 99 #o1110100#s hovering behind you. Incredible!");
			
			if (!Exchange(0, 2000002, 50))
			{
				self.say("Make sure there is an empty space in your use inventory.");
				return;
			}
			
			AddEXP(2500);
			SetQuestData(1007800, "e");
			QuestEndEffect();
			self.say("I can tell you're noble enough to do this without expecting anything return, but this is just my way of saying thank you for helping us out. Please take it.");
			self.say("You're not saying that you're going to end your journey here, right? Inside the Dungeon, you'll find nothing but really powerful, dangerous monsters. I've put up bulletin boards everywhere, so find those. I'll reward you well, if the job is done right.");
		}
		else if (step == 2)
		{
			self.say("Shhh! Silence! This requires total concentration. The study of levitation is that of an art, and even a small mistake will ruin everything. How about studying it with me? You do seem heavy for this... anyway, how can I help you? Do you have something to ... Hey! You! You must have eliminated #b999 \r\n#o1110100#s#k. I can see 999 #o1110100#s hovering behind you. Incredible!");
			
			if (!Exchange(0, 2000000, 50))
			{
				self.say("Make sure there is an empty space in your use inventory.");
				return;
			}
			
			AddEXP(600);
			SetQuestData(1007801, "e");
			SetQuestData(1007802, DateTime.UtcNow.ToString("yyyyMMdd"));
			QuestEndEffect();
			self.say("I can tell you're noble enough to do this without expecting anything return, but this is just my way of saying thank you for helping us out. Please take it.");
			self.say("You're not saying that you're going to end your journey here, right? Inside the Dungeon, you'll find nothing but really powerful, dangerous monsters. I've put up bulletin boards everywhere, so find those. I'll reward you well, if the job is done right. Watch out for those monsters!");
		}
	}
	
	// Horned Mushroom - Lv 20
	private void Wanted2(string quest, int step)
	{
		if (quest != "000")
		{
			self.say("Phew... I've been quietly meditating here, and you almost ended it. Please talk in whispers. Ah, so you're having a hard time understanding the notice I put up on the notice board. Please defeat #bHorned Mushrooms#k, then come back here.");
			return;
		}
		
		if (step == 1)
		{
			self.say("Ahh, concentrate! Phew... the art of levitation is such a delicate one that requires so much energy and effort, that one mishap can surely ruin it all. Please talk to me in whispers next time!");
			self.say("It must be something important for you to talk to me here... oh hey there! You did manage to eliminate #b99 #o2110200#s#k. I can see 99 #o2110200#s hovering behind you. Incredible!");
			
			if (!Exchange(0, 2000002, 100))
			{
				self.say("Make sure there is an empty space in your use inventory.");
				return;
			}
			
			AddEXP(3000);
			SetQuestData(1007900, "e");
			QuestEndEffect();
			self.say("I can tell you're noble enough to do this without expecting anything return, but this is just my way of saying thank you for helping us out. Please take it.");
			self.say("You're not saying that you're going to end your journey here, right? Inside the Dungeon, you'll find nothing but really powerful, dangerous monsters. I've put up bulletin boards everywhere, so find those. I'll reward you well, if the job is done right. Watch out for those monsters!");
		}
		else if (step == 2)
		{
			self.say("Ahh, concentrate! Phew... the art of levitation is such a delicate one that requires so much energy and effort, that one mishap can surely ruin it all. Please talk to me in whispers next time!");
			self.say("It must be something important for you to talk to me here... oh hey there! You did manage to eliminate #b999 #o2110200#s#k. I can see 999 #o2110200#s hovering behind you. Incredible!");
			
			if (!Exchange(0, 2000001, 50))
			{
				self.say("Make sure there is an empty space in your use inventory.");
				return;
			}
			
			AddEXP(1100);
			SetQuestData(1007901, "e");
			SetQuestData(1007902, DateTime.UtcNow.ToString("yyyyMMdd"));
			QuestEndEffect();
			self.say("I can tell you're noble enough to do this without expecting anything return, but this is just my way of saying thank you for helping us out. Please take it.");
			self.say("You're not saying that you're going to end your journey here, right? Inside the Dungeon, you'll find nothing but really powerful, dangerous monsters. I've put up bulletin boards everywhere, so find those. I'll reward you well, if the job is done right. Watch out for those monsters!");
		}
	}
	
	// Zombie Mushroom - Lv 22
	private void Wanted3(string quest, int step)
	{
		if (quest != "000")
		{
			self.say("Phew... I've been quietly meditating here, and you almost ended it. Please talk in whispers. Ah, so you're having a hard time understanding the notice I put up on the notice board. Please elminite #bZombie Mushrooms#k, then come back here.");
			return;
		}
		
		if (step == 1)
		{
			self.say("Ahh, concentrate! Phew... the art of levitation is such a delicate one that requires so much energy and effort, that one mishap can surely ruin it all. Please talk to me in whispers next time!");
			self.say("How can I help you? Are you interested in levitation, too? This is not for everyone... Hey! You! You must have eliminated #b99 #o2230101#s#k. I can see 99 #o2230101#s hovering behind you. Incredible!");
			
			if (!Exchange(0, 2000006, 50))
			{
				self.say("Make sure there is an empty space in your use inventory.");
				return;
			}
			
			AddEXP(3500);
			SetQuestData(1008000, "e");
			QuestEndEffect();
			self.say("I can tell you're noble enough to do this without expecting anything return, but this is just my way of saying thank you for helping us out. Please take it.");
			self.say("You're not saying that you're going to end your journey here, right? Inside the Dungeon, you'll find nothing but really powerful, dangerous monsters. I've put up bulletin boards everywhere, so find those. I'll reward you well, if the job is done right.");
		}
		else if (step == 2)
		{
			self.say("Ahh, concentrate! Phew... the art of levitation is such a delicate one that requires so much energy and effort, that one mishap can surely ruin it all. Please talk to me in whispers next time!");
			self.say("How can I help you? Are you interested in levitation, too? This is not for everyone... Hey! You! You must have eliminated #b999 #o2230101#s#k. I can see 99 #o2230101#s hovering behind you. Incredible!");
			
			if (!Exchange(0, 2000003, 50))
			{
				self.say("Make sure there is an empty space in your use inventory.");
				return;
			}
			
			AddEXP(1400);
			SetQuestData(1008001, "e");
			SetQuestData(1008002, DateTime.UtcNow.ToString("yyyyMMdd"));
			QuestEndEffect();
			self.say("I can tell you're noble enough to do this without expecting anything return, but this is just my way of saying thank you for helping us out. Please take it.");
			self.say("You're not saying that you're going to end your journey here, right? Inside the Dungeon, you'll find nothing but really powerful, dangerous monsters. I've put up bulletin boards everywhere, so find those. I'll reward you well, if the job is done right.");
		}
	}
	
	// Evil Eye - Lv 25
	private void Wanted4(string quest, int step)
	{
		if (quest != "000")
		{
			self.say("Phew... I've been quietly meditating here, and you almost ended it. Please talk in whispers. Ah, so you're having a hard time understanding the notice I put up on the notice board. Please eliminate #bEvil Eyes#k, then come back here.");
			return;
		}
		
		if (step == 1)
		{
			self.say("Ahh, concentrate! Phew... the art of levitation is such a delicate one that requires so much energy and effort, that one mishap can surely ruin it all. Please talk to me in whispers next time!");
			self.say("Anyway, what's going on? Anything urgent...? Hey! You found the polluted monsters. These monsters used to be just harmless animals, but with the dangerous force of polluted air, they have transformed into nasty monsters. Anything else strange around there? Anyway, I can't believe you managed to eliminate #b99 #o2230100#s#k. I can see 99 #o2230100#s hovering behind you. Don't you feel a little heavy on your back?");
			
			if (!Exchange(0, 2000006, 100))
			{
				self.say("Make sure there is an empty space in your use inventory.");
				return;
			}
			
			AddEXP(4000);
			SetQuestData(1008100, "e");
			QuestEndEffect();
			self.say("I can tell you're noble enough to do this without expecting anything return, but this is just my way of saying thank you for helping us out. Please take it.");
			self.say("You're not saying that you're going to end your journey here, right? Inside the Dungeon, you'll find nothing but really powerful, dangerous monsters. I've put up bulletin boards everywhere, so find those. I'll reward you well, if the job is done right. Watch out for those monsters!");
		}
		else if (step == 2)
		{
			self.say("Ahh, concentrate! Phew... the art of levitation is such a delicate one that requires so much energy and effort, that one mishap can surely ruin it all. Please talk to me in whispers next time!");
			self.say("Anyway, what's going on? Anything urgent...? Hey! You found the polluted monsters. These monsters used to be just harmless animals, but with the dangerous force of polluted air, they have transformed into nasty monsters. Anything else strange around there? Anyway, I can't believe you managed to eliminate #b999 #o2230100#s#k. I can see 999 #o2230100#s hovering behind you. Don't you feel a little heavy on your back?");
			
			if (!Exchange(0, 2000006, 30))
			{
				self.say("Make sure there is an empty space in your use inventory.");
				return;
			}
			
			AddEXP(2000);
			SetQuestData(1008101, "e");
			SetQuestData(1008102, DateTime.UtcNow.ToString("yyyyMMdd"));
			QuestEndEffect();
			self.say("I can tell you're noble enough to do this without expecting anything return, but this is just my way of saying thank you for helping us out. Please take it.");
			self.say("You're not saying that you're going to end your journey here, right? Inside the Dungeon, you'll find nothing but really powerful, dangerous monsters. I've put up bulletin boards everywhere, so find those. I'll reward you well, if the job is done right. Watch out for those monsters!");
		}
	}
	
	// Curse Eye - Lv 30
	private void Wanted5(string quest, int step)
	{
		if (quest != "000")
		{
			self.say("Phew... I've been quietly meditating here, and you almost ended it. Please talk in whispers. Ah, so you're having a hard time understanding the notice I put up on the notice board. Please eliminate #bCurse Eyes#k, then come back here.");
			return;
		}
		
		if (step == 1)
		{
			self.say("Ahh, concentrate! Phew... the art of levitation is such a delicate one that requires so much energy and effort, that one mishap can surely ruin it all. Please talk to me in whispers next time!");
			self.say("Anyway, what's going on? ... Hey! You found the polluted monsters. These monsters used to be just harmless animals, but with the dangerous force of polluted air, they have transformed into nasty monsters. Anything else strange around there? Anyway, I can't believe you managed to eliminate #b99 #o3230100#s#k. I can see 99 #o3230100#s hovering behind you. Don't you feel icky on your back?");
			
			if (SlotCount(2) < 1)
			{
				self.say("Make sure there is an empty space in your use inventory.");
				return;
			}
			
			var rewards = new List<(int, int, int)>();
			
			if (Job >= 100 && Job < 200)
			{
				rewards.Add((2044101, 1, 2));
				rewards.Add((2043001, 1, 2));
				rewards.Add((2043101, 1, 2));
				rewards.Add((2043201, 1, 2));
				rewards.Add((2043301, 1, 2));
				rewards.Add((2044001, 1, 2));
				rewards.Add((2044201, 1, 2));
				rewards.Add((2044301, 1, 2));
				rewards.Add((2044401, 1, 2));
			}
			else if (Job >= 200 && Job < 300)
			{
				rewards.Add((2043701, 1, 9));
				rewards.Add((2043801, 1, 9));
			}
			else if (Job >= 300 && Job < 400)
			{
				rewards.Add((2044501, 1, 9));
				rewards.Add((2044601, 1, 9));
			}
			else if (Job >= 400 && Job < 500)
			{
				rewards.Add((2043301, 1, 9));
				rewards.Add((2044701, 1, 9));
			}
			
			rewards.Add((2020015, 3, 6));
			rewards.Add((2020014, 3, 6));
			rewards.Add((2020013, 5, 6));
			
			var item = rewards.RandomElementByWeight(tuple => tuple.Item3);
			
			if (item == default)
				return;
			
			int itemID = item.Item1;
			int itemNum = item.Item2;
			
			if (!Exchange(0, itemID, itemNum))
			{
				self.say("Make sure there is an empty space in your use inventory.");
				return;
			}
			
			AddEXP(4500);
			SetQuestData(1008200, "e");
			QuestEndEffect();
			self.say("I can tell you're noble enough to do this without expecting anything return, but this is just my way of saying thank you for helping us out. Please take it.");
			self.say("You're not saying that you're going to end your journey here, right? Inside the Dungeon, you'll find nothing but really powerful, dangerous monsters. I've put up bulletin boards everywhere, so find those. I'll reward you well, if the job is done right. Watch out for those monsters!");
		}
		else if (step == 2)
		{
			self.say("Ahh, concentrate! Phew... the art of levitation is such a delicate one that requires so much energy and effort, that one mishap can surely ruin it all. Please talk to me in whispers next time!");
			self.say("Anyway, what's going on? ... Hey! You found the polluted monsters. These monsters used to be just harmless animals, but with the dangerous force of polluted air, they have transformed into nasty monsters. Anything else strange around there? Anyway, I can't believe you managed to eliminate #b999 #o3230100#s#k. I can see 999 #o3230100#s hovering behind you. Don't you feel icky on your back?");
			
			if (SlotCount(2) < 1)
			{
				self.say("Make sure there is an empty space in your use inventory.");
				return;
			}
			
			var rewards = new List<(int, int, int)>();
			
			if (Job >= 100 && Job < 200)
			{
				rewards.Add((2043000, 1, 9));
				rewards.Add((2043100, 1, 9));
				rewards.Add((2043200, 1, 9));
				rewards.Add((2044000, 1, 9));
				rewards.Add((2044100, 1, 9));
				rewards.Add((2044200, 1, 9));
				rewards.Add((2044300, 1, 9));
				rewards.Add((2044400, 1, 9));
				rewards.Add((2043001, 1, 4));
				rewards.Add((2043101, 1, 4));
				rewards.Add((2043201, 1, 4));
				rewards.Add((2044001, 1, 4));
				rewards.Add((2044101, 1, 4));
				rewards.Add((2044201, 1, 4));
				rewards.Add((2044301, 1, 4));
				rewards.Add((2044401, 1, 4));
			}
			else if (Job >= 200 && Job < 300)
			{
				rewards.Add((2043700, 1, 36));
				rewards.Add((2043800, 1, 36));
				rewards.Add((2043701, 1, 16));
				rewards.Add((2043801, 1, 16));
			}
			else if (Job >= 300 && Job < 400)
			{
				rewards.Add((2044500, 1, 36));
				rewards.Add((2044600, 1, 36));
				rewards.Add((2044501, 1, 16));
				rewards.Add((2044601, 1, 16));
			}
			else if (Job >= 400 && Job < 500)
			{
				rewards.Add((2044700, 1, 36));
				rewards.Add((2043300, 1, 36));
				rewards.Add((2044701, 1, 16));
				rewards.Add((2043301, 1, 16));
			}
			
			rewards.Add((2041013, 1, 1));
			rewards.Add((2041019, 1, 1));
			rewards.Add((2041022, 1, 1));
			rewards.Add((2041016, 1, 1));
			rewards.Add((2020013, 3, 216));
			rewards.Add((2020014, 2, 216));
			rewards.Add((2020015, 2, 216));
			rewards.Add((2000004, 10, 72));
			
			var item = rewards.RandomElementByWeight(tuple => tuple.Item3);
			
			if (item == default)
				return;
			
			int itemID = item.Item1;
			int itemNum = item.Item2;
			
			if (!Exchange(0, itemID, itemNum))
			{
				self.say("Make sure there is an empty space in your use inventory.");
				return;
			}
			
			AddEXP(3000);
			SetQuestData(1008201, "e");
			SetQuestData(1008202, DateTime.UtcNow.ToString("yyyyMMdd"));
			QuestEndEffect();
			self.say("I can tell you're noble enough to do this without expecting anything return, but this is just my way of saying thank you for helping us out. Please take it.");
			self.say("You're not saying that you're going to end your journey here, right? Inside the Dungeon, you'll find nothing but really powerful, dangerous monsters. I've put up bulletin boards everywhere, so find those. I'll reward you well, if the job is done right. Watch out for those monsters!");
		}
	}
	
	// Jr. Boogie - Lv 33
	private void Wanted6(string quest)
	{
		if (ItemCount(4000067) < 10)
		{
			self.say("Phew... I've been quietly meditating here, and you almost ended it. Please talk in whispers. Ah, so you're having a hard time understanding the notice I put up on the notice board. Please eliminate the Jr. Boogies and bring back #b10 #t4000067#s#k that it drops.");
			return;
		}
		
		self.say("Ahh, concentrate! Phew... the art of levitation is such a delicate one that requires so much energy and effort, that one mishap can surely ruin it all. Please talk to me in whispers next time!");
		self.say("Anyway how can I help you?... Oh! You! Did you find the Jr. Boogies by chance? Ever since they transformed into a hideous creature thanks to pollution, they have been notorious for attacking travelers from left and right. I know it's only 10, but I think that buys some time for travelers to walk around safely for a few. Were their horns contaminated, too? I knew it. For you to last its attack looking unscathed... wow...");
		
		if (SlotCount(4) < 1)
		{
			self.say("Make sure there is an empty space in your etc. inventory.");
			return;
		}
		
		var rnd = new Random();
		int[] items = {4021000, 4021001, 4021002, 4021003, 4021004, 4021005, 4021006, 4021007};
		
		int itemID = items[rnd.Next(items.Length)];
		
		if (!Exchange(0, 4000067, -10, itemID, 1))
		{
			self.say("Are you sure you brought all 10 of Jr. Boogie's horns?");
			return;
		}
		
		AddEXP(3500);
		SetQuestData(1008300, "e");
		QuestEndEffect();
		self.say("I can tell you're noble enough to do this without expecting anything return, but this is just my way of saying thank you for helping us out. Please take it.");
		self.say("You're not saying that you're going to end your journey here, right? Inside the Dungeon, you'll find nothing but really powerful, dangerous monsters. I've put up bulletin boards everywhere, so find those. I'll reward you well, if the job is done right. Watch out for those monsters!");
	}
	
	// Cold Eye - Lv 35
	private void Wanted7(string quest)
	{
		if (ItemCount(4000023) < 100)
		{
			self.say("Phew... I've been quietly meditating here, and you almost ended it. Please talk in whispers. Ah, so you're having a hard time understanding the notice I put up on the notice board. Please eliminate the Cold Eyes and bring back #b100 #t4000023#s#k that it drops.");
			return;
		}
		
		self.say("Ahh, concentrate! Phew... the art of levitation is such a delicate one that requires so much energy and effort, that one mishap can surely ruin it all. Please talk to me in whispers next time!");
		self.say("Anyway how can I help you?... Oh! You! Did you find the Cold Eyes by chance? I put up the notice in order to warn travelers who were exploring deep into the Ant Tunnel. I know it's only 100, but I think that buys some time for travelers to walk around safely for a few. Were their tails contaminated, too? I knew it. For you to last its attack looking unscathed... wow...");
		
		if (SlotCount(2) < 1)
		{
			self.say("Make sure there is an empty space in your use inventory.");
			return;
		}
		
		var rewards = new List<(int, int, int)>();
			
		if (Job < 200)
		{
			rewards.Add((2044101, 1, 2));
			rewards.Add((2043001, 1, 2));
			rewards.Add((2043101, 1, 2));
			rewards.Add((2043201, 1, 2));
			rewards.Add((2043301, 1, 2));
			rewards.Add((2044001, 1, 2));
			rewards.Add((2044201, 1, 2));
			rewards.Add((2044301, 1, 2));
			rewards.Add((2044401, 1, 2));
		}
		else if (Job >= 200 && Job < 300)
		{
			rewards.Add((2043701, 1, 9));
			rewards.Add((2043801, 1, 9));
		}
		else if (Job >= 300 && Job < 400)
		{
			rewards.Add((2044501, 1, 9));
			rewards.Add((2044601, 1, 9));
		}
		else if (Job >= 400 && Job < 500)
		{
			rewards.Add((2043301, 1, 9));
			rewards.Add((2044701, 1, 9));
		}
		
		var item = rewards.RandomElementByWeight(tuple => tuple.Item3);
			
		if (item == default)
			return;
		
		int itemID = item.Item1;
		int itemNum = item.Item2;
		
		if (!Exchange(0, 4000023, -100, itemID, itemNum))
		{
			self.say("Are you sure you brought all 100 of Cold Eye's tails?");
			return;
		}
		
		AddEXP(5000);
		SetQuestData(1008400, "e");
		QuestEndEffect();
		self.say("I can tell you're noble enough to do this without expecting anything return, but this is just my way of saying thank you for helping us out. Please take it.");
		self.say("You're not saying that you're going to end your journey here, right? Inside the Dungeon, you'll find nothing but really powerful, dangerous monsters. I've put up bulletin boards everywhere, so find those. I'll reward you well, if the job is done right. Watch out for those monsters!");
	}
	
	// Drake - Lv 45
	private void Wanted8(string quest)
	{
		if (ItemCount(4000014) < 200)
		{
			self.say("Phew... I've been quietly meditating here, and you almost ended it. Please talk in whispers. Ah, so you're having a hard time understanding the notice I put up on the notice board. Please eliminate the Drakes and bring back #b200 #t4000014#s#k that it drops.");
			return;
		}
		
		self.say("Ahh, concentrate! Phew... the art of levitation is such a delicate one that requires so much energy and effort, that one mishap can surely ruin it all. Please talk to me in whispers next time!");
		self.say("Anyway how can I help you?... Oh! You! Did you find the Drakes by chance? I put up the notice in order to warn travelers who were exploring deep into the Ant Tunnel. I know it's only 200, but I think that buys some time for travelers to walk around safely for a few. Were their skulls contaminated, too? I knew it. For you to last its attack looking unscathed... wow...");
		
		if (SlotCount(2) < 1)
		{
			self.say("Make sure there is an empty space in your etc. inventory.");
			return;
		}
		
		var rewards = new List<(int, int, int)>();
			
		if (Job < 200)
		{
			rewards.Add((2044102, 1, 2));
			rewards.Add((2043002, 1, 2));
			rewards.Add((2043102, 1, 2));
			rewards.Add((2043202, 1, 2));
			rewards.Add((2043302, 1, 2));
			rewards.Add((2044002, 1, 2));
			rewards.Add((2044202, 1, 2));
			rewards.Add((2044302, 1, 2));
			rewards.Add((2044402, 1, 2));
		}
		else if (Job >= 200 && Job < 300)
		{
			rewards.Add((2043702, 1, 9));
			rewards.Add((2043802, 1, 9));
		}
		else if (Job >= 300 && Job < 400)
		{
			rewards.Add((2044502, 1, 9));
			rewards.Add((2044602, 1, 9));
		}
		else if (Job >= 400 && Job < 500)
		{
			rewards.Add((2043302, 1, 9));
			rewards.Add((2044702, 1, 9));
		}
		
		var item = rewards.RandomElementByWeight(tuple => tuple.Item3);
			
		if (item == default)
			return;
		
		int itemID = item.Item1;
		int itemNum = item.Item2;
		
		if (!Exchange(0, 4000014, -200, itemID, itemNum))
		{
			self.say("Are you sure you brought all 200 of Drake's skulls?");
			return;
		}
		
		AddEXP(10000);
		SetQuestData(1008500, "e");
		QuestEndEffect();
		self.say("I can tell you're noble enough to do this without expecting anything return, but this is just my way of saying thank you for helping us out. Please take it.");
		self.say("You're not saying that you're going to end your journey here, right? Inside the Dungeon, you'll find nothing but really powerful, dangerous monsters. I've put up bulletin boards everywhere, so find those. I'll reward you well, if the job is done right. Watch out for those monsters!");
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1007800 || quest == 1007801)
		{
			if (info != "" && info != "e")
				return " DANGER! <1-G. Mushroom>";
		}
		else if (quest == 1007900 || quest == 1007901)
		{
			if (info != "" && info != "e")
				return " DANGER! <2-H. Mushroom>";
		}
		else if (quest == 1008000 || quest == 1008001)
		{
			if (info != "" && info != "e")
				return " DANGER! <3-Z. Mushroom>";
		}
		else if (quest == 1008100 || quest == 1008101)
		{
			if (info != "" && info != "e")
				return " POLLUTED! <1-Evil Eye>";
		}
		else if (quest == 1008200 || quest == 1008201)
		{
			if (info != "" && info != "e")
				return " POLLUTED! <2-Curse Eye>";
		}
		else if (quest == 1008300)
		{
			if (info == "s")
				return " POLLUTED! <3-Jr. Boogie>";
		}
		else if (quest == 1008400)
		{
			if (info == "s")
				return " WARNING! <1-Cold Eye>";
		}
		else if (quest == 1008500)
		{
			if (info == "s")
				return " WARNING! <2-Drake>";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1007800, 1007801, 1007900, 1007901, 1008000, 1008001, 1008100, 1008101, 1008200, 1008201, 1008300, 1008400, 1008500};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "To train mentally, I need to concentrate 100%.";
		
		if (GetQuestData(1008300) == "e")
			dialogue = "If you study for a long time, you'll be able to float in the air.";
		
		if (options.Count == 0)
		{
			self.say(dialogue);
			return;
		}
		
		int choice = -1;
		
		if (options.Count >= 2)
			choice = AskMenu($"{dialogue}#b", options.ToArray());
		else
			choice = options[0].Index;
		
		switch(choice)
		{
			case 0: Wanted1(GetQuestData(1007800), 1); break;
			case 1: Wanted1(GetQuestData(1007801), 2); break;
			case 2: Wanted2(GetQuestData(1007900), 1); break;
			case 3: Wanted2(GetQuestData(1007901), 2); break;
			case 4: Wanted3(GetQuestData(1008000), 1); break;
			case 5: Wanted3(GetQuestData(1008001), 2); break;
			case 6: Wanted4(GetQuestData(1008100), 1); break;
			case 7: Wanted4(GetQuestData(1008101), 2); break;
			case 8: Wanted5(GetQuestData(1008200), 1); break;
			case 9: Wanted5(GetQuestData(1008201), 2); break;
			case 10: Wanted6(GetQuestData(1008300)); break;
			case 11: Wanted7(GetQuestData(1008400)); break;
			case 12: Wanted8(GetQuestData(1008500)); break;
		}
	}
}