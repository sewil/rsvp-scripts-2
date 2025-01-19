using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		int selectHair = AskMenu("Hi I'm the assistant here. Don't worry, I'm great at this. If you have #b#t4050006##k or #b#t4051006##k by any chance, how about letting me take care of the rest?#b",
			(0, " Haircut (REG coupon)"),
			(1, " Dye your hair (REG coupon)"));
			
		if (selectHair == 0)
		{
			bool askHaircut = AskYesNo("If you use the REG coupon, your hairstyle will randomly change to a new look, with a chance to get a new style you didn't even think was possible. Are you sure you want to use #b#t4050006##k and change everything?");
			
			if (!askHaircut)
			{
				self.say("I understand. Think about this carefully and, if you still want to, feel free to talk to me.");
				return;
			}
			
			if (!Exchange(0, 4050006, -1))
			{
				self.say("Hm... It looks like you don't have the right coupon. It's a shame, but I can't cut your hair without it. I'm sorry.");
				return;
			}
			
			Random rnd = new Random();
			List<int> styles = new List<int>();
			
			int z = chr.Hair % 10;
			
			if (chr.GetGender() == 0)
			{
				styles.Add(30030 + z);
				styles.Add(30020 + z);
				styles.Add(30000 + z);
				styles.Add(30250 + z);
				styles.Add(30190 + z);
				styles.Add(30150 + z);
				styles.Add(30660 + z);
				styles.Add(30050 + z);
				styles.Add(30280 + z);
				styles.Add(30240 + z);
				styles.Add(30300 + z);
				styles.Add(30160 + z);
				styles.Add(30410 + z);
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
				styles.Add(31010 + z);
				styles.Add(31410 + z);
			}
			
			styles.Remove(chr.Hair);
			
			int mHair = styles[rnd.Next(styles.Count)];
			
			chr.SetHair(mHair);
			self.say("Hey, here's the mirror. What do you think of your new haircut? I know it wasn't the smoothest of all, but didn't it come out pretty nice? Stop by here if you feel you need to change it again.");
		}
		else if (selectHair == 1)
		{
			bool askHaircut = AskYesNo("If you use the reg coupon, your hair color will change to a random color. Are you sure you want to use #b#t4051006##k and change everything?");
			
			if (!askHaircut)
			{
				self.say("I understand. Think about this carefully and, if you still want to, feel free to talk to me.");
				return;
			}
			
			if (!Exchange(0, 4051006, -1))
			{
				self.say("Hm... It looks like you don't have the right coupon... Too bad, I can't dye your hair without it. I'm sorry.");
				return;
			}
			
			Random rnd = new Random();
			List<int> colors = new List<int>();
			
			int hair = chr.Hair - (chr.Hair % 10);
			
			colors.Add(hair);
			colors.Add(hair + 2);
			colors.Add(hair + 3);
			colors.Add(hair + 4);
			colors.Add(hair + 7);
			colors.Add(hair + 5);
			
			colors.Remove(chr.Hair);
			
			int mHair = colors[rnd.Next(colors.Count)];
			
			chr.SetHair(mHair);
			self.say("Hey, here's the mirror. What do you think of your new hair color? I know it wasn't the smoothest of all, but didn't it come out pretty nice? Stop by here if you feel you need to change it again.");
		}
	}
}