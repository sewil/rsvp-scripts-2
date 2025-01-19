using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(400);
		string quest2 = GetQuestData(401);
		
		if (quest1 == "")
		{
			self.say("Hmmm ... you look like you can use a little bit of my guidance. Hahaha, do not be afraid. It just looks like you're not used to this place, yet. Is it your first time here? You may run into some unwanted trouble by just wandering around not knowing a thing about this place. What you need more than anything is FOCUS. What do you think? Do you want me to train you?");
			
			SetQuestData(400, "010010010");
			self.say("Hmmm, alright. It's very simple actually. All you need to do right now is to hunt the monsters. And don't think a simple act like hunting won't be of much help. You'll be assigned to do a few tasks through me, and you'll ultimately end up growing as a traveler.");
			self.say("Look around this town, and you'll run into lots of monsters. The weakest of all is the Snail, a tiny green snail, and it's a piece of cake. The next weakest are the Blue Snails and the Shrooms. My advice to you is to feast on the weaker monsters and level up easily, until it gets to the point where you can handle bigger, stronger, and faster monsters. It's all about understanding your strengths and weaknesses, and using that knowledge to hunt down the right monsters. Please take down #r10 #o100100#s, 10 #o100101#s and 10 \r\n#o120100#s for me.");
			self.say("Oh, and press W to see the World Map and locate Southperry. Go there and meet #p20002#, and he may have something in store for you. You can take on #p20002#'s quest while training with me, so I suggest you meet him pronto.");
		}
		else if (quest1 == "end")
		{
			if (quest2 == "end")
			{
				self.say("How about going to the world out there?");
			}
			else
			{
				if (quest2 != "000")
				{
					self.say("I don't think you've killed enough. Press Q and check on the quest.");
					return;
				}
				
				self.say("So you've taken care of all the Orange Mushroom's? Weren't they hard to find? It would have been difficult to find them just by walking around. You could enter every portal or the door; that would have helped quite a bit. Let's see how strong you have become...");
				
				if (!Exchange(300))
				{
					self.say("Huh? You don't want my money??????");
					return;
				}
				
				AddEXP(150);
				SetQuestData(401, "end");
				QuestEndEffect();
				self.say("Great job! I can see that you're now strong enough to hold your own against any monster here. You'll have to start making job decisions once you reach level 8. If you haven't met Rain yet, I suggest you do. Rain will quiz you on a lot of things and give you some very valuable information along the way. Well then, until we meet again ....");
			}
		}
		else
		{
			if (quest1 != "000000000")
			{
				self.say("Hmmm ... I don't think you understood what I told you. You haven't defeated enough number of monsters. You know you can check on your quest progress by pressing Q, right? I suggest you check out the numbers again.");
				return;
			}
			
			self.say("How was it? Have you been training by taking on the weaker monsters? Let me see ...");
			
			AddEXP(70);
			SetQuestData(400, "end");
			SetQuestData(401, "010");
			QuestEndEffect();
			self.say("Wow, you're very fast! That's awesome. We'll head straight to the next quest, the last one I'll give you. It's important to know your limits, but it's also very important that you take on some powerful monsters every once in a while to harness your abilities. What do you think? Do you want to take on the quest of defeating some powerful monsters?");
			self.say("This time, you'll be taking on #o1210102#, which you WON'T find just by wandering around. You'll have to walk around everywhere, go into every portal, and defeat the orange-colored mushrooms. I want you to defeat #r10#k of \r\nthem!! Remember, they are considered the most powerful monsters on this island ... oh, and Biggs is collecting something about the #o1210102#'s. If you haven't done Biggs a favor already, then ... I suggest you help him out while training.");
		}
	}
}