using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		self.say("Well, hello! Welcome to the Orbis Skin-Care~! Would you like to have firm and healthy-looking skin like mine? With #b#t4053001##k, you can let us take care of everything and have the skin you've always wanted~!");
		
		List<int> styles = new List<int> {0, 1, 2, 3, 4};
		
		styles.Remove(chr.Skin);
		
		int mSkin = AskStyle(styles, "With our specialized machine, you can see yourself after the treatment in advance. What kind of skin-treatment would you like to do? Choose the style of your liking...");
			
		if (!Exchange(0, 4053001, -1))
		{
			self.say("It looks like you don't have the coupon you need to get the treatment. Sorry, but it looks like we can't do it.");
			return;
		}
			
		chr.SetSkin((byte) mSkin);
		self.say("Cool, check the result! What do you think? Does it look the way you wanted? I think it really is how you wanted it. Come back another time~");
	}
}