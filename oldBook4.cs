using System;
using WvsBeta.Game;

// 2020006 Jade
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string questBook2 = GetQuestData(1001501);
		
		if (questBook2 == "")
		{
			self.say("I've been studying the geography of this island for a long time, and I still don't know a lot of things. I need more data. Anyway, I'm worried about this friend of mine in Orbis who disappeared out of the blue one day. I wonder what happened to her.");
		}
		else if (questBook2 == "s")
		{
			self.say("You are looking for Hella? It is true that I've been friends with her for years, but this time, she really took off without much of a word...I've gone everywhere, going to every place that had anything to do with her, to no avail. Hella left home soon after #blosing her mother a few months ago#k. It ... will be hard to find her. I think you should give up on the search, too.");
			SetQuestData(1001501, "h1");
		}
		else if (questBook2 == "h1")
		{
			self.say("You are not giving up, are you? Well, I have one place I can think of right this minute. I remember Hella mentioning her #bkeepsake from her late mother#k the other day. One day it got stolen by someone, and I think she may have gone looking for it. Maybe that's what she did. #bElma the Housekeeper#k may know a thing or two about it so how about going back to Hella's house and ask Elma about it?");
			AddEXP(2000);
			SetQuestData(1001501, "h2");
		}
		else if (questBook2 == "h2")
		{
			self.say("Hella may have left home to look for her lost #bkeepsake of her late mother#k. #bElma the housekeeper#k should know some things about it, so I suggest you head back to Hella's house.");
		}
		else if (questBook2 == "h3")
		{
			self.say("Hella talked about an #bold lady#k? Well, there is no such old lady neither around Orbis nor El Nath, but oh wait. Maybe she's talking about #bSpiruna#k, who lives in a small house around Orbis Park surrounded by monsters. You should stop by that house once.");
			AddEXP(2000);
			SetQuestData(1001501, "h4");
		}
		else if (questBook2 == "h4" || questBook2 == "h5")
		{
			self.say("Maybe the old lady is #bSpiruna#k, who lives in a small house around Orbis Park surrounded by monsters. You should stop by that house once.");
		}
		else if (questBook2 == "h6")
		{
			if (ItemCount(4031052) < 1)
			{
				self.say("Maybe the old lady is #bSpiruna#k, who lives in a small house around Orbis Park surrounded by monsters. You should stop by that house once.");
				return;
			}
			
			self.say("This is the #bpendant#k that I gave Hella back when we were kids, which means you did meet her! How is she?? I can finally concentrate on my studies now that I know that Hella is doing alright. She told you to give this pendant to me? Okay, then. I'll hold on to it until the day I see her again. Here's my reward for your hard work.");
			
			Random rnd = new Random();
			int[] scrolls = {2040701, 2040702, 2040707, 2040708};
			
			int itemID = scrolls[rnd.Next(scrolls.Length)];
			
			if (!Exchange(0, 4031052, -1, itemID, 1))
			{
				self.say("Please make room in your use inventory first!");
				return;
			}
			
			AddEXP(12320);
			SetQuestData(1001501, "end");
			SetQuestData(1001500, "he");
			QuestEndEffect();
			self.say("Are you saying Hella wants to ask me about #b#t4031056##k? It's been recorded that the book's been lost somewhere in the snowfield, and hmmm ... Right! A few days ago, while checking out the landscape around town I found a #bsmall tomb#k deep in the valley of the snowfield. Maybe that tomb has something to do with it...");
			self.say("I wanted to find out what that tomb was so I tried getting close to it, only to realize that it was impossible because of all the scary monsters around that area. I think you're strong enough, though, to find a way to go in there and thoroughly check out the tomb. The place where I found it was #bdeep in the valley of the snowfield#k. I'll pray for your safety throughout this trip.");
		}
		else if (questBook2 == "end" && questBook2 == "he")
		{
			self.say("A few days ago, while checking out the landscape around town I found a #bsmall tomb#k deep in the valley of the snowfield. I wanted to find out what that tomb was so I tried getting close to it, only to realize that it was impossible because of all the scary monsters around that area. I think you're strong enough, though, to find a way to go in there and thoroughly check out the tomb. The place where I found it was #bdeep in the valley of the snowfield#k. I'll pray for your safety throughout this trip.");
		}
		else
		{
			self.say("I have no clue where Hella may be, or what she is doing, but I'm sure she's doing just fine there. I'll be here living just fine, waiting for the day when I see her again.");
		}
	}
}