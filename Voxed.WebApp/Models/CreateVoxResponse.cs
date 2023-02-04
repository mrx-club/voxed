using System;
using Voxed.WebApp.Extensions;

namespace Voxed.WebApp.Models
{
    public class CreateVoxResponse : BaseResponse
    {
        private CreateVoxResponse() { }

        public string VoxHash { get; set; }

        public static CreateVoxResponse Success(Guid voxId)
        {
            return new CreateVoxResponse()
            {
                VoxHash = voxId.ToShortString(),
                Status = true
            };
        }

        public static CreateVoxResponse Failure(string errorMessage)
        {
            return new CreateVoxResponse()
            {
                Swal = errorMessage,
                Status = false
            };
        }
    }
}
