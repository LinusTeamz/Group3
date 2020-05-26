using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class Event
    {
        public int Event_Id { get; set; }
        public string Event_Name { get; set; }
        public bool Event_Active { get; set; }
        public int Event_Arranger_Id { get; set; }
        public bool? Event_Seeking_Volunteers { get; set; }
        public int? Event_Location_Id { get; set; }
        public EventCategory Event_Category { get; set; }
        public string Event_Description { get; set; }
        public string Event_Imagelink { get; set; }
        public int? Event_Ticket_Price { get; set; }
        public DateTime? Event_Start_Datetime { get; set; }
        public DateTime? Event_End_Datetime { get; set; }
        public DateTime? Event_Create_Datetime { get; set; }
    }
}