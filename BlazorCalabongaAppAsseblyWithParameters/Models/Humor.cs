namespace BlazorCalabongaAppAsseblyWithParameters.Models
{
    public class Humor
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Content { get; set; }
        public string[] Tags { get; set; }
        public bool IsAdult { get; set; }
        public int NextItem { get; set; }
        public int PrevItem { get; set; }
        public string Title { get; set; }
        public DateTime UpdatedAt { get; set; }
        
    }
}
