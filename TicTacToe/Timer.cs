using System;
namespace TicTacToe
{
	public class Timer
	{
		private const int FPS = 20;
		private double startTime;

		private int oldTimeSlice;
		private int currentTimeSlice;

		public Timer(double timeInSeconds)
		{
			startTime = timeInSeconds;
			oldTimeSlice = 0;
			currentTimeSlice = 0;
		}

		public void Update(double currentTime)
		{
			oldTimeSlice = currentTimeSlice;
			currentTimeSlice = (int)(FPS * (currentTime - startTime)) % FPS;
			if (currentTimeSlice == FPS)
			{
				startTime = currentTime;
			}
		}

		public bool HasOneSecondPassed()
		{
			return oldTimeSlice != currentTimeSlice;
		}
	}
}
