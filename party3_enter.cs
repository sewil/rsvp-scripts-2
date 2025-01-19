using System;
using System.Collections.Generic;
using System.Linq;
using WvsBeta.Game;
using WvsBeta.Common;
using WvsBeta.Game.GameObjects;
using WvsBeta.Game.Packets;

public class NpcScript : IScriptV2
{
	private PartyData Party => PartyData.Parties[chr.PartyID];
	private FieldSet FieldSet => chr.Field.ParentFieldSet;
	private bool IsLeader => Party.Leader == chr.ID;
	
	private void TakeAwayItem()
	{
		int[] items = {4001044, 4001045, 4001046, 4001047, 4001048, 4001049, 4001050, 4001051, 4001052, 4001053, 4001054, 4001055, 4001056, 4001057, 4001058, 4001059, 4001060, 4001061, 4001062, 4001063, 4001074};
		
		var partyMembers = chr.Field.GetInParty(chr.PartyID).ToArray();
		
		foreach (var character in partyMembers)
		{
			foreach (int item in items)
			{
				int count = character.Inventory.ItemCount(item);
				if (count >= 1)
					character.Inventory.Exchange(this, 0, item, -count);
			}
		}
		
		return;
	}
	
	private void AffectionReward(int like)
	{
		self.say("I am immensely grateful that you gave me so much delicious food. It's not much but, since I don't really need it, you can take it. Make sure your inventory has at least one free slot!");
		
		var rewards = new List<(int, int, int)>();
		
		if (like >= 100 && like < 200)
		{
			rewards.Add((2020013, 1, 20));
			rewards.Add((2020014, 1, 20));
			rewards.Add((2000002, 5, 20));
			rewards.Add((2000002, 10, 20));
			rewards.Add((2020015, 1, 18));
			rewards.Add((2040708, 1, 2));
		}
		else if (like >= 200 && like < 300)
		{
			rewards.Add((2000002, 10, 20));
			rewards.Add((2020013, 1, 10));
			rewards.Add((2020014, 1, 10));
			rewards.Add((2020015, 1, 9));
			rewards.Add((2040708, 1, 1));
			rewards.Add((2040707, 1, 1));
		}
		else if (like >= 300 && like <= 400)
		{
			rewards.Add((2000002, 10, 30));
			rewards.Add((2020015, 15, 26));
			rewards.Add((2020013, 1, 20));
			rewards.Add((2020014, 1, 20));
			rewards.Add((2040707, 1, 2));
			rewards.Add((2040708, 1, 2));
		}
		
		var item = rewards.RandomElementByWeight(tuple => tuple.Item3);
		
		if (item == default)
			return;
		
		int itemID = item.Item1;
		int itemNum = item.Item2;
		
		if (!Exchange(0, itemID, itemNum))
		{
			self.say("Unfortunately, your use inventory is full and you can't receive the reward. Free up space next time.");
			return;
		}
	}
	
	private int FoodCode(int code)
	{
		switch(code)
		{
			case 0: return 2020001;
			case 1: return 2022001;
			case 2: return 2020004;
			case 3: return 2022003;
			case 4: return 2001001;
			case 5: return 2020028;
			case 6: return 2001002;
			default: return 2020001;
		}
	}
	
