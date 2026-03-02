using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CYBERQUIZ.DAL.DATA
{
    // Används BARA av EF Core-verktygen vid Add-Migration och Update-Database
    // Körs aldrig när appen är igång – bara vid design-time
    // Behövs eftersom DAL är ett class library och inte vet om connection string
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Connection string är hårdkodad här – det är OK eftersom den
            // bara används vid migrations, inte i produktion
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=CyberQuizDb;Trusted_Connection=True;",
                sqlOptions => sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null
                ));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}

