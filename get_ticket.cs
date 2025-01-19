using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private int SortTicketByLevel(int ticket1, int ticket2)
	{
		if (Level >= 30)
		{
			return ticket2;
		}
		else
		{
			if (ItemCount(ticket2) >= 1)
			{
				return ticket2;
			}
			else
			{
				return ticket1;
			}
		}
	}
	
	private void GetTicket(int shipMap, int toMap, int ticket1, int ticket2)
	{
		int ticketID = SortTicketByLevel(ticket1, ticket2);
		string EventName = GetNpcVar(180000000, 9900000, "event", "none");
		
		if (EventName == "Field Event")
		{
			bool start = AskYesNo($"During the event, I can take you to your destination instantly. You will still need to purchase #b#t{ticketID}##k to travel. Would you like to go straight to #b#m{toMap}##k?");
			
			if (start)
			{
				if (!Exchange(0, ticketID, -1))
				{
					self.say("Oh no... I don't think you have your ticket with you. You can't get on without it. Please buy the ticket at the ticketing booth.");
					return;
				}
				
				ChangeMap(toMap);
				return;
			}
		}
		
		var contiMove = ContinentMan.Instance.FindContiMove(MapID);
		
		if (contiMove.State != Conti.Wait)
		{
			self.say("We will begin boarding 5 minutes before the takeoff. Please be patient and wait for a few minutes. Be aware that the ship will take off right on time, and we stop boarding 1 minute before that, so please make sure to be here on time.");
			return;
		}
		
		if (contiMove.AboutToLeave())
		{
			self.say("This ship is ready for takeoff. I'm sorry, but you'll have to get on the next ride. The ride schedule is available through the usher at the ticketing booth.");
			return;
		}
		
		bool travel = AskYesNo("This will not be a short flight, so if you need to take care of some things, I suggest you do that first before getting on board. Do you still wish to board the ship?");
		
		if (!travel)
		{
			self.say("You must have some business to take care of, right?");
			return;
		}
		
		if (UserCount(shipMap) >= 50)
		{
			self.say("I'm sorry, but this ride is FULL. We cannot accept any more passengers. Please get on the next ride.");
			return;
		}
		
		if (!Exchange(0, ticketID, -1))
		{
			self.say("Oh no... I don't think you have your ticket with you. You can't get on without it. Please buy the ticket at the ticketing booth.");
			return;
		}
		
		ChangeMap(shipMap);
	}
	
	public override void Run()
	{
		switch(MapID)
		{
			case 101000300: GetTicket(101000301, 200000100, 4031044, 4031045); break;
			case 200000111: GetTicket(200000112, 101000300, 4031046, 4031047); break;
			case 200000121: GetTicket(200000122, 220000100, 4031073, 4031074); break;
			case 220000110: GetTicket(220000111, 200000100, 4031044, 4031045); break;
		}
	}
}