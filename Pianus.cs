using WvsBeta.Game;

class Portal : IScriptV2
{
	public override void Run()
	{
		if (UserCount(230040420) >= 10)
		{
			Message("The Cave of Pianus is currently full. Please come back later.");
			return;
		}
		
		MapPacket.PlayPortalSE(chr);
		ChangeMap(230040420);
	}
}