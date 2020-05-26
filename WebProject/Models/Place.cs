using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class Place
    {
        public Place()
        {
            Facility = new HashSet<Facility>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public string City { get; set; }

        public virtual ICollection<Facility> Facility { get; set; }
    }
}