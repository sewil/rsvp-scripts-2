using WvsBeta.Game;
using WvsBeta.Common;
using System;
using System.Collections.Generic;
using WvsBeta.SharedDataProvider.Providers;
using WvsBeta.SharedDataProvider.Templates;

public class NpcScript : IScriptV2 {
    
    public override void Run()
	{
		DataProvider.NPCs.Values.ForEach(x => {
			if (x.Trunk > 0) {
				x.Trunk = 0;
				x.Quest = "storage";
			}
		});
		self.say("Made all storage npcs unusable");
    }
}