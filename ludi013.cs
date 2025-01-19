using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1002200);
		string lastDate = GetQuestData(1002201);
		string today = DateTime.UtcNow.ToString("yyyyMMdd");
		
		if (lastDate == today)
		{
			self.say("Eos Tower is humongous ... so big that we have gotten ourselves lost in this place every once in a while.");
			return;
		}
		
		if (quest == "s")
		{
			if (ItemCount(4000103) < 30 || ItemCount(4000123) < 30)
			{
				self.say("I don't think you have collected all the items I asked of you. Please take down the monsters within Eos Tower and collect #b30 worn-out goggles and 30 propellers of the plane#k for me. I can't get to the 59th floor where I am in charge of the security because of those darn monsters. Please help me!");
				return;
			}
			
			self.say("Wow ... you really took them all down. I knew I had an eye for talent. Anyway, thank you for your hard work. As a sign of appreciation, I'll give you #b#t4001020#s#k, something I've cherished for a long time. I'll tell you how to use it after you receive it.");
			
			if (!Exchange(0, 4000123, -30, 4000103, -30, 4001020, 20))
			{
				self.say("Please leave an empty space in your etc. inventory first.");
				return;
			}
			
			SetQuestData(1002200, "end");
			SetQuestData(1002201, DateTime.UtcNow.ToString("yyyyMMdd"));
			QuestEndEffect();
			self.say("The #b#t4001020##k that I gave you is an item that is very essential in activating the four stones within Eos Tower. It'll allow you to use #b#p2040024##k at the 100th floor, #b#p2040025##k at the 71st floor, #b#p2040026##k at the 41st floor, and #b#p2040027##k at the 1st floor. Use those rocks to teleport to other rocks. Please drop by again ~");
		}
		else
		{
			bool askStart1 = AskYesNo("Hmmm ... where am I?? I'm in charge of security for the 59th floor of Eos Tower, but I have nooo idea where I am at right this minute. Dang ... this place is also full of monsters, which makes it impossible for me to do my duty here. Can you help me out, if it's okay with you?");
			
			if (askStart1)
			{
				SetQuestData(1002200, "s");
				self.say("Alright! It's a simple request, actually. Please take out the monsters that are on my way to the 59th floor of Eos Tower, and hand me the leftovers as a proof. It'll be much easier for me to go to the 59th floor if the numbers of the monsters decrease on my way there.");
				self.say("The ones you'll need to take down are #b#o3230307##k and #b#o3210206##k. Take those down and hand me #b30 worn-out goggles and 30 propellers of the plane#k. I'll be here waiting for you, my friend. Good luck!");
			}
		}
	}
}