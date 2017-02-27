namespace OdeToFood.Entities
{
    public enum CuisineType
    {
        Other,
        Italian,
        French,
        Japanese,
        Mexican,
        American,
    }

    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
