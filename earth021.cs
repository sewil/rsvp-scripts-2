using WvsBeta.Game;

// 2050009 Jr. Officer Medin
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string questKim = GetQuestData(1003002);
		string quest1 = GetQuestData(1007100);
		
		if (questKim != "e")
		{
			self.say("A-ten-hut! Can you help me perhaps?");
			return;
		}
		
		if (quest1 == "")
		{
			self.say("You must be the traveler Dr. Kim was talking about. My name is Medin, one of the Jr. Officers working here at the Omega Sector. By now, you are probably well aware of the situation we're in.");
			self.say("We have been defending Earth from the alien invasion for some time now. Before I was a Jr. Officer, I was a soldier stationed at the #bAlpha Sector#k, our headquarters to the east. One day its defenses were breached and we had no choice but to pack what we could and transfer here overnight.");
			bool start = AskYesNo("Hey, I actually have a job for you. Do you think you could help me out?");
			
			if (!start)
			{
				self.say("That's a shame. I have a lot of work to do here so if you change your mind please come see me.");
				return;
			}
			
			SetQuestData(1007100, "s");
			self.say("In our haste leaving the Alpha Sector, we left behind some important research materials. I sent my colleague #b#p2050021##k to investigate the site but I haven't received communication from him in a couple days... I want you to check up on him for me.");
		}
		else if (quest1 == "s")
		{
			self.say("What's the good word? Haven't found #bMars#k yet? He should be somewhere in the #bAlpha Sector#k, the headquarters to the east of Omega Sector.");
		}
		else if (quest1 == "1")
		{
			self.say("So you found #bMars#k right? Was he able to recover the research materials?");
		}
		else if (quest1 == "2")
		{
			self.say("You're back and by the look on your face I'm guessing #bMars#k is alright. Thank you for reporting back so soon, you look like you could use some refreshments.");
			
			if (!Exchange(0, 2022000, 50))
			{
				self.say("Please leave an empty slot in your use inventory first.");
				return;
			}
			
			AddEXP(500);
			SetQuestData(1007100, "e");
			QuestEndEffect();
			self.say("Here's something for your hard work. Hopefully #bMars#k will find everything without problem. If you have time, maybe you should check up on him from time to time. Well, I will see you around.");
		}
		else
		{
			self.say("Hmm... we can't let the aliens steal any classified information.");
		}
	}
}