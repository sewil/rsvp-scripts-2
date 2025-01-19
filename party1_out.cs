using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (MapID == 103000805)
		{
			bool exit = AskYesNo("Did you hunt a lot in the bonus map? Once you leave this place, you won't be able to return and hunt again. Are you sure you want to leave?");
			
			if (!exit)
			{
				self.say("I understand. This map was made for you to hunt as much as possible before the time runs out. You need to talk to me if you want to leave this stage.");
				return;
			}
			
			ChangeMap(103000890);
		}
		else if (MapID == 103000890)
		{
			int count1 = ItemCount(4001007);
			int count2 = ItemCount(4001008);
			
			if (count1 >= 1)
			{
				if (!Exchange(0, 4001007, -count1))
				{
					self.say("Are you sure you have the exact amount of coupons? Please check again.");
					return;
				}
			}
			
			if (count2 >= 1)
			{
				if (!Exchange(0, 4001008, -count2))
				{
					self.say("Are you sure you have the exact amount of coupons? Please check again.");
					return;
				}
			}
			
			ChangeMap(103000000);
		}
		else
		{
			bool exit = AskYesNo("If you leave the map, you'll have to redo the entire quest if you want to try again. Still want to leave the map?");
			
			if (!exit)
			{
				self.say("I understand. Teamwork is very important here. Please work hard with your party members.");
				return;
			}
			
			ChangeMap(103000890);
		}
	}
}