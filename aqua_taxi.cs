using System;
using WvsBeta.Game;
using WvsBeta.Common;

public class NpcScript : IScriptV2
{
	private void GoMap(int cost)
	{
		if (!Exchange(-cost))
		{
			self.say("I don't think you have enough money...");
			return;
		}
		
		ChangeMap(230030200, "st00");
	}
	
	public override void Run()
	{
		if (ItemCount(4031242) >= 1)
		{
			AskMenu("Oceans are all connected to each other. Places you can't reach by foot can be easily reached oversea. How about taking #bDolphin Taxi#k with us today?#b",
				(0, " I'll use #b#t4031242##k to go to #bthe sharp unknown#k.")
			);
			
			if (!Exchange(0, 4031242, -1))
			{
				self.say("I don't think you have #b#t4031242##k there with you. There must be some way to get a #b#t4031242##k...");
				return;
			}
			
			ChangeMap(230030200, "st00");
		}
		else
		{
			if (Job == 0)
			{
				AskMenu("Oceans are all connected to each other. Places you can't reach by foot can be easily reached oversea. How about taking #bDolphin Taxi#k with us today? We have special tickets with a 90% discount for Beginners!",
					(0, " Go to #bThe Sharp Unknown#k after paying 100 mesos.")
				);
				
				GoMap(100);
			}
			else
			{
				AskMenu("Oceans are all connected to each other. Places you can't reach by foot can be easily reached oversea. How about taking #bDolphin Taxi#k with us today?",
					(0, " Go to #bThe Sharp Unknown#k after paying 1,000 mesos.")
				);
				
				GoMap(1000);
			}
		}
	}
}