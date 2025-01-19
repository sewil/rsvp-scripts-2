using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1004800);
		string quest2 = GetQuestData(1004801);
		
		if (Level < 20)
		{
			self.say("We are lacking man power. We should get some help from the travelers arriving from out of town...");
			return;
		}
		
		if (quest == "")
		{
			bool start = AskYesNo("Hey, there. I'm #b#p1012106##k. Why am I pacing around like this? The Carnival is coming up really soon, and I need to prepare for a lot of things, but one thing I'm lacking is a helping hand. Can you help me out?");
			
			if (!start)
			{
				self.say("I thought you were going to help. If you feel like changing your mind, though, then please come see me. I need as much help as I can get!");
				return;
			}
			
			SetQuestData(1004800, "s");
			self.say("Carnival is all about being extravagant and fancy, but the town is seriously lacking flashy materials to decorate with. Thankfully the monsters drop some items that are. As you can see, however, I'm no good in terms of hunting.");
			self.say("Can you help me gather up #b50 #t4000037#s, 20 #t4000010#s, and 100 #t4000002#s#k?? The bubblings and the ribbons are the perfect decorations, you know. I'll be here waiting for you. Good luck!!");
		}
		else if (quest == "s")
		{
			if (ItemCount(4000002) < 100 || ItemCount(4000010) < 20 || ItemCount(4000037) < 50)
			{
				self.say("I don't think you have gathered up all the items I asked you to get. To decorate the town for the Carnival, I'll need #b50 of \r\n#t4000037#s, 50 of #t4000010#s, and 100 #t4000002#s#k. Please get them for me quickly!");
				return;
			}
			
			self.say("Oh wow, you got them all!!! This is plenty enough for me to decorate the town! Thank you so much for your help! The job isn't done, however, and I may need your help again soon, so if you have time, then please come see me.");
			
			if (!Exchange(0, 4000002, -100, 4000037, -50, 4000010, -20))
			{
				self.say("Oh! Are you sure you brought #b50 #t4000037#s, 50 #t4000010#s, and 100 #t4000002#s#k?");
				return;
			}
			
			AddEXP(1000);
			SetQuestData(1004800, "e");
			QuestEndEffect();
		}
		else if (quest == "e")
		{
			if (Level < 21)
			{
				self.say("We are lacking man power. We should get some help from the travelers arriving from out of town...");
				return;
			}
			
			if (quest2 == "")
			{
				bool start2 = AskYesNo("Hey, you're back! I'm putting the materials you got me last time to good use. The town is ready for the Carnival that's coming up really soon. Unfortunately, there's another problem at hand. Do you want to hear me out?");
			
				if (!start2)
				{
					self.say("I thought you were going to help. If you feel like changing your mind, though, then please come see me. I need as much help as I can get!");
					return;
				}
				
				SetQuestData(1004801, "m1");
				self.say("I can't thank you enough for saying yes. Decorating the town for the Carnival is important, but it's much more important to offer the tourists some food, you know? The problem is that we've run out of the materials for the big feast.");
				self.say("Can you please get me #b20 #t4000017#s, 60 Octopus Legs, and 1 #t4031154##k? You can find #t4031154# through #b#p1032105##k , who should be around Ellinia... Good luck!!!");
			}
			else if (quest2 == "m1" || quest2 == "m2")
			{
				self.say("I need lots of materials for the big feast at the Carnival. Can you please get me #b20 #t4000017#s, 60 #t4000006#s, and 1 #t4031154##k? You can find #t4031154# through #b#p1032105##k, who should be around Ellinia... Good luck!!!");
			}
			else if (quest2 == "m3")
			{
				if (ItemCount(4000006) < 60 || ItemCount(4000017) < 20 || ItemCount(4031154) < 1)
				{
					self.say("I need the ingredients for the food during the festival. Can you please get #b20 #t4000017#, 60 #t4000006#, #t4031154#? You can ask #b#p1032105##k in Ellinia for #t4031154#.");
					return;
				}
				
				self.say("You're back! How was it? Whew... I was so busy preparing all this food. Let's see ... you do have #b20 #t4000017#s, 60 \r\n#t4000006#s, and #t4031154##k. Great! I knew you could do it.");
				
				if (!Exchange(0, 4000017, -20, 4000006, -60, 4031154, -1, 1002441, 1))
				{
					self.say("Oh! Please be sure to leave an empty space in your equipment inventory...");
					return;
				}
				
				AddEXP(1200);
				SetQuestData(1004801, "e");
				QuestEndEffect();
				self.say("Thanks for helping me. Now, I got all the decorations and ingredients. This one will be great~! Thank you so much. Bye~");
			}
			else if (quest2 == "e")
			{
				self.say("Thanks for your hard work. Now we can prepare for the festival.");
			}
		}
	}
}