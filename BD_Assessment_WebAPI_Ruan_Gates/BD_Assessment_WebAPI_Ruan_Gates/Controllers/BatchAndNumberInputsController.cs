using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BD_Assessment_WebAPI_Ruan_Gates.Models;
using BD_Assessment_WebAPI_Ruan_Gates.Processors;

namespace BD_Assessment_WebAPI_Ruan_Gates.Controllers
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
            

            var usr = new Batch();
            
            usr.BatchElements = new List<BatchElement>();

            BatchElement b = new BatchElement();
            b.NumbersRemaining = 4;
            b.Aggregate = 12;
            b.NumbersInBatch = new List<NumberInBatch>();

            NumberInBatch n = new NumberInBatch();
            n.Number = 3;

            b.NumbersInBatch.Add(n);
            usr.BatchElements.Add(b);

            usr.GrandTotal = 123;

            _context.Batches.Add(usr);
            await _context.SaveChangesAsync();

            //using (var context = new BatchContext())
            //{
            //    context.Database.EnsureCreated();
            //    context.Add(usr);
            //    context.SaveChanges();
            //}

            //PostBatch(usr);

            //List<Task> listOfTasks = new List<Task>();

            //foreach (var thing in thingsToLoop)
            //{
            //    listOfTasks.Add(DoAsync(thing));
            //}

            //await Task.WhenAll(listOfTasks);

            int totalBatches = Int32.Parse(batchAndNumberInput.Batches);
            int totalNumbers = Int32.Parse(batchAndNumberInput.Numbers);

            int remainingNumbers = 0;

            //List<int> batchList = new List<int>();

            //for (int z = 0; z < totalBatches; z++)
            //{

            //    batchList
            //}




            List<Task<BatchAndNumber>> listOfTasks = new List<Task<BatchAndNumber>>();
            BatchesAndNumbersProcessor processor = new BatchesAndNumbersProcessor();

            for (int z = 1; z <= totalBatches; z++)
            {
                listOfTasks.Add(processor.PerformBatchOperations(z));
            }

            var check = await Task.WhenAll<BatchAndNumber>(listOfTasks);

            //List<int> numbersList = new List<int>();

            //for (int i = 0; i < totalBatches; i++)
            //{
            //    for (int j = 0; j < totalNumbers; j++)
            //    {

            //        var v = await processor.PerformBatchOperations(i, Int32.Parse(batchAndNumberInput.Numbers));
            //    }
            //}


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
