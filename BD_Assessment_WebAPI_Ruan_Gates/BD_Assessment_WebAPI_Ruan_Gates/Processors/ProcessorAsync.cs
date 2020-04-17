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
	public class ProcessorAsync
	{
		public async Task<BatchAndNumber> PerformBatchOperations(int batch)
		{
			var GeneratorManager = new GeneratorManager();

			BatchAndNumber b = await Generate(batch);

			return b;
		}

		public async Task<BatchAndNumber> Generate(int batch)
		{
			BatchAndNumber batchAndNumber = new BatchAndNumber();

			int randomNumber = RandomWithinRange.RandomNumber(Global.RandomIntegerLowest, Global.RandomIntegerHighest);
			int randomDelay = RandomWithinRange.RandomNumber(Global.DelayLowest, Global.DelayHighest, Global.DelayMultiplier);

			await Task.Delay(5000);

			batchAndNumber.Number = randomNumber;
			batchAndNumber.Batch = batch;

			var MultiplierManager = new MultiplierManager();
			BatchAndNumber batchAndNumberTask = await Multiply(batchAndNumber);
			//BatchAndNumber batchAndNumberFinal = batchAndNumberTask.Result;

			return batchAndNumberTask;

		}

		public async Task<BatchAndNumber> Multiply(BatchAndNumber batchAndNumber)
		{
			BatchAndNumber batchAndNumberMulti = new BatchAndNumber();

			int multiplier = RandomWithinRange.RandomNumber(Global.MultiplierLowest, Global.MultiplierHighest);
			int multipliedNumber = multiplier * batchAndNumber.Number;
			int randomDelay = RandomWithinRange.RandomNumber(Global.DelayLowest, Global.DelayHighest, Global.DelayMultiplier);

			await Task.Delay(5000);

			batchAndNumberMulti.Batch = batchAndNumber.Batch;
			batchAndNumberMulti.Number = multipliedNumber;

			return batchAndNumberMulti;
		}

		//public class GeneratorManager
		//{


		//}

		//public class MultiplierManager
		//{
			
		//}


	}
}
