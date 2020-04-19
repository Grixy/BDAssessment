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

			for (int i = 1; i <= int.Parse(receivedBatchAndNumber.Numbers); i++)
			{
				listOfTasks.Add(PerformanceLogic(receivedBatchAndNumber,i));
			}

			await Task.WhenAll(listOfTasks);
		}

		private async Task PerformanceLogic (BatchAndNumberInput inputDetails, int batch)
		{
			await Generate(inputDetails, batch);
		}

		public async void OnNumberFinishedGeneratingAsync(object source, BatchAndNumberEventArgs e)
		{
			//BatchAndNumber batchAndNumber = new BatchAndNumber
			//{
			//	Batch = e.BatchAndNumber.Batch,
			//	Number = e.BatchAndNumber.Number
			//};
			await Multiply(e.BatchAndNumberInput, e.BatchAndNumber);
		}

		public async Task Generate(BatchAndNumberInput inputDetails, int batch)
		{
			BatchAndNumber batchAndNumber = new BatchAndNumber();

			int randomNumber = RandomWithinRange.RandomNumber(Global.RandomIntegerLowest, Global.RandomIntegerHighest);
			int randomDelay = RandomWithinRange.RandomNumber(Global.DelayLowest, Global.DelayHighest, Global.DelayMultiplier);

			batchAndNumber.Batch = batch;
			batchAndNumber.Number = randomNumber;

			await Task.Delay(5000);

			OnNumberGenerated(inputDetails, batchAndNumber);
		}

		protected virtual void OnNumberGenerated(BatchAndNumberInput inputDetails, BatchAndNumber batchAndNumber)
		{
			NumberGenerated?.Invoke(this, new BatchAndNumberEventArgs() { BatchAndNumber = batchAndNumber });
		}

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

		public async Task Multiply(BatchAndNumberInput inputDetails, BatchAndNumber batchAndNumber)
		{
			int multiplier = RandomWithinRange.RandomNumber(Global.MultiplierLowest, Global.MultiplierHighest);
			int multipliedNumber = multiplier * batchAndNumber.Number;
			int randomDelay = RandomWithinRange.RandomNumber(Global.DelayLowest, Global.DelayHighest, Global.DelayMultiplier);
			batchAndNumber.Number = multipliedNumber;
			await Task.Delay(5000);

			OnNumberMultiplied(inputDetails, batchAndNumber);
		}

		protected virtual void OnNumberMultiplied(BatchAndNumberInput inputDetails, BatchAndNumber batchAndNumber)
		{
			NumberMultiplied?.Invoke(this, new BatchAndNumberEventArgs() { BatchAndNumber = batchAndNumber });
		}
	}
}
