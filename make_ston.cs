using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void MakeStone(int index, string makeItem, string needItem)
	{
		bool askBuy = AskYesNo($"To make #b5 {makeItem}s#k, you'll need the following items. Most of them can be obtained by eliminating monsters, so it shouldn't be too difficult to get them. What do you think? Want to make it?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("Don't have enough materials, huh? No problem. Come and see me when you find the necessary items. There are several ways to get them, you can hunt monsters or buy them from others, so don't be discouraged.");
			return;
		}
		
		bool trade = false;
		
		// The Magic Rock
		if (index == 0) trade = Exchange(-4000, 4000046, -20, 4000027, -20, 4021001, -1, 4006000, 5);
		else if (index == 1) trade = Exchange(-4000, 4000025, -20, 4000049, -20, 4021006, -1, 4006000, 5);
		else if (index == 2) trade = Exchange(-4000, 4000129, -15, 4000130, -15, 4021002, -1, 4006000, 5);
		else if (index == 3) trade = Exchange(-4000, 4000074, -15, 4000057, -15, 4021005, -1, 4006000, 5);
		else if (index == 4) trade = Exchange(-4000, 4000054, -7, 4000053, -7, 4021003, -1, 4006000, 5);

		// The Summoning Rock
		else if (index == 100) trade = Exchange(-4000, 4000028, -20, 4000027, -20, 4011001, -1, 4006001, 5);
		else if (index == 101) trade = Exchange(-4000, 4000014, -20, 4000056, -20, 4011003, -1, 4006001, 5);
		else if (index == 102) trade = Exchange(-4000, 4000132, -15, 4000128, -15, 4011005, -1, 4006001, 5);
		else if (index == 103) trade = Exchange(-4000, 4000074, -15, 4000069, -15, 4011002, -1, 4006001, 5);
		else if (index == 104) trade = Exchange(-4000, 4000080, -7, 4000079, -7, 4011004, -1, 4006001, 5);
		
		if (!trade)
		{
			self.say("Please make sure you have all the items you need, and that your etc. inventory isn't full.");
			return;
		}
		
		self.say($"Here, take 5 of #b5{makeItem}s#k. Even I must admit, these are a work of art. Alright, if you need my help just come back and talk to me!");
	}
	
	public override void Run()
	{
		self.say("Alright, combine the tongue of a frog with the tooth of a squirrel and... Ah! I almost forgot to add the sparkling white powder!! Man, that was almost a disaster... Woah!! How long have you been standing there? I think I got a little lost in my work... eheh.");
		int stone = AskMenu("As you can see, I'm just a wandering alchemist. I may be in training, but I can still make something useful for you. Do you want to take a look?#b",
			(0, " Make #t4006000#"),
			(1, " Make #t4006001#"));
			
		if (stone == 0)
		{
			int option = AskMenu("Haha... #b#t4006000##k is a mystical stone that only I can make. Many travelers need them to use powerful skills that require the most MP and HP. There are 5 ways to make #t4006000#. Which way would you prefer?#b",
				(0, " Make using #t4000046# and #t4000027#"),
				(1, " Make using #t4000025# and #t4000049#"),
				(2, " Make using #t4000129# and Buffoon's Clock"),
				(3, " Make using #t4000074# and #t4000057#"),
				(4, " Make using #t4000054# and #t4000053#"));
				
			if (option == 0) MakeStone(0, "#t4006000#", "#v4000046# 20 #t4000046#s\r\n#v4000027# 20 #t4000027#s\r\n#v4021001# #t4021001#\r\n4,000 mesos");
			else if (option == 1) MakeStone(1, "#t4006000#", "#v4000025# 20 #t4000025#s\r\n#v4000049# 20 #t4000049#s\r\n#v4021006# #t4021006#\r\n4,000 mesos");
			else if (option == 2) MakeStone(2, "#t4006000#", "#v4000129# 15 #t4000129#s\r\n#v4000130# 15 #t4000130#s\r\n#v4021002# #t4021002#\r\n4,000 mesos");
			else if (option == 3) MakeStone(3, "#t4006000#", "#v4000074# 15 #t4000074#s\r\n#v4000057# 15 #t4000057#s\r\n#v4021005# #t4021005#\r\n4,000 mesos");
			else if (option == 4) MakeStone(4, "#t4006000#", "#v4000054# 7 #t4000054#s\r\n#v4000053# 7 #t4000053#s\r\n#v4021003# #t4021003#\r\n4,000 mesos");
			else if (option == 5) MakeStone(5, "#t4006000#", "#v4000238# 15 #t4000238#s \r\n#v4000241# 15 #t4000241#s\r\n#v4021000# #t4021000#\r\n4,000 mesos");
			
		}
		else if (stone == 1)
		{
			int option = AskMenu("Haha... #b#t4006001##k is a mystical stone that only I can make. Many travelers need them to use powerful skills that require the most MP and HP. There are 5 ways to make #t4006001#. Which way would you prefer?#b",
				(0, " Make using #t4000028# and #t4000027#"),
				(1, " Make using #t4000014# and #t4000056#"),
				(2, " Make using #t4000132# and #t4000128#"),
				(3, " Make using #t4000074# and #t4000069#"),
				(4, " Make using #t4000080# and #t4000079#"));
			
			if (option == 0) MakeStone(100, "#t4006001#", "#v4000028# 20 #t4000028#s\r\n#v4000027# 20 #t4000027#s\r\n#v4011001# #t4011001#\r\n4,000 mesos");
			else if (option == 1) MakeStone(101, "#t4006001#", "#v4000014# 20 #t4000014#s\r\n#v4000056# 20 #t4000056#s\r\n#v4011003# #t4011003#\r\n4,000 mesos");
			else if (option == 2) MakeStone(102, "#t4006001#", "#v4000132# 15 #t4000132#s\r\n#v4000128# 15 #t4000128#s\r\n#v4011005# #t4011005#\r\n4,000 mesos");
			else if (option == 3) MakeStone(103, "#t4006001#", "#v4000074# 15 #t4000074#s\r\n#v4000069# 15 #t4000069#s\r\n#v4011002# #t4011002#\r\n4,000 mesos");
			else if (option == 4) MakeStone(104, "#t4006001#", "#v4000080# 7 #t4000080#s\r\n#v4000079# 7 #t4000079#s\r\n#v4011004# #t4011004#\r\n4,000 mesos");
			else if (option == 5) MakeStone(105, "#t4006001#", "#v4000226# 15 #t4000226#s\r\n#v4000237# 15 #t4000237#s\r\n#v4011001# #t4011001#\r\n4,000 mesos");
		}
	}
}