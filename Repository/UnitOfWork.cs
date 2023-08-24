using AMS.Contracts;
using AMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Cleaning> _Cleaning;
        private IGenericRepository<SmsUsage> _SmsUsages;
        private IGenericRepository<Emegency> _Emegencys;
        private IGenericRepository<Admission> _Admissions;
        private IGenericRepository<Customer> _Customers;
        private IGenericRepository<Loan> _Loan;
        private IGenericRepository<LoanType> _LoanType;
        private IGenericRepository<Asset> _Asset;
        private IGenericRepository<AssetType> _AssetType;
        private IGenericRepository<Communication> _Communication;
        private IGenericRepository<Water> _Water;
        private IGenericRepository<Electricity> _Electricity;
        private IGenericRepository<Invoice> _Invoice;
        private IGenericRepository<Maintenance> _Maintenance;
        private IGenericRepository<MaintenanceType> _MaintenanceType;
        private IGenericRepository<ManageProperty> _ManageProperty;
        private IGenericRepository<MeterBox> _MeterBox;
        private IGenericRepository<MeterBoxType> _MeterBoxType;
        private IGenericRepository<ParkingType> _ParkingType;
        private IGenericRepository<Property> _Property;
        private IGenericRepository<PropertyType> _PropertyType;
        private IGenericRepository<RentType> _RentType;
        private IGenericRepository<Visitor> _Visitor;
        private IGenericRepository<Audit> _Audit;
        private IGenericRepository<LoanInstallment> _LoanInstallment;
        private IGenericRepository<Parking> _Parking;
        private IGenericRepository<Stuff> _Stuff;
        private IGenericRepository<Salary> _Salary;
        private IGenericRepository<Timesheet> _Timesheet;
        private IGenericRepository<Email> _Email;
        private IGenericRepository<Sms> _Sms;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Email> Emails
    => _Email ??= new GenericRepository<Email>(_context);
        public IGenericRepository<Sms> Sms
=> _Sms ??= new GenericRepository<Sms>(_context);

        public IGenericRepository<Timesheet> Timesheets
    => _Timesheet ??= new GenericRepository<Timesheet>(_context);
        public IGenericRepository<Salary> Salarys
    => _Salary ??= new GenericRepository<Salary>(_context);
        public IGenericRepository<Stuff> Stuffs
    => _Stuff ??= new GenericRepository<Stuff>(_context);
        public IGenericRepository<Parking> Parkings
    => _Parking ??= new GenericRepository<Parking>(_context);
        public IGenericRepository<Cleaning> Cleanings
    => _Cleaning ??= new GenericRepository<Cleaning>(_context);
        public IGenericRepository<LoanInstallment> LoanInstallments
    => _LoanInstallment ??= new GenericRepository<LoanInstallment>(_context);
        public IGenericRepository<Audit> Audits
    => _Audit ??= new GenericRepository<Audit>(_context);
        public IGenericRepository<SmsUsage> SmsUsages
    => _SmsUsages ??= new GenericRepository<SmsUsage>(_context);

        public IGenericRepository<Emegency> Emegencys
=> _Emegencys ??= new GenericRepository<Emegency>(_context);

        public IGenericRepository<Admission> Admissions
    => _Admissions ??= new GenericRepository<Admission>(_context);

        public IGenericRepository<Customer> Customers
            => _Customers ??= new GenericRepository<Customer>(_context);

        public IGenericRepository<Loan> Loans
            => _Loan ??= new GenericRepository<Loan>(_context);
        public IGenericRepository<LoanType> LoanTypes
    => _LoanType ??= new GenericRepository<LoanType>(_context);

        public IGenericRepository<Asset> Assets
    => _Asset ??= new GenericRepository<Asset>(_context);

        public IGenericRepository<AssetType> AssetTypes
    => _AssetType ??= new GenericRepository<AssetType>(_context);
        public IGenericRepository<Communication> Communications
=> _Communication ??= new GenericRepository<Communication>(_context);

        public IGenericRepository<Water> Waters
=> _Water ??= new GenericRepository<Water>(_context);

        public IGenericRepository<Electricity> Electricitys
    => _Electricity ??= new GenericRepository<Electricity>(_context);

        public IGenericRepository<Invoice> Invoices
    => _Invoice ??= new GenericRepository<Invoice>(_context);

        public IGenericRepository<Maintenance> Maintenances
    => _Maintenance ??= new GenericRepository<Maintenance>(_context);

        public IGenericRepository<MaintenanceType> MaintenanceTypes
    => _MaintenanceType ??= new GenericRepository<MaintenanceType>(_context);

        public IGenericRepository<ManageProperty> ManagePropertys
    => _ManageProperty ??= new GenericRepository<ManageProperty>(_context);

        public IGenericRepository<MeterBox> MeterBoxs
    => _MeterBox ??= new GenericRepository<MeterBox>(_context);

        public IGenericRepository<MeterBoxType> MeterBoxTypes
    => _MeterBoxType ??= new GenericRepository<MeterBoxType>(_context);

        public IGenericRepository<ParkingType> ParkingTypes
    => _ParkingType ??= new GenericRepository<ParkingType>(_context);

        public IGenericRepository<Property> Propertys
    => _Property ??= new GenericRepository<Property>(_context);

        public IGenericRepository<PropertyType> PropertyTypes
    => _PropertyType ??= new GenericRepository<PropertyType>(_context);

        public IGenericRepository<RentType> RentTypes
    => _RentType ??= new GenericRepository<RentType>(_context);

        public IGenericRepository<Visitor> Visitors
=> _Visitor ??= new GenericRepository<Visitor>(_context);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                _context.Dispose();
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
