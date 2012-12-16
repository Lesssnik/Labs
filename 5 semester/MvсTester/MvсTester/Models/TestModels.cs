using System;
using System.ComponentModel.DataAnnotations;

namespace MvсTester.Models
{
    public class TestModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Время выполнения")]
        public DateTime Time { get; set; }

        [Required]
        [Display(Name = "Тип теста")]
        public Types Type { get; set; }
    }
}