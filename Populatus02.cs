using System;
using System.Collections.Generic;
using WvsBeta.Game;

// 2041021 - Mr. Bouffon
public class NpcScript : IScriptV2
{
	private void Papulatus(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("Do you know the #bsource of power#k that makes Ludibrium run? Well, it's missing, and that's why the time has stopped. We do not know exactly what happened, and many questions are still left unanswered. One thing I'm certain is the fact that I can't do this by myself, so... I have a favor to ask you... can you help me out?");
			
			if (!start)
			{
				self.say("Do you think finding it is hard? Just head downstairs, and kill the monsters that you see. It's that simple.");
				return;
			}
			
			SetQuestData(7100000, "s");
			self.say("Thanks. Hmmm ... the source of power can be described as the #bTime Sphere#k, located at the very bottom of the power generator, but it went missing a while ago. We've sent some people down for investigation, and the answer they gave was... well, we'll have to replace the Time Sphere.");
			self.say("What I'll need are 10 of the energy replacements that may in fact be able to replicate as the source of power of Time Sphere. The monsters around here have turned evil ever since obtaining that power. You will, however, be able to recover that power if you defeat the monsters.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031170) < 10)
			{
				self.say("Hmm... to see how the reaction goes, I'll need 10 energy replacements. I don't think you have all 10, though. Talk to me once you have all 10 of them with you.");
				return;
			}
			
			self.say("Did you find the item I was talking about? I want to see how it reacts...");
			bool start2 = AskYesNo("Oh, this is it!! #b#t4031175:##k is the one that reacts well with #r#t4031171:##k, the one I have. With these two, I think we can make the #bTime Sphere#k! What do you think? Can you gather them up some more?");
			
			if (!start2)
			{
				self.say("To gather up the stuff I just mentioned, you'll have to take on some very challenging monsters, so you don't have to help me do this now. You can train yourself until you find yourself ready for this.");
				return;
			}
			
			if (!Exchange(3270, 4031170, -10))
			{
				self.say("Are you sure you have the 10 energy replacements?");
				return;
			}
			
			AddEXP(2700);
			SetQuestData(7100000, "1");
			self.say("Like I said, thanks to you, we now know that #t4031175# and #t4031171# reacts to one another. Transforming this into a sphere that generates massive power will require a lot of these. You can gather up #b#t4031170##k through #bthe monsters#k that can be found downstairs. Only #r#o7130300##k has #r#t4031171##k, however.");
			self.say("To produce the #bTime Sphere#k, I'll need 300 #t4031175#s and 100 #t4031171#s.");
		}
		else if (quest == "1")
		{
			if (ItemCount(4031171) < 100 || ItemCount(4031175) < 300)
			{
				self.say("To make the PERFECT Time Sphere, I'll need #b300 #t4031170#s#k and #b100 #t4031171#s#k.");
				return;
			}
			
			self.say("Did you gather up all 300 #t4031170#s and 100 #t4031171#s needed for the #bTime Sphere#k?");
			
			if (!Exchange(76600, 4031171, -100, 4031175, -300))
			{
				self.say("Are you sure you have everything I asked for? Please check and talk to me again.");
				return;
			}
			
			AddEXP(27600);
			SetQuestData(7100000, "2");
			self.say("Okay, now I'll try to make the #bTime Sphere#k out of the items you got me. I may also need something else for this, so ... talk to me when you're ready.");
		}
		else if (quest == "2")
		{
			bool start3 = AskYesNo("I'm making the Time Sphere as we speak with the materials that you got me. In the mean time, we'll need to find #b#t4031179##k to seal up the cracked dimension in the generator.");
			
			if (!start3)
			{
				self.say("Simply re-creating Time Sphere will not be enough to supply all the power Ludibrium needs. In order to eliminate the monster that made its way here that abused the power of Time Sphere, you'll need to effectively seal up the cracked dimension it used to enter here in the first place. ");
				return;
			}
			
			SetQuestData(7100000, "3");
			self.say("Nice. Well, I'll need a piece that can effectively seal up the crack in dimension. You should go visit #p2041023# for this, who should be standing on the left side of the Path of Time. Flo should tell you all you need to know about the #b#t4031179##k. You'll need to gather up #t4031179# from him.");
		}
		else if (quest == "3")
		{
			string flo = GetQuestData(7100001);
			
			if (flo != "e")
			{
				self.say("What the, are you sure you brought the cracked piece of dimension the way it should be brought?");
				return;
			}
			
			if (ItemCount(4031179) < 1)
			{
				self.say("Didn't you get it confirmed by #p2041023#?");
				return;
			}
			
			self.say("Are you here for #t4031179:#? The Time Sphere should be well on its way, but we still need some time for this.");
			
			if (!Exchange(15000, 4031179, -1))
			{
				self.say("What the, are you sure you brought the cracked piece of dimension the way it should be brought?");
				return;
			}
			
			AddEXP(5600);
			SetQuestData(7100000, "e");
			QuestEndEffect();
			self.say("I think this is right one. I can feel the ultimate force of Papulatus here... this Time Sphere, as soon as finished, will be returned back to the power generating room. Until then, we need to destroy the old Time Sphere that provided incredible power to Papulatus Clock, and kick Papulatus out of here. When you are ready to take on this hard task, let me know. You need to be at least over level 80 to be able to handle this.");
		}
	}
	
