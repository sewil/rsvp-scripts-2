using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(7000000);
		
		if (quest == "end")
		{
			self.say("Great job clearing level 1! Alright ... I'll send you off to where #b#p2030008##k is. Before that!! Please be aware that the various, special items you have acquired here will not be carried out of here. I'll be taking away those items from your item inventory, so remember that. See ya!");
		}
		else
		{
			self.say("Must have quit midway through. Alright, I'll send you off right now. Before that!! Please be aware that the various, special items you have acquired here will not be carried out of here. I'll be taking away those items from your item inventory, so remember that. See ya!");
		}
		
		int item1 = ItemCount(4001015);
		int item2 = ItemCount(4001016);
		int item3 = ItemCount(4001018);
		
		if (item1 > 0) Exchange(0, 4001015, -item1);
		if (item2 > 0) Exchange(0, 4001016, -item2);
		if (item3 > 0) Exchange(0, 4001018, -item3);
		
		ChangeMap(211042300);
	}
}