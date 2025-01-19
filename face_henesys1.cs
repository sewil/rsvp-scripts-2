using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		int selectFace = AskMenu("I'm Denma, the head of the Plastic Surgery shop here in Henesys. If you have #b#t4052001##k or #b#t4052011##k, you can let us take care of the rest and have the kind of beautiful look you've always craved~! Remember, the first thing everyone notices about you is the eyes, and we can help you find the look that most fits you! Now, what would you like to use?#b",
			(0, " Plastic Surgery (VIP coupon)"),
			(1, " Cosmetic Lens (VIP coupon)"));
		
		if (selectFace == 0)
		{
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
				
			int mFace = AskStyle(styles, "Let's see... I can totally transform your face into something new. Don't you want to try? With #b#t4052001##k, you can win the face of your liking. Calmly choose the face of your preference.");
				
			if (!Exchange(0, 4052001, -1))
			{
				self.say("Hm... It looks like you don't have the specific coupon for this place... Sorry to say this, but without the coupon, there's no plastic surgery for you.");
				return;
			}
				
			chr.SetFace(mFace);
			self.say("Alright, the procedure's done. Check it out, here's the mirror. What do you think? Even I admit this is a work of art... haha, well, call me once you get sick of that new look, okay?");
		}
		else if (selectFace == 1)
		{
			List<int> colors = new List<int>();
			
			int eyes = chr.Face - (chr.Face / 100) % 10 * 100;
			
			colors.Add(eyes);
			colors.Add(eyes + 400);
			colors.Add(eyes + 100);
			colors.Add(eyes + 300);
			colors.Add(eyes + 600);
			
			colors.Remove(chr.Face);
			
			int mEyes = AskStyle(colors, "With our specialized machine, you can see yourself after the treatment in advance. What kind of lens would you like to wear? Calmly choose the lens of your preference.");
			
			if (!Exchange(0, 4052011, -1))
			{
				self.say("Hm... It looks like you don't have the specific coupon for this place... Sorry to say this, but without the coupon, there's no plastic surgery for you.");
				return;
			}
				
			chr.SetFace(mEyes);
			self.say("Alright, the procedure's done. Check it out, here's the mirror. What do you think? Even I admit this is a work of art... haha, well, call me once you get sick of that new look, okay?");
		}
	}
}