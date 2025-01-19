using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1002301);
		string quest2 = GetQuestData(1002303);
		string quest3 = GetQuestData(1002304);
		string RolyPolyCount = GetQuestData(1200);
		
		if (quest == "")
		{
			self.say("I used to work at the Toy Factory inside the Ludibrium Clocktower, but I've been sent here to fix the destroyed parts of Eos Tower. The number of monsters have steadily increased, though, making this job very difficult for myself and other Roly-Poly's.");
		}
		else if (quest == "e")
		{
			if (Level < 31)
			{
				self.say("You're the one that took my picture the other day. Have you met up with all 10 of us Roly Poly's? And you gave those pictures to #b#p2040015##k, right? I think our manager will be relieved after seeing those pictures and concentrate on his work.");
				return;
			}
			
			if (quest2 == "")
			{
				self.say("How's the Toy Factory operating these days? It concerns me a great deal that the majority of the workforce is here fixing up the tower as opposed to working at the factory. I really wish I could take care of both the work at the factory and the work here.");
				self.say("That's why... I'd like to ask you for a favor. Not far from where we are, at the 60th floor, you'll run into a whole bunch of \r\n#b#o3230400#s#k. They used to be just cute and cuddly, but lately, they are mad and ready to fight these days.");
				bool start = AskYesNo("I don't know what makes them want to stop us from fixing up this tower, but it has reached the point where I can't just sit back and look at them destroy the place. That's why... I'd like to ask you to \"take care of\" some of the #b#o3230400#s#k. Can you do that for me?");
				
				if (!start)
				{
					self.say("I see... I thought I could count on you to take care of them. Maybe it's too overwhelming for you to kill those cute little monsters. Maybe it's just too much to ask. In any case, if you decide to change your mind, please come talk to me.");
					return;
				}
				
				SetQuestData(1002303, "s");
				self.say("It pains me to kill these previously-adorable creatures, but it has to be done. Please take care of them and bring back \r\n#b100 #t4000127#s#k as evidence. If you do this well, I may ask you for more help down the road.");
				self.say("Oh, and ... #b#p2050008##k of the Omega Sector may know a thing or two about #b#o3230400##k causing commotion here. I suggest you pay a visit to the General before killing them. Good luck~!");
			}
			else if (quest2 == "s")
			{
				if (ItemCount(4000127) < 100)
				{
					self.say("The previously-adorable #b#o3230400#s#k have turned into a bunch of enraged monsters interfering with out fixing of the tower. Collect #b100 #t4000127#s#k for me, and I may ask you for more help down the road. Oh, and I suggest you go see #b#p2050008##k of the Omega Sector.");
					return;
				}
				
				self.say("Thanks to your help defeating the #o3230400#s, the fixing of the tower has gotten much easier now. You're much stronger than I thought. Anyway, with great work comes great reward. This may not be much, but please take it. I know it'll help you in some way shape or form.");
				
				if (!Exchange(12000, 4000127, -100))
				{
					self.say("Huh, are you sure you brought the #b100 #t4000127#s#k?");
					return;
				}
				
				AddEXP(3000);
				SetQuestData(1002303, "e");
				QuestEndEffect();
				self.say("Did you receive #b12,000 mesos#k? Anyway, I seriously hope that those guys return to their original, adorable state. I feel like I can ask for your help once more after the great job you did on this. Please come see me again down the road, and in the mean time, watch out for those monsters ~");
			}
			else if (quest2 == "e")
			{
				if (quest3 == "")
				{
					self.say("Hi there. You're back again. Thanks to your help, the fixing of the tower has been going smoothly. Hmm... I'm sure you may have heard it from #b#p2050008##k, but in order to set the raging #b#o3230400##k back to their normal state, then we need to take away their power.");
					bool start2 = AskYesNo("The best way to do that will be to... take away their Black Crystals after defeating them, like last time. What do you think? Will you help me out once more, this time for the sake of #b#o3230400##k?");
					
					if (!start2)
					{
						self.say("I see. I thought I could count on you for something as big as this, but I guess it may be too difficult a task. Or is it that they look too adorable for you to ruthlessly eliminate them? Well, either way, if you change your mind, please talk to me.");
						return;
					}
					
					SetQuestData(1002304, "s");
					self.say("Sigh... they used to be the most adorable thing in Ludibrium, but now... they are in rage, and going absolutely wild with it. I don't know how they god a hold of the force of darkness, but it's imperative that we turn them back to their original state...");
					self.say("Please eliminate #b#o3230400##k, and bring back\r\n#b1000 #t4000127#s#k as evidence. This time, it's for the sake of #o3230400#, so I hope you put your heart into this. I'll be here waiting...");
				}
				else if (quest3 == "s")
				{
					if (ItemCount(4000127) < 1000)
					{
						self.say("We need to take away their power in order to set #b#o3230400##k back to their original, adorable state. Please eliminate #b#o3230400##k and bring me #b1000 #t4000127#s#k as evidence. I prefer that you get this done with quickly. Good luck!");
						return;
					}
					
					self.say("While you were busy killing #o3230400#, I heard of the news that some have turned back into their original state. They're still suffering from the aftereffects of this and therefore needs to be sedated at a secluded place, but you can rest assured they are now in good hands. Oh, and \r\nhere... please take this.");
					
					int itemID = 0;
					
					if (Job >= 100 && Job < 200) itemID = 1002048;
					else if (Job >= 200 && Job < 300) itemID = 1002144;
					else if (Job >= 300 && Job < 400) itemID = 1002137;
					else if (Job >= 400 && Job < 500) itemID = 1002178;
					else itemID = 1002096;
					
					if (!Exchange(12000, 4000127, -200, 4000127, -200, 4000127, -200, 4000127, -200, 4000127, -200, itemID, 1))
					{
						self.say("Please leave some room in your equip. inventory first!");
						return;
					}
					
					AddEXP(4500);
					SetQuestData(1002304, "e");
					QuestEndEffect();
					self.say($"Did you get the #t{itemID}#? The ones that turned back wanted me to give this to you. You helped us fix the tower, and you also helped #o3230400# turn back to their original state... thank you so much for your help. Good bye...");
				}
				else if (quest3 == "e")
				{
					self.say("You helped us fix the tower, and you also helped #o3230400# turn back to their original state... thank you so much for your help.");
				}
			}
		}
		else
		{
			if (quest == "4")
			{
				if (ItemCount(4031078) < 1)
				{
					self.say("Man, so much work. Whoa. Are you here at #b#p2040015##k's request? It looks like you've lost the camera, though. Please go back to Manager Karl and talk to him about the camera.");
					return;
				}
				
				if (ItemCount(4031082) < 1)
				{
					self.say("Oh no, you must have lost the pictures you took with the previous worker. Oh well ... please go revisit the first Roly-Poly worker now. I'm sure you can take another picture with him. I have to get back to work! Sorry!");
					
					SetQuestData(1002301, "s");
					return;
				}
				
				if (RolyPolyCount == "4")
				{
					self.say("Wow, I'm just overwhelmed with all the work I have here. Lately there has been an increase in the number of monsters around Eos Tower, which means lots of places are getting destroyed right now. What's that? You're here at #b#p2040015##k's request? I see ... so you need to take a picture of me. Alright~ take a good picture of me working hard around here!");
					
					if (!Exchange(0, 4031082, -1, 4031083, 1))
					{
						self.say("Please leave a slot open in the etc. tab first.");
						return;
					}
					
					AddEXP(750);
					SetQuestData(1200, "5");
				}
				else
				{
					self.say("Oh no ... did you lose the picture you took with me? We'll have to take another one, then. Please make sure not to lose the picture this time around. Alright, here's a million-dollar pose of me working hard.");
					
					if (!Exchange(0, 4031082, -1, 4031083, 1))
					{
						self.say("Please leave a slot open in the etc. tab first.");
						return;
					}
				}
				
				SetQuestData(1002301, "5");
			}
			else if (quest == "s" || quest == "1" || quest == "2" || quest == "3")
			{
				self.say("Hello there. As you can see, I am working hard here at Eos Tower, fixing up spots here and there. You're here at the request of #b#p2040015##k? Hmmm ... if so, then you may want to visit the first Roly-Poly worker FIRST. He must be working somewhere around this tower.");
			}
			else
			{
				self.say("Oh, hello there. You're the one who's taking pictures of the 10 of us Roly-Poly workers, right? You should go check out some other Roly-Poly worker now. I'm sure that person's working hard somewhere around Eos Tower.");
			}
		}
	}
}