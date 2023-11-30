using Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {

        private readonly DataContext _context;

        public IngredientsController(ILogger<IngredientsController> logger, DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// GET api/get 
        /// </summary>
        /// <returns>List of Current Ingredients</returns>
        [HttpGet(Name = "GetIngredients")]
        public ActionResult<List<Ingredients>> Get()
        {
            return _context.Ingredient.ToList();
        }

        [HttpPost(Name = "Create")]
        public ActionResult<Ingredients> Create([FromBody]Ingredients request)
        {
            var ingredient = new Ingredients 
            {
                Type = request.Type,
                Name = request.Name,
                Quantity = request.Quantity
            };

            _context.Ingredient.Add(ingredient);
            var success = _context.SaveChanges() > 0;

            if(success)
            {
                return Ok(ingredient);
            }

            throw new Exception("Error adding ingredient");

        }
    }
}