using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void PatchNotes()
	{
		var patchnotes = @"Thanks for playing MG2!
In v0.11 you can expect to find the following changes:

#e[Game]#n
At long last, #bpets#k are now available! Bring your fuzzy friends with you on your journey and watch them grow alongside you!
- Purchase Pets and other accessories in the Cash Shop under the Pet tab.
- Pets follow you wherever you go and they'll even #bpick up money they find on the ground along the way#k.
- There are many ways to train your pet: feed them, talk to them or complete one of the obstacle courses found in Henesys and Ludibrium.
- #bCloy#k in Henesys and #bWisp#k in Ludibrium can provide any information you need to know about your pet.


#e[Event]#n
Easter is right around the corner and in preparation for the season's festivities, our friend the Easter Bunny has hidden eggs all over Maple World. Find Easter Eggs from monsters, stop by the #bMaple Administrator#k who will be making Easter baskets and watch out for the Easter Bunny's troublemaking cousin, #bMad Bunny#k who's lurking around Henesys, Orbis and Ludibrium.

The Ludibrium Opening Sweepstakes have come to an end, and the winners of the event have been chosen!
- 3rd prize winners: #bDusk#k, #bTomer#k, #bCostanza#k
- 2nd prize winners: #bAresTheMage#k, #bR0B0TSM0K3#k

And our Grand Prize winner is... #bKarasu#k!

Congratulations to all our winners! Please check the Cash Shop and talk to #bMia#k in Ludibrium to redeem your prizes!


#e[Maps]#n
Monsters in some maps have been adjusted.

Ludibrium has been expanded:
- Ludibrium Pet-Walking Road can be found in town.
- The homes of the residents of Ludibrium can now be found between town and the entrance to Eos Tower.
- Some NPC locations have been adjusted.


#e[Monsters]#n
A new monster can be found in Eos Tower:
- Level #r47#k: Rombard


#e[NPC]#n
New NPCs can be found in Ludibrium:
- Trainers Weaver and Neru in Pet-Walking Road
- Wisp at the Entrance to Eos Tower


#e[Quest]#n
New pet-related quests:
- NPC Mar: Mar the Fairy and the Life Water
- NPC Wisp: Scroll of Life

New quests in Ludibrium:
- Lv #b25#k, NPC Delv: Toy Soldier's Walnut
- Lv #b25#k, NPC Olson: Dollhouse
- Lv #b28#k, NPC Nemi: Nemi's Ingredients for Cooking
- Lv #b30#k, NPC Cheng the Intern: The Missing Mechanical Parts
- Lv #b30#k, NPC Marcel: Cleaning Up the Outer Parts of Eos Tower
- Lv #b33#k, NPC Olson: A Delivery to a Lost Time
- Lv #b33#k, NPC Grandpa Clock: Grandpa Clock's Crisis
- Lv #b35#k, NPC Marcel: Eos Tower Threatened!
- Lv #b40#k, NPC Marcel: Peace at Eos Tower
- Lv #b40#k, NPC Roly-Poly 10: Fixing Eos Tower


#e[Improvements]#n
Party requirements for 1st Accompaniment and Abandoned Tower party quests have been lowered to 3~4 and 5~6 party members respectively.

You no longer need to meet the stat requirements to equip an item in the Cosmetic Equipment Inventory, only level and class restrictions still apply.

A confirmation message will be displayed when purchasing Cash at the Internet Cafe.


#e[Cash Shop]#n
The Cash Shop has been changed overall:
- Items found in the equipment tab will now last for #b45 days#k. Prices of different equipment types have been adjusted accordingly.
- Recommended items will last for 14 days at a discounted rate.

Henesys, Orbis and Ludibrium will all offer a selection of different faces including some brand new faces to choose from!

New hairstyles are available from the salons in each town.


#e[Bugfixes]#n
Some map names and skill descriptions have been corrected.

The chat will no longer jump to the most recent message when scrolled up.

Fixed an issue where the screenshot settings would not get saved.

Equipment will no longer contribute to one's ability to use equipped items they don't meet the stat requirements for.

Fixed incorrect stat requirements for certain equipment.

Issues with some portals in the Crack of Dimension quest have been resolved.

Fixed an issue where players would respawn below the map in parts of Eos Tower.

Fixed a broken rope in Forbidden Time.

Issues with the Path of Thief quest are now resolved.


Happy Mapling!";

		self.say(patchnotes.Split("\n"));

	}
	
	private void Referral()
	{
		self.say("The referral system allows players to earn Cash by referring new players to MG2!");
		self.say("To refer a player, first login to your account on the website:\r\n#bhttps://rsvp.mdtz.eu#k. Once you are logged in, you will be able to copy your unique referral link.");
		self.say("Send the link to any players registering a new account on MG2. When the player reaches #blevel 30#k for the first time, you and the player you referred will both earn #b2,000 Cash#k!");
		self.say("There are no limitations on referrals, so any new account registered using your referral link will qualify. As long as a player on the referred account reaches #blevel 30#k, both accounts will receive the reward.");
	}
	
	private void Easter()
	{
		string quest = GetQuestData(8020003);
		string lastDate = GetQuestData(8021000);
		string today = DateTime.UtcNow.ToString("yyyyMMdd");
		
		if (lastDate == today)
		{
			self.say("It looks like I already made you an Easter basket today. Why don't you come back again tomorrow~?");
			return;
		}
		
		if (quest == "s")
		{
			if (ItemCount(4000003) < 100 || ItemCount(4000004) < 100 || ItemCount(4000002) < 1)
			{
				self.say("Are you missing something? I need #b100 Tree Branches#k,\r\n#b100 Squishy Liquids#k, and #b1 Pig's Ribbon#k to make an #rEaster Basket#k.");
				return;
			}
			
			self.say("Great job gathering up #b100 Tree Branches#k, #b100 Squishy Liquids#k, and #b1 Pig's Ribbon#k needed to make the #rEaster Basket#k. Now let me see here...");
			
			if (!ExchangeEx(0, "4000003", -100, "4000004", -100, "4000002", -1, "4031283,DateExpire:2021042423", 1))
			{
				self.say("Hmm... please leave an empty space in your etc. inventory and then talk to me again.");
				return;
			}
			
			AddEXP(800);
			SetQuestData(8020003, "end");
			SetQuestData(8021000, DateTime.UtcNow.ToString("yyyyMMdd"));
			QuestEndEffect();
			self.say("Here's your #rEaster Basket#k! By the way, I hear that the Easter Bunny's nasty cousin is trying to ruin Easter this year. Avoid that rotten egg. He is a disgrace to the season~");
		}
		else
		{
			bool start = AskYesNo("Easter is upon us. To celebrate, I'll be crafting Easter Baskets for everyone. Do you want one?");
			
			if (!start)
			{
				self.say("I see. I make the best baskets in town, so if you change your mind, I'll be here.");
				return;
			}
			
			SetQuestData(8020003, "s");
			self.say("Good choice. Can you bring me #b100 Tree Branches#k, #b100 Squishy Liquids#k, and #b1 Ribbon Pig's Ribbon#k?");
		}
	}
	
	public override void Run()
	{
		string talk = "Hi, welcome to MG2!";
		bool easter = false;
		
		if (DateTime.UtcNow >= DateTime.Parse("2021-03-27") && DateTime.UtcNow <= DateTime.Parse("2021-04-17"))
		{
			talk = "Hi, I hope you're having a wonderful Easter season~!";
			easter = true;
		}
		
		AskMenuCallback($"{talk}#b",
			(" Easter Basket", easter && Level >= 8, Easter),
			(" Tell me about referrals", Level >= 1, Referral),
			(" What's new in this version?", Level >= 1, PatchNotes));
	}
}