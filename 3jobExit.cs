using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (AskYesNo("You can use the Sparkling Crystal to go back to the real world. Are you sure you want to go back?"))
		{
			if (MapID == 108010301) ChangeMap(102000000);
			else if (MapID == 108010201) ChangeMap(101000000);
			else if (MapID == 108010101) ChangeMap(100000000);
			else if (MapID == 108010401) ChangeMap(103000000);
		}
	}
}