using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Huckle()
	{
		string quest = GetQuestData(1002000);
		
		if (quest == "s")
		{
			if (ItemCount(4000085) < 20 || ItemCount(4000083) < 45 || ItemCount(4000084) < 20)
			{
				self.say("I don't think you have gotten everything I asked for. Please take down the monsters in the Orbis Tower and collect #b45 #t4000083#s, 20 #t4000084#s, and 20 #t4000085#s#k up, and bring them all to me. I'll be here conducting studies until you make your way back here. Thank you, and hope you get back here safely.");
				return;
			}
			
			self.say("Ohhh ... you really did gather up the sample for me. I knew I have an eye for a talent. Anyway, thank you so much for your hard work. For your reward, I'll give you #b#t4001019##k, something only I can make. I'll give you the details on how to use it once I give you the item.");
			
			if (!Exchange(0, 4000083, -45, 4000084, -20, 4000085, -20, 4001019, 5))
			{
				self.say("Ohhh... please leave an empty slot in your etc. inventory first.");
				return;
			}
			
			AddEXP(3500);
			SetQuestData(1002000, "end");
			SetQuestData(1002001, DateTime.UtcNow.ToString("yyyyMMdd"));
			QuestEndEffect();
			self.say("The #b#t4001019##k that I just gave you is the item that activates two teleporting rocks at the Orbis Tower. I'll let you use #b#p2012014##k at the 20th floor, and #b#p2012015##k at the 1st floor. Use it on one of the teleport rock and you'll be able to move to the other teleport rock. Please put them to good use, and come back if you need me.");
		}
		else
		{
			bool start = AskYesNo("Cough cough ... excuse me ... oh, hello there. You found a way to get here, somehow. My name's #p2030012#, and I've been here for 30 years. I don't even remember the last time I've seen a person. But hey, if you have some time in your hand, then can you help me out here? It's not that hard of a task, so I'm sure you can do it.");
			
			if (!start)
			{
				self.say("Hmm... you must be really busy... Please come back to me when you have time.");
				return;
			}
			
			SetQuestData(1002000, "s");
			self.say("Alright! Actually, I've been here studying the basis of self-moving rocks for the past 30 years. The more visible ones at this tower are the monsters that resemble a bunch of moving stones, and I'm here to study anything and everything involving them. Conducting studies on them takes time, however, and so it is almost impossible for me to gather up the samples of them.");
			self.say("That's why, I need you to go to the tower, take down the monsters, and collect the pieces of rock that consists their body. I will need #b45 #t4000083#s, 20 #t4000084#s, and 20 #t4000085#s#k. I'll be here waiting for you. Good luck.");
		}
	}
	
	private void Moppie()
	{
		string quest = GetQuestData(1006101);
		string quest2 = GetQuestData(1006102);
		
		if (quest == "s")
		{
			self.say("Are you interested in my work? Well, the results are still a big secret. What? No? Then what are you here for? Moppie? Who's ... Moppie??");
			self.say("My Moppie? The cute, little Moppie that followed my every move? I have totally forgotten about him ... he may have been tiny, but he was a very loyal dog ...");
			self.say("What, Moppie's all grown up now? Has the time gone by that fast? I remember he used to fit in my bag when I got here ... and now Moppie's waiting for me...");
			
			AddEXP(3000);
			SetQuestData(1006101, "e");
			QuestEndEffect();
			self.say("Thanks for finding me here. You even took care of my Moppie. I must say, you're a person of great heart. Thank you.");
		}
		else if (quest == "e")
		{
			if (quest2 == "")
			{
				self.say("Oh no, I have totally forgotten about Moppie. Poor thing is still waiting for me at the same spot. I better do something about it.");
				bool start = AskYesNo("I would like to at least send him some food that he loves, but as you can see, I'm all tied up at work now, and I can't leave this place. Can you get Moppie some food? Please? #b100 Jr. Pepe's fishes#k should do.");
				
				if (!start)
				{
					self.say("I have no spare time these days. Can you please help me, for Moppie's sake?");
					return;
				}
				
				SetQuestData(1006102, "s");
				self.say("Thank you! I may even put your name in one of the studies I have conducted over the years. Moppie loves the fishes that the Jr. Pepe's drop at the bottom of Orbis Tower. Please get him a bunch of those! Thanks!");
				self.say("Once you gathered up the fishes, please give them directly to Moppie! Please make sure to tell him that I sent those fishes for him. He'll be ecstatic ... so the next time you stop by the Orbis Tower, please feel free drop bye... I'll be here waiting.");
			}
			else if (quest2 == "s")
			{
				self.say("Have you collected the #b100 Jr. Pepe's fishes#k yet? Once you gathered up the fishes, please give them directly to Moppie!");
			}
			else if (quest2 == "1")
			{
				self.say("Did Moppie like it? How did he react? Did you tell him I sent for it? ... really? Moppie liked it THAT much?");
				bool start2 = AskYesNo("I'm just embarrassed for myself, for failing to take care of myself. Alright, then. I should at least feed him with something he likes. I should send him 200 this time. What do you think? Can you do it? Please do this for the sake of my research.");
				
				if (!start2)
				{
					self.say("I see ... you don't want to help out anymore...?");
					return;
				}
				
				SetQuestData(1006102, "2");
				self.say("Thank you! I may even put your name in one of the studies I have conducted over the years. Make sure to pick up the fishes that the Jr. Pepes drop at the bottom of Orbis Tower. 200 fishes for Moppie!");
			}
			else if (quest2 == "2")
			{
				self.say("Have you collected the #b200 Jr. Pepe's fishes#k yet? Once you gathered up the fishes, please give them directly to Moppie!");
			}
			else if (quest2 == "3")
			{
				self.say("Aren't you the one that wanted to be my assistant? Did Moppie like the fishes? Did you tell him I sent for it? ...Really? Moppie liked them that much??");
				bool start3 = AskYesNo("Alright! Moppie should be fed more with stuff he likes. Can you gather up 300 this time? I may hire you as my assistant if this goes well.");
				
				if (!start3)
				{
					self.say("Right now ... I am so busy with this work that I can't do anything else in my life.");
					return;
				}
				
				SetQuestData(1006102, "4");
				self.say("Thank you! I may even put your name in one of the studies I have conducted over the years. Make sure to pick up the fishes that the Jr. Pepes drop at the bottom of Orbis Tower. 300 fishes for Moppie!");
			}
			else if (quest2 == "4")
			{
				self.say("Have you collected the #b300 Jr. Pepe's fishes#k yet? Once you gathered up the fishes, please give them directly to Moppie!");
			}
		}
	}
	
	private bool Check(int quest)
	{
		string info = GetQuestData(quest);
		
		string Moppie1 = GetQuestData(1006101);
		string lastDate = GetQuestData(1002001);
		string today = DateTime.UtcNow.ToString("yyyyMMdd");
		
		if (quest == 1002000)	// Collecting Huckle's Magic Ingredients
		{
			if (lastDate != today)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (quest == 1006101)	// A Request from Moppie
		{
			if (info == "s")
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (quest == 1006102)	// Food-Hunting for Moppie
		{
			if (Moppie1 == "e" && (info == "" || info == "s" || info == "1" || info == "2" || info == "3" || info == "4"))
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
		string lastDate = GetQuestData(1002001);
		
		bool checkHuckle = Check(1002000);
		bool checkMoppie1 = Check(1006101);
		bool checkMoppie2 = Check(1006102);
		
		string dialogue = "It's been a while since I last saw a person here, a place far far away from humanity. I've been in need of help, and I'm glad to see you here.";
		
		if (lastDate != "") dialogue = "You're the one that helped me gather up samples of the monsters. Thanks to you the research has picked up steam, but honestly, I can use some more samples. If you see me by the time I run out of these samples, who knows, I may ask you for more.";
		
		if (checkHuckle && (checkMoppie1 || checkMoppie2))
		{
			AskMenuCallback(dialogue + "#b",
				(" Collecting Huckle's Magic Ingredients", checkHuckle, Huckle),
				(" A Request from Moppie", checkMoppie1, Moppie),
				(" Food-Hunting for Moppie", checkMoppie2, Moppie));
		}
		else if (checkHuckle && !checkMoppie1 && !checkMoppie2)
		{
			Huckle();
		}
		else if (!checkHuckle && (checkMoppie1 || checkMoppie2))
		{
			Moppie();
		}
		else
		{
			self.say(dialogue);
		}
	}
}