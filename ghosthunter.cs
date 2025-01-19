using System;
using System.Collections.Generic;
using WvsBeta.Game;

// 2041026 Ghosthunter Bob
public class NpcScript : IScriptV2
{
	private bool CanRepeat(int quest)
	{
		string today = DateTime.UtcNow.ToString("yyyyMMdd");
		string lastDate = GetQuestData(quest);
		
		if (today == lastDate)
			return false;
		
		return true;
	}
	
	private void Binding()
	{
		string quest = GetQuestData(1006600);
		
		if (quest == "")
		{
			self.say("Ahhhhh I'm a busy person trying to fix up a wounded soul. It's impossible to keep track of all these ghosts, that are ever increasing, so they were asking for help of the Ghosthunter.");
			self.say("And...huh? Did I ever mention this before? I've met my share of people, so I don't know... have we met before...?");
			self.say("Anyway, Master Death Teddy seems to be confined and controlled by this unknown, yet creepy force of evil. I heard it used to be a very adorable teddy bear.");
			bool start = AskYesNo("I know, it's hard to imagine the cuter side of it just by looking at it now. How about eliminating the force that confines and controls it, and frees it up to its original state? What do you think of that? Do you want to do it?");
			
			if (!start)
			{
				self.say("Don't the Master Death Teddys look sad? I mean, they're being controlled and confined by this ugly force.");
				return;
			}
			
			SetQuestData(1006600, "s");
			self.say("If you bring the confining & controlling force of Master Death Teddys, I plan on studying it to see what really happened.");
			self.say("Please eliminate 20 Master Death Teddys and give me 20 of their confining forces. I'll be here looking out and see what's going on here.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4000148) < 20)
			{
				self.say("What? #t4000148# looks like this #i4000148:#. Are you sure you brought all 20 of them?");
				return;
			}
			
			self.say("Ahhh... Did you really gather up the #t4000148#s? Remember, I'll need 20 just to start the research on it. Let's see...");
			
			if (!Exchange(0, 4000148, -20))
			{
				self.say("What? #t4000148# looks like this #i4000148:#. Are you sure you brought all 20 of them?");
				return;
			}
			
			AddEXP(42000);
			SetQuestData(1006600, "e");
			QuestEndEffect();
			self.say("Perfect!! This should be a good indicator as to how this place has turned into what it has become, right? Phew, thanks!!");
		}
	}
	
	private void FreeSpirit()
	{
		string quest = GetQuestData(1006700);
		
		if (quest == "")
		{
			self.say("Who am I? I'm Bob, Ghosthunter Bob. Have you seen any monsters that roam around this area?");
			self.say("You might have noticed it, but... the Teddys are being controlled by the force of evil. Looking at the Teddys, knowing that their souls are being controlled by someone else...");
			bool start = AskYesNo("That's right. I really want to free up their souls from that force of evil, you know. So... can you help me out by killing those monsters, and gather up their souls for me?");
			
			if (!start)
			{
				self.say("What? I don't think it's a difficult task, though... please reconsider.");
				return;
			}
			
			SetQuestData(1006700, "s");
			self.say("The monster you're dealing with is Master Soul Teddy, and you'll notice that a huge evil ghost hovers around it, controlling its every move.");
			self.say("Go down below and fight the monster, and you may be able to gather up the freed-up souls of Master Soul Teddy. Bring those souls to me, and I'll do what I can for them to regain their freedom.");
			self.say("Oh, and I'd sure appreciate it if you can collect 100 of their souls. It's not gonna be too hard for you, is it? Thanks~~");
		}
		else if (quest == "s")
		{
			if (ItemCount(4000144) < 100)
			{
				self.say("Hmmm ... the numbers don't match. I don't think you brought the number I was asking for.");
				return;
			}
			
			self.say("What, you freed up their souls? All of them, like you promised?");
			
			if (!Exchange(0, 4000144, -100))
			{
				self.say("Hmmm ... the numbers don't match. I don't think you brought the number I was asking for.");
				return;
			}
			
			AddEXP(35000);
			SetQuestData(1006700, "e");
			QuestEndEffect();
			self.say("Yeah, those souls may be sent to a much nicer place now, and may they rest in peace. I'm sure they are thankful of your good deeds.");
		}
	}
	
	private void SoulCollector()
	{
		string quest = GetQuestData(1006800);
		
		if (quest == "" || quest == "e")
		{
			self.say("Who did this! Why is it that whenever I take my mind off things, someone steals my stuff??? Can you help me out here?");
			
			SetQuestData(1006800, "020");
			self.say("Arrggh, I really don't know what to do. It is true that I am constantly hungry, and it is doubly true that I enjoy eating, but... it is inexcusable for someone to keep stealing my stuff while I am eating!");
			self.say("It should be one of these guys... I am sure it's not done by the weaker ones.");
			self.say("The Soul Collector I use is chock full of evil spirits, you know!!! If someone keeps stealing that very important item of mine... I'm very sure someone is being told to take it away from me.");
			self.say("Seriously... the one I'm the most suspicious of is the one that keeps moving around me while I'm eating, the monster that moves around on a boat... the Spirit Viking...");
			self.say("Go beat up on the Spirit Vikings, about 20 of them, and take the Soul Collector away from them for me. It looks like this #i4031193#, so please remember that!");
		}
		else
		{
			if (ItemCount(4031193) < 1)
			{
				self.say("Is it too hard to find my Soul Collector? I'm very sure Spirit Viking is the culprit here! My instincts are never wrong!! Now please find it for me!!");
				return;
			}
			
			if (quest != "000")
			{
				self.say("It seems like you found my Soul Collector, but you haven't beat up on 20 Spirit Vikings like I asked you to. It just makes me mad thinking about Spirit Viking stealing my precious Soul Collector. Arrrrrghhhh...");
				return;
			}
			
			self.say("What? You found my Soul Collector?? Did the Spirit Viking really have it??");
			
			if (!Exchange(0, 4031193, -1))
			{
				self.say("Huh, are you sure you found the Soul Collector??");
				return;
			}
			
			AddEXP(63000);
			AddFame(1);
			SetQuestData(1006800, "e");
			SetQuestData(1006801, DateTime.UtcNow.ToString("yyyyMMdd"));
			QuestEndEffect();
			self.say("Thank you so much!! I'll make sure I won't lose it now, not after going through all this. I'm very concerned about the possibility of losing it again... man... what should I do THEN?");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1006600)
		{
			if (info != "e" && Level >= 84)
				return " The Binding";
		}
		else if (quest == 1006700)
		{
			if (info != "e" && Level >= 62)
				return " Free Spirit";
		}
		else if (quest == 1006800)
		{
			if (Level >= 85 && CanRepeat(1006801))
				return " The Soul Collector";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1006600, 1006700, 1006800};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "Hmmm ... gotta concentrate!";
		
		if (!CanRepeat(1006801))
			dialogue = "I feel a negative vibe around here...";
		
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
			case 0: Binding(); break;
			case 1: FreeSpirit(); break;
			case 2: SoulCollector(); break;
		}
	}
}