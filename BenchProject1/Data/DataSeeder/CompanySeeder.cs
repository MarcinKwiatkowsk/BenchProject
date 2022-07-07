using BenchProject1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BenchProject1.Data.DataSeeder
{
    public class CompanySeeder
    {
        public static void SeedData(TickContext context)
        {
            if (!context.Database.CanConnect())
            {
                context.Database.Migrate();
            }

            if (!context.Companies.Any())
            {
                var companies = new List<Company>()
                {
                    new Company()
                    {
                        Name = "Meta",
                        Code = "META",
                        Description = ""
                    },
                    new Company()
                    {
                        Name = "Nvidia",
                        Code = "NVDA",
                        Description = ""
                    },new Company()
                    {
                        Name = "Netflix",
                        Code = "NFLX",
                        Description = ""
                    },new Company()
                    {
                        Name = "Microsoft",
                        Code = "MSFT",
                        Description = ""
                    },new Company()
                    {
                        Name = "Activision",
                        Code = "ATVI",
                        Description = ""
                    },new Company()
                    {
                        Name = "Square",
                        Code = "SQ",
                        Description = ""
                    },new Company()
                    {
                        Name = "Google",
                        Code = "GOOG",
                        Description = ""
                    },new Company()
                    {
                        Name = "Allegroeu SA",
                        Code = "ALE",
                        Description = ""
                    },new Company()
                    {
                        Name = "Tauron Polska Energia",
                        Code = "TPE",
                        Description = ""
                    },new Company()
                    {
                        Name = "PGE Polska Grupa Energetyczna",
                        Code = "PGE",
                        Description = ""
                    }

                };
                context.AddRange(companies);
                context.SaveChanges();
            }
        }
    }
}
