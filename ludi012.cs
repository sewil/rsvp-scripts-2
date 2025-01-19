using System;
using System.Collections.Generic;
using WvsBeta.Game;

// 2041004 Marcel
public class NpcScript : IScriptV2
{
	private void CleaningEosTower(string quest, int order)
	{
		var rnd = new Random();
		
		if (order == 1)
		{
			if (quest == "")
			{
				bool start = AskYesNo("Hmmm ... you look like someone that likes adventure. Can I ask you for a few favors? It's not going to be easy, but if you get the job done, I'll reward you well for it!");
				
				if (!start)
				{
					self.say("Really. This task isn't that difficult, and I think you can do it. If you have any free time, then come talk to me.");
					return;
				}
				
				SetQuestData(1002100, "050");
				self.say("Cool! What I am going to ask from you is simple. Ludibrium is a floating castle supported by two huge towers, so to get down to the ground level, you'll need to go through Eos Tower, a tower of mind-numbing heights.");
				self.say("It's a very important tower, but the cleaning hasn't been done lately, and the tower is now infiltrated with filthy monsters. I can't move from my duties here as a guard, so I was hoping if you can go in the tower and take care of some monsters.");
				self.say("Please take care of #b50 #o3110102#s#k that are roaming around in Eos Tower. They are a bunch of white rats with springs on the back, and they are a handful. I'll be here waiting until you take of all of them.");
			}
			else
			{
				if (quest != "000")
				{
					self.say("I don't think you did what I asked of you. Please head to Eos Tower and take out #b50 #o3110102#s#k.");
					return;
				}
				
				self.say("Awesome! You took out all of them! There must have been quite a few #b#o3110102#s#k roaming around Eos Tower. Anyway, thank you for helping me out. I'll give you an item only available in Ludibrium that you'll need to use for hunting. Please take it!");
				
				if (!Exchange(0, 2000008, 50, 2000010, 50))
				{
					self.say("Please make sure there are two slots available in your use inventory.");
					return;
				}
				
				AddEXP(1250);
				SetQuestData(1002100, "end1");
				QuestEndEffect();
				self.say("Do you like the #b50 #t2000008#s and 50 #t2000010#s#k? Thank you so much for your help, but it seems like Eos Tower is still full of nasty monsters. I have a lot to ask of you, so if you have any free time, please come talk to me.");
			}
		}
		else if (order == 2)
		{
			if (quest == "")
			{
				bool start = AskYesNo("Wow, great timing! I actually have something else to ask you for a little help on. A few days ago, one of the guys from us reported that Eos Tower is now full of even nastier monsters than last time, and so I thought of you as the enforcer ? so can you do it instead of me??");
				
				if (!start)
				{
					self.say("Really. This task isn't that difficult, and I think you can do it. If you have any free time, then come talk to me.");
					return;
				}
				
				SetQuestData(1002101, "050050");
				self.say("Alright. It's similar to others last time. The tower that connects Ludibrium and ground, Eos Tower, is now infected with dirty spiders and black rats. So please go in and take care of some of them.");
				self.say("Please take care of #b50 #o3210205#s and #b50 #o2230103#s#k that are roaming around in Eos Tower. They are a bunch of huge black rats with springs on the back, and spiders making spider webs on the wall. I'll be here waiting until you take of all of them.");
			}
			else
			{
				if (quest != "000000")
				{
					self.say("I don't think you did what I asked of you. Please head to Eos Tower and take out #b50 #o3210205#s#k and #b50 #o2230103#s#k.");
					return;
				}
				
				self.say("Awesome! You took them all out again! There must have been quite a few #b#o2230103#s#k and #b#o3210205#s#k around Eos Tower. Anyway, thank you for helping me out. I'll give you an item that you'll need to use for hunting. Please take it!");
				
				if (!Exchange(0, 2000009, 50, 2000011, 50))
				{
					self.say("Please make sure there are two slots available in your use inventory.");
					return;
				}
				
				AddEXP(2500);
				SetQuestData(1002101, "end2");
				QuestEndEffect();
				self.say("Here they are, #b50 #t2000009#s and 50 #t2000011#s#k. Thank you so much for your help, but it seems like Eos Tower is still full of nasty monsters. I have a lot to ask of you, so if you have any free time, please come talk to me.");
			}
		}
		else if (order == 3)
		{
			if (quest == "")
			{
				bool start = AskYesNo("Hey, you're back! Actually, I have another favor to ask you. This time, I've heard reports that the menacing toy monsters have been appearing around the outer walls of Eos Tower, and I'd really like for you to defeat them for me. Will you help me out?");
				
				if (!start)
				{
					self.say("Really. This task isn't that difficult, and I think you can do it. If you have any free time, then come talk to me.");
					return;
				}
				
				SetQuestData(1002102, "030030");
				self.say("Okay! It's similar to what I requested before. There have been reports that some of the toys made from the Toy Factory, located at the bottom of the Ludibrium Clocktower, have been attacking anyone walking around the outer walls of Eos Tower. I would like for you to go back into the tower and take care of them.");
				self.say("Please take out #b30 #o3230303#s#k and #b30 #o3230308#s#k. Both of them can be found at the outer wall of Eos Tower. One resemble a toy pink plane, while the other looks like a pink bird. I'll be waiting for you here.");
			}
			else
			{
				if (quest != "000000")
				{
					self.say("I don't think you did what I asked of you. Please head to Eos Tower and take out #b30 #o3230303#s#k and #b30 #o3230308#s#k.");
					return;
				}
				
				self.say("Awesome! You took them all out again! There must have been quite a few #b#o3230303#s#k and #b#o3230308#s#k around Eos Tower. Anyway, thank you for helping me out. I'll give you an item that you'll need to use for hunting. Please take it!");
				
				if (!Exchange(0, 2000004, 50))
				{
					self.say("Please make sure there's a slot available in your use inventory.");
					return;
				}
				
				AddEXP(4000);
				SetQuestData(1002102, "e");
				QuestEndEffect();
				self.say("Here they are, #b50 #t2000004#s#k. Thank you so much for your help, but it seems like Eos Tower is still full of nasty, evil monsters. I have a lot to ask of you, so if you have any free time, please come talk to me.");
			}
		}
		else if (order == 4)
		{
			if (quest == "")
			{
				bool start = AskYesNo("Oh, hello! I've been waiting for you, actually, because something serious has occurred here. A group of unruly monsters have come to threaten and actually destroy Eos Tower and Ludibrium. I was wondering if you can help us out here ...");
				
				if (!start)
				{
					self.say("Really. This task isn't that difficult, and I think you can do it. If you have any free time, then come talk to me.");
					return;
				}
				
				SetQuestData(1002103, "025015");
				self.say("That's good! There were some leftover blocks while building Eos Tower, and those blocks were exposed to dark forces, reinventing themselves as Gollems. Those Gollems are nasty, unruly, and most definitely destructive. I know it is going to be dangerous, but I really hope you can take some of them out from Eos Tower for us.");
				self.say("Please take out #b25 #o4230109#s#k and #b15 #o4230110#s#k. They are Gollems made in toy blocks, and they are much more powerful than any you may have faced before. I'll be here wishing you a good luck.");
			}
			else
			{
				if (quest != "000000")
				{
					self.say("I don't think you have done everything I asked of you, yet. Please head over to Eos Tower and take out #b25 #o4230109#s#k and #b10 #o4230110#s#k.");
					return;
				}
				
				self.say("I can't believe you took care of all those unruly Gollems! How was it? They didn't destroy Eos Tower to the point of no return, did they? Anyway, I can't thank you enough for this. I'll give you this item that's essential on hunting, so please accept it!");
				
				if (SlotCount(2) < 1)
				{
					self.say("Please make sure there's a slot available in your use inventory.");
					return;
				}
				
				int[] rewards = {2044501, 2044601, 2043001, 2043201, 2043301, 2044001, 2044101, 2043101, 2044201, 2044301, 2044401, 2043701, 2043801, 2044701};
				
				int itemID = rewards[rnd.Next(rewards.Length)];
				
				if (!Exchange(0, itemID, 1))
				{
					self.say("Hmm... Are you sure you can take the reward?");
					return;
				}
				
				AddEXP(5500);
				SetQuestData(1002103, "e");
				QuestEndEffect();
				self.say($"Do you like the #b#t{itemID}##k? Thank you so much for your effort. Eos Tower will be safer than it was before you came here, but what is this weird feeling ? I don't know, but just to make sure, if you have any time available, please drop by.");
			}
		}
		else if (order == 5)
		{
			if (quest == "")
			{
				bool start = AskYesNo("Oh wow! Thank goodness you're here, because I've been waiting for you. First of all, I'd like to personally thank you for helping us protect Eos Tower from destruction. The problem is, unless we find the root of the problem, Eos Tower will be put to test again. I'd appreciate it if you find a way to take out this boss-life character in this game.");
				
				if (!start)
				{
					self.say("Really? I understand, since this is much tougher than any of the other things people asked for, but if you have any time, then please come back and talk to me.");
					return;
				}
				
				SetQuestData(1002104, "001");
				self.say("Thank you! As luck would have it, a few days ago, one of the guys here spotted what appeared to be a head figure. The way I see it, as long as it is here, Eos Tower will suffer the consequences. I would like for you to find it and kill it for me?");
				self.say("The monster you're facing is the leader of the Block Gollems, #b#o4130103##k. Astonishingly powerful, it is considered incomparable to other Gollems. I strongly suggest you take on it with your party or guild. I'll be here waiting for you.");
			}
			else
			{
				if (quest != "000")
				{
					self.say("I don't think you have killed it yet. Head over to the secret area of Eos Tower, and every once in a while, the leader of Block Gollem, #b#o4130103##k, should be there. It is the kind of monster you don't want to mess with, so I strongly advise you to take on it with a group of people. I'll be here waiting for you. Good luck!");
					return;
				}
				
				self.say("Unbelievable ... you really took care of #b#o4130103##k? That's just un-be-lievable. You have done so much for me and other residents of Ludibrium, that I'll have to give you a handsome reward. The item I'm giving you shall help you out while hunting, so please accept it.");
				
				if (SlotCount(2) < 1)
				{
					self.say("Please make sure there's a slot available in your use inventory.");
					return;
				}
				
				int[] rewards = {2040804, 2040805};
				
				int itemID = rewards[rnd.Next(rewards.Length)];
			
				if (!Exchange(0, itemID, 1))
				{
					self.say("Hmm... Are you sure you can take the reward?");
					return;
				}
				
				AddEXP(7200);
				SetQuestData(1002104, "e");
				QuestEndEffect();
				self.say($"Do you like the #b#t{itemID}##k? Thank you so much for helping. It seems like Eos Tower AND Ludibrium are now in peace. I am so glad I ran into you in dire times like this. Thank you for all your hard work. Please drop by often!");
			}
		}
	}
	
	
	private void CleaningHeliosTower()
	{
	}
	/*
		if (quest == "")
		{
			self.say("My gosh, it seems like there's work wherever I go. Since Ludibrium is one giant castle, there seems to be a problem here and there popping up by the minute. This time, I've been reported that there's a major problem at the Helios Tower, which opened only recently to the public.");
			bool start = AskYesNo("Unfortunately, all the toy soldiers are currently stationed at Eos Tower, so there's no one available to take care of Helios Tower. Say, you seem like someone that enjoys adventures... can I ask you for a little help? ");
			
			if (!start)
			{
				self.say("You don't feel like doing it? It's not that difficult, though. If you ever feel like changing your mind, I'll be here waiting. Like I said, this is very important, for it has everything to do with the safety of Helios Tower.");
				return;
			}
			
			SetQuestData(, "020");
			self.say("Helios Tower is located at the East of Ludibrium, and it serves as the rock-solid foundation of Ludibrium, along with Eos Tower. The tower is also the home of #b#o3210208##k, a rat monster that has been rapidly growing in numbers, and they have currently been causing a lot of problems with the elevators at the tower.");
			self.say("This is very important, for it has everything to do with the safety of the elevators there. Please head over to Helios Tower and eliminate #b30 #o3210208#s#k.");
		}
		else
		{
			if (quest != "000")
			{
				self.say("Please check Helios Tower immediately, for #o3210208#s are causing great havoc there. We need every help we can find, and your help will be very much appreciated.");
				return;
			}
			
			self.say("You must have done a great job; the people here are talking about the job you did there at the tower. They saw a noticeable decrease in the number of #o3210208#s at Helios Tower. What can I say, great job!");
			
			if (!Exchange(0, 2000011, 100))
			{
				self.say("Please make sure you have room in your use inventory first.");
				return;
			}
			
			AddEXP(6000);
			SetQuestData(, "e");
			QuestEndEffect();
			self.say("This is a reward for your effort, brought to you by the people of Ludibrium. Hopefully this will aid your journey down the road.");
		}
	}
	*/
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1002100)
		{
			if (info != "end1" && Level >= 30)
				return " Cleaning up Eos Tower";
		}
		else if (quest == 1002101)
		{
			string eos1 = GetQuestData(1002100);
			
			if (info != "end2" && eos1 == "end1")
				return " Cleaning deep inside the Eos Tower";
		}
		else if (quest == 1002102)
		{
			string eos2 = GetQuestData(1002101);
			
			if (info != "e" && eos2 == "end2")
				return " Cleaning Up the Outer Parts of Eos Tower";
		}
		else if (quest == 1002103)
		{
			string eos3 = GetQuestData(1002102);
			
			if (info != "e" && eos3 == "e" && Level >= 35)
				return " Eos Tower Threatened!";
		}
		else if (quest == 1002104)
		{
			string eos4 = GetQuestData(1002103);
			
			if (info != "e" && eos4 == "e" && Level >= 40)
				return " Peace at Eos Tower";
		}/*
		else if (quest == heliosquest)
		{
			if (info != "e" && Level >= 35)
			{
				return " Cleaning Up Helios Tower";
			}
		}*/
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1002100, 1002101, 1002102, 1002103, 1002104};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "Hello, there! I'm #b#p2041004##k, in charge of the security for Ludibrium. Lately there have been some filthy creatures dirtying up Eos Tower, and I don't like it one bit.";
		
		if (GetQuestData(1002104) == "e")
			dialogue = "Hey! You're the one that cleaned out the Eos Tower for me last time! How have you been? I'm so glad the number of monsters have generally decreased, and they aren't as wild as they were before. I really appreciate all your hard work. Oh well, hope you have a great day at Ludibrium!";
		
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
			case 0: CleaningEosTower(GetQuestData(1002100), 1); break;
			case 1: CleaningEosTower(GetQuestData(1002101), 2); break;
			case 2: CleaningEosTower(GetQuestData(1002102), 3); break;
			case 3: CleaningEosTower(GetQuestData(1002103), 4); break;
			case 4: CleaningEosTower(GetQuestData(1002104), 5); break;
			
			case 5: CleaningHeliosTower(); break;
		}
	}
}