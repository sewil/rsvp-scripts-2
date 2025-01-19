using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void FighterAction()
	{
		string qThirdJob = GetQuestData(7500000);
		
		if (Job == 111)
		{
			self.say("Ohhh... You finally became a #bCrusader#k... I knew you wouldn't let me down. So how is the life of a Crusader? Remember to continue training hard.");
		}
		else if (Job == 121)
		{
			self.say("Ohhh... You finally became a #bKnight#k... I knew you wouldn't let me down. So how is the life of a Knight? Please remember to continue your training.");
		}
		else if (Job == 131)
		{
			self.say("Ohhh... You finally became a #bDragon Knight#k... I knew you wouldn't let me down. So how is the life of a Dragon Knight? Please remember to continue your training.");
		}
		else if (Job == 110 || Job == 120 || Job == 130)
		{
			if (qThirdJob == "s")
			{
				SetQuestData(7500000, "p1");
				self.say("I was waiting for you. Few days ago, I heard about you from #bTylus#k in Ossyria. Well... I'd like to test your strength. There is a secret passage near the ant tunnel. Nobody but you can go into that passage. If you go into the passage, you will meet my the other self. Beat him and bring #b#t4031059##k to me.");
				self.say("My the other self is quite strong. He uses many special skills and you should fight with him 1 on 1. However, people cannot stay long in the secret passage, so it is important to beat him ASAP. Well... Good luck! I will look forward to you bringing #b#t4031059##k to me.");
			}
			else if (qThirdJob == "p1")
			{
				if (ItemCount(4031059) < 1)
				{
					self.say("There is a secret passage near the ant tunnel. Nobody but you can go into that passage. If you go into the passage, you will meet my the other self. Beat him and bring #b#t4031059##k to me.");
					return;
				}
				
				self.say("Wow... You beat my the other self and brought #b#t4031059##k to me. Good! This surely proves your strength. In terms of strength, you are ready to advance to 3rd job. As I promised, I will give #b#t4031057##k to you. Give this necklace to #bTylus#k in Ossyria and you will be able to take second test of 3rd job advancement. Good luck~.");
				
				if (!Exchange(0, 4031059, -1, 4031057, 1))
				{
					self.say("Hmm... how strange. Are you sure you have #b#t4031059##k? If so, make sure you have an empty slot in your etc. inventory.");
					return;
				}
				
				SetQuestData(7500000, "p2");
			}
			else if (qThirdJob == "p2")
			{
				if (ItemCount(4031057) >= 1)
				{
					self.say("Please give the necklace to #bTylus#k of Ossyria so you can take the second test for the 3rd job advancement. Good luck~!");
					return;
				}
				
				self.say("Ohh! You lost the #b#t4031057##k, huh? I told you to be careful with that... For God's sake, I will give you one... AGAIN. Please be careful this time. Without this, you will not be able to make the 3rd job advancement.");
				
				if (!Exchange(0, 4031057, 1))
				{
					self.say("Hmm... how strange. Make sure you have an empty slot in your etc. inventory.");
				}
			}
			else
			{
				if (Job == 110)
				{
					self.say("Ohhh! It's you! What do you think? How is the life of a Fighter treating you? You... look a lot stronger than before! I hope you continue to improve.");
				}
				else if (Job == 120)
				{
					self.say("Ohhh... it's you! What do you think? How is the life of a Page? I know you are still an apprentice, but soon the training will be over and you will be called a knight!");
				}
				else if (Job == 130)
				{
					self.say("Ohhh... it's you! What do you think? How is life as a Spearman? Continue training hard, because one day you will become a powerful dragon knight...");
				}
			}
		}
		else if (Job == 100)
		{
			if (Level >= 30)
			{
				if (ItemCount(4031008) >= 1)
				{
					self.say("Haven't found him yet? Find the #b#p1072000##k that's around #b#m102020300##k near #m102000000#. Give him the letter and maybe he'll tell you what you need to do.");
				}
				else if (ItemCount(4031012) >= 1)
				{
					self.say("OHH... you came back safe! I knew you'd breeze through... I'll admit you are a strong, formidable Warrior... alright. I'll make you an even stronger Warrior than you already are right now... Before THAT! you need to choose one of the three paths that you'll be given... It isn't going to be easy, so if you have any questions, feel free to ask.");
					
					int chooseSecond1 = AskMenu("Alright, when you have made your decision, click on [I'll choose my occupation!] at the very bottom.#b",
						(0, " Please explain the role of the Fighter."),
						(1, " Please explain the role of the Page."),
						(2, " Please explain the role of the Spearman."),
						(3, " I'll choose my occupation!"));
						
					if (chooseSecond1 == 0)
					{
						self.say("Let me explain the role of the Fighter. It's the most common kind of Warriors. The weapons they use are #bsword#k and #baxe#k, because there will be advanced skills available to acquire later on, I strongly recommend you avoid using both weapons, but rather stick to one to your liking...");
						self.say("Other than that, there are also skills such as #b#q1101006##k and #b#q1101007##k available for fighters. #b#q1101006##k is the kind of an ability that allows you and your party to temporarily enhance your weapon power. With that you can take out the enemies with a sudden surge of power, so it'll come very handy for you. The downside to this is that your guarding ability (defense) goes down a bit.");
						self.say("#b#q1101007##k is an ability that enables you to return a portion of the damage that you take from a weapon hit by an enemy. The harder the hit, the harder the damage they'll get in return. It'll help those that prefer close combat. What do you think? Isn't being the Fighter pretty cool?");
					}
					else if (chooseSecond1 == 1)
					{
						self.say("Let me explain the role of the Page. Page is a knight-in-training, taking its first steps towards becoming an actual knight. They usually use #bswords#k and/or #bblunt weapons#k. It's not wise to use both weapons so it'll be best for you to stick to one or the other.");
						self.say("Other than that, there are also skills such as #b#q1201006##k and #b#q1101007##k to learn. #b#q1201006##k makes every opponent around you lose some attacking and defending abilities for a time being. It's very useful against powerful monsters with good attacking abilities. It also works well in party play.");
						self.say("#b#q1101007##k is a skill where, for a short time, you can return a certain amount of damage you may receive from the monsters. The more the damage, the more the damage you return. It's a skill perfect for Warriors specializing in close combats. What do you think? Isn't being the Page pretty cool?");
					}
					else if (chooseSecond1 == 2)
					{
						self.say("Let me explain the role of the Spearman. It's a job that specializes in using long weapons such as #bspears#k and #bpolearms#k. There are lots of useful skills to acquire with both of the weapons, but I strongly recommend that you stick to one and focus on it.");
						self.say("Other than that, there are also skills such as #b#q1301006##k and #b#q1301007##k to learn. #b#q1301006##k allows you and the members of your party to increase attack and magic defense for a period of time. It's the skill that's very useful for Spearmen with weapons that require both hands and can't guard themselves as well.");
						self.say("#b#q1301007##k is a skill that allows you and your party to temporarily improve the max HP and MP. You can improve almost 160% so it'll help you and your party especially when going up against really tough opponents. What do you think? Don't you think being the Spearman can be pretty cool?");
					}
					else if (chooseSecond1 == 3)
					{
						int chooseSecond2 = AskMenu("Hmmm, have you made up your mind? Choose the 2nd job advancement of your liking.#b",
							(0, " Fighter"),
							(1, " Page"),
							(2, " Spearman"));
							
						if (chooseSecond2 == 0)
						{
							bool askSecond = AskYesNo("So you want to make the 2nd job advancement as the #bFighter#k? Once you make that decision, you can't go back and choose another job... do you still want to do it?");
							
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
								self.say("Hmmm... are you sure you have the #b#t4031012##k from #p1072000#k? You better check again. I can't allow you to make the advancement without it.");
								return;
							}
							
							ChangeJob(110); 
							AddSP(1);
							var nHP = (short)Random(300, 351);
							AddMaxHP(nHP);
							AddInventorySlots(2, 4);
							AddInventorySlots(4, 4);
							
							self.say("Alright! You have now become the #bFighter#k! A fighter strives to become the strongest of the strong, and never stops fighting. Don't ever lose that will to fight, and push forward 24/7. I'll help you become even stronger than you already are.");
							self.say("I have just given you a book that gives you the list of skills you can acquire as the Fighter. In that book you'll find a bunch of skills the Fighter can learn. Your use and etc. inventories have also been expanded with an additional row of slots now available. Your max MP has also increased, go check and see for it yourself.");
							self.say("I have also given you a little bit of #bSP#k. Open the #bSkill Menu#k located at the bottomleft corner. You'll be able to boost up the newly-acquired 2nd level skills. A word of warning, though. You can't boost them up all at once. Some of the skills are only available after you have learned other skills. Make sure to remember that.");
							self.say("Fighters have to be strong. But remember that you can't abuse that power and use it on a weakling. Please use your enormous power the right way, because... for you to use that the right way, that is much harder than just getting stronger. Find me after you have advanced much further.");
						}
						else if (chooseSecond2 == 1)
						{
							bool askSecond = AskYesNo("So you want to make the 2nd job advancement as the #bPage#k? Once you make that decision, you can't go back and choose another job... do you still want to do it?");
							
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
								self.say("Hmmm... are you sure you have the #b#t4031012##k from #p1072000#k? You better check again. I can't allow you to make the advancement without it.");
								return;
							}
							
							ChangeJob(120); 
							AddSP(1);
							var nMP = (short)Random(100, 151);
							AddMaxMP(nMP);
							AddInventorySlots(2, 4);
							AddInventorySlots(4, 4);
							
							self.say("Alright! You have now become the #bPage#k! A Page fights tactically, and uses special skills to strike each and every monster's weak spot! Always know your enemy's weakness, or else you will be weak!");
							self.say("I have just given you a book that gives you the list of skills you can acquire as the Page. In that book you'll find a bunch of skills the Page can learn. Your use and etc. inventories have also been expanded with additional row of slots now available. Your max MP has also increased... go check and see for it yourself.");
							self.say("I have also given you a little bit of #bSP#k. Open the #bSkill Menu#k located at the bottomleft corner. You'll be able to boost up the newly-acquired 2nd level skills. A word of warning, though. You can't boost them up all at once. Some of the skills are only available after you have learned other skills. Make sure to remember that.");
							self.say("The Page has to be strong. But remember that you can't abuse that power and use it on a weakling. Please use your enormous power the right way, because... for you to use that the right way, that is much harder than just getting stronger. Find me after you have advanced much further.");
						}
						else if (chooseSecond2 == 2)
						{
							bool askSecond = AskYesNo("So you want to make the 2nd job advancement as the #bSpearman#k? Once you make the decision, you won't be able to make a job advancement with any other job. Are you sure about this?");
							
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
								self.say("Hmmm... are you sure you have the #b#t4031012##k from #p1072000#k? You better check again. I can't allow you to make the advancement without it.");
								return;
							}
							
							ChangeJob(130); 
							AddSP(1);
							var nMP = (short)Random(100, 151);
							AddMaxMP(nMP);
							AddInventorySlots(2, 4);
							AddInventorySlots(4, 4);
							
							self.say("Alright! You have now become the #bSpearman#k! The Spearman use the power of darkness to take out the enemies, always in the shadows... please believe in yourself and your awesome power as you go on in your journey... I'll help you become much stronger than you are right now.");
							self.say("I have just given you a book that gives you the list of skills you can acquire as the Spearman. In that book you'll find a bunch of skills the Spearman can learn. Your use and etc. inventories have also been expanded with additional row of slots now available. Your max MP has also increased... go check and see for it yourself.");
							self.say("I have also given you a little bit of #bSP#k. Open the #bSkill Menu#k located at the bottomleft corner. You'll be able to boost up the newly-acquired 2nd level skills. A word of warning, though: You can't boost them up all at once. Some of the skills are only available after you have learned other skills. Make sure to remember that.");
							self.say("Spearman needs to be strong. But remember that you can't abuse that power and use it on a weakling. Please use your enormous power the right way, because... for you to use that the right way, that is much harder than just getting stronger. Find me after you have advanced much further. I'll be waiting for you.");
						}
					}
				}
				else
				{
					bool questSecond = AskYesNo("Whoa, you have definitely grown up! You don't look small and weak anymore... rather, now I can feel your presence as the Warrior! Impressive... so, what do you think? Do you want to get even stronger than you are right now? Pass a simple test and I'll do just that! Wanna do it?");
					
					if (!questSecond)
					{
						self.say("Really? Getting stronger quickly will help you a lot during your journey... if you change your mind in the future, you can return here whenever you want. Remember that I can make you much more powerful than you are now.");
						return;
					}
					
					self.say("Good thinking. You look strong, don't get me wrong, but there's still a need to test your strength and see if you are for real. The test isn't too difficult, so you'll do just fine... Here, take this letter first. Make sure you don't lose it.");
					
					if (!Exchange(0, 4031008, 1))
					{
						self.say("Hmmm... I can't give you my letter because you don't have any room on your etc. inventory. Please come back after you have made a space or two on your inventory, because the letter is the only way you can take the test.");
						return;
					}
					
					self.say("Please get this letter to #b#p1072000##k who may be around #b#m102020300##k that's near #m102000000#. He's the one being the instructor now in place of me, as I am busy here. Get him the letter and he'll give you the test in place of me. For more details, hear it straight from him. Best of luck to you.");
				}
			}
			else
			{
				int askHelp = AskMenu("Oh, do you have some questions?#b",
					(0, " What is the role of the Warrior?"),
					(1, " What kind of weapons do Warriors use?"),
					(2, " What kind of armor do Warriors wear?"),
					(3, " What skills can the Warrior use?"));
					
				if (askHelp == 0)
				{
					self.say("Let me explain the role of the Warrior. Warriors have amazing physical strength. They also know how to defend themselves from monsters, so they are best for fighting in close combat. With lots of health and guarding abilities, you will not die easily.");
					self.say("However, to attack the monster accurately, you'll also need a good amount of DEX, so don't only focus on your STR. If you want to improve quickly, I recommend fighting powerful monsters.");
				}
				else if (askHelp == 1)
				{
					self.say("Let me explain the weapons a Warrior can use. You can wield weapons that can cut, stab and slash. You won't be able to use weapons like bows and other projectile weapons. Not to mention wands or staffs.");
					self.say("The most common weapons are swords, maces, spears, polearms, axes, etc... Every weapon has its advantages and disadvantages, so examine them well before deciding which of them you want to use. For now, try using one with a high level of attack.");
				}
				else if (askHelp == 2)
				{
					self.say("Let me explain the armor a Warrior can wear. Warriors are strong and have a lot of stamina, so they can wear heavy and sturdy armor. They might not be very fashionable... but they serve their purpose well: to be the best defensive armor.");
					self.say("Shields especially are perfect for Warriors. Remember, though, you can't use a shield if you are wielding a two-handed weapon. I know it will be a difficult decision.");
				}
				else if (askHelp == 3)
				{
					self.say("The skills available to Warriors complement their amazing physical power. Ones that will improve your strength in close combat will help you the most. There is also a skill that let's you recover HP more quickly. You should try to master it.");
					self.say("The two attack skills available to you are #b#q1001004##k and #b#q1001005##k. #q1001004# deals enormous damage to a single enemy. You can start using this skill right away.");
					self.say("#q1001005# on the other hand doesn't deal as much damage, but can be used to hit multiple enemies at once. You can only use it after boosting the level of #q1001004# to one. It's your decision.");
				}
			}
		}
		else if (Job == 0)
		{
			self.say("Do you wish to become a Warrior? You need to meet some criteria in order to do so. #bYou should be at least in level 10, with at least 35 in STR#k. Let's see...");
			
			if (Level < 10 || STR < 35)
			{
				self.say("I don't think you have what it takes to be a Warrior just yet. You have to train hard or you won't be able to handle the challenges ahead. Come back when you are stronger.");
				return;
			}
			
			bool askFirst = AskYesNo("You definitely have the look of a Warrior. You have a long way to go but I can already see a strong Warrior in you. What do you think? Do you want to become a Warrior?");
			
			if (!askFirst)
			{
				self.say("Really? Need more time to think about it? Take your time... This should not be taken lightly. Come talk to me again when you have made your decision.");
				return;
			}
			
			self.say("From here on out, you are going to be the Warrior! Don't give up... Go and improve your skills, I hope you will continue training to become even stronger than you already are! \r\nHahh!!");
			
			ChangeJob(100);
			var nHP = (short)Random(200, 251);
			AddMaxHP(nHP);
			AddSP(1);
			AddInventorySlots(1, 4);
			AddInventorySlots(2, 4);
			AddInventorySlots(3, 4);
			AddInventorySlots(4, 4);
			
			self.say("You've gotten much stronger now. Plus every single one of your inventories have added slots. A whole row, to be exact. Go see for it yourself. I just gave you a little bit of #bSP#k. When you open up the #bSkill menu#k on the lower left corner of the screen, there are skills you can learn by using SP's. One warning, though: You can't raise it all together all at once. There are also skills you can acquire only after having learned a couple of skills first.");
			self.say("One more warning. Once you have chosen your job, try to stay alive for as long as you can. If you die, you will lose your experience. You wouldn't want to lose your hard-earned experience points, would you? That is all the knowledge I can give you for right now... going forward, you will have to train hard to become stronger. Come and see me when you have grown some more.");
			self.say("Oh, and... if you have any questions about being a Warrior, come talk to me. I don't know EVERYTHING, but I will help you to the best of my abilities. Until then...");
		}
		else
		{
			self.say("Awesome body! Awesome power! Warriors are the way to \r\ngo!!!! What do you think? Want to make the job advancement as a Warrior??");
		}
	}
	
	private void WarriorPath()
	{
		self.say("Are you here to become a warrior? Then you've come to the right place ...");
		
		AddEXP(300);
		SetQuestData(1005301, "e");
		QuestEndEffect();
		self.say("If you are at least at #blevel 10#k, then I can transform you into a #bwarrior#k. Please see me when you're ready to take the next step.");
	}
	
	private void OldBook()
	{
		string qOldBook5 = GetQuestData(1001504);
		
		if (qOldBook5 == "" && ItemCount(4031053) < 1)
		{
			self.say("Hmm...you need me for something?");
			return;
		}
	
		if (qOldBook5 == "")
		{
			self.say("Hmm...you need me for something? Wait, isn't that Elmina's #b#t4031053##k...! How did you... really? You're here looking for #t4031056# at the request of Alcaster? #bThe Book of Ancient#k, huh...I've forgotten about that book for a while...I'm sorry to say this, but even I don't know where exactly that book has gone. However, I do have something that may give you a clue as to finding the book's whereabouts.");
			bool start = AskYesNo("But I can't just give you that. I also have been giving away a little bit of my power to all the warrior-hopefuls for hundreds of years, but there have been a sudden rush of people wanting to be Warriors, I've used up most of my power as a result. Get me #b2 #t4005000#s#k and I'll help you find #b#t4031056##k. What do you think? Do you want to do it?");
			
			if (!start)
			{
				self.say("Hmmm...but without my help you won't ever be able to find #bThe Book of Ancient#k...Anyway if you have a change of heart, feel free to come back.");
				return;
			}
			
			AddEXP(4000);
			SetQuestData(1001504, "s");
			self.say("Good choice. #t4005000# is something you can acquire from the monsters on land. Of course it won't be easy to get them but still, I think you are capapble of doing it. I'll be waiting for you here. Best of luck to you!");
		}
		else if (qOldBook5 == "s")
		{
			if (ItemCount(4005000) < 2)
			{
				self.say("Still haven't found #b2 #t4005000#s#k yet? It's something you can find from the monsters on land from time to time. It won't be easy but I think you are capable of doing it. I'll be waiting for you here. Kepp trying!");
				return;
			}
			
			self.say("I knew that you won't let me down. With this, you can regain full strength. Well, like I promised, here's the item that may help you find #b#t4031056##k. Before you accept it, though, check and see if your etc. inventory has room.");
			
			if (!Exchange(0, 4005000, -2, 4031054, 1))
			{
				self.say("Please make some room in your etc. inventory, I have something very important to give you.");
				return;
			}
			
			AddEXP(8320);
			SetQuestData(1001504, "f1");
			self.say("This is a piece of a map that shows where #b#t4031056##k is hidden. It's been cut up in 4 pieces and is taken care of by us 4 wisemen. I can't just hide this for too long, though. Please find the book and then seal it tightly. Now please go visit #bthe Wiseman from Ellinia#k. I'll let him know in advance.");
		}
		else if (qOldBook5 == "f1" && ItemCount(4031054) < 1)
		{
			self.say("This is a piece of a map that shows where #b#t4031056##k is hidden. It's been cut up in 4 pieces and is taken care of by us 4 wisemen. I can't just hide this for too long, though. Please find the book and then seal it tightly. Now please go visit #bthe Wiseman from Ellinia#k. I'll let him know in advance.");
				
			if (!Exchange(0, 4031054, 1))
			{
				self.say("Please make some room in your etc. inventory, I have something very important to give you.");
				return;
			}
		}
		else
		{
			self.say("The map that shows where #b#t4031056##k is hidden is cut up in four pieces, and was left to us 4 wisemen. It can't be hidden forever, anyway. Please find the book and seal it up for all of us. Now go see #bthe wiseman in Ellinia#k. I'll let him know in advance.");
		}
	}
	
	private void Event()
	{
		string quest = GetQuestData(9000500);
		
		if (quest == "")
		{
			self.say("Greetings... Of course I'm happy, but why don't you go talk to the Maple Administrator first?");
		}
		else if (quest == "s")
		{
			self.say("I see... You're saying you came to give me a New Year's greeting? I'm happy to see you...! I'm surprised to see that there are young folk like you who still respect their elders. Alright... here's your money. Take this and find #b#p1032001##k of Ellinia. I haven't heard from him in some time so he'll probably be happy if you pay him a visit.");
			
			if (!ExchangeEx(800, "4031075,DateExpire:2021021800", 1))
			{
				self.say("Oh... I don't think you have room for my New Year's card in your inventory. Please talk to me again after making at least one empty space in your etc. inventory.");
				return;
			}
			
			AddEXP(450);
			SetQuestData(9000500, "1");
		}
		else if (quest == "1")
		{
			if (ItemCount(4031075) >= 1)
			{
				self.say("Thank you so much for coming all this way to give me your New Year's greeting. I'm surprised there's someone like you who still respects their elders... Now, go to #b#p1032001##k of Ellinia and deliver the New Year's card I gave you. He will probably be very happy.");
				return;
			}
			
			self.say("Hmm... I think you lost the New Year's card I gave you. I worked hard on that card, you can't throw it away ... I'll make another card, so please deliver this greeting card to #b#p1032001##k in Ellinia and give him your New Year's greeting. He'll probably be happy to see you.");
			
			if (!ExchangeEx(0, "4031075,DateExpire:2021021800", 1))
			{
				self.say("Oh... I don't think you have room for my New Year's card in your inventory. Please talk to me again after making at least one empty space in your etc. inventory.");
			}
		}
		else if (quest == "e")
		{
			self.say("You're the young traveler who recently came to give me a New Year's greeting. It was very nice to see you. These days, there are lots of people coming to ask me for this and that, but not many people visit just to say hello like you. Stop by every now and then to tell me about your journey.");
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
		
		if (quest == 1005301)	// The Path of Warrior
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
			if (qOldBook1 == "ke" && (info == "" || info == "s" || info == "f1"))
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
		bool cJobPath = Check(1005301);
		bool cOldBook = Check(1001504);
		bool cEvent = Check(9000500);
		
		if (cJobPath || cOldBook || cEvent)
		{
			AskMenuCallback("My name is #b#p1022000##k, who is doing various things for the warriors here in Perion. There are many who need my strength, so I am always busy. What is your business?#b",
				(" The Path of Warrior", cJobPath, WarriorPath),
				(" The Four Wisemen of Victoria Island", cOldBook, OldBook),
				(" I want to give you a New Year's Greeting", cEvent, Event),
				(" I'd like to know more about the warrior", Level >= 1, FighterAction));
		}
		else
		{
			FighterAction();
		}
	}
}