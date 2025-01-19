using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		bool askExit = AskYesNo("We're just about to take off. Are you sure you want to get off the ship? You may do so, but then you'll have to wait until the next available flight. Do you wish to get off board?");
		
		if (!askExit)
		{
			self.say("You'll get to your destination in a short while. Talk to other passengers and share your stories to them, and you'll be there before you know it.");
			return;
		}
		
		switch(MapID)
		{
			case 101000301: ChangeMap(101000300); break;
			case 200000112: ChangeMap(200000100); break;
			case 220000111: ChangeMap(220000100); break;
			case 200000122: ChangeMap(200000100); break;
		}
	}
}