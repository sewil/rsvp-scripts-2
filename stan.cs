using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Alex()
	{
		string quest = GetQuestData(1000500);
		
		if (quest == "a")
		{
			if (ItemCount(4000007) < 50 || ItemCount(4000002) < 100)
			{
				self.say("You want to talk to me? I'm the chief of this town, and I have no time for a conversation with a person like you. If you really want to talk to me, then collect these materials for me to fix up the town. #b#e50#n #t4000007#s#k and #b#e100#n #b#t4000002#s#k, and then I'll think about it.");
				return;
			}
			
			int ask1 = AskMenu("Hmmm ... who are you? I don't think we've ever met.#b",
				(0, " I'm sorry. I'm just a traveler walking around. Don't mind me."),
				(1, " Well, I'm here at the request of #p1052000# to see you. Please give me 5 minutes."),
				(2, " Haha ... isn't it beautiful out here today?"));
				
			if (ask1 == 0)
			{
				self.say("Just a traveler?? What do you think this place is, a tourist attraction?? Shame on you ... get out of my face right this minute!!");
				return;
			}
			
			if (ask1 == 2)
			{
				self.say("I see ... it's a beautiful day, indeed ... or not! I have no time for a conversation like this with you! Don't bother me anymore and leave right this minute!!!!");
				return;
			}
			
			int ask2 = AskMenu("What? #p1052000#?? I've never had a son like him! Get out of here!#b",
				(0, " Ah, yes sir. Sorry for bothering you. I'll be leaving now..."),
				(1, " #p1052000# wants to be here."),
				(2, " Stop it now! #p1052000# is really sorry for running away!"));
				
			if (ask2 == 0)
			{
				self.say("You must be hard-headed ... you tell me you know #p1052000# and then you want to leave once you hear some words from me?? I don't even want to speak to you anymore. Leave right this minute!");
				return;
			}
			
			if (ask2 == 1)
			{
				self.say("He wants to come back?? Hahaha ... I don't fall for a lie like that! I'm sure he's happy that he can do whatever he wants once he left home. What, am I wrong?");
				return;
			}
			
			int ask3 = AskMenu("Hmmm ... you're confronting me now ... you must be a somebody! How's #p1052000# doing?#b",
				(0, " #p1052000# is having a hard time since he ran out."),
				(1, " #p1052000# is getting sick of just wandering away."),
				(2, " Why don't you just ask #p1052000# how he's doing?"));
				
			if (ask3 == 0)
			{
				self.say("He's having a hard time? He left home just to live like that?? Hahaha ... well then, please tell him this. #bStay there, live hard, feel the pain, and experience the hard-knock life, just so he'll learn a thing or two about being independent.");
				return;
			}
			
			if (ask3 == 1)
			{
				self.say("Sick of it????!!!! So he wants to come back home now that he's sick of living away from home???! Hahahahahahha! As of this moment, I do not know who #p1052000# is! You and your narrow-mindedness can leave this place right this minute!!!");
				return;
			}
			
			int ask4 = AskMenu("So you want me to ask him myself? Hahahaha! I like you. Hmm ... what do you think about ME?#b",
				(0, " I think you are a great chief of this town."),
				(1, " I think you are too harsh and strict on Alex."),
				(2, " I think your appearance hides the fact that you're actually a person of warmth."));
				
			if (ask4 == 1)
			{
				self.say("Hmmm ... you are quite brutally honest. I like honesty, but I don't appreciate your candor one bit right now. Are you trying to make me mad? I don't think you have a clue in terms of how to handle a person!");
				return;
			}
			
			if (ask4 == 2)
			{
				self.say("Hahahha! You have a very observant set of eyes. How in the world did you think of me like that after seeing me? Was it an honest answer or just a kiss-up? Anyway I have no business talking to you. Leave this minute.");
				return;
			}
			
			int ask5 = AskMenu("Yes, like you said, I'm the chief of this town ... but ever since #p1052000# left I've been losing my authority as the chief!#b",
				(0, " #p1052000# knows he has made some poor decisions in the past, and now he's asking for your forgiveness. Please allow him to come home, for what he needs right now is a compassionate father."),
				(1, " Are you worried less about your son and more about your image in this town?? How is that so?!?!"),
				(2, " #p1052000#'s been wandering around ever since his mother's passing, along with your strict nature. How about forgiving him first?"));
				
			if (ask5 == 0)
			{
				self.say("You don't seem to know #p1052000# too well ... what were you offered in return for helping #p1052000# out? Well, it doesn't really matter, I can never forgive him. Please leave ...");
				return;
			}
			
			if (ask5 == 1)
			{
				self.say("Yes that may be it, but hey! I'm a chief of this town who has lived much longer than you. Are you trying to teach me a lesson? I don't need to hear a word from you anymore.");
				return;
			}
			
			self.say("You know THAT much? Hmmm... it is true that #p1052000# has been fighting back more often ever since Anna passed away. I've been way too busy as a chief and forgot to take care of him. Oh well ... it may have been my fault that he is like that...");
			
			if (!Exchange(0, 4000007, -50, 4000002, -100, 4031007, 1))
			{
				self.say("Hmm... please make some room in your inventory first.");
				return;
			}
			
			AddEXP(300);
			SetQuestData(1000500, "t");
			self.say("It's a very special watch so make sure you don't lose it. #p1052000# is in #m103000000#, right? I have a feeling I know where he \r\nis ... so please take care of this, and ... so long.");
		}
		else if (quest == "t")
		{
			if (ItemCount(4031007) >= 1)
			{
				self.say("You haven't been to #p1052000# yet? Please give #t4001003# to him. It's a very important watch so don't lose it!");
				return;
			}
			
			self.say("Oh my ... did you lose #t4001003#? I told you to be careful with it ...! But don't worry, a townsman actually found it on the street. Here, take it again, and PLEASE don't lose it this time.");
			
			if (!Exchange(0, 4031007, 1))
			{
				self.say("Hmm... please make some room in your inventory first.");
				return;
			}
		}
	}
	
	private void Stan()
	{
		string quest = GetQuestData(1002800);
		
		if (quest == "")
		{
			bool start = AskYesNo("Hoh... I've been looking for someone like you. Great! The thing is, someone from this town picked up this letter from the streets that seems to be very dangerous. He didn't know what to do with it, so he gave it to me, but this looks like something that should be sent somewhere, and I really hope you can be the delivery person for me. What do you think ... would you like to do it?");
			
			if (!start)
			{
				self.say("I guess you don't feel comfortable handling a strange letter like this. If you ever change your mind, however, please talk to me. This letter concerns me more than it should.");
				return;
			}
			
			if (!Exchange(0, 4031099, 1))
			{
				self.say("Please make sure you have room in your etc. inventory to take the letter.");
				return;
			}
			
			SetQuestData(1002800, "s");
			self.say("Great! Please give this letter to the person written here. My eyes may have failed me, but I can read this, and it says #b#p2050001# of Omega Sector#k. I have never heard of a person like this, but I'm sure someone like you that likes to travel all over the world may be able to run into that person...");
			self.say("Go to Ellinia and board on the ship to Orbis, after which you should board on the ship to Ludibrium. Here's hoping you can get this letter to the right person. I'll see you around!");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031099) >= 1)
			{
				self.say("Please give #b#t4031099##k to #b#p2050001# of Omega Sector#k, then board on the ship that heads to Orbis. After that, get on board to the ship that heads to Ludibrium, and you'll be fine! Here's hoping you deliver the letter to the right person. I'll see you around~!");
				return;
			}
			
			self.say("Oh no ... did you lose the #b#t4031099##k that I gave you, by any chance? You should have been more careful. Thankfully, someone from this town picked it up from the streets, so I'll give this to you again. Please don't lose it this time, however. Now, please deliver #t4031099# to #p2050001#, who should be at the Omega Sector.");
			
			if (!Exchange(0, 4031099, 1))
			{
				self.say("Please make sure you have room in your etc. inventory to take the letter.");
				return;
			}
		}
	}
	
	private bool Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1000500)
		{
			if (info == "a" || info == "t")
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (quest == 1002800)
		{
			if (info != "e" && Level >= 20)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		return false;
	}
	
	public override void Run()
	{
		bool checkAlex = Check(1000500);
		bool checkStan = Check(1002800);
		
		string questAlex = GetQuestData(1000500);
		
		if (checkAlex && checkStan)
		{
			AskMenuCallback("My Son...! That ungrateful kid... He just didn't listen to me and ran out. I can never ever forgive him...! He can never come to this town again...!#b",
				(" Alex the Runaway Kid", Alex),
				(" Chief Stan's Letter", Stan));
		}
		else if (checkAlex && !checkStan)
		{
			Alex();
		}
		else if (!checkAlex && checkStan)
		{
			Stan();
		}
		else
		{
			if (questAlex == "e")
			{
				self.say("Did you give the gold watch to Alex? I feel so lonely without him... Anyway, can you please tell him that I will forgive him and he can come home now.");
			}
			else
			{
				self.say("My Son...! That ungrateful kid... He just didn't listen to me and ran out. I can never ever forgive him...! He can never come to this town again...!");
			}
		}
	}
}