using WvsBeta.Game;

// 2050019 Meteorite 6
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1003402);
		
		if (quest == "" || quest == "e")
		{
			self.say("It appears to be a meteorite that was thrown from space, but it's so destroyed that nothing useful can be found.");
			return;
		}
		
		string checkInfo = quest.Substring(5, 1);
			
		if (checkInfo == "1")
		{
			self.say("It appears to be a meteorite that was thrown from space, but a sample has already been extracted from it. Look for different meteorite samples.");
			return;
		}
		
		if (!Exchange(0, 4031117, 1))
		{
			self.say("It appears to be a meteorite that was thrown from space. After further investigation, a sample in good condition was extracted, but the item couldn't be placed in the etc. inventory because it was full.");
			return;
		}
		
		string newInfo = quest.Remove(5, 1).Insert(5, "1");
		
		SetQuestData(1003402, newInfo);
		self.say("It appears to be a meteorite that was thrown from space. After further investigation, a sample in good condition was extracted.");
	}
}