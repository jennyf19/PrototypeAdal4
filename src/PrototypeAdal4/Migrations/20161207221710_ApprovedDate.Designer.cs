using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PrototypeAdal4.Data;

namespace PrototypeAdal4.Migrations
{
    [DbContext(typeof(PrototypeAdal4Context))]
    [Migration("20161207221710_ApprovedDate")]
    partial class ApprovedDate
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

                    b.Property<string>("ApprovedBy")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("ApprovedDate");

                    b.Property<int?>("ProductID");

                    b.HasKey("ApprovalID");

                    b.HasIndex("ProductID");

                    b.ToTable("Approvals");
                });

            modelBuilder.Entity("PrototypeAdal4.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("ReleaseNotes")
                        .IsRequired();

                    b.Property<DateTime>("SubmissionDate");

                    b.Property<string>("VersionNumber")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PrototypeAdal4.Models.Release", b =>
                {
                    b.Property<int>("ReleaseID");

                    b.Property<int>("ApprovalID");

                    b.Property<int>("ProductID");

                    b.HasKey("ReleaseID");

                    b.HasIndex("ApprovalID")
                        .IsUnique();

                    b.HasIndex("ProductID");

                    b.ToTable("Releases");
                });

            modelBuilder.Entity("PrototypeAdal4.Models.Approval", b =>
                {
                    b.HasOne("PrototypeAdal4.Models.Product", "Product")
                        .WithMany("Approvals")
                        .HasForeignKey("ProductID");
                });

            modelBuilder.Entity("PrototypeAdal4.Models.Release", b =>
                {
                    b.HasOne("PrototypeAdal4.Models.Approval", "Approval")
                        .WithOne("Release")
                        .HasForeignKey("PrototypeAdal4.Models.Release", "ApprovalID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PrototypeAdal4.Models.Product", "Product")
                        .WithMany("Releases")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
