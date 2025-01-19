using System;
using System.Collections.Generic;
using WvsBeta.Game;
using WvsBeta.Common;

public class NpcScript : IScriptV2
{
	private void GivePresent(int box)
	{
		int open = AskMenu("I see that you have some presents there... great job, kid! How many presents would you like to give me?#b",
			(0, " 10 boxes"),
			(1, " 20 boxes"),
			(2, " 40 boxes"),
			(3, " 50 boxes"),
			(4, " 100 boxes"),
			(5, " I have no idea which boxes I should give you."),
			(6, " No, I don't want to trade."));
		
		if (open == 5)
		{
			self.say("If you're level 10-20, you'll need to find the #bRed and Green presents#k. If you're level 21-30, you'll need to find the #bRed and White presents#k. If you're level 31-40, you'll need to find the #bRed and Blue presents#k. If you're level 41-60, you'll need to find the #bBlue and White presents#k. If you're level 61 or above, you'll need to find the #bGreen and White presents#k.");
		}
		else if (open == 6)
		{
			self.say("OK... Please feel free to come back if you want.");
		}
		else
		{
			bool trade = false;
			
			switch(open)
			{
				case 0: trade = Exchange(0, box, -10, 2000000, 50); break;
				case 1: trade = Exchange(0, box, -20, 2000003, 30, 2000001, 30); break;
				case 2: trade = Exchange(0, box, -40, 2000002, 30, 2010004, 30); break;
				case 3: trade = Exchange(0, box, -50, 2000006, 30); break;
				case 4: trade = Exchange(0, box, -100, 2000005, 30); break;
			}
			
			if (!trade)
			{
				self.say("Hmm, you're going to need more presents if you really want to help out Maple Claws!");
				return;
			}
			
			SetQuestData(8020023, "end");
			QuestEndEffect();
			self.say("Thank you so much, remember to come back if you find more presents!");
		}
	}
	
	private void CollectPresent(string quest)
	{
		if (Level < 10)
		{
			self.say("Hey, sorry, but I don't think you're strong enough to help me right now.");
			return;
		}
		
		if (quest == "")
		{
			bool start = AskYesNo("How's it going? I'm a little out of sorts, if you can help me, I'll thank you, Maple Claws style.");
			
			if (!start)
			{
				self.say("How rude! Forget it. I'm definitely going to put coal in your stocking...");
				return;
			}
			
			self.say("Thank you so soo much. I was making my deliveries like usual when I saw this giant Red Balrog flying, I was so scared that I almost jumped out of my own skin! He started to attack me! I managed to defend myself and fend off that crazy creature, but the presents ended up scattering everywhere and now the monsters have them.");
			self.say("I need you to find all the presents you can and then bring them to me. It all depends on your level, and you will only get the right presents by eliminating the monsters that pertain to your level. You will need no less than 10, with 100 being the maximum that you can collect at once. I will give the best reward to those who find the maximum limit of 100. Trust me; You won't just be getting a big thank you from Maple Claws when you're done... Go for it!");
			SetQuestData(8020023, "s");
			
			int ask = AskMenu("What do you want?#b",
				(0, " What did you mean by Pertain to your level?"),
				(1, " I would like to continue on the journey"));
			
			if (ask == 0)
			{
				self.say("Ok. You need to find monsters that are in accordance with your level to get the right presents. If you're level 10-20, you'll need to find the #bRed and Green presents#k. If you're level 21-30, you'll need to find the #bRed and White presents#k. If you're level 31-40, you'll need to find the #bRed and Blue presents#k. If you're level 41-60, you'll need to find the #bBlue and White presents#k. If you're level 61 or above, you'll need to find the #bGreen and White presents#k. To receive something from me, you need to find at least ten gifts. The greater the number of gifts, the better the prize. Please come back when you're ready!");
			}
			else if (ask == 1)
			{
				self.say("OK... I will wait for you.");
			}
		}
		else if (quest == "s")
		{
			if (Level < 21)
				GivePresent(4031443);
			
			else if (Level < 31)
				GivePresent(4031440);
			
			else if (Level < 41)
				GivePresent(4031441);
			
			else if (Level < 61)
				GivePresent(4031439);
			
			else
				GivePresent(4031442);
		}
		else if (quest == "end")
		{
			bool restart = AskYesNo("Hey, nice to see you again! How are you? So, have you already found more presents for me? Would you like to make another trade?");
			
			if (!restart)
			{
				self.say("Ah, for real? It's all good. I'll be here a while longer, if you find more presents, you know where to find me.");
				return;
			}
			
			SetQuestData(8020023, "s");
			self.say("Sweet. That's great news. I'll be here waiting.");
		}
	}
	
