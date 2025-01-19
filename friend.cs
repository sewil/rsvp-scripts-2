using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		int meso = -1;
		
		if (MapID == 104000000) meso = 250000;
		else if (MapID == 220000000) meso = 240000;
		
		bool ask1 = AskYesNo("I hope I can make as much as yesterday ...well, hello! Don't you want to extend your buddy list? You look like someone who'd have a whole lot of friends...well, what do you think? With some money I can make it happen for you. Remember, though, it only applies to one character at a time, so it won't affect any of your other characters on your account. Do you want to do it?");
		
		if (!ask1)
		{
			self.say("I see... Maybe you don't have as many friends as I thought. Hahaha, I'm kidding! Anyway, if you change your mind, feel free to come back and we can do business. If you make more friends that is... hehe...");
			return;
		}
		
		bool ask2 = AskYesNo($"Alright, good call! It's not that expensive actually. #b{meso:n0} mesos and I'll add 5 more slots to your buddy list#k. And no, I won't be selling them individually. Once you buy it, it's going to be permanently on your buddy list. So if you're one of those that needs more space there, then you might as well do it. What do you think? Will you spend {meso:n0} mesos for it?");
		
		if (!ask2)
		{
			self.say($"I see... Maybe you don't have as many friends as I thought. Or could it be you just don't have {meso:n0} mesos on you right now? Either way, if you change your mind, come back and we'll do business. That is, of course, if you have the money... hehe...");
			return;
		}
		
		if (!IncFriendMax(5, -meso))
		{
			self.say($"Hey... Are you sure you have #b{meso:n0} mesos#k?? If so, make sure you haven't expanded your friends list to the fullest. Even if you have the money, the most you can have on your friends list is #b150#k.");
			return;
		}
		
		self.say("Alright! Your buddy list will have 5 extra slots by now. Check and see for it yourself. And if you still need more room on your buddy list, you know who to find. Of course, it isn't going to be for free...well, so long...");
	}
}