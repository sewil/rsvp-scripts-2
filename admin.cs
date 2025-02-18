using System;
using WvsBeta.Game;
using System.Collections.Generic;
using WvsBeta.Common;
using System.Linq;

public class NpcScript : IScriptV2
{
	class RedeemableCredit
	{
		public double Rate;
		public RateCredits.Type Type;
		public TimeSpan Duration;
		public string Comment;
		public int QuestID;
		public DateTime EndDate;

		public RedeemableCredit(double rate, RateCredits.Type type, TimeSpan duration, string comment, int questID, DateTime endDate)
		{
			Rate = rate;
			Type = type;
			Duration = duration;
			Comment = comment;
			QuestID = questID;
			EndDate = endDate;
		}
	}
	
	private void Credit()
	{
		var rc = chr.RateCredits;

		var redcreds = new List<RedeemableCredit>
		{
			new RedeemableCredit(2.0, RateCredits.Type.Drop, TimeSpan.FromHours(12), "6 Month Anniversary", 999100, DateTime.Parse("2021-05-08T00:00:00Z")),
			new RedeemableCredit(1.5, RateCredits.Type.EXP, TimeSpan.FromHours(6), "Rollback Compensation", 999101, DateTime.Parse("2021-05-01T00:00:00Z")),

			new RedeemableCredit(1.5, RateCredits.Type.Mesos, TimeSpan.FromHours(12), "Perrito Birthday Event", 999102, DateTime.Parse("2022-08-09T00:00:00Z")),

			new RedeemableCredit(2.0, RateCredits.Type.Mesos, TimeSpan.FromHours(24), "Diamondo25 Birthday Event", 999103, DateTime.Parse("2022-12-20T00:00:00Z")),
			new RedeemableCredit(2.0, RateCredits.Type.EXP, TimeSpan.FromHours(24), "Diamondo25 Birthday Event", 999104, DateTime.Parse("2022-12-20T00:00:00Z")),
			new RedeemableCredit(2.0, RateCredits.Type.Drop, TimeSpan.FromHours(24), "Diamondo25 Birthday Event", 999105, DateTime.Parse("2022-12-20T00:00:00Z")),

			new RedeemableCredit(2.0, RateCredits.Type.Mesos, TimeSpan.FromHours(24), "Chika Birthday Event", 999106, DateTime.Parse("2022-01-22T00:00:00Z")),
			new RedeemableCredit(2.0, RateCredits.Type.EXP, TimeSpan.FromHours(24), "Chika Birthday Event", 999107, DateTime.Parse("2022-01-22T00:00:00Z")),
			new RedeemableCredit(2.0, RateCredits.Type.Drop, TimeSpan.FromHours(24), "Chika Birthday Event", 999108, DateTime.Parse("2022-01-22T00:00:00Z")),
			
			new RedeemableCredit(1.5, RateCredits.Type.Mesos, TimeSpan.FromHours(6), "Lunar New Year LuckUP! Event", 999109, DateTime.Parse("2022-02-09T00:00:00Z")),
			new RedeemableCredit(1.5, RateCredits.Type.Drop, TimeSpan.FromHours(6), "Lunar New Year LuckUP! Event", 999110, DateTime.Parse("2022-02-09T00:00:00Z")),
			
			new RedeemableCredit(2.0, RateCredits.Type.Mesos, TimeSpan.FromHours(24), "Vados Birthday Event", 999111, DateTime.Parse("2022-03-10T00:00:00Z")),
			new RedeemableCredit(2.0, RateCredits.Type.EXP, TimeSpan.FromHours(24), "Vados Birthday Event", 999112, DateTime.Parse("2022-03-10T00:00:00Z")),
			new RedeemableCredit(2.0, RateCredits.Type.Drop, TimeSpan.FromHours(24), "Vados Birthday Event", 999113, DateTime.Parse("2022-03-10T00:00:00Z")),

		};

		if (eventActive("anniversary2026"))
		{
			// 1st anniversary event
			redcreds.Add(new RedeemableCredit(2.0, RateCredits.Type.Drop, TimeSpan.FromHours(12), "1 Year Anniversary", 999190, DateTime.MaxValue));
			redcreds.Add(new RedeemableCredit(2.0, RateCredits.Type.EXP, TimeSpan.FromHours(12), "1 Year Anniversary", 999191, DateTime.MaxValue));
		}
		
		if (eventActive("anniversary2027"))
		{
			if (GetQuestData(8020051) != "e")
			{
				redcreds.Add(new RedeemableCredit(2.0, RateCredits.Type.Drop, TimeSpan.FromHours(6), "2 Year Anniversary", 999192, DateTime.MaxValue));
				redcreds.Add(new RedeemableCredit(2.0, RateCredits.Type.EXP, TimeSpan.FromHours(6), "2 Year Anniversary", 999193, DateTime.MaxValue));
			}
			else
			{
				redcreds.Add(new RedeemableCredit(2.0, RateCredits.Type.Drop, TimeSpan.FromHours(6), "2 Year Anniversary", 999195, DateTime.MaxValue));
				redcreds.Add(new RedeemableCredit(2.0, RateCredits.Type.EXP, TimeSpan.FromHours(6), "2 Year Anniversary", 999196, DateTime.MaxValue));
			}
		}
		
		// 2 day downtime :(
		redcreds.Add(new RedeemableCredit(2.0, RateCredits.Type.Drop, TimeSpan.FromHours(2), "Downtime Compensation", 999197, DateTime.Parse("2022-12-01T00:00:00Z")));
		redcreds.Add(new RedeemableCredit(2.0, RateCredits.Type.EXP, TimeSpan.FromHours(2), "Downtime Compensation", 999198, DateTime.Parse("2022-12-01T00:00:00Z")));
		redcreds.Add(new RedeemableCredit(2.0, RateCredits.Type.Mesos, TimeSpan.FromHours(2), "Downtime Compensation", 999199, DateTime.Parse("2022-12-01T00:00:00Z")));

		// Add everything that is not yet activated
		foreach (var redcred in redcreds.Where(x => DateTime.Now < x.EndDate && GetQuestData(x.QuestID) != "1"))
		{
			SetQuestData(redcred.QuestID, "1");
			rc.AddTimedCredits(redcred.Type, redcred.Duration, redcred.Rate, redcred.Comment);
		}
		
		void ManageCredit(RateCredits.Credit cr) {
			bool breakLoop = false;
			do
			{
				var extraText = "";
				if (cr.CreditsLeft == 0) {
					extraText = "This credit has expired.";
				} else {
					extraText = "This credit is currently #b#e";
					extraText += cr.Enabled ? "active" : "inactive";
					extraText += "#k#n";
				}
				
				AskMenuCallback(
					JoinLines(
						$"Name: {cr.Comment}",
						$"Time left: {(int)(cr.DurationLeft.TotalHours)}:{cr.DurationLeft:mm\\:ss} of {(int)(cr.DurationGiven.TotalHours)}:{cr.DurationGiven:mm\\:ss}",
						$"Type: {cr.Rate}x {cr.Type}",
						extraText
					),
					("#bEnable credit", !cr.Enabled && cr.CreditsLeft > 0, () =>
						{
							cr.Enabled = true;
							rc.SendUpdate(true);
						}
					),
					("#bDisable credit", cr.Enabled && cr.CreditsLeft > 0, () =>
						{
							cr.Enabled = false;
							rc.SendUpdate(true);
						}
					),
					("#bBack", true, () => breakLoop = true),
					("#bAdd 1 minute of credits (GM-only)", chr.IsGM, () => 
						{
							cr.CreditsLeft += 1 * 60;
							rc.SendUpdate(true);
						}
					)
				);
			} while (cr.CreditsLeft > 0 && !breakLoop);
		}
		
		string CreditText(RateCredits.Credit cr) {
			var txt = $"{cr.Comment}: {cr.Rate}x {cr.Type} for {(int)(cr.DurationGiven.TotalHours)} {((int)(cr.DurationGiven.TotalHours) == 1 ? "hour" : "hours")}";
			if (cr.Enabled && cr.CreditsLeft > 0) txt += " (active)";
			return txt;
		}

		while (true)
		{
			AskMenuCallback(
				$"Hello {chr.Name}! What would you like to do?#b",
				("What are credits?", true, () =>
					{
						self.say("During events, you will be awarded credits that you can redeem at your leisure. When the credit is redeemed, time will tick down, but only while you're online.");
						self.say("If you would like to check how much time is left on a credit, or disable / enable it, you can do so in [Manage my credits].");
					}
				),
				("Manage my credits", true, () =>
					{while (true) {
						var currentCredits = rc.GetCredits();

						var expiredCredits = currentCredits.Where(x => x.CreditsLeft == 0).ToArray();
						var nonExpiredCredits = currentCredits.Where(x => x.CreditsLeft > 0).OrderBy(x => !x.Enabled).ToArray();
						
						var calls = new List<(string Item, Action Callback)>();

						foreach (var cr in nonExpiredCredits)
						{
							calls.Add((CreditText(cr), () => ManageCredit(cr)));
						}
						
						if (expiredCredits.Length > 0)
						{
							calls.Add(($"Show {expiredCredits.Length} expired {(expiredCredits.Length == 1 ? "credit" : "credits")}", () => {while (true) {
								var calls = new List<(string Item, Action Callback)>();
								foreach (var cr in expiredCredits)
								{
									calls.Add((CreditText(cr), () => ManageCredit(cr)));
								}
								var breakLoop = false;
								calls.Add(("#bGo back", () => breakLoop = true));
								AskMenuCallback("Choose the credit.#b", calls.ToArray());
								if (breakLoop) break;
							}}));
						}
						
						if (calls.Count == 0)
						{
							self.say("Sorry, it looks like there are no credits available.");
						}
						else
						{
							AskMenuCallback("Choose the credit.#b", calls.ToArray());
						}
					}}
				)
			);
		}
	}
	
