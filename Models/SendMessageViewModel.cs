using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidKinder.Models
{
    public class SendMessageViewModel
    {
        [Required(ErrorMessage ="Lütfen adınızı boş geçmeyin.")]
        [StringLength(30,ErrorMessage ="Lütfen en fazla 30 karakter veri giriniz.")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Lütfen mail alanını boş geçmeyin.")]
        [StringLength(50, ErrorMessage = "Lütfen en fazla 50 karakter veri giriniz.")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli bir mail adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen konu kısmını boş geçmeyin.")]
        [StringLength(50, ErrorMessage = "Lütfen en fazla 50 karakter veri giriniz.")]
        [MinLength(5,ErrorMessage ="Lütfen en az 5 karakter veri girişi yapın.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Lütfen mesaj kısmını boş geçmeyin.")]
        [StringLength(1000, ErrorMessage = "Lütfen daha az veri girişi yapın.")]
        public string Message { get; set; }
    }
}