using System;
using System.Collections.Generic;
using System.Linq;
using WvsBeta.Game;
using WvsBeta.Game.GameObjects;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		var ParentFieldSet = chr.Field.ParentFieldSet;
		// Based off "/start" command processing
        if (ParentFieldSet == null)
        {
            self.say("This event map has no fieldset?");
            return;
        }

    	// Prepare data; temporarily set ForcedReturn to the invalidmap to prevent people from getting kicked out.

        var frDict = new Dictionary<Map, int>();

        foreach (var m in ParentFieldSet.Maps.Values) {
        	frDict[m] = m.ForcedReturn;
        	m.ForcedReturn = 999999999;
    	}

    	var started = ParentFieldSet.StartEvent(chr);

    	// Now fix em all
        foreach (var kvp in frDict) {
    		kvp.Key.ForcedReturn = kvp.Value;
		}

    	if (!started)
    	{
        	self.say("Unable to start fieldset. Check logs.");
        	return;
        }

        self.say("Fieldset started!");
	}
}
