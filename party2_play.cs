using System;
using System.Collections.Generic;
using WvsBeta.Game;
using WvsBeta.Common;
using System.Linq;
using WvsBeta.Game.GameObjects;

public class NpcScript : IScriptV2
{
	private PartyData Party => PartyData.Parties[chr.PartyID];
	private FieldSet FieldSet => chr.Field.ParentFieldSet;
	private bool IsLeader => Party.Leader == chr.ID;

	private void OpenPortal()
	{
		chr.Field.EnablePortal("next00");
		MapPacket.PortalEffect(chr.Field, 2, "gate");
	}

	private void GiveEXP(int exp, int forStage)
	{
		FieldSet.Characters.ForEach(character =>
		{
			string questData = character.Quests.GetQuestData(7010);

			if (int.TryParse(questData, out int maxCompletedStage) && maxCompletedStage >= forStage)
			{
				character.AddEXP(exp * 0.7, true, true);
			}
			else
			{
				character.AddEXP(exp, true, true);
				character.Quests.SetQuestData(7010, forStage.ToString());
			}
		});
	}

	private void ClearStage()
	{
		int stageCleared = int.Parse(FieldSet.GetVar("stage"));
		int expReward = stageCleared * 600 + 2400;
		if (stageCleared == 9) expReward += 700;
		
		FieldSet.SetVar("stage", (stageCleared + 1).ToString());
		
		if(stageCleared == 5)
			FieldSet.SetVar("stage", "7");
		
		GiveEXP(expReward, stageCleared);
		FieldSet.Characters.ForEach(character =>
		{
			MapPacket.MapEffect(character, 4, "Party1/Clear", true);
			MapPacket.MapEffect(character, 3, "quest/party/clear", true);
		});

		if (stageCleared == 9)
		{
			FieldSet.ResetTimeOut(TimeSpan.FromMinutes(1));
			FieldSet.Characters.ToList().ForEach(character =>
			{
				character.ChangeMap(922011000);
			});
		}
		else
		{
			OpenPortal();
			self.say("The portal that leads you to the next stage is now open.");
		}
	}
	
