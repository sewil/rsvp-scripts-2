using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1);
		
		if (quest == "")
		{
			self.say("You must be the new traveler. Still foreign to this, huh? I'll be giving you important informations here and there so please listen carefully and follow along. First if you want to talk to us, #bdouble-click#k us with the mouse.");
			self.say("#bLeft, right arrow#k will allow you to move. Press #bAlt#k to jump. Jump diagonally by combining it with the directional cursors. Try it later.");
			bool askStart = AskYesNo("Man... the sun is literally burning my beautiful skin! It's a scorching day today. Can I ask you for a favor? Can you get me a #bmirror#k from #r#p2100##k, please?");
			
			if (!askStart)
			{
				self.say("Don't want to? Hmmm... come back when you change your mind.");
				return;
			}
			
			SetQuestData(1, "1");
			self.say("Thank you... #r#p2100##k will be on the hill down on the east side hanging up the laundry. The mirror looks like this #i4031003#.");
		}
		else if (quest == "1")
		{
			self.say("Haven't met #r#p2100##k yet? She should be on a hill down on east side...it's pretty close from here so it will be easy to spot \r\nher...");
		}
		else if (quest == "2")
		{
			if (ItemCount(4031003) < 1)
			{
				self.say("Did you lose the mirror? Ask her for it once more.");
				return;
			}
			
			self.say("Oh wow! You brought #p2100#'s mirror! Thank you so so much. Let's see... no skin damage whatsoever...");
			
			if (!Exchange(0, 4031003, -1))
			{
				self.say("Are you sure you have the mirror?");
				return;
			}
			
			AddEXP(1);
			SetQuestData(1, "end");
			QuestEndEffect();
			self.say("If you go right, you will see the shiny spot. We call that as a \"Portal\". If you press #bup-arrow#k, you will get to the next place. So long!");
			
			if (GetQuestData(1500) != "1")
			{
				SetQuestData(1500, "1");
				ToggleUI("Guide", true);
			}
		}
		else
		{
			self.say("Now I can take a look at my face with this mirror. It looks alright.");
		}
	}
}