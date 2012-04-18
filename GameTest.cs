using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameTest
{
	[TestClass]
	public class GameTest
	{
		private void rollMany(int n, int pins)
		{
			for (int i = 0; i < n; i++)
				game.roll(pins);
		}
		Game game = new Game();

		[TestMethod]
		public void TestOnlyOne()
		{
			game.roll(5);
			Assert.AreEqual(game.score(), 5);
		}

		[TestMethod]
		public void TestAllZeros()
		{
			rollMany(20, 0);
			Assert.AreEqual(0, game.score());
		}

		[TestMethod]
		public void TestAllOnes()
		{
			rollMany(20, 1);
			Assert.AreEqual(game.score(), 20);
		}

		[TestMethod]
		public void TestOneSpare()
		{
			game.roll(5);
			game.roll(5); // spare
			game.roll(3);
			rollMany(17,0);
			Assert.AreEqual(16,game.score());
		}

		[TestMethod]
		public void TestOneStrike()
		{
			game.roll(10); // strike
			game.roll(3);
			game.roll(4);
			rollMany(16, 0);
			Assert.AreEqual(24, game.score());
		}

		[TestMethod]
		public void TestPerfectGame()
		{
			rollMany(12, 10);
			Assert.AreEqual(300, game.score());
		}

		[TestMethod]
		public void TestTypicalGame()
		{
			game.roll(1);
			game.roll(4);
			game.roll(4);
			game.roll(5);
			game.roll(6);
			game.roll(4);
			game.roll(5);
			game.roll(5);
			game.roll(10);
			game.roll(0);
			game.roll(1);
			game.roll(7);
			game.roll(3);
			game.roll(6);
			game.roll(4);
			game.roll(10);
			game.roll(2);
			game.roll(8);
			game.roll(6);
			Assert.AreEqual(133, game.score());
		}
	}
}
