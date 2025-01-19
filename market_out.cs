using WvsBeta.Game;

class Portal : IScriptV2
{
	public override void Run()
	{
		string map = GetQuestData(7600000);
		
		MapPacket.PlayPortalSE(chr);
		
		if (map == "")
		{
			switch(MapID)
			{
				case 100000110: ChangeMap(100000100, "st00"); break;
				case 102000100: ChangeMap(102000000, "st00"); break;
				case 211000110: ChangeMap(211000100, "st00"); break;
				case 220000200: ChangeMap(220000000, "st00"); break;
			}
		}
		else
		{
			ChangeMap(int.Parse(map), "st00");
		}
	}
}