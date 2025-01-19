using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string maya = GetQuestData(1000200);
		
		if (maya == "" || maya == "m1")
		{
			self.say("Ah...so boring~~! My dream's to travel all over the world, collecting all kinds of materials needed to become the best alchemist there is. Not with the way I am right now, though...sigh...soooooo boring...");
		}
		else if (maya == "m2")
		{
			self.say("Hmm... So you want to have #b#t4031004##k? That stone is very rare... Alright, get me the items, I tell you... Ready?");
			self.say("#b#e50#n #t4000004#s, #e50#n #t4000005#s, #e20#n #t4000006#s#k, and #b#e1#n \r\n#t4031005##k. Everything else should be easy to obtain. As for the #t4031005#...  you should ask #r#p1022002##k. He is somewhere around the town.");
			
			SetQuestData(1000200, "m3");
		}
		else if (maya == "m3" || maya == "m4")
		{
			self.say("If you have #e50#n #b#t4000004##k, #e50#n #b#t4000005##k, #e20#n #b#t4000006##k, #e1#n #b#t4031005##k, you can make 1 #b#t4031004##k... You should ask #r#p1022002##k about #t4031005#... I think he is somewhere around #m102000000#");
		}
		else if (maya == "m5")
		{
			if (ItemCount(4031005) < 1 || ItemCount(4000004) < 50 || ItemCount(4000005) < 50 || ItemCount(4000006) < 20)
			{
				self.say("If you have #e50#n #b#t4000004##k, #e50#n #b#t4000005##k, #e20#n #b#t4000006##k, #e1#n #b#t4031005##k, you can make 1 #b#t4031004##k... You should ask #r#p1022002##k about #t4031005#... I think he is somewhere around #m102000000#");
				return;
			}
			
			self.say("How did you get all these items?? You must be really good! Especially #t4031005#. Wow... Anyway, good job! Now we can make a #b#t4031004##k");
			
			if (!Exchange(0, 4031005, -1, 4000004, -50, 4000005, -50, 4000006, -20, 4031004, 1))
			{
				self.say("Make sure there's a space open in your etc. inventory, ok?");
				return;
			}
			
			SetQuestData(1000200, "m6");
			self.say("Here, take this, the #b#t4031004##k. By the way, what do you plan on doing with that stone? It is a special item, indeed, but ... unless you're collecting stones, this may be of no \r\nuse...");
		}
		else if (maya == "m6")
		{
			if (ItemCount(4031004) >= 1)
			{
				self.say("So what did you do with #b#t4031004##k? I see ... that piece of stone is very much coveted by many ... but so many materials were needed for this so you're the first one that ever gathered every single one of them up. Hopefully you'll put this to good use...");
				return;
			}
			
			self.say("Here, take this, the #b#t4031004##k. By the way, what do you plan on doing with that stone? It is a special item, indeed, but ... unless you're collecting stones, this may be of no use...");
			
			if (!Exchange(0, 4031004, 1))
			{
				self.say("Make sure there's a space open in your etc. inventory, ok?");
				return;
			}
		}
		else
		{
			self.say("What did you do with #b#t4031004##k? That's a coveted rock and all, but it requires so many items to make that you're the first one to actually gather them all up! Anyway, hope this is put to good use.");
		}
	}
}