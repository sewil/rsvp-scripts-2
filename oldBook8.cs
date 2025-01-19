using System;
using System.Collections.Generic;
using WvsBeta.Game;

// 2012011 Kriel the Fairy
public class NpcScript : IScriptV2
{
	private void AncientBook(string quest)
	{
		if (quest == "s4")
		{
			int ask = AskMenu("Can't you see I'm busy? You look like one of those wandering humans that I see everyday. What do you want from me?#b",
				(0, " Nothing really."),
				(1, " What's your relationship with Edel the Fairy?"),
				(2, " I need #t4031051#..."));
				
			if (ask == 0)
			{
				self.say("I'm busy so don't bother me unless you have something important to say. We've been having more customers than usual these days, so I'm really busy around here. Also in here there are a ton of materials for spells so don't even think about sneaking away with a few.");
			}
			else if (ask == 1)
			{
				self.say("What's my relationship with Edel the Fairy? I'm her sister. She opened her store not long ago and she needed a hand badly so I'm here to help at this moment, but I'm still not used to it...");
			}
			else if (ask == 2)
			{
				self.say("You need #b#t4031051##k? Are you one of those selfish humans that just blatantly ask the fairies for help with nothing in return?? Hmmm ... what's that? You came here with a word from #bSpiruna's assistant#k? To fix the cracked crystal ... ? I see... in this case I can't ignore this at all. I owe her a bit too from way back. But I'm only helping you out here once!");
				
				AddEXP(2000);
				SetQuestData(1001502, "s5");
				self.say("But I can't just give you that so easily. #b#t4031051##k is a very important item for us, but I'm willing to make a deal with you, if you get me some items that I need. What I need are #b100 #t4000059#s, 50 #t4000060#s, and 30 #t4000061##k. With those I think I can make a good tool for wizards. Good luck.");
			}
		}
		else if (quest == "s5")
		{
			if (ItemCount(4000061) < 30 || ItemCount(4000059) < 100 || ItemCount(4000060) < 50)
			{
				self.say("I don't think you have gathered up all the items I asked you to get. Bring #b100 #t4000059#s, 50 #t4000060#s and 30 #t4000061#s#k, and #b#t4031051##k will be yours. Spiruna's assistant, Hel ... oh yeah, her name is supposed to be a secret. Anyway I'm doing you a favor because of her~ Good luck!");
				return;
			}
			
			self.say("Hey, you did collect all of them! Not bad at all ... she really has an eye for a talent. Anyway since you did me a huge favor, here's #b#t4031051##k like I promised. It's a very important item so make sure you don't lose it.");
			
			if (!Exchange(0, 4000061, -30, 4000059, -100, 4000060, -50, 4031051, 1))
			{
				self.say("Huh, are you sure you have space in your etc. inventory?");
				return;
			}
			
			AddEXP(7230);
			SetQuestData(1001502, "s6");
		}
		else if (quest == "s6")
		{
			if (ItemCount(4031051) >= 1)
			{
				self.say("Please give #b#t4031051##k to her immediately! Who's her? Spiruna, of course. I have to go now. See you around.");
				return;
			}
			
			self.say("Hey, you did collect all of them! Not bad at all ... she really has an eye for a talent. Anyway since you did me a huge favor, here's #b#t4031051##k like I promised. It's a very important item so make sure you don't lose it.");
			
			if (!Exchange(0, 4031051, 1))
			{
				self.say("Huh, are you sure you have space in your etc. inventory?");
			}
		}
	}
	
	private void NewWorld(string quest)
	{
		if (quest == "s1")
		{
			if (ItemCount(4031197) < 1)
			{
				self.say("Hi, how can I help you?");
				return;
			}
			
			self.say("Hi, how can I help you? Hey, that's ... isn't that ... are you from Ellinia? That's definitely my friend Wing's, and how did you ... oh, Wing wanted you to give it to me?");
			self.say("Oh, wow, I didn't expect this to happen! I've been wanting this for so long, and I've annoyed the heck out of Wing by asking for this. Wing didn't look like he wanted to give it up, but ... I can't believe he'd send #b#t4031197##k to me through you.");
			bool start = AskYesNo("Is this your first time here in Ossyria? You may not be totally comfortable with the new surroundings and so ... if you have some spare time, would you mind helping me out here? I can give you a task that'll enable you to go to different places and get acclimated to Ossyria.");
			
			if (!start)
			{
				self.say("It'll be beneficial to you to get yourself acclimated to Ossyria while helping me out with my work.");
				return;
			}
			
			if (!Exchange(0, 4031197, -1))
			{
				self.say("Are you sure you brought the #b#t4031197##k? Please check again.");
				return;
			}
			
			AddEXP(2000);
			SetQuestData(1005800, "s2");
			self.say("Thank you so much! I make weapons and items for wizards here, but lately I've been so busy that I was looking for someone else to help me do this.");
			self.say("Walk around town, and you may find some empty wooden boxes lying around. Inside the boxes, you'll find a bunch of empty bottles. These are empty potion bottles that have been purchased from here, and are waiting to be recycled. Can you collect #b20 #t4031198#s#k for me?");
			self.say("I'm now trying to make a weapon for magicians, and I'll need you to collect some materials needed for this. You'll find #b#o3210200#, #o3210201#, and #o3210202##k wandering around near El Nath. Please collect #b200 #t4000073#s#k and #b50 #t4000058#s#k from them.");
		}
		else if (quest == "s2")
		{
			if (ItemCount(4000073) < 200 || ItemCount(4031198) < 20 || ItemCount(4000058) < 50)
			{
				self.say("Did you gather up all the items I requested? They would #b20 #t4031198#s, 200 #t4000073#s, and 50 #t4000058#s#k.");
				return;
			}
			
			self.say("I am amazed at how fast you've collected all these. You have been a great help. Thank you, and please accept this as a sign of my gratitude. \nAre you getting more comfortable here now?");
			
			if (SlotCount(2) < 1)
			{
				self.say("Please make some room in your use inventory so I can reward you.");
				return;
			}
			
			var rnd = new Random();
			int[] reward = {2040804, 2043301, 2043701, 2043801, 2044001, 2044101, 2044201, 2044301, 2044401, 2044501, 2044601, 2044701};
			
			int itemID = reward[rnd.Next(reward.Length)];
			
			if (!Exchange(0, 4000073, -200, 4031198, -20, 4000058, -50, itemID, 1))
			{
				self.say("Hmm... are you sure you gathered all the items I asked for? Please check again.");
				return;
			}
			
			AddEXP(25000);
			SetQuestData(1005800, "e");
			QuestEndEffect();
			self.say("I have to go now. I'll see you around~");
		}
	}
	
