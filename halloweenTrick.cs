using System;
using WvsBeta.Game;

// 9201028 - Malady
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (!eventActive("halloween2022"))
		{
			self.say("Excellent. Halloween is over, but I still don't like it one bit, and now the people are aware of my plans. That's alright, though; my gang will do our best to bring it down next year, too. I'll be counting on you to help us take away more Halloween Candy from others. Peace...");
			return;
		}
		
		bool start = AskYesNo("Trick or treat! This is the time of year when I can show off my collection of sweets! I made them with special ingredients and I'm offering them for a limited time! They come in 3 colors and if you want one, give me #b10 Halloween Candies#k and I'll give you a candy of any color, depending on what the card says. I have four cards here, each representing a candy that you should receive, and I'll pick one at random. Please know that ONE of these cards says \"NO CANDY FOR YOU,\" Which means you won't win anything, so carefuly with it. What's up? Want to make a deal?");
		
		if (!start)
		{
			self.say("Oh, is that right? I'm making my sweets for a limited time. I'll only be here for a little while, so if you want to trade candy, you know where to go. Nobody can resist the great flavor of MY candy!");
			return;
		}
		
		if (ItemCount(4031203) < 10)
		{
			self.say("I don't believe you have enough, child. I need at least 10! It's clear you want my candy...");
			return;
		}
		
		if (SlotCount(2) < 1)
		{
			self.say("Sorry, but I can't give you my sweets if your inventory is full! Check your inventory and make the necessary adjustments.");
			return;
		}
		
		var rnd = new Random();
		int rnum = rnd.Next(0, 10000);
		
		if (rnum < 5000)
		{
			Exchange(0, 4031203, -10);
			self.say("Today must not be your lucky day, because your card says \"NO CANDY FOR YOU!\" I'm sorry dear. I'll only be here for a little while, so if you want to trade candy, you know where to go. Nobody can resist the delicious taste of MY candy!");
		}
		else if (rnum < 9000)
		{
			if (!Exchange(0, 4031203, -10, 2022105, 1))
			{
				self.say("Sorry, but I can't give you my sweets if your inventory is full! Check your inventory and make the necessary adjustments.");
				return;
			}
			
			self.say("Heeheeheehee! Happy Halloween! I hope that you like what I gave you. I'll only be here for a little while, so if you want to trade candy, you know where to go. Nobody can resist the great flavor of MY candy!");
		}
		else if (rnum < 9900)
		{
			if (!Exchange(0, 4031203, -10, 2022106, 1))
			{
				self.say("Sorry, but I can't give you my sweets if your inventory is full! Check your inventory and make the necessary adjustments.");
				return;
			}
			
			self.say("Heeheeheehee! Happy Halloween! I hope that you like what I gave you. I'll only be here for a little while, so if you want to trade candy, you know where to go. Nobody can resist the great flavor of MY candy!");
		}
		else
		{
			if (!Exchange(0, 4031203, -10, 2022107, 1))
			{
				self.say("Sorry, but I can't give you my sweets if your inventory is full! Check your inventory and make the necessary adjustments.");
				return;
			}
			
			self.say("Heeheeheehee! Happy Halloween! I hope that you like what I gave you. I'll only be here for a little while, so if you want to trade candy, you know where to go. Nobody can resist the great flavor of MY candy!");
		}
	}
}