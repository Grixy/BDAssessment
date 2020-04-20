﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BD_Assessment_WebAPI_Ruan_Gates.Models
{
	public class BatchAndNumberInputViewModel
	{
		[Key]
		public int RequestId { get; set; }

		[Required]
		[Column(TypeName = "varchar(2)")]
		public string Batches { get; set; }

		[Required]
		[Column(TypeName = "varchar(2)")]
		public string Numbers { get; set; }
	}
}
