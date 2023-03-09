﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;

namespace StyleSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblFavoritesController : ControllerBase
    {
        private readonly DbStyleSphereContext _context;

        public TblFavoritesController(DbStyleSphereContext context)
        {
            _context = context;
        }

        // GET: api/TblFavorites
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TblFavorite>>> GetTblFavorites()
        //{
        //    return await _context.TblFavorites.ToListAsync();
        //}

        [HttpGet("customer/{customerId}")]
        public IActionResult GetFavoritesForCustomer(int customerId)
        {
            var favorites = _context.TblFavorites
                                     .Where(f => f.CustomerId == customerId)
                                     .ToList();

            return Ok(favorites);
        }

        //// GET: api/TblFavorites/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TblFavorite>> GetTblFavorite(int id)
        //{
        //    var tblFavorite = await _context.TblFavorites.FindAsync(id);

        //    if (tblFavorite == null)
        //    {
        //        return NotFound();
        //    }

        //    return tblFavorite;
        //}

        // PUT: api/TblFavorites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTblFavorite(int id, TblFavorite tblFavorite)
        //{
        //    if (id != tblFavorite.FavoriteId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tblFavorite).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TblFavoriteExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/TblFavorites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> SaveFavorite(int customerId, int productId)
        {
            // Get the customer and product from the database
            var customer = await _context.TblCustomers.FindAsync(customerId);
            var product = await _context.TblProducts.FindAsync(productId);

            // If either the customer or product is not found, return a 404 error
            if (customer == null || product == null)
            {
                return NotFound();
            }

            // Create a new favorite object and set its properties
            var favorite = new TblFavorite
            {
                CustomerId = customerId,
                ProductId = productId,
                ActiveStatus = true,
                Customer = customer,
                Product = product
            };

            // Add the new favorite to the database and save changes
            _context.TblFavorites.Add(favorite);
            await _context.SaveChangesAsync();

            // Return a success response
            return Ok();
        }

        //// DELETE: api/TblFavorites/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTblFavorite(int id)
        //{
        //    var tblFavorite = await _context.TblFavorites.FindAsync(id);
        //    if (tblFavorite == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TblFavorites.Remove(tblFavorite);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TblFavoriteExists(int id)
        //{
        //    return _context.TblFavorites.Any(e => e.FavoriteId == id);
        //}
    }
}
