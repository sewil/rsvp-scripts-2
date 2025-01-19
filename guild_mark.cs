using WvsBeta.Game;
using System.Collections.Generic;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		if (chr.Guild == null || chr.Guild.GuildMaster != chr.ID)
		{
			self.say("Oh... You are not the guild master. Guild Emblems can only be created, deleted or modified by the #rGuild Master#k.");
			return;
		}
		
		var options = new List<(int, string)>();
		
		if (!chr.Guild.HasGuildMark)
			options.Add((0, " I'd like to register a guild emblem."));
		
		else
		{
			options.Add((1, " I'd like to modify my guild emblem."));
			options.Add((2, " I'd like to delete my guild emblem."));
		}
		
		int start = AskMenu("Hi? My name is #bLea#k. I am in charge of #bGuild Emblems#k.#b", options.ToArray());
		
		if (start == 0)
		{
			bool getMark = AskYesNo("You need #r2,500,000 Mesos#k to make a guild emblem. To explain it more, guild emblem is a unique pattern for each guild. It will appear right next to the guild name in the game. So are you going to make a guild emblem?");
			
			if (!getMark)
			{
				self.say("Oh... ok... The emblem would make the guild more united. Do you need more time to prepare the guild emblem? Please come back whenever you want.");
				return;
			}
			
			if (!SetGuildMark(2500000))
			{
				self.say("You don't have enough Mesos. You need #b2,500,000 Mesos#k.");
			}
		}
		else if (start == 1)
		{
			bool changeMark = AskYesNo("Since you already have an emblem, you will only need\r\n#r2,000,000 Mesos#k to modify it. So are you going to change your guild emblem?");
			
			if (!changeMark)
			{
				self.say("Please come back whenever you want.");
				return;
			}
			
			if (!SetGuildMark(2000000))
			{
				self.say("You don't have enough Mesos to modify the guild emblem. You need #b2,000,000 Mesos#k to modify the guild emblem.");
			}
		}
		else if (start == 2)
		{
			bool removeMark = AskYesNo("If you delete the current guild emblem, you can always create a new one. You need #r500,000 Mesos#k to delete a guild emblem. Would you like to delete it?");
			
			if (!removeMark)
			{
				self.say("Please come back whenever you want.");
				return;
			}
			
			if (!RemoveGuildMark(500000))
			{
				self.say("You don't have enough Mesos to delete the guild emblem. You need #b500,000 Mesos#k to delete the guild emblem.");
			}
		}
	}
}