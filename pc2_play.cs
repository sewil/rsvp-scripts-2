using System;
using System.Linq;
using WvsBeta.Game;
using WvsBeta.Game.GameObjects;

public class NpcScript : IScriptV2
{
	private FieldSet FieldSet => chr.Field.ParentFieldSet;
	
	Random rnd = new Random();
	
	public override void Run()
	{
		// Challenge complete map
		if (MapID == 902000800 || MapID == 902011000 || MapID == 902021000)
		{
			if (chr.PartyID == 0 || FieldSet.GetVar("party") != "yes")
			{
				self.say("You don't seem to be in a party, I'll take you to the nearest exit.");
				
				switch(MapID)
				{
					case 902000800: ChangeMap(902001100); break;
					case 902011000: ChangeMap(902011300); break;
					case 902021000: ChangeMap(902021300); break;
				}
				
				return;
			}
			
			var party = PartyData.Parties[chr.PartyID];
			
			if (party.Leader != chr.ID)
			{
				self.say("When all members of the party have cleared the challenge, have the leader of the party speak to me.");
				return;
			}
			
			if (FieldSet.GetVar("count") != "0")
			{
				self.say("It doesn't look like everyone has cleared the challenge. When everyone is here, come talk to me.");
				return;
			}
			
			self.say("Congratulations on clearing the Cafe Challenge!! I'll take you and your party to the bonus map.");
			
			int bonusMap = -1;
			
			switch(MapID)
			{
				// Bonus maps
				case 902000800: bonusMap = 902000900; break;
				case 902011000: bonusMap = 902011100; break;
				case 902021000: bonusMap = 902021100; break;
			}
			
			FieldSet.ResetTimeOut(TimeSpan.FromSeconds(45));
			FieldSet.Characters.ToList().ForEach(character =>
			{
				character.ChangeMap(bonusMap);
			});
		}
		
		// Bonus map
		else if (MapID == 902000900 || MapID == 902011100 || MapID == 902021100)
		{
			self.say("This is the bonus room, break boxes and you might find some more of those missing computer mouses. Well, you've only got #b45 seconds#k, what are you talking to me for? Go!");
		}
		
		// Winner exit
		else if (MapID == 902001000 || MapID == 902011200 || MapID == 902021200)
		{
			self.say("Awesome job... you really completed the challenge! I'll take you back to the Cafe for now.");
			
			/*
			if (SlotCount(1) < 1 || SlotCount(2) < 1 || SlotCount(4) < 1)
			{
				self.say("Please make sure there's room in your equip., use, and etc. inventories first.");
				return;
			}
			
			int[] items = {2000000};
			int[] counts = {1};
			
			int rnum = rnd.Next(items.Length);
			
			int itemID = items[rnum];
			int itemNum = counts[rnum];
			
			if (!Exchange(0, itemID, itemNum))
			{
				self.say("Are you sure you have enough room in your inventory for my reward?");
				return;
			}
			
			*/
			int points = Int32.Parse(GetQuestData(1001304, "0"));
			
			if (points >= 1)
			{
				AddPoints(points);
				RemoveQuest(1001304);
			}
			
			switch(MapID)
			{
				case 902001000: ChangeMap(103000007); break;
				case 902011200: ChangeMap(103000007); break;
				case 190031000: ChangeMap(220000309); break;
				case 190041000: ChangeMap(220000309); break;
			}
		}
	}
}