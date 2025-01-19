using System;
using System.Collections.Generic;
using WvsBeta.Game;

// 2012010 Alcaster
public class NpcScript : IScriptV2
{
	private void SellItem(int itemCode, int unitPrice, string desc)
	{
		int amount = AskInteger(1, 1, 100, $"Is #b#t{itemCode}##k really the item you need? It's {desc}. It might not be the easiest item to get, but I'll make a good deal with you. It will cost #b{unitPrice} mesos#k per item. How many would you like to buy?");
			
		int nPrice = unitPrice * amount;
		
		bool askBuy = AskYesNo($"Do you really want to buy #r{amount} #t{itemCode}#(s)#k? It will cost {unitPrice} mesos per #t{itemCode}#, which is #r{nPrice}#k mesos in total.");
		
		if (!askBuy)
		{
			self.say("I see. Well, I have many different items here. Take a look. I'm selling these items only to you. So, I'm not going to scam you in any way.");
			return;
		}
		
		if (!Exchange(-nPrice, itemCode, amount))
		{
			self.say($"Are you sure you have enough mesos? Please check to see if your use or etc. inventory is full or if you have at least #r{nPrice}#k mesos.");
			return;
		}
		
		self.say("Thank you. If some other day you need items again, drop by here. I may have gotten older over time, but I can still make magical items easily.");
	}
	
