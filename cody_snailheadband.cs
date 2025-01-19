using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(8020010);
		
		if (DateTime.UtcNow > DateTime.Parse("2021-10-02"))
		{
			self.say("What's going on? I'm Cody, the head programmer of Maplestory!");
			return;
		}
		
		if (Level < 8)
		{
			self.say("I sure could use some help here, but you don't seem strong enough to help me. Come back when you're at least #blevel 8#k.");
			return;
		}
		
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
		else if (quest == "e")
		{
			self.say("Thanks again for helping with my Halloween costume! So, how's the headband?");
		}
	}
}