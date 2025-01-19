using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Advancement()
	{
		bool askThird = AskYesNo("Okay! Now, you'll be transformed into a much more powerful magician through me. Before doing that, though, please make sure your SP has been thoroughly used. You'll need to use up at least all of SP's gained until level 70 to make the 3rd job advancement. Oh, and since you have already chosen your path of the occupation by the 2nd job advancement, you won't have to choose again for the 3rd job advancement. Do you want to do it right now?");
		
		if (!askThird)
		{
			self.say("You've already passed the test, so there's no need to worry... well, come talk to me when you've made your decision. When you're ready, I will advance you to the 3rd job. As long as you're ready.");
			return;
		}
		
		int nSP = (Level - 70) * 3;
		
		if (SP > nSP)
		{
			self.say("Hmmm... you seem to have too much #bSP#k. You won't be able to make the leap to 3rd job with so much unused SP. Use more SP on your 1st and 2nd level skills before returning here.");
			return;
		}
		
		if (Job == 210) ChangeJob(211);
		else if (Job == 220) ChangeJob(221);
		else if (Job == 230) ChangeJob(231);
		
		AddSP(1);
		AddAP(5);
		
		if (Job == 211)
		{
			self.say("You're the #bMage of Fire and Poison#k from here on out. The new skill book features new and improved spells for fire and poison, and skills such as #bElemental Amplification#k (improves element-based spells) and #bSpell Booster#k (improves the overall speed of the attacking spells) will enable you to attack the monsters quickly and effectively. Defensive spells such as #bPartial Resistance#k (improved def. against certain element-based attacks) and #bSeal#k (seals up the monster) will help negate the one weakness Mages possess: lack of HP.");
		}
		else if (Job == 221)
		{
			self.say("You're the #bMage of Ice and Lightning#k from here on out. The new skill book features new and improved spells for ice and lightning, and skills such as #bElemental Amplification#k (improves element-based spells) and #bSpell Booster#k (improves the overall speed of the attacking spells) will enable you to attack the monsters quickly and effectively. Defensive spells such as #bPartial Resistance#k (improved def. against certain element-based attacks) and #bSeal#k (seals up the monster) will help negate the one weakness Mages possess: lack of HP.");
		}
		else if (Job == 231)
		{
			self.say("You're the #bPriest#k from here on out. The new skill book features new and improved holy spells such as #bShining Ray#k and #bSummoning Dragon#k, and skills such as #bMystic Door#k (creates a door for the exit to the nearest town) and #bHoly Symbol#k (improves the EXP gained) can be vital to the party play. Off-beat spells such as #bDoom#k (turns monsters into snails) separates Priests from other jobs as the most different of all.");
		}
		
		self.say("I've also given you a little bit of SP and AP, which will be beneficial to you. You have now become a powerful, powerful magician, indeed. Remember, though, that the real world will be awaiting your arrival with even tougher obstacles to overcome. Once you feel like you cannot train yourself to reach a higher place, then, and only then, come see me. I'll be here waiting.");
	}
	
	private void JobQuest()
	{
		string questThird = GetQuestData(7500000);
		
		if (Level < 70)
		{
			self.say("You are not yet qualified to make the 3rd job advancement. You need to be at least level 70 for this. Train more and then come and see me.");
			return;
		}
		
		if (Job == 210 || Job == 220 || Job == 230)
		{
			if (questThird == "")
			{
				bool startQuest = AskYesNo("Welcome. I'm #bRobeira#k, the chief of all magicians, always ready to offer my knowledge and guidance to the magicians all around the world. You seem ready to take on the challenges of the 3rd job advancement, but I advise you not to get too confident. I've seen too many magicians come and go, failing to live up to my expectations in the process. I don't know about you, though. Are you ready to be tested and make the 3rd job advancement?");
				
				if (!startQuest)
				{
					self.say("I guess you're not ready to face the challenges ahead. Come and see me only when you're certain you're prepared for the advancement.");
					return;
				}
				
				SetQuestData(7500000, "s");
				self.say("Good. You will be tested on two important aspects of the magician: strength and wisdom. I'll now explain to you the physical half of the test. Remember #b#p1032001##k from Ellinia? Go see him, and he'll give you the details on the first half of the test. Please complete the mission, and get #b#t4031057##k from #p1032001#.");
				self.say("The mental half of the test can only start after you pass the physical part of the test. #b#t4031057##k will be the proof that you have indeed passed the test. I'll let #b#p1032001##k know in advance that you're making your way there, so get ready. It won't be easy, but I have the utmost faith in you. Good luck.");
			}
			else if (questThird == "s" || questThird == "p1")
			{
				self.say("You haven't gotten #b#t4031057##k yet. Please go see #b#p1032001##k of Ellinia that helped you go through the 1st and 2nd job adv., complete the mission given and get #b#t4031057##k from him for me. Then, I'll let you take the 2nd test. Good luck...");
			}
			else if (questThird == "p2")
			{
				if (ItemCount(4031057) < 1)
				{
					self.say("You don't have #b#t4031057##k with you. Go see #b#p1032001##k from Ellinia, pass the test, and bring #b#t4031057##k back with you. Only then do you pass the first part of the test. Good luck!");
					return;
				}
				
				self.say("Great job completing the physical part of the test. I knew you could do it. Now that you have passed the first half of the test, here's the second half. Please give me the necklace first.");
				
				if (!Exchange(0, 4031057, -1))
				{
					self.say("Are you sure you received #b#t4031057##k from #b#p1032001##k? Don't forget to leave a space in your Etc. inventory.");
					return;
				}
				
				SetQuestData(7500000, "end1");
				self.say("Here's the 2nd half of the test. This test will determine whether you are smart enough to take the next step towards greatness. There is a dark, snow-covered area called the Holy Ground at the snowfield in Ossyria, where even the monsters can't reach. On the center of the area lies a huge stone called the Holy Stone. You'll need to offer a special item as the sacrifice, then the Holy Stone will test your wisdom right there on the spot.");
				self.say("You'll need to answer each and every question given to you with honesty and conviction. If you correctly answer all the questions, then the Holy Stone will formally accept you and hand you #b#t4031058##k. Bring back the necklace, and I will help you make the next leap forward. Good luck.");
			}
			else if (questThird == "end1")
			{
				if (ItemCount(4031058) < 1)
				{
					self.say("You don't have #b#t4031058##k with you. Find the dark, snow-covered area called the Holy Ground deep in the snowfields in Ossyria, offer a special item as the sacrifice and answer all of the questions with honesty and conviction to receive #b#t4031058##k. Bring it back to me to complete the test for the 3rd job advancement. Best of luck to you...");
					return;
				}
				
				self.say("Great job completing the mental part of the test. You have wisely answered all the questions correctly. I must say, I am quite impressed with the level of wisdom you have displayed there. Please hand me the necklace first, before we take on the next step.");
				
				if (!Exchange(0, 4031058, -1))
				{
					self.say("Are you sure you received #b#t4031058##k from the Holy Stone? If you're sure, don't forget to leave a space in your Etc. inventory.");
					return;
				}
				
				SetQuestData(7500000, "end2");
				Advancement();
			}
			else
			{
				Advancement();
			}
		}
		else if (Job == 211 || Job == 221)
		{
			self.say("It's you who passed the tests to make the 3rd job advancement. How's the life of a #bMage#k? You must continue training as you journey through this place. Ossyria is full of powerful monsters that even I don't know about. If you have any questions, come to me at the end of your journey. Best of luck to you.");
		}
		else if (Job == 231)
		{
			self.say("It's you who passed the tests to make the 3rd job advancement. How's the life of a #bPriest#k? You must continue training as you journey through this place. Ossyria is full of powerful monsters that even I don't know about. If you have any questions, come to me at the end of your journey. Best of luck to you.");
		}
		else
		{
			self.say("I'm #bRobeira#k, the chief of all magicians, always ready to offer my knowledge and guidance to the magicians all around the world. However, you don't look like a magician. I can't help you like this. This room is full of chiefs of their respective classes. If you need anything, go talk with one of them.");
		}
	}
	
	private void Zakum()
	{
		string questZakum1 = GetQuestData(7000000);
			
		if (questZakum1 != "")
		{
			self.say("How are you doing in the quest of the Zakum Dungeon? I heard that there is an incredible monster in the depths of the place... anyway, good luck. I'm sure that you will succeed.");
			return;
		}
		
		if (Level < 50)
		{
			self.say("You want permission to do the quest of the Zakum Dungeon. I'm sorry but the dungeon is too difficult for you. You must be at least level 50 to try... train more and then come back here.");
			return;
		}
		
		if (Job < 200 || Job >= 300)
		{
			self.say("You want permission to do the quest of the Zakum Dungeon. I'm sorry but you don't look like a magician. Go find the chief of your occupation.");
			return;
		}
		
		SetQuestData(7000000, "s");
		self.say("You want permission to do the quest of the Zakum Dungeon, right? It must be #b#p2030008##k... ok, right! I'm sure that you'll be fine in the dungeon. I hope that you take care in there...");
	}
	
	public override void Run()
	{
		if (Level < 50)
		{
			self.say("Hmm... It seems like there's nothing I can do to help you. Come back here when you have become much stronger.");
			return;
		}
		
		AskMenuCallback("What do you want from me?#b",
			(" I want to make the 3rd job advancement", Level >= 70, JobQuest),
			(" Please allow me to do the Zakum Dungeon Quest", Level >= 50, Zakum)
		);
	}
}