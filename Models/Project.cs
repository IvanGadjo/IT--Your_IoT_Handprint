using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Your_IoT_Handprint.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        public List<int> AllRatings { get; set; }

        public double AvgRating { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string GithubRepoUrl { get; set; }

        public bool ForSale { get; set; }

        public int Quantity { get; set; }

        // conn
        // public string UserId { get; set; }

        public virtual List<Order> Orders { get; set; }



        public Project()
        {
            AllRatings = new List<int>();
            Orders = new List<Order>();
        }

        // DDD methods
        // public void addNewRating(int rating) { }    // recalculate avg
        // public void order() { } 


    }
}