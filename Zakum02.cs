using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string today = DateTime.UtcNow.ToString("yyyyMMdd");
		
		self.say("How did you go through such treacherous road to get here?? Incredible! #b#t4031062##k is here. Please give this to my brother. You'll finally be meeting up with the one you've been looking for, very soon.");
		
		DateTime minTime = DateTime.Parse(GetQuestData(7000005));
		
		if (DateTime.UtcNow > minTime)
		{
			if (!Exchange(0, 4031062, 1))
			{
				self.say("Your etc. inventory seems to be full. Please make room in order to receive the item.");
				return;
			}
			
			string retry = GetQuestData(7000007);
			
			if (retry == "")
			{
				SetQuestData(7000007, $"1{today}");
			}
			else
			{
				string date = retry.Substring(1, 8);
				int retryCount = Int32.Parse(retry.Substring(0, 1)) + 1;
				
				SetQuestData(7000007, $"{retryCount}{date}");
			}
			
			AddEXP(15000);
			SetQuestData(7000001, "end");
			ChangeMap(211042300);
		}
		else
		{
			Server.Instance.ServerTraceDiscordReporter.Enqueue($"{chr.Name} has completed the Zakum Jump Quest earlier than expected!");
			self.say("For completing this quest way too early, you will not be rewarded for your effort.");
			ChangeMap(211042300);
		}
	}
}