using System;
using WvsBeta.Game;

// 2020007 Scadur
public class NpcScript : IScriptV2
{
	private void AncientBook()
	{
		string oldBook4 = GetQuestData(1001503);
		
		if (oldBook4 == "s")
		{
			self.say("This is a gorgeous ring. It looks a bit old, but I can feel the special force emanate. Hmmm, here, let me see the ring...I have to look really into it.");
			
			if (!Exchange(0, 4031053, -1))
			{
				self.say("Huh, are you sure you have that ring?");
				return;
			}
			
			SetQuestData(1001503, "k1");
			self.say("Hahaha ... Looks like I'll be taking care of this ring for a while. Don't try to wrestle it away from me, because I've been fighting monsters for a long long time and you can't even come close to beating me. If you really want it back, however, we can make a deal. Don't worry, I won't ask you to do anything ridiculous. What do you think ... do we have ourselves a deal?");
		}
		else if (oldBook4 == "k1")
		{
			self.say("Alright, the deal is simple. Recently the price on the wolf skin has skyrocketed, but it's been tough hunting them since it's that time of the year where they get very aggressive. If you get me #b100 #t4000051#s and 100 #t4000052#s#k, I'll return the ring AND tell you everything I know about it. Don't make me wait too long. Get me those ASAP!");
			SetQuestData(1001503, "k2");
		}
		else if (oldBook4 == "k2")
		{
			if (ItemCount(4000051) < 100 || ItemCount(4000052) < 100)
			{
				self.say("Recently the price on the wolf skin has skyrocketed, but it's been tough hunting them since it's that time of the year where they get very aggressive. If you get me #b100 #t4000051#s and 100 #t4000052#s#k, I'll return the ring AND tell you everything I know about it. Don't make me wait too long. Get me those ASAP!");
				return;
			}
			
			self.say("You brought #b100 #t4000051#s and 100 #t4000052#s#k like you promised. Here's the ring like I promised. Also, since you did me a big favor, here's an item for you. I don't really need it now. Before that, though, check and see if you have any room on your use inventory.");
			
			if (!Exchange(0, 4000051, -100, 4000052, -100, 2000004, 30, 4031053, 1))
			{
				self.say("Please leave a slot empty in your etc. and use inventory.");
				return;
			}
			
			AddEXP(9450);
			SetQuestData(1001503, "end");
			SetQuestData(1001500, "ke");
			QuestEndEffect();
			self.say("When I was young, before I even stepped foot on this continent, I was able to meet the #b4 wisemen#k. I think it's the same ring that they were talking about when I saw them. Take the ring and find the #b4 wisemen in Victoria Island#k. Of the four, find the wiseman of #bPerion#k first. And if you're ever stopping by this town again, please drop by and say hi.");
		}
		else if (oldBook4 == "end")
		{
			if (ItemCount(4031053) >= 1)
			{
				self.say("Haven't visited those wisemen yet? Take the ring and find the #b4 wisemen in Victoria Island#k. Of the four, find the wiseman of #bPerion#k first. And if you're ever stopping by this town again, please drop by and say hi.");
				return;
			}
			
			self.say("You brought #b100 #t4000051#s and 100 #t4000052#s#k like you promised. Here's the ring like I promised.");
			
			if (!Exchange(0, 4031053, 1))
			{
				self.say("Are you sure you have enough space in your inventory?");
				return;
			}
		}
	}
	
	private void Nick()
	{
		string scadur = GetQuestData(1001900);
		
		if (scadur == "")
		{
			bool start = AskYesNo("Aren't you the one that brought that strange ring the other day? How have you been? I'm glad you came. Anyway, I have a distinct favor to ask you ... something I've been wishing to take care of for a long, long time. What do you think? It may not be easy, but do you want to help me nonetheless?");
			
			if (!start)
			{
				self.say("I understand. You must be worn out from all that traveling ... but if you want to change your mind, then please come talk to me. I can't think of anyone else but you that can do this.");
				return;
			}
			
			SetQuestData(1001900, "s");
			self.say("Thank you so much! I can finally fulfill my long-time wish with this ... See, I have a lovely son, who I adore more than anyone else in the world. His name is #bNick#k. He wasn't exceptional in one thing, but was a great kid who was a hard worker.");
			self.say("Then one day, a group of monsters from the mines attacked our town. They took my wife Ria away from me forever ... and, ever since her passing, Nick had turned into a totally different person.");
			self.say("He made up his mind to strengthen himself so he can take care of the monsters from the mines. I tried my best to stop him, to no avail. He left 3 years ago to defeat the monsters, and I haven't heard one word from him since. It's obvious what happened to him ...");
			self.say("I don't cling on to hope that he's alive. What I do hope is to find a ring that he's wearing. There should be a lava cave at the inner part of the mines at the valley of El Nath. You may be able to find his ring somewhere in there.");
			self.say("Please find his #bring#k for me. Also, as my son had always wished, please take down #b#o7130001#'s#k and collect #b100 Cerebes Teeth#k for him. I have faith in you.");
		}
		else if (scadur == "s")
		{
			self.say("Haven't found #bNick#k's ring, yet? It should be at the lava cave at the inner part of the mine ... and, as my son has wished, please take down #b#o7130001##k in the cave and collect #b100 Bulldog Teeth#k. Thank you.");
		}
		else if (scadur == "g")
		{
			if (ItemCount(4031060) < 1 || ItemCount(4000079) < 100)
			{
				self.say("Haven't found #bNick#k's ring, yet? It should be at the lava cave at the inner part of the mine ... and, as my son has wished, please take down #b#o7130001##k in the cave and collect #b100 #t4000079#s#k. Thank you.");
				return;
			}
			
			self.say("This is IT! This is the ring my son Nick wore ...! Only two people in this world have this ring, my son and me. It has our name engraved on it at the cover. I can't believe I'm seeing this ring again, after all that happened. Thank you! Thank you SO MUCH!");
			self.say("And you also took out #b#m7130001##k and collected a lot of #b#t4000079##k, just the way my son had wanted. Scares me just looking at these... anyway, Nick should be pleased with all this in heaven ...");
			self.say("Since you have taken care of my request so well, I'm a much happier man today than I was for a long long time. All right, then. I'll give you the cape that has been passed down through generations at our household. I've been taking good care of this cape, but it may serve its real purpose with you wearing it. Please take it.");
			
			Random rnd = new Random();
			int[] capes = {1102021, 1102022, 1102023, 1102024};
			
			int itemID = capes[rnd.Next(capes.Length)];
			
			if (!Exchange(0, 4031060, -1, 4000079, -100, itemID, 1))
			{
				self.say("Please make sure you have a free slot in your equip. inventory first.");
				return;
			}
			
			AddEXP(21415);
			SetQuestData(1001900, "end");
			QuestEndEffect();
		}
	}
	
