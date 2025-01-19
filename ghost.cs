using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1005000);
		
		if (Level < 25)
		{
			self.say("It's... so... cold.");
			return;
		}
		
		if (quest == "")
		{
			bool start = AskYesNo("Man, why is it so cold here??? Um, hey ... do you know where Dr. Niora is, by any chance? Today's the day I get these bandages off, but I can't see anything. I need to see if the surgery went right. Well, if you got time, can you help me \r\nout??");
			
			if (!start)
			{
				self.say("???? I guess that's a no. Why is it so darn cold around \r\nhere?? And where is Dr. Niora??");
				return;
			}
			
			SetQuestData(1005000, "j0");
			self.say("Wow, thanks a lot. I need to get these bandages off and look at myself in the mirror, but there seems to be no mirror around here. I heard that #b#o2230102##k, that live in the mountains, may give out #b#t4031155##k. Please get me #b20 #t4031155#s#k, I'll greatly appreciate it. By the way, why is it so cold around here????");
		}
		else if (quest == "j0")
		{
			if (ItemCount(4031155) < 20)
			{
				self.say("I don't think you have gathered up #b20 pieces of #t4031155##k yet. Please get them for me ... it is waaaay too cold around here.");
				return;
			}
			
			self.say("Ah ... this may be cracked a little, but I can definitely see myself in it.");
			
			if (!Exchange(0, 4031155, -20))
			{
				self.say("Are you sure you brough all 20..?");
				return;
			}
			
			AddEXP(2300);
			SetQuestData(1005000, "j1");
			self.say("Thank you so much. I need to get out of here as soon as I get these bandages off. It's waaay too cold in here.");
		}
		else if (quest == "j1")
		{
			bool start2 = AskYesNo("What the!!!! No way!!!! What ... what happened here?? Why can't I see myself through the mirror? Did I ... die?????? No way, that cannot be true!! I can't be dead yet!!! Hey there, please help me out once more!!");
				
			if (!start2)
			{
				self.say("How can you be so cold!!! I'll be cursing you forever!!!");
				return;
			}
			
			SetQuestData(1005000, "j2");
			self.say("When you defeat the #b#o2230101#s#k, they gives off \r\n#b#t4000008##k, and from what I've heard, that charm has the power to revive the dead. Please get me the charm. #b100 #t4000008##k and maybe I may come back alive.");
		}
		else if (quest == "j2")
		{
			if (ItemCount(4000008) < 100)
			{
				self.say("You didn't get #b100 #t4000008#s#k? Please hurry ... man, it's cold around here.");
				return;
			}
			
			self.say("Ahh, thanks for getting me the charms. I can't believe you got me all that ... well, I'll have to be honest with you. Even with those charms, I don't think I'll be coming back to life.");
			self.say("Even if I come back alive with these charms, I won't be fully alive, per se, kind of like a zombie. I can't believe I figured this out just now ... but I will never forget the fact that you took great lengths to help me out. Thank you so so much.");
			
			if (!Exchange(0, 4000008, -100, 1102053, 1))
			{
				self.say("Please let me give you a reward... Make some space in your equip. inventory.");
				return;
			}
			
			AddEXP(2300);
			SetQuestData(1005000, "e");
			QuestEndEffect();
			self.say("Do you like the cape that I gave you? It's a cape made of the devastating powers of  the Charms of the Undead. I'll see you ... around ... somewhere ... somehow ...");
		}
		else
		{
			self.say("Well... where should I go now...? What do I do now?");
		}
	}
}