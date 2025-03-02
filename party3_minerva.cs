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
	
	private void TakeAwayItem()
	{
		int[] items = {4001044, 4001045, 4001046, 4001047, 4001048, 4001049, 4001050, 4001051, 4001052, 4001053, 4001054, 4001055, 4001056, 4001057, 4001058, 4001059, 4001060, 4001061, 4001062, 4001063, 4001074};
		
		foreach (int item in items)
		{
			int count = ItemCount(item);
			
			if (count >= 1)
				Exchange(0, item, -count);
		}
		
		return;
	}
	
	private void ClearMissionReward(string mission)
	{
		if (mission == "1")
		{
			if (FieldSet.TimeRemaining / 1000 < 1504)
			{
				FieldSet.Characters.ForEach(character =>
				{
					character.AddEXP(10000, true, true);
					Message(character, "<Mission Complete> Additional EXP is rewarded for completing the mission within 25 minutes.");
				});
			}
		}
		else if (mission == "2")
		{
			int count = ItemCount(4001053);
			
			if (count >= 8)
			{
				Exchange(0, 4001053, -count);
				FieldSet.Characters.ForEach(character =>
				{
					character.AddEXP(5000, true, true);
					Message(character, "<Mission Complete> Additional EXP is rewarded for collecting 8 Strange Seeds successfully.");
				});
			}
		}
		else if (mission == "3")
		{
			int count = ItemCount(4001056) + ItemCount(4001057) + ItemCount(4001058) + ItemCount(4001059) + ItemCount(4001060) + ItemCount(4001061) + ItemCount(4001062);
			
			if (count >= 6)
			{
				FieldSet.Characters.ForEach(character =>
				{
					character.AddEXP(6000, true, true);
					Message(character, "<Mission Complete> Additional EXP is rewarded for collecting 6 LP’s.");
				});
			}
		}
		else if (mission == "4")
		{
			int mobCount = MobCount(920010910, 9300044) + MobCount(920010920, 9300044) + MobCount(920010930, 9300044);
			
			if (mobCount == 0)
			{
				FieldSet.Characters.ForEach(character =>
				{
					character.AddEXP(8000, true, true);
					Message(character, "<Mission Complete> Additional EXP is rewarded for eliminating Louinel successfully.");
				});
			}
		}
		else if (mission == "5")
		{
			int mobCount = MobCount(920011000, 9300051) + MobCount(920011000, 9300052) + MobCount(920011000, 9300053);
			
			if (mobCount == 0)
			{
				FieldSet.Characters.ForEach(character =>
				{
					character.AddEXP(5000, true, true);
					Message(character, "<Mission Complete> Additional EXP is rewarded for eliminating Jr. Cellion, Jr. Grupin and Jr. Lioner successfully!");
				});
			}
		}
	}
	
	private void GiveEXP(int exp, int forStage)
	{
		FieldSet.Characters.ForEach(character =>
		{
			string questData = character.Quests.GetQuestData(7020);

			if (int.TryParse(questData, out int maxCompletedStage) && maxCompletedStage >= forStage)
			{
				character.AddEXP(exp * 0.7, true, true);
			}
			else
			{
				character.AddEXP(exp, true, true);
				character.Quests.SetQuestData(7020, forStage.ToString());
			}
		});
	}
	
	public override void Run()
	{
		if (MapID == 920010100)
		{
			self.say("Thanks for not only fixing the statue, but also for setting me free. May the blessing of the Goddess be with you until the end...");
			
			if (!IsLeader)
			{
				self.say("Now please continue with the leader of your party leading the way.");
				return;
			}
			
			GiveEXP(23000, 7);
			
			string mission = GetFieldsetVar("cMission");
			
			if (mission != null && mission != "0")
			{
				ClearMissionReward(mission);
			}
			
			FieldSet.ResetTimeOut(TimeSpan.FromMinutes(1));
			FieldSet.Characters.ToList().ForEach(character =>
			{
				character.ChangeMap(920011100, "st00");
			});
		}
		else if (MapID == 920011300)
		{
			int diary = 1;
			int[] items = {4001064, 4001065, 4001066, 4001067, 4001068, 4001069, 4001070, 4001071, 4001072, 4001073};
			
			foreach (int item in items)
			{
				if (ItemCount(item) == 0)
				{
					diary = 0;
					break;
				}
			}
			
			if (diary == 1)
			{
				self.say("Hey, isn't this a loose page from my diary? Thank you so much for finding it! I mean, I wrote this and ended up trapped inside the statue... a few hundred years ago. I can't remember.");
				bool complete = AskYesNo("The diary says how I ended up trapped inside the statue. Like I always say, I don't make the same mistake twice. I'll make a record of it and give it to you.");
				
				if (!complete)
				{
					self.say("If a record is made, a lot can be discovered... hum...");
				}
				else
				{
					if (ItemCount(4161014) >= 1)
					{
						self.say("You already have #b#t4161014##k.");
					}
					else
					{
						if (!Exchange(0, 4001064, -1, 4001065, -1, 4001066, -1, 4001067, -1, 4001068, -1, 4001069, -1, 4001070, -1, 4001071, -1, 4001072, -1, 4001073, -1, 4161014, 1))
						{
							self.say("By chance did you... lose that page from my diary?");
							return;
						}
						
						self.say("Please take good care of my diary.");
					}
				}
			}
			
			self.say("Thank you so much for rescuing me. I have a little gift as a token of your heroic attitude. Please accept it. But first, check if you have a free slot in your equip., etc., and use inventory.");
			
			if (SlotCount(1) < 1 || SlotCount(2) < 1 || SlotCount(4) < 1)
			{
				self.say("Are you sure you have an available slot in your use or etc. inventory? I cannot reward you if the inventory is full.");
				return;
			}
			
			var rewards = new List<(int, int, int)>();
			
			#region Reward Data
			
			rewards.Add((2000003, 100, 50));
			rewards.Add((2000004, 20, 35));
			rewards.Add((2000005, 10, 30));
			rewards.Add((2000002, 100, 30));
			rewards.Add((2000006, 50, 20));
			rewards.Add((2000004, 10, 1));
			rewards.Add((2000002, 100, 1));
			rewards.Add((2000003, 100, 1));
			rewards.Add((2000006, 50, 1));
			rewards.Add((2022000, 50, 1));
			rewards.Add((2022003, 50, 1));
			rewards.Add((2040002, 1, 1));
			rewards.Add((2040402, 1, 1));
			rewards.Add((2040502, 1, 1));
			rewards.Add((2040505, 1, 1));
			rewards.Add((2040602, 1, 1));
			rewards.Add((2040802, 1, 1));
			rewards.Add((4003000, 70, 1));
			rewards.Add((4010000, 20, 1));
			rewards.Add((4010001, 20, 1));
			rewards.Add((4010002, 20, 1));
			rewards.Add((4010003, 20, 1));
			rewards.Add((4010004, 20, 1));
			rewards.Add((4010005, 20, 1));
			rewards.Add((4010006, 15, 1));
			rewards.Add((4020000, 20, 1));
			rewards.Add((4020001, 20, 1));
			rewards.Add((4020002, 20, 1));
			rewards.Add((4020003, 20, 1));
			rewards.Add((4020004, 20, 1));
			rewards.Add((4020005, 20, 1));
			rewards.Add((4020006, 20, 1));
			rewards.Add((4020007, 10, 1));
			rewards.Add((4020008, 10, 1));
			rewards.Add((1032013, 1, 1));
			rewards.Add((1032011, 1, 1));
			rewards.Add((1032014, 1, 1));
			rewards.Add((1102021, 1, 1));
			rewards.Add((1102022, 1, 1));
			rewards.Add((1102023, 1, 1));
			rewards.Add((1102024, 1, 1));
			rewards.Add((2040803, 1, 1));
			rewards.Add((2070011, 1, 1));
			rewards.Add((2043001, 1, 1));
			rewards.Add((2043101, 1, 1));
			rewards.Add((2043201, 1, 1));
			rewards.Add((2043301, 1, 1));
			rewards.Add((2043701, 1, 1));
			rewards.Add((2043801, 1, 1));
			rewards.Add((2044001, 1, 1));
			rewards.Add((2044101, 1, 1));
			rewards.Add((2044201, 1, 1));
			rewards.Add((2044301, 1, 1));
			rewards.Add((2044401, 1, 1));
			rewards.Add((2044501, 1, 1));
			rewards.Add((2044601, 1, 1));
			rewards.Add((2044701, 1, 1));
			rewards.Add((2000004, 35, 1));
			rewards.Add((2000002, 80, 1));
			rewards.Add((2000003, 80, 1));
			rewards.Add((2000006, 35, 1));
			rewards.Add((2022000, 35, 1));
			rewards.Add((2022003, 35, 1));
			rewards.Add((4003000, 75, 1));
			rewards.Add((4010000, 18, 1));
			rewards.Add((4010001, 18, 1));
			rewards.Add((4010002, 18, 1));
			rewards.Add((4010003, 18, 1));
			rewards.Add((4010004, 18, 1));
			rewards.Add((4010005, 18, 1));
			rewards.Add((4010006, 12, 1));
			rewards.Add((4020000, 18, 1));
			rewards.Add((4020001, 18, 1));
			rewards.Add((4020002, 18, 1));
			rewards.Add((4020003, 18, 1));
			rewards.Add((4020004, 18, 1));
			rewards.Add((4020005, 18, 1));
			rewards.Add((4020006, 18, 1));
			rewards.Add((4020007, 7, 1));
			rewards.Add((4020008, 7, 1));
			rewards.Add((2040001, 1, 1));
			rewards.Add((2040004, 1, 1));
			rewards.Add((2040301, 1, 1));
			rewards.Add((2040401, 1, 1));
			rewards.Add((2040501, 1, 1));
			rewards.Add((2040504, 1, 1));
			rewards.Add((2040601, 1, 1));
			rewards.Add((2040601, 1, 1));
			rewards.Add((2040701, 1, 1));
			rewards.Add((2040704, 1, 1));
			rewards.Add((2040707, 1, 1));
			rewards.Add((2040801, 1, 1));
			rewards.Add((2040901, 1, 1));
			rewards.Add((2041001, 1, 1));
			rewards.Add((2041004, 1, 1));
			rewards.Add((2041007, 1, 1));
			rewards.Add((2041010, 1, 1));
			rewards.Add((2041013, 1, 1));
			rewards.Add((2041016, 1, 1));
			rewards.Add((2041019, 1, 1));
			rewards.Add((2041022, 1, 1));
			
			#endregion
			
			var reward = rewards.RandomElementByWeight(tuple => tuple.Item3);
			
			if (reward == default)
				return;
			
			int itemID = reward.Item1;
			int itemNum = reward.Item2;
			
			if (!Exchange(0, itemID, itemNum))
			{
				self.say("Are you sure you have an available slot in your use or etc. inventory? I cannot reward you if the inventory is full.");
				return;
			}
			
			TakeAwayItem();
			SetQuestData(7020, 8);
			ChangeMap(920011200);
		}
	}
}