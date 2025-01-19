using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (ItemCount(4031019) < 1)
		{
			self.say("A nobody... Leave me alone...");
			return;
		}
		
		self.say("Not bad for a nobody like you to have something so precious and rare. What? You want me to decipher the scroll for you? No. Not even the greatest exorcists can handle the scroll that is laden with the secret forces from ancient times easily.");
		self.say("But hey... will you hand that scroll over to me? If I decipher this safely, it may help me tremendously in terms of getting rid of the hidden powers of evil all over the world.");
		self.say("To decipher it safely, I may need #b50 pieces of #t4000008##k. Get me the charms and the scroll, then I'll give you a daddy of all items I've gathered up from defeating the forces of evil over the years.");
		
		if (ItemCount(4000008) >= 50)
		{
			self.say("Alright, I'll give you that precious item like I promised. This is called the #r#t4031017##k and I got it from defeating one of the evil monsters of ancient times. NOT an easy item to acquire.");
			self.say("Inside the box contains a hard-to-find item. Unfortunately I lost the key, so I can't open it for you. You can probably open it at #bKerning City#k where there's an unbelievable #rlock smith#k that may open it for you.");
			
			if (!ExchangeEx(0, "4031019", -1, "4000008", -50, "4031017,Period:21600", 1))
			{
				self.say("I don't think there's space in your inventory. Free up space there and come talk to me.");
				return;
			}
		}
	}
}