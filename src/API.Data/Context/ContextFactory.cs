using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        /// <summary>
        /// Usado para criar migrações
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public MyContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Initial Catalog=dbAPI;User Id=sa;Password=b1admin";
            var optionBuilder = new DbContextOptionsBuilder<MyContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new MyContext(optionBuilder.Options);
        }
    }
}
