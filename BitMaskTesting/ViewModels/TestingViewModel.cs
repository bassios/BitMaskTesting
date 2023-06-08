using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BitMaskTesting.ViewModels
{
    public class TestingViewModel
    {
        public List<SelectListItem> FormTypes { get; set; }

        public TestingViewModel()
        {
        }

        public TestingViewModel(List<SelectListItem> formTypes)
            : this()
        {
            FormTypes = formTypes;

            FormTypes.Insert(0, new SelectListItem() { Text = "Select...", Value = "" });
        }
    }
}
