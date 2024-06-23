using Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElMothLibs
{
	public class Moth
	{
		public static void WriteAndWait(string msg)
		{
			Console.WriteLine(msg);
			Console.ReadKey();
		}

		public static void WritingAnimation(string msg, bool wait = false, bool useExtraDelay = true, int _delay = 25, bool useCustomDelay = true)
		{
			for (int i = 0; i < msg.Length; i++)
			{
				int extraDelay = 0;
				if (msg[i] == 'ª')
				{
					i++;
					string storedDelay = string.Empty;
					while (char.IsNumber(msg[i]))
					{
						storedDelay += msg[i];
						i++;
					}
#if DEBUGDELAYS
					Console.WriteLine($"Detected delay: {storedDelay}");
#endif
					if (useCustomDelay) { Thread.Sleep(Convert.ToInt32(storedDelay)); }
				}
				else if (msg[i] == '.')
				{
					extraDelay = 1000;
				}
				else if (msg[i] == ',')
				{
					extraDelay = 500;
				}

				Console.Write(msg[i]);

				if (extraDelay > 0 && useExtraDelay)
				{
					Thread.Sleep(extraDelay);
				}
				else
				{
					Thread.Sleep(_delay);
				}
			}
			if (wait)
			{
				Console.ReadKey(true);
			}
		}

		//TODO
		public static void ShakeScreen()
		{
			Console.SetWindowPosition(0, 0);
		}
	}
}
