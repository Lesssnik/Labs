using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvсTester.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Имя не может быть пустым")]
        [Display(Name = "User name")]
        [MaxLength(30, ErrorMessage = "Максимальная длина имени - 30 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email не может быть пустым")]
        [Display(Name = "User email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль не может быть пустым")]
        [Display(Name = "User password")]
        [DataType(DataType.Password)]
        [MaxLength(30, ErrorMessage = "Максимальная длина пароля - 30 символов")]
        public string Password { get; set; }
    }

    public class LogOnModel
    {
        [Required(ErrorMessage = "Имя не может быть пустым")]
        [Display(Name = "User name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пароль не может быть пустым")]
        [Display(Name = "User password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class EditUserModel
    {
        [Display(Name = "User name")]
        public string Name { get; set; }

        [Display(Name = "User surname")]
        public string Surname { get; set; }

        [Display(Name = "User email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "User password")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "User password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }

    public class TestModel
    {
        [Required(ErrorMessage = "Имя не может быть пустым")]
        [Display(Name = "Test name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Описание не может быть пустым")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }

    public class QuestionsModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Имя не может быть пустым")]
        [Display(Name = "Question name")]
        public string Name { get; set; }

        [Display(Name = "Question 1")]
        public string Question1 { get; set; }

        [Display(Name = "Question 1 check")]
        public bool Question1Check { get; set; }

        [Display(Name = "Question 2")]
        public string Question2 { get; set; }

        [Display(Name = "Question 2 check")]
        public bool Question2Check { get; set; }

        [Display(Name = "Question 3")]
        public string Question3 { get; set; }

        [Display(Name = "Question 3 check")]
        public bool Question3Check { get; set; }

        [Display(Name = "Question 4")]
        public string Question4 { get; set; }

        [Display(Name = "Question 4 check")]
        public bool Question4Check { get; set; }

        [Display(Name = "Question 5")]
        public string Question5 { get; set; }

        [Display(Name = "Question 5 check")]
        public bool Question5Check { get; set; }

        [Display(Name = "Question 6")]
        public string Question6 { get; set; }

        [Display(Name = "Question 6 check")]
        public bool Question6Check { get; set; }
    }
}