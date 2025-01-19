using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (!eventActive("christmas2022") && !eventDone("christmas2022"))
		{
			self.say("The event has not started yet. But I will need your help soon, so come back again!");
			return;
		}
		
		if (eventDone("christmas2022"))
		{
			self.say("The event is over for now, come back again next year!");
			return;
		}
		
		string quest = GetQuestData(8020024);
		
		if (quest == "s")
		{
			if (ItemCount(4031446) < 50)
			{
				self.say("Got em all yet? No... don't think so-get a move on! In my heyday I would've been done by now!");
				return;
			}
			
			self.say("All 50? Great! Now I can build my house! I'd like to thank you by offering you a little something I made for you. It's my special Banana Graham pie. Use it wisely and thanks again!");
			
			if (!Exchange(0, 4031446, -50, 2022123, 2))
			{
				self.say("Hey! You should make some room in your use inventory for these pies first!");
				return;
			}
			
			SetQuestData(8020024, "e");
			QuestEndEffect();
			self.say("Now I can build my house! Use it wisely and thanks again!");
		}
		else
		{
			bool start = AskYesNo("Hiya... think you can help an old man with building a Graham Cracker house?");
			
			if (!start)
			{
				self.say("Hey! Hands off! If you don't want to help, fine-but you can't eat them too!");
				return;
			}
			
			SetQuestData(8020024, "s");
			self.say("Thank you, kindly. My name is Mr. Kit Kat, I worked long and hard to find the perfect spot for my graham cracker house. Only the monsters keep eating all the pieces! I put one up and they steal it when my back is turned to eat it! They even laugh at me! I've had it. I need you to get 50 Graham Cracker Pieces and bring them back to me. Good luck!");
		}
	}
}