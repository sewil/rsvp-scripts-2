using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(8020000);
		
		if (DateTime.UtcNow > DateTime.Parse("2021-03-06"))
		{
			self.say("What's going on? I'm Cody, the head programmer of Maplestory!");
			return;
		}
		
		if (DateTime.UtcNow > DateTime.Parse("2021-02-20"))
		{
			self.say("What's going on? I'm Cody, the head programmer of Maplestory! Thanks to everyone's help, it looks like we'll be building the #bGlobal Theme Park#k after all! I don't need anymore help so I'll see you around~");
			return;
		}
		
		if (Level < 20)
		{
			self.say("What's going on? I'm Cody, the head programmer of Maplestory! Right now we're building a #bGlobal Theme Park#k... I sure could use some help, so come talk to me when you're a little stronger!");
			return;
		}
		
		if (quest == "")
		{
			bool start = AskYesNo("Hey, how's it going? I'm Cody, a programmer from #bWizet#k! Right now we are trying to build a #bGlobal Theme Park#k, so I'm looking for help from anyone I can find to make it happen. If you're free, can you gather some materials for me?");
			
			if (!start)
			{
				self.say("Aw that's too bad! We only need a little bit more. If you have a change of heart, please come talk to me.");
				return;
			}
			
			SetQuestData(8020000, "s");
			self.say("Really? Thanks a lot! Okay, if you bring #b100 #t4000003#es#k, #b50 #t4000020#s#k, and #b1 #t4011001##k along with #r1000 mesos#k, we will be able to build the theme park, I'll even give you something special for your hard work. Good luck!");
		}
		else if (quest == "s")
		{
			if (ItemCount(4000003) < 100 || ItemCount(4000020) < 50 || ItemCount(4011001) < 1 || Mesos < 1000)
			{
				self.say("I don't think you have brought everything just yet. I'll need \r\n#b100 #t4000003#es#k, #b50 #t4000020#s#k, and #b1 #t4011001##k along with #r1000 mesos#k so that we can build the #bGlobal Theme Park#k! Remember to deliver these to me before February 20th!");
				return;
			}
			
			self.say("Wow! You really brought everything!! With these, we're one step closer to building our Global Theme Park! Alright, since you've been so helpful I should reward you with something special. Please take it!");
			
			if (!Exchange(-1000, 4000003, -100, 4000020, -50, 4011001, -1, 1302033, 1))
			{
				self.say("Please leave an empty space in your equip. tab for my reward!");
				return;
			}
			
			SetQuestData(8020000, "end");
			QuestEndEffect();
			self.say("What do you think? Do you like the #bMaple Flag#k? Thanks again, this will really help the making of the Global Theme Park. Take care!");
		}
		else if (quest == "end")
		{
			self.say("Hey, how's it going? Isn't it beautiful out here today? Right now, the Global Theme Park is well on its way, thanks to your help. I won't be needing any help right now, but when something comes up, I'll let you know for sure. Til then, take care!");
		}
	}
}