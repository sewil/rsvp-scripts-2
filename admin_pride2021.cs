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

		// Add everything that is not yet activated
		foreach (var redcred in redcreds.Where(x => DateTime.Now < x.EndDate && GetQuestData(x.QuestID) != "1"))
		{
			SetQuestData(redcred.QuestID, "1");
			rc.AddTimedCredits(redcred.Type, redcred.Duration, redcred.Rate, redcred.Comment);
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

						var calls = new List<(string Item, Action Callback)>();

						foreach (var cr in currentCredits)
						{
							calls.Add(($"{cr.Comment}: {cr.Rate}x {cr.Type} for {cr.DurationGiven:hh} hours", () =>
									{
										while (true)
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
										}
									}
								));
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
	
	private void Pride()
	{
		string quest = GetQuestData(8020007);
		
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
	
	private void Referral()
	{
		self.say("The referral system allows players to earn Cash by referring new players to MG2!");
		self.say("To refer a player, first login to your account on the website:\r\n#bhttps://rsvp.mdtz.eu#k. Once you are logged in, you will be able to copy your unique referral link.");
		self.say("Send the link to any players registering a new account on MG2. When the player reaches #blevel 30#k for the first time, you and the player you referred will both earn #b2,000 Cash#k!");
		self.say("There are no limitations on referrals, so any new account registered using your referral link will qualify. As long as a player on the referred account reaches #blevel 30#k, both accounts will receive the reward.");
	}

	public override void Run()
	{
		AskMenuCallback("Hi, welcome to MG2!#b",
			(" Maple Administrator's Pride Parade", DateTime.UtcNow < DateTime.Parse("2021-07-01"), Pride),
			(" Credit System", true, Credit),
			(" Tell me about referrals", true, Referral)
		);
	}
}