using WvsBeta.Game;
using WvsBeta.Common;
using System;
using System.Collections.Generic;
	
public class NpcScript : IScriptV2 {
    
    public override void Run()
	{
        var styles = new List<int>();
        
        var answer = AskMenu("Hello!\r\n\r\nWhat would you like to do?#b",
            (0, " Change my skin"),
            (1, " Change my hair"),
            (2, " Change my hair color"),
            (3, " Change my face"));
        
		if (answer == 0)
		{
			List<int> skins = new List<int> {0, 1, 2, 3, 4, 5};
			
			int option = AskStyle(skins, "Choose your style :D!");
            
            chr.SetSkin((byte) option);
		}
        else if (answer == 1)
		{
			int z = chr.Hair % 10;
			
			if (chr.GetGender() == 0)
			{
				int[] hair = {
					30000, 30010, 30020, 30030, 30040, 30050, 30060, 30070, 30080, 30090,
					30100, 30110, 30120, 30130, 30140, 30150, 30160, 30170, 30180, 30190,
					30200, 30210, 30220, 30230, 30240, 30250, 30260, 30270, 30280, 30290,
					30300, 30310, 30320, 30330, 30340, 30350, 30360, 30370,
					30400, 30410, 30420
				//	30500, 30510, 30520, 30530, 30540, 30550, 30560, 30570, 30580, 30590,
				//	30600, 30610, 30620, 30630, 30640, 30650, 30660, 30670, 30680, 30690,
				//	30700, 30710, 30720, 30730, 30740, 30750, 30760, 30770, 30780, 30790,
				//	30800, 30810, 30820, 30830, 30840, 30850, 30860, 30870, 30880, 30890,
				//	30900, 30910, 30920, 30930, 30940, 30950, 30960, 30970, 30980, 30990
				};
				
				foreach (int style in hair)
				{
					styles.Add(style + z);
				}
			}
			else if (chr.GetGender() == 1)
			{
				int[] hair = {
					31000, 31010, 31020, 31030, 31040, 31050, 31060, 31070, 31080, 31090,
					31100, 31110, 31120, 31130, 31140, 31150, 31160, 31170, 31180, 31190,
					31200, 31210, 31220, 31230, 31240, 31250, 31260, 31270, 31280, 31290,
					31300, 31310, 31320, 31330, 31340, 31350,
					31400, 31410, 31420,
				//	31500, 31510, 31520, 31530, 31540, 31550, 31560, 31570, 31580, 31590,
				//	31600, 31610, 31620, 31630, 31640, 31650, 31660, 31670, 31680, 31690,
				//	31700, 31710, 31720, 31730, 31740, 31750, 31760, 31770, 31780, 31790,
				//	31800, 31810, 31820, 31830, 31840, 31850, 31860, 31870, 31880, 31890,
				//	31900, 31910, 31920, 31930, 31940, 31950, 31960, 31970, 31980, 31990
					34050, 34090
				};
				
				foreach (int style in hair)
				{
					styles.Add(style + z);
				}
			}
			
			int option = AskStyle(styles, "Choose your style :D!");
            
            chr.SetHair(option);
		}
		else if (answer == 2)
		{
			int z = chr.Hair - (chr.Hair % 10);
			
			int[] color = {
				0, 1, 2, 3, 4, 5, 6, 7
			};
			
			foreach (int style in color)
			{
				styles.Add(style + z);
			}
			
			int option = AskStyle(styles, "Choose your style :D!");
            
            chr.SetHair(option);
		}
		else if (answer == 3)
		{
			if (chr.GetGender() == 0)
			{
				int[] face = {
					20000, 20001, 20002, 20003, 20004, 20005, 20006, 20007, 20008, 20009,
					20010, 20011, 20012, 20013, 20014, 20015, 20016, 20017, 20018, 20019,
					20020
				};
				
				foreach (int style in face)
				{
					styles.Add(style);
				}
			}
			else if (chr.GetGender() == 1)
			{
				int[] face = {
					21000, 21001, 21002, 21003, 21004, 21005, 21006, 21007, 21008, 21009,
					21010, 21011, 21012, 21013, 21014,        21016, 21017, 21018, 21019,
					21020, 21021,
					21038
				};
				
				foreach (int style in face)
				{
					styles.Add(style);
				}
			}
			
			int option = AskStyle(styles, "Choose your style :D!");
            
            chr.SetFace(option);
		}
    }
}