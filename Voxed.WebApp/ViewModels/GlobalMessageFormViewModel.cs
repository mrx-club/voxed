using System.ComponentModel.DataAnnotations;

namespace Voxed.WebApp.ViewModels
{
    public class GlobalMessageFormViewModel
    {
        public enum GlobalMessageType { TenMinutes, ThirtyMinutes, OneHour, TwoHours, FourHours, TwentyFourHours }

        [Required(ErrorMessage = "Debe ingresar un contenido")]
        [StringLength(140, ErrorMessage = "El contenido no puede superar los {1} caracteres.")]
        public string Content { get; set; }
        public GlobalMessageType Type { get; set; }
    }
}
