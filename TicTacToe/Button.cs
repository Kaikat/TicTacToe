using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TicTacToe
{
	public class Button
	{
		private const string Down = "down";
		private const string Up = "up";
		private const string Hover = "hover";

		private string path;
		private Rectangle area;
		Texture2D[] backgrounds;

		private int indexToDraw = AssetConstants.UP;
		private bool wasPreviouslyClicked = false;

		public delegate void OnClickDelegate();
		OnClickDelegate Click;

		public Button(Position button_position, int button_width, int button_height, string asset_path, OnClickDelegate click)
		{
			path = asset_path;
			area = new Rectangle(button_position.X, button_position.Y, button_width, button_height);
			backgrounds = new Texture2D[3];
			Click = click;
		}
			
		public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
		{
			backgrounds[AssetConstants.DOWN] = Content.Load<Texture2D>(path + Down);
			backgrounds[AssetConstants.UP] = Content.Load<Texture2D>(path + Up);
			backgrounds[AssetConstants.HOVER] = Content.Load<Texture2D>(path + Hover);
		}

		public void Update(MouseState mouseState)
		{
			if (!IsWithinButtonBounds(mouseState))
			{
				indexToDraw = AssetConstants.UP;
				wasPreviouslyClicked = false;
				return;
			}

			if (mouseState.LeftButton == ButtonState.Pressed)
			{
				indexToDraw = AssetConstants.DOWN;
				wasPreviouslyClicked = true;
			}
			else if (mouseState.LeftButton == ButtonState.Released)
			{
				indexToDraw = AssetConstants.HOVER;
				if (wasPreviouslyClicked)
				{
					//Makes sure to end the current click
					wasPreviouslyClicked = false;
					Click();
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(backgrounds[indexToDraw], area, Color.White);
		}

		private bool IsWithinButtonBounds(MouseState mouseState)
		{
			return area.Contains(mouseState.X, mouseState.Y);
		}
	}
}