using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (Level < 10)
		{
			self.say("Your level appears to be too low for this. For security reasons, we don't allow anyone below level 10 to come on the trip.");
			return;
		}
		
		bool buyTicket = false;
		int ticket = 0;
		int cost = 0;
		
		if (MapID == 200000100)
		{
			int askTicket = AskMenu("Hello, I'm in charge of selling tickets for the ship ride to all destinations. Which ticket would you like to buy?#b",
				(0, " Ellinia of Victoria Island"),
				(1, " Ludibrium"));
			
			if (askTicket == 0)
			{
				if (Level < 30)
				{
					buyTicket = AskYesNo("The ride to Ellinia of Victoria Island takes off every 15 minutes, beginning on the hour, and it'll cost you #b1,000 mesos#k. Are you sure you want to purchase #b#t4031046##k?");
					ticket = 4031046;
					cost = 1000;
				}
				else
				{
					buyTicket = AskYesNo("The ride to Ellinia of Victoria Island takes off every 15 minutes, beginning on the hour, and it'll cost you #b5,000 mesos#k. Are you sure you want to purchase #b#t4031047##k?");
					ticket = 4031047;
					cost = 5000;
				}
			}
			else if (askTicket == 1)
			{
				if (Level < 30)
				{
					buyTicket = AskYesNo("The ride to Ludibrium takes off every 10 minutes, beginning on the hour, and it'll cost you #b2,000 mesos#k. Are you sure you want to purchase #b#t4031073##k?");
					ticket = 4031073;
					cost = 2000;
				}
				else
				{
					buyTicket = AskYesNo("The ride to Ludibrium takes off every 10 minutes, beginning on the hour, and it'll cost you #b6,000 mesos#k. Are you sure you want to purchase #b#t4031074##k?");
					ticket = 4031074;
					cost = 6000;
				}
			}
		}
		else if (MapID == 220000100)
		{
			if (Level < 30)
			{
				buyTicket = AskYesNo("Hello, I'm in charge of selling tickets for the ship ride to Orbis Station of Ossyria. The ride to Orbis takes off every 10 minutes, beginning on the hour, and it'll cost you #b2,000 mesos#k. Are you sure you want to purchase #b#t4031044##k?");
				ticket = 4031044;
				cost = 2000;
			}
			else
			{
				buyTicket = AskYesNo("Hello, I'm in charge of selling tickets for the ship ride to Orbis Station of Ossyria. The ride to Orbis takes off every 10 minutes, beginning on the hour, and it'll cost you #b6,000 mesos#k. Are you sure you want to purchase #b#t4031045##k?");
				ticket = 4031045;
				cost = 6000;
			}
		}
		else if (MapID == 101000300)
		{
			if (Level < 30)
			{
				buyTicket = AskYesNo("Hello, I'm in charge of selling tickets for the ship ride to Orbis Station of Ossyria. The ride to Orbis takes off every 15 minutes, beginning on the hour, and it'll cost you #b1,000 mesos#k. Are you sure you want to purchase #b#t4031044##k?");
				ticket = 4031044;
				cost = 1000;
			}
			else
			{
				buyTicket = AskYesNo("Hello, I'm in charge of selling tickets for the ship ride to Orbis Station of Ossyria. The ride to Orbis takes off every 15 minutes, beginning on the hour, and it'll cost you #b5,000 mesos#k. Are you sure you want to purchase #b#t4031045##k?");
				ticket = 4031045;
				cost = 5000;
			}
		}
		
		if (!buyTicket)
		{
			self.say("You must have some business to take care of, right?");
			return;
		}
		
		if (!Exchange(-cost, ticket, 1))
		{
			self.say($"Are you sure you have #b{cost} mesos#k? If so, then you should check your etc. inventory and see if it's full or not.");
			return;
		}
	}
}