	private void DefeatPapulatus(string quest)
	{
		if (quest == "")
		{
			bool start4 = AskYesNo("Only thing we have to do now ...is to make #o8500002# disappear forever... are you ready?");
			
			if (!start4)
			{
				self.say("Oh really. Do you need more time? I'm fully confident that you'll help me out before the Time Sphere is formed.");
				return;
			}
			
			if (!Exchange(0, 4031179, 1))
			{
				self.say("Are you sure there's room for this in your etc. inventory?");
				return;
			}
			
			SetQuestData(7100002, "001");
			self.say("I'll explain to you what you need to do from here on out. \nTo enter the power-generating room, you'll need to pass either #bForgotten Passage#k or the #bWarped Passage#k. Once you defeat whichever monster that is guarding the passage, you can obtain #b#t4031172##k, which is needed to enter the power-generating room.");
			self.say("Then enter the room through the door in the middle. It's going to be MUCH quieter than you imagined. The Time Sphere should be hidden in a state undetectable in our eyes... but if you seal up the crack in dimension, the #o8500002#, panicking because its exit route is sealed up, will make its appearance there.");
			self.say("Drop the #b#t4031179:##k that I returned to you to seal up whatever crack you see that #o8500002# may have used to enter this dimension in the first place. Then it'll come out of the Time Sphere and show everyone its true appearance. Please, please kill it and then come back.");
		}
		else
		{
			if (quest != "000")
			{
				self.say("#o8500001#...isn't eliminated yet.");
				return;
			}
			
			self.say("The Time Sphere is almost complete. Have you eliminated the #o8500002#?");
			
			if (!ExchangeEx(150000, "1102057,Variation:2", 1))
			{
				self.say("Make sure there's at least 1 free slot available in your equip. window first.");
				return;
			}
			
			AddEXP(78000);
			AddFame(30);
			SetQuestData(7100002, "e");
			QuestEndEffect();
			self.say("Thank you so much. #n#o8500002##k is finally gone. We'll need to get this newly-made Time Sphere right back to where it belongs.\n\nThis cape is a cape with Ludibrium symbols stitched on it. This one's for you.");
		}
	}
	
	private void LostPiece1(string quest)
	{
		if (quest == "s")
		{
			self.say("#bFlo#k is at the entrance towards #bWarped Path of Time#k");
			return;
		}
		
		bool start = AskYesNo("Oh no, did you lose the piece of cracked dimension by any chance? That's a rare, precious item, and without that, you won't be able to enter the center of the clocktower. Oh no... well, are you willing to take one more crack at it?");
		
		if (!start)
		{
			self.say("You don't want to take another crack on the challenge. I know it's not easy taking on Papulatus.");
			return;
		}
		
		SetQuestData(7100003, "s");
		self.say("Alright. I may not be blessed with many abilities, so you may need to talk to #bFlo#k, who's at the left side of the Path of Time.");
	}
	
	private void LostMedal(string quest)
	{
		if (quest == "s")
		{
			self.say("#bFlo#k is at the entrance towards #bWarped Path of Time#k");
			return;
		}
		
		bool start = AskYesNo("Oh no, did you lose the Ludibrium Medal by any chance? That's a rare, precious item, and without that, you won't be able to enter the center of the clocktower. Oh no... well, are you willing to take one more crack at it?");
		
		if (!start)
		{
			self.say("You don't want to take another crack on the challenge. It's not easy defeating Papulatus.");
			return;
		}
		
		SetQuestData(7100004, "s");
		self.say("Alright. I may not be blessed with many abilities, so you may need to talk to #bFlo#k, who's in Path of Time.");
	}
	
