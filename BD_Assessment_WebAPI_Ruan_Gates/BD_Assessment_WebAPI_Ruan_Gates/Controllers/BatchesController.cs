using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BD_Assessment_WebAPI_Ruan_Gates.Models;

namespace BD_Assessment_WebAPI_Ruan_Gates.Datalayer
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchesController : ControllerBase
    {
        private readonly BatchContext _context;

        public BatchesController(BatchContext context)
        {
            _context = context;
        }

        // GET: api/Batches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batch>>> GetBatches()
        {
            //var data = await _context.Batches
            //    .Include(BatchAndNumberInput => BatchAndNumberInput.BatchAndNumberInput)
            //    .Include(BatchElements => BatchElements.BatchElements)
            //    .ThenInclude(NumberInBatch => NumberInBatch.NumbersInBatch)
            //    .ToListAsync();



            return await _context.Batches
                .Include(BatchAndNumberInput => BatchAndNumberInput.BatchAndNumberInput)
                .Include(BatchElements => BatchElements.BatchElements)
                .ThenInclude(NumberInBatch => NumberInBatch.NumbersInBatch)
                .ToListAsync();
        }

        // GET: api/Batches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Batch>> GetBatch(int id)
        {
            var data = await _context.Batches
                .Include(BatchAndNumberInput => BatchAndNumberInput.BatchAndNumberInput)
                .Include(BatchElements => BatchElements.BatchElements)
                .ThenInclude(NumberInBatch => NumberInBatch.NumbersInBatch)
                .Where(x => x.CollectionId == 209)
                .ToListAsync();

            if (data == null)
            {
                return NotFound();
            }

            //It seems that EF is quite prone to circular loops when returning relational data. I am going to parse and return through ViewModels to prevent this on the client-side.
            List<BatchViewModel> collection = new List<BatchViewModel>();
            foreach (Batch b in data)
            {
                BatchAndNumberInputViewModel batchAndNumberInput = new BatchAndNumberInputViewModel
                {
                    RequestId = b.BatchAndNumberInput.RequestId,
                    Batches = b.BatchAndNumberInput.Batches,
                    Numbers = b.BatchAndNumberInput.Numbers
                };

                List<BatchElementViewModel> batchElementList = new List<BatchElementViewModel>();
                foreach (BatchElement batchElement in b.BatchElements)
                {

                    List<NumberInBatchViewModel> numberInBatchViewModelList = new List<NumberInBatchViewModel>();
                    foreach (NumberInBatch numberInBatch in batchElement.NumbersInBatch)
                    {
                        NumberInBatchViewModel numberInBatchViewModel = new NumberInBatchViewModel
                        {
                            Number = numberInBatch.Number,
                            NumberId = numberInBatch.NumberId
                        };
                        numberInBatchViewModelList.Add(numberInBatchViewModel);
                    }

                    BatchElementViewModel batchElementViewModel = new BatchElementViewModel
                    {
                        BatchId = batchElement.BatchId,
                        Aggregate = batchElement.Aggregate,
                        BatchNumber = batchElement.BatchNumber,
                        NumbersRemaining = batchElement.NumbersRemaining,
                        NumbersInBatch = numberInBatchViewModelList
                    };

                    batchElementList.Add(batchElementViewModel);
                }

                BatchViewModel batchViewModel = new BatchViewModel
                {
                    RequestId = b.RequestId,
                    GrandTotal = b.GrandTotal,
                    BatchAndNumberInput = batchAndNumberInput,
                    BatchElements = batchElementList
                };

                collection.Add(batchViewModel);
            }

            return Ok(collection);

            //var batch = await _context.Batches.FindAsync(id);

            //if (batch == null)
            //{
            //    return NotFound();
            //}

            //return batch;
        }

        // PUT: api/Batches/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatch(int id, Batch batch)
        {
            if (id != batch.RequestId)
            {
                return BadRequest();
            }

            _context.Entry(batch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Batches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Batch>> PostBatch(Batch batch)
        {
            _context.Batches.Add(batch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBatch", new { id = batch.RequestId }, batch);
        }

        // DELETE: api/Batches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Batch>> DeleteBatch(int id)
        {
            var batch = await _context.Batches.FindAsync(id);
            if (batch == null)
            {
                return NotFound();
            }

            _context.Batches.Remove(batch);
            await _context.SaveChangesAsync();

            return batch;
        }

        private bool BatchExists(int id)
        {
            return _context.Batches.Any(e => e.RequestId == id);
        }
    }
}
