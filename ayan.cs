using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Stumps(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("Excuse me~ I know it's rude to ask a stranger, but can you please help me out? I am terrified of the Stumps that are wandering around outside this town. I can't even think of leaving here. I don't even want to see them, because they scare me to death. Please, if you have some time on your hands, can you help me out?");
			
			if (!start)
			{
				self.say("You must be busy. If you find some spare time later on, please come by and talk to me.");
				return;
			}
			
			SetQuestData(1005700, "050");
			self.say("Thank you so much~ I knew you would say yes. As you can see, I am not from the tribes here. According to the elders here, years ago they found me lost in the streets, all bruised up and messy.");
			self.say("The elders saved me, and I have been living here ever since. Unfortunately, I don't remember anything from the past. Something may have happened back then.");
			self.say("Maybe that's because I went through something so horrible that my head chose to block it all out. I guess that's the reason why I am so scared of the Stumps. Can you do me a favor and take out #b50 Stumps#k please?");
		}
		else
		{
			if (quest != "000")
			{
				self.say("I don't think you have gotten all the Stumps yet. Please help me, for I am terrified of the Stumps.");
				return;
			}
			
			self.say("Wow, thank you so much! I see a lot less number of Stumps near Perion now! I feel like I can finally take a step outside. Thank you so much for your hard work!");
			
			AddEXP(300);
			SetQuestData(1005700, "e");
			QuestEndEffect();
		}
	}
	
	private void Bruce(string quest)
	{
		if (quest == "b")
		{
			self.say("Hi! What? My dad is looking for me? Are you sure about that? Because I have no idea who my dad is. I don't remember anything from my childhood.");
			
			if (ItemCount(4031174) >= 1)
			{
				self.say("Hey, this sword...I remember this! That's right!! I was attacked by a humongous mushroom, and I just ran away as fast as I could. I guess that's how I ended up in here.");
				self.say("I can't believe this! I remember everything now!! Where's my dad now? Well, here's a letter for my dad. Please get this to him ASAP.");
				
				if (!Exchange(0, 4031174, -1, 4031173, 1))
				{
					self.say("Are you sure you have room in your etc. inventory for my letter?");
					return;
				}
				
				SetQuestData(1005601, "a");
				self.say("Please give this letter to my dad! I really mean it! I can't wait to meet my dad again!");
			}
		}
		else if (quest == "a")
		{
			if (ItemCount(4031173) >= 1)
			{
				self.say("Please give this letter to my dad! I really mean it! I can't wait to meet my dad again!");
				return;
			}
			
			self.say("Please take care of it! I'll write it again here. Don't lose it this time!");
			
			if (!Exchange(0, 4031173, 1))
			{
				self.say("Are you sure you have room in your etc. inventory for my letter?");
				return;
			}
		}
	}
	
	private void Alligators1(string quest)
	{
		if (quest == "")
		{
			self.say("It's been a while since I last saw you. How have you been? Not everything is going well here in Perion. A few days ago, a group of tribesmen went hunting to the swamps near Kerning City to acquire some alligator skins, only to be ambushed by them. They came back alive, but all were seriously injured.");
			bool start = AskYesNo("People haven't been going to the swamps for quite some time, and during that time, the number of the alligators have dramatically increased to the point where they are starting to attack people. Even Sitting Bull have taken notice, and he has been just as concerned about it as us.");
			
			if (!start)
			{
				self.say("You looked powerful enough to handle the task, at least in my eyes. Please reconsider your choice, because...if the alligators keep spawning like they do right now at the swamps, it'll be really dangerous for everyone here down the road...");
				return;
			}
			
			SetQuestData(1005701, "040250");
			self.say("Thank you. Because of the recent string of events, Sitting Bull decided to hire someone outside to take care of the alligators. Since he is a very busy man, however, I have assumed the task of picking out that someone to help us, and I chose you. So please head over to the swamps and take out #b250 #o3110100#s#k and #b40 #o2130103#s#k and bring back #b20 \r\n#t4000034#s#k as evidence.");
			self.say("The swamps can be reached through the sewage pipe in Kerning City. I have the utmost faith in you. Good luck.");
		}
		else
		{
			if (quest != "000000" || ItemCount(4000034) < 20)
			{
				self.say("Please take out #b250 #o3110100#s#k and #b40 #o2130103#s#k and bring back #b20 #t4000034#s#k with you.");
				return;
			}
			
			self.say("You're back early! That's incredible! I knew I had asked the right person for the job. Thanks to you the number of the alligators at the swamps should be considerably less now. Thank goodness...");
			
			var options = new List<(int, string)>();
			int[] rewards = new int[] {2043302, 2044702, 2043002, 2044002, 2043102, 2044102, 2043202, 2044202, 2044302, 2044402, 2043702, 2043802, 2044502, 2044602};

			if (Job >= 100 && Job < 200)
			{
				options.Add((3, " #t2044002#"));
				options.Add((4, " #t2043102#"));
				options.Add((5, " #t2044102#"));
				options.Add((6, " #t2043202#"));
				options.Add((7, " #t2044202#"));
				options.Add((8, " #t2044302#"));
				options.Add((9, " #t2044402#"));
			}
			else if (Job >= 200 && Job < 300)
			{
				options.Add((10, " #t2043702#"));
				options.Add((11, " #t2043802#"));
			}
			else if (Job >= 300 && Job < 400)
			{
				options.Add((12, " #t2044502#"));
				options.Add((13, " #t2044602#"));
			}
			else if (Job >= 400 && Job < 500)
			{
				options.Add((0, " #t2043302#"));
				options.Add((1, " #t2044702#"));
			}
			else
			{
				options.Add((0, " #t2043302#"));
				options.Add((1, " #t2044702#"));
				options.Add((2, " #t2043002#"));
				options.Add((3, " #t2044002#"));
				options.Add((4, " #t2043102#"));
				options.Add((5, " #t2044102#"));
				options.Add((6, " #t2043202#"));
				options.Add((7, " #t2044202#"));
				options.Add((8, " #t2044302#"));
				options.Add((9, " #t2044402#"));
				options.Add((10, " #t2043702#"));
				options.Add((11, " #t2043802#"));
				options.Add((12, " #t2044502#"));
				options.Add((13, " #t2044602#"));
			}
			
			int askReward = askReward = AskMenu("Did you bring #b#t4000034##k with you? I also have something for you as a sign of my appreciation for our hard work. Which of these do you need?#b", options.ToArray());
			
			int itemID = rewards[askReward];
			
			if (!Exchange(0, 4000034, -20, itemID, 1))
			{
				self.say("Please make sure there's an empty space in your use inventory first!");
				return;
			}
			
			AddEXP(20000);
			SetQuestData(1005701, "e");
			QuestEndEffect();
			self.say("#b#t4000034##k can also be used as a medicine. I wanted you to bring it so I could use it on people that have been attacked by the alligators. This scroll is our way of saying thanks, so please take it and put it to good use.");
		}
	}
	
	private void Alligators2(string quest)
	{
		if (quest == "")
		{
			self.say("Good to see you again. Actually, I have been waiting for you. I have never had a chance to formally thank you for taking out the Ligators at the swamp before. Thanks to your heroics, the people at the tribe had been feeling safe passing by the area.");
			bool start = AskYesNo("Lately, however, we have found out that a bunch of #b#o5130103#s#k have been residing at the deeper part of the swamps. \r\n#b#o5130103##k is much more powerful and intimidating than the Ligators, and it can create a havoc unlike any of the alligators in this world. So here I am, asking you for help one more time. Please help us take out the alligators. Can you do that for us?");
			
			if (!start)
			{
				self.say("Ah ... please think about it. We need your help, but ... I am sure you are busy with something else. But please think about it, and if you have a change of heart, then talk to me.");
				return;
			}
			
			SetQuestData(1005702, "120");
			self.say("Thank you so much. I honestly couldn't think of anyone else to ask for such a task like this. Please head to the swamps and take out #b120 #o5130103#s#k and bring back #b50 #t4000033#s#k with you. Don't worry; you'll be rewarded well for this.");
		}
		else
		{
			if (quest != "000" || ItemCount(4000033) < 50)
			{
				self.say("Please head over to the swamp and take out #b120 #o5130103#s#k while bringing back #b50 #t4000033#s#k with you.");
				return;
			}
			
			self.say("You are incredible, indeed. You single-handedly took out all those #b#o5130103#s#k! Thanks to your incredible effort, we can all feel safe now walking across the swamps.");
			
			int[] rewards = new int[] {2041013, 2041016, 2041019, 2041022};
			
			int askReward = AskMenu("Here's your reward. Please choose the one of your liking.#b",
				(0, " #t2041013#"),
				(1, " #t2041016#"),
				(2, " #t2041019#"),
				(3, " #t2041022#"));
			
			int itemID = rewards[askReward];
			
			if (!Exchange(0, 4000033, -50, itemID, 1))
			{
				self.say("Please make sure there's an empty space in your use inventory first!");
				return;
			}
			
			AddEXP(25000);
			SetQuestData(1005702, "e");
			QuestEndEffect();
			self.say("Thank you so much. Your heroics will be recorded and be passed down from generation to generation amongst our tribe, and we'll take good care of #b#t4000033##k. It's a high-quality leather, one that can be used on multiple purposes. Hope you have a safe journey. Best of luck to you.");
		}
	}
	
	// Christmas event 2021
	private void DeliverPresent(string quest)
	{
		var rnd = new Random();
		
		if (quest == "s")
		{
			bool start = AskYesNo("Do you want something from me? Does this have something to do with Maple Claws?");
			
			if (!start)
			{
				self.say("If you don't have anything to tell me then please go away!");
				return;
			}
			
			SetQuestData(8020027, "1");
			self.say("Ah... Ok... Hi! Nice to meet you! You must have come from Maple Claws, which means that... You're here with my present!");
		}
		else if (quest == "1")
		{
			if (ItemCount(4031486) < 1)
			{
				self.say("You are a strange person, coming here with no present!");
				return;
			}
			
			if (rnd.Next(0, 2) == 0)
			{
				self.say("... Now I'm not in a very good mood. Please excuse me, I need some more alone time. Maybe if you come back and talk to me later, I'll be happy to see you.");
				return;
			}
			
			if (!Exchange(0, 4031486, -1))
			{
				self.say("Sorry, but I'm having trouble taking the present, please check your inventory and try again.");
				return;
			}
			
			chr.AddCash(500);
			Message("You have gained 500 Cash.");
			SetQuestData(8020027, "2");
			SetQuestData(8020025, "2e");
			QuestEndEffect();
			self.say("Thank you so much for your present! Please say hello to Maple Claws for me!");
		}
		else if (quest == "2")
		{
			self.say("I've already received your present. Thank you so much!");
		}
	}
	
	private string Check(int quest)
	{
		var today = DateTime.UtcNow;
		string info = GetQuestData(quest);
		
		if (quest == 1005700)
		{
			if (info != "e" && Level >= 10)
				return " The Stump Horror Story";
		}
		else if (quest == 1005601)
		{
			if (info == "b" || info == "a")
				return " I Need to Find My Daughter";
		}
		else if (quest == 1005701)
		{
			string bruce = GetQuestData(1005601);
			
			if (info != "e" && bruce == "e" && Level >= 52)
				return " Taking Out the Alligators 1";
		}
		else if (quest == 1005702)
		{
			string alligators1 = GetQuestData(1005701);
			
			if (info != "e" && alligators1 == "e")
				return " Taking Out the Alligators 2";
		}
		else if (quest == 8020027)
		{
			var startDate = DateTime.Parse("2022-12-11");
			var endDate = DateTime.Parse("2022-12-26");
			
			if (info != "" && info != "end" && today >= startDate && today < endDate)
				return " Maple Claws - Visit Ayan";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1005700, 1005601, 1005701, 1005702, 8020027};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "Hi~";
		
		if (GetQuestData(1005700) == "e")
			dialogue = "You are the one who helped me the other day. Thank you~";
		
		if (GetQuestData(1005702) == "e")
			dialogue = "Thank you so much. Your heroics will be recorded and be passed down from generation to generation amongst our tribe, and we'll take good care of #b#t4000033##k. It's a high-quality leather, one that can be used on multiple purposes. Hope you have a safe journey. Best of luck to you.";
		
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
			case 0: Stumps(GetQuestData(1005700)); break;
			case 1: Bruce(GetQuestData(1005601)); break;
			case 2: Alligators1(GetQuestData(1005701)); break;
			case 3: Alligators2(GetQuestData(1005702)); break;
			case 4: DeliverPresent(GetQuestData(8020027)); break;
		}
	}
}