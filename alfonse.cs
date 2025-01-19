using WvsBeta.Game;

// 2012020 Alfonse Green
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1005900);
		
		if (Level < 40)
		{
			self.say("Have a nice day~");
			return;
		}
		
		if (quest == "")
		{
			bool start = AskYesNo("Hi there, if you aren't busy and all, then please hear me out. I have something I really want to drink right now, and I need your help. Can you please help me out?");
			
			if (!start)
			{
				self.say("Please help me out here. If you changed your mind, then please talk to me. I have something I really want to drink.");
				return;
			}
			
			SetQuestData(1005900, "s");
			self.say("Thanks for saying yes. I am a huge fan of Nependeath Juice, you know. Just thinking about it makes me drool?");
			self.say("The problem is that the main ingredient for the Nependeath Juice, the seed of Nependeath, can only be obtained by killing the dangerous Nependeath. It's also hard to squeeze out the rock-solid seed with my bare hands.");
			self.say("I only know of one person that can do it in Orbis, and that person is Ericsson. Too bad I've come up to him for the juice way too often, to the point where he doesn't want to make it for me.");
			self.say("So here's the deal. Can you please come up to Ericsson in place of me and get the Nependeath Juice made for me? If you're the one asking, I'm sure he'll say yes to that.");
		}
		else if (quest == "s" || quest == "1" || quest == "2" || quest == "3" || quest == "4")
		{
			self.say("Please go see Ericsson. Only he can make the #bSap of Nependeath#k.");
		}
		else if (quest == "5")
		{
			if (ItemCount(4031202) < 1)
			{
				self.say("Please go see Ericsson. Only he can make the #bSap of Nependeath#k.");
				return;
			}
			
			self.say("Wow, you're back!! You won't believe how much I waited for you. I couldn't do anything today other than daydream about the wonders of #t4031202#.");
			
			if (!Exchange(0, 4031202, -1, 1002006, 1))
			{
				self.say("Are you sure you have #b#t4031202##k? If so, make some room in your equip. inventory first!");
				return;
			}
			
			AddEXP(12500);
			AddFame(1);
			SetQuestData(1005900, "e");
			QuestEndEffect();
			self.say("I knew it! #t4031202# is by far the best thing in the world!! Thank you so much for bringing joy back into my life! Here, please take this helmet. It's my way of saying thanks to you for making me smile again. This helmet is very rare in that you can't get it anywhere else but here. See you around!");
		}
		else if (quest == "e")
		{
			self.say("I just drank Nependeath juice~ It's so good.");
		}
	}
}