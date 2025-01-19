using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string warp = GetQuestData(9000000);
		
		if (warp != "maple" && warp != "victoria" && warp != "ossyria" && warp != "ludi" && warp != "cody")
		{
			self.say("I don't think you talked to #p9000001# or #p9000000#. HOW did you get here in the first place??? You... ?!?!");
			return;
		}
		
		if (ItemCount(4031019) < 1)
		{
			self.say("Bam bam bam bam!!! You have won the game from the#b EVENT#k. Congratulations on making it this far!");
			self.say("You'll be awarded the #b#t4031019##k as the winning prize. On the scroll, it has a secret information written in ancient characters.");
			self.say("The Scroll of Secrets can be deciphered by #r#p9000007##k or \r\n#rGeenie#k at Ludibrium. Bring it with you, and something good's bound to happen.");
			
			if (!ExchangeEx(0, "4031019,Period:43200", 1))
			{
				self.say("I think your etc. inventory is full. Please make room there and then talk to me.");
				return;
			}
		}
		else
		{
			self.say("You already have the #r#t4031019##k. This scroll is full of an incredible magic power, so powerful that you should always carry it with you. Go and take this scroll to #r#p9000007##k right away.");
		}
		
		AddEXP(2011069705);
		RemoveQuest(9000000);
		
		if (warp == "maple") ChangeMap(60000);
		else if (warp == "victoria") ChangeMap(104000000);
		else if (warp == "ossyria") ChangeMap(200000000);
		else if (warp == "ludi") ChangeMap(220000000);
		else if (warp == "cody") ChangeMap(100000110);
	}
}