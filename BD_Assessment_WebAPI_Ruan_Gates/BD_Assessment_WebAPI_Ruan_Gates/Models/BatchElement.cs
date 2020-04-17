using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BD_Assessment_WebAPI_Ruan_Gates.Models
{
	public class BatchElement
	{
		//scalar properties
		[Key]
		public int BatchId { get; set; }

		[Required]
		public int Aggregate { get; set; }

		[Required]
		public int NumbersRemaining { get; set; }

		//navigation properties
		public Batch Batch { get; set; }
		public IList<NumberInBatch> NumbersInBatch { get; set; }
	}
}
