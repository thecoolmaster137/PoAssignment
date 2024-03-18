using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PO_Assignment.Models
{
    [Table("tblMaterialMaster")]

    public class MaterialEntryModel
    {
        [Key]
        public long ID { get; set; }

        [Required(ErrorMessage = "Code is required.")]
        [StringLength(5, ErrorMessage = "Code must be at most 5 characters long.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Short Text is required.")]
        [StringLength(150, ErrorMessage = "Short Text must be at most 150 characters long.")]
        public string ShortText { get; set; }

        [StringLength(255, ErrorMessage = "Long Text must be at most 255 characters long.")]
        public string LongText { get; set; }

        [StringLength(50, ErrorMessage = "Unit must be at most 50 characters long.")]
        public string Unit { get; set; }

        public long? ReorderLevel { get; set; } 

        [Range(0, long.MaxValue, ErrorMessage = "Min Order Quantity must be a non-negative number.")]
        public long MinOrderQuantity { get; set; }

        [Required(ErrorMessage = "IsActive is required.")]
        public bool IsActive { get; set; }
    }
}