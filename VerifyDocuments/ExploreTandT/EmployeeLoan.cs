//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExploreTandT
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeLoan
    {
        public int EmployeeId { get; set; }
        public int LoanId { get; set; }
        public int InstallementId { get; set; }
        public Nullable<System.DateTime> AssignDate { get; set; }
        public int Status { get; set; }
        public int Id { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Installement Installement { get; set; }
        public virtual Loan Loan { get; set; }
    }
}