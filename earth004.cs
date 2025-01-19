using WvsBeta.Game;

// 2040018 Black Mesoranger
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(1003100);
		string quest2 = GetQuestData(1003101);
		string quest3 = GetQuestData(1003102);
		
		if (Level < 37)
		{
			self.say("Hello! I'm #b#p2040018##k, in charge of a mission to prevent the aliens from invading this place. It seems like they have been acting up more lately. It's very dangerous around here, so I suggest you run back to the Omega Sector for safety.");
			return;
		}
		
		if (quest1 == "")
		{
			bool start = AskYesNo("Everyday, we devote everything to defeat the aliens, but the number seems to be increasing by day. I don't think I've gotten weaker, you know. Maybe there's a force of evil controlling them... Anyway, I would love to reach out for your help. Would you like to at least listen to the whole story?");
			
			if (!start)
			{
				self.say("Really...? I understand. Everyone seems to get a tad hesitant when dealing with ugly aliens like them. If you ever change your mind, however, I'll be right here.");
				return;
			}
			
			SetQuestData(1003100, "030");
			self.say("Thank you so much. Things have reached the point where I can't handle these aliens by myself, and so I would like you to help me decrease the number of aliens around. Please defeat 30 #b#o4230116#s#k for me. They can be easily found at Kulan Plain.");
			self.say("They are the weakest among the Grays, so that shouldn't be too much of a problem. Grays are very class-driven, and the lowest guys actually approach the Omega Sector as close as they can possibly get. Please take care of them, and then come back to me, okay? Best of luck to you!");
		}
		else if (quest1 == "e")
		{
			if (Level < 43)
			{
				self.say("You're the one that helped me get rid of #b#o4230116##k here at the Kulan Plain. It feels good to find someone like you here at a place where dangerous aliens are a common sight. I'm still investigating on the mastermind behind these aliens. I'm going up against yet another alien, so it's not easy...");
				return;
			}
			
			if (quest2 == "")
			{
				bool start2 = AskYesNo("You're the one that helped me get rid of #b#o4230116##k the other day at the Kulan Plain, right? The research on the force controlling them is just about to be concluded, and it's taken longer than expected, but I'm glad you're here now. I have something else to ask you for a favor. Will that be alright? Would you like to at least take a listen?");
				
				if (!start2)
				{
					self.say("Really...? I understand. Everyone seem to get a tad hesitant when dealing with ugly aliens like them. If you ever change your mind, however, I'll be right here.");
					return;
				}
				
				SetQuestData(1003101, "s");
				self.say("Thanks a lot. I told you about the class-driven nature of the Grays, right? I finally found the high-ranked Gray that is in charge of this area, and it's called #b#o4240000##k. It was hard to find them, because there just aren't many of them.");
				self.say("Anyway, please find #b#o4240000##k, defeat them, and collect #b3 #t4031102#s#k from them, after which you should bring them back to me. I have a feeling #t4031102# contains the kind of secret information we may not be ready to devour and accept. Please come to me as soon as you get done with this.");
			}
			else if (quest2 == "s")
			{
				if (ItemCount(4031102) < 3)
				{
					self.say("I don't think you have gotten #b3 #t4031102#s#k that I asked you to get, just yet. Please find #b#o4240000##k, one of the higher ranks among the Grays, defeat it, and bring #b3 #t4031102##k back to me. I have a feeling #b#t4031102#s#k pack more secrets than we even dare to know.");
					return;
				}
				
				self.say("Hoh... I can't believe you actually gathered up all 3 #b#t4031102#s#k! That's just increadible! It took me days to find out they even exist... I better start tightening up, or I may lose my place here! Anyway, thank you for the job well done. I know this isn't a lot, but please take it!");
				
				if (!Exchange(25000, 4031102, -3))
				{
					self.say("Huh? Are you sure you brought all #b3 #t4031102##k?");
					return;
				}
				
				AddEXP(5800);
				SetQuestData(1003101, "e");
				QuestEndEffect();
				self.say("Thank you so much. Now, let's try to decipher this note. Just as I thought, this is written in alien language, so it's near impossible to understand what's written here, but with a little time, I'm confident that we can decipher this book. I gotta get this going, so I'll see you around!!");
			}
			else if (quest2 == "e")
			{
				if (Level < 45)
				{
					self.say("You're the one that helped me get rid of #b#o4230116##k here at the Kulan Plain, and gathered up #b#t4031102#s#k for me. It feels good to find someone like you here at a place where dangerous aliens are a common sight. I'm still investigating on the mastermind behind these aliens. I'm going up against yet another alien, so it's not easy...");
					return;
				}
				
				if (quest3 == "")
				{
					bool start3 = AskYesNo("Hey, you're the one that helped me eliminate #b#o4230116##k from Kulan Plain, and gathered up #b#t4031102#s#k for me, right?? We just finished deciphering #t4031102#s, and we found some very astounding information inside, and frankly, I don't know how to react. Will you help me out here?");
					
					if (!start3)
					{
						self.say("Really...? I understand. Everyone seem to get a tad hesitant when dealing with ugly aliens like them. If you ever change your mind, however, I'll be right here.");
						return;
					}
					
					SetQuestData(1003102, "s");
					self.say("Thanks for saying yes. The deciphered #b#t4031102#s#k confirm our fears, in that the Grays had a reason for invading Omega Sector and Ludibrium. Apparently, the place where they live is currently filled with lethal dose of contaminants, and, fearing for their lives, decided to move here as the next habitat.");
					self.say("I think it's essential to find out how lethal those contaminants are to them. Please defeat #b#o4230116#, #o4230117#, #o4230118#, and #o4240000##k at Kulan Plain, after which you should take a sample of DNA, each and every one of them.");
				}
				else if (quest3 == "s")
				{
					if (ItemCount(4031103) < 1 || ItemCount(4031104) < 1 || ItemCount(4031105) < 1 || ItemCount(4031106) < 1)
					{
						self.say("I don't think you have gathered the DNA samples of the following Grays: #b#t4031103#, #t4031104#, #t4031105#, and #t4031106##k. Please gather up at least 1 of each, which can be found by defeating the particular Gray. Good luck~!");
						return;
					}
					
					self.say("Whoa... this is it!!! With this sample, the conducted the studies that are taking place in Omega Sector will be reinvigorated with results! I am also at a loss for words for finding someone that is more talented than me at hunting. I'll have to get back on track! Anyway, for your job well done, I'll have to reward you accordingly.");
					
					int selection = 0;
					int[] rewards = {2043002, 2043102, 2043202, 2044002, 2044102, 2044202, 2044302, 2044402, 2043702, 2043802, 2044502, 2044602, 2043302, 2044702};
					
					if (Job < 200)
					{
						selection = AskMenu("Here, please select the scroll of your choice. All success rates are at 10%.#b",
							(0, " #t2043002#"),
							(1, " #t2043102#"),
							(2, " #t2043202#"),
							(3, " #t2044002#"),
							(4, " #t2044102#"),
							(5, " #t2044202#"),
							(6, " #t2044302#"),
							(7, " #t2044402#"));
					}
					else if (Job >= 200 && Job < 300)
					{
						selection = AskMenu("Here, please select the scroll of your choice. All success rates are at 10%.#b",
							(8, " #t2043702#"),
							(9, " #t2043802#"));
					}
					else if (Job >= 300 && Job < 400)
					{
						selection = AskMenu("Here, please select the scroll of your choice. All success rates are at 10%.#b",
							(10, " #t2044502#"),
							(11, " #t2044602#"));
					}
					else if (Job >= 400 && Job < 500)
					{
						selection = AskMenu("Here, please select the scroll of your choice. All success rates are at 10%.#b",
							(12, " #t2043302#"),
							(13, " #t2044702#"));
					}
					
					int itemID = rewards[selection];
					
					if (!Exchange(0, 4031103, -1, 4031104, -1, 4031105, -1, 4031106, -1, itemID, 1))
					{
						self.say("Are you sure you have all the DNA samples? If so, please make some room in your use inventory first.");
						return;
					}
					
					AddEXP(6200);
					SetQuestData(1003102, "e");
					QuestEndEffect();
				}
				else if (quest3 == "e")
				{
					self.say("You're the one that helped me get rid of #b#o4230116##k, gathered up #b#t4031102#s#k, and helped collect the Gray's DNA samples! With this sample, the studies that are taking place in Omega Sector will be reinvigorated with results! I am also at a loss for words for finding someone that is more talented than me at hunting. I'll have to get back on track!");
				}
			}
		}
		else
		{
			if (quest1 != "000")
			{
				self.say("I don't think you have completed my request, just yet. Please defeat #b30 #o4230116#s#k at the Kulan Plain for me.");
				return;
			}
			
			self.say("Unbelievable! You actually defeated 30 out-of-control \r\n#b#o4230116#s#k and came back unscathed! This is much more than I expected, to be honest with you! Were they really that close to the Sector? Anyway, this is so awesome! I know this isn't much, but please take it.");
			
			if (!Exchange(0, 2000011, 100))
			{
				self.say("Please make some room in your use inventory first.");
				return;
			}
			
			AddEXP(5400);
			SetQuestData(1003100, "e");
			QuestEndEffect();
			self.say("What do you think about the #b100 #t2000011#s#k? Thank you so much for your great help, but I believe it's now time to attack this problem right to the core. I may need your help again down the road, so if you have any free time, then please talk to me. Til then, bye~!");
		}
	}
}