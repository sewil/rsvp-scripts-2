using WvsBeta.Game;

// 2030005 Statue
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string questBook1 = GetQuestData(1001500);
		
		if (questBook1 == "me")
		{
			if (ItemCount(4031053) < 1)
			{
				self.say("An old statue was there, but I haven't brought the #b#t4031053##k with me.");
				return;
			}
			
			bool askTake = AskYesNo("At the bottom of the statue lie a sparkling core. Use #b#t4031053##k to unlock it and investigate what's inside.");
			
			if (askTake)
			{
				if (!Exchange(0, 4031053, -1, 4031056, 1))
				{
					self.say("Your etc. inventory is full. Please make some space to take the item.");
					return;
				}
				
				AddEXP(4500);
				SetQuestData(1001500, "fb");
				self.say("I took #b#t4031053##k close to the sparkling core, and all of a sudden, I see a light beaming out of the ring, only to see it disappear. Then, the locked became unlocked. Inside I got the #r#t4031056##k that Alcaster requested.");
			}
		}
		else if (questBook1 == "fb")
		{
			if (ItemCount(4031056) >= 1)
			{
				self.say("An old statue was there, but nothing could be found.");
				return;
			}
			
			bool askTake = AskYesNo("At the bottom of the statue lie a sparkling core. Use #b#t4031053##k to unlock it and investigate what's inside.");
			
			if (askTake)
			{
				if (!Exchange(0, 4031056, 1))
				{
					self.say("Your etc. inventory is full. Please make some space to take the item.");
					return;
				}
				
				self.say("I took #b#t4031053##k close to the sparkling core, and all of a sudden, I see a light beaming out of the ring, only to see it disappear. Then, the locked became unlocked. Inside I got the #r#t4031056##k that Alcaster requested.");
			}
		}
	}
}