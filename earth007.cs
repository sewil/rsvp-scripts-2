using WvsBeta.Game;

// 2050002 Alien Gray
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1003400);
		
		if (Level < 44)
		{
			self.say("The Omega Sector is busy attacking innocent aliens again ... it's just unfortunate ...");
			return;
		}
		
		if (quest == "")
		{
			bool start = AskYesNo("Hello, there. Stunned to see an alien talking to you? \r\nHahaha... you can leave your guards down, because we're actually here to HELP you guys. Seems like you've been to Omega Sector before, haven't you? If you aren't so busy and all, can you help us out?");
			
			if (!start)
			{
				self.say("I see... that's understandable, since you've met the Sector people first, and therefore don't really like us. But trust me when I say we're ready to be friends with you, so if you feel like changing your mind, then come talk to me.");
				return;
			}
			
			SetQuestData(1003400, "s");
			self.say("I knew I could talk to you. Thanks for making some time for us. I have a small, discreet favor to ask you, so please listen carefully. You've met those people at the Omega Sector, right? Are you... aware of exactly what they REALLY do, though?");
			self.say("They probably told you they're here to take down the aliens, but in truth... it's NOT US that's a threat to the society; it's THEM. They are mercilessly attacking us, when the only crime we've committed is to try to coexist with the humans here.");
			self.say("Their real ambition is to win the public by declaring war on the strange-looking aliens, then just when the public is at their side, they take over the world. Isn't that sickening? Every one of you is falling for it. That's why... I want you to do something to help us fight against them.");
			self.say("Please enter the #bOmega Sector Silo#k, check out the solid boxes that are laying there, and bring back #b3 #t4031116#s#k for us. The boxes probably contain classified information regarding the Omega Sector, so it's something we really need to have. I'll be here waiting for you...");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031116) < 3)
			{
				self.say("Hmmm... I don't think you got a hold of #t4031116#, yet. Please enter the #bOmega Sector Silo#k, rummage through the boxes, and bring back #b3 #t4031116#s#k for us. This will be important in our goal towards defeating them. Don't worry about the rewards; we'll hook you up with something nice. I'll be here waiting.");
				return;
			}
			
			self.say("Hmmm... you really did bring back 3 #t4031116#s like we asked. Alright... since you did us a favor, we'll have to repay it with something nice. I'll give you an item that'll allow you to summon us in case you find yourself in trouble, but please pick your spots when do that, because you may find yourself in deep trouble if you don't, okay?");
			
			if (!Exchange(0, 4031116, -3, 2100017, 3))
			{
				self.say("You'll need a space in your use inventory to carry this.");
				return;
			}
			
			AddEXP(3400);
			SetQuestData(1003400, "e");
			QuestEndEffect();
			self.say("Hahahaha, sucker!!!! What an idiot! We finally got a hold of the classified information on Omega Sector!!! You really thought the great Grays will actually 'coexist' with dirtbags like you? Please... this is why the humans are at the bottom of the chain. This will accelerate our invasion of Ludibirum!");
			self.say("Now what would happen if they find out you've done all this for us? I suggest you run away before they find out that you've been the one helping out the aliens!!! Hahaha... I don't need you now, so get out of my sight!!");
		}
		else if (quest == "e")
		{
			self.say("Hahaha, you fool. The critical document you gave me is currently in the process of deciphering. Omega Sector has been impossible to attack because of their tight security, but I'm sure the deciphering will be done soon. I don't need you anymore, so get away from me!");
		}
	}
}