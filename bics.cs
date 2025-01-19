using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(100);
		
		if (quest == "")
		{
			self.say("I'll give you something nice if you get me #b#e10#n #t4000001#s#k and #b#e30#n #t4000000#s#k! You can get it by taking down the monsters, but ... looking at you, I'm not sure if you're up for the challenge...");
			SetQuestData(100, "f");
		}
		else if (quest == "f")
		{
			if (ItemCount(4000000) < 30 || ItemCount(4000001) < 10)
			{
				self.say("You don't have #e10#n #b#t4000001#s#k and #e30#n#k #b#t4000000#s#k, right? Don't worry too much about it. I'll be staying here for a while.");
				return;
			}
			
			self.say("Oh wow! You brought them all!! Sweet! Here's an item like I promised. I don't really need it anyway, so take it!");
			
			Random rnd = new Random();
			int[] knife = {1332007, 1332005};
			
			int itemID = knife[rnd.Next(knife.Length)];
			
			if (!Exchange(0, 4000000, -30, 4000001, -10, itemID, 1))
			{
				self.say("Are you sure you brought the items I asked for? If so, please check to see if there's room in your equip. inventory.");
				return;
			}
			
			AddEXP(30);
			SetQuestData(100, "end");
			QuestEndEffect();
		}
		else
		{
			self.say("Thanks for the last time. Now, if I get just little more money, I probably can start the business. Are you still using the weapon, which I gave you?");
		}
	}
}