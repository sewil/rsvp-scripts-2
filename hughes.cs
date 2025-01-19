using System;
using WvsBeta.Game;

// 2012017 Hughes the Fuse
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(1006300);
		string quest2 = GetQuestData(1006301);
		string quest3 = GetQuestData(1006302);
		
		string lastDate = GetQuestData(1006303);
		string today = DateTime.UtcNow.ToString("yyyyMMdd");
		
		if (Level < 35)
		{
			self.say("I need to invent something else. This is going to be good...");
			return;
		}
		
		if (quest1 == "")
		{
			self.say("Hey hands off my treasure chest! Who are you? How did you get in here? Everything here is mine! Everything ... I collected each and every one of these, and it was hard Whoa, the..the..the.. you're stepping on the baby seal doll! It took me a long time to find that! What are you going to do about this?!!");
			bool start = AskYesNo("I don't think \"I'm Sorry\" works here... unless you find the exact same thing.");
			
			if (!start)
			{
				self.say("So you barge into a stranger's lab, destroy my precious figures, and now you won't even accept responsibility for this? I can't believe this. Leave immeadiately!");
				return;
			}
			
			SetQuestData(1006300, "050");
			self.say("#b#t4000154##k can be obtained through Jr. Seals at the beach, but to get there, you'll need to pass through a throng of annoying #o3210450#s. #o3210450# never stop moving.");
			self.say("On your way there, also to stop #t4000154# from increasing ever further, go kill #b50 #o3210450#s#k and gather up #b10 #t4000154#s#k, then I'll think about this matter and I'll just let it slide. Hurry up. I'm not a patient person.");
		}
		else if (quest1 == "e")
		{
			if (quest2 == "")
			{
				int ask1 = AskMenu("What are you doing standing around there? Of course, you're here to see me ... hahaha. Did my latest invention already leak out to everyone else around the world? Are you just going to stand there? You're here to check out my new invention. How are you gonna see it from there?#b",
					(0, " Well, I'm not really here to see that..."));
				
				int ask2 = AskMenu("Look at this, I made this! Hahaha ... with this, you can finally breathe underwater like you always do. I'm a genius, a genius!!!#b",
					(0, " Well, I'm not THAT thrilled about watching a movie like this..."));
					
				bool start2 = AskYesNo("I'm sure you'd want to take something as cool as this. I know, I know. Since this is not the first time seeing you, if you gather up the materials, I'll make one for you myself.");
				
				if (!start2)
				{
					self.say("I offered to make you something special since I know you and all, but you turned out to be a fool. You'll regret saying no to me for the rest of your life.");
					return;
				}
				
				SetQuestData(1006301, "s");
				self.say("Of course, no fool would say no to something as genius as this. Hahaha ... what you need to gather up now are #b50 \r\n#t4000153#s, 50 #t2022040#s, 5 #t4011001#s, and 30 #t4003000#s#k. #t4000153# can be obtained through #b#o3210450##k, which lives at the underground of Orbis. #t2022040# can be found through #o3210450# or #o4230200#. Gather those up, and you're looking at the greatest invention ever!");
			}
			else if (quest2 == "s")
			{
				if (ItemCount(4003000) < 30 || ItemCount(2022040) < 50 || ItemCount(4011001) < 5 || ItemCount(4000153) < 50)
				{
					self.say("If you want my invention, then you'll have to wait. This is a discovery of the century, with #b50 #t4000153#s, 50 #t2022040#s, 5 #t4011001#s, and 30 #t4003000#s#k. #t4000153# can be obtained through #b#o3210450##k, which lives at the underground of Orbis. #t2022040# can be found through #o3210450# or #o4230200#. Gather those up, and you're looking at the greatest invention ever...");
					return;
				}
				
				self.say("Let's see ... the materials are all in. You must have really wanted this anyway! I can see that someone has a taste for a good invention. Hold on one second...");
				self.say("(kaboom!)(twist of faith)(clang clang clang)\r\nAlright, take it.");
				
				if (!Exchange(0, 4000153, -50, 2022040, -50, 4011001, -5, 4003000, -30, 1102061, 1))
				{
					self.say("To take my invention with you, you'll need an empty space in your equip. inventory first!");
					return;
				}
				
				AddEXP(3000);
				SetQuestData(1006301, "e");
				QuestEndEffect();
				self.say("This is called an oxygen tank. The oxygen is compressed in this bottle, ready to be breathed in. Consider it an honor that you're riding this car. Best of luck to you!");
			}
			else if (quest2 == "e")
			{
				if (ItemCount(1102061) >= 1 || lastDate == today)
				{
					self.say("What? What do you need?");
					return;
				}
				
				if (quest3 == "s")
				{
					if (ItemCount(4000156) < 20 || ItemCount(4000155) < 20)
					{
						self.say("I said #b20 #t4000155#s#k and #b20 #t4000156#s#k!! Were you even listening??");
						return;
					}
					
					self.say("You came in just the right time. I just used up my last material, and I was getting very worried.");
					
					if (!Exchange(0, 4000155, -20, 4000156, -20, 2000006, 10))
					{
						self.say("Make some room in your use inventory first!");
						return;
					}
					
					AddEXP(15000);
					SetQuestData(1006302, "e");
					SetQuestData(1006303, DateTime.UtcNow.ToString("yyyyMMdd"));
					QuestEndEffect();
					self.say("Ok ok this should do. Thank you, and here it is. Take it. Please come by again some time. I can always use some help in gathering up some materials for the study.");
				}
				else
				{
					self.say("Hey, it's been a while! What do you think about that stuff I made for you? Haha. Of course, I'm sure you're constantly amazed by the sheer genius the item brings, right?");
					bool start3 = AskYesNo("I've been working on something new these days, because as you know, the true geniuses never stand still. I've been working on this one so hard that I realized that I have run out of materials needed to continue my studies. Can you help me out here?");
					
					if (!start3)
					{
						self.say("You don't want to help me out, do you? Have you got not an ounce of gratitude toward me, after I made you an oxygen tank??");
						return;
					}
					
					SetQuestData(1006302, "s");
					self.say("Just get me #b20 #t4000155#s#k and #b20 #t4000156#s#k needed for this. I'm running out of them now.");
				}
			}
		}
		else
		{
			if (quest1 != "000" || ItemCount(4000154) < 10)
			{
				self.say("You didn't get the stuff I asked you to get? I am not a patient person here by any means! Go get #b10 #t4000154#s#k right now. Don't forget about taking care of some Scuba Pepes!");
				return;
			}
			
			self.say("Did you get all the dolls? Let's see ... good condition, and the right amount ... Hmmm, since you seem like you really worked on it, I'll just let it slide for now.");
			
			if (!Exchange(0, 4000154, -10, 2022040, 30))
			{
				self.say("Hey, make some room in your use inventory first!");
				return;
			}
			
			AddEXP(9000);
			SetQuestData(1006300, "e");
			QuestEndEffect();
			self.say("You're the one that started this mess, but ... I see that you're trying to make amends for your mistake, so ... here, please take it.");
		}
	}
}