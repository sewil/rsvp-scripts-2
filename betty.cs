using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string winston1 = GetQuestData(1004900);
		string quest1 = GetQuestData(1004901);
		string quest2 = GetQuestData(1004902);
		
		if (winston1 == "" || winston1 == "w0" || winston1 == "w1")
		{
			self.say("I'm Betty the biologist. There are so many things to work on, but I'm always lacking time.");
		}
		else if (winston1 == "w2")
		{
			if (ItemCount(4031148) < 1 || ItemCount(4031149) < 1)
			{
				self.say("And ... who are you?? I'm a very busy person, and if you don't have anything for me, then please leave. When is that person that Dr. Winston sent coming?");
				return;
			}
			
			self.say("Dr. Winston sent you for me? He must be at Perion recovering fossils ...");
			
			if (!Exchange(30000, 4031148, -1, 4031149, -1, 2010002, 50))
			{
				self.say("Please let me reward you for coming all the way here. Make some room in your use inventory first.");
				return;
			}
			
			AddEXP(1000);
			SetQuestData(1004900, "e");
			QuestEndEffect();
			self.say("Ohh, this is the fossil. Seeing the letter, it looks like Dr. Winston trusts you quite a bit. I may need some help once I start investigating these, so please drop by and see me if you have some time. This is the reward for your job well done. I'll see you around.");
		}
		else if (winston1 == "e")
		{
			if (Level < 22)
			{
				self.say("I'm Betty the biologist. There are so many things to work on, but I'm always lacking time.");
				return;
			}
			
			if (quest1 == "")
			{
				bool start = AskYesNo("You're the one that got me Dr. Winston's Fossil Box, right? Good to see you. You didn't forget my plea for help down the road. I've been busily working on the fossils these days. Can you help me out by any chance?");
				
				if (!start)
				{
					self.say("I thought you were going to help me out. If I do this by myself, I'll have to get going fast. Please don't bother me now. See you around.");
					return;
				}
				
				SetQuestData(1004901, "b0");
				self.say("Thank you. I've been busily investigating the leaf fossils of a plant, but this is much tougher than I thought. The leaves that are shown on this fossil are very uniquely formed...");
				self.say("I need samples that I can compare with in detail. You'll find various plants all around Ellinia. I need you to gather up a few of those, #b20 #t4031150#s#k to be exact. I'll be waiting for you. Please hurry!");
				self.say("The plants that can be used for samples are usually bigger than other plants. They are usually grown at the northern forest of Ellinia. You'll be able to find it in no time.");
			}
			else if (quest1 == "b0")
			{
				if (ItemCount(4031150) < 20)
				{
					self.say("I thought I told you #b20 #t4031150#s#k. Did you completely forget about it?");
					return;
				}
				
				bool start2 = AskYesNo("These are indeed 20 samples. They are in pretty good shape, too. Thank you for your hard work. This will help me immensely on my studies with the plant fossils. Just the way Dr. Winston designed it. Well, I have one more favor to ask... will you help me out?");
				
				if (!start2)
				{
					self.say("I thought you were going to help me out there ... oh well, I'll see you around.");
					return;
				}
				
				if (!Exchange(0, 4031150, -20))
				{
					self.say("Hmm ... are you sure you brought the #b20 #t4031150#s#k?");
					return;
				}
				
				AddEXP(1500);
				SetQuestData(1004901, "b1");
				self.say("To start working on the animal fossils, I'll need samples I can compare with. Looking at these fossils, Drake's skulls seem like a perfect sample for comparison. Can you get me some of Drake's skulls?");
				self.say("Ah, don't be too shocked. I know Drakes are not to be messed with for most people. I have #b#t4031151##k that I've gathered up a few years ago. The problem is, I didn't bring it with me to Ellinia because I'm here right now for plant fossils. Since I can't leave this place, I'm hoping you can get it for me.");
				self.say("Around Henesys, you'll find my daughter. Ask her for #b#t4031151##k. Her name is #bAnne#k.");
			}
			else if (quest1 == "b1")
			{
				self.say("Are you here empty-handed? Where's the #b#t4031151##k that I asked you to get? Please hurry.");
			}
			else if (quest1 == "b2")
			{
				if (ItemCount(4031151) < 1)
				{
					self.say("Are you here empty-handed? Where's the #b#t4031151# that I asked you to get? Please hurry.");
					return;
				}
				
				self.say("Hey, you're back. I forgot to tell you this, but Anne is very careful and difficult to be with around strangers. She just thinks twice before being nice to strangers. I should have given you a letter of approval.");
				
				if (!Exchange(0, 4031151, -1))
				{
					self.say("Hmm ... are you sure you brought the ##t4031151##k?");
					return;
				}
				
				AddEXP(1500);
				SetQuestData(1004901, "e");
				QuestEndEffect();
				self.say("Wow, incredible! Anne must have trusted you to give you this! She's my daughter and all, but she can be quite a handful at times ... how did you do that?? You are indeed someone I can count on. Now I can definitely get on with the animal fossil studies. Please drop by around the time I get done with this. I'll let you know of the outcome.");
			}
			else if (quest1 == "e")
			{
				if (Level < 23)
				{
					self.say("You are indeed someone I can count on. Now I can definitely get on with the animal fossil studies. Please drop by around the time I get done with this. I'll let you know of the outcome.");
					return;
				}
				
				if (quest2 == "")
				{
					self.say("Been a while. Thanks to you, I have successfully completed the studies.");
					self.say("The fossils you've gotten me were critical materials. Those fossils contain clues that may lead us to discover the secrets behind the special abilities of the prehistoric life. Use them well, and it will help us regular people out tremendously.");
					bool start3 = AskYesNo("I need to send Dr. Winston of Perion the final report on the results of the studies. Can you help me out?");
					
					if (!start3)
					{
						self.say("You must be very busy. I'll have to ask someone else for this.");
						return;
					}
					
					if (!Exchange(0, 4031152, 1))
					{
						self.say("Please make some room in your etc. inventory first.");
						return;
					}
					
					SetQuestData(1004902, "s");
					self.say("I knew you'd help me out. Please get the final report to Dr. Winston. Oh, and before coming up to him, gather up #b100 Leaves#k, #b50 logs of Firewood#k, #b1 Stump's Tear#k, and #b1 pair of Weight Earrings#k. Dr. Winston will be very pleased with the report and may reward you with something nice.");
					self.say("Ahhh, you may have never heard of #b#t4031153##k.\r\n#b#t4031153##k is a rare crystal you can only get from the Dark Axe Stump's.");
				}
				else if (quest2 == "s")
				{
					if (ItemCount(4031152) >= 1)
					{
						self.say("Please get the final report to Dr. Winston. Oh, and before coming up to him, gather up #b100 Leaves#k, #b50 logs of Firewood#k, #b1 Stump's Tear#k, and #b1 pair of Weight Earrings#k. Dr. Winston will be very pleased with the report and may reward you with something nice.");
						return;
					}
					
					self.say("Did you lose the final report??? My oh my, you better be really careful. Good thing I made a number of copies in case something like this happens. Now, please get this to Dr. Winston SAFELY.");
					
					if (!Exchange(0, 4031152, 1))
					{
						self.say("Please make some room in your etc. inventory first.");
						return;
					}
				}
				else
				{
					self.say("Thank you so much for your help! Couldn't have come at a better time!");
				}
			}
		}
	}
}