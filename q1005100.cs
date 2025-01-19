using WvsBeta.Game;

class Portal : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1005100);
		
		if (quest != "s")
		{
			Message("There's a portal that will take me somewhere, but I can't go in.");
			return;
		}
		
		if (UserCount(900000000) >= 1 || !FieldSet.IsAvailable("Yoota"))
		{
			Message("It seems like someone else is already visiting Utah's Farm.");
			return;
		}
		
		MapPacket.PlayPortalSE(chr);
		FieldSet.Enter("Yoota", new Character[1]{chr}, chr);
	}
}