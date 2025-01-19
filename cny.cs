using System;
using WvsBeta.Game;

//Mr. Moneybags  -  Lunar New Year event 2007
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (DateTime.UtcNow > DateTime.Parse("2022-02-20"))
		{
			self.say("Did you have a good Lunar New Year? I had so much fun celebrating with my friends here in MapleStory! I'm here wishing you all good luck this year!");
			return;
		}
		
		string quest = GetQuestData(8200033); //temp
		
		if (quest == "")
		{
			self.say("Happy Lunar New Year! May all your dreams come true in the Year of the Tiger! 2021 was a great year for me. I made a fortune selling recycled weapons and armor and I'm here to share my luck with you as a way of wishing you a wonderful new year.");
			bool start = AskYesNo("The monsters ate all my empty #b#t4031249#s#k. Vile creatures! I desperately need those to give to my family for New Years. I'll buy them from you for a certain amount of mesos, depending on how much I have in my pocket. Well then... want to do business?");
			
			if (!start)
			{
				self.say("Ah, really? Oh well... If you find more #b#t4031249#s#k, you know where to find me, I'll be here for a while longer.");
				return;
			}
			
			SetQuestData(8200033, "s");
			self.say("All right... Good luck!!!");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031249) < 1)
			{
				self.say("Are you sure that you have a #b#t4031249##k? I'll make the best proposal in town!");
				return;
			}
			
			int money = 0;
			string dialogue = "";
			
			int rnum = Random(0, 800001);
			
			if (rnum == 0)
			{
				money = 10000000;
				dialogue = "Oh my God! This is your year! 10,000,000 mesos for a #b#t4031249##k... I think I'm going to have an ulcer. A deal is a deal... Enjoy your money!";
			}
			else if (rnum <= 99)
			{
				money = 1000000;
				dialogue = "There you go! Wow!? I think you got a lot, but a deal is a deal. I'm still short on #b#t4031249#s#k, so bring them to me when you find them.";
			}
			else if (rnum <= 49900)
			{
				money = 100000;
				dialogue = "There you go! Wow!? I think you got a lot, but a deal is a deal. I'm still short on #b#t4031249#s#k, so bring them to me when you find them.";
			}
			else if (rnum <= 150000)
			{
				money = 10000;
				dialogue = "There you go! I hope that you have a great year. I'm still short on #b#t4031249#s#k, so bring them to me when you find them.";
			}
			else if (rnum <= 800000)
			{
				money = 1000;
				dialogue = "There you go! I hope that you have a great year. I'm still short on #b#t4031249#s#k, so bring them to me when you find them.";
			}
			
			if (!Exchange(money, 4031249, -1))
			{
				self.say("Sorry, but I'm having trouble putting items in your inventory. Please try again later.");
				return;
			}
			
			SetQuestData(8200033, "end");
			self.say(dialogue);
		}
		if (quest == "end")
		{
			bool restart = AskYesNo("Hey, good to see you again! How are you? So, have you found more #b#t4031249##k for me? Would you like to make another trade?");
			
			if (!restart)
			{
				self.say("Ah, really? Oh well... If you find more #b#t4031249#s#k, you know where to find me, I'll be here for a while longer.");
				return;
			}
			
			SetQuestData(8200033, "ing");
			self.say("Sweet. That's great news. I'll be here waiting.");
		}
	}
}