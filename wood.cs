using System;
using System.Collections.Generic;
using WvsBeta.Game;
using WvsBeta.Common;

public class NpcScript : IScriptV2
{
	private void Blackbull1(string quest)
	{
		if (quest == "")
		{
			self.say("Can you get me #b#e30#n #t4000003#es#k and #b#e50#n #t4000018#s#k? I'm trying to remodel my house and make it bigger... If you can do it, I'll hook you up with a nice #bshield#k that I don't really \r\nneed... You'll get plenty if you take down the ones that look like trees.");
			SetQuestData(1000100, "w");
		}
		else if (quest == "w")
		{
			if (ItemCount(4000003) < 30 || ItemCount(4000018) < 50)
			{
				self.say("Wait, what happened??? Are you sure you have #b#e30#n #t4000003#es#k and #b#e50#n #t4000018#s#k?");
				return;
			}
			
			self.say("Incredible! You must be someone special to get that many. Hmm ... alright, the shield is yours. It's my favorite one. Please take good care of it.");
			
			var rewards = new List<(int, int, int)> {
				(1092001, 1, 1),
				(1092000, 1, 9)
			};
			
			var item = rewards.RandomElementByWeight(tuple => tuple.Item3);
			
			if (item == default)
				return;
			
			int itemID = item.Item1;
			
			if (!Exchange(0, 4000003, -30, 4000018, -50, itemID, 1))
			{
				self.say("Are you sure you have the items I asked for? If so, please make space in your equip. inventory.");
			}
			
			AddEXP(50);
			SetQuestData(1000100, "end");
			QuestEndEffect();
		}
	}
	
	private void Blackbull2(string quest)
	{
		if (quest == "")
		{
			self.say("Hey, it's you! Got pretty famous since the last time I saw you, huh? Well thanks to you, I got my house fixed just fine. But hmm ... there's a problem ... all my relatives from #m100000000# want to move to this town. I need to build a new house for them, but I don't even have the materials to build with ...");
			self.say("Well Hey! Sorry to ask you for a favor, but can you get the stuff necessary to build the house for my cousins? So many relatives are coming in that #t4000018# or #t4000003# that you got for me last time won't do. So can you do that for me? I'll tell you what to get.");
			self.say("I'll need #b100 #t4000022#s#k, #b30 #t4003000#s#k, and #b30 \r\n#b#t4003001#s#k. But with only these ... well a couple of days ago, a deed to the land that I purchased disappeared \r\n... my son had it on the way to #m105040300# when he got attacked by the monsters.");
			self.say("A group of reptiles that live in the forests called #r#o3230100##k took the deed to the land. Can you help me get that and the necessary materials to build the house? If so, then you'll be handsomely rewarded for your work ... good luck!");
			SetQuestData(1000101, "p0");
		}
		else if (quest == "p0")
		{
			if (ItemCount(4000022) < 100 || ItemCount(4003000) < 30 || ItemCount(4003001) < 30 || ItemCount(4001004) < 1)
			{
				self.say("Looks like you haven't gotten all the materials needed. Please get #b100 #t4000022#s, 30 #b#t4003000#s, 30 #b#t4003001#s and the lost deed to the land#k. Do it fast, before they eat it ...");
				return;
			}
			
			self.say("THIS is the deed to the land that my son lost! And you even brought all the necessary materials to build the house! Thank you so much ... my relatives can all move in and live in #m102000000#! As a sign of appreciation ...");
			
			int[] rewards = new int[] {2044002, 2043002, 2043102, 2043202, 2044102, 2044202, 2044302, 2044402, 2043702, 2043802, 2044502, 2044602, 2043302, 2044702};
			
			var options = new List<(int, string)>();
			
			if (Job < 200)
			{
				options.Add((0, " #t2044002#"));
				options.Add((1, " #t2043002#"));
				options.Add((2, " #t2043102#"));
				options.Add((3, " #t2043202#"));
				options.Add((4, " #t2044102#"));
				options.Add((5, " #t2044202#"));
				options.Add((6, " #t2044302#"));
				options.Add((7, " #t2044402#"));
			}
			else if (Job >= 200 && Job < 300)
			{
				options.Add((8, " #t2043702#"));
				options.Add((9, " #t2043802#"));
			}
			else if (Job >= 300 && Job < 400)
			{
				options.Add((10, " #t2044502#"));
				options.Add((11, " #t2044602#"));
			}
			else if (Job >= 400)
			{
				options.Add((12, " #t2043302#"));
				options.Add((13, " #t2044702#"));
			}
			
			int selection = AskMenu("Okay, now choose the scroll of your liking ... The odds of winning are 10% each.#b", options.ToArray());
			
			int itemID = rewards[selection];
			
			if (!Exchange(15000, 4000022, -100, 4003000, -30, 4003001, -30, 4001004, -1, itemID, 1))
			{
				self.say("Are you sure you have the items I asked for? If so, please make space in your equip. inventory.");
				return;
			}
			
			AddEXP(1000);
			AddFame(2);
			SetQuestData(1000101, "pe");
			QuestEndEffect();
			self.say($"Hopefully the #b#t{itemID}##k helped. Here's also a little bit of money if that helps. I'll never forget the fact that you helped me. For that, I'll be spreading the good news about your good deed all over the town. What do you think?? Anyway thank you so much for helping me out. We'll probably meet again ...");
		}
	}
	
