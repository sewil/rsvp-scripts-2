using System;
using System.Collections.Generic;
using WvsBeta.Game;

// 2050013 Porter
public class NpcScript : IScriptV2
{
	private void Control(string quest)
	{
		if (quest == "s")
		{
			self.say("Hmmm... #b#p2051001##k the engineer at Silo requested for the deciphering of #b#t4000124##k, right? (Sniff sniff~) Yes, it's possible, but I've been suffering from crazy cold lately. (Sniff sniff~) I'll have to try this, first (Sniff sniff~) Hmmm... then please send me the #b3 #t4000124#s#k. Let's see ...");
			
			if (!Exchange(0, 4000124, -3, 4031118, 2))
			{
				self.say("Hmmm... are you sure that you have #b3 #t4000124#s#k with you? (Sniff sniff~) If so, please make some room in your etc. inventory...");
				return;
			}
			
			AddEXP(500);
			SetQuestData(1003501, "1");
			self.say("Oh no... I was able to decipher 2 out of 3 #t4000124#s that you gave me, but the other one... I sneezed in the middle of it, and the deciphering failed as a result. (Sniff sniff~) What should I do...? Well, there's not much I can do. Please head back to the Eos Tower, defeat #b#o4130103##k, and gain #b#t4000124##k for me. One's all I need.");
		}
		else if (quest == "1")
		{
			if (ItemCount(4000124) < 1)
			{
				self.say("(Sniff sniff~) I'm really really sorry about last time. You're still short on 1 #b#t4031118##k. Please go back to the Eos Tower, defeat #b#o4130103##k once more, and then obtain #b#t4000124##k so I can decipher it for you guys, with no error whatsoever. (Sniff sniff~) Any good cold medicine?");
				return;
			}
			
			self.say("(Sniff sniff~) Hoh... so you brought 1 #b#t4000124##k. It must not have been easy for you, but you did it anyway. Alright, then, I'll try to hold in the cough and sneeze as much as I can, so please wait one second. (Sniff sniff~) Let's see... this is a much more complicated program than the one you got last time.");
			
			if (!Exchange(0, 4000124, -1, 4031118, 1))
			{
				self.say("Please make some room in your etc. inventory...");
				return;
			}
			
			AddEXP(500);
			SetQuestData(1003501, "2");
			self.say("(Sniff sniff~) Alright, the deciphering is now complete! What do you think? I deciphered two memory cards for you last time, and one for you just now, so... (Sniff sniff~) you now have the 3 that #b#p2051001##k asked for, right? Now please take them right to Kay. I have to run now.");
		}
		else if (quest == "2")
		{
			self.say("With the #b3 #t4031118#s#k that I've deciphered for you, you can give these to #b#p2051001##k at the Silo. (Sniff sniff~) I saw her just now, and she seemed to be really in a hurry to see this. You better go see her now! I wonder what she's making these days...");
			
			int count = ItemCount(4031118);
			
			if (count < 3)
			{
				int needCount = 3 - count;
				
				if (!Exchange(0, 4031118, needCount))
				{
					self.say("Please make some room in your etc. inventory...");
					return;
				}
			}
		}
	}
	
