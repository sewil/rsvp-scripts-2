using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1002301);
		string RolyPolyCount = GetQuestData(1200);
		
		if (quest == "")
		{
			self.say("I used to work at the Toy Factory inside the Ludibrium Clocktower, but I've been sent here to fix the destroyed parts of Eos Tower. The number of monsters have steadily increased, though, making this job very difficult for myself and other Roly-Poly's.");
		}
		else if (quest == "e")
		{
			self.say("You're the one that took my picture the other day. Have you met up with all 10 of us Roly Poly's? And you gave those pictures to #b#p2040015##k, right? I think our manager will be relieved after seeing those pictures and concentrate on his work.");
		}
		else
		{
			if (quest == "8")
			{
				if (ItemCount(4031078) < 1)
				{
					self.say("Man, so much work. Whoa. Are you here at #b#p2040015##k's request? It looks like you've lost the camera, though. Please go back to Manager Karl and talk to him about the camera.");
					return;
				}
				
				if (ItemCount(4031086) < 1)
				{
					self.say("Oh no, you must have lost the pictures you took with the previous worker. Oh well ... please go revisit the first Roly-Poly worker now. I'm sure you can take another picture with him. I have to get back to work! Sorry!");
					
					SetQuestData(1002301, "s");
					return;
				}
				
				if (RolyPolyCount == "8")
				{
					self.say("Wow, I'm just overwhelmed with all the work I have here. Lately there has been an increase in the number of monsters around Eos Tower, which means lots of places are getting destroyed right now. What's that? You're here at #b#p2040015##k's request? I see ... so you need to take a picture of me. Alright~ take a good picture of me working hard around here!");
					
					if (!Exchange(0, 4031086, -1, 4031087, 1))
					{
						self.say("Please leave a slot open in the etc. tab first.");
						return;
					}
					
					AddEXP(750);
					SetQuestData(1200, "9");
				}
				else
				{
					self.say("Oh no ... did you lose the picture you took with me? We'll have to take another one, then. Please make sure not to lose the picture this time around. Alright, here's a million-dollar pose of me working hard.");
					
					if (!Exchange(0, 4031086, -1, 4031087, 1))
					{
						self.say("Please leave a slot open in the etc. tab first.");
						return;
					}
				}
				
				SetQuestData(1002301, "9");
			}
			else if (quest == "s" || quest == "1" || quest == "2" || quest == "3" || quest == "4" || quest == "5" || quest == "6" || quest == "7")
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