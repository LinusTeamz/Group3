using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class Facility
    {
        public Facility()
        {
            FacilitiesBooked = new HashSet<FacilitiesBooked>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Fk_Place { get; set; }

        public virtual ICollection<FacilitiesBooked> FacilitiesBooked { get; set; }

        public virtual Place Place { get; set; }
    }
}