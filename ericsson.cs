using System;
using System.Collections.Generic;
using WvsBeta.Game;

// 2012018 Ericsson
public class NpcScript : IScriptV2
{
	private void Alfonse(string quest)
	{
		if (quest == "s")
		{
			bool start = AskYesNo("Did #b#p2012020##k send you here? Alfonse loves Nependeath Juice to the point of obsession ... and that's why he keeps on badgering me about making the sap of Nependeath for him. I'm sure he sent you here. Right?");
			
			if (!start)
			{
				self.say("You don't need the sap of Nependeath? Well, that's great news for me! If you don't need me for anything else, then please leave. I need to spend some quality time with Nero.");
				return;
			}
			
			AddEXP(100);
			SetQuestData(1005900, "1");
			self.say("Making the sap of Nependeath takes a lot of time and work. As you can see, I'm having some quality time with my cat Nero, so please don't bother me right now.");
		}
		else if (quest == "1")
		{
			if (ItemCount(4031199) < 1)
			{
				self.say("I really do not have any time to make the sap of Nependeath. It's just way too much work, and it takes up too much time. I need to hang out with my cat.");
				return;
			}
			
			bool start2 = AskYesNo("Oh wow, this wristband is gorgeous~ No doubt this should look great on my cat Nero. Is this really for Nero??");
			
			if (!start2)
			{
				self.say("If that's not for my lovely Nero, then why are you even showing it to me? Are you trying to make me mad? Get out of my sight!");
				return;
			}
			
			if (!Exchange(0, 4031199, -1))
			{
				self.say("Where did the wristband go??");
				return;
			}
			
			AddEXP(500);
			AddFame(1);
			SetQuestData(1005900, "2");
			SetQuestData(1005901, "e");
			QuestEndEffect();
			self.say("Thank you so much! I can't believe you got this for my cat ... alright! You said you needed #b#t4031200##k, right? I'll make it for you! Just remember, in order to make #t4031200#, you'll need to hunt the ever-so-dangerous Nependeath.");
			self.say("You look strong enough, so that shouldn't be too much of a problem. To make a sap, I'll need #b200 #t4000058#s and 100 #t4000062#s#k. You can get them, right?");
		}
		else if (quest == "2")
		{
			if (ItemCount(4000062) < 100 || ItemCount(4000058) < 200)
			{
				self.say("I don't think you have all the ingredients yet. Hurry up and get them!");
				return;
			}
			
			self.say("You brought all the ingredients I asked you to get! Wait here, as I make #t4031200# for you.");
			
			if (!Exchange(0, 4000058, -200, 4000062, -100, 4031200, 1))
			{
				self.say("Please make some room in your etc. inventory first.");
				return;
			}
			
			AddEXP(7000);
			SetQuestData(1005900, "3");
			self.say("Here, take it! Take this to Elma the Housekeeper; she is the best at making the #b#t4031202##k.");
		}
		else if (quest == "3" || quest == "4")
		{
			if (ItemCount(4031200) >= 1)
			{
				self.say("Take this to Elma the Housekeeper; she is the best at making the #b#t4031202##k.");
				return;
			}
			
			self.say("Here, take it! Take this to Elma the Housekeeper; she is the best at making the #b#t4031202##k.");
			
			if (!Exchange(0, 4031200, 1))
			{
				self.say("Please make some room in your etc. inventory first.");
			}
		}
	}
	
