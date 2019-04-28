using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExploreTandT.Models
{
    public class AdminViewModel
    {
        public List<Loan> listofloans = new List<Loan>();
        public List<Employee> listofemployees = new List<Employee>();
        public List<EmployeeLoan> listofEmployeeLoan = new List<EmployeeLoan>();
        public List<Request> requests = new List<Request>();
        public List<PolicyAndRule> listOfPolicies = new List<PolicyAndRule>();
        public List<Installement> listOfInstallements = new List<Installement>();

        public string select { get; set; }
        public int selectrange { get; set; }


    }
}