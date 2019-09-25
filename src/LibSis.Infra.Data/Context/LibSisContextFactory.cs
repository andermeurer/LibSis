using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibSis.Infra.Data.Context
{
    public class LibSisContextFactory : IDesignTimeDbContextFactory<LibSisContext>
    {
        public LibSisContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LibSisContext>();

            builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LibSisDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new LibSisContext(builder.Options);
        }
    }
}