	private void Dropship(string quest)
	{
		if (quest == "")
		{
			self.say("(Sniff sniff~) Whoa, aren't you #p2051001#'s assistant? Right?\r\nHmmm... the Omega Sector is currently really busy with the creation of the new robot, along with the ever-increasing threats of violence from the aliens. (Sniff sniff~) The aliens are cunning and smooth-talking, so you'll need to be on your toes yourself.");
			bool start = AskYesNo("Hey, but what do you think of the life as #p2051001#'s assistant? Does #p2051001# treat you with respect? (Sniff sniff~) Well, it's not much... but... oh, oh yeah!! Can you send this letter to #p2051001# for me? (Sniff sniff~) I'd love to go there by myself, but... I'm currently on my last straw here.");
			
			if (!start)
			{
				self.say("Hmmm... you must be very busy right now (Sniff sniff~). Well, there's nothing I can do about it. But if you ever find yourself a free time, please come talk to me. I have a letter by #p2051001# that I really want to give.");
				return;
			}
			
			if (!ExchangeEx(0, "4031126,Period:1440", 1))
			{
				self.say("Please leave an empty space in your etc. inventory for the letter.");
				return;
			}
			
			SetQuestData(1003502, "s");
			self.say("Please send that letter I just gave you to #b#p2051001##k at the Silo. (Sniff sniff~) Oh, and please remember, if you don't deliver the letter in one day, the letter will just disappear, thanks to a special device on the letter. It's pretty classified information, so there's only one way to find out.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031126) >= 1)
			{
				self.say("Please send my letter to #b#p2051001##k of Omega Sector Silo (Sniff sniff~) Oh, and please remember that the letter will be destroyed if you don't deliver it within a day. Security measures, you know. (Sniff sniff~)  Oh, and please make sure not to open the letter and see what's inside, alright? I'll see you later!");
				return;
			}
			
			self.say("Hmmm... did you lose the letter I gave you, by any chance? (Sniff sniff~) Or did you forget to deliver it, causing it to destroy itself? (Sniff sniff~) Please be careful with it, okay? I'll give you a new letter, and this time, please deliver it to #b#p2051001##k on time! (Sniff sniff~) It'll destroy itself if not delivered on time. Now here's my letter.");
			
			if (!ExchangeEx(0, "4031126,Period:1440", 1))
			{
				self.say("Please leave an empty space in your etc. inventory for the letter.");
			}
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
			
			SetQuestData(8020029, "1");
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
				self.say("... Now I'm not in a very good mood. Please excuse me, I need some more alone time. Maybe if you come to me later, I'll be happy to talk with you.");
				return;
			}
			
			if (!Exchange(0, 4031486, -1))
			{
				self.say("Sorry, but I'm having trouble taking the present, please check your inventory and try again.");
				return;
			}
			
			chr.AddCash(500);
			Message("You have gained 500 Cash.");
			SetQuestData(8020029, "2");
			SetQuestData(8020025, "4e");
			QuestEndEffect();
			self.say("Thank you so much for your present! Please say hello to Maple Claws for me!");
		}
		else if (quest == "2" || quest == "end")
		{
			self.say("I've already received your present. Thank you so much!");
		}
	}
	
	private string Check(int quest)
	{
		var today = DateTime.UtcNow;
		string info = GetQuestData(quest);
		
		if (quest == 1003501)
		{
			if (info == "s")
				return " Porter the Undependable";
			
			else if (info == "1")
				return " Porter's Mistake";
			
			else if (info == "2")
				return " The Brilliant Assistant";
		}
		else if (quest == 1003502)
		{
			string control = GetQuestData(1003501);
			string robinson = GetQuestData(1007400);
			
			if ((info == "" && control == "e" && robinson == "") || info == "s")
				return " Porter's Secret Letter";
		}
		else if (quest == 8020029)
		{
			var startDate = DateTime.Parse("2022-12-11");
			var endDate = DateTime.Parse("2022-12-26");
			
			if (info != "" && info != "end" && today >= startDate && today < endDate)
				return " Maple Claws - Visit Porter";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1003501, 1003502, 8020029};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "Hello, there. My name is #b#p2050013##k, and I work here at the headquarters helping #b#p2050001##k out develop a new robot. (sniff) The new robot is coming out nicely, but I have been suffering from cold for a while. (sniff) Now, if you'll excuse me, I'll have to get back to work. I can't be caught slacking off, you know...";
		
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
			case 0: Control(GetQuestData(1003501)); break;
			case 1: Dropship(GetQuestData(1003502)); break;
			case 2: DeliverPresent(GetQuestData(8020029)); break;
		}
	}
}