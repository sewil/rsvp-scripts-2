using System.Collections.Generic;
using WvsBeta.Game;

// 1052103 Nella
public class NpcScript : IScriptV2
{
	private void Requests1(string quest)
	{
		if (quest == "")
		{
			self.say("Whoa, I haven't seen you before! I'm guessing you're not from here, since I don't recognize you and all. My name's #b#p1052103##k, the one you turn to for information around here. If anything happens in this town, I'm always the first one to know, pure and simple!");
			bool start = AskYesNo("For #b1000 mesos#k, I can gather up some information on the townspeople here, and I can even hook you up with a couple of them. It's like, if someone in town needs help, I'll introduce YOU to that person! What do you think? Wanna give it a shot?");
			
			if (!start)
			{
				self.say("This may not be the kind of request you normally would get, but it won't hurt you one bit, trust me. It's your call, and if you feel like changing your mind, then come talk to me.");
				return;
			}
			
			if (!Exchange(-1000))
			{
				self.say("Sorry, it looks like you don't have #b1000 mesos#k. Can't give you any hook-ups without it.");
				return;
			}
			
			SetQuestData(1001800, "1s");
			self.say("Awesome! Like I promised, you give me 1000 mesos, I give you the hook-ups. We have an urgent request from one of the towmsmen, so that'll be your first job. #b#p1051001##k from the armor store has been collecting rare items for a new armor he's trying to create.");
			self.say("He needs #b50 #t4000012#s#k and #b50 #t4000037#s#k. It may be just a piece of cake for you, anyway. Don't worry, he promised he'll reward you well for your service. Well, come back to me once you have gathered them all up, alright? I'll be waiting ...");
		}
		else if (quest == "1s")
		{
			if (ItemCount(4000012) < 50 || ItemCount(4000037) < 50)
			{
				self.say("You haven't collected all the items #b#p1051001##k requested yet, right? To make a new armor, he'll need #b50 Greem Mushroom \r\nTops#k and #b50 #t4000037#s#k. All you need to do is see me after you've collected them all, so keep trying!");
				return;
			}
			
			self.say("Whoa ... you came back much earlier than I thought! I knew I picked the right person for this ... Sweet! Since you have done such a wonderful job following through the request, here's your reward. #b#p1051001##k is giving you a bunch of #b#t2010004#s#k that'll help you on your journey, so go ahead and take them all!");
			
			if (!Exchange(0, 4000012, -50, 4000037, -50, 2010004, 50))
			{
				self.say("Hey! You need a free slot in your use inventory to take these #b#t2010004#s#k.");
				return;
			}
			
			AddEXP(100);
			SetQuestData(1001800, "1end");
			self.say("Alright, if you need work sometime down the road, feel free to come back and see me. This town sure can use a person like you for help!");
		}
		else if (quest == "1end")
		{
			self.say("Oh, thanks for coming! I just got a new request in store for you. This time, it's a request from #b#p1052102##k, whom you can find sitting in front of the subway station. A friend of hers gave her a puppy as a present a few days ago, and she's looking to make a cute, comfortable doghouse for it.");
			self.say("She'll need #b5 #t4003001#s#k and #b5 #t4003000#s#k. The puppy is freezing in cold, so it'll be preferable for you to get them all as soon as possible. I'm sure it's a piece of cake to you. Just bring them all to me once you have gathered them up, so good luck!");
			SetQuestData(1001800, "2s");
		}
		else if (quest == "2s")
		{
			if (ItemCount(4003001) < 5 || ItemCount(4003000) < 5)
			{
				self.say("You haven't gotten all the stuff #b#p1052102##k needs, yet, right? \r\n#b#p1052102##k needs #b5 #t4003001#s#k and #b5 #t4003000#s#k to make a doghouse. Just bring them all to me once you have gathered them up, so keep trying!");
				return;
			}
			
			self.say("Whoa ... you came back much earlier than I thought! You took care of the business last time, and you've done it again~ Alright, Since you have done such a wonderful job following through the request, here's your reward. #b#p1052102##k is giving you a bunch of hand-made #b#t2020002#s#k that'll help you on your journey!");
			
			if (!Exchange(0, 4003001, -5, 4003000, -5, 2020002, 100))
			{
				self.say("Hey! You need a free slot in your use inventory to take these #b#t2020002#s#k.");
				return;
			}
			
			AddEXP(200);
			SetQuestData(1001800, "2end");
			self.say("Alright, if you need work sometime down the road, feel free to come back and see me. This town sure can use a person like you for help~");
		}
		else if (quest == "2end")
		{
			self.say("Oh, thanks for coming! I just got a new request in store for you. This time, it's #b#p1052101##k the assistant from the beauty parlor. #b#p1052101##k is actually a lonely guy living by himself. He's apparently sick and tired of eating just for sake of eating.");
			self.say("He seems to be getting sick of eating the same thing over and over again. All I need is #b100 #t4000006#s#k and #b1 \r\n#t2022000##k to make a tasty Seafood Soup. I'm sure it's piece of cake for you to gather them all up. Well then, I'll be here waiting!");
			SetQuestData(1001800, "3s");
		}
		else if (quest == "3s")
		{
			if (ItemCount(4000006) < 100 || ItemCount(2022000) < 1)
			{
				self.say("Haven't gotten all the items #b#p1052101##k requested for, yet? He says that, to make a tasty Seafood Soup, he'll need #b100 \r\n#t4000006#s#k and #b1 #t2022000##k. Give them all to me once you have gathered them up, and that'll be it!");
				return;
			}
			
			self.say("Whoa ... you came back much earlier than I thought! I knew I could count on you~ Since you have done such a wonderful job following through the request, here's your reward. #b#p1052101##k is giving you a glove that'll help you on your journey, so go ahead and take it!");
			
			int itemID = 0;
			
			if (Job < 100) itemID = 1082002;
			else if (Job >= 100 && Job < 200) itemID = 1082004;
			else if (Job >= 200 && Job < 300) itemID = 1082020;
			else if (Job >= 300 && Job < 400) itemID = 1082013;
			else if (Job >= 400 && Job < 500) itemID = 1082032;
			
			if (!Exchange(0, 4000006, -100, 2022000, -1, itemID, 1))
			{
				self.say("Hey! You need a free slot in your equip. inventory to take the glove.");
				return;
			}
			
			AddEXP(300);
			SetQuestData(1001800, "3end");
			QuestEndEffect();
			self.say("Alright, if you need work sometime down the road, feel free to come back and see me. This town sure can use a person like you for help~");
		}
	}
	
