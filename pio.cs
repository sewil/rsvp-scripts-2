using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(200);
		string quest2 = GetQuestData(201);
		
		if (quest == "")
		{
			bool start = AskYesNo("My goodness. So many useful items are being thrown \r\naway ... I've been wandering around this town, and I see so many items that are thrown away that can be recycled! Hey, say ... can you help me collect those?\r\nWell, don't worry, I'll reward you well for your effort.");
			
			if (!start)
			{
				self.say("Come on ... try it!! It's not hard at all! Just strike this box next to me and you'll know what I'm talking about.");
				return;
			}
			
			SetQuestData(200, "s");
			self.say("That's right!! Please get me all the supposedly useless items that are abandoned all over town. I'll reward you well for your effort. Hahahah!!!");
			self.say("Well ... I don't know if you've seen the wooden boxes that have been left abandoned on your way here. Did you see them? Your job is to break those boxes and then bring them back as recyclable materials. When you break those boxes, you'll get #t4031162# and #t4031161# in return. Just collect 10 of those for me, okay?");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031162) < 10 || ItemCount(4031161) < 10)
			{
				self.say("No, no, no! Check again!! Press 'Q' to take a look at the 'Quest Info'. See the quests that are in progress and see what I'm asking of you!");
				return;
			}
			
			self.say("What? You brought them all? Okay, let's see ...");
			
			if (!Exchange(200, 4031162, -10, 4031161, -10))
			{
				self.say("Huh?? Are you sure you brought the recyclable materials with you?");
				return;
			}
			
			AddEXP(100);
			SetQuestData(200, "end");
			QuestEndEffect();
			self.say("See what I'm talking about? So many recyclable items thrown away with abandon. We need to do something about this! Anyway thank you so much for your help! Hopefully there are more people like you to help me out. I'll see you around!!");
		}
		else if (quest == "end")
		{
			self.say("Here in #m1010000#, there are shops for weapons and supplies, and in #m60000#, a port with a huge ship called The Victoria, it's there you can find a shop that sells armor.");
			self.say("A few days ago, I borrowed a hammer from #p11000# at the weapon shop, and the hammer broke. What should I do?");
			return;
			
			/*
			if (quest2 == "")
			{
				bool start2 = AskYesNo("Hmmm... I've just made the recycled item using the materials you got me, and ... I've got some leftover here. Would you like me to make something nice out of this for you?");
				
				if (!start2)
				{
					self.say("Eh? You don't trust my skills by any chance, do you?");
					return;
				}
				
				self.say("Ahh... the green cloth should be here somewhere... hmmm, and I should cut this wood, and put the screws on, and ...");
				
				if (!Exchange(0, 3010000, 1))
				{
					self.say("Huh?? Please make some room in your set-up inventory first!");
					return;
				}
				
				SetQuestData(201, "end");
				QuestEndEffect();
				self.say("Doesn't it look comfortable? This chair can come very handy for you. If you're low on HP and MP, just take the chair out and have a seat!");
				self.say("It'll get you relaxed and allow you to recover quickly.\r\nHmmm... for that! I call it ... The Relaxer! What do you think of the name? Don't forget that the chair has been brought to you by yours truly, the great Pio!");
			}
			else
			{
				self.say("Here in #m1010000#, there are shops for weapons and supplies, and in #m60000#, a port with a huge ship called The Victoria, it's there you can find a shop that sells armor.");
				self.say("A few days ago, I borrowed a hammer from #p11000# at the weapon shop, and the hammer broke. What should I do?");
			}
			*/
		}
	}
}