	private void Nero1(string quest)
	{
		string nero1 = GetQuestData(1006200);
		string nero2 = GetQuestData(1006201);
		
		if (quest == "")
		{
			self.say("Hey, you, have you seen Nero's necklace? The one that Nero wears with a little bell on it. I made that necklace for his 1st birthday, and it's been missing since yesterday afternoon.");
			bool start = AskYesNo("Where did he lose it? I really want to make a new one for Nero, but I'm so swamped with work that I have no time to purchase the materials for it. Say, can you help me out here?");
			
			if (!start)
			{
				self.say("Are you really that busy? Please help me out, for Nero's sake. Fine, then, you must be really busy right now. I'll see you around.");
				return;
			}
			
			SetQuestData(1006200, "s");
			self.say("The materials needed for Nero's necklace is not available here. You can only buy them at the shops in #b#m211000000##k. I don't remember the exact store for it...but just go there and get me #b1 #t4031191##k and #b1 #t4031192##k. With them, I can make a fantastic new necklace for Nero. It'll cost you #r1 meso#k per item.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031191) < 1 || ItemCount(4031192) < 1)
			{
				self.say("Nero seems to be very depressed lately, ever since he lost the necklace. You didn't get the materials needed for the necklace? Please don't forget to bring #b1 #t4031191##k and 1 #b#t4031192##k.");
				return;
			}
			
			self.say("This is it! This is it! With this, I can make a new necklace for my precious Nero! Thank you so much!");
			
			if (!Exchange(0, 4031191, -1, 4031192, -1))
			{
				self.say("Are you sure you brought the materials I asked for? Please check and talk to me again.");
				return;
			}
			
			AddEXP(4000);
			SetQuestData(1006200, "e");
			QuestEndEffect();
		}
	}
	
	private void Nero2(string quest)
	{
		if (quest == "")
		{
			self.say("It's been a while. How has your journey been since then? I have been feeling less than stellar these days because of the mean monsters wandering right outside Orbis. My Nero has been living in fear lately because he's been attacked by those monsters quite often these days. Darn those monsters!");
			bool start2 = AskYesNo("I can't just leave it like this, or Nero will be wounded from head to toe one of these days. Can you please help me out? I'll reward you well for your work.");
			
			if (!start2)
			{
				self.say("Can you do it for Nero's sake? Look at him, he's wounded. Don't you think Nero needs help?");
				return;
			}
			
			SetQuestData(1006201, "050050050");
			self.say("Please take out the number of monsters that are around Orbis, so Nero can wander around without having to worry about getting attacked. It looks like there's a whole lot of #b#o3210200#, #o3210201#, and #o3210202##k around lately. They are probably the ones attacking Nero, too. Please take out #b50#k of those, #beach#k. Can you also bring #b50 #t4000073#s#k as evidence?");
		}
		else
		{
			if (quest != "000000000" || ItemCount(4000073) < 50)
			{
				self.say("That's not enough. I still see too many monsters around for Nero's safety. Please take out #b50 #o3210200#s, 50 \r\n#o3210201#s, and 50 #o3210202#s#k, and bring #b50 #t4000073#s#k as evidence.");
				return;
			}
			
			self.say("Hey, you're back! Thanks to you, it seems like the number of monsters have decreased dramatically these days. Nero is healing faster than I thought, all thanks to you. He should be out roaming around in no time. I'm so glad everything turned out alright.");
			
			int rnum = Random(1, 11);
			int itemID = 0;
			
			if (rnum < 4) itemID = 2048002;
			else itemID = 2048001;
			
			if (!Exchange(0, 4000073, -50, itemID, 1))
			{
				self.say("Please leave some room in your use inventory first.");
				return;
			}
			
			AddEXP(10000);
			SetQuestData(1006201, "e");
			QuestEndEffect();
			self.say($"Do you like the #b#t{itemID}##k that I gave you? It's perfect for the ones that raise pets. If you also happen to have an adorable pet like Nero, try using that scroll on it.");
		}
	}
	
	// Christmas event 2021
	private void DeliverPresent(string quest)
	{
		var rnd = new Random();
		
		if (quest == "s")
		{
			bool start = AskYesNo("Do you want something from me? Does this have something to do with Maple Claws?");
			
			if (!start)
			{
				self.say("If you don't have anything to tell me then please go away!");
				return;
			}
			
			SetQuestData(8020028, "1");
			self.say("Ah... Ok... Hi! Nice to meet you! You must have come from Maple Claws, which means that... You're here with my present!");
		}
		else if (quest == "1")
		{
			if (ItemCount(4031486) < 1)
			{
				self.say("You are a strange person, coming here with no present!");
				return;
			}
			
			if (rnd.Next(0, 2) == 0)
			{
				self.say("... Now I'm not in a very good mood. Please excuse me, I need some more alone time. Maybe if you come to me later, I'll be happy to talk with you.");
				return;
			}
			
			if (!Exchange(0, 4031486, -1))
			{
				self.say("Sorry, but I'm having trouble taking the present, please check your inventory and try again.");
				return;
			}
			
			chr.AddCash(500);
			Message("You have gained 500 Cash.");
			SetQuestData(8020028, "2");
			SetQuestData(8020025, "3e");
			QuestEndEffect();
			self.say("Thank you so much for your present! Please say hello to Maple Claws for me");
		}
		else if (quest == "2" || quest == "end")
		{
			self.say("I've already received your present. Thank you so much!");
		}
	}
	
	private string Check(int quest)
	{
		var today = DateTime.UtcNow;
		string info = GetQuestData(quest);
		
		if (quest == 1005900)	// Alfonse and the Nependeath Juice
		{
			if (info == "s")
				return " The Nependeath Juice";
			
			else if (info == "1")
				return " Ericsson Loves Cats";
			
			else if (info == "2")
				return " A Present for Nero";
			
			else if (info == "3")
				return " Ericsson's Reward";
			
			else if (info == "4")
				return " Elma's Nependeath Juice";
		}
		else if (quest == 1006200)	// Nero's Necklace
		{
			if ((info == "" && Level >= 20) || info == "s")
				return " Nero's Necklace";
		}
		else if (quest == 1006201)	// Protect Nero!
		{
			string nero = GetQuestData(1006200);
			
			if (info != "e" && nero == "e" && Level >= 35)
				return " Protect Nero!";
		}
		else if (quest == 8020028)
		{
			var startDate = DateTime.Parse("2022-12-11");
			var endDate = DateTime.Parse("2022-12-26");
			
			if (info != "" && info != "end" && today >= startDate && today < endDate)
				return " Maple Claws - Visit Ericsson";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1005900, 1006200, 1006201, 8020028};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "Look at my kitty! Isn't she cute?";
		
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
			case 0: Alfonse(GetQuestData(1005900)); break;
			case 1: Nero1(GetQuestData(1006200)); break;
			case 2: Nero2(GetQuestData(1006201)); break;
			case 3: DeliverPresent(GetQuestData(8020028)); break;
		}
	}
}