	public override void Run()
    {
	    if (MapID == 922011100)
	    {
		    GiveReward();
		    return;
	    }

	    if (!IsLeader || MapID == 922011000)
	    {
		    SendHelp();
		    return;
	    }
		
	    switch (MapID)
	    {
		    case 922010100:
			    CollectPassStage(4001022, 25, "Hello! Welcome to the 1st stage. Walk around the map and find various types of monsters roaming the place. Defeat them all, collect #b25 #t4001022#s#k and bring them to me. Combine the collected #t4001022#s and hand them to the leader of your party, who in turn will deliver them to me. You may be familiar with these monsters, but they may be more powerful than expected. So be careful!");
			    break;
		    case 922010200:
				if (!CheckStage("2")) return;
				
			    CollectPassStage(4001022, 15, "Hello! Welcome to the 2nd stage. Walk around the map and you'll find boxes scattered around the place. Break a box and you'll be sent to another map or rewarded with a #t4001022#. Look in each box, collect #b15 #t4001022##k and bring them to me. Combine the collected #t4001022#s and hand them to the leader of your party, who in turn will deliver them to me. Good luck!");
			    break;
		    case 922010300:
			    if (!CheckStage("3")) return;
				
			    CollectPassStage(4001022, 32, "Hello! Welcome to the 3rd stage. Here you will see a lot of monsters and boxes. If you defeat the monsters, they will drop #b#t4001022##k, just like the monsters from the other dimension. If you break the box, a monster will appear and it will also drop #b#t4001022##k.\r\nYou'll need to collect all #b32 #t4001022#s#k and bring them to me. Combine the collected #t4001022#s and hand them to the leader of your party, who in turn will deliver them to me. Good luck!");
			    break;
		    case 922010400:
				if (!CheckStage("4")) return;
				
			    CollectPassStage(4001022, 6, "Hello! Welcome to the 4th stage. Here you will encounter a dark space created by the crack in dimension. Inside, you'll find a monster called #b#o9300008##k hidden in the darkness. So you'll hardly be able to see it even with your eyes wide open. Defeat the monsters and collect #b6 #t4001022#s#k.\r\nThe leader of your party must collect all the #b#t4001022#s#k from you. As I said, #b#o9300008##k cannot be seen unless you have your eyes wide open. It's a different kind of monster that disappears into the darkness. Good luck!");
			    break;
		    case 922010500:
				if (!CheckStage("5")) return;
				
			    CollectPassStage(4001022, 24, "Hello! Welcome to the 5th stage. Here you will find many spaces and, within them, you'll find some monsters. Your mission is to collect #b24 #t4001022#s#k with your party. Here's the catch: There will be cases where you'll need to have a certain occupation, or you won't be able to collect #b#t4001022##k. So be careful. Here's a hint. There's a monster called #b#o9300013##k that is invincible. Only a thief can reach the other side of the monster. There is also a route that only the magicians can take. Discovering it is up to you. Good luck!");
			    break;
			case 922010600:
				string check = GetQuestData(7011);
				string welcomeText = "Hello! Welcome to the 6th stage. Here, you'll see boxes with numbers on them and, if you stand on top of the correct box and press the UP ARROW, you will be transported to the next box. I'll give the leader of the party\r\n#btwo hints#k on how to get past this stage and it's up to the leader to remember the order and take the right step, one at a time.\r\nWhen you reach the top, you will find the portal to the next stage. When everyone in your party has passed through the portal, the stage will be completed. It will all depend on remembering the correct boxes.";
				
				if (check == "e")
				{
					self.say($"{welcomeText} I already gave the hint #btwo times#k and I can't give you any more help from now on. Good luck!");
				}
				else
				{
					if (check == "") SetQuestData(7011, "1");
					if (check == "1") SetQuestData(7011, "e");
					self.say($"{welcomeText} Here's a hint. Don't miss it!\r\n\r\n#bOne, 3, 3, 2, middle, 1, three, 3, 3, left, two, 3, 1, one, ?#k");
				}
				break;
		    case 922010700:
				if (!CheckStage("7")) return;
				
			    CollectPassStage(4001022, 3, "Hello! Welcome to the 7th stage.  Here you will find a ridiculously powerful monster called #b#o9300010##k. Defeat the monster and find the #b#t4001022##k needed to proceed to the next stage. Please collect #b3 #t4001022#s#k.\r\nTo finish off the monster, defeat it from far away. The only way to attack would be from long distance, but... ah yes, be careful, #o9300010# is very dangerous. You will certainly get hurt if you're not careful. Good luck!");
			    break;
		    case 922010800:
				if (!CheckStage("8")) return;
			    
			    var puzzle = new PermutationPuzzle(chr.Field, "ans", 5);

			    if (puzzle.Created)
			    {
				    self.say("Welcome to the 8th stage. Here you will find many platforms to stand on. #b5#k of them will be connected to the #bportal that leads to the next stage#k. To pass, place #b5 of your party members on the correct platforms#k.\r\nA warning: You will need to stand firmly in the center of the platform for the answer to count as correct. Also remember that only 5 members can stand on the platform. When these conditions are met, the leader of the party should #bdouble-\r\nclick me to find out if the answer is correct or not#k. Good luck!");
				    return;
			    }

			    switch (puzzle.AreaCheck())
			    {
				    case PermutationResult.NotEnoughPlayers:
					    self.say("I think you still haven't found the correct 5 platforms. Think of a different number. Remember that you need to have 5 members of your party on the platform, right in the center, for the answer to be valid. Keep trying!");
					    break;
				    case PermutationResult.Wrong:
					    FailStage();
					    break;
				    case PermutationResult.Correct:
					    ClearStage();
					    break;
			    }
			    break;
		    case 922010900:
				if (!CheckStage("9")) return;
				
			    CollectPassStage(4001023, 1, "You made it this far. Now is your chance to finally get your hands on the real culprit. Go to the right and you'll see a monster. Defeat it to encounter the monstrous #b#o9300012##k who will appear out of nowhere. He will be very agitated by the presence of your party, be careful.\r\nYour task is to defeat him, collect the #b#t4001023##k that he possesses and bring it to me. If you succeed in taking the key from the monster, there is no way for the dimensional door to open again. I have faith in you. Good luck!");
			    break;
	    }
    }
	
	private void FailStage()
	{
		FieldSet.Characters.ForEach(character =>
		{
			MapPacket.MapEffect(character, 4, "Party1/Failed", true);
			MapPacket.MapEffect(character, 3, "quest/party/wrong_kor", true);
		});
	}
	
	private bool CheckStage(string stage)
	{
		if (FieldSet.GetVar("stage") != stage)
		{
			self.say("Congratulations on completing the mission for this stage. Please use the portal you see up ahead and proceed to the next stage.");
			return false;
		}
		
		var party = PartyData.Parties[chr.PartyID];
			
		if (chr.Field.GetInParty(chr.PartyID).Count() != FieldSet.Characters.Count())
		{
			self.say("I don't think all the members of your party are present. You'll need to bring each member from the last stage to continue. Please find the members that are missing.");
			return false;
		}
		
		return true;
	}

