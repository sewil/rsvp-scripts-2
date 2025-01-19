using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		int selectHair = AskMenu("I'm #p2012007#. Do you have #b#t4050004##k or #b#t4051004##k on you? If so, what do you think about letting me take care of your hairdo? What do you want to do with your hair?#b",
			(0, " Haircut (REG coupon)"),
			(1, " Dye your hair (REG coupon)"));
			
		if (selectHair == 0)
		{
			bool askHaircut = AskYesNo("If you use the REG coupon, your hair will change RANDOMLY with a chance to obtain a new style that even you didn't think was possible. Still want to use #b#t4050004##k and change your hair?");
			
			if (!askHaircut)
			{
				self.say("I understand... Think about it and, if you still want to change it, come back and talk to me.");
				return;
			}
			
			if (!Exchange(0, 4050004, -1))
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
				styles.Add(30100 + z);
				styles.Add(30230 + z);
				styles.Add(30260 + z);
				styles.Add(30280 + z);
				styles.Add(30240 + z);
				styles.Add(30290 + z);
				styles.Add(30270 + z);
				styles.Add(30340 + z);
				styles.Add(30220 + z);
				styles.Add(30800 + z);
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
				styles.Add(31180 + z);
				styles.Add(31800 + z);
			}
			
			styles.Remove(chr.Hair);
			
			int mHair = styles[rnd.Next() % styles.Count];
			
			chr.SetHair(mHair);
			self.say("Here's the mirror. What do you think of the new hairdo? I know it wasn't the smoothest, but doesn't it look good? Stop by if you feel like you need to change it again.");
		}
		else if (selectHair == 1)
		{
			bool askHaircut = AskYesNo("If you use a regular coupon, your hair will change randomly. Do you still want to use #b#t4051004##k and change it up?");
			
			if (!askHaircut)
			{
				self.say("I understand... Think about it and, if you still want to change it, come back and talk to me.");
				return;
			}
			
			if (!Exchange(0, 4051004, -1))
			{
				self.say("Hm... It looks like you don't have the right coupon... Too bad, I can't dye your hair without it. I'm sorry.");
				return;
			}
			
			Random rnd = new Random();
			List<int> colors = new List<int>();
			
			int hair = chr.Hair - (chr.Hair % 10);
			
			colors.Add(hair);
			colors.Add(hair + 1);
			colors.Add(hair + 7);
			colors.Add(hair + 3);
			colors.Add(hair + 4);
			colors.Add(hair + 5);
			
			colors.Remove(chr.Hair);
			
			int mHair = colors[rnd.Next() % colors.Count];
			
			chr.SetHair(mHair);
			self.say("Here's the mirror. What do you think of the new hair color? I know it wasn't the smoothest, but doesn't it look good? Stop by if you feel like you need to change it again.");
		}
	}
}