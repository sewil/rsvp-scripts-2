using System;
using System.Collections.Generic;
using WvsBeta.Game;
using WvsBeta.Common;

// 9200000 Cody
public class NpcScript : IScriptV2
{
	private void CodyPotion(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("You seem like you've drank a potion or two before, am I right? Haha! You ever wonder how potions are made?");
			
			if (!start)
			{
				self.say("Aw man, you're no fun.");
				return;
			}
			
			SetQuestData(8020037, "s");
			self.say("Recently I was walking through Henesys Hunting Ground and couldn't help but notice all the potions.");
			self.say("Red ones, blue ones, white ones. I really wonder what this stuff is made out of.");
			self.say("Since then, I've had a compulsion to make my own potion. A CODY POTION. I thought, if these things are just appearing out of thin air, how hard could it be?");
			self.say("Let's start by getting some jars, come back when you've found ten jars. They should drop from any monster. ");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031141) < 10)
			{
				self.say("Oh hey, did you find ten jars for me yet? Sorry, I'm pretty busy over here!");
				return;
			}
			
			self.say("Thanks so much!");
			
			if (!Exchange(0, 4031141, -10))
			{
				self.say("Hey, are you sure you have all ten??");
				return;
			}
			
			SetQuestData(8020037, "1");
			self.say("Hm, I've been thinking a lot about what the ingredients to a CODY potion would be. Lets start with my favorite food, Hot Dog Supreme from Sleepywood's food truck! Can you bring me back 10, one per bottle?");
		}
		else if (quest == "1")
		{
			if (ItemCount(2020006) < 10)
			{
				self.say("Oh, I don't smell ten hot dog supremes on ya!");
				return;
			}
			
			self.say("Sniff sniff... Hey, smells like you got all ten of those dogs for me!");
			
			if (!Exchange(0, 2020006, -10))
			{
				self.say("Hey, are you sure you have all ten??");
				return;
			}
			
			AddEXP(100);
			SetQuestData(8020037, "2");
			self.say("OK! So I put a hotdog in each jar. I think the Cody potion is almost done!");
			self.say("All thats left is some kind of liquid, to help it go down.");
			self.say("Can you get me about thirty lemons? We'll use those to make a juice for the potion!");
		}
		else if (quest == "2")
		{
			if (ItemCount(2010004) < 30)
			{
				self.say("Sniff sniff...sniff... Hmm, I don't smell thirty lemons on you...");
				return;
			}
			
			self.say("Sniiiiffff. Oh man! Those lemons smell sour! Hand 'em over!");
			
			if (!Exchange(0, 2010004, -30, 2010007, 1))
			{
				self.say("Hey, are you sure you have thirty lemons?? If so, please leave a slot open in your USE. inventory first.");
				return;
			}
			
			AddEXP(200);
			SetQuestData(8020037, "3");
			self.say("Great! Let me just... ");
			self.say("All finished! Lemonade and Hotdog, it's perfect! It's kind of like going to a baseball game!");
			self.say("Would you mind taking a sip and letting me know? I have a feeling this potion will give you 1,000 HP.");
		}
		else if (quest == "3")
		{
			if (ItemCount(2010007) >= 1)
			{
				self.say("Hey, did you try my potion yet?");
				return;
			}
			
			self.say("Hm, it poisoned you? I don't think so. That must've been a preexisting condition. Either way, thanks for your help.");
			self.say("Give me a minute to clean up!");
			SetQuestData(8020037, "4");
		}
		else if (quest == "4")
		{
			self.say("As much as the Cody Potion was my very own invention, I must admit I couldn't have done it without uh, you.");
			self.say("I guess I should give you something. You can have this.");
			
			if (!Exchange(0, 1002763, 1))
			{
				self.say("Please leave a slot open in your equip. inventory first.");
				return;
			}
			
			AddEXP(300);
			SetQuestData(8020037, "e");
			QuestEndEffect();
			self.say("Catch you next time!");
		}
	}
	
	private void StartBBQ(string qr, int item)
	{
		SetQuestData(8020049, qr);
		self.say($"Enthusiasm! Always good to see. Well, I’m preparing a barbecue for some friends and we’re running low on ingredients. It starts pretty soon, so I’ll need you to gather\r\n#b30 #t{item}##k (#i{item}#), After that I can finish the barbecue! Thanks a bunch. I’ll be waiting!");
	}
	
	private void EndBBQ(int exp, int item)
	{
		if (ItemCount(item) < 30)
		{
			self.say("Looks like you haven't got all the ingredients yet, champ! Get going!");
			return;
		}
		
		self.say("Fantastic! Everything’s here. I’ll be able to whip some mighty fine barbecue now! I’ve got some serious cooking to do. Now just give me a minute...");
		
		if (!Exchange(0, item, -30, 2022184, 1))
		{
			self.say("Are you sure you brought everything? If so, please leave some room in your use inventory.");
			return;
		}
		
		AddEXP(exp);
		SetQuestData(8020049, "e");
		SetQuestData(8020050, DateTime.UtcNow.AddHours(1).ToString());
		QuestEndEffect();
		self.say("Yes, I'm done cooking! This BBQ turned out to be just right! Here, take one of these BBQs I cooked with the ingredients you gave. It's still hot, so be careful with it!");
	}
	
	private void CodyBBQ(string quest)
	{
		if (DateTime.UtcNow < DateTime.Parse("2022-07-04"))
		{
			self.say("Hey~! I'm going to be holding a barbecue here in a couple days. Why don't you come back then?");
			return;
		}
		
		if (DateTime.UtcNow >= DateTime.Parse("2022-07-24"))
		{
			self.say("Ahh~ my barbecue was a huge success! I hope you had fun. I'll see you around.");
			return;
		}
		
		if (quest == "")
		{
			bool start = AskYesNo("Hey! Nice to see you on this hot summer day. Makes me want to snag something to drink. Think you can help me out with a little barbecue?");
			
			if (!start)
			{
				self.say("Er, Maple BBQ isn't exactly animal meat if you are in any case vegetarian, but I understand. Come back if you change your mind!");
				return;
			}
			
			SetQuestData(8020049, "s");
			self.say("Enthusiasm! Always good to see. Well, I'm preparing a barbecue for some friends and we're running low on ingredients. It starts pretty soon, so I'll need you to gather\r\n#b10 #t4031664#s (#i4031664#), 10 #t4031665#s (#i4031665#) and 10 #t4031666# (#i4031666#)#k, after that I can finish the barbecue! Thanks a bunch. I'll be waiting!");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031664) < 10 || ItemCount(4031665) < 10 || ItemCount(4031666) < 10)
			{
				self.say("Looks like you haven't got all the ingredients yet, champ! Get going!");
				return;
			}
			
			self.say("Fantastic! Everything’s here. I’ll be able to whip some mighty fine barbecue now! I’ve got some serious cooking to do. Now just give me a minute...");
			
			if (!Exchange(0, 4031664, -10, 4031665, -10, 4031666, -10, 1302057, 1, 2022184, 1))
			{
				self.say("Are you sure you brought everything? If so, please leave some room in your equip. and use inventories.");
				return;
			}
			
			AddEXP(800);
			SetQuestData(8020049, "e");
			QuestEndEffect();
			self.say("Yes, I'm done cooking! This BBQ turned out to be just right! Here, take one of these BBQs I cooked with the ingredients you gave. It's still hot, so be careful with it! Oh, and this flag is a gift of my thanks to your help.");
		}
		else if (quest == "e")
		{
			string retry = GetQuestData(8020050, DateTime.UtcNow.ToString());
			
			if (DateTime.UtcNow < DateTime.Parse(retry))
			{
				self.say("Thanks for your help, my barbecue is going great! Be sure to come back later, ok?");
				return;
			}
			
			bool start = AskYesNo("Hey! Nice to see you on this hot summer day. Makes me want to snag something to drink. Think you can help me out with a little barbecue?");
			
			if (!start)
			{
				self.say("Er, Maple BBQ isn't exactly animal meat if you are in any case vegetarian, but I understand. Come back if you change your mind!");
				return;
			}
			
			if (Level < 30)
				StartBBQ("1", 4031659);
			
			else if (Level >= 30 && Level < 70)
				StartBBQ("2", 4031658);
			
			else if (Level >= 70)
				StartBBQ("3", 4031660);
		}
		else
		{
			switch(quest)
			{
				case "1": EndBBQ(800, 4031659); break;
				case "2": EndBBQ(4500, 4031658); break;
				case "3": EndBBQ(10100, 4031660); break;
			}
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 8020037)
		{
			if (info != "e" && Level >= 8)
				return " Cody's Potion";
		}
		else if (quest == 8020049)
		{
			if (Level >= 8)
				return " Summer Break: Cody's BBQ";
		}
		
		return null;
	}
	
	public override void Run()
	{
		if (Level < 8)
		{
			self.say("I sure could use some help here, but you don't seem strong enough to help me. Come back when you're at least #blevel 8#k.");
			return;
		}
		
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {8020037, 8020049};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "What's going on? I'm Cody, the head programmer of MapleStory~";
		
		if (GetQuestData(8020037) == "e")
			dialogue = "Hey buddy! Thanks again for helping with my Cody Potion. I tried getting it in some of the potion shops around here, but they all declined! I can't imagine why.";
		
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
			case 0: CodyPotion(GetQuestData(8020037)); break;
			case 1: CodyBBQ(GetQuestData(8020049)); break;
		}
	}
}