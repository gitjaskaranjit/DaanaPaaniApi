using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Model
{
    public class Location
    {
        [Column(TypeName = "Geometry")]
        public Point LocationPoints { get; set; }

        public string placeId { get; set; }
        public string formatted_address { get; set; }
        public Customer customer { get; set; }

        [Key]
        public int customerId { get; set; }
    }
}