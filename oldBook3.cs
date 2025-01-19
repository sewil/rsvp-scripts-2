using System;
using System.Collections.Generic;
using WvsBeta.Game;

// 2012010 Elma the Housekeeper
public class NpcScript : IScriptV2
{
	private void OldBook(string quest)
	{
		string questBook2 = GetQuestData(1001501);
		
		if (quest == "s")
		{
			int askHella = AskMenu("Miss Hella left the house months ago and hasn't been back since. Visitors drop by everyday looking for Hella and leave. Do you have something to say to her? I'll give her the message once she gets back here.#b",
				(0, " It's okay, don't worry about it."),
				(1, " Did Hella have any close friends?"),
				(2, " Do you have any clue as to where Hella might have went?"));
			
			if (askHella == 0)
			{
				self.say("I would like to tell you to come back later but I have no clue as to when she'll be back so I really don't have much to say to you. I haven't heard a word from her in months so I am really worried now. If you ever find out how #bMiss Hella#k is doing, please let me know. Thank you.");
			}
			else if (askHella == 1)
			{
				self.say("A close friend? Oh, him! A good friend of hers lives in #bEl Nath#k. His name is #bJade#k, and he's been friends with Miss Hella since childhood so he may have a clue as to where she might have went.");
				SetQuestData(1001500, "hs");
				SetQuestData(1001501, "s");
			}
			else if (askHella == 2)
			{
				self.say("If I knew where she was, then I wouldn't be doing this. Miss Hella doesn't divulge in her plans to begin with, and one of her favorite things to do is traveling. I tried to stop her a number of times, but now I've totally given up. Where did she go this time? I really would like to know myself.");
			}
		}
		else if (quest == "hs")
		{
			if (questBook2 == "s" || questBook2 == "h1")
			{
				self.say("Have you met #bJade#k from #bEl Nath#k? He's been friends with Miss Hella since childhood so he may have a clue as to where she might have gone. Please let me know if you find out her whereabouts.");
			}
			else if (questBook2 == "h2")
			{
				AddEXP(2000);
				SetQuestData(1001501, "h3");
				self.say("Did you see Jade from El Nath? So he has no clue, too. You heard about Miss Hella's late mother's keepsake? Oh yes...one pitch black night someone stole the item and Miss Hella hasn't been the same since ... but I have no clue who stole the item.");
				self.say("Oh yes! A few days before Miss Hella left, I heard her mentioning something about an #bold lady#k. We don't have an old lady in this town, so I don't know exactly what she was talking about ... perhaps #bJade#k may know something about the her. Jade loves traveling around the island, and is aware of things outside this town.");
			}
			else
			{
				self.say("A few days before Miss Hella left I heard her mention something about an #bold lady#k. We don't have an old lady in this town, so I didn't know exactly what she was talking about...perhaps #bJade#k may know something about the her. Jade loves traveling around the island.");
			}
		}
	}
	
