using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string nemi1 = GetQuestData(1002300);
		string quest = GetQuestData(1002301);
		
		if (nemi1 == "")
		{
			self.say("Helow there! I'm #b#p2040015##k, the one in charge of the Toy Factory. Today's another one of those busy days...");
		}
		else if (nemi1 == "s")
		{
			if (ItemCount(2020021) < 1)
			{
				self.say("You must have met my daughter! Didn't she want you to deliver the lunchbox to me? If you lost it in the middle of the track or have eaten it, please go back to her immediately. If she feels good, she may just make you another one.");
				return;
			}
			
			self.say("Ohh, this is it! The lunchbox from heaven by none other than my daughter! I can't work without this. Great job bringing this here. Thanks to you, I'll be able to concentrate on my work now. Here are some mesos for you.");
			
			if (!Exchange(4500, 2020021, -1))
			{
				self.say("Are you sure you brought the lunch that my daughter made?");
				return;
			}
			
			AddEXP(750);
			SetQuestData(1002300, "e");
			QuestEndEffect();
			self.say("Mmmhmmm, this is how it should be! #p2041005#'s the best, bar none! Oh, by the way, I have been really busy these days with work, and I was hoping someone help me out here. If you have any free time down the road, please drop by.");
		}
		else if (nemi1 == "e")
		{
			if (quest == "")
			{
				self.say("Hello there! Aren't you the one that delivered my lunchbox for my daughter? Thanks to you I had a great lunch that day. Well, now that you're here ... I have something to ask you. Will you help me out, if you have some time with you right now?");
				self.say("We had 10 Roly-Poly workers working at the factory. Those guys are hard workers, but right now, they have been sent abroad to fix Eos Tower. I'm sure they're working on the tower even as we speak.");
				bool start = AskYesNo("I'm just curious as to whether they work hard even without me watching over them. That is why... can you visit those guys and take a picture of each and every one of them through the camera that I'm giving you? It will be nice to have you visit them in order.");
				
				if (!start)
				{
					self.say("Hmmm ... you must be busy right now. I sure can use someone like you right now. If you ever have a change of heart, please let me know, okay?");
					return;
				}
				
				if (!Exchange(0, 4031078, 1))
				{
					self.say("Please leave a space open in the etc. tab for my camera.");
					return;
				}
				
				SetQuestData(1002301, "s");
				self.say("You have my camera now. Please make sure you don't lose it. After taking pictures of my 10 workers in order, all you need to do is come back, and return the camera along with the pictures. Please head over to Eos Tower ASAP. Thank you!");
			}
			else if (quest == "e")
			{
				self.say("Oh~ You're the one that met up with our Roly Poly's at the Eos Tower for me! How can I help you here? Huh? Haha, of course, I did not forget the lunch box my daughter made for me. I'm just waiting for lunch so I can eat them! I'll see you around!");
			}
			else
			{
				if (quest == "10" && ItemCount(4031078) >= 1 && ItemCount(4031088) >= 1)
				{
					self.say("Hoh ... you must have taken pictures with every one of my men at Eos Tower. Hopefully they're having fun working there. Anyway, great job. Here's my sign of appreciation for being so great.");
					
					int[] rewards = {4131000, 4131001, 4131002, 4131003, 4131004, 4131005, 4131006, 4131007, 4131008, 4131009, 4131010, 4131011, 4131012, 4131013};
					
					int askReward = 0;
					
					if (Job < 200)
					{
						askReward = AskMenu("Okay, this is an item that you'll need to have if you want to make an item through #b#p2040022##k somewhere around Ludibrium. Please choose what kind of an item you wish to have.#b",
							(0, " #t4131000#"),
							(1, " #t4131001#"),
							(2, " #t4131002#"),
							(3, " #t4131003#"),
							(4, " #t4131004#"),
							(5, " #t4131005#"),
							(6, " #t4131006#"),
							(7, " #t4131007#"));
					}
					else if (Job >= 200 && Job < 300)
					{
						askReward = AskMenu("Okay, this is an item that you'll need to have if you want to make an item through #b#p2040022##k somewhere around Ludibrium. Please choose what kind of an item you wish to have.#b",
							(8, " #t4131008#"),
							(9, " #t4131009#"));
					}
					else if (Job >= 300 && Job < 400)
					{
						askReward = AskMenu("Okay, this is an item that you'll need to have if you want to make an item through #b#p2040022##k somewhere around Ludibrium. Please choose what kind of an item you wish to have.#b",
							(10, " #t4131010#"),
							(11, " #t4131011#"));
					}
					else if (Job >= 400 && Job < 500)
					{
						askReward = AskMenu("Okay, this is an item that you'll need to have if you want to make an item through #b#p2040022##k somewhere around Ludibrium. Please choose what kind of an item you wish to have.#b",
							(12, " #t4131012#"),
							(13, " #t4131013#"));
					}
					
					int itemID = rewards[askReward];
					
					if (!Exchange(0, 4031078, -1, 4031088, -1, itemID, 1))
					{
						self.say("Hmm ... please leave space open in the etc. tab.");
						return;
					}
					
					AddEXP(3500);
					SetQuestData(1002301, "e");
					QuestEndEffect();
					self.say("Here's hoping the weapon I gave you turns out to be awesome. I found out that the 6th roly-poly worker is going through some trouble. You should go take a look at him. Thanks for your help. Now I can concentrate on my work. See you around.");
				}
				else if (quest == "10" && ItemCount(4031088) < 1)
				{
					self.say("Hmmm ... so you did meet up with all ten workers, but you lost the pictures along the way. You should have been careful... well there's no choice but to have to take the pictures again.");
						
					SetQuestData(1002301, "s");
				}
				else
				{
					if (ItemCount(4031078) >= 1)
					{
						self.say("Hmm, you haven't met with all 10 of my roly-poly workers, yet. They are all sent to Eos Tower for maintenance. I'm sure they're all working hard, but I need to have my eyes on them, though. Use the camera that I lent you to take pictures of each and every one of them, in order. Good luck!");
						return;
					}
					
					self.say("Hmmm ... did you lose my camera by any chance? You should have been careful... but don't worry, I always have some spares around. Please take this camera and head over to Eos Tower, where your job will be to take pictures of my roly-poly workers, from 1 through 10.");
					
					if (!Exchange(0, 4031078, 1))
					{
						self.say("Please leave a space open in the etc. tab for my camera.");
					}
				}
			}
		}
	}
}