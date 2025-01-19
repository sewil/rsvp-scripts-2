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
		if (GetFieldsetVar("Party5", "stage2") == "clear")
		{
			Message("I don't think there's anything else to do in this room.");
			return;
		}
		
		if (IsLeader)
		{
			FieldSet.Characters.ForEach(character =>
			{
				Message(character, "The leader of the party has entered the <Walkway>.");
			});
			
			MapPacket.PlayPortalSE(chr);
			ChangeMap(920010200, "st00");
		}
		else
		{
			if (UserCount(920010200) >= 1)
			{
				MapPacket.PlayPortalSE(chr);
				ChangeMap(920010200, "st00");
			}
			else
			{
				Message("You can only enter locations where you'll find the party leader.");
			}
		}
	}
}