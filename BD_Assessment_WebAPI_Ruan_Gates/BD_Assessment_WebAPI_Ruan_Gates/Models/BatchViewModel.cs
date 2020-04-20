using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BD_Assessment_WebAPI_Ruan_Gates.Models
{
	public class BatchViewModel
	{
		[Key]
		public int RequestId { get; set; }

		public int GrandTotal { get; set; }

		public BatchAndNumberInputViewModel BatchAndNumberInput { get; set; }

		public IList<BatchElementViewModel> BatchElements { get; set; }
	}
}
