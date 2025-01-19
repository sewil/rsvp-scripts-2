using System;
using WvsBeta.Game;

// 2050008 General Maestro
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(1004600);
		string quest2 = GetQuestData(1004601);
		string quest3 = GetQuestData(1004602);
		
		if (Level < 31)
		{
			self.say("Thanks for coming to the Omega Sector. Please stay on your toes, because the aliens may attack any minute. Oh, by the way, someone in the Sector needs your help. If you're interested, go see that person.");
			return;
		}
		
		if (quest1 == "")
		{
			self.say("Lately I've been conducting some secret, discreet checks without anyone else's knowledge. I know you've been through this path in the past, but now we have a problem where the saintly dolls have turned into ruthless monsters. What happened?");
			bool start = AskYesNo("But no one knows why, and the situation is getting worse by day. What is going on there? Is it the act of an alien? Or something else? All I know is, I can't leave this post because I'm the general. Please help me take care of other things.");
			
			if (!start)
			{
				self.say("I thought I could count on you to take care of this mission, but I guess not. This is a discreet project, one that cannot be advertised to total strangers, so ... if you ever change your mind about this, then please talk to me, okay?");
				return;
			}
			
			SetQuestData(1004600, "s");
			self.say("Okay, then! I don't know if you've ever met with #b#p2040008##k, before, but these previously-friendly #b#o3230400##k have turned into menacing monsters by unknown power. It's up to you to investigate them.");
			self.say("Defeat the #b#o3230400##k, a monster featured at the 60th floor of Eos Tower, and you'll sometimes find an item called #b#t4031135##k. Hardly anyone knows what to do with it, but I think it's a very important item. Inside that item lies the clues to the case.");
			self.say("Please go to the Eos Tower in place of me, defeat #b#o3230400##k, and collect #b20 #t4031135#s#k for me. It's doesn't seem like an easy item to obtain, but I'm sure you can collect it for awhile.");
		}
		else if (quest1 == "s")
		{
			if (ItemCount(4031135) < 20)
			{
				self.say("Hmmm... I don't think you've gathered up all the items I was asking for. I really think there's a correlation between the previously-gentle dolls suddenly becoming monsters in rage, and an item called #b#t4031135##k. Please head to the 60th floor of the Eos Tower, defeat #b#o3230400##k, and then collect #b20 #t4031135#s#k for me.");
				return;
			}
			
			self.say("Are you finally back now? Let's see the items I requested... Hoh... very nice, and trustworthy! Alright, there's no way I am not going to give you a reward. Take this first, and... I'll slowly explain everything about #b#t4031135##k.");
			
			if (!Exchange(13000, 4031135, -20))
			{
				self.say("Hmmm... are you sure you brought the #b20 #t4031135#s#k?");
				return;
			}
			
			AddEXP(3800);
			SetQuestData(1004600, "e");
			self.say("Alright, let's see... Hmmm... just as I thought. Were you aware of this? #bDrumming Bunnies#k were supposed to be the adorable party-starters at the festival in Ludibrium. They were the ones that made the festival fun.");
			self.say("And then, one by one, they started turning into monsters. I had a hunch that this crystal has something to do with it, and I'm afraid I'm right on this. It's not enough, though. I'll need to study this from different angles, so I can find out exactly what happened in the first place.");
			self.say("Anyway, I can't thank you enough for your hard work here, but the crime hasn't been solved, yet. We were able to find an important clue towards solving the crime, but we haven't solved it yet. I'll try to figure it out, but I am pretty sure I may need your help down the road. Please drop by whenever you have time. I'll see you around.");
		}
		else if (quest1 == "e")
		{
			if (quest2 == "")
			{
				bool start2 = AskYesNo("You're back. I've been wrestling with the #b#t4031135##k that you gave me. There was something in it that I found interesting... based on what I see, it looks like the aliens that are near Omega Sector may be carrying a clue or two. What do you think... would you like to help me out one more time?");
				
				if (!start2)
				{
					self.say("I thought I could count on you to take care of this mission, but I guess not. This is a discreet project, one that cannot be advertised to total strangers, so ... if you ever change your mind about this, then please talk to me, okay?");
					return;
				}
				
				SetQuestData(1004601, "s");
				self.say("Great decision. I have a feeling that one of the aliens may have a clue on the secrets of #t4031135#. I found out that a while ago, they were conducting the same studies as I was. All signs point to an alien called #b#p2050002##k, but it's not like he's going to spill out the information that easily.");
				self.say("You'll find #b#p2050002##k right outside the Omega Sector. I just received news from my assistant that he may have documented the secrets of #t4031135#. Please go there in place of me and snoop around the area for some clues. Good luck.");
			}
			else if (quest2 == "s")
			{
				if (ItemCount(4031136) < 1)
				{
					self.say("A place not too far away from the Omega Sector, you'll run into #b#p2050002##k. There's a report that he has #t4031135#'s secrets on document, so your job is to snoop around him, and find something that may provide a clue or two, then bring that item to me. Please be careful not to get caught. Good luck.");
					return;
				}
				
				self.say("For you to find it this early, you may be much more than I thought. Hoh... #b#t4031136##k... it looks like he wrote it in a hurry. It may be written in alien language, but if he thought I could never translate this, he may be in for a big surprise. Hahaha... anyway, please take this. It's my way of saying thanks.");
				
				if (!Exchange(15000, 4031136, -1))
				{
					self.say("Hmmm... are you sure you brought the #b#t4031136##k?");
					return;
				}
				
				AddEXP(4200);
				SetQuestData(1004601, "e");
				QuestEndEffect();
				self.say("Alright... I better put this document in the Alien Language Translator. This translator has got to be the pride and joy of the Omega Sector, a pinnacle of its technological achievement. Hmmm... this was written in a hurried, scribbly way so it may not be able to translate 100% accurately, but it says that the gist of it has been translated. Let's see... oh ho... I knew it.");
				self.say("According to the document, a regular doll will turn into a monster if in possession of the Dark Crystal Ore, a crystal laden with the force of evil. The #t4031135#s that you brought are just shells of its original state, with the force of evil having already escaped.");
				self.say("If that's the case, then the majority of the dolls that have turned into monsters have been attacking humans because of that Dark Crystal, laden with the force of evil. Now that the aliens have a hold of this information, you never know what kind of sinister plans they may be thinking of. We have to hurry, because this town may be in danger!");
				self.say("I can't thank you enough for helping me out one more time. Now's my turn to figure out a way to solve this. Oh, and... please keep this a secret. It's not too late to release this information only after all the studies conclude and the final results are in.");
			}
			else if (quest2 == "e")
			{
				if (quest3 == "")
				{
					bool start3 = AskYesNo("I've been waiting for you to come back here. For the last few days, I went on a research regarding #b#t4031136##k, using the powers of a language expert, as opposed to through translators. Through that, I found out something that may interest you... and of course, I'll need your help once more. What do you think... do you want to do this?");
					
					if (!start3)
					{
						self.say("I thought I could count on you to take care of this mission, but I guess not. This is a discreet project, one that cannot be advertised to total strangers, so ... if you ever change your mind about this, then please talk to me, okay?");
						return;
					}
					
					SetQuestData(1004602, "s");
					self.say("The most important part of this is missing, so the perfect way to turn these 'monsters' back to dolls isn't available, yet. What we DO know is that the #t4004004# that you'll find with #t4031135# from time to time again has something to do with all this.");
					self.say("Please head over to the 60th floor of the Eos Tower again, defeat #o3230400#, and bring back #b30 #t4031135#s#k and #b10 #t4004004#s#k with you. I know you are more than capable of doing this with ease. Please come back here as soon as you collect all the necessary items. I'll be here waiting for you.");
				}
				else if (quest3 == "s")
				{
					if (ItemCount(4031140) < 30 || ItemCount(4004004) < 10)
					{
						self.say("I don't think you have all the stuff I asked for, yet. Please head over to the 60th floor of the Eos Tower, defeat #o3230400#, and bring back #b30 #t4031135#s#k and #b10 #t4004004#s#k with you. I know you are more than capable of doing this with ease. Good luck.");
						return;
					}
					
					self.say("Hmmm... okay! I can try different things with this many to work with. Here ... I have to reward you well for your job well done. I'm a general, so if you want anything, just say it. Hmmm? You don't need anything right now? Hahah... I understand. Here, please take this~!");
					
					if (SlotCount(2) < 1)
					{
						self.say("Please make sure there's room in your use inventory first.");
						return;
					}
					
					Random rnd = new Random();
					int[] rewards = {2040501, 2040502, 2040513, 2040514, 2040516, 2040517};
					
					int itemID = rewards[rnd.Next(rewards.Length)];
					
					if (!Exchange(0, 4004004, -10, 4031140, -30, itemID, 1))
					{
						self.say("Hmmm... are you sure you brought back everything I asked for?");
						return;
					}
					
					AddEXP(5800);
					SetQuestData(1004602, "e");
					QuestEndEffect();
					self.say("I can't thank you enough for helping me out this much. I'll never forget all your help. This doesn't mean everything's been solved, but I can safely say that the path to a solution has now established. Hope to see you around here from time to time again. Bye~");
				}
				else if (quest3 == "e")
				{
					self.say("The weather is just perfect outside. This place is full of security, protecting itself from the aliens. It's been awfully quiet these past few days, which troubles me, but I can't stand pat. Oh, by the way, the work you did for me the other day, that's going great now.");
				}
			}
		}
	}
}