using Calculator.Data;
using Calculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly CalculatorDbContext _context;

        public CalculatorController(CalculatorDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Calculate(
            double num1,
            double num2,
            string operation)
        {
            ViewBag.Num1 = num1;
            ViewBag.Num2 = num2;
            ViewBag.Operation = operation;

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

            var calculation = new Calculation
            {
                FirstNumber = num1,
                SecondNumber = num2,
                Operation = operation,
                Result = result,
                CreatedAt = DateTime.UtcNow
            };

            _context.Calculations.Add(calculation);
            await _context.SaveChangesAsync();

            ViewBag.Result = result;

            return View("Index");
        }
    }
}