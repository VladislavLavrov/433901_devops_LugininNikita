using Calculator.Models;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Data
{
    public class CalculatorDbContext : DbContext
    {
        public CalculatorDbContext(
            DbContextOptions<CalculatorDbContext> options)
            : base(options)
        {
        }

        public DbSet<Calculation> Calculations => Set<Calculation>();
    }
}