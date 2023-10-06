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
    public class PlayersController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public PlayersController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: api/Players
        [HttpGet]
        [Route("GetPlayers")]
        public async Task<ActionResult<IEnumerable<PlayerViewModels>>> GetPlayers()
        {
            var players = db.Players.ToList();
            if (players.Count == 0)
            {
                return NotFound();
            }

            List<PlayerViewModels> playerList = new List<PlayerViewModels>();
            foreach (var data in players)
            {

                var tempPlayer = new PlayerViewModels
                {
                    PlayerId = data.PlayerId,
                    PlayerName = data.PlayerName,
                    Position = data.Position,
                    PlaceOfBirth = data.PlaceOfBirth,
                    DateOftBirth = data.DateOftBirth,
                    Nationality = data.Nationality,
                    CreatedAt = data.CreatedAt,
                    UpdatedAt = data.UpdatedAt
                };

                List<CareerViewModels> careerList = new List<CareerViewModels>();
                var careers = db.Careers.Where(x => x.PlayerId == data.PlayerId).ToList();
                if (careers.Count > 0)
                {
                    foreach (var career in careers)
                    {
                        var tempCareer = new CareerViewModels
                        {
                            CareerId = career.PlayerId,
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
                            TeamViewModels teamDetail = new TeamViewModels
                            {
                                TeamId = team.TeamId,
                                TeamName = team.TeamName,
                                Country = team.Country,
                                CreatedAt = team.CreatedAt,
                                UpdatedAt = team.UpdatedAt
                            };

                            tempCareer.TeamDetail = teamDetail;
                        }

                        careerList.Add(tempCareer);

                    }
                }

                tempPlayer.CareerDetails = careerList;
                playerList.Add(tempPlayer);
                
            }

            return playerList;
        }

        // GET: api/Players/5
        [HttpGet]
        [Route("GetPlayerById")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            if (db.Players == null)
            {
                return NotFound();
            }
            var player = await db.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("UpdatePlayer")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.PlayerId)
            {
                return BadRequest();
            }

            db.Entry(player).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("AddPlayer")]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            if (db.Players == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Players'  is null.");
            }
            db.Players.Add(player);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetPlayer", new { id = player.PlayerId }, player);
        }

        // DELETE: api/Players/5
        [HttpDelete]
        [Route("DeletePlayer")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            if (db.Players == null)
            {
                return NotFound();
            }
            var player = await db.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            db.Players.Remove(player);
            await db.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerExists(int id)
        {
            return (db.Players?.Any(e => e.PlayerId == id)).GetValueOrDefault();
        }
    }
}
