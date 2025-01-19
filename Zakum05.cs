using System;
using WvsBeta.Game;

class Portal : IScriptV2
{
	public override void Run()
	{
		string result = GetFieldsetVar("boss", "ZakumBoss");
		int users = UserCount(280030000);
		
		string quest3 = GetQuestData(7000002);
		string date = GetQuestData(7000003);
		string retry = GetQuestData(7000004);
		string today = DateTime.UtcNow.ToString("yyyyMMdd");
		
		if ((quest3 == "end" || quest3 == "s2") && ItemCount(4001017) >= 1)
		{
			if (users >= 30)
			{
				Message("A lot of brave fighters are currently inside battling the boss of the Zakum Dungeon. The room can only hold 30 people at once. You'll have to wait your turn for now.");
				return;
			}
			
			if (date != today)
			{
				if (result == "yes")
				{
					Message("The battle against the boss has already begun, so you can't go in.");
				}
				else
				{
					if (quest3 == "s2")
						SetQuestData(7000002, "end");
					
					MapPacket.PlayPortalSE(chr);
					SetQuestData(7000003, DateTime.UtcNow.ToString("yyyyMMdd"));
					SetQuestData(7000004, "1");
					ChangeMap(280030000);
				}
			}
			else
			{
				if (result == "yes")
				{
					Message("The battle against the boss has already begun, so you can't go in.");
				}
				else
				{
					if (retry == "")
					{
						if (quest3 == "s2")
							SetQuestData(7000002, "end");
						
						MapPacket.PlayPortalSE(chr);
						SetQuestData(7000004, "1");
						ChangeMap(280030000);
					}
					else if (retry == "1" || (chr.IsGM && AskYesNo("You have entered 2 times already, if you press YES you can still enter.")))
					{
						if (quest3 == "s2")
							SetQuestData(7000002, "end");
						
						MapPacket.PlayPortalSE(chr);
						SetQuestData(7000004, "2");
						ChangeMap(280030000);
					}
					else
					{
						Message("You can only enter the altar of Zakum twice a day.");
					}
				}
			}
		}
		else
		{
			Message("You may only enter this place after clearing level 3. You'll also need to have the Eye of Fire in possession.");
		}
	}
}