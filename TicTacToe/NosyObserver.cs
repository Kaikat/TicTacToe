using System;
namespace TicTacToe
{
	public abstract class NosyObserver
	{
		public NosyObserver()
		{
		}

		public abstract void Notify(GameEvent gameEvent);

		~NosyObserver()
		{
		}
	}
}
