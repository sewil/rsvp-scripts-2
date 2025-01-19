using System;
using System.Linq;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void WizQuestion(int index)
	{
		List<string> questions = new List<string>();
		List<int> answers = new List<int>();
		List<Dictionary<int, string>> options = new List<Dictionary<int, string>>();
		
		#region Question Data
		
		if (index == 1)
		{
			questions.Add("Here's the 1st question. Which of these NPC's will you NOT see at Henesys of Victoria Island ...?#b");
			questions.Add("Here's the 2nd question. Which of these monsters will you NOT see at Maple Island ...?#b");
			questions.Add("Here's the 3rd question. Which of these items does Maya ask for to cure her sickness ...?#b");
			questions.Add("Here's the 4th question. Which of these towns is NOT part of Victoria Island ...?#b");
			questions.Add("Here's the 5th question. Which of these monsters will you NOT see at The Ant Tunnel in Victoria Island's central dungeon ...?#b");
			
			answers.Add(1);
			answers.Add(3);
			answers.Add(4);
			answers.Add(1);
			answers.Add(4);
			
			options.Add(new Dictionary<int, string>() {
				{0, " #p1012101#"},
				{1, " #p1002001#"},
				{2, " #p1010100#"},
				{3, " #p1012100#"},
				{4, " #p1012102#"}});
			options.Add(new Dictionary<int, string>() {
				{0, " #o100101#"},
				{1, " #o1210102#"},
				{2, " #o130101#"},
				{3, " #o1210100#"},
				{4, " #o120100#"}});
			options.Add(new Dictionary<int, string>() {
				{0, " Incredible Medicine"},
				{1, " Bad Medicine"},
				{2, " The All-Healing Medicine"},
				{3, " Chinese Medicine"},
				{4, " #t4031006#"}});
			options.Add(new Dictionary<int, string>() {
				{0, " Sleepywood"},
				{1, " Amherst"},
				{2, " Perion"},
				{3, " Kerning City"},
				{4, " Ellinia"}});
			options.Add(new Dictionary<int, string>() {
				{0, " #o2110200#"},
				{1, " #o2230100#"},
				{2, " #o5130100#"},
				{3, " #o2230101#"},
				{4, " #o3000000#"}});
		}
		else if (index == 2)
		{
			questions.Add("Here's the 1st question. Which of these pairings of the monster/leftover is correctly matched ...?#b");
			questions.Add("Here's the 2nd question. Which of these NPC's will you NOT see at Perion of Victoria Island ...?#b");
			questions.Add("Here's the 3rd question. Which of these NPC's is the father of Alex the runaway kid, whom you'll see at Kerning City ...?#b");
			questions.Add("Here's the 4th question. Which of these items will you receive from the NPC after collecting 30 Dark Marbles during the test for the 2nd job advancement ...?#b");
			questions.Add("Here's the 5th question. Which of these pairings of job/required stat matches for the 1st job advancement ...?#b");
			
			answers.Add(3);
			answers.Add(1);
			answers.Add(4);
			answers.Add(0);
			answers.Add(2);
			
			options.Add(new Dictionary<int, string>() {
				{0, " #o3210100# - Fire Boar's nose"},
				{1, " #o4230100# - Cold Eye's Eye"},
				{2, " #o1210100# - Pig's ear"},
				{3, " #o2300100# - #t4000042#"},
				{4, " #o2230101# - Zombie Mushroom's hat"}});
			options.Add(new Dictionary<int, string>() {
				{0, " #p1021100#"},
				{1, " #p1032002#"},
				{2, " #p1022002#"},
				{3, " #p1022003#"},
				{4, " #p1022100#"}});
			options.Add(new Dictionary<int, string>() {
				{0, " #p1012005#"},
				{1, " #p1012002#"},
				{2, " #p12000#"},
				{3, " #p20000#"},
				{4, " #p1012003#"}});
			options.Add(new Dictionary<int, string>() {
				{0, " #t4031012#"},
				{1, " Hero's Necklace"},
				{2, " Hero's Pendant"},
				{3, " Hero's Medal"},
				{4, " Hero's Sign"}});
			options.Add(new Dictionary<int, string>() {
				{0, " Warrior - STR 30+"},
				{1, " Magician - INT 25+"},
				{2, " Bowman - DEX 25+"},
				{3, " Thief - DEX 20+"},
				{4, " Thief - LUK 20+"}});
		}
		else if (index == 3)
		{
			questions.Add("Here's the 1st question. Which of these NPC's will you see FIRST at MapleStory ...?#b");
			questions.Add("Here's the 2nd question. Which of these EXP points is required to go from level 1 to 2 ...?#b");
			questions.Add("Here's the 3rd question. Which of these NPC's will you NOT see at El Nath of Ossyria ...?#b");
			questions.Add("Here's the 4th question. Which of these jobs will you NOT get after the 2nd job advancement ...?#b");
			questions.Add("Here's the 5th question. Which of these quests can be repeated ...?#b");
			
			answers.Add(4);
			answers.Add(1);
			answers.Add(2);
			answers.Add(4);
			answers.Add(3);
			
			options.Add(new Dictionary<int, string>() {
				{0, " #p2000#"},
				{1, " #p1010100#"},
				{2, " #p2102#"},
				{3, " #p2001#"},
				{4, " #p2101#"}});
			options.Add(new Dictionary<int, string>() {
				{0, " 10"},
				{1, " 15"},
				{2, " 20"},
				{3, " 25"},
				{4, " 30"}});
			options.Add(new Dictionary<int, string>() {
				{0, " #p2020000#"},
				{1, " #p2020003#"},
				{2, " #p2012010#"},
				{3, " #p2020006#"},
				{4, " #p2020007#"}});
			options.Add(new Dictionary<int, string>() {
				{0, " Page"},
				{1, " Assassin"},
				{2, " Bandit"},
				{3, " Cleric"},
				{4, " Mage"}});
			options.Add(new Dictionary<int, string>() {
				{0, " Maya and the Weird Medicine"},
				{1, " Alex the Runaway Kid"},
				{2, " Pia and the Blue Mushroom"},
				{3, " Arwen and the Glass Shoes"},
				{4, " Alpha Platoon's Network of Communication"}});
		}
		else if (index == 4)
		{
			questions.Add("Here's the 1st question. Which of these NPC's is NOT part of the Alpha Platoon at Ossyria ...?#b");
			questions.Add("Here's the 2nd question. Whick of these items are NOT required to reawaken the old Gladius taken from Manji of Perion ...?#b");
			questions.Add("Here's the 3rd question. Which of these NPC's will you NOT see at Kerning City of Victoria Island ...?#b");
			questions.Add("Here's the 4th question. Which of these pairings of monster/leftover does NOT match ...?#b");
			questions.Add("Here's the 5th question. Which of these monsters flies in the air ...?#b");
			
			answers.Add(0);
			answers.Add(3);
			answers.Add(4);
			answers.Add(1);
			answers.Add(4);
			
			options.Add(new Dictionary<int, string>() {
				{0, " Sergeant Peter"},
				{1, " #p2010000#"},
				{2, " #p2020003#"},
				{3, " #p2030002#"},
				{4, " #p2030001#"}});
			options.Add(new Dictionary<int, string>() {
				{0, " #t4003002#"},
				{1, " #t4021009#"},
				{2, " #t4001006#"},
				{3, " #t4003003#"},
				{4, " #t4001005#"}});
			options.Add(new Dictionary<int, string>() {
				{0, " #p1052002#"},
				{1, " #p1052102#"},
				{2, " #p1052012#"},
				{3, " #p1052100#"},
				{4, " #p1040000#"}});
			options.Add(new Dictionary<int, string>() {
				{0, " #o3230200# - #t4000059#"},
				{1, " #o4230105# - Leaf of Nependeath"},
				{2, " #o6130101# - #t4000040#"},
				{3, " #o6130103# - #t4000050#"},
				{4, " #o3210800# - #t4000029#"}});
			options.Add(new Dictionary<int, string>() {
				{0, " #o5130104#"},
				{1, " #o4230105#"},
				{2, " #o4230103#"},
				{3, " #o4130101#"},
				{4, " #o5300100#"}});
		}
		else if (index == 5)
		{
			questions.Add("Here's the 1st question. Which of these pairings of sickness/results resulted from a monster's attack does NOT match ...?#b");
			questions.Add("Here's the 2nd question. Which of these NPC's will you NOT see at Orbis of Ossyria ...?#b");
			questions.Add("Here's the 3rd question. Which of these quests has the highest required level to start ...?#b");
			questions.Add("Here's the 4th question. Which of these NPC's have NOTHING to do with refining, upgrading, and making items ...?#b");
			questions.Add("Here's the 5th question. In MapleStory, which of these pairings of potion/result matches?");
			
			answers.Add(2);
			answers.Add(1);
			answers.Add(3);
			answers.Add(2);
			answers.Add(4);
			
			options.Add(new Dictionary<int, string>() {
				{0, " State of darkness - decrease in accuracy"},
				{1, " State of being cursed - decrease in EXP earned"},
				{2, " State of weakness - decrease in speed"},
				{3, " State of being sealed up - unable to use skills"},
				{4, " State of being poisoned - Slow decrease in HP"}});
			options.Add(new Dictionary<int, string>() {
				{0, " #p2010000#"},
				{1, " #p1022100#"},
				{2, " #p2010003#"},
				{3, " #p2012004#"},
				{4, " #p2012005#"}});
			options.Add(new Dictionary<int, string>() {
				{0, " Manji's Old Gladius"},
				{1, " Luke the Security Man's Wish to Travel"},
				{2, " Looking for the Book of Ancient..."},
				{3, " Alcaster and the Black Crystal"},
				{4, " Alpha Platoon's Network of Communication"}});
			options.Add(new Dictionary<int, string>() {
				{0, " #p2010003#"},
				{1, " #p1022003#"},
				{2, " #p1032003#"},
				{3, " #p1032002#"},
				{4, " #p2020000#"}});
			options.Add(new Dictionary<int, string>() {
				{0, " #t2000001# - Recover HP 200"},
				{1, " #t2001001# - Recover MP 2000"},
				{2, " #t2010004# - Recover MP 100"},
				{3, " #t2020001# - Recover HP 300"},
				{4, " #t2020003# - Recover HP 400"}});
		}
		else if (index == 6)
		{
			questions.Add("Here's the 1st question. Which of these NPC's will you NOT see at Ellinia of Victoria Island ...?#b");
			questions.Add("Here's the 2nd question. Which of these monsters will you NOT be facing at Ossyria ...?#b");
			questions.Add("Here's the 3rd question. Which of these monsters have the highest level ...?#b");
			questions.Add("Here's the 4th question. In MapleStory, which of these pairings of potion/result does not match ...?#b");
			questions.Add("Here's the 5th question. Which of these NPC's have NOTHING to do with pets ...?#b");
			
			answers.Add(4);
			answers.Add(1);
			answers.Add(3);
			answers.Add(1);
			answers.Add(3);
			
			options.Add(new Dictionary<int, string>() {
				{0, " #p1032003#"},
				{1, " #p1032002#"},
				{2, " #p1032001#"},
				{3, " #p1032100#"},
				{4, " #p1081101#"}});
			options.Add(new Dictionary<int, string>() {
				{0, " #o5140000#"},
				{1, " #o5130103#"},
				{2, " #o6300000#"},
				{3, " #o8140000#"},
				{4, " #o5120000#"}});
			options.Add(new Dictionary<int, string>() {
				{0, " #o1120100#"},
				{1, " #o1210101#"},
				{2, " #o1110100#"},
				{3, " #o1130100#"},
				{4, " #o1210103#"}});
			options.Add(new Dictionary<int, string>() {
				{0, " #t2050003# - Recover from the state of being cursed or sealed up"},
				{1, " #t2020014# - Recover MP 3000"},
				{2, " #t2020004# - Recover HP 400"},
				{3, " #t2020000# - Recover MP 200"},
				{4, " #t2000003# - Recover MP 100"}});
			options.Add(new Dictionary<int, string>() {
				{0, " #p1012005#"},
				{1, " #p1032102#"},
				{2, " #p1012007#"},
				{3, " #p1012002#"},
				{4, " #p1012004#"}});
		}
		
		#endregion
		
		for (int i = 0; i < questions.Count; i++)
		{
			int selection = AskMenu(questions[i], options[i].Select(kvp => (kvp.Key, kvp.Value)).ToArray());
			
			if (selection != answers[i])
			{
				self.say("Incorrect...\r\nTry once more...");
				return;
			}
		}
		
		self.say("Alright. All your answers have been proven as the truth...\r\nYour wisdom has been proven.\r\nTake this necklace and go back ...");
		
		if (!Exchange(0, 4031058, 1))
		{
			self.say("Is your etc. inventory full ...?#b");
			return;
		}
	}
	
	public override void Run()
	{
		string questThird = GetQuestData(7500000);
		
		if (questThird == "end1")
		{
			bool start = AskYesNo("... ... ...\r\nIf you want to test out your wisdom, then you'll have to offer #b#t4005004##k as the sacrifice...\r\nAre you ready to offer #t4005004# and answer a set of questions from me?");
			
			if (!start)
			{
				self.say("Come back when you're ready.");
				return;
			}
			
			if (SlotCount(4) < 1)
			{
				self.say("Your Etc. inventory is full... make some space or you won't be able to take the test. Make some room, then try again...");
				return;
			}
			
			if (ItemCount(4031058) >= 1)
			{
				self.say("You already possess #b#t4031058##k...\r\nTake the necklace and go back...");
				return;
			}
			
			if (!Exchange(0, 4005004, -1))
			{
				self.say("You must sacrifice the #b#t4005004##k before you can test your wisdom.");
				return;
			}
			
			self.say("Alright... I'll be testing out your wisdom here. Answer all the questions correctly, and you will pass the test. BUT, if you even lie to me once, then you'll have to start over again... ok, here we go.");
			
			Random rnd = new Random();
			
			WizQuestion(rnd.Next(1, 7));
		}
	}
}