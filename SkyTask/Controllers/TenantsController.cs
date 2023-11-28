using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkyTask.Models;

namespace SkyTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenantsController : ControllerBase
    {
        private readonly SkyDbContext _context;

        public TenantsController(SkyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Tenant>> Get()
        {
            return await _context.Tenants.ToListAsync();
        }

        [HttpGet("Get/{id}")]
        public async Task<Tenant?> Get(Guid id)
        {
            return await _context.Tenants.Where(x => x.TenantId == id).FirstOrDefaultAsync();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([Bind] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                tenant.TenantId = Guid.NewGuid();
                _context.Add(tenant);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([Bind] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tenant);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenantExists(tenant.TenantId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return BadRequest();
        }

        private bool TenantExists(Guid id)
        {
            return _context.Tenants.Any(e => e.TenantId == id);
        }
    }
}
