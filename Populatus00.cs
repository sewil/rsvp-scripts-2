using System;
using WvsBeta.Game;

class Portal : IScriptV2
{
	public override void Run()
	{
		string result = GetFieldsetVar("ludiboss", "Populatus");
		int users = UserCount(220080001);
		
		var today = DateTime.UtcNow;
		var date = DateTime.Parse(GetQuestData(7100100, today.AddDays(-1).ToString()));
		string count = GetQuestData(7100101);
		
		if (ItemCount(4031172) >= 1)
		{
			if (result == "yes")
			{
				Message("The battle against Papulatus has already begun, so you may not enter this place.");
				return;
			}
			
			if (users >= 12)
			{
				Message("The room is already in full capacity with people battling against Papulatus.");
				return;
			}
		
			if (today >= date)
			{
				SetQuestData(7100100, today.AddDays(1).ToString());
				SetQuestData(7100101, "1");
				MapPacket.PlayPortalSE(chr);
				ChangeMap(220080001, "st00");
			}
			else
			{
				if (count == "")
				{
					SetQuestData(7100100, today.AddDays(1).ToString());
					SetQuestData(7100101, "1");
					MapPacket.PlayPortalSE(chr);
					ChangeMap(220080001, "st00");
				}
				else if (count == "1")
				{
					SetQuestData(7100101, "2");
					MapPacket.PlayPortalSE(chr);
					ChangeMap(220080001, "st00");
				}
				else
				{
					Message("You can only enter The Origin of Clocktower twice a day.");
				}
			}
		}
	}
}