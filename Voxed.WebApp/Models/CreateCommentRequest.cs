using System.ComponentModel.DataAnnotations;

namespace Voxed.WebApp.Models
{
    public class CreateCommentRequest : AttachmentRequest
    {
        [StringLength(3000, ErrorMessage = "El comentario no puede superar los {1} caracteres.")]
        public string Content { get; set; }

        public bool HasEmptyContent()
        {
            return Content == null && File == null && GetVoxedAttachment()?.Extension == null;
        }
    }
}
