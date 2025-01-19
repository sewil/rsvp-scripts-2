using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(1000900);
		string quest2 = GetQuestData(1000901);
		string quest3 = GetQuestData(1000902);
		
		if (Level < 15)
		{
			self.say("Is there anyone who can help me? Well... I would like to go by myself, but as you can see, I have lots of stuff to do...");
			return;
		}
		
		if (quest3 == "end")
		{
			self.say("You are the one, who brought the flower to me. Again, thanks a lot.. Feel free to stay in this town.");
		}
		else if (quest3 == "")
		{
			if (quest2 == "end")
			{
				if (Level >= 60)
				{
					bool askStart3 = AskYesNo("Ohhh...you're the person that did me huge favors a while ago. You look so much stronger now that I can't even recognize you anymore. By now it looks like you have gone pretty much everywhere. I have one last favor to ask you. Well, my mother passed away a few days ago of old age. I need a special kind of flower for her on her grave ... can you get them for me?");
					
					if (!askStart3)
					{
						self.say("I see ... my mother loved looking at those flowers while she was alive ... I wished that you could get them for me and for her ... I understand ...");
					}
					else
					{
						SetQuestData(1000902, "30");
						self.say("Thank you so much! The flowers I want on her grave are called #b#t4031028##k and it's a very rare kind. I heard it's found deep in the forest ... I heard the place where it exists doesn't let everyone in; only a select few, I think. Something about \r\n#p1061006# at #m105040300# and something \r\nsomething ...");
						self.say("Please get me #b30 #t4031028#s#k. I want to get a whole bunch for my mother's grave. Please hurry!");
					}
				}
				else
				{
					self.say("You are the one, who brought the flower to me. Again, thanks a lot.. Feel free to stay in this town.");
				}
			}
			else if (quest2 == "")
			{
				if (quest1 == "end")
				{
					if (Level >= 30)
					{
						bool askStart2 = AskYesNo("Ohhhh, you're the one that helped me out the other day. You look much stronger now. How's traveling these days? I actually have another favor to ask you ... this time, my wife's birthday is coming up and I need more flowers. Can you get them for me?");
						
						if (!askStart2)
						{
							self.say("I understand ... my wife's birthday is coming up and I am screwed! Please come back if you have some spare time.");
							return;
						}
						
						SetQuestData(1000901, "20");
						self.say("Thank you! This time I'd like to give my wife #b#t4031026##k ... It has a very pleasant scent, and I heard it's found deep in the forest ... I heard the place where it exists doesn't let everyone in; only a selected few, I think. Something about #p1061006# at #m105040300# and something something ...");
						self.say("Please get me #b20 #t4031026#s#k. I think 20 will cover the house with that pleasant scent. Please hurry!");
					}
					else
					{
						self.say("You are the one, who brought the flower to me. Again, thanks a lot.. Feel free to stay in this town.");
					}
				}
				else if (quest1 == "")
				{
					bool askStart1 = AskYesNo("How's traveling these days? I actually have a favor to ask you, my wedding anniversary is coming up and I need flowers. Can you get them for me?");
					
					if (!askStart1)
					{
						self.say("I understand ... my wedding anniversary is coming up and I am screwed! Please come back if you have some spare time.");
						return;
					}
					
					SetQuestData(1000900, "10");
					self.say("Thank you! This time I'd like to give my wife #b#t4031025##k ... It has a very pleasant scent, and I heard it's found deep in the forest ... I heard the place where it exists doesn't let everyone in; only a select few, I think. Something about #p1061006# at #m105040300# and something something ...");
					self.say("Please get me #b10 #t4031025#s#k. I think 10 will cover the house with that pleasant scent. Please hurry!");
				}
				else
				{
					int needFlower = Int32.Parse(quest1);
					int haveFlower = ItemCount(4031025);
					
					if (haveFlower < 1)
					{
						self.say($"You haven't gotten #b#t4031025##k yet. There's #p1061006# at #m105040300# and I heard that with that you can go to the place where #t4031025##k is. Please go into the forest and collect #t4031025##k for me. I need {needFlower} more to make my wedding anniversary.");
					}
					else if (haveFlower >= needFlower)
					{
						self.say("Ohhh ... you got me all the #b#t4031025#s#k~! This is awesome ... I can't believe you went deep into the forest and got these flowers ... there's a story about this flower where it supposedly doesn't die for 100 years. With this, I can make my wife happy.");
						self.say("Oh, and ... since you have worked hard for me, I should reward you well. I found some #t4003000# in the ship. Some travelers leave things here and there. It looks like something you may need, so take it.");
						
						if (!Exchange(0, 4031025, -haveFlower, 4003000, 30))
						{
							self.say("Hold on, you should make some room in your etc. inventory first.");
							return;
						}
						
						AddEXP(300);
						SetQuestData(1000900, "end");
						QuestEndEffect();
						self.say("If you have time, why not try going back into the forest? You may find an important item in there. I can't guarantee it since obviously I've never been there before, so please don't come back complaining if all you can find is trash.");
					}
					else
					{
						self.say("Ohhh ... you got me some #b#t4031025#s#k~! I'll take those off your hands.");
						
						int nNeedFlower = needFlower - haveFlower;
						
						if (!Exchange(0, 4031025, -haveFlower))
						{
							self.say("Are you sure you brought the #t4031025#?");
							return;
						}
						
						SetQuestData(1000900, nNeedFlower.ToString());
						self.say($"Thanks, I still need {nNeedFlower} more to make my wedding anniversary.");
					}
				}
			}
			else
			{
				int needFlower = Int32.Parse(quest2);
				int haveFlower = ItemCount(4031026);
				
				if (haveFlower < 1)
				{
					self.say($"You haven't gotten the #b#t4031026##k yet. There's #p1061006# at #m105040300# and I heard that with that you can go to the place where #t4031026##k is. Please go into the forest and collect #t4031026##k for me. I need {needFlower} more to make my wife's birthday present.");
				}
				else if (haveFlower >= needFlower)
				{
					self.say("Ohhh ... you got me all the #b#t4031026#s#k~! This is awesome ... I can't believe you went deep into the forest and got these flowers ... there's a story about this flower where it supposedly doesn't die for 500 years. With this, I can make the whole house smell like flowers.");
					self.say("Oh, and ... since you have worked hard for me, I should reward you well. I found this glove in the ship. Some travelers leave things here and there. It looks like something you may need, so take it.");
					
					int glove;
					
					if (chr.Job >= 100 && chr.Job < 200) glove = 1082036;
					else if (chr.Job >= 200 && chr.Job < 300) glove = 1082056;
					else if (chr.Job >= 300 && chr.Job < 400) glove = 1082070;
					else if (chr.Job >= 400 && chr.Job < 500) glove = 1082045;
					else glove = 1082002;
					
					if (!Exchange(0, 4031026, -haveFlower, glove, 1))
					{
						self.say("Hold on, you should make some room in your equip. inventory first.");
						return;
					}
					
					AddEXP(2000);
					SetQuestData(1000901, "end");
					QuestEndEffect();
					self.say("If you have time, why not try going back into the forest? You may find an important item in there. I can't guarantee it since obviously I've never been there before, so please don't come back complaining if all you can find is trash.");
				}
				else
				{
					self.say("Ohhh ... you got me some #b#t4031026#s#k~! I'll take those off your hands.");
					
					int nNeedFlower = needFlower - haveFlower;
					
					if (!Exchange(0, 4031026, -haveFlower))
					{
						self.say("Are you sure you brought the #t4031026#?");
						return;
					}
					
					SetQuestData(1000901, nNeedFlower.ToString());
					self.say($"Thanks, I still need {nNeedFlower} more to make my wife's birthday present.");
				}
			}
		}
		else
		{
			int needFlower = Int32.Parse(quest3);
			int haveFlower = ItemCount(4031028);
			
			if (haveFlower < 1)
			{
				self.say($"You haven't gotten #b#t4031028##k yet. There's a #p1061006# at #m105040300# and I heard that with that you can go to the place where #t4031028##k is. Please go into the forest and collect #t4031028##k for me. I need {needFlower} more to make a wreath.");
			}
			else if (haveFlower >= needFlower)
			{
				self.say("Ohhh ... you got me all the #t4031028#s#k!  This is awesome ... I can't believe you went deep into the forest and got these flowers... there's a story about this flower where it supposedly doesn't die for 1000 years and it glows on its own. I can make a nice wreath out of this and bring it to my mother's grave...");
				self.say("Oh, and... since you have worked hard for me, I should reward you well. My late mother left me this earring before passing away. Apparently she had it since she was young. I don't know, but it seems to have some kind of a special power hidden in it ... anyway please take it.");
				
				if (!Exchange(0, 4031028, -haveFlower, 1032014, 1))
				{
					self.say("Hold on, you should make some room in your equip. inventory first.");
					return;
				}
				
				AddEXP(4000);
				SetQuestData(1000902, "end");
				QuestEndEffect();
				self.say("If you have time, why not try going back into the forest? You may find an important item in there. I can't guarantee it since obviously I've never been there before, so please don't come back complaining if all you can find is trash.");
			}
			else
			{
				self.say("Ohhh ... you got me some #b#t4031028#s#k~! I'll take those off your hands.");
				
				int nNeedFlower = needFlower - haveFlower;
				
				if (!Exchange(0, 4031028, -haveFlower))
				{
					self.say("Are you sure you brought the #t4031028#?");
					return;
				}
				
				SetQuestData(1000902, nNeedFlower.ToString());
				self.say($"Thanks, I still need {nNeedFlower} more to make a wreath.");
			}
		}
	}
}