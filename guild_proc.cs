using System;
using WvsBeta.Game;
using WvsBeta.Game.GameObjects;
using System.Linq;
using WvsBeta.Game.Packets;

public class NpcScript : IScriptV2
{
	const int guildRegistrationFee = 500000;
	private bool GuildCheck(Character[] partyMembers)
	{
		if (chr.IsGM) return true;
		
		var party = PartyData.Parties[chr.PartyID];
		
		if (party.Leader != chr.ID)
		{
			self.say("Please let the party leader talk to me if you want to create a guild.");
			return false;
		}

		if (partyMembers.Length < 6)
		{
			self.say("It seems like either you don't have enough members in your party, or some of your members are not here. I need all 6 party members here to register you as a guild. If your party can't even coordinate this simple task, you should think twice about forming a guild.");
			return false;
		}
		
		if (partyMembers.Any(character => character.Guild != null))
		{
			self.say("There seems to be a traitor among us. Someone in your party is already part of another guild. To form a guild, all of your party members must be out of their guild. Come back when you have solved the problem with the traitor.");
			return false;
		}
		
		if (Mesos < guildRegistrationFee)
		{
			self.say("Do you have enough mesos or people to form a guild?");
			self.say("Check again. You need to pay the service fee to make a guild and register it.");
			return false;
		}
		
		return true;
	}
	
	public string ProcessName(string promptText)
	{
		while (true)
		{
			var name = AskText("", 4, 12, promptText).Trim();

			if (name.Length < 4 || name.Length > 12)
			{
				promptText = "That guild name is not valid. Please choose another name.";
				continue;
			}
			
			if(name.Any(x =>
			{
				if (x >= 'a' && x <= 'z') return false;
				if (x >= 'A' && x <= 'Z') return false;
				if (x >= '0' && x <= '9') return false;
				return true;
			}))
			{
				promptText = "You can't have special characters in the guild name. Please choose another name.";
				continue;
			}

			if (Server.Instance.Guilds.Any(guild => guild.Name == name))
			{
				promptText = "The name is already in use... Please try other ones....";
				continue;
			}
			
			return name;
		}
	}
	
