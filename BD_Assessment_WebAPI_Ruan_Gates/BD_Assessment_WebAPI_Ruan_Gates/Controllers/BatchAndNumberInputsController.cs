using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BD_Assessment_WebAPI_Ruan_Gates.Models;
using BD_Assessment_WebAPI_Ruan_Gates.Processors;

namespace BD_Assessment_WebAPI_Ruan_Gates.Datalayer
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchAndNumberInputsController : ControllerBase
    {
        private readonly BatchContext _context;

        public BatchAndNumberInputsController(BatchContext context)
        {
            _context = context;
        }

        // GET: api/BatchAndNumberInputs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BatchAndNumberInput>>> GetBatchAndNumberInput()
        {
            return await _context.BatchAndNumberInput.ToListAsync();
        }

        // GET: api/BatchAndNumberInputs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BatchAndNumberInput>> GetBatchAndNumberInput(int id)
        {
            var batchAndNumberInput = await _context.BatchAndNumberInput.FindAsync(id);

            if (batchAndNumberInput == null)
            {
                return NotFound();
            }

            return batchAndNumberInput;
        }

        // PUT: api/BatchAndNumberInputs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatchAndNumberInput(int id, BatchAndNumberInput batchAndNumberInput)
        {
            if (id != batchAndNumberInput.RequestId)
            {
                return BadRequest();
            }

            _context.Entry(batchAndNumberInput).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatchAndNumberInputExists(id))
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

        // POST: api/BatchAndNumberInputs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BatchAndNumberInput>> PostBatchAndNumberInput(BatchAndNumberInput batchAndNumberInput)
        {
            
            int totalBatches = Int32.Parse(batchAndNumberInput.Batches);
            List<Task> listOfTasks = new List<Task>();

            for (int z = 1; z <= totalBatches; z++)
            {
                BatchesAndNumbersProcessor processor = new BatchesAndNumbersProcessor();
                BatchAndNumber batchAndNumber = new BatchAndNumber
                {
                    Batch = z,
                    //In this case, our number will indicate the total numbers (or 'number-of-numbers') in this batch.
                    Number = int.Parse(batchAndNumberInput.Numbers)
                };
                listOfTasks.Add(processor.PerformBatchOperations(batchAndNumberInput));
            }

            await Task.WhenAll(listOfTasks);

            _context.BatchAndNumberInput.Add(batchAndNumberInput);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBatchAndNumberInput", new { id = batchAndNumberInput.RequestId }, batchAndNumberInput);
        }

        // DELETE: api/BatchAndNumberInputs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BatchAndNumberInput>> DeleteBatchAndNumberInput(int id)
        {
            var batchAndNumberInput = await _context.BatchAndNumberInput.FindAsync(id);
            if (batchAndNumberInput == null)
            {
                return NotFound();
            }

            _context.BatchAndNumberInput.Remove(batchAndNumberInput);
            await _context.SaveChangesAsync();

            return batchAndNumberInput;
        }

        private bool BatchAndNumberInputExists(int id)
        {
            return _context.BatchAndNumberInput.Any(e => e.RequestId == id);
        }
    }
}
