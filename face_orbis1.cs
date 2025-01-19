using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		int selectFace = AskMenu("Well well well, welcome!! I'm Franz, the head of the Orbis Plastic Surgery Shop. My goal is to give personality to everyone's eyes through the marvels of plastic surgery, and with #b#t4052005##k or #b#t4052015##k, I can do the same for you too! Now, what would you like to use?#b",
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
			//	styles.Add(20003 + tEyes);
			//	styles.Add(20004 + tEyes);
				styles.Add(20005 + tEyes);
				styles.Add(20006 + tEyes);
				styles.Add(20007 + tEyes);
				styles.Add(20008 + tEyes);
			//	styles.Add(20009 + tEyes);
				styles.Add(20010 + tEyes);
				styles.Add(20011 + tEyes);
			//	styles.Add(20012 + tEyes);
			//	styles.Add(20013 + tEyes);
				styles.Add(20014 + tEyes);
				styles.Add(20015 + tEyes);
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
			//	styles.Add(21003 + tEyes);
			//	styles.Add(21004 + tEyes);
				styles.Add(21005 + tEyes);
				styles.Add(21006 + tEyes);
				styles.Add(21007 + tEyes);
				styles.Add(21008 + tEyes);
			//	styles.Add(21009 + tEyes);
				styles.Add(21010 + tEyes);
				styles.Add(21011 + tEyes);
			//	styles.Add(21012 + tEyes);
			//	styles.Add(21013 + tEyes);
				styles.Add(21014 + tEyes);
				styles.Add(21016 + tEyes);
			//	styles.Add(21017 + tEyes);
			//	styles.Add(21018 + tEyes);
			//	styles.Add(21019 + tEyes);
			//	styles.Add(21020 + tEyes);
			//	styles.Add(21021 + tEyes);
			}
				
			styles.Remove(chr.Face);
				
			int mFace = AskStyle(styles, "I can totally transform your face into something new... how about giving us a try? For #b#t4052005##k, you can get the face of your liking...take your time in choosing the face of your preference...");
				
			if (!Exchange(0, 4052005, -1))
			{
				self.say("Hm... It looks like you don't have the specific coupon for this place... Sorry to say this, but without the coupon, there's no plastic surgery for you.");
				return;
			}
				
			chr.SetFace(mFace);
			self.say("Very good, the procedure's done... Here's the mirror for you to see... So? What do you think? I can certainly say this is a work of art... Hahaha, well, come back when you get sick of that new look, okay?");
		}
		else if (selectFace == 1)
		{
			List<int> colors = new List<int>();
			
			int eyes = chr.Face - (chr.Face / 100) % 10 * 100;
			
			colors.Add(eyes);
			colors.Add(eyes + 200);
			colors.Add(eyes + 400);
			colors.Add(eyes + 300);
			colors.Add(eyes + 700);
			
			colors.Remove(chr.Face);
			
			int mEyes = AskStyle(colors, "With our specialized machine, you can see yourself after the treatment in advance. What kind of lens would you like to wear? Take your time in choosing the face of your preference...");
			
			if (!Exchange(0, 4052015, -1))
			{
				self.say("Hm... It looks like you don't have the specific coupon for this place... Sorry to say this, but without the coupon, there's no plastic surgery for you.");
				return;
			}
				
			chr.SetFace(mEyes);
			self.say("Very good, the procedure's done... Here's the mirror for you to see... So? What do you think? I can certainly say this is a work of art... Hahaha, well, come back when you get sick of that new look, okay?");
		}
	}
}