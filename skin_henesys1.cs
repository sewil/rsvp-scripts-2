using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		self.say("Well, hello! Welcome to the Henesys Skin-Care! Would you like to have a firm and healthy-looking skin like mine? With #b#t4053000##k, you can let us take care of everything and have the skin you've always wanted~!");
		
		List<int> styles = new List<int> {0, 1, 2, 3, 4};
		
		styles.Remove(chr.Skin);
				
		int mSkin = AskStyle(styles, "With our specialized machine, you can see yourself after the treatment in advance. What kind of skin-treatment would you like to do? Choose the style of your liking...");
		
		if (!Exchange(0, 4053000, -1))
		{
			self.say("Hm... you don't have the skin care coupon you need to get the treatment. Sorry, but we can't do it.");
			return;
		}
			
		chr.SetSkin((byte) mSkin);
		self.say("Here's the mirror, take a look! What do you think? Isn't your skin as beautiful and dazzling as mine? Hehehehe~ I'm sure you're enjoying it. Come back another time~");
	}
}