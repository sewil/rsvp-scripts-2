using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string qWing1 = GetQuestData(1005400);
		string qIcarus1 = GetQuestData(1005500);
		string qIcarus2 = GetQuestData(1005501);
		string qIcarus3 = GetQuestData(1005502);
		string qIcarus4 = GetQuestData(1005503);
		
		if (Level < 10)
		{
			self.say("Look... the sky...");
			return;
		}
		
		if (qIcarus1 == "")
		{
			bool start = AskYesNo("Man, soooo boring. Hey, you! Do you have any free time right now? Do you wanna hang out with me? I'm really bored out of my mind here.");
			
			if (!start)
			{
				self.say("Oh you're busy ... I'm really bored, though. Don't you wanna hang out with me?");
				return;
			}
			
			SetQuestData(1005500, "1");
			self.say("Alright! Thanks... now, what should we do? How about ... I know, why don't I quiz you on some things? They aren't going to be hard at all, so don't worry about it. Are you down with it?");
		}
		else if (qIcarus1 == "1")
		{
			int ask1 = AskMenu("Which of these monsters will you NOT see near Kerning City?#b",
				(0, " 1. Stump"),
				(1, " 2. Blue Mushroom"),
				(2, " 3. Slime"),
				(3, " 4. Ribbon Pig"),
				(4, " 5. Hector"));
			
			if (ask1 != 4)
			{
				self.say("No no no! Think carefully!");
				return;
			}
			
			int ask2 = AskMenu("Which of these NPC's will not NOT see at Kerning City?#b",
				(0, " 1. Don Giovanni"),
				(1, " 2. Andre"),
				(2, " 3. Monglong"),
				(3, " 4. Valen"),
				(4, " 5. Mapa"));
			
			if (ask2 != 3)
			{
				self.say("You're wrong!! You can see that NPC at Kerning City!");
				return;
			}
			
			int ask3 = AskMenu("To make your way to Orbis, which of these towns will you have to go to get on board for the trip?#b",
				(0, " 1. Ellinia"),
				(1, " 2. El Nath"),
				(2, " 3. Perion"),
				(3, " 4. Henesys"));
			
			if (ask3 != 0)
			{
				self.say("Are you sure? Think again!");
				return;
			}
			
			self.say("Wow, you're pretty good! You should be starring on a quiz show, the way you're answering these questions!");
			self.say("Hey you were good at answering those questions! That was fun, except ... I'm still bored. Can you do me one more favor? I need something to play around with here so can you get me #b40 tree branches and 40 squishy liquids#k? Please?");
			
			SetQuestData(1005500, "2");
			self.say("I'll be here waiting. You better be back fast!");
		}
		else if (qIcarus1 == "2")
		{
			if (ItemCount(4000003) < 40 || ItemCount(4000004) < 40)
			{
				self.say("You don't have all of them? Please help me ... I am bored out of my mind here.");
				return;
			}
			
			self.say("Wow, you brought all of them!! Thank you so much! Thanks to you, I won't be so bored up in here afterwards. How should I thank you for your hard work? Hmmm ... here, take this!");
			
			if (!Exchange(0, 4000003, -40, 4000004, -40, 2000000, 25, 2000003, 15))
			{
				self.say("Please let me give you these... leave two open slots in your use inventory.");
				return;
			}
			
			AddEXP(250);
			SetQuestData(1005500, "e");
			QuestEndEffect();
			self.say("Again, thanks a lot! Later!!");
		}
		else if (qIcarus1 == "e")
		{
			if (Level < 32)
			{
				self.say("Look... the sky...");
				return;
			}
			
			if (qIcarus2 == "")
			{
				int ask4 = AskMenu("Wouldn't it be incredible to swim in those clouds and fly your way through freedom? I wonder what it's like to fly, free as a bird. Even if it's only for a few minutes, I'd be more than happy to just be up there!#b",
					(0, " Can humans really fly?"),
					(1, " Grow up, you know we can't fly..."));
					
				if (ask4 == 1)
				{
					self.say("You are just like everyone else living in a box. Wake up, think outside the box! You'll see ... someday you'll see me flying around here.");
					return;
				}
				
				bool start2 = AskYesNo("Oh yeah, I truly believe we're meant to fly, and I will try my hardest to make that wish come true! That got me thinking, in order to fulfill my dream, I should make a huge hang glider! I read it in a book, and it says we can fly like a bird with the hang glider in place. All I need now is a set of materials needed to build it, and ... do you want to help me out here? If you get me the materials, I'll definitely let you ride on it. What do you think?");
				
				if (!start2)
				{
					self.say("I can't believe you're giving up on a golden opportunity to fly. If that's the case, then I'm going to try to make it myself! You'll see!!!");
					return;
				}
				
				SetQuestData(1005501, "s");
				self.say("I knew you'd help me out! Together we can make the most awesome hang glider ever! I was thinking, in order to make it happen, I'll need #b50 #t4000042#s#k for the wings, #b10 \r\n#t4003001#s#k for the framework, and #b50 #t4003004#s#k to make the flight as smooth as possible. You'll see a lot of Steezy's at the subway station nearby, so you should check it out!");
			}
			else if (qIcarus2 == "s")
			{
				if (ItemCount(4003001) < 10 || ItemCount(4000042) < 50 || ItemCount(4003004) < 50)
				{
					self.say("Did you get all the materials I asked? I don't think you have all of them! Please gather up #b50 #t4000042#s#k, #b10 \r\n#t4003001#s, and 50 #t4003004#s#k! The faster you get them for me, the earlier we'll be floating up in the air!");
					return;
				}
				
				self.say("I've been waiting for a loooong time! While you were out gathering up the materials, I have drawn up the perfect blueprint for it! All we need now is to follow through with the plan, and we'll be up in the skies in no time! Did you gather up all the materials?");
				
				if (!Exchange(0, 4000042, -50, 4003001, -10, 4003004, -50))
				{
					self.say("Huh? Are you sure you brought everything?");
					return;
				}
				
				AddEXP(6000);
				SetQuestData(1005501, "e");
				QuestEndEffect();
				self.say("Wow, that's a lot!! Well, I will have to get started on making the hang glider. Drop by sometime later. I should be done by then. We'll be flying in no time!");
			}
			else if (qIcarus2 == "e")
			{
				if (Level < 37)
				{
					self.say("Someday... Someday... I will fly...");
					return;
				}
				
				if (qIcarus3 == "")
				{
					int ask5 = AskMenu("Hey, you're the one that got me the materials for the hang glider...#b",
						(0, " Did you make the hang glider?"));
					
					bool start3 = AskYesNo("Oh, that ... well ... I faced MINOR, I mean, MIIINOR technical difficulties, and ... well don't worry about it!! Icarus does NOT let MINOR obstacle like affect him! Anyway, I was thinking of a much safer way to fly, and I think I have a great plan. Are you willing to help me out again?");
					
					if (!start3)
					{
						self.say("Trust me, we'll be flying this time! Wouldn't it stink to give it up right now, when we're so close?");
						return;
					}
					
					SetQuestData(1005502, "s");
					self.say("I knew you'd help me out. We'll make the best flying balloon in the world! It should consist of a huge balloon, with a basket at the bottom big enough to fit both of us. To make it, I'll need #b100 #t4000035#s#k for the huge balloon, and #b10 \r\n#t4031164#s#k for the sandbags that'll be needed to keep the balloon balanced.");
					self.say("I have the basket ready. As for the Alligator Skin Pouch, it's made exclusively out of #bLigator#k skin, and you can get them by hunting the Ligators at the swamp. Good luck!");
				}
				else if (qIcarus3 == "s")
				{
					if (ItemCount(4031164) < 10 || ItemCount(4000035) < 100)
					{
						self.say("Did you get all the materials I asked? I don't think you have all of them! Please gather up #b100 #t4000035#s#k and #b10 \r\n#t4031164#es#k for me. You can get #b#t4031164##k through Ligators. Please hurry~ the faster you get them for me, the faster we'll be floating up in the air!");
						return;
					}
					
					self.say("I've been working on the basket, to see if it is sturdy enough to hold both of us. Now all we need is a big balloon. Did you gather up the materials that I asked you for?");
					
					if (!Exchange(0, 4000035, -100, 4031164, -10))
					{
						self.say("Huh? Are you sure you brought everything?");
						return;
					}
					
					AddEXP(11000);
					SetQuestData(1005502, "e");
					QuestEndEffect();
					self.say("Wow, that's a lot!! Well, I will have to get started on making the balloon. Please drop by sometime later, for I should be done by then. We'll be floating our way to Ossyria in no time!");
				}
				else if (qIcarus3 == "e")
				{
					if (qWing1 != "e" || Level < 42)
					{
						self.say("I will have to get started on making the balloon. Please drop by sometime later, for I should be done by then. We'll be floating our way to Ossyria in no time!");
						return;
					}
					
					if (qIcarus4 == "")
					{
						int ask6 = AskMenu("Hey, you're the one that got me the materials for the flying balloon...#b",
							(0, " Did you get it to work?"));
							
						bool start4 = AskYesNo("Oh, that ... well ... I faced MINOR, I mean, MIIINOR technical difficulties, and ... well I don't know what's wrong!! Is it really an impossible dream to realize? All I wanted to do was to \r\nfly!! I can't let this deter me from my ultimate goal! I can't be giving up this soon. Can you help me out one last time?");
						
						if (!start4)
						{
							self.say("Even you have a hard time trusting me now...seriously, this one is FOR REAL! Why can't you trust me?");
							return;
						}
						
						SetQuestData(1005503, "s1");
						self.say("I knew you'd help me out. I really appreciate it! Anyway, I have a fairy friend, and his name is Wing. He lives in Ellinia, so it's hard to see him frequently, but we're still really close.");
						self.say("Since Wing is a fairy, I'm sure he knows a way to make me fly. Please find out what #bWing#k has to offer in terms of me flying! Since I'm a long way from Ellinia, I don't think I can go there myself. Can you go there for me and ask?");
					}
					else if (qIcarus4 == "s1" || qIcarus4 == "s2")
					{
						self.say("Since Wing is a fairy, I'm sure he knows a way to make me fly. Please find out what #bWing#k has to offer in terms of me flying! Since I'm a long way from Ellinia, I don't think I can go there myself. Can you go there for me and ask?");
					}
					else if (qIcarus4 == "s3")
					{
						if (ItemCount(4031163) < 1)
						{
							self.say("Since Wing is a fairy, I'm sure he knows a way to make me fly. Please find out what #bWing#k has to offer in terms of me flying! Since I'm a long way from Ellinia, I don't think I can go there myself. Can you go there for me and ask?");
							return;
						}
						
						self.say("Oh you're back!! Did you meet up with Wing? What about the pill? The pill! Did you bring it?");
						
						Random rnd = new Random();
						int[] cape = {1102054, 1102055, 1102056};
						
						int itemID = cape[rnd.Next(cape.Length)];
						
						if (!Exchange(0, 4031163, -1, itemID, 1))
						{
							self.say("Please make some room in your equip. inventory!");
							return;
						}
						
						AddEXP(13000);
						SetQuestData(1005503, "e");
						QuestEndEffect();
						self.say("Wow, this is it. This pill will enable me to fly anywhere I desire and finally realize my dream of flying. Thank you so much for all your help. Here's a little thank you present from me. Hopefully it'll help you down the road. I'll see you around!");
					}
					else
					{
						self.say("This pill will enable me to fly anywhere I desire and finally realize my dream of flying. Thank you so much for all your help.");
					}
				}
			}
		}
	}
}