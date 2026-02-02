using ApiFerid.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.DataAccess.Configuration
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        void IEntityTypeConfiguration<AppUser>.Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Fullname).IsRequired().HasMaxLength(256);
        }

    }
}
