using WvsBeta.Game;

// 2041019 Rocky the Repairman
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1004200);
		
		if (Level < 34)
		{
			self.say("It's broken again...and I just fixed this not too long ago! Who did this?! If only I can get my hands on whoever that's responsible for this...ARRGH!!!");
			return;
		}
		
		if (quest == "")
		{
			self.say("Oh no, this is busted again. Oh, hello there. I'm #b#p2041019##k, the head mechanic in charge of fixing all kinds of machinery here at the factory. #b#p2041018#, #p2041020##k, and myself are the three people that are in charge of this place. I can't imagine this place without me, you know!");
			bool start = AskYesNo("Lately we have been experiencing problems here. Our workers are fantastic and all, but we have experienced a sudden increase in broken machines due to a sudden increase in the number of monsters. What we need now is someone like you... can you help us out?");
			
			if (!start)
			{
				self.say("We'll have to look for someone else then. If our machines don't work, then we'll have problem making new stuff, then that's when we get in deep trouble. If you ever feel a change of heart, talk to me.");
				return;
			}
			
			SetQuestData(1004200, "s");
			self.say("Thank goodness. I've been looking long and hard on finding someone that could help us. Like I said before, the machines have been destroyed at an alarming rate, thanks to an increase in the number of monsters. We've been fixing so much that we have run out of materials needed to fix the machines. I would love for you to gather up the items necessary for us to start working again.");
			self.say("What I'll need are #b50 #t4000115#s#k and #b30 #t4003000#s#k. #t4000115# can be found through weird monsters right below this level, but I've never been there before so ...as for #t4003000#, I heard someone in Ludibrium makes it. Thanks!");
		}
		else if (quest == "s")
		{
			if (ItemCount(4003000) < 30 || ItemCount(4000115) < 50)
			{
				self.say("My goodness, the machine is not working again. If you don't gather up those items fast, we may have to shut down the factory. Please get me #b50 #t4000115#s#k and #b30 #t4003000#s#k. We need parts to fix things. Thanks.");
				return;
			}
			
			self.say("Arrgh, it's busted again... hey, you're back! You won't believe how much I've waited for you. Now that you brought the parts needed to fix the machinery, this factory will run just like the way it used to. Thank you for your hard work, and this one is for you!");
			
			if (!Exchange(0, 4000115, -50, 4003000, -30, 2002010, 30))
			{
				self.say("Please make sure you have room in your use inventory, okay?");
				return;
			}
			
			AddEXP(2950);
			SetQuestData(1004200, "e");
			QuestEndEffect();
			self.say("What do you think about the #b30 #t2002010#s#k? This one's given to me by the manager to be more efficient at work, but I already have lots of this. You may need something like this, though, so please put that to good use. Now that I have the stuff ready, it's work time! Now, if you'll excuse me...");
		}
		else if (quest == "e")
		{
			self.say("Oh no, it must be the monsters again. As soon as I fix this, they come rushing back and break things again. Oh hey, how long have you been there? Thanks to the parts you got me, I've been fixing machines here and there, but they seem to break every other day, so I have no time to rest. I gotta go! Bye!");
		}
	}
}