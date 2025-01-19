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

			new RedeemableCredit(2.0, RateCredits.Type.Mesos, TimeSpan.FromHours(24), "Diamondo25 Birthday Event", 999103, DateTime.Parse("2021-12-20T00:00:00Z")),
			new RedeemableCredit(2.0, RateCredits.Type.EXP, TimeSpan.FromHours(24), "Diamondo25 Birthday Event", 999104, DateTime.Parse("2021-12-20T00:00:00Z")),
			new RedeemableCredit(2.0, RateCredits.Type.Drop, TimeSpan.FromHours(24), "Diamondo25 Birthday Event", 999105, DateTime.Parse("2021-12-20T00:00:00Z")),

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
	
	private void NewYear(string quest)
	{
		if (quest == "")
		{
			bool start = AskYesNo("Hey there. I want to thank you for all your help with delivering those presents. Since we're coming up on New Year's, I'd like you to take this present.");
			
			if (!start)
			{
				self.say("Heh, not really, but I can understand. Please come back when you want your gift.");
				return;
			}
			
			self.say("My pleasure, this is for you. Happy New Year!");
			
			if (!Exchange(0, 4031520, 1))
			{
				self.say("Are you sure there's a slot available in the etc. window? Please check and talk to me again.");
				return;
			}
			
			SetQuestData(8020031, "s");
			self.say("Come back when you are ready to receive your gift.");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031520) < 1)
			{
				self.say("Huh, did you really lose your gift? Here, please be more careful this time.");
				
				if (!Exchange(0, 4031520, 1))
				{
					self.say("Are you sure there's a slot available in the etc. window? Please check and talk to me again.");
				}
			}
			else
			{
				bool open = AskYesNo("Would you like me to open your present?");
				
				if (!open)
				{
					self.say("I understand. Come back when you are ready to receive your gift.");
					return;
				}
				
				if (SlotCount(2) < 1)
				{
					self.say("You'll need to have at least one slot available in your use inventory first.");
					return;
				}
				
				var rewards = new List<(int, int, int)> {
					(2000006, 10, 6500),
					(2000005, 10, 3400),
					(2040801, 1, 34),
					(2040001, 1, 33),
					(2040901, 1, 33)
				};
				
				var item = rewards.RandomElementByWeight(tuple => tuple.Item3);
				
				if (item == default)
					return;
				
				int itemID = item.Item1;
				int itemNum = item.Item2;
				
				if (!Exchange(0, 4031520, -1, itemID, itemNum))
				{
					self.say("Are you sure there's a slot available in the use window? Please check and talk to me again.");
					return;
				}
				
				SetQuestData(8020031, "e");
				QuestEndEffect();
				self.say("Here they are. Do you like what you see?");
				self.say("I sincerely hope this year becomes your best year ever! Happy New Year, from MapleStory!");
			}
		}
		else if (quest == "e")
		{
			self.say($"Did you like what you got? Happy New Years {chr.Name}~!");
		}
	}
	
	private bool IsEventDate(string eventName)
	{
		var today = DateTime.UtcNow;
		string start = "";
		string end = "";
		
		if (eventName == "thanksgiving2021")
		{
			start = "2021-11-14";
			end = "2021-12-11";
		}
		else if (eventName == "newyear2022")
		{
			start = "2021-12-31";
			end = "2022-01-02";
		}
		else if (eventName == "summer2022")
		{
			start = "2022-08-12";
			end = "2022-09-01";
		}
		
		if (today >= DateTime.Parse(start) && today < DateTime.Parse(end))
		{
			return true;
		}
		
		return false;
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
			
			if (!ExchangeEx(0, "4000037", -30, $"{reward},DateExpire:2022090100", 1))
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
			
			if (!ExchangeEx(0, "4000086", -30, $"{reward},DateExpire:2022090100", 1))
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
			
			if (!ExchangeEx(0, "4000072", -30, $"{reward},DateExpire:2022090100", 1))
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
			
		if (!ExchangeEx(0, $"{reward},DateExpire:2022090100", 1))
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
		else if (quest == 8020020)
		{
			if (IsEventDate("thanksgiving2021"))
				return " Participate in the Thanksgiving Event";
		}
		else if (quest == 8020031)
		{
			if (IsEventDate("newyear2022"))
				return " New Year : New Year's Wishes";
		}
		else if (quest == 8020038)
		{
			string medium1 = GetQuestData(8020041);
			string hard1 = GetQuestData(8020044);
			
			if (IsEventDate("summer2022") && ((Level < 26 && info == "" && medium1 == "" && hard1 == "") || (info != "" && info != "e")))
				return " Beat the Heat - 1st Stage";
		}
		else if (quest == 8020039)
		{
			string easy1 = GetQuestData(8020038);
			
			if (IsEventDate("summer2022") && easy1 == "e" && info != "e")
				return " Beat the Heat - 2nd Stage";
		}
		else if (quest == 8020040)
		{
			string easy2 = GetQuestData(8020039);
			
			if (IsEventDate("summer2022") && easy2 == "e" && info != "e")
				return " Beat the Heat - 3rd Stage";
			
			if (IsEventDate("summer2022") && info == "e")
				return " Upgrading the Ice Pop";
		}
		else if (quest == 8020041)
		{
			string easy1 = GetQuestData(8020038);
			string hard1 = GetQuestData(8020044);
			
			if (IsEventDate("summer2022") && ((Level >= 26 && Level < 46 && info == "" && easy1 == "" && hard1 == "") || (info != "" && info != "e")))
				return " Beat the Heat - 1st Stage";
		}
		else if (quest == 8020042)
		{
			string medium1 = GetQuestData(8020041);
			
			if (IsEventDate("summer2022") && medium1 == "e" && info != "e")
				return " Beat the Heat - 2nd Stage";
		}
		else if (quest == 8020043)
		{
			string medium2 = GetQuestData(8020042);
			
			if (IsEventDate("summer2022") && medium2 == "e" && info != "e")
				return " Beat the Heat - 3rd Stage";
			
			if (IsEventDate("summer2022") && info == "e")
				return " Upgrading the Ice Pop";
		}
		else if (quest == 8020044)
		{
			string easy1 = GetQuestData(8020038);
			string medium1 = GetQuestData(8020041);
			
			if (IsEventDate("summer2022") && ((Level >= 46 && info == "" && easy1 == "" && medium1 == "") || (info != "" && info != "e")))
				return " Beat the Heat - 1st Stage";
		}
		else if (quest == 8020045)
		{
			string hard1 = GetQuestData(8020044);
			
			if (IsEventDate("summer2022") && hard1 == "e" && info != "e")
				return " Beat the Heat - 2nd Stage";
		}
		else if (quest == 8020046)
		{
			string hard2 = GetQuestData(8020045);
			
			if (IsEventDate("summer2022") && hard2 == "e" && info != "e")
				return " Beat the Heat - 3rd Stage";
			
			if (IsEventDate("summer2022") && info == "e")
				return " Upgrading the Ice Pop";
		}
		
		return null;
	}

	public override void Run()
	{
		var today = DateTime.UtcNow;
		var startDate = DateTime.Parse("2021-12-31");
		var endDate = DateTime.Parse("2022-01-02");
		
		int i = 0;
		var options = new List<(int Index, string Name)>();
		
		int[] quests = {9000302, 8020020, 8020031, 8020038, 8020039, 8020040, 8020041, 8020042, 8020043, 8020044, 8020045, 8020046};
		
		foreach (int quest in quests)
		{
			string name = Check(quest);
			
			if (name != null)
				options.Add((i, name));
			
			i++;
		}
		
		var icepopChrs = new List<int> {29924,30223,31266,31776,33388,34200,34248,34874,35627,36157,36468,36739,36812,37725,38768,39029,39510,39768,40315,40427,40815,40875,40895,40958,41000,41018,41099,41135,41137,41181,41209,41210,41241,41244,41255,41261,41277,41285,41317,41354,41365,41370,41376,41381,41388,41473};
		
		if (icepopChrs.Contains(chr.ID) && GetQuestData(8020052) != "e")
		{
			options.Add((15, " Redeem another ice pop"));
		}
		
		options.Add((12, " Credit System"));
		options.Add((13, " Tell me about referrals"));
		
		if (CouponCheck())
			options.Add((14, " Check my coupons"));
		
		string dialogue = "Hi, welcome to MG2!";
		
		if (today < endDate)
			dialogue = "Happy New Year from the MG2 team~!";
		
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
			case 1: Thanksgiving(GetQuestData(8020020)); break;
			case 2: NewYear(GetQuestData(8020031)); break;
			case 3: Easy1(GetQuestData(8020038)); break;
			case 4: Easy2(GetQuestData(8020039)); break;
			case 5: Easy3(GetQuestData(8020040)); break;
			case 6: Medium1(GetQuestData(8020041)); break;
			case 7: Medium2(GetQuestData(8020042)); break;
			case 8: Medium3(GetQuestData(8020043)); break;
			case 9: Hard1(GetQuestData(8020044)); break;
			case 10: Hard2(GetQuestData(8020045)); break;
			case 11: Hard3(GetQuestData(8020046)); break;
			case 12: Credit(); break;
			case 13: Referral(); break;
			case 14: Coupon(); break;
			case 15: IcePop(); break;
		}
	}
}
