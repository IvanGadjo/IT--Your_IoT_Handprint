﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Your_IoT_Handprint.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ordered on")]
        public DateTime OrderedOn { get; set; }

        [Required]
        [Display(Name = "Recipient adress")]
        public string RecipientAdress { get; set; }

        [Required]
        public int Quantity { get; set; }

        //conn
        public int ProjectId { get; set; }



        public Order()
        {
            OrderedOn = DateTime.Now;
        }

        // DDD methods
        
    }
}