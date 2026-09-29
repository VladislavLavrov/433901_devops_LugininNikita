using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate(
            double num1,
            double num2,
            string operation)
        {
            double result;

            switch (operation)
            {
                case "add":
                    result = num1 + num2;
                    break;

                case "subtract":
                    result = num1 - num2;
                    break;

                case "multiply":
                    result = num1 * num2;
                    break;

                case "divide":
                    if (num2 == 0)
                    {
                        ViewBag.Error = "Деление на ноль невозможно.";
                        return View("Index");
                    }

                    result = num1 / num2;
                    break;

                default:
                    ViewBag.Error = "Неизвестная операция.";
                    return View("Index");
            }

            ViewBag.Result = result;

            return View("Index");
        }
    }
}