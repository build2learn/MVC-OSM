using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_OSM.Models
{
    [Table("place", Schema = "public")]

    //[DisplayName("Places")]
    public class PlaceClass
    {
        [Key]
        public int placeid { get; set; }
        [DisplayName("Name")]
        public string placname { get; set; }

        [DisplayName("Place Type")]
        public string plactype { get; set; }

        [DisplayName("Address")]
        public string placaddress { get; set; }
        //public DateTime created_on { get; set; }
    }
}