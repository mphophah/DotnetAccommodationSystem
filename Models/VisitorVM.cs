using AMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    public class VisitorVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Resoan { get; set; }
        public string CheckOut { get; set; }
        public string Accept { get; set; }
        public string CarRegistration { get; set; }
        public string IsChecked { get; set; }
        public string PhoneNumber { get; set; }
        public string ConfirmationCode { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
        public int PropertyId { get; set; }
        [ForeignKey("ParkingId")]
        public Parking Parking { get; set; }
        public int ParkingId { get; set; }
        public IEnumerable<SelectListItem> CustomerList { get; set; }
        public IEnumerable<SelectListItem> PropertyList { get; set; }
        public IEnumerable<SelectListItem> ParkingList { get; set; }
        public string DateCreated { get; set; }
    }

    public class EditVisitorVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Resoan { get; set; }
        public string CheckOut { get; set; }
        public string Accept { get; set; }
        public string ConfirmationCode { get; set; }
        public string CarRegistration { get; set; }
        public string PhoneNumber { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
        public int PropertyId { get; set; }
        [ForeignKey("ParkingId")]
        public Parking Parking { get; set; }
        public int ParkingId { get; set; }
        public string DateCreated { get; set; }
    }


}
