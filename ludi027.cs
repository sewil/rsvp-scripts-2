using WvsBeta.Game;

// 2040031 Document Roll
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1002700);
		
		if (quest == "s")
		{
			if (ItemCount(4031034) >= 1)
			{
				self.say("You already have #b#t4031034##k.");
				return;
			}
			
			bool item = AskYesNo("In the midst of all the scrolls left by #b#p1012005##k, I see one that emits a bright light. Should I take it?");
			
			if (item)
			{
				if (!Exchange(0, 4031034, 1))
				{
					self.say("I don't have any free space in my inventory. I better clear a space so I can carry that scroll with me.");
				}
			}
		}
	}
}