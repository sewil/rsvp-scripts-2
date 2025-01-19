using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1001100);
		
		long isPet = AskPet("");
		
		int start = AskMenu("Do you have any business with me?#b",
			(0, " Please tell me about this place."),
			(1, " I'm here through a word from Mar the Fairy..."));
			
		if (start == 0)
		{
			if (ItemCount(4031035) >= 1)
			{
				self.say("Take that letter, jump over the obstacles with your pet and take the letter to my brother #p1012007#. Take the letter to him and something good will happen to your pet.");
				return;
			}
			
			bool letter = AskYesNo("This is the road where you can walk with your pet. You can just walk around with it, or you can train your pet to go through the obstacles. If you aren't too close with your pet yet, that may present a problem and he will not follow your command as much... so, what do you think? Wanna train your pet?");
			
			if (!letter)
			{
				self.say("Hmmm... too busy to do that right now? Anyway, if you want, come back and look for me.");
				return;
			}
			
			if (!Exchange(0, 4031035, 1))
			{
				self.say("Your etc. inventory is full! I can't give you the letter unless there is space in your inventory. Leave a free slot and then talk to me.");
				return;
			}
			
			self.say("Ok, here's the letter. He wouldn't know I sent you if you just went there straight, so go through the obstacles with your pet, go to the very top, and then talk to #p1012007# to give him the letter. It won't be hard if you pay attention to your pet while going through obstacles. Good luck!");
		}
		else if (start == 1)
		{
			if (isPet == 0 || quest != "s")
			{
				self.say("Hey, are you sure that you met #b#p1032102##k? Don't lie to me if you've never met her, because that's obvious. It wasn't even a good lie!");
				return;
			}
			
			if (ItemCount(4031034) >= 1)
			{
				self.say("Hmmm... you already have #b#t4031034##k. Take this scroll to #b#p1032102##k of #m101000000#.");
				return;
			}
			
			self.say("Are you here with a #bpet#b that doesn't move#k? It's sad to see... Huh? Did you come here through #b#p1032102##k? I see... #b#t4031034##k, uh... hey hey~ if only I had it with me... what, what is this in my pocket?");
			self.say("Wow!!! It's... this is #b#t4031034##k? Ah, right... #p1012005# probably took my clothes and ran off or something... darn it! I told him not to just take other people's clothes and wear them... Well, it's not mine anyway... do you need this? Hmm...");
			bool startQuiz = AskYesNo("Don't think I can just give it to you! I need to test your knowledge of pets in general. Horrible for a pet if its owner doesn't even know how to take care of it. You need to get everything right or you won't get the scroll. What do you think? Want to take the test?");
			
			if (!startQuiz)
			{
				self.say("What?! Are you already giving up? If you had raised your pet well, this would be a piece of cake! Look for me when you change your mind.");
				return;
			}
			
			self.say("Alright! 5 questions and you need to answer them all correctly! Are you ready? Let's go!");
			
			int ask1 = AskMenu("Question 1) In which town is #p1012004#, the person who sells #t2120000#?#b",
				(0, " #m104000000#"),
				(1, " #m100000000#"),
				(2, " #m102000000#"),
				(3, " #m101000000#"),
				(4, " #m103000000#"),
				(5, " #m105040300#"));
			
			if (ask1 != 1)
			{
				self.say("Wrong! You really don't know much... did you really raise a pet? That's horrible!");
				return;
			}
			
			int ask2 = AskMenu("Question 2) Haha... that was only practice! Right, so... among these people, choose someone who has nothing to do with pets.#b",
				(0, " #p1032102#"),
				(1, " #p1012005#"),
				(2, " #p1012101#"));
			
			if (ask2 != 2)
			{
				self.say("Wrong! You really don't know much... did you really raise a pet? That's horrible!");
				return;
			}
			
			int ask3 = AskMenu("Question 3) Very easy, right? Alright, among these descriptions of pets, choose the one that doesn't make sense.#b",
				(0, " To name a pet, you need the Name Tag."),
				(1, " When you give a command to the pet and it obeys, sometimes the level of closeness increases."),
				(2, " Don't feed the pet well, and the level of closeness goes down."),
				(3, " Pets can attack monsters with their owners."));
			
			if (ask3 != 3)
			{
				self.say("Wrong! You really don't know much... did you really raise a pet? That's horrible!");
				return;
			}
			
			int ask4 = AskMenu("Question 4) Two more to go! Well, at which level do pets begin to use human phrases?",
				(0, " #e1. #n#bLevel 5#k"),
				(1, " #e2. #n#bLevel 10#k"),
				(2, " #e3. #n#bLevel 15#k"),
				(3, " #e4. #n#bLevel 20#k"));
			
			if (ask4 != 1)
			{
				self.say("Wrong! You really don't know much... did you really raise a pet? That's horrible!");
				return;
			}
			
			int ask5 = AskMenu("Question 5) Last question! #p1012004# of #m100000000# sells #t2120000#. How much does it increase the level of fullness?#b",
				(0, " 10"),
				(1, " 20"),
				(2, " 30"),
				(3, " 40"));
			
			if (ask5 != 2)
			{
				self.say("Oh no!!! What a waste! It's the last question! Don't give up!");
				return;
			}
			
			self.say("Right! Hmmm... you know a lot about pets. Cool, since you know a bunch, I'll give you the scroll with satisfaction. I know it's not mine and all, but... who would wear someone else's clothes and leave something so important in them? Here you go!");
			
			if (!Exchange(0, 4031034, 1))
			{
				self.say("Tsk tsk... do you have an available slot in your etc. inventory? I can't give it to you if it's full.");
				return;
			}
			
			self.say("Okay... So, all you need to do now is take it and go talk to #p1032102# also carrying a #b#t4070000##k... Hahaha very good luck to you!");
		}
	}
}