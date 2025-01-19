using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		self.say("Pass through here and you will find the Central Dungeon of Victoria Island. Be careful...");
		
		string quest = GetQuestData(1000201);
		
		if (quest == "mc")
		{
			self.say("Hmmm... so you want to know how to get #b#t4021009##k, #b#t4003002##k, #b#t4001005##k and #b#t4001006##k? What do you plan to do with those precious materials? I've heard of them... since I studied a little about the island before working as a guard...");
			self.say("#b#t4021009##k and #b#t4003002##k are... I have a feeling that the fairies of #m101000000# must know something about them. It's from fairies if it really is the #t4003002# that never melts that we're talking about... they're probably making #t4021009# too.");
			self.say("#b#t4001005##k and #b#t4001006##k are the problem. The monsters probably have them, since they've been roaming around here for a long time... as for the #t4001005#... Ah, yes! The Gollems must have it, since they were created by wizards a long time ago...");
			self.say("#b#t4001006##k ... I've heard about it, a flame that resembles a feather... it has something to do with a dragon that breathes fire, something like that... anyway, it is very ruthless, so it will be difficult for you to take #t4001006# from it. Good luck!");
		}
	}
}