using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TicTacToe
{
	public class MainGameScreen : IScreen
	{
		private const string PATH = "Images/GameImages/";
		private const string BACKGROUND = "Game_Background";

		private Texture2D Background;

		private Board GameBoard;

		public MainGameScreen()
		{
			GameBoard = new Board();
		}

		public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
		{
			Background = Content.Load<Texture2D>(PATH + BACKGROUND);

			GameBoard.LoadContent(Content);
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Background, new Rectangle(0, 0, Constants.WindowWidth, Constants.WindowHeight), Color.AntiqueWhite);
			GameBoard.Draw(gameTime, spriteBatch);
		}

		public void Update(GameTime gameTime, MouseState mouseState)
		{
			GameBoard.Update(gameTime, mouseState);
		}

		public void Destroy(Microsoft.Xna.Framework.Content.ContentManager Content)
		{
			GameBoard.Destroy(Content);
		}
	}
}
