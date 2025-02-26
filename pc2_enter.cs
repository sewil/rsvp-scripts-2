using System;
using System.Linq;
using WvsBeta.Game;
using WvsBeta.Game.GameObjects;

public class NpcScript : IScriptV2
{
	private void GoPC(string field, string area, string levels)
	{
		string today = DateTime.UtcNow.ToString("yyyyMMdd");
		
		if (chr.PartyID == 0)
		{
			string date = GetQuestData(1001301);
			string retry = GetQuestData(1001302, "0");
			
			bool askEnter = AskYesNo($"Do you really want to try the #b{area}#k? There are many obstacles to overcome. Oh, and when you get there, you can return to the Internet Cafe whenever you want at the computer inside. Your time limit is #b20 minutes#k and you must complete #b{levels} stages#k to clear the challenge.");
		
			if (!askEnter)
			{
				self.say("Other fields are available as well. No need to hurry.");
				return;
			}
		
			if (FieldSet.Instances[field].UserCount != 0 || !FieldSet.IsAvailable(field))
			{
				self.say("Someone else is already inside this challenge. Please try again later.");
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
			}
			else
			{
				retryCount = 1;
			}

			if (!Exchange(0, 4030017, -1))
			{
				self.say("I'm sorry, but without a #b#t4030017##k (#i4030017#), I cannot let you in. Please talk to me again when you have acquired a ticket.");
				return;
			}
			
			SetQuestData(1001302, retryCount.ToString());
			SetQuestData(1001301, DateTime.UtcNow.ToString("yyyyMMdd"));
			FieldSet.Enter(field, new Character[1]{chr}, chr);
		}
		else
		{
			bool askEnter = AskYesNo($"Do you really want to try the #b{area}#k? There are many obstacles to overcome. Please make sure the members of your party are ready. Oh, and when you get there, you can return to the Internet Cafe whenever you want through the portal. Your time limit is #b20 minutes#k and your party must complete #b{levels} stages#k to clear the challenge.");
		
			if (!askEnter)
			{
				self.say("Other fields are available as well. No need to hurry.");
				return;
			}
			
			if (FieldSet.Instances[field].UserCount != 0 || !FieldSet.IsAvailable(field))
			{
				self.say("Someone else is already inside this challenge. Please try again later.");
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

			if (!Exchange(0, 4030017, -1))
			{
				self.say("I'm sorry, but without a #b#t4030017##k (#i4030017#), I cannot let you in. Please talk to me again when you have acquired a ticket.");
				return;
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
		int start1 = AskMenu("This computer can connect you to the Cafe Jump Challenge.#b",
			(0, " How to play"),
			(1, " Enter a course"));
		
		if (start1 == 0)
		{
			self.say("The Cafe Jump Challenge is simple: you will be sent to an obstacle course randomly. If you can reach the top, you can move on to the next stage. You'll have 20 minutes to clear the required number of stages for each difficulty.");
			self.say("Each stage cleared will earn you points. The faster the stage is cleared, the more points you can earn; if you can clear the challenge, you will be sent to a bonus area where you can collect computer mouses by breaking boxes.");
			self.say("You can enter by yourself or with a party, but keep in mind, you and each party member can only enter #btwice a day#k. One last thing, If a party member leaves early then your party won't be able to move to the bonus stage. Good luck!");
			return;
		}
		
		if (chr.PartyID != 0)
		{
			var party = PartyData.Parties[chr.PartyID];
			
			if (party.Leader != chr.ID)
			{
				self.say("To enter Premium Road, please have the leader of your party choose a difficulty.");
				return;
			}
		}
		
		int start = -1;
		
		if (MapID == 103000007)
		{
			start = AskMenu("Please choose the course you want to connect to.#b",
				(0, " Beginner course"),
				(1, " Advanced course"));
		}
		else if (MapID == 220000309)
		{
			self.say("This computer is currently unavailable.");
			return;
			/*
			start = AskMenu("Please choose the course you want to connect to.#b",
				(2, " Expert course"));
		//		(3, " Master course"));
			*/
		}
		
		switch(start)
		{
			case 0: GoPC("PC100", "beginner course", "7"); break;
			case 1: GoPC("PC101", "advanced course", "5"); break;
			case 2: GoPC("PC102", "expert course", "4"); break;
			case 3: GoPC("PC103", "master course", "2"); break;
		}
	}
}