using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (ItemCount(4031036) >= 1)
		{
			bool askEnter = AskYesNo("Here's the ticket reader. Will you use #b#t4031036##k? If you use the ticket, you will be brought in immediately.");
			
			if (askEnter)
			{
				if (!Exchange(0, 4031036, -1))
				{
					self.say("Insert #b#t4031036##k in the ticket reader.");
					return;
				}
				
				ChangeMap(103000900);
			}
		}
		else if (ItemCount(4031037) >= 1)
		{
			bool askEnter = AskYesNo("Here's the ticket reader. Will you use #b#t4031037##k? If you use the ticket, you will be brought in immediately.");
			
			if (askEnter)
			{
				if (!Exchange(0, 4031037, -1))
				{
					self.say("Insert #b#t4031037##k in the ticket reader.");
					return;
				}
				
				ChangeMap(103000903);
			}
		}
		else if (ItemCount(4031038) >= 1)
		{
			bool askEnter = AskYesNo("Here's the ticket reader. Will you use #b#t4031038##k? If you use the ticket, you will be brought in immediately.");
			
			if (askEnter)
			{
				if (!Exchange(0, 4031038, -1))
				{
					self.say("Insert #b#t4031038##k in the ticket reader.");
					return;
				}
				
				ChangeMap(103000906);
			}
		}
		else
		{
			self.say("Here's the ticket reader. You will not be allowed to enter without a ticket.");
		}
	}
}