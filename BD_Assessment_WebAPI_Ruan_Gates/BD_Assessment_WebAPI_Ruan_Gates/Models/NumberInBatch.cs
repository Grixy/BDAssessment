using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BD_Assessment_WebAPI_Ruan_Gates.Models
{
	public class NumberInBatch
	{
		[Key]
		public int NumberId { get; set; }

		[Required]
		public int Number { get; set; }

		[Required]
		public BatchElement BatchElement { get; set; }
	}
}
