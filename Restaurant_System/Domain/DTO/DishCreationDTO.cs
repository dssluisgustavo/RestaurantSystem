using Domain;

namespace Domain.DTO
{
    public class DishCreationDTO
    {
        public string Name { get; set; }
        public List<int> Ingredients { get; set; }
    }
}
