﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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

        [Display(Name = "Average rating")]
        public double AvgRating { get; set; }


        // List of primitive types

        public string AllRatingsString { get; set; }

        [NotMapped]
        public virtual List<int> RatingsDTO
        {
            get     // konvertira AllRatingsString vo List<int>
            {
                string[] strArr = AllRatingsString.Split(',');
                if (strArr[0].Equals(""))
                {
                    return new List<int>();
                }
                int[] intArr = Array.ConvertAll<string, int>(strArr, new Converter<string, int>(Convert.ToInt32));
                return intArr.ToList();
            }
            set     // konvertira List<int> vo AllRatingsString
            {
                if (value.Count != 0)
                {
                    if (AllRatingsString.Equals(""))
                    {
                        AllRatingsString = value.First().ToString();
                    }
                    else
                    {
                        var s = new StringBuilder(AllRatingsString);
                        s.Append(",");
                        s.Append(value.First());
                        AllRatingsString = s.ToString();
                    }
                }
            }
        }




        // conn
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }



        public Event()
        {
            RatingsDTO = new List<int>();
        }

        // DDD methods
        // recalculate avg rating
        public void addNewRating(int rating)
        {
            List<int> listata = new List<int>();
            listata.Add(rating);

            RatingsDTO = listata;

            List<int> allRatings = RatingsDTO;
            int suma = allRatings.Sum();
            int numEls = allRatings.Count();


            double rez = Math.Round((double)suma / (double)numEls,2);

            AvgRating = rez;
        }
    }
}