	private void LostPiece2(string quest)
	{
		if (quest == "")
		{
			int start = AskMenu("Have you met #p2041023#? Did you bring back the #t4031179# that I asked you to get?#b",
				(0, " I'm sorry. I somehow lost the Piece of Cracked\r\nDimension that #p2041023# gave me..."),
				(1, " Hahaha... I... um... haven't met Flo yet. I seriously cannot\r\nfind a way to locate this person! Haha... ha... There is NO WAY I'd ever lose the Piece of Cracked Dimsension that\r\nFlo gave me. Hahaha... ha... ha..."));
			
			if (start == 1)
			{
				self.say("Really?? Did I not tell you where #p2041023# is? I am so sorry; I must have forgotten. Please head over to the #bEntrance to the Warped Path of Time#k, which is located at the opposite end. That's where you'll meet #b#p2041023##k. Seriously, you haven't really lost it, have you? Hahaha...");
				return;
			}
			
			bool start2 = AskYesNo("What? #t4031179# is REALLY difficult to get! If #p2041023# ever finds out that you lost the piece of crack, then all hell may break loose. The more important problem here is that without the piece of crack, there is no way we can cover up the crack of time at the Generator. Man... are you honestly really trying to help me restore Ludibrium back to its original state?");
			
			if (!start2)
			{
				self.say("If you don't mean what you say, then I seriously suggest that you take your hands off this task. There will be much more difficult and challenging tasks that lay ahead and this is not something that should be taken lightly. Come back when you're 100% ready.");
				return;
			}
			
			SetQuestData(7100005, "s");
			self.say("I understand. Everyone makes mistakes. I see that you're trying to help me with good intentions, and I apologize for acting like the way I did to you. Oh well... please go visit #b#p2041023##k. Hopefully he does not get too terribly upset by this.");
		}
		else if (quest == "s")
		{
			self.say("Please go see #b#p2041023# immediately. He may not like what he hears, but he understands the significance of this situation, so just be #btotally honest#k to him, and he may help you out.");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		var today = DateTime.UtcNow;
		
		if (quest == 7100000)
		{
			if ((info == "" && Level >= 60) || info == "s")
				return " Protect Ludibrium";
			
			else if (info == "1")
				return " The Replacement Time Energy";
			
			else if (info == "2" || info == "3")
				return " The Time Sphere";
		}
		else if (quest == 7100002)
		{
			string papulatus = GetQuestData(7100000);
			
			if (papulatus == "e" && info != "e" && Level >= 80)
				return " Eliminating Papulatus";
		}
		else if (quest == 7100003)
		{
			string papulatus = GetQuestData(7100002);
			var saveddate = DateTime.Parse(GetQuestData(7100006, "2020-01-01"));
			
			if (papulatus != "" && ItemCount(4031179) < 1 && today >= saveddate)
				return " The Lost Piece of Crack";
		}
		else if (quest == 7100004)
		{
			string papulatus = GetQuestData(7100002);
			var saveddate = DateTime.Parse(GetQuestData(7100007, "2020-01-01"));
			
			if (papulatus == "e" && ItemCount(4031172) < 1 && today >= saveddate)
				return " The Lost Medal";
		}
		else if (quest == 7100005)
		{
			string papulatus = GetQuestData(7100000);
			string flo = GetQuestData(7100001);
			
			if ((papulatus == "3" && flo == "e" && ItemCount(4031179) < 1 && info == "") || info == "s")
				return " The Lost Piece of Crack";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {7100000, 7100002, 7100003, 7100004, 7100005};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "I'm Mr. Bouffon, in charge of protecting the Path of Time.";
		
		if (GetQuestData(7100002) == "e")
			dialogue = "Thanks to you the root of all evil in Ludibrium is gone forever! Only the peaceful days shall lay ahead.";
		
		if (options.Count == 0)
		{
			self.say(dialogue);
			return;
		}
		
		int choice = -1;
		
		if (options.Count >= 2)
			choice = AskMenu($"{dialogue}#b", options.ToArray());
		else
			choice = options[0].Index;
		
		switch(choice)
		{
			case 0: Papulatus(GetQuestData(7100000)); break;
			case 1: DefeatPapulatus(GetQuestData(7100002)); break;
			case 2: LostPiece1(GetQuestData(7100003)); break;
			case 3: LostMedal(GetQuestData(7100004)); break;
			case 4: LostPiece2(GetQuestData(7100005)); break;
		}
	}
}