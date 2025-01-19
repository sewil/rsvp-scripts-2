using WvsBeta.Game;
using WvsBeta.Game.GameObjects;

class Portal : IScriptV2
{
	private PartyData Party => PartyData.Parties[chr.PartyID];
	private FieldSet FieldSet => chr.Field.ParentFieldSet;
	
	public override void Run()
	{
		string result = FieldSet.GetVar("zakum");
		
		if (result == "yes")
		{
			if (!Exchange(0, 4031061, 1, 2030007, 5))
			{
				Message("Your etc. or use inventory is full, so you can't move on to the next map.");
				return;
			}
			
			AddEXP(20000);
			SetQuestData(7000000, "end");
			
			MapPacket.PlayPortalSE(chr);
			ChangeMap(280090000, "st00");
		}
		else if (result == "no")
		{
			if (!Exchange(0, 4031061, 1))
			{
				Message("Your etc. inventory is full, so you can't move on to the next map.");
				return;
			}
			
			AddEXP(12000);
			SetQuestData(7000000, "end");
			
			MapPacket.PlayPortalSE(chr);
			ChangeMap(280090000, "st00");
		}
		else
		{
			Message("The portal is closed for now. You'll need to clear level 1 first before moving on.");
		}
	}
}