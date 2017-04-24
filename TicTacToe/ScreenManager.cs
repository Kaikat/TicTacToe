using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TicTacToe
{
	public class ScreenManager : NosyObserver
	{
		public IScreen CurrentScreen { private set; get; }

		private Microsoft.Xna.Framework.Content.ContentManager Content;

		public ScreenManager(Microsoft.Xna.Framework.Content.ContentManager content)
		{
			Content = content;
			CurrentScreen = new IntroScreen();
			InterestingSubject screen = CurrentScreen as InterestingSubject;
			screen?.AddObserver(this);
		}

		public void LoadContent()
		{
			CurrentScreen.LoadContent(Content);
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			CurrentScreen.Draw(gameTime, spriteBatch);
		}

		public void Update(GameTime gameTime, MouseState mouseState)
		{
			CurrentScreen.Update(gameTime, mouseState);
		}

		public void Destroy()
		{
			CurrentScreen.Destroy(Content);
		}

		public override void Notify(GameEvent gameEvent)
		{
			switch (gameEvent)
			{
				case GameEvent.StartGame:
				{
					Console.WriteLine("RECEIVED START GAME!");
					CurrentScreen.Destroy(Content);
					CurrentScreen = new MainGameScreen();
					CurrentScreen.LoadContent(Content);
					break;
				}
				default:
					break;
			}
		}
	}
}