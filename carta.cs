using System;
using System.Collections.Generic;
using WvsBeta.Game;

// 2060100 - Carta
public class NpcScript : IScriptV2
{
	private void SeaWitch()
	{
		string quest = GetQuestData(1007500);
		
		if (quest == "s")
		{
			AskMenu("For you to voluntarily walk into a dangerous place like this, you must be either really foolish or really brave. Now, what can I do for you?#b",
				(0, " I want you to look into my future. I have something I need \r\nto find out."));
			
			self.say("You must have heard some foolish nonsense from someone on your way here. There's no such thing as fortune-telling, understand? The future isn't set in stone, contrary to popular belief. It's ignorant people like you that refuse to believe in that fact and ask me to see their future.");
			AskMenu("But then again... though I may not be able to look into someone's future, I sure can see what that someone is doing right at this moment. Afterall, isn't that the reason why you came to see me in the first place? It looks like you've been referred to here by someone ... am I right?#b",
				(0, " Actually ... I came here at the request of #p2060006# to find out about someone named Gail."));
				
			bool start = AskYesNo("I knew it. Gail must be one of those foolish souls that went deep into the ocean a few months back. I warned those fools of the treacherous path they are taking, but they refused to listen. Anyway, in order to find out exactly what you want to find out, I'll need some items along the way. They are rare items to begin with, and trying to find them may even cost your life. What do you think? Do you still want to find out about Gail?");
			
			if (!start)
			{
				self.say("You must not be as foolish as I thought. After all, what's more important than your own life?");
				return;
			}
			
			AddEXP(1000);
			SetQuestData(1007500, "1");
			self.say("The spell that allows me to observe the current events taking place from afar is not only difficult to perform, but it's even more difficult to gather up the necessary items for the spell. It's such a difficult spell that unless I have the absolute correct list of items, the chance of failure will be high. Since you have shown the desire to find out about Gail, now it's up to you to gather up the items.");
			self.say("This spell requires three important items. First, I need #b3 \r\n#t4031256#s#k, which is an item dropped by #r#o8140600##k, the underwater ghost. Second, I need #b10 #t4031251##k. #b#t4031251##k is very small, and they float around the water, so they'll be hard to find, but they can also be found inside the old chests that are sunken to the bottom of the ocean.");
			self.say("Lastly I want #b1 #t4031253##k. This is a sound that this gigantic fish that lives inside the underwater cave makes as it perishes. It'll be difficult for you to locate the fish, let alone killing it. I wonder if you're capable of getting me this last item...");
			self.say("Anyway, gather up all the items I am asking you to get, so you can find out what you've wanted to find out.");
		}
		else if (quest == "1")
		{
			if (ItemCount(4031251) < 10 || ItemCount(4031253) < 1 || ItemCount(4031256) < 3)
			{
				self.say("Hahaha ... are you still looking for the items I asked you to get? I repeat, they are not easy to find. I suggest you give it up if you want to save your life. I'll tell you this one more. I'll need #b3 #t4031256#s, 10 #t4031251#s, and 1 #t4031253##k. I strongly suggest you reconsider. No one will blame you for running away from this.");
				return;
			}
			
			self.say("You must be the one that came by before. Did you gather up the items I asked you to get? It seems like you have, from the look on your face. I'm impressed you made it back here alive.");
			
			if (!Exchange(0, 4031251, -10, 4031253, -1, 4031256, -3))
			{
				self.say("Are you sure you brought everything back? Don't lie to me.");
				return;
			}
			
			AddEXP(90000);
			SetQuestData(1007500, "2");
			AskMenu("Now, let's put these inside and wait until the color changes. So, who's this person I should look into?#b",
				(0, " A young man by the name of Gail, who is sent abroad to explore the deep parts of the ocean."));
			
			AskMenu("Oh... I can see it now. It looks like I'm looking into the past. I see a rock that features patterns on it. I also see the entrance to a cave and... huh? What is that fog? And what's this bad vibe I'm feeling looking at it? I've never seen anything like it ... and that black fog surrounding them ... and it's ... swallowing them up ... deeper ... and deeper into a darker place ... and ... they are gone.#b",
				(0, " What? Anything else? Can you see anything else?"));
			
			self.say("That's all I can see for now. I don't know what's going on, but I don't like this feeling. Now, please tell this to the lady that brought you here.");
			self.say("I've lived in here for a long long time, but I've never felt a negative vibe quite like this. Something may happen really soon. Oh, and I may be just fortune-telling, but please think carefully. Just because you know everything, doesn't mean it's necessarily the best. Sometimes, it's better to not know at all, especially a bad one like this.");
		}
		else if (quest == "2")
		{
			self.say("You can't deliver the bad news to her? But doesn't she have a right to know the truth? Please don't lie to her just to make her feel better. It's better to tell the hard-hitting truth, as opposed to telling a sugar-coated lie.");
		}
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1007500)
		{
			if (info == "s")
				return " Carta the Sea Witch";
			
			else if (info == "1")
				return " Carta's Demand";
			
			else if (info == "2")
				return " Carta's Fortune-Telling";
		}
		
		return null;
	}
	
	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {1007500};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		string dialogue = "You must be a fool to come all the way down here ... what do you want from me?";
		
		if (GetQuestData(1007500) == "e")
			dialogue = "It's foolish for anyone to want to look into the future...";
		
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
			case 0: SeaWitch(); break;
		}
	}
}