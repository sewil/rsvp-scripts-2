using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(1000700);
		string quest2 = GetQuestData(1000701);
		
		if (Level < 25)
		{
			self.say("Lots of medicinal herbs in this forest. Nothing makes me happier than finding new herbs here!");
			return;
		}
		
		if (quest1 == "")
		{
			self.say("Wait, hold on one second. I am an herb-collector traveling around the world finding herbs. I'm looking for useful medicinal herbs around this area. It's been hard finding those these days ... so, hey, have found a place where the herbs run aplenty?");
			bool askStart1 = AskYesNo("Actually I've found a place where you can find good medicinal herbs. It's at a forest not too far from here ... lots of obstacles around the area but I can tell in the end there will be goods available for us to use ... so what do you think? Do you want to go there in place of me?");
			
			if (!askStart1)
			{
				self.say("Really. You look like you can just breeze through there ... please come back here when you have time. I'll be waiting for you.");
				return;
			}
			
			string[] infos = {"1_01", "1_02", "1_03", "1_04"};
			string[] herbs = {"4031020", "4031021", "4031022", "4031023"};
			
			Random rnd = new Random();
			
			int rnum = rnd.Next(infos.Length);
			string info = infos[rnum];
			string herb = herbs[rnum];
			
			SetQuestData(1000700, info);
			SetQuestData(1100, herb);
			self.say("Thank you. The place where you can find the mysterious herb is actually the place you've been to before, which is \r\n#m101000000#. I heard someone's accepting an entrance fee at the entrance ... you have the mesos to go in, right? Sorry but I've spent all my money traveling so I'm afraid I can't help you on that ...");
			self.say($"Yes! I'll explain to you about the herb you'll be getting for me. Remember there are similar herbs around so make sure you know this. The herb you'll need to get is #b#t{herb}##k, and the flower looks like this #i{herb}#. Look carefully and please get the same one as I described for you.");
		}
		else if (quest1 == "1_00" || quest1 == "1_99")
		{
			if (Level < 50)
			{
				self.say("Lots of medicinal herbs in this forest. Nothing makes me happier than finding new herbs here!");
				return;
			}
			
			if (quest2 == "")
			{
				bool askStart2 = AskYesNo("Ohhh, you're the traveler that helped me out a lot the other day! I made the diet medicine with the herbs you got me and made some money ... and this time, I'd like to make a different kind of a medicine. What do you think? Do you want to help me out one more time?");
				
				if (!askStart2)
				{
					self.say("Really. You look like you can just breeze through there ... please come back here when you have time. I'll be waiting for you.");
					return;
				}
				
				Random rnd = new Random();
				
				string info = "";
				string herb = "";
				
				if (quest1 == "1_00")
				{
					string[] infos = {"2_01", "2_02"};
					string[] herbs = {"4031032", "4031033"};
					
					int rnum = rnd.Next(infos.Length);
					
					info = infos[rnum];
					herb = herbs[rnum];
				}
				else if (quest1 == "1_99")
				{
					string[] infos = {"2_51", "2_52", "2_53"};
					string[] herbs = {"4031029", "4031030", "4031031"};
					
					int rnum = rnd.Next(0, 3);
					
					info = infos[rnum];
					herb = herbs[rnum];
				}
				
				SetQuestData(1000701, info);
				SetQuestData(1101, herb);
				self.say("Thank you. The place where you can find the mysterious herb is actually the place you've been to before, #m101000000#. I heard someone's accepting an entrance fee at the entrance ... you have the mesos to go in, right? This time you'll be going in much deeper than before so be prepared ...");
				self.say($"Yes! I'll explain to you about the herb you'll be getting for me. Remember there are similar herbs around so make sure you know this. The herb you'll need to get is #b#t{herb}##k, and the root looks like this #i{herb}#. Look carefully and please get the same one as I described for you.");
			}
			else if (quest2 == "2_00" || quest2 == "2_99")
			{
				self.say("It's you!! Thanks to the herbs you got me, the medicine is well on its way. It should be done pretty soon. Thanks again for your help.");
			}
			else
			{
				int herb2 = Int32.Parse(GetQuestData(1101));
				
				if (ItemCount(4031029) < 1 && ItemCount(4031030) < 1 && ItemCount(4031031) < 1 && ItemCount(4031032) < 1 && ItemCount(4031033) < 1)
				{
					self.say($"You haven't gotten the herb yet. The herb you need to get is #b#t{herb2}##k. The roots look like this #i{herb2}#. Remember it and get it from #p1032003# in #m101000000#.");
					return;
				}
				
				bool askComplete = AskYesNo("Ohhh ... you came back! Were you able to find the herb I requested from #p1032003# in #m101000000#?");
				
				if (askComplete)
				{
					if (ItemCount(herb2) >= 1)
					{
						self.say($"Ohhh ... this is IT! With #b#t{herb2}##k, I can finally make the anti-aging medicine!!! Hahaha, if you ever become old and weak, find me. By then I may have a special medicine for just that!");
						
						if (!Exchange(0, herb2, -1, 4021009, 1))
						{
							self.say("Ohhh ... are you sure you brought the herb with you?");
							return;
						}
						
						AddEXP(3000);
						AddFame(2);
						SetQuestData(1000701, "2_00");
						QuestEndEffect();
						self.say("Oh, I almost forgot. Since you helped me out, I should thank you for your hard work ... #b#t4021009##k is something I found at the very bottom of a valley a lont time ago in the middle of a journey. It'll probably help you down the road. I also boosted up your fame level and from here on out, \r\n#p1032003# may let you in for free. Well, so long...");
					}
					else
					{
						self.say($"Ohhh ... this isn't it ... the herb I asked for was the #b#t{herb2}##k. Well, that's ok, I can tell you worked really hard to get this herb for me. I should still be able to make a medicine from this ...");
						
						bool trade = false;
					
						if (ItemCount(4031029) >= 1) trade = Exchange(0, 4031029, -1, 2000004, 50);
						else if (ItemCount(4031030) >= 1) trade = Exchange(0, 4031030, -1, 2000004, 50);
						else if (ItemCount(4031031) >= 1) trade = Exchange(0, 4031031, -1, 2000004, 50);
						else if (ItemCount(4031032) >= 1) trade = Exchange(0, 4031032, -1, 2000004, 50);
						else if (ItemCount(4031033) >= 1) trade = Exchange(0, 4031033, -1, 2000004, 50);
						
						if (!trade)
						{
							self.say("Ohhh ... are you sure you brought the herb with you?");
							return;
						}
						
						AddEXP(3000);
						AddFame(2);
						SetQuestData(1000701, "2_99");
						QuestEndEffect();
						self.say("Oh, I almost forgot. Since you helped me out, I should thank you for your hard work ... Here, take these elixirs. My brother made these for me a while back. Hopefully you'll use it well. I also boosted up your fame level and from here on out, #p1032003# may let you in for free. Well, so long...");
					}
				}
			}
		}
		else
		{
			int herb1 = Int32.Parse(GetQuestData(1100));
			
			if (ItemCount(4031020) < 1 && ItemCount(4031021) < 1 && ItemCount(4031022) < 1 && ItemCount(4031023) < 1)
			{
				self.say($"You haven't gotten the herb yet. The herb you need to get is #b#t{herb1}##k. The flower looks like this #i{herb1}#. Remember it and get it from #p1032003# in #m101000000#");
				return;
			}
			
			bool askComplete = AskYesNo("Ohhh ... you came back! Were you able to find the herb I requested from #p1032003# in #m101000000#?");
			
			if (askComplete)
			{
				if (ItemCount(herb1) >= 1)
				{
					self.say($"Ohhh ... this is IT! With #b#t{herb1}##k, I can finally make the diet medicine!! Hahaha, if you ever feel like you have gained weight, feel free to find me, because by then, I may have a special medicine in place for just that!");
					
					if (SlotCount(2) < 1)
					{
						self.say("Please leave a slot open on the use tab first.");
						return;
					}
					
					Random rnd = new Random();
					int[] scrolls = {2040504, 2040505};
					
					int itemID = scrolls[rnd.Next(scrolls.Length)];
					
					if (!Exchange(0, herb1, -1, itemID, 1))
					{
						self.say("Ohhh ... are you sure you brought the herb with you?");
						return;
					}
					
					AddEXP(1000);
					AddFame(1);
					SetQuestData(1000700, "1_00");
					QuestEndEffect();
					self.say("Oh, I almost forgot. Since you helped me out, I should thank you for your hard work. Here, take this scroll. My brother made this for me a while back, and it adds to the guarding abilities of the armor. Hopefully you'll use it well. And from here on out, #p1032003# will let you in free. Thanks for your help...");
				}
				else
				{
					self.say($"Ohhh ... this isn't it ... the herb I asked for was the #b#t{herb1}##k. Well, that's ok, I can tell you worked really hard to get this herb for me. I should still be able to make a medicine from this ...");
					
					bool trade = false;
					
					if (ItemCount(4031020) >= 1) trade = Exchange(0, 4031020, -1, 2000004, 10);
					else if (ItemCount(4031021) >= 1) trade = Exchange(0, 4031021, -1, 2000004, 10);
					else if (ItemCount(4031022) >= 1) trade = Exchange(0, 4031022, -1, 2000004, 10);
					else if (ItemCount(4031023) >= 1) trade = Exchange(0, 4031023, -1, 2000004, 10);
					
					if (!trade)
					{
						self.say("Ohhh ... are you sure you brought the herb with you?");
						return;
					}
					
					AddEXP(1000);
					AddFame(1);
					SetQuestData(1000700, "1_99");
					QuestEndEffect();
					self.say("Oh, I almost forgot. Since you helped me out, I should thank you for your hard work. Here, take these elixirs. My brother made these for me a while back. Hopefully you'll use it well. And from here on out, #p1032003# will let you in free. Thanks for your help...");
				}
			}
		}
	}
}