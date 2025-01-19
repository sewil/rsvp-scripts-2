using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		self.say("Welcome. This is the #m105040300# hotel. Our hotel works hard to provide excellent service at all times. If you're tired, or feeling exhausted from hunting, what do you think of a relaxing stay at our hotel?");
		
		int selection = AskMenu("We offer two kinds of rooms for our service. Please choose the one of your liking.#b",
			(0, " Regular sauna (499 mesos per use)"),
			(1, " VIP sauna (999 mesos per use)"));
			
		if (selection == 0)
		{
			bool askEnter = AskYesNo("You chose the regular sauna. Your HP and MP will recover quickly and you can even buy some items there. Are you sure you want to go in?");
			
			if (!askEnter)
			{
				self.say("We also offer other types of service. Please think carefully and then decide.");
				return;
			}
			
			if (!Exchange(-499))
			{
				self.say("I'm sorry. It looks like you don't have money. A stay at our hotel will cost at least 499 mesos.");
				return;
			}
			
			ChangeMap(105040401);
		}
		else if (selection == 1)
		{
			bool askEnter = AskYesNo("You chose the VIP sauna. Your HP and MP will recover faster than the regular sauna, and you can even find a special item there. Are you sure you want to go in?");
			
			if (!askEnter)
			{
				self.say("We also offer other types of service. Please think carefully and then decide.");
				return;
			}
			
			if (!Exchange(-999))
			{
				self.say("I'm sorry. It looks like you don't have money. A stay at our hotel will cost at least 999 mesos.");
				return;
			}
			
			ChangeMap(105040402);
		}
	}
}