using WvsBeta.Game;

// 2040028 Mark the Toy Soldier
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1002601);
		
		if (quest == "s")
		{
			if (ItemCount(4031094) < 1)
			{
				AskMenu("Hello! I'm #b#p2040028##k, I'm in charge of protecting this room. Inside you will find a lot of dollhouses and you can find one that looks a little different from the others. Your job is to search for it, break its door and find the #b#t4031094##k, which is an integral part of the Ludibrium Clocktower. You will have a time limit to do this and, if you break the wrong dollhouse, you will have to come back here, so please be careful.#b",
					(0, " I want to get out of here."));
				
				bool exit = AskYesNo("Are you sure you want to give up now? Alright, then... but remember that the next time you visit this place, the dollhouses will trade places and you'll have to look at each one again very carefully. What do you think? Do you still want to leave this place?");
				
				if (!exit)
				{
					self.say("I knew that you'd stay! It's important that you finish what you started! Now, please go find the the dollhouse that's different from the others, break it and bring the #b#t4031094##k to me!");
					return;
				}
				
				SetQuestData(1002601, "f");
				ChangeMap(221024400, "q000");
			}
			else
			{
				self.say("Oh wow, you did locate the different-looking dollhouse and find #b#t4031094##k! That was just incredible! With this, the Ludibrium Clocktower will be running again! Thank you for your work and here's a little reward for your effort. Before that, though, please check your use inventory and see if it's full or not.");
				
				if (!Exchange(0, 4031094, -1, 2000010, 100))
				{
					self.say("Are you sure you have 1 #b#t4031094##k? If you're sure, check your use inventory, it may be full!!");
					return;
				}
				
				AddEXP(2400);
				SetQuestData(1002601, "e");
				QuestEndEffect();
				self.say("What do you think? Do you like the #b100 #t2000010#s#k that I gave you? Thank you so much for helping us out. The clocktower will be running again thanks to your heroic effort, and the monsters from the other dimension seem to have disappeared, too. I'll let you out now. I'll see you around!");
				
				ChangeMap(221024400, "q000");
			}
		}
		else if (quest == "e")
		{
			self.say("Thank you so much for helping us out. The clocktower will be running again thanks to your heroic effort, and the monsters from the other dimension seem to have disappeared, too. I'll let you out now. I'll see you around!");
			
			ChangeMap(221024400, "q000");
		}
		else
		{
			self.say("But what is this... we have forbidden people from entering this room because a monster from another dimension is hiding here. I don't know how you got here, but I will have to ask you to leave immediately, because inside this room the danger is enormous.");
			
			ChangeMap(221024400);
		}
	}
}