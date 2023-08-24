using AMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    public class AssetVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<SelectListItem> CustomerList { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public IEnumerable<SelectListItem> PropertyList { get; set; }

        public int AssetTypeId { get; set; }
        public AssetType AssetType { get; set; }
        public IEnumerable<SelectListItem> AssetTypeList { get; set; }
        public string DateCreated { get; set; }

    }

    public class EditAssetVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Property Property { get; set; }
        public int PropertyId { get; set; }
        public AssetType AssetType { get; set; }
        public int AssetTypeId { get; set; }
        public string DateCreated { get; set; }
    }



}
