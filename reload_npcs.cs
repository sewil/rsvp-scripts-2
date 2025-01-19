using WvsBeta.Game;
using WvsBeta.Common;
using System;
using System.Collections.Generic;
using WvsBeta.SharedDataProvider.Providers;
using WvsBeta.SharedDataProvider.Templates;

public class NpcScript : IScriptV2 {
    
    public override void Run()
	{
		DataProvider.Load(DataProvider.LoadCategories.NPCs);
		self.say("Done!");
    }
}
