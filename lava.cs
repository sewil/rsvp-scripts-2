using WvsBeta.Game;

// 2032004 - Suspicious Lava
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1006900);
		
		if (quest == "s")
		{
			if (Level < 105)
			{
				self.say("The scorching hot lava is leaving hot tracks everywhere, and it seems to be very hot around it. I can't get any closer to it. Maybe if I was a little stronger...");
				return;
			}
			
			self.say("The scorching hot lava is leaving hot tracks everywhere, and it seems to be very hot around it. Walking up to it, I can feel the scorching heat gripping my skin. I'll have to drop the Dark Tachion here in order to destroy the force of evil once and for all!");
			
			bool start = AskYesNo("Will you destroy all the Dark Tachions that you possess in your inventory?");
			
			if (!start)
			{
				self.say("I should re-observe the lava and prepare myself to destroy the Dark Tachion, the one that contains the evil force of Papulatus.");
				return;
			}
			
			int itemNum = ItemCount(4031196);
			
			if (itemNum < 1)
			{
				self.say("You do not have the Dark Tachion necessary to dump in the lava.");
				return;
			}
			
			if (!Exchange(0, 4031196, -itemNum))
			{
				self.say("You do not have the Dark Tachion necessary to dump in the lava.");
				return;
			}
			
			AddEXP(126000);
			SetQuestData(1006900, "e");
			QuestEndEffect();
			self.say("Every Dark Tachion around has been destroyed, and all the evil forces that accompany with them have been decimated.");
		}
	}
}