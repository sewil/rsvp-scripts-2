/* 
** NPC Name: Nemi
** Location: Lith Harbor
** Purpose: Warm Welcome + Mark of Beta
** Made by: wackyracer / Joren McGrew & Kyushen
** Partially GMS-like speech
*/

using WvsBeta.Game;
using WvsBeta.Common;
using System;
using System.Collections.Generic;

public class NpcScript : INpcScript 
{
	public void Run(IHost mHost, Character character, byte State, byte Answer, string StringAnswer, int IntegerAnswer) 
	{
		if (State == 0) 
		{
			if (character.BetaPlayer)
			{
				mHost.Sendself.say("Hi, I'm #rNemi#k! I hope you're having a wonderful time here on \r\n#bMapleGlobal#k! Thanks for participating in our testing stages!");
			}
			else
			{
				mHost.Sendself.say("Isn't it beautiful today? I would like nothing more than just go somewhere.");
				mHost.Stop();
			}
        }
		else if (State == 1) 
		{
			if (character.BetaPlayer)
			{
				mHost.Sendself.say("To show our gratitude for you helping us test for bugs, I would like you to have this tester-exclusive #bMark of the Beta#k equipment item!  #v1002419#  Would you like that?!");
			}
			else
			{
				mHost.Stop();
			}
        }
		else if (State == 2) 
		{
			if (character.BetaPlayer)
			{
				if (character.Inventory.ItemCount(1002419) >= 1 || character.Inventory.GetEquippedItemId(-1, true) == 1002419) 
				{ // Item Check
					mHost.Sendself.say("Hey! You were already given a #bMark of the Beta#k! Nice try!");
					mHost.Stop();
				}
				else 
				{
					character.Inventory.AddNewItem(1002419, 1);
					mHost.Sendself.say("Have fun! And I hope you enjoy playing MapleGlobal!");
					mHost.Stop();
				}
			}
			else
			{
				mHost.Stop();
			}
		}
		else
		{
			mHost.Stop();
		}
	}
}