using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTest
{
	class Game
	{
		private int[] rolls = new int[21];
		private int currentRoll = 0;
		internal void roll(int pins)
		{
			rolls[currentRoll++] = pins;
		}

		internal int score()
		{
			int scores = 0;
			int frameIndex = 0;
			for (int frame = 0; frame < 10; ++frame)
			{
				if (isStrike(frameIndex))
				{
					scores += 10 + strikeBonus(frameIndex);
					frameIndex++;
				}
				else if (isSpare(frameIndex))
				{
					scores += 10 + spareBonus(frameIndex);
					frameIndex += 2;
				}
				else
				{
					scores += sumOfBallsInFrame(frameIndex);
					frameIndex += 2;
				}
			}
			return scores;
		}

		private int sumOfBallsInFrame(int frameIndex)
		{
			return rolls[frameIndex] + rolls[frameIndex + 1];
		}

		private int strikeBonus(int frameIndex)
		{
			return rolls[frameIndex + 1] + rolls[frameIndex + 2];
		}

		private int spareBonus(int frameIndex)
		{
			return rolls[frameIndex + 2];
		}

		private bool isSpare(int frameIndex)
		{
			return 10 == rolls[frameIndex] + rolls[frameIndex + 1];
		}

		private bool isStrike(int frameIndex)
		{
			return rolls[frameIndex] == 10;
		}
	}
}
