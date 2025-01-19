using WvsBeta.Game;

public class Portal : IScriptV2
{
	public override void Run()
	{
		MapPacket.PlayPortalSE(chr);
		
		if (MapID == 920010910)
		{
			if (MobCount(920010910) == 0)
				ChangeMap(920010912, "out00");
			
			else
				ChangeMap(920010911, "out00");
		}
		else if (MapID == 920010920)
		{
			if (MobCount(920010920) == 0)
				ChangeMap(920010922, "out00");
			
			else
				ChangeMap(920010921, "out00");
		}
		else if (MapID == 920010930)
		{
			if (MobCount(920010930) == 0)
				ChangeMap(920010932, "out00");
			
			else
				ChangeMap(920010931, "out00");
		}
	}
}