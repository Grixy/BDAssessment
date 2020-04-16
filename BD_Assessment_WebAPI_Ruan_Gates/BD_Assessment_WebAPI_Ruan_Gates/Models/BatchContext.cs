using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace BD_Assessment_WebAPI_Ruan_Gates.Models
{
    public class BatchContext : DbContext
    {
        public BatchContext(DbContextOptions<BatchContext> options) : base(options)
        { }

        public DbSet<Batch> Batches { get; set; }

        public DbSet<BatchElement> BatchElements { get; set; }

        public DbSet<NumberInBatch> BatchNumbers { get; set; }

        public DbSet<BatchAndNumberInput> BatchAndNumberInput { get; set; }
    }
}
