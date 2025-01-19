using WvsBeta.Game;
using WvsBeta.Common;
using System.Linq;
using WvsBeta.Game.GameObjects;

public class NpcScript : IScriptV2
{
    public override void Run()
    {
        if (Level > 30 && GetMonsterBookCount(8000) < 5)
        {
			self.say("Hmm... It looks like you're missing some #b#t2388000#s#k in your collection. For #b100,000 mesos#k, I can give you one.");
			
			if (!AskYesNo("What do you think? Do you want to buy a #b#t2388000##k for #b100,000 mesos#k?"))
			{
				self.say("Ok, come back and talk to me if you change your mind.");
				return;
			}
			
			if (chr.Inventory.Mesos < 100000)
			{
				self.say("Sorry, it looks like you don't have enough mesos.");
				return;
			} 
			
			GiveMonsterBookCard(2388000);
			TakeMesos(100000);
			return;
        }
        
        if (chr.PartyID == 0)
        {
            self.say("You are not in a party. You can only do the quest when you're in a party.");
            return;
        }

        var party = PartyData.Parties[chr.PartyID];

        if (party.Leader != chr.ID)
        {
            self.say("How about you and your party members collectively beating a quest? Here you'll find obstacles and problems where you won't be able to beat it unless with great teamwork. If you want to try it, please tell the #bleader of your party#k to talk to me.");
            return;
        }

        if (party.GetAvailablePartyMembers().Count() != 3 && party.GetAvailablePartyMembers().Count() != 4)
        {
            self.say("Your party doesn't have four members. Come back when you have at least three members.");
            return;
        }

        var partyMembers = chr.Field.GetInParty(chr.PartyID).ToArray();
		
        if (partyMembers.Length != party.GetAvailablePartyMembers().Count())
        {
            self.say("Not all of your party members are here. Come back and talk to me again when everyone is here.");
            return;
        }

        if (partyMembers.Any(c => c.PrimaryStats.Level < 21 || c.PrimaryStats.Level > 30))
        {
            self.say("Someone in your party is not between levels 21 ~30. Please check again.");
            return;
        }

        if (FieldSet.Instances["Party1"].UserCount != 0 || !FieldSet.IsAvailable("Party1"))
        {
            self.say("Another party has entered to complete the quest. Please try again later.");
            return;
        }
		
		if (false) {
			if (WvsBeta.Common.Constants.MAPLE_VERSION == 17) partyMembers = null; // Fix for entering with party in v.17, this should default to party members
			FieldSet.Enter("Party1", partyMembers, chr);
		} else {
			var fs = FieldSet.Instances["Party1"];
			if (!fs.TryEnter(partyMembers, 0, chr.ID)) {
				OK("Error starting fieldset");
				return;
			}
			fs.StartEvent(chr);
			fs.TryToRunInitScript = true;
		}
    }
}