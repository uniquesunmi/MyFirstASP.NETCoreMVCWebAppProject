using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;
using FinanceApp.Data.Service;

namespace FinanceApp.Data;

public class ExpensesService : IExpensesService
{

    private readonly FinanceAppDbContext _context;

    public ExpensesService(FinanceAppDbContext context) 
    {
        _context = context;
    }
    public async Task Add(Expenses expense)
    {
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();


    }

    public async Task<IEnumerable<Expenses>> GetAll()
    {
        List<Expenses> expenses = await _context.Expenses.ToListAsync();

        return expenses;

    }

    public async Task DeleteAsync(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);
        if (expense != null)
        {
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
        }
    }

    public IQueryable GetChartData()
    {
        var data = _context.Expenses
                          .GroupBy(e => e.Category)
                          .Select(g => new
                          {
                              Category = g.Key,
                              Total = g.Sum(e => e.Amount)

                          });

        return data; 
    }
}
