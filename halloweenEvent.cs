using System;
using WvsBeta.Game;
using System.Collections.Generic;
using WvsBeta.Common;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		var options = new List<(int, string)>();
		
		if (ItemCount(4031279) >= 1)
			options.Add((0, " I found your broomstick"));
		
		if (MapID == 109110000)
			options.Add((1, " I want to get out of here..."));
		
		if (options.Count == 0)
		{
			self.say("I can't believe I lost my broomstick... and in the forest of all places..! Hey you, if you find my broomstick I'll give you something nice.");
			return;
		}
		
		int exit = AskMenu("I can't believe I lost my broomstick... and in the forest of all places..! Hey you, if you find my broomstick I'll give you something nice.#b", options.ToArray());
		
		if (exit == 0)
		{
			bool trade = AskYesNo("Oh, so you do have my broomstick. Hand it here, quickly! Oh and make sure there's a slot open in your equip. and use inventory.");
			
			if (!trade)
			{
				self.say("What?! You're going to keep it for yourself? Don't play dumb, talk to me when you want to make a trade.");
				return;
			}
			
			if (SlotCount(1) < 1 || SlotCount(2) < 1)
			{
				self.say("Hey, you need a free space in your equip. and use inventories!");
				return;
			}
			
			var rewards = new List<(int, int, int)> {
				(2022256, 100, 80),
				(2022106, 100, 80),
				(2022255, 100, 80),
				(2022105, 50, 40),
				(2022107, 25, 15),
				(1432013, 1, 4),
				(1002699, 1, 1)
			};
			
			var item = rewards.RandomElementByWeight(tuple => tuple.Item3);
			
			if (item == default)
				return;
			
			int itemID = item.Item1;
			int itemNum = item.Item2;
			
			if (!Exchange(0, 4031279, -1, itemID, itemNum))
			{
				self.say("If you have the broomstick, make sure you have room in your use and equip. inventory.");
				return;
			}
			
			ChangeMap(109050000);
		}
		else if (exit == 1)
		{
			bool leave = AskYesNo("What? You're leaving?? Fine, I can take you out of here. Are you sure you want to leave?");
			
			if (!leave)
			{
				self.say("Make up your mind!");
				return;
			}
			
			ChangeMap(109050001);
		}
	}
}