	private void DeliverPresent(string quest)
	{
		if (Level < 10)
		{
			self.say("Hey, sorry, but I don't think you're strong enough to help me right now.");
			return;
		}
		
		// Rowen, Ayan, Ericsson, Porter
		int[] deliveryQuests = {8020026, 8020027, 8020028, 8020029};
		
		if (quest == "end")
		{
			self.say("Thanks for helping me deliver these presents to the four friends I asked you to find. In the spirit of Christmas, I think it would be a good idea to buy a gift for someone special. Surely a person will enjoy this good deed. Happy Holidays~!");
		}
		else if (quest == "")
		{
			bool start = AskYesNo("Hi! I couldn't fix my sled and I still have presents to deliver... Do you think you can take on this task?");
			
			if (!start)
			{
				self.say("How rude! Forget it. I'm definitely going to put coal in your stocking...");
				return;
			}
			
			self.say("Thank you so soo much! I need you to take these presents and distribute them to the good people in the towns of: Ellinia, Perion, Orbis and Omega Sector. They will distribute them to the children. You will need to talk with them to find out who is accepting presents. I need them all to be delivered, come back after you deliver them, although, no matter what you do, I'll be very grateful. Trust me, you'll get more than Santa's gratitude when you're done!");
			
			int menu = AskMenu("Ok, these are my great friends, I need you to deliver the presents to them. Who would you like to visit?#b",
				(0, " Rowen the Fairy"),
				(1, " Ayan"),
				(2, " Ericsson"),
				(3, " Porter"),
				(4, " Not yet. I am very busy.")
			);
			
			if (menu == 4)
			{
				self.say("I understand. Everyone is busy with their own stuff these days, but I really need your help. I need to deliver these presents to my dear friends, I would be delighted if you could deliver them soon. I'll be here waiting.");
				return;
			}
			
			int questID = deliveryQuests[menu];
			
			if (GetQuestData(questID) == "end")
			{
				if (menu == 0 || menu == 1)
					self.say("You were already there last time~! I'm sure she's excited about the present I gave her!");
				
				else
					self.say("You were already there last time~! I'm sure he's excited about the present I gave him!");
				
				return;
			}
			
			if (!Exchange(0, 4031486, 1))
			{
				self.say("Sorry, it looks like your etc. inventory is full. Please make some room and talk to me again.");
				return;
			}
			
			SetQuestData(questID, "s");
			
			if (menu == 0)
			{
				SetQuestData(8020025, "1");
				self.say("Ah, Rowen. She lives in Ellinia, it won't be very hard to find her. There's an off chance that she's not in a good mood and won't accept your present, but don't worry. If you persist, she'll accept. After all, who doesn't love getting presents? Go meet her right now~!");
			}
			else if (menu == 1)
			{
				SetQuestData(8020025, "2");
				self.say("Ok, Ayan. She lives in Perion, it won't be very hard to find her. There's an off chance that she's not in a good mood and won't accept your present, but don't worry. If you persist, she'll accept. After all, she loved the present I gave her last time. Go meet her now~!");
			}
			else if (menu == 2)
			{
				SetQuestData(8020025, "3");
				self.say("Ahh, Ericsson. He lives in Orbis, and believe me, it won't be hard to find him, because he really stands out. It's possible that he's in a bad mood and won't accept your present, but keep talking to him. If you persist, he will accept. Deep down he has a heart of gold and will love to receive a present. Go meet him now~!");
			}
			else if (menu == 3)
			{
				SetQuestData(8020025, "4");
				self.say("Porter... He lives in the Omega Sector and it may not be very easy to find him in a sea of labcoats, but in the end, you will end up finding him. It's possible that he's in a bad mood and won't accept your present, but keep talking to him. If you persist, he will accept. Sometimes he likes to tease people. Go meet him now~!");
			}
		}
		else
		{
			bool allComplete = true;
			
			foreach (int questID in deliveryQuests)
			{
				string deliveryQuest = GetQuestData(questID);
				
				if (deliveryQuest == "s" || deliveryQuest == "1")
				{
					if (ItemCount(4031486) >= 1)
					{
						self.say("It looks like you still have the present I gave you. Remember that you needed to give it to someone... Ask for help from your friends if you need to!");
						return;
					}
					
					self.say("Oh no! You lost the box of presents? Luckily I have some more with me. I'll give you another one. Please don't lose it this time!");
					
					if (!Exchange(0, 4031486, 1))
					{
						self.say("Sorry, it looks like your etc. inventory is full. Please make some room and talk to me again.");
						return;
					}
					
					self.say("Now you have the box of presents.");
				}
				else if (deliveryQuest == "2")
				{
					if (!Exchange(0, 4031519, 1))
					{
						self.say("Sorry, I'm having some trouble giving you this Christmas Present. Please make sure you have an empty slot or that you don't already have the Christmas Present.");
						return;
					}
					
					RemoveQuest(8020025);
					SetQuestData(questID, "end");
					self.say("I see you made the delivery, that's great. Now, in the spirit of Christmas, I'm giving a special present to you. You can return it to me to open it but traditionally you would give the gift to a friend. When you exchange gifts with a friend, the prize inside is all the sweeter! Thanks once more and I wish you a Happy Holidays!");
				}
				
				if (GetQuestData(questID) != "end")
					allComplete = false;
			}
			
			if (allComplete)
			{
				SetQuestData(8020025, "5");
				self.say("Wow... you really made all the deliveries! I want to reward you with something special, so please, hold out your hand!");
				
				if (!Exchange(0, 3995001, 1))
				{
					self.say("Hmm... it looks like your set-up inventory is full. Please make some space first and talk to me again.");
					return;
				}
				
				SetQuestData(8020025, "end");
				QuestEndEffect();
				self.say("It's a #bChristmas Wreath#k! It's a great decoration. You're so great at giving gifts, maybe you can find someone who needs it. Merry Christmas~!");
			}
		}
	}
	
