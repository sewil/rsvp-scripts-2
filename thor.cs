using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (!eventActive("christmas2022") && !eventDone("christmas2022"))
		{
			self.say("Oh~~ It looks like Christmas is over... Come back again next year!");
			return;
		}
		
		if (eventDone("christmas2022"))
		{
			self.say("Hey! What are you doing here?? Christmas will be starting soon so be patient!!");
			return;
		}
		
		if (Level < 8)
		{
			self.say("Oh no... I lost my precious horn!!!! Ahhh, it doesn't look like you're strong enough to help me. Please train a little more and look for me again, alright?");
			return;
		}
		
		string quest = GetQuestData(9000201);
		string lastDate = GetQuestData(9000202);
		string today = DateTime.UtcNow.ToString("yyyyMMdd");
		
		if (lastDate == today)
		{
			self.say("Hey, it's you! You found the horn for me, didn't you? You can only participate in the event once per day~ Please come back again tomorrow.");
			return;
		}
		
		if (quest == "s")
		{
			if (ItemCount(4031063) < 1)
			{
				self.say("Did you find it? I know it's in a shop #bsomewhere in Happyville#k. Hmmm ... I have no idea where that shop is, you know. Please look around, and you may find my horn.");
				return;
			}
			if (SlotCount(1) < 1 || SlotCount(2) < 1 || SlotCount(3) < 1)
			{
				self.say("You should have at least one slot empty in your Equip., Use or Set-up tab. Please check and come back~");
				return;
			}
			
			self.say("Ahh cool~ That's my horn! Thanks a lot! Here's a little something for the job well done. It'll be very useful for you. Bye~");
			
			Random rnd = new Random();
			
			int reward = rnd.Next(0, 15);
			bool trade = false;
			
			if (reward == 0) trade = ExchangeEx(0, "4031063", -1, "1012011,Period:21600", 1);
			else if (reward == 1) trade = ExchangeEx(0, "4031063", -1, "1012012,Period:21600", 1);
			else if (reward == 2) trade = ExchangeEx(0, "4031063", -1, "1012013,Period:21600", 1);
			else if (reward == 3) trade = ExchangeEx(0, "4031063", -1, "1012014,Period:21600", 1);
			else if (reward == 4) trade = ExchangeEx(0, "4031063", -1, "1012015,Period:21600", 1);
			else if (reward == 5) trade = ExchangeEx(0, "4031063", -1, "1012016,Period:21600", 1);
			else if (reward == 6) trade = ExchangeEx(0, "4031063", -1, "1012017,Period:21600", 1);
			else if (reward == 7) trade = ExchangeEx(0, "4031063", -1, "1012018,Period:21600", 1);
			else if (reward == 8) trade = ExchangeEx(0, "4031063", -1, "1012019,Period:21600", 1);
			else if (reward == 9) trade = ExchangeEx(0, "4031063", -1, "1012020,Period:21600", 1);
			else if (reward == 10) trade = Exchange(0, 4031063, -1, 3992024, 1);
			else if (reward == 11) trade = Exchange(0, 4031063, -1, 3992025, 1);
			else if (reward == 12) trade = Exchange(0, 4031063, -1, 3992026, 1);
			else if (reward == 13) trade = Exchange(0, 4031063, -1, 2020012, 1);
			else if (reward == 14) trade = Exchange(0, 4031063, -1, 2020013, 1);
			
			if (!trade)
			{
				self.say("Do you have empty slots in your item tabs? Do you already have my horn? Check again!");
				return;
			}
			
			SetQuestData(9000201, "end");
			SetQuestData(9000202, DateTime.UtcNow.ToString("yyyyMMdd"));
			
		}
		else
		{
			int start1 = AskMenu("Torr's looking at you. What would you say?#b",
				(0, " Hey, where can I get the Christmas ornaments?"),
				(1, " Why are you crying?"));
			
			if (start1 == 0)
			{
				self.say("Ahh... Ask Rudy, he knows everything!!! I need to look for my horn!!!");
				return;
			}
			
			int start2 = AskMenu("Grandpa Cliff scolded me again... AGAIN... AGAIN... I lost my horn AGAIN!.#b",
				(0, " You look great without the horn"),
				(1, " Yeah... You should be careful before it happened"),
				(2, " How did you lose it?"));
			
			if (start2 == 0)
			{
				self.say("... Really? Thanks, but... I really need my horn to help Grandpa Cliff ...");
				return;
			}
			
			if (start2 == 1)
			{
				self.say("I know, I know, but when I started to zone in on something, I totally forget about everything else... ");
				return;
			}
			
			int start3 = AskMenu("I lost my horn when I practiced pulling the sled... People think I am very clumsy... But, I get so nervous when I fly to the sky... So I lost my horn during the practice!!#b",
				(0, " I will help you to get your horn back."),
				(1, " What would you give to me if I get the horn for you?"));
			
			if (start3 == 1)
			{
				self.say("Don't expect something in return when you are willing to help others!! There will be SOMEONE more than willing to help me out here, someone NICE.");
				return;
			}
			
			SetQuestData(9000201, "s");
			self.say("Really? Then can you check around the shops all around this place? Somebody told me ... Hmmm. Well, I forgot. Anyway, please look for my horn. If you help me getting my horn back, I will give you something nice in return.");
		}
	}
}