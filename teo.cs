using System;
using System.Collections.Generic;
using WvsBeta.Game;
using WvsBeta.Common;
using System.Linq;

public class NpcScript : IScriptV2
{
	class RedeemableCredit
	{
		public double Rate;
		public RateCredits.Type Type;
		public TimeSpan Duration;
		public string Comment;
		public int QuestID;
		public DateTime EndDate;

		public RedeemableCredit(double rate, RateCredits.Type type, TimeSpan duration, string comment, int questID, DateTime endDate)
		{
			Rate = rate;
			Type = type;
			Duration = duration;
			Comment = comment;
			QuestID = questID;
			EndDate = endDate;
		}
	}
	
	private void Maya(string quest)
	{
		if (quest == "m1")
		{
			self.say("Well, I do have the #b#t4031006##k ... but I can't give it to you for free. If you get me the #b#t4031004##k, though, then I may reconsider ... meaning I am willing to trade with you...");
			self.say("Do you want to know how to get that stone? I wouldn't be asking for help if I knew how ... here's the deal, how about going to the department store at #b#m102000000##k, ask for the daughter of the owner, #r#p1022100##k, and ask her about its whereabouts? She may have a clue ...");
			self.say("Please don't tell me you have no idea how to get to #m102000000#. Ok, take the exit on the right from the harbor, go past \r\n#m103000000# up northwest, and then keep going east, then you'll find #m102000000#. Or do you know all this??");
			
			SetQuestData(1000200, "m2");
		}
		else if (quest == "m2" || quest == "m3" || quest == "m4" || quest == "m5")
		{
			self.say("Didn't get #b#t4031004##k yet? Oh well ... those two aren't the easiest things to acquire ... they look gorgeous when they shine like stars ... hurry and go see #r#p1022100##k from the department store at #b#m102000000##k.");
		}
		else if (quest == "m6")
		{
			if (ItemCount(4031004) < 1)
			{
				self.say("Didn't get #b#t4031004##k yet? Oh well ... those two aren't the easiest things to acquire ... they look gorgeous when they shine like stars ... hurry and go see #r#p1022100##k from the department store at #b#m102000000##k.");
				return;
			}
			
			self.say("Thank you!!! Please take this medicine instead. #r#p1012101##k from #b#m100000000##k is sick again. This wil take care of the sickness a little bit...");
			
			if (!Exchange(0, 4031004, -1, 4031006, 1))
			{
				self.say("Please make some room in your etc. inventory for the medicine.");
				return;
			}
			
			SetQuestData(1000200, "m7");
		}
		else if (quest == "m7")
		{
			if (ItemCount(4031006) >= 1)
			{
				self.say("Hurry and give #p1012101# the #b#t4031006##k that I gave you. \r\n#m100000000# is very far from here so make sure you don't lose that medicine ...!");
				return;
			}
			
			self.say("Thank you!!! Please take this medicine instead. #r#p1012101##k from #b#m100000000##k is sick again. This wil take care of the sickness a little bit...");
				
			if (!Exchange(0, 4031006, 1))
			{
				self.say("Please make some room in your etc. inventory for the medicine.");
				return;
			}
		}
	}
	
	private void TeoReminiscence(string quest)
	{
		if (quest == "")
		{
			self.say("Hello there ... are you about to embark on a journey? You look a bit too weak to take on such a task. When I was young, I was eager to prove my existence to the world by roaming around the world, experiencing everything ... I miss those days. There's nothing quite like traveling around in different exotic places, soaking in everything I could soak in...");
			self.say("I was green and unaware of what exactly was in store for me, so I had my share of hard times. Seeing you right now brings back those memories...");
			bool start = AskYesNo("You know, I am saying this because I think you have great potential, but if you prove me right by completing the task I'm about to give you, then I'll help you get started with your journey. Do you want to do it?");
			
			if (!start)
			{
				self.say("Really? I was just trying to help... if you ever change your mind, come talk to me.");
				return;
			}
			
			SetQuestData(8020051, "s");
			self.say("Alright. Please gather up #b50 #t4000016#s#k and #b30 #t4000004#s#k for me, then I'll see what I can do to help you out.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4000016) < 50 || ItemCount(4000004) < 30)
			{
				self.say("You haven't gotten all the items I asked you to get. Maybe I have overestimated your abilities. Please gather up #b50 #t4000016#s#k and #b30 #t4000004#s#k as fast as you can. I know you are more than capable of doing so.");
				return;
			}
			
			self.say("That was fast! I knew you'd be good, but this is better than I expected. I can safely say that you'll become quite a traveler around here. I truly believe that.");
			self.say("Okay, let me reward you for proving yourself...");
			
			var rnd = new Random();
			int item = -1;
			
			if (rnd.Next(0, 2) == 0)
				item = 1002424;
			
			else
				item = 1002425;
			
			if (!Exchange(10000, 4000016, -50, 4000004, -30, item, 1))
			{
				self.say("Hm... did you really bring everything? If so, make sure there's an empty slot in your equip. inventory.");
				return;
			}
			
			chr.RateCredits.AddTimedCredits(RateCredits.Type.EXP, TimeSpan.FromHours(2), 1.5, "Teo's 1.5x EXP Credit");
			chr.RateCredits.AddTimedCredits(RateCredits.Type.Mesos, TimeSpan.FromHours(2), 1.5, "Teo's 1.5x Mesos Credit");
			chr.RateCredits.AddTimedCredits(RateCredits.Type.Drop, TimeSpan.FromHours(2), 1.5, "Teo's 1.5x Drop Credit");
			
			var newCredits = chr.RateCredits.GetCredits().Where(x => x.Comment.Contains("Teo")).ToArray();
			
			foreach (var cr in newCredits)
			{
				cr.Enabled = true;
			}
			
			SetQuestData(999192, "1");
			SetQuestData(999193, "1");
			SetQuestData(999194, "1");
			SetQuestData(8020051, "e");
			QuestEndEffect();
			self.say("Did you get the money? I know it's not much, but this may be very useful to someone like you who has just begun their journey.");
			self.say("I've also given you some #bcredits#k. What are credits? With those, you'll be able to earn extra experience and loot! Credits will only be used up while in the field with monsters and you'll be able to see the effects of the credit in the top-right of the screen when you first leave town. If you'd like to save your credits for later, you can disable them by talking to the #bMaple Administrator#k.");
			self.say("It would be nice to run into you someday and see you mature into a complete package. See you later!");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1000200)
		{
			if (info == "m1")
				return " Maya of Henesys";
			
			else if (info == "m2" || info == "m3" || info == "m4" || info == "m5" || info == "m6")
				return " Finding Sophia";
			
			else if (info == "m7")
				return " Delivering the Weird Medicine";
		}
		else if (quest == 8020051)
		{
			if (Level >= 10 && chr.ID > 40670 && DateTime.UtcNow < DateTime.Parse("2022-08-01") && info != "e")
				return " Teo's Reminiscence";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1000200, 8020051};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "I heard that #p1012101# is sick again. Sad...";
		
		if (GetQuestData(1000200) == "end")
			dialogue = "Oh~ So it seems that you have delievered #b#t4031006##k to #p1012101#...! Thanks. Now #p1012101# can get better now. huh? \r\n#t4031004# It is still very beautiful~";
		
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
			case 0: Maya(GetQuestData(1000200)); break;
			case 1: TeoReminiscence(GetQuestData(8020051)); break;
		}
	}
}