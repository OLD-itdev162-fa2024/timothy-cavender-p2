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
            var ing = _context.Ingredient.FirstOrDefault(i => i.Name == request.Name);

            //Add New Ingredient
            if(ing == null)
            {
                var ingredient = new Ingredients
                {
                    Type = request.Type,
                    Name = request.Name,
                    Quantity = request.Quantity
                };

                _context.Ingredient.Add(ingredient);
                var success = _context.SaveChanges() > 0;

                if (success)
                {
                    return Ok(ingredient);
                }
                throw new Exception("Error adding ingredient");
            }
            //Update Existing Record
            {
                ing.Quantity = request.Quantity + ing.Quantity;

                var success = _context.SaveChanges() > 0;

                if (success)
                {
                    return Ok(ing);
                }
                throw new Exception("Error Updating Ingredient");
            }            
        }

        
        /// <summary>
        /// DELETE api/delete
        /// Will delete the requested item from the database
        /// based on Id match
        /// </summary>
        [HttpDelete("{name}/{quantity}", Name = "DeleteIngredient")]
        public ActionResult<Ingredients> Delete(string name, int quantity)
        {           
            string message = "";
            var ing = _context.Ingredient.FirstOrDefault(i => i.Name == name);

            if(ing == null)
            {
                throw new Exception("Requested Ingredient was not found.");
            }

            //If the change in quantity is < 1 delete the entry
            int qty = ing.Quantity - quantity;
            if(qty <= 0)
            {
                _context.Ingredient.Remove(ing);
                message = $"Id: {ing.Id}\nName: {ing.Name} was successfully removed";
            }
            //Update the quantity
            else
            {
                ing.Quantity = qty;
                message = $"Updated quantity for {ing.Name}";

            }
            //Save changes
            var success = _context.SaveChanges() > 0;
            if (success)
            {                
                return Ok(message);
            }

            throw new Exception("Failed to delete requested Ingredient");
            
        }
    }
}