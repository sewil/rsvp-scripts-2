using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Cheng()
	{
		string quest = GetQuestData(1002500);
		
		if (quest == "")
		{
			bool start = AskYesNo("Lately we've been experiencing a weird phenomenon where the machinery parts have been disappearing. We cannot operate the factory without the parts, so ... can you help us solve this case? You'll be well-rewarded for your work here.");
			
			if (!start)
			{
				self.say("Is that right? I guess you're busy granting favors from a lot of people. But if you feel a change of heart, we're ready to listen.");
				return;
			}
			
			SetQuestData(1002500, "s");
			self.say("Thank you. From the investigation we have conducted ourselves, the missing parts can be construed as a stranger walking into our factory and proceeding to hide the item somewhere. The parts need to be here so the factory can be run?should we go to where the parts are hidden as?");
			self.say("Alright, talk to me when you're ready, but seriously you know, you should not spend so much time here. If not, the parts can be hidden somewhere even deeper than before.");
		}
		else
		{
			int partCount = ItemCount(4031092);
			
			self.say("Okay, then. Inside this room, you'll see a whole lot of plastic barrels lying around. So hit the barrels to knock them down, and see if you can find the lost #b#t4031092##k inside. You'll need to collect #b10 #t4031092#s#k and then talk to me afterwards. There's a time limit on this! So go!");
				
			if (partCount >= 1)
			{
				if (!Exchange(0, 4031092, -partCount))
				{
					self.say("Hmm... are you trying to bring in some illegal materials?");
					return;
				}
			}
			
			if (FieldSet.Instances["Ludi020"].UserCount != 0 || !FieldSet.IsAvailable("Ludi020"))
			{
				self.say("Sorry, but it looks like someone else is in there looking for the barrels. Only one person is allowed in at a time, so you'll have to wait for your turn.");
				return;
			}
			
			SetQuestData(1002500, "s");
			FieldSet.Enter("Ludi020", new Character[1]{chr}, chr);
		}
	}
	
	private void Kim()
	{
		string quest = GetQuestData(1003000);
		
		if (quest == "s")
		{
			self.say("Hmmm...? Ohhhh~ #b#p2050001##k already told me about it, through a special device that connects Ludibrium and Omega Sector. The 3 Boxes of Parts that #p2050001# requested are ready here. I'll give those to you, but first make sure to have 3 slots of your etc. inventory available.");
			
			if (!Exchange(0, 4031095, 1, 4031096, 1, 4031097, 1))
			{
				self.say("Hmmm... are you sure you have 3 slots available in your etc. inventory? Please check and talk to me again.");
				return;
			}
			
			AddEXP(1600);
			SetQuestData(1003000, "1");
			self.say("So you got the 3 Boxes of Parts, right? All these Boxes of Parts contain machines that are very sensitive to pressure, so it may break on you easily. Make sure not to get ambushed by monsters on your way back to the Omega Sector, but I'm sure you can handle it just fine. I'll see you around~");
		}
		else if (quest == "1")
		{
			if (ItemCount(4031095) >= 1 && ItemCount(4031096) >= 1 && ItemCount(4031097) >= 1)
			{
				self.say("Please take these 3 Boxes of Parts and give them to #b#p2050001##k of the Omega Sector. I'm sure he's been sticking his neck out for this. These machines are all very delicate, so please be careful on your way there. I'll see you around~!");
				return;
			}
			self.say("Hmmm... did you lose the Boxes of Parts on your way back? Should have been more careful... but thankfully, the Boxes of Parts have the automatic-returning device created by \r\n#b#p2050001##k, so they are back here already. I'll give them to you once more, so please don't lose it this time!");
				
			if (ItemCount(4031095) < 1)
			{
				if (!Exchange(0, 4031095, 1))
				{
					self.say("Hmmm ... please make sure you have an empty space available in your etc. tab.");
					return;
				}
			}
			if (ItemCount(4031096) < 1)
			{
				if (!Exchange(0, 4031096, 1))
				{
					self.say("Hmmm ... please make sure you have an empty space available in your etc. tab.");
					return;
				}
			}
			if (ItemCount(4031097) < 1)
			{
				if (!Exchange(0, 4031097, 1))
				{
					self.say("Hmmm ... please make sure you have an empty space available in your etc. tab.");
					return;
				}
			}
		}
	}
	
	private bool Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1002500)
		{
			if (Level >= 30 && Job != 0 && info != "e")
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (quest == 1003000)
		{
			if (Level >= 30 && (info == "s" || info == "1"))
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
		string quest = GetQuestData(1002500);
		
		if (MapID == 220020000)
		{
			bool checkCheng = Check(1002500);
			bool checkKim = Check(1003000);
			
			if (checkCheng && checkKim)
			{
				AskMenuCallback("Lately we've been experiencing the disapperance of mechanical parts here at the factory, and we have no idea who's been committing this dastardly act. The factory can't run if the parts keep disappearing.#b",
					(" The Missing Mechanical Parts", Cheng),
					(" Delivering the Robotic Parts", Kim));
			}
			else if (checkCheng && !checkKim)
			{
				Cheng();
			}
			else if (!checkCheng && checkKim)
			{
				Kim();
			}
			else
			{
				if (quest == "e")
				{
					self.say("Thanks to you, the Toy Factory is working perfectly again. I'm so happy that you came to help us. We take good care of our extra parts, so don't worry. Well, that's that. I must return to work!");
				}
				else
				{
					self.say("Lately we've been experiencing the disapperance of mechanical parts here at the factory, and we have no idea who's been committing this dastardly act. The factory can't run if the parts keep disappearing.");
				}
			}
		}
		else if (MapID == 922000000)
		{
			if (quest == "e")
			{
				self.say("I don't know how to thank you for helping me. Thanks to your effort, the Toy Factory will be working just fine. I'll let you out now. Take care!");
					
				ChangeMap(220020000, "q000");
			}
			else
			{
				int partCount = ItemCount(4031092);
				
				if (partCount == 0)
				{
					AskMenu("Inside this room, you'll see a whole lot of plastic barrels lying around. So hit the barrels to knock them down and see if you can find the lost #b#t4031092##k. You'll need to collect #b10 \r\n#t4031092##k before the time limit expires and then talk to me afterwards. Time is running out while we talk, so please hurry up!#b",
						(0, " I want to get out of here."));
					
					bool exit = AskYesNo("Are you sure you want to give up? Well, I can let you out, but you'll have to start from the beginning next time you come here. Do you still want to leave this place?");
					
					if (!exit)
					{
						self.say("That's the kind of attitude I've been looking for! If you start something, you have to learn to finish it! Now, please search for the plastic barrels and find #b10 #t4031092##k for me.");
						return;
					}
					
					ChangeMap(922000009);
				}
				else if (partCount >= 10)
				{
					self.say("Nice work! You have managed to successfully collect #b10 \r\n#t4031092##k. Alright, since you have done us a huge favor, I'll reward you with something nice. Before doing that, please check and see if your use inventory has any room available.");
					
					if (SlotCount(2) < 1)
					{
						self.say("Hmm... your use inventory seems to be full at the moment. So you won't be able to receive my reward. Please free up space in your inventory and come talk to me again.");
						return;
					}
					
					int itemID = Random(new int[] {2040704, 2040705, 2040707, 2040708});
					
					if (!Exchange(0, 4031092, -partCount, itemID, 1))
					{
						self.say("Are you sure you have #b10 #t4031092#s#k? If so, see if your use inventory has any space available.");
						return;
					}
					
					AddEXP(2700);
					SetQuestData(1002500, "e");
					QuestEndEffect();
					self.say($"What do you think? Do you like the #b#t{itemID}##k that I gave you? I don't know how to thank you for helping me. Thanks to your effort, the Toy Factory will be working just fine. I'll let you out now. Take care!");
					
					ChangeMap(220020000, "q000");
				}
				else
				{
					AskMenu("I don't think you've collected 10 lost #b#t4031092#s#k. Break the plastic barrels that you see in this room and see if any of them contain the lost #b#t4031092##k. If you can get the 10 \r\n#b#t4031092##k before the time limit expires, then bring them to me. If you want to leave this place at any time, come talk to me.#b",
						(0, " I want to get out of here."));
					
					bool exit = AskYesNo("Are you sure you want to give up? Well, I can let you out, but you'll have to start from the beginning next time you come here. Do you still want to leave this place?");
					
					if (!exit)
					{
						self.say("That's the kind of attitude I've been looking for! If you start something, you have to learn to finish it! Now, please search for the plastic barrels and find #b10 #t4031092#s#k for me.");
						return;
					}
					
					ChangeMap(922000009);
				}
			}
		}
	}
}