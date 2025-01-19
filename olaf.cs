using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1005300);
		string questW = GetQuestData(1005301);
		string questB = GetQuestData(1005302);
		string questT = GetQuestData(1005303);
		string questM = GetQuestData(1005304);
		
		if (quest == "" && Job == 0)
		{
			self.say("It's not in my nature to babble on and describe everything, so I'll keep it short and sweet. You can choose to become a \r\n#bwarrior, bowman, or a thief#k at #blevel 10#k, or a #rmagician#k at \r\n#rlevel 8#k. To actually become one, however, you'll need to meet SOMEONE at the corresponding towns.");
			self.say("Aren't you curious to find out who to talk to for each job? Talk to #p1022000# of Perion to become a warrior, #p1012100# of Henesys for bowman, #p1052001# of Kerning City for thief, and #p1032001# of Ellinia for magician.");
			self.say("Wasn't it short and sweet? These are veerrry important information, and you must take them to heart! Talk to me once you're ready to take on some questions.");
			
			SetQuestData(1005300, "s");
		}
		else if (quest == "s")
		{
			int ask1 = AskMenu("Here's the first question. I have told you this earlier, but just to make sure. To become either #ba warrior, a bowman, or a thief#k, you'll have to reach at least a certain level. #bWhat level is that?",
				(0, " level 8"),
				(1, " level 1"),
				(2, " level 10"));
			
			if (ask1 == 0)
			{
				self.say("I thought I told you this! You can choose to become a magician after level 8!");
				return;
			}
			
			if (ask1 == 1)
			{
				self.say("Don't you think that's too early to choose an occupation? I already told you this, you'll need to be at least level 10 to become one of those!");
				return;
			}
			
			int ask2 = AskMenu("Great job.\r\nHere's the second question. To become a #bmagician#k, you'll have to reach at least a certain level. #bWhat level is that?",
				(0, " level 8"),
				(1, " level 1"),
				(2, " level 10"));
			
			if (ask2 == 1)
			{
				self.say("I think that's pretty ambitious of you to think you can choose a job at level 1.");
				return;
			}
			
			if (ask2 == 2)
			{
				self.say("Well, you can still become a magician at level 10, but ... that's really late, considering you can become a magician earlier than any other job available.");
				return;
			}
			
			int ask3 = AskMenu("You're doing a good job answering these questions! Are you using a cheat sheet by any chance?\r\nAnyway, I always thought of myself as a warrior material, but then again, every once in a while, I envision myself shooting arrows with a cool bow.\r\n\r\nHere's the next question. #bWhere#k will you have to go in order to become the #bbowman#k?#b",
				(0, " Perion"),
				(1, " Henesys"),
				(2, " Kerning City"),
				(3, " Ellinia"));
				
			if (ask3 == 0)
			{
				self.say("Isn't Perion for warriors? I went to Perion when I was training as a warrior myself.");
				return;
			}
			
			if (ask3 == 2)
			{
				self.say("At Kerning City you may find a legendary thief called Dark Road. Are you interested in becoming a thief?");
				return;
			}
			
			if (ask3 == 3)
			{
				self.say("You know, one would think with all those trees to navigate around and climb in Ellinia, you'll expect magicians to be buff and muscular, but the opposite is true!");
				return;
			}
			
			self.say("Obviously you get what I'm saying! That's good!");
			
			AddEXP(65);
			SetQuestData(1005300, "e");
			QuestEndEffect();
			self.say("I think you've passed the test. Now it's time for you to decide which of the four occupations (warrior, thief, magician, bowman) you're willing to choose. Once you've made up your mind, then come talk to me! I'll help you find your way there!");
		}
		else if (quest == "e")
		{
			if (questW == "" && questB == "" && questT == "" && questM == "" && Job == 0)
			{
				int startJob = AskMenu("Have you made up your mind? Which occupation do you choose?#b",
					(0, " The Path of Warrior"),
					(1, " The Path of Bowman"),
					(2, " The Path of Thief"),
					(3, " The Path of Magician"));
				
				if (startJob == 0)
				{
					bool start = AskYesNo("Have you chosen to become a warrior? Is it based on the way I look as a proud warrior that made the decision for you? In any case, once you're ready, press YES.");
					
					if (!start)
					{
						self.say("You weren't here to become a warrior? That's alright. Whatever occupation you'd like to choose, whenever you're ready, come talk to me.");
						return;
					}
					
					SetQuestData(1005301, "s");
					self.say("Alright. Being a #rwarrior#k emphasizes #bstrength(STR)#k, with some dexterity (DEX) with it. You should head over to \r\n#rPerion#k and see #b#p1022000##k.");
				}
				else if (startJob == 1)
				{
					bool start = AskYesNo("Have you heard of a story of #b#p1012100##k, the marksman extraordinaire? Bowmen have the luxury of performing long-range attacks with great accuracy. What do you think? How about becoming a #bbowman#k?");
					
					if (!start)
					{
						self.say("Once you meet #bHelena#k of #bHenesys#k, that may be enough for you to change your mind. If not, then take a look at other bowmen~ If you need assistance regarding the jobs, talk to me.");
						return;
					}
					
					SetQuestData(1005302, "s");
					self.say("Alright. To meet #b#p1012100##k, you'll need to head over to \r\n#rHenesys#k. If you're not sure of the way, press #rW#k to check out the #bWorld Map#k.");
				}
				else if (startJob == 2)
				{
					bool start = AskYesNo("That's right. #bThief#k requires a significant amount of dexterity (DEX) and luck (LUK). It's a very attractive job, indeed. Would you like to take the path of a thief?");
					
					if (!start)
					{
						self.say("It'll be quite an experience just to go to where #b#p1052001##k\r\nis ... in any case, talk to me when you're ready to choose a path.");
						return;
					}
					
					SetQuestData(1005303, "s");
					self.say("Thief. You'll need to head over to Kerning City in order to meet #r#p1052001##k. Meet him first. In order to become the \r\n#rthief#k, you'll have to be at least at #blevel 10#k. Make sure to take down the monsters that you may face on your way there.");
				}
				else if (startJob == 3)
				{
					bool start = AskYesNo("#b#p1032001##k the Magician...I have never seen him up close \r\nmyself... Someone told me he's always at the Magic Library, reading. What do you think? Do you want to become a magician?");
					
					if (!start)
					{
						self.say("You don't think being a magician fits you? I think it looks fine though ... in any case, talk to me when you're ready to choose a path.");
						return;
					}
					
					SetQuestData(1005304, "s");
					self.say("Okay. Once you meet #b#p1032001##k, tell him I said hi. In order to become a magician, you'll need to head to Ellinia and go to the Magic Library, located at the very top of the town.");
				}
			}
			else if (questW == "s")
			{
				self.say("You haven't met #b#p1022000##k yet? I told you to head over to \r\n#rPerion#k!");
			}
			else if (questB == "s")
			{
				self.say("I thought I told you to meet #b#p1012100##k of #rHenesys#k. You still haven't met her?");
			}
			else if (questT == "s")
			{
				self.say("#b#p1052001##k? He really likes being in the dark. He's at the basement of some cafe in Kerninig City.");
			}
			else if (questM == "s")
			{
				self.say("At the very top of the biggest tree in the biggest forest of Victoria Island, #rEllinia#k, you'll meet #b#p1032001##k. Why? Haven't seen him yet?");
			}
			else
			{
				self.say("Look at me~ Do you want to be strong like me?");
			}
		}
		else
		{
			self.say("Huh? Hey you come here!");
		}
	}
}