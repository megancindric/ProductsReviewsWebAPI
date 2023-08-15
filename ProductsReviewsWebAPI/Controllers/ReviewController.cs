using Microsoft.AspNetCore.Mvc;
using ProductsReviewsWebAPI.Data;
using ProductsReviewsWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsReviewsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ReviewController>
        [HttpGet]
        public IActionResult Get()
        {
            var reviews = _context.Reviews.ToList();
            return Ok(reviews);
        }

        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        // POST api/<ReviewController>
        [HttpPost]
        public IActionResult Post([FromBody] Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Reviews.Add(review);
                _context.SaveChanges();
                return StatusCode(201, review);
            }
            return BadRequest(ModelState);
        }

        // PUT api/<ReviewController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Review review)
        {
            var reviewToUpdate = _context.Reviews.Find(id);
            if (reviewToUpdate == null) 
            {
                return NotFound();
            }
            reviewToUpdate.Text = review.Text;
            reviewToUpdate.Rating = review.Rating;
            _context.Reviews.Update(reviewToUpdate);
            _context.SaveChanges();
            return Ok(reviewToUpdate);
        }

        // DELETE api/<ReviewController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review == null)
            {
                return NotFound();
            }
            _context.Reviews.Remove(review);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