	static Dictionary<int, int[]> lostStars = new Dictionary<int, int[]>{
		{31338, new [] {2070006 }},
		{42570, new [] {2070003 }},
		{34147, new [] {2070006 }},
		{38768, new [] {2070000, 2070000 }},
		{40176, new [] {2070000 }},
		{41162, new [] {2070004, 2070004, 2070004 }},
		{41210, new [] {2070006, 2070006, 2070006 }},
		{41221, new [] {2070006 }},
		{41638, new [] {2070000, 2070005 }},
		{42348, new [] {2070000 }},
		{42887, new [] {2070003 }},
		{43178, new [] {2070003 }},
		{43484, new [] {2070000, 2070000, 2070000, 2070000, 2070000, 2070000, 2070000, 2070000 }},
		{43508, new [] {2070001, 2070008 }},
	};
	const int lostStarsQuestID = 912345;
	
	private bool CanReturnStars() {
		return lostStars.ContainsKey(chr.ID) && GetQuestData(lostStarsQuestID) == "";
	}

	private void StarReturn()
	{
		if (lostStars.TryGetValue(chr.ID, out var items))
		{
			if (!CanReturnStars()) {
				OK("The stars you lost are already returned.");
				return;
			}

			var exchangeData = new int[items.Length * 2];
			for (var i = 0; i < exchangeData.Length; i += 2) {
				exchangeData[i + 0] = items[i / 2];
				exchangeData[i + 1] = 1;
			}
			
			if (!Exchange(0, exchangeData))
			{
				OK($"Please make sure you have space for {items.Length} stars.");
				return;
			}
			
			SetQuestData(lostStarsQuestID, "1");
			Info("Returned the stars");
			OK($"{items.Length} stars are returned to you.");
		}
	}
	
	private void Referral()
	{
		self.say("The referral system allows players to earn Cash by referring new players to MG2!");
		self.say("To refer a player, first login to your account on the website:\r\n#bhttps://rsvp.mdtz.eu/#k. Once you are logged in, you will be able to copy your unique referral link.");
		self.say("Send the link to any players registering a new account on MG2. When the player reaches #blevel 30#k for the first time, you and the player you referred will both earn #b2,000 Cash#k!");
		self.say("There are no limitations on referrals, so any new account registered using your referral link will qualify. As long as a player on the referred account reaches #blevel 30#k, both accounts will receive the reward.");
	}
	
	private bool CouponCheck() // For players with active coupon rewards
	{
		string[] names = {"oh18", "Bburinkle", "Crest", "tuff"};
		
		foreach (string name in names)
		{
			if (chr.Name == name)
				return true;
		}
		
		return false;
	}
	
	private void Coupon()
	{
		self.say($"Hi {chr.Name}! Looks like you won a coupon code in an event.");
		
		if (chr.Name == "oh18")
			self.say("Here's your coupon code. Be sure to write it down so you can enter it into the coupon field in the Cash Shop!\r\n\r\n    #bj30rh9rehg3w#k");
		
		else if (chr.Name == "Bburinkle")
			self.say("Here's your coupon code. Be sure to write it down so you can enter it into the coupon field in the Cash Shop!\r\n\r\n    #bowirejg9h3rs#k");
		
		else if (chr.Name == "Crest")
			self.say("Here's your coupon code. Be sure to write it down so you can enter it into the coupon field in the Cash Shop!\r\n\r\n    #bgowj093jrpgu#k");
		
		else if (chr.Name == "tuff")
			self.say("Here's your coupon code. Be sure to write it down so you can enter it into the coupon field in the Cash Shop!\r\n\r\n    #b2m9ejf93ehri#k");
	}
	
	private void AnniversaryRaffle(string quest)
	{
		if (quest == "s")
		{
			self.say($"Congratulations {chr.Name}! Your name was chosen for the Anniversary Event raffle. Please take this #b#t1002518##k. Please make sure you have room in your equip. inventory first.");
			
			if (!Exchange(0, 1002518, 1))
			{
				self.say("I think your equip. inventory is full. Please make some room and talk to me again!");
				return;
			}
			
			SetQuestData(9000302, "end");
			QuestEndEffect();
			self.say($"Thanks for participating in our Anniversary event, {chr.Name}. Happy mapling!");
		}
	}
	
