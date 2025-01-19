using System;
using System.Collections.Generic;
using WvsBeta.Game;

// 9201029 Grandma Benson
public class NpcScript : IScriptV2
{
	private void PumpkinPie(string quest)
	{
		if (quest == "s")
		{
			if (ItemCount(4031418) < 1 || ItemCount(4031419) < 1 || ItemCount(4031420) < 1 || ItemCount(4031421) < 1)
			{
				self.say("I don't think you have everything yet. Trying to fool an old woman? I've been your age, but you've never been mine. Remember, I need #bPie Crust, Pumpkin, Flour, and Sugar#k! Get going!");
				return;
			}
			
			self.say("Fantastic! This looks like enough to make the pie. As promised, here is a reward for your kindness. Don't let it get cold, eat up!");
			
			if (!Exchange(0, 4031418, -1, 4031419, -1, 4031420, -1, 4031421, -1, 2022113, 1))
			{
				self.say("Oh! Please make sure there's room in your use inventory first.");
				return;
			}
			
			SetQuestData(8020019, "e");
			QuestEndEffect();
			self.say("Thanks for your help! There's also a contest to see which guild can gather the most Pumpkin Pies. So when you have time, come back and see me again!");
		}
		else
		{
			bool start = AskYesNo("My, you look like a fine young spirit! Care to help me out?");
			
			if (!start)
			{
				self.say("Darn, I was hoping you'd help! Oh well, come back and see me soon!");
				return;
			}
			
			SetQuestData(8020019, "s");
			self.say("Great! I'm trying to make some pie, but those pesky monsters stole my ingredients! I'm sure gathering them will be no problem for a seasoned adventurer like yourself! I'll need #bPie Crust, Pumpkin, Flour, and Sugar#k. Bring them back to me, and I'll give you something that'll fix you right up! ");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 8020019)
		{
			if (Level >= 15)
				return " Thanksgiving : Pumpkin Pie";
		}
		
		return null;
	}
	
	public override void Run()
	{
		if (!eventActive("thanksgiving2022"))
		{
			self.say("I love to cook, but need ingredients! If you help me, you'll get something delicious!");
			return;
		}
		
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {8020019};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "I love to cook, but need ingredients! If you help me, you'll get something delicious!";
		
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
			case 0: PumpkinPie(GetQuestData(8020019)); break;
		}
	}
}