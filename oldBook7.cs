using System;
using System.Collections.Generic;
using WvsBeta.Game;
using WvsBeta.Common;

// 2032000 ???? (Hella)
public class NpcScript : IScriptV2
{
	private void OldBook(string quest)
	{
		string questBook2 = GetQuestData(1001501);
		
		if (quest == "s3")
		{
			self.say("Oh no, #bSpiruna's Black Crystal#k is cracked! She needs it to breathe life into all of her spells. I understand you may have wrongfully been accused of this, but right now nothing will calm #bSpiruna#k down. There's one item, though, that can fix the cracked Black Crystal. If you can get me that, Spiruna won't be so mad after that...");
			self.say("It's an item called #b#t4031051##k. It's a collection of dust the fairies create whenever they flap their wings. That's the only thing that can restore the #b#t4031050##k to its original state. So many people have been looking for it these days that it may not be easy to obtain. Anyway, look for #bKriel the Fairy#k at the Orbis market and ask her for it.");
			AddEXP(2000);
			SetQuestData(1001502, "s4");
		}
		else if (quest == "s4" || quest == "s5" || quest == "s6")
		{
			self.say("With #b#t4031051##k, the #b#t4031050##k can be restored to its original state. Then, and only then, Spiruna may calm down and talk to you. Anyway, look for #bKriel the Fairy#k at the Orbis market and ask her for it.");
		}
		else if (quest == "end" && questBook2 == "h5")
		{
			self.say("I guess there's no point of hiding now. Yes, I'm Hella, the person you've been looking for. After losing my mother, I went under Spiruna to learn the in's and out's of becoming a powerful sorcerer. Am I the descendant of the author of #b#t4031056##k? Where did you hear that from? From Alcaster...? Hmmm ... I guess I can't hide from that, either. Yes, I am the descendent of the author of #t4031056#.");
			self.say("At first I wanted to get the book myself and learn the secrets of the powerful spells from there, but I know that I am much too weak to fully conquer the book. Will you find the book and safely seal it away for good? I tried hard looking for it with no success. Hmmm ... but there's one thing I want to go over. I've only told Jade this, but...");
			self.say("#b#t4031056##k in the deep valley of the snowfield. It was lost so long ago that you won't be able to find it easily. But then again, Jade may know a thing or two, since he's been studying the history of this place. Anyway, please get this pendant to Jade and ask him about #t4031056#.");
			
			if (!Exchange(0, 4031052, 1))
			{
				self.say("Please make some room in your etc. inventory so I can give you this pendant...");
				return;
			}
			
			AddEXP(4610);
			SetQuestData(1001501, "h6");
		}
		else if (quest == "end" && questBook2 == "h6")
		{
			if (ItemCount(4031052) >= 1)
			{
				self.say("This is the #bpendant#k that I got from Jade when we were kids. Once he sees this, he'll know that I'm doing quite alright here and concentrate solely on his studies. Please give this pendant to #bJade in El Nath#k. As for the #b#t4031056##k, ask him about it while mentioning my name, then Jade will trust you and tell you about it.");
				return;
			}
			
			self.say("#b#t4031056##k in the deep valley of the snowfield. It was lost so long ago that you won't be able to find it easily. But then again, Jade may know a thing or two, since he's been studying the history of this place. Anyway, please get this pendant to Jade and ask him about #t4031056#.");
			
			if (!Exchange(0, 4031052, 1))
			{
				self.say("Please make some room in your etc. inventory so I can give ou this pendant...");
				return;
			}
		}
	}
	
