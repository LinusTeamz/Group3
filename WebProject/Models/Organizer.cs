using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class Organizer
    {
        public Organizer()
        {
            FacilitiesBooked = new HashSet<FacilitiesBooked>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<FacilitiesBooked> FacilitiesBooked { get; set; }
    }
}