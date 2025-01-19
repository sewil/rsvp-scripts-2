using WvsBeta.Game;

// 2050021 Mars
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(1007100);
		
		if (quest1 == "")
		{
			self.say("Hey... I'm really in a bind here, have you seen a #bLaser Gun#k around here?");
			return;
		}
		
		if (quest1 == "s")
		{
			self.say("Hey you..! Can you help me out? Huh? So Medin sent you and I guess he's wondering why I haven't sent any communications back to him. It seems like the aliens have overtaken the Alpha Sector and set up a device to jam our communicators.");
			self.say("Anyway, I would have returned already except one of those aliens stole my #bLaser Gun#k. It's far too dangerous to be wandering around here without a way to defend myself.");
			
			AddEXP(500);
			SetQuestData(1007100, "1");
			self.say("Can you find it for me? One of these aliens should have it. Thanks!!");
		}
		else if (quest1 == "1")
		{
			if (ItemCount(4031143) < 1)
			{
				self.say("Haven't found it yet? The #bLaser Gun#k was taken by a #bGray#k. I'm not sure which one, but I'm sure you'll find it if you take some of them down. Please hurry..!");
				return;
			}
			
			self.say("Oh that's it, you got it back!! You really saved my bacon, okay, I have to get back to work here but please take this as thanks from me.");
			
			if (!Exchange(0, 4031143, -1, 2002011, 10))
			{
				self.say("Are you sure you have the #bLaser Gun#k? If so, please leave some room in your use inventory.");
				return;
			}
			
			AddEXP(4000);
			SetQuestData(1007100, "2");
			self.say("Here, take these #b#t2002011#s#k made by our medic, Dr. Pepper! Oh, and please let #bMedin#k know that I'm OK. I'll have those research materials in no time. Thanks again.");
		}
		else if (quest1 == "2")
		{
			self.say("Please let #bMedin#k know that I'm OK. I'll have those research materials in no time. Thanks again.");
		}
		else
		{
			self.say("Those research materials must be around here \r\nsomewhere...");
		}
	}
}