	private void LighteningOrbis(string quest)
	{
		if (quest == "")
		{
			self.say("Hello. I was able to hear everything you and #p2032001# talked about. Please do not bother #b#p2032001##k, for she is busy meditating on how to save Orbis.");
			bool start = AskYesNo("Actually, #p2032001# had been expecting this for quite some time, and had been looking for ways to remedy this problem. Although no clear-cut answer has been mentioned yet, the theory of heavy Orbis had been gaining steam there. That's why... I have a quest that I need help on. Will you help me out?");
			
			if (!start)
			{
				self.say("I am asking you for help so Orbis won't be sinking down low by the minute...");
				return;
			}
			
			SetQuestData(1009801, "100100100");
			self.say("The reason why Orbis has been getting heavier is because of the plethora of monsters residing in this area. I especially think the numbers of #o3210200#, #o3210201#, and #o3210202# have been ridiculous. For now, the best thing we can do is lessen the weight of Orbis to delay the inevitable crashing of Orbis to the ground.");
			self.say("Please head to the garden immediately and defeat #b100 #o3210200#s, 100 #o3210201#s, and 100 #o3210202#s#k. Defeating that many monsters may be the only way to lessen the weight of Orbis.");
		}
		else
		{
			if (quest != "000000000")
			{
				self.say("How's the stuff I asked you to take care of? I'm sure it'll require you to take a long time to eliminate the monsters and collect #b100 #o3210200#s, 100 #o3210201#s, and 100\r\n#o3210202#s#k in the process.");
				return;
			}
			
			self.say("Hey, you're back! I've been hearing your heroic efforts through travelers all around. Thanks to you, they say the numbers of #o3210200#, #o3210201#, and #o3210202# have definitely decreased. That's just amazing, and thanks to your efforts, I can proudly say that the numbers of #o5120001#, #o5120002#, and\r\n#o5120003# have also decrease substantially.");
			
			var rewards = new List<(int, int, int)>();
			
			rewards.Add((4010001, 5, 2));
			rewards.Add((4010000, 5, 2));
			rewards.Add((4010002, 5, 2));
			rewards.Add((4010005, 5, 2));
			rewards.Add((4010003, 5, 2));
			rewards.Add((4010004, 5, 1));
			rewards.Add((4010006, 5, 1));
			
			var item = rewards.RandomElementByWeight(tuple => tuple.Item3);
			
			if (item == default)
				return;
			
			int itemID = item.Item1;
			
			if (!Exchange(0, itemID, 5))
			{
				self.say("Make sure there is an empty space in your etc. inventory.");
				return;
			}
			
			AddEXP(4500);
			SetQuestData(1009801, "e");
			QuestEndEffect();
			self.say("Thanks to your help, the speed in which Orbis is falling has slowed down a bit, but that doesn't mean it's stopped altogether. What is the reason behind this anyway? #p2032001# is still meditating. This really concerns me...");
		}
	}
	
	private void CloudPieces(string quest)
	{
		if (quest == "")
		{
			AskMenu("I finally figured it out! This morning, after her daily morning meditation, Spiruna told me all this was because of the pixies.#b",
				(0, " Pixies?")
			);
			AskMenu("Yes, the reason why Orbis is floating on air is because of these magical clouds. Lately, however, the Pixies have begun to absorb the magic power from the clouds, just to fill up their stamina, and... the clouds will surely weaken, all the way to the point where Orbis may be in danger of crashing down...#b",
				(0, " Ahhh, that's what she meant by that!")
			);
			bool start = AskYesNo("We need to get the #t04031309#s from the pixies so we can start the maintenance check with the clouds.");
			
			if (!start)
			{
				self.say("So you don't mind Orbis slowly sinking down until it crashes and burns?");
				return;
			}
			
			SetQuestData(1009802, "s");
			self.say("We can only start the maintenance check after the cloud pieces from the Pixies are here. There are 3 types of Pixies at Orbis, the three being Star Pixie, Lunar Pixie, and Luster Pixie. Your job is to collect #b30 #t4031309#s#k from those pixies...");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031309) < 30)
			{
				self.say("We need #b30 #t4031309#s#k to start fixing the clouds...");
				return;
			}
			
			self.say("You brought #t4031309#!! Can I see this? Wow... the #t4031309# still contains some magic power, so I should be careful with it. Orbis will never go down again after using these clouds for the maintenance check. Thank you so much.");
			
			var rewards = new List<(int, int, int)>();
			
