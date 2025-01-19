using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(1002600);
		
		if (chr.Level < 25)
		{
			self.say("I'm sorry, but I cannot let anyone inside this place. There's a monster that has invaded Ludibrium, and is currently hidden in this place. It's very dangerous here, so I advise you to leave this minute unless you're involved in this. Now, if you'll excuse me...");
			return;
		}
		
		if (quest1 == "")
		{
			bool start1 = AskYesNo("Man, I've been guarding this gate for so long, that I am beginning to ache here and there. This is sooooo boring. I need something to eat. Hello there. You look like a traveler. Can you help a brother out here?");
			
			if (!start1)
			{
				self.say("You must be really busy. It's not that difficult to do, so if you have a change of heart, then please come talk to me. Otherwise, I may go crazy here and leave this post out of the blue!!");
				return;
			}
			
			SetQuestData(1002600, "s");
			self.say("Sweet~ it can get unbelievably boring standing around in the same place all day long. If I can at least have something to eat, the whole boredom will be a lot less difficult to handle. Inside Eos Tower, you'll find a black mouse-like monster called #b#o3210205##k. Every once in a while, they drop #b#t4031093##k. Can you get me 20 of those?");
			self.say("I can get other kinds of walnuts around Eos Tower, but I'm only craving #b#t4031093##k right now. That fresh #b#t4031093##k with the steam coming out, and that distinct walnut smell... mmmhmmm. I'll be here waiting for you!");
		}
		else if (quest1 == "s")
		{
			if (ItemCount(4031093) < 20)
			{
				self.say("I don't think you have gotten all 20 of #b#t4031093#s#k yet. Inside Eos Tower, you'll find a black mouse-like monster called #b#o3210205##k. Take them down to gather up the #b#t4031093#s#k and get them to me. It'll be so much easier for me to work here without getting bored really quick.");
				return;
			}
			
			self.say("You're back!! This is it!!! 20 of these beautiful #b#t4031093#s#k, and I will be infinitely more entertained at work now. Thank you so much! Here, please take it. I know it isn't much, but...");
			
			int itemID = 0;
			
			if (Job >= 100 && Job < 200) itemID = 1072040;
			else if (Job >= 200 && Job < 300) itemID = 1072076;
			else if (Job >= 300 && Job < 400) itemID = 1072081;
			else if (Job >= 400 && Job < 500) itemID = 1072033;
			else itemID = 1072018;
			
			if (!Exchange(0, 4031093, -20, itemID, 1))
			{
				self.say("Please leave an empty slot in your equip. inventory so you can take my reward!");
				return;
			}
			
			AddEXP(1050);
			SetQuestData(1002600, "e");
			QuestEndEffect();
			self.say("I hope that pair of shoes help you on your journey. I'll give you a good word to my friend #b#p2040002##k, who's standing right next to me. You should talk to him sometime. He'll probably ask you for help, too. Well, I gotta get back to work now. Later!");
		}
		else if (quest1 == "e")
		{
			self.say("You're the one that gathered up the #b#t4031093##k for me. I am still eating those every now and then. Oh, by the way, have you talked to #b#p2040002##k, the guy next to me?");
		}
	}
}