using System;
using WvsBeta.Game;

public class NpcScript : IScriptV2
{
	private void MakeItem(int setID, int needItem1, int needItem2)
	{
		self.say($"#bYou want to make #t{setID}##k? Hmm... find some materials, then I can make it. Listen carefully, the materials you'll need are: #r99 #t{needItem1}##k, #r99 #t{needItem2}##k, and #r1 #t4030009##k. The monsters probably drop these materials from time to time...");
		
		if (ItemCount(4030009) >= 1 && ItemCount(needItem1) >= 99 && ItemCount(needItem2) >= 99)
		{
			self.say($"Wow, You really got the #r#t{needItem1}##k, #r#t{needItem2}##k, and #r#t4030009##k! Well... you brought all the necessary items. Alright, wait one second and I'll make it.");
			
			if (!Exchange(0, 4030009, -1, needItem1, -99, needItem2, -99, setID, 1))
			{
				self.say($"Are you sure you collected #b#t{needItem1}##k, #b#t{needItem2}##k, and a #b#t4030009##k? If so, check if your etc. inventory is full.");
				return;
			}
			
			self.say($"Here's the #b#t{setID}##k! You can open an Omok Room anywhere in the game and have fun playing against other Maple users. If you end up with a lot of wins, something good might happen. I'll be cheering for you, so go play!");
			self.say("Oh, if you have any questions about the Omok game, feel free to ask. I'll stay here for a while. Well, practice playing with other users until you feel like you can beat me in a minigame. But of course that will never happen hahaha. Alright, I'm out~");
		}
	}
	
