using WvsBeta.Game;

class Portal : IScriptV2
{
	public override void Run()
	{
		int partCount = ItemCount(4031092);
		
		if (partCount >= 1)
		{
			if (!Exchange(0, 4031092, -partCount))
			{
				return;
			}
		}
		
		MapPacket.PlayPortalSE(chr);
		SetQuestData(1002500, "f");
		ChangeMap(220020000, "q000");
	}
}