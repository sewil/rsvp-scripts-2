using System;
using System.Collections.Generic;
using WvsBeta.Game;

// 2032001 Spiruna
public class NpcScript : IScriptV2
{
	private void OldBook(string quest)
	{
		if (quest == "")
		{
			self.say("I am working on an important spell so don't bother me and leave this house immediately. I can't concentrate if a stranger is walking around my house. Leave! Shoo!");
			SetQuestData(1001502, "s");
		}
		else if (quest == "s")
		{
			self.say("I can't believe you'd just barge in to a stranger's home. Are you out of your mind??");
			SetQuestData(1001502, "2");
		}
		else if (quest == "2")
		{
			self.say("Want me to listen to your story? I'm busy.");
			SetQuestData(1001502, "3");
		}
		else if (quest == "3")
		{
			self.say("Do I know of a person named #bHella#k? I don't have time for stupid questions like that.");
			SetQuestData(1001502, "4");
		}
		else if (quest == "4")
		{
			self.say("You've been a really annoying presence here. #bHella#k, you say? I may have heard of the name, but I'm busy right now.");
			SetQuestData(1001502, "5");
		}
		else if (quest == "5")
		{
			self.say("You don't let up, do you. Alright, let's see what you're made of. You're looking for a woman named #bHella#k, right? I know her, but I can't tell you anything else. A few days ago I went to the snowfield looking for some materials for this spell I'm currently working on, and wound up losing my precious\r\n#bBlack Crystal#k. If you find that crystal, then I'll tell you everything I know of. Good luck.");
			AddEXP(2000);
			SetQuestData(1001502, "s1");
		}
		else if (quest == "s1")
		{
			self.say("You haven't found my crystal yet. A few days ago I went to the snowfield looking for some materials for this spell I'm currently working on, and wound up losing my precious #bBlack Crystal#k. If you find that crystal, then I'll tell you everything I know of. Good luck.");
		}
		else if (quest == "s2")
		{
			if (ItemCount(4031050) < 1)
			{
				self.say("You haven't found my crystal yet. A few days ago I went to the snowfield looking for some materials for this spell I'm currently working on, and wound up losing my precious #bBlack Crystal#k. If you find that crystal, then I'll tell you everything I know of. Good luck.");
				return;
			}
			
			self.say("Ohh ... looks like you have found my #bBlack Crystal#k, and... hey, what happened? My ... my ... Black Crystal is cracked!! You incompetent fool! Do you think you can actually get away with breaking my crystal?? I don't want to see your face so get out of here now!! Arrrgh ... I need to find a way to fix it ... do I have to let my assistant take care of it?");
			
			if (!Exchange(0, 4031050, -1))
			{
				self.say("Are you sure you brought it??");
				return;
			}
			
			AddEXP(5240);
			SetQuestData(1001502, "s3");
		}
		else if (quest == "s3" || quest == "s4" || quest == "s5")
		{
			self.say("I can't believe you have the nerve to show up after breaking my precious #bBlack Crystal#k!!! Thanks to you my work is set back another six months! It will be easy to fix it with an item from the fairies but I'd rather die than ask them for their help. Do I have to let my assistant do it? Arghhh...");
		}
		else if (quest == "s6")
		{
			if (ItemCount(4031051) < 1)
			{
				self.say("I can't believe you have the nerve to show up after breaking my precious #bBlack Crystal#k!!! Thanks to you my work is set back another six months! It will be easy to fix it with an item from the fairies but I'd rather die than ask them for their help. Do I have to let my assistant do it? Arghhh...");
				return;
			}
			
			self.say("Isn't that #t4031051#?!? I can restore #b#t4031050##k to its original state with that! And you aren't the one that cracked the crystal? I see ... it could have been the monsters walking around accidentally stepping on it ... it's my fault anyway that I dropped something as precious as the crystal at a treacherous place like that. Thank you so much for your help. Please accept this; it's the least I can do for you.");
			
			var rnd = new Random();
			int[] scrolls = {2041001, 2041002, 2041004, 2041005};
			
			int itemID = scrolls[rnd.Next(scrolls.Length)];
			
			if (!Exchange(0, 4031051, -1, itemID, 1))
			{
				self.say("Please leave a space open in your use tab.");
				return;
			}
			
			AddEXP(10590);
			SetQuestData(1001502, "end");
			SetQuestData(1001501, "h5");
			QuestEndEffect();
			self.say("I'll give you Hella's whereabouts like I promised. 3 months ago a young woman barged into my home. She lost her mother because of an evil sorcerer and wanted to acquire the powerful spell herself. She wanted to become my assistant and learn everything from me. Her name is Hella, #bright there, my assistant, she's Hella#k. There's no point hiding anymore. Might as well hear from Hella herself.");
		}
	}
	
