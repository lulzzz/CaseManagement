﻿using CaseManagement.CMMN.Persistence.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseManagement.CMMN.Persistence.EF.EntityConfigurations
{
    public class QueueMessageModelConfiguration : IEntityTypeConfiguration<QueueMessageModel>
    {
        public void Configure(EntityTypeBuilder<QueueMessageModel> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
        }
    }
}
