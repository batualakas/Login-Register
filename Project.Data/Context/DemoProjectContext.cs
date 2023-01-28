using Microsoft.EntityFrameworkCore;
using Project.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Context
{
    public class DemoProjectContext : DbContext
    {
        public DemoProjectContext(DbContextOptions<DemoProjectContext> options) : base(options)
        {

        }
        public DbSet<UserEntity> Users => Set<UserEntity>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());

            modelBuilder.Entity<UserEntity>().HasData(new List<UserEntity>()
            {
new UserEntity()
{
    Id= 1,
    FirstName="DemoAdmin",
    LastName="DemoAdmin2",
    Email="batualakas@gmail.com",
    Password="123456",
    UserType=Enums.UserTypeEnum.Admin
}});

            base.OnModelCreating(modelBuilder);
        }

    }
}
