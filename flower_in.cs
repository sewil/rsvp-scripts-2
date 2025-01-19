using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		int[] maps = {105040314, 105040312, 105040310};
		int[] quests = {1000902, 1000901, 1000900};
		int[] flowers = {4031028, 4031026, 4031025};
		
		for (int i = 0; i < maps.Length; i++)
		{
			int map = maps[i];
			int flower = flowers[i];
			string quest = GetQuestData(quests[i]);
			
			if (quest != "")
			{
				if (ItemCount(flower) >= 1)
				{
					self.say($"I lay my hand on the statue, but nothing happens. It must be because of the #t{flower}#s that I have, it seems they interfere with the power of the statue.");
					return;
				}
				
				bool askEnter = AskYesNo("Once I lay my hand on the statue, a strange light covers me and it feels like I am being sucked into somewhere else. Is it okay to be moved to somewhere else randomly just like that?");
				
				if (!askEnter)
				{
					self.say("Once I take my hand off the statue, it returns to normal, as if nothing happened.");
					return;
				}
				
				ChangeMap(map);
				return;
			}
		}
		
		self.say("I lay my hand on the statue, but nothing happens.");
	}
}