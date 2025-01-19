using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		self.say("This town is called #b#m60000##k, located on the southeast end of Maple Island. Want to job advance so you can fight much stronger monsters? Then you should board the ship and head to #bVictoria Island#k.");
		self.say("You'll need 150 mesos, but that's not that much money... you can earn that amount by taking down the monsters around the island. You can even sell items at the shops in town.");
	}
}