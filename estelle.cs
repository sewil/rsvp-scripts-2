using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Sauce()
	{
		string quest = GetQuestData(1004801);
		
		if (quest == "m1")
		{
			bool start = AskYesNo("How may I help you? Ahh ... my patented special sauce huh? You need that for the big feast for the Carnival? Hmmm ... my mom gave me this, so I don't know if I should give this to a stranger like you, unless you can do me a favor ...");
			
			if (!start)
			{
				self.say("It's not that difficult a favor, not something you'd say no to without even hearing about it one bit. If you really need my special sauce, then please come talk to me. I'll see you around.");
				return;
			}
			
			SetQuestData(1004801, "m2");
			self.say("The 'favor' is pretty simple actually. My mom's birthday is coming up in a few days. I'd love to get her a pretty #t4021000# necklace, but I'm seriously lacking #t4021000#. Can you get me 1 #b#t4021000##k?");
		}
		else if (quest == "m2")
		{
			if (ItemCount(4021000) < 1)
			{
				self.say("I'd love to get my mom a pretty #t4021000# necklace for her birthday that's coming up in a few days. Can you get me 1 \r\n#b#t4021000##k in exchange for the special sauce?");
				return;
			}
			
			self.say("Wow... This is one fine #b#t4021000##k. I can make a really good necklace with this for my mom~ thank you so much. Here. Take this special sauce and wish you happy luck.");
			
			if (!Exchange(0, 4021000, -1, 4031154, 1))
			{
				self.say("Please make sure there's room in your etc. inventory first.");
				return;
			}
			
			AddEXP(1000);
			SetQuestData(1004801, "m3");
		}
		else if (quest == "m3")
		{
			if (ItemCount(4031154) >= 1)
			{
				self.say("Please bring this sauce to #b#p1012106##k in Henessys. She must really need this. I better get going to make a necklace with this #t4021000#.");
				return;
			}
			
			self.say("Wow... This is one fine #b#t4021000##k. I can make a really good necklace with this for my mom~ thank you so much. Here. Take this special sauce and wish you happy luck.");
			
			if (!Exchange(0, 4031154, 1))
			{
				self.say("Please make sure there's room in your etc. inventory first.");
				return;
			}
		}
	}
	
	private void Syrup()
	{
		string quest = GetQuestData(1005902);
		
		if (quest == "")
		{
			self.say("You're looking #b#t4031201##k? So you're here at the request of Elma? \n How did I know? I made that syrup JUST FOR HER before.");
			bool start = AskYesNo("Alright, I'll make it again~ You'll just have to gather up the ingredients again.");
			
			if (!start)
			{
				self.say("Well, all the necessary ingredients are here, but if you don't want to make it, then ... oh well ...");
				return;
			}
			
			SetQuestData(1005902, "s");
			self.say("I'll need #b60 #t4000029#s, 30 #t2012002#s, and 10 #t4000017#s#k. As soon as you gather them all up and give them to me, the drink will be made right there on the spot~");
		}
		else if (quest == "s")
		{
			if (ItemCount(4000029) < 60 || ItemCount(4000017) < 10 || ItemCount(2012002) < 30)
			{
				self.say("I don't think you have brought all the ingredients yet. I need them all in order to make #t4031201#.");
				return;
			}
			
			self.say("You brought all the ingredients for the juice! Great job! Now hold on one second, and this juice will be made in no time.");
			
			if (!Exchange(0, 4000029, -60, 2012002, -30, 4000017, -10, 4031201, 1))
			{
				self.say("Are you certain you brought all the ingredients? Please make sure there's also one free space in your etc. inventory.");
				return;
			}
			
			AddEXP(7000);
			SetQuestData(1005902, "1");
			self.say("Here you go~ Elma must be trying to make another masterpiece with her cooking prowess... my gosh, now I'm getting hungry.");
		}
		else if (quest == "1")
		{
			if (ItemCount(4031201) >= 1)
			{
				self.say("Elma must be trying to make another masterpiece with her cooking prowess... my gosh, now I'm getting hungry.");
				return;
			}
			
			self.say("Here you go~ Elma must be trying to make another masterpiece with her cooking prowess... my gosh, now I'm getting hungry.");
			
			if (!Exchange(0, 4031201, 1))
			{
				self.say("Please make sure there's one free space in your etc. inventory.");
			}
		}
	}
	
	private bool Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 1004801)
		{
			if (info == "m1" || info == "m2" || info == "m3")
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (quest == 1005900)
		{
			if (info == "4")
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
		bool checkSauce = Check(1004801);
		bool checkSyrup = Check(1005900);
		
		string questSauce = GetQuestData(1004801);
		
		if (checkSauce && checkSyrup)
		{
			AskMenuCallback("I'm Estelle, and I love to cook!#b",
				(" Estelle's Special Sauce", Sauce),
				(" Estelle and the Syrup", Syrup));
		}
		else if (checkSauce && !checkSyrup)
		{
			Sauce();
		}
		else if (!checkSauce && checkSyrup)
		{
			Syrup();
		}
		else
		{
			if (questSauce == "e")
			{
				self.say("Did you like the sauce I made the other day? Did it help you with your cooking?");
			}
			else
			{
				self.say("I'm Estelle, and I love to cook!");
			}
		}
	}
}