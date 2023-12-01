using Domain;
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
            return _context.Ingredient.OrderBy(i => i.Type).ToList();
        }

        [HttpPost(Name = "AddIngredient")]
        public ActionResult<Ingredients> Create([FromBody]Ingredients request)
        {            
            var ingredient = new Ingredients 
            {
                Type = request.Type,
                Name = request.Name,
                Quantity = request.Quantity
            };
            var ing = _context.Ingredient.FirstOrDefault(i => i.Name == ingredient.Name);

            if (ing == null)
            {
                _context.Ingredient.Add(ingredient);
                var success = _context.SaveChanges() > 0;

                if (success)
                {
                    return Ok(ingredient);
                }
            }
            else
            {
                throw new Exception("Ingredient already exists");
            }
            

            throw new Exception("Error adding ingredient");
        }

        ///<summary>
        /// PUT api/post
        ///</summary
        ///<param>JSON Field with values to update</param>
        ///<returns>An updated Ingredient</returns>

        [HttpPut(Name = "UpdateIngredient")]
        public ActionResult<Ingredients> Update([FromBody]Ingredients request, string change)
        {
            //var ing = _context.Ingredient.Find(request.Id);
            var ing = _context.Ingredient.FirstOrDefault(i => i.Name == request.Name);

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
    
        /// <summary>
        /// DELETE api/delete
        /// Will delete the requested item from the database
        /// based on Id match
        /// </summary>
        [HttpDelete(Name = "Delete Ingredient")]
        public ActionResult<Ingredients> Delete([FromBody]Ingredients request)
        {
            var ing = _context.Ingredient.Find(request.Id);

            if(ing == null)
            {
                throw new Exception("Requested Ingredient was not found.");
            }

            _context.Ingredient.Remove(ing);
            var success = _context.SaveChanges() > 0;

            if(success)
            {
                string message = $"Id: {ing.Id}\nName:{ing.Name} was successfully removed";
                return Ok(message);
            }
            throw new Exception("Failed to delete requested Ingredient");
        }
    }
}