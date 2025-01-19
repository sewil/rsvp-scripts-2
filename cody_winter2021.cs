using System;
using System.Collections.Generic;
using WvsBeta.Game;
using WvsBeta.Common;

// 9200000 Cody
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (DateTime.UtcNow < DateTime.Parse("2021-12-24"))
		{
			self.say("What's going on? I'm Cody, the head programmer of MapleStory~");
			return;
		}
		
		if (DateTime.UtcNow >= DateTime.Parse("2022-01-09"))
		{
			self.say("What's going on? I'm Cody. Did you have a good New Years? Talk to me in a little bit, I might ask for your help again.");
			return;
		}
		
		string quest = GetQuestData(8020032);
		
		if (quest == "")
		{
			self.say($"Hey {chr.Name}~ how's it going? Are you making the most of the holiday season? Huh, me? I'm just taking a break from work to celebrate!");
			bool start = AskYesNo("Actually, I'm having some guests over soon and I need something to give my place a little more holiday cheer... do you want to help me out?");
			
			if (!start)
			{
				self.say("I understand. Well, if you're ever in the neighborhood, just stop by. Happy holidays~!");
				return;
			}
			
			SetQuestData(8020032, "s");
			self.say("Awesome~! You really do understand the spirit of the holidays. Alright, here's what I'll need: #bA wreath to hang on my door#k, #ba menorah for holding candles#k, #ba christmas tree star to put atop my tree#k and #ba pie I can share with\r\nmy guests#k.");
			self.say("As for where to get them... I'm not sure. Why don't you try #btalking to the nice folks around Happyville and Shalom Temple#k?");
		}
		else if (quest == "s")
		{
			if (ItemCount(3992025) < 1 || ItemCount(3995000) < 1 || ItemCount(3995001) < 1 || ItemCount(2022123) < 1)
			{
				self.say("I don't think you've found everything I'm looking for just yet. I need #bA wreath to hang on my door#k, #ba menorah for holding candles#k, #ba christmas tree star to put atop my tree#k and #ba pie I can share with my guests#k. I'm not sure where to find them, but maybe someone around #bHappyville#k or #bShalom Temple#k might know. Good luck!");
				return;
			}
			
			self.say("Wow!! You really brought everything... that's amazing! Okay, for being such a giving person I would like to give you something in return.");
			
			if (!Exchange(0, 3992025, -1, 3995000, -1, 3995001, -1, 2022123, -1, 1332032, 1))
			{
				self.say("Please leave a slot available in your equip. inventory so I can reward you!");
				return;
			}
			
			AddFame(3);
			SetQuestData(8020032, "e");
			QuestEndEffect();
			self.say("Do you like it? I had one of these laying around and I thought you might be able to find a use for it. Thanks again for your help, happy holidays!");
		}
		else if (quest == "e")
		{
			self.say("Hey, it's you! Thanks again for helping me out the other day. I hope you have a wonderful holiday season!");
		}
	}
}