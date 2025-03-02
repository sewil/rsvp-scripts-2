using System;
using WvsBeta.Game;
using WvsBeta.Common;
using WvsBeta.Game.GameObjects;

public class Portal : IScriptV2
{
	private PartyData Party => PartyData.Parties[chr.PartyID];
	private FieldSet FieldSet => chr.Field.ParentFieldSet;
	private bool IsLeader => Party.Leader == chr.ID;
	
	private string Shuffle(string str)
	{
		var rnd = new Random();
		char[] array = str.ToCharArray();
		int n = array.Length;
		while (n > 1)
		{
			n--;
			int k = rnd.Next(n + 1);
			var value = array[k];
			array[k] = array[n];
			array[n] = value;
		}

		return array.ToString();
	}
	
	private void SetAnswer()
	{
		string shuffle = Shuffle("11000");
		int t = 0;
		int k = 0;
		
		for (int i = 0; i < shuffle.Length; i++)
		{
			string str = shuffle.Substring(i, 1);
			
			if (str == "1")
			{
				if (t == 0)
				{
					FieldSet.SetVar("stage6_ans1", (i + 1).ToString());
					t++;
				}
				else if (t == 1)
				{
					FieldSet.SetVar("stage6_ans2", (i + 1).ToString());
					t++;
				}
			}
			else if (str == "0")
			{
				if (k == 0)
				{
					FieldSet.SetVar("stage6_wans1", (i + 1).ToString());
					k++;
				}
				else if (k == 1)
				{
					FieldSet.SetVar("stage6_wans2", (i + 1).ToString());
					k++;
				}
				else if (k == 2)
				{
					FieldSet.SetVar("stage6_wans3", (i + 1).ToString());
					k++;
				}
			}
		}
		
		FieldSet.SetVar("room6_ans", "set");
	}
	
	public override void Run()
	{
		if (GetFieldsetVar("stage7") == "clear")
		{
			Message("There is nothing left to do in this room.");
			return;
		}
		
		if (GetFieldsetVar("room6_ans") != "set")
			SetAnswer();
		
		if (IsLeader)
		{
			FieldSet.Characters.ForEach(character =>
			{
				Message(character, "The leader of the party has entered the <On the Way Up>.");
			});
			
			MapPacket.PlayPortalSE(chr);
			ChangeMap(920010700, "st00");
		}
		else
		{
			if (UserCount(920010700) >= 1)
			{
				MapPacket.PlayPortalSE(chr);
				ChangeMap(920010700, "st00");
			}
			else
			{
				Message("You can only enter locations where you'll find the party leader.");
			}
		}
	}
}