using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD_Assessment_WebAPI_Ruan_Gates.Helpers
{
	public static class Global
	{
		static int RANDOM_INTEGER_LOWEST = 1;
		static int RANDOM_INTEGER_HIGHEST = 100;
		static int DELAY_LOWEST = 20;
		static int DELAY_HIGHEST = 40;
		static int DELAY_MULTIPLIER = 1000;
		static int MULTIPLIER_LOWEST = 2;
		static int MULTIPLIER_HIGHEST = 4;

		public static int RandomIntegerLowest
		{
			get
			{
				return RANDOM_INTEGER_LOWEST;
			}
			set
			{
				RANDOM_INTEGER_LOWEST = value;
			}
		}

		public static int RandomIntegerHighest
		{
			get
			{
				return RANDOM_INTEGER_HIGHEST;
			}
			set
			{
				RANDOM_INTEGER_HIGHEST = value;
			}
		}

		public static int DelayLowest
		{
			get
			{
				return DELAY_LOWEST;
			}
			set
			{
				DELAY_LOWEST = value;
			}
		}

		public static int DelayHighest
		{
			get
			{
				return DELAY_HIGHEST;
			}
			set
			{
				DELAY_HIGHEST = value;
			}
		}

		public static int DelayMultiplier
		{
			get
			{
				return DELAY_MULTIPLIER;
			}
			set
			{
				DELAY_MULTIPLIER = value;
			}
		}

		public static int MultiplierLowest
		{
			get
			{
				return MULTIPLIER_LOWEST;
			}
			set
			{
				MULTIPLIER_LOWEST = value;
			}
		}

		public static int MultiplierHighest
		{
			get
			{
				return MULTIPLIER_HIGHEST;
			}
			set
			{
				MULTIPLIER_HIGHEST = value;
			}
		}
	}
}
