using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AMS.Models
{
    public class PropertyVMDropDown
    {
        public IEnumerable<SelectListItem> ParkingTypeList { get; set; }
        public IEnumerable<SelectListItem> PropertyTypeList { get; set; }
    }
}
