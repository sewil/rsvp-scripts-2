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
	
	private void HelpText()
	{
		if (MapID == 920010000)
		{
			self.say("I don't know what to say. Thank you for collecting pieces of my body. I'm Eak, the trusted chamberlain of the Goddess Minerva. You're here to rescue Minerva, aren't you? I will try to help. All right, I'll take you to the entrance of the tower.");
		}
		else if (MapID == 920010100)
		{
			self.say("Yes, the broken statue next to me is where #bMinerva#k is currently trapped. To rescue #bMinerva#k, you will need to gather #b6 pieces of the statue#k to repair the broken parts and bring the #b#t4001055##k to apply the mystic power to the statue.");
			self.say("Search the tower carefully to find the #bPieces of the Goddess Statue#k and the #bGrass of Life#k to rescue the Goddess Minerva!");
		}
		else if (MapID == 920010200)
		{
			self.say("This is the path to the Tower of the Goddess. The pixies broke #b#t4001044# into 30 pieces#k and took each of them. Please finish off the Pixies and bring back the #b#t4001050##k; in return, I'll create #b#t4001044##k with them. The Pixies are strengthened with the power of the Goddess statue, so be careful~");
		}
		else if (MapID == 920010300)
		{
			self.say("This was the ancient storage of the Tower of the Goddess, but now it has become home to the Cellions. A Cellion took #b#t4001045##k and hid it. You must defeat it and bring back the #bpiece of the statue#k.");
		}
		else if (MapID == 920010400)
		{
			self.say("This is the Lobby of Tower of the Goddess. It's here where the Goddess Minerva likes to listen to music. She loved to listen to various kinds of music, depending on the day of the week.");
			self.say("The Goddess liked to listen to different types of music depending on the day.\r\n#bOn Monday, she likes cute music; something charming and adorable\r\nOn Tuesday, creepy songs that, my God, would freak anyone out\r\nOn Wednesday, fun music, something to dance to;\r\nOn Thursday, sad music;\r\nOn Friday, she likes music that sends chills down her spine\r\nOn Saturday, she preferred to listen to fast music with short arrangements\r\nAnd, on Sunday, opera to go with the mood#k\r\nThe Goddess changed her tastes every day. She really studied music.");
			self.say("If you play the music from before, the spirit of Goddess Minerva might react and... something might happen.");
		}
		else if (MapID == 920010500)
		{
			self.say("This is the Sealed Room of the Tower of the Goddess. It's the room where the Goddess Minerva felt safe enough to keep her valuable possessions.");
			self.say("The three steps to the side work like locks that can release the curse and they all need to support the same weight. Let's see... this will require that five of you stay on top of them to reach the ideal weight. Also, you'll need to solve the combination within 7 attempts and not change the answer, or you will be banned from the sealed room.");
		}
		else if (MapID == 920010600)
		{
			self.say("This is the lounge of the Tower of the Goddess, where the guests would stay for a few nights. #b#t4001048##k broke into 40 pieces scattered all over the place. Please find and piece together the pieces of #b#t4001052##k.");
		}
		else if (MapID == 920010700)
		{
			self.say("This is the way to the top of the Tower of the Goddess. At the top, there are 5 levers that control the gate to the top. Your duty is to correctly identify the two levers that need to be moved. Once that's done, let me know and I'll tell you if the correct levers were moved or not.");
		}
		else if (MapID == 920010800)
		{
			self.say("This is the garden of the Tower of the Goddess. The #bGrass of Life#k can only grow in this flower pot. Just grow the grass to get the seed... oh, by the way, be careful. You might encounter #bPapa Pixie#k, the very one who trapped the Goddess in the statue.");
		}
		else if (MapID == 920010900)
		{
			self.say("This is the Room of the Guilty in the Tower of the Goddess. The Goddess Minerva used to keep in this place the most sinister monsters who committed the worst crimes. Fortunately, no part of the statue can be found in this location, so head back up the side to the right of this room. I'll say it one more time... something may be hidden...");
		}
		else if (MapID == 920011000)
		{
			self.say("Argh, it's so dark here. You are now in the Room of Darkness in the Tower of the Goddess. Hey, how did you get here? You won't find any part of the goddess statue here. I suggest you look in the other rooms.");
		}
		
		if (!IsLeader)
		{
			self.say("Now please continue with the leader of your party leading the way.");
		}
	}
	
	private void PartyExit()
	{
		if (MapID != 920011200)
		{
			int ask = AskMenu("What are you going to do?#b",
				(0, " Listen to Eak."),
				(1, " Abandon the Party Quest and leave.")
			);
			
			if (ask == 0)
			{
				HelpText();
				return;
			}
			
			bool exit = AskYesNo("Do you really want to leave?");
			
			if (!exit)
			{
				self.say("Think carefully about your options and talk to me.");
				return;
			}
			
			ChangeMap(920011200, "st00");
		}
		else
		{
			TakeAwayItem();
			RemoveBuff(2022090);
			RemoveBuff(2022091);
			RemoveBuff(2022092);
			RemoveBuff(2022093);
			ChangeMap(200080101);
		}
	}
	
	private void QuizAnswer()
	{
		var rnd = new Random();
		
		int answer1 = rnd.Next(0, 6);
		int answer2 = rnd.Next(0, 6 - answer1);
		int answer3 = 5 - answer1 - answer2;
		
		switch(rnd.Next(0, 6))
		{
			case 0:
				FieldSet.SetVar("ans1", answer1.ToString());
				FieldSet.SetVar("ans2", answer2.ToString());
				FieldSet.SetVar("ans3", answer3.ToString());
				break;
			
			case 1:
				FieldSet.SetVar("ans1", answer1.ToString());
				FieldSet.SetVar("ans3", answer2.ToString());
				FieldSet.SetVar("ans2", answer3.ToString());
				break;
			
			case 2:
				FieldSet.SetVar("ans2", answer1.ToString());
				FieldSet.SetVar("ans1", answer2.ToString());
				FieldSet.SetVar("ans3", answer3.ToString());
				break;
			
			case 3:
				FieldSet.SetVar("ans2", answer1.ToString());
				FieldSet.SetVar("ans3", answer2.ToString());
				FieldSet.SetVar("ans1", answer3.ToString());
				break;
			
			case 4:
				FieldSet.SetVar("ans3", answer1.ToString());
				FieldSet.SetVar("ans1", answer2.ToString());
				FieldSet.SetVar("ans2", answer3.ToString());
				break;
			
			case 5:
				FieldSet.SetVar("ans3", answer1.ToString());
				FieldSet.SetVar("ans2", answer2.ToString());
				FieldSet.SetVar("ans1", answer3.ToString());
				break;
		}
	}
	
	private void PreStage(string stageRecord)
	{
		if (stageRecord == "clear")
		{
			self.say("All right, I'll take you to the tower entrance.");
			ChangeMap(920010000, "st00");
			return;
		}
		
		if (!IsLeader)
		{
			self.say("Thank you for raising my body. You're all here to rescue the Goddess Minerva, aren't you? I'll help as much as I can. Now please continue with the leader of your party leading the way.");
			return;
		}
		
		FieldSet.Characters.ForEach(character =>
		{
			MapPacket.MapEffect(character, 3, "quest/party/clear", true);
			MapPacket.MapEffect(character, 4, "Party1/Clear", true);
		});
		
		GiveEXP(6000, 0);
		FieldSet.SetVar("prestage", "clear");
		self.say("Thank you for raising my body. You're all here to rescue the Goddess Minerva, aren't you? I'll help as much as I can. All right, I'll take you to the tower entrance.");
		
		FieldSet.Characters.ToList().ForEach(character =>
		{
			character.ChangeMap(920010000, "st00");
		});
	}
	
	private void Stage1(string stageRecord)
	{
		int statue = GetReactorState(920010101, 3, 38);
		
		if (!IsLeader)
		{
			if (stageRecord == null || stageRecord == "s")
			{
				PartyExit();
				return;
			}
		}
		
		if (statue == 6)
		{
			FieldSet.SetVar("stage1", "clear");
			self.say("Ahhh! The statue has been restored! Thank you so much! Now we just need the Grass of Life to bring back the #bGoddess Minerva#k. The Grass of Life only grows in the garden of the Tower of the Goddess. I'll take you there right now.");
			FieldSet.Characters.ForEach(character =>
			{
				character.ChangeMap(920010800, "in00");
			});
			return;
		}
		
		if (statue == 7)
		{
			self.say("I don't know how to thank you for saving the Goddess Minerva!");
			return;
		}
		
		if (stageRecord == null)
		{
			FieldSet.SetVar("stage1", "s");
			HelpText();
		}
		else if (stageRecord == "s")
		{
			PartyExit();
		}
		else if (stageRecord == "clear")
		{
			self.say("Did you get the Grass of Life? If so, place the item in the center of the Goddess Statue.");
		}
	}
	
	private void Stage2(string stageRecord)
	{
		if (stageRecord == "clear")
		{
			self.say("I don't think there's anything else to do in this room. Please enter another room.");
			return;
		}
		
		if (!IsLeader)
		{
			HelpText();
			return;
		}
		
		if (stageRecord == null)
		{
			FieldSet.SetVar("stage2", "s");
			HelpText();
		}
		else if (stageRecord == "s")
		{
			int count = ItemCount(4001050);
			
			if (count < 30)
			{
				self.say("Did you collect all the #b#t4001050#s#k?");
				return;
			}
			
			self.say("Ohhh! You managed to gather 30 #b#t4001050#s#k! With those I can make #b#t4001044##k. Okay, I'll make it right now!");
			
			if (!Exchange(0, 4001050, -count, 4001044, 1))
			{
				self.say("Please check if your inventory has free space");
				return;
			}
			
			FieldSet.Characters.ForEach(character =>
			{
				MapPacket.MapEffect(character, 3, "quest/party/clear", true);
				MapPacket.MapEffect(character, 4, "Party1/Clear", true);
			});
			
			GiveEXP(7500, 1);
			FieldSet.SetVar("stage2", "clear");
		}
	}
	
	private void Stage3(string stageRecord)
	{
		if (stageRecord == "clear")
		{
			self.say("I don't think there's anything else to do in this room. Please enter another room.");
			return;
		}
		
		if (!IsLeader)
		{
			HelpText();
			return;
		}
		
		if (stageRecord == null)
		{
			FieldSet.SetVar("stage3", "s");			
			HelpText();
		}
		else if (stageRecord == "s")
		{
			if (ItemCount(4001045) < 1)
			{
				self.say("Did you collect #b#t4001045##k?");
				return;
			}
			
			FieldSet.Characters.ForEach(character =>
			{
				MapPacket.MapEffect(character, 3, "quest/party/clear", true);
				MapPacket.MapEffect(character, 4, "Party1/Clear", true);
			});
			
			GiveEXP(7500, 2);
			FieldSet.SetVar("stage3", "clear");
		}
	}
	
	private void Stage4(string stageRecord)
	{
		if (stageRecord == "clear")
		{
			self.say("I don't think there's anything else to do in this room. Please enter another room.");
			return;
		}
		
		if (!IsLeader || GetReactorState(920010400, 4, 122) == 0)
		{
			HelpText();
			return;
		}
		
		int day = (int)DateTime.UtcNow.DayOfWeek;
		
		if (GetReactorState(920010400, 4, 122) != (day + 1))
		{
			self.say("This isn't it.");
			return;
		}
		
		FieldSet.Characters.ForEach(character =>
		{
			MapPacket.MapEffect(character, 3, "quest/party/clear", true);
			MapPacket.MapEffect(character, 4, "Party1/Clear", true);
		});
		
		GiveEXP(7500, 3);
		SetReactorState(920010400, 4, 122, 1);
		FieldSet.SetVar("stage4", "clear");
		self.say("Yes! This is the song! The Goddess loved to hear this song from time to time.");
	}
	
	private void Stage5(string stageRecord)
	{
		if (stageRecord == "clear")
		{
			self.say("I don't think there's anything else to do in this room. Please find the piece of the Goddess statue in another room.");
			return;
		}
		
		if (!IsLeader)
		{
			HelpText();
			return;
		}
		
		if (stageRecord == null || stageRecord == "") // this var can be reset
		{
			FieldSet.SetVar("try", "0");
			FieldSet.SetVar("stage5", "s");
			QuizAnswer();
			HelpText();
		}
		else if (stageRecord == "s")
		{
			if (GetFieldsetVar("ans1") == null)
			{
				QuizAnswer();
			}
			
			int area1 = GetUsersInArea("1");
			int area2 = GetUsersInArea("2");
			int area3 = GetUsersInArea("3");
			
			if (area1 + area2 + area3 != 5)
			{
				self.say("You'll need 5 people on top of the platforms.");
				return;
			}
			
			int count = 0;
			
			if (area1 == int.Parse(GetFieldsetVar("ans1")))
				count++;
			if (area2 == int.Parse(GetFieldsetVar("ans2")))
				count++;
			if (area3 == int.Parse(GetFieldsetVar("ans3")))
				count++;
			
			if (count < 3)
			{
				int tries = int.Parse(GetFieldsetVar("try")) + 1;
				
				FieldSet.SetVar("try", tries.ToString());
				
				if (tries < 6)
				{
					if (count == 0)
					{
						self.say($"This is try number {tries}.\r\nAll the platforms have different weights.");
					}
					else
					{
						self.say($"This is try number {tries}.\r\nThe weight on {count} of the platforms is correct.");
					}
				}
				else if (tries == 6)
				{
					if (count == 0)
					{
						self.say($"This is try number {tries}.\r\nAll these platforms have different weights.\r\nYou only have one more try, be careful!");
					}
					else
					{
						self.say($"This is try number {tries}.\r\nThe weight on {count} of the platforms is correct.\r\nYou only have one more try, be careful.");
					}
				}
				else if (tries >= 7)
				{
					FieldSet.SetVar("try", "0");
					FieldSet.SetVar("stage5", "");
					FieldSet.Characters.ForEach(character =>
					{
						Message(character, "You failed and will be removed from the room.");
						character.ChangeMap(920010100, "in03");
					});
				}
			}
			else
			{
				FieldSet.Characters.ForEach(character =>
				{
					MapPacket.MapEffect(character, 3, "quest/party/clear", true);
					MapPacket.MapEffect(character, 4, "Party1/Clear", true);
				});
				
				GiveEXP(7500, 4);
				SetReactorState(920010500, 3, 37, 1);
				FieldSet.SetVar("stage5", "clear");
				self.say("Correct answer. Something appeared on top of the altar.");
			}
		}
	}
	
	private void Stage6(string stageRecord)
	{
		if (stageRecord == "clear")
		{
			self.say("I don't think there's anything else to do in this room. Please enter another room.");
			return;
		}
		
		if (!IsLeader)
		{
			HelpText();
			return;
		}
		
		if (stageRecord == null)
		{
			FieldSet.SetVar("stage6", "s");
			HelpText();
		}
		else if (stageRecord == "s")
		{
			int count = ItemCount(4001052);
			
			if (count < 40)
			{
				self.say("Did you collect the #b#t4001052#s#k?");
				return;
			}
			
			self.say("Ohhh! You managed to gather 40 #b#t4001052#s#k! With those I can make #b#t4001048##k. Okay, I'll make it right now!");
			
			if (!Exchange(0, 4001052, -count, 4001048, 1))
			{
				self.say("Please check if your inventory has free space.");
				return;
			}
			
			FieldSet.Characters.ForEach(character =>
			{
				MapPacket.MapEffect(character, 3, "quest/party/clear", true);
				MapPacket.MapEffect(character, 4, "Party1/Clear", true);
			});
			
			GiveEXP(7500, 5);
			FieldSet.SetVar("stage6", "clear");
		}
	}
	
	private void Stage7(string stageRecord)
	{
		if (stageRecord == "clear")
		{
			self.say("I don't think there's anything else to do in this room. Please enter another room.");
			return;
		}
		
		if (!IsLeader)
		{
			HelpText();
			return;
		}
		
		if (stageRecord == null)
		{
			FieldSet.SetVar("stage7", "s");
			HelpText();
		}
		else if (stageRecord == "s")
		{
			int ans1  = 93 + int.Parse(GetFieldsetVar("stage6_ans1"));
			int ans2  = 93 + int.Parse(GetFieldsetVar("stage6_ans2"));
			int wans1 = 93 + int.Parse(GetFieldsetVar("stage6_wans1"));
			int wans2 = 93 + int.Parse(GetFieldsetVar("stage6_wans2"));
			int wans3 = 93 + int.Parse(GetFieldsetVar("stage6_wans3"));
			
			self.say($"{ans1}  {ans2}  {wans1}  {wans2}  {wans3}");
			
			if (GetReactorState(920010700, 3, ans1) != 1 || GetReactorState(920010700, 3, ans2) != 1 || GetReactorState(920010700, 3, wans1) != 0 || GetReactorState(920010700, 3, wans2) != 0 || GetReactorState(920010700, 3, wans3) != 0)
			{
				self.say("Nothing happened, which means you must not have moved the correct lever.");
				return;
			}
			
			FieldSet.Characters.ForEach(character =>
			{
				MapPacket.MapEffect(character, 3, "quest/party/clear", true);
				MapPacket.MapEffect(character, 4, "Party1/Clear", true);
			});
			
			GiveEXP(7500, 6);
			SetReactorState(920010700, 3, 99, 1);
			FieldSet.SetVar("stage7", "clear");
			self.say("You successfully moved the lever. Something appeared on top of the altar.");
		}
	}
	
	private void StageBoss(string stageRecord)
	{
		if (!IsLeader || ItemCount(4001055) < 1)
		{
			PartyExit();
			return;
		}
		
		self.say("Oh, you found the Grass of Life! Now we can save the Goddess! Please go back to the Center of the Tower and save the Goddess!");
	}
	
	public override void Run()
	{
		switch(MapID)
		{
			case 920010000: PreStage(GetFieldsetVar("prestage")); break;
			case 920010100: Stage1(GetFieldsetVar("stage1")); break;
			case 920010200: Stage2(GetFieldsetVar("stage2")); break;
			case 920010300: Stage3(GetFieldsetVar("stage3")); break;
			case 920010400: Stage4(GetFieldsetVar("stage4")); break;
			case 920010500: Stage5(GetFieldsetVar("stage5")); break;
			case 920010600: Stage6(GetFieldsetVar("stage6")); break;
			case 920010700: Stage7(GetFieldsetVar("stage7")); break;
			case 920010800: StageBoss(GetFieldsetVar("stageboss")); break;
			case 920010900: HelpText(); break;
			case 920011000: HelpText(); break;
			case 920011100: PartyExit(); break;
			case 920011200: PartyExit(); break;
		}
	}
}