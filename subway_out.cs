using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (AskYesNo("This device is connected to the outside. Will you give up and leave this place? You'll have to start from the beginning the next time you come here..."))
		{
			ChangeMap(103000100);
		}
	}
}