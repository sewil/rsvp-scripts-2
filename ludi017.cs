using WvsBeta.Game;

// 2040027 Fourth Eos Rock, 1st Floor
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (ItemCount(4001020) < 1)
		{
			self.say("There's a rock that allows you to teleport to #b#p2040026##k, but it cannot be activated without the scroll.");
			return;
		}
		
		bool teleport = AskYesNo("You can use the #b#t4001020##k to activate the #b#p2040027##k. Are you going to #b#p2040026##k on the 41st floor?");
		
		if (teleport)
		{
			if (!Exchange(0, 4001020, -1))
			{
				self.say("You cannot activate the #b#p2040027##k without #b#t4001020##k.");
				return;
			}
			
			ChangeMap(221021700, "go00");
		}
	}
}