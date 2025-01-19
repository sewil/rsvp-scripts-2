using WvsBeta.Game;

// 2040024 First Eos Rock, 100th Floor
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (ItemCount(4001020) < 1)
		{
			self.say("There's a rock that allows you to teleport to #b#p2040025##k, but it cannot be activated without the scroll.");
			return;
		}
		
		bool teleport = AskYesNo("You can use the #b#t4001020##k to activate the #b#p2040024##k. Will you teleport to the 71st floor to #b#p2040025##k?");
		
		if (teleport)
		{
			if (!Exchange(0, 4001020, -1))
			{
				self.say("You cannot activate the #b#p2040024##k without #b#t4001020##k.");
				return;
			}
			
			ChangeMap(221022900, "go00");
		}
	}
}