using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class EventFacility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Place Place { get; set; }
    }
}