	private void AncientBook(string quest)
	{
		if (quest == "")
		{
			self.say("Allow me to introduce myself. I'm Alcaster the Sorcerer, studying the intricate details of magic and wizardry for over 300 years here. Say, I haven't seen someone with a piercing, affirming look in the eyes like you have in a while. I feel safe asking someone like you for help. What do you think? I am sure you may be busy with your other endeavors, but can you make some time and listen to my story?");
			self.say("Recently I found something very interesting from an old book that I was looking at while studying forbidden magic. The book states that somewhere around Ossyria, an incredible book by the name of #b#t4031056##k is hidden away. It was used ages ago at a war but its whereabouts have been questionable at best since. At least the very existence of the book is recorded for us to wonder...");
			bool start = AskYesNo("I'd like to have that book with me and study it. I'm sure once it's discovered the book will be full of important, previously-unknown knowledge on spells. Too bad I'm very old and in need of more research here so I won't be able to find it myself. I'm sorry, but can you find #b#t4031056##k for me? I know it won't be easy, but I can at least help you out a little bit.");
			
			if (!start)
			{
				self.say("Really, it could have been too much for you to handle. If that book ever ends up with an evil magician, however, it will be the end of the world as we know it ... anyway if you ever feel a change of heart, please come...");
				return;
			}
			
			SetQuestData(1001500, "s");
			self.say("Thank you! But it will be impossible for you to locate the book without any information on its whereabouts. According to this book, a descendant of the author of #b#t4031056##k resides in Orbis. That person may have a clue or two on \r\n#b#t4031056##k's whereabouts. I'll be waiting for you to come back with good news. Good luck.");
		}
		else if (quest == "s" || quest == "hs" || quest == "he")
		{
			self.say("You haven't found #b#t4031056##k yet. Please head over to Orbis where a descendant of the author of #b#t4031056##k lives. That person may know the whereabouts of the book. I'm counting on you.");
		}
		else if (quest == "ks" || quest == "ke")
		{
			self.say("So this is the #b#t4031053##k that you found at the tomb. It doesn't look like much, but I can feel the force emanate. You didn't find anything else but the ring? Okay... you should look for #bScadur the Hunter#k, who lives around here. He's been hunting exclusively at that valley the last couple of years.");
		}
		else if (quest == "fe")
		{
			self.say("Ohhh, this is it. The piece of a map that shows where #b#t4031056##k is at ...! But they are in pieces, after all, which is no good...Wait, #b#p2030002##k of Alpha platoon must have found #b#t4031055##k while investigating something around the Orbis Tower. Can you get the item for me, please? Thank you!");
			
			if (!Exchange(0, 4031054, -4))
			{
				self.say("Hold on, did you lose any pieces of the map?");
				return;
			}
			
			AddEXP(5430);
			SetQuestData(1001500, "ms");
		}
		else if (quest == "ms" || quest == "mw")
		{
			self.say("I'm studying these four pieces of #b#t4031054##k, but these don't mean a thing unless they are put together! #b#p2030002##k of Alpha platoon must have found #b#t4031055##k while investigating something around the Orbis Tower. Can you get the item for me, please? Thank you!");
		}
		else if (quest == "mg")
		{
			if (ItemCount(4031055) < 1)
			{
				self.say("I'm studying all #b4 of the #t4031054##k that you got me. It doesn't matter if they aren't put together into a single piece! #b#p2030002##k of Alpha platoon must have found #b#t4031055##k while investigating something around the Orbis Tower. Can you get the item for me, please? Thank you!");
				return;
			}
			
			self.say("You found it ... you got a hold of #b#t4031055##k!! All right, now. I'll have to cast a special spell on it so please be quiet for a second. If I can't concentrate, there's a chance that these gathered items may disappear for good. Here we go...Haaaap!");
			
			if (!Exchange(0, 4031055, -1))
			{
				self.say("Hmm... are you sure you have brought the #b#t4031055##k?");
				return;
			}
			
			AddEXP(7850);
			SetQuestData(1001500, "me");
			self.say("Phew, the spell worked. Now that the map is in one piece, we need to look through this. Let's see ... it's written in ancient language, so I'm having a hard time understanding this...Hmmm...I see...that's it! I got it! #t4031056# is hidden at the Orbis Tower! It's hidden in one of the statues there. I'm surprised it's there...");
			self.say("To open this statue, it looks like we need #b#t4031053##k from the battle...the ring works as the key here. Please head over to Orbis Tower, and come back with #b#t4031056##k in your hand! Meanwhile I'll be here figuring out how to seal #t4031056# up for good.");
		}
		else if (quest == "me")
		{
			if (ItemCount(4031053) >= 1)
			{
				self.say("You haven't gotten #b#t4031056##k, yet. According to the map, #b#t4031056##k is hidden at a statue at the Orbis Tower, and to open it, you'll need #b#t4031053##k. Well, then, please head over to Orbis Tower now.");
				return;
			}
			
			self.say("Oh... I take it you lost the #b#t4031053##k?");
			
			if (!Exchange(0, 4031053, 1))
			{
				self.say("Hmm... please make some space in your etc. inventory.");
				return;
			}
			
			self.say("Please be more careful with it this time.");
		}
		else if (quest == "fb")
		{
			if (ItemCount(4031056) < 1)
			{
				self.say("You haven't gotten #b#t4031056##k, yet. According to the map, #b#t4031056##k is hidden at a statue at the Orbis Tower, and to open it, you'll need #b#t4031053##k. Well, then, please head over to Orbis Tower now.");
				return;
			}
			
			self.say("You have FINALLY found #b#t4031056##k! This is amazing! Alright, I'm going to try my hardest to seal up the book. Great work you've done, and I really appreciate your effort. Thank you so much...and this is only a small sign of my gratitude. Please take it.");
			
			Random rnd = new Random();
			int[] capes = {1102011, 1102012, 1102013, 1102014};
			
			int itemID = capes[rnd.Next(capes.Length)];
			
			if (!Exchange(0, 4031056, -1, itemID, 1))
			{
				self.say("Hmm... are you sure you have brought #b#t4031056##k? If so, please leave an empty slot in your equip. inventory.");
				return;
			}
			
			AddEXP(16170);
			SetQuestData(1001500, "end");
			QuestEndEffect();
			self.say("I'll be really busy for a while now. This book is packed with so much power that it'll take me a long time to even find a way to seal it up. Anyway allow me to do the rest of the work. If you ever come back in this town, please come back and visit me. Again, thank you so much for your work. Best wishes...");
		}
	}
	
