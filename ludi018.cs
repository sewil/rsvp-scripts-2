using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string nemi1 = GetQuestData(1002300);
		string nemi2 = GetQuestData(1003800);
		string nemi3 = GetQuestData(1003801);
		string nemi4 = GetQuestData(1003802);
		
		if (nemi1 == "")
		{
			bool start = AskYesNo("My father may be waiting for me by now. I have so many chores to take care of here ... I have a favor to ask you regarding my father... will you help us out?");
			
			if (!start)
			{
				self.say("I see ... you must be swamped with other things yourself. If you ever find some time, then please come talk to me. I can always use some help, you know~");
				return;
			}
			
			if (!Exchange(0, 2020021, 1))
			{
				self.say("You'll need a free space in your use inventory to take the lunchbox!");
				return;
			}
			
			SetQuestData(1002300, "s");
			self.say("Thank you so much~ My father is the manager of the Toy Factory inside the Ludibrium Clocktower, and I think he forgot to pack his lunch today. I am hoping you can deliver this to my father for me.");
		}
		else if (nemi1 == "s")
		{
			if (ItemCount(2020021) >= 1)
			{
				self.say("I don't think you have met my father yet. He is the manager of the Toy Factory which is inside the Ludibrium Clocktower. Please get this lunchbox to him as soon as possible. He must be starving by now. Thanks~");
				return;
			}
			
			self.say("I think you may have lost the lunchbox somewhere on the way. Or ... you may have had a hard time resisting the smell of it and ate it yourself. Well, that's okay. I'll make you another one, and pleaaaase don't lose it this time. My father should be starving by now.");
			
			if (!Exchange(0, 2020021, 1))
			{
				self.say("You'll need a free space in your use inventory to take the lunchbox!");
				return;
			}
		}
		else if (nemi1 == "e")
		{
			if (Level < 28)
			{
				self.say("Hello~! Thanks to you, my dad got his appetite back. He really enjoys it. How can I help you today? Oh no!!! You shouldn't enter this place with your shoes on! I cleaned up this place just now, you know!!! If you don't have much else to do, then please come back some other time!");
				return;
			}
			
			if (nemi2 == "")
			{
				bool start2 = AskYesNo("So much work to do at home... oh, hello there... What are you doing here? Oh, oh yeah! If it's all right with you, can you help me out a little? I have to do something for my father, but I have no time to do it with all these chores to take care of.");
				
				if (!start2)
				{
					self.say("I see ... you must be swamped with other things yourself. If you ever find some time, then please come talk to me. I can always use some help, you know~");
					return;
				}
				
				SetQuestData(1003800, "s");
				self.say("Oh, thank you~! Actually it seems like my father has been working really hard lately, with an overwhelming number of new orders for toys. He's been leaving before dawn, and comes home before midnight, so I've decided to make him a special dinner, but I don't have anything to work with right now?");
				self.say("Head over to Eos Tower and you'll see a monster called \r\n#b#o3110102##k. Take them out and please gather up #b10 #t4031129#s#k. Their cheese is supposed to be top-notch. I feel like I can make the best soup in the world with that chesse, you know? Well, good luck~~");
			}
			else if (nemi2 == "s")
			{
				if (ItemCount(4031129) < 10)
				{
					self.say("Hmmm ... I don't think you have gathered up #b#t4031129##k yet. Please head over to Eos Tower and defeat the #b#o3110102##k, then gather up #b10 #t4031129#s#k for me. I feel like I'll be the best cook in the world with that cheese.");
					return;
				}
				
				self.say("Hey, you're back! Yes! That's the cheese I was talking about! With this, I think I can make a hearty bowl of soup that my father will really enjoy after a long day at work. Thank you so much for helping me out again. I'll have to reward you for this. I hope you like it...");
				
				if (!Exchange(0, 4031129, -10, 2020004, 100))
				{
					self.say("Please make some room in your use inventory so I can reward you~");
					return;
				}
				
				AddEXP(1150);
				SetQuestData(1003800, "e");
				QuestEndEffect();
				self.say("Do you like the #b100 #t2020004#s#k that I gave you? Now that I've gotten the ingredients and all, I'll have to start working on this soup. My father is coming soon, and I'll need to start this now in order for him to enjoy it the moment he gets here. Thank you so much for your help! Now, if you'll excuse me...");
			}
			else if (nemi2 == "e")
			{
				if (nemi3 == "")
				{
					bool start3 = AskYesNo("Hi~ It's sunny here today. I can't tell you how much I love the fact that it's sunny here 365 days a year. How's it going? Are you here just to say hi? Well, if that's so... then can you help me out one more time...?");
					
					if (!start3)
					{
						self.say("I see ... you must be swamped with other things yourself. If you ever find some time, then please come talk to me. I can always use some help, you know~");
						return;
					}
					
					SetQuestData(1003801, "s");
					self.say("Thank you so much~! This one's also on the fact that I don't have anything to cook with at home. My dad works everyday, and I want to make something healthy as well as delicious for his lunch today, but I have nothing to work with at home. My dad seems to be losing his appetite, so I need something better than usual.");
					self.say("Head over to Eos Tower and you'll see a monster called \r\n#b#o3230308##k hanging around at the outer wall. They cough up #t4000116#, so please gather up #b15 #t4000116#s#k. They are full inside, and tasty like no other. It can be used on a variety of dishes, so ... good luck!");
				}
				else if (nemi3 == "s")
				{
					if (ItemCount(4000116) < 15)
					{
						self.say("I don't think you have the stuff I asked for, yet. Defeat the \r\n#b#o3230308#s#k, who are usually located at the outer wall of Eos Tower, and collect #b15 #t4000116#s#k in the process. That will make me look like a great cook in a hurry!");
						return;
					}
					
					self.say("Hey, you're back! That's it! That's what I was looking for! My father will love it when he sees it in his lunchbox! Thank you so much, yet again. Here, this is an item that I truly cherish, and it's for you. Hope you like it.");
					
					if (!Exchange(0, 4000116, -15, 1032006, 1))
					{
						self.say("Please make some room in your equip. inventory so I can reward you~");
						return;
					}
					
					AddEXP(1650);
					SetQuestData(1003801, "e");
					QuestEndEffect();
					self.say("Do you like the #b#t1032006##k? Now that I have the ingredients ready, I'll have to get back to cooking now. I can literally see my dad drooling over this as we speak. Thank you so much for you help. I'll have to go now. See you around!");
				}
				else if (nemi3 == "e")
				{
					if (nemi4 == "")
					{
						bool start4 = AskYesNo("Oh no... what should I do? oh hi!! You came by again! I have run into yet another problem. I am so sorry that I keep asking you for favors, but I seriously can't find a way to wiggle out of this by myself. Can you help me out??");
						
						if (!start4)
						{
							self.say("I see ... you must be swamped with other things yourself. If you ever find some time, then please come talk to me. I can always use some help, you know~");
							return;
						}
						
						SetQuestData(1003802, "s");
						self.say("Thank you. I am sure you're terribly busy but still. Well, here's a problem. It has happened before, but it has happened much more often lately. Every time I make food, it disappears. I am sure it's the rats, but I can't prove it.");
						self.say("I work hard at making the best food possible, and as soon as I leave, even for a few minutes, the food just disappears. It's so disheartening. The thing is ... this has happened before, and because of that, I got some #o3110102#s as a toy rat, and I set up rat traps on them to catch rats.");
						self.say("But as you can see, they have since turned into monsters and are attacking people now. It's all my fault... and because of that... can you go back to Eos Tower and defeat #b#o3110102##k? Please gather up #b45 #t4000095#s#k afterwards, and do it ASAP. Thank you.");
					}
					else if (nemi4 == "s")
					{
						if (ItemCount(4000095) < 45)
						{
							self.say("Please head over to Eos Tower and collect #b45 #t4000095#s#k by defeating the #b#o3110102##k so I can chase off the rats from my food. I'll have to get the #t4000095#s back from the rats. Thanks again!");
							return;
						}
						
						self.say("Oh no, those rats must have taken my lunch ... whoa, hello! You're back already! That's much faster than I thought!\r\nSigh ... I'm just glad it's over now. With these traps, I can at least surround my food with them. This may not seem like much, but please accept it. Thanks.");
						
						int itemID = 0;
						
						if (Job >= 100 && Job < 200) itemID = 1002023;
						else if (Job >= 200 && Job < 300) itemID = 1002036;
						else if (Job >= 300 && Job < 400) itemID = 1002163;
						else if (Job >= 400 && Job < 500) itemID = 1002174;
						else itemID = 1002097;
						
						if (!Exchange(0, 4000095, -45, itemID, 1))
						{
							self.say("Please make some room in your equip. inventory so I can reward you~");
							return;
						}
						
						AddEXP(2150);
						SetQuestData(1003802, "e");
						QuestEndEffect();
						self.say("Do you like the hat that I gave you? I've been saving up the hat in case I venture outside Ludibrium, but it looks like you need it more than I do right now. Now I'll have to set these traps up before making the dinner. I'll see you around!");
					}
					else if (nemi4 == "e")
					{
						self.say("Hello~! Thanks to you, my dad got his appetite back. He really enjoys it. How can I help you today? Oh no!!! You shouldn't enter this place with your shoes on! I cleaned up this place just now, you know!!! If you don't have much else to do, then please come back some other time!");
					}
				}
			}
		}
	}
}