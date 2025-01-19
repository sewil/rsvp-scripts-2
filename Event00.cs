using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string ask = "";
			
		if (MapID == 60000)
		{
			self.say("Hey, I'm #b#p9000000##k, if you're not busy right now ... Then, can I hang with you? I heard that people are gathering around here for an #revent#k, but I don't want to go alone... Well, do you want to go there with me to have a look?");
			
			ask = "Huh? What kind of event? Well, it's... ";
		}
		else if (MapID == 104000000)
		{
			self.say("Hey, I'm #b#p9000001##k. I'm here waiting for my brother #bPaul#k. He should be here by now...");
			self.say("Hmm... What should I do? The event will start soon... Many people arrived to participate in the event, so we better hurry...");
			
			ask = "Hey... Why don't you go with me? I think my brother will come with other people.";
		}
		else if (MapID == 200000000)
		{
			self.say("Hey, I'm #b#p9000011##k. I'm here waiting for my brothers... Why are they taking so long? I'm pretty upset here... If we don't get there in time, we won't be able to participate in the event...");
			self.say("Hmm... What should I do? The event will start soon... Many people arrived to participate in the event, so we better hurry...");
			
			ask = "Hey... Why don't you come with me then?";
		}
		else if (MapID == 220000000)
		{
			self.say("Hey, I'm #b#p9000013##k. Right now I'm waiting for my brothers, but they haven't arrived yet. I'm sick and tired of doing things on my own. At least during the event I don't feel so alone, with so many people around and all. All events can only take a limited number of people, so if I don't get there soon, I won't be able to participate.");
			self.say("We might be bros and all, but we keep missing each other. Dude, what should I do? The event should start any minute... A lot of people must be waiting there and there won't be any space for them...");
			
			ask = "What do you think? Do you want to join me and go to the event?";
		}
		
		int askEvent = AskMenu(ask,
			(0, " #e1. #n#bWhat kind of an event is it?#k"),
			(1, " #e2. #n#bExplain the event game to me.#k"),
			(2, " #e3. #n#bAlright, let's go!#k"));
		
		if (askEvent == 0)
		{
			self.say("I haven't heard much from the GMs yet about the next Event, but when I do hear from them, I will make sure to tell you!");
		}
		else if (askEvent == 1)
		{
			int eventHelp = AskMenu("There'll be many games for this event. This will teach you how to play the game before you start it. Choose the event of which you want more information.#b",
				(0, " Ola Ola"),
				(1, " MapleStory Physical Fitness Test"),
				(2, " Snowball"),
				(3, " Coconut Harvest"),
				(4, " OX Quiz"),
				(5, " Treasure Hunt"),
				(6, " Toy Castle Climb"),
				(7, " Alien Hunt"));
			
			if (eventHelp == 0)
			{
				self.say("#b[Ola Ola]#k is a game where participants climb ladders to reach the top. Climb your way up and move to the next level by choosing the correct portal out of the numerous portals available.\r\n\r\nThe game consists of three levels, and the time limit is #b6 MINUTES#k. During [Ola Ola], you #bwon't be able to jump, teleport, haste, or boost your speed using potions or items#k.\nThere are also trick portals that'll lead you to a strange place, so please be aware of those.");
			}
			else if (eventHelp == 1)
			{
				self.say("#b[MapleStory Physical Fitness Test] is a race through an obstacle course#k much like the Forest of Patience. You can win by overcoming various obstacles and reaching the final destination within the time limit.\r\n\r\nThe game consists of four levels, and the time limit is #b15 MINUTES#k. During the [MapleStory Physical Fitness Test], you will not be able to use teleport or haste.");
			}
			else if (eventHelp == 2)
			{
				self.say("#b[Snowball]#k consists of two teams, Maple Team and Story Team, and the two teams duke it out to see #bwhich team rolled the snowball further and bigger in a limited time#k. If the game cannot be decided within the time period, then the team that rolled the snowball further wins.\r\n\r\nTo roll up the snow, attack it by pressing Ctrl. All long-range attacks and skill-based attack will not work here; #bonly the close-range attacks will#k.\r\n\r\nIf a character touches the snowball, he/she'll be sent back to the starting point. Attack the snowman in front of the starting point to prevent the opposing team from rolling the snow forward. This is where a well-planned strategy works, as the team will decide whether to attack the snowball or the snowman.");
			}
			else if (eventHelp == 3)
			{
				self.say("#b[Coconut Harvest]#k consists of two teams, Maple Team and Story Team. The two teams compete to see #bwhich of them can collect more coconuts#k. The time limit is #b5 MINUTES#k. If the game ends in a draw, then 2 minutes of extra time will be given to determine the winner. If the game ends in a draw after 2 minutes of extra time, the game will just end as a draw.\r\n\r\nAll long-range attacks and skill-based attack will not work here; #bonly the close-range attacks will#k. If you don't have a close-range weapon, you can purchase one from the NPC in the event map. Regardless of the level of the character, the weapon or skill, all damage will be the same.\r\n\r\nThere are many traps & obstacles all over the map. If you run out of HP, you are going to be left out of the game. The character that attacks last before the coconut falls will score the point. Only the coconuts that fall down will count. However, coconuts that never fall or just break now and then WILL NOT COUNT. There are also hidden portals on the wreath shell, so please use them wisely!");
			}
			else if (eventHelp == 4)
			{
				self.say("#b[OX Quiz]#k is a MapleStory game using Xs and Os. Once you join the game, turn on the minimap by pressing M to see where the X and O are. A total of #r10 questions#k will be given, and the character that answers them all correctly wins the game.\r\n\r\nOnce the question is given, use the ladder to enter the area where the correct answer may be, be it X or O. If the character does not choose an answer or is hanging on the ladder past the time limit, the character will be eliminated. Hold your position until [CORRECT] is off the screen before moving on. To prevent cheating of any kind, all types of chatting will be turned off during the OX quiz.");
			}
			else if (eventHelp == 5)
			{
				self.say("#b[Treasure Hunt]#k is a game in which your goal is to find, in 10 minutes, the #bTreasury Maps#k that are hidden in every map. There will be a number of mysterious hidden treasure chests and once you break them, many items will emerge from the chest. Your job is to separate the treasury scroll from these items.\r\n\r\nTreasure Chests can be destroyed using #bregular attacks#k, and when you have the treasury scroll, you can exchange it for the Scroll of Secrets through an NPC who is in charge of exchanging items. The NPC who exchanges items can be found at the Treasure Hunt map, but you can also exchange your scroll through #b[Vikin]#k in Lith Harbor.\r\n\r\nThis game has hidden portals, and hidden teleports. To use them, press the #bup arrow#k at a certain location and you will be teleported to a different place. Try jumping around, you can also reach hidden stairs and ropes. There will also be a treasure chest that will take you to a hidden location, and a secret chest that can only be found through the secret portal. So search all around you.\r\n\r\nDuring the Treasure Hunt game, all attack skills will be#r disabled#k, so please break the chests with a regular attack.");
			}
			else if (eventHelp == 6)
			{
				self.say("#b[Toy Castle Climb]#k is a race up a tower in Ludibrium#k. You can win by overcoming various obstacles and reaching the final destination within the time limit.\r\n\r\nThe game consists of an outdoor and an indoor section, you will have to move between them to reach the end. The trick is to find the fastest route!\r\nThe time limit is #b10 minutes#k but when half of the players in the event enter the portal at the top, the remaining players will have only #b1 MINUTE#k to reach the goal. During [Toy Castle Climb], you will not be able to use teleport or haste.");
			}
			else if (eventHelp == 7)
			{
				self.say("#b[Alien Hunt]#k consists of two teams, Matian Team and Gray Team. The two teams compete to see #bwhich of them can eliminate the most aliens#k. The time limit is #b5 MINUTES#k. If the game ends in a draw, then 2 minutes of extra time will be given to determine the winner. If the game ends in a draw after 2 minutes of extra time, the game will just end as a draw.\r\n\r\nDuring Alien Hunt you cannot use any attack skills to fight aliens, #bonly normal attacks will work#k. Players on the Matian Team will fight Matian while players on Gray Team will hunt Grays. You won't be able to attack the monsters that the other team is hunting to give them points. Some areas in the battlefield are seemingly inaccessible, but if you search around you may find hidden portals, so keep your eyes open!");
			}
		}
		else if (askEvent == 2)
		{
			string lastDate = GetQuestData(9000001);
			string today = DateTime.UtcNow.ToString("yyyyMMdd");
			
			string map = GetNpcVar(180000000, 9900000, "map", "-1");
			
			if (lastDate == today || ItemCount(4031019) >= 1 || map == "-1")
			{
				self.say("Either the event hasn't started yet, you already have #t4031019#, or you've participated in an event in the last 24 hours. Please try again later!");
				return;
			}
			
			if (!Exchange(0, 4000038, 1))
			{
				self.say("Do you have a free slot in your etc. inventory? Check again!");
				return;
			}
			
			if (MapID == 60000) SetQuestData(9000000, "maple");
			else if (MapID == 104000000) SetQuestData(9000000, "victoria");
			else if (MapID == 200000000) SetQuestData(9000000, "ossyria");
			else if (MapID == 220000000) SetQuestData(9000000, "ludi");
			
			//SetQuestData(9000001, DateTime.UtcNow.ToString("yyyyMMdd"));
			ChangeMap(Int32.Parse(map));
		}
	}
}