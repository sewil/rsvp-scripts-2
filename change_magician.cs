using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (Job == 200 && Level >= 30)
		{
			if (ItemCount(4031009) < 1)
			{
				self.say("Want to become a more powerful Magicican than you already are? Allow me to take care of that. You seem to be qualified. Go find #b#p1032001##k of #m101000000# first.");
				return;
			}
			
			int marble = ItemCount(4031013);
			
			if (marble == 0)
			{
				self.say("Hmmm... it is definitely the letter from #b#p1032001##k... so you came all the way here to take the test and make the 2nd job advancement as the magician? Alright, I'll explain the test to you. Don't sweat it too much, because it's not that complicated.");
				self.say("I'll send you to a hidden map. You'll see monsters not normally seen in normal fields. They look the same like the regular ones, but with a totally different attitude. They neither boost your experience level nor provide you with item.");
				self.say("You'll be able to acquire a marble called #b#t4031013##k while knocking down those monsters. It is a special marble made out of their sinister, evil minds. Collect 30 of those, and then go talk to a colleague of mine in there. That's how you pass the test.");
				bool askEnter = AskYesNo("Once you go inside, you can't leave until you take care of your mission. If you die, your experience level will decrease... so you better really buckle up and get ready... well, do you want to go for it now?");
				
				if (!askEnter)
				{
					self.say("I don't think you're qualified for this. Come and talk to me when you're well prepared. There are no portals or shops in there, so it's better you are ready beforehand.");
					return;
				}
				
				self.say("Alright, I'll let you in! Once you go in, defeat the monsters and collect 30 #t4031013#s. After that go talk to my colleague inside to receive #b#t4031012##k as the proof that you have passed the test. Best of luck to you.");
			}
			else if (marble > 0)
			{
				bool askEnter = AskYesNo("So you already gave up once. Don't worry, you can always retake the test. Now... do you want to go back there and try one more time?");
				
				if (!askEnter)
				{
					self.say("You don't seem very prepared for this. Look for me when you're READY. There are no portals or shops in there, so it's better you are 100% prepared.");
					return;
				}
				
				self.say("Alright! I'll let you in! I'm sorry, but I'll have to take all of your dark marbles first. Once you go inside, defeat the monsters to earn 30 #t4031013#s. After that go talk to my colleague inside to receive #b#t4031012##k, as the proof that you have passed the test. Best of luck to you.");
				
				Exchange(0, 4031013, -marble);
			}
			
			Random rnd = new Random();
			int[] maps = {108000200, 108000201, 108000202};
				
			int field = maps[rnd.Next(maps.Length)];
			
			ChangeMap(field);
		}
		else if (Job == 200 && Level < 30)
		{
			self.say("Want to become a more powerful Magicican than you already are? Allow me to take care of that. However, you seem a little weak. Train a little more, get stronger and then come back here.");
		}
		else if (Job == 210 || Job == 220 || Job == 230)
		{
			self.say("Ah, you're the one who passed my test the other day! What do you think? Did you manage to become stronger? Good! Now I can definitely feel the presence of a Magician...");
		}
	}
}