using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void GoFlorina()
	{
		int start = AskMenu("Ever heard of a beach with a wonderful view of the ocean, called #b#m110000000##k, located near #m104000000#? I can take you there right away for only #b1,500 mesos#k. If you happen to have a #bVIP Ticket#k, I can take you there free of charge.#b",
			(0, " I'll pay 1,500 mesos."),
			(1, " I have a VIP Ticket."),
			(2, " What's a VIP ticket?"));
			
		if (start == 0)
		{
			bool travel = AskYesNo("You want to pay the #b1,500 mesos#k and depart to Florina Beach? Alright! Know that the monsters you run into there are pretty tough, make sure you're prepared. Alright, ready to go to Florina Beach?");
		
			if (!travel)
			{
				self.say("You must have some business to take care of here. All that traveling and hunting can get pretty tiring. Go rest for a while, and if you change your mind, come back and talk to me.");
				return;
			}
			
			if (!Exchange(-1500))
			{
				self.say("I don't think you have enough mesos. Don't worry, there are plenty of ways to make money around here, you know... Selling your armor... Defeating monsters... Completing quests... You know what I'm talking about.");
				return;
			}
			
			if (MapID == 104000000) SetQuestData(9000005, "0");
			if (MapID == 200000000) SetQuestData(9000005, "1");
			if (MapID == 220000000) SetQuestData(9000005, "2");
			
			ChangeMap(110000000, "st00");
		}
		else if (start == 1)
		{
			bool travel = AskYesNo("So you have a #bVIP Ticket#k? You can always go to Florina Beach with one of these. Know that the monsters you run into there are pretty tough, make sure you're prepared. Alright, ready to go?");
			
			if (!travel)
			{
				self.say("You must have some business to take care of here. All that traveling and hunting can get pretty tiring. Go rest for a while, and if you change your mind, come back and talk to me.");
				return;
			}
			
			if (ItemCount(4031134) < 1)
			{
				self.say("Hmm, are you sure you have a #bVIP Ticket#k on you? Check to make sure first and talk to me again!");
				return;
			}
			
			if (MapID == 104000000) SetQuestData(9000005, "0");
			if (MapID == 200000000) SetQuestData(9000005, "1");
			if (MapID == 220000000) SetQuestData(9000005, "2");
			
			ChangeMap(110000000, "st00");
		}
		else if (start == 2)
		{
			self.say("Curious about the #bVIP Ticket#k? Haha, that's understandable. If you have one, all of your trips to and from Florina Beach will be free. It's such a rare item that even I had to go out and buy one... unfortunately, I lost mine a few weeks ago during my vacation.");
			self.say("I came back without it and I feel horrible for losing it. I hope someone found it and put it in a safe place. Well, this is my story and - who knows - maybe you'll find it and make good use of it. If you have any other questions, just let me know.");
		}
	}
	
	private void Shuri()
	{
		string quest = GetQuestData(1006500);
		
		if (quest == "s3")
		{
			self.say("I heard about it through Nana of Ludibrium. You have the ripped VIP ticket with you? I've heard stories about how rough the area around Omega Sector is, but wow... I can't believe someone would actually rip the ticket just because that person cannot use the ticket..");
			bool start2 = AskYesNo("The VIP ticket cannot be re-issued because it's a special ticket, but there's a way to fix up the ticket. I'll need some materials to work with in order to do so, and if you get those materials for me, I'll try to put it back in one piece.");
			
			if (!start2)
			{
				self.say("That's too bad. That ripped VIP ticket is issued to be a life-time free pass. If you ever feel the desire to head to the beach for vacation, then please come talk to me. Without the VIP pass, you'll have to pay Mesos each time you make the trip there. Hope you have a good time at Orbis!");
				return;
			}
			
			AddEXP(500);
			SetQuestData(1006500, "s4");
			self.say("In order to apply spells to this ticket, I'll need the following materials: #b50 Star Pixie's Starpieces#k and #b30 Lunar Pixie Moonpieces#k, both of which can be found at a park around Orbis, and #b3 diamonds#k. These materials all contain pure clean force of Orbis.");
		}
		else if (quest == "s4")
		{
			if (ItemCount(4031206) < 1 || ItemCount(4031207) < 1 || ItemCount(4021007) < 3 || ItemCount(4000059) < 50 || ItemCount(4000060) < 30)
			{
				self.say("I don't think you have enough materials here. The light is not emitting. It seems like the magical power is still lacking, and I think it has to do with the fact that something is missing. Please check once more. If you lost the ripped VIP ticket, then try going back to those places you've been to. Who knows, someone may actually have been keeping it for you.");
				return;
			}
			
			self.say("Wow, you gathered up all the materials. It's emitting a beautiful light, which tells me the materials are laden with magical powers. If you hand me the materials, I'll restore the ticket for you so you won't ever have to go through this ordeal again.");
			
			if (!Exchange(0, 4000059, -50, 4000060, -30, 4021007, -3, 4031206, -1, 4031207, -1, 4031134, 1))
			{
				self.say("Are you sure you have all the materials here? If so, please make sure there's an empty slot in your etc. inventory.");
				return;
			}
			
			AddEXP(4500);
			SetQuestData(1006500, "e");
			QuestEndEffect();
			self.say("Here, take it. This is the ticket at its original state. As long as you have this VIP ticket with you, you may enter Florina Beach, free of charge!! Whenever you find yourself craving for the beach, find Pason, Nana the Tour Guide or myself. Please take care of the ticket so you won't lose it like Nana.");
		}
	}
	
	private void Nana()
	{
		string quest = GetQuestData(1006500);
		
		if (quest == "s2")
		{
			if (ItemCount(4031206) < 1 || ItemCount(4031207) < 1)
			{
				self.say("Hi, I'm Nana the Tour Guide. Did you have something you wanted to show me?");
				return;
			}
			
			self.say("So you have my lost VIP pass? Oh no... someone ripped it out. I can't use it as the VIP pass when it's ripped like this!!");
			bool start = AskYesNo("This VIP pass is no ordinary ticket; it allows the possessor to freely teleport back and forth from continents to Florina Beach. It's a very special item, so it cannot be reissued... Maybe the other Tour Guide, Shuri, has a clue on what to do with the ticket. Do you want to go see her right now?");
			
			if (!start)
			{
				self.say("Oh, that's unfortunate. The ripped travel ticket really has some value to it, enough to make it a keeper. If you ever find yourself intrigued by this ticket, then talk to me.");
				return;
			}
			
			SetQuestData(1006500, "s3");
			self.say("Shuri the Tour Guide is currently on duty guiding people on traveling around Orbis. The skies at Ludibrium look beautiful, but I'd much prefer working under the splendid skies, and weather, of Orbis.");
		}
		else if (quest == "s3")
		{
			self.say("Did you go to Orbis? You still have the ticket ripped in \r\npieces...");
		}
	}
	
	public override void Run()
	{
		string quest = GetQuestData(1006500);
		
		if (MapID == 200000000 && (quest == "s3" || quest == "s4"))
		{
			AskMenuCallback("Don't you want to head off to Florina Beach?#b",
				(" VIP Ticket to Florina Beach", Shuri),
				(" Trip to Florina Beach", GoFlorina));
		}
		else if (MapID == 220000000 && (quest == "s2" || quest == "s3"))
		{
			AskMenuCallback("Don't you want to head off to Florina Beach?#b",
				(" VIP Ticket to Florina Beach", Nana),
				(" Trip to Florina Beach", GoFlorina));
		}
		else
		{
			GoFlorina();
		}
	}
}