using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Sauna()
	{
		string questMilk = GetQuestData(1000);
		string questUnagi = GetQuestData(1001);
		
		if (questUnagi == "")
		{
			self.say("So you came here through a favor by #p1061004#? Hahaha ... hopefully #p1061004# is not in any trouble this time around. Anyway, he wants the #bUnagi special#k, huh? It's pretty easy, so why don't you just sit around and wait for a little bit as I make this dish...");
			self.say("Oh shoot. I'm lacking #b#t4000013##k and #b#t4000017##k, the most important ingredients for Unagi. Do these really go in the dish? oh of course~~just please make this a secret from #p1061004#, ok?");
			self.say("Anyway I don't have enough ingredients for Unagi. Sorry but can you gather up the ingredients for me? #b50 #t4000013#s and 5 #t4000017#s#k and then the #bUnagi Special#k will be made.");
			
			SetQuestData(1001, "1");
			if (questMilk != "") SetQuestData(1000600, "3");
		}
		else if (questUnagi == "1")
		{
			if (ItemCount(4000013) < 50 || ItemCount(4000017) < 5)
			{
				self.say("Please get me #b50 #b#t4000013#s and #b5 #t4000017#s#k. Then I'll get you #p1061004#'s favorite, the Unagi Special.");
				return;
			}
			
			self.say("You got all the ingredients!! I knew you'd be the one to do it... alright, now just wait oooone second. I, Rina, proudly present the #bUnagi special#k!");
			
			if (!Exchange(0, 4000013, -50, 4000017, -5, 4031014, 1))
			{
				self.say("Please leave some room in your etc. inventory so I can give you the #bUnagi Special#k.");
				return;
			}
			
			AddEXP(500);
			SetQuestData(1001, "end");
			QuestEndEffect();
			self.say("Ok, here it is, the #bUnagi Special#k! You should take this to \r\n#p1061004# before it gets cold. It's #p1061004#'s favorite.");
		}
		else if (questUnagi == "end")
		{
			if (ItemCount(4031014) >= 1)
			{
				self.say("How is #p1061004# doing? Did you get him the #bUnagi Special#k?");
				return;
			}
			
			self.say("Ok, here it is, the #bUnagi Special#k! You should take this to \r\n#p1061004# before it gets cold. It's #p1061004#'s favorite.");
			
			if (!Exchange(0, 4031014, 1))
			{
				self.say("Please leave some room in your etc. inventory so I can give you the #bUnagi Special#k");
				return;
			}
		}
	}
	
	private void Pia()
	{
		string quest = GetQuestData(1000301);
		
		if (quest == "s")
		{
			self.say("Hi~ Nice weather~ isn't it? What? You want #b#t4031043##k, which I brought from #p1012102#? Hmm... I should say... \"no\"... because I didn't borrow it from #p1012102#. #p1012102# took my precious thing and never gave it back to me. So I took this cape from her. Therefore, I can't give this cape to you.");
			bool askStart = AskYesNo("Hmm... If you really need this, you should give the thing, which #p1012102# took, to me. Then, I will give #b#t4031043##k to you. Of course, the thing, which #p1012102# took, is very precious~");
			
			if (!askStart)
			{
				self.say("Okay. You don't have to pay the debt, which you didn't borrow. Anyway, please talk to #p1012102# that if she wants to get the cape back, she should pay the things, which she took from me.");
				return;
			}
			
			SetQuestData(1000301, "g");
			self.say("Really? You must be really close to #p1012102#. Anyway, okay. I need #b1 #t4021008#, 1 #t4001005#, 30 #t4000028##k. I spent years to collect all these and #p1012102# just took them all!!! Well... If you give these back to me, I will definitely give #b#t4031043##k to you, in return.");
		}
		else if (quest == "g")
		{
			if (ItemCount(4021008) < 1 || ItemCount(4001005) < 1 || ItemCount(4000028) < 30)
			{
				self.say("You haven't collected #b1 #t4021008#, 1 #t4001005#, 30 \r\n#t4000028# #k. I will give #p1012102#'s #b#t4031043##k back to you.");
				return;
			}
			
			self.say("Wow! You have collected them all...!!! Great! Okay then. I will give #b#t4031043##k as I promised. Hmm... I liked this cape a \r\nlot... Well... promise is a promise... Take it...!");
			
			if (!Exchange(0, 4021008, -1, 4001005, -1, 4000028, -30, 4031043, 1))
			{
				self.say("Are you sure you brought everything? Please make some space in your etc. inventory otherwise...");
				return;
			}
			
			AddEXP(500);
			SetQuestData(1000301, "p");
		}
		else if (quest == "p")
		{
			if (ItemCount(4031043) >= 1)
			{
				self.say("Oh...  You are the one who gave the stuff, which #p1012102# took. How's #p1012102# doing? When you get to #m100000000#, say hello to \r\n#p1012102# for me.");
				return;
			}
			
			self.say("Wow! You have collected them all...!!! Great! Okay then. I will give #b#t4031043##k as I promised. Hmm... I liked this cape a \r\nlot... Well... promise is a promise... Take it...!");
			
			if (!Exchange(0, 4031043, 1))
			{
				self.say("Please make some space in your etc. inventory...");
				return;
			}
		}
	}
	
	private bool Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1000600)
		{
			if (info == "2" || info == "3")
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (quest == 1000301)
		{
			if (info != "" && info != "end")
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
		bool checkSauna = Check(1000600);
		bool checkPia = Check(1000301);
		string questPia = GetQuestData(1000301);
		
		if (checkSauna && checkPia)
		{
			AskMenuCallback("This town is made by the group of bowmen. If you want to become a bowman, please meet with #r#p1012100##k... She will help you. What? You don't know #r#p1012100##k? She saved our town long time ago from the monsters. Of course, it is safe now. She is the hero of our town.#b",
				(" Making the Unagi Special", Sauna),
				(" Pia's Present For a Friend", Pia));
		}
		else if (checkSauna && !checkPia)
		{
			Sauna();
		}
		else if (!checkSauna && checkPia)
		{
			Pia();
		}
		else
		{
			if (questPia == "end")
			{
				self.say("Oh... You are the one who gave the stuff back? So what's up? Is #p1012102# doing fine? If you get to #m100000000# someday, please say hello to #p1012102# for me.");
			}
			else
			{
				self.say("This town is made by the group of bowmen. If you want to become a bowman, please meet with #r#p1012100##k... She will help you. What? You don't know #r#p1012100##k? She saved our town long time ago from the monsters. Of course, it is safe now. She is the hero of our town.");
			}
		}
	}
}