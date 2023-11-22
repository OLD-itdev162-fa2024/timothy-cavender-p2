using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Persistence;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<Recipes> _logger;
        private readonly DataContext _context;

        public RecipeController(ILogger<Recipes> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetRecipes")]  //LocalHost:Port/recipe
        public IEnumerable<Recipes> Get()//List<Recipes> Get()
        {
            List<Recipes> recipes = new List<Recipes>();

            Recipes r = new Recipes(){
                RecipeName = "Ranch Chicken",
                Ingredients = new List<String>() { "Ranch", "Chicken" }
            };

            Recipes r1 = new Recipes()
            {
                RecipeName = "Nachos",
                Ingredients = new List<String>() { "Turkey", "Taco Seasoning", "Cheese","Doritos","Salsa" }
            };

            Recipes r2 = new Recipes()
            {
                RecipeName = "Pizza",
                Ingredients = new List<String>() { "Flour", "Yeast", "Sugar", "Salt", "Sauce", "Cheese", "Pepperoni" }
            };
            
            recipes.Add(r);
            recipes.Add(r1);
            recipes.Add(r2);

            return Enumerable.ToArray(recipes);
        }

        [HttpPost]

        public ActionResult<Recipes> Create()
        {
            Console.WriteLine($"Database path: {_context.DbPath}");
            Console.WriteLine("Insert a new Recipe");

            Recipes recipe = new Recipes()
            {
                RecipeName = "Breakfast Mac",
                Ingredients = new List<String>(){"Milk","Butter","Mac n Cheese","Sausage"}
            };

            _context.Recipes.Add(recipe);
            var success = _context.SaveChanges() > 0;

            if(success) {return recipe;}

            throw new Exception("Error Creating New Recipe");
        }
    
    }
}