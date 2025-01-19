using WvsBeta.Game;

public class Portal : IScriptV2
{
	public override void Run()
	{
		int count = UserCount(920010930) + UserCount(920010931) + UserCount(920010932);
		
		if (count >= 1)
		{
			Message("Someone is already inside.");
		}
		else
		{
			MapPacket.PlayPortalSE(chr);
			ChangeMap(920010930, "out00");
		}
	}
}