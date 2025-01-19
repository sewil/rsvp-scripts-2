using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		self.say("Oh, hi! Welcome to the Ludibrium Skin-Care! Interested in getting tanned and looking sexy? How about a beautiful white skin? With #b#t4053002##k, you can let us take care of everything and have the skin you've always dreamed of~!");
		
		List<int> styles = new List<int> {0, 1, 2, 3, 4};
		
		styles.Remove(chr.Skin);
				
		int mSkin = AskStyle(styles, "With our specialized machine, you can see BEFORE the procedure how it will look after the treatment. What kind of appearance do you want? Go ahead and choose your preferred style.");
		
		if (!Exchange(0, 4053002, -1))
		{
			self.say("Hmm... I don't think you have our skin care coupon at the moment. Without the coupon, I'm sorry, I won't be able to do it.");
			return;
		}
			
		chr.SetSkin((byte) mSkin);
		self.say("Alright, go look at the mirror! What do you think? Like what you see? I'm sure it came out like you wanted. Come back another time~");
	}
}