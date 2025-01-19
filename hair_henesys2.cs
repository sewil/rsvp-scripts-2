using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		int selectHair = AskMenu("I'm Brittany the assistant. If you have #b#t4050000##k or #b#t4051000##k by any chance, then how about letting me change your hairdo?#b",
			(0, " Haircut (REG coupon)"),
			(1, " Dye your hair (REG coupon)"));
			
		if (selectHair == 0)
		{
			bool askHaircut = AskYesNo("If you use the REG coupon your hair will change RANDOMLY with a chance to obtain a new style that even you didn't think was possible. Are you going to use #b#t4050000##k and really change your hairstyle?");
			
			if (!askHaircut)
			{
				self.say("I understand... Think about it and, if you still want to change it, come back and talk to me.");
				return;
			}
			
			if (!Exchange(0, 4050000, -1))
			{
				self.say("Hm... It looks like you don't have the right coupon... Too bad, I can't cut your hair without it. I'm sorry.");
				return;
			}
			
			Random rnd = new Random();
			List<int> styles = new List<int>();
			
			int z = chr.Hair % 10;
			
			if (chr.GetGender() == 0)
			{
				styles.Add(30000 + z);
				styles.Add(30020 + z);
				styles.Add(30030 + z);
				styles.Add(30060 + z);
				styles.Add(30120 + z);
				styles.Add(30140 + z);
				styles.Add(30150 + z);
				styles.Add(30200 + z);
				styles.Add(30210 + z);
				styles.Add(30250 + z);
				styles.Add(30330 + z);
				styles.Add(33150 + z);
				styles.Add(30620 + z);
			}
			else if (chr.GetGender() == 1)
			{
				styles.Add(31000 + z);
				styles.Add(31030 + z);
				styles.Add(31040 + z);
				styles.Add(31050 + z);
				styles.Add(31080 + z);
				styles.Add(31070 + z);
				styles.Add(31100 + z);
				styles.Add(31150 + z);
				styles.Add(31160 + z);
				styles.Add(31170 + z);
				styles.Add(31320 + z);
				styles.Add(31990 + z);
				styles.Add(31510 + z);
			}
			
			styles.Remove(chr.Hair);
			
			int mHair = styles[rnd.Next(styles.Count)];
			
			chr.SetHair(mHair);
			self.say("Hey, here's the mirror. What do you think of your new haircut? I know it wasn't the smoothest of all, but didn't it come out pretty nice? Come back later when you need to change it up again!");
		}
		else if (selectHair == 1)
		{
			bool askHaircut = AskYesNo("If you use the REG coupon your hair color will change RANDOMLY. Still want to use #b#t4051000##k and change it?");
			
			if (!askHaircut)
			{
				self.say("I understand... Think about it and, if you still want to change it, come back and talk to me.");
				return;
			}
			
			if (!Exchange(0, 4051000, -1))
			{
				self.say("Hm... It looks like you don't have the right coupon... Too bad, I can't cut your hair without it. I'm sorry.");
				return;
			}
			
			Random rnd = new Random();
			List<int> colors = new List<int>();
			
			int hair = chr.Hair - (chr.Hair % 10);
			
			colors.Add(hair);
			colors.Add(hair + 1);
			colors.Add(hair + 2);
			colors.Add(hair + 4);
			colors.Add(hair + 6);
			colors.Add(hair + 7);
			
			colors.Remove(chr.Hair);
			
			int mHair = colors[rnd.Next(colors.Count)];
			
			chr.SetHair(mHair);
			self.say("Here's the mirror. What do you think of your new hair color? know it wasn't the smoothest of all, but didn't it come out pretty nice?");
		}
	}
}