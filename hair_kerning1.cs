using System;
using System.Linq;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private static readonly int[] mHairDefault = {30030, 30020, 30000, 30780, 30130, 30350, 30190, 30110, 30180, 30050, 30040, 30160};
	private static readonly int[] fHairDefault = {31050, 31040, 31000, 31760, 31060, 31090, 31330, 31020, 31130, 31120, 31140, 31010};
	
	private static readonly int[] mHairUnlocks = {30170, 30360, 30440, 30560, 30600, 30670, 30720, 30740, 30750, 30830, 30850, 30880, 30900, 30920, 30990};
	private static readonly int[] fHairUnlocks = {31170, 31200, 31350, 31440, 31470, 31520, 31560, 31620, 31660, 31750, 31800, 31850, 31870, 31890, 31930};
	
	private int QuestID(int step)
	{
		var rnd = new Random();
		
		switch(step)
		{
			case 1: return rnd.Next(2, 8);
			case 2: return rnd.Next(3, 9);
			case 3: return rnd.Next(5, 10);
			case 4: return rnd.Next(6, 11);
			case 5: return rnd.Next(7, 12);
			case 6: return rnd.Next(9, 13);
			case 7: return rnd.Next(10, 14);
			case 8: return rnd.Next(11, 15);
			case 9: return rnd.Next(13, 16);
			case 10: return rnd.Next(14, 17);
			case 11: return rnd.Next(15, 18);
			case 12: return rnd.Next(17, 19);
			case 13: return rnd.Next(18, 20);
			case 14: return rnd.Next(19, 21);
			default: return rnd.Next(1, 2);
		}
	}
	
	// Pull quest requirements depending on quest ID.
	private List<(int Item, int Amount)> QuestRequirement(string index)
	{
		var itemList = new List<(int Item, int Amount)>();
		
		#region Quest Data
		
		switch(int.Parse(index))
		{
			case 1:
				itemList.Add((4000000, 35));
				itemList.Add((4000004, 15));
				break;
			
			case 2:
				itemList.Add((4000016, 30));
				break;
				
			case 3:
				itemList.Add((4000005, 25));
				itemList.Add((4000003, 35));
				break;
				
			case 4:
				itemList.Add((4000006, 20));
				itemList.Add((4000016, 30));
				break;
				
			case 5:
				itemList.Add((4000002, 55));
				break;
				
			case 6:
				itemList.Add((4000018, 35));
				itemList.Add((4000037, 25));
				break;
				
			case 7:
				itemList.Add((4000006, 35));
				itemList.Add((4000004, 20));
				break;
				
			case 8:
				itemList.Add((4000015, 30));
				itemList.Add((4000215, 15));
				itemList.Add((4000042, 15));
				break;
				
			case 9:
				itemList.Add((4000007, 45));
				itemList.Add((4000024, 40));
				break;
				
			case 10:
				itemList.Add((4000035, 40));
				itemList.Add((4000037, 30));
				break;
				
			case 11:
				itemList.Add((4000013, 30));
				itemList.Add((4000032, 15));
				break;
				
			case 12:
				itemList.Add((4000024, 80));
				break;
				
			case 13:
				itemList.Add((4000039, 30));
				itemList.Add((4000042, 30));
				itemList.Add((4000032, 25));
				break;
				
			case 14:
				itemList.Add((4000032, 40));
				itemList.Add((4000033, 25));
				break;
				
			case 15:
				itemList.Add((4000178, 45));
				itemList.Add((4000036, 15));
				break;
				
			case 16:
				itemList.Add((4000044, 70));
				itemList.Add((4000033, 50));
				break;
				
			case 17:
				itemList.Add((4000014, 60));
				itemList.Add((4000025, 35));
				break;
				
			case 18:
				itemList.Add((4000041, 20));
				itemList.Add((4000036, 55));
				break;
				
			case 19:
				itemList.Add((4000027, 45));
				itemList.Add((4000177, 45));
				break;
				
			case 20:
				itemList.Add((4000028, 25));
				itemList.Add((4000046, 25));
				break;
		}
		
		#endregion
		
		return itemList;
	}
	
	private string MakeNeededString(string qr)
	{
		string str = "";
		var list = QuestRequirement(qr);
		
		for (int i = 0; i < list.Count(); i++)
		{
			if (i == list.Count - 1 && list.Count != 1)
				str += " and ";
			
			if (list[i].Amount >= 2)
				str += $"#b{list[i].Amount} #t{list[i].Item}#s#k";
			
			else
				str += $"#b1 #t{list[i].Item}##k";
			
			if (i < list.Count - 2)
				str += ", ";
		}
		
		return str;
	}
	
	private List<int> GetStyleList(int[] defaultStyles, int[] newStyles)
	{
		int z = chr.Hair % 10;
		var hairs = new List<int>();
		
		foreach (int style in defaultStyles)
		{
			hairs.Add(style + z);
		}
		
		string unlocks = GetQuestData(1301, "000000000000000");
		
		for (int i = 0; i < unlocks.Length; i++)
		{
			if (unlocks.Substring(i, 1) == "1")
			{
				// These styles only come in one color :)
				if (newStyles[i] == 30010 || newStyles[i] == 30080 || newStyles[i] == 31500)
				{
					hairs.Add(newStyles[i]);
				}
				else
				{
					hairs.Add(newStyles[i] + z);
				}
			}
		}
		
		hairs.Remove(chr.Hair);
		
		return hairs;
	}
	
	private void Haircut()
	{
		var styles = new List<int>();
		
		if (chr.GetGender() == 0)
			styles = GetStyleList(mHairDefault, mHairUnlocks);
		
		else if (chr.GetGender() == 1)
			styles = GetStyleList(fHairDefault, fHairUnlocks);
		
		int selectedStyle = AskStyle(styles, "I can change the style of your hair to something totally new. Aren't you sick of your hairdo? I can give you a new haircut with #b#t4050003##k. Choose the style of your liking.");
		
		if (!Exchange(0, 4050003, -1))
		{
			self.say("Hm... It looks like you don't have the right coupon... Too bad, I can't cut your hair without it. Sorry, buddy.");
			return;
		}
		
		chr.SetHair(selectedStyle);
		self.say("Alright, look at your new hairdo. What do you think? Even I admit this is a work of art! HAHAHA. Look for me when you want a new haircut. I'll take care of the rest!");
	}
	
	private void DyeHair()
	{
		if (chr.Hair == 30010 || chr.Hair == 30080 || chr.Hair == 31500)
		{
			self.say("Hm... I don't think I can style this hair any differently. Come back and talk to me with a different haircut.");
			return;
		}
		
		var styles = new List<int>();
		
		int hair = chr.Hair - (chr.Hair % 10);
		int[] colors = {0, 1, 2, 4, 6, 7};
		
		foreach (int color in colors)
		{
			styles.Add(hair + color);
		}
		
		styles.Remove(chr.Hair);
		
		int selectedStyle = AskStyle(styles, "I can change the color of your hair to something totally new. Aren't you sick of your hairdo? I can give you a new haircut with #b#t4051003##k. Choose a color of your liking.");
		
		if (!Exchange(0, 4051003, -1))
		{
			self.say("Hm... It looks like you don't have the right coupon... Too bad, I can't dye your hair without it. Sorry, buddy.");
			return;
		}
		
		chr.SetHair(selectedStyle);
		self.say("Alright, look at your new hair color. What do you think? Even I admit this is a work of art! HAHAHA. Look for me when you want a new haircut. I'll take care of the rest!");
	}
	
	private void Quest(string quest)
	{
		var rnd = new Random();
		string unlocks = GetQuestData(1301, "000000000000000");
		string lastDate = GetQuestData(1008901);
		
		if (!unlocks.Contains("0"))
		{
			self.say("Hey, it's you! It has been a pleasure doing business with you; you got me everything I asked for and then some, so please come back and get your haircut here anytime!");
			return;
		}
		
		if (lastDate == DateTime.UtcNow.ToString("yyyyMMdd"))
		{
			self.say("Hey! You've done a great job gathering supplies for me today. Come back again tomorrow and I'll have something more for you to do.");
			return;
		}
		
		if (quest == "")
		{
			self.say("Hey... you look like you're interested in trying something new. I'm Don Giovanni but you can call me Don. You see, I have been running this salon here in Kerning City for years. Business is booming, but that's the problem, I don't have time to work on my own personal projects.");
			bool start = AskYesNo("I have some new hairdos I want to try out, but I need some more time to perfect them. You would be doing me a big favor collecting some supplies for my shop, and if you bring them quick enough I might even let you see the style for youself. What do you think? Want to help me out?");
			
			if (!start)
			{
				self.say("Hm... I understand. You seem like a busy person. Come back if you change your mind, I'll be here.");
				return;
			}
			
			string needString = MakeNeededString("1");
			
			SetQuestData(1008900, "1");
			self.say($"Wow, thanks so much! I'll work out this new hairdo, but in the meantime I need you to get me {needString} for my supplies. Come back when you've found everything.");
		}
		else if (quest == "e")
		{
			self.say("Welcome back, I have been waiting for you. Ready to gather more supplies?");
			bool start = AskYesNo("The supplies might be harder to get this time. Are you ready?");
			
			if (!start)
			{
				self.say("Hm... I understand. You seem like a busy person. Come back if you change your mind, I'll be here.");
				return;
			}
			
			string newQuestID = QuestID(unlocks.Count(f => (f == '1'))).ToString();
			string needString = MakeNeededString(newQuestID);
			
			SetQuestData(1008900, newQuestID);
			self.say($"Thanks. This time I'll need {needString}. Come back when you've found everything.");
		}
		else
		{
			var needed = QuestRequirement(quest);
			string neededString = MakeNeededString(quest);
			
			for (int i = 0; i < needed.Count(); i++)
			{
				if (ItemCount(needed[i].Item) < needed[i].Amount)
				{
					self.say($"Hm... it doesn't look like you have everything I asked for. I'll need {neededString}. Come back when you've found everything.");
					return;
				}
			}
			
			self.say("Looks like you're back with everything I asked for.");
			
			for (int i = 0; i < needed.Count(); i++)
			{
				if (!Exchange(0, needed[i].Item, -needed[i].Amount))
					return;
			}
			
			string newUnlockedHairs = "";
			int rnum = -1;
			
			while(true)
			{
				rnum = rnd.Next(0, 15);
				
				if (unlocks.Substring(rnum, 1) == "0")
				{
					newUnlockedHairs = unlocks.Remove(rnum, 1).Insert(rnum, "1");
					break;
				}
			}
			
			string newHairString = "";
			
			if (chr.GetGender() == 0)
				newHairString = $"#t{mHairUnlocks[rnum]}#";
			
			else if (chr.GetGender() == 1)
				newHairString = $"#t{fHairUnlocks[rnum]}#";
			
			AddEXP(1000 * (int)(Level * 0.3));
			SetQuestData(1301, newUnlockedHairs);
			SetQuestData(1008900, "e");
			SetQuestData(1008901, DateTime.UtcNow.ToString("yyyyMMdd"));
			QuestEndEffect();
			self.say($"While you were out collecting these materials, I've come up with a new style I like to call #b{newHairString}#k. Thanks again for your help, come back soon, I may need your help again.");
		}
	}
	
	private void RegisterHair()
	{
		var hairList = new List<int>();
		
		string savedHairs = GetQuestData(1311);
		string[] hairs = savedHairs.Split('_');
		
		foreach (string hair in hairs)
		{
			if (hair != "")
				hairList.Add(int.Parse(hair));
		}
		
		int savedOption = AskMenu("I can save your favorite hairdo's and style your hair the same way anytime you like. What would you like to do?#b",
			(0, " Haircut (saved hairstyles)"),
			(1, " Save a hairstyle"),
			(2, " Remove a saved hairstyle")
		);
		
		if (savedOption == 0)
		{
			int cost = (660 * Level) + Level * 66;
			
			if (hairList.Count == 0)
			{
				self.say("It looks like you don't have any styles registered here right now.");
				return;
			}
			
			hairList.Remove(chr.Hair);
			
			if (hairList.Count == 0)
			{
				self.say("It looks like you already have the hairstyle you registered here.");
				return;
			}
			
			int mHair = AskStyle(hairList, "Here are the styles you have registered. Which one would you like?");
			
			bool buyHair = AskYesNo($"I can change your hair for #r{cost:n0} mesos#k. Are you sure you really want #b#t{mHair}##k?");
			
			if (!buyHair)
			{
				self.say("Okay. If you ever feel like changing it up, come and talk to me.");
				return;
			}
			
			if (!Exchange(-cost))
			{
				self.say($"Hm... are you sure you have enough mesos for this? I can't change up your hair without {cost:n0} mesos. Sorry, buddy.");
				return;
			}
			
			chr.SetHair(mHair);
			self.say("Alright, look at your new hair color. What do you think? Even I admit this is a work of art! HAHAHA. Look for me when you want a new haircut. I'll take care of the rest!");
		}
		else if (savedOption == 1)
		{
			int cost = (990 * Level) + Level * 99;
			
			if (savedHairs.Contains($"{chr.Hair}_"))
			{
				self.say("Hm... it looks like you have already registered this hairstyle here.");
				return;
			}
			
			if (hairList.Count == 2)
			{
				self.say("You have already registered 2 hairstyles here. I'm sorry but you'll have to remove one if you'd like to register another.");
				return;
			}
			
			bool askSave = AskYesNo($"Are you sure you'd like to register your current hairstyle at this salon? It'll cost #r{cost:n0} mesos#k to register it.");
			
			if (!askSave)
			{
				self.say("If you change your mind, come and talk to me.");
				return;
			}
			
			if (!Exchange(-cost))
			{
				self.say($"Hm... are you sure you have enough mesos for this? I can't register your hairstyle without {cost:n0} mesos. Sorry, buddy.");
				return;
			}
			
			savedHairs += $"{chr.Hair}_";
			SetQuestData(1311, savedHairs);
			self.say($"I've registered your hairstyle #b#t{chr.Hair}##k here at this salon. Come back anytime!");
		}
		else if (savedOption == 2)
		{
			int cost = (330 * Level) + Level * 33;
			
			if (hairList.Count == 0)
			{
				self.say("It looks like you don't have any styles registered here right now.");
				return;
			}
			
			int mHair = AskStyle(hairList, "Here are the styles you have registered. Which one would you like to remove?");
			
			bool removeHair = AskYesNo($"I can remove this hairstyle for #r{cost:n0} mesos#k. Are you sure you really want to remove #b#t{mHair}##k from your registered hairstyles?");
			
			if (!removeHair)
			{
				self.say("Okay. If you ever get sick of those styles, just talk to me!");
				return;
			}
			
			if (!Exchange(-cost))
			{
				self.say($"Hm... are you sure you have enough mesos for this? I can't change up your hair without {cost:n0} mesos. Sorry, buddy.");
				return;
			}
			
			savedHairs = savedHairs.Replace($"{mHair}_", string.Empty);
			SetQuestData(1311, savedHairs);
			self.say("Alright, that style is no longer registered here. If you have any other style you'd like to register, just talk to me!");
		}
	}
	
	public override void Run()
	{
		var options = new List<(int, string)>();
		
		if (Level >= 25)
			options.Add((0, " Don Giovanni's Salon Supplies\r\n"));
		
		options.Add((1, " Haircut (VIP coupon)"));
		options.Add((2, " Dye your hair (VIP coupon)"));
		options.Add((3, " Check your registered hairstyles"));
		
		int start = AskMenu("Hey! I'm Don Giovanni, the head of this hair salon! If you have #b#t4050003##k or #b#t4051003##k, why don't you let me take care of the rest? Decide what you want to do with your hair...#b", options.ToArray());
		
		switch(start)
		{
			case 0: Quest(GetQuestData(1008900)); break;
			case 1: Haircut(); break;
			case 2: DyeHair(); break;
			case 3: RegisterHair(); break;
		}
	}
}

