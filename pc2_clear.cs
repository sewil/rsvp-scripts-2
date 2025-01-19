using System;
using System.Collections.Generic;
using WvsBeta.Game;
using WvsBeta.Common;
using System.Linq;
using WvsBeta.Game.GameObjects;

class Portal : IScriptV2
{
	Random rnd = new Random();
	
	private FieldSet FieldSet => chr.Field.ParentFieldSet;
	
	private List<int> GetMapList(string mode)
	{
		var mapList = new List<int>();
		
		if (mode == "0")
		{
			mapList.Add(902000100);
			mapList.Add(902000200);
			mapList.Add(902000300);
			mapList.Add(902000400);
			mapList.Add(902000500);
			mapList.Add(902000600);
			mapList.Add(902000700);
		}
		else if (mode == "1")
		{
			mapList.Add(902010100);
			mapList.Add(902010200);
			mapList.Add(902010300);
			mapList.Add(902010400);
			mapList.Add(902010500);
			mapList.Add(902010600);
			mapList.Add(902010700);
			mapList.Add(902010800);
			mapList.Add(902010900);
		}
		else if (mode == "2")
		{
			mapList.Add(902020100);
			mapList.Add(902020200);
			mapList.Add(902020300);
			mapList.Add(902020400);
			mapList.Add(902020500);
			mapList.Add(902020600);
			mapList.Add(902020700);
			mapList.Add(902020800);
			mapList.Add(902020900);
		}
		else if (mode == "3")
		{
		}
		
		string checkList = FieldSet.GetVar($"{chr.Name}List", "");
		
		foreach (int map in mapList.ToArray())
		{
			if (checkList.Contains($"-{map}"))
				mapList.Remove(map);
		}
		
		return mapList;
	}
	
	private void Start()
	{
		var maps = GetMapList(MapID.ToString().Substring(4, 1));
		
		if (FieldSet.GetVar("started") != "yes")
		{
			FieldSet.SetVar("count", FieldSet.Characters.Count().ToString());
			FieldSet.SetVar("winner", "0");
			FieldSet.SetVar("started", "yes");
			if (int.Parse(FieldSet.GetVar("count")) >= 2)
				FieldSet.SetVar("party", "yes");
			else
				FieldSet.SetVar("party", "no");
		}
		
		SetQuestData(1001303, "1");
		SetQuestData(1001304, "0");
		SetQuestData(1001305, DateTime.UtcNow.ToString());
		
		ChangeMap(maps[rnd.Next(maps.Count)]);
		
		MapPacket.MapEffect(chr, 3, "quest/pc/start", true);
	}
	
	private void ClearStage(int reqStageCount, int mapTime, int points, int bonusPoints)
	{
		var maps = GetMapList(MapID.ToString().Substring(4, 1));
		
		int stage = int.Parse(GetQuestData(1001303, "1"));
		int totalPoints = int.Parse(GetQuestData(1001304, "0"));
		var stageTime = DateTime.Parse(GetQuestData(1001305, DateTime.UtcNow.ToString()));
		
		var seconds = (DateTime.UtcNow - stageTime).TotalSeconds;
		
		var timeDifference = mapTime - seconds;
		
		if (timeDifference < 0)
		{
			int newPoints = (int)(points + (timeDifference * 0.8));
			
			if (newPoints < (int)(points * 0.6))
				points = (int)(points * 0.6);
			else
				points = newPoints;
		}
		
		if (int.Parse(FieldSet.GetVar("count")) >= 2)
		{
			FieldSet.Characters.ForEach(character =>
			{
				character.AddPoints(bonusPoints);
			});
		}
		
		SetQuestData(1001304, (totalPoints + points).ToString());
		Message($"You earned {points} points for clearing stage {stage}/{reqStageCount} in {(int)seconds} seconds.");
		
		if (stage >= reqStageCount)
		{
			RemoveQuest(1001305);
			ClearChallenge(MapID.ToString().Substring(4, 1));
		}
		else
		{
			maps.Remove(MapID);
			
			int newMap = maps[rnd.Next(maps.Count)];
			string checkList = FieldSet.GetVar($"{chr.Name}List", "");
			
			FieldSet.SetVar($"{chr.Name}List", $"{checkList}-{MapID}");
			SetQuestData(1001303, (stage + 1).ToString());
			SetQuestData(1001305, DateTime.UtcNow.ToString());
			ChangeMap(newMap, "st00");
		}
	}
	
