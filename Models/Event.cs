using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Your_IoT_Handprint.Models
{
    public class Event
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
        public string Location { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Event link")]
        public string EventLinkUrl { get; set; }

        [Required]
        public DateTime Date { get; set; }

        // conn
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }



        public Event()
        {
            AllRatings = new List<int>();
        }

        // DDD methods
        // recalculate avg rating
        public void addNewRating(int rating)
        {
            AllRatings.Add(rating);

            double rez = (AllRatings.Sum()) / (AllRatings.Count());

            AvgRating = rez;
        }
    }
}