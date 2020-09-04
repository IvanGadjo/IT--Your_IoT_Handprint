using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        // unopened
        // in the making
        // finished
        // sent
        public string Status { get; set; }

        //conn
        public int ?ProjectId { get; set; }

        public string UserId { get; set; }      // id of the creator of the order
        public string CreatorUsername { get; set; }
        //[ForeignKey("UserId")]
        //public ApplicationUser User { get; set; }   // creator of the order



        public Order()
        {
            OrderedOn = DateTime.Now;
            Status = "Unopened";
        }

        // DDD methods
        
    }
}