using WvsBeta.Game;

// 2040032 Weaver the Trainer
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (ItemCount(4031128) >= 1)
		{
			self.say("Take that letter, jump over the obstacles with your pet and take the letter to my brother #p2040033#. Take the letter to him and something good will happen to your pet.");
			return;
		}
		
		bool pet = AskYesNo("This is the road where you can go take a walk with your pet. You can just walk around with it, or you can train your pet to go through the obstacles here. If you aren't too close with your pet yet, that may present a problem and he will not follow your command as much... so, what do you think? Wanna train your pet?");
		
		if (!pet)
		{
			self.say("Hmm... too busy right now? If you want to do this later, just come back and talk to me.");
			return;
		}
		
		if (!Exchange(0, 4031128, 1))
		{
			self.say("Your etc. inventory is full! I can't give you the letter unless there is a free space in your inventory. Free up space in your inventory and come talk to me again.");
			return;
		}
		
		self.say("Ok, here's the letter. He wouldn't know I sent you if you just went there straight, so go through the obstacles with your pet, go to the very top, and then talk to #p2040033# to give him the letter. It won't be hard if you pay attention to your pet while going through obstacles. Good luck!");
	}
}