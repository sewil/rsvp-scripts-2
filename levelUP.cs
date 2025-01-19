using WvsBeta.Game;
using WvsBeta.Common;
using WvsBeta;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class NpcScript : IScriptV2 {
	
	// Use own StringBuilder, because linux uses "\n" only
	public class StringBuilder {
		private string buf;
		public void AppendLine(string str = "") {
			buf += str + "\r\n";
		}
		
		public string ToString() => buf;
	}

	public string GetList(IEnumerable<Character> chars) {
		var list = chars.ToList();
		return "Online players: " + list.Count + "\r\n" +
				"[id][Userid] name - LastMove - IsAFK\r\n" +
				string.Join("\r\n", list.OrderBy(x => x.LastMove).Select(x => 
					string.Format("[{0:D5}][{1:D5}] {2} - {3} - {4}", x.ID, x.UserID, x.Name, GetTimedValue(x.LastMove), x.IsAFK))
				);
	}
	
	public string GetTimedValue(long v) {
		if (v == 0) {
			return "-zero-";
		}
		
		var secs = ((MasterThread.CurrentTime - v) / 1000);
		if (secs < 0) {
			return "in " + (-secs) + " seconds";
		}
		else {
			return "" + secs + " seconds ago";
		}
	}
	
	public void WriteBuffstatValue(StringBuilder sb, BuffStat bs, string name) {
		if (bs.IsSet()) {
			sb.AppendLine(name + ": Ref " + bs.R + ", Num " + bs.N + ", Expires " + GetTimedValue(bs.TM));
		}
	}
	
	public override void Run()
	{
		QuestEndEffect();
		
		var answer = AskMenu("hi friend", 
			"#bOnline admins#k", 
			"#bOnline players#k", 
			"#bCheck player info#k"
		);

		switch (answer)
		{
			case 0:
			{
				self.say("List of online staff:\r\n" + GetList(Server.Instance.StaffCharacters));
				return;
			}
			case 1:
			{
				self.say("List of online players:\r\n" + GetList(Server.Instance.CharacterList.Values));
				return;
			}
			case 2:
			{
				var name = AskText("", 0, 12, "Character ID or name?");

				ShowCharacterInfo(name);
				return;
			}
		}
	}

	private void ShowCharacterInfo(string name)
	{
		var c = int.TryParse(name, out int id) ? Server.Instance.GetCharacter(id) : Server.Instance.GetCharacter(name);
			
		if (c == null) {
			self.say("Character '" + name + "' not found.");
			return;
		}
		
		var sb = new StringBuilder();
		sb.AppendLine("ID: " + c.ID);
		sb.AppendLine("User ID: " + c.UserID);
		sb.AppendLine("Name: " + c.Name);
		sb.AppendLine("Level: " + c.Level);
		sb.AppendLine("Job: " + c.Job);
		sb.AppendLine("Map: " + c.MapID);
		sb.AppendLine("Position: X: " + c.Position.X + ", Y: " + c.Position.Y + ", FH: " + c.Foothold);
		sb.AppendLine("LastMove: " + GetTimedValue(c.LastMove));
		sb.AppendLine("LastChat: " + GetTimedValue(c.LastChat));
		sb.AppendLine("Portal count: " + c.PortalCount);
		sb.AppendLine("Has Player: " + (c.Player != null));
		if (c.Player != null) {
			sb.AppendLine("Has Socket: " + (c.Player.Socket != null));
			if (c.Player.Socket != null) {
				var sock = c.Player.Socket;
				sb.AppendLine("Has Pong: " + sock.gotPong);
				sb.AppendLine("Ping (ms): " + sock.PingMS);
				sb.AppendLine("Last ping: " + GetTimedValue(sock.pingSentDateTime));
			}
		}
			
		AskMenuCallback(sb.ToString(), 
			("#bShow stats & buffs#k", () => self.say(ShowStats(c))), 
			("#bShow skills#k", () => self.say(ShowSkills(c))), 
			("#bShow Quests#k", () => self.say(ShowQuests(c)))
		);
	}

	private string ShowQuests(Character c)
	{
		return "Option not implemented yet.";
	}

	private string ShowSkills(Character c)
	{
		var sb = new StringBuilder();

		c.Skills.Skills.OrderBy(pair => pair.Key).ForEach(pair =>
		{
			sb.AppendLine($"{pair.Key}: level {pair.Value}");
		});
		
		return sb.ToString();
	}

	private string ShowStats(Character c)
	{
		var sb = new StringBuilder();
		// Stats & Buffs
		var ps = c.PrimaryStats;
		sb.AppendLine("Name: " + c.Name);
		sb.AppendLine("Level: " + ps.Level);
		sb.AppendLine("Str: " + ps.Str);
		sb.AppendLine("Dex: " + ps.Dex);
		sb.AppendLine("Int: " + ps.Int);
		sb.AppendLine("Luk: " + ps.Luk);
		sb.AppendLine("HP: " + ps.HP);
		sb.AppendLine("MaxHP: " + ps.MaxHP);
		sb.AppendLine("MP: " + ps.MP);
		sb.AppendLine("MaxMP: " + ps.MaxMP);
		sb.AppendLine("AP: " + ps.AP);
		sb.AppendLine("SP: " + ps.SP);
		sb.AppendLine("Fame: " + ps.Fame);
		var expForLevel = Constants.GetLevelEXP(ps.Level);
		double percentage = 0;
		if (expForLevel != 0) percentage = (ps.EXP * 100.0) / expForLevel;
		sb.AppendLine("EXP: " + ps.EXP + " (" + percentage.ToString("0.0000") + ")");
		sb.AppendLine();
		
		sb.AppendLine("Total Str: " + ps.TotalStr);
		sb.AppendLine("Total Dex: " + ps.TotalDex);
		sb.AppendLine("Total Int: " + ps.TotalInt);
		sb.AppendLine("Total Luk: " + ps.TotalLuk);
		sb.AppendLine("Total MaxHP: " + ps.TotalMaxHP);
		sb.AppendLine("Total MaxMP: " + ps.TotalMaxMP);
		sb.AppendLine("Total MAD: " + ps.TotalMAD);
		sb.AppendLine("Total MDD: " + ps.TotalMDD);
		sb.AppendLine("Total PAD: " + ps.TotalPAD);
		sb.AppendLine("Total PDD: " + ps.TotalPDD);
		sb.AppendLine("Total ACC: " + ps.TotalACC);
		sb.AppendLine("Total EVA: " + ps.TotalEVA);
		sb.AppendLine("Total Hands: " + ps.TotalHands);
		sb.AppendLine("Total Jump: " + ps.TotalJump);
		sb.AppendLine("Total Speed: " + ps.TotalSpeed);
		
		sb.AppendLine();
			
		WriteBuffstatValue(sb, ps.BuffWeaponAttack, "WeaponAttack");
		WriteBuffstatValue(sb, ps.BuffWeaponDefense, "WeaponDefense");
		WriteBuffstatValue(sb, ps.BuffMagicAttack, "MagicAttack");
		WriteBuffstatValue(sb, ps.BuffMagicDefense, "MagicDefense");
		WriteBuffstatValue(sb, ps.BuffAccurancy, "Accurancy");
		WriteBuffstatValue(sb, ps.BuffAvoidability, "Avoidability");
		WriteBuffstatValue(sb, ps.BuffHands, "Hands");
		WriteBuffstatValue(sb, ps.BuffSpeed, "Speed");
		WriteBuffstatValue(sb, ps.BuffJump, "Jump");
		WriteBuffstatValue(sb, ps.BuffMagicGuard, "MagicGuard");
		WriteBuffstatValue(sb, ps.BuffDarkSight, "DarkSight");
		WriteBuffstatValue(sb, ps.BuffBooster, "Booster");
		WriteBuffstatValue(sb, ps.BuffPowerGuard, "PowerGuard");
		WriteBuffstatValue(sb, ps.BuffMaxHP, "MaxHP");
		WriteBuffstatValue(sb, ps.BuffMaxMP, "MaxMP");
		WriteBuffstatValue(sb, ps.BuffInvincible, "Invincible");
		WriteBuffstatValue(sb, ps.BuffSoulArrow, "SoulArrow");
		WriteBuffstatValue(sb, ps.BuffStun, "Stun");
		WriteBuffstatValue(sb, ps.BuffPoison, "Poison");
		WriteBuffstatValue(sb, ps.BuffSeal, "Seal");
		WriteBuffstatValue(sb, ps.BuffDarkness, "Darkness");
		WriteBuffstatValue(sb, ps.BuffComboAttack, "ComboAttack");
		WriteBuffstatValue(sb, ps.BuffCharges, "Charges");
		WriteBuffstatValue(sb, ps.BuffDragonBlood, "DragonBlood");
		WriteBuffstatValue(sb, ps.BuffHolySymbol, "HolySymbol");
		WriteBuffstatValue(sb, ps.BuffMesoUP, "MesoUP");
		WriteBuffstatValue(sb, ps.BuffShadowPartner, "ShadowPartner");
		WriteBuffstatValue(sb, ps.BuffPickPocket, "PickPocketMesoUP");
		WriteBuffstatValue(sb, ps.BuffMesoGuard, "MesoGuard");
		WriteBuffstatValue(sb, ps.BuffThaw, "Thaw");
		WriteBuffstatValue(sb, ps.BuffWeakness, "Weakness");
		WriteBuffstatValue(sb, ps.BuffCurse, "Curse");

		return sb.ToString();
	}

}
