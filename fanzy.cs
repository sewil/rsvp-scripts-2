using System.Collections.Generic;
using WvsBeta.Game;

// 1040002 Fanzy
public class NpcScript : IScriptV2
{
	private void Fanzy(string quest)
	{
		if (quest == "s")
		{
			int ask1 = AskMenu("Meow~!#b",
				(0, " Aren't you the talking cat?"),
				(1, " Hey kitty kitty! Isn't it nice out here today? Did you find the stuff you lost?"));
			
			if (ask1 == 0)
			{
				self.say("Meow?");
				return;
			}
			
			int ask2 = AskMenu("I can't believe you actually talked to a cat in a straight, sincere tone... you must be quite strange! And how did you know I lost something?#b",
				(0, " Haha, I know anything and everything that goes around\r\nhere."),
				(1, " I heard of Nella's dream at Kerning City."));
			
			if (ask2 == 0)
			{
				self.say("...Right... but I don't feel like asking you for help! I do appreciate you making your way here, but I don't really need your help~!");
				return;
			}
			
			self.say("It's true that I went into her dream and asked her to find an item that I lost, but for you to hear that story and actually find me here... you must be something!");
			self.say("Meow~ didn't you think it's interesting to see a cat talk like this? Well, my name is #b#p1040002##k. Pets usually don't talk unless they become very closely attached to their owners, but my master is a fairy living in this forest.");
			bool start = AskYesNo("The fairy gave me a little bit of magical abilities, which enabled me to talk to others on my own, and also become transparent at will! Since you came a long way to see me, can you help me find the stuff that I lost?");
			
			if (!start)
			{
				self.say("Are you here just to see me out of a curiosity? You must have nothing to do. If you don't have anything to do, then just leave. Meow!");
				return;
			}
			
			SetQuestData(1007700, "1");
			self.say("What I lost is  #b#t4031273##k. My master gave me that as a present, and it's a very important item to me as a result. I really love playing around with that furball~ but then, a few days ago, I dropped it somewhere, and the furball kept rolling around the forest. Now I can't find it...");
			self.say("I have a feeling the #r#o0210100##k, a very curious bunch, took them in amusement, and they're not returning them! Please find the meowy #b#t4031273##k from #r#o0210100##k. Find the furball, and bring it with #byour pet#k, and then I'll reward you with something nice.");
		}
		else if (quest == "1")
		{
			if (ItemCount(4031273) < 1)
			{
				self.say("The item I lost is a #bsmall, red furball #k~");
				return;
			}
			
			if (PetName == "")
			{
				self.say("Are you sure you brought your pet with you? Please let me see them~!");
				return;
			}
			
			self.say("Meow! That was incredible! It's the red furball that I lost, indeed! Thank you so much~! Meow!");
			
			if (!Exchange(0, 4031273, -1))
			{
				self.say("Are you sure you brought the #t4031273#? Meow~?");
				return;
			}
			
			AddEXP(500);
			AddCloseness(15);
			SetQuestData(1007700, "e");
			QuestEndEffect();
			self.say("Don't you feel like you've gotten really close with your pet? I told your pet that you've been very good to me~ then your pet told me it's very happy to have a good master like you, and thinks you're the best!");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1007700)
		{
			if (info == "s" || info == "1")
				return " Fanzy's Red Furball";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1007700};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "Meoooow~~";
		
		if (GetQuestData(1007700) == "e")
			dialogue = "Ennnng~";
		
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
			case 0: Fanzy(GetQuestData(1007700)); break;
		}
	}
}