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
			if (ItemCount(4001055) >= 1)
			{
				MapPacket.PlayPortalSE(chr);
				FieldSet.Characters.ForEach(character =>
				{
					character.ChangeMap(920010100, "st02");
				});
			}
			else
			{
				Message("We need the power of the Grass of Life.");
			}
		}
		else
		{
			Message("Only the party leader can make the decision to leave this room or not.");
		}
	}
}