using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void GoTown(int mapNum, int fee)
	{
		bool askTravel = AskYesNo($"I guess you don't need to be here. Do you really want to go to #b#m{mapNum}##k? Well, It'll cost you #b{fee:n0} mesos#k. What do you think?");
						
		if (!askTravel)
		{
			self.say("There's a lot to see in this town, too. Let me know if you want to go somewhere else.");
			return;
		}
		
		if (!Exchange(-fee))
		{
			self.say("You don't have enough mesos. With your skills, you should have more than that!");
			return;
		}
		
		ChangeMap(mapNum);
	}
	
	public override void Run()
	{
		self.say("Do you want to travel to another town? I can take you for a little money. It's a little expensive, but I give a special 90% discount for beginners.");
		
		int askStart = AskMenu("It makes sense that you'd be confused about where to go if you're new around here. If you have any questions about this place, let me know.",
				(0, " #bWhat kinds of towns are on Victoria Island?#k"),
				(1, " #bTake me to another town.#k"));
				
		if (askStart == 0)
		{
			int townInfo = AskMenu("There are 6 major towns on Victoria Island. Which one do you want to learn about?",
				(0, " #b#m104000000##k"),
				(1, " #b#m102000000##k"),
				(2, " #b#m101000000##k"),
				(3, " #b#m100000000##k"),
				(4, " #b#m103000000##k"),
				(5, " #b#m105040300##k"));
			
			if (townInfo == 0)
			{
				self.say("The town you're in right now is Lith Harbor! Alright, I'll tell you more about #b#m104000000##k. It's the town in Victoria Island that you arrived in when traveling on the ship. It's #m104000000#. Many beginners who have just arrived from Maple Island begin their journeys here.");
				self.say("It's a quiet town, overlooking an endless sea, thanks to its position at the southwest corner of the island. Many of the people here are or used to be fishermen. They may seem threatening, but if you strike up a conversation, they will be friendly to you.");
				self.say("Around the town there are beautiful prairies. For the most part, the monsters here are small and gentle, perfect for beginners. If you haven't chosen your job yet, this is a good place to boost your level.");
			}
			else if (townInfo == 1)
			{
				self.say("Alright, I'll tell you more about #b#m102000000##k. It's a warrior town located in the northernmost part of Victoria Island, surrounded by rocky mountains. With a harsh climate, only the strong can survive there.");
				self.say("Around the highlands, you'll find dried up trees, wild boars walking around and monkeys that live all over the island. There's also a deep valley, if you enter it, you'll encounter a large dragon as strong as it is big. Better take caution if you're going there, or not go right away.");
				self.say("If you want to be a #bWarrior#k, find #r#p1022000##k, the chief of \r\n#m102000000#. If you're level 10 or higher and have a good amount of STR, he can make you a warrior. If not, better to continue training until you're strong enough.");
			}
			else if (townInfo == 2)
			{
				self.say("Alright, I'll tell you more about #b#m101000000##k. It's a town of wizards, located in the remote eastern part of Victoria Island. It's covered with tall, mystical trees. There you'll also find some fairies. They don't like humans in general, so it would be better to stay away from them and keep your voice down.");
				self.say("Around the forest you'll find that slimes, walking mushrooms, monkeys, alive and undead, all live there. Go deeper into the forest and you'll see witches on flying broomsticks flying across the sky. A word of warning: Unless you're really strong, I recommend you don't go near them.");
				self.say("If you want to be a #bMagician#k, look for #r#p1032001##k, the great wizard of #m101000000#. He can make you a magician if you're level 8 or higher, and have a decent amount of INT. If not, you need to train to achieve it.");
			}
			else if (townInfo == 3)
			{
				self.say("Alright, I'll tell you more about #b#m100000000##k. It's a town of bowmen, located on the southernmost part of the island, in a flat region, surrounded by dense forests and grasslands. The climate is perfect and the town is bustling, a great place to live. Go check it out!");
				self.say("Around the prairie you'll find weak monsters like snails, mushrooms and pigs. Though I heard that deep in the Pig Park, found somewhere in town, you'll occasionally find a huge and powerful mushroom called Mushmom.");
				self.say("If you want to be a #bBowman#k, you have to talk to #r#p1012100##k of \r\n#m100000000#. With a level of 10 or higher and a decent amount of DEX, she can make you a bowman. If you're too weak, go train, get stronger, and try again.");
			}
			else if (townInfo == 4)
			{
				self.say("Alright, I'll tell you more about #b#m103000000##k. It's a city of thieves, located in the northwest part of Victoria Island. There are construction sites around there that'll give you a strange feeling. The horizon is covered in dark clouds, but if you can climb to somewhere high up, you can see a beautiful sunset there.");
				self.say("From #m103000000#, you can travel to various dungeons. You can go to a swamp full of gators and snakes, or explore the underground tunnels, full of ghosts and bats. In the deepest part of the underground, you'll encounter the Wraith, which is almost as huge and as dangerous as a dragon.");
				self.say("If you want to be a #bRogue#k, seek out #r#p1052001##k, the chief of darkness in #m103000000#. He can turn you into a thief if you're level 10 or above, with a good amount of DEX. If not, hunt monsters and train to get stronger.");
			}
			else if (townInfo == 5)
			{
				self.say("Alright, I'll tell you more about #b#m105040300##k. It's a town deep in the forest, located on the southeastern side of Victoria Island. It's between #m100000000# and the Ant Tunnel dungeon. There's a hotel there, so you can rest after a long and tiring day in the dungeon... in general it's a calm town.");
				self.say("Standing in front of the hotel is an old Buddhist monk named #r#p1061000##k. Nobody knows anything about the monk. Apparently he collects materials from travelers and uses them to craft something, but I don't know all the details. If you have business in that area, please check it out for me.");
				self.say("From #m105040300#, going east, you will find the ant tunnel that connects to the deepest part of Victoria Island. There are a lot of powerful and disgusting monsters there. If you go there thinking it'll be a walk in the park, you'll end up as a corpse. Before you go, you have to prepare yourself well for the intricate tunnels.");
				self.say("I also heard that... apparently, in #m105040300# there's a secret entrance that leads to an unknown place. It seems that if you go deep inside, you'll find a pile of dark stones that move on their own, for real. I want to see it with my own eyes someday...");
			}
		}
		else if (askStart == 1)
		{
			if (Job == 0)
			{
				int askTown = AskMenu("There's a special 90% discount for all beginners. Alright, where would you like to go?",
					(0, " #b#m102000000# (120 mesos)#k"),
					(1, " #b#m101000000# (120 mesos)#k"),
					(2, " #b#m100000000# (80 mesos)#k"),
					(3, " #b#m103000000# (100 mesos)#k"));
						
				switch(askTown)
				{
					case 0: GoTown(102000000, 120); break;
					case 1: GoTown(101000000, 120); break;
					case 2: GoTown(100000000, 80); break;
					case 3: GoTown(103000000, 100); break;
				}
			}
			else
			{
				int askTown = AskMenu("Oh, you're not a beginner, are you? Sorry, but I have to charge you the normal price. Where would you like to go?",
					(0, " #b#m102000000# (1,200 mesos)#k"),
					(1, " #b#m101000000# (1,200 mesos)#k"),
					(2, " #b#m100000000# (800 mesos)#k"),
					(3, " #b#m103000000# (1,000 mesos)#k"));
						
				switch(askTown)
				{
					case 0: GoTown(102000000, 1200); break;
					case 1: GoTown(101000000, 1200); break;
					case 2: GoTown(100000000, 800); break;
					case 3: GoTown(103000000, 1000); break;
				}
			}
		}
	}
}