using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(9000301);
		
		if (quest == "")
		{
			self.say("Hi, welcome to Ludibrium~!");
			return;
		}
		
		if (quest == "s")
		{
			self.say($"Hey {chr.Name}! Congratulations on winning the Ludibrium Opening Sweepstakes~!! I have something special for you so please make sure you have room in your equip. inventory first.");
			
			if (!Exchange(0, 1002419, 1))
			{
				self.say("I think your equip. inventory is full. Please make some room and talk to me again!");
				return;
			}
			
			SetQuestData(9000301, "end");
			self.say("Here you go, a hat to commemorate the grand opening of Ludibrium. Well, I'll see you around~!");
		}
		else
		{
			self.say("Are you enjoying your time in Ludibrium?");
		}
		
		/*
		// Event will run for 20 days, March 6th to 26th
		DateTime cTime = DateTime.UtcNow;
		DateTime sTime = DateTime.Parse("2021-03-06T00:00:00Z");
		DateTime eTime = DateTime.Parse("2021-03-26T23:59:59Z");
		
		string quest = GetQuestData(9000300);
		
		if (cTime < sTime)
		{
			self.say("Hi~ I'm here celebrating the Ludibrium opening sweepstakes. But Ludibrium isn't open just yet so be patient!");
			return;
		}
		
		if (cTime > eTime)
		{
			self.say("Sorry~ It looks like the Ludibrium opening sweepstakes has officially ended. I hope you have a great time in Ludibrium~!");
			return;
		}
		
		if (quest == "")
		{
			SetQuestData(9000300, "s");
			self.say($"Hey {chr.Name}, welcome to Ludibrium!! To celebrate the grand opening, we're holding a sweepstakes here.");
			self.say("The rules are simple, collect #b20 of #t4000106#s#k and #b20 #t4000095#s#k and bring them back to me. I'll give you something nice and enter your name into the drawing list for a special prize. The winners will be chosen on #bMarch 27th#k so come back and see me before then, okay~?");
		}
		else if (quest == "s")
		{
			if (ItemCount(4000106) < 20 || ItemCount(4000095) < 20)
			{
				self.say("I don't think you brought everything yet. You need #b20 \r\n#t4000106#s#k and #b20 #t4000095#s#k to enter the sweepstakes. Remember, you only have until #bMarch 27th#k!");
				return;
			}
			
			self.say("Wow, you really did bring everything! Alright, let me reward you for all your hard work. But first, please make sure you have two empty slots in your use inventory!");
			
			if (!Exchange(0, 4000106, -20, 4000095, -20, 2000010, 150, 2000009, 150))
			{
				self.say("You'll need two empty slots in your use inventory first, so please talk to me again when you've made the adjustment.");
				return;
			}
			
			AddEXP(2000);
			SetQuestData(9000300, "end");
			QuestEndEffect();
			self.say($"Thanks for participating in the opening event, {chr.Name}~! I've entered your name into the drawing list so make sure to check back on the 27th to see the if you won! I'll see you around~");
		}
		else if (quest == "end")
		{
			self.say($"Hey {chr.Name}! Are you enjoying your time in Ludibrium? Your name's already on the drawing list so check back again on the 27th to see who won!");
		}
		*/
	}
}