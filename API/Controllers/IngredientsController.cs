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

        ///<summary>
        /// PUT api/post
        ///</summary
        ///<param>JSON Field with values to update</param>
        ///<returns>An updated Ingredient</returns>

        [HttpPut(Name = "Update")]
        public ActionResult<Ingredients> Update([FromBody]Ingredients request, string change)
        {
            var ing = _context.Ingredient.Find(request.Name);

            if(ing == null)
            {
                throw new Exception("Could not find chosen Ingredient");
            }

            int quantity = 0;
            if(change == "add")
                quantity = ing.Quantity + request.Quantity;
            else
            {
                quantity = ing.Quantity - request.Quantity;
                if (quantity < 0)
                    throw new Exception($"Requested amount must be smaller than the current amount of {ing.Quantity}");              
            }

            //Update the selected Ingredient Quantity
            ing.Quantity = quantity;

            var success = _context.SaveChanges() > 0;

            if(success)
            {
                return Ok(ing);
            }

            throw new Exception("Error Updating Ingredient");
        }
    }
}