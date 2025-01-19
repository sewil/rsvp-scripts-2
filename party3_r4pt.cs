using System;
using WvsBeta.Game;

public class Portal : IScriptV2
{
	private FieldSet FieldSet => chr.Field.ParentFieldSet;
	
	public override void Run()
	{
		var rnd = new Random();
		if (GetFieldsetVar("Party5", "room4_portals") != "set")
		{
			FieldSet.SetVar("r4way0", rnd.Next(0, 3).ToString());
			FieldSet.SetVar("r4way1", rnd.Next(0, 3).ToString());
			FieldSet.SetVar("room4_portals", "set");
		}
		
		MapPacket.PlayPortalSE(chr);
		
		for (int i = 0; i < 6; i++)
		{
			if (GetPortalID() == 11 + i)
			{
				if (GetFieldsetVar("Party5", $"r4way{i / 3}") == $"{i % 3}")
				{
					ChangeMap(-1, $"np0{i / 3}");
				}
				else
				{
					ChangeMap(-1, "np02");
				}
				
				break;
			}
		}
	}
}