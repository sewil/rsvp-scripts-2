using System;
using WvsBeta.Game;
using WvsBeta.Common;
using System.Linq;
using WvsBeta.Game.GameObjects;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(7000000);
		string quest2 = GetQuestData(7000001);
		string quest3 = GetQuestData(7000002);
		string today = DateTime.UtcNow.ToString("yyyyMMdd");
		
		if (!chr.IsAdmin && false)
		{
			self.say("Shhhh ... be quiet. Deep in the dungeon rests a powerful foe. Complete the quests in order of the level, and you'll be able to meet the boss of the Zakum Dungeon. It won't be easy, at all ... but try your best.");
			return;
		}
		
		int start = AskMenu("Well ... alright. You seem more than qualified for this. Which of these tasks do want to tackle on?#b",
			(0, " Explore the Dead Mine. (Level 1)"),
			(1, " Observe the Zakum Dungeon. (Level 2)"),
			(2, " Request for a refinery. (Level 3)"),
			(3, " Get briefed for the quest."));
			
		if (start == 0)
		{
			string retry = GetQuestData(7000006);
			
			if (chr.PartyID == 0)
			{
				self.say("You are not currently in a party right now. You may only tackle this assignment as a party.");
				return;
			}
			
			var party = PartyData.Parties[chr.PartyID];
			
			if (party.Leader != chr.ID)
			{
				self.say("This journey will be a neverending maze of quests you won't be able to solve by yourself. But if you're willing to take on the challenge, then talk to the chief of your occupation at the Chief's Residence in El Nath to receive the quest.");
				self.say("After receiving the quest, either join a party or form one yourself, and have the leader of the party speak to me to start the quest. Once you are ready, have the leader of the party come up and talk to me.");
				return;
			}
			
			if (retry != "")
			{
				string date = retry.Substring(1, 8);
				int retryCount = Int32.Parse(retry.Substring(0, 1));
				
				if (date == today)
				{
					if (retryCount >= 3)
					{
						self.say("You have already looked through the Cave at the Dead Mine three times today and therefore I cannot let you in once more. Please come back tomorrow.");
						return;
					}
				}
				else
				{
					SetQuestData(7000006, "");
				}
			}
			
			var partyMembers = chr.Field.GetInParty(chr.PartyID).ToArray();
			
			foreach (var partyMember in partyMembers)
			{
				if (GetQuestData(partyMember, 7000000) == "")
				{
					self.say("There's a member of your party that hasn't received the quest from the chief of the occupation at El Nath. Every single one of the party members must receive the quest from the chiefs of their respective occupation in order to do this.");
					return;
				}
			}
			
			if (FieldSet.Instances["Party2"].UserCount != 0 || !FieldSet.IsAvailable("Party2"))
			{
				self.say("An another party has already started this quest. Please try again later.");
				return;
			}
			
			foreach (var partyMember in partyMembers)
			{
				int item1 = partyMember.Inventory.ItemCount(4001015);
				int item2 = partyMember.Inventory.ItemCount(4001016);
				int item3 = partyMember.Inventory.ItemCount(4001018);
				
				if (item1 > 0) partyMember.Inventory.TakeItem(4001015, (short)item1);
				if (item2 > 0) partyMember.Inventory.TakeItem(4001016, (short)item2);
				if (item3 > 0) partyMember.Inventory.TakeItem(4001018, (short)item3);
			}
			
			if (false)
			{
				FieldSet.Enter("Party2", partyMembers, chr);
			}
			else
			{
				if (!FieldSet.Instances.TryGetValue("Party2", out var fs)) return;
				if (fs.TryEnter(partyMembers, 0, chr.ID))
				{
					fs.StartEvent(chr);
					fs.TryToRunInitScript = true;
				}
				else
				{
					self.say("Error starting FieldSet");
				}
			}
			
			//Set the name of the leader so the check used inside can't be abused
			MapProvider.Maps[280010000].ParentFieldSet.SetVar("leader", chr.Name);
			
			return;
		}
		else if (start == 1)
		{
			string retry = GetQuestData(7000007);
			
			if (quest1 == "end")
			{
				bool askEnter = false;
				
				if (quest2 == "")
				{
					askEnter = AskYesNo("You have safely cleared the 1st stage. There's still a long way to go before meeting the boss of Zakum Dungeon, however. So, what do you think? Are you ready to move on to the next stage?");
				}
				else if (quest2 == "s")
				{
					askEnter = AskYesNo("Hmmm ... you must have tried this quest before and gave up midway through. What do you think? Do you want to retry this level?");
				}
				else if (quest2 == "end")
				{
					askEnter = AskYesNo("Hmmm ... You have already cleared this level before.  For you to be rewarded again, you need to restart the quest from Level 1. Otherwise, you will still be able to do the quest but will not be rewarded. Do you still want to retry this level?");
				}
				
				if (!askEnter)
				{
					self.say("I see ... but if you ever decide to change your mind, then talk to me.");
					return;
				}
				
				if (retry != "")
				{
					string date = retry.Substring(1, 8);
					int retryCount = Int32.Parse(retry.Substring(0, 1));
					
					if (date == today)
					{
						if (retryCount >= 3)
						{
							self.say("You have already completed the exploration of the Zakum Dungeon three times today, and therefore I cannot let you explore once more. Please come back tomorrow");
							return;
						}
					}
					else
					{
						SetQuestData(7000007, "");
					}
				}
				
				self.say("Alright! From here on out, you'll be transported to the map where obstacles will be aplenty. There will be a person standing at the deepest part of the map, and if you talk to her, you'll find an item that will be used as a material to create an item that summons the boss of Zakum Dungeon. Please get me that item. Good luck!");
				
				if (quest2 != "end")
				{
					SetQuestData(7000001, "s");
				}
				
				SetQuestData(7000005, DateTime.UtcNow.AddMinutes(2).ToString());
				ChangeMap(280020000);
			}
			else if (quest1 == "fail")
			{
				self.say("It seems like you're in the middle of the 1st stage. You must first clear this one before moving on to Level 2. Please clear the 1st stage first.");
			}
			else
			{
				self.say("It doesn't look like you have cleared the previous stage, yet. Please beat the previous stage before moving onto the next level.");
			}
		}
		else if (start == 2)
		{
			if (quest2 != "end")
			{
				self.say("Hmmm ... I don't think you have cleared the previous stage, yet. Please beat the previous stage before moving onto the next level.");
				return;
			}
			
			if (quest3 == "s" || quest3 == "s2")
			{
				if (ItemCount(4000082) < 30)
				{
					self.say("I don't think you have #b30 Zombie's Lost Gold Teeth#k yet. Gather them all up and I may be able to refine them and make a special item for you ...");
					return;
				}
				
				self.say("Ha ha ha, don't worry, I'll make it in a heartbeat!");
				
				if (!Exchange(0, 4000082, -30, 4031061, -1, 4031062, -1, 4001017, 5))
				{
					self.say("Hmmm... are you sure you have all the items required to make #rEye of Fire#k with you? If so, then please check and see if your etc. inventory is full or not.");
					return;
				}
				
				SetQuestData(7000002, "end");
				self.say("Here it is. You will now be able to enter the alter of the Zakum Dungeon when the door on the left is open.. You'll need\r\n#b#t4001017##k with you in order to go through the door and enter the stage. Now, let's see how many can enter this place ...?");
			}
			else if (quest3 == "end")
			{
				bool askStart = AskYesNo("Hmmm ... aren't you the one who refined #b#t4001017##k before? Then what can I do for you? Are you interested in mixing #b#t4031061##k with #b#t4031062##k again to create #b#t4001017##k?");
				
				if (!askStart)
				{
					self.say("I see ... but please be aware that you won't be able to see the boss of Zakum Dungeon without the #b#t4001017##k.");
					return;
				}
				
				SetQuestData(7000002, "s2");
				self.say("Hmmm, by mixing #b#t4031061##k with #b#t4031062##k, I can make an the item that will be used as a sacrifice to summon the boss, called #b#t4001017##k. The problem is ... (cough cough) as you can see, I am not feeling terribly well these days, so it's difficult for me to move around and gather up items. Well ... will it be ok for you to gather up #b30 Zombie's Lost Gold Teeth#k for me? Don't ask me where I'll be using it, though ...");
			}
			else
			{
				SetQuestData(7000002, "s");
				self.say("Hmmm, by mixing #b#t4031061##k with #b#t4031062##k, I can make an the item that will be used as a sacrifice to summon the boss, called #b#t4001017##k. The problem is ... (cough cough) as you can see, I am not feeling terribly well these days, so it's difficult for me to move around and gather up items. Well ... will it be ok for you to gather up #b30 Zombie's Lost Gold Teeth#k for me? Don't ask me where I'll be using it, though ...");
			}
		}
		else if (start == 3)
		{
			self.say("Not sure where to start? In order to do this quest, you'll have to receive the approval from the chief of your occupation. I do not want to be scolded later on for letting someone in without going through the proper procedure. The only ones that I can let in are the party full of members that have received the approval.");
			self.say("Complete the quests in order of the level, and you'll be able to meet the boss of the Zakum Dungeon. Gather up the items I'll request from you, and I'll make them into a sacrificial item. Place the sacrificial item at the altar, and you'll get to see what you've come to see. To do that, first look through the Dead Mine and bring back #b#t4001018##k.");
			self.say("There, other than #b#t4001018##k, you'll also find Paper documents. Give that to #b#p2032002##k, and you may get something helpful in return along with Piece of Fire ore. Next, go across the lava area and find #b#t4031062##k. It'll be a treacherous road to take, but ... it's a must item, in terms of making a sacrificical item.");
			self.say("Once you have gotten #b#t4031062##k, you'll need to refine the #bPieces of Fire ore#k and #b#t4031062#s#k that you have acquired at level 1 and 2. Don't worry about it, though; I can refine them for you. Once you've completed them all, all you'll have left to do is to meet the boss of Zakum Dungeon. It won't be easy, at all ... but try your best.");
		}
	}
}