using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string warp = GetQuestData(9000005);
		
		int field;
		
		if (warp == "0") field = 104000000;
		else if (warp == "1") field = 200000000;
		else if (warp == "2") field = 220000000;
		else field = 104000000;
		
		bool askExit = AskYesNo($"Are you sure you want to go back to #b#m{field}##k? Alright but we'll have to hurry. Ready to go?");
		
		if (!askExit)
		{
			self.say($"You must have more to do here. Nothing wrong with waiting to return to #m{field}#. Look at me, I like it so much I wound up living here. Hahaha... well, talk to me anytime you want to go back.");
			return;
		}
		
		ChangeMap(field);
	}
}