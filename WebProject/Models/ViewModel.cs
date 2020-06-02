using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class ViewModel
    {
        // Used in different views if needed
        public List<Facility> facilityList = new List<Facility>();
        public List<Place> placeList = new List<Place>();
        public List<Organizer> organizerList = new List<Organizer>();
        public List<FacilitiesBooked> facilitiesBookedList = new List<FacilitiesBooked>();
        public List<MonitorModel> monitorList = new List<MonitorModel>();
    }
}