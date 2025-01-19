using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest3 = GetQuestData(1002602);
		string quest4 = GetQuestData(1002603);
		string quest5 = GetQuestData(1002605);
		string quest6 = GetQuestData(1002604);
		
		if (quest3 == "")
		{
			self.say("I'm #b#p2040029##k, and I've been sent here to see what's wrong with the Ludibrium Clocktower, but I can't seem to find any errors in this.");
		}
		else if (quest3 == "s")
		{
			if (quest4 == "")
			{
				if (ItemCount(4031094) < 1)
				{
					self.say("Can I help you?? What? Olson sent you here? Then you must have brought #b#t4031094##k with you. But where's \r\n#t4031094#? If you lost it, then please go get it from Olson again.");
					return;
				}
				
				self.say("Hmmm ... I'm #b#p2040029##k, indeed, but...how can I help you? What? #b#p2040002##k wants me to plug \r\n#b#t4031094##k somewhere appropriate? So that the Clocktower will run right ...... Hmmm ... that's not a problem, except ... there's ... one problem ... with ... me ");
				bool start = AskYesNo("I know where to put it ... but ... I've been working so hard ... that ... I need to be rewound very soon ... please take \r\n#b#o4230113##k down ... and obtain one #b#t4031098##k for me ... thanks ...");
				
				if (!start)
				{
					self.say("Hmmm ... you must be busy with other stuff, but without me, there won't be anyone else that can put #b#t4031094##k in place. If you want the Ludibrium Clocktower working again, then you may want to do me a favor. If you have a change of heart, please talk to me.");
					return;
				}
				
				if (!Exchange(0, 4031094, -1))
				{
					self.say("Hmm ... are you sure ... you brought the #b#t4031094##k?");
					return;
				}
				
				SetQuestData(1002603, "s");
				self.say("Thanks ... I need to be rewound ... to the point ... where ... even talking ... is hard ... anyway, please go get #b#t4031098##k ... by killing #b#o4230113##k ... I don't have ... much time ... so please ... hurry ... I'll be here ... waiting...");
			}
			else if (quest4 == "s")
			{
				if (ItemCount(4031098) < 1)
				{
					self.say("I don't think you ... have gotten ... #b#t4031098##k, yet ... Around this abandoned place, you'll ... find ... a monster called #b#o4230113##k. Kill it, and get one #b#t4031098##k ... and bring ... it ...to me... I don't ... have...much time ... please ... hurry.");
					return;
				}
				
				self.say("Ohh... you must have finally found #b#t4031098##k. Thank goodness. I can probably ... start ... wor...king ...right now ... let's see if ... this ... fits on ...me. Then I'll put \r\n#b#t4031094##k where ... it ... be...longs.");
				
				if (!Exchange(0, 4031098, -1))
				{
					self.say("Hmm ... are you sure ... you brought the #b#t4031098##k?");
					return;
				}
				
				AddEXP(2700);
				SetQuestData(1002603, "e");
				QuestEndEffect();
				self.say("Oooh, I'm back in full strength!! Now I shall put this part where it belongs... Hahhhh...Hahhhh...there you go, it's done! The clocktower shall be working fine now. Please tell #b#p2040002##k of the good news. I'll have to get back to work now. I'll see you around!");
			}
			else if (quest4 == "e")
			{
				self.say("Hoh, you're the one that found #b#t4031098##k for me, and help me fix the clocktower by handing me \r\n#b#t4031094##k. Well, now please go tell #b#p2040002##k of the good news! I have some business to take care of here.");
			}
		}
		else if (quest3 == "e")
		{
			if (Level < 34)
			{
				self.say("You must have told #b#p2040002##k the Clocktower has been fixed. Hopefully the soldiers can trust the time now. Thank you so much for your hard work. I'll have to get back to work now. Please head back to Ludibrium, as this place is too dangerous a place to just hang out.");
				return;
			}
			
			if (quest5 == "")
			{
				self.say("Glad to see you again here. The spring you got me last time, that was good enough for me to be 100% healthy again. Does it never run out? Well, it ain't #t4031098# for nothing. It's very well-made, so I don't have to worry about that one bit.");
				bool start2 = AskYesNo("I have recovered, but there's another set of problems killing me now. Some random, unqualified monsters are the ones opening up the Clocktower, and ruining things. My workers are also not doing so well right now... because of this, I'll need your help one more time.");
				
				if (!start2)
				{
					self.say("We need your help desperately. Who am I going to ask for this ... if you have a change of heart, then please talk to me.");
					return;
				}
				
				SetQuestData(1002605, "100");
				self.say("I can't believe you said yes! Well, here's the details. There have been monsters contaminated with the dark force that seems to emanate here, and one of the worst seems to be #b#o3210207##k, but I can't do a thing about it.");
				self.say("They use their small bodies to penetrate their way into the huge clock and cause all kinds of troubles this way. The clock is vulnerable in multiple spots to begin with, and they tend to attack in bunches, so the workers have a hard time fixing it. That's why...");
				self.say("Please take down #b100 #o3210207#s#k that should be around here. It'll be better for us if they just decrease in numbers. #o3210207# is a bug-like monster that has a clock on its back, so it won't be hard to locate it.");
			}
			else if (quest5 == "e")
			{
				if (Level < 39)
				{
					self.say("You must have told #b#p2040002##k the Clocktower has been fixed. Hopefully the soldiers can trust the time now. Thank you so much for your hard work. I'll have to get back to work now. Please head back to Ludibrium, as this place is too dangerous a place to just hang out.");
					return;
				}
				
				if (quest6 == "")
				{
					self.say("You're the one that took care of the annoying ones the other day, but what are you doing here on a dangerous spot like this? We're here for work, but this floor is full of monsters contaminated by evil force, and you may not get out of here healthy.");
					bool start3 = AskYesNo("Hmm, but then again, if you're here in the first place, then you're strong enough. We've been looking for someone that can help us in our journey, and it's you! You might be busy taking care of other things, too, but please set aside some time for us. Please??");
					
					if (!start3)
					{
						self.say("Sigh ... this is precisely the time when we need your help. Who are we going to ask for?????");
						return;
					}
					
					SetQuestData(1002604, "s");
					self.say("Thanks! As you may know, this place is pretty abandoned, but a lot of the workers are here on special duties. I can move around with the old-school spring being rewound, but most of the new workers are operated in batteries.");
					self.say("But we've also been lacking batteries to the point where some workers cannot even perform expected duties because of the lack of power. The worst thing that can happen is for each and every one of us to freeze altogether. I don't even want to think of the possibilities.");
					self.say("Please gather up #b200 #t4000111#s#k so the workers here can work much better. From what I have heard, the monster that most resembles a robot inside the Toy Factory has it.");
				}
				else if (quest6 == "s")
				{
					if (ItemCount(4000111) < 200)
					{
						self.say("Please hurry before these workers stop. The monster that most resembles a robot inside the toy factory has it, along with the belt #b#t4000111##k. Please gather up 200 #b#t4000111#s#k!");
						return;
					}
					
					self.say("You're back!!! Let's see... yeah, it is indeed the #b200 #t4000111#s#k. There were quite a few workers on the verge of stopping, but I'm glad that won't be the case anymore. Here's a small sign of our appreciation for your hard work.");
					
					int itemID = 0;
					
					if (chr.GetGender() == 0)
					{
						if (Job >= 100 && Job < 200) itemID = 1040085;
						else if (Job >= 200 && Job < 300) itemID = 1050036;
						else if (Job >= 300 && Job < 400) itemID = 1040079;
						else if (Job >= 400 && Job < 500) itemID = 1040083;
						else itemID = 1040014;
					}
					else if (chr.GetGender() == 1)
					{
						if (Job >= 100 && Job < 200) itemID = 1041085;
						else if (Job >= 200 && Job < 300) itemID = 1051024;
						else if (Job >= 300 && Job < 400) itemID = 1041081;
						else if (Job >= 400 && Job < 500) itemID = 1041074;
						else itemID = 1041004;
					}
					
					if (!Exchange(0, 4000111, -200, itemID, 1))
					{
						self.say("Are you sure you brought the batteries? If so, make some room in your equip. inventory please.");
						return;
					}
					
					AddEXP(5800);
					SetQuestData(1002604, "e");
					QuestEndEffect();
					self.say("Alright, the batteries are gong to be in, now. Thanks for your hard work. Thank you. Thank you. Hopefully you'll make it to the bottom safely!");
				}
				else if (quest6 == "e")
				{
					self.say("Thanks for your hard work. Thank you. Thank you. Hopefully you'll make it to the bottom safely!");
				}
			}
			else
			{
				if (quest5 != "000")
				{
					self.say("Please take out a 100 #b#o3210207#s#k, the number 1 reason for all those nicks and bruises the clock takes.");
					return;
				}
				
				self.say("What took you so long!! I've been waiting for you here. From what I've heard, you took care of the #b100 #o3210207#s#k just the way you promised. It may have taken you some time, but we're more than thankful for helping us. Here's a small present for your hard work.");
				
				if (!Exchange(0, 2000010, 120))
				{
					self.say("Hoh... you will need to free up some space in your use inventory first.");
					return;
				}
				
				AddEXP(4200);
				SetQuestData(1002605, "e");
				QuestEndEffect();
				self.say("Do you like the #b120 #t2000010#s#k that I gave you? Thank you so much for all your help. Now that the #b#o3210207#s#k are much lesser than they were before, I hope they don't go in the clock of Clocktower and destroy things anymore. There are still lots of problems that remain unsolved, though. I'll be here waiting for you.");
			}
		}
	}
}