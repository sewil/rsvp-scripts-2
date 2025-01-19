using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(1002800);
		string quest2 = GetQuestData(1002900);
		string quest3 = GetQuestData(1003000);
		string quest4 = GetQuestData(1003001);
		string quest5 = GetQuestData(1003002);
		
		if (quest1 == "")
		{
			self.say("Hmmm... the fuel's fine, the parts are fine ... and, by debugging this critical error of the Alpha system ... huh? Can I help you? I'm busy developing new machines, so unless you need me for something, talk to someone else. I need to get back to work now.");
		}
		else if (quest1 == "s")
		{
			self.say("Hmmm... the fuel's fine, the parts are fine ... and, by debugging this critical error of the Alpha system ... huh? Can I help you? What? You received a letter from a place far far away and brought it all the way here? Is that so? Then let's see...");
			
			if (ItemCount(4031099) < 1)
			{
				self.say("Hmmm... where exactly is the #b#t4031099##k? I think you might have lost it on your way here. I'm sorry, but I'm very busy conducting a new project as we speak, so you'll have to excuse me for this. Oh, and please don't touch any of the machines here at Omega Sector HQ. Now, if you'll excuse me...");
				return;
			}
			
			self.say("Oh ho... I didn't think I'd receive the much-anticipated \r\n#b#t4031099##k from a total stranger like you. So you brought this here all the way from that place? Thank you so much. I'll have to reward you for your work bringing it here. It's not much, but I hope this helps you on your journey.");
			
			if (!Exchange(7500, 4031099, -1))
			{
				self.say("Hmmm ... are you sure you brought the letter with you?");
				return;
			}
			
			SetQuestData(1002800, "e");
			QuestEndEffect();
			self.say("Hmmm ... this is a very interesting material, indeed. A letter from an unknown, living thing from a place far far away... I guess it was aware of my existence from all the way there, but I don't think it knew the exact place I am in. I'll have to study this letter more. Please, make yourself at home.");
		}
		else if (quest1 == "e")
		{
			if (Level < 30)
			{
				self.say("Ohh... the greatest masterpiece of all time, by me! With this blueprint, I can make the most indestructable robot ever!");
				return;
			}
			
			if (quest2 == "")
			{
				bool start = AskYesNo("Hmmm ... done! The #b#t4031100##k, which contains the blueprint of the new robot, is now COMPLETE! Hahaha!! Once the making of the robot is complete, straight out of this blueprint, the aliens outside the sector will be of no factor whatsoever! Yes... hey you! You look like you don't have much to do. Can you do me a favor?");
				
				if (!start)
				{
					self.say("Did you feel irked when I said you look like you don't have much to do? I know a whole bunch of people just like you... hmmm... anyway, if you change your mind, talk to me. I am well aware that you really don't have much to do right now.");
					return;
				}
				
				if (!Exchange(0, 4031100, 1))
				{
					self.say("Please leave an empty slot in your etc. inventory first.");
					return;
				}
				
				SetQuestData(1002900, "s");
				self.say("Thank you! I'll give you this #b#t4031100##k. Your job is to show this to #b#p2050005#, #p2050006#, and #p2050007##k. They should be all over Omega Sector. The first person you'll need to meet is #p2050005#. He should be resting somewhere around the Silo.");
			}
			else if (quest2 == "e")
			{
				if (quest3 == "")
				{
					self.say("Glad you are here... thanks to you, the designing of the new robot is complete, and I've started the process of actually making it. Then I realized, we were missing 3 very important mechanical parts necessary to build the robot. I've already given #b#p2040003##k of Ludibrium the word, so can you please go there and pick up the pieces for me? Thank you!");
					
					SetQuestData(1003000, "s");
				}
				else if (quest3 == "s")
				{
					self.say("I don't think you've met #b#p2040003##k yet. I asked #p2040003# for the parts, so all you need to do is go there and pick them up for me. #b#p2040003##k is located somewhere around the Ludibrium Toy Factory. I'll be waiting for you here.");
				}
				else if (quest3 == "1")
				{
					if (ItemCount(4031095) < 1 || ItemCount(4031096) < 1 || ItemCount(4031097) < 1)
					{
						self.say("Hmmm... I think you have met #b#p2040003##k, but you may have lost one of the boxes full of robotic parts on your way back here. I need 3 Boxes of Parts, and without one, it's nothing. Please go see #p2040003# again at the Ludibrium Toy Factory, receive all 3 boxes full of robotic parts, and then deliver them to me. Thanks!");
						return;
					}
					
					self.say("Ohhh, this is it! These 3 Boxes of Parts are essential in trying to create an important device for the robot. This information is classified, so this is about all I can tell you for now, but... it must have been tough for you to travel from Ludibrium to here. Take this, the #b#t2030012##k.");
					
					if (!Exchange(0, 4031095, -1, 4031096, -1, 4031097, -1, 2030012, 7))
					{
						self.say("Please leave an empty slot in your use inventory first.");
						return;
					}
					
					AddEXP(3200);
					SetQuestData(1003000, "e");
					QuestEndEffect();
					self.say("The #b#t2030012##k I gave you will enable you to teleport straight to Ludibrium. Please be aware that you may not use this on other continents. Thank you so much for helping me out on numerous occasions. Now that I have the parts ready, I better get this started.");
				}
				else if (quest3 == "e")
				{
					if (quest4 == "")
					{
						bool start2 = AskYesNo("Ohhh... good thing you're here. I've been really needing your help, and thank goodness you're here. It's about the Boxes of Parts that you brought here last time... are you willing to listen?");
						
						if (!start2)
						{
							self.say("Hmmm ... you must be busy doing things here and there, but this is a very important task, and we don't have much time. I can't think of anyone else worthy of taking on this task but you! Please, if you ever change your mind, talk to me, okay?");
							return;
						}
						
						SetQuestData(1003001, "s");
						self.say("Thank you for making some time with me. I have heard that someone's been looking for the boxes, but I didn't think much of it, until one day, the Boxes of Parts disappeared totally. The Boxes of Parts have been stolen, and I think it's the work of the aliens. Maybe they were just worried about the possibility of our new robot controlling their livelihood.");
						self.say("The one good thing is that, thanks to the automatic-returning device I attached to all the boxes, even the most intricate of the responses will generate a signal that'll enable us to locate where the boxes are located at. They may have broken the device, but I don't think they completely destroyed it. The Boxes of Parts are hidden at the Roswell Plain. Go there, and you may find a box that looks like that of the aliens. Your task is to destroy that box and bring back the Box of Parts.");
					}
					else if (quest4 == "s")
					{
						if (ItemCount(4031095) < 1 || ItemCount(4031096) < 1 || ItemCount(4031097) < 1)
						{
							self.say("Hmmm... I don't think you have all 3 Boxes, yet. Head over to a secretive place around Roswell Plain, all the way to the alien headquarters, and you'll find a huge box that appears to be that of the aliens'. Your task is to break those Boxes, and find the 3 Boxes of Parts for me. I'll be here waiting for you!");
							return;
						}
						
						self.say("Hoh... you brought all 3 Boxes of Parts! I'm sure the... aliens made your way back a little more difficult that it should have been... you really must be something special. How about joining us and working here full-time as a member of the Omega Sector? Hahaha... anyway, great job there. Since you worked so hard to make it here, I'll give you some more spare Warp Capsules. Please take this.");
						
						if (!Exchange(0, 4031095, -1, 4031096, -1, 4031097, -1, 2030011, 3, 2030012, 3))
						{
							self.say("Hmm... please make sure there are two free slots in your use inventory first!");
							return;
						}
						
						AddEXP(4200);
						SetQuestData(1003001, "e");
						QuestEndEffect();
						self.say("Now that all the parts are here, I'll have to get back to work. Oh, before I do that... I better make sure to attach these Boxes of Parts with the newest automatic-returning device! It would be terrible to have these stolen by the aliens, again. Now, if you'll excuse me, I have a lot of work to do... I'll see you around~");
					}
					else if (quest4 == "e")
					{
						if (Level < 40)
						{
							self.say("Now that all the parts are here, I'll have to get back to work. Oh, before I do that... I better make sure to attach these Boxes of Parts with the newest automatic-returning device! It would be terrible to have these stolen by the aliens, again. Now, if you'll excuse me, I have a lot of work to do... I'll see you around~");
							return;
						}
						
						if (quest5 == "")
						{
							bool start3 = AskYesNo("Hmmm... we have ourselves an emergency. We received a word that a group of imposing, threatening aliens are on their way here. The problem is, the new robot is still on its developmental stage... arrght, this is driving me crazy! You... if  that's fine with you, will you please help us out? We need your word right now.");
							
							if (!start3)
							{
								self.say("Really...! I thought you'd be there to help us out. This is quite disappointing. I'll have to find someone else eager to join forces with us. Now, if you'll excuse me...");
								return;
							}
							
							SetQuestData(1003002, "005");
							self.say("Thank you so much! The word is, there's a group of Matian aliens on their way here, and one of the most powerful Matians around, #b#o5120100##k, is already undercover, waiting around the Roswell Plain. #b#o5120100##k is definitely unlike anyone else you've ever faced, and even our army is having a difficult time handling it. I guess it's too powerful a monster for even a disciplined army like ours.");
							self.say("What I'm asking from you is simple. Please go and defeat 5 #b#o5120100#s#k, which is operated by the aliens. #b#o5120100##k is the culmination of advanced technology from the aliens, so they are much more devastating than anything you've ever run into. I strongly suggest that you take them on with a party, not just by yourself. I'll be waiting for you here. Good luck!");
						}
						else if (quest5 == "e")
						{
							self.say("I can't even begin to thank you for all your hard work done for the Omega Sector and myself. I am sincerely thankful to have run into someone like you in times of need. Now, it's my job to fully develop the new robot so I don't put all your work in vain. Please drop by to say hello every now and then, alright? Bye!!");
						}
						else
						{
							if (quest5 != "000")
							{
								self.say("I don't think you have completed my task, yet. Head over to the hidden area of Roswell Plain defeat #b5 #o5120100#s#k for us.");
								return;
							}
							
							self.say("Oh my goodness... did you really find a way to defeat #b5 \r\n#o5120100#s#k? I knew you were something else, but this just blows my mind!! Alright... since you helped us protect the Omega Sector as well as Ludibrium, I'll have to reward you accordingly. This will definitely help you on your journey, so please take it.");
							
							if (!Exchange(0, 1032011, 1))
							{
								self.say("Hmm... please make some room in your equip. inventory first.");
								return;
							}
							
							AddEXP(6000);
							SetQuestData(1003002, "e");
							QuestEndEffect();
							self.say("What do you think about #b#t1032011##k? I can't even begin to thank you for all your hard work done for the Omega Sector and myself. I am sincerely thankful to have run into someone like you in times of need. Now, it's my job to fully develop the new robot so I don't put all your work in vain. Please drop by to say hello every now and then, alright? Bye!!");
						}
					}
				}
			}
			else
			{
				if (ItemCount(4031100) < 1)
				{
					self.say("Oh no... did you lose the #b#t4031100##k that I gave you, by any chance? You should have been more careful!! What would have happened if an alien gets a hand on this? Hmmm... good thing I put an automatic-returning device on #b#t4031100##k, in case something like this happened. I'll give you this one more time, so please show it to #b#p2050005#, \r\n#p2050006#, #p2050007##k");
				
					if (!Exchange(0, 4031100, 1))
					{
						self.say("Please leave an empty slot in your etc. inventory first.");
					}
					
					return;
				}
				
				if (quest2 != "3")
				{
					self.say("Please take this #b#t4031100##k to #b#p2050005#, #p2050006#, and \r\n#p2050007##k, who should be spread out all over Omega Sector, and show them what's inside. I want to give them the good news ASAP. The first person you'll need to see is #p2050005#. He should be around the Silo taking a rest.");
				}
				else
				{
					self.say("Oh ho... you must have met #b#p2050005#, #p2050006#, and #p2050007##k and showed them #b#t4031100##k. How did they react to it? Were they happy to see it? Hahaha... that was good to know. Now, since you helped us out a great deal, here's a small reward for your job well done. I know it isn't much, but please take it.");
				
					if (!Exchange(12000, 4031100, -1))
					{
						self.say("Hmm... are you sure you brought the blueprints back with you?");
						return;
					}
					
					AddFame(2);
					AddEXP(4500);
					SetQuestData(1002900, "e");
					QuestEndEffect();
					self.say("Did you get the #b12,000 Mesos#k? I also raised your fame level a little bit. It's only fair that your reputation improves after the great job you did. I may need your help again down the road, so please drop by from time to time again.");
				}
			}
		}
	}
}