using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssesmentMandiri.Models;
using Microsoft.CodeAnalysis;

namespace AssesmentMandiri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareersController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public CareersController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: api/Careers
        [HttpGet]
        [Route("GetCareers")]
        public async Task<ActionResult<IEnumerable<CareerViewModels>>> GetCareers()
        {
            var careers = db.Careers.ToList();
            if (careers.Count == 0)
            {
                return NotFound();
            }

            List<CareerViewModels> careerList = new List<CareerViewModels>();
            foreach(var career in careers)
            {
                var tempCareer = new CareerViewModels
                {
                    CareerId = career.CareerId,
                    PlayerId = career.PlayerId,
                    TeamId = career.TeamId,
                    JoinDate = career.JoinDate,
                    EndDate = career.EndDate,
                    Appearances = career.Appearances,
                    Goals = career.Goals,
                    Assists = career.Assists,
                    Cleansheets = career.cleansheets,
                    YellowCards = career.YellowCards,
                    RedCards = career.RedCards,
                    CreatedAt = career.CreatedAt,
                    UpdatedAt = career.UpdatedAt
                };

                var team = db.Teams.FirstOrDefault(x => x.TeamId == career.TeamId);
                if (team != null)
                {
                    var tempTeam = new TeamViewModels
                    {
                        TeamId = team.TeamId,
                        TeamName = team.TeamName,
                        Country = team.Country,
                        CreatedAt = team.CreatedAt,
                        UpdatedAt = team.UpdatedAt,
                    };

                    tempCareer.TeamDetail = tempTeam;
                }

                var player = db.Players.FirstOrDefault(x => x.PlayerId == career.PlayerId);
                if (player != null)
                {
                    var tempPlayer = new PlayerViewModels
                    {
                        PlayerId = player.PlayerId,
                        PlayerName = player.PlayerName,
                        Position = player.Position,
                        PlaceOfBirth = player.PlaceOfBirth,
                        DateOftBirth = player.DateOftBirth,
                        Nationality = player.Nationality,
                        CreatedAt = player.CreatedAt,
                        UpdatedAt = player.UpdatedAt,
                    };

                    tempCareer.PlayerDetail = tempPlayer;
                }

                careerList.Add(tempCareer);
            }

            return careerList;
        }

        // GET: api/Careers/5
        [HttpGet]
        [Route("GetCareerById")]
        public async Task<ActionResult<Career>> GetCareer(int id)
        {
            if (db.Careers == null)
            {
                return NotFound();
            }
            var career = await db.Careers.FindAsync(id);

            if (career == null)
            {
                return NotFound();
            }

            return career;
        }

        // PUT: api/Careers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("UpdateCareer")]
        public async Task<IActionResult> PutCareer(int id, Career career)
        {
            if (id != career.CareerId)
            {
                return BadRequest();
            }

            db.Entry(career).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CareerExists(id))
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

        // POST: api/Careers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("AddCareer")]
        public async Task<ActionResult<Career>> PostCareer(Career career)
        {

            var checkPlayer = db.Players.FirstOrDefault(x => x.PlayerId == career.PlayerId);
            if (checkPlayer == null)
            {
                return Problem("Player not found");
            }

            var checkTeam = db.Teams.FirstOrDefault(x => x.TeamId == career.TeamId);
            if (checkTeam == null)
            {
                return Problem("Team not found");
            }

            var checkCareer = db.Careers.FirstOrDefault(x => x.PlayerId == career.PlayerId && x.TeamId == career.TeamId && x.EndDate == null);
            if (checkCareer != null)
            {
                return Problem("Player career already added.");
            }

            if (db.Careers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Careers'  is null.");
            }
            db.Careers.Add(career);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetCareer", new { id = career.CareerId }, career);
        }

        // DELETE: api/Careers/5
        [HttpDelete]
        [Route("DeleteCareer")]
        public async Task<IActionResult> DeleteCareer(int id)
        {
            if (db.Careers == null)
            {
                return NotFound();
            }
            var career = await db.Careers.FindAsync(id);
            if (career == null)
            {
                return NotFound();
            }

            db.Careers.Remove(career);
            await db.SaveChangesAsync();

            return NoContent();
        }

        private bool CareerExists(int id)
        {
            return (db.Careers?.Any(e => e.CareerId == id)).GetValueOrDefault();
        }
    }
}
