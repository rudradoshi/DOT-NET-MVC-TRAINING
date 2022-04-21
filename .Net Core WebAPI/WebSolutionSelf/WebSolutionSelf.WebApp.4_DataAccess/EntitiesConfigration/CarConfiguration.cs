using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebSolutionSelf.WebApp._4_DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebSolutionSelf.WebApp._4_DataAccess.EntitiesConfigration
{
    public class CarConfiguration : IEntityTypeConfiguration<CarEntities>
    {
        public void Configure(EntityTypeBuilder<CarEntities> builder)
        {
            builder.ToTable("Rudra_Car");
            builder.HasKey(PrimaryKey => PrimaryKey.Id);
        }
    }
}
