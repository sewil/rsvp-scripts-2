using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Shop(int item, int unitPrice, string itemOption)
	{
		int amount = AskInteger(1, 1, 100, $"You want #b#t{item}##k? #t{item}# allows you to recover {itemOption}. How many do you want to buy?");
			
		int nPrice = unitPrice * amount;
		
		bool askBuy = AskYesNo($"You want to buy #r{amount}#k #b#t{item}#(s)#k? #b#t{item}##k costs {unitPrice:n0} per unit, so the total will be #b{nPrice:n0}#k mesos.");
		
		if (!askBuy)
		{
			self.say("I still have some of the materials you got for me. It's all here, so come back when you've made a choice.");
			return;
		}
		
		if (!Exchange(-nPrice, item, amount))
		{
			self.say($"Are you lacking in funds by chance? Please make sure you have an empty slot in your use inventory and if you have at least #r{nPrice:n0}#k mesos.");
			return;
		}
		
		self.say("Thanks for coming! I'm always open for business here, so if you need something, come back, okay?");
	}
	
	public override void Run()
	{
		string jane1 = GetQuestData(1000400);
		string jane2 = GetQuestData(1000401);
		
		if (jane2 == "je")
		{
			self.say("It's you... thanks to you I was able to make a lot of stuff. Currently I'm making a couple different items. If you need anything, just let me know.");
			int selection = AskMenu("Which item would you like to buy?#b",
				(0, " #t2000002# (price: 310 mesos)"),
				(1, " #t2022003# (price: 1,060 mesos)"),
				(2, " #t2022000# (price: 1,600 mesos)"),
				(3, " #t2001000# (price: 3,120 mesos)"));
				
			switch(selection)
			{
				case 0: Shop(2000002, 310, "300 HP"); break;
				case 1: Shop(2022003, 1060, "1,000 HP"); break;
				case 2: Shop(2022000, 1600, "800 HP"); break;
				case 3: Shop(2001000, 3120, "\r\n1,000 HP and MP"); break;
			}
		}
		else if (jane2 == "j4")
		{
			if (ItemCount(4000030) < 20 || ItemCount(4011007) < 1 || ItemCount(2012002) < 10)
			{
				self.say("You haven't collected #b1 #t4011007##k, #b20 #t4000030#s#k, and#b 10 #t2012002#s#k, yet. You should be able to acquire all of them from monsters. Keep trying!");
				return;
			}
			
			self.say("You have gotten #b1 #t4011007##k, #b20 #t4000030#s#k, and #b10 Saps of Ancient Tree#k. Good! Thanks. Please wait. I need to get this started...");
			self.say("Okay I have made this. You know this is only my third time doing this, so I am not sure it is good or not. However, as I promised, whatever this is, I will give it to you. Please check and see if you have an extra slot on your use inventory.");
			
			if (SlotCount(2) < 1)
			{
				self.say("Please leave a space open in your use inventory~");
				return;
			}
			
			Random rnd = new Random();
			int[] item = {2040805, 2040804};
			
			int itemID = item[rnd.Next(item.Length)];
			
			if (!Exchange(0, 4011007, -1, 4000030, -20, 2012002, -10, itemID, 1))
			{
				self.say("Huh? Are you sure you brought all the items?");
				return;
			}
			
			AddEXP(1000);
			SetQuestData(1000401, "je");
			QuestEndEffect();
			
			if (itemID == 2040805)
			{
				self.say("Wow... I have a talent for this or what? I have made 1 #r#t2040805##k! You have been a great help for me. Thanks ~");
			}
			else if (itemID == 2040804)
			{
				self.say("Hm... it didn't turn out the way I thought... I have made 1 #r#t2040804##k. That is still pretty good~ You have been a great help for me. Thanks ~");
			}
		}
		else if (jane2 == "j3")
		{
			bool askStart4 = AskYesNo("Are you using those items I gave you? I want to make a more complicated stuff for the last time. Can you please me?");
			
			if (!askStart4)
			{
				self.say("Okay... Now you don't have time to listen to a girl like me... Well... Okay... If you change your mind, please get back to me... Thanks...");
				return;
			}
			
			SetQuestData(1000401, "j4");
			self.say("Thanks. Would you please get 1 #b#t4011007##k, 20 Dragon Skins#k, 10 #b#t2012002##k, first? If I do it well, I would probably make a scroll.");
		}
		else if (jane2 == "j2")
		{
			if (ItemCount(2012000) < 3 || ItemCount(4000040) < 1 || ItemCount(4000041) < 30 || ItemCount(4000036) < 100)
			{
				self.say("You haven't collected #b30 #t4000041##k, #b1 \r\n#t4000040##k, #b3 bottles of #t2012000##k, and #b100 Medicines with Weird Vibes#k, yet. You should be able to acquire all of them from monsters. Keep trying!");
				return;
			}
			
			self.say("You have gotten #b30 #t4000041##k, #b1 \r\n#t4000040##k, #b3 bottles of #t2012000##k, and #b100 Medicines with Weird Vibes#k. Good! Thanks. Now I need to do my part and mix them up!");
			self.say("Okay I have made this. You know this is only my second time doing this, so I am not sure it is good or not. However, as I promised, whatever this is, I will give it to you. Please check and see if you have an extra slot on your use inventory.");
			
			if (SlotCount(2) < 1)
			{
				self.say("Please leave a space open in your use inventory~");
				return;
			}
			
			Random rnd = new Random();
			int[] item = {2000005, 2000006};
			
			int itemID = item[rnd.Next(item.Length)];
			
			if (!Exchange(0, 4000040, -1, 2012000, -3, 4000036, -100, 4000041, -30, itemID, 15))
			{
				self.say("Huh? Are you sure you brought all the items?");
				return;
			}
			
			AddEXP(600);
			SetQuestData(1000401, "j3");
			
			if (itemID == 2000005)
			{
				self.say("Wow... I have a talent for this or what? I have made 15 \r\n#r#t2000005##k. My second experiment was a great success~ Thanks for your help~");
			}
			else if (itemID == 2000006)
			{
				self.say($"Hm... it didn't turn out the way I thought... I have made 15 #r#t2000006##k. My second experiment was a failure, but maybe it will work out next time. Thanks for your help~");
			}
		}
		else if (jane2 == "j1")
		{
			bool askStart3 = AskYesNo("Are you using those items I gave you? I want to make a more complicated stuff. Can you please me, just like the other time?");
			
			if (!askStart3)
			{
				self.say("Okay... Now you don't have time to listen to a girl like me... Well... Okay... If you change your mind, please get back to me... Thanks...");
				return;
			}
			
			SetQuestData(1000401, "j2");
			self.say("Thanks. Would you please get me #b30 #t4000041##k, #b1 #t4000040##k, #b3 #t2012000#s#k, and #b100 Medicines with Weird Vibes#k? If I do it well, I would probably make a #t2000005#.");
		}
		else if (jane2 == "j0")
		{
			if (ItemCount(2022000) < 1 || ItemCount(4000041) < 20 || ItemCount(4000036) < 30)
			{
				self.say("You haven't collected #b1 #t2022000##k, #b30 #t4000036##k, and #b20 #t4000041#s#k, yet. I heard someone is selling #t2022000#. You should get the other two from the monsters.");
				return;
			}
			
			self.say("You have gotten #b1 #t2022000##k, #b30 Medicines with Weird Vibes#k, and #b20 #t4000041##k. Good! Thanks. Now I got to do my part and mix up these babies...");
			self.say("Okay I have made this. You know this is my first time. So I am not sure it is good or not. However, as I promised, whatever this is, I will give it to you. Please check and see if you have an extra slot on your use inventory.");
			
			if (SlotCount(2) < 1)
			{
				self.say("Please make some room in your use inventory first.");
				return;
			}
			
			Random rnd = new Random();
			int[] item = {2000004, 2000000};
			
			int itemID = item[rnd.Next(item.Length)];
			
			if (!Exchange(0, 2022000, -1, 4000036, -30, 4000041, -20, itemID, 10))
			{
				self.say("Huh? Are you sure you brought all the items?");
				return;
			}
			
			AddEXP(300);
			SetQuestData(1000401, "j1");
			
			if (itemID == 2000004)
			{
				self.say($"Wow... I have a talent for this or what? I have made 10 #r#t2000004##k. My first experiment was a great success~ Thanks for your help~");
			}
			else if (itemID == 2000000)
			{
				self.say($"Hm... it didn't turn out the way I thought... I have made 10 #r#t2000000##k. My first experiment was a failure, but maybe it will work out next time. Thanks for your help~");
			}
		}
		else if (jane2 == "")
		{
			if (jane1 == "end")
			{
				if (Level < 40)
				{
					self.say("Oh! You are the one who helped me on the other day! Long time no see~ How have you been? You get me all those items to help me, but my dad still have not allowed me to travel by myself... But I really appreciate that you helped me...");
					return;
				}
				
				self.say("You look much stronger... I envy you... I must have started traveling then... ha.... Anyway, I want to ask you for another favor if you don't mind... Do you have time?");
				self.say("After I gave up my dream to be a traveler, I have another dream. Yeah... Being a traveler is pretty hard for an weak girl like me... Anyway, my new dream is to be a good alchemist. Someday I will be a better alchemy than Maria in #m102000000#.");
				self.say("Alchemist doesn't have to go through all the danger like traveler, so my dad doesn't go against it... Oh do you know what alchemist is? I will just briefly explain it to you.");
				self.say("Alchemist can handle every matter in the world and make a special item by combining the materials.");
				bool askStart2 = AskYesNo("Therefore... I need many materials to practice... Would you please get those materials if you are not busy? I will give you everything I make, in return. Even though I don't know what that will be... How about that?");
				
				if (!askStart2)
				{
					self.say("Okay... Now you don't have time to listen to a girl like me... Well... Okay... If you change your mind, please get back to me... Thanks...");
					return;
				}
				
				SetQuestData(1000401, "j0");
				self.say("Thanks. Would you please get me #b1 #t2022000##k, #b30 Medicines with Weird Vibes#k, and #b20 #t4000041##k? If I do it well, I would probably make an #t2000004#.");
			}
			else if (jane1 == "j")
			{
				if (ItemCount(4000015) < 120 || ItemCount(4000020) < 100)
				{
					self.say("If you get #e100#n #b#t4000020##k and #e120#n #b#t4000015##k, I can start traveling... Please I beg you... ");
					return;
				}
				
				self.say("Wow... You have beaten so many #o2230102# and #o2110200#... Incredible~ I can tell my dad that I am strong enough to travel by myself. Thanks~! ");
				self.say("Wait! I must have forgotten... You have done all these for \r\nme... I will give you something that I have kept for long time. This might help you.");
				
				if (SlotCount(2) < 1)
				{
					self.say("Please make some room in your use inventory for my reward.");
					return;
				}
				
				Random rnd = new Random();
				int[] scrolls = {2044501, 2044601, 2043001, 2043101, 2043201, 2043301, 2044001, 2044101, 2044201, 2044301, 2044401, 2043701, 2043801, 2044701};
				
				int itemID = scrolls[rnd.Next(scrolls.Length)];
				
				if (!Exchange(0, 4000020, -100, 4000015, -120, itemID, 1))
				{
					self.say("Are you sure you have the items from #o2230102# and #o2110200#..?");
					return;
				}
				
				AddEXP(500);
				SetQuestData(1000400, "end");
				QuestEndEffect();
				self.say("This scroll ... I think it has the power to strengthen a certain weapon. It's easy to use. All you need to do is open both the use tab and the equipment inventory at once ... then drag the scroll onto the equipment that you're wearing. There's a chance that it may not work, so be careful with it.");
			}
			else if (jane1 == "" && Level >= 25 && Job > 0)
			{
				self.say("I have always wanted to travel around just like you... but my dad doesn't let me... I have prepared for this for like years... What should I do?");
				self.say("You look pretty strong! Can you do me a favor? Would you please get #b100 Wild Boar Teeth#k and #b120 #t4000015#s#k for me? If I show those to my dad, he would probably let me travel. Please I beg you.");
				self.say("Oh.... #t4000020# looks like #i4000020# and #t4000015# looks like #i4000015#. You would probably get those from #o2230102# and #o2110200#. You got it?");
				SetQuestData(1000400, "j");
			}
			else
			{
				self.say("My dream is to travel all over the world, just like you. But my dad won't let me because he thinks that it's too dangerous. Maybe he'll let me go if I show him somehow that I'm not the weak girl he thinks I am...");
			}
		}
	}
}