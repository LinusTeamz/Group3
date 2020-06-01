using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class MonitorModel
    {
        public bool Ping { get; set; }
        public string GroupName { get; set; }
        //public string Adress { get; set; }
        public string BaseAdress { get; set;}
        public string ApiURL { get; set; }
    }
}