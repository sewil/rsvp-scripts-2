using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		int platform = AskMenu("Orbis Station has lots of platforms available to choose from. You need to choose the one that'll take you to the destination of your choice. Which platform will you take?#b",
			(0, " The platform to the ship that heads to Ellinia"),
			(1, " The platform to the ship that heads to Ludibrium"));
		
		bool askEnter = false;
		int map = 0;
		
		if (platform == 0)
		{
			askEnter = AskYesNo("Even if you took the wrong passage, you can come back here using the portal. Do you want to go to the #bplatform for the ship going to Ellinia#k?");
			map = 200000110;
		}
		else if (platform == 1)
		{
			askEnter = AskYesNo("Even if you took the wrong passage, you can come back here using the portal. Do you want to go to the #bplatform for the ship going to Ludibrium#k?");
			map = 200000120;
		}
		
		if (!askEnter)
		{
			self.say("Please, be sure of where you're going and head to the platform through me. The departure is scheduled, so don't miss it!");
			return;
		}
		
		ChangeMap(map, "west00");
	}
}