using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1005100);
		
		if (!CharacterInArea(chr, "0"))
		{
			Message("I'm too far away to talk to him.");
			return;
		}
		
		if (quest == "")
		{
			self.say("Hi. Welcome to my farm.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031156) < 1)
			{
				self.say("Who are you? This is our farm, and we raise a bunch of Ribbon Pigs. They are much stronger than the #o1210101#s that are raised out in the wild. Anyway, how can I help you?");
				return;
			}
			
			self.say("Who are you? Whoa, isn't that the marble that #p1012108# so preciously takes care of? How did you get that??? What? Camila asked you to get me that for my birthday? Wow, that's just awesome. This is a very precious item, you know. Now that the farming is almost done, I may have to go see Camila to say thanks.");
			
			if (SlotCount(1) < 1 || SlotCount(2) < 1)
			{
				self.say("I would like to give you something, but first you need to make some room in your equip. and use inventories...");
				return;
			}
			
			Random rnd = new Random();
			int rnum = rnd.Next(1, 11);
			
			int itemID = 0;
			int itemNum = 0;
			
			if (rnum < 8)
			{
				itemID = 2020002;
				itemNum = 30;
			}
			else
			{
				itemID = 1322031;
				itemNum = 1;
			}
			
			if (!Exchange(0, 4031156, -1, itemID, itemNum))
			{
				self.say("Are you sure you have that marble? If so, please make sure there's space in your equip. and use inventories.");
				return;
			}
			
			AddEXP(1700);
			SetQuestData(1005100, "e");
			QuestEndEffect();
			self.say($"Thanks for delivering Camila's present to me. Did you get the #b#t{itemID}##k? Hopefully it'll help you on your journey.");
		}
		else if (quest == "e")
		{
			self.say("I should rush back to Camila. You can exit the farm if you take a left here.");
		}
	}
}