using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1001400);
		
		if (quest == "")
		{
			self.say("It's so cold around here! I'm #b#p2030001##k, member of the Alpha Platoon. We got on an accident in mid-flight and made an emergency landing here, but I can't find the others. I'm pretty confident that they're all okay, though.");
			return;
		}
		
		if (quest.Contains("end"))
		{
			self.say("Did you get #b#t4031049##k to #b#p2020003##k? Do I need anything? Well, not for now. But come see me later, alright?");
			return;
		}
		
		if (quest == "s" || quest == "1" || quest == "100" || quest == "102" || quest == "201")
		{
			self.say("What? You came all the way here by #b#p2020003#'s#k request? I thought I was the only survivor. I knew that nothing can hurt #b#p2020003##k. HAHA!");
			self.say("It is good to hear that he is alive. So he is working at El Nath huh? Okay... I found #b#t4031049##k and this would be somewhat related to our mission.");
			bool meetAlpha = AskYesNo("So #b#p2020003##k will also be wating for this. I will give this to you if you give me 2 #b#t4011003#. You can't say that you have met me without this.");
			
			if (meetAlpha)
			{
				if (!Exchange(0, 4011003, -2, 4031049, 1))
				{
					self.say("Oh... are you sure you have #b2 #t4011003#s#k? If not then see if your etc. inventory is full or not, then come talk to me!");
					return;
				}
				
				AddEXP(3000);
				
				if (quest == "s")
				{
					SetQuestData(1001400, "10");
					self.say("Okay... Now, you gotta meet #p2010000# and #p2030002# ... right? They must have found something like me. So long~");
				}
				else if (quest == "1")
				{
					SetQuestData(1001400, "21");
					self.say("Okay... Now, you gotta meet #p2030002#... right? He must have found something like me. So long~");
				}
				else if (quest == "100")
				{
					SetQuestData(1001400, "120");
					self.say("Okay... Now, you gotta meet #p2010000#... right? He must have found something like me. So long~");
				}
				else if (quest == "102")
				{
					SetQuestData(1001400, "132");
					self.say("I guess you've met all the troopers of the Alpha platoon! I'm sure the other men are just doing their job. Now please notify #b#p2020003##k of our whereabouts. Thanks!");
				}
				else if (quest == "201")
				{
					SetQuestData(1001400, "231");
					self.say("I guess you've met all the troopers of the Alpha platoon! I'm sure the other men are just doing their job. Now please notify #b#p2020003##k of our whereabouts. Thanks!");
				}
			}
		}
		else
		{
			self.say("Did you get #b#p2020003##k the #b#t4031049##k I asked you for? Do I have anything more to ask for? Hmmm ... none for now. Come back again sometime~!");
		}
	}
}