using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (ItemCount(4001019) < 1)
		{
			self.say("Here's an #b#p2012015##k that allows you to teleport to where #b#p2012014##k is, but you can't activate it without the scroll.");
			return;
		}
		
		bool teleport = AskYesNo("You can use #b#t4001019##k to activate #b#p2012015##k. Will you teleport to where #b#p2012014##k is?");
		
		if (teleport)
		{
			if (!Exchange(0, 4001019, -1))
			{
				self.say("Unable to activate #b#p2012015##k because you don't have #b#t4001019##k.");
				return;
			}
			
			ChangeMap(200080200);
		}
	}
}