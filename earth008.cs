using WvsBeta.Game;

// 2041011 Yellow Mesoranger
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string questGray = GetQuestData(1003400);
		string quest1 = GetQuestData(1003401);
		string quest2 = GetQuestData(1003402);
		
		if (questGray != "e")
		{
			self.say("Hi. I'm #b#p2041011##k, in charge of a special mission here. Have you seen an alien around here? Apparently they attract innocent strangers by sweet-talking to them, so please be aware of that.");
			return;
		}
		
		if (quest1 == "")
		{
			self.say("Hmmm... Aren't you... the one that helped #b#p2050002##k out the other day? This is serious stuff... I heard about an alien that trick the people into fishing out classified information on us, but I thought they were just rumors... not in real life.");
			bool start = AskYesNo("It's only a matter of time before the Sector finds out about this, and who knows? You may be classified as an alien-supporter, too. Well, but then again, you really didn't know any better... What do you think? Would you like to take on my mission to regain at least my trust?");
			
			if (!start)
			{
				self.say("Hmmm... so it wasn't really an accident, but rather, you ARE an alien-supporter? I'll try to believe that's not true. If you want to change your mind, then talk to me.");
				return;
			}
			
			SetQuestData(1003401, "120");
			self.say("Good choice. You never know when you're going to be classified as an enemy of the Sector. Your task is simple. Just show it to us that you're NOT an alien-supporter, and if you're not a supporter, you would have no trouble whatsoever going in the battle against them.");
			self.say("There are quite a few aliens that have approached the nearby fields of the Omega Sector. Your task is to defeat \r\n#b120 #o4230118#s#k. They are pretty strong, so it'll be best for you to team up with other people in order to complete this mission faster. I'll be here awaiting good news from you.");
		}
		else if (quest1 == "e")
		{
			if (quest2 == "")
			{
				bool start2 = AskYesNo("Been a while! As you can see, I've been given orders from upstairs, and I am flooded with work to do. It's getting to the point where I can't possibly do all this by myself. Ohhh... yeah, I want to ask you for a favor. Will it be okay if you can spend some time for us, the Omega Sector?");
				
				if (!start2)
				{
					self.say("You seem to be pretty busy right now, and I can't do anything about that. However, if you find yourself some free time, please talk to me. I have so much work to do right now, that I don't even sleep these days. I'll see you around~");
					return;
				}
				
				SetQuestData(1003402, "000000");
				self.say("Sweet! What I wanted to ask you to do is to collect samples of the asteroids that recently fell. Apparently, the aliens, while making their way here, landed hard, to the point of having quite a number of asteroids dropping around Omega Sector. My boss said that by collecting samples, it'll immensely help our level of science in Omega Sector.");
				self.say("There's a report that a whole lot of asteroids fell on the field slightly far from here, Kulan Plain. Please look through the samples there, and collect #b6 #t4031117#s#k for me. I'll be here waiting for you.");
			}
			else if (quest2 == "e")
			{
				self.say("Thank you so much for helping me out. I know you made a mistake of helping the aliens obtain classified information, but everyone makes mistakes... I think you can be proudly considered one of us now.");
			}
			else
			{
				int sampleCount = ItemCount(4031117);
				
				if (sampleCount < 6 && quest2 == "111111")
				{
					self.say("Huh... did you lose some of the meteorite samples you collected? Please go and collect them again.");
					
					if (Exchange(0, 4031117, -sampleCount))
					{
						SetQuestData(1003402, "000000");
					}
					
					return;
				}
				
				if (ItemCount(4031117) < 6)
				{
					self.say("There are loads of asteroids all over Kulan Plain as a result of the crash landing that took place while the aliens invaded this place. Check out the asteroids and pick out #b6 #t4031117#s#k for me. With these samples, some of the classified studies may receive the boost they need to finish them up.");
					return;
				}
				
				self.say("Ohhh, you're back! Let me see... oooh, you really picked out the best #b#t4031117#s#k available. This should immensely help our scientific studies down the road. As a sign of appreciation, I'll give you an item that's been given to me from my bosses. Please take it.");
				
				if (!Exchange(0, 4031117, -6, 2022003, 50))
				{
					self.say("Please have a slot available in your use inventory.");
					return;
				}
				
				AddEXP(4200);
				SetQuestData(1003402, "e");
				QuestEndEffect();
				self.say("Thank you so much for helping me out. I know you made a mistake of helping the aliens obtain classified information, but everyone makes mistakes... I think you can be proudly considered one of us now. Bye~!");
			}
		}
		else
		{
			if (quest1 != "000")
			{
				self.say("I don't think you have completed the mission, yet. In order to regain the trust of the Omega Sector, you'll have to go downfield and defeat #b120 #o4230118#s#k.");
				return;
			}
			
			self.say("Hoh... you did defeat all the #b#o4230118#s#k like I asked you to do. It was a difficult task, for sure, but I guess you really wanted to restore the faith in you, right? Alright... I'll tell the people upstairs that you are indeed a friend of the Omega Sector. Oh, and here's a small reward for your job well done.");
			
			if (!Exchange(0, 1032018, 1))
			{
				self.say("Please have a slot available in your equip. inventory.");
				return;
			}
			
			AddEXP(5700);
			SetQuestData(1003401, "e");
			QuestEndEffect();
			self.say("Here's #b1 #t1032018##k for you. This should help you on your traveling. Here's hoping that you won't ever help out the aliens again. Also, if you find yourself with some time to kill, please find me. I may need your help sometime down the road.");
		}
	}
}