	private void CollectPassStage(int itemId, int amount, string welcomeText)
	{
		if (MapID == 922010100)
		{
			if (FieldSet.GetVar("stage") == "" || FieldSet.GetVar("stage") == null)
			{
				FieldSet.SetVar("stage", "1");
				self.say(welcomeText);
				return;
			}
			
			if (FieldSet.GetVar("stage") != "1")
			{
				self.say("Wow! Congratulations on completing the mission for this stage. Please use the portal that you see up ahead and proceed to the next stage. Best of luck to you!");
				return;
			}
		}
		
		if (chr.Inventory.ItemCount(itemId) >= amount)
		{
			chr.Inventory.TakeItem(itemId, (short) amount);
			ClearStage();
		}
		else
		{
			self.say(welcomeText);
		}
	}

	private void GiveReward()
    {
		self.say("Incredible! You completed all the stages and now you're here enjoying your victory. Wow! My sincere congratulations to each of you for the job well done. Here's a little gift for you. Before accepting, check if your use and equip. inventories have a slot available.");
		
		if (SlotCount(1) < 1 || SlotCount(2) < 1 || SlotCount(4) < 1)
		{
			self.say("Your equip., use and etc. inventories need to have at least one slot available. Please make the necessary adjustments and talk to me.");
			return;
		}
		
		Random rnd = new Random();
		
		int itemID = 0;
		int itemNum = 0;
		int rnum = rnd.Next(0, 251);
		
		int[] commonReward = {2000004, 2000002, 2000003, 2000006, 2022000, 2022003, 2040002, 2040402, 2040502, 2040505, 2040602, 2040802, 4003000, 4010000, 4010001, 4010002, 4010003, 4010004, 4010005, 4010006, 4020000, 4020001, 4020002, 4020003, 4020004, 4020005, 4020006, 4020007, 4020008, 1032002, 1032011, 1032008, 1102011, 1102012, 1102013, 1102014, 2040803, 2070011, 2043001, 2043101, 2043201, 2043301, 2043701, 2043801, 2044001, 2044101, 2044201, 2044301, 2044401, 2044501, 2044601, 2044701, 2000004, 2000002, 2000003, 2000006, 2022000, 2022003, 4003000, 4010000, 4010001, 4010002, 4010003, 4010004, 4010005, 4010006, 4020000, 4020001, 4020002, 4020003, 4020004, 4020005, 4020006, 4020007, 4020008, 2040001, 2040004, 2040301, 2040401, 2040501, 2040504, 2040601, 2040601, 2040701, 2040704, 2040707, 2040801, 2040901, 2041001, 2041004, 2041007, 2041010, 2041013, 2041016, 2041019, 2041022, 4132001, 4132002};
		int[] commonRewardNum = {10, 100, 100, 30, 30, 30, 1, 1, 1, 1, 1, 1, 50, 15, 15, 15, 15, 15, 15, 10, 15, 15, 15, 15, 15, 15, 15, 6, 6, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 15, 80, 80, 25, 25, 25, 55, 12, 12, 12, 12, 12, 12, 8, 12, 12, 12, 12, 12, 12, 12, 4, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2};
		
		if (rnum < 96)
		{
			itemID = commonReward[rnum];
			itemNum = commonRewardNum[rnum];
		}
		else if (rnum >= 96 && rnum <= 150)
		{
			itemID = 2000004;
			itemNum = 10;
		}
		else if (rnum >= 151 && rnum <= 200)
		{
			itemID = 2000002;
			itemNum = 100;
		}
		else
		{
			itemID = 2000003;
			itemNum = 100;
		}
		
		int item1 = ItemCount(4001022);
        int item2 = ItemCount(4001023);
		
		if (item1 > 0)
		{
			if (!Exchange(0, 4001022, -item1))
			{
				self.say("Are you sure you have the exact number of #t4001022#? Please check again.");
				return;
			}
		}
		
		if (item2 > 0)
		{
			if (!Exchange(0, 4001023, -item2))
			{
				self.say("Are you sure you have the exact number of #t4001023#? Please check again.");
				return;
			}
		}
		
		if (!Exchange(0, itemID, itemNum))
		{
			self.say("Hmmm... are you sure you have a free slot in your use and etc. inventories? I can't reward you for your effort if your inventory is full...");
			return;
		}
		
		RemoveQuest(7011);
	    ChangeMap(221024500);
    }

