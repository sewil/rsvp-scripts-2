using WvsBeta.Game;

// 2041012 Pink Mesoranger
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(1003300);
		string quest2 = GetQuestData(1003301);
		string quest3 = GetQuestData(1003302);
		
		if (Level < 38)
		{
			self.say("Hello, there. I'm #b#p2041012##k of Omega Sector, currently in a secret mission to prevent the alien invasion here. I've been really busy these days taking care of important missions. This place is very dangerous, so I suggest you get out of here and go to a safer place.");
			return;
		}
		
		if (quest1 == "")
		{
			bool start = AskYesNo("Phew... I can't believe it, but I've overslept AGAIN. I've been late to work so many times, that now I don't think my boss likes me one bit. I'm in a tight spot not as a result. That's why, I'd like to ask you for some help. Will you help me out?");
			
			if (!start)
			{
				self.say("Hmmm... you must be busy from doing a lot of things, but if you ever find yourself some free time, please come talk to me. I have something very important to ask you for...");
				return;
			}
			
			SetQuestData(1003300, "s");
			self.say("Thank you. The thing is, I sleep a lot, and I get told on that, as a result. Even if I'm the best at what I do, there's no point of all that if I don't wake up on time, you know. That's why lately, I've been hearing it a lot from upstairs. Please help me wake up on time...");
			self.say("I heard that deep in the Ludibrium Clocktower, a monster by the name of #b#o4230113##k gives off #b#t4000114##k when it dies! Please collect 20 of them for me. I feel like, with 20 alarm clocks going off at once, even someone like me may be able to wake up on time! Good luck!!");
		}
		else if (quest1 == "s")
		{
			if (ItemCount(4000114) < 20)
			{
				self.say("I don't think you have the clocks that I requested, just yet. Deep in the Ludibrium Clocktower, you'll find a monster called #b#o4230113##k. Defeat it, and collect 20 #b#t4000114#s#k for me. That'll probably help me overcome my oversleeping habits.");
				return;
			}
			
			self.say("Hey! Isn't this #b#t4000114##k? I can't believe you brought them all here!! Alright, then, I feel like I can wake up early and on time from here on out! Anyway, for your tireless effort, I need to hook you up with something. Before that, though, please check and see if your use inventory has any room available.");
			
			if (!Exchange(0, 4000114, -20, 2020007, 50))
			{
				self.say("Please leave some room available in your use inventory.");
				return;
			}
			
			AddEXP(4200);
			SetQuestData(1003300, "e");
			QuestEndEffect();
			self.say("How do you like the #b50 #t2020007#s#k? I've had this food just to fight off the boredom while on a mission. I really cherish this food, but I think it's all worth it if you're the one eating them. Thank you so much for your help. I may have something else to ask you later, so please drop by from time to time again.");
		}
		else if (quest1 == "e")
		{
			if (quest2 == "")
			{
				bool start2 = AskYesNo("Hey, you're the one that helped me gather up #t4000114# so I can actually wake up on time! I have to say, I thank you for your work that day, but the problem is... those clocks all got busted after a short while. I have another favor to ask... will you help me out?");
				
				if (!start2)
				{
					self.say("Hmmm... you must be busy from doing a lot of things, but if you ever find yourself some free time, please come talk to me. I have something very important to ask you for...");
					return;
				}
				
				SetQuestData(1003301, "s");
				self.say("Nice! Thanks! I would really like to get a hold of a powerful clock that lasts for a long time. In order to make that clock, I'll need the following materials: #b2 Special Batteries, 10 #t4000115#s, and 10 #t4000114#s#k. With these, I feel like I can make the ultimate alarm clock!");
				self.say("You can find all of them at the Ludibrium Clocktower. #b#t4031115##k can be found through a robot-looking monster, #b#t4000115##k through Chronos, and #b#t4000114##k through Tick-Tocks. I'll be here waiting for good news. Good luck!~~!");
			}
			else if (quest2 == "s")
			{
				if (ItemCount(4031115) < 2 || ItemCount(4000114) < 10 || ItemCount(4000115) < 10)
				{
					self.say("I don't think you have gathered up the materials I asked you to get, just yet. Please take out the monsters at the Ludibrium Clocktower and bring back #b2 Special Batteries, 10 \r\n#t4000115#s, and 10 #t4000114#s#k for me, so I can make myself the ultimate alarm clock!");
					return;
				}
				
				self.say("I can't believe you brought them all. You must be something special...!!! I feel that with these great materials to work with, I'll finally make the ultimate alarm clock!! Thank you so much for all your effort. Here, I'll give you some food in case of an emergency.");
				
				if (!Exchange(0, 4031115, -2, 4000115, -10, 4000114, -10, 2020008, 50))
				{
					self.say("Please leave some room in your use inventory first.");
					return;
				}
				
				AddEXP(5500);
				SetQuestData(1003301, "e");
				QuestEndEffect();
				self.say("What do you think about the #b50 #t2020008#s#k that I gave you? I've had this food just to fight off the boredom while on a mission. I really cherish this food, but I think it's all worth it if you're the one eating them. Thank you so much for your help. I may have something else to ask you later, so please drop by from time to time again.~");
			}
			else if (quest2 == "e")
			{
				if (quest3 == "")
				{
					bool start3 = AskYesNo("Arrggh, I was actually waiting for you!! I worked so hard trying to build the ultimate alarm clock, and they were not easy at all. While doing all this, I found something I'll need help on. Can you please help me out one last time?");
					
					if (!start3)
					{
						self.say("Hmmm... you must be busy from doing a lot of things, but if you ever find yourself some free time, please come talk to me. I have something very important to ask you for...");
						return;
					}
					
					SetQuestData(1003302, "s");
					self.say("You should be a busy person to begin with, but you're still finding some time to help me out. Thank you so much. Anyway, I wrote down how to assemble the clock, and I sent it to #b#p2050011##k of Omega Sector. It's been a week since then, and the clock should be completed by now.");
					self.say("He told me to pick up the clock after a week, but I am still not done with this mission, and that's why I keep finding myself waking up late, again and again. Anyway, please head over to the Omega Sector and pick up the Alarm Clock from#b Kevin the Soldier#k for me, okay?");
				}
				else if (quest3 == "s")
				{
					self.say("I don't think you have found #b#t4031108##k, yet. The parts you gave me the other day, those have been sent to #b#p2050011##k of the Omega Sector. The clock should be done by now, but I can't move one bit thanks to the fact that I'm in the middle of work. Please get that Clock for me...");
				}
				else if (quest3 == "1")
				{
					if (ItemCount(4031108) < 1)
					{
						self.say("I don't think you have found #b#t4031108##k, yet. The parts you gave me the other day, those have been sent to #b#p2050011##k of the Omega Sector. The clock should be done by now, but I can't move one bit thanks to the fact that I'm in the middle of work. Please get that Clock for me...");
						return;
					}
					
					self.say("Whoaaaaa! This is one incredible alarm clock!! Isn't he good? I didn't know he was this good... I truly feel that with this clock, I will never oversleep in the mornings anymore! Thank you so much for all your hard work. For your reward, I'll give you some items that I received from the Sector. Please take it.");
					
					if (!Exchange(0, 4031108, -1, 2030011, 3, 2030012, 3))
					{
						self.say("Please make sure there are at least two slots available in your use inventory first.");
						return;
					}
					
					AddEXP(3200);
					SetQuestData(1003302, "e");
					QuestEndEffect();
					self.say("I can't thank you enough for helping me out this much. I feel like I won't ever hear the heat from my boss anymore, and I also feel like I'm going to work harder from here on out. Now, I need to take care of my mission, so I'll have to leave now. Bye~~!");
				}
				else if (quest3 == "e")
				{
					self.say("You're back~ I've been getting up on time these days, and I'm never late on missions. I'm also glad the people upstairs are taking notice. It's all thanks to you. Now, I have something important to do, so please excuse me~");
				}
			}
		}
	}
}