using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void PatchNotes()
	{
		var patchnotes = @"Happy Valentine's Day from the MG2 team!
In v0.9 you can expect to find the following changes:

#e[Game]#n
The #bGuild System#k has been implemented. With a party of 6 people and 1,500,000 mesos, you'll be able to form your own guild at Orbis Guild Park!


#e[Event]#n
To celebrate #bLunar New Year#k, from today until February 18th, you can talk to the Maple Administrator to participate in a special quest.

From February 14th until the 23rd, #bValentine's Day#k chocolates can be made through Ace of Hearts found in Ellinia and Orbis. Combine items dropped by monsters and materials sold by Ace of Hearts to make something special for that special someone~!


#e[Maps]#n
New maps have been added around Orbis:
- Orbis Guild Park

You can now travel to Florina Beach from Ossyria by speaking with #bShuri#k in Orbis.

Objects like boxes and tree branches can now be found all around the game. These will occasionally drop useful items like mesos and potions.


#e[NPC]#n
New NPCs have appeared on Maple Island:
- Todd in Mushroom Town

New NPCs have appeared on Victoria Island:
- Olaf in Lith Harbor
- Mrs. Ming Ming, Anne, Camila and Utah in Henesys
- Wing the Fairy, Estelle and Dr. Betty in Ellinia
- Winston in Perion
- Icarus and Jane Doe in Kerning City

New NPCs have appeared in Ossyria:
- Shuri in Orbis
- Heracle at Guild Headquarters


#e[Quest]#n
New quests on Maple Island:
- NPC Todd: Todd's How-to-Hunt
- NPC Pio: Pio's Collecting Recycled Goods
- NPC Rain: Rain's Maple Quiz
- NPC Mai: Mai's Training

New quests on Victoria Island:
- None, NPC Olaf: A Lesson on Job Advancement
- Lv #b10#k, NPC Wing: I Need Help on My Homework!
- Lv #b10#k, NPC Icarus: I'm Bored
- Lv #b20#k, NPC Winston: Winston's Fossil Dig-up
- Lv #b20#k, NPC Mrs. Ming Ming: Mrs. Ming Ming's First Worry
- Lv #b21#k, NPC Mrs. Ming Ming: Mrs. Ming Ming's Second Worry
- Lv #b22#k, NPC Betty: Dr. Betty's Research on Fossils
- Lv #b23#k, NPC Betty: Progress on Fossil Research
- Lv #b23#k, NPC Camila: Camila's Gem
- Lv #b25#k, NPC Jane Doe: Mystery of Niora Hospital
- Lv #b32#k, NPC Icarus: Icarus's Hang Glider
- Lv #b35#k, NPC Riel: Special Taste of Florina Beach
- Lv #b37#k, NPC Icarus: Icarus's and the Balloon
- Lv #b42#k, NPC Icarus: Icarus's and the Flying Pill


#e[Improvements]#n
An effect will play when a quest is completed.


#e[Cash Shop]#n
New hairstyles can be found at each salon.

New items have been added.


#e[Bugfixes]#n
Some item descriptions have been corrected.

An issue preventing players from entering the new Internet Cafe map 'Chilly Field' has been resolved.


Happy Mapling!";

		self.say(patchnotes.Split("\n"));

	}
	
	private void Event()
	{
		string quest = GetQuestData(9000500, "");
		
		if (Level < 10)
		{
			self.say("Happy New Year~! I have something to ask of you... but you should come back when you're at least #blevel 10#k.");
			return;
		}
		
		if (quest == "")
		{
			self.say($"Hey {chr.Name}~! How are you doing? The Lunar New Year took place on February 12th. Have you been celebrating~? Well, if you have some free time I could really use your help.");
			bool start = AskYesNo("The four chiefs around Victoria Island are always working hard, giving their strength to their new apprentices. They're so busy, they probably haven't had any time to celebrate Lunar New Year. So I want you to give each of them a New Year's greeting for me. What do you think?");
			
			if (!start)
			{
				self.say("You must be busy. Well, if you have some free time down the line, I think the four chiefs would really appreciate it.");
				return;
			}
			
			SetQuestData(9000500, "s");
			self.say("Great! Please deliver a New Year's greeting to #b#p1022000##k, #b#p1032001##k, #b#p1012100##k and #b#p1052001##k in that order. You'll have to meet with #p1022000# first.");
		}
		else if (quest == "4")
		{
			if (ItemCount(3993003) < 1)
			{
				self.say("I don't think you've met the four chiefs of Victoria Island. Please talk to #b#p1022000##k, #b#p1032001##k, #b#p1012100##k and #b#p1052001##k in order and then return to me!");
				return;
			}
			
			self.say("Oh~ you did wish all four chiefs a Happy New Year! I'm sure they were happy to see a kind young traveler like you. This must be a present from #b#p1052001##k for visiting all 4 wisemen!");
			self.say("Thank you for sending your greetings, now I need you to help me with one more thing...");
			
			SetQuestData(9000500, "5");
			self.say("While you were visiting the elders, some monsters came and took all of our #b#t3993002#s#k. Can you go take down some monsters and bring back #b5 #t3993002#s#k? I'll be waiting here for you!");
		}
		else if (quest == "5")
		{
			if (ItemCount(3993003) < 1 || ItemCount(3993002) < 5)
			{
				self.say("I don't think you have everything. Please gather #b5 #t3993002#s#k from monsters and return with the #b#t3993003##k that #b#p1052001##k gave you!");
				return;
			}
			
			self.say("Oh~ You brought them all! Thanks for all your help. Please hold out your hands, I have a present for you!");
			
			if (!Exchange(800, 3993003, -1, 3993002, -5, 2022006, 20))
			{
				self.say("It looks like you don't have room to take my present. Please talk to me again when you have an empty space in your use inventory.");
				return;
			}
			
			AddEXP(450);
			StartWeather(2090006, 15);
			SetQuestData(9000500, "e");
			QuestEndEffect();
			self.say($"Here you go, #b20 #b#t2022006#s#k. Happy New Year {chr.Name}~!");
		}
		else if (quest == "e")
		{
			self.say($"Happy New Year {chr.Name}~!");
		}
		else
		{
			self.say("I don't think you've met the four chiefs of Victoria Island. Please talk to #b#p1022000##k, #b#p1032001##k, #b#p1012100##k and #b#p1052001##k in order and then return to me!");
		}
	}
	
	public override void Run()
	{
		DateTime today = DateTime.UtcNow;
			
		DateTime start = DateTime.Parse("2021-02-13");
		DateTime end = DateTime.Parse("2021-02-18");
		
		if (today > start && today < end)
		{
			AskMenuCallback("Hi, welcome to MG2!#b",
				(" Visiting the Elders!", Event),
				(" What's new in this version?", PatchNotes));
		}
		else
		{
			PatchNotes();
		}
	}
}