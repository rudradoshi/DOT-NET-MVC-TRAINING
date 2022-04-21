using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebSolutionSelf.Common.Model;
using WebSolutionSelf.WebApp._4_DataAccess.Entities;
using WebSolutionSelf.WebApp._4_DataAccess.EntitiesConfigration;

namespace WebSolutionSelf.WebApp._4_DataAccess
{
    public class Context:DbContext
    {
        public DbSet<CarEntities> CarDbSet { get; set; }

        public Context(DbContextOptions options) :base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfiguration());
        }

    }
}