	private void Requests2(string quest)
	{
		if (quest == "")
		{
			self.say("Hey, you look much stronger than before! Alright, if that's the case ... you can probably take care of more difficult requests now.");
			self.say("I have a new request in store for you, actually. #b#p1051002##k of the Famous Pharmacy needs help. He's been working on creating a new potion, and one day, he realized he has run out of ingredients. Those are pretty hard to find, and he claims that it's slowing down his experiments these days ...");
			self.say("He seems to be in a hurry to get those, so he can resume his experiments. He'll need #b100 #t4000015#s#k and #b50 #t4000034#s#k ... I'm sure it'll be a piece of cake for you, so ... I'll be waiting here, at this same spot, while you go gather up the items.");
			SetQuestData(1001801, "1s");
		}
		else if (quest == "1s")
		{
			if (ItemCount(4000015) < 100 || ItemCount(4000034) < 50)
			{
				self.say("Haven't gotten all the items #b#p1051002##k requested, yet? He said he'll need #b100 #t4000015#s#k and #b50 #t4000034#s#k to experiment more with potions. Just gather them all up and give them to me, that's all!");
				return;
			}
			
			self.say("I knew it ... I knew you could get it done quickly! You did your job well last time, and here you are again, taking care of business!! Alright, since you have done it so well, I should reward you well. #b#p1051002##k is giving you #b100 #t2000002#s#k to help you in the future.");
			
			if (!Exchange(0, 4000015, -100, 4000034, -50, 2000002, 100))
			{
				self.say("Hey! You need a free slot in your use inventory to take these #b#t2000002#s#k.");
				return;
			}
			
			AddEXP(400);
			SetQuestData(1001801, "1end");
			self.say("Alright, if you need work sometime down the road, feel free to come back and see me. This town sure can use a person like you for help~");
		}
		else if (quest == "1end")
		{
			self.say("Oh, thanks for coming! I just got a new request in store for you. It seems like #b#p1052003##k of the hardware store is having trouble sleeping these days. Someone apparently stole his pillow ... now who would steal a pillow these days???");
			self.say("Anyway, to make a new pillow, he'll need various materials, and he seems to have a hard time gathering them up. He said he'll need #b50 #t4003004#s#k and #b20 #t4000021#s#k to make a nice pillow ... I'm sure it's a piece of cake for you. Well, come find me once you have gathered them all up.");
			SetQuestData(1001801, "2s");
		}
		else if (quest == "2s")
		{
			if (ItemCount(4003004) < 50 || ItemCount(4000021) < 20)
			{
				self.say("Haven't gotten all the items #b#p1052003##k requested, yet? He said he'll need #b50 #t4003004#s#k and #b20 #t4000021#s#k to make a new pillow. Just gather them all up and give them to me, that's all!");
				return;
			}
			
			self.say("I knew it ... I knew you could get it done quickly! You did your job well last time, and here you are again, taking care of business!! Alright, since you have done it so well, I should reward you well. #b#p1052003##k is giving you #b1 #t4011001##k and #b1 \r\n#t4011000##k to help you with as a sign to help your travels.");
			
			if (!Exchange(0, 4003004, -50, 4000021, -20, 4011001, 1, 4011000, 1))
			{
				self.say("Hey! You need two free slots in your etc. inventory to take the #b1 #t4011001##k and #b1 #t4011000##k.");
				return;
			}
			
			AddEXP(500);
			SetQuestData(1001801, "2end");
			self.say("Alright, if you need work sometime down the road, feel free to come back and see me. This town sure can use a person like you for help~");
		}
		else if (quest == "2end")
		{
			self.say("Oh, thanks for coming! I just got a new request in store for you. You know #b#p1051000##k from the weapon store? Everyone in this town knows this, but he really has an appetite unlike anyone else. Not just food, but EXOTIC ones!");
			self.say("There's this dish that no one would ever put his or her mouth on, but somehow, it's his favorite dish. It's called the Evil Eye Tail Stew. A very interesting person, indeed. He really loves it but no one else so much as even looks at it. I tried it too, and it did taste OK, but I'm never eating it again.");
			self.say("Anyway, he seems to have run out of the main ingredient for that dish, #b#t4000007##k. With #b200 #t4000007#s#k, he said he won't ever have to ask for it again ... I'm sure it'll be a piece of cake for you, so ... I'll be waiting here, at this same spot, while you go gather up the items!");
			SetQuestData(1001801, "3s");
		}
		else if (quest == "3s")
		{
			if (ItemCount(4000007) < 200)
			{
				self.say("Haven't gotten all the items #b#p1051000##k requested. yet? To make #t4000007#, his favorite dish, he'll need #b200 #t4000007#s#k. Just get them to me once you have collected them all, alright? Good luck!");
				return;
			}
			
			self.say("I knew it ... I knew you could get it done with, quickly! You did your job well last time, and here you are again, taking care of business!! Alright, since you have done it so well, I should reward you well. #b#p1051000##k is giving you a pair of shoes in hopes of helping you out on your future traveling.");
			
			int itemID = 0;
			
			if (Job < 100) itemID = 1072018;
			else if (Job >= 100 && Job < 200) itemID = 1072003;
			else if (Job >= 200 && Job < 300) itemID = 1072077;
			else if (Job >= 300 && Job < 400) itemID = 1072081;
			else if (Job >= 400 && Job < 500) itemID = 1072035;
			
			if (!Exchange(0, 4000007, -200, itemID, 1))
			{
				self.say("Hey! You need a free slot in your equip. inventory to take the shoes.");
				return;
			}
			
			AddEXP(600);
			SetQuestData(1001801, "3end");
			QuestEndEffect();
			self.say("Alright, if you need work sometime down the road, feel free to come back and see me. This town sure can use a person like you for help~");
		}
	}
	
