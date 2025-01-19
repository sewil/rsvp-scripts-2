using System;
using System.Collections.Generic;
using WvsBeta.Game;

// 2022003 Shammos
public class NpcScript : IScriptV2
{
	private void Awakening()
	{
		string quest = GetQuestData(1007300);
		
		if (quest == "")
		{
			bool start = AskYesNo("Hehehe... you should check out my story...");
			
			if (!start)
			{
				self.say("Hehe... please help me... I will reward you handsomely for it.");
				return;
			}
			
			SetQuestData(1007300, "s");
			self.say("Hah... alright, please don't be alarmed by my appearance. I can use some help right now. I have something planned these days, and I need something to get it started.");
			self.say("What am I planning for? I'm afraid I can't tell you that... anyway, in order to successfully complete a ritual, I'll need\r\n#b#t4031218##k. Have you ever heard of it?");
			self.say("I'm sure you haven't... its very existence is a stuff of legend, and I've spent a lot of time trying to find it... but the only thing I've found so far is that the person that knows about #b#t4031218##k resides somewhere in #bPerion#k.");
			self.say("Go to #bPerion#k, find that person, and bring #b#t4031218##k with you from him. I'll pay you handsomely for your work.");
		}
		else if (quest == "s")
		{
			self.say("You haven't found #b#t4031218##k, yet ... hehe.");
		}
		else if (quest == "1")
		{
			if (ItemCount(4031218) < 1)
			{
				self.say("You haven't found #b#t4031218##k, yet ... hehe.");
				return;
			}
			
			self.say("Oh, wow ... how did you ... how did you find #b#t4031218##k? I'm glad I trusted you to take care of this job. Hugh ... the things are going well for us now.");
			
			var rnd = new Random();
			int[] scrolls = {2040701, 2040702, 2040704, 2040705, 2040707, 2040708};
			
			int itemID = scrolls[rnd.Next(scrolls.Length)];
			
			if (!Exchange(0, 4031218, -1, itemID, 1))
			{
				self.say("You need room in your use inventory first ... hehe.");
				return;
			}
			
			AddFame(-2);
			SetQuestData(1007300, "e");
			QuestEndEffect();
			self.say("Hehe ... I need to get this plan in action ... I may need your help down the road ... please come see me some other time.");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1007300)
		{
			if ((info == "" && Level >= 55) || info == "s")
				return " Shammos's Request";
			
			else if (info == "1")
				return " The Secrets Behind the Contract of Darkness";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1007300};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "Hehe... I need to gather up strength right now!";
		
		if (GetQuestData(1007300) == "e")
			dialogue = "Hehe... the master plan is well underway.";
		
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
			case 0: Awakening(); break;
		}
	}
}