	private void DarkCrystal(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("Hey, aren't you the one that helped me out the other day? Thank you for coming back. Is the #b#t4031056##k safely sealed up? Hmmm ... to be honest with you, that's giving me plenty of headache these days. If you aren't busy or anything ... will it be okay for you to help me out here, one more time ...?");
			
			if (!start)
			{
				self.say("Oh ... really? Well I am fully aware of all the troubles you went through to help me out last time. What can I do? Age has caught up with me, and I can't even move around freely anymore. Please reconsider, and if you have changed your mind, then come talk to me.");
				return;
			}
			
			SetQuestData(1001600, "s");
			self.say("Thank you so much. After studying and researching for endless hours, I have finally found a clue that can help me seal #b#t4031056##k up for good. The problem is, this book is so powerful, I can't do it on my own. I know it's forbidden to do what I'm about to do, but...to seal it up, I need an item that possesses awesome magical power.");
			self.say("It's a mysterious crystal called #b#t4005004##k. It's been forgotten for years, but lately I have heard that the ore of the crystal can be obtained through monsters with dark powers in them. That can only mean one thing: the evil thoughts within those monsters are expanding by day. It's definitely not a good thing...");
			self.say("Anyway I really need that crystal. Please get me #b1 #t4005004##k and #b1 #t4021009##k, and I will reward you the way you should be rewarded. Oh, and ... #b#t4005004##k can be refined by #b#p2032001##k at Orbis Park. Thanks!");
		}
		else if (quest == "s")
		{
			if (ItemCount(4021009) < 1 || ItemCount(4005004) < 1)
			{
				self.say("It doesn't look like you have gotten #b1 #t4005004##k and #b1 #t4021009##k yet. I need those items to seal #b#t4031056##k up. The ores of #b#t4005004##k can be obtained through monsters with dark powers in them, and can be refined through #b#p2032001##k. Keep up the good work!");
				return;
			}
			
			self.say("You did gather up all of those items ... not bad at all. You may be much more powerful than I originally thought. Anyway thank you very much for your hard work. And for that, I'll get you a much nicer cape than the one I got you last time. Before all that, though, check and see if you equip. inventory is full or not.");
			
			var rnd = new Random();
			int[] capes = {1102015, 1102016, 1102017, 1102018};
			
			int itemID = capes[rnd.Next(capes.Length)];
			
			if (!Exchange(0, 4005004, -1, 4021009, -1, itemID, 1))
			{
				self.say("Hmm... are you sure you have gotten #b1 #t4005004##k and #b1 #t4021009##k? If so, please make sure you have space in your equip. inventory.");
				return;
			}
			
			AddEXP(18410);
			SetQuestData(1001600, "end");
			QuestEndEffect();
			self.say("Okay, with this I can seal #b#t4031056##k up right this minute, all thanks to you. I won't ever forget your good deed, and if you ever have some free time in your hand, please come back and visit. I feel like I can trust you to handle anything that may be difficult for others. Take care ...");
		}
	}
	
	private void OceanView(string quest)
	{
		if (quest == "1")
		{
			self.say("What's going on? Are you here to see me? I'm sorry, but I'm currently in the middle of something, so please talk to me later, okay? Thanks.");
			
			AddEXP(2000);
			SetQuestData(1009900, "2");
		}
		else if (quest == "2")
		{
			AskMenu("Sorry to make you wait. It seems like you've come a long way to see me. How can I help you?#b",
				(0, " Can I get #t4031312# from you?")
			);
			bool start = AskYesNo("#t4031312# ... yes, I can make it, but it'll require a whole lot of #b#t4031311#s#k to make a #t4031312#. Can you get them for me?");
			
			if (!start)
			{
				self.say("Please know that it's not only difficult to obtain #t4031311#, but you'll also need to bring in a large quantity of it, so think carefully before making the decision.");
				return;
			}
			
			SetQuestData(1009900, "3");
			self.say("I can see it in your eyes that you clearly want it. To make\r\n#t4031312#, I'll need #b100 #t4031311#s#k, and you can get it from #b#o5300000##k at the Orbis Tower. Once you collect all the snow crystals, then bring them all to me.");
		}
		else if (quest == "3")
		{
			if (ItemCount(4031311) < 100)
			{
				self.say("To make #t4031312#, I'll need #b100 #t4031311#s#k. Please hurry.");
				return;
			}
			
			self.say("Amazing, you brought all the #t4031311#s! Please wait as I turn those into #t4031312#.");
			
			if (!Exchange(0, 4031311, -100, 4031312, 1))
			{
				self.say("Please make sure there's a free slot in your etc. inventory first.");
				return;
			}
			
			AddEXP(6000);
			SetQuestData(1009900, "4");
			self.say("Alright, it's completed. I don't know exactly where you plan on using it, but I really hope you use it where it's needed. It surely does not melt, but please be careful with it, for it may break.");
		}
		else if (quest == "4")
		{
			if (ItemCount(4031312) >= 1)
			{
				self.say("Where did you use #t4031312#? Please think carefully and remember if anyone asked you for it...");
				return;
			}
			
			self.say("I found the #t4031312# you dropped earlier, please be more careful with it this time.");
			
			if (!Exchange(0, 4031312, 1))
			{
				self.say("Please make sure there's a free slot in your etc. inventory first.");
			}
		}
	}
	
	private void StartShop()
	{
		int selection = AskMenu("Thanks to you, #b#t4031056##k is in good hands. Of course I ended up using half of the power I accumulated over 800 years... but now I can die in peace. Oh, by the way... would you happen to be searching for rare items? As proof of my gratitude for your effort, I will sell some items I have ONLY for you. Choose what you want!#b",
			(0, " #t2050003#(price: 300 mesos)"),
			(1, " #t2050004#(price: 400 mesos)"),
			(2, " #t4006000#(price: 5000 mesos)"),
			(3, " #t4006001#(price: 5000 mesos)")
		);
			
		switch(selection)
		{
			case 0: SellItem(2050003, 300, "an item that heals the state of being sealed or cursed"); break;
			case 1: SellItem(2050004, 400, "an item that cures everything"); break;
			case 2: SellItem(4006000, 5000, "an item of magic power used for high level skills"); break;
			case 3: SellItem(4006001, 5000, "an item of summoning power used for high level skills"); break;
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1001500)
		{
			if ((Level >= 55 && info == "") || info == "s" || info == "hs" || info == "he")
				return " The Descendent of the Author of the Book of Ancient";
			
			else if (info == "ks")
				return " An Old Ring";
			
			else if (info == "ke")
				return " The Secrets Behind the Ring?";
			
			else if (info == "fe")
				return " All the Map Pieces in One Place";
			
			else if (info == "ms" || info == "mw")
				return " Restoring the Map";
			
			else if (info == "mg")
				return " The Map is in One Piece";
			
			else if (info == "me")
				return " The Secrets Behind the Statue";
			
			else if (info == "fb")
				return " The Book of Ancient is Back!";
		}
		else if (quest == 1001600)
		{
			string oldBook = GetQuestData(1001500);
			
			if (Level >= 60 && oldBook == "end" && info != "e")
				return " Alcaster and the Dark Crystal";
		}
		else if (quest == 1009900)
		{
			if (info == "1" || info == "2" || info == "3" || info == "4")
				return " Snow Crystal";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1001500, 1001600, 1009900};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "I'm Alcaster the sorcerer, and I've been working on various spells and magic here for over 300 years.";
		
		if (GetQuestData(1001500) == "end")
			dialogue = "Hey, how have you been? Thanks to you, I can now live out the remaining days of my life in peace. All I want to do now is just study things in life.";
		
		if (GetQuestData(1001600) == "end")
			options.Add((3, " I'd like to purchase a special item"));
		
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
			case 0: AncientBook(GetQuestData(1001500)); break;
			case 1: DarkCrystal(GetQuestData(1001600)); break;
			case 2: OceanView(GetQuestData(1009900)); break;
			case 3: StartShop(); break;
		}
	}
}