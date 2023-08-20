using API.Data.Mapping;
using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        
        public MyContext(DbContextOptions<MyContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(new UserMap().Configure);

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrador",
                    Email = "adm@projeto.com.br",
                    CreateAt = DateTime.Now,
                    UpdateAt = null
                }
            );
        }
    }
}
