using WvsBeta.Game;
using System.Linq;
using WvsBeta.Game.GameObjects;

public class NpcScript : IScriptV2
{
    public override void Run()
    {
		if (MapID == 922010000)
		{
			int item1 = ItemCount(4001022);
            int item2 = ItemCount(4001023);

            if (item1 > 0)
			{
				if (!Exchange(0, 4001022, -item1))
				{
					self.say("Are you sure you have the exact number of #t4001022#? Please check again.");
					return;
				}
			}
			
            if (item2 > 0)
			{
				if (!Exchange(0, 4001023, -item2))
				{
					self.say("Are you sure you have the exact number of #t4001023#? Please check again.");
					return;
				}
			}
			
			RemoveQuest(7011);
			ChangeMap(221024500);
		}
		else
		{
			bool exit = AskYesNo("You'll have to start again from zero if you want to try this quest after leaving this stage. Are you sure you want to leave this map?");
			
			if (!exit)
			{
				self.say("I understand. Join forces with the members of your party and try harder!");
				return;
			}
			
			ChangeMap(922010000);
		}
    }
}