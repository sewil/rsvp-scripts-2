using System;
using WvsBeta.Game;

public class Portal : IScriptV2
{
	private FieldSet FieldSet => chr.Field.ParentFieldSet;
	
	public override void Run()
	{
		var rnd = new Random();
		
		if (GetFieldsetVar("room6_portals") != "set")
		{
			for (int i = 0; i < 16; i++)
			{
				FieldSet.SetVar($"r6way{i}", rnd.Next(0, 4).ToString());
			}
			
			FieldSet.SetVar("room6_portals", "set");
		}
		
		MapPacket.PlayPortalSE(chr);
		
		string[] set1 = {"np00", "np01", "np02", "np03", "np04", "np05", "np06", "np07", "np08", "np09", "np10", "np11", "np12", "np13", "np14", "np15"};
		string[] set2 = {"np16", "np03", "np07", "np11"};
		
		for (int i = 0; i < 64; i++)
		{
			if (GetPortalID() == 24 + i)
			{
				if (GetFieldsetVar($"r6way{i / 4}") == $"{i % 4}")
				{
					ChangeMap(-1, $"{set1[i / 4]}");
				}
				else
				{
					ChangeMap(-1, $"{set2[i / 16]}");
				}
				
				break;
			}
		}
	}
}