﻿// <auto-generated />
using System;
using LABA2CORE;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LABA2CORE.Migrations
{
    [DbContext(typeof(BankSystemContext))]
    [Migration("20211125184113_Funcs")]
    partial class Funcs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LABA2CORE.Account", b =>
                {
                    b.Property<string>("AccountNumber")
                        .HasMaxLength(17)
                        .HasColumnType("nchar(17)")
                        .IsFixedLength(true);

                    b.Property<double>("Balance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValueSql("((0.00))");

                    b.Property<double?>("CreditSum")
                        .HasColumnType("float");

                    b.Property<string>("Currency")
                        .HasMaxLength(15)
                        .HasColumnType("nchar(15)")
                        .IsFixedLength(true);

                    b.Property<string>("Itn")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("ITN")
                        .IsFixedLength(true);

                    b.Property<string>("Usreou")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("USREOU")
                        .IsFixedLength(true);

                    b.HasKey("AccountNumber")
                        .HasName("PK__Account__BE2ACD6E4CFA75C3");

                    b.HasIndex("Itn");

                    b.HasIndex("Usreou");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("LABA2CORE.Bank", b =>
                {
                    b.Property<string>("Usreou")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("USREOU")
                        .IsFixedLength(true);

                    b.Property<string>("Departments")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .IsFixedLength(true);

                    b.Property<double?>("GoldCapacity")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .IsFixedLength(true);

                    b.Property<string>("OriginCountry")
                        .HasMaxLength(15)
                        .HasColumnType("nchar(15)")
                        .IsFixedLength(true);

                    b.Property<double?>("OverallBalance")
                        .HasColumnType("float");

                    b.HasKey("Usreou")
                        .HasName("PK__Bank__E16F21C3F654D63D");

                    b.ToTable("Bank");
                });

            modelBuilder.Entity("LABA2CORE.Card", b =>
                {
                    b.Property<string>("CardNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .IsFixedLength(true);

                    b.Property<int?>("Cvv")
                        .HasColumnType("int")
                        .HasColumnName("CVV");

                    b.Property<DateTime>("DateOfExpire")
                        .HasColumnType("date");

                    b.Property<string>("Itn")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("ITN")
                        .IsFixedLength(true);

                    b.Property<double?>("Percentage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValueSql("((0.00))");

                    b.Property<string>("TypeOfCard")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .IsFixedLength(true);

                    b.HasKey("CardNumber")
                        .HasName("PK__Card__A4E9FFE814BA8F9F");

                    b.HasIndex("Itn");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("LABA2CORE.Customer", b =>
                {
                    b.Property<string>("Itn")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("ITN")
                        .IsFixedLength(true);

                    b.Property<string>("Adress")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .IsFixedLength(true);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .IsFixedLength(true);

                    b.Property<string>("FirstName")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .IsFixedLength(true);

                    b.Property<string>("LastName")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .IsFixedLength(true);

                    b.Property<string>("LegalEntityIndividual")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nchar(11)")
                        .HasColumnName("LegalEntity/Individual")
                        .IsFixedLength(true);

                    b.Property<int>("Mfo")
                        .HasColumnType("int")
                        .HasColumnName("MFO");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nchar(16)")
                        .IsFixedLength(true);

                    b.Property<int?>("Postcode")
                        .HasColumnType("int");

                    b.Property<int?>("TrustLimit")
                        .HasColumnType("int");

                    b.HasKey("Itn")
                        .HasName("PK__Customer__C4978204CC9EB27C");

                    b.HasIndex(new[] { "PhoneNumber" }, "UQ__Customer__85FB4E381EC5770E")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Customer__A9D1053491D83182")
                        .IsUnique();

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("LABA2CORE.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FromBank")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true);

                    b.Property<string>("Specialization")
                        .HasMaxLength(15)
                        .HasColumnType("nchar(15)")
                        .IsFixedLength(true);

                    b.Property<string>("WorkDays")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true);

                    b.HasKey("DepartmentId");

                    b.HasIndex("FromBank");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("LABA2CORE.Employee", b =>
                {
                    b.Property<string>("Itn")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("ITN")
                        .IsFixedLength(true);

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nchar(25)")
                        .IsFixedLength(true);

                    b.Property<string>("FirstName")
                        .HasMaxLength(15)
                        .HasColumnType("nchar(15)")
                        .IsFixedLength(true);

                    b.Property<string>("Job")
                        .HasMaxLength(18)
                        .HasColumnType("nchar(18)")
                        .IsFixedLength(true);

                    b.Property<string>("LastName")
                        .HasMaxLength(15)
                        .HasColumnType("nchar(15)")
                        .IsFixedLength(true);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nchar(18)")
                        .IsFixedLength(true);

                    b.Property<int?>("PostCode")
                        .HasColumnType("int");

                    b.Property<double>("Sallary")
                        .HasColumnType("float");

                    b.HasKey("Itn")
                        .HasName("PK__Employee__C4978204A7CB1A92");

                    b.HasIndex("Department");

                    b.HasIndex(new[] { "PhoneNumber" }, "UQ__Employee__85FB4E386F059E34")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Employee__A9D10534EC02EEF6")
                        .IsUnique();

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("LABA2CORE.InsuranceGiver", b =>
                {
                    b.Property<string>("InsuranceUsreou")
                        .HasMaxLength(16)
                        .HasColumnType("nchar(16)")
                        .HasColumnName("InsuranceUSREOU")
                        .IsFixedLength(true);

                    b.Property<string>("BankCountry")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("Bank/Country")
                        .IsFixedLength(true);

                    b.Property<double?>("InsuranceAmount")
                        .HasColumnType("float");

                    b.Property<string>("InsuranceObject")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true);

                    b.Property<bool>("IsBank")
                        .HasColumnType("bit");

                    b.HasKey("InsuranceUsreou")
                        .HasName("PK__Insuranc__863B01ED95F48418");

                    b.HasIndex("InsuranceObject");

                    b.ToTable("InsuranceGiver");
                });

            modelBuilder.Entity("LABA2CORE.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .HasColumnType("int")
                        .HasColumnName("TransactionID");

                    b.Property<double?>("BalanceChange")
                        .HasColumnType("float");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .IsFixedLength(true);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .IsFixedLength(true);

                    b.HasKey("TransactionId");

                    b.HasIndex("CardNumber");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("LABA2CORE.Account", b =>
                {
                    b.HasOne("LABA2CORE.Customer", "ItnNavigation")
                        .WithMany("Accounts")
                        .HasForeignKey("Itn")
                        .HasConstraintName("FK__Account__ITN__22AA2996")
                        .IsRequired();

                    b.HasOne("LABA2CORE.Bank", "UsreouNavigation")
                        .WithMany("Accounts")
                        .HasForeignKey("Usreou")
                        .HasConstraintName("FK__Account__USREOU__21B6055D")
                        .IsRequired();

                    b.Navigation("ItnNavigation");

                    b.Navigation("UsreouNavigation");
                });

            modelBuilder.Entity("LABA2CORE.Card", b =>
                {
                    b.HasOne("LABA2CORE.Customer", "ItnNavigation")
                        .WithMany("Cards")
                        .HasForeignKey("Itn")
                        .HasConstraintName("FK__Card__ITN__164452B1")
                        .IsRequired();

                    b.Navigation("ItnNavigation");
                });

            modelBuilder.Entity("LABA2CORE.Department", b =>
                {
                    b.HasOne("LABA2CORE.Bank", "FromBankNavigation")
                        .WithMany("DepartmentsNavigation")
                        .HasForeignKey("FromBank")
                        .HasConstraintName("FK__Departmen__FromB__2B3F6F97")
                        .IsRequired();

                    b.Navigation("FromBankNavigation");
                });

            modelBuilder.Entity("LABA2CORE.Employee", b =>
                {
                    b.HasOne("LABA2CORE.Department", "DepartmentNavigation")
                        .WithMany("Employees")
                        .HasForeignKey("Department")
                        .HasConstraintName("FK__Employee__Depart__300424B4")
                        .IsRequired();

                    b.Navigation("DepartmentNavigation");
                });

            modelBuilder.Entity("LABA2CORE.InsuranceGiver", b =>
                {
                    b.HasOne("LABA2CORE.Bank", "InsuranceObjectNavigation")
                        .WithMany("InsuranceGivers")
                        .HasForeignKey("InsuranceObject")
                        .HasConstraintName("FK__Insurance__Insur__286302EC")
                        .IsRequired();

                    b.Navigation("InsuranceObjectNavigation");
                });

            modelBuilder.Entity("LABA2CORE.Transaction", b =>
                {
                    b.HasOne("LABA2CORE.Card", "CardNumberNavigation")
                        .WithMany("Transactions")
                        .HasForeignKey("CardNumber")
                        .HasConstraintName("FK__Transacti__CardN__1A14E395")
                        .IsRequired();

                    b.Navigation("CardNumberNavigation");
                });

            modelBuilder.Entity("LABA2CORE.Bank", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("DepartmentsNavigation");

                    b.Navigation("InsuranceGivers");
                });

            modelBuilder.Entity("LABA2CORE.Card", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("LABA2CORE.Customer", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Cards");
                });

            modelBuilder.Entity("LABA2CORE.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}