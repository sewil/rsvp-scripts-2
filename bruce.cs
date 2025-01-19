using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(1005600);
		string quest2 = GetQuestData(1005601);
		string ayan1 = GetQuestData(1005700);
		
		if (Level < 10)
		{
			self.say("My name is Bruce.");
			return;
		}
		
		if (quest1 == "")
		{
			bool start = AskYesNo("Hey there, kid. Yes, you! I am a scientist that specializes in the field of monsters and animals in this world. If you have any time available, would you mind helping the old man out?");
			
			if (!start)
			{
				self.say("I would appreciate a good deal if you could help me out, but alas, you are busy.");
				return;
			}
			
			SetQuestData(1005600, "s");
			self.say("Thank you. I have been currently studying the mushroom monsters, and ... speaking of mushroom monsters, this reminds me of something.");
			self.say("Years ago, my daughter and I went out of town in search of research materials. While we were busy excavating, we were ambushed by an enormous mushroom monster.");
			self.say("By the time I regained my consciousness, I had been severely battered and bruised, while my daughter was nowhere to be found. Ever since the incident, I have been studying the mushroom monsters in hopes for finding some clues for my daughter's whereabouts.");
			self.say("Oh, I'm rambling on again. Anyway, I would appreciate it a great deal if you can get me #b10 #t4000011#s#k and #b40 \r\n#t4000001#s#k. Good luck!");
		}
		else if (quest1 == "s")
		{
			if (ItemCount(4000001) < 40 || ItemCount(4000011) < 10)
			{
				self.say("I don't think you have collected all the items I requested. These are the ones you'll need: #b10 #t4000011#s#k and #b40 #t4000001#s#k.");
				return;
			}
			
			self.say("You brought them all here! Thank you thank you! I shall start studying these samples carefully. Oh, I almost forgot to reward you for your hard work.");
			
			if (!Exchange(0, 4000001, -40, 4000011, -10, 2000000, 25))
			{
				self.say("Hmm, are you sure you have enough space in your use inventory?");
				return;
			}
			
			AddEXP(300);
			SetQuestData(1005600, "e");
			QuestEndEffect();
			self.say("Here's a small gift to you. This should help you on your journey. I will see you around.");
		}
		else if (quest1 == "e")
		{
			if (quest2 == "" && ayan1 == "e")
			{
				bool start2 = AskYesNo("Oh, it is you! I have great news! A great news, indeed... if you have any spare time, then ask me what exactly the great news is. I also need your help on this.");
				
				if (!start2)
				{
					self.say("It is really a great news ... and I would really appreciate it if you can help me out here.");
					return;
				}
				
				self.say("The great news is that I have found my daughter!! My assistant went to places near Perion to pick up some samples. After he got done with it, he stopped by Perion for a few, and ... apparently, he met a lady that eerily resembled my daughter!");
				self.say("So he started talking to her, and... apparently, she does not remember anything from her childhood. She's also not a tribesperson... that has got to be my daughter. It seems like she was beyond shocked when she was attacked by the mushroom monster.");
				self.say("That is most likely the reason why she does not remember her childhood. Here ... I want you to give her this sword for me. My daughter liked to pose as a knight while growing up.");
				
				if (!Exchange(0, 4031174, 1))
				{
					self.say("I would like to give you this toy sword so... please leave an empty slot in your etc. inventory.");
					return;
				}
				
				SetQuestData(1005601, "b");
				self.say("This toy sword was something she really enjoyed playing with. This may help her bring back the memories and remember the past. Please help me help my daughter.");
			}
			else if (quest2 == "b")
			{
				if (ItemCount(4031174) >= 1)
				{
					self.say("This toy sword was something she really enjoyed playing with. This may help her bring back the memories and remember the past. Please help me help my daughter.");
					return;
				}
				
				self.say("Please don't lose it again. This is a very important item for me. Good thing my assistant picked it up from the ground. Again, please don't lose it.");
				
				if (!Exchange(0, 4031174, 1))
				{
					self.say("I would like to give you this toy sword so... please leave an empty slot in your etc. inventory.");
				}
			}
			else if (quest2 == "a")
			{
				if (ItemCount(4031173) < 1)
				{
					self.say("This toy sword was something she really enjoyed playing with. This may help her bring back the memories and remember the past. Please help me help my daughter.");
					return;
				}
				
				self.say("Oh... that's ... my ... daughter... indeed ... I ... can't believe it ... I don't think I have ever been so happy in my life ... thank you so much.");
				self.say("I am so glad my daughter is alive and well! I have to make my way there now. I cannot wait to see her. Here's some money for your traveling expense. It may not be much, but please take it.");
				
				if (!Exchange(500, 4031173, -1))
				{
					self.say("Hmm ... are you sure you brought the letter?");
				}
				
				AddEXP(200);
				SetQuestData(1005601, "e");
				QuestEndEffect();
				self.say("This is too good to be true!");
			}
			else
			{
				self.say("You're the one who helped me the other day. How are you?");
			}
		}
	}
}