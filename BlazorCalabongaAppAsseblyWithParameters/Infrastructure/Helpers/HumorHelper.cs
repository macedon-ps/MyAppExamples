using BlazorCalabongaAppAsseblyWithParameters.Models;

namespace BlazorCalabongaAppAsseblyWithParameters.Infrastructure.Helpers
{
    public static class HumorHelper
    {
        public static Humor GetFirst()
        {
            return new Humor
            {
                Id = 1000,
                CategoryId = 1,
                CategoryName = "Анекдоты",
                Title = "Про маленького Мишу",
                Content = "В детстве маленький Миша доезжал только до 6-ого этажа, а потом он шел пешком и матерился, потому что мама научила его считать до шести, а папа - материться",
                IsAdult = false,
                CreateAt = new DateTime(2025, 2, 13),
                UpdatedAt = new DateTime(2025, 4, 5),
                Tags = new[] { "дети", "тупо, но смешно", "рост" },
                NextItem = 1001,
                PrevItem = 999
            };
        }
        
        public static Humor GetSecond()
        {
            return new Humor
            {
                Id = 1001,
                CategoryId = 2,
                CategoryName = "Истории из жизни",
                Title = "Талогы на виски",
                Content = "У нас в нашем городе резко исчезли качественные виски. Поэтому недовольные горожане решили потребовать от властей гарантии для пьющих и ввести талоны на виски",
                IsAdult = false,
                CreateAt = new DateTime(2025, 2, 11),
                UpdatedAt = new DateTime(2025, 4, 6),
                Tags = new[] { "водка", "торгуем как можем", "шок" },
                NextItem = 1002,
                PrevItem = 1000
            };
        }
    }
}
