using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(4);
		
		if (quest == "end")
		{
			self.say("You safely delivered my reply to #r#p2103##k? Thanks~ so #r#p2103##k gave you a present? Haha... She is one of the best for making a hat....");
		}
		else if (quest == "2")
		{
			if (ItemCount(4031001) >= 1)
			{
				self.say("You didn't meet up with #r#p2103##k yet? Please get her my reply letter... if you lose the letter by any chance, come find me again... I can always write a new one.");
				return;
			}
			
			self.say("You lost my reply letter!! Should have been more careful. Oh well, there are lots of monsters around this area, so it's understandable.");
			
			if (!Exchange(0, 4031001, 1))
			{
				self.say("Please make some room in your etc. inventory to take my reply letter.");
				return;
			}
		}
		else if (quest == "1" && ItemCount(4031000) >= 1)
		{
			self.say("This is definitely the letter from #p2103#! Ohhh, thank you. I was beginning to get worried because the letter didn't get here. Ok! here's the #breply letter#k. Please get this to her. Just head back to #p2103# and you'll be fine.");
			
			if (!Exchange(0, 4031000, -1, 4031001, 1))
			{
				self.say("Are you sure you have the letter? If so, please make some room in your etc. inventory.");
				return;
			}
			
			SetQuestData(4, "2");
		}
		else
		{
			self.say("The letter from #r#p2103##k should be here by now. What \r\nhappened...? Someone please let me know what's going on here...");
		}
	}
}