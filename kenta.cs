using System;
using System.Collections.Generic;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void KentaResearch1(string quest)
	{
		if (quest == "")
		{
			self.say("Have you noticed something strange while making your way here to Aquarium? It seems like the animals and the fishes here have been acting strange lately. It's not overtly noticeable, but it seems like some of them look very fatigued, while the others seem... overly in rage.");
			bool start = AskYesNo("I'd like to believe that I'm just overreacting, but it does bother me that this has started to happen after Aqua Road went through a wild storm. I want to really investigate into this matter. Will you help me out?");
			
			if (!start)
			{
				self.say("This may take a while, so if you change your mind, then please talk to me. I sure can use your help.");
				return;
			}
			
			SetQuestData(1009600, "s");
			self.say("Thank you so much for offering to help. What I'd like to ask you for help is that... I need to gather up the DNA samples of the living organisms here at the Aqua Road. I don't know exactly what kind of changes have occurred, but I do notice that SOMETHING's changing...");
			self.say("If I study the DNA samples of these living organisms, I may be able to uncover some things that may provide a clue to the picture. Please get me the #bDNA samples#k of #rSeacle, Cico, and Pin Boom#k, and I only need #b1 of each#k.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031259) < 1 || ItemCount(4031260) < 1 || ItemCount(4031261) < 1)
			{
				self.say("Did you gather up all the samples I asked you to get? Please gather up  #b1 of each#k of #b#t4031259#, #t4031260#, and #t4031261##k");
				return;
			}
			
			self.say("Did you gather up all the samples I asked you to get?");
			
			int itemID = -1;
			
			if (Job >= 100 && Job < 200)
				itemID = 2002004;
			
			else if (Job >= 200 && Job < 300)
				itemID = 2002002;
			
			else if (Job >= 300 && Job < 400)
				itemID = 2002005;
			
			else if (Job >= 400 && Job < 500)
				itemID = 2002000;
			
			else
				itemID = 2002001;
			
			if (!Exchange(0, 4031259, -1, 4031260, -1, 4031261, -1, itemID, 30))
			{
				self.say("Are you sure you brought the DNA samples? If so, please check and make sure there's room in your use inventory.");
				return;
			}
			
			AddEXP(500);
			SetQuestData(1009600, "e");
			QuestEndEffect();
			self.say("I know this must have been a chore for you, so thank you so much for helping me out. I may ask you for some help again down the road. Will you help me out again like you did this time?");
		}
	}
	
	private void KentaResearch2(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("Aren't you the one that helped me out last time? I'm still here, studying the general living organisms of Aqua Road. Thanks to your help, I was able to uncover some questionable points regarding the state of life here, but there are still way too many things to uncover here. That's why, this time, I'd like to gather up the samples of other animals here. Will you help me out here once more?");
			
			if (!start)
			{
				self.say("This may take a while, so if you change your mind, then please talk to me. I sure can use your help.");
				return;
			}
			
			SetQuestData(1009601, "s");
			self.say("Thank you so much. I knew you'd help out. It's just like the last time you helped me out, in that this time, I'd like to study the fish. Please gather up the #bDNA samples#k of #rFlower Fish, Mask Fish, and Bubble Fish#k, and I need #bONE#k of each.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031262) < 1 || ItemCount(4031263) < 1 || ItemCount(4031264) < 1)
			{
				self.say("Did you gather up all the samples I asked you to get?  Please get me #b1 of each#k of #b#t4031262#, #t4031263#, and #t4031264##k.");
				return;
			}
			
			self.say("Did you gather up all the samples I asked you to get?");
			
			if (!Exchange(0, 4031262, -1, 4031263, -1, 4031264, -1, 1432008, 1))
			{
				self.say("Are you sure you brought the DNA samples? If so, please check and make sure there's room in your equip. inventory.");
				return;
			}
			
			AddEXP(2500);
			SetQuestData(1009601, "e");
			QuestEndEffect();
			self.say("I know this must have been a chore for you, so thank you so much for helping me out. I may ask you for some help again down the road. Will you help me out again like you did this time?");
		}
	}
	
	private void KentaResearch3(string quest)
	{
		if (quest == "")
		{
			self.say("Aren't you the one that helped me out twice? I'm still here, studying the general living creatures that reside in Aqua Road. Thanks to your help last time, I was able to find out that the state of the living organisms around Aquarium is much more in danger than the ones far away from here.");
			bool start = AskYesNo("I still don't know if this has to do with Aquarium, however, so this time, I plan on gathering up the samples of other living organisms. Will you help me out one more time? I still don't know if this has to do with Aquarium, however, so this time, I plan on gathering up the samples of other living organisms. Will you help me out one more time?");
			
			if (!start)
			{
				self.say("This may take a while, so if you change your mind, then please talk to me. I sure can use your help.");
				return;
			}
			
			SetQuestData(1009602, "s");
			self.say("Thank you so much. I knew you'd help out. It's just like the last time you helped me out, in that this time, I'd like to study the living organisms in the west coast. Please get me #b1 of each#k of #rPuper, Sparker, and Freezer's DNA samples#k.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031265) < 1 || ItemCount(4031266) < 1 || ItemCount(4031267) < 1)
			{
				self.say("Did you get all the samples I asked you to get? Please get me #b1 #t4031265#, 1 #t4031266#, and 1 #t4031267##k. One of each.");
				return;
			}
			
			self.say("Did you gather up the samples I asked you to get? ");
			
			if (!Exchange(0, 4031265, -1, 4031266, -1, 4031267, -1, 4031242, 10))
			{
				self.say("Are you sure you brought the DNA samples? If so, please check and make sure there's room in your etc. inventory.");
				return;
			}
			
			AddEXP(6500);
			SetQuestData(1009602, "e");
			QuestEndEffect();
			self.say("I know it must have been a chore for you to do it, so thank you so much for helping me out. I sure hope I can find out why the animals have changed, since you've helped me out so much on that area. The VIP Cab coupon I gave you is the coupon that allows you to transport straight to the Sharp Unknown from the Aquarium. Try using it while in Aqua Road!");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1009600)
		{
			if (Level >= 17 && info != "e")
				return " Kenta's Research 1";
		}
		else if (quest == 1009601)
		{
			string kenta1 = GetQuestData(1009600);
			
			if (Level >= 27 && kenta1 == "e" && info != "e")
				return " Kenta's Research 2";
		}
		else if (quest == 1009602)
		{
			string kenta2 = GetQuestData(1009601);
			
			if (Level >= 37 && kenta2 == "e" && info != "e")
				return " Kenta's Research 3";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1009600, 1009601, 1009602};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "Welcome to the Aquarium Zoo!";
		
		if (GetQuestData(1009602) == "e")
			dialogue = "Thank you so much for helping me out. I sure hope I can find out why the animals have changed, since you've helped me out so much on that area.";
		
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
			case 0: KentaResearch1(GetQuestData(1009600)); break;
			case 1: KentaResearch2(GetQuestData(1009601)); break;
			case 2: KentaResearch3(GetQuestData(1009602)); break;
		}
	}
}