using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movie.Entities
{
   public class Orders
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [StringLength(100)]
        public string MovieTitle { get; set; }
        [StringLength(100)]
        public string MovieActor { get; set; }
        [StringLength(100)]
        public string MovieCountry { get; set; }
        [StringLength(100)]
        public string MoviePublisher { get; set; }
        [StringLength(100)]
        public string MovieCategory { get; set; }
        [StringLength(100)]
        public string MovieType { get; set; }
       
     
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
