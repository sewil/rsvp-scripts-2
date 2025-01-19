using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1004700);
		
		if (Level < 35)
		{
			self.say("Welcome to Florina Beach! How can I help you?");
			return;
		}
		
		if (quest == "")
		{
			bool start = AskYesNo("Welcome to the Florina Beach, where the beautiful sunshine and the mind-numbingly spectacular ocean awaits you, \r\nand.... what? what?? Ah, you are looking for a job. That's awesome! I've been looking for some help, anyway! Florina Beach is renowned for delicious cononut juice, along with tropical fruits and seafood. Your job is to collect those for me. What do you think?");
			
			if (!start)
			{
				self.say("You don't need to start right away, huh? We at the Florina Beach can always use a hand or two, since there are so many tourists that come and go everyday. It's not that difficult a job, so if you're looking for a job that isn't terribly difficult, then feel free to come back and talk to me, okay?");
				return;
			}
			
			SetQuestData(1004700, "1s");
			self.say("Alright!! I'll first have to see how good you are. Don't worry, I'll pay you accordingly. It'll be a good experience for you. Head over to the beach on the right side, and you'll see a number of coconut trees. Please gather up #b10 fresh coconuts#k. I need fresh ones, nothing else, alright??");
		}
		else if (quest == "1s")
		{
			if (ItemCount(4000136) < 10)
			{
				self.say("I don't think you have enough number of coconuts. Can't find the fresh ones? Head over to the right side of the beach. The trees there have some of the freshest coconuts you can find.");
				return;
			}
			
			self.say("Did you collect #b10 coconuts#k? If you get me the fresh ones, you'll be working for me, no problem. Well, can I see what you have there?");
			
			if (!Exchange(500, 4000136, -10))
			{
				self.say("Woah, are you sure you have the #b10 #t4000136#s#k?");
				return;
			}
			
			AddEXP(1000);
			SetQuestData(1004700, "1end");
			self.say("Wow, they really are fresh!! That's just awesome!! I can't believe I ran into someone as good as you. This one's a test, so I'll give you 500 mesos. Don't worry, the future ones will get you much more money. If you want to work while enjoying the life at the beach, then please come see me. YOU will always be welcome here.");
		}
		else if (quest == "1end")
		{
			int ask1 = AskMenu("I'm sure you know this and all, but I'll still ask. Which of these monsters will you not be seeing at the Florina Beach?#b",
				(0, " Umti"),
				(1, " Clang"),
				(2, " Croco"));
			
			if (ask1 == 0)
			{
				self.say("You'll find Umti at the right side of the beach...");
			}
			else if (ask1 == 1)
			{
				self.say("One of the more renowned treats at the Florina Beach is the 'Clang's Claw' special!");
			}
			else if (ask1 == 2)
			{
				self.say("I'm glad you know the basic stuff around here. I'm just worried you may wander around and hunt around stuff without knowing what you'll be facing. Well, shall we get this started?");
				
				SetQuestData(1004700, "2s");
				self.say("I'll explain to you more about this job. I need #b15 #t4000136#s#k for some coconut juice, #b150 #t4000043#s#k for the meals, and #b15 #t4000029#s#k for the dessert. Please get me the freshest materials available!!");
			}
		}
		else if (quest == "2s")
		{
			if (ItemCount(4000029) < 15 || ItemCount(4000136) < 15 || ItemCount(4000043) < 150)
			{
				self.say("I think you're lacking some. Please check and see if you have all of the #b15 coconuts, 150 of Lorang's Claws, and 15 of Lupin's bananas.#k");
				return;
			}
			
			self.say("Did you collect them all? If the materials aren't fresh, I may not pay you for your service. Of course, you also can't be short on those. Now, let's see ...");
			
			if (!Exchange(7500, 4000029, -15, 4000136, -15, 4000043, -150))
			{
				self.say("Woah, are you sure you have everything I asked for?");
				return;
			}
			
			AddEXP(3000);
			SetQuestData(1004700, "2end");
			self.say("Wow, you got them all!!! The sweet-smelling coconut ... the tasty-looking claws ... and the fresh batch of bananas ... good job!! We have been booking more tourists lately, and I can sure use someone like you again. If you're looking for more work, then come talk to me. I feel like I can trust you to take on some of the harder tasks. I should even raise your pay, then!!!");
		}
		else if (quest == "2end")
		{
			bool start2 = AskYesNo("Remember I told you last time... I'll need much more materials since more tourists are being booked here now. It may take you some time, although the amount of time it'll take depends on your ability to get the job done. What do you think? Do you want to take a crack at it? You'll be paid quite well for this.");
			
			if (!start2)
			{
				self.say("Is it because I'm asking you for too much? Just remember, you'll be paid accordingly ? if you feel like doing it, then please come talk to me.");
				return;
			}
			
			SetQuestData(1004700, "3s");
			self.say("Alright, the visitors that are coming by this time around are quite something. They only want the specials, and #t4000043# will not do. Because of that, I'll need #r30#k #t4000136#s for the coconut juice, #r150#k #t4000043#s and #r150#k #t4000044#s for the main course, and #r30#k #t4000029#s for the dessert.");
		}
		else if (quest == "3s")
		{
			if (ItemCount(4000029) < 30 || ItemCount(4000136) < 30 || ItemCount(4000043) < 150 || ItemCount(4000044) < 150)
			{
				self.say("Please check and see if you have all of the #b30 coconuts, 150 Claws of Lorang, 150 Claws of Clang, and 30 bananas of Lupin#k. I don't think you have all of them ....");
				return;
			}
			
			self.say("Did you gather up all the materials I asked of you? Well, let's see...");
			
			if (!Exchange(20000, 4000043, -150, 4000044, -150, 4000029, -30, 4000136, -30))
			{
				self.say("Woah, are you sure you have everything I asked for?");
				return;
			}
			
			AddEXP(7000);
			SetQuestData(1004700, "3end");
			self.say("I knew it!!! All the materials you've gathered up are fresh and ready to be served!! The customers will be more than satisfied with it. I don't think we'll ever have a huge group of visitors like this anymore. If I find something to do, I'll definitely ask you for help. Thanks, and take care~");
		}
		else if (quest == "3end")
		{
			bool start3 = AskYesNo("I have a job for you now. All you need to do is gather up a few materials. What do you think? Do you want to do it?");
			
			if (!start3)
			{
				self.say("Oh, really? Well, it's not something I need right this minute, so take your time, see if you want to do it. If you do, then come talk to me alright? Well, I gotta get going...");
				return;
			}
			
			SetQuestData(1004700, "4s");
			self.say("Drop by every once in a while, and I'll have something for you. What do you think? Isn't that cool? Valen's been trying to create some new recipes and he'll need more fresh materials. Your job is to gather up #r10#k #t4000136#s, #r10#k of \r\n#t4000043#, #r10#k of #t4000044# and #r10#k of #t4000029#s. What do you think?");
		}
		else if (quest == "4s")
		{
			if (ItemCount(4000029) < 10 || ItemCount(4000136) < 10 || ItemCount(4000043) < 10 || ItemCount(4000044) < 10)
			{
				self.say("I don't think you have all of them. Please double-check.");
				return;
			}
			
			self.say("Did you gather them all up?? Let's see ...");
			
			if (!Exchange(3000, 4000043, -10, 4000044, -10, 4000029, -10, 4000136, -10))
			{
				self.say("Woah, are you sure you have everything I asked for?");
				return;
			}
			
			AddEXP(3000);
			SetQuestData(1004700, "4end");
			QuestEndEffect();
			self.say("As usual!! You're the best I've ever seen!! Thanks for your help. I'll definitely be waiting for you if I find myself looking for a help. See you around~");
		}
		else if (quest == "4end")
		{
			self.say("You're the one that's famous for getting the job done. Are you looking for more tasks?");
		}
	}
}