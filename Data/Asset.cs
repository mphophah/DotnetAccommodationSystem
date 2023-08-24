using AMS.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace AMS.Data
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string isDeleted { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }


        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
        public int PropertyId { get; set; }


        [ForeignKey("AssetTypeId")]
        public AssetType AssetType { get; set; }
        public int AssetTypeId { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }
}
