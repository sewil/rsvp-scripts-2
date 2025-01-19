using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void BuyTicket(int ticket, int price, string stage)
	{
		bool askBuy = AskYesNo($"Will you purchase the ticket to #bconstruction site B{stage}#k? It'll cost you {price:n0} mesos. Before making the purchase, please make sure you have an empty slot on your etc. inventory.");
		
		if (!askBuy)
		{
			self.say("You can enter the construction site if you purchase a ticket. I heard there are strange machines everywhere in there, but at the end rare and precious items await you. So, tell me if you change your mind.");
			return;
		}
		
		if (!Exchange(-price, ticket, 1))
		{
			self.say($"Are you short on cash? Check whether or not you have an empty slot in your etc. inventory.");
			return;
		}
		
		self.say($"You can insert the ticket in the #p1052007#. I heard Area {stage} has rare, precious items available but with so many traps all over the place most come back out early. Please be safe.");
	}
	
	public override void Run()
	{
		if (Level < 20)
		{
			self.say("You can enter if you purchase a ticket, but it doesn't seem like you're ready. There are strange machines in the subway and it'll be very hard for you to overcome them, so train, prepare yourself and come back, ok?");
			return;
		}
		
		int selection = AskMenu("You must purchase the ticket to enter. Once you have made the purchase, you can enter through #p1052007# on the right. What would you like to buy?#b",
			(0, " construction site B1", Level >= 20),
			(1, " construction site B2", Level >= 30),
			(2, " construction site B3", Level >= 40));
		
		switch(selection)
		{
			case 0: BuyTicket(4031036, 500, "1"); break;
			case 1: BuyTicket(4031037, 1200, "2"); break;
			case 2: BuyTicket(4031038, 2000, "3"); break;
			default: return;
		}
	}
}