	private int AteFood(int code)
	{
		string food = $"#t{FoodCode(code)}#";
		string record = GetQuestData(7021, "1009999");
		
		// this creates a string that moves the three most recent food items forward and adds the new food item at the end
		string newRecord = record.Substring(0, 3) + record.Substring(4, 3) + code.ToString();
		
		SetQuestData(7021, newRecord);
		
		int food1 = int.Parse(record.Substring(3, 1));
		int food2 = int.Parse(record.Substring(4, 1));
		int food3 = int.Parse(record.Substring(5, 1));
		int food4 = int.Parse(record.Substring(6, 1));
		
		if (food1 == code && food2 == code && food3 == code && food4 == code)
		{
			self.say($"#b{food}#k again? I love eating this, but I'm starting to get sick...");
			return 2;
		}
		else if (food2 == code && food3 == code && food4 == code)
		{
			int[] like = {1, 3, 3, 7, 20, 26, 30};
			
			self.say($"#b{food}#k is delicious, but now I want to eat something else.");
			return like[code];
		}
		else if (food3 == code && food4 == code)
		{
			int[] like = {2, 4, 4, 10, 27, 32, 40};
			
			self.say($"Oh~... I knew it, this #b{food}#k is very good!");
			return like[code];
		}
		else if (food4 == code)
		{
			int[] like = {2, 5, 5, 13, 30, 40, 50};
			
			self.say($"Oh~... I knew it, this #b{food}#k is very good!");
			return like[code];
		}
		else if (food1 != code && food2 != code && food3 != code && food4 != code)
		{
			int[] like = {4, 8, 8, 19, 39, 50, 69};
			
			self.say($"Wow, isn't this #b{food}#k??? New food: Always welcome!");
			return like[code];
		}
		else
		{
			switch(code)
			{
				case 0:
					self.say("Wow!~ #bChicken#k!! There's nothing like fried chicken, crispy on the outside and soft on the inside.");
					return 3;
				
				case 1:
					self.say("Wow!~ #b#t2022001##k!!! So sweet and delicious! I feel cozy eating this.");
					return 6;
				
				case 2:
					self.say("Wow!~ My favorite, #bHamburger#k! Look at these hamburgers! Don't they look fantastic?");
					return 6;
				
				case 3:
					self.say("Wow!~ #bUnagi#k!! Unagi with sweet sauce... mmm... try it~");
					return 16;
				
				case 4:
					self.say("Wow!~ One of these #bIcecream Pops#k is sure to freeze the summer heat! Very cold!!");
					return 36;
				
				case 5:
					self.say("Wow!~ It's the #bChocolate#k with all the sweetness filling my body. Too much! Try one too!");
					return 47;
				
				case 6:
					self.say("Wow! It's the delicious #bSlush with Red Beans#k! A block of crushed ice with red beans and fruit on top... mmmm... so cold that my mouth is almost frozen!!");
					return 65;
			}
		}
		
		return 0;
	}
	
	private void Affection(int item)
	{
		var rnd = new Random();
		string affection = GetQuestData(7021, "1009999");
		string time = GetQuestData(7022, DateTime.UtcNow.ToString());
		
		int like = int.Parse(affection.Substring(0, 3));
		
		if (DateTime.UtcNow > DateTime.Parse(time).AddMinutes(84))
		{
			if (like >= 130)
				like -= 30;
			else
				like = 100;
		}
		
		SetQuestData(7022, DateTime.UtcNow.ToString());
		
		// item name code (#t) cannot be used in chat messages
		string[] itemName = {
			"Fried Chicken",
			"Red Bean Soup",
			"a Hamburger",
			"Unagi",
			"an Ice Cream Pop",
			"Chocolate",
			"Slush with Red Beans"
		};
		
		if (item == -1)
		{
			Message("Wonky's mood turned sour.");
			if (like >= 103)
				like -= 3;
			else
				like = 100;
		}
		else
		{
			if (rnd.Next(0, 100) <= AteFood(item))
			{
				Message($"Wonky is feeling great after having eaten {itemName[item]}.");
				if (rnd.Next(0, 20) == 0)
					AffectionReward(like);
				
				like += 5;
			}
			else
			{
				Message($"Wonky delights in eating {itemName[item]}.");
				like += 3;
			}
		}
		
		if (like > 500)
			like = 500;
		
		if (like < 100)
			like = 100;
		
		if (item == -1)
		{
			string result = like.ToString() + affection.Substring(3, 4);
			SetQuestData(7021, result);
		}
		else
		{
			string result = like.ToString() + affection.Substring(4, 3) + item.ToString();
			SetQuestData(7021, result);
		}
	}
	
