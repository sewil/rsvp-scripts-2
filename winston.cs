using System;
using System.Collections.Generic;
using WvsBeta.Game;
using WvsBeta.Common;

public class NpcScript : IScriptV2
{
	private void FossilDig(string quest)
	{
		if (quest == "")
		{
			self.say("Hello, there, nice to meet you. I'm #b#p1022006##k the archeologist, and I'm looking for fossils of the prehistoric life.");
			bool start = AskYesNo("Perion may now be a land of dry, rocky mountains, but it used to be a fertile land full of tall trees and lots of creatures, much like Ellinia. Can you believe that? I'm looking for evidences from that era. If you are not busy and all, can you help me out?");
			
			if (!start)
			{
				self.say("Kids these days are so selfish, saying no to an old man's favor. Fine, please leave.");
				return;
			}
			
			SetQuestData(1004900, "w0");
			self.say("Thank you. I ran into something odd yesterday. I went to Perion for some food, and when I came back, I found my tent raided by the monsters. They took my fossils and ran away.");
			self.say("Looking at the footprints, it seems like #b#o1110100##k and #b#o1130100##k that did it. Please go take care of them and gather up #b100 #t4031146#s#k and #b100 #t4031147#s#k for me. Thanks, and good luck!");
		}
		else if (quest == "w0")
		{
			if (ItemCount(4031147) < 100 || ItemCount(4031146) < 100)
			{
				self.say("I don't think you've gathered them all up, yet. These materials are important. Please try harder.");
				return;
			}
			
			self.say("Oh my, these are it!! Thank you so much! I finally got these back!! Phew, that saved me from losing my years of work.");
			
			if (!Exchange(0, 4031146, -100, 4031147, -100))
			{
				self.say("Oh my, are you sure you brought all the fossils back?");
				return;
			}
			
			AddEXP(1000);
			SetQuestData(1004900, "w1");
		}
		else if (quest == "w1")
		{
			bool start2 = AskYesNo("Since you did such a fine job recovering those for me ... can you help me out one more time?");
			
			if (!start2)
			{
				self.say("I may have asked you for too big a favor. I'm sure you must be busy and all. I may have to ask someone else for this. Take care.");
				return;
			}
			
			if (!Exchange(0, 4031148, 1, 4031149, 1))
			{
				self.say("Hmm ... please make sure you have at least two spaces available in your etc. tab.");
				return;
			}
			
			SetQuestData(1004900, "w2");
			self.say("Thank you so much. You're unlike any of the young people that seem so selfish and self-absorbent. I think leaving the fossils that you worked hard to recover here in the tent is too dangerous. You never know when the monsters will raid again. I can't leave this place, though, because I have more fossils to recover.");
			self.say("Please get that letter of introduction to #bDr. Betty#k of Ellinia, who's a renowned Biologist. Please get this #bFossil Box#k to her. Thank you, and good luck.");
		}
		else if (quest == "w2")
		{
			if (ItemCount(4031148) >= 1 && ItemCount(4031149) >= 1)
			{
				self.say("Please get that letter of introduction to #bDr. Betty#k of Ellinia, who's a renowned Biologist. Please get this #bFossil Box#k to her. Thank you, and good luck.");
				return;
			}
			
			self.say("I think you left this here ... you have to be more careful than that.");
				
			if (ItemCount(4031148) < 1)
			{
				if (!Exchange(0, 4031148, 1))
				{
					self.say("Hmm ... please make sure you have an empty space available in your etc. tab.");
					return;
				}
			}
			if (ItemCount(4031149) < 1)
			{
				if (!Exchange(0, 4031149, 1))
				{
					self.say("Hmm ... please make sure you have an empty space available in your etc. tab.");
					return;
				}
			}
		}
	}
	
