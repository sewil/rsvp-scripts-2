using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(500);
		
		if (quest == "")
		{
			bool start = AskYesNo("Hey you! You're new around here, right? Umm... do you want to learn more about monsters?");
			
			if (!start)
			{
				self.say("Oh... I guess you're busy... If you change your mind, I can tell you a lot about the monsters around here.");
				return;
			}
			
			SetQuestData(500, "s1");
			self.say("You can learn a lot about a monster by hunting it, but did you know you can also find #bMonster Cards#k containing all kinds of information about them?");
			self.say("Monsters have strengths and weaknesses just like you and me. Some are weak to physical attacks and some are only weak against certain elemental attacks. #bSlimes#k for example will definitely be weak against a wizard who uses #blightning spells#k.");
			self.say("I really like collecting monster cards and learning more about the monsters here on Maple Island. Hey, why don't you try hunting for one? The weakest monster around here is the #bGreen Snail#k. Take some down and I'm sure you'll find one in no time!");
		}
		else if (quest == "s1")
		{
			self.say("Umm.... did you find a Monster Card? #b#t4031144##k looks like a red card with a picture of a Snail on it. It can be found by hunting #bSnails#k...");
		}
		else if (quest == "s2")
		{
			self.say("Woah... cool!! You found your very own Monster Card, you're a natural at this. You can check out your Monster Book by pressing #bB#k. Anytime you find a card you'll unlock new information in your book about the monster on it.");
			self.say("Umm... thanks for talking about monsters with me. I have something I want to give you.");
			
			Random rnd = new Random();
			int[] cards = {2380001, 2380002, 2380004, 2380007};
			
			int card = cards[rnd.Next(cards.Length)];
			
			AddEXP(25);
			GiveMonsterBookCard(card);
			SetQuestData(500, "end");
			QuestEndEffect();
			
			self.say($"Here, please have this #b#t{card}##k, it's a rare card that I found the other day. It's one of my favorites, so please take good care of it.");
			
			if (card == 2380001) self.say("#bBlue Snails#k are a lot like Snails, but are a little bit stronger, you're bound to see them all over Maple Island!");
			else if (card == 2380002) self.say("#bShrooms#k are agile but they're mostly harmless. Don't let them cover you with their nasty spores though...");
			else if (card == 2380004) self.say("#bRed Snail#k looks a lot like the Blue Snail, but don't underestimate them, they are very strong!");
			else if (card == 2380007) self.say("#bMushrooms#k are the strongest monster here on Maple Island. They don't have great defense but they'll still be tough for any traveler who doesn't have a lot of #bstrength#k.");
			
			self.say("Keep collecting cards and one day you'll have an even bigger collection than me. Well, I'll see you around, bye..!");
		}
		else if (quest == "end")
		{
			self.say("Have you found any new cards since last time?");
		}
	}
}