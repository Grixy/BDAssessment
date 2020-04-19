using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BD_Assessment_WebAPI_Ruan_Gates.Models;
using BD_Assessment_WebAPI_Ruan_Gates.Processors;

namespace BD_Assessment_WebAPI_Ruan_Gates.Datalayer
{
	[Route("api/[controller]")]
	[ApiController]
	public class NumbersAndBatchesData : ControllerBase
	{
		private BatchContext _context;

		public NumbersAndBatchesData()
		{
		}

		public NumbersAndBatchesData(BatchContext context)
		{
			_context = context;
		}

		public async Task WriteBatchAndNumberToDatabase(BatchAndNumberFullInfo batchAndNumberFullInfo)
		{
			var optionsBuilder = new DbContextOptionsBuilder<BatchContext>();
			optionsBuilder.UseSqlServer("Server=(local)\\sqlexpress;Database=RuanGatesBDAssessmentDB;Trusted_Connection=True;MultipleActiveResultSets=True;");

			var batch = new Batch();

			batch.BatchElements = new List<BatchElement>();
			batch.BatchAndNumberInput = new BatchAndNumberInput();
			batch.BatchAndNumberInput.Batches = "00";
			batch.BatchAndNumberInput.Numbers = "00";

			BatchElement batchElement = new BatchElement();
			batchElement.BatchNumber = batchAndNumberFullInfo.BatchAndNumber.Batch;
			batchElement.NumbersRemaining = 4;
			batchElement.Aggregate = 12;
			batchElement.NumbersInBatch = new List<NumberInBatch>();

			NumberInBatch number = new NumberInBatch();
			number.Number = batchAndNumberFullInfo.BatchAndNumber.Number;

			batchElement.NumbersInBatch.Add(number);
			batch.BatchElements.Add(batchElement);

			batch.GrandTotal = 99;

			using (var ctx = new BatchContext(optionsBuilder.Options))
			{
				ctx.Batches.Add(batch);
				await ctx.SaveChangesAsync();
			}
		}
	}
}
