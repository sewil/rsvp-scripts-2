using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(1001200);
		string quest2 = GetQuestData(1001201);
		string quest3 = GetQuestData(1001202);
		
		if (Level < 20)
		{
			self.say("Oh my gosh ... I lost the coin that my friend lent me ... I can't find it!!");
			return;
		}
		
		if (quest1 == "")
		{
			bool askStart1 = AskYesNo("Hey, um ... have seen a coin around here? Oh my gosh, I'm in deep trouble ... I was going to pay my friend back with that coin so I put it in my pocket ... I guess the coin fell out of it and fell deep into the subway. It's a special coin, so my friend's going to be really mad about it. Well, can I ask you a favor? Can you find it for me?");
			
			if (!askStart1)
			{
				self.say("You must be busy here and there, huh? But if you ever decide to change your mind, then please help me. I'm being serious here...");
				return;
			}
			
			SetQuestData(1001200, "s");
			self.say("Thanks! Good thing I asked. Phew ... I saw a couple of guys draped in white cloth picking that coin up when I dropped it in the subway and running away with it ... I tried to chase them down but the entrance was blocked so I couldn't go much further...");
			self.say("The entrance must be somewhere in the subway ... probably at a #bconstruction site B1#k. Anyway good luck with that ... everyone else have turned down the favor because it was too dangerous for them to actually do it.. You look strong, so I'm pretty confident that you'll find it for me.");
		}
		else if (quest1 == "end")
		{
			if (Level < 30)
			{
				self.say("You're the one that helped me out before!! I can't thank you enough for getting me out of trouble.");
				return;
			}
			
			if (quest2 == "")
			{
				bool askStart2 = AskYesNo("You came!! I was waiting for you ... well ... there's a big problem that just arose. This time, I didn't just lose a coin; I lost a whole roll of money. It happened quick. I looked away for a second, and those #o2300100# punks took it and ran away. What do you think? Will you help me?");
			
				if (!askStart2)
				{
					self.say("You must be busy here and there, huh? But if you ever decide to change your mind, then please help me. I'm being serious here...");
					return;
				}
				
				SetQuestData(1001201, "s");
				self.say("I knew you'd say yes!! I saw them go into #bconstruction site B2#k with my roll of money, but I couldn't chase them down further because there was a weird device put on the entrance. That money is very important to me ... I need that for something important ... I know you can do it, so please find it and bring it back to me~!");
			}
			else if (quest2 == "end")
			{
				if (Level < 40)
				{
					self.say("You're the one that helped me out two times!!! I can't thank you enough for getting me out of trouble. I mean, you helped me out two times!");
					return;
				}
				
				if (quest3 == "")
				{
					bool askStart3 = AskYesNo("Whoa ... I've been really waiting for you to come back!! What? Did I lose money again? Yep ... well, this time, it's really big \r\n... Someone I know asked me for a favor and get him 100 \r\n#t2000004#s. He gave me the money to buy them all, so I put that sack of money in my pocket, carrying it with me. It was way too heavy, though, so I dropped it on the ground, only to have the bottom of the sack wear off and have a hole in the end. The money fell down because of it ... Can you find them for me?");
					
					if (!askStart3)
					{
						self.say("You must be busy here and there, huh? But if you ever decide to change your mind, then please help me. I'm being serious here...");
						return;
					}
					
					SetQuestData(1001202, "s");
					self.say("Thank you so much! Well, the person that asked for the favor is sitting waaaaaaay down there. His name is #p1052002#, and ... he worked hard for that money through backdoor dealings, and if he ever finds out that I lost that money, he'll go crazy on me. Don't be fooled by his appearance; he's got quite a temper ... argh ... pleeaasssee help me! Please help me find the sack of money!! You're the only one I can count on right now!");
					self.say("I think the sack of money was dropped at the subway#b construction site B3#k. I tried to go there and retrieve it but there are even more weird devices all over the place this time around, so I did little more than take a look at it from the distance. This may be difficult even for you this time around. Anyway please please please get that sack of money for me. I believe in you...");
				}
				else if (quest3 == "end")
				{
					self.say("You're the one that helped me out three times!!!! I can't thank you enough for getting me out of trouble. I mean, you helped me out three times!! I've been much more careful these days. Isn't that an improvement or what?");
				}
				else
				{
					if (ItemCount(4031041) < 1)
					{
						self.say("Still haven't found the sack of money that I lost? Without it, I don't know what he's going to do with me ... you may find it at the #bconstruction site B3 of #m103000000##k subway. Be careful, there are some weird equipments around in there. I believe in you~");
						return;
					}
					
					self.say("Hey, it's that sack of money I lost!! Phew ... it's all good now. I knew you'd find it ... seriously, you should become a professional at this ... but hey ... you didn't happen to take some from this, right? let me see ... I'm not doubting your honesty, but I still got to count them ... one ... two ... three ... four ... hmm I'm sure it's all good.");
					self.say("Alright! Since you did me a huge favor, the reward will be handsome, don't worry about it ... hmmm ... what should I give you ... YEAH! This has been passed down from generation to generation in my family ... but I'll give it to you. This is NOT an easy find~ you should thank me for it. It looks an old scroll ... not too sure of the details.");
					
					if (SlotCount(2) < 2)
					{
						self.say("I can't thank you properly until you have TWO free spaces in your use inventory.");
						return;
					}
					
					Random rnd = new Random();
					int[] scroll = {2040706, 2040707, 2040708};
					
					int itemID = scroll[rnd.Next(scroll.Length)];
					
					if (!Exchange(0, 4031041, -1, 2000004, 30, itemID, 1))
					{
						self.say("Huh? Are you sure you have the sack of money?");
						return;
					}
					
					AddEXP(800);
					AddFame(1);
					SetQuestData(1001202, "end");
					QuestEndEffect();
					self.say("As a reward I boosted your experience and fame up a bit ... and, this is a very valuable item to our family, the scroll is yours. Please use it wisely. The potion's just an added bonus. If I run into trouble again in the near future, I'll be looking for you help ... so please come back and visit, alright? hehe ... of course, I'll be careful with the money from here on out!");
				}
			}
			else
			{
				if (ItemCount(4031040) < 1)
				{
					self.say("Still haven't found the roll of money that I lost? Without it I'll be homeless ... that's my rent money! You may find it at the#b constructoin site B2 of #m103000000# subway#k. Be careful, there are some weird equiments around in there. I believe in you~");
					return;
				}
				
				self.say("Hey, it's the ROLL of cash I lost!! Phew ... I can finally pay rent with this ... what? How do I know if this is the money that I lost? Look ... I wrote my name on it really small ... can't see it? Don't you really need a pair of glasses?");
				self.say("Anyway thank you sooooo much. And you helped me out last time, too ... I keep turning to you for help...don't worry, I'll reward you handsomely for it ... but anyway, you should really look into helping others' problems as a job ... you're pretty good at it~");
				
				if (!Exchange(0, 4031040, -1, 2000006, 100))
				{
					self.say("I can't thank you properly until you have a free space in your use inventory.");
					return;
				}
				
				AddEXP(500);
				AddFame(1);
				SetQuestData(1001201, "end");
				QuestEndEffect();
				self.say("As a sign of appreciation, I bumped up your fame status and experience level a little. And, although too precious to give away, here's a bunch of #t2000006# that I collected for months while travelling...so use them wisely!! Next time I find myself in trouble, I'll look to you for help again, so please come again, alright?");
			}
		}
		else
		{
			if (ItemCount(4031039) < 1)
			{
				self.say("Still haven't found the coin that I lost? I'm screwed without it. Go to the #bconstruction site B1 of the #m103000000# subway#k and maybe you'll find it ... there's a lot of weird equipments there so be careful. I believe in you!");
				return;
			}
			
			self.say("Yeah, this is it!! There are lots of different coins, but this one's special, because it was made the same year my friend was born. In short, they were created the same year...what? you want to know where the year is written? You must have bad eyes, because if you look close enough, you'll be able to see it.");
			self.say("Besides, I borrowed this coin for a sec because apparently it brings good luck. Anyway thanks a lot. I can now return it to my friend, all thanks to you...and here, as a small sign of appreciation, this is for you. I collected these from different towns I've visited over time.");
			
			if (SlotCount(2) < 1)
			{
				self.say("I can't thank you properly until you have a free space in your use inventory.");
				return;
			}
			
			Random rnd = new Random();
			int[] scroll = {2030000, 2030001, 2030002, 2030003, 2030004, 2030005, 2030006};
			
			int itemID = scroll[rnd.Next(scroll.Length)];
			
			if (!Exchange(0, 4031039, -1, itemID, 30))
			{
				self.say("Huh? Are you sure you have the coin?");
				return;
			}
			
			AddEXP(200);
			AddFame(1);
			SetQuestData(1001200, "end");
			QuestEndEffect();
			self.say("As a sign of appreciation, I bumped up your fame status and experience level a little. And, although too precious to give away, here they are, a whole bunch of the return scrolls to help you get back to town. I'll talk to you later then. Take care.");
		}
	}
}