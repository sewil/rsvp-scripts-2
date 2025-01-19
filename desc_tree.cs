using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		self.say("Do you see the group of snowmen standing over there? Go talk to one of them, and it'll take you to the famous Christmas tree~ It's just humongous! While there, you can decorate the tree using various kinds of ornaments. What do you think? Sounds fun, right?");
		self.say("Only 6 can be in the map at one time, and you can't #btrade or open a store#k there. Also, only you can pick up the ornaments that you have dropped, so don't worry about losing your ornaments here.");
		self.say("Of course, the items you drop in the map will never disappear. When you are ready, you can leave through the snowman that is inside. You will recover all the items that you dropped inside the map when you leave, so don't worry about picking up all your items. Isn't that sweet?");
		self.say("Well then, go see #p2002001#, buy some Christmas ornaments there, and then decorate the tree with those~ Oh yeah! The biggest and most beautiful ornament can't be bought from him. It's probably been... taken by a monster! Dum dum dum~");
	}
}