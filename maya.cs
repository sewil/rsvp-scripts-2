using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(1000200);
		string quest2 = GetQuestData(1000202);
		
		if (Level < 15 || Job == 0)
		{
			self.say("Cough... Cough... Ah... Headache... Can somebody help me?...");
			return;
		}
		
		if (quest1 == "")
		{
			self.say("Cough ... cough ... ah ... oh, hello stranger. Sorry, but may I ask you for a favor? I've been suffering from sickness for a while, and the doctors can't do anything about it. Lately, it has gotten so bad I can't even take care of myself.");
			self.say("Sorry to ask, but is there any way you can get me the #b#t4031006##k? I am not sure exactly how to get that medicine, but #r#p1002001##k from #b#m104000000##k may know a thing or two about it. Please help me out.");
			
			SetQuestData(1000200, "m1");
		}
		else if (quest1.Contains("m"))
		{
			if (ItemCount(4031006) < 1)
			{
				self.say("Haven't met #r#p1002001##k, yet? #p1002001# from #b#m104000000##k can definitely help you find #p1002001#. Please find him.");
				return;
			}
			
			self.say("Darn ... my whole body's aching ... what, oh my ... isn't that #b#t4031006##k?? How did you get it?? wow, you must be amazing.");
			bool questEnd = AskYesNo("Um ... is it okay if I get that medicine? I'll give you something that I don't really need ... I urge you ... please ... I need that medicine ...");
			
			if (questEnd)
			{
				if (!Exchange(5000, 4031006, -1, 1002026, 1))
				{
					self.say("Your equip. inventory is full ... please make some room first.");
					return;
				}
				
				AddEXP(200);
				SetQuestData(1000200, "end");
				QuestEndEffect();
				self.say("Thank you so much ... this may cure my longtime sickness afterall ... here's something I don't really need ... hopefully it'll help you through your journey ... here are some mesos also as a sign of my appreciation ...");
			}
		}
		else if (quest1 == "end")
		{
			if (quest2 == "" && Level >= 55 && Job >= 300 && Job < 400)
			{
				self.say("Hey~ You are the one who gave a medicine to me! Long time no talk. I got better, because of that medicine. Thanks, again. You look much stronger. You might be stronger than \r\n#p1012100#~ I am just joking.");
				bool askStart1 = AskYesNo("Anyway, would you do me favor? I am collecting some stuff from here and there. I think I can make something new out of them... So can you help me to collect them? It won't be that hard!");
				
				if (!askStart1)
				{
					self.say("Oh you must be really busy now... But please get back to me if you have time later. I would like to get the stuff by myself, but I am not fully recovered...");
					return;
				}
				
				SetQuestData(1000202, "1");
				self.say("Thanks! Can you get #b#t4000019#, #t4000000#, #t4000011#, #t4000003#, 50 of each? They come from very weak monsters. It might not be fun for you... lol... Anyway this is just a start~");
			}
			else if (quest2 == "1")
			{
				if (ItemCount(4000000) < 50 || ItemCount(4000003) < 50 || ItemCount(4000011) < 50 || ItemCount(4000019) < 50)
				{
					self.say("You haven't collected #b#t4000019#, #t4000000#, \r\n#t4000011#, #t4000003#, 50 of each#k... Come on~ I will give you something good if you do these things for me~");
					return;
				}
				
				self.say("Wow~!! You got them all! This one was too easy for you, right? Anyway, thanks, but they are not enough, though.");
				
				if (!Exchange(0, 4000019, -50, 4000000, -50, 4000011, -50, 4000003, -50))
				{
					self.say("Huh, are you sure you brought all the items?");
					return;
				}
				
				AddEXP(600);
				SetQuestData(1000202, "1e");
				self.say("I got the stuff. Thanks you so much~ But I need much more stuff, though... So please get back to me when you are ready.");
			}
			else if (quest2 == "1e")
			{
				bool askStart2 = AskYesNo("Oh... Are you ready? Don't go too fast, though~ Okay, would you please get #b#t4000024#, #t4000037#, #t4000002#, #t4000035#, 50 of each#k?");
				
				if (!askStart2)
				{
					self.say("Oh you must be really busy now... But please get back to me if you have time later. I would like to get the stuff by myself, but I am not fully recovered...");
					return;
				}
				
				SetQuestData(1000202, "2");
				self.say("Thanks! I think you have to travel all over the places to get these items. If you have collected them all, please get back to me. I will wait right here.");
			}
			else if (quest2 == "2")
			{
				if (ItemCount(4000024) < 50 || ItemCount(4000002) < 50 || ItemCount(4000035) < 50 || ItemCount(4000037) < 50)
				{
					self.say("You haven't collected #b#t4000024#, #t4000037#, #t4000002#, #t4000035# 50 of each#k... Come on~ I will give you something good if you do these things for me~");
					return;
				}
				
				self.say("Wow~!! You got them all! This one was little bit harder than the last one, right? But Nothing will be hard for you... Anyway, thanks, but they are not enough, though.");
				
				if (!Exchange(0, 4000024, -50, 4000037, -50, 4000002, -50, 4000035, -50))
				{
					self.say("Huh, are you sure you brought all the items?");
					return;
				}
				
				AddEXP(800);
				SetQuestData(1000202, "2e");
				self.say("I got the stuff. Thanks you so much~ But I need much more stuff, though... So please get back to me when you are ready.");
			}
			else if (quest2 == "2e")
			{
				bool askStart3 = AskYesNo("Oh... Are you ready? Don't go too fast, though~ Okay, would you please get #b10 #t4000026# and #t4000023#, #t4000045#, #t4000039#, 50 of each#k?");
				
				if (!askStart3)
				{
					self.say("Oh you must be really busy now... But please get back to me if you have time later. I would like to get the stuff by myself, but I am not fully recovered...");
					return;
				}
				
				SetQuestData(1000202, "3");
				self.say("Thanks! I think you have to travel all over the places to get these items. If you have collected them all, please get back to me. I will wait right here.");
			}
			else if (quest2 == "3")
			{
				if (ItemCount(4000039) < 50 || ItemCount(4000023) < 50 || ItemCount(4000026) < 10 || ItemCount(4000045) < 50)
				{
					self.say("You haven't collected #b10 #t4000026# and #t4000023#, #t4000045#, #t4000039#, 50 of each#k ... Come on~ I will give you something good if you do these things for me~");
					return;
				}
				
				self.say("Wow~!! You got them all! This one was little bit harder than the last one, right? But Nothing will be hard for you... Anyway, thanks, but they are not enough, though.");
				
				if (!Exchange(0, 4000026, -10, 4000023, -50, 4000045, -50, 4000039, -50))
				{
					self.say("Huh, are you sure you brought all the items?");
					return;
				}
				
				AddEXP(1000);
				SetQuestData(1000202, "3e");
				self.say("I got the stuff. Thanks you so much~ But I need much more stuff, though... So please get back to me when you are ready.");
			}
			else if (quest2 == "3e")
			{
				bool askStart4 = AskYesNo("Oh... Are you ready? Don't go too fast, though~ Okay, this time will be the last. Would you please get #b#t4000044#, #t4000025#, #t4000027#, #t4000028#, 50 of each and 1 #t4021007# #k?");
				
				if (!askStart4)
				{
					self.say("Oh you must be really busy now... But please get back to me if you have time later. I would like to get the stuff by myself, but I am not fully recovered...");
					return;
				}
				
				SetQuestData(1000202, "4");
				self.say("Thanks! I think you have to travel all over the places to get these items. If you have collected them all, please get back to me. I will wait right here.");
			}
			else if (quest2 == "4")
			{
				if (ItemCount(4021007) < 1 || ItemCount(4000025) < 50 || ItemCount(4000027) < 50 || ItemCount(4000044) < 50 || ItemCount(4000028) < 50)
				{
					self.say("You haven't collected #b#t4000044#, #t4000025#, #t4000027#, #t4000028#, 50 of each \r\nand 1 #t4021007# #k ... Come on~ I will give you something good if you do these things for me~");
					return;
				}
				
				self.say("Wow~!! You got them all! This one was little bit harder than the last one, right? But nothing will be hard for you... Anyway, thank you! Now, I got all the stuff I need~");
				
				Random rnd = new Random();
				int[] rewards = {1072144, 1072145, 1072146};
				
				int itemID = rewards[rnd.Next(rewards.Length)];
				
				if (!Exchange(0, 4000044, -50, 4000025, -50, 4000027, -50, 4000028, -50, 4021007, -1, itemID, 1))
				{
					self.say("Huh ... are you sure you brought all the items? If so, make sure there is a free space in your equip. inventory.");
					return;
				}
				
				AddEXP(1500);
				SetQuestData(1000202, "end");
				QuestEndEffect();
				self.say($"I got the stuff. How do you like the #b#t{itemID}##k? My grandma made these shoes for #p1012100# back then ... well, thank you so much~ I have gotten everything I need now ... so long~");
			}
			else
			{
				self.say("Thanks for the last time. Now I feel much better. Thanks for everything.");
			}
		}
	}
}