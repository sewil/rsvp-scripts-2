using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void CraftScroll(int index, string makeLevel, string makeItem, string needItem, int[] scrolls)
	{
		bool askBuy = AskYesNo($"To make a #b{makeItem}#k, I'll need the following ingredients. This recipe will produce a #b{makeLevel}#k scroll but there's no way of knowing what kind of enchantment will come out of it. What do you think? Do you still want me to make it?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("I understand. There is always a risk involved when enchanting a scroll. If you change your mind please come back and talk to me!");
			return;
		}
		
		if (SlotCount(2) < 1)
		{
			self.say("Hmm... it looks like your use inventory is full. Please leave an available slot and talk to me again.");
			return;
		}
		
		Random rnd = new Random();
		
		int itemID = scrolls[rnd.Next(scrolls.Length)];
		
		bool trade = false;
		
		// tops
		if (index == 1) trade = Exchange(-10000, 4132000, -1, 4000016, -45, 2000000, -20, itemID, 1);
		else if (index == 2) trade = Exchange(-80000, 4132001, -1, 4000023, -240, 2000001, -60, itemID, 1);
		
		// bottoms
		else if (index == 100) trade = Exchange(-10000, 4132000, -1, 4000000, -45, 2000003, -10, itemID, 1);
		else if (index == 101) trade = Exchange(-80000, 4132001, -1, 4000013, -240, 2000006, -30, itemID, 1);
		
		// gloves
		else if (index == 200) trade = Exchange(-10000, 4132000, -1, 4000006, -40, 2000000, -30, itemID, 1);
		else if (index == 201) trade = Exchange(-80000, 4132001, -1, 4000030, -60, 2012002, -15, itemID, 1);
		
		// capes
		else if (index == 300) trade = Exchange(-10000, 4132000, -1, 4000002, -50, 2000000, -20, itemID, 1);
		else if (index == 301) trade = Exchange(-80000, 4132001, -1, 4000033, -200, 2000006, -50, itemID, 1);
		
		// pet equip
		else if (index == 400) trade = Exchange(-10000, 4132000, -1, 4000037, -15, 2120000, -10, itemID, 1);
		else if (index == 401) trade = Exchange(-50000, 4132001, -1, 4000026, -30, 2022000, -10, itemID, 1);
		
		// 2H weapon
		else if (index == 500) trade = Exchange(-30000, 4132000, -1, 4000008, -45, 2000001, -15, itemID, 1);
		else if (index == 501) trade = Exchange(-120000, 4132001, -1, 4000025, -200, 2012002, -15, itemID, 1);
		
		if (!trade)
		{
			self.say("Hmm... are you sure you have all the necessary ingredients? I won't be able to enchant a scroll without them.");
			return;
		}
		
		MapPacket.SendScrollResult(chr, true);
		self.say($"Hahhhh!! Alright, it is done. Using the recipe I was able to make a #b#t{itemID}##k. All those years spent training in the Magic Library were worth it! Please come back again soon.");
	}
	
	private void RemoveEnchant(int level, int cost, int makeItem, int chance, int[] scrolls)
	{
		bool hasScroll = false;
				
		List<int> scroll = new List<int>();
		List<string> options = new List<string>();
				
		for (var i = 0; i < scrolls.Length; i++)
		{
			if (ItemCount(scrolls[i]) >= 1)
			{
				hasScroll = true;
				scroll.Add(scrolls[i]);
				options.Add($" #t{scrolls[i]}#");
			}
		}

		if (!hasScroll)
		{
			self.say($"Hmm... it looks like you don't have any Level {level} scrolls. Please check your use inventory and talk to me again.");
			return;
		}
				
		int chosenScroll = AskMenu("Which of these scrolls do you want me to strip of its enchantment?#b", options.ToArray());
		
		int scrollID = scroll[chosenScroll];
		
		bool askRemove = AskYesNo($"Let's see... I can strip the following scroll of its enchantment and turn it into a #bLevel {level} Blank Scroll#k. It will cost #r{cost:n0}#k mesos and there's a #r{chance}% chance the scroll will be destroyed in the process#k. Please remember this cannot be undone. So what do you think? Do you really want me to strip this scroll of its enchantment?\r\n\r\n#b#v{scrollID}# #t{scrollID}##k");
		
		if (!askRemove)
		{
			self.say("I understand. There is always a risk involved when stripping the enchantment from a scroll. If you change your mind please come back and talk to me.");
			return;
		}
		
		if (SlotCount(4) < 1)
		{
			self.say("Hmm... it looks like your etc. inventory is full. Please leave an available slot and talk to me again.");
			return;
		}
		
		if (Mesos < cost)
		{
			self.say($"Are you sure you have #r{cost:n0}#k mesos? Please check and talk to me again.");
			return;
		}
		
		Random rnd = new Random();
		
		int rnum = rnd.Next(1, 101);
		
		// fail
		if (rnum <= chance)
		{
			if (!Exchange(0, scrollID, -1))
			{
				self.say($"Are you sure you have the #t{scrollID}#? If so, please make sure you have at least #r{cost:n0} mesos#k.");
				return;
			}
			
			MapPacket.SendScrollResult(chr, false);
			self.say("Oh no... it looks like the scroll was destroyed. I warned you that this could happen. I'm sorry... I hope that you can understand.");
		}
		
		// success
		else
		{
			if (!Exchange(-cost, scrollID, -1, makeItem, 1))
			{
				self.say($"Are you sure you have the #t{scrollID}#? If so, please make sure you have at least #r{cost:n0} mesos#k.");
				return;
			}
			
			MapPacket.SendScrollResult(chr, true);
			self.say($"Hahhhh!! Alright, it is done, please take the #b#t{makeItem}##k. All those years spent training in the Magic Library were worth it! Please come back again soon.");
		}
	}
		
	public override void Run()
	{
		bool askStart = AskYesNo("Hmm... Topaz... the wart of a frog and... aha! With this I can make... OH! Hello, I'm #b#p1052104##k the alchemist. For years I have studied the art of scroll enchantment under the great wizard #b#p1032001##k. If you're in need of a scroll to enchant your armor, I can make just what you're looking for! What do you think? Want to see what I can do?");
		
		if (!askStart)
		{
			self.say("Alright, I understand. Your gear must already be enchanted. Well, if you're ever in need of a scroll, please come back and talk to me.");
			return;
		}
		
		int craftType = AskMenu("Alright! With a #bBlank Scroll#k and some other ingredients, I can make an enchanted scroll. What can I do for you?#b",
			(0, " What is a Blank Scroll?"),
			(1, " Remove the enchantment from a scroll\r\n"),
			(2, " Create a scroll for tops"),
			(3, " Create a scroll for bottoms"),
			(4, " Create a scroll for gloves"),
			(5, " Create a scroll for capes"),
			(6, " Create a scroll for pet equips"),
			(7, " Create a scroll for two-handed weapons"));
		
		if (craftType == 0)
		{
			self.say("A #bBlank Scroll#k is exactly what it sounds like: a blank slate onto which I can imbue magical enchantments. It's like an empty canvas, there are infinite possibilities. But the power of the enchantment will depend on the type of Blank Scroll I use.");
			self.say("For example, a #bLevel 1#k scroll can only contain enough magic for small enchantments, but the scroll that comes out of it will have a 100% chance of success. On the other hand, a \r\n#bLevel 3#k scroll will contain a very powerful enchantment, but the chance of success will be very slim.");
			self.say("Blank Scrolls can be obtained in a number of ways. #bLevel 1#k scrolls can be purchased from potion shops in each town. You might find them from monsters every now and then. Ah yes, if you happen to have an enchanted scroll on you, I can strip it of its enchantment. A word of warning, though: the stronger the scroll, #rthe higher the chance it will be destroyed in the process#k, so be careful! That is all the information I have for you. If you find a blank scroll, bring it to me!");
		}
		else if (craftType == 1)
		{
			int scrollLevel = AskMenu("So you want me to strip a scroll of its enchantment? What level of enchantment is on the scroll?#b",
				(0, " Level 1"),
				(1, " Level 2"));
			
			if (scrollLevel == 0)
			{
				int[] possibleScrolls = {2040000, 2040003, 2040018, 2040300, 2040312, 2040400, 2040414, 2040500, 2040503, 2040512, 2040515, 2040600, 2040614, 2040623, 2040700, 2040703, 2040706, 2040800, 2040803, 2040900, 2040923, 2040926, 2040929, 2041000, 2041003, 2041006, 2041009, 2041012, 2041015, 2041018, 2041021, 2043000, 2043100, 2043200, 2043300, 2043700, 2043800, 2040818, 2044000, 2044100, 2044200, 2044300, 2044400, 2044500, 2044600, 2044700, 2048000, 2048003};
				
				RemoveEnchant(1, 10000, 4132000, 10, possibleScrolls);
			}
			else if (scrollLevel == 1)
			{
				int[] possibleScrolls = {2040001, 2040004, 2040017, 2040301, 2040311, 2040401, 2040413, 2040501, 2040504, 2040513, 2040516, 2040601, 2040613, 2040625, 2040701, 2040704, 2040707, 2040801, 2040804, 2040817, 2040901, 2040924, 2040927, 2040931, 2041001, 2041004, 2041007, 2041010, 2041013, 2041016, 2041019, 2041022, 2043001, 2043101, 2043201, 2043301, 2043701, 2043801, 2044001, 2044101, 2044201, 2044301, 2044401, 2044501, 2044601, 2044701, 2048001, 2048004};
				
				RemoveEnchant(2, 120000, 4132001, 20, possibleScrolls);
			}
		}
		else if (craftType == 2)
		{
			int scrollLevel = AskMenu("So you want to make a scroll that can be used to enchant a top? Okay! How strong will the enchantment be?#b",
				(0, " Level 1"),
				(1, " Level 2"));
			
			if (scrollLevel == 0)
			{
				int[] possibleScrolls = {2040400, 2040414};
				
				CraftScroll(1, "Level 1", "Scroll for Topwear", "#v4132000# #t4132000#\r\n#v4000016# 45 #t4000016#s\r\n#v2000000# 20 #t2000000#s\r\n10,000 mesos", possibleScrolls);
			}
			else if (scrollLevel == 1)
			{
				int[] possibleScrolls = {2040401, 2040413};
				
				CraftScroll(2, "Level 2", "Scroll for Topwear", "#v4132001# #t4132001#\r\n#v4000023# 240 #t4000023#\r\n#v2000001# 60 #t2000001#s\r\n80,000 mesos", possibleScrolls);
			}
		}
		else if (craftType == 3)
		{
			int scrollLevel = AskMenu("So you want to make a scroll that can be used to enchant a pair of pants? Okay! How strong do you want the enchantment to be?#b",
				(0, " Level 1"),
				(1, " Level 2"));
			
			if (scrollLevel == 0)
			{
				int[] possibleScrolls = {2040600, 2040614, 2040623};
				
				CraftScroll(100, "Level 1", "Scroll for Bottomwear", "#v4132000# #t4132000#\r\n#v4000000# 45 #t4000000#s\r\n#v2000003# 10 #t2000003#s\r\n10,000 mesos", possibleScrolls);
			}
			else if (scrollLevel == 1)
			{
				int[] possibleScrolls = {2040601, 2040613, 2040625};
				
				CraftScroll(101, "Level 2", "Scroll for Bottomwear", "#v4132001# #t4132001#\r\n#v4000013# 240 #t4000013#s\r\n#v2000006# 30 #t2000006#s\r\n80,000 mesos", possibleScrolls);
			}
		}
		else if (craftType == 4)
		{
			int scrollLevel = AskMenu("So you want to make a scroll that can be used to enchant a pair of gloves? Okay! How strong will the enchantment be?#b",
				(0, " Level 1"),
				(1, " Level 2"));
			
			if (scrollLevel == 0)
			{
				int[] possibleScrolls = {2040800, 2040803, 2040818};
				
				CraftScroll(200, "Level 1", "Scroll for Gloves", "#v4132000# #t4132000#\r\n#v4000006# 40 #t4000006#s\r\n#v2000000# 30 #t2000000#s\r\n10,000 mesos", possibleScrolls);
			}
			else if (scrollLevel == 1)
			{
				int[] possibleScrolls = {2040801, 2040804, 2040817};
				
				CraftScroll(201, "Level 2", "Scroll for Gloves", "#v4132001# #t4132001#\r\n#v4000030# 60 #t4000030#s\r\n#v2012002# 15 #t2012002#s\r\n80,000 mesos", possibleScrolls);
			}
		}
		else if (craftType == 5)
		{
			int scrollLevel = AskMenu("So you want to make a scroll that can be used to enchant a cape? Okay! How strong will the enchantment be?#b",
				(0, " Level 1"),
				(1, " Level 2"));
			
			if (scrollLevel == 0)
			{
				int[] possibleScrolls = {2041000, 2041003, 2041006, 2041009, 2041012, 2041015, 2041018, 2041021};
				
				CraftScroll(300, "Level 1", "Scroll for Cape", "#v4132000# #t4132000#\r\n#v4000002# 50 #t4000002#s\r\n#v2000000# 20 #t2000000#s\r\n10,000 mesos", possibleScrolls);
			}
			else if (scrollLevel == 1)
			{
				int[] possibleScrolls = {2041001, 2041004, 2041007, 2041010, 2041013, 2041016, 2041019, 2041022};
				
				CraftScroll(301, "Level 2", "Scroll for Cape", "#v4132001# #t4132001#\r\n#v4000033# 200 #t4000033#s\r\n#v2000006# 50 #t2000006#s\r\n80,000 mesos", possibleScrolls);
			}
		}
		else if (craftType == 6)
		{
			int scrollLevel = AskMenu("So you want to make a scroll that can be used to enchant a pet equip? Okay! How strong will the enchantment be?#b",
				(0, " Level 1"),
				(1, " Level 2"));
			
			if (scrollLevel == 0)
			{
				int[] possibleScrolls = {2048000, 2048003};
				
				CraftScroll(400, "Level 1", "Scroll for Pet Equip", "#v4132000# #t4132000#\r\n#v4000037# 15 #t4000037#s\r\n#v2120000# 10 #t2120000#s\r\n10,000 mesos", possibleScrolls);
			}
			else if (scrollLevel == 1)
			{
				int[] possibleScrolls = {2048001, 2048004};
				
				CraftScroll(401, "Level 2", "Scroll for Pet Equip", "#v4132001# #t4132001#\r\n#v4000026# 30 #t4000026#s\r\n#v2022000# 10 #t2022000#s\r\n50,000 mesos", possibleScrolls);
			}
		}
		else if (craftType == 7)
		{
			int scrollLevel = AskMenu("So you want to make a scroll that can be used to enchant a two-handed weapon? The scroll that I make for you will work on #bTwo-Handed Sword#k, #bTwo-Handed Axe#k, #bTwo-Handed Blunt Weapon#k, #bSpear#k, #bPolearm#k, #bBow#k, #bCrossbow#k and #bClaw#k. Okay! How strong will the enchantment be?#b",
				(0, " Level 1"),
				(1, " Level 2"));
			
			if (scrollLevel == 0)
			{
				int[] possibleScrolls = {2044000, 2044100, 2044200, 2044300, 2044400, 2044500, 2044600, 2044700};
				
				CraftScroll(500, "Level 1", "Scroll for Two-Handed Weapons", "#v4132000# #t4132000#\r\n#v4000008# 45 #t4000008#s\r\n#v2000001# 15 #t2000001#s\r\n30,000 mesos", possibleScrolls);
			}
			else if (scrollLevel == 1)
			{
				int[] possibleScrolls = {2044001, 2044101, 2044201, 2044301, 2044401, 2044501, 2044601, 2044701};
				
				CraftScroll(501, "Level 2", "Scroll for Two-Handed Weapons", "#v4132001# #t4132001#\r\n#v4000025# 200 #t4000025#s\r\n#v2012002# 15 #t2012002#s\r\n120,000 mesos", possibleScrolls);
			}
		}
	}
}