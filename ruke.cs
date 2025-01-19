using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
    public override void Run()
	{
		string Luke1 = GetQuestData(1000800);
		string Luke2 = GetQuestData(1000801);
		
		if (Job == 0 || Level < 15)
		{
			self.say("Okay, who just woke me up?? I hate anyone that wakes me up from my nap ... huh? What am I doing? What do you think I'm doing? Of course I'm guarding the entrance!! This is the entrance to the #bVictoria Island : Center Dungeon#k. You have to be careful in there; the monsters you've faced don't even compare to the ones you're about to face in here. I suggest you don't go in there unless you can protect yourself. Okay, nap time!");
			return;
		}
		
		if (Luke1 == "")
		{
			bool askStart = AskYesNo("Hmmm... wait! You must be pretty strong, huh? I have a favor to ask you... being a good son, every year I make my mom a special, healthy & tasty dish, but I don't have any free time these days from all this guarding. I'm sorry, but would it be okay if you can help me get the ingredients needed for the dish?");
			
			if (!askStart)
			{
				self.say("Must be busy here and there, huh? Please come back and do me a favor when you get some spare time.");
			}
			else
			{
				SetQuestData(1000800, "s");
				self.say("Alright! This year I'm trying to make my mom a very tasty Snake Drink! Can you get me #b100 #t4000034#s#k, #b10 of \r\n#t4000042#s#k, and, for dessert, #b1 #t2020000##k please? Please find me once you have gathered them all up!");
			}
		}
		else if (Luke1 == "s")
		{
			if (ItemCount(2020000) < 1 || ItemCount(4000034) < 100 || ItemCount(4000042) < 10)
			{
				self.say("This year I'm trying to make my mom a very tasty Snake Drink! Can you get me #b100 #t4000034#s#k, #b10 #t4000042#s#k, and, for dessert, #b1 #t2020000##k please? Please find me once you have gathered them all up!");
				return;
			}
			
			self.say("Oh my... you actually gathered them all up!! This will definitely help me make a very tasty Snake Drink... it's a very rare drink so I wouldn't be sharing this to anyone else, but I'll make an exception with you ... so when the drink is done, please drop by and have it with us. Promise?");
			self.say("Oh yeah ... since you worked hard at getting me all that ingredients, I need to give you something in return. Now, what will be a good one... Oh yeah! around here you'll see lots of shiny, sparkling objects. I've been collecting a lot of those, but as of this moment, they are yours. It will help you through your journey. Here, take it.");
			
			if (SlotCount(4) < 1)
			{
				self.say("Please make sure you have room in your etc. inventory so I can reward you.");
				return;
			}
			
			Random rnd = new Random();
			int[] rewards = {4021000, 4021001, 4021002, 4021003, 4021004, 4021005, 4021006, 4021007};
			
			int itemID = rewards[rnd.Next(rewards.Length)];
			
			if (!Exchange(0, 4000034, -100, 4000042, -10, 2020000, -1, itemID, 1))
			{
				self.say("Are you sure you have the ingredients I asked for?");
			}
			
			AddEXP(300);
			SetQuestData(1000800, "end");
			QuestEndEffect();
			self.say("Got it? Thanks for you help... Now I must rush back home... So long~");
		}
		else
		{
			if (Luke2 == "" && Job >= 100 && Job < 200 && Level >= 50)
			{
				self.say("Hey! You're the one that helped me make a tasty Snake Drink for my mom! I'm sorry to say this, but ... my mom and I drank it all... hehe... anyway, you look much stronger then before! Maybe you may even surpass me one day...well, that's not going to happen though hahahah...");
				self.say("Ok, I think you can do it since you've gotten much stronger since then... actually I've been thinking about taking up a journey somewhere ... I'm getting tired of being the security guy here... so I'm trying to make a solid equipment for myself, and to do that, I visited #p1022004# from #m102000000#, and ... he wants me to get some RIDICULOUS materials for it!!! Those are so rare to begin with...");
				bool askStart = AskYesNo("I'm trying to be a warrior like you, and um... can you get me the materials #p1022004# asked me to get? I tried, but it's too hard for me... Don't worry, I'll reward you well for your work. What do you think? Isn't it good for both of us?");
				
				if (!askStart)
				{
					self.say("You must be really busy right now. If you ever have spare time, please come back and do me that favor! It's very important to me!");
					return;
				}
				
				SetQuestData(1000801, "s");
				self.say("Yes! Actually I really wanted to make a nice glove... and to make it, I need #b1 #t4031042#, 10 #t4011005#s, 50 #t4000030#s, 40 #t4003000#s and 3 #t4000046#s#k. Oh, the fairies might know about #b#t4031042##k. Alright, I'm counting on you! If you get me that, I'll definitely get you something nice in return.");
			}
			else if (Luke2 == "s")
			{
				if (ItemCount(4011005) < 10 || ItemCount(4000046) < 3 || ItemCount(4000030) < 50 || ItemCount(4003000) < 40 || ItemCount(4031042) < 1)
				{
					self.say("You haven't gotten all the materials needed for the gloves yet? Get me #b1 #t4031042#, 10 #t4011005#s, 50 \r\n#t4000030#s, 40 #t4003000#s and 3 #t4000046#s#k! The fairies may know someithing about #b#t4031042##k. Keep working!");
					return;
				}
				
				self.say("Oh my goodness! I can't believe you got all of them. Sweet! If I get this to #p1022004# ... wow, it's going to be one incredible glove ... Oh yeah, I'll get you something good for doing me a favor. It's a helmet that's been passed down from generation to generation in our family... maybe Mr. Thunder can make a better one.");
				
				if (!Exchange(0, 4011005, -10, 4000046, -3, 4000030, -50, 4003000, -40, 4031042, -1, 1002100, 1))
				{
					self.say("Please leave a slot open in your equip. inventory.");
					return;
				}
				
				AddEXP(1000);
				SetQuestData(1000801, "end");
				QuestEndEffect();
				self.say("You got #b#t1002100##k, right? Thanks for your work. It'll definitely help you on your journey so use it well! Well then, back to making more gloves...");
			}
			else
			{
				self.say("Hey, it's you! Am I falling asleep again? Well, I was actually called out the other day for doing that, so I've been trying NOT to these days. It's dangerous around here, so please be careful.");
			}
		}
	}
}