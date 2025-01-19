using System;
using WvsBeta.Game;

// 9200000 Cody
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(8020016);
		
		if (DateTime.UtcNow > DateTime.Parse("2021-11-13"))
		{
			self.say("Sorry, but the Halloween event is over. I'll let you know when a new event appears, alright? See you then!");
			return;
		}
		
		if (quest == "")
		{
			bool start = AskYesNo("Trick or treat! What's happening? It's me, Cody, and of course it's time for a new event! Halloween has been one of my favorite times of year and I have something special available for everyone! I just want you to do one thing for me in return. Are you ready?");
			
			if (!start)
			{
				self.say("Oh, really? Well, just so you know, this basket is available for a limited time. Get yours before it's too late!");
				return;
			}
			
			SetQuestData(8020016, "s");
			self.say("It's very simple actually. All that I need from you is a bunch of #bHalloween Candy.#k A #bhundred#k to be exact! Now, immerse yourself in the spirit of Halloween and get the candy! I'll be here waiting for you!");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031203) < 100)
			{
				self.say("I don't think you got #b100 Halloween Candies#k. This basket is available for a limited time, so continue searching!");
				return;
			}
			
			bool end = AskYesNo("Oh wow! You brought a mountain of candy. Great work, buddy! Now, do you want to trade your candy for the basket?");
			
			if (!end)
			{
				self.say("Oh, really? Well, just so you know, this basket is available for a limited time. Get yours before it's too late!");
				return;
			}
			
			if (!Exchange(0, 4031203, -100, 1302062, 1))
			{
				self.say("I don't think you have any open slots for this Pumpkin Basket in your inventory. You need at minimum one slot available in your equip. inventory to receive this!");
				return;
			}
			
			SetQuestData(8020016, "e");
			QuestEndEffect();
			self.say("Here's the basket! What do you think? Seems cool, right? You'll never find a pumpkin basket like this anywhere!");
		}
		else if (quest == "end")
		{
			self.say("I already gave you the basket! I only have enough for one person. Don't be selfish!");
		}
	}
}