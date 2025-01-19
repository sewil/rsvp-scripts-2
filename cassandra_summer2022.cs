using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(8020047);
		
		if (DateTime.UtcNow >= DateTime.Parse("2022-09-01"))
		{
			self.say("Oh my, it looks like Summer will soon be coming to an end. I'll see you around~");
			return;
		}
		
		if (DateTime.UtcNow < DateTime.Parse("2022-08-12"))
		{
			self.say("Isn't my crystal ball beautiful? Look closely... it could reveal your fortune~");
			return;
		}
		
		if (quest == "")
		{
			self.say("Hi, I'm Cassandra. Isn't it hot out today? I'm sure my friend the #bMaple Administrator#k could find a way to cool off on a day like today~");
		}
		else if (quest == "s1")
		{
			bool start = AskYesNo("So the Maple Administrator told you to come see me, right? Yes, I can make the scroll that will upgrade your ice pop, but I'll need you to run some errands for me first. What do you think? Are you interested?");
			
			if (!start)
			{
				self.say("Hmm... okay. If you change your mind, I'll be right here.");
				return;
			}
			
			SetQuestData(8020047, "s2");
			self.say("Cool~! I can make you a scroll to upgrade your ice pop, but I'll need you to bring me #b10 Large Pearls#k which can only be found from #bclams#k around #bAqua Road#k. Once you've found 10, come back and talk to me!");
		}
		else if (quest == "s2")
		{
			if (ItemCount(4031843) < 10)
			{
				self.say("It looks like you don't have all 10 pearls. Remember, you can find them from the #bclams#k in #bAqua Road#k.");
				return;
			}
			
			self.say("Oh wow! 10 beautiful pearls, just like I asked~! Now that you've brought these, I can make a scroll for your ice pop. Close your eyes and hold out your hands!");
			
			if (!ExchangeEx(0, "4031843", -10, "2040150,DateExpire:2022090100", 1))
			{
				self.say("Are you sure you have all 10 pearls? If so, please make sure there's a free slot in your use inventory.");
				return;
			}
			
			AddEXP(200);
			SetQuestData(8020047, "e");
			SetQuestData(8020048, DateTime.UtcNow.ToString("yyyyMMdd"));
			QuestEndEffect();
			self.say("Here it is. This should power up your ice pop but remember: it will only work during this event so use it as soon as possible. Come back again tomorrow and I can make a scroll for you again~!");
		}
		else if (quest == "e")
		{
			string today = DateTime.UtcNow.ToString("yyyyMMdd");
			string lastDate = GetQuestData(8020048);
			
			if (lastDate == today)
			{
				self.say("Thanks again for your help today. Come back tomorrow and I can make you another scroll.");
				return;
			}
			
			bool start = AskYesNo("Oh, you're the one who brought me those beautiful pearls. I can make another scroll for your ice pop, but I'll need you to run more errands for me. What do you think? Do you want me to make another scroll?");
			
			if (!start)
			{
				self.say("Hmm... okay. If you change your mind, I'll be right here.");
				return;
			}
			
			SetQuestData(8020047, "s2");
			self.say("All right, you know what to do. Collect #b10 Large Pearls#k and bring them back here to me. I'll be waiting~");
		}
	}
}