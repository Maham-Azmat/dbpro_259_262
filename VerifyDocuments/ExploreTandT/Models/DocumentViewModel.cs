using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExploreTandT.Models
{
    public class DocumentViewModel
    {
        public HttpPostedFileBase ImageFile { get; set; }
        public int Id;
        public int Loanid;
        public int Employeeid;
        public string Document;
        public int Status;
        public int temp;
        public string Title;
    }
}