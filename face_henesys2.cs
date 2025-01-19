using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		int selectFace = AskMenu("My name is Dr. Feeble, Denma's assistant. If you have\r\n#b#t4052000##k or #b#t4052010##k, how about letting me change your face?#b",
			(0, " Plastic Surgery (REG coupon)"),
			(1, " Cosmetic Lens (REG coupon)"));
			
		if (selectFace == 0)
		{
			bool askStyle = AskYesNo("If you use the regular coupon, your face may transform into something else... Still want to do this using #b#t4052000##k?");
			
			if (!askStyle)
			{
				self.say("I understand... Think about it a little and see if it's really what you want. When you decide, let me know.");
				return;
			}
			
			if (!Exchange(0, 4052000, -1))
			{
				self.say("Hm... It looks like you don't have the specific coupon for this place. Sorry to say this, but without the coupon, there's no plastic surgery for you.");
				return;
			}
			
			Random rnd = new Random();
			List<int> styles = new List<int>();
			
			int tEyes = (chr.Face / 100) % 10 * 100;
			
			if (chr.GetGender() == 0)
			{
				styles.Add(20000 + tEyes);
				styles.Add(20001 + tEyes);
				styles.Add(20002 + tEyes);
				styles.Add(20003 + tEyes);
				styles.Add(20004 + tEyes);
				styles.Add(20005 + tEyes);
				styles.Add(20006 + tEyes);
				styles.Add(20007 + tEyes);
				styles.Add(20008 + tEyes);
				styles.Add(20009 + tEyes);
			//	styles.Add(20010 + tEyes);
			//	styles.Add(20011 + tEyes);
			//	styles.Add(20012 + tEyes);
				styles.Add(20013 + tEyes);
			//	styles.Add(20014 + tEyes);
			//	styles.Add(20015 + tEyes);
			//	styles.Add(20016 + tEyes);
			//	styles.Add(20017 + tEyes);
			//	styles.Add(20018 + tEyes);
			//	styles.Add(20019 + tEyes);
			//	styles.Add(20020 + tEyes);
			}
			else if (chr.GetGender() == 1)
			{
				styles.Add(21000 + tEyes);
				styles.Add(21001 + tEyes);
				styles.Add(21002 + tEyes);
				styles.Add(21003 + tEyes);
				styles.Add(21004 + tEyes);
				styles.Add(21005 + tEyes);
				styles.Add(21006 + tEyes);
				styles.Add(21007 + tEyes);
				styles.Add(21008 + tEyes);
				styles.Add(21009 + tEyes);
			//	styles.Add(21010 + tEyes);
			//	styles.Add(21011 + tEyes);
			//	styles.Add(21012 + tEyes);
				styles.Add(21013 + tEyes);
			//	styles.Add(21014 + tEyes);
			//	styles.Add(21016 + tEyes);
			//	styles.Add(21017 + tEyes);
			//	styles.Add(21018 + tEyes);
			//	styles.Add(21019 + tEyes);
			//	styles.Add(21020 + tEyes);
			//	styles.Add(21021 + tEyes);
			}
			
			styles.Remove(chr.Face);
			
			int mFace = styles[rnd.Next(styles.Count)];
			
			chr.SetFace(mFace);
			self.say("Okay, the surgery's complete. Here's the mirror... What do you think? I think this is a work of art... hahahaha, please come back when you get sick of that new look, okay?");
		}
		else if (selectFace == 1)
		{
			bool askLens = AskYesNo("If you use the regular coupon, you'll be awarded a random pair of cosmetic lenses. Are you going to use #b#t4052010##k and really make the change to your eyes?");
			
			if (!askLens)
			{
				self.say("I understand... Think about it a little and see if it's really what you want. When you decide, let me know.");
				return;
			}
			
			if (!Exchange(0, 4052010, -1))
			{
				self.say("Hm... It looks like you don't have the specific coupon for this place. Sorry to say this, but without the coupon, there's no plastic surgery for you.");
				return;
			}
			
			Random rnd = new Random();
			List<int> colors = new List<int>();
				
			int eyes = chr.Face - (chr.Face / 100) % 10 * 100;
			
			colors.Add(eyes);
			colors.Add(eyes + 400);
			colors.Add(eyes + 100);
			colors.Add(eyes + 300);
			colors.Add(eyes + 600);
			
			colors.Remove(chr.Face);
			
			int mEyes = colors[rnd.Next(colors.Count)];
			
			chr.SetFace(mEyes);
			self.say("Okay, the surgery's complete. Here's the mirror... What do you think? I think this is a work of art... hahahaha, please come back when you get sick of that new look, okay?");
		}
	}
}