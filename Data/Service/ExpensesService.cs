using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data;

public class ExpensesService : IExpensesService
{

    private readonly Data.ExpensesService _context;

    public ExpensesService(Data.IExpensesService  context) 
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
}
