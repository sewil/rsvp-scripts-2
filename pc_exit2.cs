using System;
using WvsBeta.Game;
using System.Linq;
using WvsBeta.Game.GameObjects;

// Loser exit
public class NpcScript : IScriptV2
{
    public override void Run()
    {
		if (MapID == 904010000)
		{
			if (AskYesNo("Ready to go back to the #bInternet Cafe#k?"))
			{
				int points = Int32.Parse(GetQuestData(1001304, "0"));
				
				if (points >= 1)
				{
					AddPoints(points);
					RemoveQuest(1001304);
				}
				
				switch(MapID)
				{
					case 904010000: ChangeMap(220000309); break;
				}
			}
		}
		else
		{
			if (AskYesNo("Are you sure you want to give up? If you leave now, you and your party won't be able to clear the challenge during this attempt."))
			{
				self.say("You will be taken to the challenge exit.");
				
				switch(MapID.ToString().Substring(4, 1))
				{
					case "0": ChangeMap(902001100); break;
					case "1": ChangeMap(902011300); break;
					case "2": ChangeMap(902021300); break;
				}
			}
		}
    }
}