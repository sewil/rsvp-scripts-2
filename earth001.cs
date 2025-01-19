using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string kim1 = GetQuestData(1002900);
		string quest1 = GetQuestData(1003200);
		
		if (kim1 == "")
		{
			self.say("Sigh ... This is the first time I'm resting in a long time. I've been up the past few days on missions. The aliens always make noise after dark... anyway, it's the first break I've had in a while, so I need to enjoy this as much as I can. But then again, I should still be aware on guard...");
		}
		else if (kim1 == "s")
		{
			if (ItemCount(4031100) < 1)
			{
				self.say("Hmmm... are you saying that #b#p2050001##k has completed the \r\n#b#t4031100##k of the new robot? But where is the \r\n#t4031100#? Maybe you lost it on the way here... if so, then please go back to #p2050001#. He put a security device on that baby just in case something like this happened.");
				return;
			}
			
			self.say("Hoh... so this is #b#t4031100##k, the blueprint for the new robot that #b#p2050001##k had been diligently working on for the past few months. Hmmm... so when I put my eyes right there, I can see the contents inside, just for a security measure. Amazing, just the kind of stuff that he would make. Okay, now let's see what's inside this baby...");
			
			AddEXP(2400);
			SetQuestData(1002900, "1");
			self.say("Ohhh... this is just incredible! I can't believe he drew up a robot as technologically advanced as this! I knew he was incredible to begin with, but... wow!!! He's much more than I thought! Anyway, please take this #b#t4031100##k and show it to #b#p2050006##k, who should be at a field around Omega Sector. I bet you he'll be just as astounded looking at it as I am right now.");
			self.say("Oh, and... #b#p2050006##k ... he's been out on a mission for a while now and I'm pretty sure he's run out of food as we speak. Please gather up #b20 #t4000117#s#k, which can be found through \r\n#b#o4230116##k the alien, and give them to him. Good luck!");
		}
		else if (kim1 == "1")
		{
			self.say("Please take the #b#t4031100##k that #b#p2050001##k gave you, along with the 20 #b#t4000117#s#k that can be found through \r\n#b#o4230116##k, and give them to #b#p2050006##k, who should be around a field in Omega Sector. He's probably crazy hungry right now, so please find him ASAP.");
		}
		else if (kim1 == "2" || kim1 == "3")
		{
			self.say("You're the one that brought #b#p2050001#'s#k #b#t4031100##k here and showed it to me. I can't thank you enough for that. How's the robot coming along? I can't wait for the day I get to have my hands on that robot. Now, I need to finish the training, so please excuse me.");
		}
		else if (kim1 == "e")
		{
			if (Level < 35)
			{
				self.say("You're the one that brought #b#p2050001#'s#k #b#t4031100##k here and showed it to me. I can't thank you enough for that. How's the robot coming along? I can't wait for the day I get to have my hands on that robot. Now, I need to finish the training, so please excuse me.");
				return;
			}
			
			if (quest1 == "")
			{
				bool start = AskYesNo("Hmmm... this is troubling. It seems like there is a group of people that chose to ignore the danger that lies with the aliens, and instead have begun to SUPPORT them. If this is true, then we're in deep trouble, and I'll really need help from someone like you. Will you help us out one more time?");
				
				if (!start)
				{
					self.say("You must be really busy right now, but this is unlike any other emergency we've experienced, and we really need help from someone like you. If you ever want to change your mind, please talk to me.");
					return;
				}
				
				SetQuestData(1003200, "s");
				self.say("Thank you so much. Like I previously mentioned, a few alien supporters have built #bDogon's HQ#k at a hidden area around Omega Sector, and have been providing classified information to the aliens. I knew the aliens have been becoming more powerful by day, but this...");
				self.say("The acts like this takes away the liberty and freedom of the innocent people living in this world. We need to find their hidden base and find an item that can be used as an evidence. I'm sure there's a #breport#k that's being sent to the aliens by the alien-supporters. I'll be here waiting for you! Good luck!");
			}
			else if (quest1 == "s")
			{
				if (ItemCount(4031107) < 1)
				{
					self.say("Hmmm... I don't think you have found #bDogon's HQ#k, where a group of alien-supporters use it as their home base to provide information to aliens. Please find their secret HQ, and bring back a #breport#k they write to the aliens as evidence. It should be inside a very solid box. Good luck to you!");
					return;
				}
				
				self.say("Oh... you must have really found #bDogon's HQ#k. I was hoping such would be nothing more than rumors... I guess not. We really have a group of alien-supporters that provide information beneficial to aliens. This is very troubling... anyway, since you found their base, as well as bringing the #breport#k here with you, I can't express enough thanks for your hard work. As a reward, here's some money, as well as a pair of earrings.");
				
				if (!Exchange(15000, 4031107, -1, 1032008, 1))
				{
					self.say("Oh... you'll need an empty slot in your equip. inventory first.");
					return;
				}
				
				AddEXP(5700);
				SetQuestData(1003200, "e");
				QuestEndEffect();
				self.say("Thank you so much for your help. All we have to do now is to examine the #b#t4031107##k that you brought here. I wonder what's inside... anyway, I'll have to get back to work now, so if you'll excuse me... I'll see you around!");
			}
			else
			{
				self.say("Thank you so much for your help. All we have to do now is to examine the #b#t4031107##k that you brought here. I wonder what's inside... anyway, I'll have to get back to work now, so if you'll excuse me... I'll see you around!");
			}
		}
	}
}