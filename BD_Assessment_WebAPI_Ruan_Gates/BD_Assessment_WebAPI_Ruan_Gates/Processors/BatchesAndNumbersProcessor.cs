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

		ProcessorWorkers processorWorkers = new ProcessorWorkers();
		BatchAndNumber batchAndNumber = new BatchAndNumber();

		public async Task PerformBatchOperations(BatchAndNumber receivedBatchAndNumber)
		{

			processorWorkers.NumberGenerated += OnNumberFinishedGenerating;
			processorWorkers.NumberMultiplied += OnNumberFinishedMultiplying;

			List<Task> listOfTasks = new List<Task>();

			for (int i = 1; i <= receivedBatchAndNumber.Number; i++)
			{
				ProcessorWorkers p = new ProcessorWorkers();
				listOfTasks.Add(p.PerformanceLogic(receivedBatchAndNumber));
			}

			await Task.WhenAll(listOfTasks);
		}

		public void OnNumberFinishedGenerating(object source, BatchAndNumberEventArgs e)
		{
			batchAndNumber.Batch = e.BatchAndNumber.Batch;
			batchAndNumber.Number = e.BatchAndNumber.Number;
		}

		public void OnNumberFinishedMultiplying(object source, BatchAndNumberEventArgs e)
		{

		}

	}

	public class ProcessorWorkers
	{
		public event EventHandler<BatchAndNumberEventArgs> NumberGenerated;
		public event EventHandler<BatchAndNumberEventArgs> NumberMultiplied;
		BatchAndNumber batchAndNumber = new BatchAndNumber();

		public async Task PerformanceLogic(BatchAndNumber receivedBatchAndNumber)
		{
			await Generate(receivedBatchAndNumber.Batch);
			await Multiply(batchAndNumber);

			BatchAndNumber bbbbbbbbbbbbbbbbb = batchAndNumber;
		}

		public async Task Generate(int batch)
		{
			int randomNumber = RandomWithinRange.RandomNumber(Global.RandomIntegerLowest, Global.RandomIntegerHighest);
			int randomDelay = RandomWithinRange.RandomNumber(Global.DelayLowest, Global.DelayHighest, Global.DelayMultiplier);

			batchAndNumber.Batch = batch;
			batchAndNumber.Number = randomNumber;

			await Task.Delay(5000);

			OnNumberGenerated(batchAndNumber);
		}

		protected virtual void OnNumberGenerated(BatchAndNumber batchAndNumber)
		{
			NumberGenerated?.Invoke(this, new BatchAndNumberEventArgs() { BatchAndNumber = batchAndNumber });
		}

		public async Task Multiply(BatchAndNumber batchAndNumber)
		{
			int multiplier = RandomWithinRange.RandomNumber(Global.MultiplierLowest, Global.MultiplierHighest);
			int multipliedNumber = multiplier * batchAndNumber.Number;
			int randomDelay = RandomWithinRange.RandomNumber(Global.DelayLowest, Global.DelayHighest, Global.DelayMultiplier);
			batchAndNumber.Number = multipliedNumber;

			await Task.Delay(5000);

			OnNumberMultiplied(batchAndNumber);
		}

		protected virtual void OnNumberMultiplied(BatchAndNumber batchAndNumber)
		{
			NumberMultiplied?.Invoke(this, new BatchAndNumberEventArgs() { BatchAndNumber = batchAndNumber });
		}
	}
}
