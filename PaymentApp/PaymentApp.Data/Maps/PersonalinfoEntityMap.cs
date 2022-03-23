using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data.Maps
{
   public class PersonalinfoEntityMap : IEntityTypeConfiguration<PersonalinfoEntity>
    {
        public void Configure(EntityTypeBuilder<PersonalinfoEntity> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Personalinfo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");

        }
    }
}
