using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Inspinia.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "الاسم الكامل مطلوب")]
        [Display(Name = "الاسم الكامل")]
        [StringLength(100, ErrorMessage = "يجب أن يكون الاسم بين {2} و {1} حرفًا.", MinimumLength = 3)]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "نوع النشاط مطلوب")]
        [Display(Name = "نوع النشاط")]
        [StringLength(100, ErrorMessage = "يجب أن يكون نوع النشاط بين {2} و {1} حرفًا.", MinimumLength = 2)]
        public string? BusinessType { get; set; }

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
        [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صحيح")]
        [Display(Name = "البريد الإلكتروني")]
        [StringLength(100, ErrorMessage = "البريد الإلكتروني طويل جداً")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "رقم الهاتف مطلوب")]
        [Display(Name = "رقم الهاتف")]
        [StringLength(20, ErrorMessage = "رقم الهاتف طويل جداً")]
        [RegularExpression(@"^[0-9\-+\s()]{7,20}$", ErrorMessage = "رقم الهاتف غير صحيح")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "كلمة المرور مطلوبة")]
        [StringLength(100, ErrorMessage = "يجب أن تكون كلمة المرور على الأقل {2} حرفًا.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمة المرور")]
        [Compare("Password", ErrorMessage = "كلمة المرور وتأكيد كلمة المرور غير متطابقين")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "نوع الوثيقة مطلوب")]
        [Display(Name = "نوع الوثيقة")]
        public string? DocumentType { get; set; }

        [Required(ErrorMessage = "صورة الوثيقة مطلوبة")]
        [Display(Name = "صورة الوثيقة")]
        public IFormFile? DocumentImage { get; set; }
    }
}