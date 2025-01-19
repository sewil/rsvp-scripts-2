using WvsBeta.Game;

// 2012012 Lisa
public class NpcScript : IScriptV2
{
	private void FurCoat()
	{
		string quest = GetQuestData(1006000);
		
		if (quest == "")
		{
			bool start = AskYesNo("Um, excuse me, traveler~ If you have any spare time, then please hear me out.");
			
			if (!start)
			{
				self.say("You must be a busy person. If you have any spare time, then please come talk to me.");
				return;
			}
			
			if (!Exchange(0, 4031204, 1))
			{
				self.say("Please allow me to give you this. You need to make some room in your etc. inventory first.");
				return;
			}
			
			SetQuestData(1006000, "s");
			self.say("I wanted to talk to you because I could tell you're mighty powerful. Have you heard of #bScadur the Hunter#k of #bEl Nath#k? Lately he has been itching to throw away his old fur coat and don a new one. It is difficult to gather up the finest materials for the fur coat, because the finer the quality, the stronger the monsters are, and the harder it is to obtain the fur.");
			self.say("That is why #b#p2020007##k wanted me to look around and recommend a strong person whom he could ask for help later on. Please take this letter of recommendation to\r\n#b#p2020007##k. You'll be of great help to him.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031204) >= 1)
			{
				self.say("I don't think you have met up with #b#p2020007##k of #bEl Nath#k yet. Please go see him immediately.");
				return;
			}
			
			self.say("You lost the letter of recommendation? Oh no ... here, I'll write it again. Please be careful with it.");
			
			if (!Exchange(0, 4031204, 1))
			{
				self.say("Please allow me to give you this. You need to make some room in your etc. inventory first.");
			}
		}
	}
	
	private void Moppie()
	{
		string quest = GetQuestData(1006100);
		
		if (quest == "s")
		{
			self.say("Is Moppie really hurt? I can sort of connect with him. I can feel some kind of a vibe from him, but ... there's no way I can tell exactly what he's trying to say. I can tell he's in pain, though ... poor thing ...");
			
			AddEXP(500);
			SetQuestData(1006100, "1");
			self.say("There is one way to translate Moppie's barkings into actual words ... if you really want to help him out ... then come see me again. I'll tell you how to do it.");
		}
		else if (quest == "1")
		{
			self.say("Are you really intent on understanding what Moppie is saying? There's actually a way to do it ... as long as you get a hold of an item only fairies carry around and use: the horn flute. With it, you may be able to talk to Moppie like never before.");
			bool start = AskYesNo("But the fairies won't give us their horn flute. Fairies generally hate humans, remember. Well ... I have blown the pipe before, and I think I can at least replicate it. Can you gather up the materials for me?");
			
			if (!start)
			{
				self.say("What are you afraid of? Or are you worried about me messing it up?");
				return;
			}
			
			SetQuestData(1006100, "2");
			self.say("I'll need #b100 solid horns, 20 stiff feathers#k, and #b10 leathers#k as materials for the horn flute.");
			self.say("It also reminds me of the past, so ... this is going to be interesting, to say the least. Please gather up the materials for me! Head over to the garden where the monsters reside.");
		}
		else if (quest == "2")
		{
			self.say("I am getting nervous and excited at the same time. Before I get started, however, let me check on all the materials and see if you brought them all or not.");
			
			if (ItemCount(4000073) < 100 || ItemCount(4003004) < 20 || ItemCount(4000021) < 10)
			{
				self.say("Hmm... I think you're lacking the materials. Please bring back #b100 #t4000073#s#k, #b20 #t4003004#s#k and #b10 #t4000021#s#k for the horn flute");
				return;
			}
			
			self.say("Wow, these materials are perfect! I got nervous and excited at the same time the whole time I was making this.");
			self.say("This is a gorgeous horn flute. I made it myself, but even I have to admit, it's a thing of a beauty. With this, you'll be able to understand what Moppie wants to say. Please go and help poor Moppie out immediately!");
			
			if (!Exchange(0, 4000073, -100, 4003004, -20, 4000021, -10, 4031190, 1, 1032011, 1, 2050004, 10))
			{
				self.say("Please make sure there's a free space in your equip., use and etc. inventories first.");
				return;
			}
			
			AddEXP(6000);
			SetQuestData(1006100, "3");
			
			bool ask1 = AskYesNo("Let's see what happens when a human uses the fairy's horn flute, I don't know how it'll react to humans using it, so there's no guarantee it'll work, but ... do you still want to try it?");
			
			if (!ask1)
			{
				self.say("You took so much time and effort to acquire the horn flute, and now you don't want to help Moppie out? Are you really THAT afraid of the fairies?");
				return;
			}
			
			self.say("Alright, then go up to Moppie and play the horn flute in front of him. I don't know if the fairies will like the idea of a human playing it, though...");
		}
		else if (quest == "3")
		{
			if (ItemCount(4031190) >= 1)
			{
				self.say("You still haven't used it? Don't be scared. Try it.");
				return;
			}
			
			self.say("With this, you'll be able to understand what Moppie wants to say. Please go and help poor Moppie out immediately!");
			
			if (!Exchange(0, 4031190, 1))
			{
				self.say("Please make sure there's a free space in your etc. inventory first.");
			}
		}
		else if (quest == "5")
		{
			self.say("What? Moppie's hurt? Moppie's a strong dog, and he usually doesn't admit to any kind of pain. It must be very seroius if he's complaining about it.");
			bool start2 = AskYesNo("All the cuts and wounds that have been caused by the monsters near Orbis can only be cured through my special medicine. It's something I can make with my eyes closed. What do you think? Do you want to make one?");
			
			if (!start2)
			{
				self.say("Are you scared by the fact that your life may be in danger?");
				return;
			}
			
			AddEXP(500);
			SetQuestData(1006100, "6");
			self.say("I'll need #b40 orange potions, 20 blue potions, 1 antidote#k, and #b1 Fierry's Tentacle#k. Please be aware that Fierry's Tentacle is a really tough item to get, since Fierry's are the kind of monsters with special abilities, ready to pounce on unsuspecting travelers.");
			self.say("You better be strong-willed if you intend on collecting those ingredients, because if not, you may put yourself in really serious, grave danger. Can you still do it?");
		}
		else if (quest == "6")
		{
			self.say("Really? You gathered up all the ingredients needed for the medicine? Alright, let's get this started! Oh, before we start, can I check and see if you have brought all the right ingredients for the medicine?");
			
			if (ItemCount(2000001) < 40 || ItemCount(2000003) < 20 || ItemCount(2050000) < 1 || ItemCount(4000068) < 1)
			{
				self.say("Wait, why is this not responding? ... I don't think you brought all the ingredients needed for this.");
				return;
			}
			
			self.say("...mix the potions well, and ... the mixing ratio is so important here ... okay, now I need to boil it up, and ...throw in the antidote ... ooh, now we're getting there ...that's one indescribable color we're seeing ... we're almost there ...");
			self.say("Lastly, add Fierry's Tentacles, and...");
			
			if (!Exchange(0, 2000001, -40, 2000003, -20, 2050000, -1, 4000068, -1, 4031205, 1, 2048001, 1))
			{
				self.say("Please leave a space available in your use and etc. inventories first.");
				return;
			}
			
			AddEXP(5000);
			SetQuestData(1006100, "7");
			self.say("A loud thud occured, followed by a scintillating scent of sweetness covering the area.");
			self.say("Please take my special medicine to Moppie. Moppie's wounds will be gone in an instant.");
			self.say("Apply the medicine evenly directly to the wound, and it'll be gone in an instant. There's one thing you should remember. PLEASE DON'T EAT IT!!!");
			self.say("Thank you so much for taking care of Moppie. I really hope the wounds will disappear with the medicine. I'm worried, legitimately worried, about Moppie.");
		}
		else if (quest == "7")
		{
			if (ItemCount(4031205) >= 1)
			{
				self.say("Haven't found Moppie? He should be around here ...");
				return;
			}
			
			self.say("Please take my special medicine to Moppie. Moppie's wounds will be gone in an instant.");
			
			if (!Exchange(0, 4031205, 1))
			{
				self.say("Please leave a space available in your etc. inventory first.");
			}
		}
	}
	
	private bool Check(int quest)
	{
		string info = GetQuestData(quest);
		string oldBook5 = GetQuestData(1001504);
		
		if (quest == 1006000)	// Scadur's New Fur Coat
		{
			if ((Level >= 60 && info == "") || info == "s")
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (quest == 1006100)	// Moppie the Lone Dawg
		{
			if (info == "s" || info == "1" || info == "2" || info == "3" || info == "5" || info == "6" || info == "7")
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		return false;
	}
	
	public override void Run()
	{
		string questBook1 = GetQuestData(1001500);
		string questBook2 = GetQuestData(1001501);
		
		bool checkFurCoat = Check(1006000);
		bool checkMoppie = Check(1006100);
		
		string dialogue = "";
		
		if (questBook1 == "") dialogue = "The monsters lately have been much more malicious and cruel. What if they show up around here?? That will never happen, right? Right?";
		else if (questBook2 == "end") dialogue = "Where did #bHella#k go... huh? She's doing well? Hmmm... I don't know if I should trust the words of a stranger, but, if it's true then that's great. Of course you already informed Jade, right? After all, he is the most concerned about her.";
		else dialogue = "Are you looking for #bHella#k? Technically she lives here, but you won't find her here these days. A couple months ago, she left town out of the blue and hasn't been back since. Waiting for her at her house won't do much good, but, at least the housekeeper must still be there. How about talking to her?";
		
		if (checkFurCoat && checkMoppie)
		{
			AskMenuCallback(dialogue + "#b",
				(" Scadur's New Fur Coat", FurCoat),
				(" Moppie the Lone Dawg", Moppie));
		}
		else if (checkFurCoat && !checkMoppie)
		{
			FurCoat();
		}
		else if (!checkFurCoat && checkMoppie)
		{
			Moppie();
		}
		else
		{
			self.say(dialogue);
		}
	}
}