using WvsBeta.Game;
using WvsBeta.Common;
using System;
using System.Collections.Generic;
using WvsBeta.SharedDataProvider.Providers;
using WvsBeta.SharedDataProvider.Templates;

public class NpcScript : IScriptV2 {
    
    public override void Run()
	{
		Server.Instance.CharacterList.Values.ForEach(x => x.Storage.Load());
		self.say("Reload storages");
    }
}