using Microsoft.AspNetCore.Routing.Constraints;

namespace FuelPH.API
{
    public class TodoResponse
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool Completed { get; set; }
    }
}
