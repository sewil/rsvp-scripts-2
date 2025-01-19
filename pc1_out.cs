using WvsBeta.Game;

class Portal : IScriptV2
{
	public override void Run()
	{
		NpcID = 1052013;
		
		if (AskYesNo("Are you sure want to logout of Premium Road and go back to the Internet Cafe?"))
		{
			MapPacket.PlayPortalSE(chr);
			switch(MapID)
			{
				//Kerning
				case 901000000: ChangeMap(103000007); break;
				case 901010000: ChangeMap(103000007); break;
				case 901020000: ChangeMap(103000007); break;
				case 901030000: ChangeMap(103000007); break;
				case 901080000: ChangeMap(103000007); break;
				
				//Ludi
				case 901040000: ChangeMap(220000309); break;
				case 901050000: ChangeMap(220000309); break;
				case 901060000: ChangeMap(220000309); break;
				case 901070000: ChangeMap(220000309); break;
				case 901090000: ChangeMap(220000309); break;
			}
		}
	}
}