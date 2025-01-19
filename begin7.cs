using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		bool askTravel = AskYesNo("Take this ship and you'll head off to a bigger continent. For #e150 mesos#n, I'll take you to #bVictoria Island#k. The thing is, once you leave this place, you can't ever come back. What do you think? Do you want to go to Victoria Island?");
		
		if (!askTravel)
		{
			self.say("Hmmm...I guess you still have things to do here.");
			return;
		}

		if (Level < 7)
		{
			self.say("Let's see... I don't think you are strong enough. You'll have to be at least #bLevel 7#k to go to Victoria Island.");
			return;
		}
		
		self.say("Bored of this place? Here... give me #e150 mesos#n first...");
		
		if (!Exchange(-150))
		{
			self.say("What? You're telling me you wanted to travel without any money? You're one weirdo...");
			return;
		}
		
		self.say("Awesome! #e150 mesos#n accepted! Alright, off to #bVictoria \r\nIsland#k!");
		
		ChangeMap(104000000, "maple00");
	}
}