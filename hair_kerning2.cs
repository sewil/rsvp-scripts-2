using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		int selectHair = AskMenu("I'm Andres, Don's assistant. Everyone calls me Andre, though. If you have #b#t4050002##k or #b#t4051002##k, please let me change your hairdo ...#b",
			(0, " Haircut (REG coupon)"),
			(1, " Dye your hair (REG coupon)"));
			
		if (selectHair == 0)
		{
			bool askHaircut = AskYesNo("If you use the REG coupon, your hair will change RANDOMLY with a chance to get a new style you didn't even think was possible. Will you use a #b#t4050002##k and really change your hairstyle?");
			
			if (!askHaircut)
			{
				self.say("I see... Think a little more and, if you reconsider, come find me.");
				return;
			}
			
			if (!Exchange(0, 4050002, -1))
			{
				self.say("Hm... Are you sure you have the right coupon? Sorry, but you can't get a haircut without it.");
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
				styles.Add(30040 + z);
				styles.Add(30050 + z);
				styles.Add(30110 + z);
				styles.Add(30130 + z);
				styles.Add(30160 + z);
				styles.Add(30180 + z);
				styles.Add(30190 + z);
				styles.Add(30170 + z);
				styles.Add(30360 + z);
				styles.Add(30920 + z);
				styles.Add(30550 + z);
			}
			else if (chr.GetGender() == 1)
			{
				styles.Add(31000 + z);
				styles.Add(31010 + z);
				styles.Add(31020 + z);
				styles.Add(31040 + z);
				styles.Add(31050 + z);
				styles.Add(31060 + z);
				styles.Add(31090 + z);
				styles.Add(31120 + z);
				styles.Add(31130 + z);
				styles.Add(31140 + z);
				styles.Add(31210 + z);
				styles.Add(31350 + z);
				styles.Add(31300 + z);
				styles.Add(31550 + z);
			}
			
			styles.Remove(chr.Hair);
			
			int mHair = styles[rnd.Next(styles.Count)];
			
			chr.SetHair(mHair);
			self.say("Ok, here's the mirror. Your new haircut! What do you think? I know it wasn't the smoothest, but it still looks pretty good! Come back later when you need to change it up again!");
		}
		else if (selectHair == 1)
		{
			bool askHaircut = AskYesNo("If you use the REG coupon, your hair will change randomly. Will you use a #b#t4051002##k and dye your hair?");
			
			if (!askHaircut)
			{
				self.say("I see... Think a little more and, if you reconsider, come find me.");
				return;
			}
			
			if (!Exchange(0, 4051002, -1))
			{
				self.say("Hm... Are you sure you have the right coupon? Sorry, but you can't get a haircut without it.");
				return;
			}
			
			Random rnd = new Random();
			List<int> colors = new List<int>();
			
			int hair = chr.Hair - (chr.Hair % 10);
			
			colors.Add(hair);
			colors.Add(hair + 2);
			colors.Add(hair + 3);
			colors.Add(hair + 7);
			colors.Add(hair + 5);
			
			colors.Remove(chr.Hair);
			
			int mHair = colors[rnd.Next(colors.Count)];
			
			chr.SetHair(mHair);
			self.say("Ok, here's the mirror. Your new haircut! What do you think? I know it wasn't the smoothest, but it still looks pretty good! Come back later when you need to change it up again!");
		}
	}
}