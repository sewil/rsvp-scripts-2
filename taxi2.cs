using WvsBeta.Game;

// Henesys
public class NpcScript : IScriptV2
{
	private void GoTown(int map, int fee)
	{
		bool askTravel = AskYesNo($"You don't have anything else to do here, huh? Do you really want to go to #b#m{map}##k? It'll cost you #b{fee} mesos#k.");
		
		if (!askTravel)
		{
			self.say("There's a lot to see in this town, too. Come back and find us when you need to go to a different town.");
			return;
		}
		
		if (!Exchange(-fee))
		{
			self.say("You don't have enough mesos. Sorry to say this, but without them, you won't be able to ride the cab.");
			return;
		}
		
		ChangeMap(map);
	}
	
	public override void Run()
	{
		self.say("Hi! I drive the #p1012000#. If you want to go from town to town safely and fast, then ride our cab. We'll gladly take you to your destination for an affordable price.");
		
		if (Job == 0)
		{
			int askStart = AskMenu("We have a special 90% discount for beginners. Choose your destination, for fees will change from place to place.#b",
				(0, " #m104000000# (80 mesos)"),
				(1, " #m102000000# (100 mesos)"),
				(2, " #m101000000# (100 mesos)"),
				(3, " #m103000000# (120 mesos)"));
				
			switch(askStart)
			{
				case 0: GoTown(104000000, 80); break;
				case 1: GoTown(102000000, 100); break;
				case 2: GoTown(101000000, 100); break;
				case 3: GoTown(103000000, 120); break;
			}
		}
		else
		{
			int askStart = AskMenu("Choose your destination, for fees will change from place to place.#b",
				(0, " #m104000000# (800 mesos)"),
				(1, " #m102000000# (1,000 mesos)"),
				(2, " #m101000000# (1,000 mesos)"),
				(3, " #m103000000# (1,200 mesos)"));
				
			switch(askStart)
			{
				case 0: GoTown(104000000, 800); break;
				case 1: GoTown(102000000, 1000); break;
				case 2: GoTown(101000000, 1000); break;
				case 3: GoTown(103000000, 1200); break;
			}
		}
	}
}