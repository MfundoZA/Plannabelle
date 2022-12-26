using Microsoft.AspNetCore.Mvc;
using PlannabelleClassLibrary.Data;

namespace Plannabelle.ViewComponents
{
    public class AuthNavViewComponent : ViewComponent
    {
        public PlannabelleDbContext DbContext { get; set; } = new PlannabelleDbContext();

        public async Task<IViewComponentResult> InvokeAsync(int studentId, string email)
        {
            var model = new List<object>();
            model.Add(studentId);
            model.Add(email);

            return View(model);
        }
    }
}
