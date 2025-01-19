using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string RolyPolyCount = GetQuestData(1200);
		string quest = GetQuestData(1002301);
		string quest2 = GetQuestData(1002302);
		
		if (quest == "")
		{
			self.say("I used to work at the Toy Factory inside the Ludibrium Clocktower, but I've been sent here to fix the destroyed parts of Eos Tower. The number of monsters have steadily increased, though, making this job very difficult for myself and other Roly-Poly's.");
		}
		else if (quest == "e")
		{
			if (quest2 == "")
			{
				bool start = AskYesNo("Hey, aren't you the one that took our picture as a favor from #b#p2040015##k? How's the manager doing? Hmm? well, I have a bit of a problem here. Care to hear me out??");
				
				if (!start)
				{
					self.say("Oh really? Well, that's too bad that you're busy. This shouldn't be too difficult for you, though, so this should not be time-consuming. If you want to do it, then feel free to come talk to me.");
					return;
				}
				
				SetQuestData(1002302, "s");
				self.say("Thank you so much! The thing is... I have this screwdriver that I use for everything, and a few days ago, I lost it on my way here. The problem is, the spot where I lost it is full of monsters roaming around at will.");
				self.say("Just below where I am right now, you may see a monster looking like an octopus called #b#o3230302##k, and one of those guys probably have it. Please take them down and find my screwdriver for me. Don't worry, I'll reward you well for your hard work.");
			}
			else if (quest2 == "s")
			{
				if (ItemCount(4031089) < 1)
				{
					self.say("I don't think you have found my screwdriver yet. Just below where I am right now, you may see #b#o3230302##k. Please take them down and find my screwdriver for me. Don't worry, I'll reward you well for your hard work.");
					return;
				}
				
				self.say("Oh this is it!! I can't believe I got this back!!! Thank you so so much!!! As a thank you, here's a special item for you. I picked it up while roaming around the tower one day, and I don't know exactly what it is for, but please take it!");
				
				if (!Exchange(0, 4031089, -1, 2100016, 3))
				{
					self.say("Please leave some room in your use inventory first.");
					return;
				}
				
				AddEXP(1600);
				SetQuestData(1002302, "e");
				QuestEndEffect();
				self.say("Thanks to you I'll be able to concentrate on my work now. And the item I just gave you probably has the power to summon monsters. You should try it some time. Thanks for your help. See you around!");
			}
			else
			{
				self.say("Thanks to you I'll be able to concentrate on my work now. And the item I just gave you probably has the power to summon monsters. You should try it some time. Thanks for your help. See you around!");
			}
		}
		else
		{
			if (quest == "5")
			{
				if (ItemCount(4031078) < 1)
				{
					self.say("Man, so much work. Whoa. Are you here at #b#p2040015##k's request? It looks like you've lost the camera, though. Please go back to Manager Karl and talk to him about the camera.");
					return;
				}
				
				if (ItemCount(4031083) < 1)
				{
					self.say("Oh no, you must have lost the pictures you took with the previous worker. Oh well ... please go revisit the first Roly-Poly worker now. I'm sure you can take another picture with him. I have to get back to work! Sorry!");
					
					SetQuestData(1002301, "s");
					return;
				}
				
				if (RolyPolyCount == "5")
				{
					self.say("Wow, I'm just overwhelmed with all the work I have here. Lately there has been an increase in the number of monsters around Eos Tower, which means lots of places are getting destroyed right now. What's that? You're here at #b#p2040015##k's request? I see ... so you need to take a picture of me. Alright~ take a good picture of me working hard around here!");
					
					if (!Exchange(0, 4031083, -1, 4031084, 1))
					{
						self.say("Please leave a slot open in the etc. tab first.");
						return;
					}
					
					AddEXP(750);
					SetQuestData(1200, "6");
				}
				else
				{
					self.say("Oh no ... did you lose the picture you took with me? We'll have to take another one, then. Please make sure not to lose the picture this time around. Alright, here's a million-dollar pose of me working hard.");
					
					if (!Exchange(0, 4031083, -1, 4031084, 1))
					{
						self.say("Please leave a slot open in the etc. tab first.");
						return;
					}
				}
				
				SetQuestData(1002301, "6");
			}
			else if (quest == "s" || quest == "1" || quest == "2" || quest == "3" || quest == "4")
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