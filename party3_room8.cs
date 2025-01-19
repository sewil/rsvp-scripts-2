using WvsBeta.Game;
using WvsBeta.Game.GameObjects;
using WvsBeta.Common;

public class Portal : IScriptV2
{
	private PartyData Party => PartyData.Parties[chr.PartyID];
	private FieldSet FieldSet => chr.Field.ParentFieldSet;
	private bool IsLeader => Party.Leader == chr.ID;
	
	public override void Run()
	{
		if (IsLeader)
		{
			FieldSet.Characters.ForEach(character =>
			{
				Message(character, "The leader of the party has entered the <Room of Darkness>.");
			});
			
			MapPacket.PlayPortalSE(chr);
			ChangeMap(920011000, "st00");
		}
		else
		{
			if (UserCount(920011000) >= 1)
			{
				MapPacket.PlayPortalSE(chr);
				ChangeMap(920011000, "st00");
			}
		}
	}
}