	private int PreMission()
	{
		var rnd = new Random();
		var partyMembers = chr.Field.GetInParty(chr.PartyID).ToArray();
		
		int warrior = 0;
		int magician = 0;
		int bowman = 0;
		int rogue = 0;
		
		foreach (var partyMember in partyMembers)
		{
			if (partyMember.Job >= 100 && partyMember.Job < 200)
				warrior++;
			
			if (partyMember.Job >= 200 && partyMember.Job < 300)
				magician++;
			
			if (partyMember.Job >= 300 && partyMember.Job < 400)
				bowman++;
			
			if (partyMember.Job >= 400 && partyMember.Job < 500)
				rogue++;
		}
		
		if (warrior >= 1 && magician >= 1 && bowman >= 1 && rogue >= 1)
		{
			return rnd.Next(1, 5);
		}
		
		return 0;
	}
	
	private void ClearMission2(int index)
	{
		bool help = false;
		
		if (index == 0)
		{
			help = AskYesNo("Can you do me a favor? Try to complete the #bParty Mission<Traces of the Goddess>#k in less than 25 minutes. I'm hungry, you know. If you can do it, I'll give you some extra EXP.");
			
			if (help)
			{
				FieldSet.Characters.ForEach(character =>
				{
					Message(character, "You must complete <Mission> Party Mission <Traces of the Goddess> in less than 25 minutes!");
				});
				
				FieldSet.SetVar("cMission", "1");
				self.say("All right! Time is passing as we speak. Complete the mission!");
			}
		}
		else if (index == 1)
		{
			help = AskYesNo("Can you do me a favor? Can you do the #bParty Mission<Traces of the Goddess>#k and gather 8 #bStrange Seeds#k for me?\r\nI still haven't found a food that I've never tried, but I really have no idea what these #bStrange Seeds#k taste like~ I really want to prove it. And remember, it's the leader of the party who must deliver them to me.");
			
			if (help)
			{
				FieldSet.Characters.ForEach(character =>
				{
					Message(character, "<Mission> Gather at least 8 strange seeds!");
				});
				
				FieldSet.SetVar("cMission", "2");
				self.say("All right, there are the 8 #bStrange Seeds#k~ Make sure the leader of the party delivers them all!");
			}
		}
		else if (index == 2)
		{
			help = AskYesNo("Can you do me a favor? Do the #bParty Mission<Traces of the Goddess>#k and get me the #bLP's#k? I only need 6. And remember, it's the leader of the party who must deliver them to me.");
			
			if (help)
			{
				FieldSet.Characters.ForEach(character =>
				{
					Message(character, "<Mission> Gather 6 LP’s of various songs!");
				});
				
				FieldSet.SetVar("cMission", "3");
				self.say("All right, here are the 6 #bLP's#k~ I don't care about the type, but the leader of the party needs to deliver them all!");
			}
		}
		else if (index == 3)
		{
			help = AskYesNo("Can you do me a favor? Can you eliminate #bLouinels#k in the Tower of the Goddess?");
			
			if (help)
			{
				FieldSet.Characters.ForEach(character =>
				{
					Message(character, "<Mission> Eliminate the Louinels!");
				});
				
				FieldSet.SetVar("cMission", "4");
				self.say("All right! You need to eliminate EACH OF THEM!");
			}
		}
		else if (index == 4)
		{
			help = AskYesNo("Can you do me a favor? Can you eliminate #bJr. Cellion, Jr. Lioner and Jr. Grupin#k in the Tower of the Goddess?");
			
			if (help)
			{
				FieldSet.Characters.ForEach(character =>
				{
					Message(character, "<Mission> Please, eliminate Jr. Cellion, Jr. Lioner and Jr. Grupin!");
				});
				
				FieldSet.SetVar("cMission", "5");
				self.say("All right! You need to eliminate EACH OF THEM!");
			}
		}
		
		if (!help)
		{
			self.say("OH, I understand. Too bad for me, but I understand. I'll ask another time~");
			FieldSet.SetVar("cMission", "0");
		}
		
		return;
	}
	
