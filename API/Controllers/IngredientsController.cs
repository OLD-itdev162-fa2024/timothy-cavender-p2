using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet(Name = "GetIngredients")]
        public ActionResult<List<Ingredients>> Get()
        {
            return _context.Ingredient.ToList();
        }
    }
}