using WvsBeta.Game;

// 2030007 Piece of Statue
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string scadur = GetQuestData(1001900);
		
		if (scadur == "s")
		{
			bool askTake = AskYesNo("There seems to be a little bit of room below #b#p2030007##k, and, looking into it, there seems to be a sparkling item in there. Should I stretch my arm out and get that item?");
			
			if (askTake)
			{
				if (!Exchange(0, 4031060, 1))
				{
					self.say("Your etc. inventory is full. Please make some space to take the item.");
					return;
				}
				
				AddEXP(3000);
				SetQuestData(1001900, "g");
				self.say("I found what appears to be the #b#t4031060##k of #b#p2020007##k's son.");
			}
		}
		else if (scadur == "g")
		{
			if (ItemCount(4031060) >= 1)
			{
				self.say("There seems to be a little bit of room below #b#p2030007##k, but no matter how much I look into it, I can't find anything in there.");
				return;
			}
			
			bool askTake = AskYesNo("There seems to be a little bit of room below #b#p2030007##k, and, looking into it, there seems to be a sparkling item in there. Should I stretch my arm out and get that item?");
			
			if (askTake)
			{
				if (!Exchange(0, 4031060, 1))
				{
					self.say("Your etc. inventory is full. Please make some space to take the item.");
					return;
				}
				
				self.say("I found what appears to be the #b#t4031060##k of #b#p2020007##k's son.");
			}
		}
	}
}