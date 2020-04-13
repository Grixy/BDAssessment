using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BD_Assessment_WebAPI_Ruan_Gates.Models
{
	public class Batch
	{
		[Key]
		public int BatchId { get; set; }

		[Required]
		[Column(TypeName = "varchar(16)")]
		public string CardNumber { get; set; }
	}


}
