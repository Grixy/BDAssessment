//using BD_Assessment_WebAPI_Ruan_Gates.DataLayer;
using BD_Assessment_WebAPI_Ruan_Gates.Datalayer;
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
		public BatchAndNumberInput BatchAndNumberInput { get; set; }
	}




	public class BatchesAndNumbersProcessor
	{
		public event EventHandler<BatchAndNumberEventArgs> NumberGenerated;
		public event EventHandler<BatchAndNumberEventArgs> NumberMultiplied;

		public async Task PerformBatchOperations(BatchAndNumberInput receivedBatchAndNumber)
		{
			
			NumberGenerated += OnNumberFinishedGeneratingAsync;
			NumberMultiplied += OnNumberFinishedMultiplyingAsync;

			List<Task> listOfTasks = new List<Task>();

			//This is the second splitting point for our logic. While this means more db calls later when trying to keep track of our aggregate, it ultimately reduces our time,
			//Since unique numbers are now also generated asyncronously, as opposed to just batches themselves.
			for (int i = 1; i <= int.Parse(receivedBatchAndNumber.Numbers); i++)
			{
				listOfTasks.Add(PerformanceLogic(receivedBatchAndNumber,i));
			}

			await Task.WhenAll(listOfTasks);
		}

		//If we want to change the logic followed by the processor, this is our entrypoint to do so.
		private async Task PerformanceLogic (BatchAndNumberInput inputDetails, int batch)
		{
			await GeneratorManager(inputDetails, batch);
		}

		//Our GeneratorManager event result.
		public async void OnNumberFinishedGeneratingAsync(object source, BatchAndNumberEventArgs e)
		{
			await MultiplierManager(e.BatchAndNumberInput, e.BatchAndNumber);
		}

		//Generate a random number and fire an event with its results.
		public async Task GeneratorManager(BatchAndNumberInput inputDetails, int batch)
		{
			BatchAndNumber batchAndNumber = new BatchAndNumber();

			int randomNumber = RandomWithinRange.RandomNumber(Global.RandomIntegerLowest, Global.RandomIntegerHighest);
			int randomDelay = RandomWithinRange.RandomNumber(Global.DelayLowest, Global.DelayHighest, Global.DelayMultiplier);

			batchAndNumber.Batch = batch;
			batchAndNumber.Number = randomNumber;

			await Task.Delay(5000);

			OnNumberGenerated(inputDetails, batchAndNumber);
		}

		//Our GeneratorManager event.
		protected virtual void OnNumberGenerated(BatchAndNumberInput inputDetails, BatchAndNumber batchAndNumber)
		{
			NumberGenerated?.Invoke(this, new BatchAndNumberEventArgs() { BatchAndNumber = batchAndNumber, BatchAndNumberInput = inputDetails });
		}

		//Our MultiplierManager event result.
		public async void OnNumberFinishedMultiplyingAsync(object source, BatchAndNumberEventArgs e)
		{
			NumbersAndBatchesData n = new NumbersAndBatchesData();
			BatchAndNumberFullInfo saveData = new BatchAndNumberFullInfo
			{
				BatchAndNumber = e.BatchAndNumber,
				BatchAndNumberInputDetails = e.BatchAndNumberInput
			};

			await n.WriteBatchAndNumberToDatabase(saveData);
		}

		//Receive a number and multiply it by a random multiple.
		public async Task MultiplierManager(BatchAndNumberInput inputDetails, BatchAndNumber batchAndNumber)
		{
			int multiplier = RandomWithinRange.RandomNumber(Global.MultiplierLowest, Global.MultiplierHighest);
			int multipliedNumber = multiplier * batchAndNumber.Number;
			int randomDelay = RandomWithinRange.RandomNumber(Global.DelayLowest, Global.DelayHighest, Global.DelayMultiplier);
			batchAndNumber.Number = multipliedNumber;
			await Task.Delay(5000);

			OnNumberMultiplied(inputDetails, batchAndNumber);
		}

		//Our MultiplierManager event.
		protected virtual void OnNumberMultiplied(BatchAndNumberInput inputDetails, BatchAndNumber batchAndNumber)
		{
			NumberMultiplied?.Invoke(this, new BatchAndNumberEventArgs() { BatchAndNumber = batchAndNumber, BatchAndNumberInput = inputDetails });
		}
	}
}
