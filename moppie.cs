using WvsBeta.Game;

// 2012019 Moppie
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(1006100);
		string quest2 = GetQuestData(1006101);
		string quest3 = GetQuestData(1006102);
		
		if (Level < 30)
		{
			self.say("T.T");
			return;
		}
		
		if (quest1 == "")
		{
			int ask1 = AskMenu("Bark~bark bark bark~ bark bark bark!! Keeeeng ~~#b",
				(0, " Bark~bark bark bark~ bark bark bark!! Keeeeng ~~~"),
				(1, " What? I want to help you"));
				
			if (ask1 == 0)
			{
				self.say("...bark bark? Bark ... bark ... keeeng keeeng");
				return;
			}
			
			SetQuestData(1006100, "s");
			self.say("Bark bark! Bark bark!");
			self.say("Moppie started wagging its tails and smiled as if it understood what I was saying, but I have no clue as to what HE's saying.");
			self.say("On my way here, I think I ran into a lady that may know something about this ... I should ask her some questions about Moppie.");
		}
		else if (quest1 == "s" || quest1 == "1" || quest1 == "2")
		{
			self.say("Bark bark ...??");
		}
		else if (quest1 == "3")
		{
			if (ItemCount(4031190) < 1)
			{
				self.say("Bark bark?");
				return;
			}
			
			self.say("Bark bark ... bark bark bark??");
			
			if (!Exchange(0, 4031190, -1))
			{
				self.say("What was that? I don't speak dog.");
				return;
			}
			
			AddEXP(500);
			SetQuestData(1006100, "4");
			self.say("(When the horn flute starts to be played, a soothing sound echoes throughout the area while the horn flute disappears in a puff) Hey, it's ... gone! Is that because I'm a human?");
			self.say("Did I do all this for naught?\r\n#bHey can you hear me, bark bark~?#k\r\n Hey, isn't this Moppie talking? ... It IS!! I can clearly understand Moppie now!");
			self.say("Okay, now I can understand what Moppie's saying!! But ... what??");
		}
		else if (quest1 == "4")
		{
			int ask2 = AskMenu("Can you hear me? Do you understand me? Bark bark! That was so annoying, talking to someone that couldn't understand what I was saying. Bark, my master likes to go out researching, and he said he would be back early, but ... bark bark ... I'm waiting for my master, as always, but he's still nowhere to be found ... bark bark ...#b",
				(0, " I think it's best for you to go home."),
				(1, " Why? Hey are you hurt? Where exactly?"));
			
			if (ask2 == 0)
			{
				self.say("I want to go home, but where's my master...?");
				return;
			}
			
			SetQuestData(1006100, "5");
			self.say("Bark bark ... actually I left town looking for my master, only to be attacked by a group of intimidating monsters, and here's the wound...");
			self.say("Bark ... I had to get back here as soon as I could. I miss my master so bad ...");
			self.say("The wound I got from then still hurts to this day. I need help, bark. Actually, I really really need help, because it hurts so bad, bark.");
		}
		else if (quest1 == "5" || quest1 == "6")
		{
			self.say("You still haven't found someone that could take care of my wound?");
		}
		else if (quest1 == "7")
		{
			bool start2 = AskYesNo("Bark bark? What? You're here to help me heal my wound? Please don't tell me you brought Lisa's Special Medicine? you did? Can you put it on my wound?");
			
			if (start2)
			{
				if (!Exchange(0, 4031205, -1))
				{
					self.say("Bark bark... are you sure you brought the medicine?");
					return;
				}
				
				AddEXP(1000);
				AddFame(5);
				SetQuestData(1006100, "e");
				QuestEndEffect();
				self.say("Bark bark! The pain is gone! I'm pain free!! Lisa is incredible! Wait, I heard that it required a whole lot of rare ingredients to make, and ...");
				self.say("You're the one that gathered up the ingredients? Well, thanks to you I'm doing well now. Thank you so much! Bark bark!");
			}
		}
		else if (quest1 == "e")
		{
			if (quest2 == "")
			{
				self.say("Did my master safely run past those scary monsters?\r\nBark ... it's been a long time since he left me out here to pursue his studies ... and I can't believe he's been gone this long without saying a word.");
				bool start = AskYesNo("Bark, I'd love to go see him myself, but I don't think I can handle the monsters yet, so ... bark! You! I think you can handle those monsters outside ... so what do you think? Can you find my master for me? Bark bark, just to see if he's doing alright, bark!");
				
				if (!start)
				{
					self.say("My master should be somewhere around Orbis Tower, bark bark. Please find my master...");
					return;
				}
				
				SetQuestData(1006101, "s");
				self.say("Thanks, bark! You must be an incredibly kind person, bark! I have a feeling something good may happen to you, bark!!");
				self.say("My master is doing his studies at a safe place in Orbis Tower, bark. His name is HUCKLE! Bark bark!");
			}
			else if (quest2 == "s")
			{
				self.say("You haven't found my master, bark? He's at Orbis Tower!! His name is HUCKLE! Bark bark!");
			}
			else if (quest2 == "e")
			{
				if (quest3 == "s")
				{
					if (ItemCount(4000088) < 100)
					{
						self.say("Bark bark?");
						return;
					}
					
					self.say("So my master is fine? Bark bark!!");
					
					if (!Exchange(0, 4000088, -100, 2020006, 10, 2120000, 30, 4001019, 4))
					{
						self.say("Bark bark? Free up at least two spots in your use inventory and one in your etc. inventory, bark!");
						return;
					}
					
					AddEXP(4000);
					SetQuestData(1006102, "1");
					self.say("Hey, this is a bag full of fish!! Bark! And you're telling me my dad planned it and sent you these fishes through me! Bark, I can't believe it. A workaholic dad buys me some fish to eat? That's awesome!");
					self.say("Owwww~~ ow~~ my master never forgot about me! Thank you so much for bringing good news to my life~ Bark bark! I think you're one compassionate person ...");
				}
				else if (quest3 == "2")
				{
					if (ItemCount(4000088) < 200)
					{
						self.say("Bark bark, thanks for the update on my master, but ... he didn't send for the Jr. Pepes fishes, huh?");
						return;
					}
					
					self.say("Bark, did my master send for it again? Bark! He should be busy beyond belief with his research, and still thinks about me... bark! That's cool!");
					
					if (!Exchange(2000, 4000088, -200, 2020006, 15, 2120000, 30, 4001019, 4))
					{
						self.say("Bark bark? Free up at least two spots in your use inventory and one in your etc. inventory, bark!");
						return;
					}
					
					AddEXP(5000);
					SetQuestData(1006102, "3");
					self.say("That smell of fish filling up this room. Bark! Thanks! Oh, and the next time you see my master, tell him I still love it! Bark bark!");
				}
				else if (quest3 == "4")
				{
					if (ItemCount(4000088) < 300)
					{
						self.say("Hey, is that all the fishes you have?");
						return;
					}
					
					self.say("Fish again? Did my master send for it again? I just wish he stops working so hard on his research ... bark, I understand that he wants to take care of me, but ...");
					
					if (!Exchange(0, 4000088, -300, 2040707, 1, 2120000, 30, 2000002, 20, 4001019, 4))
					{
						self.say("Bark bark? Free up at least three spots in your use inventory and one in your etc. inventory, bark!");
						return;
					}
					
					AddEXP(6000);
					AddFame(1);
					SetQuestData(1006102, "e");
					QuestEndEffect();
					self.say("Yuck, that smell of fish. My master may not like to hear what I'm about to say, but ... I'm sick of it!! Bark! Please don't bring fish again, bark ... please ... bark bark!");
					self.say("Anyway, thanks for the great news, bark! You really do love all animals, bark!");
				}
				else
				{
					self.say("Bark bark!");
				}
			}
		}
	}
}