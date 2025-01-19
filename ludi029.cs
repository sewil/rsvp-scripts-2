using WvsBeta.Game;

// 2040033 Neru the Trainer
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string pName = PetName;
		
		if (!CharacterInArea(chr, "0"))
		{
			Message("I'm too far away to talk to him.");
			return;
		}
		
		if (ItemCount(4031128) < 1)
		{
			self.say("My brother told me to take care of the obstacle course, but... since I'm so far from him, I can't help playing around, hehe... since he can't control me, I take the opportunity to relax a little.");
			return;
		}
		
		self.say("Eh, that's my brother's letter! Probably scolding me for thinking I'm not working and stuff... Eh? Ahhh... you followed my brother's advice and trained your pet and got up here, huh? Nice! Since you worked hard to get here, I'll boost your intimacy level with your pet.");
		
		if (pName == "")
		{
			self.say("Hmm... did you really come here with your pet!? These obstacles are for the pets. What are you doing here without it? Get out of here!!");
			return;
		}
		
		if (!Exchange(0, 4031128, -1))
		{
			self.say("Hey, do you really have my brother's letter? Go to your etc. inventory and see if the letter is really there or not!");
			return;
		}
		
		AddCloseness(4);
		self.say("What do you think? Don't you feel closer with your pet? If you have time, train your pet on this obstacle course... with my brother's permission, of course!");
	}
}