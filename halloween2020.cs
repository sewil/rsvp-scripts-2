using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string Halloween = GetQuestData(8020001);
		
		if (Halloween == "")
		{
			self.say("Have you noticed all the creepy monsters that showed up? Someone told me they drop some sweet loot...");
			
			SetQuestData(8020001, "s");
			self.say("So how about this, Bring me 250 #i4031203# and I'll give you something special~");
		}
		else if (Halloween == "s")
		{
			if (DateTime.UtcNow > DateTime.Parse("2021-11-02"))
			{
				self.say("Aww man, looks like you missed the deadline, Halloween is over... Look at it this way there's always next year!");
				return;
			}
			
			if (ItemCount(4031203) < 250)
			{
				self.say("You don't have the 250 #t4031203# yet? No worries~ come find me when you have!");
				return;
			}
			
			self.say("Whoa! That's a lot of candy, Glad to see you didn't get eaten by a ghost! Here take this #i1302034#, you've earned it.");
			
			if (!Exchange(0, 4031203, -250, 1302034, 1))
			{
				self.say("You don't have enough space in your inventory. Please make room and talk to me again.");
				return;
			}
			
			SetQuestData(8020001, "end");
		}
		else if (Halloween == "end")
		{
			self.say("Hey! Thanks for helping me collect that candy, I'll make sure to put it to good use!");
		}
	}
}