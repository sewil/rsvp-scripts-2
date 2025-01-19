using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1001100);
		
		long isPet = AskPet("");
		
		if (isPet == 0)
		{
			if (quest == "end")
			{
				self.say("Hey... how's the pet with its new life? It feels very good to see you happy with your pet. Well then... I'll have to get back to my studies...");
			}
			else
			{
				self.say("Hey, I'm #p1032102#. I study various types of spells here in #m101000000#. I have been studying the magic of life for hundreds of years, but it has no end... Well then, I'll have to get back to my studies...");
			}
			
			return;
		}
		
		if (quest == "s")
		{
			if (ItemCount(4070000) < 1 || ItemCount(4031034) < 1)
			{
				self.say("You still haven't gotten #b#t4070000##k and #b#t4031034##k, right? Go see #b#p1012006##k of #m100000000#, that person must know about the scroll. Please gather these items quickly...");
				return;
			}
			
			bool complete = AskYesNo("You brought the #b#t4070000##k and #b#t4031034##k... With them I can bring the doll back to life with my magic power. What do you think? Do you want to use the items and awaken your pet...?");
			
			if (!complete)
			{
				self.say("I understand... you're not 100% ready for this, are you? You're not thinking of leaving this pet as a doll, right? Please come back if you change your mind...");
				return;
			}
			
			long petCode = AskPet("So, which pet do you want to recover? Choose the pet you want alive the most...");
			
			bool okPet = SetPetLife(petCode, 4070000, 4031034);
			
			if (!okPet)
			{
				self.say("Something is not right... are you sure that you have #b#t4070000##k and #b#t4031034##k? Without these two I can't make the doll back into being an animal.");
				return;
			}
			
			SetQuestData(1001100, "end");
			QuestEndEffect();
			self.say("Your doll has now returned to being your pet. However, my magic isn't perfect. So, I can't promise eternal life... please take good care of this pet before the #t4070000# runs out. Well then... bye...");
		}
		else
		{
			self.say("Nice to meet you! I'm #p1032102# and study various types of spells here in #m101000000#. I am especially fascinated by the magic of life. The mystery that has no end, the mystery known as life... I'm trying to discover how to create life.");
			bool start = AskYesNo("It looks like you already met #p1012005#. #p1012005# is a person who studied the magic of life with me. I heard talk that he used an incomplete life magic on a doll to create a living animal... The doll that you have is the same one that #p1012005# created, called a #bPet#k?");
			
			if (!start)
			{
				self.say("But it looks like the one made by #p1012005#, I'm sure. Ah... well, nevermind. I've known #p1012005# for years and it's safe to say he can't succeed in life magic for dolls. Well then...");
				return;
			}
			
			self.say("I understand. The doll came to be a living animal... but the same item that #p1012005# used to give life to the pet, #b#t4070000##k, ran out and thus returned to being a doll... obviously it's not moving, since it's a doll now... hmmm... is this thing called life really not something you can create with magic...?");
			self.say("Do you want to bring the doll back as it was, alive? You want to go back to the time when your pet obeyed you, only you, and kept your company, right? Of course, it's totally possible. Since I am the Fairy who studied the magic of life with #p1012005#... Maybe I can make it move again...");
			bool start2 = AskYesNo("If I can get a #b#t4070000##k and a #b#t4031034##k, maybe I can bring the doll back to life. What do you think? Do you want to gather the items? Bring the items and I will try to make your doll revive...");
			
			if (!start2)
			{
				self.say("Do you want to leave the doll as it is? It's a doll and all, but... it will be difficult to erase your memories with it too. If you regret it, look for me, okay?");
				return;
			}
			
			SetQuestData(1001100, "s");
			self.say("Very well. I'll say it again, but what I need is a #b#t4070000##k and a #b#t4031034##k. Get them and I can bring the doll back to life. The #b#t4031034##k is the most difficult to obtain... what do you think of looking for the #b#p1012006##k, of #bHenesys#k? Maybe that person will give you a tip or two...");
		}
	}
}