using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Korin()
	{
		string quest = GetQuestData(1002401);
		
		if (quest == "")
		{
			self.say("Shhhh... I suggest you don't talk to me around here for your safety. Omega Sector is constantly under watch, and it's best for you to be as careful as possible around here. \r\nHmmm... and...? So you're saying you came here at #b#p2041015##k's request? I see ...");
			bool start = AskYesNo("I wish I could say I have no knowledge of that person, but looking at you, I don't think that's going to work. Alright, then, I'll tell you everything I know about her. Before that, though, can you please promise me that you won't tell anyone anything about matters regarding #b#p2041015##k, myself included?");
			
			if (!start)
			{
				self.say("This is classified information, and it's a dangerous mission, to say the least, so I cannot stress this enough, but please do not reveal this information to anyone. I cannot talk to you about anything unless you promise to keep this information a secret. Well then, I'll have to get back to work, so if you'll excuse me...");
				return;
			}
			
			SetQuestData(1002401, "s");
			self.say("Okay, then. I'll spill out everything I know. I've actually been well aware of the fact that she'd been declared missing, but by then, it was past our hands. All we could do afterwards was to just hope for her safe return.");
			self.say("As we had suspected, she was ... kidnapped by the forces that invaded Omega Sector. We suspect that the alien that abducted her is #b#o4230119##k. Anyway, she's now living a different life, thanks to the fact that she's currently suffering from amnesia. It'd be nice to help her find the lost memories ...");
			self.say("Matian probably tried to break in by kidnapping a number of the citizens around the area. Anyway, head over to Roswell Plain, and you'll be fighting #b#o4230119#s#k. Every once in a while, you may be able to pick up #b#t4031090##k, which contains the memories of #b#p2041015##k. It won't be easy, but I think you can do it.");
			self.say("Please gather up #b5 Pieces of Memory#k for me, so I can put them all together for you. Now, I trust that you keep all this information to yourself. Please head over to Roswell Plain and face them. They are difficult to fight against, so I advise you to be on your toes at all times.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031090) < 5)
			{
				self.say("I don't think you have collected all the pieces of #b#p2041015##k's lost memory. Please head over to the Roswell Plain near the Omega Sector and defeat #b#o4230119##k, in order to collect #b5 Pieces of Memory#k to recover #b#p2041015#'s#k memory.");
				return;
			}
			
			self.say("Great job taking down the #b#o4230119#s#k at the Roswell Plain and collecting #b5 Pieces of Memory#k in the process. Alright, then. I'll try to put these pieces together and make it a whole. Here are some Mesos as a sign of thanks for taking out some aliens for us.");
			
			if (!Exchange(5500, 4031090, -5, 4031091, 1))
			{
				self.say("You'll have to leave a slot open in your etc. inventory first.");
				return;
			}
			
			AddEXP(2150);
			SetQuestData(1002401, "e");
			self.say("Okay, it's done. Now, take this 'memory' to #b#p2041015##k, and she'll probably be able to recover her lost memory. She'll go through an initial stage of shock the moment she recovers the memory, but that's the price she'll have to pay for that. I have a lot to do, so if you'll excuse me...");
		}
		else if (quest == "e")
		{
			if (ItemCount(4031091) >= 1)
			{
				self.say("Please give #b#t4031091##k to #b#p2041015##k so she can recover her lost memories. She'll probably be in a state of shock at first, but she'll be fine. Please go see her immediately.");
				return;
			}
			
			self.say("Okay, it's done. Now, take this 'memory' to #b#p2041015##k, and she'll probably be able to recover her lost memory. She'll go through an initial stage of shock the moment she recovers the memory, but that's the price she'll have to pay for that. I have a lot to do, so if you'll excuse me...");
			
			if (!Exchange(0, 4031091, 1))
			{
				self.say("You'll have to leave a slot open in your etc. inventory first.");
				return;
			}
		}
	}
	
	private void Event()
	{
		string quest = GetQuestData(8020009);
		
		if (quest == "")
		{
			bool start2 = AskYesNo("Good Lord! Aliens are striking us harder than ever! Hey! Would you be interested to fight aliens for the independence of our world?");
			
			if (!start2)
			{
				self.say("Oh... If you are scared, I guess we have to take care of this by ourselves. However, if you can get those nerves under control, come talk to me again.");
				return;
			}
			
			SetQuestData(8020009, "s");
			self.say("Just as I thought! I knew you'd be the one to help us out. There was a tremendous invasion of #rPlatians#k somewhere around Roswell Plains. Terminate the ugly suckers and bring back #b100 Platian Helmets#k to me as a proof of your work. I better not find you hiding in a hole!");
		}
		else if (quest == "s")
		{
			if (ItemCount(4000121) < 100)
			{
				self.say("Roswell Plains are still suffering from the invasion of Platians. Take them out!");
				return;
			}
			
			self.say("You made it! Now I know we can win this battle! As token of our gratitude, we shall award you with #bthe Stars and Stripes#k. Good work soldier!");
			
			if (!Exchange(0, 4000121, -100, 1302057, 1))
			{
				self.say("Please leave a slot open in your equip. inventory for this!");
				return;
			}
			
			AddEXP(3000);
			SetQuestData(8020009, "end");
			QuestEndEffect();
			self.say("How do you like the Stars and Stripes? It is a flag specially designed to commemorate this Independence Day!");
		}
	}
	
	private bool Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1002400)
		{
			if (info == "s")
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (quest == 8020009)
		{
			var startTime = DateTime.Parse("2021-07-04");
			var endTime = DateTime.Parse("2021-07-26");
			var today = DateTime.UtcNow;
			
			if (today >= startTime && today < endTime && info != "end")
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		return false;
	}
	
	public override void Run()
	{
		bool checkKorin = Check(1002400);
		bool checkEvent = Check(8020009);
		
		string questKorin = GetQuestData(1002400);
		
		if (checkKorin && checkEvent)
		{
			AskMenuCallback("Shhh... I advise you not to act like you know me here. The Omega Sector is the safest place in this world, as well as the most threatened. Unless you need me for something important, please excuse me right this minute.#b",
				(" The Man in the Black Suit", Korin),
				(" Independence Day : Alien Invasion", Event));
		}
		else if (checkKorin && !checkEvent)
		{
			Korin();
		}
		else if (!checkKorin && checkEvent)
		{
			Event();
		}
		else
		{
			if (questKorin == "e")
			{
				self.say("Hmmm... Fortunately #b#p2041015##k seems to have found her memory back. Please warn her not to get abducted by the aliens again. Now, please excuse me, for I have business to take care of.");
			}
			else
			{
				self.say("Shhh... I advise you not to act like you know me here. The Omega Sector is the safest place in this world, as well as the most threatened. Unless you need me for something important, please excuse me right this minute.");
			}
		}
	}
}