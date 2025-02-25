using System;
using WvsBeta.Game;
using System.Linq;
using WvsBeta.Game.GameObjects;

// Loser exit
public class NpcScript : IScriptV2
{
    public override void Run()
    {
		if (MapID == 902001100 || MapID == 902011300 || MapID == 902021300 || MapID == 904000000)
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
					case 902001100: ChangeMap(103000007); break;
					case 902011300: ChangeMap(103000007); break;
					case 904000000: ChangeMap(103000007); break;
					case 902021300: ChangeMap(220000309); break;
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