	private void Fanzy(string quest)
	{
		if (quest == "")
		{
			int ask = AskMenu("That was just really, really weird.#b",
				(0, " The world is full of weird things."),
				(1, " What is it?"));
			
			
			if (ask == 0)
			{
				self.say("That's true... it shouldn't be so strange, considering it all happened in a dream...");
				return;
			}
			
			AskMenu("I had a really weird dream last night, and I can't seem to forget it. It's completely stuck in my head.#b",
				(0, " What kind of a dream was it?"));
			
			AskMenu("Last night, I had a dream, and I was walking around a huge forest. The whole area was covered with green trees that were so tall, they were kissing the sky with ease. Suddenly, out of nowhere, I heard a cat cry. I ran straight to where the crying occurred. There, I saw a striped cat, crouching down in a tree hole, staring at me. I carefully laid out my hand to pet it, then suddenly, the cat seemed to blur for a second, then just plain disappeared! Right in front of my eyes!!#b",
				(0, " Whoa, that much be one interesting cat. What happened afterwards?"));
			
			AskMenu("I was so shocked, so I looked around here and there, but I couldn't find the cat. Suddenly I heard someone talk from behind. So I looked back, and to my very amusement, the cat was back in the spot, as if nothing ever happened. The real shock, however, was just about to come.#b",
				(0, " The real shock?"));
			
			bool start = AskYesNo("That cat proceeded to talk to me. I think it was asking me to find something that it lost... and while I stopped for a second to gather my thoughts, it disappeared on me again. The weird thing is, it does not feel like a dream at all. I feel like if I go there again, I'll find that cat, sitting at the same spot, in that same crouch. I think you have an affinity for interesting stories... how about you finding that cat for me?");
			
			if (!start)
			{
				self.say("Anyway, this was all just a dream, so... I don't think there's ever a cat quite like that in real life. Oh no, this has taken a lot of time... thanks for listening to my dream story.");
				return;
			}
			
			SetQuestData(1007700, "s");
			self.say("You must be really curious about this cat, too. Remember, this all happened in my dream, nothing else. I don't know if there's ever going to be a cat quite like that around here. If you find a way to find that green forest, however, then that's a different story...");
			self.say("But then again, I've never seen a place quite like that. #bA place surrounded by humongous green trees...#k well I've heard of a huge forest somewhere down on the East side, but I've never been there...");
		}
		else if (quest == "s")
		{
			self.say("Can't find the forest I saw in the dream? Well, there's a chance that the place doesn't even exist. #bA place surrounded by humongous green trees...#k I don't think I've ever heard of such place. Even if you find it, I can't guarantee that there's such thing as a #bcat that talks and becomes transparent#k. I mean, that's just freaky...");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1001800)
		{
			if ((info == "" && Level >= 15) || info == "1s")
				return " Don Hwang's Request";
			
			else if (info == "1end" || info == "2s")
				return " Shumi's Request";
			
			else if (info == "2end" || info == "3s")
				return " Andre's Request";
		}
		else if (quest == 1001801)
		{
			string requests1 = GetQuestData(1001800);
			
			if ((info == "" && requests1 == "3end" && Level >= 25) || info == "1s")
				return " Dr. Faymus's Request";
			
			else if (info == "1end" || info == "2s")
				return " Chris's Request";
			
			else if (info == "2end" || info == "3s")
				return " Cutthroat Manny's Request";
		}
		else if (quest == 1007700)
		{
			if ((info == "" && Level >= 10 && PetName != "") || info == "s")
				return " Nella's Dream";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1001800, 1001801, 1007700};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "I got so many requests from the townspeople today! I need help here...";
		
		if (GetQuestData(1001800) == "3end")
			dialogue = "You're the one that helped me take care of #b#p1052101##k's request, right? He should be enjoying his seafood soup riiiight about now. Unfortunately, I haven't gotten any new requests today. Come talk to me some other time, alright?";
		
		if (GetQuestData(1001801) == "3end")
			dialogue = "Aren't you the one that helped me take care of #b#p1051000##k's request? He should be at home fixing himself a hearty dinner right about now. Unfortunately, I haven't gotten any new requests today. Come talk to me some other time, alright?";
		
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
			case 0: Requests1(GetQuestData(1001800)); break;
			case 1: Requests2(GetQuestData(1001801)); break;
			case 2: Fanzy(GetQuestData(1007700)); break;
		}
	}
}
