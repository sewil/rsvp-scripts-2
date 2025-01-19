using System;
using WvsBeta.Game;

class Portal : IScriptV2
{
	public override void Run()
	{
		if (AskYesNo("Beep... beep... you can make your escape to a safer place through me. Beep ... beep ... would you like to leave this place?"))
		{
			ChangeMap(220080000, "st00");
		}
	}
}