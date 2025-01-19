using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (Job == 400 && Level >= 30)
		{
			if (ItemCount(4031011) < 1)
			{
				self.say("You really want to improve as a Thief? If so, let me take care of it... you seem to have the necessary skills... for now, you can go see #b#p1052001##k of #m103000000#.");
				return;
			}
			
			int marble = ItemCount(4031013);
			
			if (marble == 0)
			{
				self.say("Hmmm... it is definitely the letter from #b#p1052001##k... so you came all the way here to take the test and make the 2nd job advancement as the thief. Alright, I'll explain the test to you. Don't sweat it too much, it's not that complicated.");
				self.say("I'll send you to a hidden map. You'll see monsters not normally seen in normal fields. They look the same like the regular ones, but with a totally different attitude. They neither boost your experience level nor provide you with item.");
				self.say("You'll be able to acquire a marble called #b#t4031013##k while knocking down those monsters. It is a special marble made out of their sinister, evil minds. Collect 30 of those and then go talk to a colleague of mine in there. That's how you pass the test.");
				bool askEnter = AskYesNo("Once you go inside, you can't leave until you take care of your mission. If you die, your experience level will decrease... so you better really buckle up and get ready... well, do you want to go for it now?");
				
				if (!askEnter)
				{
					self.say("You don't seem very prepared for this. Look for me when you're READY. There are no portals or shops in there, so it's better you are 100% prepared.");
					return;
				}
				
				self.say("Alright! I'll let you in! Defeat the monster inside to earn 30 #t4031013# and then talk to my colleague inside, he'll give you #b#t4031012##k as a proof that you've passed the test. Best of luck to you.");
			}
			else if (marble > 0)
			{
				bool askEnter = AskYesNo("So you already gave up once. Don't worry, you can always retake the test. Now... do you want to go back there and try one more time?");
				
				if (!askEnter)
				{
					self.say("You don't seem very prepared for this. Look for me when you're READY. There are no portals or shops in there, so it's better you're 100% prepared.");
					return;
				}
				
				self.say("Alright! I'll let you in! I'm sorry, but I'll have to take all of your dark marbles before you enter. Defeat the monsters, collect 30 #t4031013# and then talk to my colleague inside. He'll give you #b#t4031012##k, the proof that you've passed the test. Best of luck to you.");
				
				Exchange(0, 4031013, -marble);
			}
			
			Random rnd = new Random();
			int[] maps = {108000400, 108000401, 108000402};
				
			int field = maps[rnd.Next(maps.Length)];
			
			ChangeMap(field);
		}
		else if (Job == 400 && Level < 30)
		{
			self.say("You really want to improve as a Thief? So let me take care of that. However, you seem very weak. Train until you get stronger and then come back here.");
		}
		else if (Job == 310 || Job == 320)
		{
			self.say("Hmmm... you're the one who passed my test!! What do you think? Gotten stronger since then? Good! Now I can definitely feel the presence of a Thief...");
		}
	}
}