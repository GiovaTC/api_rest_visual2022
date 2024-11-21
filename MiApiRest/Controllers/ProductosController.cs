using Microsoft.AspNetCore.Mvc;

namespace MiApiRest.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private static List<Producto> productos = new List<Producto>
    {
        new Producto { Id = 1, Nombre = "Laptop", Precio = 1500.99M, Stock = 10 },
        new Producto { Id = 2, Nombre = "Mouse", Precio = 25.50M, Stock = 100 }
    };

        // GET: api/Productos
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            return Ok(productos);
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return NotFound();
            return Ok(producto);
        }

        // POST: api/Productos
        [HttpPost]
        public ActionResult<Producto> Post([FromBody] Producto nuevoProducto)
        {
            nuevoProducto.Id = productos.Max(p => p.Id) + 1;
            productos.Add(nuevoProducto);
            return CreatedAtAction(nameof(Get), new { id = nuevoProducto.Id }, nuevoProducto);
        }

        // PUT: api/Productos/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Producto productoActualizado)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return NotFound();

            producto.Nombre = productoActualizado.Nombre;
            producto.Precio = productoActualizado.Precio;
            producto.Stock = productoActualizado.Stock;

            return NoContent();
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return NotFound();

            productos.Remove(producto);
            return NoContent();
        }
    }

}