			rewards.Add((4020000, 5, 2));
			rewards.Add((4020001, 5, 2));
			rewards.Add((4020002, 5, 2));
			rewards.Add((4020003, 5, 2));
			rewards.Add((4020004, 5, 2));
			rewards.Add((4020005, 5, 2));
			rewards.Add((4020006, 5, 2));
			rewards.Add((4020007, 5, 1));
			rewards.Add((4020008, 5, 1));
			
			var item = rewards.RandomElementByWeight(tuple => tuple.Item3);
			
			if (item == default)
				return;
			
			int itemID = item.Item1;
			
			if (!Exchange(0, 4031309, -30, itemID, 5))
			{
				self.say("Make sure there is an empty space in your etc. inventory.");
				return;
			}
			
			AddEXP(5000);
			SetQuestData(1009802, "e");
			QuestEndEffect();
		}
	}
	
	private void Sprayer(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("I have one more thing to ask; would you like to help me out?");
			
			if (!start)
			{
				self.say("It's been over 50 years since I lent it away, and ... I guess I shouldn't put too much hope up on this...");
				return;
			}
			
			SetQuestData(1009803, "s");
			self.say("To put together the #t4031309# and blend it in with the existing clouds, I'll need #t4031308# with me. It was supposedly held by #p2032001# before, but 50 years ago, she lent it to #bElma the Housekeeper#k, who was anxious to see the pictures. Now, your job is to go see Elma and get #b#t4031308##k from her.");
		}
		else if (quest == "s")
		{
			self.say("The person that borrowed #b#t4031308##k 50 years ago was... #bElma the Housekeeper#k.");
		}
		else if (quest == "1")
		{
			if (ItemCount(4031308) < 1)
			{
				self.say("Did you bring the Cloud Sprayer that Elma the Housekeeper borrowed? Did you meet Elma in the first place?");
				return;
			}
			
			self.say("You brought the Cloud Sprayer! Thanks to you, we can finally start fixing up the clouds. The citizens of Orbis will be very thankful of your efforts. Thank you so much.");
			
			if (!Exchange(0, 4031308, -1, 2000002, 30))
			{
				self.say("Make sure there is an empty space in your use inventory.");
				return;
			}
			
			AddEXP(500);
			SetQuestData(1009800, "e");
			SetQuestData(1009803, "e");
			QuestEndEffect();
			self.say("Did you get the #b#t2000002#s#k I gave you? Spiruna wanted me to give you them in person. She may look angry at all times, but she was very concerned about this. She's very thankful of your efforts.");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1001502)
		{
			string questBook2 = GetQuestData(1001501);
			
			if (info == "s3")
				return " A Word from the Assistant";
			
			else if (info == "s4" || info == "s5" || info == "s6")
				return " To Acquire the Fairy Dust";
			
			else if (info == "end" && questBook2 == "h5")
				return " The Truth Comes Out...";
			
			else if (info == "end" && questBook2 == "h6")
				return " Hella is Found!";
		}
		else if (quest == 1009801)
		{
			string spiruna = GetQuestData(1009800);
			
			if (spiruna == "1" && info != "e")
				return " Lightening Up Orbis";
		}
		else if (quest == 1009802)
		{
			string hella1 = GetQuestData(1009801);
			
			if (hella1 == "e" && info != "e")
				return " Pixies' Cloud Pieces";
		}
		else if (quest == 1009803)
		{
			string hella2 = GetQuestData(1009802);
			
			if (hella2 == "e" && info != "e")
				return " The Sprayer Elma Borrowed";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1001502, 1009801, 1009802, 1009803};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "I'm #bSpiruna#k's assistant. Please forgive me for not giving you my name. Spiruna has been busy working on a new, difficult spell, and so she's quite edgy right now. Unless it's an urgent matter, I suggest you leave her alone.";
		
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
			case 0: OldBook(GetQuestData(1001502)); break;
			case 1: LighteningOrbis(GetQuestData(1009801)); break;
			case 2: CloudPieces(GetQuestData(1009802)); break;
			case 3: Sprayer(GetQuestData(1009803)); break;
		}
	}
}