	private void BirthdayRed(string quest)
	{
		var rnd = new Random();
		
		if (quest == "s")
		{
			if (ItemCount(4031306) < 1)
			{
				self.say("I don't think you have the #bRED Birthday Present#k yet. Please bring it to me, so I can help you open it!");
				return;
			}
			
			bool end = AskYesNo("Wow, that was pretty fast! Aren't you ready to open up your present?");
			
			if (end)
			{
				if (SlotCount(1) < 1 || SlotCount(2) < 1)
				{
					self.say("Are you sure you have a slot available in your equip. and use inventories? Please check and talk to me again.");
					return;
				}
				
				int rnum = rnd.Next(0, 10000);
				
				int itemID = -1;
				
				if (rnum < 8390) itemID = 2020032;
				else if (rnum < 9390) itemID = 1002603;
				else if (rnum < 9890) itemID = 1002601;
				else if (rnum < 9990) itemID = 1002600;
				else if (rnum <= 10000) itemID = 1002602;
				
				if (!Exchange(0, 4031306, -1, itemID, 1))
				{
					self.say("Are you sure you brought the #bRed Birthday Present#k? Please check and talk to me again.");
					return;
				}
				
				QuestEndEffect();
				SetQuestData(8020054, "e");
				self.say($"Tada~ Here's your present, 1 #b#t{itemID}##k! Hope you like what you see in it!! Thank you so much for helping us celebrate MG2's second birthday!");
			}
		}
		else
		{
			bool start = AskYesNo("MG2 is having its second birthday bash, and we're going to celebrate it big time! We'd like to thank you, are you ready for the Birthday Quest?");
			
			if (!start)
			{
				self.say("I see~ Please remember that this event ends soon, so if you want to take a crack at it later, then please talk to me!");
				return;
			}
			
			SetQuestData(8020054, "s");
			self.say("Excellent! Here's the deal... bring me a #bRed Birthday Present#k, and I'll help you open it. Hurry back!");
		}
	}
	
	private void BirthdayBlue(string quest)
	{
		var rnd = new Random();
		
		if (quest == "s")
		{
			if (ItemCount(4031307) < 1)
			{
				self.say("I don't think you have a Blue Birthday Present yet. Please bring me one and I can open it for you!");
				return;
			}
			
			bool end = AskYesNo("Wow, that was pretty fast! Aren't you ready to open up your present?");
			
			if (end)
			{
				if (SlotCount(1) < 1 || SlotCount(2) < 1)
				{
					self.say("Are you sure you have a slot available in your equip. and use inventories? Please check and talk to me again.");
					return;
				}
				
				int rnum = rnd.Next(1, 10001);
				
				int itemID = -1;
				
				if (rnum < 8390) itemID = 2020032;
				else if (rnum < 9390) itemID = 1002603;
				else if (rnum < 9890) itemID = 1002601;
				else if (rnum < 9990) itemID = 1002600;
				else if (rnum <= 10000) itemID = 1002602;
				
				if (!Exchange(0, 4031307, -1, itemID, 1))
				{
					self.say("Are you sure you brought the #bBlue Birthday Present#k? Please check and talk to me again.");
					return;
				}
				
				QuestEndEffect();
				SetQuestData(8020055, "e");
				self.say($"Tada~ Here's your present, 1 #b#t{itemID}##k! Hope you like what you see in it!! Thank you so much for helping us celebrate MG2's second birthday!");
			}
		}
		else
		{
			bool start = AskYesNo("MG2 is having its second birthday bash, and we're going to celebrate it big time! We'd like to thank you, are you ready for the Birthday Quest?");
			
			if (!start)
			{
				self.say("I see~ Please remember that this event ends soon, so if you want to take a crack at it later, then please talk to me!");
				return;
			}
			
			SetQuestData(8020055, "s");
			self.say("Great! Please bring a Blue Birthday Present to me, and I'll help you open it. What you get will be a surprise!");
		}
	}
	
