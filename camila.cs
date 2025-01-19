using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1005100);
		
		if (Level < 23)
		{
			self.say("Hey there, I'm Camila...");
			return;
		}
		
		if (quest == "")
		{
			self.say("I have a friend named #b#p1012107##k whom I've grown up with, and it's his birthday in a few days. I've decided to give #b#t4031156##k to him as a birthday present.");
			bool start = AskYesNo("There's a problem, though. #p1012107# hasn't been coming uptown lately, probably because he's been swarmed with work. I'd like to go there and give it to him myself, but the Ribbon Pigs that he raises scare me to death. Well ... if you have any time, can you get this marble to #p1012107# for me?");
			
			if (!start)
			{
				self.say("Oh, I see. Sorry for asking. You must be a very busy \r\nperson ... #p1012107# might be disappointed ... sigh ... what should I do now??");
				return;
			}
			
			if (!Exchange(0, 4031156, 1))
			{
				self.say("Please leave some room in your etc. inventory so I can give you the marble.");
				return;
			}
			
			SetQuestData(1005100, "s");
			self.say("Really? Thank you, thank you so much!! Here's the marble. I even carved a message for #p1012107# on it. You can get to Utah's farm through the Eastern forest of Henesys. Good luck!");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031156) >= 1)
			{
				self.say("Oh, that crystal... did you not see Utah yet? Please get him the present before his birthday passes. Did you lose your way to his farm by any chance?");
				self.say("Head to the Eastern forest of Henesys and you'll see an entrance to Utah's pig farm. Avoid the Ribbon Pigs and traps and navigate your way through the hidden paths, and you'll find him.");
				return;
			}
			
			self.say("Ah, did you lose the marble that I gave you by any chance? Someone picked it up from the streets a couple of minutes ago. This is something I really cherish, so please take good care of it, and get it to Utah ASAP.");
			
			if (!Exchange(0, 4031156, 1))
			{
				self.say("Please leave some room in your etc. inventory so I can give you the marble.");
				return;
			}
		}
		else if (quest == "e")
		{
			self.say("Ah, you're the one that helped me out the other day. Thank you so much for that!");
		}
	}
}