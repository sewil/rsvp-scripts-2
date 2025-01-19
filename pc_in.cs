using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		bool askEnter = AskYesNo("Ever wanted to try playing at an Internet Cafe? If you're strong enough, enter here... and you'll probably go to a familiar place. What do you think? Do you want to come in?");
			
		if (!askEnter)
		{
			self.say("You must be out of time, huh? But, if you're interested in the Internet Cafe, you should come in. You may end up in a strange place inside.");
			return;
		}
			
		if (MapID == 103000000)
		{
			if (Level < 15)
			{
				self.say("Hey, hey... I don't think you're strong enough. You can't come in unless you're #blevel 15#k...");
				return;
			}
			
			ChangeMap(103000007, "out00");
		}
		else if (MapID == 220000308)
		{
			if (Level < 30)
			{
				self.say("Sorry buddy, you'll need to be at least #blevel 30#k to come in. Come back again later.");
				return;
			}
			
			ChangeMap(220000309, "out00");
		}
	}
}