	private void FurCoat()
	{
		string quest = GetQuestData(1006000);
		
		if (quest == "s")
		{
			bool start = AskYesNo("You came here through Lisa? Hmm, you look strong enough. Lisa knows how to pick out great people from the crowd. Okay, then, will you help me with my work?");
			
			if (!start)
			{
				self.say("Okay, so what's the pointing of saying no now?");
				return;
			}
			
			if (!Exchange(0, 4031204, -1))
			{
				self.say("Are you sure you have Lisa's letter of recommendations with you?");
				return;
			}
			
			AddEXP(1000);
			SetQuestData(1006000, "1");
			self.say("I knew you'd be interested. Here's the situation. Lately it's been even colder than usual, and I need to make myself a much better fur coat than the one I am wearing right now to combat the coldness.");
			self.say("That's why it would be nice if you can gather up the items needed to make the fur coat. I can definitely use a strong person like you, and don't worry, you will be handsomely rewarded for your effort, so please help me.");
			self.say("To make a new fur coat, I'll need #b300 #t4000051#s, 300 #t4000052#s, 100 #t4000049#s, and 60 #t4020005#s#k. Good luck~");
		}
		else if (quest == "1")
		{
			if (ItemCount(4020005) < 60 || ItemCount(4000049) < 100 || ItemCount(4000051) < 300 || ItemCount(4000052) < 300)
			{
				self.say("I don't think you have gathered up all the materials necessary to make my new fur coat. Please hurry.");
				return;
			}
			
			self.say("Incredible! You brought all of them! Now I can spend the rest of the icy winter break wearing my fur coat and relax.");
			
			if (SlotCount(2) < 1)
			{
				self.say("Are you sure you brought everything with you? If so, please free up a space in your use inventory.");
				return;
			}
			
			Random rnd = new Random();
			int[] reward = {2040504, 2040501, 2040516, 2040513};
			
			int itemID = reward[rnd.Next(reward.Length)];
			
			if (!Exchange(0, 4000051, -300, 4000052, -300, 4000049, -100, 4020005, -60, itemID, 1))
			{
				self.say("Are you sure you brought everything with you? If so, please free up a space in your use inventory.");
				return;
			}
			
			AddEXP(27000);
			AddFame(2);
			SetQuestData(1006000, "e");
			QuestEndEffect();
			self.say("Thank you so much~ here, please take it. I don't need it anymore.");
		}
	}
	
	private bool Check(int quest)
	{
		string info = GetQuestData(quest);
		string oldBook5 = GetQuestData(1001504);
		
		if (quest == 1001503)	// Scadur the Hunter
		{
			if ((info == "s" || info == "k1" || info == "k2" || info == "end") && oldBook5 == "")
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (quest == 1001900)	// Nick, the Son of Scadur the Hunter
		{
			if (Level >= 65 && oldBook5 != "" && (info == "" || info == "s" || info == "g"))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (quest == 1006000)	// Scadur's New Fur Coat
		{
			if (info == "s" || info == "1")
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
		bool checkOldBook = Check(1001503);
		bool checkScadur = Check(1001900);
		bool checkFurCoat = Check(1006000);
		
		if ((checkOldBook || checkScadur) && checkFurCoat)
		{
			AskMenuCallback("I am concerned about the state of the monsters being much more aggressive than usual these days. There were times where I felt like I was putting my life on the line while hunting. Back in the day I used to bring home a whole lot of Yeti's. As the years go by, the age is definitely starting to show...#b",
				(" Scadur the Hunter", checkOldBook, AncientBook),
				(" Nick, the Son of Scadur the Hunter", checkScadur, Nick),
				(" Scadur's New Fur Coat", checkFurCoat, FurCoat));
		}
		else if (!checkOldBook && !checkScadur && checkFurCoat)
		{
			FurCoat();
		}
		else if ((checkOldBook || checkScadur) && !checkFurCoat)
		{
			if (checkOldBook)
			{
				AncientBook();
			}
			else if (checkScadur)
			{
				Nick();
			}
		}
		else
		{
			self.say("I am concerned about the state of the monsters being much more aggressive than usual these days. There were times where I felt like I was putting my life on the line while hunting. Back in the day I used to bring home a whole lot of Yeti's. As the years go by, the age is definitely starting to show...");
		}
	}
}