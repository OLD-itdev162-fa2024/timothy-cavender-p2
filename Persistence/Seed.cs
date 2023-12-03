using Domain;

namespace Persistence
{
    public class Seed
    {
        //Seed Data for Ingredients
        public static void SeedIngredientData(DataContext context)
        {
            if(!context.Ingredient.Any())
            {
                var Ingredients = new List<Ingredients>
                {
                    new Ingredients
                    {
                        Type = "Produce",
                        Name = "Tomato",
                        Quantity = 5
                    },
                    new Ingredients
                    {
                        Type = "Dairy",
                        Name = "Cheese",
                        Quantity = 2
                    },
                    new Ingredients
                    {
                        Type = "Meat",
                        Name = "Steak",
                        Quantity = 1
                    }
                };

                context.Ingredient.AddRange(Ingredients);
                context.SaveChanges();
            }
        }
    }
}