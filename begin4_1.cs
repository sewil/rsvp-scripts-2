using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(5);
		
		if (quest == "")
		{
			self.say("Ohh, a new traveler, huh? Don't you want to learn the ways of hunting? The Jr. Stoneball's you see are normally too powerful a monster to be here, or for you to handle. The ones you see here, however, are devoid of any power, thanks to Hines, the head of all magicians who sealed up their power. These are here for the sole purpose of training. Here's your task: Take one down, pick up its dropping, and go see \r\n#b#p2002##k, who should be up there somewhere. It's that easy.");
			
			SetQuestData(5, "001");
			self.say("As you can see through the Minimap (#bM#k), located on the left corner of the screen, you'll see something green blink on the northeast side of the map. That's where #b#p2002##k is. You'll run into a Jr. Stoneball on your way to seeing #b#p2002##k. Defeat it, pick up 1 #t4000142#, then see #p2002#.");
		}
		else if (quest == "end")
		{
			self.say("So... did you see Peter?");
		}
		else
		{
			self.say("As you can see through the Minimap (#bM#k), located on the left corner of the screen, you'll see something green blink on the northeast side of the map. That's where #b#p2002##k is. You'll run into a Jr. Stoneball on your way to seeing #b#p2002##k. Defeat it, pick up 1 #t4000142#, then see #p2002#.");
		}
	}
}