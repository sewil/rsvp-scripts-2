using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		self.say("Hey, it seems like you want to travel even further. Past this point, however, you'll see agressive and dangerous monsters everywhere, even if you think you're prepared, be careful. Long ago, some brave men from our town went through here to eliminate whatever threatened the town, but never returned...");
		
		if (Level < 50)
		{
			self.say("If you're thinking of entering, I suggest you change your mind. But if you really want to enter... You can only enter if you're strong enough to stay alive inside. I don't want to see anyone else die. Let's see... Hmmm... you haven't reached level 50 yet. I can't let you inside, forget it.");
			return;
		}
		
		bool enter = AskYesNo("If you're thinking of entering, I suggest you change your mind. But if you insist... You can only enter if you're strong enough to stay alive inside. I don't want to see anyone else die. Let's see... Hmm...! You look quite strong. Alright, do you want to go in?");
		
		if (!enter)
		{
			self.say("Even if your level is high, it's difficult to enter here. But, if you change your mind, talk to me. After all, it's my job to guard this place.");
			return;
		}
		
		ChangeMap(211040300, "under00");
	}
}