	private void Alfonse(string quest)
	{
		if (quest == "3")
		{
			if (ItemCount(4031200) < 1)
			{
				self.say("Hey you're the one who needed the #t4031202#, right? What did Ericsson say?");
				return;
			}
			
			bool start = AskYesNo("Hello there~ we meet again! You must have gotten #b#t04031200##k this time around! I told you. Get something for Nero, and #p2012018# will be only too happy to make #b#t4031200##k. So are you going to use this sap to make #b#t4031202##k?");
			
			if (!start)
			{
				self.say("You don't need #t4031202#? If you have a change of heart, please feel free to see me.");
				return;
			}
			
			SetQuestData(1005900, "4");
			self.say("I can tell Alfonse wants to drink #b#t4031202##k again! Okay, I'll fix him a very nutritious, tasty #b#t4031202##k.");
			self.say("I need some ingredients in order to make the #t4031202#. I'll need #b#t4031200#, 20 #t4000136#s, 1 #t4031201#, and 1 #t2022039##k, along with my service charge of #b20,000 mesos#k.");
			self.say("Surprised that the juice requires a lot of ingredients? Well, you have #b#t4031200##k already, so that's out of the way. #b#t4000136##k can be found at the #bFlorina Beach#k. As for #b#t4031201##k ... I've used up the last of that a few days ago, so I'll have to get some more of it.");
			self.say("I got that from #b#p1032105##k of Victoria Island years ago. Look for #b#p1032105##k, because she's the one that gave me it.\r\n#b#t2022039##k can be found through hunting #b#o4230105##k.");
			self.say("I know it's not easy to gather all of them up, but please do so. That way, I can fix Alfonse a hearty glass of Nependeath Juice.");
		}
		else if (quest == "4")
		{
			if (ItemCount(2022039) < 1 || ItemCount(4000136) < 20 || ItemCount(4031200) < 1 || ItemCount(4031201) < 1)
			{
				self.say("I don't think you have gathered up all the ingredients yet. I need all of them in order to make a hearty Nependeath Juice.");
				return;
			}
			
			bool start2 = AskYesNo("Alright, the #b#t4031202##k is finally ready~ You should go see #bAlfonse#k right now. He's probably dying to see you right this minute with that in your hand.");
			
			if (!start2)
			{
				self.say("Wasn't #t4031202# for Alfonse Green? Imagine the disappointment he'll face if you didn't bring that to him?");
				return;
			}
			
			if (!Exchange(-20000, 4031200, -1, 4031201, -1, 4000136, -20, 2022039, -1, 4031202, 1))
			{
				self.say("Are you sure you have #b20,000#k mesos? If so, please make some room in your etc. inventory for the glass of Nependeath Juice.");
				return;
			}
			
			AddEXP(7500);
			SetQuestData(1005900, "5");
			SetQuestData(1005902, "e");
			QuestEndEffect();
			self.say("Alfonse is probably dreaming about the juice right as we speak. He really really loves #t4031202#.");
		}
		else if (quest == "5")
		{
			if (ItemCount(4031202) >= 1)
			{
				self.say("Please go see Alfonse right now. He may be waiting for you.");
				return;
			}
			
			self.say("Alfonse is probably dreaming about the juice right as we speak. He really really loves #t4031202#.");
			
			if (!Exchange(0, 4031202, 1))
			{
				self.say("Please make some room in your etc. inventory for the glass of Nependeath Juice.");
				return;
			}
		}
	}
	
