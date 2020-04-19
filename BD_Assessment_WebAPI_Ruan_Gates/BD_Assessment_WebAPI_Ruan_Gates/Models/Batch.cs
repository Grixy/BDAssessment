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
		public int RequestId { get; set; }

		public int GrandTotal { get; set; }

		public BatchAndNumberInput BatchAndNumberInput { get; set; }

		public IList<BatchElement> BatchElements { get; set; }
	}


}
