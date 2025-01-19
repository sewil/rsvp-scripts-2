using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(2);
		
		if (quest == "")
		{
			if (chr.GetGender() == 0)
			{
				self.say("Hey, you there! Can I talk to you for a minute? Haha! I am Roger, an instructor who helps new travelers like you.");
				self.say("You are asking who MADE me do this? HAHAHAH! You are a VERY curious traveler! Well, well, well... I'm doing it because I want to. That's all.");
			}
			else if (chr.GetGender() == 1)
			{
				self.say("Hey hotness! Are you free? Hehe... I'm Roger the instructor, one that hooks up cute girls like you with useful information to go through this game.");
				self.say("Hey, give me just a little bit of your time. I'll give you a lot of valuable informations, just for a cutie like you. Hahaha!!!");
			}
			
			self.say("Alright, let's have some fun. Yahh!");
			
			int nHP = HP / 2;
			SetHP((short) -nHP);
			
			self.say("Surprised? Can't have your HP down to 0. Alright, I'll give you an #r#t2010000##k so eat it. You'll regain strength by doing that. Open your item inventory and double-click on it.");
			self.say("You have to eat all the #t2010000#s that I gave you, but you can actually recover HP just by standing still, so talk to me when you have fully recovered your HP.");
			
			if (!Exchange(0, 2010000, 1))
			{
				self.say("You can't carry this apple can you?");
				return;
			}
			
			SetQuestData(2, "1");
		}
		else if (quest == "1")
		{
			if (ItemCount(2010000) >= 1)
			{
				self.say("Come on, eat the #r#t2010000##k that I gave you~ Open the inventory and click on the #b'Use'#k tab, then double-click on the #t2010000# to use it.");
				return;
			}
			
			if (HP < MaxHP)
			{
				self.say("You haven't fully regained your strength. Did you really eat the #t2010000# that I gave you? Are you sure?");
				return;
			}
			
			self.say("How easy is it to consume the item? Simple, right? You can set a #bhotkey#k on the right bottom slot. You didn't know that, right? Hahaha!");
			self.say("Alright! You have learned a lot, so I will give you a present. You don't need to thank me for teaching you this skill. Use it when needed.");
			
			if (!Exchange(0, 2010000, 3))
			{
				self.say("You can't carry these apples can you?");
				return;
			}
			
			AddEXP(2);
			SetQuestData(2, "end");
			QuestEndEffect();
			self.say("This is all I can teach you. It's sad but it is time to say good bye. Take care of yourself. See you...");
			
			if (GetQuestData(1500) != "1")
			{
				SetQuestData(1500, "1");
				ToggleUI("Guide", true);
			}
		}
		else
		{
			self.say("Nice weather today!");
		}
	}
}