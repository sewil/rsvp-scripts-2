using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = chr.Quests.GetQuestData(3);
		
		if (quest == "")
		{
			self.say("Oh, a traveler!! Nice, right on time... I have a favor to ask, will you do it for me? Go a little more to the right and you'll find a #bhouse with the orange roof#k.");
			self.say("That's my house. I have a little brother #r#p2001##k that's at home, so can you please ask him what he wants for dinner? Stand in front of the door, press the #bup arrow#k and then you'll be able to enter the house.");
			SetQuestData(3, "1");
		}
		else if (quest == "1")
		{
			self.say("Haven't met #p2001# yet? Press the up arrow in front of the door!");
		}
		else if (quest == "2")
		{
			self.say("He wants the mushroom soup? I guess that's our dinner right there then. Thanks for doing me a favor.");
			AddEXP(3);
			SetQuestData(3, "end");
			QuestEndEffect();
			
			if (GetQuestData(1500) != "1")
			{
				SetQuestData(1500, "1");
				ToggleUI("Guide", true);
			}
		}
		else
		{
			self.say("I will make a mushroom soup for #p2001#. Is there a fresh mushroom?");
		}
	}
}