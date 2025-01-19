using System;
using System.Collections.Generic;
using WvsBeta.Game;

// 2060001 Robinson
public class NpcScript : IScriptV2
{
	private void Lost()
	{
		string quest = GetQuestData(1007400);
		
		if (quest == "s")
		{
			AskMenu("Oh, a person? It's a person!!! I'm alive now!!!#b",
				(0, " Are you the one that sent out this letter?"));
			bool start = AskYesNo("That's correct. I was the one who delivered the letter. I \r\nshould ... ... cough cough!!! Hah ... hah ... please help me \r\nout... please...");
			
			if (!start)
			{
				self.say("So am I going to ... die ... in this place ...?");
				return;
			}
			
			if (!Exchange(0, 4031209, -1))
			{
				self.say("Huh... did you lose the letter?");
				return;
			}
			
			SetQuestData(1007400, "1");
			self.say("Hah... hah ... I've been suffering from dehydration for a while now. There's no drinking water in this place ... if I drink ocean water, I would have dehydrated and died. Please get me \r\n#b#t2022000##k.");
		}
		else if (quest == "1")
		{
			if (ItemCount(2022000) < 1)
			{
				self.say("Is the water still ... ? The sun is scorching my back now, and my body has gotten completely dried up. Please ... please, somebody get me #bPure Water#k.");
				return;
			}
			
			self.say("Water ... are... are you holding on to water? Oh, it is water ... please give me that water!");
			
			if (!Exchange(0, 2022000, -1, 4031210, 1))
			{
				self.say("Huh... please make a space in your etc. inventory first.");
				return;
			}
			
			AddEXP(5000);
			SetQuestData(1007400, "2");
			self.say("Hah, now I feel like living. I didn't know a simple bottle of water will really mean a lot me. Thank you so much! You're my hero, the one that saved my life. Since you came all the way here after reading the email, I'd like to ask you something...special.");
			self.say("I'm Robinson, the pilot of the Omega Sector army. One day, I received an order from the commander and I was on my way to delivering that item when I got ambushed by the aliens and made an emergency landing.");
			self.say("I wasn't seriously injured when I crash-landed, so I got out of the transport ship and ran away from the aliens. To further avoid the aliens, I dove into the ocean, not knowing I was about to be swept away by a huge tidal wave, and I lost conscious. By the time I woke up, I found myself here in this remote island, so I wrote a letter and float it on the water looking for help.");
			self.say("I'm glad my effort didn't go unnoticed, seeing that you're here after reading the letter. Now that you are here, please help me. I need to return to the Omega Sector immediately, but I have no idea where I am at, and I am considerably weaker than I was before. I can't even think of getting out of here by myself, so please go to the Omega Sector in place of me and notify them of my situation so they can send some people here to rescue me.");
			self.say("This is my ID. Hand this to #b#p2051001##k of the Omega Sector so he can send me some help here. Thanks!");
		}
		else if (quest == "2")
		{
			if (ItemCount(4031210) >= 1)
			{
				self.say("Hand the ID to #b#p2051001##k of the Omega Sector so he can send me some help here. Thanks!");
				return;
			}
			
			self.say("You'll need to take my ID in order for the Omega Sector to send me some help here. Good luck!");
			
			if (!Exchange(0, 4031210, 1))
			{
				self.say("Huh... please make a space in your etc. inventory first.");
				return;
			}
		}
		else if (quest == "3")
		{
			if (ItemCount(4031221) < 1)
			{
				self.say("Hey, how come you came back by yourself? What about the rescuers?");
				return;
			}
			
			AskMenu("Hey, how come you came back by yourself? What about the rescuers?#b",
				(0, " I was told to give you this."));
				
			self.say("Oh, this is the #t4031221# that was supposedly in development. With this, I can return to the Omega Sector in a hurry. Thank you so much, and as a sign of thanks, I'll give you my equipment.");
			
			int itemID = -1;
			
			if (Job < 100) itemID = 1002020;
			else if (Job >= 100 && Job < 200) itemID = 1002047;
			else if (Job >= 200 && Job < 300) itemID = 1002153;
			else if (Job >= 300 && Job < 400) itemID = 1002166;
			else if (Job >= 400 && Job < 500) itemID = 1002181;
			
			if (!ExchangeEx(0, "4031221", -1, $"{itemID},Variation:1", 1))
			{
				self.say("Please make some room in your equip. inventory first so I can give you my equipment.");
				return;
			}
			
			AddEXP(10000);
			SetQuestData(1007400, "e");
			QuestEndEffect();
			self.say("Thank you so much. Now I can head back to the Sector with ease. I'll never forget this. Thank you.");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1007400)
		{
			if ((Level >= 35 && ItemCount(4031209) >= 1 && info == "s") || info == "1")
				return " The Bottled-up Letter";
			
			else if (info == "2")
				return " Robinson's ID";
			
			else if (info == "3")
				return " Sending Relief";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1007400};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "How long have I been here in this island? I don't even know the date now.";
		
		if (GetQuestData(1007400) == "e")
			dialogue = "I better get out of this island now and return to the headquarters.";
		
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
			case 0: Lost(); break;
		}
	}
}