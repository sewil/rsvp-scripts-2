using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WvsBeta.Game;
using WvsBeta.Common;

using WvsBeta.Game.GameObjects;
using WvsBeta.SharedDataProvider.Templates;

// 9200000 Cody
public class NpcScript : IScriptV2
{
	private void GoEvent()
	{
		string map = GetNpcVar(180000000, 9900000, "map", "-1");
		
		if (map == "-1")
		{
			self.say("Either the event hasn't started yet, you already have #t4031019#, or you've participated in an event in the last 24 hours. Please try again later!");
			return;
		}
		
		if (!Exchange(0, 4000038, 1))
		{
			self.say("Do you have a free slot in your etc. inventory? Check again!");
			return;
		}
		
		SetQuestData(9000000, "cody");
		//SetQuestData(9000001, DateTime.UtcNow.ToString("yyyyMMdd"));
		ChangeMap(Int32.Parse(map));
	}
	
	public void GenerateItem()
	{
		var categories = Enum.GetValues(typeof(Constants.Items.Types.ItemTypes))
			.OfType<Constants.Items.Types.ItemTypes>()
			.Select(x => ((int)x, x.ToString()))
			.ToArray();

		while (true)
		{
			var onlyForJob = AskYesNo("Limit by job?");

			// Category selector
			while (true)
			{
				var cat = AskMenu(
					"Category?",
					new[] { (9999000, "Go back"), (9999001, "stop") }.Union(categories).ToArray());
				
				if (cat == 9999000) break;
				if (cat == 9999001) return;

				var startId = cat * 10000;
				var endId = (cat + 1) * 10000;

				var inv = Constants.getInventory(startId);

				if (inv == 5) {
					OK("Can't let you do that. Please buy pets in cashshop");
					continue;
				}

				IEnumerable<int> itemIDs;

				if (inv == 1)
					itemIDs = DataProvider.Equips.Where(x => x.Key >= startId && x.Key < endId && (!onlyForJob || Constants.isRequiredJob(Constants.getJobTrack(Job), x.Value.RequiredJob))).Select(x => x.Key);
				else if (inv == 5)
					itemIDs = DataProvider.Pets.Where(x => x.Key >= startId && x.Key < endId).Select(x => x.Key);
				else
					itemIDs = DataProvider.Items.Where(x => x.Key >= startId && x.Key < endId).Select(x => x.Key);

				var entries = itemIDs.Select(x => (x, itemIconAndName(x))).ToArray();

				var itemID = AskMenu("Item?",
					new[] { (9999000, "Go back"), (9999001, "stop") }.Union(entries).ToArray()
				);
				if (itemID == 9999000) break;
				if (itemID == 9999001) return;
				int amount = 1;
				ItemVariation iv = WvsBeta.Game.ItemVariation.None;
				if (inv != 1) {
					amount = AskInteger(1, 1, 100, "How many do you want to make?");
				}
				else {
					iv = (WvsBeta.Game.ItemVariation)AskMenu("What kind of equip do you want to generate?",
						(0, "Default stat, like shop"),
						(2, "Normal like drop stats"),
						(1, "Better stats (70% chance of good stat, 30% default stat)"),
						(3, "Great stats (90% chance of good stat, 10% default stat)"),
						(4, "Gachapon stats (50% chance of either boosted or reduced stats, bigger variation in stat)")
					);
				}
				SetItemVariation(iv);
				Exchange(0, itemID, amount);
			}
		}
	}

	public void Teleporter() {
		var maps = new int[]{
            // Maple Island
            60000,
            1010000,
            // Victoria
            100000000,
            102000000,
            101000000,
            105040300,
            104000000,
            110000000,
            103000000,
            // Ossyria
            200000000,
            211000000,
            // Ludus Lake area
            220000000,
            221000000,
            230000000,
		};
		
		var map = AskMenu("Which map?", maps.Select(elem => (elem, $" #m{elem}#")).ToArray());
		ChangeMap(map);
	}
	
