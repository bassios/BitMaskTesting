using System.ComponentModel.DataAnnotations;

namespace BitMaskTesting.Models.Enums
{
    public enum FormType
    {
        None = 0,
        [Display(Name = "Form 1")]
        Form1 = 1,
        [Display(Name = "Form 2")]
        Form2 = 2,
        [Display(Name = "Form 3")]
        Form3 = 4
    }
}
