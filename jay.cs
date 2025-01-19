using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1005200);
		
		if (Level < 25 || Job == 0)
		{
			self.say("I really love it here, and my goal is to make Henesys an even better place to live.");
			return;
		}
		if (quest == "")
		{
			bool start = AskYesNo("Hello. My name is #b#p1012109##k, Chief Stan's oldest son. I am sure you've met my father before. Anyway, I have a huge dilemma that has been bothering me lately, and it's a very important matter. I've been looking for someone, someone trustworthy and dependable enough to help me take on an important matter, and the sooner the better. Will you ... help me out?");
			
			if (!start)
			{
				self.say("Oh, re...really? Do know of anyone around that may help me out? I really really need this help, you know. If only I was stronger than I am right now?");
				return;
			}
			
			SetQuestData(1005200, "s1");
			self.say("Oh, thank you... actually, the moment you came and talk to me, I had a feeling that you'd help me out on something like this.\nOur job is to recover #bMaple History Books#k, which has every historical detail of this world from its creation. What happened was ...\nwell, this is going to take a while, so you may want to grab a seat next to me.");
			self.say("These books have been kept safely by important people in this place, until something happened recently. One of those books have been safely kept away, but ... the other two books are either stolen or at least in danger of being stolen. We need to find #ball 3 volumes of [Maple History Book]#k and give them to #r#p2041022# of Ludibrium#k.");
			self.say("#b#t4031157##k, the one that covers the creation of MapleStory, was on its way to Orbis, along with the person responsible for it, but ... nothing's been heard from the person since. I don't think the book is in someone else's hands, and ... it should be somewhere out there ... we lost contact of him #rafter boarding on the ship to Orbis#k... Was he ambushed by #o8150000#? Maybe it's hidden well inside the ship?");
			self.say("#b#t4031158##k contains the developmental part of MapleStory, and how it rose to become the society that it is today. That book is #rwell taken care of by Hines of Ellinia, who stores it in a box back at home#k, so all you need to do is ask him for a favor, and he'll give the book to you.");
			self.say("Lastly, #b#t4031159##k is apparently #rstolen by a bunch of #o3230306#'s in Ludibrium#k. Defeat a whole group of #o3230306#'s and one of them may actually cough-up the book. The book contains important information on the background of the monsters' stories, along with ways to combat them. This book should never be in the hands of a monster. Please gather up all 3 books and deliver them to #b#p2041022##k...\n\n#i4031157#   #i4031158#   #i4031159#");
		}
		else if (quest == "s1" || quest == "s2")
		{
			self.say("Have you met up with the person I asked you to meet? You may want to start hurrying things up...");
		}
		else if (quest == "s3")
		{
			if (ItemCount(4031160) < 1)
			{
				self.say("If you have completely taken care of all the requirements for this, then you would have gotten #t4031160# from #p2041022#...but you'll have to show me...");
				return;
			}
			
			self.say("Are you back already? Did you get the #bMaple History Books#k sent? Did you receive a #b#t4031160##k  from #b#p2041022##k??");
			
			if (!Exchange(0, 4031160, -1, 1002436, 1))
			{
				self.say("Oh... please leave some room in your equip. inventory so I can reward you...");
				return;
			}
			
			AddEXP(560);
			SetQuestData(1005200, "e");
			QuestEndEffect();
			self.say("Oh, wow. Thank you so much! I can't believe how excited I'm to hand the book over to the King of Ludibrium. Hmmm, what would be a perfect gift for my friend? Ah, here's a hat my dad used to wear during his traveling days. It may be old and used, but it's very valuable nontheless. Try it on!");
		}
		else if (quest == "e")
		{
			self.say("You're the one that helped me recover the history book. Your good deeds will be remembered for generations to come!");
		}
	}
}