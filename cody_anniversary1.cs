using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(8020013);
		
		if (DateTime.UtcNow > DateTime.Parse("2021-10-23"))
		{
			self.say("Hi~! I hope you had a great time celebrating the anniversary of MG2 with us. Here's to another great year~!");
			return;
		}
		
		if (DateTime.UtcNow < DateTime.Parse("2021-10-02"))
		{
			self.say("I'm getting ready for the anniversary of MG2! Can you believe we've been around for a year already? Talk to me again on #bOctober 2nd#k and I'll have something for you to do~!");
			return;
		}
		
		if (quest == "s")
		{
			if (ItemCount(4031305) < 10)
			{
				self.say("I don't think you have the #b10 Birthday Candles#k that I asked you to get. The party is going to start soon, and I'll need those #bBirthday Candles#k fast! Please hurry!!");
				return;
			}
			
			self.say("Oh my goodness, you really did bring all #b10 of the Birthday Candles#k that I asked you to get! Nicely done!!");
			
			if (!Exchange(0, 4031305, -10, 1302033, 1))
			{
				self.say("Please make soom room in your equip. inventory first.");
				return;
			}
			
			QuestEndEffect();
			SetQuestData(8020013, "e");
			SetQuestData(8020014, DateTime.UtcNow.ToString("yyyyMMdd"));
			self.say("Thanks a whole bunch for your help!! Phew, I could have gotten chewed out by my boss for this. Anyway, here's something for you. Hope you like it! Well, I'm off to tha par-tay, so I'll see you later! Happy Mapling!");
		}
		else
		{
			string today = DateTime.UtcNow.ToString("yyyyMMdd");
			string lastDate = GetQuestData(8020014);
			
			if (lastDate == today)
			{
				self.say("Thanks to your help, the party went bananas! Boy it was fun. anyway, hope you liked the stuff that I gave you. I'll see you around~");
				return;
			}
			
			bool start = AskYesNo("Hey, what's going on? Can you believe it? MG2 is nearing its very first birthday!!! It's all thanks to great Maplers like you! Well, anyway, we plan on having a big party among the MG2 staff, and I need your help, big time. Can you help me out?");
			
			if (!start)
			{
				self.say("Oh, I see... that's alright. You must be busy with your other quests. But if you ever have a spare time, then please help me out here!! I'll be here waiting for you...");
				return;
			}
			
			SetQuestData(8020013, "s");
			self.say("Thanks! Well, we have the cake, the food, and everything else needed for a grand party, but I forgot to buy something very important: #bCANDLES#k!! I mean, what's a birthday party without the candles on the cake, you know? We'll need #b10 Birthday Candles#k for the party, so please get them for me fast. I'll be here waiting for you. Good luck! ");
		}
	}
}