	private void ClearMission(string affection)
	{
		var rnd = new Random();
		
		if (GetFieldsetVar("cMission", "Party5") == null)
		{
			int like = int.Parse(affection.Substring(0, 3));
			int rnum = rnd.Next(0, 15);
			
			if (like >= 100 && like < 200)
			{
				if (rnum >= 0 && rnum <= 2)
					ClearMission2(rnd.Next(0, 5));
			}
			else if (like >= 200 && like < 300)
			{
				if (rnum >= 0 && rnum <= 4)
					ClearMission2(rnd.Next(0, 5));
			}
			else if (like >= 300 && like <= 400)
			{
				if (rnum >= 0 && rnum <= 7)
					ClearMission2(rnd.Next(0, 5));
			}
		}
		
		return;
	}
	
	public override void Run()
	{
		string quest = GetQuestData(7020);
		string affection = GetQuestData(7021, "1009999");
		
		if (MapID == 200080101)
		{
			while(true)
			{
				string dialogue = "";
				var options = new List<(int, string)>();
				
				int affectionNum = int.Parse(affection.Substring(0, 3));
				
				if (affectionNum >= 100 && affectionNum < 200)
				{
					dialogue = "Hi! I'm Wonky the Fairy. Do you want to explore the Tower of the Goddess? By the way, if your party has at least one warrior, magician, bowman and rogue, I'll give you a little of Wonky's Blessing.#b";
					options.Add((0, " Register to Enter."));
				}
				else if (affectionNum >= 200 && affectionNum < 300)
				{
					dialogue = "Hey~~~ Nice to see you! Do you want to explore the Tower of the Goddess? By the way, if your party has at least one warrior, magician, bowman and rogue, I'll give you a little of Wonky's Blessing.#b";
					options.Add((0, " Register to Enter."));
				}
				else if (affectionNum >= 300 && affectionNum <= 400)
				{
					dialogue = $"Hey #b{chr.Name}#k. How are you? By the way, if your party has at least one warrior, magician, bowman and rogue, I'll give you a little of Wonky's Blessing.#b";
					options.Add((0, " Register to Enter."));
				}
				else
				{
					dialogue = "Hi! I'm Wonky the Fairy. If you're interested in exploring the Tower of the Goddess, let me know...#b";
				}
				
				options.Add((1, " Ask about the Tower of the Goddess."));
				options.Add((2, " Give Wonky something to eat."));
				
				int start = AskMenu(dialogue, options.ToArray());
				
				if (start == 0)
				{
					if (chr.PartyID == 0)
					{
						self.say("You are not in a party. You need to be in a party to do this!");
						return;
					}
					
					var party = PartyData.Parties[chr.PartyID];
					
					if (party.Leader != chr.ID)
					{
						self.say("Hey, I need the leader of your party to talk to me, no one else.");
						return;
					}
					
					if (party.GetAvailablePartyMembers().Count() < 6 && !chr.IsGM)
					{
						self.say("Your party doesn't have 6 members! I need 6!!");
						return;
					}
					
					var partyMembers = chr.Field.GetInParty(chr.PartyID).ToArray();
					
					if (partyMembers.Length != party.GetAvailablePartyMembers().Count())
					{
						self.say("Not all of your party members are here. Come back and talk to me again when everyone is here.");
						return;
					}
					
					if (partyMembers.Any(c => c.PrimaryStats.Level < 50 || c.PrimaryStats.Level > 70))
					{
						self.say("Someone in your party is not between Levels 51 ~70. Leave your party within those levels!");
						return;
					}
					
					if (!FieldSet.IsAvailable("Party5"))
					{
						self.say("Another party already entered to complete the quest. Try again later.");
						return;
					}
					
					int mis = PreMission();
					int buff = 0;
					string buffMessage = "";
					
					if (mis == 1)
					{
						buff = 2022090;
						buffMessage = "For fulfilling Wonky's request, your MAGIC AND WEAPON ATTACK have been increased for 30 minutes.";
					}
					else if (mis == 2)
					{
						buff = 2022091;
						buffMessage = "For fulfilling Wonky's request, your MAGIC AND WEAPON DEFENSE have been increased for 30 minutes.";
					}
					else if (mis == 3)
					{
						buff = 2022092;
						buffMessage = "For fulfilling Wonky's request, your ACCURACY AND AVOIDABILITY have been increased for 30 minutes.";
					}
					else if (mis == 4)
					{
						buff = 2022093;
						buffMessage = "For fulfilling Wonky's request, your SPEED AND JUMP have been increased for 30 minutes.";
					}
					
					if (mis >= 1)
					{
						foreach (var character in partyMembers)
						{
							character.Buffs.AddItemBuff(buff);
							Message(character, buffMessage);
						}
					}
					
					var rnd = new Random();
					
					if (rnd.Next(0, 10) <= 1)
						SetReactorState(920010912, 3, 18, 1);
					
					if (rnd.Next(0, 10) <= 1)
						SetReactorState(920010922, 3, 18, 1);
					
					if (rnd.Next(0, 10) <= 1)
						SetReactorState(920010932, 3, 18, 1);
					
					TakeAwayItem();
					FieldSet.Enter("Party5", partyMembers, chr);
					return;
				}
				else if (start == 1)
				{
					self.say("Some days ago, after a huge storm, a new cloud path appeared above Orbis Tower, behind the #bstatue of the Goddess Minerva#k. The clouds dissipated and a new and mysterious tower emerged.");
					self.say("We concluded that the tower that we're searching for is that of a being who stands behind me, controlling Orbis. #bGoddess Minerva#k. I'm quite certain that the #bGoddess Minerva#k is trapped somewhere in the tower. What do you think? Would you like to explore the tower and find the remains of the Goddess?");
				}
				else if (start == 2)
				{
					int[] food = {2020001, 2022001, 2020004, 2022003, 2001001, 2020028, 2001002};
					
					int selection = AskMenu("Hey, you have something to eat?!#b",
						(0, " #t2020001#"),
						(1, " #t2022001#"),
						(2, " #t2020004#"),
						(3, " #t2022003#"),
						(4, " #t2001001#"),
						(5, " #t2020028#"),
						(6, " #t2001002#")
					);
					
					int item = food[selection];
					
					if (ItemCount(item) < 1)
					{
						Affection(-1);
						self.say($"What? How do you expect me to eat #t{item}# if you didn't bring any? Are you trying to challenge me?");
						return;
					}
					
					if (!Exchange(0, item, -1))
					{
						Message($"Impossible to eat, you don't have #t{item}#.");
						return;
					}
					
					MapPacket.MapEffect(chr, 4, "Party3/Eat", true);
					Affection(selection);
				}
			}
		}
		else if (MapID == 920010000)
		{
			bool exit = false;
			string clearMission = GetFieldsetVar("cm", "Party5");
			var party = PartyData.Parties[chr.PartyID];
					
			if (party.Leader == chr.ID)
			{
				if (clearMission != "1")
				{
					FieldSet.SetVar("cm", "1");
					ClearMission(affection);
				}
				
				exit = AskYesNo("Do you want to exit the Party Quest in the middle and leave this place? If you leave, you'll have to start all over again...");
			}
			
			if (!exit)
			{
				self.say("Think carefully about your choice and talk to me when you decide.");
				return;
			}
			
			self.say("Try again later~");
			ChangeMap(920011200, "st00");
		}
	}
}