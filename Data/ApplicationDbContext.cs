﻿
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AMS.Models;

namespace AMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Email> Emails { get; set; }
        public DbSet<Sms> Sms { get; set; }

        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<Salary> Salarys { get; set; }
        public DbSet<Stuff> Stuffs { get; set; }
        public DbSet<CustomerDocument> CustomerDocuments { get; set; }
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<DocumentM> Documents { get; set; }
        public DbSet<Cleaning> Cleanings { get; set; }
        public DbSet<LoanInstallment> LoanInstallments { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<Emegency> Emegencys { get; set; }
        public DbSet<SmsUsage> SmsUsages { get; set; }
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanType> LoansTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<Communication> Communications { get; set; }
        public DbSet<Water> Waters { get; set; }
        public DbSet<Electricity> Electricitys { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<MaintenanceType> MaintenanceTypes { get; set; }
        public DbSet<ManageProperty> ManagePropertys { get; set; }
        public DbSet<MeterBox> MeterBoxs { get; set; }
        public DbSet<MeterBoxType> MeterBoxTypes { get; set; }
        public DbSet<ParkingType> ParkingTypes { get; set; }
        public DbSet<Property> Propertys { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<RentType> RentTypes { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<AMS.Models.CommunicationVM> CommunicationVM { get; set; }
        public DbSet<AMS.Models.LoanTypeVM> LoanTypeVM { get; set; }
        public DbSet<AMS.Models.RentTypeVM> RentTypeVM { get; set; }
        public DbSet<AMS.Models.AssetTypeVM> AssetTypeVM { get; set; }
        public DbSet<AMS.Models.ParkingTypeVM> ParkingTypeVM { get; set; }
        public DbSet<AMS.Models.PropertyTypeVM> PropertyTypeVM { get; set; }
        public DbSet<AMS.Models.MeterBoxTypeVM> MeterBoxTypeVM { get; set; }
        public DbSet<AMS.Models.WaterVM> WaterVM { get; set; }
        public DbSet<AMS.Models.EditElectricityVM> EditElectricityVM { get; set; }
        public DbSet<AMS.Models.MaintenanceTypeVM> MaintenanceTypeVM { get; set; }



    }
}
