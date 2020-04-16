using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BD_Assessment_WebAPI_Ruan_Gates.Models;

namespace BD_Assessment_WebAPI_Ruan_Gates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberInBatchesController : ControllerBase
    {
        private readonly BatchContext _context;

        public NumberInBatchesController(BatchContext context)
        {
            _context = context;
        }

        // GET: api/NumberInBatches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NumberInBatch>>> GetBatchNumbers()
        {
            return await _context.BatchNumbers.ToListAsync();
        }

        // GET: api/NumberInBatches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NumberInBatch>> GetNumberInBatch(int id)
        {
            var numberInBatch = await _context.BatchNumbers.FindAsync(id);

            if (numberInBatch == null)
            {
                return NotFound();
            }

            return numberInBatch;
        }

        // PUT: api/NumberInBatches/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNumberInBatch(int id, NumberInBatch numberInBatch)
        {
            if (id != numberInBatch.NumberId)
            {
                return BadRequest();
            }

            _context.Entry(numberInBatch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NumberInBatchExists(id))
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

        // POST: api/NumberInBatches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NumberInBatch>> PostNumberInBatch(NumberInBatch numberInBatch)
        {
            _context.BatchNumbers.Add(numberInBatch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNumberInBatch", new { id = numberInBatch.NumberId }, numberInBatch);
        }

        // DELETE: api/NumberInBatches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NumberInBatch>> DeleteNumberInBatch(int id)
        {
            var numberInBatch = await _context.BatchNumbers.FindAsync(id);
            if (numberInBatch == null)
            {
                return NotFound();
            }

            _context.BatchNumbers.Remove(numberInBatch);
            await _context.SaveChangesAsync();

            return numberInBatch;
        }

        private bool NumberInBatchExists(int id)
        {
            return _context.BatchNumbers.Any(e => e.NumberId == id);
        }
    }
}
