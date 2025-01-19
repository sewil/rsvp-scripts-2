using WvsBeta.Game;
using System.Linq;

public class NpcScript : IScriptV2
{
	public void CantEnterError()
	{
		self.say("There seems to be a door that leads me to the other dimension, but I can't go in for some reason.");
	}

	public void TryEnter(string fsName, int npcId, params int[] jobIds)
	{
		if (GetQuestData(7500000) != "p1" || !jobIds.Contains(Job))
		{
			CantEnterError();
			return;
		}
		
		if (!FieldSet.IsAvailable(fsName) || FieldSet.Instances[fsName].UserCount != 0)
		{
			self.say($"Someone's already inside fighting #b#p{npcId}#'s clone#k. Please come at a later time.");
			return;
		}
		
		FieldSet.Enter(fsName, new Character[1]{chr}, chr);
	}

	public override void Run()
	{
		switch (MapID)
		{
			case 105070001: TryEnter("ThirdJob1", 1022000, 110, 120, 130); break;
			case 100040106: TryEnter("ThirdJob2", 1032001, 210, 220, 230); break;
			case 105040305: TryEnter("ThirdJob3", 1012100, 310, 320); break;
			case 107000402: TryEnter("ThirdJob4", 1052001, 410, 420); break;
			default:
				CantEnterError();
				return;
		}
    }
}