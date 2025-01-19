using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1002301);
		string RolyPolyCount = GetQuestData(1200);
		
		string quest2 = GetQuestData(1003900);
		
		if (quest == "")
		{
			self.say("I used to work at the Toy Factory inside the Ludibrium Clocktower, but I've been sent here to fix the destroyed parts of Eos Tower. The number of monsters have steadily increased, though, making this job very difficult for myself and other Roly-Poly's.");
		}
		else if (quest == "e")
		{
			if (Level < 40)
			{
				self.say("You're the one that took my picture the other day. Have you met up with all 10 of us Roly Poly's? And you gave those pictures to #b#p2040015##k, right? I think our manager will be relieved after seeing those pictures and concentrate on his work.");
				return;
			}
			
			if (quest2 == "")
			{
				bool start = AskYesNo("How can I help you here? Eos Tower is always full of monsters, so you better be careful, because you never know who's going to attack you. Me? I work here, so I have no choice. Haha ... well, if you have any free time, then do you want to hear my story?");
				
				if (!start)
				{
					self.say("Ahh, you must be busy right now. I really didn't want help on this, but this is beyond my power. If you have a spare time, please drop by.");
					return;
				}
				
				SetQuestData(1003900, "s");
				self.say("Thanks~! Lately the monsters have gotten much angrier than usual, so that makes my job that much harder, as I have to constantly fix the damages they inflict. The problem is, I have been running out of materials to work with, so I haven't been able to do any fixing at this point. I am worried that one day, this tower may fall apart.");
				self.say("Somewhere not far from here, you may run into monsters \r\n#b#o4230109##k and #b#o4230110##k. Please take them down and collect #b30 #t4000101#s#k and #b15 #t4000102#s#k along the way. With those in place, I can definitely get back to work in a hurry.");
			}
			else if (quest2 == "s")
			{
				if (ItemCount(4000101) < 30 || ItemCount(4000102) < 15)
				{
					self.say("I don't think you have gathered up the items yet. Somewhere not far from here, you may run into monsters #b#o4230109##k and #b#o4230110##k. Please take them down and collect #b30 #t4000101#s#k and #b15 #t4000102#s#k along the way. Thanks!");
					return;
				}
				
				self.say("That was incredibly fast! Golems are the kind of monsters we have trouble against, but ... wow! Thank you for gathering up these items for me! Well, I picked this up somewhere around the tower, and it looks like someone lost it. Here, please take it.");
				
				Random rnd = new Random();
				int[] rewards = {1102000, 1102001, 1102002, 1102003, 1102004};
				
				int itemID = rewards[rnd.Next(rewards.Length)];
				
				if (!Exchange(0, 4000101, -30, 4000102, -15, itemID, 1))
				{
					self.say("Please leave some room available in your equip. tab first!");
					return;
				}
				
				AddEXP(5300);
				SetQuestData(1003900, "e");
				QuestEndEffect();
				self.say($"Hopefully the #b#t{itemID}##k will help you on your journey. Now that I have the materials ready to work with, I got to get back to work pronto! Hope you get back to town safely!");
			}
			else if (quest2 == "e")
			{
				self.say("You're the one that took my picture the other day. Have you met up with all 10 of us Roly Poly's? And you gave those pictures to #b#p2040015##k, right? I think our manager will be relieved after seeing those pictures and concentrate on his work.");
			}
		}
		else
		{
			if (quest == "9")
			{
				if (ItemCount(4031078) < 1)
				{
					self.say("Man, so much work. Whoa. Are you here at #b#p2040015##k's request? It looks like you've lost the camera, though. Please go back to Manager Karl and talk to him about the camera.");
					return;
				}
				
				if (ItemCount(4031087) < 1)
				{
					self.say("Oh no, you must have lost the pictures you took with the previous worker. Oh well ... please go revisit the first Roly-Poly worker now. I'm sure you can take another picture with him. I have to get back to work! Sorry!");
					
					SetQuestData(1002301, "s");
					return;
				}
				
				if (RolyPolyCount == "9")
				{
					self.say("Wow, I'm just overwhelmed with all the work I have here. Lately there has been an increase in the number of monsters around Eos Tower, which means lots of places are getting destroyed right now. What's that? You're here at #b#p2040015##k's request? I see ... so you need to take a picture of me. Alright~ take a good picture of me working hard around here!");
					
					if (!Exchange(0, 4031087, -1, 4031088, 1))
					{
						self.say("Please leave a slot open in the etc. tab first.");
						return;
					}
					
					AddEXP(750);
					SetQuestData(1200, "end");
				}
				else
				{
					self.say("Oh no ... did you lose the picture you took with me? We'll have to take another one, then. Please make sure not to lose the picture this time around. Alright, here's a million-dollar pose of me working hard.");
					
					if (!Exchange(0, 4031087, -1, 4031088, 1))
					{
						self.say("Please leave a slot open in the etc. tab first.");
						return;
					}
				}
				
				SetQuestData(1002301, "10");
			}
			else if (quest == "s" || quest == "1" || quest == "2" || quest == "3" || quest == "4" || quest == "5" || quest == "6" || quest == "7" || quest == "8")
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