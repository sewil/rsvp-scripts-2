using WvsBeta.Game;
using WvsBeta.Common;
using System;
using System.Collections.Generic;
using WvsBeta.SharedDataProvider.Providers;
using WvsBeta.SharedDataProvider.Templates;

public class NpcScript : IScriptV2 {
    
    public override void Run()
	{
		var errors = "Unable to DC: \r\n";
		foreach (var c in Server.Instance.CharacterList.Values)
		{
			if (c == chr) continue;
			try
			{
				c.Disconnect();
			}
			catch
			{
				errors += c.ToString() + "\r\n";
			}
		}

		self.say(errors);
    }
}
