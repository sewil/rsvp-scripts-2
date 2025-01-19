using System;
using System.Collections.Generic;
using WvsBeta.Game;
using WvsBeta.Common;
using System.Linq;
using WvsBeta.Game.GameObjects;

public class NpcScript : IScriptV2
{
	
	private struct PermutationStageData
	{
		public int Stage;
		public int Exp;
		public string IntroText;
		public string NotEnoughPlayersText;
	}
	
	private static readonly List<(string, int)> Questions = new List<(string, int)>
	{
		("Here's the question. Collect the same number of coupons as the number of levels needed to make the first job advancement as the magician.", 8),
		("Here's the question. Collect the same number of coupons as the minimum amount of STR level needed to make the first job advancement as the warrior.", 35),
		("Here's the question. Collect the same number of coupons as the minimum amount of INT level needed to make the first job advancement as the magician.", 20),
		("Here's the question. Collect the same number of coupons as the minimum amount of DEX level needed to make the first job advancement as the bowman.", 25),
		("Here's the question. Collect the same number of coupons as the minimum amount of DEX level needed to make the first job advancement as the thief.", 25),
		("Here's the question. Collect the same number of coupons as the number of levels needed to make the first job advancement as the warrior.", 10),
		("Here's the question. Collect the same number of coupons as the number of levels needed to make the first job advancement as the bowman.", 10),
		("Here's the question. Collect the same number of coupons as the number of levels needed to make the first job advancement as the thief.", 10)
	};
	
