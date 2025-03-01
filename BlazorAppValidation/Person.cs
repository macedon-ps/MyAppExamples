using System.ComponentModel.DataAnnotations;

namespace BlazorAppValidation
{
    public class Person
    {
        /*
        public string Name { get; set; } = "";
        public int Age { get; set; }
        */

        /* Пример 4. Валидация на основе аннотаций данных */
        /* Пример 8. Программная валидация 

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string? Name { get; set; }
        [Required]
        [Range(1, 110)]
        public int Age { get; set; }
        */

        /* Пример 5. Валидация на основе аннотаций данных. Использование ErrorMessage */
        /*Пример 6. Валидация на основе аннотаций данных.Использование ErrorMessage.ValidationMessage для каждого поля ввода */
        /* Пример 7. Стилизация сообщений об ошибках в полях ввода 
        [Required(ErrorMessage = "Необходимо ввести имя")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Длина имени должна быть от {2} до {1} символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Необходимо ввести возраст")]
        [Range(1, 110, ErrorMessage = "Возраст должен находиться в диапазоне от {1} до {2}")]
        public int Age { get; set; }
        */

        /* Пример 11. Кастомная валидация */

        [PersonNameValidator(new[] { "admin" })]
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; } = "";
        [Required]
        [Range(1, 110)]
        public int Age { get; set; }
    }
}
