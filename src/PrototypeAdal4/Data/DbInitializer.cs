﻿using System;
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

                new Product {ProductName = "Adal-v4", VersionNumber = "v1.11.11", ReleaseNotes = "Cats are cool"},
                new Product {ProductName = "Azure-ActiveDirectory", VersionNumber = "v1.00.11", ReleaseNotes = "Cats are awesoeme"},
                 new Product {ProductName = "Build-Android-Master", VersionNumber = "v1.11.01", ReleaseNotes = "Cats sleep all day"},
                  new Product {ProductName = "Msal-Dotnet", VersionNumber = "v1.11.02", ReleaseNotes = "Cats are love trees"},

            };

            foreach (Product r in products)
            {
                context.Products.Add(r);
            }
            context.SaveChanges();

            var releases = new Release[]
            {
                new Release {ProductID = 1, SubmissionDateTime = DateTime.Parse("2016-12-03")},
                new Release {ProductID = 2, SubmissionDateTime = DateTime.Parse("2015-01-03")},
                new Release {ProductID = 3, SubmissionDateTime = DateTime.Parse("2012-02-03")},
                new Release {ProductID = 4, SubmissionDateTime = DateTime.Parse("2010-03-03")},
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
                    ApprovalID = 1, ProductID = 1,
                    ApprovalStatus = ApprovalStatus.Approved,
                    ApprovedBy = "Rich",
                    ApprovedDateTime = DateTime.Parse("2016-12-6")
                },
                new Approval
                {
                    ApprovalID = 2, ProductID = 2,
                    ApprovalStatus = ApprovalStatus.Approved,
                    ApprovedBy = "Ashima",
                    ApprovedDateTime = DateTime.Parse("2016-12-7")
                },
                new Approval
                {
                    ApprovalID = 3, ProductID = 3,
                    ApprovalStatus = ApprovalStatus.Approved,
                    ApprovedBy = "Rich",
                    ApprovedDateTime = DateTime.Parse("2016-11-6")
                },
                new Approval
                {
                    ApprovalID = 4, ProductID = 4,
                    ApprovalStatus = ApprovalStatus.Approved,
                    ApprovedBy = "Ashima",
                    ApprovedDateTime = DateTime.Parse("2016-11-7")
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