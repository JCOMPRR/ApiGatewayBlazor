using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiGatewayBlazor.SqlServer.Models;

namespace ApiGatewayBlazor.SqlServer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : Controller
    {
        private readonly VentasContext _context;

        public VentasController(VentasContext context)
        {
            _context = context;
        }

        // GET: Ventas
        [HttpGet]
        public async Task<IActionResult> Index()
        {
              return _context.Ventas != null ? 
                          View(await _context.Ventas.ToListAsync()) :
                          Problem("Entity set 'VentasContext.Ventas'  is null.");
        }

        // GET: Ventas/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ventas == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdVenta,IdProducto,IdCliente,Cantidad")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenta,IdProducto,IdCliente,Cantidad")] Venta venta)
        {
            if (id != venta.IdVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.IdVenta))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ventas == null)
            {
                return Problem("Entity set 'VentasContext.Ventas'  is null.");
            }
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
          return (_context.Ventas?.Any(e => e.IdVenta == id)).GetValueOrDefault();
        }
    }
}
