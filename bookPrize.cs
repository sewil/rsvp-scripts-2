using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (ItemCount(4031048) >= 1)
		{
			bool askTrade = AskYesNo("Hey, hey! Do you have a #b#t4031048##k? Okay... if you give it to me, I'll give you something nice. BUT understand that the item you receive is chosen RANDOMLY. It's a matter of luck. What do you think? Do you want to trade?");
			
			if (!askTrade)
			{
				self.say("Alright... whatever you want. Just know, that item is only taking up space in your inventory. So, I suggest you exchange it for a prize.");
				return;
			}
			
			if (SlotCount(2) < 1 || SlotCount(4) < 1)
			{
				self.say("Hey, hey! You need at least one slot available in your use and etc. inventory to receive my prize. Come and talk to me when you've made some room.");
				return;
			}
			
			Random rnd = new Random();
			int[] itemID = {2000004, 4011006, 4011000, 4011005, 4021005, 4021001, 4021007};
			int[] itemNum = {100, 10, 10, 10, 10, 10, 10};
			
			int rnum = rnd.Next(itemID.Length);
			
			if (!Exchange(0, 4031048, -1, itemID[rnum], itemNum[rnum]))
			{
				self.say("Please make sure you have the #t4031048# and that your use and etc. inventories have enough space.");
			}
			else
			{
				self.say($"Did you get the #b{itemNum[rnum]} #t{itemID[rnum]}#s#k? What do you think? Did you like what you got? Hahaha... see you later~");
			}
		}
	}
}