	private void Thanksgiving(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("Hello there, Mapler! We'll be conducting a small Thanksgiving event here. Are you interested?");
			
			if (!start)
			{
				self.say("Oh I see. Hurry, though, because this event ends soon.");
				return;
			}
			
			SetQuestData(8020020, "s");
			self.say("Cool! Okay, here's the deal. A number of monsters will randomly drop alphabet letters, and your job is to collect all the letters of the word #bMAPLESTORY#k. Once you collect them all, bring them to me and I'll put you in our Thanksgiving event. From this pool, we will randomly select winners to receive MaplePoints. Good luck, and hurry, because this event ends soon!");
		}
		else if (quest == "s")
		{
			if (ItemCount(3994000) < 1 || ItemCount(3994001) < 1 || ItemCount(3994003) < 1 || ItemCount(3994005) < 1 || ItemCount(3994006) < 1 || ItemCount(3994007) < 1 || ItemCount(3994008) < 1 || ItemCount(3994010) < 1 || ItemCount(3994012) < 1 || ItemCount(3994013) < 1)
			{
				self.say("I don't think you have all the letters. The letters you need are #bM A P L E S T O R Y#k. Check and see if you have them all.");
				return;
			}
			
			bool complete = AskYesNo("Thanks. Great job. It must have been difficult for you to collect all the letters, but you managed to pull it off!! Alright, so do you want to turn in the letters and participate in the event?");
			
			if (!complete)
			{
				self.say("Really? I don't see what those letters can be put to good use for other than on this event. It's your call, though. Come back and talk to me if you have a change of heart.");
				return;
			}
			
			if (!Exchange(0, 3994012, -1, 3994000, -1, 3994006, -1, 3994003, -1, 3994001, -1, 3994013, -1, 3994008, -1, 3994005, -1, 3994007, -1, 3994010, -1))
			{
				self.say("Are you sure you brought all the letters? Please check again.");
				return;
			}
			
			SetQuestData(8020020, "e");
			QuestEndEffect();
			self.say("Good choice. Now all you need to do is wait until we select the winners. It'll be posted #bon the website#k soon, so please check it regularly. I'll see you around. Ciao~");
		}
		else if (quest == "e")
		{
			self.say("You have already participated in the event. Now all you need to do is to wait until we select the winners. It'll be posted soon, so please keep an eye out. I'll see you around. Ciao~");
		}
	}

	private void Easter(string quest)
	{
		string lastDate = GetQuestData(8021000);
		string today = DateTime.UtcNow.ToString("yyyyMMdd");
		
		if (lastDate == today)
		{
			self.say("It looks like I already made you an Easter basket today. Why don't you come back again tomorrow~?");
			return;
		}
		
		if (quest == "s")
		{
			if (ItemCount(4000003) < 100 || ItemCount(4000004) < 100 || ItemCount(4000002) < 1)
			{
				self.say("Are you missing something? I need #b100 Tree Branches#k,\r\n#b100 Squishy Liquids#k, and #b1 Pig's Ribbon#k to make an #rEaster Basket#k.");
				return;
			}
			
			self.say("Great job gathering up #b100 Tree Branches#k, #b100 Squishy Liquids#k, and #b1 Pig's Ribbon#k needed to make the #rEaster Basket#k. Now let me see here...");
			
			if (!ExchangeEx(0, "4000003", -100, "4000004", -100, "4000002", -1, "4031283,DateExpire:2025042423", 1))
			{
				self.say("Hmm... please leave an empty space in your etc. inventory and then talk to me again.");
				return;
			}
			
			AddEXP(800);
			SetQuestData(8020003, "end");
			SetQuestData(8021000, DateTime.UtcNow.ToString("yyyyMMdd"));
			QuestEndEffect();
			self.say("Here's your #rEaster Basket#k! By the way, I hear that the Easter Bunny's nasty cousin is trying to ruin Easter this year. Avoid that rotten egg. He is a disgrace to the season~");
		}
		else
		{
			bool start = AskYesNo("Easter is upon us. To celebrate, I'll be crafting Easter Baskets for everyone. Do you want one?");
			
			if (!start)
			{
				self.say("I see. I make the best baskets in town, so if you change your mind, I'll be here.");
				return;
			}
			
			SetQuestData(8020003, "s");
			self.say("Good choice. Can you bring me #b100 Tree Branches#k, #b100 Squishy Liquids#k, and #b1 Ribbon Pig's Ribbon#k?");
		}
	}
	
	private void LunarNewYear(string quest)
	{
		if (Level < 10)
		{
			self.say("Happy New Year~! I have something to ask of you... but you should come back when you're at least #blevel 10#k.");
			return;
		}
		
		if (quest == "")
		{
			self.say($"Hey {chr.Name}~! How are you doing? The Lunar New Year took place on February 17th. Have you been celebrating~? Well, if you have some free time I could really use your help.");
			bool start = AskYesNo("The four chiefs around Victoria Island are always working hard, giving their strength to their new apprentices. They're so busy, they probably haven't had any time to celebrate Lunar New Year. So I want you to give each of them a New Year's greeting for me. What do you think?");
			
			if (!start)
			{
				self.say("You must be busy. Well, if you have some free time down the line, I think the four chiefs would really appreciate it.");
				return;
			}
			
			SetQuestData(9000500, "s");
			self.say("Great! Please deliver a New Year's greeting to #b#p1022000##k, #b#p1032001##k, #b#p1012100##k and #b#p1052001##k in that order. You'll have to meet with #p1022000# first.");
		}
		else if (quest == "4")
		{
			if (ItemCount(3993003) < 1)
			{
				self.say("I don't think you've met the four chiefs of Victoria Island. Please talk to #b#p1022000##k, #b#p1032001##k, #b#p1012100##k and #b#p1052001##k in order and then return to me!");
				return;
			}
			
			self.say("Oh~ you did wish all four chiefs a Happy New Year! I'm sure they were happy to see a kind young traveler like you. This must be a present from #b#p1052001##k for visiting all 4 wisemen!");
			self.say("Thank you for sending your greetings, now I need you to help me with one more thing...");
			
			SetQuestData(9000500, "5");
			self.say("While you were visiting the elders, some monsters came and took all of our #b#t3993002#s#k. Can you go take down some monsters and bring back #b5 #t3993002#s#k? I'll be waiting here for you!");
		}
		else if (quest == "5")
		{
			if (ItemCount(3993003) < 1 || ItemCount(3993002) < 5)
			{
				self.say("I don't think you have everything. Please gather #b5 #t3993002#s#k from monsters and return with the #b#t3993003##k that #b#p1052001##k gave you!");
				return;
			}
			
			self.say("Oh~ You brought them all! Thanks for all your help. Please hold out your hands, I have a present for you!");
			
			if (!Exchange(800, 3993003, -1, 3993002, -5, 2022006, 20))
			{
				self.say("It looks like you don't have room to take my present. Please talk to me again when you have an empty space in your use inventory.");
				return;
			}
			
			AddEXP(450);
			StartWeather(2090006, 15);
			SetQuestData(9000500, "e");
			QuestEndEffect();
			self.say($"Here you go, #b20 #b#t2022006#s#k. Happy New Year {chr.Name}~!");
		}
		else if (quest == "e")
		{
			self.say($"Happy New Year {chr.Name}~!");
		}
		else
		{
			self.say("I don't think you've met the four chiefs of Victoria Island. Please talk to #b#p1022000##k, #b#p1032001##k, #b#p1012100##k and #b#p1052001##k in order and then return to me!");
		}
	}

	private void MapleQuiz(int index)
	{
		int answer = 0;
		
		if (index == 1)
		{
			int question1 = AskMenu("Here goes the 1st question. What does Gordon make near the potion shop in El Nath?#b",
				(0, " Gloves"),
				(1, " Shoes"),
				(2, " Clothes"),
				(3, " Food"));
			
			if (question1 == 1)
			{
				int question2 = AskMenu("Here goes the 2nd question. Where will you find Rowen the Fairy?#b",
					(0, " Ellinia"),
					(1, " Orbis"),
					(2, " Sleepywood"),
					(3, " Kerning City"));
				
				if (question2 == 0)
				{
					int question3 = AskMenu("Here goes the last question. Which of these items will you find in the Cash Shop right now?#b",
						(0, " Glowing Shoes"),
						(1, " Chocolate Bar Sword"),
						(2, " Transparent Hat"),
						(3, " Green T-Shirt"));
					
					if (question3 == 2) answer = 1;
					else answer = 0;
				}
				else answer = 0;
			}
			else answer = 0;
		}
		else if (index == 2)
		{
			int question1 = AskMenu("Here goes the 1st question. Which of these options is not true about the Cash Shop?#b",
				(0, " You can gift items to your friends."),
				(1, " There's a button that allows you to buy what you're wearing."),
				(2, " The Wish List can contain up to 15 different items."),
				(3, " You can try on outfits by double-clicking them."));
			
			if (question1 == 2)
			{
				int question2 = AskMenu("Here goes the 2nd question. Which is the command that you use when you want to find out if your friends are online or where they are at the moment??#b",
					(0, " /find character-name"),
					(1, " /search character-name"),
					(2, " /who character-name"),
					(3, " /where character-name"));
				
				if (question2 == 0)
				{
					int question3 = AskMenu("Here goes the last question. Which is the command that you use when you want help??#b",
						(0, " /!"),
						(1, " /?"),
						(2, " /h"),
						(3, " //"));
					
					if (question3 == 1) answer = 1;
					else answer = 0;
				}
				else answer = 0;
			}
			else answer = 0;
		}
		else if (index == 3)
		{
			int question1 = AskMenu("Here goes the 1st question. Which is the shortcut key that shows your friends list??#b",
				(0, " H"),
				(1, " R"),
				(2, " A"),
				(3, " C"));
			
			if (question1 == 1)
			{
				int question2 = AskMenu("Here goes the 2nd question. Which is the shortcut key for the Mini Map?#b",
					(0, " H"),
					(1, " M"),
					(2, " 1"),
					(3, " F5"));
				
				if (question2 == 1)
				{
					int question3 = AskMenu("Here goes the last question. Which of these pieces of advice does Roger teach you on Maple Island?#b",
						(0, " How to equip weapons"),
						(1, " How to get to Victoria Island"),
						(2, " How to climb ladders"),
						(3, " How to consume items"));
					
					if (question3 == 3) answer = 1;
					else answer = 0;
				}
				else answer = 0;
			}
			else answer = 0;
		}
		else if (index == 4)
		{
			int question1 = AskMenu("Here goes the 1st question. How many floors are there in the Orbis Tower?#b",
				(0, " 15"),
				(1, " 25"),
				(2, " 20"),
				(3, " 30"));
			
			if (question1 == 2)
			{
				int question2 = AskMenu("Here goes the 2nd question. Which of these events can you NOT play with GMs??#b",
					(0, " Ola Ola"),
					(1, " Snowball"),
					(2, " Coconut Harvest"),
					(3, " Forest of Patience"));
				
				if (question2 == 3)
				{
					int question3 = AskMenu("Here goes the last question. Where is El Nath?#b",
						(0, " Victoria Island"),
						(1, " Ossyria"),
						(2, " Maple Island"),
						(3, " Florina Beach"));
					
					if (question3 == 1) answer = 1;
					else answer = 0;
				}
				else answer = 0;
			}
			else answer = 0;
		}
		else if (index == 5)
		{
			int question1 = AskMenu("Here goes the 1st question. Which monster should you hunt to find Tablecloth?#b",
				(0, " Wraith"),
				(1, " Leatty"),
				(2, " Jr. Wraith"),
				(3, " Malady"));
			
			if (question1 == 2)
			{
				int question2 = AskMenu("Here goes the 2nd question. Which friend of Ronnie lives in Henesys of Victoria Island?#b",
					(0, " Pia"),
					(1, " Chief Stan"),
					(2, " Cloy"),
					(3, " Rina"));
				
				if (question2 == 3)
				{
					int question3 = AskMenu("Here goes the last question. Which event can be played with a team?#b",
						(0, " Coconut Harvest"),
						(1, " OX Quiz"),
						(2, " MapleStory Physical Fitness Test"),
						(3, " Treasure Hunt"));
					
					if (question3 == 0) answer = 1;
					else answer = 0;
				}
				else answer = 0;
			}
			else answer = 0;
		}
		else if (index == 6)
		{
			int question1 = AskMenu("Here goes the 1st question. Which of these does Etran in Ellinia NOT make?#b",
				(0, " Wands"),
				(1, " Shoes"),
				(2, " Gloves"),
				(3, " Hats"));
			
			if (question1 == 1)
			{
				int question2 = AskMenu("Here goes the 2nd question. Which ingredients are needed to craft the Moon Rock?#b",
					(0, " One of every refined jewel"),
					(1, " One of every refined mineral"),
					(2, " One of every refined crystal"),
					(3, " One of every mineral and jewel"));
				
				if (question2 == 1)
				{
					int question3 = AskMenu("Here goes the last question. Which tab in the Cash Shop would you select to buy weather effects?#b",
						(0, " Set-up"),
						(1, " Etc."),
						(2, " Use"),
						(3, " Package"));
					
					if (question3 == 2) answer = 1;
					else answer = 0;
				}
				else answer = 0;
			}
			else answer = 0;
		}
		else if (index == 7)
		{
			int question1 = AskMenu("Here goes the 1st question. Which of these will restore 150 MP?#b",
				(0, " Apple"),
				(1, " Unagi"),
				(2, " Cake"),
				(3, " Lemon"));
			
			if (question1 == 3)
			{
				int question2 = AskMenu("Here goes the 2nd question. Who do you talk to in Lith Harbor to learn about each town in Victoria Island?#b",
					(0, " Pason"),
					(1, " Vikin"),
					(2, " Chef"),
					(3, " Phil"));
				
				if (question2 == 3)
				{
					int question3 = AskMenu("Here goes the last question. How do you get to Ossyria?#b",
						(0, " Take the boat in Ellinia"),
						(1, " Take the subway in Kerning City"),
						(2, " Take a plane in Henesys"),
						(3, " Take a train in Perion"));
					
					if (question3 == 0) answer = 1;
					else answer = 0;
				}
				else answer = 0;
			}
			else answer = 0;
		}
		else if (index == 8)
		{
			int question1 = AskMenu("Here goes the 1st question. What is Unagi made of?#b",
				(0, " Flounder"),
				(1, " Eel"),
				(2, " Tuna"),
				(3, " Salmon"));
			
			if (question1 == 1)
			{
				int question2 = AskMenu("Here goes the 2nd question. Which monster is NOT found in Florina Beach??#b",
					(0, " Clang"),
					(1, " Zombie Lupin"),
					(2, " Lorang"),
					(3, " Lupin"));
				
				if (question2 == 1)
				{
					int question3 = AskMenu("Here goes the last question. Which animal in the Chinese zodiac is 2026 the year of?#b",
						(0, " Dragon"),
						(1, " Ox"),
						(2, " Horse"),
						(3, " Monkey"));
					
					if (question3 == 2) answer = 1;
					else answer = 0;
				}
				else answer = 0;
			}
			else answer = 0;
		}
		
		if (answer == 0)
		{
			SetQuestData(9000200, "fail");
			self.say("Nope~ that's not the right answer. Sorry, you'll have to try again!");
		}
		else
		{
			self.say("Wow, you answered all three questions, great job~! Hold out your hands, I have a special gift just for you.");
			
			if (!Exchange(10000, 2022006, 20))
			{
				self.say("Hmm... are you sure there's room in your use inventory?");
				return;
			}
			
			AddEXP(1300);
			SetQuestData(9000200, "end");
			self.say($"Happy New Year, {chr.Name}, hopefully this well help you on your journey. I'll see you around!");
		}
	}
	
	private void NewYear(string cakePrize)
	{
		if (Level < 8)
			{
				self.say("Happy New Year~! To celebrate the new year, I'm giving out something special to those who take my quiz! You'll have to be at least #blevel 8#k to take the quiz, though.");
				return;
			}
			
			if (cakePrize == "end")
			{
				self.say("Hey~ you're the one who took my quiz! I wish you the best of luck in the new year!");
			}
			else
			{
				self.say("Happy New Year~! To celebrate New Year's Day, I'm giving out something special to those who take my quiz. It's easy, just answer all three questions correctly and I'll give you a nice reward! Make sure there's a space available in your use inventory first.");
				
				Random rnd = new Random();
				MapleQuiz(rnd.Next(1, 9));
			}
	}

	private void Pride(string quest)
	{
		if (Level < 8)
		{
			self.say("Hi there~! I could really use some help here, but I don't think you're strong enough yet. Please come back when you're at least #blevel 8#k.");
			return;
		}
		
		if (quest == "")
		{
			self.say($"Hi there {chr.Name}~! I could really use some help here... I'm making some decorations to celebrate Pride Month and hanging them up here in town. The problem is I'm fresh out of materials.");
			
			bool start = AskYesNo("So if you have some time, could you gather the materials for me?");
			
			if (!start)
			{
				self.say("Okay, if you change your mind just come back and see me!");
				return;
			}
			
			SetQuestData(8020007, "s");
			self.say("Awesome! Just walk around town and you're bound to run into some #bRainbow Slimes#k. Take them down and collect \r\n#b150 #t4009000#s#k and #b25 #t4009001#s#k. If you bring them back to me before the end of June, I'll give you something nice!");
		}
		else if (quest == "s")
		{
			if (ItemCount(4009000) < 150 || ItemCount(4009001) < 25)
			{
				self.say("I don't think you've found #b150 #t4009000#s#k and #b25 #t4009001#s#k yet. Look around town and you'll find colorful slimes jumping around. They should have what you're looking for!");
				return;
			}
			
			self.say("Wow, it looks like you really brought everything! Alright, for all your help I'll give you a Pride Flag. Hold out your hands!");
			
			if (!Exchange(0, 4009000, -150, 4009001, -25, 1302038, 1))
			{
				self.say("Are you sure you have everything? If so, please make sure there's an empty slot in your equip. tab.");
				return;
			}
			
			AddEXP(900);
			SetQuestData(8020007, "end");
			QuestEndEffect();
			self.say($"Here you go {chr.Name}~ Have a happy Pride Month!");
		}
		else if (quest == "end")
		{
			self.say("Thanks for your help! I hope you have a nice time in MG2!");
		}
	}

	private void Easy1(string quest)
	{
		if (quest == "")
		{
			self.say("Isn't it really hot these days? It seems like everyone's depending on fans and air conditioner to get through the day. I, however, believe that it's important for one to defeat the dog days of the summer by means of moving around and sweating.");
			bool start = AskYesNo("This is why MapleStory is proud to present #rBeat the Heat#k Challenge for the summer. Anyone that passes the three stages of the event will be provided with an opportunity to enter a ballot for prizes. Would you like to participate in this event?");
			
			if (!start)
			{
				self.say("This event goes on until August 1st, so if you decide to change your mind, you should definitely participate in this event!");
				return;
			}
			
			SetQuestData(8020038, "050020");
			self.say("Good choice. You'll find yourself forgetting how hot it is outside once you fully engage yourself in this event. This event has 3 difficulty settings designed to sufficiently meet your level, and I think you should participate in the #r<Easy>#k level.");
			self.say("The 1st stage of the <Easy> level will be a warm-up task. Your job is to head out to the field and defeat #b50 #o0130101#s#k and #b20 #o1210102#s#k. Easy, right? Complete the task for the 1st stage, and then I'll give you the instructions for the 2nd stage. Good luck!");
		}
		else
		{
			if (quest != "000000")
			{
				self.say("Here's your task for Stage 1: Defeat #b50 #o0130101#s#k and #b20 #o1210102#s#k. Good luck!");
				return;
			}
			
			self.say("Woo hoo!!! Congratulations on completing Stage 1!");
			
			if (!Exchange(0, 2001000, 10))
			{
				self.say("Please check to make sure there's an empty space in your use inventory.");
				return;
			}
			
			AddEXP(800);
			SetQuestData(8020038, "e");
			QuestEndEffect();
			self.say("Here are some watermelons for you to forget the dog days of the summer. Please come see me if you want to tackle on Stage 2.");
		}
	}
	
	private void Easy2(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("You're the one that completed Stage 1, right? Would you like to move up and tackle on the Level 2 training?");
			
			if (!start)
			{
				self.say("This event goes on until August 1st, so if you decide to change your mind, you should definitely participate in this event!");
				return;
			}
			
			SetQuestData(8020039, "s");
			self.say("The task for the 2nd stage of the <Easy> level will be to gather up items. I hung up #b#t4031167##k on #b#o1110100##k and #b#o1110101##k for the sake of this task. Please gather up #b10 #t4031167#s#k for me.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031167) < 10)
			{
				self.say("Here's your task for Stage 2: Gather up #b10 #t4031167#s#k that are hanging around the bodies of #b#o1110100##k and #b#o1110101##k.");
				return;
			}
			
			self.say("Woo hoo!!! Congratulations on completing the Level 2 training!");
			
			if (!Exchange(0, 4031167, -10, 2001000, 15))
			{
				self.say("Are you sure you brought everything? If so, please check to make sure there's an empty space in your use inventory.");
				return;
			}
			
			AddEXP(1000);
			SetQuestData(8020039, "e");
			QuestEndEffect();
			self.say("Here are some watermelons for you to forget the dog days of the summer. Please come see me if you want to tackle on Stage 3.");
		}
	}
	
	private void Easy3(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("You're the one that completed Stage 2, right? Would you like to move up and tackle on the Level 3 training?");
			
			if (!start)
			{
				self.say("This event goes on until August 1st, so if you decide to change your mind, you should definitely participate in this event!");
				return;
			}
			
			SetQuestData(8020040, "025025");
			self.say("The task for the 3rd stage of the <Easy> level will require you to both hunt AND gather up items. Defeat #b25 #o1130100#s#k and #b#o2220100#s#k each, and gather up #b30 #t4000037#s#k that #b#o1210103##k drops.");
		}
		else if (quest == "e")
		{
			self.say($"Hey {chr.Name}~ Thanks for participating in the 'Beat the Heat' challenge! You look like you're fighting off the heat just fine.");
			
			if (GetQuestData(8020047) == "")
				SetQuestData(8020047, "s1");
			
			self.say("By the way, would you be interested in upgrading that ice pop I gave you? It will melt before the end of summer but, if you want to make the most of it, I recommend you talk to my friend #bCassandra#k. Happy Mapling~");
		}
		else
		{
			if (quest != "000000" || ItemCount(4000037) < 30)
			{
				self.say("Here's your task for Stage 3: Defeat #b25#k #b#o1130100#s#k and #b#o220100#s each#k, and gather up #b30 #t4000037#s that #b#o1210103##k drops.");
				return;
			}
			
			self.say("Woo hoo!!! Congratulations on completing Stage 3!");
			
			var rnd = new Random();
			int reward = 1012070 + rnd.Next(0, 4);
			
			if (!ExchangeEx(0, "4000037", -30, $"{reward},DateExpire:2025090100", 1))
			{
				self.say("Are you sure you brought everything? If so, please check to make sure there's an empty space in your equip. inventory.");
				return;
			}
			
			AddEXP(1500);
			SetQuestData(8020040, "e");
			QuestEndEffect();
			self.say("Great work there! What do you think? To overcome the dog days of the summer, I advise you to live the life to the fullest, and keep yourself busy!");
			self.say("Congratulations on completing the <Easy> level of the Beat the Heat Challenge. I've given you an ice cold treat as a reward, you've earned it. Happy Mapling~!");
		}
	}
	
	private void Medium1(string quest)
	{
		if (quest == "")
		{
			self.say("Isn't it really hot these days? It seems like everyone's depending on fans and air conditioner to get through the day. I, however, believe that it's important for one to defeat the dog days of the summer by means of moving around and sweating.");
			bool start = AskYesNo("This is why MapleStory is proud to present #rBeat the Heat#k Challenge for the summer. Anyone that passes the three stages of the event will be provided with an opportunity to enter a ballot for prizes. Would you like to participate in this event?");
			
			if (!start)
			{
				self.say("This event goes on until August 1st, so if you decide to change your mind, you should definitely participate in this event!");
				return;
			}
			
			SetQuestData(8020041, "050020");
			self.say("Good choice. You'll find yourself forgetting how hot it is outside once you fully engage yourself in this event. This event has 3 difficulty settings designed to sufficiently meet your level, and I think you should participate in the #r<Medium>#k level.");
			self.say("The 1st stage of the <Medium> level will be a warm-up task. Your job is to head out to the Orbis Tower and defeat #b50 #o5200000#s#k and #b20 #o3000000#s#k. Easy, right? Complete the task for the 1st stage, and then I'll give you the instructions for the 2nd stage. Good luck!");
		}
		else
		{
			if (quest != "000000")
			{
				self.say("Here's your task for Stage 1: Defeat #b50 #o5200000#s#k and\r\n#b20 #o3000000#s#k. Good luck!");
				return;
			}
			
			self.say("Woo hoo!!! Congratulations on completing Stage 1!");
			
			if (!Exchange(0, 2001000, 25))
			{
				self.say("Please check to make sure there's an empty space in your use inventory.");
				return;
			}
			
			AddEXP(3700);
			SetQuestData(8020041, "e");
			QuestEndEffect();
			self.say("Here are some watermelons for you to forget the dog days of the summer. Please come see me if you want to tackle on Stage 2.");
		}
	}
	
	private void Medium2(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("You're the one that completed Stage 1, right? Would you like to move up and tackle on the Level 2 training?");
			
			if (!start)
			{
				self.say("This event goes on until August 1st, so if you decide to change your mind, you should definitely participate in this event!");
				return;
			}
			
			SetQuestData(8020042, "s");
			self.say("The task for the 2nd stage of the <Medium> level will be to gather up items. I hung up #b#t4031168##k on #b#o5200002##k and #b#o5200001##k for the sake of this task. Please gather up #b10 #t4031168#s#k for me.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031168) < 10)
			{
				self.say("Here's your task for Stage 2: Gather up #b10 #t4031168#s#k that are hanging around the bodies of #b#o5200002##k and #b#o5200001##k.");
				return;
			}
			
			self.say("Woo hoo!!! Congratulations on completing Stage 2!");
			
			if (!Exchange(0, 4031168, -10, 2001000, 30))
			{
				self.say("Are you sure you brought everything? If so, please check to make sure there's an empty space in your use inventory.");
				return;
			}
			
			AddEXP(4000);
			SetQuestData(8020042, "e");
			QuestEndEffect();
			self.say("Here are some watermelons for you to forget the dog days of the summer. Please come see me if you want to tackle on Stage 3.");
		}
	}
	
	private void Medium3(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("You're the one that completed Stage 2, right? Would you like to move up and tackle on the Level 3 training?");
			
			if (!start)
			{
				self.say("This event goes on until August 1st, so if you decide to change your mind, you should definitely participate in this event!");
				return;
			}
			
			SetQuestData(8020043, "025025");
			self.say("The task for the 3rd stage of the <Medium> level will require you to both hunt AND gather up items. Defeat #b25 #o3210201#s#k and #b#o5300001#s#k each, and gather up #b30 #t4000086#s#k that #b#o5300000##k drops.");
		}
		else if (quest == "e")
		{
			self.say($"Hey {chr.Name}~ Thanks for participating in the 'Beat the Heat' challenge! You look like you're fighting off the heat just fine.");
			
			if (GetQuestData(8020047) == "")
				SetQuestData(8020047, "s1");
			
			self.say("By the way, would you be interested in upgrading that ice pop I gave you? It will melt before the end of summer but, if you want to make the most of it, I recommend you talk to my friend #bCassandra#k. Happy Mapling~");
		}
		else
		{
			if (quest != "000000" || ItemCount(4000086) < 30)
			{
				self.say("Here's your task for Stage 3: Defeat #b25#k #b#o3210201#s#k and #b#o5300001#s each#k, and gather up #b30 #t4000086#s#k that #b#o5300000##k drops.");
				return;
			}
			
			self.say("Woo hoo!!! Congratulations on completing Stage 3!");
			
			var rnd = new Random();
			int reward = 1012070 + rnd.Next(0, 4);
			
			if (!ExchangeEx(0, "4000086", -30, $"{reward},DateExpire:2025090100", 1))
			{
				self.say("Are you sure you brought everything? If so, please check to make sure there's an empty space in your equip. inventory.");
				return;
			}
			
			AddEXP(4300);
			SetQuestData(8020043, "e");
			QuestEndEffect();
			self.say("Great work there! What do you think? To overcome the dog days of the summer, I advise you to live the life to the fullest, and keep yourself busy!");
			self.say("Congratulations on completing the <Medium> level of the Beat the Heat Challenge. I've given you an ice cold treat as a reward, you've earned it. Happy Mapling~!");
		}
	}
	
	private void Hard1(string quest)
	{
		if (quest == "")
		{
			self.say("Isn't it really hot these days? It seems like everyone's depending on fans and air conditioner to get through the day. I, however, believe that it's important for one to defeat the dog days of the summer by means of moving around and sweating.");
			bool start = AskYesNo("This is why MapleStory is proud to present #rBeat the Heat#k Challenge for the summer. Anyone that passes the three stages of the event will be provided with an opportunity to enter a ballot for prizes. Would you like to participate in this event?");
			
			if (!start)
			{
				self.say("This event goes on until August 1st, so if you decide to change your mind, you should definitely participate in this event!");
				return;
			}
			
			SetQuestData(8020044, "050020");
			self.say("Good choice. You'll find yourself forgetting how hot it is outside once you fully engage yourself in this event. This event has 3 difficulty settings designed to sufficiently meet your level, and and I think you should participate in the #r<Hard>#k level.");
			self.say("The 1st stage of the <Hard> level will be a warm-up task. Your job is to head out to the field and defeat #b50 #o4230120#s#k and #b20 #o4230118#s#k. Easy, right? Complete the task for the 1st stage, and then I'll give you the instructions for the 2nd stage. Good luck!");
		}
		else
		{
			if (quest != "000000")
			{
				self.say("Here's your task for Stage 1: Defeat #b50 #o4230120#s#k and #b20 #o4230118#s#k. Good luck!");
				return;
			}
			
			self.say("Woo hoo!!! Congratulations on completing Stage 1!");
			
			if (!Exchange(0, 2001000, 40))
			{
				self.say("Please check to make sure there's an empty space in your use inventory.");
				return;
			}
			
			AddEXP(12000);
			SetQuestData(8020044, "e");
			QuestEndEffect();
			self.say("Here are some watermelons for you to forget the dog days of the summer. Please come see me if you want to tackle on Stage 2.");
		}
	}
	
	private void Hard2(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("You're the one that completed Stage 1, right? Would you like to move up and tackle on the Level 2 training?");
			
			if (!start)
			{
				self.say("This event goes on until August 1st, so if you decide to change your mind, you should definitely participate in this event!");
				return;
			}
			
			SetQuestData(8020045, "s");
			self.say("The task for the 2nd stage of the <Hard> level will be to gather up items. I hung up #b#t4031169##k on #b#o4230104##k and #b#o4230115##k for the sake of thie task. Please gather up #b15 #t4031169#s#k for me.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031169) < 15)
			{
				self.say("Here's your task for Stage 2: Gather up #b15 #t4031169#s#k that are hanging around the bodies of #b#o4230104##k and #b#o4230115##k.");
				return;
			}
			
			self.say("Woo hoo!!! Congratulations on completing Stage 2!");
			
			if (!Exchange(0, 4031169, -15, 2001000, 45))
			{
				self.say("Are you sure you brought everything? If so, please check to make sure there's an empty space in your use inventory.");
				return;
			}
			
			AddEXP(13000);
			SetQuestData(8020045, "e");
			QuestEndEffect();
			self.say("Here are some watermelons for you to forget the dog days of the summer. Please come see me if you want to tackle on Stage 3.");
		}
	}
	
	private void Hard3(string quest)
	{
		
		if (quest == "")
		{
			bool start = AskYesNo("You're the one that completed Stage 2, right? Would you like to move up and tackle on the Level 3 training?");
			
			if (!start)
			{
				self.say("This event goes on until August 1st, so if you decide to change your mind, you should definitely participate in this event!");
				return;
			}
			
			SetQuestData(8020046, "025025");
			self.say("The task for the 3rd stage of the <Hard> level will require you to both hunt AND gather up items. Defeat #b25 #o5120002#s#k and #b#o5120000#s#k each, and gather up #b30 #t4000072##k that #b#o5120003##k drops.");
		}
		else if (quest == "e")
		{
			self.say($"Hey {chr.Name}~ Thanks for participating in the 'Beat the Heat' challenge! You look like you're fighting off the heat just fine.");
			
			if (GetQuestData(8020047) == "")
				SetQuestData(8020047, "s1");
			
			self.say("By the way, would you be interested in upgrading that ice pop I gave you? It will melt before the end of summer but, if you want to make the most of it, I recommend you talk to my friend #bCassandra#k. Happy Mapling~");
		}
		else
		{
			if (quest != "000000" || ItemCount(4000072) < 30)
			{
				self.say("Here's your task for Stage 3: Defeat #b25#k #b#o5120002#s#k and #b#o5120000#s each#k, and gather up #b30 #t4000072#s#k that #b#o5120003##k drops.");
				return;
			}
			
			self.say("Woo hoo!!! Congratulations on completing Stage 3!");
			
			var rnd = new Random();
			int reward = 1012070 + rnd.Next(0, 4);
			
			if (!ExchangeEx(0, "4000072", -30, $"{reward},DateExpire:2025090100", 1))
			{
				self.say("Are you sure you brought everything? If so, please check to make sure there's an empty space in your equip. inventory.");
				return;
			}
			
			AddEXP(15000);
			SetQuestData(8020046, "e");
			QuestEndEffect();
			self.say("Great work there! What do you think? To overcome the dog days of the summer, I advise you to live the life to the fullest, and keep yourself busy!");
			self.say("Congratulations on completing the <Hard> level of the Beat the Heat Challenge. I've given you an ice cold treat as a reward, you've earned it. Happy Mapling~!");
		}
	}
	
	private void IcePop()
	{
		self.say("You're back for another ice pop, right? Alright, I can give you another one that won't melt until the end of August!");
		
		var rnd = new Random();
		int reward = 1012070 + rnd.Next(0, 4);
			
		if (!ExchangeEx(0, $"{reward},DateExpire:2025090100", 1))
		{
			self.say("Please check to make sure there's an empty space in your equip. inventory.");
			return;
		}
		
		SetQuestData(8020052, "e");
		self.say("There you go, a brand new ice pop. Enjoy~");
	}
	
	private string Check(int quest)
	{
		string info = GetQuestData(quest);
		
		if (quest == 9000302)
		{
			if (info == "s")
				return " Anniversary Raffle Winner";
		}
		else if (quest == 8020054)
		{
			if ((info == "s" || Level < 31) && eventActive("anniversary2026"))
				return " 1st Anniversary : Birthday Present (Red)";
		}
		else if (quest == 8020055)
		{
			if (Level >= 31 && eventActive("anniversary2026"))
				return " 1st Anniversary : Birthday Present (Blue)";
		}
		else if (quest == 8020020)
		{
			if (eventActive("thanksgiving2025"))
				return " Participate in the Thanksgiving Event";
		}
		else if (quest == 8020003)
		{
			if (eventActive("easter2025"))
				return " Easter Basket";
		}
		else if (quest == 9000500)
		{
			if (eventActive("lunarnewyear2026"))
				return " Visiting the Elders!";
		}
		else if (quest == 9000200)
		{
			if (eventActive("newyear2026"))
				return " Celebrate New Year's Day";
		}
		else if (quest == 8020007)
		{
			if (eventActive("pride2025"))
				return " Maple Administrator's Pride Parade";
		}
		else if (quest == 8020038)
		{
			string medium1 = GetQuestData(8020041);
			string hard1 = GetQuestData(8020044);
			
			if (eventActive("summer2025") && ((Level < 26 && info == "" && medium1 == "" && hard1 == "") || (info != "" && info != "e")))
				return " Beat the Heat - 1st Stage";
		}
		else if (quest == 8020039)
		{
			string easy1 = GetQuestData(8020038);
			
			if (eventActive("summer2025") && easy1 == "e" && info != "e")
				return " Beat the Heat - 2nd Stage";
		}
		else if (quest == 8020040)
		{
			string easy2 = GetQuestData(8020039);
			
			if (eventActive("summer2025") && easy2 == "e" && info != "e")
				return " Beat the Heat - 3rd Stage";
			
			if (eventActive("summer2025") && info == "e")
				return " Upgrading the Ice Pop";
		}
		else if (quest == 8020041)
		{
			string easy1 = GetQuestData(8020038);
			string hard1 = GetQuestData(8020044);
			
			if (eventActive("summer2025") && ((Level >= 26 && Level < 46 && info == "" && easy1 == "" && hard1 == "") || (info != "" && info != "e")))
				return " Beat the Heat - 1st Stage";
		}
		else if (quest == 8020042)
		{
			string medium1 = GetQuestData(8020041);
			
			if (eventActive("summer2025") && medium1 == "e" && info != "e")
				return " Beat the Heat - 2nd Stage";
		}
		else if (quest == 8020043)
		{
			string medium2 = GetQuestData(8020042);
			
			if (eventActive("summer2025") && medium2 == "e" && info != "e")
				return " Beat the Heat - 3rd Stage";
			
			if (eventActive("summer2025") && info == "e")
				return " Upgrading the Ice Pop";
		}
		else if (quest == 8020044)
		{
			string easy1 = GetQuestData(8020038);
			string medium1 = GetQuestData(8020041);
			
			if (eventActive("summer2025") && ((Level >= 46 && info == "" && easy1 == "" && medium1 == "") || (info != "" && info != "e")))
				return " Beat the Heat - 1st Stage";
		}
		else if (quest == 8020045)
		{
			string hard1 = GetQuestData(8020044);
			
			if (eventActive("summer2025") && hard1 == "e" && info != "e")
				return " Beat the Heat - 2nd Stage";
		}
		else if (quest == 8020046)
		{
			string hard2 = GetQuestData(8020045);
			
			if (eventActive("summer2025") && hard2 == "e" && info != "e")
				return " Beat the Heat - 3rd Stage";
			
			if (eventActive("summer2025") && info == "e")
				return " Upgrading the Ice Pop";
		}
		return null;
	}

	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {9000302, 8020054, 8020055, 8020020, 8020003, 9000500, 9000200, 8020007, 8020038, 8020039, 8020040, 8020041, 8020042, 8020043, 8020044, 8020045, 8020046};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		options.Add((100, " Credit System"));
		// options.Add((101, " Tell me about referrals"));
		
		if (CouponCheck())
			options.Add((102, " Check my coupons"));
		
		if (CanReturnStars())
			options.Add((103, " #rI want to retrieve the stars I lost.#b"));
		
		string dialogue = "Hi, welcome to MG2!";
		
		if (eventActive("anniversary2026"))
			dialogue = "Happy Anniversary, MG2~!";
		
		if (options.Count == 0)
		{
			self.say(dialogue);
			return;
		}
		
		int choice = -1;
		
		if (options.Count >= 2)
			choice = AskMenu($"{dialogue}#b", options.ToArray());
		else
			choice = options[0].Index;
		
		switch(choice)
		{
			case 0: AnniversaryRaffle(GetQuestData(9000302)); break;
			case 1: BirthdayRed(GetQuestData(8020054)); break;
			case 2: BirthdayBlue(GetQuestData(8020055)); break;
			case 3: Thanksgiving(GetQuestData(8020020)); break;
			case 4: Easter(GetQuestData(8020003)); break;
			case 5: LunarNewYear(GetQuestData(9000500)); break;
			case 6: NewYear(GetQuestData(9000200)); break;
			case 7: Pride(GetQuestData(8020007)); break;

			case 8: Easy1(GetQuestData(8020038)); break;
			case 9: Easy2(GetQuestData(8020039)); break;
			case 10: Easy3(GetQuestData(8020040)); break;
			case 11: Medium1(GetQuestData(8020041)); break;
			case 12: Medium2(GetQuestData(8020042)); break;
			case 13: Medium3(GetQuestData(8020043)); break;
			case 14: Hard1(GetQuestData(8020044)); break;
			case 15: Hard2(GetQuestData(8020045)); break;
			case 16: Hard3(GetQuestData(8020046)); break;
			case 17: IcePop(); break;

			case 100: Credit(); break;
			case 101: Referral(); break;
			case 102: Coupon(); break;
			case 103: StarReturn(); break;
		}
	}
}
