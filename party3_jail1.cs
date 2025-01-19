using WvsBeta.Game;

public class Portal : IScriptV2
{
	public override void Run()
	{
		int count = UserCount(920010910) + UserCount(920010911) + UserCount(920010912);
		
		if (count >= 1)
		{
			Message("Someone is already inside.");
		}
		else
		{
			MapPacket.PlayPortalSE(chr);
			ChangeMap(920010910, "out00");
		}
	}
}