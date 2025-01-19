using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(1000300);
		string quest2 = GetQuestData(1000301);
		
		if (quest1 == "")
		{
			if (Level < 20 || chr.Job == 0)
			{
				self.say("Ah~! It is really getting to me!!! #o2220100#... Oh... Are you a stranger?");
				return;
			}
			
			self.say("Sigh... a few days ago, on the way to see my friend at Ellinia, I ran into a #o2220100# and had just a miserable time!! That blue mushroom would not have had a chance against me, if only I was stronger than I am right now.");
			self.say("Whoa hey, you look pretty strong ... if you got any time, can you please take care of them for me?? If you bring me #b#e60#n#k \r\n#b#t4000009#s#k and #b#e60#n#k #b#t4000012#s#k as proof, I'll get you something. Something REALLY sweeeet~!! You won't regret doing it!");
			SetQuestData(1000300, "p");
		}
		else if (quest1 == "p")
		{
			if (ItemCount(4000009) < 60 || ItemCount(4000012) < 60)
			{
				self.say("Gather up #b#e60#n #t4000009#s#k and #b#e60#n #t4000012#s#k and I'll get you something nice in return. TRUST ME ON THIS!");
				return;
			}
			
			self.say("What the!! Aren't those the #b#t4000009#s#k and #b#t4000012#s#k? That's A LOT of those that you gathered\r\nup... you must be something!! Thank you so much!!! I feel a little better from that. Ahahaha, right back at ya punks!!");
			self.say("Oh yeah ... I knew I was forgetting something ... this isn't much, but ... here it is, as a sign of my appreciation. Great work there~");
			
			if (SlotCount(2) < 1)
			{
				self.say("Oh~ check your use inventory to see if there's an open slot first.");
				return;
			}
			
			Random rnd = new Random();
			int[] scrolls = {2040000, 2040001, 2040002};
			
			int itemID = scrolls[rnd.Next(scrolls.Length)];
			
			if (!Exchange(0, 4000009, -60, 4000012, -60, itemID, 1))
			{
				self.say("Are you sure you brought everthing?");
				return;
			}
			
			AddEXP(100);
			SetQuestData(1000300, "end");
			QuestEndEffect();
			self.say("This scroll ... I think it has the power to strengthen the helmet. It's easy to use. All you need to do is open both the use tab and the equipment inventory at once ... then drag the scroll onto the helmet that you're wearing. There's a chance that it may not work, so be careful with it.");
		}
		else if (quest1 == "end")
		{
			if (quest2 == "" && Level >= 55 && chr.Job >= 400)
			{
				self.say("Oh you are the one who beat #o2220100# for me~ You look much stronger than the last time? Did my scroll help you? Hehe... Anyway, good. Since you look strong, I would like to ask you a favor... Would you help me?");
				self.say("One of my friends in Ellinia wanted to be a thief. After some training, he will start traveling... I would like to give him something special for him! So I asked #p1052002# in #m103000000# to make a good claw and he wanted some weird stuff to make it.");
				bool askStart = AskYesNo("So can you get the materials, which #p1052002# wants? I'd like to get them by myself, but I can't move, because of this stupid clothing! Of course, I will pay you, if you do this for me... If you are not busy, can you please help me?");
				
				if (!askStart)
				{
					self.say("You must be very busy... If you have time later, please get back to me~! My friend will start traveling soon...");
					return;
				}
				
				SetQuestData(1000301, "s");
				self.say("Thanks! I need #b15 #t4011004#, 50 #t4000030#, 40 #t4003000#s#k. Oh... and I need a cape for my friend! Few days ago, I lend #p1010100# in #m100000000# a cape. Can you please get it back from her? I think my friend will definitely need it. If you get these, it would be much help for my friend.");
			}
			else if (quest2 == "s" || quest2 == "g")
			{
				self.say("So you haven't gotten all the materials, yet? Please get #b15 \r\n#t4011004#, 50 #t4000030#, 40 #t4003000#s#k... You can get #t4031043# from #p1010100# in #m100000000#...");
			}
			else if (quest2 == "p")
			{
				if (ItemCount(4000030) < 50 || ItemCount(4003000) < 40 || ItemCount(4011004) < 15 || ItemCount(4031043) < 1)
				{
					self.say("So you haven't gotten all the materials, yet? Please get #b15 \r\n#t4011004#, 50 #t4000030#, 40 #t4003000# #k? You can get #t4031043# from #p1010100# in #m100000000#...");
					return;
				}
				
				self.say("Wow! You have gotten them all! Okay. Now I can just give these to #p1052002# and get the claw. Oh yeah, I will give you a good stuff, since you did all these for me. In fact, my family makes the armor. I will give this armor to you. It will be a lot of help for you.");
				
				bool trade = false;
				
				if (chr.GetGender() == 0) trade = Exchange(0, 4000030, -50, 4003000, -40, 4031043, -1, 4011004, -15, 1040100, 1, 1060089, 1);
				else if (chr.GetGender() == 1) trade = Exchange(0, 4000030, -50, 4003000, -40, 4031043, -1, 4011004, -15, 1041096, 1, 1061095, 1);
				
				if (!trade)
				{
					self.say("Please check to see if you have at least two slots available in your equip. inventory!");
					return;
				}
				
				AddEXP(1000);
				SetQuestData(1000301, "end");
				QuestEndEffect();
				self.say("Got it? Thanks for helping me. It will be very helpful. I will get going to #m103000000#.");
			}
			else
			{
				self.say("Thanks for the last time. Now #o2220100# is about to extinct. So how was the scroll?");
			}
		}
	}
}