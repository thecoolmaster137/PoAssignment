using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PO_Assignment.Models
{
    [Table("tblPoHeader")]
    public class PoHeaderModel
    {
        [Key]
        public long ID { get; set; }

        [Required(ErrorMessage = "OrderNumber is required.")]
        public long OrderNumber { get; set; }

        [Required(ErrorMessage = "Order Date is required.")]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        public long VendorId { get; set; }

        [StringLength(255, ErrorMessage = "Notes cannot exceed 255 characters.")]
        public string Notes { get; set; }

        [Required(ErrorMessage = "OrderValue is required.")]
        public long OrderValue { get; set; }

        [Required(ErrorMessage = "Order Status is required.")]
        [StringLength(5, ErrorMessage = "Code must be 5 characters long.")]
        public string OrderStatus { get; set; }
    }
}