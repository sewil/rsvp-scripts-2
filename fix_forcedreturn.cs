using System;
using System.Linq;
using WvsBeta.Game;
using WvsBeta.Game.GameObjects;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		int[] Maps = {102000100, 102000101, 102000102, 102000103, 102000104, 102000105, 102000106, 102000107, 102000108, 102000109};
		
		foreach (int Map in Maps)
		{
			MapProvider.Maps[Map].ForcedReturn = 220000200;
		}
		
		self.say("Fixed!");
	}
}
