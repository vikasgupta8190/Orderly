﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orderly.Core.EntityModels;

namespace Orderly.Core.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220204094317_ChangeColumnNameInNetworkTokenTable")]
    partial class ChangeColumnNameInNetworkTokenTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Common.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPortfolioSetup")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Common.QueuedEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bcc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FailedTries")
                        .HasColumnType("int");

                    b.Property<string>("From")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsTGEMail")
                        .HasColumnType("bit");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<bool>("Sent")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("SentOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TriedToSendOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("QueuedEmails");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Contact.Monitoring", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IncommingTokenNotificationEvent")
                        .HasColumnType("bit");

                    b.Property<int?>("PortfolioMonitoringId")
                        .HasColumnType("int");

                    b.Property<bool>("ShowInPortfolio")
                        .HasColumnType("bit");

                    b.Property<bool>("TokenGenerationNotificationEvent")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioMonitoringId")
                        .IsUnique()
                        .HasFilter("[PortfolioMonitoringId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("Monitorings");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Contact.UserContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserContact");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Contact.UserContactGroupMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContactId")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("GroupId");

                    b.ToTable("UserContactGroupMappings");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Contact.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOnUTC")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOnUTC")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserGroup");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Investment.InvestmentDynamicDistribution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InvestmentId")
                        .HasColumnType("int");

                    b.Property<int?>("Lookup")
                        .HasColumnType("int");

                    b.Property<int?>("LookupDuration")
                        .HasColumnType("int");

                    b.Property<decimal?>("Peroid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TGE")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TokenPercentage")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("InvestmentId");

                    b.ToTable("InvestmentDynamicDistributions");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Investment.SharedInvestmentDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.Property<int>("InvestmentId")
                        .HasColumnType("int");

                    b.Property<decimal>("Percentage")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("InvestmentId");

                    b.ToTable("SharedInvestmentDetails");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Investment.UserInvestment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContactId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOnDateTimeUTC")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistributionPortal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DistributionTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("InvestedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("InvestedQuantity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InvestmentGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("InvestmentTransactionLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvestmentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("MonitoringTypeId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfToken")
                        .HasColumnType("int");

                    b.Property<decimal>("RefundAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SaftFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SaftPathSavedFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SentAddressFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sign")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TokenId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOnDateTimeUTC")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VestingId")
                        .HasColumnType("int");

                    b.Property<decimal>("VestingLockup")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VestingTokenPercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WebsiteLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("MonitoringTypeId");

                    b.HasIndex("TokenId");

                    b.HasIndex("UserId");

                    b.ToTable("UserInvestments");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Log.ErrorLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IPAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ErrorLog");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Portfolio.MonitoringType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MonitoringTypes");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Portfolio.PortfolioMonitoring", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressAlias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MonitoringTypeId")
                        .HasColumnType("int");

                    b.Property<int>("TokenId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MonitoringTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("PortfolioMonitorings");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Tokens.Calendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Goal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Stage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TokenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TokenId");

                    b.ToTable("Calendars");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Tokens.NetworkToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("AllTimeHighValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("AllTimeLowValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedOnDateTimeUTC")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("CurrentPriceUSD")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("IsNotificationSet")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsShowInPortfolio")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NetworkId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price24HrsDifference")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOnDateTimeUTC")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NetworkId");

                    b.HasIndex("UserId");

                    b.ToTable("NetworkTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Orderly.Core.Domain.Common.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Orderly.Core.Domain.Common.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Orderly.Core.Domain.Common.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Orderly.Core.Domain.Common.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Orderly.Core.Domain.Contact.Monitoring", b =>
                {
                    b.HasOne("Orderly.Core.Domain.Portfolio.PortfolioMonitoring", "PortfolioMonitoring")
                        .WithOne("Monitoring")
                        .HasForeignKey("Orderly.Core.Domain.Contact.Monitoring", "PortfolioMonitoringId");

                    b.HasOne("Orderly.Core.Domain.Common.ApplicationUser", "User")
                        .WithMany("Monitorings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PortfolioMonitoring");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Contact.UserContact", b =>
                {
                    b.HasOne("Orderly.Core.Domain.Common.ApplicationUser", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Contact.UserContactGroupMapping", b =>
                {
                    b.HasOne("Orderly.Core.Domain.Contact.UserContact", "Contact")
                        .WithMany("GroupMapping")
                        .HasForeignKey("ContactId");

                    b.HasOne("Orderly.Core.Domain.Contact.UserGroup", "Group")
                        .WithMany("ContactMapping")
                        .HasForeignKey("GroupId");

                    b.Navigation("Contact");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Contact.UserGroup", b =>
                {
                    b.HasOne("Orderly.Core.Domain.Common.ApplicationUser", "User")
                        .WithMany("Groups")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Investment.InvestmentDynamicDistribution", b =>
                {
                    b.HasOne("Orderly.Core.Domain.Investment.UserInvestment", "Investment")
                        .WithMany("DynamicDistributions")
                        .HasForeignKey("InvestmentId");

                    b.Navigation("Investment");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Investment.SharedInvestmentDetails", b =>
                {
                    b.HasOne("Orderly.Core.Domain.Contact.UserContact", "Contact")
                        .WithMany("sharedInvestmentDetails")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Orderly.Core.Domain.Investment.UserInvestment", "Investment")
                        .WithMany("sharedInvestmentDetails")
                        .HasForeignKey("InvestmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");

                    b.Navigation("Investment");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Investment.UserInvestment", b =>
                {
                    b.HasOne("Orderly.Core.Domain.Contact.UserContact", "UserContact")
                        .WithMany("userInvestment")
                        .HasForeignKey("ContactId");

                    b.HasOne("Orderly.Core.Domain.Portfolio.MonitoringType", "MonitoringType")
                        .WithOne("Investment")
                        .HasForeignKey("Orderly.Core.Domain.Investment.UserInvestment", "MonitoringTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Orderly.Core.Domain.Tokens.NetworkToken", "networkTokens")
                        .WithMany("userInvestment")
                        .HasForeignKey("TokenId");

                    b.HasOne("Orderly.Core.Domain.Common.ApplicationUser", "User")
                        .WithMany("Investments")
                        .HasForeignKey("UserId");

                    b.Navigation("MonitoringType");

                    b.Navigation("networkTokens");

                    b.Navigation("User");

                    b.Navigation("UserContact");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Portfolio.PortfolioMonitoring", b =>
                {
                    b.HasOne("Orderly.Core.Domain.Portfolio.MonitoringType", "MonitoringType")
                        .WithMany()
                        .HasForeignKey("MonitoringTypeId");

                    b.HasOne("Orderly.Core.Domain.Common.ApplicationUser", "User")
                        .WithMany("Portfolios")
                        .HasForeignKey("UserId");

                    b.Navigation("MonitoringType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Tokens.Calendar", b =>
                {
                    b.HasOne("Orderly.Core.Domain.Tokens.NetworkToken", "Token")
                        .WithMany("Calendars")
                        .HasForeignKey("TokenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Token");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Tokens.NetworkToken", b =>
                {
                    b.HasOne("Orderly.Core.Domain.Portfolio.MonitoringType", "Network")
                        .WithMany("Tokens")
                        .HasForeignKey("NetworkId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Orderly.Core.Domain.Common.ApplicationUser", "User")
                        .WithMany("NetworkTokens")
                        .HasForeignKey("UserId");

                    b.Navigation("Network");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Common.ApplicationUser", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Groups");

                    b.Navigation("Investments");

                    b.Navigation("Monitorings");

                    b.Navigation("NetworkTokens");

                    b.Navigation("Portfolios");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Contact.UserContact", b =>
                {
                    b.Navigation("GroupMapping");

                    b.Navigation("sharedInvestmentDetails");

                    b.Navigation("userInvestment");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Contact.UserGroup", b =>
                {
                    b.Navigation("ContactMapping");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Investment.UserInvestment", b =>
                {
                    b.Navigation("DynamicDistributions");

                    b.Navigation("sharedInvestmentDetails");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Portfolio.MonitoringType", b =>
                {
                    b.Navigation("Investment");

                    b.Navigation("Tokens");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Portfolio.PortfolioMonitoring", b =>
                {
                    b.Navigation("Monitoring");
                });

            modelBuilder.Entity("Orderly.Core.Domain.Tokens.NetworkToken", b =>
                {
                    b.Navigation("Calendars");

                    b.Navigation("userInvestment");
                });
#pragma warning restore 612, 618
        }
    }
}
