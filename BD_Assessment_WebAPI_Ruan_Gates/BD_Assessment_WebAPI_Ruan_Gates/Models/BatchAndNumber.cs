using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD_Assessment_WebAPI_Ruan_Gates.Models
{
	public class BatchAndNumber
	{
		[Key]
		public int RequestId { get; set; }

		public int Batch { get; set; }

		public int Number { get; set; }
	}
}