	private void ClearChallenge(string level)
	{
		// Send directly to bonus if player is by themselves
		if (FieldSet.GetVar("party") != "yes")
		{
			Message("You have cleared the Cafe Jump Challenge!");
			
			FieldSet.ResetTimeOut(TimeSpan.FromSeconds(45));
			switch(level)
			{
				case "0": ChangeMap(902000900, "st00"); break;
				case "1": ChangeMap(902011100, "st00"); break;
				case "2": ChangeMap(902021100, "st00"); break;
			//	case "3": ChangeMap(902000900, "st00"); break;
			}
		}
		else
		{
			int remaining = int.Parse(FieldSet.GetVar("count")) - 1;
			int winnerCount = int.Parse(FieldSet.GetVar("winner"));
			
			FieldSet.SetVar("count", remaining.ToString());
			
			FieldSet.Characters.ForEach(character =>
			{
				if (remaining == 1)
					Message(character, $"{chr.Name} has cleared the Cafe Challenge! {remaining} player remaining.");
				else if (remaining > 1)
					Message(character, $"{chr.Name} has cleared the Cafe Challenge! {remaining} players remaining.");
				else
					Message(character, $"{chr.Name} has cleared the Cafe Challenge! Talk to Billy to proceed to the next area.");
			});
			
			int clearMap = -1;
			
			switch(level)
			{
				case "0": clearMap = 902000800; break;
				case "1": clearMap = 902011000; break;
				case "2": clearMap = 902021100; break;
			//	case "3": clearMap = 902000900; break;
			}
			
			switch(winnerCount)
			{
				case 0: ChangeMap(clearMap, "st00"); break;
				case 1: ChangeMap(clearMap, "st01"); break;
				case 2: ChangeMap(clearMap, "st02"); break;
				case 3: ChangeMap(clearMap, "st03"); break;
				case 4: ChangeMap(clearMap, "st04"); break;
				case 5: ChangeMap(clearMap, "st05"); break;
			}
			
			FieldSet.SetVar("winner", (winnerCount + 1).ToString());
		}
		
		MapPacket.MapEffect(chr, 4, "Party1/Clear", true);
		MapPacket.MapEffect(chr, 3, "quest/party/clear", true);
	}
	
	public override void Run()
	{
		MapPacket.PlayPortalSE(chr);
		
		switch(MapID)
		{
			// Easy Course
			case 902000000: Start(); break;
			case 902000100: ClearStage(7, 65, 285, 45); break;
			case 902000200: ClearStage(7, 50, 210, 35); break;
			case 902000300: ClearStage(7, 80, 360, 60); break;
			case 902000400: ClearStage(7, 50, 285, 60); break;
			case 902000500: ClearStage(7, 80, 425, 70); break;
			case 902000600: ClearStage(7, 120, 415, 50); break;
			case 902000700: ClearStage(7, 40, 30, 30); break;
			
			// Advanced Course
			case 902010000: Start(); break;
			case 902010100: ClearStage(5, 65, 825, 80); break;
			case 902010200: ClearStage(5, 55, 980, 110); break;
			case 902010300: ClearStage(5, 90, 945, 90); break;
			case 902010400: ClearStage(5, 45, 900, 90); break;
			case 902010500: ClearStage(5, 90, 930, 100); break;
			case 902010600: ClearStage(5, 95, 980, 110); break;
			case 902010700: ClearStage(5, 70, 725, 70); break;
			case 902010800: ClearStage(5, 90, 845, 90); break;
			case 902010900: ClearStage(5, 55, 770, 80); break;
			
			// Expert Course
			case 902020000: Start(); break;
			case 902020100: ClearStage(7, 20, 190, 20); break;
			case 902020200: ClearStage(7, 20, 140, 15); break;
			case 902020300: ClearStage(7, 20, 240, 30); break;
			case 902020400: ClearStage(7, 20, 190, 30); break;
			case 902020500: ClearStage(7, 20, 295, 35); break;
			case 902020600: ClearStage(7, 20, 290, 25); break;
			case 902020700: ClearStage(7, 20, 20, 15); break;
			case 902020800: ClearStage(7, 20, 20, 15); break;
			case 902020900: ClearStage(7, 20, 20, 15); break;
		}
	}
}