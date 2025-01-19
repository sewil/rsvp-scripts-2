using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1002400);
		string marco1 = GetQuestData(1002401);
		
		if (Level < 25)
		{
			self.say("Hmmm...? I don't think we've ever met. What are you doing at my house? If you don't have anything to talk about, then please leave.");
			return;
		}
		
		if (quest == "")
		{
			bool start = AskYesNo("Hello, there. I don't think we've ever met ... what can I do for you here? Well, the thing is, lately I've been experiencing some very strange things, and therefore very apprehensive towards strangers. Because of that ... well, um ... will it be okay for you to help me out here?");
			
			if (!start)
			{
				self.say("Hmmm ... you must be busy with other things. I understand. You travel around different places, and it's only natural that you're busy. If you ever find some free time, however, then please find me. I really need help from someone like you.");
				return;
			}
			
			SetQuestData(1002400, "s");
			self.say("Thank you so much. Now, here's the story. I've actually been declared missing for 10 months now, but I have no recollection of what happened during the 10 months that I've been deemed missing. It's like, I woke up one day, and 10 months have passed, just like that. Isn't that strange?");
			self.say("I couldn't sleep for a while because I was in shock. Luckily, there were people around me to bring me back to my senses, and I slowly started living a normal life again when two men dressed in dark suits came to me. They proceeded to ask me questions regarding the lost 10 months, then left.");
			self.say("I'm very much sure that those men know what happened to me, and I need to find out what happened. Please find those men in black suits for me and ask them whatever they know about me, so I can recover 10 months' worth of memories. I don't think they're at either Ludibrium or Eos Tower, though. Good luck!");
		}
		else if (quest == "s" && marco1 == "")
		{
			self.say("I don't think you have located the men in black suits yet. The only ones that know what happened to me over the past 10 months are them, and I need to find out what happened. Please find those men in black suits for me and ask them whatever they know about me, so I can recover 10 months' worth of memories.");
		}
		else if (quest == "s" && (marco1 == "s" || marco1 == "e"))
		{
			if (ItemCount(4031091) < 1)
			{
				self.say("Hmmm... It seems like you have met the man in black suit that I described for you. Did you find out anything new? What did he say about my lost memories? Please revisit him and find out more information about me. Thanks.");
				return;
			}
			
			self.say("Oh wow, you're back! What?? The man in black suit told you that I spent the last 10 months being abducted by the aliens? I can't believe this ... aliens?? Do they even exist? I can't believe what I'm hearing... I can't believe you.");
			self.say("Hmmm... What's that you're holding? Is that ... what the ...?? Is that ... the lost memory of mine?? Okay, now you have turned my lost 'memories' into an object... and I'm supposed to trust you?? But ... well, maybe I should just go there and take a look at the item. Maybe it is what it really is, a lost memory. Let's see....");
			
			if (!Exchange(0, 4031091, -1, 2040001, 1))
			{
				self.say("Oh... please make sure you have space in your use inventory");
				return;
			}
			
			AddEXP(2550); // check later
			SetQuestData(1002400, "e");
			self.say("Arrrgh ... this ... this ... oh my goodness ... now I remember everything. Yes, I had been abducted by the aliens who call themselves #bMatians#k. They were trying to extract any information regarding Ludibrium and Omega Sector from me, but I refused...");
			self.say("I finally escaped their wrath after spending countless days being held captive. They followed me for a while, but I successfully found refuge in Omega Sector, after which I got safely sent home. Whew... thank you so much for helping me recover my lost memories. There are still some loose ends that need to be addressed, but...");
			self.say("Anyway, without your help, I would have probably spent the rest of my life wondering whatever happened in those 10 months. Did you like the small reward I gave you for your hard work? Use that scroll on the hat / helmet you're currently wearing, and it'll significantly improve its stats. Thank you so much for helping me out. Good bye.");
		}
		else if (quest == "e")
		{
			self.say("You're the one that helped me find my lost memories. I can't thank you enough for your effort. I've been trying to live a normal life these days.");
		}
	}
}