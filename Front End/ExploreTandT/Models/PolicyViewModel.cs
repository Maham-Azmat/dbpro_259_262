using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExploreTandT.Models
{
    public class PolicyViewModel
    {
        public int Id;

        public int LoanId;

        [Required]
        [Display(Name = "Details")]
        public string Details { get; set; }

        [Display(Name = "Rank")]
        [Required]
        public string Rank { get; set; }

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Salary should be in Digits")]
        [Display(Name = "Salary")]
        [Required]
        public int Salary { get; set; }
    }
}