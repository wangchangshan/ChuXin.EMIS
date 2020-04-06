using System;
using Microsoft.EntityFrameworkCore;

namespace ChuXin.EMIS.WebAPI.DataBaseContext
{
    public class AdoDbContext : DbContext
    {
        public AdoDbContext(DbContextOptions<AdoDbContext> options) : base(options)
        {
        }
    }
}
