using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/facts")]
[ApiController]
public class FactsController : ControllerBase
{
    private readonly MyDbContext _context;
    public FactsController(MyDbContext context)
    {
        _context = context;
    }
    // GET: api/Facts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fact>>> GetFacts()
    {
        // Retrieve all facts from the database
        var facts = await _context.Facts.ToListAsync(); 
        int[]ids = new int [facts.Count]; 
        int i = 0;
        foreach(var f in facts)
        {
            ids[i] = f.Id;
            i++;
        }
        Random random = new();
        int randomNr = random.Next(0, ids.Length);
        var fact = await _context.Facts.FindAsync(ids[randomNr]);
        // If there are no facts in the database, return a 404 Not Found response
        if (facts == null)
        {
            return NotFound();
        }
        // Return a 200 OK response with the list of facts
        return Ok(fact);
    }
    //GET : api/Facts/id
    [HttpGet("{id}")]
    public async Task<ActionResult<Fact>> GetFact(int id)
    {
        var fact = await _context.Facts.FindAsync(id);
        if (fact == null)
        {
            return NotFound();
        }
        return Ok(fact);
    }
    //POST  : api/Facts
    [HttpPost]
    public async Task<ActionResult<Fact>> PostFact(Fact fact)
    {
        _context.Facts.Add(fact);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetFact", new { id = fact.Id }, fact);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFact(int id, Fact fact)
    {
        if(!_context.Facts.Any(f => f.Id == id))
        {
            return NotFound();
        }
        _context.Facts.Update(fact);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFact(int id)
    {
        var fact = await _context.Facts.FindAsync(id);
        if(fact == null)
        {
            return NotFound();
        }
        _context.Facts.Remove(fact);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}