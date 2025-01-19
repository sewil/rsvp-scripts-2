using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		var startTime = DateTime.Parse("2021-07-04");
		var endTime = DateTime.Parse("2021-07-26");
		var today = DateTime.UtcNow;
		
		string quest = GetQuestData(8020008);
		
		if (today < startTime || today >= endTime)
		{
			self.say("What's going on? I'm Cody, the head programmer of Maplestory!");
			return;
		}
		
		if (quest == "")
		{
			bool start = AskYesNo("Hi there! I'm preparing a small #rBarbecue Party#k for the upcoming #rIndependance Day#k. But I just found out that I have no meats, no woods, and just nothing but this homemade Barbecue sauce! Could you lend me a hand and get me some cooking materials for me?");
			
			if (!start)
			{
				self.say("Too bad... I guess we'll have to party without you. If you ever change your mind, come back. I'll be here for a while longer.");
				return;
			}
			
			SetQuestData(8020008, "s");
			self.say("Great, thank you! Just get me #b50 Pigs' heads, 50 Tree Branches, 50 Leathers#k. I think that will be enough to cover this small party for #rIndependence Day#k. Don't worry.  I'll reward you handsomely for your effort.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4000017) < 50 || ItemCount(4000003) < 50 || ItemCount(4000021) < 50)
			{
				self.say("You don't have everything I asked for. Please get me #b50 Pigs' heads, 50 Tree Branches, 50 Leathers#k and hurry before we run out of time.");
				return;
			}
			
			self.say("Thank you! For your hard work, I shall give you a hat to celebrate Independence Day and some delicious homemade Barbecue to stuff your stomach.");
			
			if (!Exchange(0, 4000017, -50, 4000003, -50, 4000021, -50, 1002527, 1, 2022079, 10))
			{
				self.say("Please make sure there's room in your equip. and use inventories!");
				return;
			}
			
			AddEXP(2000);
			SetQuestData(8020008, "end");
			QuestEndEffect();
			self.say("Did you like the hat I gave you? It's an item specially made to celebrate Independence Day! And the Barbecue that we made with the ingredients you gave us turned out to be GREAT! Hope you enjoy celebrating Independence Day.");
		}
		else if (quest == "end")
		{
			self.say("Thanks to your help, the party went bananas! Boy it was fun. anyway, hope you liked the stuff that I gave you. I'll see you around~");
		}
	}
}