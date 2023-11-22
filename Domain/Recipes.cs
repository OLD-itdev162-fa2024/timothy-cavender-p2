using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Recipes
    {
        public int Id {get;set;}
        public string? RecipeName {get;set;}

        [NotMapped]
        public List<String>? Ingredients {get;set;}

    }
}