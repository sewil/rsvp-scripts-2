using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (!eventActive("christmas2022") && !eventDone("christmas2022"))
		{
			self.say("I'm very sorry, Happyville is still not open to the public~ Be patient!");
			return;
		}
		
		if (eventDone("christmas2022"))
		{
			self.say("Thanks for joining us for the event~! Christmas is over now, but be sure to drop by again next year!");
			return;
		}
		
		if (MapID == 101000000)
		{
			bool askEnter = AskYesNo("Have you heard of a Christmas town all covered in snow that's not very far from #m101000000#? It's a beautiful and peaceful place, all covered in snow. Do you want to come along? Hmmm... I can't take you there just like that... Ah, yes! Collect #b10 #t4000004#s, 10 #t4000003#s and 1000 mesos#k, with that I can take you there. What do you think? Do you want to go there?");
			
			if (!askEnter)
			{
				self.say("You must not have time, huh? If you have time later, stop by again. A town all covered in snow... Doesn't your heart just race thinking about it?");
				return;
			}
			
			if (!Exchange(-1000, 4000004, -10, 4000003, -10))
			{
				self.say("Are you sure you have #b10 #t4000004#s and 10 #t4000003#s and 1000 mesos#k? I can't let you come along without those two and some money~");
				return;
			}
			
			SetQuestData(9000200, "0");
			ChangeMap(209000000, "st00");
		}
		else if (MapID == 211000000)
		{
			bool askEnter = AskYesNo("Have you heard of a Christmas town all covered in snow that's not very far from #m211000000#? It's a beautiful and peaceful place, all covered in snow. Want to come along? Hmm... Hmmm... I can't take you there just like that... Ah, yes! Collect #b10 #t4000086#s, 10 #t4000088#s and 1000 mesos#k, and I will take you there. What do you think? Do you want to go there?");
			
			if (!askEnter)
			{
				self.say("You must not have time, huh? If you have time later, stop by again. A town all covered in snow... Doesn't your heart just race thinking about it?");
				return;
			}
			
			if (!Exchange(-1000, 4000086, -10, 4000088, -10))
			{
				self.say("Are you sure you have #b10 #t4000086#s and 10 #t4000088#s, and 1000 mesos#k? I can't let you come along without those two and some money~");
				return;
			}
			
			SetQuestData(9000200, "1");
			ChangeMap(209000000, "st00");
		}
		else if (MapID == 220000400)
		{
			bool askEnter = AskYesNo("Have you heard of a Christmas town all covered in snow that's not very far from #m220000000#? It's a beautiful and peaceful place, all covered in snow. Want to come along? Hmm... Hmmm... I can't take you there just like that... Ah, yes! Collect #b10 #t4000095#s, 10 #t4000106#s and 1000 mesos#k, and I will take you there. What do you think? Do you want to go there?");
			
			if (!askEnter)
			{
				self.say("You must not have time, huh? If you have time later, stop by again. A town all covered in snow... Doesn't your heart just race thinking about it?");
				return;
			}
			
			if (!Exchange(-1000, 4000095, -10, 4000106, -10))
			{
				self.say("Are you sure you have #b10 #t4000095#s and 10 #t4000106#s and 1000 mesos#k? I can't let you come along without those two and some money~");
				return;
			}
			
			SetQuestData(9000200, "2");
			ChangeMap(209000000, "st00");
		}
	}
}