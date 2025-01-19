using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(300);
		
		if (quest == "")
		{
			bool start = AskYesNo("Hello there! I think you're still having trouble adjusting to life in Maple World.\r\nI'm going to be giving you a brief rundown on this place, then will give you a Maple Quiz. Once you answer them all correct, I'll be giving you a small present as a sign of appreciation, something that'll come in handy here.\r\nWhat do you think? Do you want to take a crack at The Maple Quiz?");
			
			if (!start)
			{
				self.say("Are you worried you're still a beginner in MapleStory? \r\nHmmm ... even with that, you'll be learning a lot through my Maple Quiz. You should at least try it!!");
				return;
			}
			
			SetQuestData(300, "s");
			self.say("Hehe ... I'll have to warn you, don't underestimate the questions for the quiz. There's still a lot to learn about this place, you know. Well, I'll give you a quick rundown on the quiz. It'll be very quick, so you better listen carefully, because it'll all be on the quiz.");
			self.say("Have you tried hunting there at the hunting ground? What key did you press to attack the monsters? Didn't you press #bCtrl for attack#k and #bAlt to jump#k? And you did press #bz to pick up the items#k, right?\r\nYou can also use the #rKey Config#k, located on the bottom right corner of the game, to recalibrate the buttons to your liking. Phew, I guess I got too carried away with the explanations. You'll be picking up these in no time at the Maple Island.");
			self.say("Now here's a brief description on the most important part of the game, the Job Advancement.\r\nTo become a more powerful traveler, you'll need to have a job. To obtain a job, you'll have to leave this place, the Maple Island, and head over to Victoria Island instead. \r\nYou'll need to be at least at level #b10#k to become either a warrior, a bowman, or a thief. To become a magician, however, you'll need to be only at level #b8#k. Each occupation has its plus's and minus's so choose carefully.");
			self.say("I didn't tell you EVERYTHING you'll need to know for the quiz, so please make sure to focus for the quiz. Now, shall we get this started?");
		}
		else if (quest == "s")
		{
			int ask1 = AskMenu("What do you press to open up the item inventory?#b",
				(0, " I  "),
				(1, " K  "),
				(2, " S  "),
				(3, " E  "));
			
			if (ask1 != 0)
			{
				if (ask1 == 1) self.say("K is for the Skill Window. You'll be able to use skills once you get yourself a job. Don't you remember the shortcut key for the i-tem inventory?");
				if (ask1 == 2) self.say("No, no, no. S is to check out your ability stats and the AP's. Come on, think!!");
				if (ask1 == 3) self.say("Eh? E is to check out the equipments you're donning and the ones you'd like to take off, so E is definitely not it.");
				return;
			}
			
			self.say("That's right!! To open up the item inventory, you press #rI#k.");
			
			AddEXP(2);
			SetQuestData(300, "1");
			self.say("Alright, talk to me when you're ready to take on the next question.");
		}
		else if (quest == "1")
		{
			int ask2 = AskMenu("Can you wear an item just by double-clicking it with your mouse?#b",
				(0, " Oh yes"),
				(1, " No way."));
			
			if (ask2 == 1)
			{
				self.say("You'll have to try it for yourself. Press E, then take off an item by double-clicking it. Then, double-click the item from the item inventory (I) to put it back on.");
				return;
			}
			
			self.say("Yup, you can wear an item just by double clicking it from your inventory. If you can't put it on, please check and see if your character matches or exceeds the level limit and the ability point requirements each item is assigned to.");
			
			AddEXP(4);
			SetQuestData(300, "2");
			self.say("The questions I'm giving out aren't terribly difficult! Even if you don't answer it right the first time, just listen to my explanations carefully and you'll be able to pass it.\nTalk to me when you're ready for the 3rd question.");
		}
		else if (quest == "2")
		{
			int ask3 = AskMenu("What do you press to open up your equipment inventory?#b",
				(0, " E  "),
				(1, " S  "),
				(2, " I  "));
			
			if (ask3 != 0)
			{
				if (ask3 == 1) self.say("S is to check out your stats and AP's. Please remember that.");
				if (ask3 == 2) self.say("I is to check out your item inventory.");
				return;
			}
			
			self.say("That's right! To check out the equipments you're wearing, just press E.");
			
			AddEXP(6);
			SetQuestData(300, "3");
			self.say("Alright! You're on question number 4. There are 7 questions total for this Maple Quiz. Talk to me when you're ready.");
		}
		else if (quest == "3")
		{
			int ask4 = AskMenu("What do you press to pick up an item on the ground?#b",
				(0, " X  "),
				(1, " S  "),
				(2, " I  "),
				(3, " Z  "));
			
			if (ask4 != 3)
			{
				if (ask4 == 0) self.say("Once you see a chair or a bench you can sit on, you can do just that. Unfortunately, you won't find any chairs in Maple Island that you can sit on. Head over to Victoria Island to sit on some chairs, and when you find one, make sure to press X. You'll be able to tell that you're recovering much faster by sitting as opposed to just standing still.");
				if (ask4 == 1) self.say("You can raise your ability stats using the AP's that you earn after every level-up. To check out the AP's, simply press S.");
				if (ask4 == 2) self.say("I is used to check out your item inventory. It is one of the most useful functions in the game, one that'll enable you to check out the items you've collected.");
				return;
			}
			
			self.say("That's correct. #bZ#k is used to pick up items on the ground dropped by the monsters. The other key you can use to pick up items would be #b0 on the number pad#k.\r\nAs for the seldom-used X, you can use that to sit on a chair. Once you head over to Victoria Island, you'll find some chairs you can sit on. You should try it, since you can recover much faster by sitting as opposed to just standing still!");
			
			AddEXP(10);
			SetQuestData(300, "4");
			self.say("You're inching closer and closer towards making the job advancement. I'm anxious to see which job you're going to take.\r\nNow, talk to me when you're ready for the 5th question.");
		}
		else if (quest == "4")
		{
			int ask5 = AskMenu("In order to make the job advancement as either a warrior, a bowman, or a thief, you'll have to be at least level 10 to do so. What level do you have to be in order to make the job adv. as a magician?#b",
				(0, " 10 "),
				(1, " 8  "));
			
			if (ask5 == 0)
			{
				self.say("You'll need to be at least level 10 in order to make the job advancement as either a warrior, a bowman, or a thief, but you can make the job adv. as a magician earlier than that.");
				return;
			}
			
			self.say("That is correct!! You'll need to be at least level 10 in order to make the job advancement as either a warrior, a bowman, or a thief. To become a magician, however, you only need to be at level 8. Head over to Victoria Island, go to a magician town called Ellinia, and look for Hines, the chief magician that'll lead you towards becoming a magician yourself.");
			
			AddEXP(10);
			SetQuestData(300, "5");
			self.say("Wow, you're pretty good at this. Are you assigning your Ability Points (AP) well? You know you get those after leveling up, right? You'll need to know how to assign your AP's well in order to become a powerful hunter. Talk to me when you're ready for the 6th question.");
		}
		else if (quest == "5")
		{
			int ask6 = AskMenu("Every time you level up, you can raise your character's ability stats. How many ability points (AP) are you awarded after every level up?#b",
				(0, " 2 points"),
				(1, " 10 points"),
				(2, " 5 points"));
			
			if (ask6 != 2)
			{
				if (ask6 == 0) self.say("Come on, you get more than 2 measly points~ you should check out the AP's you get after leveling up by pressing S.");
				if (ask6 == 1) self.say("Nope, not 10 points. Press S to find out~");
				return;
			}
			
			self.say("That's right. Every time you level up, you'll be awarded #r5 AP's (Ability Point)#k, which can be used to raise your character's abilities. Press #bS#k after every level up to check out your character's abilities and the AP's. Make sure to assign those points well for maximum results.");
			
			AddEXP(10);
			SetQuestData(300, "6");
			self.say("Alright, here's the LAST QUESTION. Talk to me when you're ready.");
		}
		else if (quest == "6")
		{
			int ask7 = AskMenu("Last question, and this is also the most important one. You can only make the job advancement at Victoria Island, but you're currently at Maple Island. Where do you have to go in order to get on the ride to Victoria Island?#b",
				(0, " Southperry"),
				(1, " Amherst"),
				(2, " No way I can get there"));
			
			if (ask7 != 0)
			{
				if (ask7 == 1) self.say("You won't find any ports at Amherst. Head over to the only place in Maple Island with a port to catch the ride to Victoria Island.");
				if (ask7 == 2) self.say("You won't be able to come back here once you leave this place, but as for leaving ...");
				return;
			}
			
			self.say("That's absolutely correct. Head over to Southperry and get on the #rship#k that heads to Victoria Island.");
			
			AddEXP(20);
			SetQuestData(300, "end");
			QuestEndEffect();
			self.say("Once you get to Victoria Island, the first thing you'd want to do is make the job advancement, right?\r\nYou should set your level just right so you can make the job adv with the job of your choice. Head to Perion to become a warrior, Henesys for bowman, Kerning City for thief, and Ellinia for magician. If you're curious on where you are on the island, #bpress W for the world map#k. Always be aware of where you are at all times.\r\nAlright, your journey should get much more interesting now! Happy Mapling!!");
		}
		else if (quest == "end")
		{
			self.say("This town is called #b#m1010000##k and it's located on the northeast end of Maple Island. You know Maple Island is only for beginners, right? It's a good thing there are only weak monsters around here.");
			self.say("If you want to get stronger, you should travel to #b#m60000##k. There's a port there with a gigantic ship. Take that ship and you'll find yourself on #bVictoria Island#k. It's much bigger than this little island.");
			self.say("On Victoria Island, you'll be able to choose your job. There's a place called #bPerion#k...? I heard about it from a friend, there's a desolate town in the mountains where warriors live. I wonder what it's like.");
		}
	}
}