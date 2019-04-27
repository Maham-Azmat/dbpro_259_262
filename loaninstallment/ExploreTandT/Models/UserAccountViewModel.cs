using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExploreTandT.Models
{
    public class UserAccountViewModel
    {
        public List<SelectedPackagesViewModel> listofpackages = new List<SelectedPackagesViewModel>();

        public List<RegisterViewModel> listofusers = new List<RegisterViewModel>();

        public List<ReviewsModel> StoreReview = new List<ReviewsModel>();

        [Required]
        [Display(Name = "Details")]
        public string Details { get; set; }

        public int status;


    }
}