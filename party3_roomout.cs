using WvsBeta.Game;
using WvsBeta.Game.GameObjects;
using WvsBeta.Common;

public class Portal : IScriptV2
{
	private PartyData Party => PartyData.Parties[chr.PartyID];
	private FieldSet FieldSet => chr.Field.ParentFieldSet;
	private bool IsLeader => Party.Leader == chr.ID;
	
	private void RoomOut(string retportal, string retname)
	{
		FieldSet.Characters.ForEach(character =>
		{
			Message(character, $"The leader of the party has left {retname}.");
		});
		
		MapPacket.PlayPortalSE(chr);
		Map(MapID).Characters.ForEach(character =>
		{
			character.ChangeMap(920010100, retportal);
		});
	}
	
	public override void Run()
	{
		if (!IsLeader)
		{
			Message("Only the party leader can make the decision to leave this room or not.");
			return;
		}
		
		switch(MapID)
		{
			case 920010200: RoomOut("in00", "<Walkway>"); break;
			case 920010300: RoomOut("in01", "<Storage>"); break;
			case 920010400: RoomOut("in02", "<Lobby>"); break;
			case 920010500: RoomOut("in03", "<Sealed Room>"); break;
			case 920010600:
				if (UserCount(920010601) + UserCount(920010602) + UserCount(920010603) + UserCount(920010604) != 0)
				{
					Message("You can't leave because someone in your party is still inside.");
					return;
				}
				
				RoomOut("in04", "<Lounge>");
				break;
				
			case 920010700: RoomOut("in05", "<On the Way Up>"); break;
			case 920011000: RoomOut("in06", "<Room of Darkness>"); break;
		}
	}
}