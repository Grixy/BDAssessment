﻿using System;
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
            return await _context.Batches.ToListAsync();
        }

        // GET: api/Batches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Batch>> GetBatch(int id)
        {
            var batch = await _context.Batches.FindAsync(id);

            if (batch == null)
            {
                return NotFound();
            }

            return batch;
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