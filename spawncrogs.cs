using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		foreach (var contis in ContinentMan.Instance.ContiMoveArray)
		{
			if (contis.Event == false) contis.ResetEvent();
		}
	}
}