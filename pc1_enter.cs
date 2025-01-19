using System;
using System.Linq;
using System.Collections.Generic;
using WvsBeta.Game;
using WvsBeta.Game.GameObjects;

public class NpcScript : IScriptV2
{
	private void GoPC(string field, string area, string levelrange)
	{
		string today = DateTime.UtcNow.ToString("yyyyMMdd");
		
		if (chr.PartyID == 0)
		{
			string date = GetQuestData(1001301);
			string retry = GetQuestData(1001302, "0");
			
			bool askEnter = AskYesNo($"Do you really want to move to the #b{area}#k? You will find many kinds of monsters (Lv {levelrange}) there. Oh, and when you get there, you can return to the Internet Cafe whenever you want through the portal. Your time limit is #b30 minutes#k.");
		
			if (!askEnter)
			{
				self.say("Other fields are available as well. No need to hurry.");
				return;
			}
			
			if (FieldSet.Instances[field].UserCount != 0 || !FieldSet.IsAvailable(field))
			{
				self.say("Someone else is already inside this this field. Please try again later.");
				return;
			}
			
			int retryCount = Int32.Parse(retry) + 1;
			
			if (date == today)
			{
				if (retryCount > 2)
				{
					self.say("You have already entered Premium Road two times today. Please come back tomorrow.");
					return;
				}
				
				SetQuestData(1001302, retryCount.ToString());
			}
			else
			{
				SetQuestData(1001302, "1");
			}
			
			SetQuestData(1001301, DateTime.UtcNow.ToString("yyyyMMdd"));
			FieldSet.Enter(field, new Character[1]{chr}, chr);
		}
		else
		{
			bool askEnter = AskYesNo($"Do you really want to move to the #b{area}#k? You will find many kinds of monsters (Lv {levelrange}) there. Please make sure the members of your party are ready. Oh, and when you get there, you can return to the Internet Cafe whenever you want through the portal. Your time limit is #b30 minutes#k");
		
			if (!askEnter)
			{
				self.say("Other fields are available as well. No need to hurry.");
				return;
			}
			
			if (FieldSet.Instances[field].UserCount != 0 || !FieldSet.IsAvailable(field))
			{
				self.say("Someone else is already inside this this field. Please try again later.");
				return;
			}
			
			var partyMembers = chr.Field.GetInParty(chr.PartyID).ToArray();
			
			foreach (var partyMember in partyMembers)
			{
				if (GetQuestData(partyMember, 1001301) == today)
				{
					string retry = GetQuestData(partyMember, 1001302, "0");
                    
					int retryCount = Int32.Parse(retry) + 1;
					
					if (retryCount > 2)
					{
						self.say("Someone in your party has already entered the premium road twice today. Please check again.");
						return;
					}
				}
			}
			
			foreach (var partyMember in partyMembers)
			{
				string date = GetQuestData(partyMember, 1001301);
				string retry = GetQuestData(partyMember, 1001302, "0");
				int retryCount = Int32.Parse(retry) + 1;
				
				if (date == today)
				{
					SetQuestData(partyMember, 1001302, retryCount.ToString());
				}
				else
				{
					SetQuestData(partyMember, 1001302, "1");
				}
			}
			
			foreach (var partyMember in partyMembers)
			{
				SetQuestData(partyMember, 1001301, DateTime.UtcNow.ToString("yyyyMMdd"));
			}
			
			FieldSet.Enter(field, partyMembers, chr);
		}
	}
	public override void Run()
	{
		int start1 = AskMenu("This computer can connect you to the monster elimination area.#b",
			(0, " How to play"),
			(1, " Connect to a field"));
		
		if (start1 == 0)
		{
			self.say("The monster elimination area is simple: once you enter Premium Road, you'll be surrounded by monsters. Take them down and they'll occasionally cough up one the #bcomputer mouses#k that were stolen from the cafe.");
			self.say("Collecting these will return them to the cafe automatically and award you #b10 points#k. You can bring up to 6 people in a party, and for each mouse you find, every party member will earn 10 points. You'll have #b30 minutes#k inside Premium Road to find as many as possible.");
			return;
		}
		
		if (chr.PartyID != 0)
		{
			var party = PartyData.Parties[chr.PartyID];
			
			if (party.Leader != chr.ID)
			{
				self.say("To enter Premium Road, please have the leader of your party select which place to connect to.");
				return;
			}
		}
		
		var options = new List<(int, string)>();
		
		if (MapID == 103000007)
		{
			options.Add((0, " Prairie Field"));
			options.Add((1, " Field of Bright Forest"));
			options.Add((2, " Field of Highland"));
			options.Add((3, " Ant Tunnel Dungeon"));
			options.Add((8, " Ski-Camp Field"));
		}
		else if (MapID == 220000309)
		{
			options.Add((4, " Cloud Garden Field"));
			options.Add((5, " Chilly Field"));
			options.Add((6, " Toy Field"));
			options.Add((7, " Aquatic Field"));
			options.Add((9, " Snow Valley Field"));
		}
		
		int start2 = AskMenu("Please choose the place you want to connect to.#b", options.ToArray());
		
		switch(start2)
		{
			//Kerning
			case 0: GoPC("PC1", "Prairie Field", "6 ~ 55"); break;
			case 1: GoPC("PC2", "Field of Bright Forest", "15 ~ 40"); break;
			case 2: GoPC("PC3", "Field of Highland", "10 ~ 32"); break;
			case 3: GoPC("PC4", "Ant Tunnel Dungeon", "22 ~ 62"); break;
			case 8: GoPC("PC9", "Ski-Camp Field", "10 ~ 38"); break;
			
			//Ludi
			case 4: GoPC("PC7", "Cloud Garden Field", "23 ~ 53"); break;
			case 5: GoPC("PC5", "Chilly Field", "50 ~ 78"); break;
			case 6: GoPC("PC6", "Toy Field", "30 ~ 32"); break;
			case 7: GoPC("PC8", "Aquatic Field", "28 ~ 94"); break;
			case 9: GoPC("PC10", "Snow Valley Field", "30 ~ 70"); break;
		}
	}
}