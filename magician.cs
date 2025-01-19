using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void MagicianAction()
	{
		string qThirdJob = GetQuestData(7500000);
		
		if (Job == 211 || Job == 221)
		{
			self.say("Ohhh... You finally became a #bMage#k... I knew that you wouldn't let me down. So, what do you think of life as the Mage? Please dedicate yourself and train even more.");
		}
		else if (Job == 231)
		{
			self.say("Ohhh... You finally became a #bPriest#k... I knew that you wouldn't let me down. So, what do you think of life as the Priest? Please dedicate yourself and train even more.");
		}
		else if (Job == 210 || Job == 220 || Job == 230)
		{
			if (qThirdJob == "s")
			{
				SetQuestData(7500000, "p1");
				self.say("I was waiting for you. Few days ago, I heard about you from #bRobeira#k in Ossyria. Well... I'd like to test your strength. There is a secret passage near the forest of Ellinia. Nobody but you can go into that passage. If you go into the passage, you will meet my the other self. Beat him and bring #b#t4031059##k to me.");
				self.say("My the other self is quite strong. He uses many special skills and you should fight with him 1 on 1. However, people cannot stay long in the secret passage, so it is important to beat him ASAP. Well... Good luck! I will look forward to you bringing #b#t4031059##k to me.");
			}
			else if (qThirdJob == "p1")
			{
				if (ItemCount(4031059) < 1)
				{
					self.say("There is a secret passage near the forest of Ellinia. Nobody but you can go into that passage. If you go into the passage, you will meet my the other self. Beat him and bring #b#t4031059##k to me. My the other self is quite strong. He uses many special skills and you should fight him 1 on 1. However, people cannot stay long in the secret passage, so it is important to beat him ASAP. Well... Good luck! I will look forward to you bringing #b#t4031059##k to me.");
					return;
				}
				
				self.say("Wow... You beat my the other self and brought #b#t4031059##k to me. Good! This surely proves your strength. In terms of strength, you are ready to advance to 3rd job. As I promised, I will give #bThe Necklace of Strength#k to you. Give this necklace to #bRobeira#k in Ossyria and you will be able to take second test of 3rd job advancement. Good luck~.");
				
				if (!Exchange(0, 4031059, -1, 4031057, 1))
				{
					self.say("Hmm... how strange. Are you sure you have #b#t4031059##k? If so, make sure you have an empty slot in your item inventory.");
					return;
				}
				
				SetQuestData(7500000, "p2");
			}
			else if (qThirdJob == "p2")
			{
				if (ItemCount(4031057) >= 1)
				{
					self.say("Give this necklace to #bRobeira#k in Ossyria and you will be able to take second test of 3rd job advancement. Good luck~!");
					return;
				}
				
				self.say("Ohh... you lost the #b#t4031057##k, huh? I told you to be careful with that... For God's sake, I will give you one... AGAIN. Please be careful this time. Without this, you will not be able to take the test for the 3rd job advancement.");
				
				if (!Exchange(0, 4031057, 1))
				{
					self.say("Hmm... how strange. Make sure you have an empty slot in your item inventory.");
				}
			}
			else
			{
				if (Job == 210)
				{
					self.say("Ohhh... it's you... what do you think of life as a Wizard? You... seem quite at ease with flaming arrows now... please dedicate yourself and train even more.");
				}
				else if (Job == 220)
				{
					self.say("Ohhh... it's you... what do you think of life as a Wizard? You... seem to be capable of handling ice and lightning with ease... please dedicate yourself and train even more.");
				}
				else if (Job == 230)
				{
					self.say("Ohhh... it's you... what do you think of life as the Cleric? You... seem to be capable of handling sanctity magic with ease... please dedicate yourself and train even more.");
				}
			}
		}
		else if (Job == 200)
		{
			if (Level >= 30)
			{
				if (ItemCount(4031009) >= 1)
				{
					self.say("Haven't seen him yet? Please go see #b#p1072001##k that's around #b#m101020000##k near #m101000000#... get him this letter and he'll tell you what to do in detail...");
				}
				else if (ItemCount(4031012) >= 1)
				{
					self.say("You got back here safely. Well done. I knew you'd pass the tests very easily... alright, I'll make you much stronger now. Before that, though... you need to choose one of the three paths that will given to you. It will be a tough decision for you to make, but... if you have any questions about it, feel free to ask.");
					
					int chooseSecond1 = AskMenu("Alright, when you have made your decision, click on [I'll choose my occupation!] at the very bottom...#b",
						(0, " Please explain the characteristics of the Wizard of Fire and Poison."),
						(1, " Please explain the characteristics of the Wizard of Ice and Lightning."),
						(2, " Please explain the characteristics of the Cleric."),
						(3, " I'll choose my occupation!"));
						
					if (chooseSecond1 == 0)
					{
						self.say("Allow me to explain all about the Wizard of Fire and Poison. They specialize in fire and poison magic. Skills like #b#q2101001##k, which boost you and your party's magic for a while, and #b#q2100000##k, which gives you a certain chance to absorb a little of the enemy's MP, are essential for the Wizards casting the attack.");
						self.say("Let me explain to you a magic attack called #b#q2101004##k. It fires flaming arrows at enemies, making this attack the most powerful skill available among the 2nd level skills. It works best against the enemies that are generally weak to fire, as the damage will be much greater. On the other hand, if you use it against enemies that are resistant to fire, the damage will be reduced by half. Don't forget that.");
						self.say("Let me explain to you a magic attack called #b#q2101005##k. It fires a ball of poison at the enemies and inflicts them with poison. Afterwards, the enemy's HP will decrease more and more over time. If the spell doesn't work very well or the monster has high HP, it can be a good idea to fire it as many times as necessary to kill it with a poison overdose...");
					}
					else if (chooseSecond1 == 1)
					{
						self.say("Allow me to explain all about the Wizard of Ice and Lightning. They specialize in ice and lightning magic. Skills like #b#q2101001##k, which boost you and your party's magic for a while, and #b#q2100000##k, which gives you a certain chance to absorb a little of the enemy's MP, are essential for the Wizards casting the attack.");
						self.say("Let me explain to you a magic attack called #b#q2201004##k. It fires shards of ice at the enemies, and while not as powerful as #q2101004#, those hit by the attack will be frozen for a brief period of time. The damage will be much greater if the enemy is weak to ice. The opposite is also true, if the enemy is accustomed to ice, the damage will not be as great. Don't forget that.");
						self.say("Let me explain to you a magic attack called #b#q2201005##k. It's the only 2nd level skill for Wizards that can be considered a Complete Spell and it affects various monsters at once. It may not do much damage, but the advantage is that it does damage to several monsters around you. However, you can only attack six monsters at a time. Still, it's an incredible attack.");
					}
					else if (chooseSecond1 == 2)
					{
						self.say("Allow me to explain all about the Cleric. Clerics use religious magic against monsters through prayers and incantations. Skills like #b#q2301004##k, which temporarily improve weapon defense, magic defense, accuracy and avoidability, and #b#q2301003##k, which reduces a certain amount of damage from physical attacks, helps the Magician make up for their weaknesses...");
						self.say("The Cleric is the only Magician capable of learning recovery magic. Clerics are also the only ones capable of performing recovery magic. It's called #b#q2301002##k and the higher the MP, INT, and level of this skill, the more HP you will recover. It also affects the members of your party that are close to you, so it is a very useful skill, allowing you to continue hunting without the use of potions.");
						self.say("Clerics also have a magic attack called #b#q2301005##k. It's a spell that allows the Cleric to shoot holy arrows at monsters. The effect isn't very great, but it can inflict enormous damage to zombies and other evil monsters. These monsters are very weak to sanctity attacks. What do you think? Isn't it interesting?");
					}
					else if (chooseSecond1 == 3)
					{
						int chooseSecond2 = AskMenu("Now, have you made up your mind? Please select your occupation for your 2nd job advancement.#b",
							(0, " The Wizard of Fire and Poison"),
							(1, " The Wizard of Ice and Lightning"),
							(2, " Cleric"));
							
						if (chooseSecond2 == 0)
						{
							bool askSecond = AskYesNo("So you want to make the 2nd job advancement as the#b Wizard of Fire and Poison#k? Once you've made your decision, you can't go back and change your class. Are you sure about your decision?");
							
							if (!askSecond)
							{
								self.say("Really? You need to think about it more, right? Take your time, take your time. It's not something you should do right away... come and talk to me when you make your decision.");
								return;
							}
							
							int nSP = (Level - 30) * 3;
							
							if (SP > nSP)
							{
								self.say("Hmmm... you have too much #bSP#k... you can't advance to the 2nd job with so much SP saved up. Use more SP on 1st level skills and come back...");
								return;
							}
							
							if (!Exchange(0, 4031012, -1))
							{
								self.say("Hmmm... are you sure you have #b#t4031012##k from #p1072001#? It's better to be sure... because you can't advance to the 2nd job without it.");
								return;
							}
							
							ChangeJob(210); 
							AddSP(1);
							var incval = (short)Random(450, 501);
							AddMaxMP(incval);
							AddInventorySlots(4, 4);
							
							
							self.say("From now on, you have become a #bWizard of Fire and Poison#k... Wizards use their high intelligence and the force of nature around them to take down their enemies... continue with your studies, because one day I will make you much stronger with my own power...");
							self.say("I have just given you a book that gives you the the list of skills you can acquire as the Wizard of Fire and Poison... I've also expanded your etc. inventory by a whole row, along with your maximum MP... go see for it yourself.");
							self.say("I have also given you a little bit of #bSP#k. Open the #bSkill Menu#k located at the bottomleft corner. You'll be able to boost up the newly-acquired 2nd level skills. A word of warning, though: You can't boost them up all at once. Some of the skills are only available after you have learned other skills. Make sure to remember that.");
							self.say("Wizards have to be strong. But remember that you can't abuse that power and use it on a weakling. Use your enormous power the right way, because... for you to use that the right way, that is much harder than just getting stronger. Find me after you have advanced much further.");
						}
						else if (chooseSecond2 == 1)
						{
							bool askSecond = AskYesNo("So you want to make the 2nd job advancement as the#b Wizard of Ice and Lightning#k? Once you've made your decision, you can't go back and change your job... are you sure about your decision?");
							
							if (!askSecond)
							{
								self.say("Really? You need to think about it more, right? Take your time, take your time. It's not something you should do right away... come and talk to me when you make your decision.");
								return;
							}
							
							int nSP = (Level - 30) * 3;
							
							if (SP > nSP)
							{
								self.say("Hmmm... you have too much #bSP#k... you can't advance to the 2nd job with so much SP saved up. Use more SP on 1st level skills and come back...");
								return;
							}
							
							if (!Exchange(0, 4031012, -1))
							{
								self.say("Hmmm... are you sure you have #b#t4031012##k from #p1072001#? It's better to be sure... because you can't advance to the 2nd job without it.");
								return;
							}
							
							ChangeJob(220);
							AddSP(1);
							var incval = (short)Random(450, 501);
							AddMaxMP(incval);
							AddInventorySlots(4, 4);
							
							self.say("Alright, now you have become the #bWizard of Ice and Lightning#k... Wizards use their high intelligence and the force of nature around them to take down enemies... continue your with your studies, because one day I will make you much more powerful with my own power...");
							self.say("I have just given you a book that gives you the the list of skills you can acquire as the Wizard of Ice and Lightning... I've also expanded your etc. inventory by a whole row, along with your maximum MP... go see for it yourself.");
							self.say("I have also given you a little bit of #bSP#k. Open the #bSkill Menu#k located at the bottomleft corner. You'll be able to boost up the newly-acquired 2nd level skills. A word of warning, though: You can't boost them up all at once. Some of the skills are only available after you have learned other skills. Make sure to remember that.");
							self.say("Wizards have to be strong. But remember that you can't abuse that power and use it on a weakling. Use your enormous power the right way, because... for you to use that the right way, that is much harder than just getting stronger. Find me after you have advanced much further. I'll be waiting for you...");
						}
						else if (chooseSecond2 == 2)
						{
							bool askSecond = AskYesNo("So you want to make the 2nd job advancement as the#b Cleric#k? You can't go back and change your job once you have made the decision... are you really sure about it?");
							
							if (!askSecond)
							{
								self.say("Really? You need to think about it more, right? Take your time, take your time. It's not something you should do right away... come and talk to me when you make your decision.");
								return;
							}
							
							int nSP = (Level - 30) * 3;
							
							if (SP > nSP)
							{
								self.say("Hmmm... you have too much #bSP#k... you can't advance to the 2nd job with so much SP saved up. Use more SP on 1st level skills and come back...");
								return;
							}
							
							if (!Exchange(0, 4031012, -1))
							{
								self.say("Hmmm... are you sure you have #b#t4031012##k from #p1072001#? It's better to be sure... because you can't advance to the 2nd job without it.");
								return;
							}
							
							ChangeJob(230);
							AddSP(1);
							var incval = (short)Random(450, 501);
							AddMaxMP(incval);
							AddInventorySlots(4, 4);
							
							
							self.say("Alright, you're a #bCleric#k from here on out. Clerics blow life into every living organism here with their undying faith in God. Never stop working on your faith... then one day, I'll help you become much more powerful...");
							self.say("I have just given you a book that gives you the the list of skills you can acquire as the Cleric... I've also expanded your etc. inventory by a whole row, along with your maximum MP... go see for it yourself...");
							self.say("I have also given you a little bit of #bSP#k. Open the #bSkill Menu#k located at the bottomleft corner. You'll be able to boost up the newly-acquired 2nd level skills. A word of warning, though: You can't boost them up all at once. Some of the skills are only available after you have learned other skills. Make sure to remember that.");
							self.say("The Cleric needs faith more than anything else. Keep your strong faith in God and treat everyone with respect and dignity they deserve. Keep working hard and you may one day earn more religious magic power... alright... please find me after you have made more strides. I'll be waiting for you...");
						}
					}
				}
				else
				{
					bool questSecond = AskYesNo("Hmmm... you have grown quite a bit since last time. You look much different from before, where you looked weak and small... instead now I can definitely feel your presence as the Magician... so... what do you think? Do you want to get even stronger than you are right now? Pass a simple test and I can do just that for you... do you want to do it?");
					
					if (!questSecond)
					{
						self.say("Really? Getting stronger quickly will help you a lot during your journey... if you change your mind in the future, you can come back here whenever you want. Remember that I can make you much stronger than you already are...");
						return;
					}
					
					self.say("Good... you look strong, alright, but I need to see if it is for real. The test isn't terribly difficult, and you should be able to pass it. Here, take my letter first. Make sure you don't lose it.");
					
					if (!Exchange(0, 4031009, 1))
					{
						self.say("I don't think you have space in your inventory to receive my letter. Free up some space in your Etc. inventory and come back to me. After all, you can only take the test with the letter.");
						return;
					}
					
					self.say("Please get this letter to #b#p1072001##k around #b#m101020000##k near #m101000000#. He's doing the role of an instructor in place of me... Get him the letter and he'll test you in place of me. He'll give you all the details about it. Best of luck to you...");
				}
			}
			else
			{
				int askHelp = AskMenu("Do you have any questions about how to be a Magician?#b",
					(0, " What are the basic characteristics of the Magician?"),
					(1, " What are the weapons of a Magician?"),
					(2, " What are the armors of a Magician?"),
					(3, " What are the skills available for a Magician?"));
					
				if (askHelp == 0)
				{
					self.say("I'll tell you more about being a Magician. Magicians use very high levels of magic and intelligence. They can use the power of nature around them to kill enemies, but they are very weak in hand-to-hand combat. Your stamina also isn't very high, so be careful to avoid dying in any way.");
					self.say("The fact that you're able to attack monsters from a distance will help you greatly. Try to improve your INT level if you want to attack your enemies with spells precisely. The more intelligence, the better you'll be at handling your magic...");
				}
				else if (askHelp == 1)
				{
					self.say("I'll tell you more about the Magician's weapons. The truth is, it doesn't mean much to a Magician to attack their opponents with weapons. Magicians don't have strength and dexterity, so you'll have a hard time defeating even a snail.");
					self.say("Magic powers are a ANOTHER story. Magicians use maces, staffs and wands. Maces are good for, well, attacking with force, but... I wouldn't recommend this for a Magician, period.");
					self.say("In fact, staffs and wands are the perferred weapons. They have special magic powers and therefore improve the Magician's abilities. It's a good idea to carry a weapon with a lot of magic power...");
				}
				else if (askHelp == 2)
				{
					self.say("I'll tell you more about the Magician's armor. Honestly, Magicians don't have very much armor, as they already have little physical strength and little stamina. Your defense skills are also not so good, so I don't know if it will help very much...");
					self.say("Some armor, however, has the ability to block magic power, so it can protect you from magic attacks. They won't help much, but it's better than using nothing... so, be sure to buy them if you have time...");
				}
				else if (askHelp == 3)
				{
					self.say("The skills available to the Magicians use the high levels of intelligence and magic that the Magicians posess. Magic Guard and Magic Armor are also available, which prevent Magicians from dying with little health.");
					self.say("The attack skills are #b#q2001004##k and #b#q2001005##k. First of all, #q2001004# is a skill that does a lot of damage to the opponent with minimal MP use.");
					self.say("#q2001005#, on the other hand uses lots of MP to attack the opponent TWICE. But you can only use it when #q2001004# has been raised one level. Don't forget that. You can decide what to do...");
				}
			}
		}
		else if (Job == 0)
		{
			self.say("Do you want to be a Magician? You need to meet some requirements in order to do so. You need to be at least at#b Level 8, and INT 20#k. Let's see if you have what it takes to become a Magician...");
			
			if (Level < 8 || INT < 20)
			{
				self.say("You need to train more to become a Magician. For this, you have to strive to become more powerful than you already are. Come back when you're much stronger.");
				return;
			}
			
			bool askFirst = AskYesNo("You definitely have the look of a Magician. You may not be there yet, but I can see the Magician in you... what do you think? Do you want to become the Magician?");
			
			if (!askFirst)
			{
				self.say("Really? Need more time to think about it? Take your time... This should not be taken lightly. Come talk to me again when you have made your decision.");
				return;
			}
			
			self.say("Alright, you're a Magician from here on out, since I, #p1032001#, the head Magician, allow you so. It isn't much, but I'll give you a little bit of what I have...");
			
			ChangeJob(200);
			var incval = (short)Random(100, 151);
			AddMaxMP(incval);
			AddSP(1);
			
			self.say("You have just been equipped yourself with much more magical power. Continue training and get better every day... I will watch over you from time to time...");
			self.say("I just gave you a little bit of #bSP#k. When you open the #bSkill menu#k on the lower left corner of the screen, there are skills you can learn by using SP's. One warning, though: You can't raise it all together all at once. There are also skills you can acquire only after having learned a couple of skills first.");
			self.say("One more warning. Once you have chosen your job, try to stay alive as much as you can. Once you reach that level, when you die, you will lose your experience level. You wouldn't want to lose your hard-earned experience points, do you?");
			self.say("OK! This is all I can teach you. Go places, train to become even better. Look for me when you think you've done everything you can and need something interesting. I'll be waiting for you here...");
			self.say("Oh, and... if you have any questions about being a Magician, just ask. I don't know EVERYTHING, to tell you the truth, but I will help you with everything I know. Until then...");
		}
		else
		{
			self.say("Would you like to have the power of nature in itself in your hands? It may be a long, hard road to be on, but you'll surely be rewarded in the end, reaching the very top of wizardry...");
		}
	}
	
	private void MagicianPath()
	{
		self.say("Are you ready to become a magician like me?");
		
		AddEXP(300);
		SetQuestData(1005304, "e");
		self.say("Yes. We have a growing number of people training themselves to become the best magician they can be. In order to join them, you'll have to be at least #blevel 8#k to do so. Talk to me when you're ready.");
	}
	
	private void OldBook()
	{
		string qOldBook5 = GetQuestData(1001504);
		
		int mapCount = ItemCount(4031054);
		
		if (qOldBook5 == "f1")
		{
			if (mapCount < 1)
			{
				self.say("Hmm... are you missing a piece of the map?");
				return;
			}
			
			self.say("I heard about you through #b#p1022000##k from Perion. We don't need to necessarily talk to each other to communicate; we communicate through our minds. You've worked hard to get here. But hey, you're looking for #b#t4031056##k? Of course I also happen to have the piece of the map that shows the book's whereabouts. I've forgotten about it for a while...");
			bool askStart = AskYesNo("But I can't just give you that. I also have been giving away a little bit of my power to all the magician-hopefuls for hundreds of years, but there have been a sudden rush of people wanting to be Magicians, I've used up most of my power as a result. Get me #b2 #t4005001#s#k and I'll help you find #b#t4031056##k. What do you think? Do you want to do it?");
			
			if (!askStart)
			{
				self.say("Hmmm. Without my help you won't ever be able to find #b#t4031056##k. Anyway, if you have a change of heart, feel free to come back.");
				return;
			}
			
			AddEXP(4000);
			SetQuestData(1001504, "f2");
			self.say("Good choice. #t4005001# is something you can acquire from the monsters on land. Of course it won't be easy to get them but still, I think you are capapble of doing it. I'll be waiting for you here. Best of luck to you!");
		}
		else if (qOldBook5 == "f2")
		{
			if (ItemCount(4005001) < 2)
			{
				self.say("You didn't collect #b2 #t4005001f#s#k yet? You'll be able to find it from the monsters on land from time to time. It won't be an easy task, but I think you are more than capable of getting them. I'll be waiting for you here. Good luck!");
				return;
			}
			
			self.say("I knew you wouldn't let me down. I had no doubt in my mind you would be able to do it. This will help me recover my health. Like I promised, here's the item that may hold key to finding #b#t4031056##k. Before that, though, check and make sure your etc. inventory has room for an item.");
			
			if (!Exchange(0, 4005001, -2, 4031054, 1))
			{
				self.say("Please make some room in your etc. inventory, I have something very important to give you.");
				return;
			}
			
			AddEXP(8320);
			SetQuestData(1001504, "f3");
			self.say("This is the 2nd piece of the map that shows where #b#t4031056##k is hidden. The map has been cut to four pieces and given to the 4 of us wisemen. The book won't stay hidden forever, though...Please find the book and seal it up tight for all of us. Now go see the #bWisewoman from Henesys#k. I'll let her know in advance.");
		}
		else if (qOldBook5 == "f3" && ItemCount(4031054) < 2)
		{
			self.say("This is the 2nd piece of the map that shows where #b#t4031056##k is hidden. The map has been cut to four pieces and given to the 4 of us wisemen. The book won't stay hidden forever, though...Please find the book and seal it up tight for all of us. Now go see the #bWisewoman from Henesys#k. I'll let her know in advance.");
			
			int newItemCount = 2 - mapCount;
				
			if (!Exchange(0, 4031054, newItemCount))
			{
				self.say("Please make some room in your etc. inventory, I have something very important to give you.");
				return;
			}
		}
		else
		{
			self.say("The map that shows where #b#t4031056##k is hidden is cut up in four pieces and is currently taken care of by the four of us wisemen. But it can't stay hidden forever...please find the book and seal it up tightly for us. Now go see the #bWisewoman from Henesys#k. I'll let her know of the situation.");
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
			self.say("A New Year's greeting... How commendable...! But first, you should visit #b#p1022000##k of Perion. It won't be too late to say hello to me after that. I'll be waiting for you to return...");
		}
		else if (quest == "1")
		{
			self.say("I see... You're saying you came to give me a New Year's greeting? I'm happy to see you...! I'm surprised to see that there are young folk like you who still respect their elders. This must be a New Year's card from #b#p1022000##k. Alright... Here's some money. take this and find #b#p1012100##k of Henesys. I haven't heard from her in some time. so she'll probably be happy if you pay her a visit.");
			
			if (!ExchangeEx(800, "4031075", -1, "4031076,DateExpire:2021021800", 1))
			{
				self.say("Oh... I don't think you have room for my New Year's card in your inventory. Please talk to me again after making at least one empty space in your etc. inventory.");
				return;
			}
			
			AddEXP(450);
			SetQuestData(9000500, "2");
		}
		else if (quest == "2")
		{
			if (ItemCount(4031076) >= 1)
			{
				self.say("Thank you so much for coming all this way to give me your New Year's greeting. I'm surprised there's someone like you who still respects their elders... Now, go to #b#p1012100##k of Henesys and deliver the New Year's card I gave you. She will probably be very happy.");
				return;
			}
			
			self.say("Hmm... I think you lost the New Year's card I gave you. I worked hard on that card, you can't throw it away~ I'll make another one, so give this New Year's card to #b#p1012100##k of Henesys and give her your New Year's greeting. She'll probably be happy to see you.");
			
			if (!ExchangeEx(0, "4031076,DateExpire:2021021800", 1))
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
		
		if (quest == 1005304)
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
			if (info == "f1" || info == "f2" || info == "f3")
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
		bool cJobPath = Check(1005304);
		bool cOldBook = Check(1001504);
		bool cEvent = Check(9000500);
		
		if (cJobPath || cOldBook || cEvent)
		{
			AskMenuCallback("I'm #b#p1032001##k, who is doing various things for the magicians here in Ellinia. There are many who need my strength, so I am always busy. What do you need with me?#b",
				(" The Path of Magician", cJobPath, MagicianPath),
				(" The Four Wisemen of Victoria Island", cOldBook, OldBook),
				(" I want to give you a New Year's Greeting", cEvent, Event),
				(" I'd like to know more about the magician", Level >= 1, MagicianAction));
		}
		else
		{
			MagicianAction();
		}
	}
}