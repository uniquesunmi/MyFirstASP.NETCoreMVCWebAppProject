using FinanceApp.Data.Service;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace FinanceApp.Controllers;

public class ExpensesController : Controller
{
   private readonly IExpensesService _expensesService;

    public ExpensesController(IExpensesService expensesService)
    {
        _expensesService = expensesService;
    }
    public async Task< IActionResult> Index()
    {
        var expenses = await  _expensesService.GetAll();
        return View(expenses);

    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public  async Task<IActionResult> Create(Expenses expense)
    {
        if (ModelState.IsValid)
        {
            await _expensesService.Add(expense);

            return RedirectToAction("Index");

        }
        return View(expense);

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        await _expensesService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult GetChart()
    {
        var data = _expensesService.GetChartData();
        return Json(data);

    }
}
