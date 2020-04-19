using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BD_Assessment_WebAPI_Ruan_Gates.Models;
using BD_Assessment_WebAPI_Ruan_Gates.Processors;

namespace BD_Assessment_WebAPI_Ruan_Gates.DataLayer
{
	public class NumbersAndBatchesData : ControllerBase
	{
		private readonly BatchContext _context;

		public NumbersAndBatchesData(BatchContext context)
		{
			_context = context;
		}

		public async Task<ActionResult<BatchAndNumberInput>> WriteBatchAndNumberToDatabase (BatchAndNumberInput batchAndNumber)
		{

			var usr = new Batch();

			usr.BatchElements = new List<BatchElement>();
			usr.BatchAndNumberInput = new BatchAndNumberInput();
			usr.BatchAndNumberInput.Batches = "9";
			usr.BatchAndNumberInput.Numbers = "9";

			BatchElement b = new BatchElement();
			b.NumbersRemaining = 4;
			b.Aggregate = 12;
			b.NumbersInBatch = new List<NumberInBatch>();
			

			NumberInBatch n = new NumberInBatch();
			n.Number = 3;

			b.NumbersInBatch.Add(n);
			usr.BatchElements.Add(b);

			usr.GrandTotal = 99;

			_context.Batches.Add(usr);
			await _context.SaveChangesAsync();

			_context.BatchAndNumberInput.Add(batchAndNumber);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetBatchAndNumberInput", new { id = batchAndNumber.RequestId }, batchAndNumber);
		}
	}
}
