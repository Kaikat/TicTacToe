using System;
using System.Collections.Generic;

namespace TicTacToe
{
	public class InterestingSubject
	{
		private List<NosyObserver> Observers;

		public InterestingSubject()
		{
			Observers = new List<NosyObserver>();
		}

		protected void Notify(GameEvent gameEvent)
		{
			foreach (NosyObserver nosyObserver in Observers)
			{
				nosyObserver.Notify(gameEvent);
			}
		}

		public void AddObserver(NosyObserver observer)
		{
			Observers.Add(observer);
		}

		public void RemoveObserver(NosyObserver observer)
		{
			Observers.Remove(observer);
		}
	}
}
