namespace Voxed.WebApp.Models
{
    public class CreateCommentResponse : BaseResponse
    {
        private CreateCommentResponse() { }

        public string Hash { get; set; }

        public static CreateCommentResponse Success(string hash)
        {
            return new CreateCommentResponse() { Status = true, Hash = hash };
        }

        public static CreateCommentResponse Failure(string errorMessage)
        {
            return new CreateCommentResponse() { Status = false, Swal = errorMessage };
        }
    }
}
