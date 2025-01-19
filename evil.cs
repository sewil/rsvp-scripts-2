using System.Collections.Generic;
using WvsBeta.Game;

// 1061012 Insignificant Being
public class NpcScript : IScriptV2
{
	private void CriticalDanger(string quest)
	{
		if (quest == "")
		{
			self.say("I...I really don't have much of a presence... it's been a long time since I lost my flesh and blood, but ... the fight against them is still on...");
			self.say("I may have turned into an insignificant being, but with my vast mental abilities as well as the experience gathered from years of training, I can quiet the danger that may be looming ahead... hah...");
			self.say("Humans and monsters should coexist under one roof. That's how it works here in this world. The problem is, those monsters think otherwise, and are getting more powerful by the minute...");
			bool start = AskYesNo("I think you can quiet down that force of evil, seeing that you're brave enough to strike up a conversation with me. I feel like I should test your inner resolve. Are you ready?");
			
			if (!start)
			{
				self.say("I guess I expected too much from you.");
				return;
			}
			
			SetQuestData(1007200, "s");
			self.say("I need 33 of Cold Eye's Cold Steam. They may take a small part in the ritual, but they are difficult to gather up. Are you sure you can do it? Your eyes tell me that you can. Hah... but please be careful not to become an insignificant being like me!");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031212) < 33)
			{
				self.say("No, no, no! Please get the right set of items like I asked you to get!");
				return;
			}
			
			self.say("Something feels creepy around here ... is that you? Did you collect the Cold Steam? I can't believe this! You really did\r\nit ... what are you doing? Bring them over here! Yes, this is it! All 33 of them!");
			self.say("This should help me get the ritual started. They may have been feeling safe ever since I became something like this, but I still have the strength to run this ritual!");
			
			if (!Exchange(0, 4031212, -33, 2000005, 20))
			{
				self.say("Please make sure you have a space available in your use inventory!");
				return;
			}
			
			AddEXP(12000);
			SetQuestData(1007200, "1");
			self.say("The items needed for the ritual can be difficult to obtain... it may even cost your life. Now, please hold on to this potion carefully. It'll help prevent you from turning into a ghost yourself!");
			
		}
		else if (quest == "1")
		{
			self.say("Alright, let's cut to the chase. I still need the items that take an integral part of this ritual. I need the spirit rocks of the monsters that live beyond those two doors.");
			bool start2 = AskYesNo("They'll be difficult to handle, but those spirit rocks are essential to this ritual. Can you gather them up for me?");
			
			if (!start2)
			{
				self.say("I can't start the ritual without them!");
				return;
			}
			
			SetQuestData(1007200, "2");
			self.say("The Spirit Rock is a small, shiny rock that contains their sealed spirit. Please get me #b33 #t4031213#s, 18 #t4031214#s, and 18 #t4031215#s#k");
			self.say("Okay, there are two roads, and in order to obtain the item, you'll need to take both. Hurry! Please gather up their Spirit Rocks quickly!");
		}
		else if (quest == "2")
		{
			if (ItemCount(4031213) < 33 || ItemCount(4031214) < 18 || ItemCount(4031215) < 18)
			{
				self.say("Did you forget what I told you? I told you to get #b33 #t4031213#s, 18 #t4031214#s, and 18#t4031215#s#k! Please check again. It's the spirit rock! The spirit rock!!");
				return;
			}
			
			self.say("Be careful! I need those items for the ritual! They may be spirit rocks, but you should be more careful with it than that. If you're not being careful with it, one slip-up can ruin the whole thing! Man... just incredible... just incredible...");
			
			if (!Exchange(0, 4031213, -33, 4031214, -18, 4031215, -18, 2000005, 30))
			{
				self.say("Please make sure you have a space available in your use inventory!");
				return;
			}
			
			AddEXP(45000);
			SetQuestData(1007200, "e");
			QuestEndEffect();
			self.say("Great job! It's been a while since I last saw a great soldier like you.");
		}
	}
	
	private void SourceOfEvil(string quest)
	{
		if (quest == "")
		{
			self.say("So you have returned ... since you came here last the force of evil has only grown stronger. The ritual may have weakened it temporarily, but it has not been completely eliminated.");
			self.say("There is one way to seal it for good but in order to complete the ritual to seal all evil back into the sanctuary, I am asking you to eliminate the powerful monster: #bJr. Balrog#k. Take it down and take its spirit rock!");
			bool start = AskYesNo("Taking it down will be difficult but the spirit rock is essential to the ritual. Can you gather it up for me?");
			
			if (!start)
			{
				self.say("The force of evil will run amuck if we don't seal it!");
				return;
			}
			
			SetQuestData(1007201, "s");
			self.say("The Spirit Rock is a small, shiny rock that contains the sealed spirit. Please bring it back in one piece.");
			self.say("Take the road ahead of me to the very end to where the sanctuary is. Hurry! Please gather up the Spirit Rock quickly!");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031216) < 1)
			{
				self.say("Did you forget what I told you? I told you to take down #bJr. Balrog#k and get #b#t4031216##k! Please check again. It's the spirit rock! The spirit rock!!");
				return;
			}
			
			self.say("Be careful! I need that item for the ritual! They may be spirit rocks, but you should be more careful with it than that. If you're not being careful with it, one slip-up can ruin the whole thing! Man... just incredible... just incredible...");
			
			int itemID = 0;
			
			if (Job >= 100 && Job < 200) itemID = 1082105;
			else if (Job >= 200 && Job < 300) itemID = 1082100;
			else if (Job >= 300 && Job < 400) itemID = 1082108;
			else if (Job >= 400 && Job < 500) itemID = 1082097;
			else itemID = 1082150;
			
			if (!Exchange(0, 4031216, -1, itemID, 1))
			{
				self.say("Please make sure you have a space available in your equip. inventory!");
				return;
			}
			
			AddEXP(75000);
			SetQuestData(1007201, "e");
			QuestEndEffect();
			self.say("Great job! Now that the ritual is complete, the force of evil should be sealed away for good. You've proven your strength to me, so I am giving you my last worldly posession. These are the gloves I wore while fighting them back then.");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1007200)
		{
			if ((info == "" && Level >= 50) || info == "s")
				return " A Spell that Seals Up a Critical Danger I";
			
			else if (info == "1" || info == "2")
				return " A Spell that Seals Up a Critical Danger II";
		}
		else if (quest == 1007201)
		{
			string spell = GetQuestData(1007200);
			
			if ((info == "" && spell == "e" && Level >= 70) || info == "s")
				return " Sealing Up the Source of Evil";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1007200, 1007201};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "......";
		
		if (GetQuestData(1007200) == "e")
			dialogue = "Did the force of evil disappear completely...?";
		
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
			case 0: CriticalDanger(GetQuestData(1007200)); break;
			case 1: SourceOfEvil(GetQuestData(1007201)); break;
		}
	}
}