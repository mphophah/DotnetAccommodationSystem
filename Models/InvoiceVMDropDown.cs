using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AMS.Models
{
    public class InvoiceVMDropDown
    {
        public IEnumerable<SelectListItem> CustomerList { get; set; }
        public IEnumerable<SelectListItem> RentTypeList { get; set; }
    }
}