	private void Blackbull3(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("Hey, it's you! It has been a long time. I see you've grown so much stronger since then. Have you come to hear about the house?");
			
			if (!start)
			{
				self.say("I see... actually there is something I would like to ask you, but maybe another time.");
				return;
			}
			
			SetQuestData(1000102, "200");
			self.say("Well... we recently finished construction on our new home. Everything was going well until a group of Iron Boars began attacking the houses around Perion. Their thick plated armor has left cracks in our walls and I'm worried if we don't stop them, the house could collapse at any time.");
			self.say("Please help me take care of them before it's too late! If you can eliminate around #b200 of them#k and bring back #b100 of their armor#k, we can prevent the house from getting damaged further..");
		}
		else
		{
			if (quest != "000")
			{
				self.say("Have you taken down #r200 Iron Boars#k yet? Please hurry, I'm afraid for my family...");
				return;
			}
			
			if (ItemCount(4000178) < 100)
			{
				self.say("It looks like you haven't collected #b100 of Iron Boar's armor#k yet. Please hurry!");
				return;
			}
			
			self.say("You DID IT! You really took down 200 Iron Boars ... Thank you so much for all your help. Please take this as a sign of appreciation.");
			
			int itemID = 0;
			
			if (Job < 200)
				itemID = 2001001;
			else if (Job >= 200 && Job < 300)
				itemID = 2001002;
			else
				itemID = 2001000;
			
			if (!Exchange(30000, 4000178, -100, itemID, 100))
			{
				self.say("Are you sure you brought the #b100 #t4000178#s#k? Please leave an empty space in your use inventory.");
				return;
			}
			
			AddEXP(25000);
			SetQuestData(1000102, "e");
			QuestEndEffect();
			self.say($"Did you get the #b100 #t{itemID}#s#k? I also gave you a little bit of money, I hope it helps you on your journey. Finally my family is safe in our new home! Come back and see me again when you have time.");
		}
	}
	
	private void Blackbull4(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("Welcome back! Now that there are less Iron Boar roaming the village in Perion, my family is finally safe. My house, however, still has some cracks from the attack. Can you gather the materials needed to fix it?");
			
			if (!start)
			{
				self.say("You must be busy right now. I need to reinforce the walls of my house in case the Iron Boars return, so please come back soon.");
				return;
			}
			
			SetQuestData(1000103, "10");
			self.say("Thank you so much! I would like to reinforce the walls of our house with a strong metal so that this never happens again. Which metal? Well ... at the top of one of Perion's tallest mountains you can find a rare ore called #btungsten#k. If you can gather 10 of the ore I'll be able to fix up my house for good!");
			
			Travel();
		}
		else
		{
			int needOre = Int32.Parse(quest);
			int haveOre = ItemCount(4031142);
			
			if (haveOre < 1)
			{
				self.say($"You don't have any more #b#t4031142##k on you, right? I'll need 10 to fortify my house here in Perion so please bring me #b{needOre}#k more.");
			}
			else if (haveOre >= needOre)
			{
				self.say("You really brought them all!! With these ores, I can make a foundation that will hold for many years. While you were climbing up the mountain, I asked my cousins to help make some armor for your journey. Please take it!");
				
				bool trade = false;
				
				if (Job < 200)
				{
					if (chr.GetGender() == 0)
						trade = Exchange(0, 4031142, -haveOre, 1040087, 1, 1060076, 1);
					else if (chr.GetGender() == 1)
						trade = Exchange(0, 4031142, -haveOre, 1041087, 1, 1061086, 1);
				}
				else if (Job >= 200 && Job < 300)
				{
					if (chr.GetGender() == 0)
						trade = Exchange(0, 4031142, -haveOre, 1050047, 1);
					else if (chr.GetGender() == 1)
						trade = Exchange(0, 4031142, -haveOre, 1051034, 1);
				}
				else if (Job >= 300 && Job < 400)
				{
					if (chr.GetGender() == 0)
						trade = Exchange(0, 4031142, -haveOre, 1050052, 1);
					else if (chr.GetGender() == 1)
						trade = Exchange(0, 4031142, -haveOre, 1051038, 1);
				}
				else if (Job >= 400)
				{
					if (chr.GetGender() == 0)
						trade = Exchange(0, 4031142, -haveOre, 1040096, 1, 1060085, 1);
					else if (chr.GetGender() == 1)
						trade = Exchange(0, 4031142, -haveOre, 1041079, 1, 1061078, 1);
				}
				
				if (!trade)
				{
					self.say("Please make sure there's at least two slots available in your equip. inventory first.");
					return;
				}
				
				AddEXP(40000);
				AddFame(5);
				SetQuestData(1000103, "e");
				QuestEndEffect();
				self.say("Thank you so much for everything you've done for us. I won't forget your dedication to helping me here. You're welcome here anytime you like.");
			}
			else
			{
				self.say("You did find the #b#t4031142##k I asked for! I'll take those off your hands.");
				
				int nNeedOre = needOre - haveOre;
				
				if (!Exchange(0, 4031142, -haveOre))
				{
					self.say("Are you sure you brought the #t4031142#?");
					return;
				}
				
				SetQuestData(1000103, nNeedOre.ToString());
				self.say($"Thanks, I will still need {nNeedOre} more to fortify the house.");
			}
		}
	}
	
	private void Travel()
	{
		bool go = AskYesNo("So ... would you like to head to the base of the mountain? I can take you there anytime.");
		
		if (!go)
		{
			self.say("Okay, please come back and see me when you're ready to go.");
			return;
		}
		
		ChangeMap(102000200);
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1000100)
		{
			if (info != "end")
				return " Fixing \"Blackbull's\" House";
		}
		else if (quest == 1000101)
		{
			string blackbull1 = GetQuestData(1000100);
			
			if ((blackbull1 == "end" && info == "" && Level >= 30 && Fame >= 10) || info == "p0")
				return " Building a New House For \"Blackbull\"";
		}
		else if (quest == 1000102)
		{
			string blackbull2 = GetQuestData(1000101);
			
			if ((blackbull2 == "pe" && info == "" && Level >= 45 && Fame >= 15) || (info != "" && info != "e"))
				return " \"Blackbull's\" Conundrum";
		}
		else if (quest == 1000103)
		{
			string blackbull3 = GetQuestData(1000102);
			
			if (blackbull3 == "e" && info != "e")
				return " Fortifying \"Blackbull's\" New House";
		}
		
		return null;
	}
	
	public override void Run()
	{
		if (MapID != 102000000)
		{
			bool exit = AskYesNo("Are you sure you want to give up now? If you leave you'll have to start over from the beginning.");
			
			if (!exit)
			{
				self.say("That's the spirit! Keep going, I know you can make it to the top.");
				return;
			}
			
			ChangeMap(102000000);
			return;
		}
		
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1000100, 1000101, 1000102, 1000103};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		if (GetQuestData(1000103) != "" && ItemCount(4031142) < 1)
			options.Add((4, " Go to the mountains"));
		
		string dialogue = "Our family grew, and I'll have to fix the house to make it bigger, but I need materials to do so...";
		
		if (GetQuestData(1000101) == "pe")
			dialogue = "Hey, it's you! Thanks to you, the building of the house for my cousins are well on their way. You should come check it out when it's completed.";
		
		if (GetQuestData(1000102) == "e")
			dialogue = "Thanks for taking down the Iron Hog, now I just have to find a way to reinforce the foundation ...";
		
		if (GetQuestData(1000103) == "e")
			dialogue = "Thanks to you, our house will stand strong for years to come. I can't thank you enough for everything you've done for us. Come back and see me again sometime.";
		
		if (options.Count == 0)
		{
			self.say(dialogue);
			return;
		}
		
		int choice = -1;
		
		if (options.Count >= 2 || options.Contains((4, " Go to the mountains")))
			choice = AskMenu($"{dialogue}#b", options.ToArray());
		else
			choice = options[0].Index;
		
		switch(choice)
		{
			case 0: Blackbull1(GetQuestData(1000100)); break;
			case 1: Blackbull2(GetQuestData(1000101)); break;
			case 2: Blackbull3(GetQuestData(1000102)); break;
			case 3: Blackbull4(GetQuestData(1000103)); break;
			case 4: Travel(); break;
		}
	}
}