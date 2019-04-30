using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExploreTandT.Models
{
    public class InstallmentViewModel
    {
        public int Id;

        public int LoanId;

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Number of Installments should be in Digits")]
        [Display(Name = "Number Of Installments")]
        [Required]
        public int Plan { get; set; }

        public int Amount { get; set; }
    }
}