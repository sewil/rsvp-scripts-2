using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		bool askExit = AskYesNo("Do you want to get out of here? Well... this place can really wear you down... I'm used to it, I'm fine. Anyway, remember that if you leave here through me, you will have to start over again. Still want to go?");
		
		if (!askExit)
		{
			self.say("Isn't it awful that you have to restart the whole thing? Keep trying... the more you explore, the better you will know this whole place. Soon you'll be able to walk around here with your eyes closed hehe.");
			return;
		}
		
		ChangeMap(101000000);
	}
}