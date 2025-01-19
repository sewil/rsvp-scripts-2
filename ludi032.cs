using WvsBeta.Game;

// 2041020 Mac the Mechanic
public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1004300);
		
		if (Level < 40)
		{
			self.say("Great weather today. I'm #b#p2041020##k, working here at the Toy Factory. I'm in charge of making blueprints for the machines around here, as well as fixing them if necessary.");
			return;
		}
		
		if (quest == "")
		{
			bool start = AskYesNo("Oh my gosh, what can I do? I lost something very important, the one that'll help me fix the machinery. Without that, I can't do a thing ... can you help me out?");
			
			if (!start)
			{
				self.say("I know it's hard to say yes to a favor from stranger. That's alright. I'll try asking someone else. But if you feel a change of heart, then go ahead and talk to me.");
				return;
			}
			
			SetQuestData(1004300, "s");
			self.say("You're really helping me out? Awesome! I told you I'm the head engineer in this factory, right? Well, the stuff I need to work with went missing a few days ago. What I lost were the blueprints for the machines in this factory, as well as documents detailing the references I need to fix the machines.");
			self.say("The one I'm suspicious of is the knight-look-alike monster called #b#o9300011##k. I don't think it's a work of a regular monster, though. I think whoever stole #b#t4031130##k, wound up making a shadow of himself and hide inside the box with secret path.");
			self.say("The secret path can be reached by destroying the boxes of the toy factory. If you open up a box inside the secret path, then you'll face a bunch of #b#o9300011##k coming right at you. One of them will cough up the #b#t4031130##k. I know you can do it!");
		}
		else if (quest == "s")
		{
			if (ItemCount(4031130) < 1)
			{
				self.say("You're back, but I don't think you have found #b#t4031130##k yet. Break the boxes you see at the Toy Factory, and you may find yourself a secret path every once in a while. Please open the box, and kill the #b#o9300011##k that pops out so you can bring #b#t4031130##k back with you.");
				return;
			}
			
			self.say("Hey, you're back! HEY! That's the #b#t4031130##k that I lost!! Phew ... I can't believe it's here again. Thank you so much for your hard work. Here's something for you.");
			
			if (!Exchange(0, 4031130, -1, 2100019, 5))
			{
				self.say("Please make sure you have room in your use inventory, okay?");
				return;
			}
			
			AddEXP(6200);
			SetQuestData(1004300, "e");
			QuestEndEffect();
			self.say("What do you think of the #b5 #t2100019#s#k? Inside the sack you'll find #b#o9300011##k and #b#o3210203##k. If you use it, those toys will come out and cause a scene, so you may want to be at a quiet place where you can be ready to handle it. Again, please be careful with it.");
			self.say("Let's see the documents ... thankfully, other than a few, the rest are all in here. The ones that aren't here, probably the ones that stole the manual lost it on their way out. I can't do anything about that. I can make another one. Thank you so much for helping me out. I'll see you around.");
		}
		else if (quest == "e")
		{
			self.say("You're back. I've been busy here working thanks to the documents you got me. Oh, and this time, I hid it in a safe just in a case. I have to get back to work now. See you around!");
		}
	}
}