using WvsBeta.Game;
using System.Linq;
using WvsBeta.Game.GameObjects;

public class NpcScript : IScriptV2
{
    public override void Run()
    {
        if (Level > 50 && GetMonsterBookCount(8004) < 5)
        {
			self.say("It seems like you're missing some #b#t2388004#s#k in your collection. For #b250,000 mesos#k, I can give you one.");

            if (!AskYesNo("What do you think? Do you want to buy a #b#t2388004##k for \r\n#b250,000 mesos#k?"))
            {
                self.say("Ok, come back and talk to me if you change your mind.");
                return;
            }

            if (Mesos < 250000)
            {
                self.say("Sorry, it looks like you don't have enough mesos.");
                return;
            }

            GiveMonsterBookCard(2388004);
            TakeMesos(250000);
            return;
        }

        if (chr.PartyID == 0)
        {
            self.say("From this point on, this place is full of obstacles and dangerous monsters. Therefore, I can't let you go any further. However, if you're interested in saving us and bringing peace back to Ludibrium, that's another story. If you want to defeat the powerful creature that lives at the top, please gather the members of your party. It will not be easy, but... I think you can do it.");
            return;
        }

        var party = PartyData.Parties[chr.PartyID];

        if (party.Leader != chr.ID)
        {
            self.say("From this point on, this place is full of obstacles and dangerous monsters. Therefore, I can't let you go any further. However, if you're interested in saving us and bringing peace back to Ludibrium, that's another story. If you want to defeat the powerful creature that lives at the top, please gather the members of your party. It will not be easy, but... I think you can do it.");
            return;
        }
		
		if (party.GetAvailablePartyMembers().Count() < 5)
        {
            self.say("Your party can't participate in the quest because it doesn't have at least 5 members. Please gather 5 people for your party.");
            return;
        }

        var partyMembers = chr.Field.GetInParty(chr.PartyID).ToArray();
		
		if (partyMembers.Length != party.GetAvailablePartyMembers().Count())
        {
            self.say("Not all of your party members are here. Come back and talk to me again when everyone is here.");
            return;
        }

        if (partyMembers.Any(c => c.PrimaryStats.Level < 35 || c.PrimaryStats.Level > 50))
        {
            self.say("Someone in your party is not between levels 35 ~50. Please resolve this and try again.");
            return;
        }

        if (FieldSet.Instances["Party3"].UserCount != 0 || !FieldSet.IsAvailable("Party3"))
        {
            self.say("Another party is inside doing the quest. Please try again when the quest becomes available.");
            return;
        }

        foreach (var character in partyMembers)
        {
            int item1 = character.Inventory.ItemCount(4001022);
            int item2 = character.Inventory.ItemCount(4001023);

            if (item1 > 0) character.Inventory.Exchange(this, 0, 4001022, -item1);
            if (item2 > 0) character.Inventory.Exchange(this, 0, 4001023, -item1);
        }
		
		if (WvsBeta.Common.Constants.MAPLE_VERSION == 17) partyMembers = null; // Fix for entering with party in v.17, this should default to party members
		FieldSet.Enter("Party3", partyMembers, chr);
        return;
    }
}