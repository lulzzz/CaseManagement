﻿using CaseManagement.BPMN.Persistence.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseManagement.BPMN.Persistence.EF.Configuration
{
    public class ActivityStateHistoryModelConfiguration : IEntityTypeConfiguration<ActivityStateHistoryModel>
    {
        public void Configure(EntityTypeBuilder<ActivityStateHistoryModel> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
        }
    }
}