	private void FossilResearch(string quest)
	{
		if (quest == "s")
		{
			if (ItemCount(1032000) < 1 || ItemCount(4000018) < 50 || ItemCount(4031152) < 1 || ItemCount(4031153) < 1 || ItemCount(4000005) < 100)
			{
				self.say("What's up? Aren't the fossil studies going well? I'm more than ready to take a look at the results ...");
				return;
			}
			
			self.say("Welcome, welcome. You're the one that helped me get my fossils back the other day. I heard that you've also helped Dr. Betty with her studies. She said she gave you the final report for me to look at. Did you bring it?");
			self.say("Please also give me the materials that you've gathered up. Those materials will be used to conduct the studies regarding the final report. Dr. Betty did tell you this in advance, right?");
			
			if (!Exchange(0, 4000005, -100, 4000018, -50, 4031153, -1, 1032000, -1, 4031152, -1, 1032025, 1))
			{
				self.say("Hmm ... are you sure you brought everything with you? If so, please make some room in the equip. tab.");
				return;
			}
			
			AddEXP(1700);
			SetQuestData(1004902, "e");
			QuestEndEffect();
			self.say("Wow ... a huge secret laden in the fossils!! The more you dig up the fossils, the more you're amazed by them. It never ceases to surprise me on many levels.");
			self.say("Do you like the earring? It's the result of the studies we have conducted here. It is laden with the abilities of the Stump, so use it wisely!");
		}
	}
	
	private void PlantingTrees(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("Perion has been steadily deteriorating these days. It seems barren to begin with because of the rocky landscape, but it's also because of the recent excavation project that has been affecting areas around Perion. The sheer digging only speeds up the deterioration. I, for one, would like to restore Perion to its previous, glorious days. Would you like to help me out?");
			
			if (!start)
			{
				self.say("Did I ask for something too difficult...? I sincerely hope the Perion area transforms into a green forest with trees to spare...");
				return;
			}
			
			SetQuestData(1010000, "s");
			self.say("I can't thank you enough for stepping up for Perion. New monsters have been popping up lately, with the land around Perion rapidly deteriorating. Recent reports suggest that a mutant version of the Stumps, #r#o1140100#s#k, have been roaming around the area.");
			self.say("After studying the #o1140100#, I learned that if the tree brances on the top of Ghost Stumps' heads are planted on the ground, they will grow into huge trees. It's kind of like #t4000195#. Please head to the excavation site and eliminate #o1140100#s, while gathering up #b54 #t4000195#s#k for me. I'll surely appreciate it.");
			self.say("#o1140100# appears quite often around the excavation site. The way to get there is quite simple. Head all the way East until you reach #rRocky Road III#k. There, you'll see a portal at the very top. Enter the portal to head to the excavation site.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4000195) < 54)
			{
				self.say("Please gather up #b54 #t4000195#s#k for me.");
				return;
			}
			
			self.say("Did you collect the #t4000195#?");
			
			if (!Exchange(0, 4000195, -54, 2000000, 30))
			{
				self.say("Are you sure you have the #b54 #t4000195#s#k? If so, please make sure there's an empty slot in your use inventory.");
				return;
			}
			
			AddEXP(1500);
			SetQuestData(1010000, "e");
			QuestEndEffect();
			self.say("Great job. The #t4000195# will be planted all around Perion, and hopefully that'll turn into a huge, green forest. I may be in it by myself for now, but once people start helping out, it'll speed up the process. You should plant one around your house yourself.");
			self.say("Anyway, I feel this weird vibe going around the excavation site... wonder what that is.");
		}
	}
	
	private void ShawnsRequest(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("I have a friend who's busy excavating at the Excavation Site near Perion. His name is #p9040002#, and he asked for some help. Apparently he's never seen these monsters before, and they are interfering with the excavating process, and so he has asked me for help in eliminating them. Can you help us out?");
			
			if (!start)
			{
				self.say("I don't know if I've asked for too much... but the monsters need to be taken care of ASAP...");
				return;
			}
			
			SetQuestData(1010100, "s");
			self.say("I appreciate your willingness to help me here. Before eliminating the monsters, I need you to do something else first. The only way to prevent the monster from ever coming back is to scientifically study the origin of the monster. The best way to do it would be for me to take a look at them myself, but I have so many other researches to conduct that I need you to gather up #b5 each of #t4000196# and #t4000197##k that #r#o2230110##k and #r#o2230111##k possess.");
			self.say("Don't know how to get to the Excavation Site? Head East for a while, until you run into #rRocky Road III#k, then look up to see a portal. Go there, and you'll be sent directly to the Site.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4000196) < 5 || ItemCount(4000197) < 5)
			{
				self.say("Please bring 5 #t4000196#s and 5 #t4000197#s with you.");
				return;
			}
			
			self.say("Did you bring 5 #t4000196#s and 5 #t4000197#s?");
			
			if (!Exchange(0, 4000196, -5, 4000197, -5))
			{
				self.say("What? Are you sure you brought everything?");
				return;
			}
			
			AddEXP(500);
			SetQuestData(1010100, "e");
			QuestEndEffect();
			self.say("Good job. Now please wait here while I look into these,\r\n#t4000196# and #t4000197#. ");
		}
	}
	
