using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1002301);
		string RolyPolyCount = GetQuestData(1200);
		
		string quest2 = GetQuestData(1004100);
		
		if (quest == "")
		{
			self.say("I used to work at the Toy Factory inside the Ludibrium Clocktower, but I've been sent here to fix the destroyed parts of Eos Tower. The number of monsters have steadily increased, though, making this job very difficult for myself and other Roly-Poly's.");
		}
		else if (quest == "e")
		{
			if (Level < 35)
			{
				self.say("You're the one that took my picture the other day. Have you met up with all 10 of us Roly Poly's? And you gave those pictures to #b#p2040015##k, right? I think our manager will be relieved after seeing those pictures and concentrate on his work.");
				return;
			}
			
			if (quest2 == "")
			{
				bool start = AskYesNo("Hmm ... this area has been fixed only days ago, and here's another hole ... what is going on here?? Oh, hi! We've met before. What brings you here this time? If you aren't that busy, then can you hear me out?");
				
				if (!start)
				{
					self.say("Ahh, you must be busy right now. I really didn't want help on this, but this is beyond my power. If you have a spare time, please drop by.");
					return;
				}
				
				SetQuestData(1004100, "030");
				self.say("Cool. Just like the other roly-poly workers here, my job is to fix whatever is wrong with the tower, but because of the monsters around this area, all that fixing goes for naught. They keep drilling holes and destroy things in this tower, and I can't do a thing about it.");
				self.say("I hope you can kill off some of the monsters around this area. #b#o3230103##k is the one I have the most trouble with, Please defeat 30 of them, while collecting #b25 #t4000100#s#k that they drop. Thanks.");
			}
			else if (quest2 == "e")
			{
				self.say("You're the one that took my picture the other day. Have you met up with all 10 of us Roly Poly's? And you gave those pictures to #b#p2040015##k, right? I think our manager will be relieved after seeing those pictures and concentrate on his work.");
			}
			else
			{
				if (quest2 != "000")
				{
					self.say("You're back, but I don't think you've taken down all the monsters that I asked of you. Please take down #b30 #o3230103#s#k and bring back #b25 #t4000100#s#k with you. I can't stand these monsters anymore.");
					return;
				}
				
				if (ItemCount(4000100) < 25)
				{
					self.say("You're back. Let's see... you've taken down all 30 #b#o3230103#es#k, but I don't think you've collected all the #b#t4000100#s#k that I asked of you. Please bring back #b25 #t4000100#s#k with you. I can't stand those monsters anymore.");
					return;
				}
				
				self.say("Oh you're back! Seems like you've taken a little longer than I thought you would. Haha. Let's see ... you took down all 30 of the #b#o3230103#es#k, and you also collected 25 #b#t4000100#s#k. Thanks for making the time for me. This may not be much, but please accept it.");
				
				int itemID = 0;
				
				if (Job >= 100 && Job < 200) itemID = 1082035;
				else if (Job >= 200 && Job < 300) itemID = 1082055;
				else if (Job >= 300 && Job < 400) itemID = 1082069;
				else if (Job >= 400 && Job < 500) itemID = 1082047;
				else itemID = 1082002;
				
				if (!Exchange(0, 4000100, -25, itemID, 1))
				{
					self.say("Please leave a space in your equip. tab so I can give you this.");
					return;
				}
				
				AddEXP(4200);
				SetQuestData(1004100, "e");
				self.say($"Did you get the #b#t{itemID}##k? It's a glove I bring out everyday, thinking I may need it for work, but I think you'll need it more than I do. I'll have to get back to work now. Take care!");
			}
		}
		else
		{
			if (quest == "7")
			{
				if (ItemCount(4031078) < 1)
				{
					self.say("Man, so much work. Whoa. Are you here at #b#p2040015##k's request? It looks like you've lost the camera, though. Please go back to Manager Karl and talk to him about the camera.");
					return;
				}
				
				if (ItemCount(4031085) < 1)
				{
					self.say("Oh no, you must have lost the pictures you took with the previous worker. Oh well ... please go revisit the first Roly-Poly worker now. I'm sure you can take another picture with him. I have to get back to work! Sorry!");
					
					SetQuestData(1002301, "s");
					return;
				}
				
				if (RolyPolyCount == "7")
				{
					self.say("Wow, I'm just overwhelmed with all the work I have here. Lately there has been an increase in the number of monsters around Eos Tower, which means lots of places are getting destroyed right now. What's that? You're here at #b#p2040015##k's request? I see ... so you need to take a picture of me. Alright~ take a good picture of me working hard around here!");
					
					if (!Exchange(0, 4031085, -1, 4031086, 1))
					{
						self.say("Please leave a slot open in the etc. tab first.");
						return;
					}
					
					AddEXP(750);
					SetQuestData(1200, "8");
				}
				else
				{
					self.say("Oh no ... did you lose the picture you took with me? We'll have to take another one, then. Please make sure not to lose the picture this time around. Alright, here's a million-dollar pose of me working hard.");
					
					if (!Exchange(0, 4031085, -1, 4031086, 1))
					{
						self.say("Please leave a slot open in the etc. tab first.");
						return;
					}
				}
				
				SetQuestData(1002301, "8");
			}
			else if (quest == "s" || quest == "1" || quest == "2" || quest == "3" || quest == "4" || quest == "5" || quest == "6")
			{
				self.say("Hello there. As you can see, I am working hard here at Eos Tower, fixing up spots here and there. You're here at the request of #b#p2040015##k? Hmmm ... if so, then you may want to visit the first Roly-Poly worker FIRST. He must be working somewhere around this tower.");
			}
			else
			{
				self.say("Oh, hello there. You're the one who's taking pictures of the 10 of us Roly-Poly workers, right? You should go check out some other Roly-Poly worker now. I'm sure that person's working hard somewhere around Eos Tower.");
			}
		}
	}
}