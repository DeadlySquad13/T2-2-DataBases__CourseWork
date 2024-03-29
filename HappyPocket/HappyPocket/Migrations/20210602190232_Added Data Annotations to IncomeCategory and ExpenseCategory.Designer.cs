﻿// <auto-generated />
using System;
using HappyPocket.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HappyPocket.Migrations
{
    [DbContext(typeof(HappyPocketContext))]
    [Migration("20210602190232_Added Data Annotations to IncomeCategory and ExpenseCategory")]
    partial class AddedDataAnnotationstoIncomeCategoryandExpenseCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExpensePaymentType", b =>
                {
                    b.Property<int>("ExpensesId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentTypesId")
                        .HasColumnType("int");

                    b.HasKey("ExpensesId", "PaymentTypesId");

                    b.HasIndex("PaymentTypesId");

                    b.ToTable("ExpensePaymentType");
                });

            modelBuilder.Entity("HappyPocket.DataModel.Counteragent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Counteragents");
                });

            modelBuilder.Entity("HappyPocket.DataModel.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CounteragentId")
                        .HasColumnType("int");

                    b.Property<int?>("ExpenseCategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("FamilyMemberId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CounteragentId");

                    b.HasIndex("ExpenseCategoryId");

                    b.HasIndex("FamilyMemberId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("HappyPocket.DataModel.ExpenseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Limit")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("ExpenseCategories");
                });

            modelBuilder.Entity("HappyPocket.DataModel.FamilyMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("FamilyMembers");
                });

            modelBuilder.Entity("HappyPocket.DataModel.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CounteragentId")
                        .HasColumnType("int");

                    b.Property<int?>("FamilyMemberId")
                        .HasColumnType("int");

                    b.Property<int?>("IncomeCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CounteragentId");

                    b.HasIndex("FamilyMemberId");

                    b.HasIndex("IncomeCategoryId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("HappyPocket.DataModel.IncomeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("IncomeCategories");
                });

            modelBuilder.Entity("HappyPocket.DataModel.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("HappyPocket.DataModel.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("IncomePaymentType", b =>
                {
                    b.Property<int>("IncomesId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentTypesId")
                        .HasColumnType("int");

                    b.HasKey("IncomesId", "PaymentTypesId");

                    b.HasIndex("PaymentTypesId");

                    b.ToTable("IncomePaymentType");
                });

            modelBuilder.Entity("ExpensePaymentType", b =>
                {
                    b.HasOne("HappyPocket.DataModel.Expense", null)
                        .WithMany()
                        .HasForeignKey("ExpensesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HappyPocket.DataModel.PaymentType", null)
                        .WithMany()
                        .HasForeignKey("PaymentTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HappyPocket.DataModel.Expense", b =>
                {
                    b.HasOne("HappyPocket.DataModel.Counteragent", "Counteragent")
                        .WithMany("Expenses")
                        .HasForeignKey("CounteragentId");

                    b.HasOne("HappyPocket.DataModel.ExpenseCategory", "ExpenseCategory")
                        .WithMany("Expenses")
                        .HasForeignKey("ExpenseCategoryId");

                    b.HasOne("HappyPocket.DataModel.FamilyMember", "FamilyMember")
                        .WithMany("Expenses")
                        .HasForeignKey("FamilyMemberId");

                    b.Navigation("Counteragent");

                    b.Navigation("ExpenseCategory");

                    b.Navigation("FamilyMember");
                });

            modelBuilder.Entity("HappyPocket.DataModel.FamilyMember", b =>
                {
                    b.HasOne("HappyPocket.DataModel.Role", "Role")
                        .WithMany("FamilyMembers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HappyPocket.DataModel.Income", b =>
                {
                    b.HasOne("HappyPocket.DataModel.Counteragent", "Counteragent")
                        .WithMany("Incomes")
                        .HasForeignKey("CounteragentId");

                    b.HasOne("HappyPocket.DataModel.FamilyMember", "FamilyMember")
                        .WithMany("Incomes")
                        .HasForeignKey("FamilyMemberId");

                    b.HasOne("HappyPocket.DataModel.IncomeCategory", "IncomeCategory")
                        .WithMany("Incomes")
                        .HasForeignKey("IncomeCategoryId");

                    b.Navigation("Counteragent");

                    b.Navigation("FamilyMember");

                    b.Navigation("IncomeCategory");
                });

            modelBuilder.Entity("IncomePaymentType", b =>
                {
                    b.HasOne("HappyPocket.DataModel.Income", null)
                        .WithMany()
                        .HasForeignKey("IncomesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HappyPocket.DataModel.PaymentType", null)
                        .WithMany()
                        .HasForeignKey("PaymentTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HappyPocket.DataModel.Counteragent", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Incomes");
                });

            modelBuilder.Entity("HappyPocket.DataModel.ExpenseCategory", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("HappyPocket.DataModel.FamilyMember", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Incomes");
                });

            modelBuilder.Entity("HappyPocket.DataModel.IncomeCategory", b =>
                {
                    b.Navigation("Incomes");
                });

            modelBuilder.Entity("HappyPocket.DataModel.Role", b =>
                {
                    b.Navigation("FamilyMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
