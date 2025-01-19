using WvsBeta.Game;
using WvsBeta.Game.GameObjects;

public class NpcScript : IScriptV2
{
	private void Dollhouse()
	{
		self.say("Alright! I'll take you to a room, where you'll find a number of dollhouses all over the place. One of them will look slightly different from the others. Your job is to locate it and break its door. If you locate it correctly, you'll find #b#t4031094##k. If you break a wrong dollhouse, however, you'll be sent out here without warning, so please be careful on that.");
		self.say("You'll also find monsters in there, and they have gotten so powerful thanks to the monster from the other dimension that you won't be able to take them down. Please find \r\n#b#t4031094##k within the time limit and then notify #b#p2040028##k, who should be inside. Let's get this started!");
		
		int pendulums = ItemCount(4031094);
		
		if (pendulums > 0)
		{
			if (!Exchange(0, 4031094, -pendulums))
			{
				self.say("Hmm... are you trying to bring in some illegal materials?");
				return;
			}
		}
		
		if (FieldSet.Instances["Ludi023"].UserCount != 0 || !FieldSet.IsAvailable("Ludi023"))
		{
			self.say("Someone else must be inside searching for the dollhouse. Unfortunately, I can only let one person in at a time, so please wait your turn.");
			return;
		}
		
		SetQuestData(1002601, "s");
		FieldSet.Enter("Ludi023", new Character[1]{chr}, chr);
	}
	public override void Run()
	{
		string quest1 = GetQuestData(1002600);
		string quest2 = GetQuestData(1002601);
		string quest3 = GetQuestData(1002602);
		string quest4 = GetQuestData(1002603);
		
		if (quest1 != "e")
		{
			self.say("We're the toy soldiers who guard this room to prevent anyone else from entering. I can't tell you why. Now, if you'll excuse me, I have work to do.");
			return;
		}
		
		if (quest2 == "")
		{
			self.say("Hmmm...I've heard a lot about you through #b#p2040001##k. You got him a bunch of #b#t4031093##k so he can fight off boredom at work. Well ... alright, then. There's a dangerous, dangerous monster inside. I want to ask you for help in regards to locating it. Would you like to help me out?");
			self.say("Actually, #b#p2040001##k asked you to get #b#t4031093#s#k as a way of testing your abilities to see if you can handle this, so don't think of it as a random request. I think someone like you can handle adversity well.");
			bool start = AskYesNo("A while ago, a monster came here from another dimension thanks to a crack in dimensions, and it stole the pendulum of the clock. It hid itself inside the room over there camouflaged as a dollhouse. It all looks the same to me, so there's no way to find it. Would you help us locate it?");
			
			if (!start)
			{
				self.say("I understand. It's totally understandable, considering the fact that you'll be facing a very dangerous monster. If you ever change your mind, come and talk to me again. I'm certain that your assistance will be very helpful.");
				return;
			}
			
			SetQuestData(1002601, "s");
			Dollhouse();
		}
		else if (quest2 == "e")
		{
			if (chr.Level < 33)
			{
				self.say($"Thanks to {chr.Name}, we have recovered the #b#t4031094##k and destroyed the monster from the other dimension. Thankfully we haven't found another one like that since. I don't know how to thank you for helping us. Hope you have a great time here at Ludibrium!");
				return;
			}
			
			if (quest3 == "")
			{
				self.say("It's been a while since we last met. Thanks to you, there hasn't been anything strange going on here ever since. I have another favor to ask you, though.");
				self.say("I've been thankful for you getting the #b#t4031094##k for me. The problem is, the person that is in charge of putting \r\n#b#t4031094##k in the right place is far and far away at this point. Help us find the #b#p2040029##k first and give him the \r\n#t4031094#.");
				self.say("From what I know, #b#p2040029##k is currently at the #bLost Time#k, deep in the Ludibrium Clocktower. Lots of tough monsters reside there, but please find him ASAP for the sake of Ludibrium and give him the #b#t4031094##k that I'm about to give you. Good luck...");
				
				if (!Exchange(0, 4031094, 1))
				{
					self.say("Please leave some space available in your etc. inventory.");
					return;
				}
				
				SetQuestData(1002602, "s");
			}
			else if (quest3 == "s")
			{
				if (quest4 == "")
				{
					if (ItemCount(4031094) >= 1)
					{
						self.say("Please get this #b#t4031094##k to #b#p2040029##k, who should be at the deepest part of the Ludibrium Clocktower, the #bLost Time#k. Only he can put it where it should be. Be prepared, for you're guaranteed to face some tough monsters on your way there.");
						return;
					}
					
					self.say("I can't believe you lost such an important item. Good thing I found it. Please don't lose it next time!");
					
					if (!Exchange(0, 4031094, 1))
					{
						self.say("Please leave some space available in your etc. inventory.");
					}
				}
				else if (quest4 == "s")
				{
					self.say("Please get this #b#t4031094##k to #b#p2040029##k, who should be at the deepest part of the Ludibrium Clocktower, the #bLost Time#k. Only he can put it where it should be. Be prepared, for you're guaranteed to face some tough monsters on your way there.");
				}
				else if (quest4 == "e")
				{
					self.say("You must have found #b#p2040029##k deep in the clocktower and gave him #b#t4031094##k. I just heard from a colleague that the Ludibrium Clocktower is back up and running! I'm so glad things ended up this way. For your great work, I'll have to reward you well for this. Please accept this!");
					
					int[] rewards = {2043001, 2043101, 2043201, 2044001, 2044101, 2044201, 2044301, 2044401, 2043701, 2043801, 2044501, 2044601, 2043301, 2044701};
					
					int askReward = 0;
					
					if (Job < 200)
					{
						askReward = AskMenu("Here, please choose the scroll of your choice. The success rate is 60% for all.#b",
							(0, " #t2043001#"),
							(1, " #t2043101#"),
							(2, " #t2043201#"),
							(3, " #t2044001#"),
							(4, " #t2044101#"),
							(5, " #t2044201#"),
							(6, " #t2044301#"),
							(7, " #t2044401#"));
					}
					else if (Job >= 200 && Job < 300)
					{
						askReward = AskMenu("Here, please choose the scroll of your choice. The success rate is 60% for all.#b",
							(8, " #t2043701#"),
							(9, " #t2043801#"));
					}
					else if (Job >= 300 && Job < 400)
					{
						askReward = AskMenu("Here, please choose the scroll of your choice. The success rate is 60% for all.#b",
							(10, " #t2044501#"),
							(11, " #t2044601#"));
					}
					else if (Job >= 400 && Job < 500)
					{
						askReward = AskMenu("Here, please choose the scroll of your choice. The success rate is 60% for all.#b",
							(12, " #t2043301#"),
							(13, " #t2044701#"));
					}
					
					int itemID = rewards[askReward];
					
					if (!Exchange(0, itemID, 1))
					{
						self.say("Please leave an available space in your use inventory!");
						return;
					}
					
					AddEXP(3100);
					SetQuestData(1002602, "e");
					QuestEndEffect();
					self.say("Hopefully #b#t{itemID}##k will do you some good. Now that the monsters from other dimensions are gone, and the Ludibrium Clocktower is working fine, we may actually live in peace. Thank you so much for all your hard work. We may meet again someday. Cheers!");
				}
			}
			else if (quest3 == "e")
			{
				self.say("You're the one that not only defeated the monster from the other dimension, but also helped us fix the Ludibrium Clocktower. I can't thank you enough for all your hard work. Thanks to you, everything is alright now. Hope you have a great time here at Ludibrium!");
			}
		}
		else
		{
			Dollhouse();
		}
	}
}