using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using Voxed.WebApp.Attributes;

namespace Voxed.WebApp.Models
{
    public class CreateCommentFormViewModel
    {
        public Guid VoxID { get; set; }
        public Guid UserID { get; set; }

        [Required(ErrorMessage = "Debe ingresar un comentario")]
        [StringLength(3000, ErrorMessage = "El comentario no puede superar los {1} caracteres.")]
        public string Content { get; set; }

        [MaxFileSize(10 * 1024 * 1024)]
        [AllowedExtensions(new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" }, ErrorMessage = "Formato de archivo no soportado.")]
        public IFormFile File { get; set; }
    }
}
