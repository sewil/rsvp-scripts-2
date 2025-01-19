using WvsBeta.Game;
using WvsBeta.Game.GameObjects;

class Portal : IScriptV2
{
	public override void Run()
	{
		MapPacket.PlayPortalSE(chr);
		SetQuestData(7600000, MapID.ToString());
		ChangeMap(MapProvider.CurrentFM, "st00");
	}
}