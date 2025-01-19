using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(4);
		
		if (quest == "")
		{
			self.say("Ahh...I'm getting worried...because I need to get this letter to #p12000# fast. It's an urgent matter so I need to let him know of this ASAP. Too bad I have things to do here for a while so I won't be leaving this spot anytime soon...");
			bool askStart = AskYesNo("I'm sorry but can you get this #bletter#k to #r#p12000##k from #b#m1010000##k? I have a lot of things to do here so I have to stay here for now. It'll only take a minute...");
			
			if (!askStart)
			{
				self.say("Are you really busy? Ahhhh, this is not good. If I don't get this to the town chief... anyway if you have some free time please come back and talk to me.");
				return;
			}
			
			if (!Exchange(0, 4031000, 1))
			{
				self.say("Oh, please make some room in your etc. inventory first.");
				return;
			}
			
			SetQuestData(4, "1");
			self.say("You're gonna do it? Thank goodness. Now I can breathe a sigh of relief. Here's my letter, and please get this to the town chief that's at #b#m1010000##k.");
			self.say("Head northeast and soon you'll find #b#m1010000##k. #p12000# is the town chief of #m1010000#. He should be in front of the department store probably taking a walk. Please get \r\n#p12000#'s reply letter fast!");
		}
		else if (quest == "1")
		{
			if (ItemCount(4031000) >= 1)
			{
				self.say("Haven't met #r#p12000##k from #m1010000# yet? Please send him my letter. It's urgent. I need to get a reply from #p12000# quickly...");
				return;
			}
			
			self.say("You lost my letter!! You should have been more careful.");
			
			if (!Exchange(0, 4031000, 1))
			{
				self.say("Please make some room in your etc. inventory first.");
				return;
			}
		}
		else if (quest == "2")
		{
			if (ItemCount(4031001) < 1)
			{
				self.say("Haven't met #r#p12000##k from #m1010000# yet? Please send him my letter. It's urgent. I need to get a reply from #p12000# quickly...");
				return;
			}
			
			self.say("So you have gotten the reply from #p12000#. Thanks! and I want to give you something to show my appreciation.");
			
			Random rnd = new Random();
			int[] hat = {1002008, 1002053, 1002014, 1002066, 1002067, 1002068, 1002069};
			
			int itemID = hat[rnd.Next(hat.Length)];
			
			if (!Exchange(0, 4031001, -1, itemID, 1))
			{
				self.say("Are you sure you have the reply letter? If so, please make some room in your equip. inventory.");
				return;
			}
			
			AddEXP(10);
			SetQuestData(4, "end");
			QuestEndEffect();
			self.say($"Here is a #b#t{itemID}##k. It has a Lv. limitation, but I think you are strong enough to wear this. I hope this can help you. Thanks!!!");
			
			if (GetQuestData(1500) != "1")
			{
				SetQuestData(1500, "1");
				ToggleUI("Guide", true);
			}
		}
		else
		{
			self.say("Now I can deliver important news to the town. Thanks a lot. Are you using the hat, I gave you? How is that? Pretty good, huh?");
		}
	}
}