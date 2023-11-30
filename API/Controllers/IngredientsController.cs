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
    [Route("[controller]")]
    public class IngredientsController : ControllerBase
    {
        private static readonly string[] IngredientNames = new[]
        {
            "Milk","Cheese","Apple","Steak"
        };

        private readonly ILogger<IngredientsController> _logger;

        private readonly DataContext _context;

        public IngredientsController(ILogger<IngredientsController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetIngredients")]
        public string[] Get()
        {
            return IngredientNames;
        }
    }
}