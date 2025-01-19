using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Advancement()
	{
		bool askThird = AskYesNo("Okay! Now, you'll be transformed into a much more powerful warrior through me. Before doing that, though, please make sure your SP has been thoroughly used. You'll need to use up at least all of SP's gained until level 70 to make the 3rd job advancement. Oh, and since you have already chosen your path of the occupation by the 2nd job advancement, you won't have to choose again for the 3rd job advancement. Do you want to do it right now?");
		
		if (!askThird)
		{
			self.say("You've already passed the test, so there's no need to worry... well, come talk to me when you've made your decision. When you're ready, I will advance you to the 3rd job. As long as you're ready...");
			return;
		}
		
		int nSP = (Level - 70) * 3;
		
		if (SP > nSP)
		{
			self.say("Hmmm... you seem to have too much #bSP#k. You can't make the 3rd job advancement with so much unused SP. Use more SP on your 1st and 2nd level skills before returning here.");
			return;
		}
		
		if (Job == 110) ChangeJob(111);
		else if (Job == 120) ChangeJob(121);
		else if (Job == 130) ChangeJob(131);
		
		AddSP(1);
		AddAP(5);
		
		if (Job == 111)
		{
			self.say("You have just become the #bCrusader#k. A number of new attacking skills such as #bShout#k and #bCombo Attack#k are devastating, while #bArmor Crash#k will put a dent on the monsters' defensive abilities. It'll be best to concentrate on acquiring skills with the weapon you mastered during the days as a Fighter.");
		}
		else if (Job == 121)
		{
			self.say("You have just become the #bWhite Knight#k. You'll be introduced to a new skill book featuring various new attacking skills as well as element-based attacks. It's recommended that the type of weapon complementary to the Page, whether it be a sword or a blunt weapon, should be continued as the White Knight. There's a skill called #bCharge#k, which adds an element of fire, ice, or lightning to the weapon, making White Knight the only warrior that can perform element-based attacks. Charge up your weapon with an element that weakens the monster, and then apply massive damage with the #bCharged Blow#k. This will definitely make you a devastating force around here.");
		}
		else if (Job == 131)
		{
			self.say("You're #bDragon Knight#k from here on out. You'll be introduced to a slew of new attacking skills for spears and pole arms, and whatever weapon was chosen as the Spearman should be continued as the Dragon Knight. Skills such as #bCrusher#k (maximum damage to one monster) and #bDragon Fury#k (damage to multiple monsters) are recommended as main attacking skills of choice, while a skill called #bDragon Roar#k will damage everything on screen with devastating force. The downside is the fact that the skill uses up over half of the available HP.");
		}
		
		self.say("I've also given you some SP and AP, which will help you get started. You have now become a powerful, powerful warrior, indeed. Remember, though, that the real world will be awaiting your arrival with even tougher obstacles to overcome. Once you feel like you cannot train yourself to reach a higher place, then, and only then, come see me. I'll be here waiting.");
	}
	
	private void JobQuest()
	{
		string questThird = GetQuestData(7500000);
			
		if (Level < 70)
		{
			self.say("You are not yet qualified to make the 3rd job advancement. You need to be at least level 70 for this. Train more and then come and see me.");
			return;
		}
		
		if (Job == 110 || Job == 120 || Job == 130)
		{
			if (questThird == "")
			{
				bool startQuest = AskYesNo("Welcome. I'm #bTylus#k, the chief of all warriors, in charge of bringing out the best in each and every warrior that needs my guidance. You seem like the kind of warrior that wants to make the leap forward, the one ready to take on the challenges of the 3rd job advancement. But I've seen countless warriors eager to make the jump just like you, only to see them fail. What about you? Are you ready to be tested and make the 3rd job advancement?");
				
				if (!startQuest)
				{
					self.say("I guess you're not ready to face the challenges ahead. Come and see me only when you're certain you're prepared for the advancement.");
					return;
				}
				
				SetQuestData(7500000, "s");
				self.say("Good. You will be tested on two important aspects of the warrior: strength and wisdom. I'll now explain to you the physical half of the test. Remember b#p1022000##k from Perion? Go see him, and he'll give you the details on the first half of the test. Please complete the mission, and get #b#t4031057##k from #p1022000#.");
				self.say("The mental half of the test can only start after you pass the physical part of the test. #b#t4031057##k will be the proof that you have indeed passed the test. I'll let #b#p1022000##k know in advance that you're making your way there, so get ready. It won't be easy, but I have the utmost faith in you. Good luck.");
			}
			else if (questThird == "s" || questThird == "p1")
			{
				self.say("You don't have #b#t4031057##k with you. Please go see #b#p1022000##k of Perion, pass the test, and bring #b#t4031057##k back with you. Only then will you be able to take the second test. Best of luck to you.");
			}
			else if (questThird == "p2")
			{
				if (ItemCount(4031057) < 1)
				{
					self.say("You don't have #b#t4031057##k with you. Please go see #b#p1022000##k of Perion, pass the test, and bring #b#t4031057##k back with you. Then, and only then, you will be given the second test. Good luck!");
					return;
				}
				
				self.say("Great job completing the physical part of the test. I knew you could do it. Now that you have passed the first half of the test, here's the second half. Please give me the necklace first.");
				
				if (!Exchange(0, 4031057, -1))
				{
					self.say("Are you sure you received #b#t4031057##k from #b#p1022000##k? Don't forget to leave a space in your Etc. inventory.");
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
					self.say("You don't have #b#t4031058##k with you. Find the dark, snow-covered area called the Holy Ground deep in the snowfields in Ossyria, offer a special item as the sacrifice and answer all of the questions with honesty and conviction to receive #b#t4031058##k.. Only then will you receive #b#t4031058##k. Bring it back to me to conclude the the test for the 3rd job advancement. Best of luck to you...");
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
		else if (Job == 111)
		{
			self.say("It's you who passed the tests to make the 3rd job advancement. How's the life of a #bCrusader#k? You must continue training as you journey through the world. Ossyria is full of powerful monsters that even I don't know about. If you have any questions, come to me at the end of your journey. Best of luck to you.");
		}
		else if (Job == 121)
		{
			self.say("It's you who passed the tests to make the 3rd job advancement. How's the life of a #bKnight#k? You must continue training as you journey through this place. Ossyria is full of powerful monsters that even I don't know about. If you have any questions, come to me at the end of your journey. Best of luck to you.");
		}
		else if (Job == 131)
		{
			self.say("It's you who passed the tests to make the 3rd job advancement. How's the life of a #bDragon Knight#k? You must continue training as you journey through this place. Ossyria is full of powerful monsters that even I don't know about. If you have any questions, come to me at the end of your journey. Best of luck to you.");
		}
		else
		{
			self.say("I'm #bTylus#k, the chief of all warriors, in charge of awakening the best in warriors who need my guidance. But you don't seem to be a warrior. Unfortunately, I can't help you. This room is full of chiefs of their respective classes. If you need anything, go talk with one of them.");
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
		
		if (Job < 100 || Job >= 200)
		{
			self.say("You want permission to do the quest of the Zakum Dungeon. I'm sorry but you don't look like a warrior. Go find the chief of your occupation.");
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
		
		AskMenuCallback("Can I help you?#b",
			(" I want to make the 3rd job advancement", Level >= 70, JobQuest),
			(" Please allow me to do the Zakum Dungeon Quest", Level >= 50, Zakum)
		);
	}
}