	private static readonly int[] Rewards = {2000004, 2000001, 2000002, 2000003, 2000006, 2022000, 2022003, 2040002, 2040402, 2040502, 2040505, 2040602, 2040802, 4003000, 4010000, 4010001, 4010002, 4010003, 4010004, 4010005, 4010006, 4020000, 4020001, 4020002, 4020003, 4020004, 4020005, 4020006, 4020007, 4020008, 1032002, 1032004, 1032005, 1032006, 1032007, 1032009, 1032010, 1002026, 1002089, 1002090, 4132001, 4132002};
	private static readonly int[] Amounts = {5, 100, 70, 100, 50, 15, 15, 1, 1, 1, 1, 1, 1, 30, 8, 8, 8, 8, 8, 8, 5, 8, 8, 8, 8, 8, 8, 8, 3, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
	
	private PartyData Party => PartyData.Parties[chr.PartyID];
	private FieldSet FieldSet => chr.Field.ParentFieldSet;
	private bool IsLeader => Party.Leader == chr.ID;

	public override void Run()
	{
		switch (MapID)
		{
			case 103000800:
				StageOne();
				return;
			case 103000801:
				PermutationStage(new PermutationStageData
				{
					Stage = 2,
					Exp = 200,
					IntroText = "Hi. Welcome to the 2nd stage. Next to me, you'll see a number of ropes. Out of these ropes, #b3 are connected to the portal that sends you to the next stage#k. All you need to do is have #b3 party members to find the answer ropes and hang on them.#k\r\nBUT, it doesn't count as an answer if you hang onto the rope too low, please bring yourself higher to be counted as a correct answer. Also, only 3 members of your party are allowed on the ropes. Once they are hanging on, the leader of the party must #bdouble-click on me to check and see if the answer's correct or not#k. Now, find the right ropes to hang on!",
					NotEnoughPlayersText = "It looks like you haven't found the 3 ropes yet. Think of a different combination of ropes. Remember that only 3 party members can hang on the ropes, and do not hang too low or the answer won't count!"
				});
				return;
			case 103000802:
				PermutationStage(new PermutationStageData
				{
					Stage = 3,
					Exp = 400,
					IntroText = "Hello. Welcome to the 3rd stage. Next to you you'll see barrels with kittens inside on top of the platforms. Out of these platform, #b3 of them lead to the portals for the next stage. 3 of the party members need to find the correct playform to step on and clear the stage.\r\nBUT, you need to stand firm right at the centor of it, not standing on the edge, in order to be counted as a correct answer, so make sure to remember that. Also, only 3 members of your party are allowed on the platforms. Once the members are on them, the leader of the party must double-click on me to check and see if the answer's right or not#k. Now, find the correct platforms~!",
					NotEnoughPlayersText = "It looks like you haven't found the 3 platforms yet. Think of a different combination of platforms. Remember that only 3 party members can stay on the platforms, firm in the center, for the answer to be correct!"
				});
				return;
			case 103000803:
				PermutationStage(new PermutationStageData
				{
					Stage = 4,
					Exp = 800,
					IntroText = "I will describe the 4th stage. You will see a lot of barrels close by. #b3 of these barrels will be connected to the portal leading to the next stage. 3 group members need to find the correct barrels and stay on top of them#k to complete the stage. BUT, you need to stand firm right in the center of the barrel, not the edge, in order to be counted as a correct answer. And only 3 members of your party can stay on top of the barrels. When the members are on top, the party leader should #bdouble-click on me to check and see if the answer's correct or not#k. Now, find the right barrels to stand on!",
					NotEnoughPlayersText = "It looks like you haven't found the 3 barrels yet. Think of a different combination of barrels. Remember that only 3 party members can stay on the barrels, firm in the center, for the answer to be correct!"
				});
				return;
			case 103000804:
				StageFive();
				return;
		}
	}

	private void ClearStage(string stageKey, int exp)
	{
		FieldSet.SetVar("stage", stageKey);
						
		FieldSet.Characters.ForEach(character =>
		{
			character.SetupLogging();
			character.AddEXP(exp, true, true);
			MapPacket.MapEffect(character, 4, "Party1/Clear", true);
			MapPacket.MapEffect(character, 3, "quest/party/clear", true);
		});
	}

	private void FailStage()
	{
		FieldSet.Characters.ForEach(character =>
		{
			MapPacket.MapEffect(character, 4, "Party1/Failed", true);
			MapPacket.MapEffect(character, 3, "quest/party/wrong_kor", true);
		});
	}

	private void OpenPortal()
	{
		chr.Field.EnablePortal("next00");
		MapPacket.PortalEffect(chr.Field, 2, "gate");
	}

	private void StageOne()
	{
		if (IsLeader)
		{
			switch (FieldSet.GetVar("stage"))
			{
				case null:
					self.say("Hello. Welcome to the first stage. Look around and you'll see Ligators wandering around. When you defeat it, it'll cough up a piece of #bcoupon#k. Every member of the party other than the leader should talk to me, get a question, and gather up the same number of #bcoupons#k as the answer to the question I'll give to them.\r\nIf you gather up the right amount of #bcoupons#k, I'll give the #bpass#k to that player. Once all the party members other than the leader gather up the #bpasses#k and give them to the leader, the leader will hand over the #bpasses#k to me, clearing the stage in the process. The faster you take care of the stages, the more stages you'll be able to challenge, so I suggest you take care of things quickly and swiftly. Well then, best of luck to you.");
					FieldSet.SetVar("stage", "1");
					break;
				case "1":
					int needed = Party.GetAvailablePartyMembers().Count() - 1;

					if (needed < 2) needed = 2;
						
					if (chr.Inventory.ItemCount(4001008) >= needed)
					{
						chr.Inventory.TakeItem(4001008, (short) needed);
						ClearStage("2", 100);
						OpenPortal();

						self.say($"You gathered up #b{needed} passes#k! Congratulations on clearing the stage! I'll make the portal that sends you to the next stage. There's a time limit on getting there, so please hurry. Best of luck to you all!");
					}
					else
					{
						self.say($"I'm sorry, but you are short on the number of passes. You need to give me the right number of passes, it should be the number of members of your party minus the leader, #b{needed} passes#k to clear the stage. Tell your party members to solve the questions, gather up the passes, and give them to you.");
					}

					break;
				case "2":
					self.say("You have completed this stage. Proceed to the next stage using the portal.");
					break;
			}

			return;
		}
		
		string chrStatus = FieldSet.GetVar($"{chr.Name}_");
		
		if (chrStatus == "clear")
		{
			self.say("You got the right answer! For that you have just received a #bpass#k. Please hand it to your leader of the party.");
			return;
		}

		if (chrStatus == null)
		{
			chrStatus = FieldSet.SetVar($"{chr.Name}_", Random(0, 8).ToString());
			self.say("Here, you need to collect #bcoupons#k by defeating the same number of Ligators as the answer to the question asked individually.");
		}
		else
		{
			int needed = Questions[int.Parse(chrStatus)].Item2;
			int amount = chr.Inventory.ItemCount(4001007);

			if (amount == needed)
			{
				FieldSet.SetVar($"{chr.Name}_", "clear");
				chr.Inventory.TakeItem(4001007, (short) needed);
				chr.Inventory.AddNewItem(4001008, 1);
				self.say("That's the right answer! For that you have just received a #bpass#k. Please hand it to your leader of the party.");
				return;
			}
			
			self.say("That's not the right answer. I can only give you the pass if you collect the same number of #bcoupons#k as the answer to the question suggests. I'll repeat the question.");
		}
		
		self.say(Questions[int.Parse(chrStatus)].Item1);
	}

	private void PermutationStage(PermutationStageData stageData)
	{
		if (FieldSet.GetVar("stage") != stageData.Stage.ToString()) return;
		
		if (!IsLeader)
		{
			self.say(stageData.IntroText);
			return;
		}
		
		var puzzle = new PermutationPuzzle(chr.Field, $"ans{stageData.Stage}", 3);

		if (puzzle.Created)
		{
			Next(stageData.IntroText);
			return;
		}

		switch (puzzle.AreaCheck())
		{
			case PermutationResult.NotEnoughPlayers:
				self.say(stageData.NotEnoughPlayersText);
				break;
			case PermutationResult.Wrong:
				FailStage();
				break;
			case PermutationResult.Correct:
				ClearStage((stageData.Stage + 1).ToString(), stageData.Exp);
				OpenPortal();
				break;
		}
	}
	
	private void StageFive()
	{
		if (FieldSet.GetVar("stage") == "clear")
		{
			GiveReward();
			return;
		}
		
		if (!IsLeader)
		{
			self.say("Hello. Welcome to the 5th and final stage. You will see some strong monsters around the map. Defeat all of them and bring the 10 #bpasses#k to me. Once you obtain all the passes, the party leader will gather all 10 and hand them over to me. The monsters may look familiar, but they are much stronger than you think. So be careful. Good luck!");
			return;
		}
		
		int amount = chr.Inventory.ItemCount(4001008);
		if (amount < 10)
		{
			self.say("Hello. Welcome to the 5th and final stage. You will see some strong monsters around the map. Defeat all of them and bring the 10 #bpasses#k to me. Once you obtain all the passes, the party leader will gather all 10 and hand them over to me. The monsters may look familiar, but they are much stronger than you think. So be careful. Good luck!");
			return;
		}
		
		chr.Inventory.TakeItem(4001008, 10);
		ClearStage("clear", 1500);
	}

	private void GiveReward()
	{
		if (SlotCount(1) == 0 || SlotCount(2) == 0 || SlotCount(4) == 0)
		{
			self.say("Hmm. You don't have enough inventory space. Please make sure you have room and talk to me again.");
			return;
		}
		
		int chosenReward = Random(0, 40);
		GiveItem(Rewards[chosenReward], (short) Amounts[chosenReward]);

		if (FieldSet.TimeRemaining > 600 * 1000) 
		{
			FieldSet.ResetTimeOut(TimeSpan.FromSeconds(600));
		}

		ChangeMap(103000805);
	}
}