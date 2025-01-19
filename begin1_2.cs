using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1);
		
		if (quest == "")
		{
			self.say("It is a fine day to do the laundry~ Don't you think so?");
		}
		else if (quest == "1")
		{
			self.say("How am I going to hang all these up? Sigh... what? My mirror? Please don't tell me #p2101# asked you for this ...");
			
			if (!Exchange(0, 4031003, 1))
			{
				self.say("Are you sure you have room in your etc. inventory to take the mirror?");
				return;
			}
			
			SetQuestData(1, "2");
			self.say("Aye...she should have come and get it herself. Seriously, she is SOOO lazy. Here's the mirror you're looking for.");
		}
		else if (quest == "2" && ItemCount(4031003) < 1)
		{
			self.say("How am I going to hang all these up? Sigh... what? My mirror? Please don't tell me #p2101# asked you for this ...");
			
			if (!Exchange(0, 4031003, 1))
			{
				self.say("Are you sure you have room in your etc. inventory to take the mirror?");
				return;
			}
			
			self.say("Aye...she should have come and get it herself. Seriously, she is SOOO lazy. Here's the mirror you're looking for.");
		}
		else
		{
			self.say("Did you give my mirror to #p2101#? When will she help me to do this...");
		}
	}
}