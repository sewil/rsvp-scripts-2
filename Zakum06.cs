using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (MapID == 280030000)
		{
			string attempt = GetQuestData(7000004);
			
			bool exit = false;
			
			if (attempt == "1")
			{
				exit = AskYesNo("Are you sure you want to leave this place? You are entitled to enter the Zakum Altar up to twice a day, and by leaving right now, you may only re-enter this shrine once more for the rest of the day.");
			}
			else if (attempt == "2")
			{
				exit = AskYesNo("Are you sure you want to leave this place? You are entitled to enter the Zakum Altar up to twice a day, and since you have been here twice already, you will be denied entrance to this shrine for the rest of the day by leaving right now.");
			}
			else
			{
				self.say("How did you??? This is bonkers. Get out of here...");
				exit = true;
			}
			
			if (exit)
			{
				ChangeMap(211042300);
			}
		}
		else
		{
			if (AskYesNo("Are you sure you want to quit and leave this place? Next time you come back in, you'll have to start all over again."))
			{
				ChangeMap(211042300);
			}
		}
	}
}