using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (Job == 300 && Level >= 30)
		{
			if (ItemCount(4031010) < 1)
			{
				self.say("Do you want to be an even stronger Bowman? Let me take care of that. You definitely seem qualified. For now, go find #b#p1012100##k of #m100000000# first.");
				return;
			}
			
			int marble = ItemCount(4031013);
			
			if (marble == 0)
			{
				self.say("Hmmm... it is definitely the letter from #b#p1012100##k... so you came all the way here to take the test and make the 2nd job advancement as the bowman? Alright, I'll explain the test to you. Don't worry, though, it's not that complicated.");
				self.say("I'll send you to a hidden map. You'll see monsters not normally seen in normal fields. They look the same like the regular ones, but with a totally different attitude. They neither boost your experience level nor provide you with item.");
				self.say("You'll be able to acquire a marble called #b#t4031013##k while knocking down those monsters. It is a special marble made out of their sinister, evil minds. Collect 30 of those and then go talk to a colleague of mine in there. That's how you pass the test.");
				bool askEnter = AskYesNo("Once you go inside, you can't leave until you take care of your mission. If you die, your experience level will decrease... so you better really buckle up and get ready... well, do you want to go for it now?");
				
				if (!askEnter)
				{
					self.say("You don't seem very prepared for this. Look for me when you're READY. There are no portals or shops in there, so it's better you are 100% prepared.");
					return;
				}
				
				self.say("Alright! I'll let you in! Defeat the monsters, collect 30 #t4031013#, and then talk to my colleague inside. Then he'll award you the proof of passing the test, #b#t4031012##k. Good luck.");
			}
			else if (marble > 0)
			{
				bool askEnter = AskYesNo("So you already gave up once. Don't worry, you can always retake the test. Now... do you want to go back there and try one more time?");
				
				if (!askEnter)
				{
					self.say("You don't seem very prepared for this. Look for me when you're READY. There are no portals or shops in there, so it's better you are 100% prepared.");
					return;
				}
				
				self.say("Alright! I'll let you in! I'm sorry, but the dark marbles that you collected will be taken. Once you go inside, defeat the monsters until you collect 30 #t4031013#s and then talk to my colleague inside. Then he'll award you the proof of passing the test, #t4031012#.");
				
				Exchange(0, 4031013, -marble);
			}
			
			Random rnd = new Random();
			int[] maps = {108000100, 108000101, 108000102};
				
			int field = maps[rnd.Next(maps.Length)];
			
			ChangeMap(field);
		}
		else if (Job == 300 && Level < 30)
		{
			self.say("Do you want to be an even stronger Bowman? Let me take care of that. However... you look pretty weak. It'll be much better if you can train until you become stronger and come back later.");
		}
		else if (Job == 310 || Job == 320)
		{
			self.say("Hmmm... you're the one who passed my test! What do you think? Do you feel more powerful than before? Good! You definitely have the presence of a Bowman now...");
		}
	}
}