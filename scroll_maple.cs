using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(600);
		
		if (quest == "")
		{
			self.say("Hmm... by mixing these spores with snail shells, I can \r\nmake... OH! Hello, I am #b#p2105##k the alchemist.");
			bool start = AskYesNo("You're a new traveler, right? If you have some time, please allow me to impart some knowledge onto you.");
			
			if (!start)
			{
				self.say("Hmm... you must be very busy, but don't pass up the opportunity to learn more about the world around you. Come and see me if you change your mind.");
				return;
			}
			
			if (!Exchange(0, 4031145, 1))
			{
				self.say("Please leave one slot available in your etc. inventory.");
				return;
			}
			
			SetQuestData(600, "s");
			self.say("For years I studied the art of scroll enchantment under the great wizard #b#p1032001##k. Enchanted scrolls can be used to#b enhance the abilities of weapons and other equipment#k so, as you can imagine, they are highly sought after. Creating them is no simple task, though.");
			self.say("What I just handed you is called a #bBlank Scroll#k. On its own it has little value, but in the hands of an enchanter like myself, it can be imbued with powerful spells.");
			self.say("I can enchant the Blank Scroll for you, but I'll need you to bring #b15 Snail Shells#k and #b10 Mushroom Spores#k first. Talk to me when you've found them and I'll run you through the other details.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031145) < 1)
			{
				self.say("Hmm... did you lose the Blank Scroll I gave you? Please be more careful with this one.");
				
				if (!Exchange(0, 4031145, 1))
				{
					self.say("Please leave one slot available in your etc. inventory.");
				}
				
				return;
			}
			
			bool trade = AskYesNo("To enchant the blank scroll, I'll need the following ingredients. This recipe will produce a #bScroll for Defense#k. What do you think? Do you want me to make it?\r\n\r\n#b#v4031145# #t4031145#\r\n#v4000019# 15 #t4000019#s\r\n#v4000011# 10 #t4000011#s#k");
			
			if (!trade)
			{
				self.say("I understand. There is always a risk involved when enchanting a scroll. If you change your mind please come back and talk to me!");
				return;
			}
			
			if (SlotCount(2) < 1)
			{
				self.say("Hmm... it looks like your use inventory is full. Please leave an available slot and talk to me again.");
				return;
			}
			
			var rnd = new Random();
			int[] scrolls = {2040050, 2040450, 2040650};
			
			int itemID = scrolls[rnd.Next(scrolls.Length)];
			
			if (!Exchange(0, 4031145, -1, 4000019, -15, 4000011, -10, itemID, 1))
			{
				self.say("Hmm... are you sure you have all the necessary ingredients? I won't be able to enchant the scroll without them.");
				return;
			}
			
			SetQuestData(600, "end");
			QuestEndEffect();
			self.say($"Hahhhh!! Alright, it is done. Using the recipe I was able to make a #b#t{itemID}##k. To use the scroll, simply open Item and Equipment inventories. Drag the scroll from the Use tab onto the corresponding piece of equipment to enchant it. I hope this will help you out on your journey. Until we meet again!");
		}
		else if (quest == "end")
		{
			self.say("Hello, have you made use of the scroll that I made for you?");
		}
	}
}