    private void SendHelp()
    {
	    switch (MapID)
	    {
		    case 922010100:
			    self.say("Here's the information about the 1st stage. You will see monsters at different points on the map. These monsters have an item called #b#t4001022##k, which opens the entrance to another dimension. With it, you can take a step closer to the top of the Eos Tower, where the portal to another dimension will open and, finally, you'll encounter the culprit behind it all.\r\nDefeat the monsters, collect #b25 #t4001022##k and give it to the leader of your party, who will then deliver it to me. This will take you to the next stage. Good luck!");
			    break;
		    case 922010200:
			    self.say("Here's the information about the 2nd stage. You will see boxes all over the map. Break a box and you'll be sent to another map or rewarded with a #t4001022#. Look in each box, collect #b15 #t4001022#s#k and bring them all to me. Combine the collected #t4001022#s, hand them all to the leader of your party, who in turn will hand them to me.\r\nMoreover, even if you're sent somewhere else, you can find other boxes there. So don't simply leave the strange place you're teleported to. If you leave that place, you won't be able to return and you'll have to start the quest over from the beginning. Good luck!");
			    break;
		    case 922010300:
			    self.say("Here's the information about the 3rd stage. Here you'll see a lot of monsters and boxes. If you defeat the monsters, they will drop #b#t4001022##k, just like the monsters from the other dimension. If you break the box, a monster will appear and it will also drop #b#t4001022##k.\r\nYou'll need to collect all #b32 #t4001022#s#k and bring them to me. Combine the collected #t4001022#s and hand them to the leader of your party, who in turn will deliver them to me. Good luck!");
			    break;
		    case 922010400:
			    self.say("Here's the information about the 4th stage. Here you will encounter a dark space created by the crack in dimension. Inside, you'll find a monster called #b#o9300008##k hidden in the darkness. So you'll hardly be able to see it if your eyes aren't wide open. Defeat the monsters and collect #b6 #t4001022#s#k.\r\nLike I said, #b#o9300008##k can't be seen if your eyes aren't wide open. It's a different kind of monster that disappears into the darkness. Good luck!");
			    break;
		    case 922010500:
			    self.say("Here's the information about the 5th stage. Here you will find many spaces and, in each one, you'll find some monsters. Your mission is to collect #b24 #t4001022#s#k with your party. Here's the catch: There will be cases where you'll need to have a certain occupation, or you won't be able to collect #b#t4001022##k. So be careful. Here's a hint. There's a monster called #b#o9300013##k that is invincible. Only a thief can reach the other side of the monster. There is also a route that only the magicians can take. Discovering it is up to you. Good luck!");
			    break;
		    case 922010600:
			    self.say("Here's the information about the 6th stage. Here, you'll see boxes with numbers on them and, if you stand on top of the correct box and press the UP ARROW, you will be transported to the next box. I'll give the leader of the party\r\n#btwo hints#k on how to get past this stage and it's up to the leader to remember the order and take the right step, one at a time.\r\nWhen you reach the top, you will find the portal to the next stage. When everyone in your party has passed through the portal, the stage will be completed. It will all depend on remembering the correct boxes. Good luck!!");
			    break;
		    case 922010700:
			    self.say("Here's the information about the 7th stage. Here you will find a ridiculously powerful monster called #b#o9300010##k. Defeat the monster and find the #b#t4001022##k needed to proceed to the next stage. Please collect #b3 #t4001022#s#k.\r\nTo finish off the monster, defeat it from far away. The only way to attack would be from long distance, but... ah yes, be careful, #o9300010# is very dangerous. You will certainly get hurt if you're not careful. Good luck!");
			    break;
		    case 922010800:
			    self.say("Here's the information about the 8th stage. Here you will find many platforms to stand on. #b5#k of them will be connected to the #bportal that leads to the next stage#k. To pass, place #b5 of your party members on the correct platforms#k.\r\nA warning: You will need to stand firmly in the center of the platform for the answer to count as correct. Also remember that only 5 members can stand on the platform. When these conditions are met, the leader of the party should #bdouble-\r\nclick me to find out if the answer is correct or not#k. Good luck!");
			    break;
		    case 922010900:
			    self.say("Here's the information about the 9th stage. Now is your chance to finally get your hands on the real culprit. Go to the right and you'll see a monster. Defeat it to encounter the monstrous #b#o9300012##k who will appear out of nowhere. He will be very agitated by the presence of your party, be careful.\r\nYour task is to defeat him, collect the #b#t4001023##k that he possesses and bring it to me. If you succeed in taking the key from the monster, there is no way for the dimensional door to open again. Good luck!");
			    break;
		    case 922011000:
			    self.say("Welcome to the bonus stage. I can't believe you guys really defeated #b#o9300012##k! Incredible! But we don't have much time, so I'll get to the point. There are many boxes here. Your task is to break the boxes within the time limit and pick up the items inside. If you're lucky, you can even find a rare item here and there. Good luck!!");
			    break;
	    }
    }
}