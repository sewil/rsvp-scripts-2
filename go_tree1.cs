using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void GoTree(int z, int map)
	{
		string[] str = {"1st", "2nd", "3rd", "4th", "5th"};
		
		int field = map + z;
		
		if (UserCount(field) >= 6)
		{
			self.say($"Are you going to enter #bthe room with the {str[z]} tree#k? Hmm... Sorry, but it's full at the moment. Please enter another room~");
			return;
		}
		
		ChangeMap(field);
	}
	
	public override void Run()
	{
		int askTree = AskMenu("Hello~ I'm #p2001001#. I can take you to the room where the humongous Christmas tree is! For more information, talk to #b#p2001000##k. Which room will you enter?#b",
			(0, " The room with the 1st tree"),
			(1, " The room with the 2nd tree"),
			(2, " The room with the 3rd tree"),
			(3, " The room with the 4th tree"),
			(4, " The room with the 5th tree"));
			
		GoTree(askTree, 209000001);
	}
}