using AutoMapper;
using AMS.Data;
using AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Sms, SmsVM>().ReverseMap();
            CreateMap<Email, EmailVM>().ReverseMap();


            CreateMap<Timesheet, EditTimesheetVM>().ReverseMap();

            CreateMap<Salary, EditSalaryVM>().ReverseMap();

            CreateMap<Salary, SalaryVM>().ReverseMap();

            CreateMap<Stuff, StuffVM>().ReverseMap();

            CreateMap<Parking, EditParkingVM>().ReverseMap();

            CreateMap<Parking, ParkingVM>().ReverseMap();

            CreateMap<DocumentM, DocumentVM>().ReverseMap();

            CreateMap<Cleaning, CleaningVM>().ReverseMap();

            CreateMap<Cleaning, EditCleaningVM>().ReverseMap();

            CreateMap<LoanInstallment, LoanInstallmentVM>().ReverseMap();

            CreateMap<Emegency, EmegencyVM>().ReverseMap();

            CreateMap<SmsUsage, SmsUsageVM>().ReverseMap();

            CreateMap<Admission, AdmissionVM>().ReverseMap();

            CreateMap<Employee, EmployeeVM>().ReverseMap();

            CreateMap<Customer, CustomerVM>().ReverseMap();

            CreateMap<Loan, LoanVM>().ReverseMap();

            CreateMap<LoanType, LoanTypeVM>().ReverseMap();

            CreateMap<Loan, EditLoanVM>().ReverseMap();

            CreateMap<AssetType, AssetTypeVM>().ReverseMap();

            CreateMap<Communication, CommunicationVM>().ReverseMap();

            CreateMap<Water, WaterVM>().ReverseMap();

            CreateMap<Asset, AssetVM>().ReverseMap();

            CreateMap<Asset, EditAssetVM>().ReverseMap();

            CreateMap<Electricity, ElectricityVM>().ReverseMap();

            CreateMap<Electricity, EditElectricityVM>().ReverseMap();

            CreateMap<Invoice, InvoiceVM>().ReverseMap();

            CreateMap<Invoice, EditInvoiceVM>().ReverseMap();

            CreateMap<MaintenanceType, MaintenanceTypeVM>().ReverseMap();

            CreateMap<Maintenance, MaintenanceVM>().ReverseMap();

            CreateMap<Maintenance, EditMaintenanceVM>().ReverseMap();

            CreateMap<ManageProperty, ManagePropertyVM>().ReverseMap();

            CreateMap<ManageProperty, EditManagePropertyVM>().ReverseMap();

            CreateMap<MeterBoxType, MeterBoxTypeVM>().ReverseMap();

            CreateMap<MeterBox, MeterBoxVM>().ReverseMap();

            CreateMap<MeterBox, EditMeterBoxVM>().ReverseMap();

            CreateMap<ParkingType, ParkingTypeVM>().ReverseMap();

            CreateMap<Property, PropertyVM>().ReverseMap();

            CreateMap<Property, EditPropertyVM>().ReverseMap();

            CreateMap<PropertyType, PropertyTypeVM>().ReverseMap();

            CreateMap<RentType, RentTypeVM>().ReverseMap();

            CreateMap<Visitor, VisitorVM>().ReverseMap();

            CreateMap<Visitor, EditVisitorVM>().ReverseMap();

        }
    }
}
