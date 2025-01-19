using System;
using WvsBeta.Game;

class Portal : IScriptV2
{
	public override void Run()
	{
		Random rnd = new Random();
		
		MapPacket.PlayPortalSE(chr);
		
		switch(rnd.Next(0, 27))
		{
			case 0: ChangeMap(109090000, "h00"); break;
			case 1: ChangeMap(109090000, "h00"); break;
			case 2: ChangeMap(109090000, "h00"); break;
			case 3: ChangeMap(109090000, "h00"); break;
			case 4: ChangeMap(109090000, "h00"); break;
			case 5: ChangeMap(109090000, "h00"); break;
			case 6: ChangeMap(109090000, "h01"); break;
			case 7: ChangeMap(109090000, "h01"); break;
			case 8: ChangeMap(109090000, "h01"); break;
			case 9: ChangeMap(109090000, "h01"); break;
			case 10: ChangeMap(109090000, "h01"); break;
			case 11: ChangeMap(109090000, "h01"); break;
			case 12: ChangeMap(109090000, "h02"); break;
			case 13: ChangeMap(109090000, "h02"); break;
			case 14: ChangeMap(109090000, "h02"); break;
			case 15: ChangeMap(109090000, "h02"); break;
			case 16: ChangeMap(109090000, "h02"); break;
			case 17: ChangeMap(109090000, "h03"); break;
			case 18: ChangeMap(109090000, "h03"); break;
			case 19: ChangeMap(109090000, "h03"); break;
			case 20: ChangeMap(109090000, "h03"); break;
			case 21: ChangeMap(109090000, "h03"); break;
			case 22: ChangeMap(109090000, "h04"); break;
			case 23: ChangeMap(109090000, "h04"); break;
			case 24: ChangeMap(109090000, "h05"); break;
			case 25: ChangeMap(109090000, "h06"); break;
			case 26: ChangeMap(109090000, "h07"); break;
		}
	}
}