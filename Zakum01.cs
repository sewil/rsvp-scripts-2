using System;
using WvsBeta.Game;
using WvsBeta.Game.GameObjects;

public class NpcScript : IScriptV2
{
	private PartyData Party => PartyData.Parties[chr.PartyID];
	private FieldSet FieldSet => chr.Field.ParentFieldSet;
	
	public override void Run()
	{
		string retry = GetQuestData(7000006);
		string today = DateTime.UtcNow.ToString("yyyyMMdd");
		string result = FieldSet.GetVar("zakum");
		string leader = FieldSet.GetVar("leader");
		
		if (result == "yes")
		{
			self.say("You have safely passed the test and gotten the #b#t4001018##k to me. Now, enter the portal next to me, and every member of the party will receive the refined #b#t4001018##k, #b#t4031061##k. Since you also have collected more than #b30 #t4001015#s#k in the process, you are also eligible to receive #b#t2030007##k. The portal is open now.");
		}
		else if (result == "no")
		{
			self.say("You have safely passed the test and gotten the #b#t4001018##k to me. Now, enter the portal next to me, and every member of the party will receive the refined #b#t4001018##k, #b#t4031061##k. The portal is open now.");
		}
		else
		{
			self.say("You are the one who wanted to investigate the Dead Mine. You need to gather up the necessary items to reach the point of your final goal: meeting the boss of the Zakum Dungeon. To obtain that item, you'll first need to acquire the materials for that item, right? You can get one of the materials, #b#t4001018##k, right here. It won't be easy, though ...");
			self.say("Here, there is an entrance that leads to numerous caves. Once inside the cave, you'll see some boxes. Destroy them all, and collect #b7 of #t4001016#s#k. The box cannot be destroyed using attack skills; only the regular, basic attack works. Afterwards, gather up the 7 keys, move into the innermost room, where the treasure chest is. Drop the keys there to obtain #b#t4001018##k. It'll take some time after dropping the keys to obtain it, so be patient.");
			self.say("Of course, not every box contains #t4001016#. You'll all run into some very unexpected circumstances, so please be aware of that. Every once in a while, in the middle of going through the boxes, #t4001015# will pop out. Gather those up, too, and something good will definitely happen. You need to collect at least 30 #t4001015#s. This is all I can tell you, for now.");
			int start = AskMenu("Anything do you want to ask?#b",
				(0, " I brought #t4001018#."),
				(1, " Forget the quest, I'm out of here."));
			
			if (start == 0)
			{
				if (chr.Name != leader)
				{
					self.say("Once you have obtained #b#t4001018##k by dropping 7 #b#t4001016#s#k at the huge chest in the cave, please hand the item over to the party leader. Once the leader of the party has #b#t4001018##k in possession and talks to me, that'll signal that you have cleared Level 1.");
					return;
				}
				
				if (ItemCount(4001018) < 1)
				{
					self.say("I guess you haven't gotten #b#t4001018##k yet. Please go through the various treasure chests in here within the time limit, collect #b7 of #t4001016#s#k, and drop them all at the treasure chest in the innermost part of the cave to collect #b#t4001018##k. Once you have obtained the item, please hand it to me.");
					return;
				}
				
				bool complete = false;
				
				int bonusCount = ItemCount(4001015);
				
				if (bonusCount == 0)
				{
					complete = AskYesNo("You brought back #b1 #t4001018##k safely, but it doesn't look like you have brought #b#t4001015# back. Is this all your party has gathered up?");
				}
				else
				{
					complete = AskYesNo($"You have brought back #b1 #t4001018##k and #b{bonusCount} #t4001015#s#k. Is this all the items your party members have gathered up?");
				}
				
				if (!complete)
				{
					self.say("All the items collected from the cave by the party members should be given to the party leader, who'll give them all to me. Please double-check.");
					return;
				}
				
				if (bonusCount == 0)
				{
					if (!Exchange(0, 4001018, -1))
					{
						self.say("Please check and see if you have #b1 #t4001018##k with you.");
						return;
					}
				}
				else
				{
					if (!Exchange(0, 4001018, -1, 4001015, -bonusCount))
					{
						self.say($"Please check and see if you really have #b1 #t4001018##k and #b{bonusCount} #t4001015##k with you.");
						return;
					}
				}
				
				if (bonusCount >= 30)
					FieldSet.SetVar("zakum", "yes");
				else
					FieldSet.SetVar("zakum", "no");
				
				if (retry == "")
				{
					SetQuestData(7000006, $"1{today}");
				}
				else
				{
					string date = retry.Substring(1, 8);
					int retryCount = Int32.Parse(retry.Substring(0, 1)) + 1;
					
					SetQuestData(7000006, $"{retryCount}{date}");
				}
				
				self.say("Alright. Using the portal that's been made down there, you can return to the map where Adobis is. While using the portal, I'll be handing out #b#t4031061##k made out of #b#t4001018##k you've all given me to each and every member of the party. Congratulations on clearing Level 1. See you around ...");
			}
			else if (start == 1)
			{
				bool exit = AskYesNo("If you quit in the middle of a mission, you'll have to start all over again ... not only that, but since it's a party quest, even if one player decides to leave, it may be difficult to clear the level. Are you SURE you want to leave?");
				
				if (exit)
				{
					self.say("Alright, I'll send you to the Exit Map. #b#p2030011##k will be there standing. Go talk to him; He'll let you out. So long ...");
					SetQuestData(7000000, "fail");
					ChangeMap(280090000, "st00");
				}
			}
		}
	}
}