using WvsBeta.Game;

// 2041018 Hans the Assembler
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1004000);
		
		if (Level < 36)
		{
			self.say("I just need few things to make a fun toy to play around with...but I don't know if I'm even allowed to make this.");
			return;
		}
		
		if (quest == "")
		{
			bool start = AskYesNo("Hi there. My name is #b#p2041018##k, and I work here at the Toy Factory as a member now. My job is to assemble toys in different ways to make the model work... You look a little bored, though ... do you want to do something fun?");
			
			if (!start)
			{
				self.say("Aww, you look bored though. Come on, you should try it! You won't be disappointed, that's for sure. So if you're ready to change your mind, then come talk to me.");
				return;
			}
			
			SetQuestData(1004000, "s");
			self.say("Alright! I hope you didn't forget the fact that I'm the master toy assembler. We were forbidden from making any dangerous toys, so it had been quite boring for me. Please listen to me carefully as I will give you the list of items needed for something nice. Don't worry, it's for free.");
			self.say("What I need are #b20 #t4000111#s#k from #o4230111#, #b20 #t4000112#s#k from #o4230112#, and #b30 #t4000115#s#k from #o3230306# type of monsters. The moment you gather them all up, bring them back to me, okay? Good luck!!!");
		}
		else if (quest == "s")
		{
			if (ItemCount(4000111) < 20 || ItemCount(4000112) < 20 || ItemCount(4000115) < 30)
			{
				self.say("I don't think you have them all yet. What I need are #b20 #t4000111#s#k from #o4230111#, #b20 #t4000112#s#k from #o4230112#, and #b30 #t4000115#s#k from #o3230306# type of monsters. The moment you gather them all up, bring them back to me, okay? Good luck!!!");
				return;
			}
			
			self.say("You're back!!! Let's see ... you brought them all! Okay, it's showtime now. Time to make history here, for this has never been made before. Now hold on one second ... the screw goes here, the metal goes here, the battery goes here, \r\nand ...");
			
			if (!Exchange(0, 4000111, -20, 4000112, -20, 4000115, -30, 2100018, 3))
			{
				self.say("Hey, are you sure you have enough room in your use inventory? Please check again!");
				return;
			}
			
			AddEXP(5850);
			SetQuestData(1004000, "e");
			QuestEndEffect();
			self.say("Tada!! What do you think about the #b3 #t2100018#s#k? This sack will contain all kinds of toys that I made for this. They are a little on the wild side, though, so please be careful before opening up the sack. This was fun!! I'll see you later!");
		}
		else if (quest == "e")
		{
			self.say("Hey, what's going on? Have you tried using the stuff I gave you the other day? That item had some experimental elements to it, and therefore a little dangerous, but it was fun making something I've always wanted to make. I have to get back to work now!");
		}
	}
}