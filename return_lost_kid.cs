using System.Linq;
using WvsBeta.Game;
using WvsBeta.Game.GameObjects;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		var map = MapProvider.Maps[100010000];
		var npcs = map.NPCs.Where(x => x.ID == 1012110).ToArray();
		var i = 0;
		foreach (var npc in npcs) {
			if (i == 0) npc.LimitedName = "";
			else npc.LimitedName = "disappear_now_plz";
			i++;
		}

		OK("NPC Returned");
	}
}