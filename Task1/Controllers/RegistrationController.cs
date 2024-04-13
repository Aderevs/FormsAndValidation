using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Task1.Models;

namespace Task1.Controllers
{
    public class RegistrationController : Controller
    {
        private DateValidator _validator;

        public RegistrationController(DateValidator validator)
        {
            _validator = validator;
            
            
        }

        public IActionResult Index()
        {
            var model = new RegistrationModel()
            {
                WantedDate = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
            };
            model.SelectedValue = model.Options[1].Value;

            return View(model);
        }


        [HttpPost]
        public IActionResult Index(RegistrationModel model)
        {
            var validRes =  _validator.Validate(model);

            if (ModelState.IsValid && validRes.IsValid)
            {
                Debug.WriteLine($"В базу записаний користувач: {model.FirstName} {model.LastName} (email: {model.Email}, date: {model.WantedDate})");
                return View("Success");
            }
            else
            {
                foreach (var error in validRes.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(model);
            }
        }
    }
}
