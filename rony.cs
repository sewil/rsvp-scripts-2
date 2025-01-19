using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1000600);
		string quest2 = GetQuestData(1000602);
		
		if (quest == "")
		{
			self.say("Now what exactly is in this book that makes my dad take care of it so much? I want to know what's inside, but I don't think I'll understand it one bit...");
		}
		else if (quest == "1")
		{
			self.say("Hey who are you? You know my dad well? Ah... you want this red book, huh?? I see...my daddy likes this book more than he likes me! This book ... NO, I can't give you this book!! (stomach growling...) Ahhhh!");
			self.say("No... no... I'm NOT hungry ...! Dang, all, alright. I'll give you back the book. BUT! Not for free! I am really starving, and I need some food, so...if you get me something to eat, the book is yours. I promise!");
			self.say("I want... #b50 #t4000029#s#k and #p1010100#'s #bUnagi Special#k, along with a #b#t4031015##k. #p1010100# is my awesome friend that lives in #m100000000#. Ask her for the Unagi Special and she'll make it for you.");
			self.say("Oh yeah! The fairies from #m101000000# probably have #b#t4031015##k. I usually ate it at #m101000000#. If you ever get hungry on the way back and eat a couple of those... my dad's book is going to \r\n#o3230100#, so you better take care of that food!!!");
			
			SetQuestData(1000600, "2");
		}
		else if (quest == "2")
		{
			self.say("You didn't get all my food yet?? Bring #b50 #t4000029#s#k, #p1010100# from #m100000000#'s #bUnagi Special#k, and #b#t4031015##k from the fairies of #m101000000#, and I'll give you back my dad's book. I promise~!!");
		}
		else if (quest == "3")
		{
			if (ItemCount(4000029) < 50 || ItemCount(4031014) < 1 || ItemCount(4031015) < 1)
			{
				self.say("You didn't get all my food yet?? Bring #b50 #t4000029#s#k, #p1010100# from #m100000000#'s #bUnagi Special#k, and #b#t4031015##k from the fairies of #m101000000#, and I'll give you back my dad's book. I promise~!!");
				return;
			}
			
			self.say("Wow...! You DID bring all that food!!!! Sweeeeeeet!!! Thank you so, so, soo much!! Oh yeah, a promise is a promise...here's my dad's book. I have no idea what this book is about, but...why is he so gaga over this anyway??");
			
			if (!Exchange(0, 4031014, -1, 4031015, -1, 4000029, -50, 4031016, 1))
			{
				self.say("You don't have room in your etc. inventory... do you want the book or not??");
				return;
			}
			
			AddEXP(300);
			SetQuestData(1000600, "4");
		}
		else if (quest == "4")
		{
			if (ItemCount(4031016) >= 1)
			{
				self.say("Hehehe... I took off with my dad's precious book... but ... this book ... what's it for??? Why does my dad take such good care of this book?? I have noooo idea ...");
				return;
			}
			
			self.say("Wow...! You DID bring all that food!!!! Sweeeeeeet!!! Thank you so, so, soo much!! Oh yeah, a promise is a promise...here's my dad's book. I have no idea what this book is about, but...why is he so gaga over this anyway??");
			
			if (!Exchange(0, 4031016, 1))
			{
				self.say("You don't have room in your etc. inventory... do you want the book or not??");
				return;
			}
		}
		else if (quest == "e")
		{
			if (quest2 == "" && Level >= 55 && Job >= 200 && Job < 300)
			{
				self.say("Oh... You are the one who returns the book to my dad! Did you give it back to my dad? Ah... My dad... he doesn't worry about me... The only thing he cares is that stupid book... Aren't I right?");
				bool askStart1 = AskYesNo("You look much stronger than the last time... Can you do me a favor? I got a request from the fairy in the Ellinia... There are many baby fairies and we should make houses for them... Can you collect those materials for building the houses? Would you?");
				
				if (!askStart1)
				{
					self.say("Yeah... You can't take a request from the kid... yeah... right... If you change your mind, please let me know... I can't do this on my own...");
					return;
				}
				
				SetQuestData(1000602, "1");
				self.say("Wow~ Thanks! First of all, can you collect #b#t4000001#, #t4000005#, #t4000004#, #t4000016#, 50#k of each? Those materials come from very weak monsters... So it won't be that hard... It is only a start... ");
			}
			else if (quest2 == "1")
			{
				if (ItemCount(4000001) < 50 || ItemCount(4000005) < 50 || ItemCount(4000004) < 50 || ItemCount(4000016) < 50)
				{
					self.say("I don't think you have collected #b#t4000001#s, Leaves, #t4000004#s, #t4000016#s 50 of each #k. But cheer up! If you help me, I will give something good~ I promise~");
					return;
				}
				
				self.say("Wow... You have collected them all! Cool~ Isn't it fun to hunt weak monsters? No? oh come on~ Anyway I will give these to the fairies... It won't be enough, though...");
				
				if (!Exchange(0, 4000001, -50, 4000005, -50, 4000004, -50, 4000016, -50))
				{
					self.say("Are you sure you brought everything?");
					return;
				}
				
				AddEXP(600);
				SetQuestData(1000602, "1e");
				self.say("I got the materials... Yeah... It was a good idea to ask you a favor... Thanks... but there are still more things to get. Therefore, whenever you have spare time, please get back to me...");
			}
			else if (quest2 == "1e")
			{
				bool askStart2 = AskYesNo("Oh... Are you ready? Don't go too fast! Anyway can you get \r\n#b#t4000006#, #t4000013#, #t4000020#, #t4000008# 50 of each#k? Thanks~");
				
				if (!askStart2)
				{
					self.say("Yeah... You can't take a request from the kid... yeah... right... If you change your mind, please let me know... I can't do this on my own...");
					return;
				}
				
				SetQuestData(1000602, "2");
				self.say("Thanks! I think you should travel around this time. When you get all those items, please bring them to me. I will wait here~");
			}
			else if (quest2 == "2")
			{
				if (ItemCount(4000006) < 50 || ItemCount(4000013) < 50 || ItemCount(4000020) < 50 || ItemCount(4000008) < 50)
				{
					self.say("I don't think you have collected #b#t4000006#, #t4000013#, #t4000020#, #t4000008# 50 of each#k. But cheer up! If you help me, I will give something good~ I promise~");
					return;
				}
				
				self.say("Wow you have collected them all! Great! This one was harder than last time, right? What? It is nothing? Haha... Anyway I will give these to the fairies, but there should be something more...");
				
				if (!Exchange(0, 4000006, -50, 4000013, -50, 4000020, -50, 4000008, -50))
				{
					self.say("Are you sure you brought everything?");
					return;
				}
				
				AddEXP(800);
				SetQuestData(1000602, "2e");
				self.say("I got the materials... Yeah... It was a good idea to ask you a favor... Thanks... but there are still more things to get. Therefore, whenever you have spare time, please get back to me...");
			}
			else if (quest2 == "2e")
			{
				bool askStart3 = AskYesNo("Oh... Are you ready? Don't go too fast! Anyway can you get \r\n#b#t4000014#, #t4000022#, #t4000033#, #t4000029# 50 of each #k? Thanks~");
				
				if (!askStart3)
				{
					self.say("Yeah... You can't take a request from the kid... yeah... right... If you change your mind, please let me know... I can't do this on my own...");
					return;
				}
				
				SetQuestData(1000602, "3");
				self.say("Thanks! I think you should travel around this time. When you get all those items, please bring them to me. I will wait here~");
			}
			else if (quest2 == "3")
			{
				if (ItemCount(4000014) < 50 || ItemCount(4000022) < 50 || ItemCount(4000033) < 50 || ItemCount(4000029) < 50)
				{
					self.say("I don't think you have collected #b#t4000014#, #t4000022#, #t4000033#, #t4000029# 50 of each#k. But cheer up! If you help me, I will give something good~ I promise~");
					return;
				}
				
				self.say("Wow you have collected them all! Great! This one was harder than last time, right? What? It is nothing? Haha... Anyway I will give these to the fairies, but there should be something more...");
				
				if (!Exchange(0, 4000014, -50, 4000022, -50, 4000033, -50, 4000029, -50))
				{
					self.say("Are you sure you brought everything?");
					return;
				}
				
				AddEXP(1000);
				SetQuestData(1000602, "3e");
				self.say("I got the materials... Yeah... It was a good idea to ask you a favor... Thanks... but there are still more things to get. Therefore, whenever you have spare time, please get back to me...");
			}
			else if (quest2 == "3e")
			{
				bool askStart4 = AskYesNo("Oh... Are you ready? Don't go too fast! Anyway can you get \r\n#b#t4000036#, #t4000025#, #t4000027#, #t4000028# 50 of each and 1 \r\n#t4021007##k? Thanks~");
				
				if (!askStart4)
				{
					self.say("Yeah... You can't take a request from the kid... yeah... right... If you change your mind, please let me know... I can't do this on my own...");
					return;
				}
				
				SetQuestData(1000602, "4");
				self.say("Thanks! I think you should travel around this time. When you get all those items, please bring them to me. I will wait here~");
			}
			else if (quest2 == "4")
			{
				if (ItemCount(4000036) < 50 || ItemCount(4000025) < 50 || ItemCount(4000027) < 50 || ItemCount(4000028) < 50 || ItemCount(4021007) < 1)
				{
					self.say("I don't think you have collected #b#t4000036#, #t4000025#, #t4000027#, #t4000028# 50 of each and 1 #t4021007##k. But cheer up! If you help me, I will give something good~ I promise~");
					return;
				}
				
				self.say("Wow you have collected them all! Great! This one was harder than last time, right? What? It is nothing? Haha... Anyway I will give these to the fairies...");
				
				Random rnd = new Random();
				int[] shoes = {1072136, 1072137, 1072138, 1072139};
				
				int itemID = shoes[rnd.Next(shoes.Length)];
				
				if (!Exchange(0, 4000036, -50, 4000025, -50, 4000027, -50, 4000028, -50, 4021007, -1, itemID, 1))
				{
					self.say("Are you sure you brought everything? If so, leave a space open in your equip. inventory!");
					return;
				}
				
				AddEXP(1500);
				SetQuestData(1000602, "end");
				QuestEndEffect();
				self.say($"I got the materials... Yeah... It was a good idea to ask you a favor... Thanks... Do you like the #b#t{itemID}##k? The fairies gave them to me... they found them somewhere around the forest ...");
				self.say("It looks like there is a certain way to wear this shoe... but I don't know how... Well... Anyway, I don't need this... So you can take it... I hope this can help you... Bye~ ");
			}
			else
			{
				self.say("You got him the book, right? I still don't think he even cares about me. I should just go back to the fairy town and stay there.");
			}
		}
	}
}