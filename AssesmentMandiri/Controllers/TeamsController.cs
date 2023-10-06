using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssesmentMandiri.Models;

namespace AssesmentMandiri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public TeamsController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: api/Teams
        [HttpGet]
        [Route("GetTeams")]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
          if (db.Teams == null)
          {
              return NotFound();
          }
            return await db.Teams.ToListAsync();
        }

        // GET: api/Teams/5
        [HttpGet]
        [Route("GetTeamById")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
          if (db.Teams == null)
          {
              return NotFound();
          }
            var team = await db.Teams.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("UpdateTeam")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.TeamId)
            {
                return BadRequest();
            }

            db.Entry(team).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: api/Teams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("AddTeam")]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
          if (db.Teams == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Teams'  is null.");
          }
            db.Teams.Add(team);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetTeam", new { id = team.TeamId }, team);
        }

        // DELETE: api/Teams/5
        [HttpDelete]
        [Route("DeleteTeam")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            if (db.Teams == null)
            {
                return NotFound();
            }
            var team = await db.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            db.Teams.Remove(team);
            await db.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamExists(int id)
        {
            return (db.Teams?.Any(e => e.TeamId == id)).GetValueOrDefault();
        }
    }
}
