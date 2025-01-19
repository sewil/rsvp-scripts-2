
using System;
using System.Linq;
using WvsBeta.Game;
using WvsBeta.Game.GameObjects;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		var fs = MapProvider.Maps[109090000].ParentFieldSet;
		var playersInEvent = fs.UserCount;
		playersInEvent /= 2;
		fs.SetVar("count", playersInEvent.ToString());
		fs.ResetTimeOut(TimeSpan.FromMinutes(10));
	}
}
