using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void EasterYellow()
	{
		string quest = GetQuestData(8020004);
		
		if (quest == "s")
		{
			if (ItemCount(4031283) < 1 || ItemCount(2022065) < 10)
			{
				self.say("You trying to scam me! I need #b10 Yellow Easter Eggs#k and #b1 Easter Basket#k! Remember the plan?");
				return;
			}
			
			self.say("I see that you have the #bEaster Basket#k and the #b10 Yellow Easter Eggs#k like I asked you to get. I'm sure it was a piece of cake for you to get all those.");
			
			if (!ExchangeEx(0, "2022065", -10, "4031283", -1, "4120001,Period:129600", 1))
			{
				self.say("Check your pockets. You'll need some room in your etc. for what I'm about to give you.");
				return;
			}
			
			AddEXP(3100);
			SetQuestData(8020004, "end");
			SetQuestData(8021001, DateTime.UtcNow.ToString("yyyyMMdd"));
			QuestEndEffect();
			self.say("My posse and I will be putting these to good use, if you know what I mean. Oh yeah? I always pay my debts on time. Talk to me later and we'll do it again.");
		}
		else
		{
			self.say("Yeah, you heard me right, I hate Easter. I come from a long line of Easter Bunny's, but I'm not down with all that painting and scavenger hunting nonsense.\r\nDon't get me wrong. I did my time at Easter Bunny School, but they told me I don't have painting skills. I got skillz... graffiti skillz that is!");
			bool start = AskYesNo("Besides, you think I want to walk around all night climbing trees and looking for bushes to plant some stupid boiled eggs. Hells no! You should join my crew and take down Easter. If you do, I'll hook you up.");
			
			if (!start)
			{
				self.say("You just wasted my breath. Get lost!");
				return;
			}
			
			SetQuestData(8020004, "s");
			self.say("Good. My cousin is an Easter Bunny and he's been planting eggs all week long. What's worse is that his buddy has been giving away Easter Baskets. Get me #b10 Yellow Easter Eggs#k and #b1 Easter Basket#k and I'll give you something worth your while!");
		}
	}
	
	private void EasterGreen()
	{
		string quest = GetQuestData(8020005);
		
		if (quest == "s")
		{
			if (ItemCount(4031283) < 1 || ItemCount(2022066) < 10)
			{
				self.say("You trying to scam me? I need #b10 Green Easter Eggs#k and #b1 Easter Basket#k! Remember the plan?");
				return;
			}
			
			self.say("I see that you have the #bEaster Basket#k and the #b10 Green Easter Eggs#k like I asked you to get. I?m sure it was a piece of cake for you to get all those.");
			
			if (!ExchangeEx(0, "2022066", -10, "4031283", -1, "4120001,Period:129600", 1))
			{
				self.say("Check your pockets. You'll need some room in your etc. for what I'm about to give you.");
				return;
			}
			
			AddEXP(4300);
			SetQuestData(8020005, "end");
			SetQuestData(8021001, DateTime.UtcNow.ToString("yyyyMMdd"));
			QuestEndEffect();
			self.say("My posse and I will be putting these to good use, if you know what I mean. Oh yeah? I always pay my debts on time. Talk to me later and we?ll do it again.");
		}
		else
		{
			self.say("Yeah, you heard me right, I hate Easter. I come from a long line of Easter Bunny's, but I'm not down with all that painting and scavenger hunting nonsense.\r\nDon't get me wrong. I did my time at Easter Bunny School, but they told me I don't have painting skills. I got skillz... graffiti skillz that is!");
			bool start = AskYesNo("Besides, you think I want to walk around all night climbing trees and looking for bushes to plant some stupid boiled eggs. Hells no! You should join my crew and take down Easter. If you do, I'll hook you up.");
			
			if (!start)
			{
				self.say("You just wasted my breath. Get lost!");
				return;
			}
			
			SetQuestData(8020005, "s");
			self.say("Good. My cousin is an Easter Bunny and he's been planting eggs all week long. What's worse is that his buddy has been giving away Easter Baskets. Get me #b10 Green Easter Eggs#k and #b1 Easter Basket#k and I'll give you something worth your while!");
		}
	}
	
	private void GoldenEgg()
	{
		string quest = GetQuestData(8020006);
		
		if (quest == "")
		{
			bool start = AskYesNo("I see, so does that mean you can help us out by giving us the Golden Egg?");
			
			if (!start)
			{
				self.say("You just wasted my breath. Get lost!");
				return;
			}
			
			SetQuestData(8020006, "s");
			self.say("Okay... Good luck!!!");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031284) < 1)
			{
				self.say("You don't have the Golden Egg!! Man... if you ever find one, then please see me, alright?");
				return;
			}
			
			bool complete = AskYesNo("Wow! You found the Golden Egg? That's the rarest of the Easter Eggs! What are you going to do with it? If you give it to me, I'll give you some EXP! Now, I'm not used to giving out EXP, so I can't guarantee how much you're going to get. But life's a gamble, right? Otherwise, I've got a deal with all the store owners, and they'll give you some good money for it. (These EXP points may level you up as much as 'almost' two levels, depending on your level.)");
			
			if (complete)
			{
				self.say("Good deal! Hope you get some good EXP!");
				
				if (Exchange(0, 4031284, -1))
				{
					Random rnd = new Random();
					
					int chance = rnd.Next(1, 10001);
					int exp = 1;
					
					if (chance <= 5000) exp = 100;
					else if (chance <= 8500) exp = 1000;
					else if (chance <= 9999) exp = 10000;
					else exp = 100000;
					
					AddEXP(exp);
					SetQuestData(8020006, "e");
					QuestEndEffect();
					self.say($"I'm giving you {exp} EXP. Peace out!");
				}
			}
		}
		else if (quest == "e")
		{
			bool start = AskYesNo("Hey, nice to see you again! How have you been? So, have you found more #b#t4031284##k for me?");
			
			if (!start)
			{
				self.say("Oh really? That's alright. I'll be here for a bit, so if you find more #b#t4031284##k, you know where to find me.");
				return;
			}
			
			SetQuestData(8020006, "s");
			self.say("Sweet. That sounds like good news. I'll be here waiting.");
		}
	}
	
	private bool Check(int quest)
	{
		string info = GetQuestData(quest);
		string lastDate = GetQuestData(8021001);
		string today = DateTime.UtcNow.ToString("yyyyMMdd");
		
		if (quest == 8020004)
		{
			string green = GetQuestData(8020005);
			
			if (info == "s" || (lastDate != today && green != "s" && Level < 30))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (quest == 8020005)
		{
			string yellow = GetQuestData(8020004);
			
			if (info == "s" || (lastDate != today && yellow != "s" && Level >= 30))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		return false;
	}
	
	public override void Run()
	{
		bool checkYellow = Check(8020004);
		bool checkGreen = Check(8020005);
		
		if (DateTime.UtcNow < DateTime.Parse("2021-03-27"))
		{
			self.say("Quit buggin me. When Easter comes along, I'll have plenty for you to do...");
			return;
		}
		
		if (DateTime.UtcNow > DateTime.Parse("2021-04-17"))
		{
			self.say("Sup. Easter is over, but I still don't like it one bit, and now the people are aware of my plans. That's alright, though; my gang will do our best to bring it down next year, too. I'll be counting on you to help us take away more Easter Eggs from others. Peace...");
			return;
		}
		
		if (Level < 8)
		{
			self.say("Sup. I'm Roy, but my boys call me 'The Mad Bunny'. I hate Easter and I'm going to bring it down this year. I don't think you can help us out right now, cuz you seem weak. Go get yourself stronger, and maybe we'll talk business.");
			return;
		}
		
		AskMenuCallback("Sup. I'm Roy, but my boys call me 'The Mad Bunny'. I hate Easter and I'm going to bring it down this year. There are two ways to help my gang, and you can help us out by giving us either the Easter Egg or the Golden Egg. Which one of them can you give us?#b",
			(" Mad Bunny's Easter(Yellow)", checkYellow, EasterYellow),
			(" Mad Bunny's Easter(Green)", checkGreen, EasterGreen),
			(" Golden Egg", Level >= 8, GoldenEgg));
	}
}