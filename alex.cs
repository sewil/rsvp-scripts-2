using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1000500);
		
		if (Level < 20)
		{
			self.say("It's been a months since I ran away from home, and frankly I'm sick of wandering around strange places now. But I feel weird about going back home...");
			return;
		}
		
		if (quest == "")
		{
			self.say("Hmmm ... hey, hear me out. A couple of days ago I ran away from home because of my very straightlaced father. And so here I am, here at #m103000000#, just wandering around. These days, however, I'm getting sick of living the life of a wanderer ... even the money i took secretly from home has all been spent already ... I shouldn't have run away in the first place.");
			bool askStart = AskYesNo("I can't just go back home acting like nothing ever happened, though ... I'm sorry but can you find a way to calm my father down and convince him to let me back in? I have a feeling if I just walk in one day, he'll beat the crap out of me. Seriously. I'm sure you may be busy and all, but PLEASE help me.");
			
			if (!askStart)
			{
				self.say("So you can't do me a favor because I'm an immature kid who ran away from home? I see I see ... well, nevermind. BUT if you ever feel like changing your mind, then please drop by. You will be rewarded well for helping me out...");
				return;
			}
			
			SetQuestData(1000500, "a");
			self.say("Thank you! My father's actually #p1012003# from #m100000000#. Because he's a man of power, he's also very very strict. I can't communicate with him at all, so please convince him on my behalf to let me be back home ... ok? My father has a very explosive personality to go along with his usual crankiness, so if you talk to him in a submissive manner, that won't work either ... well, I'm sure you'll be fine.");
			self.say("If you found a way to convince my father, then please get the #t4001003# from him. It will be hard for to get it, but... The #t4001003# is actually an item left by my mother before she passed away. He always said he'll never give it to a guy like me ... Anyway, I'll be waiting for you here, so please come back fast!");
		}
		else if (quest == "a")
		{
			self.say("You haven't met my father yet? He's the chief of #m100000000#. Please convince my father to let me back in. And as a sign of proof, please get #t4001003#, the item left by my mother before passing away, from him. Please help me. I'm flat broke now ...");
		}
		else if (quest == "t")
		{
			if (ItemCount(4031007) < 1)
			{
				self.say("You haven't met my father yet? He's the chief of #m100000000#. Please convince my father to let me back in. And as a sign of proof, please get #t4001003#, the item left by my mother before passing away, from him. Please help me. I'm flat broke now ...");
				return;
			}
			
			self.say("What? You DID convince my father to let me in??? That's just unbelievable ... I'm amazed that you changed his heart, the Mr. Holier-Than-Thou ... you're one incredible person!!! Phew ... now I can say goodbye to the life of a wanderer. Thank you so so much!");
			self.say("Whoa ... this #t4001003# is ... it's my mother's, for sure ... I should have been much a much better son to her when she was alive, but instead I'm here regretting it while she passed away ... anyway, you did me a huge favor, so ... here! It isn't much, but please take it!");
			
			Random rnd = new Random();
			int[] earrings = {1032004, 1032005, 1032006, 1032007};
			
			int itemID = earrings[rnd.Next(earrings.Length)];
			
			if (!Exchange(0, 4031007, -1, itemID, 1))
			{
				self.say("I want to give you the earrings, so please make some space in your equip inventory.");
				return;
			}
			
			AddEXP(550);
			SetQuestData(1000500, "end");
			QuestEndEffect();
			self.say("I got this earing from the friends I met while traveling all around the island. Might as well look good traveling, right? Hehe ... well ... this is an important item to me, but here it is. It's for you. Hopefully it'll help you on your journey ...");
		}
		else
		{
			self.say("Thanks for the help the other day. I'd love to go back home, but I have to at least say my goodbyes to everyone that helped me out here. These people will actually miss me, you know ...");
		}
	}
}