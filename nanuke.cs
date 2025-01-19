using System;
using System.Collections.Generic;
using WvsBeta.Game;

// 2060000 Nanuke
public class NpcScript : IScriptV2
{
	private void Huskies(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("Hello, my name is #p2060000#. You must be a traveler of some sort, for you to make your way all the way down to this remote island. I live here, raising huskies. These boys are my family, my closest friends. I know I've just met you, and I apologize in advance for asking, but would you like to help me out?");
			
			if (!start)
			{
				self.say("I may have gone too far by asking for help to someone I've just met. Just forget what I said, and have fun here at the island. It would have been nice for my huskies to have a piece of that seal meat though...");
				return;
			}
			
			SetQuestData(1006400, "s");
			self.say("I appreciate you saying yes. These huskies have voracious appetite, and I've just fed them the last meal I made with the food I brought from El Nath. I heard that the seals that live around here are very nutritious. Can you get me #b50 #t4000157#s#k for my huskies? Please help me~");
		}
		else if (quest == "s")
		{
			if (ItemCount(4000157) < 50)
			{
				self.say("Aren't the seals hard to handle? They are especially tough to handle, and if you're not used to the water, that was the end for you. #b50 #t4000157#s#k are what I need to feed the huskies.");
				return;
			}
			
			self.say("I was worried about the high tidal wave. Isn't that the seal meat? Wow, I can't believe you got them all! Weren't those seals tough to deal with? This is incredible!");
			
			if (!Exchange(0, 4000157, -50, 2020007, 50))
			{
				self.say("Are you sure you brought all the seal meat? If so, please make sure there is room in your use inventory!");
				return;
			}
			
			AddEXP(10000);
			SetQuestData(1006400, "e");
			QuestEndEffect();
			self.say("Do you like the reward I'm giving you? It's the least I can do to show my appreciation to someone that gathered up a whole lot of rare #t4000157#s. Have fun on the rest of your journey, and if you feel uncomfortable traveling around water, you will always be welcome here.");
		}
	}
	
	private void Chair(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("Hello, my name is #p2060000#. You must be a traveler of some sort, for you to make your way all the way down to this remote island. I live here, raising huskies. These boys are my family, and they're also my closest friends. I heard it's MG2's birthday. I haven't celebrated anyone's birthday in a long time, so this year, I made an item that'll let myself and others kick back and enjoy the celebration, hahaha. Say, would you like one?");
			
			if (!start)
			{
				self.say("I see. Birthday celebrations end sooner than you may think, and I will not make this chair after the event. If you decide to change your mind, then just look for me and my huskies.");
				return;
			}
			
			self.say("I knew you'd say yes. It's a nifty chair, indeed. It'll allow you to relax pretty much wherever you go.");
			
			if (!Exchange(0, 3010000, 1))
			{
				self.say("Hmm... please make sure there's a slot open in your set-up inventory first!");
				return;
			}
			
			SetQuestData(8020015, "e");
			QuestEndEffect();
			self.say("This chair can come very handy for you. If you're low on HP and MP, sit on this chair wherever you are, and just relax. Your HP and MP will be back up in no time! Hope you have safe travels! Peace!");
		}
	}
	
	private void Ingredients(string quest)
	{
		if (quest == "")
		{
			AskMenu("Hello, there. I'm sure there are many gourmet dishes I've never had a chance to chow down in my life, and I'm doubly sure that the food #p2060006# promised to make will be something special. I'm also very sure that I'll never get to see that food in real life.#b",
				(0, " What is it?")
			);
			AskMenu("My friend #p2060006#, who lives in Aquarium, sent me this letter with a picture of a gourmet dish. She mentioned how delicious it was, since the ingredients were freshly caught in the water. I've only seen it through a picture, but... my gosh, it looked so good.#b",
				(0, " Then why don't you buy one for yourself?")
			);
			AskMenu("I really wanted to, but according to #p2060006#, the ingredients for that dish are almost impossible to get, making it a true, rare gourmet dish! Man... if only I get to sit down and eat it once...#b",
				(0, " Isn't there a way to get it?")
			);
			
			bool start = AskYesNo("#p2060006# said she'll make it for me, as long as I gather up the ingredients, but... they are really hard to get! For me to get all those is beyond my ability. You, on the other hand, seem more than powerful enough to handle it. Will you help me out?");
			
			if (!start)
			{
				self.say("Ahhh, that stinks, but I can't do anything about it. The ocean is a very dangerous place. Ahhh... I wonder how that tastes like... I'd love to find out myself...");
				return;
			}
			
			SetQuestData(1009700, "s");
			self.say("Sweet!!! Thank you so much. #p2060006# said she can make it for me, as long as the ingredients are there, so after you gather them up, go straight to #p2060006#, who should be at #m230000000#. Please don't tell me you've changed your mind while I'm saying all this. Please don't!");
			self.say("That one can only be obtained at the deep sea, and therefore really difficult to obtain. #b150 #t4000183#s#k and #b80 #t4000181#s#k are needed to make it, and I couldn't even fathom gathering them up. You, on the other hand, I think you won't have much trouble getting them. Please help me!");
		}
		else if (quest == "s")
		{
			self.say("Gather up #b150 #t4000183#s#k and #b80 #t4000181#s#k, and bring them to #p2060006#. She'll make the food for you right on the spot.");
		}
		else if (quest == "1")
		{
			if (ItemCount(4031281) < 1)
			{
				self.say("So where's the food?");
				return;
			}
			
			self.say("Whoa, what's this delicious smell! Is it the food that #p2060006# made? Really?");
			
			if (!Exchange(0, 4031281, -1, 2040805, 1))
			{
				self.say("Huh? Are you sure you have room in your use inventory?");
				return;
			}
			
			AddEXP(200);
			SetQuestData(1009700, "e");
			QuestEndEffect();
			self.say("Ohh, it's still warm. Thank you so much! I never thought I'd ever eat something like this. I can't thank you enough for your hard work... FOR ME! Here, take the scrolls. This is really nothing compared to what you just did for me... please use them well!");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1006400)
		{
			if (Level >= 40 && info != "e")
				return " A Healthy Snack for the Huskies";
		}
		else if (quest == 1009700)
		{
			if ((Level >= 95 && info == "") || info == "s")
				return " Nanuke's Ingredients";
			
			else if (info == "1")
				return " Muse is Cooking";
		}
		else if (quest == 8020015)
		{
			string pio = GetQuestData(201);
			//return " Nanuke and the Chair";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1006400, 1009700, 8020015};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "Hi! Aren't these huskies adorable?";
		
		if (GetQuestData(1006400) == "e")
			dialogue = "Long time! Are you here to check out the huskies? Then you've come to the right place!";
		
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
			case 0: Huskies(GetQuestData(1006400)); break;
			case 1: Ingredients(GetQuestData(1009700)); break;
			case 2: Chair(GetQuestData(8020015)); break;
		}
	}
}