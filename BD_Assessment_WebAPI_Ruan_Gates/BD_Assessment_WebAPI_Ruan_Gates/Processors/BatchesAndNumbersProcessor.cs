using BD_Assessment_WebAPI_Ruan_Gates.Helpers;
using BD_Assessment_WebAPI_Ruan_Gates.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace BD_Assessment_WebAPI_Ruan_Gates.Processors
{

	public class BatchAndNumberEventArgs : EventArgs
	{
		public BatchAndNumber BatchAndNumber { get; set; }
	}

	public class BatchesAndNumbersProcessor
	{
		public int numbertest = 0;

		static BatchAndNumber batchAndNumber = new BatchAndNumber();

		public async Task<BatchAndNumber> PerformBatchOperations(int batch)
		{
			var GeneratorManager = new GeneratorManager();
			var MultiplierManager = new MultiplierManager();
			var BatchesAndNumbersProcessor = new BatchesAndNumbersProcessor();

			int remainingNumbers = 0;

			GeneratorManager.NumberGenerated += MultiplierManager.OnNumberGenerated;
			MultiplierManager.NumberMultiplied += BatchesAndNumbersProcessor.OnNumberMultiplied;

			await GeneratorManager.Generate(batch);

			Console.WriteLine("" + numbertest);
			return batchAndNumber;
		}

		public async void OnNumberMultiplied(object source, BatchAndNumberEventArgs e)
		{
			Console.WriteLine("123" + e.BatchAndNumber.Batch + " " + e.BatchAndNumber.Number);
			numbertest = e.BatchAndNumber.Number;
			batchAndNumber.Batch = e.BatchAndNumber.Batch;
			batchAndNumber.Number = e.BatchAndNumber.Number;
		}

	}

	public class GeneratorManager
	{
		public event EventHandler<BatchAndNumberEventArgs> NumberGenerated;

		public async Task Generate(int batch)
		{
			BatchAndNumber batchAndNumber = new BatchAndNumber();

			int randomNumber = RandomWithinRange.RandomNumber(Global.RandomIntegerLowest, Global.RandomIntegerHighest);
			int randomDelay = RandomWithinRange.RandomNumber(Global.DelayLowest, Global.DelayHighest, Global.DelayMultiplier);

			batchAndNumber.Batch = batch;
			batchAndNumber.Number = randomNumber;

			await Task.Delay(5000);

			OnNumberGenerated(batchAndNumber);
		}

		protected virtual void OnNumberGenerated(BatchAndNumber batchAndNumber)
		{
			if (NumberGenerated != null)
				NumberGenerated(this, new BatchAndNumberEventArgs() { BatchAndNumber = batchAndNumber });
		}
	}

	public class MultiplierManager
	{
		public async void OnNumberGenerated(object source, BatchAndNumberEventArgs e)
		{
			Console.WriteLine("123" + e.BatchAndNumber.Batch + " " + e.BatchAndNumber.Number);

			await Task.Run(() => Multiply(e.BatchAndNumber.Batch, e.BatchAndNumber.Number));

			//await Multiply(e.BatchAndNumber.Batch, e.BatchAndNumber.Number);
		}

		public event EventHandler<BatchAndNumberEventArgs> NumberMultiplied;

		public async Task Multiply(int batch, int number)
		{
			BatchAndNumber batchAndNumber = new BatchAndNumber();

			int multiplier = RandomWithinRange.RandomNumber(Global.MultiplierLowest, Global.MultiplierHighest);
			int multipliedNumber = multiplier * number;
			int randomDelay = RandomWithinRange.RandomNumber(Global.DelayLowest, Global.DelayHighest, Global.DelayMultiplier);

			batchAndNumber.Batch = batch;
			batchAndNumber.Number = multipliedNumber;

			await Task.Delay(5000);

			OnNumberMultiplied(batchAndNumber);
		}

		protected virtual void OnNumberMultiplied(BatchAndNumber batchAndNumber)
		{
			if (NumberMultiplied != null)
				NumberMultiplied(this, new BatchAndNumberEventArgs() { BatchAndNumber = batchAndNumber });
		}
	}
}