	public override void Run()
	{
		if (chr.Guild == null)
		{
			self.say("Hey ... are you interested in GUILDS by any chance?");
			
			var start = AskMenu("#b",
				(0, " What's a guild?"),
				(1, " What do I do to form a guild?"),
				(2, " I want to start a guild")
			);
				
			if (start == 0)
			{
				self.say("A guild is ... you can think of it as a small crew, a crew full of people with similar interests and goals, except it will be officially registered in our Guild Headquarters and be accepted as a valid GUILD.");
			}
			else if (start == 1)
			{
				self.say($"To make your own guild, you'll need to be at least level 10. You'll also need to have at least {guildRegistrationFee:n0} mesos with you. That's the fee you need to pay in order to register your guild.");
				self.say("To make a guild you'll need a total of 6 people. Those 6 should be in a same party, and the party leader should come talk to me. Please be aware that the party leader also becomes the Guild Master. Once the Guild Master is assigned, the position remains the same until the Guild breaks up.");
				self.say($"Once the 6 people are gathered up, you'll need {guildRegistrationFee:n0} mesos. This is the fee you pay to register your guild");
				self.say("Alright, to register your guild, bring 6 people here~ You can't make one without all 6...Oh, and of course, the 6 cannot be a part of some other guild!!");
			}
			else if (start == 2)
			{
				bool startGuild = AskYesNo("Alright, now, do you want to make a guild?");
				
				if (!startGuild) return;

				if (Level < 10)
				{
					self.say("Hmm ... I don't think you have the qualifications to be a master of the guild. Please train more to become the Master of the guild.");
					return;
				}
				
				if (chr.PartyID == 0)
				{
					self.say("I don't care how tough you think you are... In order to form a guild, you need to be in a party of 6. Create a party of 6, and then bring all your party members back here if you are indeed serious about forming a guild.");
					return;
				}
				
				var partyMembers = chr.Field.GetInParty(chr.PartyID).ToArray();
				
				if (!GuildCheck(partyMembers)) return;

				var name = ProcessName("Enter the name of your guild, and your guild will be created. The guild will also be officially registered under our Guild Headquarters, so best of luck to you and your guild!");
				if (name == null) return;
				bool finalize = AskYesNo($"Are you certain you, {chr.Name}, want to pay #r{guildRegistrationFee:n0}#k mesos to start the guild #b{name}#k?");
				
				if (!finalize) return;
			
				if (!GuildCheck(partyMembers)) return;
				
				if (!CreateGuild(name, partyMembers, -guildRegistrationFee))
				{
					self.say("Something went wrong while registering your guild. Please check if the guild name isn't used yet, or that you may not have enough mesos.");
					return;
				}
				
				self.say($"Congratulation~ {name} guild has been registered to our guild office... I wish the best luck for you guys~");
			}
		}
		else
		{
			var guild = chr.Guild;
			
			int selection = AskMenu("Now, how can I help you?#b",
				(0, " I want to expand my guild"),
				(2, " I want to rename my guild"),
				(1, " I want to break up my guild")
			);
			
			if (guild.GuildMaster != chr.ID)
			{
				self.say("Hey, you're not the Guild Master!! This decision can only be made by the Guild Master.");
				return;
			}
			
			if (selection == 0)
			{
				var guildCapacity = guild.Capacity;
				
				if (guildCapacity >= 100)
				{
					self.say("Your guild seems to have grown quite a bit. I cannot expand your guild any longer...");
					return;
				}
				
				self.say("Are you here to expand your guild? Your guild must have grown quite a bit~ To expand your guild, the guild has to be re-registered in our Guild Headquarters, and that'll require some service fee ...");

				var fee = guildCapacity switch
				{
					10 => 500000,
					15 => 1500000,
					20 => 2500000,
					25 => 3500000,
					30 => 4500000,
					35 => 5000000,
					40 => 5000000,
					45 => 5000000,
					50 => 5000000,
					55 => 5000000,
					60 => 5000000,
					65 => 5000000,
					70 => 5000000,
					75 => 5000000,
					80 => 5000000,
					85 => 5000000,
					90 => 5000000,
					95 => 5000000,
					_ => 0
				};

				var expand = AskYesNo($"The service fee will only cost you #r{fee:n0} mesos#k. Would you like to expand your guild?");
				
				if (!expand) return;

				if (!ResizeGuild((byte) (guildCapacity + 5), -fee))
				{
					self.say("Please check again. You'll need to pay the service fee in order to expand your guild and re-register it....");
					return;
				}
				
				self.say($"Congratulation~ The number of guild members has now increased to {guildCapacity + 5} ... Please come back to me whenever you want to expand your guild further.");
			}
			else if (selection == 1)
			{
				var price = 200000;
				bool endGuild = AskYesNo($"Are you sure you want to break up your guild? Really ... just remember, once you break up your guild, that guild will be gone forever. Oh, and one thing. If you want to break up your guild, you'll have to pay a {price:n0} meso service fee. Are you sure you still want to do it?");
				
				if (!endGuild)
				{
					self.say("Good thinking. I wouldn't like to break up my guild that's already so strong...");
					return;
				}
				
				if (!DisbandGuild(-price))
				{
					self.say("Hey, you don't have money for the service... are you sure you have enough money there?");
					return;
				}

				self.say("The guild has been disbanded.. Please come back to me when you want to make a guild, again..");
			}
			else if (selection == 2)
			{
				var price = 500000;
				var oncePerDayQuestID = 7600001;
				if (GetQuestData(oncePerDayQuestID) == "")
					SetQuestData(oncePerDayQuestID, "2021-05-28");
				
				string savedDate = GetQuestData(oncePerDayQuestID);
				var renameDate = DateTime.Parse(savedDate);
				
				bool rename = AskYesNo($"Are you here to change the name of your guild? I can do this for you, but I'll need to modify your entry in the Compendium of Guilds. You can only change the name of your guild #ronce per day#k, and you'll have to pay a {price:n0} meso service fee. Are you sure you still want to do it?");
				
				if (!rename)
				{
					self.say($"Have you changed your mind? That's alright, I think '{guild.Name}' is a great name, anyway.");
					return;
				}
				
				if (DateTime.UtcNow < renameDate)
				{
					self.say("It seems that you have already changed your guild's name today. Please come back again tomorrow.");
					return;
				}
				
				var name = ProcessName("Enter the name you would like as your new guild name. Once you have chosen a new name it will be officially re-registered under our Guild Headquarters.");
				
				bool finalize = AskYesNo($"Are you certain you, {chr.Name}, want to pay #r{price:n0}#k mesos to change your guild's name from {guild.Name} to {name}?");
				
				if (!finalize) return;
				
				if (!RenameGuild(name, -price))
				{
					// Could be either that the guild name is already taken or no money
					// Just give this error, we threw an error in the server logs
					self.say("Hey, you don't have money for the service... are you sure you have enough money there?");
					return;
				}
				
				SetQuestData(oncePerDayQuestID, DateTime.UtcNow.AddDays(1).ToString("yyyy-MM-dd"));
				self.say("The guild name change has been processed!");
			}
		}
	}
}