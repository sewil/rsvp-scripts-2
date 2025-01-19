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
			new RedeemableCredit(1.5, RateCredits.Type.Mesos, TimeSpan.FromHours(12), "Perrito Birthday Event", 999102, DateTime.Parse("2021-08-09T00:00:00Z")),
		};
		
		if (Constants.MAPLE_VERSION == 17)
		{
			// 1st anniversary event
			redcreds.Add(new RedeemableCredit(2.0, RateCredits.Type.Drop, TimeSpan.FromHours(12), "1 Year Anniversary", 999190, DateTime.MaxValue));
			redcreds.Add(new RedeemableCredit(2.0, RateCredits.Type.EXP, TimeSpan.FromHours(12), "1 Year Anniversary", 999191, DateTime.MaxValue));
		}

		// Add everything that is not yet activated
		foreach (var redcred in redcreds.Where(x => DateTime.Now < x.EndDate && GetQuestData(x.QuestID) != "1"))
		{
			SetQuestData(redcred.QuestID, "1");
			rc.AddTimedCredits(redcred.Type, redcred.Duration, redcred.Rate, redcred.Comment);
		}
		
		void ManageCredit(RateCredits.Credit cr) {
			do
			{
				AskMenuCallback(
					JoinLines(
						$"Name: {cr.Comment}",
						$"Time left: {cr.DurationLeft:hh\\:mm\\:ss} of {cr.DurationGiven:hh\\:mm\\:ss}",
						$"Type: {cr.Rate}x {cr.Type}"
					),
					("#bEnable credit", !cr.Enabled && cr.CreditsLeft > 0, () =>
						{
							cr.Enabled = true;
							self.say("This credit has been enabled");
						}
					),
					("#bDisable credit", cr.Enabled && cr.CreditsLeft > 0, () =>
						{
							cr.Enabled = false;
							self.say("This credit has been disabled");
						}
					)
				);
			} while (cr.CreditsLeft > 0);
		}
		
		string CreditText(RateCredits.Credit cr) {
			return $"{cr.Comment}: {cr.Rate}x {cr.Type} for {cr.DurationGiven:hh} {(cr.DurationGiven.TotalHours == 1 ? "hour" : "hours")}";
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
					{
						var currentCredits = rc.GetCredits();

						var expiredCredits = currentCredits.Where(x => x.CreditsLeft == 0).ToArray();
						var nonExpiredCredits = currentCredits.Where(x => x.CreditsLeft > 0).ToArray();
						
						var calls = new List<(string Item, Action Callback)>();

						foreach (var cr in nonExpiredCredits)
						{
							calls.Add((CreditText(cr), () => ManageCredit(cr)));
						}
						
						if (expiredCredits.Length > 0)
						{
							calls.Add(($"Show {expiredCredits.Length} expired {(expiredCredits.Length == 1 ? "credit" : "credits")}", () => {
								var calls = new List<(string Item, Action Callback)>();
								foreach (var cr in expiredCredits)
								{
									calls.Add((CreditText(cr), () => ManageCredit(cr)));
								}
								AskMenuCallback("Choose the credit.#b", calls.ToArray());
							}));
						}
						
						if (calls.Count == 0)
						{
							self.say("Sorry, it looks like there are no credits available.");
						}
						else
						{
							AskMenuCallback("Choose the credit.#b", calls.ToArray());
						}
					}
				)
			);
		}
	}
	
	private void BirthdayRed()
	{
		var rnd = new Random();
		string quest = GetQuestData(8020011);
		
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
				
				if (rnum < 8000) itemID = 2020032;
				else if (rnum < 9100) itemID = 1002515;
				else if (rnum < 9700) itemID = 1002516;
				else if (rnum < 9900) itemID = 1002517;
				else if (rnum < 10000) itemID = 1002518;
				
				if (!Exchange(0, 4031306, -1, itemID, 1))
				{
					self.say("Are you sure you brought the #bRed Birthday Present#k? Please check and talk to me again.");
					return;
				}
				
				QuestEndEffect();
				SetQuestData(8020011, "e");
				self.say($"Tada~ Here's your present, 1 #b#t{itemID}##k! Hope you like what you see in it!! Thank you so much for helping us celebrate MG2's first birthday!");
			}
		}
		else
		{
			bool start = AskYesNo("MG2 is nearing its very first birthday, and we're going to celebrate it in style! I have a new, anniversary-related quest for you. Would you like to do it?");
			
			if (!start)
			{
				self.say("I see~ Please remember that this event ends soon, so if you want to take a crack at it later, then please talk to me!");
				return;
			}
			
			SetQuestData(8020011, "s");
			self.say("Here's the deal~ Please bring a #bRED birthday present#k to me, and I'll help you open it. Deal? I'll see you later~");
		}
	}
	
	private void BirthdayBlue()
	{
		var rnd = new Random();
		string quest = GetQuestData(8020012);
		
		if (quest == "s")
		{
			if (ItemCount(4031307) < 1)
			{
				self.say("I don't think you have the #bBLUE Birthday Present #kyet. Please bring it to me, so I can help you open it!");
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
				
				if (rnum < 8399) itemID = 2020032;
				else if (rnum < 9399) itemID = 1002515;
				else if (rnum < 9899) itemID = 1002516;
				else if (rnum < 9999) itemID = 1002517;
				else if (rnum == 10000) itemID = 1002518;
				
				if (!Exchange(0, 4031307, -1, itemID, 1))
				{
					self.say("Are you sure you brought the #bBlue Birthday Present#k? Please check and talk to me again.");
					return;
				}
				
				QuestEndEffect();
				SetQuestData(8020012, "e");
				self.say($"Tada~ Here's your present, 1 #b#t{itemID}##k! Hope you like what you see in it!! Thank you so much for helping us celebrate MG2's first birthday!");
			}
		}
		else
		{
			bool start = AskYesNo("MG2 is nearing its very first birthday, and we're going to celebrate it in style! I have a new, anniversary-related quest for you. Would you like to do it?");
			
			if (!start)
			{
				self.say("I see~ Please remember that this event ends soon, so if you want to take a crack at it later, then please talk to me!");
				return;
			}
			
			SetQuestData(8020012, "s");
			self.say("Here's the deal~ Please bring a #bBLUE Birthday Present#k to me, and I'll help you open it. Deal? I'll see you later~");
		}
	}
	
	private void Referral()
	{
		self.say("The referral system allows players to earn Cash by referring new players to MG2!");
		self.say("To refer a player, first login to your account on the website:\r\n#bhttps://rsvp.mdtz.eu#k. Once you are logged in, you will be able to copy your unique referral link.");
		self.say("Send the link to any players registering a new account on MG2. When the player reaches #blevel 30#k for the first time, you and the player you referred will both earn #b2,000 Cash#k!");
		self.say("There are no limitations on referrals, so any new account registered using your referral link will qualify. As long as a player on the referred account reaches #blevel 30#k, both accounts will receive the reward.");
	}
	
	private bool Check(int quest)
	{
		string info = GetQuestData(quest);
		var today = DateTime.UtcNow;
		var startDate = DateTime.Parse("2021-10-02");
		var endDate = DateTime.Parse("2021-10-23");
		
		if (quest == 8020011)
		{
			string blue = GetQuestData(8020012);
			
			if ((info == "s" || (blue != "s" && Level < 31)) && today >= startDate && today < endDate)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (quest == 8020012)
		{
			string red = GetQuestData(8020011);
			
			if ((info == "s" || (red != "s" && Level >= 31)) && today >= startDate && today < endDate)
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
		AskMenuCallback("Happy Anniversary MG2!!#b",
			(" Anniversary : Birthday Present (Red)", Check(8020011), BirthdayRed),
			(" Anniversary : Birthday Present (Blue)", Check(8020012), BirthdayBlue),
			(" Credit System", true, Credit),
			(" Tell me about referrals", true, Referral)
		);
	}
}