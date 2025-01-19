using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void MakeItem(int index, string makeItem, string itemOption)
	{
		if (index == 1 || index == 2)
		{
			self.say("If you gather up the ingredients for the chocolate along with the packaging materials, I'll put the chocolate in a beautiful heart-shaped box and cast a special spell of love on it. Oh, and since you made it, I'll inscribe your name onto it.");
			self.say("#t4031110# and #t4031109# can be found through monsters. I just need #r2 chocolates#k to make either #t2020022# or #t2020023#. As for #t04031111# and #t04031112#, you can buy those through me. With those ingredients I'll make it for a loooooow price of #r1,000 mesos#k.");
		}
		else if (index == 3)
		{
			self.say("Just follow my lead, and you'll be fine. What I do is ... I'll first wrap up the chocolate in two layers, and I'll package it up nicely to make sure it doesn't spill. To do all that, though, requires a number of extra materials.");
			self.say("I'll need #b1 #t2020022# box#k and #b1 #t2020023# box#k. Of course, with the enhanced power of love on the chocolate, the packaging will also have to be different. You'll need to buy #b1 #t4031113##k and #b1 #t4031114##k through me. With those ingredients I'll make it for a loooooow price of #r5,000 mesos#k.");
		}
		
		bool askBuy = AskYesNo($"So you HAVE gathered up the necessary ingredients for \r\n{makeItem}, right...? {makeItem} will improve \r\n#r{itemOption}#k for 30 minutes... Do you want to make it?");
		
		if (!askBuy)
		{
			self.say("Hey, please remember that I only make these for the Valentine's season so gather these items quickly. Good luck!");
			return;
		}
		
		bool trade = false;
		
		//White Chocolate
		if (index == 1) trade = Exchange(-1000, 4031109, -2, 4031111, -1, 4031112, -1, 2020022, 1);
		
		//Dark Chocolate
		else if (index == 2) trade = Exchange(-1000, 4031110, -2, 4031111, -1, 4031112, -1, 2020023, 1);
		
		//Chocolate Basket
		else if (index == 3) trade = Exchange(-5000, 2020022, -1, 2020023, -1, 4031113, -1, 4031114, -1, 2020024, 1);
		
		if (!trade)
		{
			self.say("Hmm? Are you sure you're not lacking any materials or mesos? Please check and see if you have all the items I asked you to get.");
			return;
		}
			
		self.say($"Tada! Isn't it pretty? Take a look! Your name is inscribed on {makeItem}. Have a lovely Valentine's Day with your special someone!");
	}
	
	private void Shop(int item, int cost, string itemUse)
	{
		bool askBuy = AskYesNo($"You want to buy a #b#t{item}##k? This material is needed to make a #b{itemUse}#k and It'll cost #r{cost:n0} mesos#k. What do you think? Do you want to buy one?");
		
		if (!askBuy)
		{
			self.say("Did you change your mind? No problem! I only make these for the Valentine's season so make sure to make you valentine before it's too late~ Well, see you around!");
			return;
		}
		
		if (!Exchange(-cost, item, 1))
		{
			self.say($"Hmm... Are you sure you're not lacking any mesos? Please check and see if you have enough space in your etc. inventory first.");
			return;
		}
		
		self.say($"Tada! Here's your #b#t{item}##k! Have a lovely Valentine's Day with your special someone!");
	}
	
	public override void Run()
	{
		if (DateTime.UtcNow > DateTime.Parse("2021-02-23"))
		{
			self.say("Did you have a wonderful #bValentine's Day#k with your special someone~? The event is over for now... I'll see you next year!");
			return;
		}
		
		int option = AskMenu("Allow me to introduce myself. I am the #bAce of Hearts#k, and I'm here to bake lovely goods for everyone needing my service!#b",
			(0, " Make a chocolate"),
			(1, " Buy materials"));
		
		if (option == 0)
		{
			self.say("Valentine's Day is coming, and love is in the air~ I can bake some special goods for you to give to your special someone~");
			
			int make = AskMenu("Now, would you like to make a chocolate for that special someone? Or even for yourself?#b",
				(0, " #t2020022#"),
				(1, " #t2020023#"),
				(2, " #t2020024#"));
			
			switch(make)
			{
				case 0: MakeItem(1, "#t2020022#", "weapon attack +5"); break;
				case 1: MakeItem(2, "#t2020023#", "magic attack +5"); break;
				case 2: MakeItem(3, "#t2020024#", "accuracy and avoidability +10"); break;
			}
		}
		else if (option == 1)
		{
			int shop = AskMenu("If you need some materials to make your valentine, I've got what you need! So, what would you like?#b",
				(0, " #t4031111# (price: 500 mesos)"),
				(1, " #t4031112# (price: 1,500 mesos)"),
				(2, " #t4031113# (price: 3,000 mesos)"),
				(3, " #t4031114# (price: 1,200 mesos)"));
			
			switch(shop)
			{
				case 0: Shop(4031111, 500, "chocolate box"); break;
				case 1: Shop(4031112, 1500, "chocolate box"); break;
				case 2: Shop(4031113, 3000, "chocolate basket"); break;
				case 3: Shop(4031114, 1200, "chocolate basket"); break;
			}
		}
	}
}