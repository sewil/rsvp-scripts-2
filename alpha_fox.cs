using System;
using WvsBeta.Game;

//2020003 Master Sergeant Fox
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1001400);
		
		if (Level < 40)
		{
			self.say("Because of an accident, all my men have been separated and spread out everywhere. I hope they're alright.");
			return;
		}
		
		if (quest.Contains("end"))
		{
			self.say("Oh... thanks for locating all my men for me the other day. Have you ever run into any one of them since? If not, then you should go see them. They may ask you for some help.");
			return;
		}
		
		if (quest == "")
		{
			self.say("Hey! Attention! Oh, I'm sorry ... If you're not busy and all, can I ask you for help? Let me introduce myself. I am #b#p2020003##k from the Alpha platoon. We got on the aeroboat to get here to complete an important mission when there was an accident on the plane. We all had to parachute our way down.");
			bool askStart = AskYesNo("The problem is, I can't find any of my men that I parachuted with around here. We were supposed to gather up here, but days have passed and I still haven't heard a word from my men. Because of that, can you find them for me? They are all over Ossyria, scattered everywhere. I'm not asking you to do this for free, of course. I'll reward you for your hard work.");
			
			if (!askStart)
			{
				self.say("I guess you're really busy right now. But, if you ever find time later on, you'll be most welcome to come back here. My men ... if I am not there, they may just goof off and therefore, I'm worried much about them.");
				return;
			}
			
			SetQuestData(1001400, "s");
			self.say("Thank you! The three members from my platoon I need to find are #b#p2010000#, #p2030002# and #p2030001##k all three of them. I have a favor to ask, though. Instead of finding them randomly, can you find them according to the #rorder of the ranks#k? Of course you should know which rank is low and which one is high, right? hahaha");
			self.say("Since they have made emergency landings all over Ossyria following through with the operation, it'll require you to search every corner of this place, be it towns, fields, etc. Please see my men from the highest rank down, and if they have something for me, please take them and give them to me in the end. I'll be waiting you then. Good luck!");
		}
		else if (quest.Contains("3"))
		{
			bool order = false;
			bool scroll = false;
			
			if (quest == "123")
			{
				self.say("So you did meet up with my men. That was much quicker than I expected. Let's see ... you met up with them from the lowest rank up, that's totally the wrong order! Corporal is the lowest, then Sergeant, and then Staff Sergeant ... #b#p2010000#, #p2030001# and #p2030002##k was the right order.");
			}
			else if (quest == "132")
			{
				self.say("So you did meet up with my men. That was much quicker than I expected. Let's see ... you met up with them in the wrong order... Corporal is the lowest, Staff Sergeant is the highest, then Sergeant is in the middle ... #b#p2010000#, #p2030001# and #p2030002##k was the right order.");
			}
			else if (quest == "213")
			{
				self.say("So you did meet up with my men. That was much quicker than I expected. Let's see ... you met up with them in the wrong order... Sergeant is in the middle, Corporal is the lowest, then Staff Sergeant is the highest ... #b#p2010000#, #p2030001# and #p2030002##k was the right order.");
			}
			else if (quest == "231")
			{
				self.say("So you did meet up with my men. That was much quicker than I expected. Let's see ... you met up with them in the wrong order... Staff Sergeant is the highest, Corporal is the lowest, then Sergeant is in the middle ... #b#p2010000#, #p2030001# and #p2030002##k was the right order.");
			}
			else if (quest == "312")
			{
				self.say("So you did meet up with my men. That was much quicker than I expected. Let's see ... you met up with them in the wrong order... Sergeant is in the middle, Staff Sergeant is the highest, then Corporal is the lowest ... #b#p2010000#, #p2030001# and #p2030002##k was the right order.");
			}
			else if (quest == "321")
			{
				order = true;
				self.say("So you did meet up with my men. That was much quicker than I expected. Let's see ... and you met up with them from the highest rank down! Good, Staff Sergeant is the highest, then Sergeant, and then the Corporal ... #b#p2010000#, #p2030001# and #p2030002##k was the right order, just the way you did it.");
			}
			
			self.say("By the way, didn't the men give you #b#t4031049##k? We're actually here to find those pieces of documents. I can't tell you how this will be used because it's a top secret, but if my men are doing their job, I should have 3 pieces with me. They did tell you to give them to me, right? Let's see how they did...");
			
			if (ItemCount(4031049) < 3)
			{
				self.say("Maybe my men aren't working hard like I thought! Hahaha, thank you so much for checking up on them. Finding out that my men are okay gives me relief, enough so I can go on with the operation. Oh yes, this is just a token of my appreciation for your hard work. Please take it.");
			}
			else
			{
				scroll = true;
				self.say("My men ARE working hard, indeed! Hahaha, thank you so much for getting all of them. Finding out that my men are actually working hard gives me relief, enough so I can go on with the operation. Oh yes, this is just a token of my appreciation for your hard work. Please take it.");
			}
			
			if (!scroll)
			{
				if (!order)
				{
					chr.AddMesos(25000);
					AddEXP(1000);
					AddFame(1);
					SetQuestData(1001400, "end3");
				}
				else
				{
					chr.AddMesos(50000);
					AddEXP(7000);
					AddFame(1);
					SetQuestData(1001400, "end4");
				}
				
				QuestEndEffect();
				self.say("Do you like what I'm giving you? What do you think? I hope it helps you on your journey. And please drop by and check on my men from time to time. They are still quite inexperienced and may need help down the road. Thanks.");
			}
			else
			{
				if (SlotCount(2) < 1)
				{
					self.say("Please check if your inventory is full...");
					return;
				}
				
				Random rnd = new Random();
				
				if (!order)
				{
					if (SlotCount(2) < 1)
					{
						self.say("Hold on there, you need a free slot in your use inventory!");
						return;
					}
					
					int[] reward = {2040401, 2040402, 2040504, 2040505, 2040601, 2040602};
				
					int newItemID = reward[rnd.Next(reward.Length)];
					
					if (!Exchange(0, 4031049, -3, newItemID, 1))
					{
						self.say("Please check if your inventory is full...");
						return;
					}
					
					AddEXP(1000);
					AddFame(1);
					SetQuestData(1001400, "end2");
					QuestEndEffect();
					self.say($"Do you like what I'm giving you, the #b#t{newItemID}##k? What do you think? I hope it helps you on your journey. And please drop by and check on my men from time to time. They are still quite inexperienced and may need help down the road. Thanks.");
				}
				else
				{
					if (SlotCount(2) < 1)
					{
						self.say("Hold on there, you need a free slot in your use inventory!");
						return;
					}
					
					int[] reward = {2040704, 2040705, 2040707, 2040708};
				
					int newItemID = reward[rnd.Next(reward.Length)];
					
					if (!Exchange(0, 4031049, -3, newItemID, 1))
					{
						self.say("Please check if your inventory is full...");
						return;
					}
					
					AddEXP(7000);
					AddFame(1);
					SetQuestData(1001400, "end1");
					QuestEndEffect();
					self.say($"Do you like what I'm giving you, the #b#t{newItemID}##k? What do you think? I hope it helps you on your journey. And please drop by and check on my men from time to time. They are still quite inexperienced and may need help down the road. Thanks.");
				}
			}
		}
		else
		{
			self.say("Ohhh ... looks like you haven't met all three of my men. Harder than you thought...right? Please meet them in the order of ranks from the highest. I'm sure you can figure that out by yourself.");
		}
	}
}