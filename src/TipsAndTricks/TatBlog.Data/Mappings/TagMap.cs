﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TatBlog.Core.Entities;

namespace TatBlog.Data.Mappings
{
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.Decsription)
                .HasMaxLength(500);

            builder.Property(t => t.UrlSlug)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
