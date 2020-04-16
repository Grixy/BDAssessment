using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace BD_Assessment_WebAPI_Ruan_Gates.Processors
{
	public class BatchesAndNumbersProcessor
	{
		public delegate void NumberGeneratorEventHandler(object source, EventArgs args);

		public event NumberGeneratorEventHandler NumberGenerated;

		public async Task PerformBatchOperations (int batch, int numbers)
		{
			var BatchesAndNumbersProcessor = new BatchesAndNumbersProcessor();

			//var MultiplyService = new MultiplyService();

			BatchesAndNumbersProcessor.NumberGenerated += BatchesAndNumbersProcessor.OnNumberGenerated;

			await GeneratorManager(numbers);

			//await MultiplierManager(randomNumber);
		}

		private void test(object source, EventArgs args)
		{
			throw new NotImplementedException();
		}

		public async Task GeneratorManager(int totalNumbers)
		{
			int randomNumber = RandomNumber(1, 100);
			int randomDelay = RandomNumber(5000, 10000);

			await Task.Delay(randomDelay);
			OnNumberGenerated();
		}

		// Generate a random number between two numbers  
		private static int RandomNumber(int min, int max)
		{
			Random random = new Random();
			return random.Next(min, max);
		}

		protected virtual void OnNumberGenerated()
		{
			if (NumberGenerated != null)
				NumberGenerated(this, EventArgs.Empty);
		}

		public void OnNumberGenerated(object source, EventArgs e)
		{
			Console.WriteLine("123");
		}
	}

	//public class MultiplyService
	//{
	//	public void OnNumberGenerated(object source, EventArgs e)
	//	{
	//		Console.WriteLine("123");
	//	}
	//}
}




//public static void GeneratorManager(int totalNumbers)
//{
//	Timer timer = new Timer(10000);
//	timer.Elapsed += Timer_Elapsed;
//	timer.Start();
//	//Console.WriteLine(DateTime.Now);
//}

//public static void MultiplierManager(int numberToMultiply)
//{

//}

//private static void CustomTimer(int timeSeconds)
//{

//}

//private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
//{
//	DateTime dt = new DateTime();
//	dt = DateTime.Now;
//	Console.WriteLine(dt);
//}