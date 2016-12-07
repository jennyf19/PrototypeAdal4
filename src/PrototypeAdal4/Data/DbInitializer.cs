using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrototypeAdal4.Data;
using PrototypeAdal4.Models;

namespace PrototypeAdal4.Data
{
    public class DbInitializer
    {
        public static void Initialize(PrototypeAdal4Context context)
        {
            context.Database.EnsureCreated();

            //Look for any products
            if (context.Products.Any())
            {
                return; //db has been seeded
            }

            var products = new Product[]
            {

                new Product {ProductName = "Adal-v4", VersionNumber = "v1.11.11", ReleaseNotes = "Cats are cool", SubmissionDate = DateTime.Parse("2016-12-03")},
                new Product {ProductName = "Azure-ActiveDirectory", VersionNumber = "v1.00.11", ReleaseNotes = "Cats are awesoeme", SubmissionDate = DateTime.Parse("2015-01-03")},
                 new Product {ProductName = "Build-Android-Master", VersionNumber = "v1.11.01", ReleaseNotes = "Cats sleep all day", SubmissionDate = DateTime.Parse("2012-02-03")},
                  new Product {ProductName = "Msal-Dotnet", VersionNumber = "v1.11.02", ReleaseNotes = "Cats are love trees", SubmissionDate = DateTime.Parse("2010-03-03")},

            };

            foreach (Product r in products)
            {
                context.Products.Add(r);
            }
            context.SaveChanges();

            var releases = new Release[]
            {
                new Release {ProductID = 1},
                new Release {ProductID = 2},
                new Release {ProductID = 3},
                new Release {ProductID = 4},
            };
            foreach (Release r in releases)
            {
                context.Releases.Add(r);
            }
            context.SaveChanges();

            var approvals = new Approval[]
            {
                new Approval
                {
                    ApprovalID = 1, 
                    ApprovalStatus = ApprovalStatus.Approved,
                    ApprovedBy = "Rich",
                    ApprovedDate = DateTime.Parse("2016-12-6")
                },
                new Approval
                {
                    ApprovalID = 2, 
                    ApprovalStatus = ApprovalStatus.Approved,
                    ApprovedBy = "Ashima",
                    ApprovedDate = DateTime.Parse("2016-12-7")
                },
                new Approval
                {
                    ApprovalID = 3, 
                    ApprovalStatus = ApprovalStatus.Approved,
                    ApprovedBy = "Rich",
                    ApprovedDate = DateTime.Parse("2016-11-6")
                },
                new Approval
                {
                    ApprovalID = 4, 
                    ApprovalStatus = ApprovalStatus.Approved,
                    ApprovedBy = "Ashima",
                    ApprovedDate = DateTime.Parse("2016-11-7")
                }
            };
            foreach (Approval a in approvals)
            {
                context.Approvals.Add(a);
            }
            context.SaveChanges();
        }
    }
}