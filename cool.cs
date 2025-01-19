using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	public override void Run()
	{
		string quest = GetQuestData(1000600);
		
		if (Level < 30 || Job == 0)
		{
			self.say("Welcome to the VIP sauna of the #m105040300# Hotel. Actually I need some help here ...");
			return;
		}
		
		if (quest == "")
		{
			self.say("Good job getting here. Actually I have a favor to ask you. If you accept it, I'll give you a piece of clothing that you'll need in return. I think you are more than capable of doing it. Even if you don't care, just please listen to my story first.");
			self.say("I have a son that can do me no wrong. But one day he took a book of mine that is very dear to me and left. That book ... hmmm ... I can't give you the full detail on it, but it is a very very important book to me...");
			bool askStart = AskYesNo("If you get me that book back safely, I'll give you a comfortable article of clothing, perfect for saunas like this. What do you think? Will you find my son and take back that book?");
			
			if (!askStart)
			{
				self.say("I see ... I guess you're busy with things here and there ... but I'll definitely reward you handsomely for your work so if you ever change your mind, please let me know.");
				return;
			}
			
			SetQuestData(1000600, "1");
			self.say("Ohhh ... thank you so much. It won't be easy locating my son in this humongous island, the Victoria Island. I'm guessing that he may be in a passage made of trees near the forest at #m101000000#, because that's his favorite spot ... best of luck to you!");
		}
		else if (quest == "1" || quest == "2" || quest == "3")
		{
			self.say("You haven't found out my son yet, huh. He took a very important book out with him. I'll definitely reward you handsomely for your work. He may be in a passage made of trees near the forest at #m101000000#.");
		}
		else if (quest == "4")
		{
			if (ItemCount(4031016) < 1)
			{
				self.say("You haven't found out my son yet, huh. He took a very important book out with him. I'll definitely reward you handsomely for your work. He may be in a passage made of trees near the forest at #m101000000#.");
				return;
			}
			
			self.say("Ohhh ... this is the book! The book I was looking for ... phew, thank you so much. I knew you'd bring it to me ... Here, a piece of clothing like I promised ... and this isn't much, but ... here you go.");
			
			bool questReward = false;
			
			if (chr.GetGender() == 0) questReward = Exchange(10000, 4031016, -1, 1050018, 1);
			else if (chr.GetGender() == 1) questReward = Exchange(10000, 4031016, -1, 1051017, 1);
			
			if (!questReward)
			{
				self.say("Please leave a space available in your equip. tab.");
				return;
			}
			
			AddEXP(500);
			SetQuestData(1000600, "e");
			QuestEndEffect();
		}
		else if (quest == "e")
		{
			self.say("I'm so glad I got this book back safely. It's my number one treasure, you know. Am I not worried about #p1061004#? The fairies are taking care of him alright, so I'm not worried one bit.");
		}
	}
}