using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void RogueAction()
	{
		string qThirdJob = GetQuestData(7500000);
		
		if (Job == 411)
		{
			self.say("Ohhh... it's you. You must have passed the test and become a #bHermit#k! I knew you could do it! What do you think? I see someone who will one day become the BEST thief in the region...");
		}
		else if (Job == 421)
		{
			self.say("Ohhh... it's you. You must have passed the test and become a #bChief Bandit#k! I knew you could do it! What do you think? I see someone who will one day become the BEST thief in the region...");
		}
		else if (Job == 410 || Job == 420)
		{
			if (qThirdJob == "s")
			{
				SetQuestData(7500000, "p1");
				self.say("There you are. A few days ago, #bArec#k of Ossyria talked to me about you. I see that you are interested in making the leap to the dark world of the third job advancement for thieves. To achieve that goal, I will have to test your strength in order to see whether you are worthy of the advancement. There is an opening in the middle of a deep swamp in Victoria Island, where it'll lead you to a secret passage. Once inside, you'll face a clone of myself. Your task is to defeat him and bring #b#t4031059##k back with you.");
				self.say("Since he is a clone of myself, you can expect a tough battle ahead. He uses a number of special attacking skills unlike any you have ever seen, and it is your task to successfully take him one on one. There is a time limit in the secret passage, so it is crucial that you defeat him within the time limit. I wish you the best of luck, and I hope you bring the #b#t4031059##k with you.");
			}
			else if (qThirdJob == "p1")
			{
				if (ItemCount(4031059) < 1)
				{
					self.say("There is an opening in the middle of a deep swamp in Victoria Island , where it'll lead you to a secret passage. Inside, you'll face my clone. Your task is to defeat him and bring the #b#t4031059##k back with you.");
					return;
				}
				
				self.say("Nice work. You have defeated my clone and brought #b#t4031059##k back safely. You have now proven yourself worthy of the 3rd job advancement from the physical standpoint. Now you should give this necklace to #bArec#k in Ossyria to take on the second part of the test. Good luck. You'll need it.");
				
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
					self.say("Take #b#t4031057##k with you and go see #bArec#k of Ossyria. It's proof that you passed one of the two tests for the 3rd job advancement. I'm sure you'll easily pass the other test. Best of luck to you...");
					return;
				}
				
				self.say("Apparently, you lost #b#t4031057##k. Please be careful next time. Here's another one. Without this, you will not be able to take the test for the 3rd job advancement.");
				
				if (!Exchange(0, 4031057, 1))
				{
					self.say("Hmmm... something is wrong. Is your item inventory full? Make sure your Etc. inventory has an enough space.");
					return;
				}
			}
			else
			{
				if (Job == 410)
				{
					self.say("It's you. How is the life of an Assassin? Now I can feel the presence of an Assassin... Very good! Continue training!");
				}
				else if (Job == 420)
				{
					self.say("It's you. How is the life of a Bandit? Now I can feel the presence of a Bandit... Very good! Continue training!");
				}
			}
		}
		else if (Job == 400)
		{
			if (Level >= 30)
			{
				if (ItemCount(4031011) >= 1)
				{
					self.say("Haven't seen him yet, have you? Go find #b#p1072003##k around #b#m102040000##k near #m103000000#. Give him this letter and he'll tell you what to do.");
				}
				else if (ItemCount(4031012) >= 1)
				{
					self.say("Hmmm...so you got back here safely. I knew that test would be too easy for you. I admit, you are a great great thief. Now...I'll make you even more powerful than you already are. But, before all that...you need to choose one of two ways. It'll be a difficult decision for you to make, but...if you have any questions, please ask.");
					
					int chooseSecond1 = AskMenu("Alright, when you have made your decision, click on [I'll choose my occupation!] at the very bottom...#b",
						(0, " Please explain the characteristics of the Assassin."),
						(1, " Please explain the characteristics of the Bandit."),
						(2, " I'll choose my occupation!"));
						
					if (chooseSecond1 == 0)
					{
						self.say("Let me explain the role of the Assassin. The Assassin is a Thief that uses ninja stars or daggers. Skills like #b#q4100000##k and #b#q4100001##k will help you make better use of your ninja stars. Boost up #q4100000# even more and your maximum number of stars will increase. So, you better learn that skill. Remember this.");
						self.say("I'll explain one of the Assassin's skills, #b#q4101004##k. It temporarily improves jumping and movement speed for you and your party. Perfect for when you're walking to a distant place. Wouldn't it be great if getting to your destination didn't take an entire day?");
						self.say("And here's another skill available for the Assassin: #b#q4101005##k. It allows you to recover a portion of the damage done to an enemy and absorb it as HP! The greater the damage, the more health you wil recover...isn't it incredible? Remember that the maximum you will be able to absorb at once will be half of your maximum HP. The higher the enemy's HP, the more you will be able to absorb.");
					}
					else if (chooseSecond1 == 1)
					{
						self.say("This is what it's like to be a Bandit. Bandits are Thieves who specialize in using daggers. Skills like #b#q4200000##k and #b#q4201002##k will help you make better use of your dagger. For starters, daggers have a fast attack speed and if you add mastery to that...wow! It will be so fast that it will scare any monster!");
						self.say("I will explain to you what #b#q4201004##k does for Bandits. It offers you a chance to steal an item from the enemy. You can only steal one per enemy, but you can keep trying until you succeed. The stolen item will fall to the ground; don't forget to pick it up immediately since anyone can pick it up.");
						self.say("I will explain to you what #b#q4201005##k does for Bandits. Use HP and MP to attack the enemy 6 TIMES with the dagger. The higher the skill level, the more attacks can occur. You'll cut the enemy into pieces with the dagger...aaaah, isn't that cool? Do you want to become a Bandit and feel the rush of adrenaline?");
					}
					else if (chooseSecond1 == 2)
					{
						int chooseSecond2 = AskMenu("Ok...have you made your decision? Choose the job you want for the 2nd job advancement.#b",
							(0, " Assassin"),
							(1, " Bandit"));
							
						if (chooseSecond2 == 0)
						{
							bool askSecond = AskYesNo("So you want to make the 2nd job advancement as the #bAssassin#k? Once you have made your decision, you can't go back and change your mind. You ARE sure about this, right?");
							
							if (!askSecond)
							{
								self.say("Really? Need to think about it some more, right? Take your time, take your time. It's not something you should do right away... come and talk to me when you make your decision, alright?");
								return;
							}
							
							int nSP = (Level - 30) * 3;
							
							if (SP > nSP)
							{
								self.say("Hmmm... you have too much #bSP#k... you can't make the 2nd job advancement with that much SP in store. Use more SP on 1st level skills and come back later.");
								return;
							}
							
							if (!Exchange(0, 4031012, -1))
							{
								self.say("Hmm... Are you sure you have the #b#t4031012##k from #p1072003#? You better make sure. I cannot allow you to advance without it.");
								return;
							}
							
							ChangeJob(410); 
							AddSP(1);
							var incval1 = (short)Random(300, 351);
							var incval2 = (short)Random(150, 201);
							AddMaxHP(incval1);
							AddMaxMP(incval2);
							AddInventorySlots(2, 4);
							
							self.say("Alright, from here on out you are the #bAssassin#k#k. Assassins apreciam revel in shadows and darkness, waiting until the right time comes for them to stick a dagger through the enemy's heart, suddenly and swiftly...please keep training. I'll make you even more powerful than you are right now!");
							self.say("I have just given you a book that gives you the the list of skills you can acquire as a assassin. I have also added a whole row to your use inventory, along with boosting up your max HP and MP...go see for it yourself.");
							self.say("I have also given you a little bit of #bSP#k. Open the #bSkill Menu#k located at the bottom-left corner. You'll be able to boost up the newly-acquired 2nd level skills. A word of warning, though: You can't boost them up all at once. Some of the skills are only available after you have learned other skills. Make sure to remember that.");
							self.say("Assassins have to be strong. But remember that you can't abuse that power and use it on a weakling. Please use your enormous power the right way, because...for you to use that the right way, that is much harder than just getting stronger. Find me after you have advanced much further.");
						}
						else if (chooseSecond2 == 1)
						{
							bool askSecond = AskYesNo("So you want to make the 2nd job advancement as the #bBandit#k? Once you have made your decision, there's no turning back. You can't make the job advancement as anything else. You ARE sure about this, right?");
							
							if (!askSecond)
							{
								self.say("Really? Need to think about it some more, right? Take your time, take your time. It's not something you should do right away... come and talk to me when you make your decision, alright?");
								return;
							}
							
							int nSP = (Level - 30) * 3;
							
							if (SP > nSP)
							{
								self.say("Hmmm...you have too much #bSP#k... you can't make the 2nd job advancement with that much SP in store. Use more SP on 1st level skills and come back later.");
								return;
							}
							
							if (!Exchange(0, 4031012, -1))
							{
								self.say("Hmmm... are you sure you have the #b#t4031012##k from #p1072003#? You better make sure. I cannot allow you to advance without it.");
								return;
							}
							
							ChangeJob(420); 
							AddSP(1);
							var incval1 = (short)Random(300, 351);
							var incval2 = (short)Random(150, 201);
							AddMaxHP(incval1);
							AddMaxMP(incval2);
							AddInventorySlots(2, 4);
							
							
							self.say("Alright from here on out, you're the #bBandit#k. Bandits have quick hands and quicker feet to subdue enemies. Don't stop training. I'll make you even more powerful than you are right now!");
							self.say("I have just given you a book that gives you the the list of skills you can acquire as a Bandit. I have also added a whole row to your use inventory, along with boosting up your max HP and MP...go see for it yourself.");
							self.say("I have also given you a little bit of #bSP#k. Open the #bSkill Menu#k located at the bottom-left corner. You'll be able to boost up the newly-acquired 2nd level skills. A word of warning, though: You can't boost them up all at once. Some of the skills are only available after you have learned other skills. Make sure to remember that.");
							self.say("Bandits need to be strong... but remember that you can't abuse that power and use it on a weakling. Please use your enormous power the right way, because...for you to use that the right way, that is much harder than just getting stronger. Find me after you have advanced much further.");
						}
					}
				}
				else
				{
					bool questSecond = AskYesNo("Hmmm... you seem to have gotten a whole lot stronger. You got rid of the old, weak self and look much more like a thief now. Well, what do you think? Don't you want to get even more powerful than that? Pass a simple test and I'll do just that for you. Do you want to do it?");
					
					if (!questSecond)
					{
						self.say("Really...? Getting stronger quickly will help you a lot during your journey. Come and see me if you change your mind. I'll make you even more powerful than you are right now.");
						return;
					}
					
					self.say("Good thinking. But, I need to make sure you are as strong as you look. It's not a hard test, one that should be easy for you to pass. First, take this letter...make sure you don't lose it.");
					
					if (!Exchange(0, 4031011, 1))
					{
						self.say("Well... it looks like there's no space in your reserves for this letter. Free up space in your etc. inventory and come talk to me. You can only take the test with the letter.");
						return;
					}
					
					self.say("Please get this letter to #b#p1072003##k around #b#m102040000##k near #m103000000#. He's doing the job of an instructor in place of me. Give him the letter and he'll give you the test for me. If you want more details, hear it straight from him. I'll be wishing you good luck.");
				}
			}
			else
			{
				int askHelp = AskMenu("Do you want to know something about the Thief?#b",
					(0, " What are the basic characteristics of the Thief?"),
					(1, " What are the Thief's weapons?"),
					(2, " What are the Thief's armors?"),
					(3, " What are the skills available to the Thief?"));
					
				if (askHelp == 0)
				{
					self.say("Let me explain what it means to be a Thief. Thieves have just enough vigor and strength to survive. I don't recommend that you train your strength like the Warriors. You need LUK and DEX...");
					self.say("If you raise your luck and dexterity, the damage done to enemies will also increase. Thieves also differentiate themselves from other individuals by using throwing weapons like ninja stars and throwing knives. With their high dexterity, they also manage to avoid various attacks.");
				}
				else if (askHelp == 1)
				{
					self.say("Thieves use these weapons. They have just the right amount of intelligence and power... their strengths are their quick movement and quicker minds...");
					self.say("Therefore, we normally use daggers or throwing weapons. Daggers are basically small swords, but they are very fast, allowing them to do multiple attacks. If you are in hand-to-hand combat, use the dagger to eliminate the enemy quickly before he reacts to your attack.");
					self.say("For throwing weapons, ninja stars and throwing knives are available. But you won't be able to use them just like that. Go to the weapons shop in #m103000000# and they will sell a claw called #t1472000#. Equip it and you will be able to throw the ninja stars found in the Use inventory.");
					self.say("Choosing the right Claw is as important as selecting the appropriate type of ninja star. Want to know where to get those stars? Go check the armor shop near this city... there will probably be someone who specializes in them...");
				}
				else if (askHelp == 2)
				{
					self.say("Let me explain the armors Thieves wear. Thieves value speed, so you'll need clothes that fit you perfectly. But it doesn't need to be chainmail like Archers, as that won't help at all.");
					self.say("Instead of flashy clothes or stiff and sturdy golden plates, try to wear simple, comfortable clothes that fit you perfectly and fulfill your mission. It will help a lot when hunting the monsters.");
				}
				else if (askHelp == 3)
				{
					self.say("For Thieves, there are skills that support the high precision and dexterity that we have in general. There is a good variety of skills, for ninja stars and daggers. Choose your weapon carefully, as your skills will be determined by it.");
					self.say("If you're using ninja stars, skills like #b#q4000001##k or #b#q4001344##k are perfect. #q4001344# allows you to throw several ninja stars at once, so it will help you a lot when chasing enemies.");
					self.say("If using daggers, choose #b#q4001002##k or #b#q4001334##k as your skills. #q4001334#, will actually be a great skill to use, as it allows you to attack with an insane streak of blows, something that will definitely leave the enemy stunned.");
				}
			}
		}
		else if (Job == 0)
		{
			self.say("Want to be a Thief? You'll have to meet some requirements. We don't accept just ANYONE... #bYour level must be at least 10, with DEX greater than 25#k. Let's see...");
			
			if (Level < 10 || DEX < 25)
			{
				self.say("Hmm... you're just a apprentice... I don't think you can join us yet... get a lot stronger and THEN look for me...");
				return;
			}
			
			bool askFirst = AskYesNo("Oh...! You definitely look like someone who could be one of us... all you need is an evil mind and... yes, yes... so, what do you think? Want to be a Thief?");
			
			if (!askFirst)
			{
				self.say("I understand... well, choosing your class is a very important step. But don't you want to live a life that's more fun? Let me know when you make your decision, ok?");
				return;
			}
			
			self.say("Alright, from now on, you're one of us! You will live like a wanderer at first, but be patient and soon you'll be living the good life. Alright, it's not much but I'm going to give you some of my skills... HAAAAA!!");
			
			AddInventorySlots(1, 4);
			AddInventorySlots(4, 4);
			ChangeJob(400);
			var valh = (short)Random(100, 151);
			var valm = (short)Random(30, 51);
			AddMaxHP(valh);
			AddMaxMP(valm);
			AddSP(1);
			
			self.say("I have just created more slots in your equipment and etc. inventories. Additionally, you are much stronger now. By becoming one of us and learning to enjoy life in many ways, you will one day be on top of the world of darkness. I'll be watching your every move. Don't let me down.");
			self.say("I just gave you a little bit of #bSP#k. When you open the #bSkill menu#k on the lower left corner of the screen, there are skills you can learn by using SP's. One warning, though: You can't raise it all together all at once. There are also skills you can acquire only after having learned a couple of skills first.");
			self.say("One more warning. Once you have chosen your job, try to stay alive as much as you can. Once you reach that level, when you die, you will lose your experience level. You wouldn't want to lose your hard-earned experience points, do you?");
			self.say("OK! This is all I can teach you. Go places, train to become even better. Look for me when you think you've done everything you can and need something interesting. Then, and only then, will I give you even better experiences...");
			self.say("Oh, and... if you have any questions about being a Thief, feel free to ask. I don't know EVERYTHING, but I will help you with everything I know. Until then...");
		}
		else
		{
			self.say("Exploring is good, and getting stronger is good and all...but don't you want to enjoy living the life as you know it? How about becoming a Rogue like us and really LIVE the life? Sounds fun, isn't it?");
		}
	}
	
	private void RoguePath()
	{
		self.say("Did you make yourself come all the way down to this dingy hideout just to become a thief?");
		
		AddEXP(300);
		SetQuestData(1005303, "e");
		QuestEndEffect();
		self.say("Haha. See me only when you're ready to become a thief at heart. I have one rule of thumb about becoming a thief. Your level has be to at least at #r10#k.");
	}
	
	private void OldBook()
	{
		string qOldBook5 = GetQuestData(1001504);
		
		int mapCount = ItemCount(4031054);
		
		if (qOldBook5 == "f5")
		{
			if (mapCount < 3)
			{
				self.say("Hmm... are you missing a piece of the map?");
				return;
			}
			
			self.say("I heard about you through #b#p1012100##k from Henesys. We don't need to necessarily talk to each other to communicate; we communicate through our minds. You've worked hard to get here. But hey...you're looking for #b#t4031056##k? Of course I also happen to have the piece of the map that shows the book's whereabouts. I've forgotten about it for a while...");
			bool askStart = AskYesNo("But I can't just give you that. I also have been giving away a little bit of my power to all the thief-hopefuls for hundreds of years, but there have been a sudden rush of people wanting to be thieves, I've used up most of my power as a result. Get me #b2 #t4005003#s#k and I'll help you find #b#t4031056##k. What do you think? Do you want to do it?");
			
			if (!askStart)
			{
				self.say("Hmmm...but without my help you won't ever be able to find #b#t4031056##k...Anyway if you have a change of heart, feel free to come back.");
				return;
			}
			
			AddEXP(4000);
			SetQuestData(1001504, "f6");
			self.say("Good choice. #t4005003# is something you can acquire from the monsters on land. Of course it won't be easy to get them but still, I think you are capapble of doing it. I'll be waiting for you here. Best of luck to you!");
		}
		else if (qOldBook5 == "f6")
		{
			if (ItemCount(4005003) < 2)
			{
				self.say("You haven't gotten #b2 #t4005003#s#k yet. You'll find it from time to time through the monsters at land. Of course it won't be easy to get them, but still, I think you are capable of doing it. I'll be waiting for you here. Best of luck to you!");
				return;
			}
			
			self.say("I knew I could count on you. I had the utmost faith in you. This will help me recover my health. Like I promised, here's the item that may hold key to finding #b#t4031056##k. Before that, though, check and make sure your etc. inventory is available for storage.");
			
			if (!Exchange(0, 4005003, -2, 4031054, 1))
			{
				self.say("Please make some room in your etc. inventory, I have something very important to give you.");
				return;
			}
			
			AddEXP(8320);
			SetQuestData(1001504, "end");
			SetQuestData(1001500, "fe");
			QuestEndEffect();
			self.say("With this, you have collected all four pieces of the map. You won't be able to do anything with these in pieces, though. You mentioned Alcaster, right? Maybe he might know something about putting these together, so I think you should revisit him. Oh, and the #b#t4031053##k you have...take good care of it. It may hold the key to a very important matter.");
		}
		else if (qOldBook5 == "end" && ItemCount(4031054) < 4)
		{
			self.say("With this, you have collected all four pieces of the map. You won't be able to do anything with these in pieces, though. You mentioned Alcaster, right? Maybe he might know something about putting these together, so I think you should revisit him. Oh, and the #b#t4031053##k you have...take good care of it. It may hold the key to a very important matter.");
			
			int newItemCount = 4 - mapCount;
				
			if (!Exchange(0, 4031054, newItemCount))
			{
				self.say("Please make some room in your etc. inventory, I have something very important to give you.");
				return;
			}
		}
		else
		{
			self.say("The map that shows where #b#t4031056##k is hidden is cut up in four pieces, and was left to us 4 wisemen. It can't be hidden forever, anyway. Please find the book and seal it up for all of us. Now please take the map pieces back to the sorcerer in El Nath.");
		}
	}
	
	private void Event()
	{
		string quest = GetQuestData(9000500);
		
		if (quest == "")
		{
			self.say("Greetings... Of course I'm happy, but why don't you go talk to the Maple Administrator first?");
		}
		else if (quest == "s" || quest == "1" || quest == "2")
		{
			self.say("A New Year's greeting... How commendable! But first, you should visit #b#p1012100## of Henesys. It won't be too late to say hello to me after that. I'll be waiting for you to return.");
		}
		else if (quest == "3")
		{
			self.say("I see. You're saying you came to give me a New Year's greeting? I'm happy to see you...! I'm surprised there's young folk like you who care about us these days. This must be\r\n#b#p1012100##k's New Year's card. Here's some money. Alright... I'll give you a gift for visiting all of us. Go back to the #b#p9010000##k with this. Maybe something good will happen.");
			
			if (!ExchangeEx(800, "4031077", -1, "3993003,DateExpire:2021021800", 1))
			{
				self.say("Oh... I don't think there's enough room for my gift in your inventory. Please talk to me again after making at least one empty space in your set-up inventory.");
				return;
			}
			
			AddEXP(450);
			SetQuestData(9000500, "4");
		}
		else if (quest == "4" || (quest == "5" && ItemCount(3993003) < 1))
		{
			if (ItemCount(3993003) >= 1)
			{
				self.say("Thank you so much for coming all this way to give me your New Year's greeting. I'm surprised there's young folk like you who care about us these days. Now, go back to #b#p9010000##k with the gift I gave you. Maybe something good will happen.");
				return;
			}
			
			self.say("Hmm... you seem to have lost the gift I gave you. It's a precious item, so you can't throw it away~ I'll give you this special item again, so take this #t3993003# to #b#p9010000##k. I'm sure something good will happen.");
			
			if (!ExchangeEx(0, "3993003,DateExpire:2021021800", 1))
			{
				self.say("Oh... I don't think there's enough room for my gift in your inventory. Please talk to me again after making at least one empty space in your set-up inventory.");
			}
		}
		else if (quest == "e")
		{
			self.say("You're the young traveler who recently came to give me a New Year's greeting. It was very nice to see you, These days, there are lots of people coming to ask me for this and that, but not many people visit just to say hello like you. Stop by every now and then to tell me about your journey.");
		}
		else
		{
			self.say("You already gave me your New Year's greeting. Victoria Island has a few more wisemen besides me. Why don't you visit them all and say hello? Well then, please work hard~");
		}
	}
	
	private bool Check(int quest)
	{
		string info = GetQuestData(quest);
		
		string qOldBook1 = GetQuestData(1001500);
		
		if (quest == 1005303)	// The Path of Thief
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
		else if (quest == 1001504)	// The Four Wisemen of Victoria Island
		{
			if (info == "f5" || info == "f6" || (info == "end" && qOldBook1 == "fe"))
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
		bool cJobPath = Check(1005303);
		bool cOldBook = Check(1001504);
		bool cEvent = Check(9000500);
		
		if (cJobPath || cOldBook || cEvent)
		{
			AskMenuCallback("I'm #b#p1052001##k, the one doing various things for the thieves here in Kerning City. People are always looking for me, so I'm always busy. What did you need?#b",
				(" The Path of Thief", cJobPath, RoguePath),
				(" The Four Wisemen of Victoria Island", cOldBook, OldBook),
				(" I want to give you a New Year's Greeting", cEvent, Event),
				(" I'd like to know more about the thief", Level >= 1, RogueAction));
		}
		else
		{
			RogueAction();
		}
	}
}