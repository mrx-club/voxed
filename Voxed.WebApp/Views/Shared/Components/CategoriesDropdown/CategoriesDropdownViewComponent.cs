using Core.Data.Repositories;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voxed.WebApp.Views.Shared.Components.CategoriesDropdown
{
    public class CategoriesDropdownViewComponent : ViewComponent
    {
        private readonly IVoxedRepository _voxedRepository;
        private static IEnumerable<Category> _categories;

        public CategoriesDropdownViewComponent(
            IVoxedRepository voxedRepository)
        {
            _voxedRepository = voxedRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            _categories = _categories ?? await _voxedRepository.Categories.GetAll();
            return View(_categories);
        }
    }
}
