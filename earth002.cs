using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string kim1 = GetQuestData(1002900);
		string quest1 = GetQuestData(1003600);
		
		if (kim1 == "" || kim1 == "s")
		{
			self.say("I'm #b#p2050006##k from the Omega Sector, currently on a secret mission. You look like a traveler, and eventhough you seem to be on our side, I can't divulge any information regarding this mission.");
		}
		else if (kim1 == "1")
		{
			if (ItemCount(4000117) < 20)
			{
				self.say("Ahh... I'm so hungry!! Oh hello, are you saying that #b#p2050001##k has completed the #b#t4031100##k of the new robot? I'll need to fill my belly up first before I check out the #b#t4031100##k or anything else for that matter. Please find me #b20 #t4000117#s#k!");
				return;
			}
			
			if (ItemCount(4031100) < 1)
			{
				self.say("Hmmm... are you saying that #b#p2050001##k has completed the \r\n#b#t4031100##k of the new robot? But where is the \r\n#t4031100#? Maybe you lost it on the way here... if so, then please go back to #p2050001#. He put a security device on that baby just in case something like this happened.");
				return;
			}
			
			self.say("Hoh... #b#t4000117##k!!! Great timing, because I've just ran out of food, and I'm still in the middle of a mission. Can you give me the #t4000117#s? I'll need to fill my belly up first before I check out the #b#t4031100##k or anything else for that matter.");
			
			if (!Exchange(0, 4000117, -20, 4031101, 1))
			{
				self.say("Hmmm... are you sure you have #b20 #t4000117#s#k? Or is your etc. inventory full by any chance? Please check your item inventory one more time.");
				return;
			}
			
			AddEXP(2700);
			SetQuestData(1002900, "2");
			self.say("Phew... I feel much better now. But #b#t4031100##k is really amazing! I really want to show #b#p2050007##k this... please find him somewhere around the fields. Oh, and please give him the #b#t4031101##k that I just gave you, too. He told me it was broken, so I fixed it for him.");
		}
		else if (kim1 == "2")
		{
			if (ItemCount(4031101) >= 1)
			{
				self.say("Please find #b#p2050007##k around the fields, and show him the \r\n#b#t4031100##k that #b#p2050001##k gave you, as well as the \r\n#b#t4031101##k that I promised to fix for him. I'm sure he's having problems fighting the aliens without his main weapon.");
				return;
			}
			
			self.say("Oh no... did you lose the #b#t4031101##k that I gave you, by any chance? Good thing I put automatic-returning devices on it in case something like this happened. I'll give you another chance, so please show it to #b#p2050007##k the #b#t4031101##k as well as #b#t4031100##k.");
			
			if (!Exchange(0, 4031101, 1))
			{
				self.say("Hmmm... is your etc. inventory full by any chance? Please check your item inventory one more time.");
				return;
			}
		}
		else if (kim1 == "3")
		{
			self.say("You're the one that brought #b#p2050001#'s#k #b#t4031100##k here and showed it to me. I can't thank you enough for that. How's the robot coming along? I can't wait for the day I get to have my hands on that robot. Now I need to get back to work...");
		}
		else if (kim1 == "e")
		{
			if (Level < 31)
			{
				self.say("You're the one that brought #b#p2050001#'s#k #b#t4031100##k here and showed it to me. I can't thank you enough for that. How's the robot coming along? I can't wait for the day I get to have my hands on that robot. Now I need to get back to work...");
				return;
			}
			
			if (quest1 == "")
			{
				self.say("Arrrrgh... this hurts!!! Whoa, hey! Aren't you the one that brought Dr. Kim's blueprint to me the other day? Thanks a lot for your work that time. What are you doing here? There seems to be more aliens today than there were ever before. Arghhh, ouch ouch!!! This toothache is just killing me!!! Oh, what's up? Do you want to know why I'm like this?");
				self.say("I honestly have a severe case of sweet tooth, and I just can't spend a day without eating any sweets. I guess that's what contributed to my death being a mecca for all bacteria to ruin my teeth. In a way, it's only fair that I'm suffering from a severe case of tooth cavity. I can't go back to the base right now because I am in the middle of work, so can you do me a favor and pick up #b#t2002011##k for me?");
				self.say("So where can you find #b#t2002011##k? Hmmm... well... who can make such thing at the Omega Sector...? Who actually sells it...? I am sorry, but I can't remember this on top of my head. Who can make it? Arrgh, this is causing major headache right now. Please help me!");
				
				SetQuestData(1003600, "s");
			}
			else if (quest1 == "s")
			{
				if (ItemCount(2002011) < 1)
				{
					self.say("Arrrrgh, my teeth are killing me, and I can't take this much longer. Please go to the Omega Sector and get me #b#t2002011##k. I have no idea who makes this or sells this, and frankly, I'm in such pain that I can't think straight. I'll be here waiting for good news from you.");
					return;
				}
				
				self.say("Wahhh! You really found #b#t2002011##k for me!! Really? It's being sold by #b#p2051000##k? Anyway, thank you so much for bringing this to me. Hopefully this will at least alleviate some of that pain. Oh, here's your reward for helping me out here~");
				
				if (!Exchange(0, 2002011, -1, 2048001, 3))
				{
					self.say("Oh... you'll need an empty slot in your use inventory first.");
					return;
				}
				
				AddEXP(3000);
				SetQuestData(1003600, "e");
				QuestEndEffect();
				self.say("Did you get the #b3 #t2048001#s#k? Now that I have #t2002011#, I will have to cut back on sweets and brush my teeth regularly. I'll have to get back to what I was doing, so... thanks a lot for your help. Bye~!");
			}
			else
			{
				self.say("Now that I have #t2002011#, I will have to cut back on sweets and brush my teeth regularly. I'll have to get back to what I was doing, so... thanks a lot for your help. Bye~!");
			}
		}
	}
}