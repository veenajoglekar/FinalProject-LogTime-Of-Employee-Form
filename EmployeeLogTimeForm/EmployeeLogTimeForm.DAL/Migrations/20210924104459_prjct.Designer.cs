﻿// <auto-generated />
using System;
using EmployeeLogTimeForm.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeLogTimeForm.DAL.Migrations
{
    [DbContext(typeof(EmployeeLogDbContext))]
    [Migration("20210924104459_prjct")]
    partial class prjct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeLogTimeForm.DAL.Data.Model.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("EmployeeLogTimeForm.DAL.Data.Model.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("EmployeeLogTimeForm.DAL.Data.Model.JobInfo", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("JobName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobId");

                    b.ToTable("jobInfo");
                });

            modelBuilder.Entity("EmployeeLogTimeForm.DAL.Data.Model.LogTimeForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("WorkItem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("JobId");

                    b.HasIndex("ProjectId");

                    b.ToTable("LogTimeForm");
                });

            modelBuilder.Entity("EmployeeLogTimeForm.DAL.Data.Model.ProjectInfo", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BillableStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Costing")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("projectInfo");
                });

            modelBuilder.Entity("EmployeeLogTimeForm.DAL.Data.Model.LogTimeForm", b =>
                {
                    b.HasOne("EmployeeLogTimeForm.DAL.Data.Model.Client", "Client")
                        .WithMany("LogTimeForm")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeLogTimeForm.DAL.Data.Model.JobInfo", "JobInfo")
                        .WithMany("LogTimeForm")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeLogTimeForm.DAL.Data.Model.ProjectInfo", "ProjectInfo")
                        .WithMany("LogTimeForm")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}