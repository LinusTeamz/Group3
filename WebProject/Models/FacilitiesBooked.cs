using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class FacilitiesBooked
    {
        public int Id { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public int Fk_Facility { get; set; }

        public int Fk_Organizer { get; set; }

        public virtual Facility Facility { get; set; }

        public virtual Organizer Organizer { get; set; }

    }
}