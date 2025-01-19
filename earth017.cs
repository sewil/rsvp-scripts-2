using WvsBeta.Game;

// 2050020 Dropship
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest3 = GetQuestData(1003502);
		
		if (quest3 == "1")
		{
			self.say("The pilot, described by #b#p2051001##k, was nowhere to be found, but a hastily-written letter is found near the cockpit. The letter needs to be delivered to #b#p2051001##k of Omega Sector Silo.");
			
			if (!Exchange(0, 4031127, 1))
			{
				self.say("I'll need to free up some space in my etc. inventory before I can take the letter with me.");
				return;
			}
			
			SetQuestData(1003502, "2");
		}
		else if (quest3 == "2")
		{
			self.say("The Dropship appears to be broken. Observing the Dropship, it looks like a property of Omega Sector. Inside, a letter is found. The letter needs to be delivered to #b#p2051001##k of Omega Sector Silo.");
			
			if (ItemCount(4031127) < 1)
			{
				if (!Exchange(0, 4031127, 1))
				{
					self.say("I'll need to free up some space in my etc. inventory before I can take the letter with me.");
				}
			}
		}
	}
}