	private void CodyPotion(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("You seem like you've drank a potion or two before, am I right? Haha! You ever wonder how potions are made?");
			
			if (!start)
			{
				self.say("Aw man, you're no fun.");
				return;
			}
			
			SetQuestData(8020037, "s");
			self.say("Recently I was walking through Henesys Hunting Ground and couldn't help but notice all the potions.");
			self.say("Red ones, blue ones, white ones. I really wonder what this stuff is made out of.");
			self.say("Since then, I've had a compulsion to make my own potion. A CODY POTION. I thought, if these things are just appearing out of thin air, how hard could it be?");
			self.say("Let's start by getting some jars, come back when you've found ten jars. They should drop from any monster. ");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031141) < 10)
			{
				self.say("Oh hey, did you find ten jars for me yet? Sorry, I'm pretty busy over here!");
				return;
			}
			
			self.say("Thanks so much!");
			
			if (!Exchange(0, 4031141, -10))
			{
				self.say("Hey, are you sure you have all ten??");
				return;
			}
			
			SetQuestData(8020037, "1");
			self.say("Hm, I've been thinking a lot about what the ingredients to a CODY potion would be. Lets start with my favorite food, Hot Dog Supreme from Sleepywood's food truck! Can you bring me back 10, one per bottle?");
		}
		else if (quest == "1")
		{
			if (ItemCount(2020006) < 10)
			{
				self.say("Oh, I don't smell ten hot dog supremes on ya!");
				return;
			}
			
			self.say("Sniff sniff... Hey, smells like you got all ten of those dogs for me!");
			
			if (!Exchange(0, 2020006, -10))
			{
				self.say("Hey, are you sure you have all ten??");
				return;
			}
			
			AddEXP(100);
			SetQuestData(8020037, "2");
			self.say("OK! So I put a hotdog in each jar. I think the Cody potion is almost done!");
			self.say("All thats left is some kind of liquid, to help it go down.");
			self.say("Can you get me about thirty lemons? We'll use those to make a juice for the potion!");
		}
		else if (quest == "2")
		{
			if (ItemCount(2010004) < 30)
			{
				self.say("Sniff sniff...sniff... Hmm, I don't smell thirty lemons on you...");
				return;
			}
			
			self.say("Sniiiiffff. Oh man! Those lemons smell sour! Hand 'em over!");
			
			if (!Exchange(0, 2010004, -30, 2010007, 1))
			{
				self.say("Hey, are you sure you have thirty lemons?? If so, please leave a slot open in your USE. inventory first.");
				return;
			}
			
			AddEXP(200);
			SetQuestData(8020037, "3");
			self.say("Great! Let me just... ");
			self.say("All finished! Lemonade and Hotdog, it's perfect! It's kind of like going to a baseball game!");
			self.say("Would you mind taking a sip and letting me know? I have a feeling this potion will give you 1,000 HP.");
		}
		else if (quest == "3")
		{
			if (ItemCount(2010007) >= 1)
			{
				self.say("Hey, did you try my potion yet?");
				return;
			}
			
			self.say("Hm, it poisoned you? I don't think so. That must've been a preexisting condition. Either way, thanks for your help.");
			self.say("Give me a minute to clean up!");
			SetQuestData(8020037, "4");
		}
		else if (quest == "4")
		{
			self.say("As much as the Cody Potion was my very own invention, I must admit I couldn't have done it without uh, you.");
			self.say("I guess I should give you something. You can have this.");
			
			if (!Exchange(0, 1002763, 1))
			{
				self.say("Please leave a slot open in your equip. inventory first.");
				return;
			}
			
			AddEXP(300);
			SetQuestData(8020037, "e");
			QuestEndEffect();
			self.say("Catch you next time!");
		}
	}
	
	private void CodyEarlyHalloween(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("Hey! I've seen you walking past a bunch of times. Would you mind helping me out?");
			
			if (!start)
			{
				self.say("Aw man, that's fine then.");
				return;
			}
			
			SetQuestData(8020010, "s");
			self.say("Great! I'm sure a tough adventurer like you has seen quite a few snails, huh?");
			self.say("I know it's only September, but I'm getting my, uh, Halloween costume ready a bit early this year.");
			self.say("I'm much too busy working at Wizet these days. Could you help me find fifteen green snail shells?");
		}
		else if (quest == "s")
		{
			if (ItemCount(4000019) < 15)
			{
				self.say("Hey! How's the hunt going? Come back when you find all the shells!");
				return;
			}
			
			SetQuestData(8020010, "1");
			self.say("...Huh? Fifteen? No no, I said FIFTY snail shells! Come back when you have those.");
		}
		else if (quest == "1")
		{
			if (ItemCount(4000019) < 50)
			{
				self.say("Hey buddy, remember I said get FIFTY snail shells this time. 50!!");
				return;
			}
			
			self.say("Nice! I knew you could gather up all those shells! Give me a sec while I...");
			
			if (!Exchange(0, 4000019, -50))
			{
				self.say("Hey, are you sure you have all fifty??");
				return;
			}
			
			AddEXP(100);
			SetQuestData(8020010, "2");
		}
		else if (quest == "2")
		{
			self.say("Dang it! These green shells are so weak, they crumbled when I tried to put together my costume!");
			self.say("Do you think you could go get me fift- No, ONE HUNDRED blue... No- make that RED snail shells?");
			SetQuestData(8020010, "3");
		}
		else if (quest == "3")
		{
			if (ItemCount(4000016) < 100)
			{
				self.say("Hey! Remember, you need to get 100 Red Snail Shells! Red!");
				return;
			}
			
			self.say("Woah! That was pretty fast, you must be some kind of snail genius. Give me a sec while I...");
			
			if (!Exchange(0, 4000016, -100))
			{
				self.say("Hey, are you sure you have 100 Red Snail Shells??");
				return;
			}
			
			AddEXP(200);
			SetQuestData(8020010, "4");
		}
		else if (quest == "4")
		{
			self.say("OK.. OK... It's looking like these shells will do the trick, but I need something in order to hold this all together.");
			self.say("Could you get me a Pig's Ribbon? Just one should do.");
			SetQuestData(8020010, "5");
		}
		else if (quest == "5")
		{
			if (ItemCount(4000002) < 1)
			{
				self.say("Hey! How's it hangin? Did you find a Pig's Ribbon for me yet?");
				return;
			}
			
			self.say("Nice, you found a Pig's Ribbon! Give me a sec while I...");
			
			if (!Exchange(0, 4000002, -1))
			{
				self.say("Hey, are you sure you have a Pig's Ribbon??");
				return;
			}
			
			AddEXP(300);
			SetQuestData(8020010, "6");
		}
		else if (quest == "6")
		{
			self.say("Well, it looks like it's about done, but I think it's missing something that will really bring it all together.");
			self.say("Do you know of Bob the Snail? I overheard some low level adventurers loaded out in NX cash talking about a special snail deep in the dungeon.");
			self.say("Maybe the shell of a snail like that will really push my costume to the next level!");
			self.say("Oh, and while you're down there- could you pick me up a Hot Dog Supreme from the food truck? Thanks!");
			SetQuestData(8020010, "7");
		}
		else if (quest == "7")
		{
			if (ItemCount(4031447) < 1 || ItemCount(2020006) < 1)
			{
				self.say("Hey! Did you find Bob the Snail's shell, and Hot Dog Supreme yet?");
				return;
			}
			
			self.say("Oh hey, you got my hotdog? Nice nice! *Munch munch*");
			
			if (!Exchange(0, 4031447, -1, 2020006, -1))
			{
				self.say("Hey, are you sure you have Bob the Snail's shell, and Hot Dog Supreme??");
				return;
			}
			
			AddEXP(400);
			SetQuestData(8020010, "8");
			self.say("So actually *gulp* I heard my co-worker Robin was going to the Halloween party dressed as a snail. I think I'll just go as a ghost like last year.");
			self.say("Do you think you could just get me some tablecloths from Jr. Wraith? Ten should do it. In exchange I'll give you my snail costume.");
		}
		else if (quest == "8")
		{
			if (ItemCount(4000035) < 10)
			{
				self.say("Hey! Did you find 10 tablecloth for me yet?");
				return;
			}
			
			self.say("Wow! Thanks so much! Give me a sec while I...");
			
			if (!Exchange(0, 4000035, -10))
			{
				self.say("Hey, are you sure you have 10 Tablecloths??");
				return;
			}
			
			AddEXP(500);
			SetQuestData(8020010, "9");
		}
		else if (quest == "9")
		{
			self.say("Great! I'm going to be a totally awesome ghost this year! But one thing's missing...");
			self.say("Here, you've earned it! My Snail Headband.");
			
			if (!Exchange(0, 1002762, 1))
			{
				self.say("Please leave a slot open in your equip. inventory first.");
				return;
			}
			
			SetQuestData(8020010, "e");
			QuestEndEffect();
			self.say("Thanks so much for your time!");
		}
	}
	
	private void Cody2ndAnniversary(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("Hey, what's going on? Can you believe it? MG2 is having its second birthday!!! It's all thanks to great Maplers like you! Well, anyway, we plan on having a big party among the MG2 staff, and I need your help, big time. Can you help me out?");
			
			if (!start)
			{
				self.say("Oh, I see... that's alright. You must be busy with your other quests. But if you ever have a spare time, then please help me out here!! I'll be here waiting for you...");
				return;
			}
			
			SetQuestData(8020053, "s");
			self.say("Thanks! Well, we have the cake (and pie), the food, and everything else needed for a grand party, but I forgot to buy something very important- birthday candles! I mean, what's a birthday party without the candles on the cake, you know? We'll need #b10 Birthday Candles#k for the party, so please get them for me as fast as you can. You should try hunting the #bCandle Monsters#k for them. I'll be here waiting for you. Good luck!");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031590) < 10)
			{
				self.say("I don't think you have the #b10 Birthday Candles#k that I asked you to get. The party is going to start soon, and I'll need those #bBirthday Candles#k fast! Please hurry!!");
				return;
			}
			
			self.say("Oh my goodness, you really did bring all #b10 of the Birthday Candles#k that I asked you to get! Nicely done!!");
			
			if (!Exchange(0, 4031590, -10, 1302065, 1))
			{
				self.say("Are you sure you brought all the candles? If so please make sure there is an empty space in your equip. inventory!!");
				return;
			}
			
			AddEXP(365);
			SetQuestData(8020053, "e");
			QuestEndEffect();
			self.say("Thanks a whole bunch for your help!! Phew, I could have gotten chewed out by my boss for this. Anyway, here's something for you. Hope you like it! Well, I'm off to tha par-tay, so I'll see you later! Happy Mapling!");
		}
	}
	
	private void ThanksgivingYellow(string quest)
	{
		if (quest == "s")
		{
			if (ItemCount(4031416) < 1)
			{
				self.say("Hmm, looks like your bag has some lint, but no #bYellow Turkey Eggs#k! Collect some #bYellow Turkey Eggs#k and I'll make it worth your while!");
				return;
			}
			
			self.say("Excellent work! That is a fine Turkey egg you've got...in return, let me dig around in the backpack here...I think I do have something here for you...");
			
			if (SlotCount(2) < 1 || SlotCount(4) < 1)
			{
				self.say("Hey, make sure you have at least one empty slot in your use and etc. inventories!");
				return;
			}
			
			var rewards = new List<(int, int, int)> {
				(4031425, 1, 1),
				(2000004, 1, 25),
				(2020029, 1, 150),
				(2000002, 1, 50),
				(2000001, 1, 50),
				(2020030, 1, 224)
			};
			
			if (ItemCount(4031425) >= 1) rewards.Remove((4031425, 1, 1));
			
			var item = rewards.RandomElementByWeight(tuple => tuple.Item3);
			
			if (item == default)
				return;
			
			int itemID = item.Item1;
			int itemNum = item.Item2;
			
			if (!Exchange(0, 4031416, -1, itemID, itemNum))
			{
				self.say("Are you sure you brought the #bYellow Turkey Egg#k? Please check again.");
				return;
			}
			
			SetQuestData(8020017, "e");
			QuestEndEffect();
			self.say("Take this and I hope it helps out in your travels! Thank you! Find me more eggs and I'll reward you!");
		}
		else
		{
			bool start = AskYesNo("Hello there! You look like you've been out on a few adventures! I'm in dire need of some high-quality Turkey Eggs for a Thanksgiving breakfast I'm cooking. Do you have any Yellow eggs for me?");
			
			if (!start)
			{
				self.say("Oh, ok.  Be sure to come back, because I won't wait forever to get my eggs!");
				return;
			}
			
			SetQuestData(8020017, "s");
			self.say("I'm in dire need of some high-quality Turkey Eggs for a Thanksgiving breakfast I'm cooking. Will you gather some\r\n#bYellow Turkey Eggs#k for me? Yellow Turkey Eggs can be obtained from tamed turkeys. Good luck!");
		}
	}
	
	private void ThanksgivingGreen(string quest)
	{
		if (quest == "s")
		{
			if (ItemCount(4031417) < 1)
			{
				self.say("Hmm, looks like your bag has some lint, but no #bGreen Turkey Eggs#k! Collect some #bGreen Turkey Eggs#k and I'll make it worth your while!");
				return;
			}
			
			self.say("Excellent work! That is a fine Turkey eggs you've got...in return, let me dig around in the backpack here...I think I do have something here for you...!");
			
			if (SlotCount(2) < 1 || SlotCount(4) < 1)
			{
				self.say("Hey, make sure you have at least one empty slot in your use and etc. inventories!");
				return;
			}
			
			var rewards = new List<(int, int, int)> {
				(4031425, 1, 1),
				(2000004, 1, 25),
				(2020029, 1, 150),
				(2000002, 1, 50),
				(2000001, 1, 50),
				(2020030, 1, 224)
			};
			
			if (ItemCount(4031425) >= 1) rewards.Remove((4031425, 1, 1));
			
			var item = rewards.RandomElementByWeight(tuple => tuple.Item3);
			
			if (item == default)
				return;
			
			int itemID = item.Item1;
			int itemNum = item.Item2;
			
			if (!Exchange(0, 4031417, -1, itemID, itemNum))
			{
				self.say("Are you sure you brought the #bGreen Turkey Egg#k? Please check again.");
				return;
			}
			
			SetQuestData(8020018, "e");
			QuestEndEffect();
			self.say("Take this and I hope it helps out in your travels! Thank you! Find me more eggs and I'll reward you!");
		}
		else
		{
			bool start = AskYesNo("Hello there! You look like you've been out on a few adventures! I'm in dire need of some high-quality Turkey Eggs for a Thanksgiving breakfast I'm cooking. Do you have any Green eggs for me?");
			
			if (!start)
			{
				self.say("Oh, ok.  Be sure to come back, because I won't wait forever to get my eggs!");
				return;
			}
			
			SetQuestData(8020018, "s");
			self.say("I'm in dire need of some high-quality Turkey Eggs for a Thanksgiving breakfast I'm cooking. Will you gather some\r\n#bGreen Turkey Eggs#k for me?");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 8020037)
		{
			if (info != "e" && Level >= 8)
				return " Cody's Potion";
		}
		else if (quest == 8020010)
		{
			if (info != "e" && Level >= 8 && eventActive("earlyhalloween2022"))
				return " Cody's Early Halloween";
		}
		else if (quest == 8020053)
		{
			if (info != "e" && eventActive("anniversary2022"))
				return " 2nd Anniversary : Cody's Quest";
		}
		else if (quest == 8020017)
		{
			if (((Level >= 15 && Level < 30) || info == "s") && eventActive("thanksgiving2022"))
				return " Thanksgiving : Turkey Yellow Egg hunt";
		}
		else if (quest == 8020018)
		{
			if (Level >= 30 && eventActive("thanksgiving2022"))
				return " Thanksgiving : Turkey Green Egg hunt";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		if (MapID == 100000110)
			options.Add((90003, " Join the event!\r\n"));
		options.Add((90000, " Generate item"));
		options.Add((90002, " Teleport to map"));
		
		if (chr.IsGM) {
			
			options.Add((90001, "Add me to FM (do only once!)"));
		}
		
		int[] quests = {8020037, 8020010, 8020053, 8020017, 8020018};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "What's going on? I'm Cody, the head programmer of MapleStory~";
		
		if (GetQuestData(8020037) == "e")
			dialogue = "Hey buddy! Thanks again for helping with my Cody Potion. I tried getting it in some of the potion shops around here, but they all declined! I can't imagine why.";
		
		if (GetQuestData(8020053) == "e" && DateTime.UtcNow < DateTime.Parse("2022-11-05"))
			dialogue = "Thanks to your help, the party went bananas! Boy it was fun. anyway, hope you liked the stuff that I gave you. I'll see you around~";
		
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
			case 0: CodyPotion(GetQuestData(8020037)); break;
			case 1: CodyEarlyHalloween(GetQuestData(8020010)); break;
			case 2: Cody2ndAnniversary(GetQuestData(8020053)); break;
			case 3: ThanksgivingYellow(GetQuestData(8020017)); break;
			case 4: ThanksgivingGreen(GetQuestData(8020018)); break;
			case 90000: GenerateItem(); break;
			case 90001:
				var map = MapProvider.Maps[100000110];
				var life = new Life
				{
					RespawnTime = -1,
					FacesLeft = false,
					X = 505,
					Y = -326,
					Cy = -326,
					Rx0 = 505 - 50,
					Rx1 = 505 + 50,
					Foothold = 6,
					ID = 9200000,
					Type = 'n'
				};
				var npc = new NpcLife(life, map);
				npc.SpawnID = 0xBAADF00;
				map.NPCs.Add(npc);
				npc.Spawn();
			break;
			case 90002: Teleporter(); break;
			case 90003: GoEvent(); break;
		}
	}
}