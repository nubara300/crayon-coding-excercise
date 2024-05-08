﻿// <auto-generated />
using System;
using CloudSalesSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CloudSalesSystem.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CloudSalesSystem.Domain.Models.Accounts.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DateModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c73404d8-7346-4222-a576-b58f768ff1eb"),
                            CustomerId = new Guid("b3fd58c6-03e6-4769-a3b7-892d12574111"),
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "AccDesc1",
                            IsDeleted = false,
                            Name = "Account1"
                        },
                        new
                        {
                            Id = new Guid("2bc60f98-8e04-4940-b7fb-04e2ec129c4d"),
                            CustomerId = new Guid("b3fd58c6-03e6-4769-a3b7-892d12574111"),
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "AccDesc2",
                            IsDeleted = false,
                            Name = "Account2"
                        },
                        new
                        {
                            Id = new Guid("1225e582-71b6-4b81-ade8-6c37e32fdbc8"),
                            CustomerId = new Guid("b3fd58c6-03e6-4769-a3b7-892d12574111"),
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "AccDesc3",
                            IsDeleted = false,
                            Name = "Account3"
                        });
                });

            modelBuilder.Entity("CloudSalesSystem.Domain.Models.Customers.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DateModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b3fd58c6-03e6-4769-a3b7-892d12574111"),
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "CustomerDesc",
                            IsDeleted = false,
                            Name = "Customer1"
                        });
                });

            modelBuilder.Entity("CloudSalesSystem.Domain.Models.Licences.License", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DateModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LicenseKey")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ServiceSubscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("ServiceSubscriptionId");

                    b.ToTable("Licences");
                });

            modelBuilder.Entity("CloudSalesSystem.Domain.Models.ServiceSubscriptions.ServiceSubscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DateModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SoftwareServiceName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<Guid>("SubscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TransactionTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ValidToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("ServiceSubscriptions");
                });

            modelBuilder.Entity("CloudSalesSystem.Domain.Models.Accounts.Account", b =>
                {
                    b.HasOne("CloudSalesSystem.Domain.Models.Customers.Customer", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CloudSalesSystem.Domain.Models.Customers.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CloudSalesSystem.Domain.Models.Customers.Customer", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedBy");

                    b.Navigation("Customer");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("CloudSalesSystem.Domain.Models.Customers.Customer", b =>
                {
                    b.HasOne("CloudSalesSystem.Domain.Models.Customers.Customer", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CloudSalesSystem.Domain.Models.Customers.Customer", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("CloudSalesSystem.Domain.Models.Licences.License", b =>
                {
                    b.HasOne("CloudSalesSystem.Domain.Models.Customers.Customer", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CloudSalesSystem.Domain.Models.Customers.Customer", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CloudSalesSystem.Domain.Models.ServiceSubscriptions.ServiceSubscription", "ServiceSubscription")
                        .WithMany("Licenses")
                        .HasForeignKey("ServiceSubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("ServiceSubscription");
                });

            modelBuilder.Entity("CloudSalesSystem.Domain.Models.ServiceSubscriptions.ServiceSubscription", b =>
                {
                    b.HasOne("CloudSalesSystem.Domain.Models.Accounts.Account", "Account")
                        .WithMany("ServiceSubscriptions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CloudSalesSystem.Domain.Models.Customers.Customer", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CloudSalesSystem.Domain.Models.Customers.Customer", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Account");

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("CloudSalesSystem.Domain.Models.Accounts.Account", b =>
                {
                    b.Navigation("ServiceSubscriptions");
                });

            modelBuilder.Entity("CloudSalesSystem.Domain.Models.Customers.Customer", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("CloudSalesSystem.Domain.Models.ServiceSubscriptions.ServiceSubscription", b =>
                {
                    b.Navigation("Licenses");
                });
#pragma warning restore 612, 618
        }
    }
}
