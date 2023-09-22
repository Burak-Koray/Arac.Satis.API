using Arac.Satis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac.Satis.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Username).IsRequired();
            builder.Property(u => u.Username).HasMaxLength(50);
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(20);
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Name).HasMaxLength(20);
            builder.Property(u => u.Surname).IsRequired();
            builder.Property(u => u.Surname).HasMaxLength(20);
        }
    }
}