	public override void Run()
	{
		int start = -1;
		
		if (MapID == 100000203)
		{
			start = AskMenu("Hey, it looks like you need to take a break from hunting. You should be enjoying life like me. Well, if you have some items, I can make a trade with you for an item used to play minigames. So... what can I do for you?#b",
				(0, " Create a minigame item"),
				(1, " Explain more about minigames"));
		}
		else if (MapID == 220000308)
		{
			start = AskMenu("Well, hello! I'm #b#p2040014##k and I'm responsible for everything that involves minigames here. It seems like you have a certain interest in minigames... I can certainly help you! Alright... so, what can I do for you?#b",
				(0, " Create a minigame item"),
				(1, " Explain more about minigames"));
		}
		
		if (start == 0)
		{
			int gameSelect = AskMenu("Do you want to make a minigame item? Minigames aren't something you can simply play out of nowhere. You'll need some specific items for each minigame. Which minigame item would you like to make?#b",
				(0, " Omok Set"),
				(1, " A Set of Match Cards"));
			
			if (gameSelect == 0)
			{
				self.say("You want to play #bOmok#k, huh? To play, you need an Omok Set. Only those who have this item can open a room for the Omok game. You can play practically anywhere, except for some places in the Free Market.");
				
				if (MapID == 100000203)
				{
					int askOmok = AskMenu("The set is also different depending on the pieces you want to use in the game. Which set would you like to make?#b",
						(0, " #t4080000#"),
						(1, " #t4080001#"),
						(2, " #t4080002#"),
						(3, " #t4080003#"),
						(4, " #t4080004#"),
						(5, " #t4080005#"));
					
					switch(askOmok)
					{
						case 0: MakeItem(4080000, 4030000, 4030001); break;
						case 1: MakeItem(4080001, 4030000, 4030010); break;
						case 2: MakeItem(4080002, 4030000, 4030011); break;
						case 3: MakeItem(4080003, 4030010, 4030001); break;
						case 4: MakeItem(4080004, 4030011, 4030010); break;
						case 5: MakeItem(4080005, 4030011, 4030001); break;
					}
				}
				else
				{
					int askOmok = AskMenu("The Omok Set is also different depending on the rocks you want to use in the game. Which set would you like to make?#b",
						(0, " #t4080006#"),
						(1, " #t4080007#"),
						(2, " #t4080008#"),
						(3, " #t4080009#"),
						(4, " #t4080010#"),
						(5, " #t4080011#"));
					
					switch(askOmok)
					{
						case 0: MakeItem(4080006, 4030013, 4030014); break;
						case 1: MakeItem(4080007, 4030013, 4030016); break;
						case 2: MakeItem(4080008, 4030014, 4030016); break;
						case 3: MakeItem(4080009, 4030015, 4030013); break;
						case 4: MakeItem(4080010, 4030015, 4030014); break;
						case 5: MakeItem(4080011, 4030015, 4030016); break;
					}
				}
			}
			else if (gameSelect == 1)
			{
				self.say("You want #b#t4080100##k? Hmmm... to make #t4080100#, you will need some #b#t4030012#s#k. #t4030012#s can be obtained by defeating monsters around the island. Collect 99 #t4030012#s and you'll be able to make #t4080100#.");
				
				if (ItemCount(4030012) >= 99)
				{
					self.say("Wow, you really got #r99 #t4030012#s#k!! Awesome... Alright, this will be fun. Hold on one second~ I'll make #r#t4080100##k right away.");
					
					if (!Exchange(0, 4030012, -99, 4080100, 1))
					{
						self.say("Are you sure you collected #r99 #t4030012#s#k? If so, check if your etc. inventory is full.");
						return;
					}
					
					self.say("Here you go, #b#t4080100##k! The \"Match Cards\" room can be played almost anywhere in the game. Open a room here and play with other users. If you end up with a lot of wins, something good might happen. I'll be cheering for you, so go play!");
					self.say("Oh, if you have any questions about the Match Cards game, feel free to ask. I'll stay here for a while. Well, practice playing with other users until you feel like you can beat me in a minigame. But of course that will never happen, haha... Alright, I'm out~");
				}
			}
		}
		else if (start == 1)
		{
			int askHelp = AskMenu("Do you want to learn more about minigames? Wow! Ask whatever you want. Which minigame do you want to know more about?#b",
				(0, " Omok"),
				(1, " Match Cards"));
				
			if (askHelp == 0)
			{
				self.say("These are the rules of the Omok game. Listen carefully. Omok is a game in which you and yout opponent will, one at a time, place a piece on the board until someone finds a way to place 5 pieces in a row horizontally, diagonally, or vertically. Whoever succeeds will be the winner. For starters, only those with an #bOmok Set#k can open the game room.");
				self.say("Each game of Omok will cost #r100 mesos#k. Even if you don't have an #bOmok Set#k, you can enter the room and play. But if you don't have 100 mesos, you won't be able to enter the room at all. The person who opens the room also needs to have 100 mesos or there will be no game.");
				self.say("Enter the room, and when you're ready to play, click on \r\n#bReady#k. Once the visitor clicks on #bReady#k, the owner of the room can press #bStart#k to start the game. If an unwanted visitor walks in, and you don't want to play with that person, the owner of the room has the right to kick the visitor out of the room. There will be a square box with #rx#k written on the right of that person. Click on that for a cold goodbye, ok?");
				self.say("When the first game starts, #bthe owner of the room goes \r\nfirst#k. Beware that you'll be given a time limit, and you may lose your turn if you don't make your move on time. Normally, 3 x 3 is not allowed, but if there comes a point that it's absolutely necessary to put your piece there or face a game over, then you can put it there. 3 x 3 is allowed as the last line of defense! Oh, and it won't count if it's #r6 or 7 straight#k. Only 5!");
				self.say("If you know your back is against the wall, you can request a #bRedo#k. If the opponent accepts your request, then the opponent's last move, along with yours, will be canceled out. If you ever feel the need to go to the bathroom, or take an extended break, you can request a #btie#k. The game will end in a tie if the opponent accepts the request. This may be a good way to keep your friendship in tact with your buddy.");
				self.say("Once the game is over, and the next game starts, the loser will go first. Oh, and you can't leave in the middle of the game. If you do, you may need to request either a #bforfeit, or a tie#k. Of course, if you request a forfeit, you'll lose the game, so be careful of that. And if you click on \"Leave\" in the middle of the game and call to leave after the game, you'll leave the room right after the game is over, so this will be a much more useful way to leave.");
			}
			else if (askHelp == 1)
			{
				self.say("Here are the rules to the game of Match Cards. Listen carefully. Match Cards is just like the way it sounds, finding a matching pair among the number of cards laid on the table. When all the matching pairs are found, then the person with more matching pairs will win the game. Just like Omok, you'll need #bA Set of Match Cards#k to open the game room.");
				self.say("Every game of Match Cards will cost you #r100 mesos#k. Even if you don't have #bA set of Match Cards#k, you can enter the game room and play the game. If you don't have 100 mesos, however, then you won't be allowed in the room, period. The person opening the game room also needs 100 mesos to open the room, or there's no game. If you run out of mesos during the game, then you're automatically kicked out of the room!");
				self.say("Enter the room, and when you're ready to play, click on \r\n#bReady#k. Once the visitor clicks on #bReady#k, the owner of the room can press #bStart#k to start the game. If an unwanted visitor walks in, and you don't want to play with that person, the owner of the room has the right to kick the visitor out of the room. There will be a square box with #rx#k written on the right of that person. Click on that for a cold goodbye, ok?");
				self.say("Oh, and unlike Omok, on Match Cards, when you create the game room, you'll need to set your game on the number of cards you'll use for the game. There are 3 modes available, 3x4, 4x5, and 5x6, which will require 12, 20, and 30 cards. Remember, though, you won't be able to change it up once the room is open, so if you really wish to change it up, you may have to close the room and open another one.");
				self.say("When the first game starts, #bthe owner of the room goes \r\nfirst#k. Beware that you'll be given a time limit, and you may lose your turn if you don't make your move on time. When you find a matching pair on your turn, you'll get to keep your turn, as long as you keep finding a pair of matching cards. Use your memorizing skills for a devastating combo of turns.");
				self.say("If you and your opponent have the same number of matched pairs, then whoever had a longer streak of matched pairs will win. If you ever feel the need to go to the bathroom, or take an extended break, you can request a #btie#k. The game will end in a tie if the opponent accepts the request. This may be a good way to keep your friendship in tact with your buddy.");
				self.say("Once the game is over, and the next game starts, the loser will go fisrt. Oh, and you can't leave in the middle of the game. If you do, you may need to request either a #bforfeit, or a tie#k. Of course, if you request a forfeit, you'll lose the game, so be careful of that. And if you click on \"Leave\" in the middle of the game and call to leave after the game, you'll leave the room right after the game is over, so this will be a much more useful way to leave.");
			}
		}
	}
}