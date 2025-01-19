using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string betty1 = GetQuestData(1004901);
		
		if (betty1 == "" || betty1 == "b0")
		{
			self.say("I'm Anne, the daughter of Dr. Betty.");
		}
		else if (betty1 == "b1")
		{
			int ask1 = AskMenu("Can I ... help you??#b",
				(0, " Your dad asked me to see you."),
				(1, " Your mom asked me to see you."));
				
			if (ask1 != 1)
			{
				self.say("Hey, I don't have a dad. You CREEP!!!! Who are you???");
				return;
			}
			
			int ask2 = AskMenu("My mom sent you here? For what?#b",
				(0, " She asked me to get some preserved Drake's Skulls from you.."),
				(1, " She asked me to get a crushed Drake's Skull from you."));
				
			if (ask2 != 0)
			{
				self.say("I don't have any of crushed Drake's skulls here. Something's not right about you.");
				return;
			}
			
			int ask3 = AskMenu("I know I have them. I'll have to check and see if you're indeed sent by my mom, though. What's her name?#b",
				(0, " Bettie"),
				(1, " Batty"),
				(2, " Betty"));
				
			if (ask3 != 2)
			{
				self.say("You're wrong. A stranger indeed.");
				return;
			}
			
			int ask4 = AskMenu("Where did you meet my mom?#b",
				(0, " Perion"),
				(1, " Ellinia"),
				(2, " Kerning City"),
				(3, " Henesys"),
				(4, " Sleepywood"));
				
			if (ask4 != 1)
			{
				self.say("Liar!!! Who are you!!!! HELP!!");
				return;
			}
			
			int ask5 = AskMenu("What's the color of her shoes?#b",
				(0, " Black"),
				(1, " Blue"),
				(2, " Red"),
				(3, " Yellow"));
				
			if (ask5 != 2)
			{
				self.say("You're wrong. A stranger indeed.");
				return;
			}
			
			int ask6 = AskMenu("What's the color of the book that my mom is holding?#b",
				(0, " Black"),
				(1, " Blue"),
				(2, " Red"),
				(3, " Green"));
				
			if (ask6 != 1)
			{
				self.say("Wrong. Are you sure you've met my mom?");
				return;
			}
			
			int ask7 = AskMenu("Last question. What's the color of the earrings that my mom is wearing?#b",
				(0, " Black"),
				(1, " Blue"),
				(2, " Red"),
				(3, " Yellow"));
				
			if (ask7 != 3)
			{
				self.say("You're wrong. A stranger indeed.");
				return;
			}
			
			self.say("Oh my goodness, you got them all right! My mom DID send you here.");
			bool start = AskYesNo("#b#t4031151##k is here. Will you get this to my mom?");
			
			if (!start)
			{
				self.say("You don't need it? I thought you were sent here to get \r\n#b#t4031151##k from me. If you don't need it, then oh \r\nwell ...");
				return;
			}
			
			if (!Exchange(0, 4031151, 1))
			{
				self.say("Make some room in your etc. inventory first!!");
				return;
			}
			
			AddEXP(100);
			SetQuestData(1004901, "b2");
			self.say("She asked you this for her work, right? I hope her studies get done soon.");
		}
		else if (betty1 == "b2")
		{
			if (ItemCount(4031151) >= 1)
			{
				self.say("She asked you this for her work, right? I hope her studies get done soon.");
				return;
			}
			
			self.say("You lost that????? Sigh ... please don't lose it again.");
			
			if (!Exchange(0, 4031151, 1))
			{
				self.say("Make some room in your etc. inventory first!!");
				return;
			}
		}
		else
		{
			self.say("Hey, you wanna hang out with me?");
		}
	}
}