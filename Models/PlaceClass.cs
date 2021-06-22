using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_OSM.Models
{
    [Table("place", Schema = "public")]

    public class PlaceClass
    {
        [Key]
        public int placeid { get; set; }
        public string placname { get; set; }
        public string plactype { get; set; }
        public string placaddress { get; set; }
        //public DateTime created_on { get; set; }
    }
}