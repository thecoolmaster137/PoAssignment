using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PO_Assignment.Models
{
    [Table("tblVendorMaster")]

    public class VendorEntryModel
    {
       
            [Key]
            public long ID { get; set; }
            [Required(ErrorMessage = "Code is required.")]
            [StringLength(5, ErrorMessage = "Code must be 5 characters long.")]
            public string Code { get; set; }

            [Required(ErrorMessage = "Name is required.")]
            [StringLength(150, ErrorMessage = "Name cannot exceed 150 characters.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Address Line 1 is required.")]
            [StringLength(255, ErrorMessage = "Address Line 1 cannot exceed 255 characters.")]
            public string AddressLine1 { get; set; }

            [StringLength(255, ErrorMessage = "Address Line 2 cannot exceed 255 characters.")]
            public string AddressLine2 { get; set; }

            [Required(ErrorMessage = "Contact Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid email address.")]
            [StringLength(150, ErrorMessage = "Contact Email cannot exceed 150 characters.")]
            public string ContactEmail { get; set; }

            [Required(ErrorMessage = "Contact No is required.")]
            [StringLength(10, ErrorMessage = "Contact No must be 10 characters long.")]
            public string ContactNo { get; set; }

            [Required(ErrorMessage = "Valid Till Date is required.")]
            [Display(Name = "Valid Till Date")]
            public DateTime ValidTillDate { get; set; }

            [Display(Name = "Is Active")]
            public bool IsActive { get; set; }


    }
}