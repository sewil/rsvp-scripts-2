using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void HeartChocolate(string quest)
	{
		if (quest == "s")
		{
			if (ItemCount(4031109) < 1 || ItemCount(4031110) < 1 || ItemCount(4031111) < 1 || ItemCount(4031112) < 1 || Mesos < 1000)
			{
				self.say("Hmm? Are you sure you're not lacking any materials or mesos? Please check and see if you have all the items I asked you to get.");
				return;
			}
			
			bool make = AskYesNo("So you HAVE gathered up the necessary ingredients for #t4140100#, right...? I'll need #b1,000 mesos#k to make it and wrap it up neatly in a package. Do you want to make it?");
			
			if (!make)
			{
				self.say("No problem! If you change your mind please make sure to come see me before the end of the event!");
				return;
			}
			
			if (!ExchangeEx(-1000, "4031109", -1, "4031110", -1, "4031111", -1, "4031112", -1, "4140100,Period:4320", 1))
			{
				self.say("Are you SURE you gathered up the necessary ingredients and that there's a free spot in your etc. inventory? If so please check to make sure you don't already have a #bHeart Chocolate#k.");
				return;
			}
			
			AddEXP(800);
			AddFame(1);
			SetQuestData(8020034, "e");
			SetQuestData(8020036, DateTime.UtcNow.AddMinutes(60).ToString());
			QuestEndEffect();
			self.say("Tada! Isn't it pretty? This will protect the owner of the #t4140100# for #b3 days#k. Have a lovely Valentine's Day with your special someone!");
		}
		else
		{
			self.say("Allow me to introduce myself. I am the #bAce of Hearts#k, and I am here to bake lovely goods for everyone needing my service!");
			self.say("Since everything will be handmade, I can only make one per hour for you. Please remember that.");
			bool start = AskYesNo("Now. would you like to make a chocolate for that special someone? Or even for yourself?");
			
			if (!start)
			{
				self.say("Hey, please remember that I only make these for the Valentine's season so gather these items quickly. Good luck!");
				return;
			}
			
			SetQuestData(8020034, "s");
			self.say("If you gather up the ingredients for the chocolate along with the packaging materials, I'll put the chocolate in a beautiful heart-shaped box and cast a special spell of love on it. That spell will protect the owner of the chocolate.");
			self.say("#t4031110# and #t4031109# can be found through monsters. I just need #r1 of each#k. As for #t4031111# and #t4031112#, you can buy those through #bCoco#k. I'll make it for a loooooow price of #r1,000 mesos#k, so please gather them up quickly!");
		}
	}
	
	private void ChocolateBasket(string quest)
	{
		if (quest == "")
		{
			self.say("Valentine's Day is coming, and love is in the air~ So what do you think of the Heart Chocolate that I made for you? With it, you won't lose any EXP even after dying in the middle of the battle. This item is used up when you die and goes bad in 3 days, so make sure to put it to good use! Got that?");
			bool start = AskYesNo("And who's the man that brought you that tasty treat? Me, the #bAce of Hearts#k!! Well, this time, with my magic touch, I can actually extend the expiration date for that chocolate. Would you like to gather up the necessary materials for it?");
			
			if (!start)
			{
				self.say("Oh no ~ I extend the life of #b#t4140100##k once per person, and you said no to it! It's hard to get a deal better than this... oh well, if you decide to change your mind, then please see me before Valentine's.");
				return;
			}
			
			SetQuestData(8020035, "s");
			self.say("Just follow my lead, and you'll be fine. What I do is ... I'll first wrap up the chocolate in two layers, and I'll package it up nicely to make sure it doesn't spill. To do all that, though, requires a number of extra materials.");
			self.say("First I'll need #b1 #t4140100##k. You have it with you, right? Then, in order to wrap it up in two layers, I'll need #b1 #t4031110##k and #b1 #t4031109##k. Of course, with the enhanced power of love on the chocolate, the packaging will also have to be different. You'll need to buy #b1 #t4031113##k and #b1 #t4031114##k through #bCoco#k, who's next to me.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4140100) < 1 || ItemCount(4031109) < 1 || ItemCount(4031110) < 1 || ItemCount(4031113) < 1 || ItemCount(4031114) < 1)
			{
				self.say("Hmm? Are you sure you're not lacking any materials or mesos? Please check and see if you have all the items I asked you to get.");
				return;
			}
			
			bool make = AskYesNo("So you HAVE gathered up the necessary ingredients for #t4140200#, right...? This time, it'll require a lot more of my work, so I'll need #b2,500 mesos#k to make it. Do you still want it?");
			
			if (!make)
			{
				self.say("No problem! If you change your mind please make sure to come see me before the end of the event!");
				return;
			}
			
			if (!ExchangeEx(-2500, "4140100", -1, "4031109", -1, "4031110", -1, "4031113", -1, "4031114", -1, "4140200,Period:7200", 1, "2020028", 3))
			{
				self.say("Are you SURE you gathered up the necessary ingredients and that there's one free spot in your use and etc. inventory? If so please check to make sure you don't already have a #bChocolate Basket#k.");
				return;
			}
			
			AddEXP(1800);
			AddFame(3);
			SetQuestData(8020035, "e");
			QuestEndEffect();
			self.say("Tada! Isn't it pretty? Take a look! This will protect the owner of #t4140200# for #b5 days#k. Oh, and I also made a chocolate out of the leftovers, so please take it. Have a lovely Valentine's Day with your special someone!");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 8020034)
		{
			var saveddate = DateTime.Parse(GetQuestData(8020036, "2020-01-01"));
			
			if ((info == "" && Level >= 8) || info == "s" || (info == "e" && DateTime.UtcNow > saveddate))
				return " Valentine's Day : Heart Chocolate";
		}
		else if (quest == 8020035)
		{
			if ((info == "" && Level >= 8 && ItemCount(4140100) >= 1) || info == "s")
				return " Eliminating Papulatus";
		}
		
		return null;
	}
	
	public override void Run()
	{
		if (DateTime.UtcNow > DateTime.Parse("2022-03-01"))
		{
			self.say("Did you have a wonderful #bValentine's Day#k with your special someone~? The event is over for now... I'll see you next year!");
			return;
		}
		
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {8020034, 8020035};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "I am here to bake lovely goods for everyone needing my service! Doesn't it smell good around here? Mmmm Hmmm!";
		
		if (GetQuestData(8020034) == "e")
			dialogue = "I can only make so much of it by myself. Please bear with me, for I can only make one per hour for you.";
		
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
			case 0: HeartChocolate(GetQuestData(8020034)); break;
			case 1: ChocolateBasket(GetQuestData(8020035)); break;
		}
	}
}