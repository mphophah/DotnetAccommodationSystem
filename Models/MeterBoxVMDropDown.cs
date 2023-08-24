using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AMS.Models
{
    public class MeterBoxVMDropDown
    {
        public IEnumerable<SelectListItem> PropertyList { get; set; }
        public IEnumerable<SelectListItem> MeterBoxTypeList { get; set; }
    }
}
