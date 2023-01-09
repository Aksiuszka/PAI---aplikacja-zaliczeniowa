using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace info_2022.Models
{
    public class Pytanko
    {
        [Key]
        [Display(Name = "Identyfikator pytania")]
        public int IdPytanie { get; set; }

        [Required(ErrorMessage = "Proszę podać Imię")]
        [Display(Name = "Imię")]
        [MaxLength(50, ErrorMessage = "Imię nie może być dłuższe niż 50 znaków")]
        public string? Imie { get; set; }

        [Required(ErrorMessage = "Proszę podać adres e-mail")]
        [Display(Name = "Adres email")]
        [EmailAddress(ErrorMessage = "Niepoprawny adres e-mail")]
        public string? Adres { get; set; }

        [Required(ErrorMessage = "Proszę podać treść pytania/uwagi")]
        [Display(Name = "Treść pytania")]
        [MaxLength(500, ErrorMessage = "Treść pytania/uwagi nie może być dłuższe niż 500 znaków")]
        public string? Tresc { get; set; }

        [Required]
        [Display(Name = "Odpowiedz")]
        public bool Odpowiedz { get; set; }
    }
}
