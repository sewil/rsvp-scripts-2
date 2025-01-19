using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void SecretBook(string quest)
	{
		string questMilk = GetQuestData(1000);
		string questUnagi = GetQuestData(1001);
		
		if (quest == "2" || quest == "3")
		{
			if (questMilk == "")
			{
				self.say("Hmmm... I'm sure you're aware of the fact that we fairies aren't exactly friends with humans ... but if you're bothering us, there must be a valid reason for it ... so how can I help you?");
				self.say("So you're here as a favor from #p1061004# to get back #bFresh \r\nMilk#k? #p1061004# is the one boy that we have opened up to ... hmm, please hold on one second, I'll get you the Fresh Milk.");
				self.say("But then again, I can't give you this just like that. You're also aware that we fairies love fancy, spectacular items, right? If you get me a refined #b#t4021007##k, then #t4031015# is yours.");
				
				SetQuestData(1000, "1");
				
				if (questUnagi != "")
					SetQuestData(1000600, "3");
			}
			else if (questMilk == "1")
			{
				if (ItemCount(4021007) < 1)
				{
					self.say("Haven't gotten the refined #b#t4021007##k yet? Come to me once you have gotten #t4021007#. I'll give you the #t4031015# from \r\n#m101000000#.");
					return;
				}
				
				bool askComplete = AskYesNo("Wow...! This is one very well-refined #t4021007#! If you give it to me, I'll give you something that #p1061004# likes, which is #b#t4031015##k. Will you give the #t4021007# to me?");
				
				if (askComplete)
				{
					if (!Exchange(0, 4021007, -1, 4031015, 1))
					{
						self.say("Are you lacking space in your etc. inventory? Please check and talk to me again.");
						return;
					}
					
					AddEXP(500);
					SetQuestData(1000, "end");
					QuestEndEffect();
					self.say("Thank you very much. Please get #b#t4031015##k to #p1061004#. I'll take good care of #t4021007# that you got me.");
				}
			}
			else if (questMilk == "end")
			{
				if (ItemCount(4031015) >= 1)
				{
					self.say("Did you take the #b#t4031015##k to #p1061004#? I'll take good care of the #t4021007# that you got me.");
					return;
				}
				
				self.say("Thank you very much. Please get #b#t4031015##k to #p1061004#. I'll take good care of #t4021007# that you got me.");
				
				if (!Exchange(0, 4031015, 1))
				{
					self.say("Are you lacking space in your etc. inventory? Please check and talk to me again.");
					return;
				}
			}
		}
	}
	
	private void CursedDoll(string quest)
	{
		if (quest == "")
		{
			self.say("You're #p1061004#'s friend. You came just at the right time. It's not easy for me to ask a human for help, but ... I have a hunch that I can trust you on this.");
			self.say("Allow me to introduce myself. I'm #p1032101#, secretary of the Head Magician in this town, #b#p1032001##k. We've been looking for a traveler who can help out our town and its troubles. Well, would you like to hear the whole story?");
			self.say("#p1032001# used to be very much into #bblack magic#k, which was considered off limits. The black magic is VERY powerful, but it risks the magician of losing the ability to do magic altogether. It's a very potent magic that needs to be carefully used.");
			self.say("#p1032001# wasn't fully trained, but thought nothing of the black magic and started working on a forbidden magic that brings life to a doll made out of straw. I'm sure you're aware of the fact that the one forbidden magic in this world is that of life, anything that has to do with life itself.");
			self.say("But something went terribly wrong in the process and... the curse of black magic wound up seeping into the doll, thus becoming a #r#t4000031##k, having to be encased and sealed up forever. In the end, #p1032001# sealed #t4000031# up and placed it somewhere unknown.");
			self.say("But then the #o3210800# that lived around the #m101000000# forest took the doll, went back into the forest, and became zombies. The \r\n#bZombie #o3210800##k are now ruining the forest as a result. #p1032001# assigned me to handle the situation, but ... for me to do this alone ...");
			bool askStart = AskYesNo("To get the forest back to the way it used to be, we need to kill the zombie #o3210800#s and take away the #b#t4000031##k that they possess. I have so many things to take care of here so I don't have time to do so, but ... will you help me out and do it in place of me?");
			
			if (!askStart)
			{
				self.say("I see ... I thought you could be the one helping us out ... I understand that you're busy, but if you ever have a change of heart, please find me.");
				return;
			}
			
			SetQuestData(1000601, "r0");
			self.say("Thank you so much. #o4230101# can be found at a monkey forest near #m101000000#. First, please collect #b100 #t4000031#s#k. I'll reward you for your work.");
		}
		else if (quest == "r0")
		{
			if (ItemCount(4000031) < 100)
			{
				self.say("Doesn't look like you have all of the #b100 #t4000031#s#k yet. Even at this moment #t4000031# is probably multiplying itself. Please gather up the dolls for me.");
				return;
			}
			
			self.say("Oh my gosh...! It's all #b100 #t4000031#s#k! Thank goodness. With this, the numbers of #o4230101# will probably go down a bit. This doll, however, continually multiplies itself, so it's no time to relax just yet.");
			self.say("Oh yeah, I forgot about rewarding you for your hard work. This is just a token of my appreciation. And we fairies will spread your name all over this world with your good deed. I think you are deserving of hero status.");
			
			if (SlotCount(4) < 1)
			{
				self.say("Please make sure there's an empty slot in your etc. inventory first.");
				return;
			}
			
			Random rnd = new Random();
			int[] reward = {4010000, 4010001, 4010002, 4010003, 4010004, 4010005};
			
			int itemID = reward[rnd.Next(reward.Length)];
			
			if (!Exchange(0, 4000031, -100, itemID, 7))
			{
				self.say("Huh, are you sure you brought everything?");
				return;
			}
			
			AddEXP(300);
			AddFame(1);
			SetQuestData(1000601, "r1");
			self.say("I have boosted up your fame a little. I've also gotten you some ores that we fairies gathered up in the forest. Please put them to good use. So long...");
		}
		else if (quest == "r1")
		{
			bool askStart2 = AskYesNo("Oh hello, traveler. The dolls that you found for us is sealed and hidden away deep in a dark forest. Unfortunately, the numbers of zombied #o3210800# are still increasing ... I'm sorry, but can you please gather up #b200 #t4000031#s#k?");
			
			if (!askStart2)
			{
				self.say("I see ... I thought I could count on you for this, but if you are busy, then it's understandable. Please come back if you ever have a change of heart in the near future.");
				return;
			}
			
			SetQuestData(1000601, "r2");
			self.say("Thank you so much. #o4230101# can be found at a monkey forest near #m101000000#. Please collect #b200 #t4000031##k. I'll definitely reward you well for your work.");
		}
		else if (quest == "r2")
		{
			if (ItemCount(4000031) < 200)
			{
				self.say("Doesn't look like you have collected all #b200 #t4000031#s#k yet. Even at this moment #t4000031# is probably multiplying itself. Please gather up the dolls for me.");
				return;
			}
			
			self.say("Oh my gosh...! It's all of the #b200 #t4000031#s#k! Thank goodness. With this, the numbers of #o4230101# will probably go down a bit. This doll, however, continually reproduces itself, so it's no time to relax just yet.");
			self.say("Oh yeah, I forgot about rewarding you for your hard work. This is just a token of my appreciation. And we fairies will spread your name all over this world with your good deed. I think you are deserving of hero status.");
			
			if (SlotCount(4) < 1)
			{
				self.say("Please make sure there's an empty slot in your etc. inventory first.");
				return;
			}
			
			Random rnd = new Random();
			int[] reward = {4020000, 4020001, 4020002, 4020003, 4020004, 4020005, 4020006};
			
			int itemID = reward[rnd.Next(reward.Length)];
			
			if (!Exchange(0, 4000031, -200, itemID, 10))
			{
				self.say("Huh, are you sure you brought everything?");
				return;
			}
			
			AddEXP(600);
			AddFame(1);
			SetQuestData(1000601, "r3");
			self.say("I have boosted up your fame a little. I've also gotten you some jewelries we fairies gathered up in the forest. Please put them to good use. So long...");
		}
		else if (quest == "r3")
		{
			bool askStart3 = AskYesNo("Oh hello, traveler. The dolls that you have found for us is sealed and hidden away deep in a dark forest. Unfortunately, the numbers of zombied #o3210800# are still increasing ... I'm sorry, but can you please gather up #b400 #t4000031#s#k?");
			
			if (!askStart3)
			{
				self.say("I see ... I thought you could be the one helping us out ... I understand that you're busy, but if you ever have a change of heart, please find me.");
				return;
			}
			
			SetQuestData(1000601, "r4");
			self.say("Thank you so much. #o4230101# can be found at a monkey forest near #m101000000#. Please collect #b400 #t4000031#s#k. I'll definitely reward you well for your work.");
		}
		else if (quest == "r4")
		{
			if (ItemCount(4000031) < 400)
			{
				self.say("Doesn't look like you have collected all #b400 #t4000031#s#k yet. Even at this moment #t4000031# is probably multiplying itself. Please gather up the dolls for me.");
				return;
			}
			
			self.say("Oh my gosh!! It's all of the #b400 #t4000031#s#k! Thank goodness. With this, the numbers of #o4230101# will probably go down a bit. This doll, however, continually multiplies itself, so it's no time to relax just yet.");
			self.say("Oh yeah, I forgot about rewarding you for your hard work. This is just a token of my appreciation. And we fairies will spread your name all over this world with your good deed. I think you are deserving of hero status.");
			
			if (SlotCount(4) < 1)
			{
				self.say("Please make sure there's an empty slot in your etc. inventory first.");
				return;
			}
			
			Random rnd = new Random();
			int[] reward = {4010006, 4020007};
			
			int itemID = reward[rnd.Next(reward.Length)];
			
			if (!Exchange(0, 4000031, -200, 4000031, -200, itemID, 5))
			{
				self.say("Huh, are you sure you brought everything?");
				return;
			}
			
			AddEXP(900);
			AddFame(2);
			SetQuestData(1000601, "r5");
			self.say("I have boosted up your fame a little. I've also gotten you some jewelries we fairies gathered up in the forest. Please put them to good use. So long...");
		}
		else if (quest == "r5")
		{
			bool askStart4 = AskYesNo("Oh hello, traveler. The dolls that you found for us is sealed and hidden away deep in a dark forest. Unfortunately, the numbers of zombied #o3210800# are still increasing. I'm sorry, but can you please gather up #b600 #t4000031#s#k?");
			
			if (!askStart4)
			{
				self.say("I see ... I thought you could be the one helping us out ... I understand that you're busy, but if you ever have a change of heart, please find me.");
				return;
			}
			
			SetQuestData(1000601, "r6");
			self.say("Thank you so much. #o4230101# can be found at a monkey forest near #m101000000#. Please collect #b600 Cursed \r\nDolls#k. I'll definitely reward you well for your work.");
		}
		else if (quest == "r6")
		{
			if (ItemCount(4000031) < 600)
			{
				self.say("Doesn't look like you have collected all #b600 #t4000031#s#k yet. Even at this moment #t4000031# is probably multiplying itself. Please gather up the dolls for me.");
				return;
			}
			
			self.say("Oh my gosh!! It's all of the #b600 #t4000031#s#k! Thank goodness. With this, the numbers of #o4230101# will probably go down a bit. This doll, however, continually multiplies itself, so it's no time to relax just yet.");
			self.say("Oh yeah, I forgot about rewarding you for your hard work. This is just a token of my appreciation. And we fairies will spread your name all over this world with your good deed. I think you are deserving of hero status.");
			
			if (SlotCount(2) < 1)
			{
				self.say("Please make sure there's an empty slot in your use inventory first.");
				return;
			}
			
			Random rnd = new Random();
			int[] reward = {2040801, 2040802};
			
			int itemID = reward[rnd.Next(reward.Length)];
			
			if (!Exchange(0, 4000031, -200, 4000031, -200, 4000031, -200, itemID, 1))
			{
				self.say("Huh, are you sure you brought everything?");
				return;
			}
			
			AddEXP(1200);
			AddFame(2);
			SetQuestData(1000601, "r7");
			self.say("I have boosted up your fame a little. I am also giving you this scroll that I made myself by learning from #p1032001# way back. Plese put them to good use. So long...");
		}
		else if (quest == "r7")
		{
			bool askStart5 = AskYesNo("Hello, traveler. You're back ... I'm really sorry I keep asking you to gather up #t4000031#. This will be the last time, I promise. Can you please gather up 1000 #b#t4000031##k?");
			
			if (!askStart5)
			{
				self.say("I see ... I thought you could be the one helping us out ... I understand that you're busy, but if you ever have a change of heart, please find me.");
				return;
			}
			
			SetQuestData(1000601, "r8");
			self.say("Thank you so much. #o4230101# are being seen at a monkey forest near #m101000000#. Please collect #b1,000 Cursed Dolls#k. I'll definitely reward you well for your work.");
		}
		else if (quest == "r8")
		{
			if (ItemCount(4000031) < 1000)
			{
				self.say("Doesn't look like you have gotten all #b1,000 #t4000031#s#k yet. Even at this moment #t4000031# is probably multiplying itself. Please gather up the dolls for me.");
				return;
			}
			
			self.say("Oh my gosh!! It's all 1,000 of #t4000031#! Thank goodness. With this, the numbers of #o4230101# will probably go down a bit. This doll, however, continually multiplies itself, so it's no time to relax just yet.");
			self.say("Oh yeah, I forgot about rewarding you for your hard work. This is just a token of my appreciation. And we fairies will spread your name all over this world with your good deed. I think you are deserving of hero status.");
			
			int itemID = 0;
			
			if (Job >= 100 && Job < 200) itemID = 1002021;
			else if (Job >= 200 && Job < 300) itemID = 1002154;
			else if (Job >= 300 && Job < 400) itemID = 1002170;
			else if (Job >= 400 && Job < 500) itemID = 1002185;
			
			if (!Exchange(0, 4000031, -200, 4000031, -200, 4000031, -200, 4000031, -200, 4000031, -200, itemID, 1))
			{
				self.say("Please leave an empty slot in your equip. inventory!");
				return;
			}
			
			AddEXP(1800);
			AddFame(3);
			SetQuestData(1000601, "re");
			QuestEndEffect();
			self.say("I have boosted up your fame a little. I am also giving you this hat that we fairies made through magic. Please put them to good use. This is pretty much all we needed. Thank you so much for your help.");
			self.say("Maybe we fairies just had a bad perception towards humans. I'm confident that you'll protect this forest for all of us. Well then, so long...");
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
			
			SetQuestData(8020026, "1");
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
			SetQuestData(8020026, "2");
			SetQuestData(8020025, "1e");
			QuestEndEffect();
			self.say("Thank you so much for giving me a present! Please say hello to Maple Claws for me!");
		}
		else if (quest == "2" || quest == "end")
		{
			self.say("I've already received your present. Thank you so much!");
		}
	}
	
	public override void Run()
	{
		int i = 0;
		var today = DateTime.UtcNow;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1000600, 1000601, 8020026};
		
		foreach (int quest in quests)
		{
			string name = "";
			string info = GetQuestData(quest);
			
			if (quest == 1000600)
			{
				if (info == "2" || info == "3")
					name = " Cold Milk";
			}
			else if (quest == 1000601)
			{
				if ((info == "" && Level >= 35) || info == "r0")
					name = " Collecting 100 Cursed Dolls";
				
				else if (info == "r1" || info == "r2")
					name = " Collecting 200 Cursed Dolls";
				
				else if (info == "r3" || info == "r4")
					name = " Collecting 400 Cursed Dolls";
				
				else if (info == "r5" || info == "r6")
					name = " Collecting 600 Cursed Dolls";
				
				else if (info == "r7" || info == "r8")
					name = " Collecting 1000 Cursed Dolls";
			}
			else if (quest == 8020026)
			{
				var startDate = DateTime.Parse("2022-12-11");
				var endDate = DateTime.Parse("2022-12-26");
				
				if (info != "" && info != "end" && today >= startDate && today < endDate)
					name = " Maple Claws - Visit Rowen the Fairy";
			}
			
			if (name != "")
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "Do you need me for something? Please don't bother me unless you need me right this minute.";
		
		if (GetQuestData(1000600) == "4" || GetQuestData(1000600) == "e")
			dialogue = "Did you take the #b#t4031015##k to #p1061004#? I'll take good care of the #t4021007# that you got me.";
		
		if (GetQuestData(1000601) == "re")
			dialogue = "It's you, my savior. #o4230101# hasn't been attacking our town ever since you helped us out the other day. How are you doing these days?";
		
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
			case 0: SecretBook(GetQuestData(1000600)); break;
			case 1: CursedDoll(GetQuestData(1000601)); break;
			case 2: DeliverPresent(GetQuestData(8020026)); break;
		}
	}
}