using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    IdNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    MoveInNumber = table.Column<string>(type: "TEXT", nullable: true),
                    MoveInDate = table.Column<string>(type: "TEXT", nullable: true),
                    AccommodationIntrested = table.Column<string>(type: "TEXT", nullable: true),
                    status = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Firstname = table.Column<string>(type: "TEXT", nullable: true),
                    Lastname = table.Column<string>(type: "TEXT", nullable: true),
                    TaxId = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateJoined = table.Column<DateTime>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    IntrestingKey = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetTypeVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypeVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    Action = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Communications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommunicationType = table.Column<string>(type: "TEXT", nullable: true),
                    EmailReceiver = table.Column<string>(type: "TEXT", nullable: true),
                    EmailSubject = table.Column<string>(type: "TEXT", nullable: true),
                    EmailMessage = table.Column<string>(type: "TEXT", nullable: true),
                    SmsReceiver = table.Column<string>(type: "TEXT", nullable: true),
                    SmsSubject = table.Column<string>(type: "TEXT", nullable: true),
                    SmsMessage = table.Column<string>(type: "TEXT", nullable: true),
                    Process = table.Column<string>(type: "TEXT", nullable: true),
                    Respond = table.Column<string>(type: "TEXT", nullable: true),
                    TenantId = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommunicationType = table.Column<string>(type: "TEXT", nullable: true),
                    EmailReceiver = table.Column<string>(type: "TEXT", nullable: true),
                    EmailSubject = table.Column<string>(type: "TEXT", nullable: true),
                    EmailMessage = table.Column<string>(type: "TEXT", nullable: true),
                    SmsReceiver = table.Column<string>(type: "TEXT", nullable: true),
                    SmsSubject = table.Column<string>(type: "TEXT", nullable: true),
                    SmsMessage = table.Column<string>(type: "TEXT", nullable: true),
                    Process = table.Column<string>(type: "TEXT", nullable: true),
                    Respond = table.Column<string>(type: "TEXT", nullable: true),
                    TenantId = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    FileType = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    FileData = table.Column<byte[]>(type: "BLOB", nullable: true),
                    TenantOrStuff = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    IDNumber = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Occupation = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    HomeAddress = table.Column<string>(type: "TEXT", nullable: true),
                    MoveInNumber = table.Column<string>(type: "TEXT", nullable: true),
                    MoveInDate = table.Column<string>(type: "TEXT", nullable: true),
                    AccommodationIntrested = table.Column<string>(type: "TEXT", nullable: true),
                    process = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    TenantAccess = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    FileType = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    FileData = table.Column<byte[]>(type: "BLOB", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommunicationType = table.Column<string>(type: "TEXT", nullable: true),
                    EmailReceiver = table.Column<string>(type: "TEXT", nullable: true),
                    EmailSubject = table.Column<string>(type: "TEXT", nullable: true),
                    EmailMessage = table.Column<string>(type: "TEXT", nullable: true),
                    SmsReceiver = table.Column<string>(type: "TEXT", nullable: true),
                    SmsSubject = table.Column<string>(type: "TEXT", nullable: true),
                    SmsMessage = table.Column<string>(type: "TEXT", nullable: true),
                    Process = table.Column<string>(type: "TEXT", nullable: true),
                    Respond = table.Column<string>(type: "TEXT", nullable: true),
                    TenantId = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoansTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    IntrestRate = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoansTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanTypeVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    IntrestRate = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanTypeVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaintenanceTypeName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceTypeVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaintenanceTypeName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceTypeVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeterBoxTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeterBoxName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterBoxTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeterBoxTypeVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeterBoxName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterBoxTypeVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParkingTypeName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingTypeVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParkingTypeName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingTypeVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropertyTypeName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypeVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropertyTypeName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypeVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RentTypeName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentTypeVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RentTypeName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentTypeVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommunicationType = table.Column<string>(type: "TEXT", nullable: true),
                    EmailReceiver = table.Column<string>(type: "TEXT", nullable: true),
                    EmailSubject = table.Column<string>(type: "TEXT", nullable: true),
                    EmailMessage = table.Column<string>(type: "TEXT", nullable: true),
                    SmsReceiver = table.Column<string>(type: "TEXT", nullable: true),
                    SmsSubject = table.Column<string>(type: "TEXT", nullable: true),
                    SmsMessage = table.Column<string>(type: "TEXT", nullable: true),
                    Process = table.Column<string>(type: "TEXT", nullable: true),
                    Respond = table.Column<string>(type: "TEXT", nullable: true),
                    TenantId = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmsUsages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sender = table.Column<string>(type: "TEXT", nullable: true),
                    Receiver = table.Column<string>(type: "TEXT", nullable: true),
                    SmsDate = table.Column<string>(type: "TEXT", nullable: true),
                    SmsResoan = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsUsages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stuffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    IDNumber = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Occupation = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    HomeAddress = table.Column<string>(type: "TEXT", nullable: true),
                    Salary = table.Column<string>(type: "TEXT", nullable: true),
                    MoveInNumber = table.Column<string>(type: "TEXT", nullable: true),
                    MoveInDate = table.Column<string>(type: "TEXT", nullable: true),
                    AccommodationIntrested = table.Column<string>(type: "TEXT", nullable: true),
                    process = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    TenantAccess = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stuffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Waters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LoanTerm = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    RemainingAmount = table.Column<string>(type: "TEXT", nullable: true),
                    LoanNumber = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    LoanTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_LoansTypes_LoanTypeId",
                        column: x => x.LoanTypeId,
                        principalTable: "LoansTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parkings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    isAvailable = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    Owner = table.Column<string>(type: "TEXT", nullable: true),
                    ParkingTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parkings_ParkingTypes_ParkingTypeId",
                        column: x => x.ParkingTypeId,
                        principalTable: "ParkingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InvoiceNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    RentTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    isPaid = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_RentTypes_RentTypeId",
                        column: x => x.RentTypeId,
                        principalTable: "RentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salarys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InvoiceNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<string>(type: "TEXT", nullable: true),
                    StuffId = table.Column<int>(type: "INTEGER", nullable: false),
                    isPaid = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salarys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salarys_Stuffs_StuffId",
                        column: x => x.StuffId,
                        principalTable: "Stuffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timesheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InvoiceNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<string>(type: "TEXT", nullable: true),
                    StuffId = table.Column<int>(type: "INTEGER", nullable: false),
                    isPaid = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timesheets_Stuffs_StuffId",
                        column: x => x.StuffId,
                        principalTable: "Stuffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanInstallments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<string>(type: "TEXT", nullable: true),
                    datePaid = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    LoanId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanInstallments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanInstallments_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Propertys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropertyName = table.Column<string>(type: "TEXT", nullable: true),
                    Occupied = table.Column<string>(type: "TEXT", nullable: true),
                    OccupiedDate = table.Column<string>(type: "TEXT", nullable: true),
                    ParkingId = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propertys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Propertys_Parkings_ParkingId",
                        column: x => x.ParkingId,
                        principalTable: "Parkings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Propertys_PropertyTypes_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssetTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_AssetTypes_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AssetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_Propertys_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Propertys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cleanings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    dateCleaning = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cleanings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cleanings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cleanings_Propertys_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Propertys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EditElectricityVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Units = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<string>(type: "TEXT", nullable: true),
                    PurchaseDate = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditElectricityVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EditElectricityVM_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EditElectricityVM_Propertys_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Propertys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Electricitys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Units = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<string>(type: "TEXT", nullable: true),
                    PurchaseDate = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electricitys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Electricitys_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Electricitys_Propertys_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Propertys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emegencys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    Time = table.Column<string>(type: "TEXT", nullable: true),
                    Solved = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emegencys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emegencys_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emegencys_Propertys_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Propertys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    MaintenanceTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenances_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maintenances_MaintenanceTypes_MaintenanceTypeId",
                        column: x => x.MaintenanceTypeId,
                        principalTable: "MaintenanceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maintenances_Propertys_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Propertys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagePropertys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    available = table.Column<string>(type: "TEXT", nullable: true),
                    RentAmount = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false),
                    RentTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagePropertys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagePropertys_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagePropertys_Propertys_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Propertys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagePropertys_RentTypes_RentTypeId",
                        column: x => x.RentTypeId,
                        principalTable: "RentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeterBoxs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeterBoxNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false),
                    MeterBoxTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterBoxs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterBoxs_MeterBoxTypes_MeterBoxTypeId",
                        column: x => x.MeterBoxTypeId,
                        principalTable: "MeterBoxTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeterBoxs_Propertys_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Propertys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Resoan = table.Column<string>(type: "TEXT", nullable: true),
                    CheckOut = table.Column<string>(type: "TEXT", nullable: true),
                    Accept = table.Column<string>(type: "TEXT", nullable: true),
                    CarRegistration = table.Column<string>(type: "TEXT", nullable: true),
                    IsChecked = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    ConfirmationCode = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false),
                    isDeleted = table.Column<string>(type: "TEXT", nullable: true),
                    ParkingId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitors_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visitors_Parkings_ParkingId",
                        column: x => x.ParkingId,
                        principalTable: "Parkings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visitors_Propertys_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Propertys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetTypeId",
                table: "Assets",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CustomerId",
                table: "Assets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_PropertyId",
                table: "Assets",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cleanings_CustomerId",
                table: "Cleanings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cleanings_PropertyId",
                table: "Cleanings",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_EditElectricityVM_CustomerId",
                table: "EditElectricityVM",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_EditElectricityVM_PropertyId",
                table: "EditElectricityVM",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Electricitys_CustomerId",
                table: "Electricitys",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Electricitys_PropertyId",
                table: "Electricitys",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Emegencys_CustomerId",
                table: "Emegencys",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Emegencys_PropertyId",
                table: "Emegencys",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_RentTypeId",
                table: "Invoices",
                column: "RentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanInstallments_LoanId",
                table: "LoanInstallments",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CustomerId",
                table: "Loans",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_LoanTypeId",
                table: "Loans",
                column: "LoanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_CustomerId",
                table: "Maintenances",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_MaintenanceTypeId",
                table: "Maintenances",
                column: "MaintenanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_PropertyId",
                table: "Maintenances",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagePropertys_CustomerId",
                table: "ManagePropertys",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagePropertys_PropertyId",
                table: "ManagePropertys",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagePropertys_RentTypeId",
                table: "ManagePropertys",
                column: "RentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterBoxs_MeterBoxTypeId",
                table: "MeterBoxs",
                column: "MeterBoxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterBoxs_PropertyId",
                table: "MeterBoxs",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Parkings_ParkingTypeId",
                table: "Parkings",
                column: "ParkingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Propertys_ParkingId",
                table: "Propertys",
                column: "ParkingId");

            migrationBuilder.CreateIndex(
                name: "IX_Propertys_PropertyTypeId",
                table: "Propertys",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Salarys_StuffId",
                table: "Salarys",
                column: "StuffId");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_StuffId",
                table: "Timesheets",
                column: "StuffId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_CustomerId",
                table: "Visitors",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_ParkingId",
                table: "Visitors",
                column: "ParkingId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_PropertyId",
                table: "Visitors",
                column: "PropertyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admissions");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "AssetTypeVM");

            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "Cleanings");

            migrationBuilder.DropTable(
                name: "Communications");

            migrationBuilder.DropTable(
                name: "CommunicationVM");

            migrationBuilder.DropTable(
                name: "CustomerDocuments");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "EditElectricityVM");

            migrationBuilder.DropTable(
                name: "Electricitys");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Emegencys");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "LoanInstallments");

            migrationBuilder.DropTable(
                name: "LoanTypeVM");

            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DropTable(
                name: "MaintenanceTypeVM");

            migrationBuilder.DropTable(
                name: "ManagePropertys");

            migrationBuilder.DropTable(
                name: "MeterBoxs");

            migrationBuilder.DropTable(
                name: "MeterBoxTypeVM");

            migrationBuilder.DropTable(
                name: "ParkingTypeVM");

            migrationBuilder.DropTable(
                name: "PropertyTypeVM");

            migrationBuilder.DropTable(
                name: "RentTypeVM");

            migrationBuilder.DropTable(
                name: "Salarys");

            migrationBuilder.DropTable(
                name: "Sms");

            migrationBuilder.DropTable(
                name: "SmsUsages");

            migrationBuilder.DropTable(
                name: "Timesheets");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "Waters");

            migrationBuilder.DropTable(
                name: "WaterVM");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AssetTypes");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "MaintenanceTypes");

            migrationBuilder.DropTable(
                name: "RentTypes");

            migrationBuilder.DropTable(
                name: "MeterBoxTypes");

            migrationBuilder.DropTable(
                name: "Stuffs");

            migrationBuilder.DropTable(
                name: "Propertys");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "LoansTypes");

            migrationBuilder.DropTable(
                name: "Parkings");

            migrationBuilder.DropTable(
                name: "PropertyTypes");

            migrationBuilder.DropTable(
                name: "ParkingTypes");
        }
    }
}
