using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void BowmanAction()
	{
		string qThirdJob = GetQuestData(7500000);
		
		if (Job == 311)
		{
			self.say("Ohhh... you must have passed all the tests to become a #bRanger#k! I knew you could do it. What do you think? It won't be much longer before you reach the top and become the best bowman in the region.");
		}
		else if (Job == 321)
		{
			self.say("Ohhh... you must have passed all the tests to become a #bSniper#k! I knew you could do it. What do you think? It won't be much longer before you reach the top and become the best bowman in the region.");
		}
		else if (Job == 310 || Job == 320)
		{
			if (qThirdJob == "s")
			{
				SetQuestData(7500000, "p1");
				self.say("Been waiting for you. A while ago, #bRene#k of Ossyria gave me a word on you. I see that you are interested in making the leap to the third job advancement. To do that, I will have to conduct a test of strength on you, in order to see whether you are worthy of the advancement. In the midst of a thick forest somewhere in the Victoria Island, you'll find a secret passage that'll lead you to a whole new dimension. Once inside, you'll face a clone of myself. Your task is to defeat her and bring #b#t4031059##k back with you.");
				self.say("Since she is a clone of myself, you can expect a tough battle ahead. She uses a number of special attacking skills unlike any you have ever seen, and it is your task to successfully take her down. There is a time limit in the secret passage, so it is crucial that you defeat her fast. I wish you the best of luck, and I hope you bring the #b#t4031059##k with you.");
			}
			else if (qThirdJob == "p1")
			{
				if (ItemCount(4031059) < 1)
				{
					self.say("In the middle of a dense forest somewhere on Victoria Island, you will find a secret passage that will take you to a new dimension. Inside, you'll face my clone. Your task is to defeat her and bring the #b#t4031059##k back with you.");
					return;
				}
				
				self.say("Great work there. You have defeated my clone and brought #b#t4031059##k back safely. I'm impressed. You have now passed the 1st half of the 3rd job advancement test. You should give this necklace to #bRene#k in Ossyria to take on the second part of the test. Take care. I'll be rooting for you.");
				
				if (!Exchange(0, 4031059, -1, 4031057, 1))
				{
					self.say("Are you sure you have #b#t4031059##k? If you're sure, check if you have an empty space available in your Etc. inventory.");
					return;
				}
				
				SetQuestData(7500000, "p2");
			}
			else if (qThirdJob == "p2")
			{
				if (ItemCount(4031057) >= 1)
				{
					self.say("Take #b#t4031057##k with you and go see #bRene#k of Ossyria. It is proof that you passed one of the two tests for the 3rd job advancement. I'm sure you'll pass the other test easily. Now, go forth!");
					return;
				}
				
				self.say("Apparently, you lost #b#t4031057##k. Please be careful next time. Here's another one. Without this, you won't be able to take the test for the 3rd job advance.");
				
				if (!Exchange(0, 4031057, 1))
				{
					self.say("Hmm... how strange. Is your item inventory full? Make sure your Etc. inventory has an enough space.");
					return;
				}
			}
			else
			{
				if (Job == 310)
				{
					self.say("Ohhh... It's you. What do you think? How is the life of a Hunter? You seem capable of handling explosive arrows with ease... continue training.");
				}
				else if (Job == 320)
				{
					self.say("Ohhh... it's you. What do you think? How is the life of a Crossbowman? Be careful with those iron arrows. You don't want to hurt innocent people with them.");
				}
			}
		}
		else if (Job == 300)
		{
			if (Level >= 30)
			{
				if (ItemCount(4031010) >= 1)
				{
					self.say("Haven't found her yet, have you? Find the #b#p1072002##k who's around #b#m106010000##k near #m100000000#. Give her the letter and she'll tell you what to do.");
				}
				else if (ItemCount(4031012) >= 1)
				{
					self.say("Haha... I knew you'd breeze through that test. I'll admit, you are a great bowman. I'll make you much stronger one than you're right now. Before that, however... you'll need to choose one of two paths given to you. It'll be a difficult decision for you to make, but... if there's any question to ask, please do so.");
					
					int chooseSecond1 = AskMenu("Alright, when you have made your decision, click on [I'll choose my occupation!] at the very bottom.#b",
						(0, " Please explain me all about the Hunter."),
						(1, " Please explain me everything about the Crossbowman."),
						(2, " I'll choose my occupation!"));
						
					if (chooseSecond1 == 0)
					{
						self.say("Ok. Here's what it's like to be a Hunter. Hunters have abilities like #q3100000# and #q3101002# that allow them to improve the use of bows. There is also a skill called #q3101004# for Hunters who use lots of arrows. It allows you to shoot arrows for a long period of time without actually using them up. So, if you've already spent a lot of mesos on arrows, this skill is perfect for you...");
						self.say("I'll explain to you one of the Hunter's skills, #b#q3101003##k. Nobody is better than a Hunter at long-range attacks, but it's a totally different story when there are multiple enemies or if you need to attack them up close. That's why this skill is very important. Not only does it allow you to attack the enemy up close, it also knocks several monsters away. It's a very important skill for you to acquire a little more space, a necessity in battle.");
						self.say("I will explain the Hunter's attack skill, #b#q3101005##k. It's a skill that allows you to shoot an arrow with a bomb. If it hits the target, the bomb will explode on top of the enemy, causing dmaage to those around it and stunning them temporarily. Combine this skill with #q3000001#, the first level skill, and the damage will be incredible. You should try becoming a Hunter.");
					}
					else if (chooseSecond1 == 1)
					{
						self.say("Ok. Here's what it's like to be a Crossbowman. For Crossbowmen, skills like #q3200000# and #q3201002# are available along with #q3201004# for those who use up their arrows shooting a lot and hitting infrequently. This skill allows the player to shoot arrows for a long period of time without using up arrows. So, if you've already spent a lot of mesos on arrows, you'll want to check this out...");
						self.say("Ok. One of the skills that a Crossbowman can learn is #b#q3101003##k. Nobody comes close to the Crossbowman's long-range attacks, but it's a totally different story when it comes to hand-to-hand combat or facing many enemies at one time. That's why this skill is very important. It allows you to attack with full force, sending several enemies away in the process. It's a very important skill that gives you a little more space, which is quite necessary.");
						self.say("Ok, I'll explain to you one of the attack skills for Crossbowman, #b#q3201005##k. This skill allows you to attack multiple enemies, the arrow will pierce through the monster and hit other monsters behind it. The damage will diminish each time it goes through an enemy, but it still hits several enemies at one time, a very threatening skill to have. And... if combined with #q3000001#... it'll be simply incredible.");
					}
					else if (chooseSecond1 == 2)
					{
						int chooseSecond2 = AskMenu("Now... have you made up your mind? Please choose the job you'd like to select for your 2nd job advancement.#b",
							(0, " Hunter"),
							(1, " Crossbowman"));
							
						if (chooseSecond2 == 0)
						{
							bool askSecond = AskYesNo("So you want to make the second job advancement as the #bHunter#k? You know you won't be able to choose a different job for the 2nd job advancement once you make your decision here, right?");
							
							if (!askSecond)
							{
								self.say("Really? Need to think about it some more, right? Take your time, take your time. It's not something you should do right away... come and talk to me when you make your decision, alright?");
								return;
							}
							
							int nSP = (Level - 30) * 3;
							
							if (SP > nSP)
							{
								self.say("Hmmm... you have too much #bSP#k... you can't make the 2nd job advancement with so much SP saved up. Use more SP on 1st level skills and come back later.");
								return;
							}
							
							if (!Exchange(0, 4031012, -1))
							{
								self.say("Hmm... Are you sure you have the #b#t4031012##k from #p1072002#? I can't allow you to make the advancement without it...");
								return;
							}
							
							ChangeJob(310); 
							AddSP(1);
							var incval1 = (short)Random(300, 351);
							var incval2 = (short)Random(150, 201);
							AddMaxHP(incval1);
							AddMaxMP(incval2);
							AddInventorySlots(4, 4);
							
							self.say("Alright, you're the #bHunter#k from now onwards. Hunters are the intelligent bunch with incredible vision, able to pierce the arrow through the heart of the monsters with ease... please train yourself each and everyday. We'll help you become even stronger than you already are.");
							self.say("I have just given you a book that gives you the list of skills you can acquire as a hunter. Also your etc. inventory has expanded by adding another row to it. Your max HP and MP have increased, too. Go check and see for it yourself.");
							self.say("I have also given you a little bit of #bSP#k. Open the #bSkill Menu#k located at the bottom left corner. You'll be able to boost up the newly-acquired 2nd level skills. A word of warning, though: You can't boost them up all at once. Some of the skills are only available after you have learned other skills. Make sure to remember that.");
							self.say("Hunters need to be strong. But remember that you can't abuse that power and use it on a weakling. Please use your enormous power the right way, because... for you to use that the right way, that is much harder than just getting stronger. Please find me after you have advanced much further. I'll be waiting for you.");
						}
						else if (chooseSecond2 == 1)
						{
							bool askSecond = AskYesNo("So you want to make the second job advancement as the #bCrossbowman#k? Once you make your decision, you cannot go back and choose a different job. Are you sure about this?");
							
							if (!askSecond)
							{
								self.say("Really? Need to think about it some more, right? No rush, no rush. It's not something you should do right away... come and talk to me when you make your decision, alright?");
								return;
							}
							
							int nSP = (Level - 30) * 3;
							
							if (SP > nSP)
							{
								self.say("Hmmm... you have too much #bSP#k... you can't make the 2nd job advancement with so much SP saved up. Use more SP on 1st level skills and come back later.");
								return;
							}
							
							if (!Exchange(0, 4031012, -1))
							{
								self.say("Hmmm... are you sure you have the #b#t4031012##k from #p1072002#k? You better check again. I can't allow you to make the advancement without it.");
								return;
							}
							
							ChangeJob(320); 
							AddSP(1);
							var incval1 = (short)Random(300, 351);
							var incval2 = (short)Random(150, 201);
							AddMaxHP(incval1);
							AddMaxMP(incval2);
							AddInventorySlots(4, 4);
							
							self.say("Very well. Now you are a #bCrossbowman#k. The Crossbowmen are intelligent individuals with incredible vision, able to pierce an arrow through the heart of monsters with ease... be sure to train everyday. I'll help you to become stronger than you already are.");
							self.say("I have just given you a book that gives you the list of skills you can acquire as a Crossbowman. Also your etc. inventory has expanded by adding another row to it. Your max HP and MP have also increased. Go check and see for it yourself.");
							self.say("I have also given you a little bit of #bSP#k. Open the #bSkill menu#k located at the bottomleft corner. You'll be able to boost up the newly-acquired 2nd level skills. A word of warning: You can't boost them up all at once. Some of them are only available after you have learned other skills. Don't forget it.");
							self.say("Crossbowmen have to be strong, but remember that you can't abuse that power and use it on a weakling. Please use your enormous power the right way, because... for you to use that the right way, that is much harder than just getting stronger. Find me after you have advanced much further. I'll be waiting for you.");
						}
					}
				}
				else
				{
					bool questSecond = AskYesNo("Hmmm... you have grown a lot since I last saw you. I don't see the weakling I saw before, and instead, look much more like a bowman now. Well, what do you think? Don't you want to get even more powerful than that? Pass a simple test and I'll do just that for you. Do you want to do it?");
					
					if (!questSecond)
					{
						self.say("Really? Need to think about it some more, right? No rush, no rush. It's not something you should do right away... come and talk to me when you make your decision, alright?");
						return;
					}
					
					self.say("Good decision. You look strong, but I need to see if you really are strong enough to pass the test. It's not a difficult test, so you'll do just fine. Here, take my letter first... make sure you don't lose it!");
					
					if (!Exchange(0, 4031010, 1))
					{
						self.say("Hmmm... your inventory seems full... free up space in your Etc. inventory and talk to me. Without the letter, you won't be able to take the test.");
						return;
					}
					
					self.say("Please get this letter to #b#p1072002##k who's around #b#m106010000##k near #m100000000#. She's taking care of the job of an instructor in place of me. Give her the letter and she'll test you in place of me. Best of luck to you.");
				}
			}
			else
			{
				int askHelp = AskMenu("Do you have some questions about the life of the Bowman?#b",
					(0, " What are the basic characteristics of a Bowman?"),
					(1, " What are the weapons used by Bowmen?"),
					(2, " What kind of armor do Bowmen wear?"),
					(3, " What are the abilities of a Bowman?"));
					
				if (askHelp == 0)
				{
					self.say("This is what it means to be a Bowman. The Bowman has a good amount of vigor and strength. Your most important ability is DEX. You don't have much stamina, so avoid hand-to-hand combat if possible.");
					self.say("The main advantage is that you can attack from a distance, avoiding the hand to hand combat up close with monsters. Additionally, with your high amount dexterity, you will also be able to avoid many incoming attacks. The higher the DEX, the more damage you can inflict.");
				}
				else if (askHelp == 1)
				{
					self.say("Let me explain to you the weapons of a Bowman. Instead of using melee weapons to attack or slash their opponentsm they use long range weapons like bows and crossbows to kill monsters. Both have their advantages and disadvantages.");
					self.say("Bows aren't as powerful as crossbows, but they are much faster when attacking. Crossbows, in turn, are more powerful but slower. It'll be hard to make a decision...");
					self.say("You will get arrows for bows and crossbows from monsters, so it's important that you hunt them frequently. But it won't be easy. Be sure to train everyday and success will come to you...");
				}
				else if (askHelp == 2)
				{
					self.say("I'll explain to you the Bowman's armor. You'll need to move swiftly, so it won't be good to wear armor that's heavy and complex. Garbs with long uncomfortable laces are out of the question.");
					self.say("If you use the huge and resistant armor of a Warrior, you'll soon find you're surrounded by enemies. Equip yourself with a simple and comfortable armor that fits you perfectly and fulfills its function. It'll help you a lot when you're hunting monsters.");
				}
				else if (askHelp == 3)
				{
					self.say("The skills available to Bowmen utilize their high precision and dexterity. It's essential that Bowmen acquire skills that allow them to attack enemies with precision.");
					self.say("There are two types of attacking skills for bowmen: #b#q3001004##k and #b#q3001005##k. #q3001004# is a good and simple skill that allows you to deal high damage to the enemy without using too much MP.");
					self.say("On the other hand, #q3001005# allows you to attack the enemy twice using a considerable amount of MP. You can acquire this skill only after putting at least 1 point into #q3001004#. Don't forget it. Whichever you choose, become an expert in that skill.");
				}
			}
		}
		else if (Job == 0)
		{
			self.say("So you want to become a Bowman??? Well... you need to meet some requirements in order to do so... at least #bLevel 10 and 25 DEX#k. Let's see... hmm...");
			
			if (Level < 10 || DEX < 25)
			{
				self.say("You need to train more. Don't think that being a bowman is easy...");
				return;
			}
			
			bool askFirst = AskYesNo("You are qualified. You have a great pair of eyes for identifying the real monsters and the skills needed to pierce them with an arrow... we could use someone like that. Do you want to become the Bowman?");
			
			if (!askFirst)
			{
				self.say("Really? Need to think about it some more, right? Take your time, take your time. It's not something you should do right away... come and talk to me when you make your decision, alright?");
				return;
			}
			
			self.say("Alright! You will be a Bowman now because I said so... haha. Here is some of my power for you... Hahh!");
			
			AddInventorySlots(1, 4);
			AddInventorySlots(2, 4);
			ChangeJob(300);
			var valh = (short)Random(100, 151);
			var valm = (short)Random(30, 51);
			AddMaxHP(valh);
			AddMaxMP(valm);
			AddSP(1);
			
			self.say("I have added slots to your equipment and etc. inventories. You have also become much stronger. Train hard and one day you may achieve the height of the bowman's skill. I'll be watching you from here. Work hard.");
			self.say("I just gave you a little bit of #bSP#k. When you open the #bskill menu#k in the lower left corner of the screen, you will see the skills you can learn using SP's. A warning: You can't raise it all together all at once. There are also skills you can acquire only after having learned some skills first.");
			self.say("One more warning. Once you have chosen your job, try to stay alive as much as you can. Once you reach that level, when you die, you will lose your experience level. You wouldn't want to lose your hard-earned experience points, do you?");
			self.say("OK! This is all I can teach you. Go places, train and become even better. Look for me when you think you've done everything you can and need something interesting. I'll be waiting for you.");
			self.say("Oh, and... if you have any questions about being a Bowman, feel free to ask. I don't know everything there is to know, but I will answer what I can. Until then...");
		}
		else
		{
			self.say("Don't you want to feel the excitement of hunting down the monsters from out of nowhere? Only the Bowman can do that...");
		}
	}
	
	private void BowmanPath()
	{
		self.say("Are you here to become a bowman?");
		
		AddEXP(300);
		SetQuestData(1005302, "e");
		QuestEndEffect();
		self.say("Please talk to me when you're ready to become a bowman. To qualify as one, you'll need to be at least at #blevel 10#k. Press S to look at your character stats.");
	}
	
	private void OldBook()
	{
		string qOldBook5 = GetQuestData(1001504);
		
		int mapCount = ItemCount(4031054);
		
		if (qOldBook5 == "f3")
		{
			if (mapCount < 2)
			{
				self.say("Hmm... are you missing a piece of the map?");
				return;
			}
			
			self.say("I've heard about you before through #b#p1032001##k from Ellinia. We don't need to necessarily talk to each other to communicate; we communicate through our minds. You've worked hard to get here. But hey...you're looking for #b#t4031056##k? Of course I also happen to have the piece of the map that shows the book's whereabouts. I've forgotten about it for a while...");
			bool askStart = AskYesNo("But I can't just give you that. I also have been giving away a little bit of my power to all the bowman-hopefuls for hundreds of years, but there have been a sudden rush of people wanting to be the bowman, I've used up most of my power as a result. Get me #b2 #t4005002#s#k and I'll help you find #b#t4031056##k. What do you think? Do you want to do it?");
			
			if (!askStart)
			{
				self.say("Hmmm...but without my help you won't be able to find #b#t4031056##k, ever ... anyway if you have a change of heart, please feel free to come back.");
				return;
			}
			
			AddEXP(4000);
			SetQuestData(1001504, "f4");
			self.say("Good choice. #t4005002# is something you can acquire from the monsters on land. Of course it won't be easy to get them but still, I think you are capapble of doing it. I'll be waiting for you here. Best of luck to you!");
		}
		else if (qOldBook5 == "f4")
		{
			if (ItemCount(4005002) < 2)
			{
				self.say("I don't think you have collected #b2 #t4005002#s#k yet. They can be found through monsters on this land from time to time. It's a challenging task, I know, but I have the utmost faith in you. Best of luck to you.");
				return;
			}
			
			self.say("I knew I could count on you. I had no doubt you could do it. This will help me recover my health. Like I promised, here's the item that may hold key to finding #b#t4031056##k. Before that, though, check and make sure your etc. inventory isn't full so you can store something inside.");
			
			if (!Exchange(0, 4005002, -2, 4031054, 1))
			{
				self.say("Please make some room in your etc. inventory, I have something very important to give you.");
				return;
			}
			
			AddEXP(8320);
			SetQuestData(1001504, "f5");
			self.say("This is the 3rd piece of the map that shows where #b#t4031056##k is hidden. The map has been cut to four pieces and was handed to us 4 wisemen. It cannot stay hidden forever, though...please find that book and seal it up tightly for all of us. Ok, for the final piece of the map, please find the #bWiseman from Kerning City#k. I'll let him know of what's going on.");
		}
		else if (qOldBook5 == "f5" && ItemCount(4031054) < 3)
		{
			self.say("This is the 3rd piece of the map that shows where #b#t4031056##k is hidden. The map has been cut to four pieces and was handed to us 4 wisemen. It cannot stay hidden forever, though...please find that book and seal it up tightly for all of us. Ok, for the final piece of the map, please find the #bWiseman from Kerning City#k. I'll let him know of what's going on.");
			
			int newItemCount = 3 - mapCount;
				
			if (!Exchange(0, 4031054, newItemCount))
			{
				self.say("Please make some room in your etc. inventory, I have something very important to give you.");
				return;
			}
		}
		else
		{
			self.say("The map that shows where #b#t4031056##k is hidden is cut up in 4 pieces, and taken care of by us 4 wisemen. It cannot stay hidden forever, though...please find that book and seal it up tightly for all of us. Ok, for the final piece, please find #bthe Wiseman from Kerning City#k. I've let him know of what's going on.");
		}
	}
	
	private void Event()
	{
		string quest = GetQuestData(9000500);
		
		if (quest == "")
		{
			self.say("Greetings... Of course I'm happy, but why don't you go talk to the Maple Administrator first?");
		}
		else if (quest == "s" || quest == "1")
		{
			self.say("A New Year's greeting... That's so nice to hear...! But first, you should visit #b#p1032001##k of Ellinia. It won't be too late to say hello to me after that. I'll be waiting for you to return.");
		}
		else if (quest == "2")
		{
			self.say("I see... You're saying you came to give me a New Year's greeting? I'm glad to see you...! I was surprised that there are people like you who think of us these days. This must be a New Year's card from #b#p1032001##k. Here's some allowance for you. Alright... then please take this and find #b#p1052001##k of Kerning City. I haven't heard from him in some time. If you visit, he'll probably be very happy.");
			
			if (!ExchangeEx(800, "4031076", -1, "4031077,DateExpire:2021021800", 1))
			{
				self.say("Oh... I don't think you have room for my New Year's card in your inventory. Please talk to me again after making at least one empty space in your etc. inventory.");
				return;
			}
			
			AddEXP(450);
			SetQuestData(9000500, "3");
		}
		else if (quest == "3")
		{
			if (ItemCount(4031077) >= 1)
			{
				self.say("Thank you so much for coming all this way to give me your New Year's greeting. I'm surprised that there are people like you who thinks of us these days. Now, please visit #b#p1052001##k of Kerning City and deliver the New Year's card I gave you. He'll probably be very happy.");
				return;
			}
			
			self.say("Hmm... you seem to have lost the New Year's card I gave you. I worked hard on that card, you can't throw it away~ I'll make another one, so please send this New Year's card to #b#p1052001##k of Kerning City and give him your New Year's greeting. He'll probably be happy to see you.");
			
			if (!ExchangeEx(0, "4031077,DateExpire:2021021800", 1))
			{
				self.say("Oh... I don't think you have room for my New Year's card in your inventory. Please talk to me again after making at least one empty space in your etc. inventory.");
				return;
			}
		}
		else if (quest == "e")
		{
			self.say("You're the one who came to say hello to me for New Year's. It was very nice to see you. These days, there are lots of people coming to ask me for this and that, but not many people visit just to say hello like you. I hope you can stop by every now and then to tell me about your journey.");
		}
		else
		{
			self.say("You already gave me a New Year's greeting. There are a few more wisemen on Victoria Island besides me. Why don't you visit them all and say hello? Well then, please work hard~");
		}
	}
	
	private bool Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1005302)
		{
			if (info == "s")
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (quest == 1001504)
		{
			if (info == "f3" || info == "f4" || info == "f5")
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (quest == 9000500)
		{
			DateTime today = DateTime.UtcNow;
			
			DateTime start = DateTime.Parse("2021-02-13");
			DateTime end = DateTime.Parse("2021-02-18");
			
			if (today > start && today < end)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		return false;
	}
	
	public override void Run()
	{
		bool cJobPath = Check(1005302);
		bool cOldBook = Check(1001504);
		bool cEvent = Check(9000500);
	
		if (cJobPath || cOldBook || cEvent)
		{
			AskMenuCallback("My name is #b#p1012100##k, who watches over the bowmen here in Henesys. There are many who need my strength, so I am always busy. But, is there anything you need?#b",
				(" The Path of Bowman", cJobPath, BowmanPath),
				(" The Four Wisemen of Victoria Island", cOldBook, OldBook),
				(" I want to give you a New Year's Greeting", cEvent, Event),
				(" I'd like to know more about the bowman", Level >= 1, BowmanAction));
		}
		else
		{
			BowmanAction();
		}
	}
}