using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS.Data;

namespace AMS.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Email> Emails { get; }
        IGenericRepository<Sms> Sms { get; }

        IGenericRepository<Timesheet> Timesheets { get; }
        IGenericRepository<Salary> Salarys { get; }
        IGenericRepository<Stuff> Stuffs { get; }
        IGenericRepository<Parking> Parkings { get; }
        IGenericRepository<Cleaning> Cleanings { get; }
        IGenericRepository<Audit> Audits { get; }
        IGenericRepository<Emegency> Emegencys { get; }
        IGenericRepository<SmsUsage> SmsUsages { get; }
        IGenericRepository<Admission> Admissions { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Loan> Loans { get; }
        IGenericRepository<LoanType> LoanTypes { get; }
        IGenericRepository<Asset> Assets { get; }
        IGenericRepository<AssetType> AssetTypes { get; }
        IGenericRepository<Communication> Communications { get; }
        IGenericRepository<Water> Waters { get; }
        IGenericRepository<Electricity> Electricitys { get; }
        IGenericRepository<Invoice> Invoices { get; }
        IGenericRepository<Maintenance> Maintenances { get; }
        IGenericRepository<MaintenanceType> MaintenanceTypes { get; }
        IGenericRepository<ManageProperty> ManagePropertys { get; }
        IGenericRepository<MeterBox> MeterBoxs { get; }
        IGenericRepository<MeterBoxType> MeterBoxTypes { get; }
        IGenericRepository<ParkingType> ParkingTypes { get; }
        IGenericRepository<Property> Propertys { get; }
        IGenericRepository<PropertyType> PropertyTypes { get; }
        IGenericRepository<RentType> RentTypes { get; }
        IGenericRepository<Visitor> Visitors { get; }
        IGenericRepository<LoanInstallment> LoanInstallments { get; }
        Task Save();

    }
}
