using WvsBeta.Game;
using WvsBeta.Common;
using System.Linq;
using WvsBeta.Game.GameObjects;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		int start = AskMenu("Hi, welcome to MG2!#b",
			(0, " Participate in the Thanksgiving Event"),
			(1, " What's new in this version?"));
		
		var items = new int[] {
			3994012,
			3994000,
			3994006,
			3994003,
			3994001,
			3994013,
			3994008,
			3994005,
			3994007,
			3994010,
		};
		
		switch(start)
		{
			case 0:
			{
				string Thanksgiving = GetQuestData(8020002);
		
				if (Thanksgiving == "")
				{
					bool askStart = AskYesNo("Hello there, Mapler! We'll be conducting a small Thanksgiving event here. Are you interested?");
					
					if (!askStart)
					{
						self.say("Oh I see. Hurry, though, because this event ends soon.");
					}
					else
					{
						self.say("Cool! Okay, here's the deal. A number of monsters will randomly drop alphabet letters, and your job is to collect all the letters of the word #bMAPLESTORY#k. Once you collect them all, bring them to me and I'll put you in our Thanksgiving event. From this pool, we will randomly select winners to receive MaplePoints. Good luck, and hurry, because this event ends soon!");
						SetQuestData(8020002, "s");
					}
				}
				else if (Thanksgiving == "s")
				{
					if (items.Any(x => ItemCount(x) < 1))
					{
						self.say("I don't think you have all the letters. The letters you need are #bM A P L E S T O R Y#k. Check and see if you have them all.");
						return;
					}
					
					bool askComplete = AskYesNo("Thanks. Great job. It must have been difficult for you to collect all the letters, but you managed to pull it off!! Alright, so do you want to turn in the letters and participate in the event?");
					
					if (!askComplete)
					{
						self.say("Really? I don't see what those letters can be put to good use for other than on this event. It's your call, though. Come back and talk to me if you have a change of heart.");
						return;
					}
					
					if (items.All(x => ItemCount(x) >= 1))
					{
						// Take away all the letters.
						items.ForEach(x => TakeItem(x, 1));
						SetQuestData(8020002, "end");
						self.say("Good choice. Now all you need to do is wait until we select the winners. It'll be posted #bon the website#k soon, so please check it regularly. I'll see you around. Ciao~");
					}
					else
					{
						self.say("Huh? Are you sure you have all the letters?");
					}
				}
				else
				{
					self.say("You have already participated in the event. Now all you need to do is to wait until we select the winners. It'll be posted on the website soon, so please check the it regularly. I'll see you around. Ciao~");
				}
				break;
			}
			case 1:
			{
				self.say("Happy Thanksgiving from the MG2 Team! In v0.04 you can expect to find the following changes:\r\n\r\n#e[Event]#n\r\n- The Thanksgiving Event will take place from November 21st to December 5th. I will be collecting some alphabet letters to spell M.A.P.L.E.S.T.O.R.Y, which will be dropped by a set of random monsters.\r\n- Turkeys will be roaming all over Victoria Island dropping random new items.\r\n\r\n#e[Monster Book]#n\r\n- Monster Book has been added! Monsters all around the world will drop cards with information about the monster on them. The more cards you collect, the more you'll learn:\r\n\r\n#e1 Card#n - See what the monster looks like\r\n#e2 Cards#n - Monster HP and MP level\r\n#e3 Cards#n - In-depth monster description\r\n#e4 Cards#n - See what loot you can find from the monster\r\n#e5 Cards#n - A list of locations to find the monster in\r\n\r\n- You can bind it to a key in your key settings, the default key is \"B\" for new characters. You can also double-click a monster to view its Monster Book page.\r\n- The total number of cards collected will appear in the the Character Information window, try to collect them all!\r\n\r\n#e[Improvements]#n\r\n- Players can now view their world and class rankings on the character screen while logging into the game!\r\n- When a player uses a scroll, a visual effect and sound will play to show the outcome.\r\n\r\n#e[Bugfixes]#n\r\n- Some skills that were missing sound effects have been corrected.\r\n- Some monster animations have been corrected.\r\n\r\nHappy Mapling!");
				break;
			}
		}
	}
}