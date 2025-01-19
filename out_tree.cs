using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		bool askExit = AskYesNo("Have you decorated your tree nicely? It's an interesting experience, to say the least, decorating a Christmas tree with other people. Don't cha think? Oh yeah... are you suuuuure you want to leave this place?");
		
		if (!askExit)
		{
			self.say("You need some more time to decorate the tree, huh? If you want to get out of here, you can come and talk to me~");
			return;
		}
		
		ChangeMap(209000000);
	}
}