namespace Voxed.WebApp.Models
{
    public class DeleteRequest
    {
        public int ContentType { get; set; } //puede ser 0:comment o 1
        public string ContentId { get; set; }
    }
}
