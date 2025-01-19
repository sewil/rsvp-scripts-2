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

		if (Constants.MAPLE_VERSION == 17)
		{
			// 1st anniversary event
			redcreds.Add(new RedeemableCredit(2.0, RateCredits.Type.Drop, TimeSpan.FromHours(12), "1 Year Anniversary", 999190, DateTime.MaxValue));
			redcreds.Add(new RedeemableCredit(2.0, RateCredits.Type.EXP, TimeSpan.FromHours(12), "1 Year Anniversary", 999191, DateTime.MaxValue));
		}
		
		if (eventActive("anniversary2022"))
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
			if ((info == "s" || Level < 31) && eventActive("anniversary2022"))
				return " 2nd Anniversary : Birthday Present (Red)";
		}
		else if (quest == 8020055)
		{
			if (Level >= 31 && eventActive("anniversary2022"))
				return " 2nd Anniversary : Birthday Present (Blue)";
		}
		else if (quest == 8020020)
		{
			if (eventActive("thanksgiving2022"))
				return " Participate in the Thanksgiving Event";
		}
		
		return null;
	}

	public override void Run()
	{
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {9000302, 8020054, 8020055, 8020020};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		options.Add((100, " Credit System"));
		options.Add((101, " Tell me about referrals"));
		
		if (CouponCheck())
			options.Add((102, " Check my coupons"));
		
		if (CanReturnStars())
			options.Add((103, " #rI want to retrieve the stars I lost.#b"));
		
		string dialogue = "Hi, welcome to MG2!";
		
		if (DateTime.UtcNow < DateTime.Parse("2022-11-05"))
			dialogue = "Happy 2nd Anniversary, MG2~!";
		
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
			case 100: Credit(); break;
			case 101: Referral(); break;
			case 102: Coupon(); break;
			case 103: StarReturn(); break;
		}
	}
}