	private void Nero(string quest)
	{
		if (quest == "")
		{
			self.say("You're looking for the sap of Nependeath? Only Ericsson can make that.");
			self.say("Ericsson blew you off to hang out with his cat? Hmm ... then how about this? Make a small present for his cat Nero. Ericsson will then be happy enough to make you one.");
			self.say("The owner's not here right now, so I'll just help you out here. I am no slouch either, and I can make #b#t4031199##k myself.");
			
			SetQuestData(1005901, "s");
			self.say("Give that to Ericsson for his cat, and he'll love it. To make the Lunar Wristband, I'll need #b100 #t4000059#s and 80 #t4000060#s#k. For #b10,000 mesos#k, I'll make it for you right here on the spot.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4000059) < 100 || ItemCount(4000060) < 80)
			{
				self.say("I don't think you have gathered up all the materials yet. I'll tell you what I need to make the wristband: #b100 #t4000059#s and 80 #t4000060#s#k.");
				return;
			}
			
			self.say("All the materials are here. Great job! Hold on one second. The wristband should be out in no time.");
			
			if (!Exchange(-10000, 4000059, -100, 4000060, -80, 4031199, 1))
			{
				self.say("Are you sure you have #b10,000#k mesos? If so, please make some room in your etc. inventory for the wristband.");
				return;
			}
			
			AddEXP(7500);
			SetQuestData(1005901, "1");
			self.say("Here it is! Take this to Ericsson, and he cannot possibly say no to making #b#t4031200##k for you. Good luck!");
		}
		else if (quest == "1")
		{
			if (ItemCount(4031199) >= 1)
			{
				self.say("Take this to Ericsson, and he cannot possibly say no to making #b#t4031200##k for you. Good luck!");
				return;
			}
			
			self.say("Take this to Ericsson, and he cannot possibly say no to making #b#t4031200##k for you. Good luck!");
			
			if (!Exchange(0, 4031199, 1))
			{
				self.say("Please make some room in your etc. inventory for the wristband.");
			}
		}
	}
	
	private void Sprayer(string quest)
	{
		if (quest == "s")
		{
			AskMenu("How can I help you? I'm in the midst of cleaning up place, so I do not have much time with me. It looks like you'll be covered with dirt in no time if you just stand there...#b",
				(0, " I'm here to collect the #t4031308# that you have borrowed 50 years ago.")
			);
			self.say("#t4031308#? Isn't that the item I lent to #p2032001# 50 years ago. Maybe I haven't returned it yet. Please wait.");
			self.say("Ah, here it is!! I should have returned this much sooner... Please tell Spiruna I sincerely apologize for not returning it sooner. I had been swamped with work, and I guess this is a way to put off work until the last second. I won't ever do that again...");
			
			if (!Exchange(0, 4031308, 1))
			{
				self.say("Please make sure there is some room in your etc. inventory first.");
				return;
			}
			
			AddEXP(500);
			SetQuestData(1009803, "1");
			self.say("I don't think anything's wrong with it. It's just currently covered in dust, thanks to the fact that this item has not been used for so long... ");
		}
		else if (quest == "1")
		{
			if (ItemCount(4031308) >= 1)
			{
				self.say("I can't believe I'd be THE PERSON to borrow the item, only to keep it with me for FIFTY YEARS! I feel horrible now... and please tell Spiruna I feel bad about this...");
				return;
			}
			
			self.say("How can you leave the Cloud Sprayer here when you told me you need to give that to Spiruna? Here, take it. Please tell Spiruna I'm really sorry for returning it really late.");
			
			if (!Exchange(0, 4031308, 1))
			{
				self.say("Please make sure there is some room in your etc. inventory first.");
			}
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1001500)
		{
			string questBook2 = GetQuestData(1001501);
			
			if (info == "s")
				return " Hella's Missing";
			
			else if (info == "hs")
			{
				if (questBook2 == "s" || questBook2 == "h1")
					return " Where's Hella?";
				
				else if (questBook2 == "h2")
					return " One Clue";
				
				else
					return " Looking For the Old Lady";
			}
		}
		else if (quest == 1005900)
		{
			if (info == "3" || info == "4" || info == "5")
				return " Elma's Nependeath Juice";
		}
		else if (quest == 1005901)
		{
			string alfonse = GetQuestData(1005900);
			
			if (alfonse == "1")
				return " A Present for Nero";
		}
		else if (quest == 1009803)
		{
			if (info == "s" || info == "1")
				return " The Sprayer Elma Borrowed";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1001500, 1005900, 1005901, 1009803};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string questBook1 = GetQuestData(1001500);
		
		string dialogue = "It looks like you've been looking for her too. Do you have any idea how this all happened? I wonder where she is.";
		
		if (questBook1 == "" || questBook1 == "s" || questBook1 == "hs")
			dialogue = "It's been months since she left out of the blue. I haven't had much to work lately, so that's good, but I also haven't been paid in months because she's not here. I'm just worried someone else may take over this house and I may never get paid...";
		
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
			case 0: OldBook(GetQuestData(1001500)); break;
			case 1: Alfonse(GetQuestData(1005900)); break;
			case 2: Nero(GetQuestData(1005901)); break;
			case 3: Sprayer(GetQuestData(1009803)); break;
		}
	}
}