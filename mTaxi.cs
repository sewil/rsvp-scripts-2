using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		self.say("Hey! This taxi is for VIP customers only. Instead of simply taking you to different towns, like other taxis, we offer a much better service, worthy of the VIP class. It's a little bit more expensive, but... for just 10,000 mesos, we take you safely to the #bAnt Tunnel#k.");
		
		int fee = 0;
		bool askStart = false;
		
		if (Job == 0)
		{
			askStart = AskYesNo("We have a special 90% discount for beginners. The Ant Tunnel is located at the very bottom of the Dungeon, in the center of Victoria Island, there's a #b24 Hr Mobile Store#k there. Would you like to go there for #b1,000 mesos#k?");
			fee = 1000;
		}
		else
		{
			askStart = AskYesNo("The standard rate applies to all non-beginners. The Ant Tunnel is located at the very bottom of the Dungeon, in the center of Victoria Island, there's a #p1061001#. Would you like to go there for #b10,000 mesos#k?");
			fee = 10000;
		}
		
		if (!askStart)
		{
			self.say("This town also has a lot to offer. Look for us if and when you feel the need to go to the Ant Tunnel Park");
			return;
		}
		
		if (!Exchange(-fee))
		{
			self.say("It looks like you don't have enough money. Sorry, but you won't be able to use the taxi without money.");
			return;
		}
		
		ChangeMap(105070001);
	}
}