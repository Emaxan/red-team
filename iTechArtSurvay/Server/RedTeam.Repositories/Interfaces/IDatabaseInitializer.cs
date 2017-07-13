using System.Data.Entity;

namespace RedTeam.Repositories.Interfaces
{
    public interface IDatabaseInitializer<in TContext> where TContext : DbContext
    {
        // Summary:
        //   Executes the strategy to initialize
        //   the database for the given context.
        // Parameters:
        //   context: The context.
        void InitializeDatabase(TContext context);
    }
}