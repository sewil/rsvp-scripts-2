using WvsBeta.Game;

// 2040017 Green Mesoranger
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(1004500);
		string quest2 = GetQuestData(1004501);
		string quest3 = GetQuestData(1004502);
		
		if (Level < 41)
		{
			self.say("I'm here taking care of a very important mission given to me by the Omega Sector. It is very dangerous around here, so I suggest you run right now.");
			return;
		}
		
		if (quest1 == "")
		{
			self.say("Roswell Plain is full of aliens wandering around, making it the most-watched zone for the Sector. The attacks are relentless, and it's still going on, so I suggest a regular person should just stay away from this area.");
			bool start = AskYesNo("I've heard about your performance through others in the Sector. From what I've heard, you're quite a strong person, and... you know what, why don't you and I take care of some missions as the member of the Mesorangers? Of course, the Sector will recognize your work and pay you accordingly.");
			
			if (!start)
			{
				self.say("I don't think this would necessarily do you any harm. If you have a change of heart, please talk to me. Until then, if you'll excuse me...");
				return;
			}
			
			SetQuestData(1004500, "100");
			self.say("Alright, here's the 1st mission. A few days ago, we received a word that #b#o4230119##k have been attacking innocent bystanders. It's our job to come out and lay a whopping on them.");
			self.say("Please take care of #b100 #o4230119#s#k for me. They actually wear helmets while shooting laser guns, so please be careful around them. I'll be here taking care of the other aliens.");
		}
		else if (quest1 == "e")
		{
			if (quest2 == "")
			{
				self.say("I keep getting new tasks thrown at me from the Sector, and I'm busy beyond belief as a result. I've been actually waiting for your arrival. The news is, the aliens threatening the Sector now are much more powerful than the #o4230119# that you've previously faced.");
				bool start2 = AskYesNo("The alien in question is #b#o4230120##k, and they are much higher ranked than #o4230119#, with the power to show for. What do you think? These may be much tougher than you've ever faced off against, but... will you do the honor of defeating each and every one of them?");
				
				if (!start2)
				{
					self.say("I don't think this would necessarily do you any harm. If you have a change of heart, please talk to me. Until then, if you'll excuse me...");
					return;
				}
				
				SetQuestData(1004501, "s");
				self.say("I knew you'd say yes. Somewhere around this field, you'll have to defeat #b#o4230120##k, and bring me the helmet it wears as a proof. Bring me #b100 #t4000121#s#k, and your mission will be deemed a success. Good luck!");
			}
			else if (quest2 == "s")
			{
				if (ItemCount(4000121) < 100)
				{
					self.say("I don't think you have completed the mission from the Sector, just yet. Please defeat the #b#o4230120##k that's been threatening the Sector's safety, as well as pick up #b100 #t4000121#s#k along the way as a proof. They are much more powerful and higher-classed, so please be careful on that. Good luck!");
					return;
				}
				
				self.say("You're back~ Wasn't #b#o4230120##k too difficult to handle? Let's \r\nsee... #b100 #t4000121#s#k, just as advertised. I'll send these to the Sector, and your mission will be deemed accomplished. Here...here's an item from the Sector. Please take it!");
				
				if (!Exchange(0, 4000121, -100, 2020009, 50))
				{
					self.say("Oh~ please make some room in your use inventory for this!");
					return;
				}
				
				AddEXP(5600);
				SetQuestData(1004501, "e");
				QuestEndEffect();
				self.say("Did you get the #b50 #t2020009#s#k? This mission sure is more difficult that the last one, but I'm sure you had an easy time completing it. There are still some missions left from the Sector, so whenever you have time, please talk to me, alright?");
			}
			else if (quest2 == "e")
			{
				if (quest3 == "")
				{
					bool start3 = AskYesNo("A few days ago, you helped me take care of my missions from the Sector, so I thought I'd be chilling around here for a while, but.. ooooo! I've been saddled with the toughest task, yet, and so... would you like to work with me one last time??");
					
					if (!start3)
					{
						self.say("This wouldn't be something that would do you any harm, so it's a tad disappointing that you said no. If you ever change your mind, however, please talk to me immediately. I've got some things to do, so if you'll excuse me.");
						return;
					}
					
					SetQuestData(1004502, "200");
					self.say("Thanks for saying yes! I remember you defeated #b#o4230120##k the other day, but the Sector wants more aliens gone from the Earth. I was also told to pick up the laser guns that they shoot, if they are available, like it's going to help them develop new types of weapons in the near future...");
					self.say("Please take out #b200 #o4230120#s#k, and collect  #b150 #t4000122#s#k by defeating Mecatians. The laser gun should be available through #b#o4230121##k. #o4230121# rides on a big bad robot, so please be careful of that. Good luck!");
				}
				else if (quest3 == "e")
				{
					self.say("The Roswell Plain is prone to aliens making apperances, so this place is under special constant watch. The attack is still on, so I suggest you and others not to get too comfortable in this place. I'll have to head back to the Sector for some more work, so I'll see you around!");
				}
				else
				{
					if (quest3 != "000")
					{
						self.say("I don't think you have completed the mission, yet. Please take out #b200 #o4230120#s#k and collect #b150 #t4000122#s#k before returning to this place.");
						return;
					}
					
					if (ItemCount(4000122) < 150)
					{
						self.say("I don't think you have collected all the #t4000122#s necessary. Please gather up #b150 #t4000122#s#k #o4230121#.");
						return;
					}
					
					self.say("What the? Are you telling me you've already taken out 200 \r\n#o4230120#s? And these ... yes, these really are 150 #t4000122#s. I was wondering how you were going to complete this mission all by yourself, but you took care of it just fine. Alright, here ... this is a very important item for me, but please take it.");
					
					int itemID = 0;
			
					if (Job >= 100 && Job < 200) itemID = 1082024;
					else if (Job >= 200 && Job < 300) itemID = 1082063;
					else if (Job >= 300 && Job < 400) itemID = 1082072;
					else if (Job >= 400 && Job < 500) itemID = 1082076;
					else itemID = 1082002;
					
					if (!Exchange(0, 4000122, -150, itemID, 1))
					{
						self.say("Please leave some room in your equip. inventory for this!");
						return;
					}
					
					AddEXP(6100);
					SetQuestData(1004502, "e");
					QuestEndEffect();
					self.say("Do you like the glove? I've kept this for a while, and I was planning on using it someday, but it looks much better on you. Please put it to good use; besides, I got so much stuff from the Sector, that I don't need it anymore.");
					self.say("Thank you so much for fulfilling your missions as one of the Mesorangers. I've told the Sector about your successful story, and the Sector seems to be very pleased with you, too. Hopefully you'll keep working with us. Bye~");
				}
			}
		}
		else
		{
			if (quest1 != "000")
			{
				self.say("I don't think you have completed the mission just yet. Please take out the aliens that attack innocent people, they being #o4230119#. Your job is to eliminate #b100 #o4230119#s#k.");
				return;
			}
			
			self.say("You're back!!! I can't believe you completed this mission as well as you did just now. I mean, the aliens you faced were quite dangerous, to say the least. You're just as advertised. I feel like I can work with you from here on out. Here, this isn't much, but please put this to good use.");
			
			if (!Exchange(20000))
			{
				self.say("Hmm... how strange... You can't carry any money with you?");
				return;
			}
			
			AddEXP(5100);
			SetQuestData(1004500, "e");
			QuestEndEffect();
			self.say("What do you think about the 20,000 Mesos? This mission must have been a piece of cake for you. Rest assured, there are still plenty of missions to take care of. The aliens attack day and night, everyday. You know who to talk to whenever you have some time available, right? I'll be here waiting.");
		}
	}
}