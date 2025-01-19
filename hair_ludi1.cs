using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		int selectHair = AskMenu("Welcome welcome, welcome to the Ludibrium Hair Salon! By any chance, do you have #b#t4050007##k or #b#t4051007##k? If so, how about letting me take care of your hair? Decide what you want to do with your hair...#b",
			(0, " Haircut (VIP coupon)"),
			(1, " Dye your hair (VIP coupon)"),
			(2, " Check your registered hairstyles")
		);
			
		if (selectHair == 0)
		{
			List<int> styles = new List<int>();
			
			int z = chr.Hair % 10;
			
			if (chr.GetGender() == 0)
			{
				styles.Add(30030 + z);
				styles.Add(30020 + z);
				styles.Add(30000 + z);
				styles.Add(30250 + z);
				styles.Add(30660 + z);
				styles.Add(30190 + z);
				styles.Add(30150 + z);
				styles.Add(30050 + z);
				styles.Add(30280 + z);
				styles.Add(30240 + z);
				styles.Add(30300 + z);
				styles.Add(30410 + z);
				styles.Add(30160 + z);
			}
			else if (chr.GetGender() == 1)
			{
				styles.Add(31040 + z);
				styles.Add(31000 + z);
				styles.Add(31150 + z);
				styles.Add(31280 + z);
				styles.Add(31160 + z);
				styles.Add(31340 + z);
				styles.Add(31120 + z);
				styles.Add(31290 + z);
				styles.Add(31270 + z);
				styles.Add(31030 + z);
				styles.Add(31230 + z);
				styles.Add(31410 + z);
				styles.Add(31010 + z);
			}
			
			styles.Remove(chr.Hair);
			
			int mHair = AskStyle(styles, "I can completely change the style of your hair. Aren't you ready for a change? With #b#t4050007##k, I'll take care of the rest for you. Choose the style of your liking...");
			
			if (!Exchange(0, 4050007, -1))
			{
				self.say("Hm... It looks like you don't have the right coupon... Too bad, I can't cut your hair without it. I'm sorry.");
				return;
			}
			
			chr.SetHair(mHair);
			self.say("Look at that!! What do you think? Even I think this is a work of art! HAHAHA. Look for me if you want a new haircut, because I'll make you look great every time!");
		}
		else if (selectHair == 1)
		{
			List<int> colors = new List<int>();
			
			int hair = chr.Hair - (chr.Hair % 10);
			
			colors.Add(hair);
			colors.Add(hair + 2);
			colors.Add(hair + 3);
			colors.Add(hair + 4);
			colors.Add(hair + 7);
			colors.Add(hair + 5);
			
			colors.Remove(chr.Hair);
			
			int mHair = AskStyle(colors, "I can completely change the color of your hair. Aren't you ready for a change? With #b#t4051007##k, I'll take care of the rest. Choose the color of your liking!");
			
			if (!Exchange(0, 4051007, -1))
			{
				self.say("Hm... It looks like you don't have the right coupon... Too bad, I can't cut your hair without it. I'm sorry.");
				return;
			}
			
			chr.SetHair(mHair);
			self.say("Look at that!! What do you think? Even I think this is a work of art! HAHAHA. Look for me if you want a new haircut, because I'll make you look great every time!");
		}
		else if (selectHair == 2)
		{
			var hairList = new List<int>();
			
			string savedHairs = GetQuestData(1313);
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
				int cost = (650 * Level) + Level * 65;
				
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
				int cost = (980 * Level) + Level * 98;
				
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
				SetQuestData(1313, savedHairs);
				self.say($"I've registered your hairstyle #b#t{chr.Hair}##k here at this salon. Please come back soon!");
			}
			else if (savedOption == 2)
			{
				int cost = (320 * Level) + Level * 32;
				
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
				SetQuestData(1313, savedHairs);
				self.say("Alright, the hairstyle is no longer registered at this salon. If you have another style you want to register, come talk to me~!");
			}
		}
	}
}