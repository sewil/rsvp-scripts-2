using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		self.say("Hmmm... are you raising one of my children by any chance? I perfected a spell that uses Water of Life to breathe life into a doll. People call them #bPets#k. If you have one with you, feel free to ask me whatever you want.");
		
		int start = AskMenu("What do you want to know more about?#b",
			(0, " Tell me more about pets."),
			(1, " How do I train my pet?"),
			(2, " Do pets die too?"),
			(3, " What are the commands for the Brown and Black Kitties?"),
			(4, " What are the commands for the Brown Puppy?"),
			(5, " What are the commands for the Bunnies?"),
			(6, " What are the commands for the Mini Kargo?"),
			(8, " What are the commands for the Black Pig?"),
			(10, " What are the commands for the Husky?"),
			(11, " What are the commands for the Dino Boy and Dino Girl?"),
			(14, " What are the commands for the White Tiger?"),
			(9, " What are the commands for the Panda?"),
			(12, " What are the commands for the Monkey?"),
			(17, " What are the commands for the Robot?"),
			(19, " What are the commands for the Jr. Balrog?"),
			(23, " What are the commands for the Mini Grim Reaper?"),
			(27, " What are the commands for Kino?"),
			(28, " What are the commands for White Duck?")

// Unavailable Pets:
//			(7, " What are the commands for Rudolph and Dasher?"),
//			(13, " What are the commands for the Turkey?"),
//			(15, " What are the commands for the Penguin?"),
//			(16, " What are the commands for the Golden Pig?"),
//			(18, " What are the commands for the Mini Yeti?"),
//			(20, " What are the commands for the Baby Dragon?"),
//			(21, " What are the commands for the Green/Red/Blue Dragons?"),
//			(22, " What are the commands for the Black Dragon?"),
//			(24, " What are the commands for the Hedgehog?"),
		);
		
		if (start == 0)
		{
			self.say("So you want to know more about pets. A long time ago I made a doll, sprayed it with #t4070000# and cast a spell to create a magical animal. I know it sounds unbelievable, but the doll really came to life. They understand people and they're very obedient.");
			self.say("But #t4070000# is scarce, only appearing a little at the base of the World Tree, so I can't give them life for too long... I know, it's very sad... but even if it becomes a doll again, I can always bring it back to life. Be nice while you're with it.");
			self.say("Ah yes! They will respond when you give them special commands. You can scold them, give them affection... it all depends on how you take care of them. They are afraid of getting separated from their owners, so be kind to them, and show them some love. Or they might suddenly \r\nbecome sad...");
		}
		else if (start == 1)
		{
			self.say("Depending on the commands you give them, pets can love, hate and express other types of reactions. If you give them a command and they obey you, their closeness will increase. If you double-click the pet, you can see the closeness, level, fullness, etc.");
			self.say("Talk with the pet, give it attention, and its level of closeness will increase. Eventually, their general level will increase as well. If the level of closeness increases, the general level of the pet will increase along with it. As the general level increases, one day the pet may even start to speak, like a person. So try to raise it. Of course it won't be that easy...");
			self.say("They may just be living dolls, but they live an ordinary life, like us. So they get hungry too. #bFullness#k shows the pet's hunger level. 100 is the max, and as it decreases, the pet will start getting hungry. After a while, they won't even obey your commands and will become aggressive, so be careful.");
			self.say("Oh right! Pet's can't eat people food. My disciple #b#p1012004##k sells #b#t2120000##k in #m100000100#. It's a good idea to keep a supply of food and to feed your pet before it gets too hungry.");
			self.say("Oh... and if you don't feed the pet for a long period of time, it goes home by itself. You can take it out of its house and feed it, but that's not good for its health. Try to feed it regularly, so it doesn't reach that level, alright? I think you can do it.");
		}
		else if (start == 2)
		{
			self.say("Dying... well, they aren't technically ALIVE, they come to life through other means, so I don't know if death is the correct term. They are dolls with magic energy, and the power of \r\n#t4070000# brings objects to life. Of course, while alive, they are like a normal animal...");
			self.say("After some time... that's right, they stop moving. They simply turn back into dolls when the effect of the magic weakens and the #t4070000# dries up. But that doesn't mean it's done forever, because, if you pour #t4070000# on it, it'll come back to life again.");
			self.say("Even if they move again, it's sad to see them totally lifeless. Be kind to them while they're alive, alright? Feed them well, too. Isn't it nice to have a living companion to keep you company that obeys only you?");
		}
		else if (start == 3)
		{
			self.say("These are the commands for #rBrown and Black Kitties#k. The level displayed next to the command is the level the pet needs to be to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b stupid, ihateyou, dummy#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 10 ~ 30)\r\n#b cutie#k (level 10 ~ 30)\r\n#b up, stand, rise#k (level 20 ~ 30)");
		}
		else if (start == 4)
		{
			self.say("These are the commands for #rBrown Puppy#k. The level displayed next to the command is the level the pet needs to be to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b stupid, ihateyou, dummy#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b pee#k (level 1 ~ 30)\r\n#b talk, say, chat#k (level 10 ~ 30)\r\n#b down#k (level 10 ~ 30)\r\n#b stand, up, rise#k (level 20 ~ 30)");
		}
		else if (start == 5)
		{
			self.say("These are the commands for #rPink and White Bunny#k. The level displayed next to the command is the level the pet needs to be to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b stand, up, rise#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b talk, say, chat#k (level 10 ~ 30)\r\n#b hug#k (level 10 ~ 30)\r\n#b sleep, sleepy, gotobed#k (level 20 ~ 30)");
		}
		else if (start == 6)
		{
			self.say("These are the commands for #rMini Kargo#k. The level displayed next to the command is the level the pet needs to be to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b stand, up, rise#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b pee#k (level 1 ~ 30)\r\n#b talk, say, chat#k (level 10 ~ 30)\r\n#b thelook, charisma#k (level 10 ~ 30)\r\n#b down#k (level 20 ~ 30)\r\n#b goodboy, goodgirl#k (level 20 ~ 30)");
		}
		else if (start == 7)
		{
			self.say("These are the commands for #rRudolph and Dasher#k. The level displayed next to the command is the level the pet needs to be to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b stand, up#k (level 1 ~ 30)\r\n#b stupid, ihateyou, dummy#k (level 1 ~ 30)\r\n#b merryxmas#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b talk, say, chat#k (level 11 ~ 30)\r\n#b lonely, alone#k (level 11 ~ 30)\r\n#b cutie#k (level 11 ~ 30)\r\n#b mush, go#k (level 21 ~ 30)");
		}
		else if (start == 8)
		{
			self.say("These are the commands for #rBlack Pig#k. The level displayed next to the command is the level the pet needs to be to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b hand#k (level 1 ~ 30)\r\n#b stupid, ihateyou, dummy#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 10 ~ 30)\r\n#b smile#k (level 10 ~ 30)\r\n#b thelook, charisma#k (level 20 ~ 30)");
		}
		else if (start == 9)
		{
			self.say("These are the commands for #rPanda#k. The level displayed next to the command is the level the pet needs to be to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b chill, relaxa#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b stand, up, rise#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 10 ~ 30)\r\n#b letsplay#k (level 10 ~ 30)\r\n#b meh, bleh#k (level 10 ~ 30)\r\n#b sleep#k (level 20 ~ 30)");
		}
		else if (start == 10)
		{
			self.say("These are the commands for #rHusky#k. The level displayed next to the command is the level the pet needs to be to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b stupid, ihateyou, dummy#k (level 1 ~ 30)\r\n#b hand#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b down#k (level 10 ~ 30)\r\n#b talk, chat, say#k (level 10 ~ 30)\r\n#b stand, up, rise#k (level 20 ~ 30)");
		}
		else if (start == 11)
		{
			self.say("These are the commands for #rDino Boy and Dino Girl#k. The level displayed next to the command is the level the pet needs to be to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b smile, laugh#k (level 1 ~ 30)\r\n#b stupid, ihateyou, dummy#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 10 ~ 30)\r\n#b cutie#k (level 10 ~ 30)\r\n#b sleep, nap, sleepy#k (level 20 ~ 30)");
		}
		else if (start == 12)
		{
			self.say("These are the commands for #rMonkey#k. The level displayed next to the command is the level the pet needs to be to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b rest#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b pee#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b stand, up#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 10 ~ 30)\r\n#b play#k (level 10 ~ 30)\r\n#b melong#k (level 10 ~ 30)\r\n#b sleep, gotobed, sleepy#k (level 20 ~ 30)");
		}
		else if (start == 13)
		{
			self.say("These are the commands for #rTurkey#k. The level displayed next to the command is the level the pet needs to be to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b no, rudeboy, mischief#k (level 1 ~ 30)\r\n#b stupid#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b up, stand#k (level 1 ~ 30)\r\n#b talk, chat, gobble#k (level 10 ~ 30)\r\n#b yes, goodboy#k (level 10 ~ 30)\r\n#b sleepy, birdnap, doze#k (level 20 ~ 30)\r\n#b birdeye, thanksgiving, fly, friedbird, imhungry#k (level 20 ~ 30)");
		}
		else if (start == 14)
		{
			self.say("These are the commands for #rWhite Tiger#k. The level displayed next to the command is the level the pet needs to be to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b rest, chill#k (level 1 ~ 30)\r\n#b stupid, ihateyou, dummy#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 10 ~ 30)\r\n#b actsad, sadlook#k (level 10 ~ 30)\r\n#b wait#k (level 20 ~ 30)");
		}
		else if (start == 15)
		{
			self.say("These are the commands for #rPenguin#k. The level displayed next to the command is the level the pet needs to be to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b up, stand, rise#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 10 ~ 30)\r\n#b hug, hugme#k (level 10 ~ 30)\r\n#b wing, hand#k (level 10 ~ 30)\r\n#b sleep#k (level 20 ~ 30)\r\n#b kiss, smooch, muah#k (level 20 ~ 30)\r\n#b fly#k (level 20 ~ 30)\r\n#b cute, adorable#k (level 20 ~ 30)");
		}
		else if (start == 16)
		{
			self.say("These are the commands for #rGolden Pig#k. The level displayed next to the command is the level the pet needs to be to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 11 ~ 30)\r\n#b loveme, hugme#k (level 11 ~ 30)\r\n#b sleep, sleepy, gotobed#k (level 21 ~ 30)\r\n#b ignore, impressed, outofhere#k (level 21 ~ 30)\r\n#b roll, showmethemoney#k (level 21 ~ 30)");
		}
		else if (start == 17)
		{
			self.say("These are the commands for #rRobot#k. The level displayed next to the command is the level the pet needs to be to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b up, stand, rise#k (level 1 ~ 30)\r\n#b stupid, ihateyou, dummy#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b attack, charge#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b good, thelook, charisma#k (level 11 ~ 30)\r\n#b speak, talk, chat, say#k (level 11 ~ 30)\r\n#b disguise, change, transform#k (level 11 ~ 30)");
		}
		else if (start == 18)
		{
			self.say("These are the commands for #rMini Yeti#k. The level displayed next to the command is the level the pet needs to be to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b dance, boogie, shakeit#k (level 1 ~ 30)\r\n#b cute, cutie, pretty, adorable#k (level 1 ~ 30)\r\n#b loveyou, ilikeyou, mylove#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 11 ~ 30)\r\n#b sleep, nap, sleepy, gotobed#k (level 11 ~ 30)");
		}
		else if (start == 19)
		{
			self.say("These are the commands for #rJr. Balrog#k. The level displayed next to the command is the level the pet needs to be to respond.\r\n#b liedown#k (level 1 ~ 30)\r\n#b no, bad, badboy, badgirl#k (level 1 ~ 30)\r\n#b loveyou, mylove, ilikeyou#k (level 1 ~30)\r\n#b cute, cutie, pretty, adorable#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b smirk, crooked, laugh#k (level 1 ~ 30)\r\n#b melong#k (level 11 ~ 30)\r\n#b good, thelook, charisma#k (level 11 ~ 30)\r\n#b speak, talk, chat, say#k (level 11 ~ 30)\r\n#b sleep, nap, sleepy#k (level 11 ~ 30)\r\n#b gas#k (level 21 ~ 30)");
		}
		else if (start == 20)
		{
			self.say("These are the commands for #rBaby Dragon#k. The level displayed next to the command is the level the pet needs to be to respond.");
		}
		else if (start == 21)
		{
			self.say("These are the commands for #rGreen, Red and Blue Dragon#k. The level displayed next to the command is the level the pet needs to be to respond.");
		}
		else if (start == 22)
		{
			self.say("These are the commands for #rBlack Dragon#k. The level displayed next to the command is the level the pet needs to be to respond.");
		}
		else if (start == 23)
		{
			self.say("These are the commands for #rMini Grim Reaper#k. The level displayed next to the command is the level the pet needs to be to respond.");
		}
		else if (start == 24)
		{
			self.say("These are the commands for #rHedgehog#k. The level displayed next to the command is the level the pet needs to be to respond.");
		}
		else if (start == 25)
		{
			self.say("These are the commands for #rSnowman#k. The level displayed next to the command is the level the pet needs to be to respond.");
		}
		else if (start == 27)
		{
			self.say("These are the commands for #rKino#k. The level displayed next to the command is the level the pet needs to be to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b sleep, nap, sleepy, gotobed#k (level 1 ~ 30)\r\n#b loveyou, mylove, ilikeyou#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 10 ~ 30)\r\n#b meh, bleh#k (level 10 ~ 30)\r\n#b disguise, change, transform#k (level 20 ~ 30)");
		}
		else if (start == 28)
		{
			self.say("These are the commands of #rWhite Duck#k. The level displayed next to the command is the level needed for the pet to respond.\r\n#b sit#k (level 1 ~ 30)\r\n#b bad, no, badboy, badgirl#k (level 1 ~ 30)\r\n#b up, stand#k (level 1 ~ 30)\r\n#b poop#k (level 1 ~ 30)\r\n#b talk, chat, say#k (level 1 ~ 30)\r\n#b hug#k (level 1 ~ 30)\r\n#b loveyou#k (level 1 ~ 30)\r\n#b cutie#k (level 1 ~ 30)\r\n#b sleep#k (level 1 ~ 30)\r\n#b smarty#k (level 10 ~ 30)\r\n#b swan#k (level 20 ~ 30)\r\n#b dance#k (level 20 ~ 30)");
		}
	}
}