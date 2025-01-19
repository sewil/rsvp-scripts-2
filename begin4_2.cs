using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(5);
		
		if (quest == "")
		{
			self.say("So are you ready for the adventure?");
		}
		else if (quest == "end")
		{
			if (Job != 0)
			{
				self.say("This is the tutorial area for beginners. You're not a beginner, are you?");
				ChangeMap(104000000, "maple00");
			}
			else
			{
				self.say("You've come so far... incredible! You can start traveling around now! Ok, I'll take you to the next area.");
				self.say("But I will give you some advice: After you leave here, you'll be free; in places with many monsters and no means to return. Well then, see you later!");
				AddEXP(3);
				ChangeMap(40000, "in00");
				
				if (GetQuestData(1500) != "1")
				{
					SetQuestData(1500, "1");
					ToggleUI("Guide", true);
				}
			}
		}
		else
		{
			int itemNum = ItemCount(4000142);
			
			if (quest != "000")
			{
				self.say("Hmmm ... you should have seen a small Jr. Stoneball at the bottom of the map. Maybe you missed it. All you need to do is attack it by pressing #rCtrl#k and kill it. Once you pick up the dropping, then come back to me.");
				return;
			}
			
			if (itemNum < 1)
			{
				self.say("Huh? I don't think you have #b#t4000142##k. When you defeat Jr. Stoneball here, #t4000142# will be dropped right there on that spot. When that happens, make sure to press #rZ#k to pick up the item. Please hurry!");
				return;
			}
			
			self.say("Are you the one that #p2004# is training to hunt? He said something about you having the potential to be a great hunter. Let's see ... let's see if you've trained right.");
			
			if (!Exchange(0, 4000142, -itemNum))
			{
				self.say("Huh? Are you sure you brought them?");
				return;
			}
			
			AddEXP(10);
			SetQuestData(5, "end");
			QuestEndEffect();
			self.say("Someday, long after you leave this place, you'll be powerful enough to take on the real Jr. Stoneball's ... oh, and ... when you level up, make sure to press #bS#k and check out your \r\n#bability points.#k\n\nTo move on to the next map, either press #bup arrow#k in front of the portal on the right, or just talk to me again. Hmmm, it will be an interesting experience in itself to go to the next map through me.");
		}
	}
}