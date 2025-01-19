using WvsBeta.Game;

// 2030003 Rock Covered in Snow
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string questBook3 = GetQuestData(1001502);
		
		if (questBook3 == "s1")
		{
			bool askTake = AskYesNo("Amidst the pile of snow-covered rocks I see a something shining. Will you stretch your hand out and grab that object?");
			
			if (askTake)
			{
				if (!Exchange(0, 4031050, 1))
				{
					self.say("Your etc. inventory is full. Please make some space to take the item.");
					return;
				}
				
				AddEXP(3500);
				SetQuestData(1001502, "s2");
				self.say("The object found in there was indeed the one Spiruna lost, the #b#t4031050##k.");
			}
		}
		else if (questBook3 == "s2")
		{
			if (ItemCount(4031050) >= 1)
			{
				self.say("There's a little bit of space at the bottom of a rock. Looked carefully inside but found nothing.");
				return;
			}
			
			bool askTake = AskYesNo("Amidst the pile of snow-covered rocks I see a something shining. Will you stretch your hand out and grab that object?");
			
			if (askTake)
			{
				if (!Exchange(0, 4031050, 1))
				{
					self.say("Your etc. inventory is full. Please make some space to take the item.");
					return;
				}
				
				self.say("The object found in there was indeed the one Spiruna lost, the #b#t4031050##k");
			}
		}
	}
}