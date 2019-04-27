using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExploreTandT.Models
{
    public class LoanViewModel
    {
        public int Id;

        [Required]
        [Display(Name = "Details")]
        public string Details { get; set; }

        [Required]
        [Display(Name = "TermsAndConditions")]
        public string TermsAndConditions { get; set; }


        [Required(ErrorMessage = "Pleasee enter Valid Expense")]
        [DataType(DataType.Currency)]
        [Range(5000, 1000000, ErrorMessage = "Enter Range between 5000 and 1000000")]
        [RegularExpression(@"^(((\d{1})*))$", ErrorMessage = "Enter Valid Expense")]
        public int Amount { get; set; }

        public List<Loan> listofloans = new List<Loan>();
    }
}