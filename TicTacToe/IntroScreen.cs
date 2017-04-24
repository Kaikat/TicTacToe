using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TicTacToe
{
	public class IntroScreen : IScreen
	{
		private const string PATH = "Images/TitleScreenAnimation/";
		private const int IN_COUNT = 61;
		private const int OUT_COUNT = 20;
		private const string BUTTON_PATH = "Images/StartGameButton/";
		private const int START_BUTTON_WIDTH = 548;
		private const int START_BUTTON_HEIGHT = 80;
		private const int START_BUTTON_X = (Constants.WindowWidth / 2) - (START_BUTTON_WIDTH / 2) + 3;
		private const int START_BUTTON_Y = 560;

		private Timer timer;
		private List<Texture2D> InAnimation;
		private List<Texture2D> OutAnimation;
		private Button StartGameButton;

		private int index = 0;

		public IntroScreen()
		{
			InAnimation = new List<Texture2D>();
			OutAnimation = new List<Texture2D>();
			StartGameButton = new Button(new Position(START_BUTTON_X, START_BUTTON_Y), START_BUTTON_WIDTH, START_BUTTON_HEIGHT, BUTTON_PATH, () => TempFunc());
		}

		public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
		{
			string InPath = PATH + AssetConstants.InFolder + AssetConstants.InImage;
			string OutPath = PATH + AssetConstants.OutFolder + AssetConstants.OutImage;

			for (int i = 0; i < IN_COUNT; i++)
			{
				InAnimation.Add(Content.Load<Texture2D>(InPath + i.ToString()));
				if (i < OUT_COUNT)
				{
					OutAnimation.Add(Content.Load<Texture2D>(OutPath + i.ToString()));
				}
			}

			StartGameButton.LoadContent(Content);
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(InAnimation[index], new Rectangle(0, 0, Constants.WindowWidth, Constants.WindowHeight), Color.White);
			if ((index < IN_COUNT - 1) && timer.HasOneSecondPassed())
			{
				index++;
			}

			if (index >= IN_COUNT - 1)
			{
				StartGameButton.Draw(spriteBatch);
			}
		}

		public void Update(GameTime gameTime, MouseState mouseState)
		{
			if (timer == null)
			{
				timer = new Timer(gameTime.TotalGameTime.TotalSeconds);
			}

			timer.Update(gameTime.TotalGameTime.TotalSeconds);

			if (index >= IN_COUNT - 1)
			{
				StartGameButton.Update(mouseState);
			}
		}

		private void TempFunc()
		{
			Console.WriteLine("SwitchScreen");
		}

		public void Destroy(Microsoft.Xna.Framework.Content.ContentManager Content)
		{
			InAnimation.Clear();
			OutAnimation.Clear();
			Content.Unload();
		}
	}
}