	private void OrbisInDanger(string quest)
	{
		if (quest == "")
		{
			AskMenu("...You've got no manners whatsoever, to barge into someone else's house without permission.#b",
				(0, " Are you #p2032001#, the prophet with an uncanny ability to see the future?")
			);
			AskMenu("Well... it seems like people refer to me as that. That wouldn't be the only reason for you to see me, to find out who I am. What do you want?#b",
				(0, " Apparently, you made a very ominous prophecy on something, and I'm here to find out the details of it")
			);
			AskMenu("Ahhh... because of THAT little thing? Don't worry about it, it's nothing big. Soon #bOrbis will crash-land to the ground.#k It'll happen in a very near future, too.#b",
				(0, " What?! That's huge! Is there anything I can do to stop it?")
			);
			
			bool start = AskYesNo("You're full of courage, aren't you. Do you really want to save Orbis?");
			
			if (!start)
			{
				self.say("At least you are aware of your limitations ... but how can you call yourself a traveler when you're only concerned with your own safety? Think again...");
				return;
			}
			
			SetQuestData(1009800, "s");
			self.say("Are you full of confidence, or ignorance? Do you really think you can single-handedly save #m200000000# from its impending doom? It's all just fruitless.");
		}
		else if (quest == "s")
		{
			AskMenu("Don't bother me ... if you're intimidated, than just leave Orbis.#b",
				(0, " #p2032001# Hold on! Is there really no way to stop it?")
			);
			self.say("You're really getting on my nerves. One more, and I'll drop your fame level!");
			
			SetQuestData(1009800, "1");
		}
		else if (quest == "1")
		{
			self.say("...(Spiruna seems to be in a state of deep thought.)");
		}
	}
	
	private void DarkCrystal()
	{
		int start = AskMenu("Hella is a good child. Everything I ask, whether it's difficult or not, she does without complaining about anything. One day she will become a much better sorcerer than I. What do you want from me anyway??#b",
			(0, " I want to make #t4005004#"),
			(1, " No, nothing"));
		
		if (start == 0)
		{
			bool askCraft = AskYesNo("#b#t4005004##k?? How did you ... did you hear about this from  #b#p2020005##k? Yes, I know how to refine, but... this ore is very difficult to obtain. To make #b1 #t4005004##k, I need #b10 #t4004004#s#k and 50000 mesos. Do you want one?");
			
			if (!askCraft)
			{
				self.say("#b#t4005004##k. I haven't seen it for a long time... it's been hundreds of years since I last refined it, so I can barely remember how I made it... of course, you won't have it now...");
				return;
			}
			
			if (!Exchange(-50000, 4004004, -10, 4005004, 1))
			{
				self.say("Are you lacking mesos? Make sure you have #b10 #t4004004#s#k, 50000 mesos and your etc. inventory has space.");
				return;
			}
			
			self.say("Here, take #b1 #t4005004##k. It's been a long time since I last made one, I hope it worked... By the way, how did you obtain the crystal ores? You must be really special. Either way, it's an incredible item. Please make good use of it.");
		}
		else if (start == 1)
		{
			self.say("I am working on an important spell so don't bother me and leave this house immediately. I can't concentrate if a stranger is walking around my house. Please go away...");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1001502)
		{
			string questBook2 = GetQuestData(1001501);
			
			if (questBook2 == "h4" && (info == "" || info == "s" || info == "2" || info == "3" || info == "4" || info == "5"))
				return " Looking For the Old Lady";
			
			else if (info == "s1")
				return " Spiruna's Black Crystal";
			
			else if (info == "s2")
				return " The Cracked Black Crystal";
			
			else if (info == "s3" || info == "s4" || info == "s5" || info == "s6")
				return " To Restore the Crystal";
		}
		else if (quest == 1009800)
		{
			if ((Level >= 30 && info == "") || info == "s" || info == "1")
				return " Spiruna's Prophecy";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1001502, 1009800};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		if (GetQuestData(1001502) == "end")
			options.Add((2, " Dark Crystal"));
		
		string dialogue = "I'm in the middle of a very important work here so please don't bother me and leave this place. I can't concentrate when a stranger is around.";
		
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
			case 0: OldBook(GetQuestData(1001502)); break;
			case 1: OrbisInDanger(GetQuestData(1009800)); break;
			case 2: DarkCrystal(); break;
		}
	}
}