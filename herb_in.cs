using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest1 = GetQuestData(1000700);
		string quest2 = GetQuestData(1000701);
		
		if (quest1 == "")
		{
			self.say("You want to enter? You must have heard about the precious medicinal herbs here, right? But I can't let a stranger like you in here, who doesn't even know that I own this land. Sorry, but that's all.");
			return;
		}
		
		if (quest1 == "1_00" || quest1 == "1_99")
		{
			if (quest2 == "")
			{
				self.say("It's you from the other day... is #p1061005# working hard on the diet medicine? Anyways, I was kind of surprised that you went through this place without trouble. As a reward, I'll let you stay for a while without paying. You can even find some cool items there, along the way.");
				ChangeMap(101000100);
			}
			else if (quest2 == "2_00" || quest2 == "2_99")
			{
				self.say("It's you from the other day... is #p1061005# working hard on the anti-aging medicine? Anyways, I was kind of surprised that you went through this place without trouble. As a reward, I'll let you stay for a while without paying. You can even find some cool items there, along the way.");
				self.say("Oh yes... #p1032100# from this very town tried to sneak in. I grabbed her and in the process, #p1032100# dropped something inside. I tried to find it, but I have no idea where it is. What do you think about searching for it?");
				ChangeMap(101000102);
			}
			else
			{
				int price = Level * 200;
				
				bool askEnter2 = AskYesNo($"It's you from the other day... #b#p1061005##k made another request for you? What? You need to stay much longer? Hmmm... it's very dangerous there, but... alright, for #r{price:n0} mesos#k I'll let you search through everything. So, are you going to pay to enter?");
				
				if (!askEnter2)
				{
					self.say("I understand... but understand my side too, you can't come here for free.");
					return;
				}
				
				if (ItemCount(4031029) >= 1 || ItemCount(4031030) >= 1 || ItemCount(4031031) >= 1 || ItemCount(4031032) >= 1 || ItemCount(4031033) >= 1)
				{
					self.say("Hold on... I think you have already found some medicinal herbs growing in here... You should return to #b#p1061005##k.");
					return;
				}
				
				if (!Exchange(-price))
				{
					self.say($"Are you lacking money by chance? See if you have more than #r{price:n0}#k mesos in hand. Don't expect me to give you any discounts.");
					return;
				}
				
				ChangeMap(101000102);
			}
		}
		else
		{
			int price = Level * 100;
				
			bool askEnter2 = AskYesNo($"So you came here at the request of #b#p1061005##k to get medicinal herbs? Well... I inherited this land from my father and I can't let some stranger in just like that... But, with \r\n#r{price:n0}#k mesos, it's a totally different story... So, do you want to pay the entrance fee?");
			
			if (!askEnter2)
			{
				self.say("I understand... but understand my side too, you can't come here for free.");
				return;
			}
			
			if (ItemCount(4031020) >= 1 || ItemCount(4031021) >= 1 || ItemCount(4031022) >= 1 || ItemCount(4031023) >= 1)
			{
				self.say("Hold on... I think you have already found some medicinal herbs growing in here... You should return to #b#p1061005##k.");
				return;
			}
			
			if (!Exchange(-price))
			{
				self.say($"Are you lacking money by chance? See if you have more than #r{price:n0}#k mesos in hand. Don't expect me to give you any discounts.");
				return;
			}
			
			ChangeMap(101000100);
		}
	}
}