using Microsoft.AspNetCore.Mvc;
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<string> products = new List<string>
        {
            "Phone",
            "Laptop",
            "Tablet"
        };

        // GET: api/products
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(products);
        }

        // GET: api/products/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0 || id >= products.Count)
                return NotFound();

            return Ok(products[id]);
        }

        // POST: api/products
        [HttpPost]
        public IActionResult Post([FromBody] string product)
        {
            products.Add(product);
            return Created("", product);
        }

        // PUT: api/products/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string product)
        {
            if (id < 0 || id >= products.Count)
                return NotFound();

            products[id] = product;
            return NoContent();
        }

        // DELETE: api/products/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= products.Count)
                return NotFound();

            products.RemoveAt(id);
            return NoContent();
        }
    }
}
