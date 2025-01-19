using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (ItemCount(4031018) < 1)
		{
			self.say("Hey, hey!!! Find the #t4031018#! I lost the map somewhere and I can't leave without it.");
			return;
		}
		
		if (ItemCount(4031019) >= 1)
		{
			self.say("You already have the #r#t4031019##k. This scroll is filled with an incredible magic power, so powerful that you should always carry it with you. Go and take this scroll to #r#p9000007##k right away.");
			return;
		}
		
		self.say("Wow, you're incredible. Want to sail with us? What? You're busy? Hm... You can't. Instead, I'll take you to another interesting place. I'll take you to the map whenever you're ready.");
		
		if (!Exchange(0, 4031018, -1))
		{
			self.say("Oh no... Are you sure you have a #t4031018#? Check again.");
			return;
		}
		
		SetQuestData(9000000, "victoria");
		ChangeMap(109050000);
	}
}