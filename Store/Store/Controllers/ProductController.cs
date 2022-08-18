using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private const string Path = "C:\\Users\\vladi\\source\\repos\\Store\\Store\\data.json";

        [HttpGet] 
        public async Task<ActionResult<StoreData>> Get()
        { 
            return Ok(Program.Data); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = Program.Data.Products.Find(p => p.Id == id);

            if (product == null)
                return BadRequest("Product not found!");

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<StoreData>> AddProduct(Product product)
        {
            Program.Data.Products.Add(product);

            SaveData();

            return Ok(Program.Data);
        }

        [HttpPut]
        public async Task<ActionResult<StoreData>> UpdateProduct(Product product)
        {
            var pr = Program.Data.Products.Find(p => p.Id == product.Id);

            if (pr == null) 
                return BadRequest("Product not found");

            pr.Id = product.Id;
            pr.Name = product.Name;   
            pr.Description = product.Description;
            pr.Amount = product.Amount;
            pr.Price = product.Price;

            SaveData();

            return Ok(Program.Data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StoreData>> Delete(int id)
        {
            var product = Program.Data.Products.Find(p => p.Id == id);

            if (product == null)
                return BadRequest("Product not found!");

            Program.Data.Products.Remove(product);

            var writeJson = JsonConvert.SerializeObject(Program.Data);

            SaveData();

            return Ok(Program.Data);
        }

        private void SaveData()
        {
            var writeJson = JsonConvert.SerializeObject(Program.Data);

            try
            {
                System.IO.File.WriteAllText(Path, writeJson);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
