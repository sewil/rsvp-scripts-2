using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		var options = new List<(int, string)>();
		
		options.Add((0, " Haircut (VIP coupon)"));
		options.Add((1, " Dye your hair (VIP coupon)"));
		
		if (chr.GetGender() == 1)
			options.Add((2, " Use #t4054000#"));
		
		else if (chr.GetGender() == 0)
			options.Add((3, " Use #t4054001#"));
		
		options.Add((4, " Check your registered hairstyles"));
		
		int selectHair = AskMenu("Hello, I'm #p2010001#. If you have #b#t4050005##k or #b#t4051005##k, then let me take care of your hair. Decide what you want to do with it.#b", options.ToArray());
			
		if (selectHair == 0)
		{
			var styles = new List<int>();
			
			int z = chr.Hair % 10;
			
			if (chr.GetGender() == 0)
			{
				styles.Add(30030 + z);
				styles.Add(30020 + z);
				styles.Add(30000 + z);
				styles.Add(30100 + z);
				styles.Add(30230 + z);
				styles.Add(30260 + z);
				styles.Add(30280 + z);
				styles.Add(30240 + z);
				styles.Add(30290 + z);
				styles.Add(30270 + z);
				styles.Add(30340 + z);
				styles.Add(30400 + z);
				styles.Add(30800 + z);
				styles.Add(30220 + z);
			}
			else if (chr.GetGender() == 1)
			{
				styles.Add(31000 + z);
				styles.Add(31250 + z);
				styles.Add(31220 + z);
				styles.Add(31420 + z);
				styles.Add(31260 + z);
				styles.Add(31240 + z);
				styles.Add(31110 + z);
				styles.Add(31270 + z);
				styles.Add(31030 + z);
				styles.Add(31230 + z);
				styles.Add(31320 + z);
				styles.Add(31400 + z);
				styles.Add(31800 + z);
				styles.Add(31180 + z);
			}
			
			styles.Remove(chr.Hair);
			
			int mHair = AskStyle(styles, "I can completely change the style of your hair. Are you ready for a change? If you have #b#t4050005##k I'll change it for you. Choose what you want!");
			
			if (!Exchange(0, 4050005, -1))
			{
				self.say("Hm... It looks like you don't have the the right coupon... Too bad, I can't cut your hair without it. I'm sorry.");
				return;
			}
			
			chr.SetHair(mHair);
			self.say("Look at that!! What do you think? Even I think it's a work of art! HAHAHA. Come find me if you want a new haircut, because I'll make you look great every time!");
		}
		else if (selectHair == 1)
		{
			List<int> colors = new List<int>();
			
			int hair = chr.Hair - (chr.Hair % 10);
			
			colors.Add(hair);
			colors.Add(hair + 1);
			colors.Add(hair + 7);
			colors.Add(hair + 3);
			colors.Add(hair + 4);
			colors.Add(hair + 5);
			
			colors.Remove(chr.Hair);
			
			int mHair = AskStyle(colors, "I can completely change the color of your hair. Are you ready for a change? If you have #b#t4051005##k I'll change it for you. Choose what you want!");
			
			if (!Exchange(0, 4051005, -1))
			{
				self.say("Hm... It looks like you don't have the the right coupon... Too bad, I can't dye your hair without it. I'm sorry.");
				return;
			}
			
			chr.SetHair(mHair);
			self.say("Look at that!! What do you think? Even I think it's a work of art! HAHAHA. Come find me if you want a new hair color, because I'll make you look great every time!");
		}
		else if (selectHair == 2)
		{
			if (chr.Hair % 31240 < 10)
			{
				self.say("Want to use the #b#t4054000##k? Sorry, but it looks like you already have disheveled hair. Try again another time.");
				return;
			}
			
			bool askHaircut = AskYesNo("It seems like you have a #b#t4054000##k with you. This coupon is specifically made for all women who have a preference for ruffled hair. Use it and I'll immediately change your hairstyle to disheveled hair. Are you sure you want to use #b#t4054000##k and change your hair?");
			
			if (!askHaircut)
			{
				self.say("I see... Well, think about it and, if you have a change of heart, talk to me.");
				return;
			}
			
			if (!Exchange(0, 4054000, -1))
			{
				self.say("Hm... It looks like you don't have the the right coupon... Too bad, I can't cut your hair without it. I'm sorry.");
				return;
			}
			
			int mHair = 31240 + (chr.Hair % 10);
			
			chr.SetHair(mHair);
			self.say("Look at that!! What do you think? Even I think it's a work of art! HAHAHA. Come find me if you want a new haircut, because I'll make you look great every time!");
		}
		else if (selectHair == 3)
		{
			if (chr.Hair % 30090 < 10)
			{
				self.say("Want to use the #b#t4054001##k? Sorry, but it looks like you already have the mohawk hair. Try again another time.");
				return;
			}
			
			bool askHaircut = AskYesNo("It seems like you have a #b#t4054001##k with you. This coupon is specifically made for all men who are looking for a wild new look. Use it and I'll immediately change your hairstyle to a mohawk. Are you sure you want to use #b#t4054001##k and change your hair?");
			
			if (!askHaircut)
			{
				self.say("I see... Well, think about it and, if you have a change of heart, talk to me.");
				return;
			}
			
			if (!Exchange(0, 4054001, -1))
			{
				self.say("Hm... It looks like you don't have the the right coupon... Too bad, I can't cut your hair without it. I'm sorry.");
				return;
			}
			
			int mHair = 30090 + (chr.Hair % 10);
			
			chr.SetHair(mHair);
			self.say("Look at that!! What do you think? Even I think it's a work of art! HAHAHA. Come find me if you want a new haircut, because I'll make you look great every time!");
		}
		else if (selectHair == 4)
		{
			var hairList = new List<int>();
			
			string savedHairs = GetQuestData(1312);
			string[] hairs = savedHairs.Split('_');
			
			foreach (string hair in hairs)
			{
				if (hair != "")
					hairList.Add(int.Parse(hair));
			}
			
			int savedOption = AskMenu("I can save your favorite hairstyles and style your hair the same way anytime you like. What would you like to do?#b",
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
				self.say("Look at that!! What do you think? Even I think it's a work of art! HAHAHA. Come find me if you want a new haircut, because I'll make you look great every time!");
			}
			else if (savedOption == 1)
			{
				int cost = (990 * Level) + Level * 99;
				
				if (savedHairs.Contains($"{chr.Hair}_"))
				{
					self.say("I think you have already registered this hairstyle here.");
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
				SetQuestData(1312, savedHairs);
				self.say($"I've registered your hairstyle #b#t{chr.Hair}##k here at this salon. Please come back soon!");
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
				SetQuestData(1312, savedHairs);
				self.say("Alright, the hairstyle is no longer registered at this salon. If you have another style you want to register, come talk to me~!");
			}
		}
	}
}