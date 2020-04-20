using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BD_Assessment_WebAPI_Ruan_Gates.Models
{
	public class NumberInBatchViewModel
	{
		[Key]
		public int NumberId { get; set; }

		[Required]
		public int Number { get; set; }

	}
}
