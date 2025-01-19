using System;
using System.Collections.Generic;
using WvsBeta.Game;

// 2060006 - Muse
public class NpcScript : IScriptV2
{
	private void SeaWitch(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("Thank you for making your way here. I need to ask you for a favor. Would you like to find out what it is?");
			
			if (!start)
			{
				self.say("It may be a difficult task, so please think carefully, and if you want to change your mind, please talk to me. I'll give you the details then.");
				return;
			}
			
			SetQuestData(1007500, "s");
			self.say("That's good to hear. I can't thank you enough for saying yes because the favor I want to ask of you involves a very personal matter. See, I have a boyfriend named #bGail#k, a sweet-hearted fella with a passion for the ocean.");
			self.say("A while ago, he volunteered to go on an expedition to investigate the signs of anomaly that were occuring at the deep ocean. I was able to keep in touch with him for a bit, but I haven't been able to talk to him the past few days. I'm concerned about his well-being, because the deep part of the ocean is not to be messed with, a dangerous place for anyone to venture into. So dangerous, in fact, that I can't even fathom going there myself.");
			self.say("A few days ago, Melias of the Armor Store told me this interesting story. He said there's a sea witch living at the entrance of the deep ocean called #b#p2060100##k, and apparently, she is a great fortune-teller who sees everything.");
			self.say("Go talk to that sea witch and ask her the whereabouts of \r\n#bGail#k. I'm too weak to go all the way down to the bottom of the ocean, but you seem more than strong enough to do so. I'm sure you'll run into her there. Thanks~");
		}
		else if (quest == "s" || quest == "1")
		{
			self.say("Go talk to that sea witch and ask her the whereabouts of \r\n#bGail#k. I'm too weak to go all the way down to the bottom of the ocean, but you seem more than strong enough to do so. I'm sure you'll run into her there. Thanks~");
		}
		else if (quest == "2")
		{
			AskMenu("You're back. I was beginning to worry about you, since you haven't showed up in so long. Have you met the Sea Witch? What did she say?#b",
				(0, " Not good. She said Gail is swallowed up by a black fog, which cannot be good, and because of that she can't see anything else."));
			
			self.say("I see... something really must have happened ... oh no, I feel like I'm gonna lose it. Who am I supposed to ask for help? I better alert the townspeople first.");
			
			if (!Exchange(0, 1102048, 1))
			{
				self.say("Please leave a slot open in your inventory so I can give you this...");
				return;
			}
			
			AddEXP(1000);
			SetQuestData(1007500, "e");
			QuestEndEffect();
			self.say("Thank you for your work. It must have been really difficult for you, but you came through. This isn't much, but please take it. Now I'll have to discuss this matter with the townspeople, so I'll see you around.");
		}
	}
	
	private void Cooking(string quest)
	{
		if (quest == "s")
		{
			if (ItemCount(4000181) < 80 || ItemCount(4000183) < 150)
			{
				self.say("Hi, welcome to the Aquarium Zoo! Did you need help with anything?");
				return;
			}
			
			self.say("Oh my! That's a LOT of #t4000183# and #t4000181#! And you're here through a request from #p2060000#? Ahhh... he really wanted that food, and I am guessing he asked you for help. Please wait for a minute. I'll make something really delicious out of these ingredients!");
			self.say("...");
			self.say("You've waited long enough, and now, the food is ready. Please deliver this to #b#p2060000##k.");
			
			if (!ExchangeEx(0, "4000183", -150, "4000181", -80, "4031281,Period:60", 1))
			{
				self.say("Please make sure there's an empty space in your etc. inventory first!");
				return;
			}
			
			AddEXP(80000);
			SetQuestData(1009700, "1");
			
			self.say("And please remember this one thing! This food is worth eating only when it's hot. That's also the reason why I've wrapped it up in multiple layers inside the box. Despite all that, it only keeps the food hot for #r1 hour#k, then it's going to get cold fast. PLEASE get this to Nanuke in #r1 hour#k! Got it?");
		}
		else if (quest == "1")
		{
			if (ItemCount(4031281) >= 1)
			{
				self.say("Please go see #p2060000#. If you don't get there in #r1 hour#k, the food is going to get cold and may need to be thrown away as a result.");
				return;
			}
			
			self.say("Ahhh... you wound up not giving the dish to #b#p2060000##k in #r1\r\nhour#k like you were told. I made it clear that you had to be on time. Thankfully, you brought all the necessary ingredients, so I'll make it again for you. This time, please give them to #b#p2060000##k in #r1 hour#k.");
			
			if (!ExchangeEx(0, "4031281,Period:60", 1))
			{
				self.say("Please make sure there's an empty space in your etc. inventory first!");
			}
		}
	}
	
	private void OceanView(string quest)
	{
		if (quest == "s")
		{
			AskMenu("#t4031310#? Yeah, I sell them, but those were special, limited editions, and they are all sold out.#b",
				(0, " Really? Is there a way I can get it? I really, really need it...")
			);
			bool start = AskYesNo("Hmmm... there's this photo album I made for myself, but ... oh well, if you really, really need it, then I'll sell it to you. But you'll have to do me one favor...");
			
			if (!start)
			{
				self.say("I cannot give you the photo album if you don't want to help me out here...");
				return;
			}
			
			SetQuestData(1009900, "1");
			self.say("I have never been out of water in my whole entire life. I've heard from various travelers that there's this thing called SNOW on land, and they all mentioned how beautiful the snow crystal looks like. I really wanna see it myself, but unfortunately, snow melts very quickly inside the ocean.");
			self.say("To keep it from melting even in the middle of the ocean will require the special magic of #r#p2020005##k, the head wizard of El Nath. I heard he can make the Snow Crystal Sphere by collecting the snow crystals. Please get me the object that surely looks like this #i4031312#.");
		}
		else if (quest == "1" || quest == "2" || quest == "3")
		{
			self.say("Have you met #p2020005#?");
		}
		else if (quest == "4")
		{
			if (ItemCount(4031312) < 1)
			{
				self.say("Have you gotten the #b#t4031312##k that I asked you to get?");
				return;
			}
			
			self.say("So you brought the snow? Let me see let me see!! Ahh... it's white, and it's cold... wow, so this is called snow. This is just incredible... and SO PRETTY! I can finally understand what it's like to be simultaneously ice cold and warm. Thank you so much, traveler! I have finally experienced something I'll experience again...");
			
			if (!Exchange(0, 4031312, -1, 4031310, 1))
			{
				self.say("Are you sure you have a free space in your etc. inventory?");
				return;
			}
			
			AddEXP(1000);
			SetQuestData(1009900, "5");
			self.say("Here, I'll give you #b#t4031310##k. Since you have given me a present that I'll never forget, this photo album is yours for free.");
		}
		else if (quest == "5")
		{
			if (ItemCount(4031310) >= 1)
			{
				self.say("Hi! Are you enjoying the photo album I gave you?");
				return;
			}
			
			AskMenu("Hello. You're the person that gave me the Snow Crystal Sphere, right? Don't worry, I'm keeping it at a safe place. How can help you?#b",
				(0, " I lost the photo album. Can I get another one?")
			);
			bool purchase = AskYesNo("Oh, no!! Well... I've made a new one since then, but I can't give it to you for free this time. I'm selling this for 10,000 mesos. Do you want one?");
			
			if (!purchase)
			{
				self.say("Hmmm ... are you short on mesos?");
				return;
			}
			
			if (!Exchange(-10000, 4031310, 1))
			{
				self.say("Hmmm ... are you short on mesos?");
				return;
			}
			
			self.say("Yes, thank you. Here's the photo album. The album is full of pictures that capture the true beauty of Aqua Road. Enjoy~!");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1007500)
		{
			if ((info == "" && Level >= 90) || info == "s" || info == "1")
				return " Carta the Sea Witch";
			
			else if (info == "2")
				return " Carta's Fortune-Telling";
		}
		else if (quest == 1009700)
		{
			if (info == "s")
				return " Nanuke's Ingredients";
			
			else if (info == "1")
				return " Muse is Cooking";
		}
		else if (quest == 1009900)
		{
			if (info == "s" || info == "5")
				return " Aqua Road Photo Album";
			
			else if (info == "1" || info == "2" || info == "3" || info == "4")
				return " Snow Crystal";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1007500, 1009700, 1009900};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "Welcome to the Aquarium Zoo~ I'm Muse, your guide to the zoo!";
		
		if (GetQuestData(1007500) == "e")
			dialogue = "I really miss my boyfriend at times... I wonder how he's doing these days...";
		
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
			case 0: SeaWitch(GetQuestData(1007500)); break;
			case 1: Cooking(GetQuestData(1009700)); break;
			case 2: OceanView(GetQuestData(1009900)); break;
		}
	}
}