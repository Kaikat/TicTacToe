using System;
namespace TicTacToe
{
	public class Position
	{
		public int X { private set; get; }
		public int Y { private set; get; }

		public Position(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}
