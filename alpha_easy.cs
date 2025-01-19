using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void AlphaPlatoon()
	{
		string quest = GetQuestData(1001400);
		
		if (quest == "s" || quest == "1" || quest == "10" || quest == "12" || quest == "21")
		{
			self.say("What? You came all the way here by #b#p2020003#'s#k request? I thought I was the only survivor. I knew that nothing can hurt #b#p2020003##k. HAHA!");
			self.say("It is good to hear that he is alive. So he is working at El Nath huh? Okay... I found #b#t4031049##k and this would be somewhat related to our mission.");
			bool meetAlpha = AskYesNo("So #b#p2020003##k will also be wating for this. I will give this to you if you give me 2 #b#t4021005#. You can't say that you have met me without this.");
			
			if (meetAlpha)
			{
				if (!Exchange(0, 4021005, -2, 4031049, 1))
				{
					self.say("Oh... are you sure you have #b2 #t4021005#s#k? If not then see if your etc. inventory is full or not, then come talk to me!");
					return;
				}
				
				AddEXP(3000);
				
				if (quest == "s")
				{
					SetQuestData(1001400, "100");
					self.say("Okay... Now, you gotta meet #p2010000# and #p2030001# ... right? They must have found something like me. So long~");
				}
				else if (quest == "1")
				{
					SetQuestData(1001400, "201");
					self.say("Okay... Now, you gotta meet #p2030001#... right? He must have found something like me. So long~");
				}
				else if (quest == "10")
				{
					SetQuestData(1001400, "210");
					self.say("Okay... Now, you gotta meet #p2010000#... right? He must have found something like me. So long~");
				}
				else if (quest == "12")
				{
					SetQuestData(1001400, "312");
					self.say("I guess you've met all the troopers of the Alpha platoon! I'm sure the other men are just doing their job. Now please notify #b#p2020003##k of our whereabouts. Thanks!");
				}
				else if (quest == "21")
				{
					SetQuestData(1001400, "321");
					self.say("I guess you've met all the troopers of the Alpha platoon! I'm sure the other men are just doing their job. Now please notify #b#p2020003##k of our whereabouts. Thanks!");
				}
			}
		}
		else
		{
			self.say("Haven't we met before? Please get #b#p2020003##k the #b#t4031049##k that I gave you. Thanks! Well, then, back to work...");
		}
	}
	
	private void AncientBook()
	{
		string questBook1 = GetQuestData(1001500);
		
		if (questBook1 == "ms")
		{
			self.say("I'm doing a secret op right now so don't bother me. What? you're here because you need #b#t4031055##k? How did you know I found it? That was a top secret, to say the least. This looks like a very important item so I can't give it to you just like that. If you do me a favor, though, then the story changes. I recently found something I desperately need.");
			
			AddEXP(3000);
			SetQuestData(1001500, "mw");
			self.say("A comrade of mine should be here soon and I had nothing to brag about. I heard at the deep end of the valley exist a scary, humongous wolf, a werewolf! If you collect three of the toenails he offers, I may give you the stuff. My comrade will go crazy if he sees it. Well then, good luck!");
		}
		else if (questBook1 == "mw")
		{
			if (ItemCount(4000053) < 3)
			{
				self.say("Haven't gotten #b3 #t4000053#s#k yet? Oh well, its been infamous for its wildness, and I'm sure you can't do a thing about it. I'm not even sure if you can go deep into the valley safely. Anyway collect #b3 #t4000053#s#k and I may hand you #b#t4031055##k, so keep up the good work.");
				return;
			}
			
			self.say("I can't believe you collected all of them. I may see you in a different light now. You took down the same monster that even our general was hesitant of ... that's just incredible! Anyway a promise is a promise so here's the #b#t4031055##k I found during the operation.");
			
			if (!Exchange(0, 4000053, -3, 4031055, 1))
			{
				self.say("Please leave some room in your etc. inventory first.");
				return;
			}
			
			AddEXP(6340);
			SetQuestData(1001500, "mg");
			self.say("I don't know what you're going to do with it, but it's a pretty important item so I suggest you handle it with care. If you screw it up and throw it away in an accident, it'll vanish without a trace, so be really careful with it. Well then, bye~");
		}
		else if (questBook1 == "mg")
		{
			if (ItemCount(4031055) >= 1)
			{
				self.say("I don't know what you're going to do with it, but it's a pretty important item so I suggest you handle it with care. If you screw it up and throw it away in an accident, it'll vanish without a trace, so be really careful with it. Well then, bye~");
				return;
			}
			
			if (!Exchange(0, 4031055, 1))
			{
				self.say("If you would like some more of the #t4031055#, you have to make room in your etc. inventory first.");
				return;
			}
			
			self.say("I don't know what you're going to do with it, but it's a pretty important item so I suggest you handle it with care. If you screw it up and throw it away in an accident, it'll vanish without a trace, so be really careful with it. Well then, bye~");
		}
	}
	
	private bool Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1001400)
		{
			if (info != "" && !info.Contains("end"))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (quest == 1001500)
		{
			if (info == "ms" || info == "mw" || info == "mg")
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
		bool checkAlpha = Check(1001400);
		bool checkBook = Check(1001500);
		
		if (!checkAlpha && !checkBook)
		{
			self.say("This is a strange place ... It looks like an old, abandoned tower. I'm #b#p2030002##k, member of the Alpha platoon. I was headed somewhere on the aeroboat when a freak accident forced us to land here on an emergency, and I am worried that I don't see any of the other troopers around, but I'm sure they are all alive and well. Well, then, back to work...!");
			return;
		}
		
		if (checkAlpha && !checkBook)
		{
			AlphaPlatoon();
		}
		else if (!checkAlpha && checkBook)
		{
			AncientBook();
		}
		else
		{
			int askQuest = AskMenu("This is a strange place ... It looks like an old, abandoned tower. I'm #b#p2030002##k, member of the Alpha platoon. I was headed somewhere on the aeroboat when a freak accident forced us to land here on an emergency, and I am worried that I don't see any of the other troopers around, but I'm sure they are all alive and well. Well, then, back to work...!#b",
				(0, " Alpha Platoon's Network of Communication"),
				(1, " Looking for a Book of Ancient"));
			
			if (askQuest == 0)
			{
				AlphaPlatoon();
			}
			else if (askQuest == 1)
			{
				AncientBook();
			}
		}
	}
}