using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TicTacToe
{
	public class Board
	{
		private const string PATH = "Images/Board/";
		private const string Up = "up";
		private const string Down = "down";
		private const string Hover = "hover";
		private const int BOARD_WIDTH = 500;
		private const int BOARD_X = (Constants.WindowWidth / 2) - (BOARD_WIDTH / 2);
		private const int BOARD_Y = 0;

		private Texture2D Background;
		private Rectangle area;

		public Board()
		{
			area = new Rectangle(BOARD_X, BOARD_Y, BOARD_WIDTH, BOARD_WIDTH);
		}

		public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
		{
			Background = Content.Load<Texture2D>(PATH + Up);
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Background, area, Color.White);
		}

		public void Update(GameTime gameTime, MouseState mouseState)
		{
		}

		public void Destroy(Microsoft.Xna.Framework.Content.ContentManager Content)
		{
		}
	}
}
