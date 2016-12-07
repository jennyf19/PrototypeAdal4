using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PrototypeAdal4.Data;

namespace PrototypeAdal4.Migrations
{
    [DbContext(typeof(PrototypeAdal4Context))]
    [Migration("20161207200056_MaxLengthOnNames")]
    partial class MaxLengthOnNames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PrototypeAdal4.Models.Approval", b =>
                {
                    b.Property<int>("ApprovalID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApprovalStatus");

                    b.Property<string>("ApprovedBy");

                    b.Property<DateTime>("ApprovedDateTime");

                    b.Property<int>("ProductID");

                    b.Property<int?>("ReleaseID");

                    b.HasKey("ApprovalID");

                    b.HasIndex("ProductID");

                    b.HasIndex("ReleaseID");

                    b.ToTable("Approvals");
                });

            modelBuilder.Entity("PrototypeAdal4.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProductName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("ReleaseNotes");

                    b.Property<DateTime>("SubmissionDate");

                    b.Property<string>("VersionNumber");

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PrototypeAdal4.Models.Release", b =>
                {
                    b.Property<int>("ReleaseID");

                    b.Property<int>("ApprovalID");

                    b.Property<int>("ProductID");

                    b.HasKey("ReleaseID");

                    b.ToTable("Releases");
                });

            modelBuilder.Entity("PrototypeAdal4.Models.Approval", b =>
                {
                    b.HasOne("PrototypeAdal4.Models.Product", "Product")
                        .WithMany("Approvals")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PrototypeAdal4.Models.Release", "Release")
                        .WithMany("Approvals")
                        .HasForeignKey("ReleaseID");
                });
        }
    }
}