	private void OceanView(string quest)
	{
		if (quest == "")
		{
			AskMenu("I see a lot of traveling humans up here in Orbis. I'm sure each and every one of them are here to observe the world from an elevated stand point, but as a fairy, I really don't understand the need to see from up there, since I can just straighten up the wings and fly wherever you want.#b",
				(0, " But there are places you can't go with the wings on, a\r\nplace like Aqua Road.")
			);
			AskMenu("I heard there's a place called Aqua Road deep in the middle of the ocean. I have seen the ocean from up here a million times, and seriously, what's so incredible about a huge body of blue water? Lisa went there a few days ago and came back with nothing but praise about Aqua Road, but it's nothing compared to what we the fairies see.#b",
				(0, " No, no! Aqua Road is a beautiful place. You'll see what I mean if you ever get to go there.")
			);
			bool start = AskYesNo("I don't think I can believe you. There's no place in the world as beautiful as Orbis, where the fairies reside. My opinion may change, however, if you show me, say, a photo album full of Aqua Road pictures...");
			
			if (!start)
			{
				self.say("That's what I thought. You're not really sure about what you just said, right? It's only a fleeting rumor that a place like Aqua Road is beautiful. It's much more beautiful up here, where I live.");
				return;
			}
			
			SetQuestData(1009900, "s");
			self.say("According to Lisa, who visited Aqua Road a few days ago, she said a person by the name of Muse, who works at the Aquarium Zoo, sells the \"Official Aqua Road Photo Album.\"");
			self.say("If Aqua Road is indeed more beautiful than this place like you said, then prove it to me by showing me that photo album.");
		}
		else if (quest == "s" || quest == "1" || quest == "2" || quest == "3" || quest == "4")
		{
			self.say("Are you sure there really is a photo album around?");
		}
		else if (quest == "5")
		{
			if (ItemCount(4031310) < 1)
			{
				self.say("Are you sure there really is a photo album around?");
				return;
			}
			
			self.say("What? You brought the Aquarium Photo album? Hmm, this doesn't interest me too much, but lemme see.");
			
			var rnd = new Random();
			int[] reward = {2040705, 2040704, 2040707, 2040708};
			
			int itemID = reward[rnd.Next(reward.Length)];
			
			if (!Exchange(0, 4031310, -1, itemID, 1))
			{
				self.say("Make room in your use inventory first.");
				return;
			}
			
			AddEXP(3000);
			SetQuestData(1009900, "e");
			self.say("Aqua Road... indeed, it's a beautiful place. It didn't seem like anything more than a huge body of water looking from up there, but... to think all these beautiful things are around under the sea... I was just being ignorant. I didn't think long and hard enough about this. Hey, traveler, I strongly recommend you walk around and observe each and everything that's around this world.");
			self.say("And if you ever find another place with beautiful scenery, please let me know! I know this isn't much, but please take it. It should definitely help you on your journey...");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1001502)
		{
			if (info == "s4")
				return " To Acquire the Fairy Dust";
			
			else if (info == "s5" || info == "s6")
				return " Acquiring the Fairy Dust";
		}
		else if (quest == 1005800)
		{
			if (info == "s1")
				return " Delivering a Mysterious Item";
			
			else if (info == "s2")
				return " Helping Kriel Out";
		}
		else if (quest == 1009900)
		{
			if (Level >= 30 && info != "e")
				return " The Ocean View : Kriel's Offer";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1001502, 1005800, 1009900};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "Lately humans have been asking for favors as if it's nothing. If they think we fairies will say yes to their every demand, well that's WRONG! Anyway, what do you want from me?";
		
		if (GetQuestData(1001502) == "end")
			dialogue = "Did #b#t4031051##k help you in any way shape or form? Anyway, that assistant of Spiruna ... is she doing alright? If you ever see her again, then please say hi to her for me.";
		
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
			case 0: AncientBook(GetQuestData(1001502)); break;
			case 1: NewWorld(GetQuestData(1005800)); break;
			case 2: OceanView(GetQuestData(1009900)); break;
		}
	}
}