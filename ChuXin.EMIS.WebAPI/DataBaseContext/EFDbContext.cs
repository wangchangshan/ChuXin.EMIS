using System;
using ChuXin.EMIS.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChuXin.EMIS.WebAPI.DataBaseContext
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
