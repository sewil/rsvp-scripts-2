using System;
using System.Collections.Generic;
using WvsBeta.Game;

// 2041023 - Flo
public class NpcScript : IScriptV2
{
	private void PieceOfCrack(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("Did #p2041021# mention something about collecting the Piece of Cracked Dimension to seal up the crack at the generator? They come in all shapes and sizes, but only one is real. Can you find it for me?");
			
			if (!start)
			{
				self.say("Just so you know, I am the ONLY person that can pick out the cracked piece of dimension~");
				return;
			}
			
			SetQuestData(7100001, "s");
			self.say("Only powerful monsters possess the pieces of cracked dimension. They all possess the pieces of cracked dimension that they penetrated through. If there's a monster that came through with the same crack as #o8500001#, then that one will have the piece to the crack that seals it up.");
			self.say("I am aware of 3 types of cracks. If you bring out all three of them, then I can use my spells to pick out which one of those is the one that fits #b#o8500001##k's crack.");
			self.say("You can probably get the pieces from #b#o8141100##k and #b#o8143000##k, the monsters that came with #o8500001#, two of the monsters that came here with the #o8500001# Please get me one of each of these three types of cracks.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031176) < 1 || ItemCount(4031177) < 1 || ItemCount(4031178) < 1)
			{
				self.say("You didn't bring the stuff I asked you to get. Please check again.");
				return;
			}
			
			self.say("Did you gather up the #r3 types#k of #b#t4031179##k like I asked you to? Don't worry, I'll look at each and every one of them and see which of those fits into the #bcracked dimension#k.");
			
			if (!Exchange(41000, 4031176, -1, 4031177, -1, 4031178, -1, 4031179, 1))
			{
				self.say("Please leave an empty slot in your etc. inventory first.");
				return;
			}
			
			AddEXP(13400);
			SetQuestData(7100001, "e");
			QuestEndEffect();
			self.say("Here you go. This piece seems to be the one that fell out of the cracked dimension when #o8500001# barged in. Take #b#t4031179##k and see #b#p2041021##k. He'll tell you what to do from there on out.");
		}
	}
	
	private void LostPiece1()
	{
		self.say("I heard about what happened through Mr. Bouffon. You lost your cracked piece of dimension? I'll give you my cracked piece right now.");
		
		if (!Exchange(0, 4031179, 1))
		{
			self.say("Check your etc. inventory to see if there's a free slot first.");
			return;
		}
		
		SetQuestData(7100003, "e");
		SetQuestData(7100006, DateTime.UtcNow.AddDays(1).ToString());
		QuestEndEffect();
		self.say("How do I have cracked pieces of dimension? That's a secret, kind of like magic. Please drop by every once in a while.");
	}
	
	private void LostMedal()
	{
		self.say("I also heard from Mr. Bouffon about the medal. I'll give you the one that I'm wearing right now, then.");
		
		if (!Exchange(0, 4031172, 1))
		{
			self.say("Check your etc. inventory to see if there's a free slot first.");
			return;
		}
		
		SetQuestData(7100004, "e");
		SetQuestData(7100007, DateTime.UtcNow.AddDays(3).ToString());
		QuestEndEffect();
		self.say("How do I have this Ludibrium medal? there's a way...there's a way... kind of like magic.");
	}
	
	private void LostPiece2()
	{
		int start = AskMenu("What's going on? Did you give #p2041021# the #t4031179# that I gave you?#b",
			(0, " Ah... um... I haven't met #p2041021#, yet. I've been really busy lately. I better get going... right... now..."),
			(1, " Well, the truth is... I lost the #t4031179# that you gave me."));
		
		if (start == 0)
		{
			self.say("Ah... you were busy, but then... #b#p2041021##k is located right across here, at the #bEntrance of Forgotten Path of Time#k. Please get this and give it to him immediately. It is very important that you do NOT lose the piece of crack this time around.");
			return;
		}
		
		self.say("What? How? How in the world did you lose it? You should have taken that and give it to #b#p2041021##k immediately! You fought hard against dangerous monsters to obtain that item! Well... there's no choice now. I had another one of #b#t4031179##k for emergency purposes like this. I'll give that to you.");
		
		if (!Exchange(0, 4031179, 1))
		{
			self.say("Check your etc. inventory to see if there's a free slot first.");
			return;
		}
		
		SetQuestData(7100005, "e");
		QuestEndEffect();
		self.say("And #rPLEASE listen#k to what I'm about to tell you. The #b#t4031179##k that I gave you, I luckily found it somewhere deep in the Warped Path of Time  because some monster dropped it. What I'm saying is, #rif you lose #t4031179# again, then there's no way I can help you around it#k. Now PLEASE take care of it.");
		self.say("There's not much time left. Please go see #b#p2041021##k and give him the #b#t4031179##k. Please remember that the cracked piece represents your very #rLAST CHANCE#k at doing this. Here's wishing you a good luck.");
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		var today = DateTime.UtcNow;
		
		if (quest == 7100001)
		{
			string papulatus = GetQuestData(7100000);
			
			if ((info == "" && papulatus == "3") || info == "s")
				return " A Piece of Crack";
		}
		else if (quest == 7100003)
		{
			if (info == "s")
				return " The Lost Piece of Crack";
		}
		else if (quest == 7100004)
		{
			if (info == "s")
				return " The Lost Medal";
		}
		else if (quest == 7100005)
		{
			if (info == "s")
				return " The Lost Piece of Crack";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {7100001, 7100003, 7100004, 7100005};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "I'm Flo, in charge of protecting the Path of Time. Would you like to see me work my magic?";
		
		if (GetQuestData(7100001) == "e")
			dialogue = "Showtime!! Am I good or what?";
		
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
			case 0: PieceOfCrack(GetQuestData(7100001)); break;
			case 1: LostPiece1(); break;
			case 2: LostMedal(); break;
			case 3: LostPiece2(); break;
		}
	}
}