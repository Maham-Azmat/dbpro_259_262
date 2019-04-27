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
        public int Loanid;

        [Required(ErrorMessage = "Pleasee enter Valid Plan")]
        [DataType(DataType.Currency)]
        [Range(1, 50, ErrorMessage = "Enter Range between 1 and 50")]
        [RegularExpression(@"^(((\d{1})*))$", ErrorMessage = "Enter Valid Expense")]
        public int Installmentplan { get; set; }


        public int Amount { get; set; }


       
    }
}