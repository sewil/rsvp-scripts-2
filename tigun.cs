using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1005200);
		
		if (quest == "")
		{
			self.say("I, Tigun the Advisor, am responsible for helping the King of Ludibrium run this place as smooth as possible... hmmm...");
		}
		else if (quest == "s1")
		{
			if (ItemCount(4031157) < 1 || ItemCount(4031158) < 1 || ItemCount(4031159) < 1)
			{
				self.say("Are you bothering me for no purpose? My gosh, I'm here doing something VERY important here, finding a way to recover Maple History Book. So don't even try pulling any simple thing first, because it's just SO annoying.");
				return;
			}
			
			self.say("Hahaha. Do you have any business here with me? Unless you have something very important to discuss, please leave immediately. What? Isn't that the Maple History Books that you're holding on to? How do you have that in the first place? Oh boy ... please show me the books iminediately!");
			
			if (!Exchange(0, 4031157, -1, 4031158, -1, 4031159, -1))
			{
				self.say("Oh... please leave some room in your equip. inventory so I can reward you...");
				return;
			}
			
			AddEXP(3000);
			SetQuestData(1005200, "s2");
			self.say("Wow ... These really are the Maple History Books! How did you?? No way? YOU are the one that #b#p1012109##k mentioned? I am so so sorry, I cannot believe how ignorant I can get sometimes. #b#p1012109##k told me all the nice things, but I didn't expect you to be here early!\r\nThese 3 books will be handed straight to the King of Ludibrium. Thank you so much, and now my Dad and I can go on \"break\" and see something I may like at some other countries.\nAlso, I just asked the King of Ludibrium to award you #t4031160#, but ... I made a mistake of leaving it there ... can you stop by again later?");
		}
		else if (quest == "s2")
		{
			self.say("Thank you for coming back. I was unable to award you #t4031160# last time; I've been very busy, you know. But now that I have a chance again, will you accept this as a sign of our hearts?");
			
			if (!Exchange(0, 4031160, 1))
			{
				self.say("Please make sure there's an empty slot in your etc. inventory.");
				return;
			}
			
			SetQuestData(1005200, "s3");
			self.say("#r#t4031160##k looks really nice on you.\r\nGo back to #bHenesys#k and show it to #b#p1012109##k to prove that the #bMaple History Books#k are well on its way to Ludibrium. For that, you may be able to get something nice in return, so go see that person.");
		}
		else if (quest == "s3")
		{
			if (ItemCount(4031160) >= 1)
			{
				self.say("Go back to #bHenesys#k and show it to #b#p1012109##k to prove that the \r\n#bMaple History Books#k are well on its way to Ludibrium. For that, you may be able to get something nice in return, so go see that person.");
				return;
			}
			
			self.say("By the way, #t4031160# is for you. Please accept this, for this is my way of saying Thank You for your hard work.");
			
			if (!Exchange(0, 4031160, 1))
			{
				self.say("Please make sure there's an empty slot in your etc. inventory.");
				return;
			}
		}
		else if (quest == "e")
		{
			self.say("Aren't you the honorable traveler? Did you meet with #p1012109#? You remind me of my own traveling days...I was one fearless kid back then...");
		}
	}
}