using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data
{
    public class FinanceAppDbContext: DbContext
    {
     public  FinanceAppDbContext(DbContextOptions<FinanceAppDbContext> options):base(options){ }




        public DbSet<Expenses> Expenses { get; set; }
    }
}
