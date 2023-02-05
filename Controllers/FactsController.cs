using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Dapper;

[Route("api/facts")]
[ApiController]
public class FactsController : ControllerBase
{
    private readonly ILogger<FactsController> _logger;
    public FactsController(ILogger<FactsController> logger)
    {
        _logger = logger;
    }
    // GET: api/Facts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fact>>> GetFacts()
    {
        try
        {
            // Retrieve all facts from the database 
            List<int> ids = new();
            using (MySqlConnection con = new("connectionstring här"))
            {
                string query = "SELECT id FROM facts;";
                ids = con.Query<int>(query).ToList();
            }

            Random random = new();
            int randomNr = random.Next(0, ids.Count);
            Fact fact = new();
            using(MySqlConnection con2 = new("connectionstring"))
            {
                string query = "SELECT id, description, source, date_added as 'dateadded' " + 
                $"FROM facts WHERE id = {randomNr};";
                fact = con2.QuerySingle<Fact>(query);
            }
            // If there are no facts in the database, return a 404 Not Found response
            if (fact == null)
            {
                return NotFound();
            }
            // Return a 200 OK response with the list of facts
            return Ok(fact);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while processing the request.");
            throw;
        }

    }
    // //GET : api/Facts/id
    // [HttpGet("{id}")]
    // public async Task<ActionResult<Fact>> GetFact(int id)
    // {
    //     var fact = await _context.Facts.FindAsync(id);
    //     if (fact == null)
    //     {
    //         return NotFound();
    //     }
    //     return Ok(fact);
    // }
    // //POST  : api/Facts
    // [HttpPost]
    // public async Task<ActionResult<Fact>> PostFact(Fact fact)
    // {
    //     _context.Facts.Add(fact);
    //     await _context.SaveChangesAsync();
    //     return CreatedAtAction("GetFact", new { id = fact.Id }, fact);
    // }
    // [HttpPut("{id}")]
    // public async Task<IActionResult> PutFact(int id, Fact fact)
    // {
    //     if (!_context.Facts.Any(f => f.Id == id))
    //     {
    //         return NotFound();
    //     }
    //     _context.Facts.Update(fact);
    //     await _context.SaveChangesAsync();
    //     return NoContent();
    // }
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteFact(int id)
    // {
    //     var fact = await _context.Facts.FindAsync(id);
    //     if (fact == null)
    //     {
    //         return NotFound();
    //     }
    //     _context.Facts.Remove(fact);
    //     await _context.SaveChangesAsync();
    //     return NoContent();
    // }
}