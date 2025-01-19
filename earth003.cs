using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string kim1 = GetQuestData(1002900);
		string quest1 = GetQuestData(1003700);
		
		if (kim1 == "" || kim1 == "s" || kim1 == "1")
		{
			self.say("I'm #b#p2050007##k from the Omega Sector, currently on a secret mission. You look like a traveler, and eventhough you seem to be on our side, I can't divulge any information regarding this mission.");
		}
		else if (kim1 == "2")
		{
			if (ItemCount(4031101) < 1)
			{
				self.say("Well, I was sent here on a mission, and one day, my precious #b#t4031101##k broke down on me. I gave it to #b#p2050006##k so he can fix it up quickly, but I'm guessing the fixing has taken longer than expected, and thus, I do not have a weapon to defend myself with. It's quite dangerous around here without a trusty weapon... I hope I can get that really soon...");
				return;
			}
			
			if (ItemCount(4031100) < 1)
			{
				self.say("Hmmm... are you saying that #b#p2050001##k has completed the \r\n#b#t4031100##k of the new robot? But where is the \r\n#t4031100#? Maybe you lost it on the way here... if so, then please go back to #p2050001#. He put a security device on that baby just in case something like this happened.");
				return;
			}
			
			self.say("Oh wow, you have my #b#t4031101##k! I am guessing you ran into #b#p2050006##k first. Anyway, it's been tough for me to handle all these aliens by myself. Now, let's see if this gun is fixed right.");
			
			if (!Exchange(0, 4031101, -1, 2030011, 7))
			{
				self.say("Hmmm... is your use inventory full by any chance? Please check your item inventory one more time.");
				return;
			}
			
			AddEXP(3000);
			SetQuestData(1002900, "3");
			self.say("Whoa... this #b#t4031101##k ... it seems like it's actually working better than it did before it broke. And this... this must be the #b#t4031100##k of the new robot that #b#p2050001##k had been working so hard on. This is incredible!! I truly believe with this robot, the aliens will be much easier to handle.");
			self.say("Must have been tough for you to show all 3 of us the \r\n#b#t4031100##k. All you need to do now is to report all this to #b#p2050001##k. The #b#t2030011##k that I just gave you is an item that allows you to teleport straight to the Command Center in Omega Sector. This will help you report this much easier.");
		}
		else if (kim1 == "3")
		{
			self.say("Great work showing all 3 of us the #b#t4031100##k! Now all you need to do is report all this to #b#p2050001##k. Use the \r\n#b#t2030011##k that I gave you to teleport straight to the Command Center in the Omega Sector. Good luck~!");
		}
		else if (kim1 == "e")
		{
			if (Level < 47)
			{
				self.say("You're the one that brought #b#p2050001#'s#k #b#t4031100##k here and showed it to me. I can't thank you enough for that. How's the robot coming along? I can't wait for the day I get to have my hands on that robot. Now I need to get back to work...");
				return;
			}
			
			if (quest1 == "")
			{
				self.say("Hello, there... You look quite familiar... if I'm not mistaken, aren't you the one that showed me Dr. Kim's blueprint the other day? Am I right? Haha... no one can beat me in terms of remembering people. The problem is, I have really a hard time remembering DIRECTIONS, and thus, I get lost very easily...");
				self.say("Can you help me out? The mission that's given to me this time is to chase #b#o4240000##k, but even after knowing their current location, I keep getting lost trying to chase them down, making my mission nearly impossible to conquer. Please help me gather up #b5 #t4000125#s#k, which can be obtained by defeating #b#o4240000##k. Please help me.");
				
				SetQuestData(1003700, "s");
			}
			else if (quest1 == "s")
			{
				if (ItemCount(4000125) < 5)
				{
					self.say("I'm beyond terrible at directions, and I need to get this mission completed, so please help me find #b#o4240000##k and collect #b5 #t4000125#s#k for me. I feel like with that, I'll be having a much easier time chasing them down. Thanks, and I'll be waiting for you here.");
					return;
				}
				
				self.say("I knew you'd have no trouble doing this. #b5 #t4000125#s#k, indeed. This will do just fine. For your hard work, I feel obligated to give you something nice. I got these from the Sector, and I'll give you some of them. Please take it!");
				
				if (!Exchange(0, 4000125, -5, 2020008, 100))
				{
					self.say("Oh... you'll need an empty slot in your use inventory first.");
					return;
				}
				
				AddEXP(5200);
				SetQuestData(1003700, "e");
				QuestEndEffect();
				self.say("How do you like the #b100 #t2020008#s#k? I better start chasing #o4240000# with the newly-received #b#t4000125##k, right now. These guys are difficult to find, and they seem to pop up everywhere, so this should be a life-saver for me. I gotta get to work now, so if you'll excuse me...");
			}
			else
			{
				self.say("I better start chasing #o4240000# with the newly-received \r\n#b#t4000125##k, right now. These guys are difficult to find, and they seem to pop up everywhere, so this should be a life-saver for me. I gotta get to work now, so if you'll excuse me...");
			}
		}
	}
}