using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void Craft1(int index, string makeItem, string needItem, int reqLevel)
	{
		bool askBuy = AskYesNo($"To make a(n) {makeItem}, I'll need the following materials. The level limit is {reqLevel} and please make sure that you aren't using an item that is used as a material for the upgrade. What do you think? Do you want one?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("Don't have the materials? It's alright... go look for them all and then come talk to me, alright? I'll wait...");
			return;
		}
		
		bool trade = false;
		
		if (index == 1) trade = Exchange(-1000, 4000021, -15, 4011001, -1, 1082003, 1);
		else if (index == 2) trade = Exchange(-2000, 4011001, -2, 1082000, 1);
		else if (index == 3) trade = Exchange(-5000, 4000021, -40, 4011000, -2, 1082004, 1);
		else if (index == 4) trade = Exchange(-10000, 4011001, -2, 1082001, 1);
		else if (index == 5) trade = Exchange(-20000, 4011000, -3, 4011001, -2, 4003000, -15, 1082007, 1);
		else if (index == 6) trade = Exchange(-30000, 4011001, -4, 4000021, -30, 4003000, -30, 1082008, 1);
		else if (index == 7) trade = Exchange(-40000, 4011001, -5, 4000021, -50, 4003000, -40, 1082023, 1);
		else if (index == 8) trade = Exchange(-50000, 4011001, -3, 4021007, -2, 4000030, -30, 4003000, -45, 1082009, 1);
		else if (index == 9) trade = Exchange(-70000, 4011007, -1, 4011000, -8, 4011006, -2, 4000030, -50, 4003000, -50, 1082059, 1);
		
		if (!trade)
		{
			self.say("Please check carefully that you have all the items you need, and if your equip. inventory is full or not.");
			return;
		}
		
		self.say($"Here! Take the {makeItem}. You don't think that I'm as good as Mr. Thunder? You'll be more than happy with what I made here.");
	}
	
	private void Craft2(int index, string makeItem, string needItem, int reqLevel)
	{
		bool askBuy = AskYesNo($"To make a(n) {makeItem}, I'll need the following materials. The level limit is {reqLevel} and please make sure that you aren't going to use an item that is being used as a material for the upgrade. What do you think? Do you want one?\r\n\r\n#b{needItem}");
		
		if (!askBuy)
		{
			self.say("Don't have the materials? It's alright... go look for them all and then come talk to me, alright? I'll wait...");
			return;
		}
		
		bool trade = false;
		
		if (index == 1) trade = Exchange(-20000, 1082007, -1, 4011001, -1, 1082005, 1);
		else if (index == 2) trade = Exchange(-25000, 1082007, -1, 4011005, -2, 1082006, 1);
		else if (index == 3) trade = Exchange(-30000, 1082008, -1, 4021006, -3, 1082035, 1);
		else if (index == 4) trade = Exchange(-40000, 1082008, -1, 4021008, -1, 1082036, 1);
		else if (index == 5) trade = Exchange(-45000, 1082023, -1, 4011003, -4, 1082024, 1);
		else if (index == 6) trade = Exchange(-50000, 1082023, -1, 4021008, -2, 1082025, 1);
		else if (index == 7) trade = Exchange(-55000, 1082009, -1, 4011002, -5, 1082010, 1);
		else if (index == 8) trade = Exchange(-60000, 1082009, -1, 4011006, -4, 1082011, 1);
		else if (index == 9) trade = Exchange(-70000, 1082059, -1, 4011002, -3, 4021005, -5, 1082060, 1);
		else if (index == 10) trade = Exchange(-80000, 1082059, -1, 4021007, -2, 4021008, -2, 1082061, 1);
		
		if (!trade)
		{
			self.say("Please check carefully that you have all the items you need, and if your equip. inventory is full or not.");
			return;
		}
		
		self.say($"Here! Take the {makeItem}. You don't think that I'm as good as Mr. Thunder? You'll be more than happy with what I made here.");
	}
	
	private void Craft3(int index, string makeItem, string needItem, int needNumber, int itemNumber)
	{
		int amount = AskInteger(1, 1, 100, $"With #b{needNumber} {needItem}#k, I can create {itemNumber} {makeItem}. Be happy, because this is on me. What do you think? How many do you want?");
		
		int nNeedNum = amount * needNumber;
		int nAllNum = amount * itemNumber;
		
		bool askBuy = AskYesNo($"You want to make #b{makeItem}#k {amount} times? I will need #r{nNeedNum} {needItem}#k then.");
		
		if (!askBuy)
		{
			self.say("Don't have the materials? No problem... go look for them all and then come talk to me, alright? I'll wait...");
			return;
		}
		
		bool trade = false;
		
		if (index == 1) trade = Exchange(0, 4000003, -nNeedNum, 4003001, nAllNum);
		else if (index == 2) trade = Exchange(0, 4000018, -nNeedNum, 4003001, nAllNum);
		else if (index == 3) trade = Exchange(0, 4011001, -nNeedNum, 4011000, -nNeedNum, 4003000, nAllNum);
		
		if (!trade)
		{
			self.say("Please check carefully that you have all the items you need, and if your etc. inventory is full or not.");
			return;
		}
		
		self.say($"Here! Take {nAllNum} {makeItem}. You don't think that I'm as good as Mr. Thunder? You'll be more than happy with what I made here.");
	}
	
	public override void Run()
	{
		bool askStart = AskYesNo("I am Mr. Thunder's apprentice. He's getting very old and isn't what he used to be... haha! Oh shoot! Please don't go and tell him that I said that... well... I can make various items specifically designed for warriors, so what do you think? Want to let me do it?");
		
		if (!askStart)
		{
			self.say("*Sigh*... My boss will definitely chew me out if I don't make stuff right today... Oh well... whatever!");
			return;
		}
		
		int craftType = AskMenu("Alright! The service fee will be reasonable, so don't worry. What do you want to make?#b",
			(0, " Make a glove"),
			(1, " Upgrade a glove"),
			(2, " Create materials"));
		
		if (craftType == 0)
		{
			int craftSelect = AskMenu("I'm the best glove maker in town!! Now... what kind of glove do you want me to make?",
				(0, " #b#t1082003##k(level limit: 10, warrior)"),
				(1, " #b#t1082000##k(level limit: 15, warrior)"),
				(2, " #b#t1082004##k(level limit: 20, warrior)"),
				(3, " #b#t1082001##k(level limit: 25, warrior)"),
				(4, " #b#t1082007##k(level limit: 30, warrior)"),
				(5, " #b#t1082008##k(level limit: 35, warrior)"),
				(6, " #b#t1082023##k(level limit: 40, warrior)"),
				(7, " #b#t1082009##k(level limit: 50, warrior)"),
				(8, " #b#t1082059##k(level limit: 60, warrior)"));
				
			if (craftSelect == 0) Craft1(1, "#t1082003#", "#v4000021# 15 #t4000021#s\r\n#v4011001# #t4011001# \r\n1,000 mesos", 10);
			else if (craftSelect == 1) Craft1(2, "#t1082000#", "#v4011001# 2 #t4011001#s \r\n2,000 mesos", 15);
			else if (craftSelect == 2) Craft1(3, "#t1082004#", "#v4000021# 40 #t4000021#s \r\n#v4011000# 2 #t4011000#s \r\n5,000 mesos", 20);
			else if (craftSelect == 3) Craft1(4, "#t1082001#", "#v4011001# 2 #t4011001#s \r\n10,000 mesos", 25);
			else if (craftSelect == 4) Craft1(5, "#t1082007#", "#v4011000# 3 #t4011000#s \r\n#v4011001# 2 #t4011001#s \r\n#v4003000# 15 #t4003000#s \r\n20,000 mesos", 30);
			else if (craftSelect == 5) Craft1(6, "#t1082008#", "#v4000021# 30 #t4000021#s \r\n#v4011001#  4 #t4011001#s \r\n#v4003000# 30 #t4003000#s \r\n30,000 mesos", 35);
			else if (craftSelect == 6) Craft1(7, "#t1082023#", "#v4000021# 50 #t4000021#s \r\n#v4011001# 5 #t4011001#s \r\n#v4003000# 40 #t4003000#s \r\n40,000 mesos", 40);
			else if (craftSelect == 7) Craft1(8, "#t1082009#", "#v4011001# 3 #t4011001#s \r\n#v4021007# 2 #t4021007#s \r\n#v4000030# 30 #t4000030#s \r\n#v4003000# 45 #t4003000#s \r\n50,000 mesos", 50);
			else if (craftSelect == 8) Craft1(9, "#t1082059#", "#v4011007# #t4011007# \r\n#v4011000# 8 #t4011000#s \r\n#v4011006# 2 #t4011006#s \r\n#v4000030# 50 #t4000030#s \r\n#v4003000# 50 #t4003000#s \r\n70,000 mesos", 60);
		}
		else if (craftType == 1)
		{
			self.say("So, you want to upgrade the glove? Ok then. But I'll give you some advice: All the items that will be used for the upgrade will disappear, and if you use an item that has already been #renhanced#k with a scroll, the effect will disappear when upgraded. Take this into consideration when making a decision, alright?");
			
			int craftSelect = AskMenu("So~~ what kind of glove do you want to upgrade and make?",
				(0, " #b#t1082005##k(level limit: 30, warrior)"),
				(1, " #b#t1082006##k(level limit: 30, warrior)"),
				(2, " #b#t1082035##k(level limit: 35, warrior)"),
				(3, " #b#t1082036##k(level limit: 35, warrior)"),
				(4, " #b#t1082024##k(level limit: 40, warrior)"),
				(5, " #b#t1082025##k(level limit: 40, warrior)"),
				(6, " #b#t1082010##k(level limit: 50, warrior)"),
				(7, " #b#t1082011##k(level limit: 50, warrior)"),
				(8, " #b#t1082060##k(level limit: 60, warrior)"),
				(9, " #b#t1082061##k(level limit: 60, warrior)"));
				
			if (craftSelect == 0) Craft2(1, "#t1082005#", "#v1082007# #t1082007# \r\n#v4011001# #t4011001# \r\n20,000 mesos", 30);
			else if (craftSelect == 1) Craft2(2, "#t1082006#", "#v1082007# #t1082007# \r\n#v4011005# 2 #t4011005#s \r\n25,000 mesos", 30);	
			else if (craftSelect == 2) Craft2(3, "#t1082035#", "#v1082008# #t1082008# \r\n#v4021006# 3 #t4021006#s \r\n30,000 mesos", 35);
			else if (craftSelect == 3) Craft2(4, "#t1082036#", "#v1082008# #t1082008# \r\n#v4021008# #t4021008# \r\n40,000 mesos", 35);
			else if (craftSelect == 4) Craft2(5, "#t1082024#", "#v1082023# #t1082023# \r\n#v4011003# 4 #t4011003#s \r\n45,000 mesos", 40);
			else if (craftSelect == 5) Craft2(6, "#t1082025#", "#v1082023# #t1082023# \r\n#v4021008# 2 #t4021008#s \r\n50,000 mesos", 40);
			else if (craftSelect == 6) Craft2(7, "#t1082010#", "#v1082009# #t1082009# \r\n#v4011002# 5 #t4011002#s \r\n55,000 mesos", 50);
			else if (craftSelect == 7) Craft2(8, "#t1082011#", "#v1082009# #t1082009# \r\n#v4011006# 4 #t4011006#s \r\n60,000 mesos", 50);
			else if (craftSelect == 8) Craft2(9, "#t1082060#", "#v1082059# #t1082059# \r\n#v4011002# 3 #t4011002#s \r\n#v4021005# 5 #t4021005#s \r\n70,000 mesos", 60);
			else if (craftSelect == 9) Craft2(10, "#t1082061#", "#v1082059# #t1082059# \r\n#v4021007# 2 #t4021007#s \r\n#v4021008# 2 #t4021008#s \r\n80,000 mesos", 60);
				
		}
		else if (craftType == 2)
		{
			int craftSelect = AskMenu("So, you want to create some materials, right? Ok... What kind of materials do you want to make?#b",
				(0, " Create #t4003001# with #t4000003#"),
				(1, " Create #t4003001# with #t4000018#"),
				(2, " Create #t4003000#s"));
				
			if (craftSelect == 0) Craft3(1, "#t4003001#(s)", "#t4000003#es", 10, 1);
			else if (craftSelect == 1) Craft3(2, "#t4003001#(s)", "#t4000018#s", 5, 1);
			else if (craftSelect == 2) Craft3(3, "#t4003000#s", "#t4011001#(s) and #t4011000#(s) each", 1, 15);
		}
	}
}