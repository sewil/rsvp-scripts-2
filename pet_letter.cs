using WvsBeta.Game;

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
		
		if (ItemCount(4031035) < 1)
		{
			self.say("My brother told me to take care of the obstacle course, but... since I'm so far from him, I can't resist, I want to mess around... hehe. I don't feel the same personally, I think I can relax for a few minutes.");
			return;
		}
		
		self.say("Eh, That's my brother's letter! Probably scolding me because he thinks I'm not working... Eh? Ahhh... you followed my brother's advice and trained your pet and got up here, huh? Nice! Since you worked so hard to get here, I'll boost your intimacy level with your pet.");
		
		if (pName == "")
		{
			self.say("Hmmm... did you really come here with your pet? These obstacles are for animals. What are you doing here without it? You're the one playing!!!");
			return;
		}
		
		if (!Exchange(0, 4031035, -1))
		{
			self.say("Hey, do you really have my brother's letter? Go to your etc. inventory and see if the letter is really there or not!");
			return;
		}
		
		AddCloseness(2);
		self.say("What do you think? Don't you feel closer with your pet? If you have time, train your pet on this obstacle course again... of course, with my brother's permission.");
	}
}