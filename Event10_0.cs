using System;
using System.Collections.Generic;
using WvsBeta.Game;
using WvsBeta.Common;
using System.Linq;
using WvsBeta.Game.GameObjects;

public class NpcScript : IScriptV2
{
	private FieldSet FieldSet => chr.Field.ParentFieldSet;
	
	public override void Run()
	{
		int total = FieldSet.Characters.Count();
				
		int half = total / 2;
				
		FieldSet.SetVar("count", half.ToString());
	}
}