using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExploreTandT.Models
{
    public class SalaryDeductionViewModel
    {
        public int Id;
        public int Loanid;
        public int Employeeid;
        public int Installementid;
        public int Salaryafterdeduction;
        public DateTime Date;
        public string Month;
    }
}