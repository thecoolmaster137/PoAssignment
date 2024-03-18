using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PO_Assignment.Models
{
    [Table("tblPoDetails")]

    public class PoDetailsModel
    {
        [Key]
        public long ID { get; set; }

        public long OrderID { get; set; }

        [Required(ErrorMessage = "Item Quantity is required.")]
        public long ItemQuantity { get; set; }

        [Required(ErrorMessage = "Item Rate is required.")]
        public decimal ItemRate { get; set; }

        [Required(ErrorMessage = "Item Value is required.")]
        public decimal ItemValue { get; set; }

        [Required(ErrorMessage = "Item Notes is required.")]
        [StringLength(255, ErrorMessage = "Item Notes cannot exceed 255 characters.")]
        public string ItemNotes { get; set; }

        [Required(ErrorMessage = "Expected Date is required.")]
        [Display(Name = "Expected Date")]
        public DateTime ExpectedDate { get; set; }

        public long MaterialID { get; set; }
    }
}