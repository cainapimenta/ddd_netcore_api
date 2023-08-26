using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

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
            var optionBuilder = new DbContextOptionsBuilder<MyContext>();

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
                optionBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"));
            else
                optionBuilder.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION"));

            return new MyContext(optionBuilder.Options);
        }
    }
}
