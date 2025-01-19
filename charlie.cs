using System;
using WvsBeta.Game;

// 2010000 Staff Sergeant Charlie
public class NpcScript : IScriptV2
{
	private void ReplaceItem(int itemCode)
	{
		bool askStart2 = AskYesNo($"Let's see, you want to exchange your #b100 #t{itemCode}#s#k for what I have, right? Before the trade, make sure you have a free slot in your use and etc. inventories. So, do you really want to trade?");
		
		if (!askStart2)
		{
			self.say("Hmmm... it won't be bad for you. If you come and see me at the right time, I'll have great items. Anyway, when you want to trade, come to me.");
			return;
		}
		
		Random rnd = new Random();
		
		int newItemID = 0;
		int newItemNum = 0;
		
		// Hard Horn
		if (itemCode == 4000073)
		{
			int[] item = {2000001, 2000003, 2020001, 2010004, 4003001, 2030000};
			int[] count = {20, 15, 15, 10, 15, 15};
			
			int rnum = rnd.Next(item.Length);
			
			newItemID = item[rnum];
			newItemNum = count[rnum];
		}
		// Star Pixie's Piece of Star or Flying Eye's Wings
		else if (itemCode == 4000059 || itemCode == 4000076)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 25)
			{
				newItemID = 2000001;
				newItemNum = 30;
			}
			else if (rnum <= 50)
			{
				newItemID = 2000003;
				newItemNum = 20;
			}
			else if (rnum <= 75)
			{
				newItemID = 2010001;
				newItemNum = 40;
			}
			else if (rnum <= 99)
			{
				newItemID = 4003001;
				newItemNum = 20;
			}
			else
			{
				newItemID = 2040002;
				newItemNum = 1;
			}
		}
		// Nependeath's Seed
		else if (itemCode == 4000058)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 25)
			{
				newItemID = 2000002;
				newItemNum = 15;
			}
			else if (rnum <= 50)
			{
				newItemID = 2000003;
				newItemNum = 25;
			}
			else if (rnum <= 75)
			{
				newItemID = 2010004;
				newItemNum = 15;
			}
			else if (rnum <= 99)
			{
				newItemID = 4003001;
				newItemNum = 30;
			}
			else
			{
				newItemID = 2040302;
				newItemNum = 1;
			}
		}
		// Jr. Bulldog's Tooth
		else if (itemCode == 4000078)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 20)
			{
				newItemID = 2000002;
				newItemNum = 15;
			}
			else if (rnum <= 40)
			{
				newItemID = 2000003;
				newItemNum = 25;
			}
			else if (rnum <= 60)
			{
				newItemID = 2010004;
				newItemNum = 15;
			}
			else if (rnum <= 80)
			{
				newItemID = 4003001;
				newItemNum = 30;
			}
			else if (rnum <= 99)
			{
				newItemID = 2050004;
				newItemNum = 15;
			}
			else
			{
				newItemID = 2040302;
				newItemNum = 1;
			}
		}
		// Lunar Pixie's Piece of Moon
		else if (itemCode == 4000060)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 25)
			{
				newItemID = 2000002;
				newItemNum = 25;
			}
			else if (rnum <= 50)
			{
				newItemID = 2000006;
				newItemNum = 10;
			}
			else if (rnum <= 75)
			{
				newItemID = 2022000;
				newItemNum = 5;
			}
			else if (rnum <= 99)
			{
				newItemID = 4000030;
				newItemNum = 15;
			}
			else
			{
				newItemID = 2040902;
				newItemNum = 1;
			}
		}
		// Jr. Yeti's Skin or Dark Nependeath's Seed
		else if (itemCode == 4000048 || itemCode == 4000062)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 25)
			{
				newItemID = 2000002;
				newItemNum = 30;
			}
			else if (rnum <= 50)
			{
				newItemID = 2000006;
				newItemNum = 15;
			}
			else if (rnum <= 75)
			{
				newItemID = 2020000;
				newItemNum = 20;
			}
			else if (rnum <= 99)
			{
				newItemID = 4003000;
				newItemNum = 5;
			}
			else
			{
				newItemID = 2040402;
				newItemNum = 1;
			}
		}
		// Fireball's Flame
		else if (itemCode == 4000081)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 15)
			{
				newItemID = 2000006;
				newItemNum = 25;
			}
			else if (rnum <= 30)
			{
				newItemID = 2020006;
				newItemNum = 25;
			}
			else if (rnum <= 45)
			{
				newItemID = 4010004;
				newItemNum = 8;
			}
			else if (rnum <= 60)
			{
				newItemID = 4010005;
				newItemNum = 8;
			}
			else if (rnum <= 75)
			{
				newItemID = 4010006;
				newItemNum = 3;
			}
			else if (rnum <= 90)
			{
				newItemID = 4020008;
				newItemNum = 3;
			}
			else if (rnum <= 95)
			{
				newItemID = 4020007;
				newItemNum = 2;
			}
			else
			{
				newItemID = 2040705;
				newItemNum = 1;
			}
		}
		// Luster Pixie's Piece of Sun
		else if (itemCode == 4000061)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 25)
			{
				newItemID = 2000002;
				newItemNum = 30;
			}
			else if (rnum <= 50)
			{
				newItemID = 2000006;
				newItemNum = 15;
			}
			else if (rnum <= 75)
			{
				newItemID = 2020000;
				newItemNum = 20;
			}
			else if (rnum <= 99)
			{
				newItemID = 4003000;
				newItemNum = 5;
			}
			else
			{
				newItemID = 2041016;
				newItemNum = 1;
			}
		}
		// Cellion's Tail or Lioner's Tail or Grupin's Tail
		else if (itemCode == 4000070 || itemCode == 4000071 || itemCode == 4000072)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 25)
			{
				newItemID = 2000002;
				newItemNum = 30;
			}
			else if (rnum <= 50)
			{
				newItemID = 2000006;
				newItemNum = 15;
			}
			else if (rnum <= 75)
			{
				newItemID = 2020000;
				newItemNum = 20;
			}
			else if (rnum <= 99)
			{
				newItemID = 4003000;
				newItemNum = 5;
			}
			else
			{
				newItemID = 2041005;
				newItemNum = 1;
			}
		}
		// Hector's Tail 
		else if (itemCode == 4000051)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 35)
			{
				newItemID = 2002004;
				newItemNum = 15;
			}
			else if (rnum <= 70)
			{
				newItemID = 2002005;
				newItemNum = 15;
			}
			else if (rnum <= 97)
			{
				newItemID = 2002003;
				newItemNum = 10;
			}
			else if (rnum <= 99)
			{
				newItemID = 4001005;
				newItemNum = 1;
			}
			else
			{
				newItemID = 2040502;
				newItemNum = 1;
			}
		}
		// Dark Jr. Yeti's Skin
		else if (itemCode == 4000055)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 35)
			{
				newItemID = 2022001;
				newItemNum = 30;
			}
			else if (rnum <= 70)
			{
				newItemID = 2020006;
				newItemNum = 15;
			}
			else if (rnum <= 97)
			{
				newItemID = 2020005;
				newItemNum = 30;
			}
			else if (rnum <= 99)
			{
				newItemID = 4003003;
				newItemNum = 1;
			}
			else
			{
				newItemID = 2040505;
				newItemNum = 1;
			}
		}
		// Zombie's Lost Tooth
		else if (itemCode == 4000069)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 25)
			{
				newItemID = 2050004;
				newItemNum = 20;
			}
			else if (rnum <= 50)
			{
				newItemID = 2000006;
				newItemNum = 20;
			}
			else if (rnum <= 75)
			{
				newItemID = 2020006;
				newItemNum = 15;
			}
			else if (rnum <= 98)
			{
				newItemID = 2020005;
				newItemNum = 30;
			}
			else if (rnum <= 99)
			{
				newItemID = 4003003;
				newItemNum = 1;
			}
			else
			{
				newItemID = 2041002;
				newItemNum = 1;
			}
		}
		// White Pang's Tail
		else if (itemCode == 4000052)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 40)
			{
				newItemID = 2000006;
				newItemNum = 20;
			}
			else if (rnum <= 60)
			{
				newItemID = 4010003;
				newItemNum = 7;
			}
			else if (rnum <= 80)
			{
				newItemID = 4010004;
				newItemNum = 7;
			}
			else if (rnum <= 97)
			{
				newItemID = 4010005;
				newItemNum = 7;
			}
			else if (rnum <= 99)
			{
				newItemID = 4003002;
				newItemNum = 1;
			}
			else
			{
				newItemID = 2040602;
				newItemNum = 1;
			}
		}
		// Pepe's Beek
		else if (itemCode == 4000050)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 30)
			{
				newItemID = 2000006;
				newItemNum = 20;
			}
			else if (rnum <= 45)
			{
				newItemID = 4010000;
				newItemNum = 7;
			}
			else if (rnum <= 60)
			{
				newItemID = 4010001;
				newItemNum = 7;
			}
			else if (rnum <= 79)
			{
				newItemID = 4010002;
				newItemNum = 7;
			}
			else if (rnum <= 99)
			{
				newItemID = 4010006;
				newItemNum = 2;
			}
			else
			{
				newItemID = 2040702;
				newItemNum = 1;
			}
		}
		// Dark Pepe's Beek
		else if (itemCode == 4000057)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 30)
			{
				newItemID = 2000006;
				newItemNum = 20;
			}
			else if (rnum <= 50)
			{
				newItemID = 4010004;
				newItemNum = 7;
			}
			else if (rnum <= 62)
			{
				newItemID = 4010005;
				newItemNum = 7;
			}
			else if (rnum <= 74)
			{
				newItemID = 4010006;
				newItemNum = 3;
			}
			else if (rnum <= 86)
			{
				newItemID = 4020008;
				newItemNum = 2;
			}
			else if (rnum <= 99)
			{
				newItemID = 4020007;
				newItemNum = 2;
			}
			else
			{
				newItemID = 2040705;
				newItemNum = 1;
			}
		}
		// Yeti's Horn
		else if (itemCode == 4000049)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 30)
			{
				newItemID = 2000006;
				newItemNum = 25;
			}
			else if (rnum <= 50)
			{
				newItemID = 4020000;
				newItemNum = 7;
			}
			else if (rnum <= 65)
			{
				newItemID = 4020001;
				newItemNum = 7;
			}
			else if (rnum <= 85)
			{
				newItemID = 4020002;
				newItemNum = 3;
			}
			else if (rnum <= 99)
			{
				newItemID = 4020007;
				newItemNum = 2;
			}
			else
			{
				newItemID = 2040708;
				newItemNum = 1;
			}
		}
		// Dark Yeti's Horn
		else if (itemCode == 4000056)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 30)
			{
				newItemID = 2000006;
				newItemNum = 25;
			}
			else if (rnum <= 50)
			{
				newItemID = 4020003;
				newItemNum = 7;
			}
			else if (rnum <= 65)
			{
				newItemID = 4020004;
				newItemNum = 7;
			}
			else if (rnum <= 85)
			{
				newItemID = 4020005;
				newItemNum = 7;
			}
			else if (rnum <= 99)
			{
				newItemID = 4020008;
				newItemNum = 2;
			}
			else
			{
				newItemID = 2040802;
				newItemNum = 1;
			}
		}
		// Bulldog's Tooth
		else if (itemCode == 4000079)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 15)
			{
				newItemID = 2000006;
				newItemNum = 25;
			}
			else if (rnum <= 30)
			{
				newItemID = 2022001;
				newItemNum = 35;
			}
			else if (rnum <= 45)
			{
				newItemID = 4020000;
				newItemNum = 8;
			}
			else if (rnum <= 60)
			{
				newItemID = 4020001;
				newItemNum = 8;
			}
			else if (rnum <= 75)
			{
				newItemID = 4020002;
				newItemNum = 8;
			}
			else if (rnum <= 90)
			{
				newItemID = 4020007;
				newItemNum = 2;
			}
			else if (rnum <= 99)
			{
				newItemID = 2050004;
				newItemNum = 30;
			}
			else
			{
				newItemID = 2041023;
				newItemNum = 1;
			}
		}
		// Werewolf's Toenail
		else if (itemCode == 4000053)
		{
			int rnum = rnd.Next(1, 100);
			if (rnum <= 37)
			{
				newItemID = 2000006;
				newItemNum = 30;
			}
			else if (rnum <= 57)
			{
				newItemID = 4020006;
				newItemNum = 7;
			}
			else if (rnum <= 77)
			{
				newItemID = 4020007;
				newItemNum = 2;
			}
			else if (rnum <= 97)
			{
				newItemID = 4020008;
				newItemNum = 2;
			}
			else if (rnum <= 99)
			{
				newItemID = 2070010;
				newItemNum = 1;
			}
			else
			{
				newItemID = 2040805;
				newItemNum = 1;
			}
		}
		// Lycanthrope's Toenail
		else if (itemCode == 4000054)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 37) {
				newItemID = 2000006;
				newItemNum = 30;
			}
			else if (rnum <= 57)
			{
				newItemID = 4020006;
				newItemNum = 7;
			}
			else if (rnum <= 77)
			{
				newItemID = 4020007;
				newItemNum = 2;
			}
			else if (rnum <= 97)
			{
				newItemID = 4020008;
				newItemNum = 2;
			}
			else if (rnum <= 99)
			{
				newItemID = 2070010;
				newItemNum = 1;
			}
			else
			{
				newItemID = 2041020;
				newItemNum = 1;
			}
		}
		// Firedawg's necklace
		else if (itemCode == 4000080)
		{
			int rnum = rnd.Next(1, 101);
			
			if (rnum <= 37)
			{
				newItemID = 2000006;
				newItemNum = 35;
			}
			else if (rnum <= 57)
			{
				newItemID = 4020006;
				newItemNum = 9;
			}
			else if (rnum <= 77)
			{
				newItemID = 4020007;
				newItemNum = 4;
			}
			else if (rnum <= 97)
			{
				newItemID = 4020008;
				newItemNum = 4;
			}
			else if (rnum <= 99)
			{
				newItemID = 2070011;
				newItemNum = 1;
			}
			else
			{
				newItemID = 2041008;
				newItemNum = 1;
			}
		}
		
		if (SlotCount(2) < 1 || SlotCount(4) < 1)
		{
			self.say("Your etc. or use inventory seems to be full. You need a free space to trade with me! Make space and find me.");
			return;
		}
		
		if (!Exchange(0, itemCode, -100, newItemID, newItemNum))
		{
			self.say($"Hmmm... Are you sure that you collected #b100 #t{itemCode}#s#k? If so, make sure your inventory isn't full.");
			return;
		}
		
		AddEXP(500);
		QuestEndEffect();
		self.say($"For your #b100 #t{itemCode}#s#k, here is my #b{newItemNum} #t{newItemID}#(s)#k. What do you think? Did you like the item I gave in exchange? I must stay here for a while, so if you have more items, I'm always willing to negotiate...");
	}
	
	private void StartExchange()
	{
		self.say("Hey, you have a moment? Well, my job is to collect items here and sell them elsewhere, but lately the monsters have become more hostile and it's been very difficult to get good items... What do you think? Want to do business with me?");
		bool askStart = AskYesNo("The trade is simple. You get something I need and I'll give you something you need. The problem is that I deal with a lot of people. So the items I have to offer can change every time we meet. What do you think? Still want to do it?");
		
		if (!askStart)
		{
			self.say("Hmmm... it won't be bad for you. Find me when you're sure you want to get much better items. But let me know when you change your mind.");
			return;
		}
		
		int askTrade = AskMenu("Ok! First, you need to choose the item you want to trade. The better the item, the greater the chance of getting a better item in return.#b",
			(0, " 100 #t4000073#s"),
			(1, " 100 #t4000059#s"),
			(2, " 100 #t4000076#s"),
			(3, " 100 #t4000058#s"),
			(4, " 100 #t4000078#s"),
			(5, " 100 #t4000060#s"),
			(6, " 100 #t4000062#s"),
			(7, " 100 #t4000048#s"),
			(8, " 100 #t4000081#s"),
			(9, " 100 #t4000061#s"),
			(10, " 100 #t4000070#s"),
			(11, " 100 #t4000071#s"),
			(12, " 100 #t4000072#s"),
			(13, " 100 #t4000051#s"),
			(14, " 100 #t4000055#s"),
			(15, " 100 #t4000069#s"),
			(16, " 100 #t4000052#s"),
			(17, " 100 #t4000050#s"),
			(18, " 100 #t4000057#s"),
			(19, " 100 #t4000049#s"),
			(20, " 100 #t4000056#s"),
			(21, " 100 #t4000079#s"),
			(22, " 100 #t4000053#s"),
			(23, " 100 #t4000054#s"),
			(24, " 100 #t4000080#s"));
		
		switch(askTrade)
		{
			case 0: ReplaceItem(4000073); break;
			case 1: ReplaceItem(4000059); break;
			case 2: ReplaceItem(4000076); break;
			case 3: ReplaceItem(4000058); break;
			case 4: ReplaceItem(4000078); break;
			case 5: ReplaceItem(4000060); break;
			case 6: ReplaceItem(4000062); break;
			case 7: ReplaceItem(4000048); break;
			case 8: ReplaceItem(4000081); break;
			case 9: ReplaceItem(4000061); break;
			case 10: ReplaceItem(4000070); break;
			case 11: ReplaceItem(4000071); break;
			case 12: ReplaceItem(4000072); break;
			case 13: ReplaceItem(4000051); break;
			case 14: ReplaceItem(4000055); break;
			case 15: ReplaceItem(4000069); break;
			case 16: ReplaceItem(4000052); break;
			case 17: ReplaceItem(4000050); break;
			case 18: ReplaceItem(4000057); break;
			case 19: ReplaceItem(4000049); break;
			case 20: ReplaceItem(4000056); break;
			case 21: ReplaceItem(4000079); break;
			case 22: ReplaceItem(4000053); break;
			case 23: ReplaceItem(4000054); break;
			case 24: ReplaceItem(4000080); break;
		}
	}
	
	public override void Run()
	{
		string quest = GetQuestData(1001400);
		
		if (quest != "" && !quest.Contains("end"))
		{
			int askQuest = AskMenu("How can I help you today?#b",
				(0, " Alpha Platoon's Network of Communication"),
				(1, " I would like to exchange..."));
			
			if (askQuest == 0)
			{
				if (quest == "s" || quest == "10" || quest == "100" || quest == "120" || quest == "210")
				{
					self.say("What? You came all the way here by #b#p2020003#'s#k request? I thought I was the only survivor. I knew that nothing can hurt #b#p2020003##k. HAHA!");
					self.say("It is good to hear that he is alive. So he is working at El Nath huh? Okay... I found #b#t4031049##k and this would be somewhat related to our mission.");
					bool meetAlpha = AskYesNo("So #b#p2020003##k will also be wating for this. I will give this to you if you give me 2 #b#t4011005#. You can't say that you have met me without this.");
					
					if (meetAlpha)
					{
						if (!Exchange(0, 4011005, -2, 4031049, 1))
						{
							self.say("Oh... are you sure you have #b2 #t4011005#s#k? If not then see if your etc. inventory is full or not, then come talk to me!");
							return;
						}
						
						AddEXP(3000);
						
						if (quest == "s")
						{
							SetQuestData(1001400, "1");
							self.say("Okay... Now, you gotta meet #p2030001# and #p2030002#... right? They must have found something like me. So long~");
						}
						else if (quest == "10")
						{
							SetQuestData(1001400, "12");
							self.say("Okay... Now, you gotta meet #p2030002#... right? He must have found something like me. So long~");
						}
						else if (quest == "100")
						{
							SetQuestData(1001400, "102");
							self.say("Okay... Now, you gotta meet #p2030001#... right? He must have found something like me. So long~");
						}
						else if (quest == "120")
						{
							SetQuestData(1001400, "123");
							self.say("I guess you've met all the troopers of the Alpha platoon! I'm sure the other men are just doing their job. Now please notify #b#p2020003##k of our whereabouts. Thanks!");
						}
						else if (quest == "210")
						{
							SetQuestData(1001400, "213");
							self.say("I guess you've met all the troopers of the Alpha platoon! I'm sure the other men are just doing their job. Now please notify #b#p2020003##k of our whereabouts. Thanks!");
						}
					}
				}
				else
				{
					self.say("Did you get #b#p2020003##k the #b#t4031049##k I asked you for? Do I have anything more to ask for? Hmmm ... none for now. Come back again sometime~!");
				}
			}
			else
			{
				StartExchange();
			}
		}
		else
		{
			StartExchange();
		}
	}
}