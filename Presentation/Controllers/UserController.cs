using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace TakeLeaveMngSystem.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        //34f81e1e-eff0-443a-9704-2a4819961c52
        //private readonly UserService _userService;

        //public UserController(UserService userService)
        //{
        //    _userService = userService;
        //}

        //[HttpGet("/get-all")]
        //public ActionResult GetAll(string? input)
        //{
        //    //throw new ValidationException("inout khong duoc de trong");
        //    //throw new Exception("Lỗi test Global Exception Middleware!");

        //    Global.WriteLog(TYPE_ERROR.INFO, "test ok");

        //    // Giả vờ lỗi do truy cập thuộc tính của một object null
        //    string upperName = input.ToUpper();

        //    return Ok(new { upperName });

        //    //return Ok();
        //}

        //[HttpGet("{id}")]
        //public ActionResult GetById(Guid id)
        //{
        //    var result = new { Id = id };
        //    return Ok(result);
        //}

        //[HttpPost]
        //public ActionResult Create(Guid id)
        //{
        //    return Ok(id);
        //}

        //[HttpPut("{id}")]
        //public ActionResult Update(Guid id)
        //{
        //    return Ok(id);
        //}

        //[HttpDelete("{id}")]
        //public ActionResult Delete(Guid id)
        //{
        //    return Ok(id);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetProduct(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return product;
        //}

        //[HttpPost]
        //public async Task<ActionResult<Product>> CreateProduct(Product product)
        //{
        //    _context.Products.Add(product);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateProduct(int id, Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(product).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}
    }
}
