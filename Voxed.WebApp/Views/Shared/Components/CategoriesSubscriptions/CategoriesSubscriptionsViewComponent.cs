using Core.Data.Repositories;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Voxed.WebApp.Views.Shared.Components.CategoriesSubscriptions
{
    public class CategoriesSubscriptionsViewComponent : ViewComponent
    {
        private readonly IVoxedRepository _voxedRepository;
        private static IEnumerable<Category> _categories;

        public CategoriesSubscriptionsViewComponent(
            IVoxedRepository voxedRepository)
        {
            _voxedRepository = voxedRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (_categories == null)
            {
                _categories = await _voxedRepository.Categories.GetAll();
            }

            return View(_categories);
        }
    }
}
