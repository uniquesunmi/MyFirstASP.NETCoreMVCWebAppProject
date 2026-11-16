using FinanceApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Controllers
{
    public class ExpensesController1 : Controller
    {
        private readonly FinanceAppContext _
        public IActionResult Index()
        {
            return View();
        }
    }
}
