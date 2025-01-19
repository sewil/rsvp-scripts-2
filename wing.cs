using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Homework()
	{
		string qWing1 = GetQuestData(1005400);
		
		if (qWing1 == "")
		{
			bool start = AskYesNo("Hey there, human! Do you have any time on your hands? If not, then oh well... I have something to ask you ... well, not really ask, but I have a favor to ask. Are you interested??");
			
			if (!start)
			{
				self.say("Fine, I don't care! I can always find someone else!");
				return;
			}
			
			SetQuestData(1005400, "s");
			self.say("There's this teacher in my Magic School that scares the bejesus out of everyone. I mean, he's as scary as they come. Anyway, he gave us homework and we have to make a potion, but I am swamped with homework from other classes that I don't know if I can do it.");
			self.say("I need #b30 tree branches, 30 squishy liquids, and 10 slime bubbles.#k Please get me those immediately!");
			self.say("So where am I going to use that potion? That's none of your business. Know this, though. If you get me the ingredients, I will reward you well for your effort. I can't stand owing something to a human.");
		}
		else if (qWing1 == "s")
		{
			if (ItemCount(4000010) < 10 || ItemCount(4000003) < 30 || ItemCount(4000004) < 30)
			{
				self.say("I don't think you've gathered them all up. Hurry up, I don't have much time. I have to start memorizing the spells after I'm done with the potion homework!");
				return;
			}
			
			self.say("Oh you got them all! I need to make this potion fast and get on with other homework. Thanks to you I think I can finish my homework. Here's a potion I made from earlier. I don't need it, so you should take it.");
			
			if (!Exchange(0, 4000003, -30, 4000004, -30, 4000010, -10, 2000003, 25))
			{
				self.say("Hey, leave some space in your use inventory first.");
				return;
			}
			
			AddEXP(250);
			SetQuestData(1005400, "e");
			QuestEndEffect();
			self.say("I don't need you now, so please leave!");
		}
	}
	
	private void FlyingPill()
	{
		string qIcarus4 = GetQuestData(1005503);
		
		if (qIcarus4 == "s1")
		{
			int ask1 = AskMenu("What's a human doing here? I have nothing to talk to you. Please leave.#b",
				(0, " I don't think I want to talk to you, either!"),
				(1, " About the \"Flying Pill\"..."));
			
			if (ask1 == 0)
			{
				self.say("Whatever. Leave!");
				return;
			}
			
			int ask2 = AskMenu("Hey, how can a human like you know of such a medicine? Well, even if you know of it, I don't think I feel like talking about it to someone like you!#b",
				(0, " You are one rude, despicable kid!!"),
				(1, " I really need that pill, though."));
			
			if (ask2 == 1)
			{
				self.say("Whether you need it or not, that's your business, not mine.");
				return;
			}
			
			int ask3 = AskMenu("What?!! A kid? Trust me, I am NOT a kid!!#b",
				(0, " Sorry, didn't mean to be rude"),
				(1, " Aren't you much too young to talk to me like that anyway?"),
				(2, " I wouldn't even be here if not for Icarus..."));
			
			if (ask3 == 0)
			{
				self.say("Get out of my face. Bye!");
				return;
			}
			
			if (ask3 == 1)
			{
				self.say("Hey, you're talking to a fairy! Of course I've lived much longer than you! In any case, I don't feel like talking to you, so just leave!");
				return;
			}
			
			bool start2 = AskYesNo("Icarus? You're here for him? He's the only friend of mine that is human ... and since you're here at his request, I'll make you the pill. You'll need to know that the ingredients I need are really hard to find. I wonder if you are qualified enough to gather them all up.");
			
			if (!start2)
			{
				self.say("I knew you'd be like this. It's way too tough for a weakling like you. At least you're aware of your limitations. Now get out of here!");
				return;
			}
			
			SetQuestData(1005503, "s2");
			self.say("Okay. You seem like the kind of person that really cares about the promises made with friends. You're not as bad as I thought. Get me #b50 #t4000036#s#k and #b20 #t4031165##k and I'll make you the #b#t4031163##k. The Witch Grass Leaves grows on swamps, and it's not the easiest to extract. You HAVE to #bextract from the right side#k in order to do it right. Good luck on that.");
		}
		else if (qIcarus4 == "s2")
		{
			if (ItemCount(4031165) < 20 || ItemCount(4000036) < 50)
			{
				self.say("Were you even listening to what I was saying? I need #b50 #t4000036#s#k and #b20 #t4031165#s#k! Get it??");
				return;
			}
			
			int ask4 = AskMenu("Whoa you got them all? What's this? The leaves are dry! How am I going to make the Flying Pill with crappy ingredients like this?#b",
				(0, " Hey, what's your problem??"),
				(1, " They look fine to me."));
				
			if (ask4 == 0)
			{
				self.say("What? I don't feel like making it right now. Come back some other time.");
				return;
			}
			
			self.say("What are you trying to say? You don't even know what you're talking about! I'll use these ingredients for now, but it's not my responsibility if it comes out less than perfect. The ingredients you got me stink!");
			self.say("Okay, I mix this with that, and add that with this, and ... okay, I'm done! Here, take it.");
			
			if (!Exchange(0, 4000036, -50, 4031165, -20, 4031163, 1))
			{
				self.say("I'll give you the #t4031163# once you leave some room for it in your etc. inventory!");
				return;
			}
			
			AddEXP(100);
			SetQuestData(1005503, "s3");
			self.say("It's a very rare pill, and it should only be taken by Icarus, and no one else. If you have any desire to take that pill for yourself, then don't even think about it. It will only work on Icarus.");
		}
		else if (qIcarus4 == "s3")
		{
			if (ItemCount(4031163) >= 1)
			{
				self.say("You haven't given the pill to Icarus yet? I thought I told you the pill doesn't work on anyone else but him, meaning YOU CAN'T FLY WITH IT. Now that you know, go see Icarus immediately and give him the pill, alright?");
				return;
			}
			
			self.say("Okay, I mix this with that, and add that with this, and ... okay, I'm done! Here, take it.");
			
			if (!Exchange(0, 4031163, 1))
			{
				self.say("I'll give you the #t4031163# once you leave some room for it in your etc. inventory!");
				return;
			}
			
			self.say("It's a very rare pill, and it should only be taken by Icarus, and no one else. If you have any desire to take that pill for yourself, then don't even think about it. It will only work on Icarus.");
		}
	}
	
	private void NewWorld()
	{
		string quest = GetQuestData(1005800);
		
		if (quest == "")
		{
			bool start = AskYesNo("Hey, you, human! Yeah, you! You look quite strong enough. Are you interested in becoming even stronger?");
			
			if (!start)
			{
				self.say("Not interested? You don't want to make yourself stronger, huh?");
				return;
			}
			
			if (!Exchange(0, 4031197, 1))
			{
				self.say("Cool, but you need to make some room in your etc. inventory first. I have something important to give you.");
				return;
			}
			
			SetQuestData(1005800, "s1");
			self.say("I knew you'd be interested. Have you heard of Ossyria? I think you'll be much stronger once you start training there. Face new monsters, interact with new surroundings, and train yourself to become much more powerful than you ever were in Victoria Island.");
			self.say("If you ever stop by Orbis, please meet up with my friend\r\n#b#p2012011##k. I have to give her something. It's called #b#t4031197##k, and it's been passed down from generation to generation.");
			self.say("Ever since Kriel saw this, she's been badgering me on and on about giving it to her. She's the one that makes all the wizard-related items and weapons at Orbis, and she thinks she can make something powerful out of it. Anyway, if you ever drop by Orbis soon, I want you to give this to her.");
		}
		else if (quest == "s1")
		{
			if (ItemCount(4031197) >= 1)
			{
				self.say("You still haven't met #bKriel the Fairy#k? She's at Orbis.");
				return;
			}
			
			self.say("Huh? Did you lose the #b#t4031197##k? Be more careful this time!");
			
			if (!Exchange(0, 4031197, 1))
			{
				self.say("Make some room for it in your etc. inventory first.");
			}
		}
	}
	
	private bool Check(int quest)
	{
		string info = GetQuestData(quest);
		
		string qIcarus4 = GetQuestData(1005503);
		
		if (quest == 1005400)	// I Need Help on My Homework!
		{
			if (info != "e" && Level >= 10)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (quest == 1005503)	// Icarus and the Flying Pill
		{
			if (info == "s1" || info == "s2" || info == "s3")
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (quest == 1005800)	// To the New World
		{
			if ((info == "" || info == "s1") && Level >= 40)
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
		bool cWing1 = Check(1005400);
		bool cWing2 = Check(1005800);
		bool cIcarus4 = Check(1005503);
		
		string qWing1 = GetQuestData(1005400);
		
		string dialogue = "...";
		
		if (qWing1 == "e")
		{
			dialogue = "I've got a lot of work to do! I'd appreciate it if you don't bother me for now.";
		}
		
		if (Level < 10)
		{
			self.say(dialogue);
			return;
		}
		
		if (cWing2)
		{
			if (cWing1 || cIcarus4)
			{
				AskMenuCallback(dialogue + "#b",
					(" I Need Help on My Homework!", cWing1, Homework),
					(" Icarus and the Flying Pill", cIcarus4, FlyingPill),
					(" To the New World", cWing2, NewWorld));
			}
			else
			{
				NewWorld();
			}
		}
		else if (cWing1)
		{
			Homework();
		}
		else if (cIcarus4)
		{
			FlyingPill();
		}
		else
		{
			self.say(dialogue);
		}
	}
}