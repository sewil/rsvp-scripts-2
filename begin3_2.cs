using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = chr.Quests.GetQuestData(3);
		
		if (quest == "")
		{
			self.say("There is nothing to eat in here~ oh...");
		}
		else if (quest == "1")
		{
			self.say("Ahh, soooo hungry. Where's my sister?!! I was gonna ask her to make me a mushroom soup. Soooo hungry!!");
			self.say("Please tell my sister I really really want #bmushroom soup#k for dinner!");
			SetQuestData(3, "2");
		}
		else
		{
			self.say("What did my sister say? oh... I am so hungry...");
		}
	}
}