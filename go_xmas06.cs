using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (MapID == 209010000)
		{
			int returnMap = int.Parse(GetQuestData(8847, "101000000"));
			
			bool exit = AskYesNo("I hope you have enjoyed seeing this temple. Are you ready to go back to the place you came from?");
			
			if (!exit)
			{
				self.say("Make yourself at home for as long as you like! This temple has very beautiful spots to take pictures. Enjoy your stay!");
				return;
			}
			
			self.say("I look forward to your next visit to the temple. Take care!");
			
			ChangeMap(returnMap, "h001");
		}
		else
		{
			if (!eventActive("hanukkah2022") && !eventDone("hanukkah2022"))
			{
				self.say("Hanukkah will be starting soon~!");
				return;
			}

			if (eventDone("hanukkah2022"))
			{
				self.say("Thanks for joining us at Shalom Temple for Hanukkah, we'll see you next year!");
				return;
			}

			bool go = AskYesNo("The Shalom Temple is unlike anything you've ever seen.  It's an excellent place to take pictures too. Do you want to go?");
			
			if (!go)
			{
				self.say("I understand. You must have business to do here. In case you want to visit the temple again, please let me know!");
				return;
			}
			
			self.say("Okay, let's go!");
			
			SetQuestData(8847, MapID.ToString());
			ChangeMap(209010000, "st00");
		}
	}
}