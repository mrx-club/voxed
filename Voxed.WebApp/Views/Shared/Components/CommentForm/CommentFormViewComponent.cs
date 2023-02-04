using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Voxed.WebApp.Models;

namespace Voxed.WebApp.Views.Shared.Components.CommentForm
{
    public class CommentFormViewComponent : ViewComponent
    {
        public CommentFormViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid voxID, Guid userID)
        {
            await Task.Run(() => Console.WriteLine());
            var commentForm = new CreateCommentFormViewModel() 
            { 
                VoxID = voxID, 
                UserID = userID 
            };
                
            return View(commentForm);
        }
    }
}
