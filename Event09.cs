using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		int start = AskMenu("Dude... It's so hot!!! How can I help you?#b",
			(0, " Exit the event"),
			(1, " Buy a weapon.(#t1322005# 1 meso)"));
			
		if (start == 0)
		{
			bool exit = AskYesNo("If you leave now, you won't be able to participate in the event in the next 24 hours. Do you really want to leave?");
			
			if (!exit)
			{
				self.say("Good. Don't give up, try for real. If you try hard, you'll earn a reward!");
				return;
			}
			
			ChangeMap(109050001);
		}
		else if (start == 1)
		{
			bool exit = AskYesNo("A #t1322005# for beginners is 1 meso. What do you think? Do you want one?");
			
			if (!exit)
			{
				self.say("A weapon with attack speed is more important than a high-damage weapon. If you need one, please come back.");
				return;
			}
			
			if (!Exchange(-1, 1322005, 1))
			{
				self.say("Are you sure you have an empty slot? Or have 1 meso? Please check again.");
				return;
			}
			
			self.say("Did you get the #t1322005#? I wish you good luck!");
		}
	}
}