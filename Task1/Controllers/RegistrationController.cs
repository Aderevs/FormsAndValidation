using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            return View();
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
                // якщо модель містить значення, що суперечать бізнес правилам - повертаємо те ж саме подання з неправильними даними
                // для того, щоб користувач міг їх виправити
                foreach(var error in validRes.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(model);
            }
        }
    }
}
