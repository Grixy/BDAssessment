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
    public class BatchElementsController : ControllerBase
    {
        private readonly BatchContext _context;

        public BatchElementsController(BatchContext context)
        {
            _context = context;
        }

        // GET: api/BatchElements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BatchElement>>> GetBatchElements()
        {
            return await _context.BatchElements.ToListAsync();
        }

        // GET: api/BatchElements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BatchElement>> GetBatchElement(int id)
        {
            var batchElement = await _context.BatchElements.FindAsync(id);

            if (batchElement == null)
            {
                return NotFound();
            }

            return batchElement;
        }

        // PUT: api/BatchElements/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatchElement(int id, BatchElement batchElement)
        {
            if (id != batchElement.BatchId)
            {
                return BadRequest();
            }

            _context.Entry(batchElement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatchElementExists(id))
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

        // POST: api/BatchElements
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BatchElement>> PostBatchElement(BatchElement batchElement)
        {
            _context.BatchElements.Add(batchElement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBatchElement", new { id = batchElement.BatchId }, batchElement);
        }

        // DELETE: api/BatchElements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BatchElement>> DeleteBatchElement(int id)
        {
            var batchElement = await _context.BatchElements.FindAsync(id);
            if (batchElement == null)
            {
                return NotFound();
            }

            _context.BatchElements.Remove(batchElement);
            await _context.SaveChangesAsync();

            return batchElement;
        }

        private bool BatchElementExists(int id)
        {
            return _context.BatchElements.Any(e => e.BatchId == id);
        }
    }
}
