using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Your_IoT_Handprint.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Creator")]
        public string CreatorUsername { get; set; }

        [Display(Name = "All ratings")]
        public List<int> AllRatings { get; set; }

        [Display(Name = "Average rating")]
        public double AvgRating { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Github repo")]
        public string GithubRepoUrl { get; set; }

        [Display(Name = "For sale")]
        public bool ForSale { get; set; }

        public int? Quantity { get; set; }

        // conn
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public virtual List<Order> Orders { get; set; }



        public Project()
        {
            AllRatings = new List<int>();
            Orders = new List<Order>();
        }

        // DDD methods
        // recalculate avg rating
        public void addNewRating(int rating)
        {
            AllRatings.Add(rating);

            double rez = (AllRatings.Sum())/(AllRatings.Count());

            AvgRating = rez;
        }
        // public void order() { } 


    }
}