	private void EliminateMonsters(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("What... this... did this really exist?");
			
			if (!start)
			{
				self.say("If we don't get this excavation complete soon, then we may all be in grave danger. Once you're done preparing to eliminate the monsters, then please come talk to me.");
				return;
			}
			
			SetQuestData(1010101, "200300");
			self.say("Hey you, please go take care of the monsters that keep interfering with our excavation project here. We do not have much time, for if the monsters keep interfering and we don't complete this on time, then we may all be in grave danger. Please go eliminate #r200 #o2230110#s#k and #r300 #o2230111#s#k. If you can't do it yourself, then bring your party with you and take care of it ASAP.");
		}
		else
		{
			if (quest != "000000")
			{
				self.say("Please eliminate #r200 Wooden Masks#k and #r300 Rocky\r\nMasks#k. We can't afford to waste even a second here.");
				return;
			}
			
			self.say("The numbers of #o2230110# and #o2230111# sure have decreased.");
			
			if (SlotCount(2) < 1)
			{
				self.say("Please leave some room in your use inventory first.");
				return;
			}
			
			var rewards = new List<(int, int, int)>();
			
			rewards.Add((2000001, 40, 11));
			rewards.Add((2000002, 20, 11));
			rewards.Add((2000003, 30, 11));
			rewards.Add((2000006, 10, 11));
			rewards.Add((2040707, 1, 3));
			rewards.Add((2040704, 1, 3));
			
			var item = rewards.RandomElementByWeight(tuple => tuple.Item3);
			
			if (item == default)
				return;
			
			int itemID = item.Item1;
			int itemNum = item.Item2;
			
			if (!Exchange(0, itemID, itemNum))
			{
				self.say("Please leave some room in your use inventory first.");
				return;
			}
			
			AddEXP(3500);
			SetQuestData(1010101, "e");
			QuestEndEffect();
			self.say("Thank you for your hard work. This should finally allow us to work on excavating without having to watch our back at all times. But then again, in order to get this done with, we'll need help from someone like you on a daily basis. If you ever walk by this area again, then please help us keep #o2230110# and #o2230111# from overtaking this area. Thanks.");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1004900)
		{
			if ((Level >= 20 && info == "") || info == "w0")
				return " Searching for Fossils";
			
			if (info == "w1" || info == "w2")
				return " Delivering a Box of Fossils";
		}
		else if (quest == 1004902)
		{
			if (info == "s")
				return " Progress on Fossil Research";
		}
		else if (quest == 1010000)
		{
			if ((Level >= 20 && info == "") || info == "s")
				return " Planting Trees";
		}
		else if (quest == 1010100)
		{
			if ((Level >= 25 && info == "") || info == "s")
				return " Shawn the Excavator's Request";
		}
		else if (quest == 1010101)
		{
			string shawn = GetQuestData(1010100);
			
			if (shawn == "e" && info != "e")
				return " Eliminate Monsters from the Site";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1004900, 1004902, 1010000, 1010100, 1010101};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "I'm Winston the archeologist.";
		
		if (GetQuestData(1004900) == "e")
			dialogue = "You're the one that helped me out the other day. Unfortunately I'm really busy right this minute. I'll talk to you later.";
		
		if (options.Count == 0)
		{
			self.say(dialogue);
			return;
		}
		
		int choice = -1;
		
		if (options.Count >= 2)
			choice = AskMenu($"{dialogue}#b", options.ToArray());
		else
			choice = options[0].Index;
		
		switch(choice)
		{
			case 0: FossilDig(GetQuestData(1004900)); break;
			case 1: FossilResearch(GetQuestData(1004902)); break;
			case 2: PlantingTrees(GetQuestData(1010000)); break;
			case 3: ShawnsRequest(GetQuestData(1010100)); break;
			case 4: EliminateMonsters(GetQuestData(1010101)); break;
		}
	}
}