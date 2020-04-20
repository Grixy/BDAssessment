using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BD_Assessment_WebAPI_Ruan_Gates.Models
{
	public class BatchElementViewModel
	{
		[Key]
		public int BatchId { get; set; }

		[Required]
		public int Aggregate { get; set; }

		[Required]
		public int BatchNumber { get; set; }

		[Required]
		public int NumbersRemaining { get; set; }

		public IList<NumberInBatchViewModel> NumbersInBatch { get; set; }
	}
}
