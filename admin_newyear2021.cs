using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void PatchNotes()
	{
		var patchnotes = @"Thanks for playing MG2! In v0.07 you can expect to find the following changes:

#e[Event]#n
- For the remainder of the Winter season, snow will fall in some maps.
- #bHappyville#k has closed until next year, and the ornaments will no longer drop from monsters.


#e[Features]#n
- The Internet Cafe is now available!
To enter, talk to #bMonglong#k who's sitting at the entrance in#b Kerning City#k. Once inside, strike up a conversation with the owner, #bBilly#k, and start a quest to find the stolen computer mouses from monsters in Premium Road. Turning them in will earn you some Cafe points to use for various prizes!
To enter Premium Road, you'll need a ticket which can occasionally be found from all monsters and from the Scroll of Secrets quest. Entry is limited to #bonce per day#k for #b30 minutes#k. You can enter alone or with a party of up to 6 people!
- You can clear your chatlog by using /clear in the chat.
- Added experimental IME support for typing in foreign languages (Korean, Japanese, etc)
- New options have been added to Game Options:

#bMapleTip#k - Enable or disable MapleTip messages in chat.
#bMegaphone#k - Enable or disable megaphone messages in chat.
#bDark Chat#k - When selected, the chat background will become more opaque, improving the readability of chat messages.


#e[Maps]#n
- Monsters have been rebalanced in some of the fields in Kerning City subway.
- Some monsters in the Subway<Depot> maps have been adjusted.


#e[Cash Shop]#n
- All inventory upgrades have been reduced in price from \n#b4,000#k to #b2,000 Cash#k, and have had their limits increased from 40 to 80 slots. Players who previously purchased additional inventory slots will be refunded the difference.
- Storage Upgrade is now available in the Cash Shop, up until 80 slots of storage.
- The coupon feature is now available. Be on the lookout for special codes featured during events and in some of our newsletters!
- Cash can be earned by exchanging Cafe points at the Internet Cafe.


#e[Improvements]#n
- Many NPCs and quests have been reworked overall.
- Monster card drops have been adjusted for some Victoria Island monsters.
- Adjustments have been made to improve the user \ninterface.
- IME is now available when typing in chat.
- A fix has been applied that should reduce lagspikes while killing mobs in certain system configurations.


#e[Bugfixes]#n
- Drop information in the Monster Book has been adjusted for items with a drop chance greater than 1 in 2.
- Bugs related to the Shield slot on the Cosmetic Inventory have been corrected.
- Fixed a bug with the Bowman skill Focus.
- A bug causing players to get caught at the top of ropes and ladders has been corrected in most maps.
- Inviting someone as a buddy should not erroneously report the player is a Gamemaster.


Happy Mapling!";

		self.say(patchnotes.Split("\n"));
	}
	
	private void MapleQuiz(int index)
	{
		int answer = 0;
		
		if (index == 1)
		{
			int question1 = AskMenu("Here goes the 1st question. What does Gordon make near the potion shop in El Nath?#b",
				(0, " Gloves"),
				(1, " Shoes"),
				(2, " Clothes"),
				(3, " Food"));
			
			if (question1 == 1)
			{
				int question2 = AskMenu("Here goes the 2nd question. Where will you find Rowen the Fairy?#b",
					(0, " Ellinia"),
					(1, " Orbis"),
					(2, " Sleepywood"),
					(3, " Kerning City"));
				
				if (question2 == 0)
				{
					int question3 = AskMenu("Here goes the last question. Which of these items will you find in the Cash Shop right now?#b",
						(0, " Glowing Shoes"),
						(1, " Chocolate Bar Sword"),
						(2, " Transparent Hat"),
						(3, " Green T-Shirt"));
					
					if (question3 == 2) answer = 1;
					else answer = 0;
				}
				else answer = 0;
			}
			else answer = 0;
		}
		else if (index == 2)
		{
			int question1 = AskMenu("Here goes the 1st question. Which of these options is not true about the Cash Shop?#b",
				(0, " You can gift items to your friends."),
				(1, " There's a button that allows you to buy what you're wearing."),
				(2, " The Wish List can contain up to 15 different items."),
				(3, " You can try on outfits by double-clicking them."));
			
			if (question1 == 2)
			{
				int question2 = AskMenu("Here goes the 2nd question. Which is the command that you use when you want to find out if your friends are online or where they are at the moment??#b",
					(0, " /find character-name"),
					(1, " /search character-name"),
					(2, " /who character-name"),
					(3, " /where character-name"));
				
				if (question2 == 0)
				{
					int question3 = AskMenu("Here goes the last question. Which is the command that you use when you want help??#b",
						(0, " /!"),
						(1, " /?"),
						(2, " /h"),
						(3, " //"));
					
					if (question3 == 1) answer = 1;
					else answer = 0;
				}
				else answer = 0;
			}
			else answer = 0;
		}
		else if (index == 3)
		{
			int question1 = AskMenu("Here goes the 1st question. Which is the shortcut key that shows your friends list??#b",
				(0, " H"),
				(1, " R"),
				(2, " A"),
				(3, " C"));
			
			if (question1 == 1)
			{
				int question2 = AskMenu("Here goes the 2nd question. Which is the shortcut key for the Mini Map?#b",
					(0, " H"),
					(1, " M"),
					(2, " 1"),
					(3, " F5"));
				
				if (question2 == 1)
				{
					int question3 = AskMenu("Here goes the last question. Which of these pieces of advice does Roger teach you on Maple Island?#b",
						(0, " How to equip weapons"),
						(1, " How to get to Victoria Island"),
						(2, " How to climb ladders"),
						(3, " How to consume items"));
					
					if (question3 == 3) answer = 1;
					else answer = 0;
				}
				else answer = 0;
			}
			else answer = 0;
		}
		else if (index == 4)
		{
			int question1 = AskMenu("Here goes the 1st question. How many floors are there in the Orbis Tower?#b",
				(0, " 15"),
				(1, " 25"),
				(2, " 20"),
				(3, " 30"));
			
			if (question1 == 2)
			{
				int question2 = AskMenu("Here goes the 2nd question. Which of these events can you NOT play with GMs??#b",
					(0, " Ola Ola"),
					(1, " Snowball"),
					(2, " Coconut Harvest"),
					(3, " Forest of Patience"));
				
				if (question2 == 3)
				{
					int question3 = AskMenu("Here goes the last question. Where is El Nath?#b",
						(0, " Victoria Island"),
						(1, " Ossyria"),
						(2, " Maple Island"),
						(3, " Florina Beach"));
					
					if (question3 == 1) answer = 1;
					else answer = 0;
				}
				else answer = 0;
			}
			else answer = 0;
		}
		else if (index == 5)
		{
			int question1 = AskMenu("Here goes the 1st question. Which monster should you hunt to find Tablecloth?#b",
				(0, " Wraith"),
				(1, " Leatty"),
				(2, " Jr. Wraith"),
				(3, " Malady"));
			
			if (question1 == 2)
			{
				int question2 = AskMenu("Here goes the 2nd question. Which friend of Ronnie lives in Henesys of Victoria Island?#b",
					(0, " Pia"),
					(1, " Chief Stan"),
					(2, " Cloy"),
					(3, " Rina"));
				
				if (question2 == 3)
				{
					int question3 = AskMenu("Here goes the last question. Which event can be played with a team?#b",
						(0, " Coconut Harvest"),
						(1, " OX Quiz"),
						(2, " MapleStory Physical Fitness Test"),
						(3, " Treasure Hunt"));
					
					if (question3 == 0) answer = 1;
					else answer = 0;
				}
				else answer = 0;
			}
			else answer = 0;
		}
		else if (index == 6)
		{
			int question1 = AskMenu("Here goes the 1st question. Which of these does Etran in Ellinia NOT make?#b",
				(0, " Wands"),
				(1, " Shoes"),
				(2, " Gloves"),
				(3, " Hats"));
			
			if (question1 == 1)
			{
				int question2 = AskMenu("Here goes the 2nd question. Which ingredients are needed to craft the Moon Rock?#b",
					(0, " One of every refined jewel"),
					(1, " One of every refined mineral"),
					(2, " One of every refined crystal"),
					(3, " One of every mineral and jewel"));
				
				if (question2 == 1)
				{
					int question3 = AskMenu("Here goes the last question. Which tab in the Cash Shop would you select to buy weather effects?#b",
						(0, " Set-up"),
						(1, " Etc."),
						(2, " Use"),
						(3, " Package"));
					
					if (question3 == 2) answer = 1;
					else answer = 0;
				}
				else answer = 0;
			}
			else answer = 0;
		}
		else if (index == 7)
		{
			int question1 = AskMenu("Here goes the 1st question. Which of these will restore 150 MP?#b",
				(0, " Apple"),
				(1, " Unagi"),
				(2, " Cake"),
				(3, " Lemon"));
			
			if (question1 == 3)
			{
				int question2 = AskMenu("Here goes the 2nd question. Who do you talk to in Lith Harbor to learn about each town in Victoria Island?#b",
					(0, " Pason"),
					(1, " Vikin"),
					(2, " Chef"),
					(3, " Phil"));
				
				if (question2 == 3)
				{
					int question3 = AskMenu("Here goes the last question. How do you get to Ossyria?#b",
						(0, " Take the boat in Ellinia"),
						(1, " Take the subway in Kerning City"),
						(2, " Take a plane in Henesys"),
						(3, " Take a train in Perion"));
					
					if (question3 == 0) answer = 1;
					else answer = 0;
				}
				else answer = 0;
			}
			else answer = 0;
		}
		else if (index == 8)
		{
			int question1 = AskMenu("Here goes the 1st question. What is Unagi made of?#b",
				(0, " Flounder"),
				(1, " Eel"),
				(2, " Tuna"),
				(3, " Salmon"));
			
			if (question1 == 1)
			{
				int question2 = AskMenu("Here goes the 2nd question. Which monster is NOT found in Florina Beach??#b",
					(0, " Clang"),
					(1, " Zombie Lupin"),
					(2, " Lorang"),
					(3, " Lupin"));
				
				if (question2 == 1)
				{
					int question3 = AskMenu("Here goes the last question. Which animal in the Chinese zodiac is 2021 the year of?#b",
						(0, " Dragon"),
						(1, " Ox"),
						(2, " Tiger"),
						(3, " Monkey"));
					
					if (question3 == 2) answer = 1;
					else answer = 0;
				}
				else answer = 0;
			}
			else answer = 0;
		}
		
		if (answer == 0)
		{
			SetQuestData(9000200, "fail");
			self.say("Nope~ that's not the right answer. Sorry, you'll have to try again!");
		}
		else
		{
			self.say("Wow, you answered all three questions, great job~! Hold out your hands, I have a special gift just for you.");
			
			if (!Exchange(10000, 2022006, 20))
			{
				self.say("Hmm... are you sure there's room in your use inventory?");
				return;
			}
			
			AddEXP(1300);
			SetQuestData(9000200, "end");
			self.say($"Happy New Year, {chr.Name}, hopefully this well help you on your journey. I'll see you around!");
		}
	}
	
	public override void Run()
	{
		string cakePrize = GetQuestData(9000200);
		string today = DateTime.UtcNow.ToString("yyyyMMdd");
		
		if (today != "20210101" && today != "20210102")
		{
			PatchNotes();
			return;
		}
		
		int start = AskMenu("Hi, welcome to MG2!#b",
			(0, " Celebrate New Year's Day"),
			(1, " What's new in this version?"));
		
		if (start == 0)
		{
			if (Level < 8)
			{
				self.say("Happy New Year~! To celebrate the new year, I'm giving out something special to those who take my quiz! You'll have to be at least #blevel 8#k to take the quiz, though.");
				return;
			}
			
			if (cakePrize == "end")
			{
				self.say("Hey~ you're the one who took my quiz! I wish you the best of luck in the new year!");
			}
			else
			{
				self.say("Happy New Year~! To celebrate New Year's Day, I'm giving out something special to those who take my quiz. It's easy, just answer all three questions correctly and I'll give you a nice reward! Make sure there's a space available in your use inventory first.");
				
				Random rnd = new Random();
				MapleQuiz(rnd.Next(1, 9));
			}
		}
		else
		{
			PatchNotes();
		}
	}
}