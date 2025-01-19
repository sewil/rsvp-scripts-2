using System;
using System.Linq;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private static readonly int[] mHairDefault = {30030, 30020, 30000, 30480, 30310, 30330, 30060, 30150, 30410, 30210, 30140, 30120, 30200};
	private static readonly int[] fHairDefault = {31050, 31040, 31000, 31700, 31150, 31310, 31300, 31160, 31100, 31410, 31030, 31080, 31070};
	
	private static readonly int[] mHairUnlocks = {30100, 30380, 30450, 30510, 30550, 30570, 30610, 30620, 30700, 30730, 30790, 30810, 30870, 30940, 33150};
	private static readonly int[] fHairUnlocks = {31210, 31340, 31420, 31480, 31490, 31550, 31590, 31690, 31720, 31790, 31820, 31900, 31940, 31980, 31990};
	
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
				itemList.Add((4000000, 10));
				itemList.Add((4000011, 15));
				break;
			
			case 2:
				itemList.Add((4000003, 20));
				itemList.Add((4000016, 10));
				break;
				
			case 3:
				itemList.Add((4000004, 30));
				itemList.Add((4000001, 35));
				break;
				
			case 4:
				itemList.Add((4000001, 50));
				break;
				
			case 5:
				itemList.Add((4000004, 45));
				itemList.Add((4000005, 20));
				break;
				
			case 6:
				itemList.Add((4000002, 35));
				itemList.Add((4000012, 20));
				break;
				
			case 7:
				itemList.Add((4000012, 65));
				break;
				
			case 8:
				itemList.Add((4000015, 20));
				itemList.Add((4000006, 20));
				itemList.Add((4000018, 20));
				break;
				
			case 9:
				itemList.Add((4000020, 50));
				itemList.Add((4000009, 25));
				break;
				
			case 10:
				itemList.Add((4000029, 35));
				itemList.Add((4000013, 35));
				break;
				
			case 11:
				itemList.Add((4000035, 45));
				itemList.Add((4000215, 35));
				break;
				
			case 12:
				itemList.Add((4000043, 45));
				itemList.Add((4000031, 30));
				break;
				
			case 13:
				itemList.Add((4000039, 30));
				itemList.Add((4000023, 20));
				itemList.Add((4000034, 10));
				break;
				
			case 14:
				itemList.Add((4000014, 20));
				itemList.Add((4000013, 60));
				break;
				
			case 15:
				itemList.Add((4000178, 50));
				break;
				
			case 16:
				itemList.Add((4000045, 35));
				itemList.Add((4000023, 25));
				itemList.Add((4000014, 15));
				break;
				
			case 17:
				itemList.Add((4000022, 50));
				itemList.Add((4000039, 50));
				break;
				
			case 18:
				itemList.Add((4000177, 50));
				itemList.Add((4000034, 30));
				break;
				
			case 19:
				itemList.Add((4000041, 50));
				break;
				
			case 20:
				itemList.Add((4000027, 45));
				itemList.Add((4000023, 50));
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
		
		string unlocks = GetQuestData(1300, "000000000000000");
		
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
		
		int selectedStyle = AskStyle(styles, "I can change your hairstyle and make it look great. Why don't you change it up a little bit? If you have #b#t4050001##k, I will change it for you. Choose the one of your liking.");
		
		if (!Exchange(0, 4050001, -1))
		{
			self.say("Hm... It looks like you don't have the right coupon... Too bad, I can't cut your hair without it. I'm sorry.");
			return;
		}
		
		chr.SetHair(selectedStyle);
		self.say("Look at that!! What do you think? Even I think this is a work of art! HAHAHA. Look for me if you want a new haircut, because I'll make you look great every time!");
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
		
		int selectedStyle = AskStyle(styles, "I can change your haircolor and make it look great. Why don't you change it up a little bit? If you have #b#t4051001##k, I will change it for you. Choose the one of your liking.");
		
		if (!Exchange(0, 4051001, -1))
		{
			self.say("Hm... It looks like you don't have the right coupon... Too bad, I can't cut your hair without it. I'm sorry.");
			return;
		}
		
		chr.SetHair(selectedStyle);
		self.say("Look at that!! What do you think? Even I think this is a work of art! HAHAHA. Look for me if you want a new haircut, because I'll make you look great every time!");
	}
	
	private void Quest(string quest)
	{
		var rnd = new Random();
		string unlocks = GetQuestData(1300, "000000000000000");
		string lastDate = GetQuestData(1008801);
		
		if (!unlocks.Contains("0"))
		{
			self.say("Thank you again for all your help~ I have everything I could ever need here at my wonderful salon. Please stop by any time you'd like!");
			return;
		}
		
		if (lastDate == DateTime.UtcNow.ToString("yyyyMMdd"))
		{
			self.say("Oh~ I'm still preparing the materials you brought for me. Please come back again tomorrow and I'll have more for you to do.");
			return;
		}
		
		if (quest == "")
		{
			self.say("Hello darling~ welcome to my wonderful salon! As you must know, my assistant Brittany and I have been running this shop for many years. Our catalogue features all of those classic hairstyles that everyone knows and loves, but lately I have been thinking of shaking things up.");
			self.say("There's a whole world of hair our there that I have yet to explore. I just need some time to experiment but when I'm not styling hair I'm picking up supplies for the shop. Hm... what to do... With the right materials I think I can come up with some new hairstyles you've never seen before!");
			bool start = AskYesNo("Oh, I know! If you gather the supplies for me, I'll have some time to experiment. I think I can come up with some new hairstyles you've never seen before and they'll all be available for you here. What do you think? Doesn't it sound like fun?");
			
			if (!start)
			{
				self.say("I understand. You must be busy right now. If you get some time, please come back and help me. I'll make it worth your while~");
				return;
			}
			
			string needString = MakeNeededString("1");
			
			SetQuestData(1008800, "1");
			self.say($"Thank you so much~! Hmm... let's see... I could use {needString} for my supplies. Come back when you've found everything.");
		}
		else if (quest == "e")
		{
			self.say("Oh~! Just in time... I still need some more supplies for my salon.");
			bool start = AskYesNo("The supplies might be harder to get this time. Are you ready?");
			
			if (!start)
			{
				self.say("I understand. Please come back when you have time. I really appreciate it!");
				return;
			}
			
			string newQuestID = QuestID(unlocks.Count(f => (f == '1'))).ToString();
			string needString = MakeNeededString(newQuestID);
			
			SetQuestData(1008800, newQuestID);
			self.say($"Thank you so much~! This time I'll need {needString}. Please hurry back, I'll be waiting for you!");
		}
		else
		{
			var needed = QuestRequirement(quest);
			string neededString = MakeNeededString(quest);
			
			for (int i = 0; i < needed.Count(); i++)
			{
				if (ItemCount(needed[i].Item) < needed[i].Amount)
				{
					self.say($"Hm... it doesn't look like you have everything I asked for. I'll need {neededString}. Please hurry back soon!");
					return;
				}
			}
			
			self.say("Wow, you really brought everything! Alright, let me just take these off your hands.");
			
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
			
			AddEXP(400 * (int)(Level * 0.3));
			SetQuestData(1300, newUnlockedHairs);
			SetQuestData(1008800, "e");
			SetQuestData(1008801, DateTime.UtcNow.ToString("yyyyMMdd"));
			QuestEndEffect();
			self.say($"While you were out collecting these materials, I've come up with a new style! I call it... #b{newHairString}#k. Thanks again for your help! Come back soon, I may need your help again.");
		}
	}
	
	private void RegisterHair()
	{
		var hairList = new List<int>();
		
		string savedHairs = GetQuestData(1310);
		string[] hairs = savedHairs.Split('_');
		
		foreach (string hair in hairs)
		{
			if (hair != "")
				hairList.Add(int.Parse(hair));
		}
		
		int savedOption = AskMenu("I can save the hairstyles that you absolutely adore and style your hair the same way anytime you like. What would you like to do?#b",
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
				self.say($"Hm... are you sure you have enough mesos for this? I can't change up your hair without {cost:n0} mesos. I'm sorry.");
				return;
			}
			
			chr.SetHair(mHair);
			self.say("Look at that!! What do you think? Even I think this is a work of art! HAHAHA. Look for me if you want a new haircut, because I'll make you look great every time!");
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
				self.say($"Hm... are you sure you have enough mesos for this? I can't register your hairstyle without {cost:n0} mesos. I'm sorry.");
				return;
			}
			
			savedHairs += $"{chr.Hair}_";
			SetQuestData(1310, savedHairs);
			self.say($"I've registered your hairstyle #b#t{chr.Hair}##k here at this salon. Please come back soon~!");
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
				self.say("Okay. If you ever get tired of those hairstyles, just come and talk to me.");
				return;
			}
			
			if (!Exchange(-cost))
			{
				self.say($"Hm... are you sure you have enough mesos for this? I can't change up your hair without {cost:n0} mesos. I'm sorry.");
				return;
			}
			
			savedHairs = savedHairs.Replace($"{mHair}_", string.Empty);
			SetQuestData(1310, savedHairs);
			self.say("Alright, the hairstyle is no longer registered at this salon. If you have another style you want to register, come talk to me~!");
		}
	}
	
	public override void Run()
	{
		var options = new List<(int, string)>();
		
		if (Level >= 15)
			options.Add((0, " Natalie's Salon Supplies\r\n"));
		
		options.Add((1, " Haircut (VIP coupon)"));
		options.Add((2, " Dye your hair (VIP coupon)"));
		options.Add((3, " Check your registered hairstyles"));
		
		int start = AskMenu("I'm the head of this hair salon Natalie. If you have #b#t4050001##k or #b#t4051001##k, let me take care of your hairstyle. Choose what you want.#b", options.ToArray());
		
		switch(start)
		{
			case 0: Quest(GetQuestData(1008800)); break;
			case 1: Haircut(); break;
			case 2: DyeHair(); break;
			case 3: RegisterHair(); break;
		}
	}
}

