﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using CaseManagement.CMMN.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace CaseManagement.CMMN.SqlServer.Host
{
    public class CaseManagementMigration : IDesignTimeDbContextFactory<CaseManagementDbContext>
    {
        public CaseManagementDbContext CreateDbContext(string[] args)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            var builder = new DbContextOptionsBuilder<CaseManagementDbContext>();
            builder.UseSqlServer("Data Source=DESKTOP-T4INEAM\\SQLEXPRESS;Initial Catalog=CaseManagement;Integrated Security=True",
                optionsBuilder => optionsBuilder.MigrationsAssembly(migrationsAssembly));
            return new CaseManagementDbContext(builder.Options);
        }
    }
}
