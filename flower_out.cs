using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		bool askExit = AskYesNo("Once I lay my hand on the statue, a strange light covers me and it feels like I am being sucked into somewhere else. Is it okay to go back to #m105040300#?");
		
		if (!askExit)
		{
			self.say("Once I take my hand off the statue, it returns to normal, as if nothing happened.");
			return;
		}
		
		ChangeMap(105040300);
	}
}