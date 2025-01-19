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
		if (GetFieldsetVar("Party5", "stage6") == "clear")
		{
			Message("There is nothing left to do in this room.");
			return;
		}
		
		if (IsLeader)
		{
			FieldSet.Characters.ForEach(character =>
			{
				Message(character, "The party leader entered the <Lounge>.");
			});
			
			MapPacket.PlayPortalSE(chr);
			ChangeMap(920010600, "st00");
		}
		else
		{
			int count = UserCount(920010600) + UserCount(920010601) + UserCount(920010602) + UserCount(920010603) + UserCount(920010604);
			
			if (count >= 1)
			{
				MapPacket.PlayPortalSE(chr);
				ChangeMap(920010600, "st00");
			}
			else
			{
				Message("You can only enter locations where you'll find the party leader.");
			}
		}
	}
}