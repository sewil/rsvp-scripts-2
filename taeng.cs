using System;
using System.Collections.Generic;
using WvsBeta.Game;

// 2060101 - Taeng the Explorer
public class NpcScript : IScriptV2
{
	private void BlockedPath()
	{
		string quest = GetQuestData(1007600);
		
		if (quest == "")
		{
			self.say("Who's that? Is that you guys ...............? Oh, it's not... then who are you? How did you get so deep in here? I'm Taeng, the lead explorer of this expedition. This is usually not the place to run into people, and ... it's been a while since I talked to anyone, actually.");
			bool start = AskYesNo("Are you here by yourself? If you could get here alone ... then you may be able to help me out here. I really can use a hand here. Will you listen to my story?");
			
			if (!start)
			{
				self.say("I really wished someone as powerful and brave as you would help me out...");
				return;
			}
			
			SetQuestData(1007600, "s");
			self.say("A few months ago, my crew and I were sent here from Aquarium to observe the state of the ocean. Lately there had been some strange things happening here, so the crew of four, including myself, were sent here to check out the problem.");
			self.say("But a few days earlier, the rest of the crew that went out the check out the debris of the wrecked ships went missing. I've been looking around places since then to find them, to no avail.");
			self.say("It would be nice to at least find traces of the men, but something terrible must have happened if I can't find a single thing here since then. Not only that, but ever since they went missing, the path that leads to the bottom of the ocean has been blocked by a black fog. Something doesn't feel right. Please help me find at least the traces left behind by my men.");
			self.say("I think the swarms of sharks that are swimming around this area look suspicious to say the least. I've been looking through the rocks to no avail, so I should start looking through the sharks, but it's really dangerous to do so, and I don't think I can do it by myself.");
			self.say("I see that you're full of courage and strength, since you made it here by yourself. Please help me look into these sharks and find the item that my men carried around, like a \r\n#bflashlight#k, a #bcamera#k and a #bnotebook#k, and give them to me.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031252) < 1 || ItemCount(4031254) < 1 || ItemCount(4031255) < 1)
			{
				self.say("Haven't found them yet? I haven't, either. Please keep trying. If you find a #bcamera#k, a #bflashlight#k, or a #bnotebook#k, then please give them to me.");
				return;
			}
			
			self.say("Did you find something? I haven't found anything. Hey, the items you're carrying... they look like they're from our crew... can I see them?");
			
			var rnd = new Random();
			int rnum = rnd.Next(0, 100);
			
			int itemID = -1;
			
			if (rnum < 15) itemID = 2041005;
			else if (rnum < 30) itemID = 2041002;
			else if (rnum < 65) itemID = 2041004;
			else if (rnum < 100) itemID = 2041001;
			
			if (!Exchange(0, 4031254, -1, 4031255, -1, 4031252, -1, itemID, 1))
			{
				self.say("Please make sure you have one empty slot in your use inventory first.");
				return;
			}
			
			AddEXP(70000);
			SetQuestData(1007600, "e");
			QuestEndEffect();
			self.say("Right, I'm 100% sure these are the items from our men. I don't know what happened to them... and why is the path to the bottom of the ocean blocked? I'll need to keep inquiring about the whereabouts of the rest of the men. I can't thank you enough for your help. It really helped me out a great deal. Now, I will have to stay here and get on with the exploration.");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1007600)
		{
			if ((info == "" && Level >= 90) || info == "s")
				return " The Blocked Path of the Ocean";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1007600};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "I need to investigate whatever that's going deep in the ocean.";
		
		if (GetQuestData(1007600) == "e")
			dialogue = "Please be careful, for you'll run into a lot of sharks outside. You need to be on your toes at all times.";
		
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
			case 0: BlockedPath(); break;
		}
	}
}