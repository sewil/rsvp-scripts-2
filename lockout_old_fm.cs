
using System;
using System.Linq;
using WvsBeta.Game;
using WvsBeta.Game.GameObjects;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		var otherMaps = new []{
			// henesys entrance
			100000110,
			// perion entrance
			102000100,
			// ludi entrance
			220000200,
			// el nath entrance
			211000110,
		};
		var newEntrance = 211000110;
		
		foreach (var oldMapID in otherMaps) {
			var newMap = oldMapID == newEntrance ? 999999999 : newEntrance;
			for (var i = 0; i <= 12; i++) {
				
				if (!MapProvider.Maps.TryGetValue(oldMapID + i, out var oldMap)) break;
				Console.WriteLine("Patching {0} to point to {1}", oldMap.ID, newMap);
				oldMap.ForcedReturn = newMap;
				oldMap.OnBanishAllUsers();
			}
		}
	}
}
