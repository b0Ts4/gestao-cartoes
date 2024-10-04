using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gestao_cartoes_bancarios.Models;

namespace gestao_cartoes_bancarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalhesCartaoController : ControllerBase
    {
        private readonly DetalhesCartaoContext _context;

        public DetalhesCartaoController(DetalhesCartaoContext context)
        {
            _context = context;
        }

        // GET: api/DetalhesCartao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalhesCartao>>> GetDetalhesCartao()
        {
            return await _context.DetalhesCartao.ToListAsync();
        }

        // GET: api/DetalhesCartao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalhesCartao>> GetDetalhesCartao(int id)
        {
            var detalhesCartao = await _context.DetalhesCartao.FindAsync(id);

            if (detalhesCartao == null)
            {
                return NotFound();
            }

            return detalhesCartao;
        }

        // PUT: api/DetalhesCartao/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalhesCartao(int id, DetalhesCartao detalhesCartao)
        {
            if (id != detalhesCartao.DetalhesCartaoId)
            {
                return BadRequest();
            }

            _context.Entry(detalhesCartao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalhesCartaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.DetalhesCartao.ToListAsync());
        }

        // POST: api/DetalhesCartao
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalhesCartao>> PostDetalhesCartao(DetalhesCartao detalhesCartao)
        {
            _context.DetalhesCartao.Add(detalhesCartao);
            await _context.SaveChangesAsync();

            return Ok(await _context.DetalhesCartao.ToListAsync());
        }

        // DELETE: api/DetalhesCartao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalhesCartao(int id)
        {
            var detalhesCartao = await _context.DetalhesCartao.FindAsync(id);
            if (detalhesCartao == null)
            {
                return NotFound();
            }

            _context.DetalhesCartao.Remove(detalhesCartao);
            await _context.SaveChangesAsync();

            return Ok(await _context.DetalhesCartao.ToListAsync());
        }

        private bool DetalhesCartaoExists(int id)
        {
            return _context.DetalhesCartao.Any(e => e.DetalhesCartaoId == id);
        }
    }
}
