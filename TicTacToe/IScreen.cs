using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TicTacToe
{
	public interface IScreen
	{
		void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content);
		void Draw(GameTime gameTime, SpriteBatch spriteBatch);
		void Update(GameTime gameTime, MouseState mouseState);
		void Destroy(Microsoft.Xna.Framework.Content.ContentManager Content);
	}
}
