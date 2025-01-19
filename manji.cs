using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Medicine()
	{
		string quest = GetQuestData(1000200);
		
		if (quest == "m3")
		{
			self.say("So you want to acquire #b#t4031005##k? Hah ... that's not for a nobody like you. Can't have #t4031005# in your hand unless you're the strong one ... If you really want it, prove me wrong and show me that you really are strong enough and worthy of it...");
			self.say("There's a huge cave underground in the middle of this \r\nisland ... and in the deepest part live the mutants of Arcon. Take down those monsters in the cave and collect #b#e40 pieces of #t4000008##k#n. Are you brave enough to put yourself in there?");
			self.say("That's right ... #b#t4000008##k looks like this #i4000008#. I'm doing this for a first-timer like you, so be thankful.");
			SetQuestData(1000200, "m4");
		}
		else if (quest == "m4")
		{
			if (ItemCount(4000008) < 40)
			{
				self.say("If you want to get #t4031005# from me, you need to defeat the monster in the underground tunnel and collect #b#e40 pieces of #t4000008##k#n. Before all this happens, I can't give #t4031005# to a nobody like you...");
				return;
			}
			
			self.say("Hmmm... I may have underestimated you... alright, here's \r\n#t4031005#, since a promise is definitely a promise. Take it.");
			
			if (!Exchange(0, 4000008, -40, 4031005, 1))
			{
				self.say("Make some room in your etc. inventory first if you want the #t4031005#.");
				return;
			}
			
			SetQuestData(1000200, "m5");
			self.say("It's the bottle that contains the blood of Arcon that I have slain before ... Hopefully you'll use this wisely, because it's a rare, precious item...");
			self.say("By the way what are you going to do with #b#t4031005##k? It's used as a material for precious important items, so ... are you going to take it to #p1022100#? Anyway it's none of your business.");
		}
		else if (quest == "m5")
		{
			if (ItemCount(4031005) >= 1)
			{
				self.say("By the way what are you going to do with #b#t4031005##k? It's used as a material for precious important items, so ... are you going to take it to #p1022100#? Well, it's none of business anyway ...");
				return;
			}
			
			self.say("By the way what are you going to do with #b#t4031005##k? It's used as a material for precious important items, so ... are you going to take it to #p1022100#? Well, it's none of business anyway ...");
			
			if (!Exchange(0, 4031005, 1))
			{
				self.say("Make some room in your etc. inventory first if you want the #t4031005#.");
				return;
			}
		}
	}
	
	private void Gladius()
	{
		string quest = GetQuestData(1000201);
		
		if (quest == "")
		{
			self.say("Ok so who's bothering me now ... hey!! You have a knack for annoying me even at the best of times ... well, that's alright. If you have indeed gotten that much stronger, then I'd like to see it firsthand. Did you put #t4031005# to good use? Well, it's all in the past, so ...");
			bool askStart = AskYesNo("I would like you to help me out once. Of course, I can take care of it myself, but I can't leave this area. What do you \r\nthink...? You seem to have gotten strong enough to handle \r\nit easily ... will you take a crack at it?");
			
			if (!askStart)
			{
				self.say("Hah ... must be still hating the fact that I thought nothing of you before ... You can't catch up with me with that kind of a mindset! Now I'm not so sure if I'll accept you even if you decide to change your mind ... hahah.");
				return;
			}
			
			if (!Exchange(0, 1302014, 1))
			{
				self.say("Leave an empty space in your equip. inventory first.");
				return;
			}
			
			SetQuestData(1000201, "ms");
			self.say("Good decision. A few decades ago, I went into a huge cave in the middle of this island. In there I felt this force of evil only I could feel, and I was sucked into it, following it deeper into the cave ... I felt a sense of danger inside but that didn't prevent me from walking further into the cave.");
			self.say("By the time I regained consciousness, everything around me was blue. And in the middle of darkness I saw a pair of piercing eyes staring at me. He was ... yeah, the mythical, legendary Balrog. Possessing a huge set of wings and the teeth so sharp it could have cut through anything ...");
			self.say("I've spent all my life fighting, but his presence was undeniably overwhelming. My mind was telling me it was impossible to beat him, but it was already right in front of me. His weighty tail went up, high up ... and starting moving towards me!");
			self.say("Right at that second, someone stood in my way. This man, with a mysterious aura around his sword, fought Balrog straight up, enabling me to escape. After rescuing me, he was struck by Balrog's teeth and fell down the cliff. He \r\nwas ... yes, the hero of legendary proportion, Tristan.");
			self.say("I went all the way down to where he ultimately fell. He didn't look like he had much of a chance. Before it was too late, he handed me the #b#t1302014##k, by then worn-out by the sheer evil of Balrog, and then passed away. This is that same sword right here. I would love to restore this to its original state.");
			self.say("The sword becomes #b#t1302015##k once it is reawaken. However, as for the details of how to reawaken it, I have no idea. I think you have to eliminate the evil force of Balrog, though ... You should go see #p1061000# from \r\n#m105040300# and ask about it.");
		}
		else if (quest == "ms" || quest == "mc")
		{
			if (ItemCount(1302014) >= 1)
			{
				self.say("I want you to awaken #b#t1302014##k that I gave you with #b#t1302015##k. #r#p1061000##k of #m105040300# may know the way to do it. If you return the reawaken sword to me ... I'll definitely reward you for your hard work. Let's see if you can do this ...");
				return;
			}
			
			self.say("The sword becomes #b#t1302015##k once it is reawaken. However, as for the details of how to reawaken it, I have no idea. I think you have to eliminate the evil force of Balrog, though ... You should go see #p1061000# from \r\n#m105040300# and ask about it.");
			
			if (!Exchange(0, 1302014, 1))
			{
				self.say("Leave an empty space in your equip. inventory first.");
				return;
			}
		}
		else if (quest == "mh")
		{
			if (ItemCount(1302014) >= 1)
			{
				self.say("I want you to awaken #b#t1302014##k that I gave you with #b#t1302015##k. #r#p1061000##k of #m105040300# may know the way to do it. If you return the reawaken sword to me ... I'll definitely reward you for your hard work. Let's see if you can do this ...");
				return;
			}
			
			bool end = AskYesNo("Yes ... it is this sword indeed, the sword that took care of me then ...! What do you think ... are you going to return it to me like you promised? If you do, I'll reward you with the earring that my friend left me with before he passed away.");
			
			if (end)
			{
				if (!Exchange(0, 1302015, -1, 1032012, 1))
				{
					self.say("Are you sure you have #t1302015#? If so, leave an empty space in your equip. inventory.");
					return;
				}
				
				AddEXP(1000);
				SetQuestData(1000201, "yes");
				QuestEndEffect();
				self.say("Thanks for helping me out. We may run into one another some day ... until then, take care ...");
			}
			else if (!end)
			{
				SetQuestData(1000201, "no");
				QuestEndEffect();
				self.say("Huh?? You're not going to return it? You little ... get out of my sight right now!! Don't even think about coming back here.");
			}
		}
	}
	
	private void Shammos()
	{
		string quest = GetQuestData(1007300);
		
		if (quest == "s")
		{
			int start = AskMenu("About #b#t4031218##k? Hey ... how did you find out about it? It's not something you should be aware of ......\r\nWho told you of it???#b",
				(0, " Someone around El Nath told me about it, and also told \r\nme of #t4031218#."),
				(1, " I randomly heard of it while traveling. I want to learn about it too, in hopes of something important like this will help me on my future hunting endeavors."));
			
			if (start == 0)
			{
				self.say("Did the person that told you of the story wants #b#t4031218##k?? That, that is... not something you can just pray for to get. It's very dangerous, and you should stop asking about that special iffy subject.");
				return;
			}
			
			AddEXP(2500);
			SetQuestData(1007300, "1");
			self.say("Hmmm ... I don't know how you found out about it, but ... I think #b#t4031218##k is really a terrifying force. You've done your share of traveling, and I suppose you've never seen any monster that is supposedly dead, but still moves around as if it's alive, like #b#o5130107##k and #b#o5130108##k. They shouldn't be roaming around as if they're alive, but they are, thanks to #b#t4031218##k. It's the very force behind those two and other \"undead\" monsters moving around as if they're alive.");
		}
		else if (quest == "1")
		{
			self.say("Hmmm ... I don't know how you found out about it, but ... I think #b#t4031218##k is really a terrifying force. You've done your share of traveling, and I suppose you've never seen any monster that is supposedly dead, but still moves around as if it's alive, like #b#o5130107##k and #b#o5130108##k. They shouldn't be roaming around as if they're alive, but they are, thanks to #b#t4031218##k. It's the very force behind those two and other \"undead\" monsters moving around as if they're alive.");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1000200)
		{
			if (info == "m3")
				return " Arcon's Blood?";
			
			else if (info == "m4" || info == "m5")
				return " Getting Arcon's Blood";
		}
		else if (quest == 1000201)
		{
			string medicine = GetQuestData(1000200);
			
			if ((info == "" && Level >= 45 && medicine == "end") || info == "ms" || info == "mc" || info == "mh")
				return " Hero's Gladius";
		}
		if (quest == 1007300)
		{
			if (info == "s")
				return " Shammos's Request";
			
			else if (info == "1")
				return " The Secrets Behind the Contract of Darkness";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1000200, 1000201, 1007300};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "Anyone who dares to stand in my path will be punished dearly...";
		
		if (GetQuestData(1000200) == "end")
			dialogue = "Hah... I was wondering who's bothering me, and it's you. Alright, I won't call you a nobody anymore...";
		
		if (GetQuestData(1000201) == "no")
			dialogue = "...";
		
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
			case 0: Medicine(); break;
			case 1: Gladius(); break;
			case 2: Shammos(); break;
		}
	}
}