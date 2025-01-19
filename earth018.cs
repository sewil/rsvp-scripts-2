using WvsBeta.Game;

// 2050010 Rice the Medic
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1004400);
		
		if (Level < 40)
		{
			self.say("Please be careful of your every act here in Omega Sector. How can I help you? My name is #b#p2050010##k, and as you can see, I take care of the wounded here. I'm always on my toes here, in case aliens attacked.");
			return;
		}
		
		if (quest == "")
		{
			bool start = AskYesNo("You seem to look bored, unlike us who are really bombarded with work. If that's the case, can I ask you for few favors? It's a difficult task, so I can sure use someone who is adept at hunting down the aliens, like you. You'll be rewarded handsomely for your effort. What do you think?");
			
			if (!start)
			{
				self.say("I thought you'd say yes, but... that surprised me quite a bit. You must be really busy these days. By the way, i can still use someone to call the play-by-play.");
				return;
			}
			
			SetQuestData(1004400, "s");
			self.say("Great choice! Now, I'll explain it to you what you're going to do. Lately the aliens have been applying substantial damage to our army through lethal dose of poison, and we still haven't found a way to cure that. Fortunately, we've figured out the main reason behind the poisonous attack.");
			self.say("The alien that applies the poisonous attack is a monster called #b#o4230119##k, and their tentacle seems be generate a powerful poison. We used to think the tentacle is used to feel out the situation, but I think they are also creating a lethal dose of poison to fight us.");
			self.say("Please gather up #b100 #t4000120#s#k for me, which will help me create a breakthrough Antidote that'll combat the poisonous attacks made by the aliens. Remember, this is to be kept a secret from #b#p2051000##k of Omega Sector Silo, alright??");
		}
		else if (quest == "s")
		{
			if (ItemCount(4000120) < 100)
			{
				self.say("Please gather up #b100 #t4000120#s#k for me, which will help me create a breakthrough Antidote that'll combat the poisonous attacks made by the aliens. Remember, this is to be kept a secret from #b#p2051000##k of Omega Sector Silo, alright??");
				return;
			}
			
			self.say("You are back! Did you gather up all #b100 #t4000120#s#k? Great! This will help me prolong the studies on creating the Antidote. Here, I'll give you an item that may help you down the stretch. Congratulations!");
			
			if (!Exchange(0, 4000120, -100, 2050003, 50))
			{
				self.say("Are you lacking space in your use inventory by any chance?");
				return;
			}
			
			AddEXP(4500);
			SetQuestData(1004400, "1");
			self.say("You really gathered up the finest-quality tentacles available. Do you see the purple liquid that's flowing on the cover? It looks like a lethal poison, and it scares a lot out of me. Alright, now, gotta go back to the studies. Please remember that I may run out of the materials sometime soon, and please keep dropping by, alright? Good bye!");
		}
		else if (quest == "1")
		{
			bool start2 = AskYesNo("You're back once more. Good timing, because the materials were about to run out on me. I've been trying to extract the tentacle in various ways, but since it's straight from outer space, it's much more difficult than I thought. Well, for one last time, can you please help me out?");
			
			if (!start2)
			{
				self.say("I thought you'd say yes, but... that surprised me quite a bit. You must be really busy these days. By the way, I can still use someone to call the play by play.");
				return;
			}
			
			SetQuestData(1004400, "2");
			self.say("I can't believe you said yes! You don't know how much this means to me, for you to help me out one more time. Anyway, the Sector is also counting on someone to make an Antidote that'll successfully negate the poisonous attacks by the aliens. The problem is, the materials you got me the last time have run out, again. This time, please gather up #b200 \r\n#t4000120#s#k for me. Good luck~~!");
		}
		else if (quest == "2")
		{
			if (ItemCount(4000120) < 200)
			{
				self.say("Please gather up #b200 #t4000120#s#k for me, which will help me create a breakthrough Antidote that'll combat the poisonous attacks made by the aliens. Remember, this is to be kept a secret from #b#p2051000##k of Omega Sector Silo, alright??");
				return;
			}
			
			self.say("You are back! Did you gather up all #b200 #t4000120#s#k? Great! This will help me prolong the studies on creating the Antidote. Here, I'll give you an item that may help you down the stretch. Congratulations!");
			
			if (!Exchange(0, 4000120, -200, 2050004, 50))
			{
				self.say("Are you lacking space in your use inventory by any chance?");
				return;
			}
			
			AddEXP(5000);
			SetQuestData(1004400, "3");
			self.say("You really gathered up the finest-quality tentacles available. Do you see the purple liquid that's flowing on the cover? It looks like a lethal poison, and it scares a lot out of me. Alright, now, gotta go back to the studies. Please remember that I may run out of the materials sometime soon, and please keep dropping by, alright? Good bye!");
		}
		else if (quest == "3")
		{
			bool start3 = AskYesNo("You're back once more. Good timing, because the materials were about to run out on me. I've been trying to extract the tentacle in various ways, but since it's straight from outer space, it's much more difficult than I thought. Well, for one last time, can you please help me out?");
			
			if (!start3)
			{
				self.say("I thought you'd say yes, but... that surprised me quite a bit. You must be really busy these days. By the way, i can still use someone to call the play by play.");
				return;
			}
			
			SetQuestData(1004400, "4");
			self.say("I can't believe you said yes! You don't know how much this means to me, for you to help me out one more time. Anyway, the Sector is also counting on someone to make an Antidote that'll successfully negate the poisonous attacks by the aliens. The problem is, the materials you got me the last time have run out, again. This time, please gather up #b300 \r\n#t4000120#s#k for me. Good luck~~!");
		}
		else if (quest == "4")
		{
			if (ItemCount(4000120) < 300)
			{
				self.say("Please gather up #b300 #t4000120#s#k for me, which will help me create a breakthrough Antidote that'll combat the poisonous attacks made by the aliens. Remember, this is to be kept a secret from #b#p2051000##k of Omega Sector Silo, alright??");
				return;
			}
			
			self.say("You are back! Did you gather up all #b300 #t4000120#s#k? Great! This will help me prolong the studies on creating the Antidote. Here, I'll give you an item that may help you down the stretch. Congratulations!");
			
			if (!Exchange(0, 4000120, -300, 2000004, 50))
			{
				self.say("Are you lacking space in your use inventory by any chance?");
				return;
			}
			
			AddEXP(5500);
			SetQuestData(1004400, "5");
			self.say("You really gathered up the finest-quality tentacles available. Do you see the purple liquid that's flowing on the cover? It looks like a lethal poison, and it scares a lot out of me. Alright, now, gotta go back to the studies. Please remember that I may run out of the materials sometime soon, and please keep dropping by, alright? Good bye!");
		}
		else if (quest == "5")
		{
			bool start4 = AskYesNo("Welcome back. Great timing, by the way, because I was just about to run out of the tentacles. I want to extract the tentacle in a couple of really interesting ways, but since they are from aliens, it hasn't been easy. Well, do you want to help me gather up some materials one more time?");
			
			if (!start4)
			{
				self.say("I thought you'd easily say yes. You must be really busy right now. I can always use some help here, so please talk to me if you ever feel like changing your mind.");
				return;
			}
			
			SetQuestData(1004400, "6");
			self.say("Thanks for deciding to help me out once more! The people upstairs, the higher-ranked officials, said thanks to you for your help. The people upstairs have been waiting for the creation of the Antidote to combat the poison attack the aliens feature. I'm sorry, but the material you gathered up for me have run out, so... please gather up #b400 #t4000120#s#k for me. Okay?");
		}
		else if (quest == "6")
		{
			if (ItemCount(4000120) < 400)
			{
				self.say("Please gather up #b400 #t4000120#s#k to fight off the deadly poison and the aliens. With them, I may be able to create a breakthrough Antidote! Hey, by the way, this is to be kept a secret from #b#p2051000##k of Omega Sector Silo, alright?");
				return;
			}
			
			self.say("You're back. Did you gather up the #b400 #t4000120#s#k like I asked you to get? Alright, then. I can finally continue on with the Antidote studies. Well, this isn't much, but I'm sure it'll help you on your journey, so please use it wisely.");
			
			if (!Exchange(0, 4000120, -400, 2000005, 30))
			{
				self.say("Are you lacking space in your use inventory by any chance?");
				return;
			}
			
			AddEXP(6000);
			SetQuestData(1004400, "7");
			self.say("You really gathered up the finest-quality tentacles available. Do you see the purple liquid that's flowing on the cover? It looks like a lethal poison, and it scares a lot out of me. Alright, now, gotta go back to the studies. Please remember that I may run out of the materials sometime soon, and please keep dropping by, alrght? Good bye!");
		}
		else if (quest == "7")
		{
			bool start5 = AskYesNo("You're back once more. Good timing, because the materials were about to run out on me. I've been trying to extract the tentacle in various ways, but since it's straight from outer space, it's much more difficult than I thought. Well, for one last time, can you please help me out?");
			
			if (!start5)
			{
				self.say("I thought you'd say yes, but... that surprised me quite a bit. You must be really busy these days. By the way, i can still use someone to call the play by play.");
				return;
			}
			
			SetQuestData(1004400, "8");
			self.say("I can't believe you said yes! You don't know how much this means to me, for you to help me out one more time. Anyway, the Sector is also counting on someone to make an Antidote that'll successfully negate the poisonous attacks by the aliens. The problem is, the materials you got me the last time have run out, again. This time, please gather up #b500 \r\n#t4000120#s#k for me. Good luck~~!");
		}
		else if (quest == "8")
		{
			if (ItemCount(4000120) < 500)
			{
				self.say("Please collect #b500 #t4000120#s#k so we can sufficiently defend ourselves from poisonous attacks. With those, I think I can make a breakthrough Antidote really soon. Make sure to keep this a secret from #b#p2051000##k of Omega Sector Silo, alright?");
				return;
			}
			
			self.say("You're back. Did you gather up the #b500 #t4000120#s#k? Oh my goodness, you really did! Sweet, now I may finally be able to start analyzing data for the Antidote! This isn't much, but I'm sure it's going to help you down the road. Please take it.");
			
			int itemID = 0;
			
			if (Job >= 100 && Job < 200) itemID = 1072126;
			else if (Job >= 200 && Job < 300) itemID = 1072116;
			else if (Job >= 300 && Job < 400) itemID = 1072119;
			else if (Job >= 400 && Job < 500) itemID = 1072110;
			else itemID = 1072018;
			
			if (!Exchange(0, 4000120, -500, itemID, 1))
			{
				self.say("Are you lacking space in your equip. inventory by any chance?");
				return;
			}
			
			AddEXP(6500);
			SetQuestData(1004400, "e");
			QuestEndEffect();
			self.say("Phew... I can't thank you enough for all your help. Now I have enough materials to work with, so I'll be concentrating on this research for a while. I can't wait to get a patent out of this Antidote. I'll need to start the research now. I'll see you around~");
		}
		else if (quest == "e")
		{
			self.say("Please be careful of your every act here in Omega Sector. How can I help you? My name is #b#p2050010##k, and as you can see, I take care of the wounded here. I'm always on my toes here, in case aliens attacked.");
		}
	}
}