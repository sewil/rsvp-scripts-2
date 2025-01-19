using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1002700);
		
		int start = AskMenu("Hello, you there! I'm the main disciple of #b#p1032102##k from Victoria Island. #p1032102# called me to check if the pets are treated well here in Ludibrium. What can I do for you?#b",
			(0, " My pet turned back into a doll. Please help me make it \r\nmove again!"),
			(1, " Tell me more about Pets."),
			(2, " How can I take care of Pets?"),
			(3, " Do the Pets die too?"),
			(4, " What are the commands of the Brown and Black Kitties?"),
			(5, " What are the commands of the Brown Puppy?"),
			(6, " What are the commands of the Bunnies?"),
			(7, " What are the commands of the Mini Kargo?"),
			(9, " What are the commands of the Black Pig?"),
			(11, " What are the commands of the Husky?"),
			(12, " What are the commands of the Dino Boy and Dino Girl?"),
			(15, " What are the commands of the White Tiger?"),
			(10, " What are the commands of the Panda?"),
			(13, " What are the commands of the Monkey?"),
			(18, " What are the commands of the Robot?"),
			(20, " What are the commands of the Jr. Balrog?"),
			(24, " What are the commands of the Mini Grim Reaper?"),
			(27, " What are the commands of Kino?"),
			(28, " What are the commands of White Duck?")

// Unavailable Pets:
//			(8, " What are the commands of Rudolph and Dasher?"),
//			(14, " What are the commands of the Turkey?"),
//			(16, " What are the commands of the Penguin?"),
//			(17, " What are the commands of the Golden Pig?"),
//			(19, " What are the commands of the Mini Yeti?"),
//			(21, " What are the commands of the Baby Dragon?"),
//			(22, " What are the commands of the Green/Red/Blue Dragons?"),
//			(23, " What are the commands of the Black Dragon?"),
//			(25, " What are the commands of the Hedgehog?"),
//			(26, " What are the commands of the Snowman?"),
		);

		if (start == 0)
		{
			long isPet = AskPet("");
			
			if (isPet == 0)
			{
				if (quest == "e")
				{
					self.say("Hello! How is your reanimated pet doing? I'm glad to know you're happy with your pet. Well, now I have to get back to the studies my master passed on to me, so...");
				}
				else
				{
					self.say("I am #p2040030#, continuing with the studies that my master #p1032102# gave me. It seems that there are many pets even here in Ludibrium. I need to get back to my studies, so if you'll excuse me...");
				}
				
				return;
			}
			
			if (quest == "s")
			{
				if (ItemCount(4070000) < 1 || ItemCount(4031034) < 1)
				{
					self.say("I don't think you've gotten #b#t4070000##k and #b#t4031034##k yet. Somewhere in Ludibrium you will find the home of #b#p1012005##k. The home is empty at the moment, but take a look and maybe you'll find it. Cheers!");
					return;
				}
				
				bool complete = AskYesNo("You brought me #b#t4070000##k and #b#t4031034##k... with these items, I can bring the doll back to life using the magic power of my master. What do you think? Do you want to use the items and reanimate your pet?");
				
				if (!complete)
				{
					self.say("I get it, you're not sure about that, are you? You don't think leaving the pet as a doll is wrong? Please return here if you change your mind...");
					return;
				}
				
				long petCode = AskPet("So, which pet do you want to restore? Please choose the pet you want to revive...");
			
				bool okPet = SetPetLife(petCode, 4070000, 4031034);
				
				if (!okPet)
				{
					self.say("Something is wrong... are you sure you have #b#t4070000##k and #b#t4031034##k? Without these two items, I can't turn your doll back into a pet.");
					return;
				}
				
				SetQuestData(1002700, "e");
				QuestEndEffect();
				self.say("Your doll has now returned to being a pet. However, my magic isn't perfect, so I can't promise that it will live forever ... take care of your pet before the #t4070000# runs out. Well, I think that's that... goodbye!");
			}
			else
			{
				bool start2 = AskYesNo("It looks like you already met #p1012005#. #p1012005# is someone who studied the magic of life with my master, #p1032102#. I heard talk that he used an incomplete life spell on a doll to create a living animal... is the doll that you have the same doll that #p1012005# created, called #bPet#k?");
				
				if (!start2)
				{
					self.say("But it certainly looks like the work of #p1012005#. Oh well! It doesn't matter. I've seen #p1012005# in the past few years and I'm sure he can't create life magic on dolls. Well, that's that...");
					return;
				}
				
				self.say("I understand. This doll used to be a live animal... but the same item that #p1012005# used to give life to the pet, #b#t4070000##k, it ran out and the pet returned to being a doll... it doesn't move anymore because now it's a doll again... hmm... isn't life something you can create with magic...?");
				self.say("Do you want to turn the doll back into what it was? A living being? You want your pet to accompany you again, walking around and keeping you company right? Of course! That is totally possible! Since I am the Fairy disciple who studied magic with #p1012005#... Maybe I can make it live again...");
				bool start3 = AskYesNo("If I can obtain #b#t4070000##k and #b#t4031034##k, maybe I can make your doll come back to life. What do you think? Do you want to go find these items? Bring the items to me and I will try to bring your doll back to life...");
				
				if (!start3)
				{
					self.say("You want to leave the doll the way it is? It's a doll now but... it will be difficult to erase your memories too. If you change your mind, just come and talk to me...");
					return;
				}
				
				SetQuestData(1002700, "s");
				self.say("Very well. I said this already, but what I need is #b#t4070000##k and #b#t4031034##k. Bring me these two items and I can bring your doll back to life. #b#t4031034##k is hard to find... somewhere in Ludibrium you will find the home of #b#p1012005##k. The house is empty at the moment, but take a look around and maybe you'll find it.");
			}
		}
		else if (start == 1)
		{
			self.say("Hmm... you must have a lot of questions about pets. A long time ago, a person by the name of #b#p1012005##k splashed #t4070000# on one, and cast a spell on it to create a magic animal. I know it sounds unbelievable, but it's a doll that has become a living being. They understand and accompany people.");
			self.say("But #t4070000# is scarce, only appearing a little at the base of the World Tree, so these babies can't live forever... I know, it's very boring... but even if it becomes a doll again, I can always bring it back to life. Be nice while you're with it.");
			self.say("Ah yes! They will respond when you speak special commands. You can fight with them, love them... it all depends on how you take care of them. They are afraid to abandon their masters, so be kind to them, and show them some love. They can get sad and lonely very quickly...");
		}
		else if (start == 2)
		{
			self.say("Depending on the commands you give, pets can like, hate and express other types of reactions. If you give the pet command and he obeys with no complaints, their bond with you will increase. Double-click the pet and you will be able to view the level of closeness, hunger, and etc...");
			self.say("Talk with the pet, give it attention, and their level of intamacy will increase. As your level of intamacy increases, your pet's overall level will also increase. As the general level increases, one day the pet may even speak a little like a person, so try to raise your pet in the best possible way. Of course it won't be easy to do that...");
			self.say("They are living dolls, but they also get hungry, for example. #bFullness#k shows the pet's level of hunger, with 100 being the maximum and the lower this becomes, the hungrier your pet is feeling. After some time, they will not follow your commands and will be irritated, so take good care of them.");
			self.say("That's right! Pet's can't eat normal human food. A teddy bear named #b#p2041014##k who lives in Ludibrium sells #b#t2120000##k so, if you need food for your pet, go talk to #b#p2041014##k. It's a good idea to buy extra food and feed your pet before it gets too hungry.");
			self.say("Oh, and if you don't feed the pet for a long time, it goes home by itself. You can take it out of its house and feed it, but that's not very good for your pet's health, so try to feed it regularly to avoid these problems, alright? I think that's all.");
		}
		else if (start == 3)
		{
			self.say("Dying... well, see, they're not actually ALIVE, so I don't know if death is the correct word to use. They are dolls with the magical power from #p1012005# and #t4070000# that makes them living objects. Of course, while it's alive, it looks like a living animal...");
			self.say("After some time... Yes! It is what you're thinking! They stop moving. They are just a doll again, when the magic runs out and the #t4070000# dries up. But that doesn't mean it stops moving forever, because when you pour #t4070000# on it, it comes back to life.");
			self.say("Even knowing this, it's sad to see them stop moving. Be nice to them while they're alive and moving. And don't forget to feed them too. Isn't it nice to know that there's a living thing that follows you and obeys only you?");
		}
		else if (start == 4)
		{
			self.say("These are the commands of the #rBrown and Black Kitties#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b stupid, ihateyou, dummy#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 10 ~ 30)\r\n#b cutie#k (level 10 ~ 30)\r\n#b up, stand, rise#k (level 20 ~ 30)");
		}
		else if (start == 5)
		{
			self.say("These are the commands of the #rBrown Puppy#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b stupid, ihateyou, dummy#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b pee#k (level 1 ~ 30)\r\n#b talk, say, chat#k (level 10 ~ 30)\r\n#b down#k (level 10 ~ 30)\r\n#b stand, up, rise#k (level 20 ~ 30)");
		}
		else if (start == 6)
		{
			self.say("These are the commands of the #rPink and White Bunny#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b stand, up, rise#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b talk, say, chat#k (level 10 ~ 30)\r\n#b hug#k (level 10 ~ 30)\r\n#b sleep, sleepy, gotobed#k (level 20 ~ 30)");
		}
		else if (start == 7)
		{
			self.say("These are the commands of the #rMini Kargo#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b stand, up, rise#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b pee#k (level 1 ~ 30)\r\n#b talk, say, chat#k (level 10 ~ 30)\r\n#b thelook, charisma#k (level 10 ~ 30)\r\n#b down#k (level 20 ~ 30)\r\n#b goodboy, goodgirl#k (level 20 ~ 30)");
		}
		else if (start == 8)
		{
			self.say("These are the commands of the #rRudolph and Dasher#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b stand, up#k (level 1 ~ 30)\r\n#b stupid, ihateyou, dummy#k (level 1 ~ 30)\r\n#b merryxmas#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b talk, say, chat#k (level 11 ~ 30)\r\n#b lonely, alone#k (level 11 ~ 30)\r\n#b cutie#k (level 11 ~ 30)\r\n#b mush, go#k (level 21 ~ 30)");
		}
		else if (start == 9)
		{
			self.say("These are the commands of the #rBlack Pig#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b hand#k (level 1 ~ 30)\r\n#b stupid, ihateyou, dummy#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 10 ~ 30)\r\n#b smile#k (level 10 ~ 30)\r\n#b thelook, charisma#k (level 20 ~ 30)");
		}
		else if (start == 10)
		{
			self.say("These are the commands of the #rPanda#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b chill, relaxa#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b stand, up, rise#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 10 ~ 30)\r\n#b letsplay#k (level 10 ~ 30)\r\n#b meh, bleh#k (level 10 ~ 30)\r\n#b sleep#k (level 20 ~ 30)");
		}
		else if (start == 11)
		{
			self.say("These are the commands of the #rHusky#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b stupid, ihateyou, dummy#k (level 1 ~ 30)\r\n#b hand#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b down#k (level 10 ~ 30)\r\n#b talk, chat, say#k (level 10 ~ 30)\r\n#b stand, up, rise#k (level 20 ~ 30)");
		}
		else if (start == 12)
		{
			self.say("These are the commands of the #rDino Boy and Dino Girl#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b smile, laugh#k (level 1 ~ 30)\r\n#b stupid, ihateyou, dummy#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 10 ~ 30)\r\n#b cutie#k (level 10 ~ 30)\r\n#b sleep, nap, sleepy#k (level 20 ~ 30)");
		}
		else if (start == 13)
		{
			self.say("These are the commands of the #rMonkey#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b rest#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b pee#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b stand, up#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 10 ~ 30)\r\n#b play#k (level 10 ~ 30)\r\n#b melong#k (level 10 ~ 30)\r\n#b sleep, gotobed, sleepy#k (level 20 ~ 30)");
		}
		else if (start == 14)
		{
			self.say("These are the commands of the #rTurkey#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b no, rudeboy, mischief#k (level 1 ~ 30)\r\n#b stupid#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b up, stand#k (level 1 ~ 30)\r\n#b talk, chat, gobble#k (level 10 ~ 30)\r\n#b yes, goodboy#k (level 10 ~ 30)\r\n#b sleepy, birdnap, doze#k (level 20 ~ 30)\r\n#b birdeye, thanksgiving, fly, friedbird, imhungry#k (level 20 ~ 30)");
		}
		else if (start == 15)
		{
			self.say("These are the commands of the #rWhite Tiger#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b rest, chill#k (level 1 ~ 30)\r\n#b stupid, ihateyou, dummy#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 10 ~ 30)\r\n#b actsad, sadlook#k (level 10 ~ 30)\r\n#b wait#k (level 20 ~ 30)");
		}
		else if (start == 16)
		{
			self.say("These are the commands of the #rPenguin#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b up, stand, rise#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 10 ~ 30)\r\n#b hug, hugme#k (level 10 ~ 30)\r\n#b wing, hand#k (level 10 ~ 30)\r\n#b sleep#k (level 20 ~ 30)\r\n#b kiss, smooch, muah#k (level 20 ~ 30)\r\n#b fly#k (level 20 ~ 30)\r\n#b cute, adorable#k (level 20 ~ 30)");
		}
		else if (start == 17)
		{
			self.say("These are the commands of the #rGolden Pig#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 11 ~ 30)\r\n#b loveme, hugme#k (level 11 ~ 30)\r\n#b sleep, sleepy, gotobed#k (level 21 ~ 30)\r\n#b ignore, impressed, outofhere#k (level 21 ~ 30)\r\n#b roll, showmethemoney#k (level 21 ~ 30)");
		}
		else if (start == 18)
		{
			self.say("These are the commands of the #rRobot#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b up, stand, rise#k (level 1 ~ 30)\r\n#b stupid, ihateyou, dummy#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b attack, charge#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b good, thelook, charisma#k (level 11 ~ 30)\r\n#b speak, talk, chat, say#k (level 11 ~ 30)\r\n#b disguise, change, transform#k (level 11 ~ 30)");
		}
		else if (start == 19)
		{
			self.say("These are the commands of the #rMini Yeti#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b dance, boogie, shakeit#k (level 1 ~ 30)\r\n#b cute, cutie, pretty, adorable#k (level 1 ~ 30)\r\n#b loveyou, ilikeyou, mylove#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 11 ~ 30)\r\n#b sleep, nap, sleepy, gotobed#k (level 11 ~ 30)");
		}
		else if (start == 20)
		{
			self.say("These are the commands of the #rJr. Balrog#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b liedown#k (level 1 ~ 30)\r\n#b no, bad, badboy, badgirl#k (level 1 ~ 30)\r\n#b loveyou, mylove, ilikeyou#k (level 1 ~30)\r\n#b cute, cutie, pretty, adorable#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b smirk, crooked, laugh#k (level 1 ~ 30)\r\n#b melong#k (level 11 ~ 30)\r\n#b good, thelook, charisma#k (level 11 ~ 30)\r\n#b speak, talk, chat, say#k (level 11 ~ 30)\r\n#b sleep, nap, sleepy#k (level 11 ~ 30)\r\n#b gas#k (level 21 ~ 30)");
		}
		else if (start == 21)
		{
			self.say("These are the commands of the #rBaby Dragon#k. The level displayed next to the command is the level needed for the pet to respond.");
		}
		else if (start == 22)
		{
			self.say("These are the commands of the #rGreen, Red and Blue Dragon#k. The level displayed next to the command is the level needed for the pet to respond.");
		}
		else if (start == 23)
		{
			self.say("These are the commands of the #rBlack Dragon#k. The level displayed next to the command is the level needed for the pet to respond.");
		}
		else if (start == 24)
		{
			self.say("These are the commands of the #rMini Grim Reaper#k. The level displayed next to the command is the level needed for the pet to respond.");
		}
		else if (start == 25)
		{
			self.say("These are the commands of the #rHedgehog#k. The level displayed next to the command is the level needed for the pet to respond.");
		}
		else if (start == 26)
		{
			self.say("These are the commands of the #rSnowman#k. The level displayed next to the command is the level needed for the pet to respond.");
		}
		else if (start == 27)
		{
			self.say("These are the commands of #rKino#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b sleep, nap, sleepy, gotobed#k (level 1 ~ 30)\r\n#b loveyou, mylove, ilikeyou#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 10 ~ 30)\r\n#b meh, bleh#k (level 10 ~ 30)\r\n#b disguise, change, transform#k (level 20 ~ 30)");
		}
		else if (start == 28)
		{
			self.say("These are the commands of #rWhite Duck#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b up, stand#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 1 ~ 30)\r\n#b hug#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b cutie#k (level 1 ~ 30)\r\n#b sleep#k (level 1 ~ 30)\r\n#b smarty#k (level 10 ~ 30)\r\n#b swan#k (level 20 ~ 30)\r\n#b dance#k (level 20 ~ 30)");
		}
	}
}