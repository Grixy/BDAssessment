using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD_Assessment_WebAPI_Ruan_Gates.Helpers
{
	public class RandomWithinRange
	{
		//We include a multiplier to correct for SI units. e.g., delay is measured in milliseconds rather than seconds, so multiplier would = 1000.
		public static int RandomNumber(int min, int max, int multiplier = 1)
		{
			Random random = new Random();
			int correctedMinimum = (min*multiplier) + 1;
			int correctedMaximum = (max*multiplier) + 1;
			return random.Next(correctedMinimum, correctedMaximum);
		}
	}
}
