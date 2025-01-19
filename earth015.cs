using System.Collections.Generic;
using WvsBeta.Game;

// 2051001 Kay
public class NpcScript : IScriptV2
{
	private void Fuel()
	{
		string quest = GetQuestData(1003500);
		
		if (quest == "")
		{
			bool start = AskYesNo("I am the master of my domain at recycling throwaway machines into something totally new. Lately I've been working on recycling the fuel of MT-09 for something, but I desperately need more people to help me out here. Say, would you like to work for me as my assistant?");
			
			if (!start)
			{
				self.say("Hmmm... I think you can be a great assistant for me... you must be really busy right now. Please remember that for the sake of Omega Sector, we really need your help, so if you change your mind, please tell me so.");
				return;
			}
			
			SetQuestData(1003500, "s");
			self.say("Okay, nice! I've been waiting for someone like you, actually, and this is going to be great!! I'll be counting on you as my trusty assistant. Anyway, here's your first task. I told you something about recycling the fuel of MT-09, right? Well, I need the materials necessary to conduct the studies, and therefore I've been delaying it for a while now.");
			self.say("Around Omega Sector, you'll find a hidden field or two, where you'll run into a monster named #b#o5120100##k. Your job is to defeat #o5120100# and gather up #b5 #t4000126#s#k in the process. I'll be here continuing my research.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4000126) < 5)
			{
				self.say("I don't think you have gathered up the necessary items for my research. Find the hidden fields around Omega Sector. Every once in a while, you'll run into a machine called \r\n#b#o5120100##k. Defeat the machine, and collect #b5 #t4000126#s#k in the process, okay? I'm counting on you!");
				return;
			}
			
			self.say("You're finally back. Let's see... yes, this is indeed #b#t4000126##k, the fuel for the aliens. With this, we can seriously make new machines for our benefits. Great job collecting these for me. Since you did your job as my 'assistant', I'll give you some items directly from my bosses. These will indeed help you out.");
			
			if (!Exchange(0, 4000126, -5, 4003000, 50))
			{
				self.say("Please leave some room in your etc. inventory first.");
				return;
			}
			
			AddEXP(5800);
			SetQuestData(1003500, "e");
			QuestEndEffect();
			self.say("Did you get the #b50 #t4003000#s#k? These are the leftovers from a research, and I'm sure you'll need it, too. Now, the first part of the task is over, but please remember that you're still my assistant. I may need your help down the road, so please drop by often, okay? Bye!");
		}
	}
	
	private void Control()
	{
		string quest = GetQuestData(1003501);
		
		if (quest == "")
		{
			self.say("You are back. Thanks to the fuel of MT-09, I was able to create a remote transporting device. It's still in its experimental stage, but once the experiments are over, we'll be able to navigate through the Sector much easier. By the way, I've been in need of my assistant, and I'm so glad you're here!");
			self.say("This time, I need a special item for my new robot program, which I am currently working on. You'll see a monster called #b#o4130103##k every once in a while at the Eos Tower. I'll need at least #b3 #t4000124#s#k from you through that monster, alright?");
			self.say("All the #b#t4000124##k that have been collected afterwards, please send them to #b#p2050013##k at the Sector Command Center for deciphering. He's not really the one to be depended upon, so I'm worried about that, but...#b3 #t4031118#s#k from him for me, okay? Alright, let's get going!");
			SetQuestData(1003501, "s");
		}
		else if (quest == "s" || quest == "1")
		{
			self.say("I don't think you have #b#t4031118##k, yet. Find #b#o4130103##k around Eos Tower, collect #b3 #t4000124#s#k, then bring them to the Command Center in the Omega Sector. #b#p2050013##k will then decipher it, and will give me #b3 #t4031118#s#k.");
		}
		else if (quest == "2")
		{
			if (ItemCount(4031118) < 3)
			{
				self.say("Hmm... I thought you gathered up 3 Rombard's Memory Cards to request Porter for some deciphering. How come you don't have all 3 Deciphered Memory Cards? Please get me all 3 of them for me to work.");
				return;
			}
			
			self.say("Brilliant!! It's #b3 #t4031118#s#k, indeed! I'm sure #b#p2050013##k didn't get this done in one attempt, and I'm sure you've went through some unnecessary trouble to get this done with. I'm very impressed. Thanks to you, the research should receive some boost from it. Oh, here's something from the Sector, to you. Please take it.");
			
			if (!Exchange(0, 4031118, -3, 2030011, 3))
			{
				self.say("Please leave some room in your use inventory first.");
				return;
			}
			
			AddEXP(6300);
			SetQuestData(1003501, "e");
			QuestEndEffect();
			self.say("What do you think about the #b3 #t2030011#s#k? This was sent straight from the Sector, but I didn't really need it, so here. Anyway, with this, the programming of the new robot should receive a much-needed boost. I knew I had an eye for talent. You're a brilliant assistant, you know that? I may have something else in store for you, so keep dropping by every now and then, okay?");
		}
	}
	
	private void Dropship()
	{
		string quest = GetQuestData(1003502);
		
		if (quest == "s")
		{
			if (ItemCount(4031126) < 1)
			{
				self.say("Hello there. I've been keeping myself busy trying to invent something new today. By the way... what did #b#p2050013##k want me to receive from him? If it's from #b#p2050013##k, then it must be an important item to begin with. Did you lose it by any chance...? You should go back to him; he may have the item with him again.");
				return;
			}
			
			self.say("Hello, there. I'm still busy trying to create a new machine for everyone here. Hey... did #b#p2050013##k really ask you to send his letter to me, like that?");
			
			if (!Exchange(0, 4031126, -1))
			{
				self.say("Are you sure you brought the letter?");
				return;
			}
			
			AddEXP(2500);
			SetQuestData(1003502, "1");
			self.say("Oh my goodness!! The Dropship that had been reported missing may have been found! The members had a huge mission to carry on, and they were on their way back to the Sector when we lost them, and we had no idea where they were from that point on. I can't believe the Dropship is found now!! Alright, here's your next task on hand.");
			self.say("According to the letter I have just received, the location of the Dropship has been confirmed to be around Roswell Plain, so I suggest you check out the area and see if the pilot's alright, as well as the Dropship. It doesn't really matter what happened to the Dropship, as long as the pilot's fine...");
		}
		else if (quest == "1")
		{
			self.say("Have you searched the Roswell Plain? It looks like the Dropship has been found, and the clues were inside for the taking, but I think you lost it on your way back here. Please check the Dropship again to check out the whereabouts of the pilot. It doesn't really matter what happened to the Dropship, as long as the pilot's fine...");
		}
		else if (quest == "2")
		{
			if (ItemCount(4031127) < 1)
			{
				self.say("Have you searched the Roswell Plain? It looks like the Dropship has been found, and the clues were inside for the taking, but I think you lost it on your way back here. Please check the Dropship again to check out the whereabouts of the pilot. It doesn't really matter what happened to the Dropship, as long as the pilot's fine...");
				return;
			}
			
			self.say("Oh, you're back. I've been waiting for you to come back with good news. How is it? Did you find the lost Dropship at the Roswell Plain? How about the pilot? Did you find anything about him? If you found any clue whatsoever inside the Dropship, please show me right now.");
			self.say("Ohh... so you were unable to find the pilot, but you did find a letter near the cockpit. If the letter's there, that means he's alive somewhere!!! Please show me the letter immediately. Let's see... the handwriting looks like his... he must have written this in a hurry. Hmm...");
			
			if (!Exchange(0, 4031127, -1, 1032013, 1))
			{
				self.say("Please leave a space open in your equip. inventory.");
				return;
			}
			
			AddEXP(6800);
			SetQuestData(1003502, "e");
			QuestEndEffect();
			self.say("It looks like he was attacked by the aliens on his way back from a mission. He tried to survive the attack, but once the Dropship got busted, he decided to leave the place to save his life. I am not sure if he's alive now, but I really would like to believe that he is indeed alive and well.");
			self.say("Thank you so much for all your help. Actually, the Sector had pretty much given up on this, and this had been quietly ran by myself and #b#p2050013##k. We may not have been able to find him, but I'm glad we at least have a chance that he's alive. Well, I'll have to get back to the studies now...");
		}
	}
	
	private void Robinson()
	{
		string quest = GetQuestData(1007400);
		
		if (quest == "2")
		{
			if (ItemCount(4031210) < 1)
			{
				self.say("Hello there. Can I help you? As you can see, I'm really busy right now. Please don't bother me unless it's something important.");
				return;
			}
			
			self.say("Hello, there. Can I help you? As you can see, I'm really busy right now. We've been in combat against the aliens, and that really increases the number of machines to be fixed.");
			AskMenu("Ah, this ... this is... Robinson's!! Did you... did you meet him? Where is he? Everyone at the Sector had given up on looking for him, since he was so hard to locate. Where is he?#b",
				(0, " I found him at a remote island right in the middle of the ocean."));
			
			AskMenu("How did he end up there? Is he doing alright? Is he okay??#b",
				(0, " He got injured while being swept away by the tidal wave. \r\nHe wants to be rescued."));
			
			bool start = AskYesNo("Oh yes, we should be sending the rescuers there, but the Sector is currently in the middle of combat against the aliens, and we just cannot send any men out for any other reason. Since you're here and all, can you help us out?");
			
			if (!start)
			{
				self.say("I know it's a difficult task, one that puts you in hesitation. But please remember that this involves a man's life, so please reconsider your decision.");
				return;
			}
			
			if (!Exchange(0, 4031210, -1, 4031221, 1))
			{
				self.say("Are you sure there's a free slot in your etc. inventory?");
				return;
			}
			
			AddEXP(10000);
			AddFame(2);
			SetQuestData(1007400, "3");
			self.say("The warp capsule that I'm giving you is specially designed in Omega Sector that adds new features to the existing warp capsule. It'll enable you to warp to the Omega Sector from anywhere in MapleStory. Please get this to Robinson right now.");
			self.say("I know you want to test out the capsule, but please refrain yourself from doing so. The only people that know how to use this warp capsule are the members of the Omega Sector. Here's wishing you good luck. I would like to see him soon.");
		}
		else if (quest == "3")
		{
			if (ItemCount(4031221) >= 1)
			{
				self.say("I know you want to test out the capsule, but please refrain yourself from doing so. The only people that know how to use this warp capsule are the members of the Omega Sector. Here's wishing you good luck. I would like to see him soon.");
				return;
			}
			
			self.say("This is a very precious item. Please don't lose it again. Be careful.");
			
			if (!Exchange(0, 4031221, 1))
			{
				self.say("Are you sure there's a free slot in your etc. inventory?");
				return;
			}
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1003500)
		{
			if (info != "e" && Level >= 50)
				return " Fuel for MT-09";
		}
		else if (quest == 1003501)
		{
			string fuel = GetQuestData(1003500);
			
			if ((info == "" && fuel == "e") || info == "s")
				return " The New Control Program";
			
			else if (info == "1")
				return " Porter the Undependable";
			
			else if (info == "2")
				return " The Brilliant Assistant";
		}
		else if (quest == 1003502)
		{
			if (info == "s")
				return " Porter's Secret Letter";
			
			else if (info == "1")
				return " Where is the Dropship?";
			
			else if (info == "2")
				return " The Pilot's Whereabouts...";
		}
		else if (quest == 1007400)
		{
			if (info == "2")
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
		
		int[] quests = {1003500, 1003501, 1003502, 1007400};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "Hi! I'm the head engineer of the Omega Sector, #b#p2051001##k. I don't have too much work with me, but I'm really busy because I don't have any assistants here with me.";
		
		if (GetQuestData(1003502) == "e")
			dialogue = "You're back again. Thanks for investigating the transporter last time. I still have no idea what happened to the pilot, \r\nbut ... at least we found a letter that he wrote, so that'll do for now. Hopefully he's doing fine somewhere in the world, just the way he said it in the letter.";
		
		if (GetQuestData(1007400) == "e")
			dialogue = "Hello there. I've been keeping myself busy trying to invent something new today.";
		
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
			case 0: Fuel(); break;
			case 1: Control(); break;
			case 2: Dropship(); break;
			case 3: Robinson(); break;
		}
	}
}