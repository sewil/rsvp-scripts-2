using WvsBeta.Game;

// 2050011 Kevin the Soldier
public class NpcScript : IScriptV2
{
	private void AlarmClock()
	{
		string quest = GetQuestData(1003302);
		
		if (quest == "s")
		{
			self.say("Ahh... I've been waiting for you, actually. #b#p2041012##k must be quite busy these days. The clock was about to be completed anyway. Please hand this to #p2041012#. Once it starts ringing in the morning, there is no way she'll be able to sleep through it. Thanks~");
			
			if (!Exchange(0, 4031108, 1))
			{
				self.say("Please make some room in your etc. inventory for the #b#t4031108##k.");
				return;
			}
			
			AddEXP(500);
			SetQuestData(1003302, "1");
		}
		else if (quest == "1")
		{
			if (ItemCount(4031108) >= 1)
			{
				self.say("Please get this #b#t4031108##k to #b#p2041012##k. The moment it starts ringing, there is no way anyone is going to sleep through it! Good luck!~!");
				return;
			}
			
			self.say("Hmmm... did you lose the #b#t4031108##k that I left there? Don't worry too much about it. It has the automatic-returning device attached to it, and therefore, it's back here with me. I'll give it to you again, but please don't lose it this time.");
			
			if (!Exchange(0, 4031108, 1))
			{
				self.say("Please make some room in your etc. inventory for the #b#t4031108##k.");
			}
		}
	}
	
	private void VIPTicket()
	{
		string quest = GetQuestData(1006500);
		
		if (quest == "")
		{
			self.say("I envy you. I envy you, because you can run away and travel around freely. I can't find Medin right now, so please be my talking buddy for a sec.");
			self.say("You know, I entered the army to fight the aliens, but here I am, currently just protecting the HQ, and it's really affecting my patience. I would more than love to use a day off to travel, but you, you haven't really accomplished EVERYTHING.");
			self.say("A while ago, while driving around the neighborhood, I picked up a ripped travel ticket. Looking at that ticket really makes me want to leave this place for a second. How are your parents doing?");
			bool start = AskYesNo("There is a way to leave here for the vacation, but I really cannot do this by myself. I've asked other travelers for help, to no avail. If you have time to burn, will you help me out?");
			
			if (!start)
			{
				self.say("Hmmm... that's why. Even the travelers seem to be doing more than just wander around these days. Everyone's so busy around here... if you ever pass by this place again, please be my chat buddy again.");
				return;
			}
			
			SetQuestData(1006500, "s1");
			self.say("To leave for vacation, I'll need to be cleared by Jr. Officer Medin, but he doesn't check off the vacations unless I have some track record in working. That's why... can you do me a favor and take out some Matians around the area?");
			self.say("It'll be doubly appreciated if you can gather up a big bag of Matian's Tentacles. #b30 pieces of Matian's Tentacles#k, alright? With those, I may actually earn enough brownie points to take a vacation!");
			self.say("Oh, and lately, I heard that Matian has been holding something that it picked up around the Sector, so please find out what that thing is for me.");
		}
		else if (quest == "s1")
		{
			if (ItemCount(4000120) < 30 || ItemCount(4031206) < 1)
			{
				self.say("Hmmm ... this may not be enough to report to the Jr. Officer. Since you promised to help, anyway, I'd appreciate it if you put more effort to what I asked you do.");
				return;
			}
			
			self.say("You really gathered up the tentacles for me! I actually thought you just left without any word. Thank you so much, my friend! Now I can finally enjoy a little bit of vacation!!");
			self.say("Hey, that Ripped Travel Ticket looks like the other half of the ticket that I've been carrying around!! Can I see? Let's match the two up, and ... oh my gosh, this is going to be awesome.");
			self.say("I'm sorry. I'm a soldier, so I can't really reward you in materialistic ways, but... I can give you the other half of the ticket. Put the two together, and you'll find yourself an awesome VIP pass! The back of the card says Nana the Tour Guide, so find her!");
			
			if (!Exchange(0, 4000120, -30, 4031207, 1))
			{
				self.say("Make sure you can hold an item in your etc. inventory first.");
				return;
			}
			
			AddEXP(4000);
			SetQuestData(1006500, "s2");
			self.say("I can't even fully use the vacation, because I only have a few days off. Here, take it! I got to go get my vacation break accepted. Good luck!");
		}
		else
		{
			if (ItemCount(4031206) >= 1 && ItemCount(4031207) >= 1)
			{
				self.say("Put the two together, and you'll find yourself an awesome VIP pass! The back of the card says Nana the Tour Guide, so find her!");
				return;
			}
			
			self.say("I've been waiting for you here. You left your ripped travel ticket on the ground after you left here.");
			
			if (ItemCount(4031206) < 1)
			{
				if (!Exchange(0, 4031206, 1))
				{
					self.say("Make sure you have an empty space in your etc. inventory first.");
					return;
				}
			}
			if (ItemCount(4031207) < 1)
			{
				if (!Exchange(0, 4031207, 1))
				{
					self.say("Make sure you have an empty space in your etc. inventory first.");
					return;
				}
			}
		}
	}
	
	private bool Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1003302)
		{
			if (info == "s" || info == "1")
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (quest == 1006500)
		{
			if (Level >= 30 && info != "e")
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
		bool checkAlarm = Check(1003302);
		bool checkTicket = Check(1006500);
		
		if (checkAlarm && checkTicket)
		{
			AskMenuCallback("Sigh. I wish I could go outside and defeat the aliens myself, but the only work I am getting is restricted to here at the headquarters. I am confident that I can do a good job too. When can I go out and combat them...?#b",
				(" Delivering the Alarm Clock", AlarmClock),
				(" VIP Ticket to Florina Beach", VIPTicket));
		}
		else if (checkAlarm && !checkTicket)
		{
			AlarmClock();
		}
		else if (!checkAlarm && checkTicket)
		{
			VIPTicket();
		}
		else
		{
			self.say("Sigh. I wish I could go outside and defeat the aliens myself, but the only work I am getting is restricted to here at the headquarters. I am confident that I can do a good job too. When can I go out and combat them...?");
		}
	}
}