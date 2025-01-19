using System;
using System.Collections.Generic;
using WvsBeta.Game;

// 2041027 - Mason the Collector
public class NpcScript : IScriptV2
{
	private void Collector()
	{
		var rnd = new Random();
		string quest = GetQuestData(1007000);
		
		if (quest == "")
		{
			bool start = AskYesNo("A marble that emits a mysterious sparkle... I saw with my very own eyes; I can't help, I want it!! I want Aurora Marble!!! I want it... Get that marble for me.");
			
			if (!start)
			{
				self.say("If you get me the Aurora Marble, I'll give you something from my collection. Get me that sparkling marble.");
				return;
			}
			
			SetQuestData(1007000, "s");
			self.say("Are you really going to get it for me? I went to the #bWarped Path of Time#k before to collect some items, and that's where I saw it... and it was right there on the ground!!!!");
			self.say("Aurora Marble, very mystifying. I was ready to take it when someone else took it and ran away with it!! Very angry now, thinking about it. I want the marble, and I want it now.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031189) < 1)
			{
				self.say("No. Not it. You don't have the marble I am looking for!");
				return;
			}
			
			self.say("You may find yourself staring at that mystifying light. Did you bring it? Show it to me.");
			
			if (SlotCount(4) < 1)
			{
				self.say("You need 1 empty slot in your etc. inventory!");
				return;
			}
			
			int rnum = rnd.Next(0, 100);
			
			int itemID = -1;
			
			if (rnum < 10) itemID = 4004000;
			else if (rnum < 20) itemID = 4004001;
			else if (rnum < 30) itemID = 4004002;
			else if (rnum < 40) itemID = 4011007;
			else if (rnum < 50) itemID = 4011006;
			else if (rnum < 60) itemID = 4011005;
			else if (rnum < 70) itemID = 4080006;
			else if (rnum < 80) itemID = 4080010;
			else if (rnum < 85) itemID = 4004004;
			else if (rnum < 90) itemID = 4004003;
			else if (rnum < 100) itemID = 4080011;
			
			if (!Exchange(0, 4031189, -1, itemID, 1))
			{
				self.say("Are you sure you have the marble I am looking for??");
				return;
			}
			
			AddEXP(2700);
			SetQuestData(1007000, "1");
			QuestEndEffect();
			self.say("This is it. Yes, the beautiful, mystifying colors. This marble deserves to be part of my collection. I now give you an item from the collection as I promised..");
		}
		else if (quest == "1")
		{
			bool start2 = AskYesNo("Aurora Marble, very important part of my collection. I don't think it looked like that in the beginning, though. I give you goodies if you give me the Aurora Marble in its original state.");
			
			if (!start2)
			{
				self.say("You don't like the goodies I gave you the last time you gave me the Aurora Marble? What do you like? I give you something else this time. Get me the marble, first.");
				return;
			}
			
			SetQuestData(1007000, "2");
			self.say("Doesn't Lazy Buffy have the Aurora Marble? I do not think it has it; it has something else.");
			self.say("Get me the marble, any way possible. Add my knowledge to that marble, and I get more Aurora Marbles later on.");
		}
		else if (quest == "2")
		{
			if (ItemCount(4031195) < 10 || ItemCount(4000129) < 50)
			{
				self.say("50 Lazy Buffy Marbles and 10 Aurora Marbles. Are they correct? Do you have all?");
				return;
			}
			
			self.say("Have it? Bring it? Did you? Where? Let me see.");
			
			if (SlotCount(2) < 1 || SlotCount(4) < 1)
			{
				self.say("You need 1 empty slot in your use and etc. inventories!!");
				return;
			}
			
			int rnum = rnd.Next(0, 58);
			
			int itemID = -1;
			
			if (rnum < 5) itemID = 4131005;
			else if (rnum < 10) itemID = 4131006;
			else if (rnum < 15) itemID = 4131007;
			else if (rnum < 20) itemID = 4131008;
			else if (rnum < 25) itemID = 4131009;
			else if (rnum < 30) itemID = 4131010;
			else if (rnum < 35) itemID = 4131011;
			else if (rnum < 40) itemID = 4131012;
			else if (rnum < 45) itemID = 4131013;
			else if (rnum < 50) itemID = 4131003;
			else if (rnum < 55) itemID = 4131004;
			else if (rnum < 58) itemID = 2070009;
			
			if (!Exchange(0, 4000129, -50, 4031195, -10, itemID, 1))
			{
				self.say("Are you sure you have the 50 Lazy Buffy Marbles and 10 Aurora Marbles??");
				return;
			}
			
			AddEXP(38000);
			SetQuestData(1007000, "e");
			QuestEndEffect();
			self.say("Do you know the feeling of getting exactly what you covet and desire? Now, I give you a goody that may be useful to you. Take it.");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1007000)
		{
			if (info != "e" && Level >= 60)
				return " Mason the Collector";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1007000};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "I want this, this, this, and that...";
		
		if (GetQuestData(1007000) == "e")
			dialogue = "Anything else to collect???";
		
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
			case 0: Collector(); break;
		}
	}
}