	private void OpenPresent(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("Did you exchange gifts with a friend? If so, would you like me to help you open your present?");
			
			if (!start)
			{
				self.say("Really? All right! Remember to open the present soon or you'll run the risk of losing it. I'll be here; if you need me, you know where to find me.");
				return;
			}
			
			SetQuestData(8020030, "s");
			self.say("Ok, cool! I love doing this. I'll help you open your present and end the suspense.");
		}
		else if (quest == "s")
		{
			if (SlotCount(1) < 1 || SlotCount(2) < 1 || SlotCount(4) < 1)
			{
				self.say("Sorry, but you need to have at least one empty slot in your equip., use, and etc. inventories first.");
			}
			
			var rewards = new List<(int, int, int)>();
			
			rewards.Add((2060000, 100, 100000));
			rewards.Add((2061000, 100, 100000));
			rewards.Add((2000000, 25, 70000));
			rewards.Add((2000003, 25, 70000));
			rewards.Add((4010004, 2, 60000));
			rewards.Add((1322000, 1, 50000));
			rewards.Add((2000001, 10, 50000));
			rewards.Add((2000006, 5, 50000));
			rewards.Add((4010003, 2, 50000));
			rewards.Add((4010005, 1, 50000));
			rewards.Add((4010006, 2, 50000));
			rewards.Add((2002004, 1, 50000));
			rewards.Add((2000002, 5, 50000));
			rewards.Add((2002010, 1, 50000));
			rewards.Add((4020003, 10, 30000));
			rewards.Add((4011006, 1, 20000));
			rewards.Add((4004000, 1, 20000));
			rewards.Add((1002138, 1, 13929));
			rewards.Add((2050004, 3, 10000));
			rewards.Add((1040022, 1, 10000));
			rewards.Add((1060031, 1, 10000));
			rewards.Add((1040044, 1, 10000));
			rewards.Add((2000004, 2, 10000));
			rewards.Add((1002143, 1, 5000));
			rewards.Add((2022120, 2, 5000));
			rewards.Add((2000005, 3, 5000));
			rewards.Add((1072103, 1, 1000));
			rewards.Add((1432005, 1, 30));
			rewards.Add((2041013, 1, 10));
			rewards.Add((2041016, 1, 10));
			rewards.Add((2041019, 1, 10));
			rewards.Add((2041022, 1, 10));
			rewards.Add((2048000, 1, 1));
			
			var item = rewards.RandomElementByWeight(tuple => tuple.Item3);
			
			if (item == default)
				return;
			
			int itemID = item.Item1;
			int itemNum = item.Item2;
			
			if (!Exchange(0, 4031519, -1, itemID, itemNum))
			{
				self.say("Sorry, but I'm having trouble opening your present. Please try again later.");
				return;
			}
			
			SetQuestData(8020030, "end");
			QuestEndEffect();
			self.say("This is for you.");
		}
		else if (quest == "end")
		{
			bool restart = AskYesNo("Do you want to try again?");
			
			if (!restart)
			{
				self.say("Ah, for real? It's all good. I will stay here for a while longer; if you find more presents, you know where to find me.");
				return;
			}
			
			SetQuestData(8020030, "s");
			self.say("Sweet. That's great news. I'll be here waiting.");
		}
	}
	
	public override void Run()
	{
		var endTime2 = DateTime.Parse("2022-12-26");
		
		if (!eventActive("christmas2022") && !eventDone("christmas2022"))
		{
			self.say("The event has not started yet. Please wait~");
			return;
		}
		
		if (eventDone("christmas2022"))
		{
			self.say("The event is over. See you next year~");
			return;
		}
		
		var options = new List<(int Index, string Name)>();
		
		options.Add((0, " Collecting Presents"));
		
		if (DateTime.UtcNow < endTime2)
		{
			options.Add((1, " Delivering Presents"));
			
			if (ItemCount(4031519) >= 1)
				options.Add((2, " Opening the Christmas Present"));
		}
		
		string dialogue = "Hi! I'm Maple Claws and I need your help!";
		
		if (GetQuestData(8020023) != "")
			dialogue = "I might have a present for you...";
		
		if (options.Count == 0)
		{
			self.say(dialogue);
			return;
		}
		
		int choice = -1;
		
		if (options.Count >= 2)
			choice = AskMenu($"{dialogue}#b", options.ToArray());
		else
			choice = options[0].Index;
		
		switch(choice)
		{
			case 0: CollectPresent(GetQuestData(8020023)); break;
			case 1: DeliverPresent(GetQuestData(8020025)); break;
			case 2: OpenPresent(GetQuestData(8020030)); break;
		}
	}
}