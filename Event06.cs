using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string warp = GetQuestData(9000000);
		
		if (ItemCount(4031018) >= 1)
		{
			int askInfo = AskMenu("So you have the #b#t4031018##k. Instead of talking to me, you might want to talk with #p9000006# about exchanging #t4031018# for a prize.#b",
				(0, " Who is #p9000006#?"),
				(1, " Please take me back to where I was before."));
				
			if (askInfo == 0)
			{
				self.say("#b#p9000006##k is the person who will send you to the map where you can exchange your #t4031018# for a prize. He's to the left of where I am now, finding him will be easy.");
				return;
			}
			
			bool askExit = AskYesNo("I recommend exchanging your #b#t4031018##k for a prize before returning. You can still trade in Lith Harbor, however, if you're very busy, you can leave right now. Would you like to return to where you came from right now?");
			
			if (!askExit)
			{
				return;
			}
		}
		else
		{
			self.say("I'm sorry but I'm afraid you didn't win the event. Try it again some other time. You can return to where you were through me.");
		}
		
		RemoveQuest(9000000);
		
		if (warp == "maple") ChangeMap(60000);
		else if (warp == "victoria") ChangeMap(104000000);
		else if (warp == "ossyria") ChangeMap(200000000);
		else if (warp == "ludi") ChangeMap(220000000);
		else ChangeMap(104000000);
	}
}