using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExploreTandT.Models
{
    public class RequestViewModel
    {
        public int Id;

        public int Loanid;
        public int Employeeid;
        public int Status;
        public string Reason;
        
    }
}