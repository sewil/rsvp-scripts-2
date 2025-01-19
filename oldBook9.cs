using WvsBeta.Game;

// 2030004 Small Tomb
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string questBook1 = GetQuestData(1001500);
		string questBook4 = GetQuestData(1001503);
		
		if (questBook1 == "he")
		{
			bool askTake = AskYesNo("Dug up the small tomb, and found a shining object on the finger of a corpse. Will you stretch your arm out and take the item from it?");
			
			if (askTake)
			{
				if (!Exchange(0, 4031053, 1))
				{
					self.say("Your etc. inventory is full. Please make some space to take the item.");
					return;
				}
				
				AddEXP(3500);
				SetQuestData(1001500, "ks");
				SetQuestData(1001503, "s");
				self.say("The item taken from the finger of a corpse is an #b#t4031053##k that seems to have been around for a long time.");
			}
		}
		else if (questBook1 == "ks" && questBook4 == "s")
		{
			if (ItemCount(4031053) >= 1)
			{
				self.say("In the tomb there was some moss, a corpse, and not much else. Looked further in but still found nothing.");
				return;
			}
			
			bool askTake = AskYesNo("Dug up the small tomb, and found a shining object on the finger of a corpse. Will you stretch your arm out and take the item from it?");
			
			if (askTake)
			{
				if (!Exchange(0, 4031053, 1))
				{
					self.say("Your etc. inventory is full. Please make some space to take the item.");
					return;
				}
				
				self.say("The item taken from the finger of a corpse is an #b#t4031053##k that seems to have been around for a long time.");
			}
		}
	}
}