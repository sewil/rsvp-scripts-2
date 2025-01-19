using System;
using System.Collections.Generic;
using WvsBeta.Game;
using WvsBeta.Common;
using System.Linq;
using WvsBeta.Game.GameObjects;

class Portal : IScriptV2
{
	private FieldSet FieldSet => chr.Field.ParentFieldSet;
	
	public override void Run()
	{
		if (FieldSet.GetVar("count") != "clear")
		{
			int remaining = int.Parse(FieldSet.GetVar("count"));
			if (remaining > 0) remaining--;
			else if (remaining < 0) remaining = 0;
			
			if (remaining == 0)
			{
				FieldSet.Characters.ForEach(character =>
				{
					Message(character, "Half of the participants have cleared the quest! You have one minute left to reach the top.");
				});
				
				FieldSet.ResetTimeOut(TimeSpan.FromSeconds(60));
				FieldSet.SetVar("count", "clear");
			}
			else
			{
				FieldSet.SetVar("count", remaining.ToString());
			}
		}
		
		MapPacket.PlayPortalSE(chr);
		ChangeMap(109050000);
	}
}