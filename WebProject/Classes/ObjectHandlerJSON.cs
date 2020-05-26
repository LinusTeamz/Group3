﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Threading.Tasks;
using System.Text;
using WebProject.Models;

namespace WebProject.classes
{
    public class ObjectHandlerJSON
    {
        // Egen API
        //private string BaseURL = "http://193.10.202.78/";
        private string organiserBaseURL = "http://localhost:50270/";
        // URL:er för egen API
        private string facilityURL = "Facilities", organizersURL = "Organizers", placeURL = "Places", facilitiesBookedURL = "FacilitiesBooked";

        // Annan API 
        private string eventBaseURL = "http://193.10.202.77/EventService/";
        private string eventAPI = "Api/Events";


        
        #region Read
        public async Task<List<Facility>> GetFacilityList()
        {
            List<Facility> FacilityInfo = new List<Facility>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(organiserBaseURL);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  

                HttpResponseMessage Res = await client.GetAsync(facilityURL);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    FacilityInfo = JsonConvert.DeserializeObject<List<Facility>>(response);

                }
     
                return FacilityInfo;
            }
        }
        public async Task<List<Organizer>> GetOrganizerList()
        {
            List<Organizer> organizerInfo = new List<Organizer>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(organiserBaseURL);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  

                HttpResponseMessage Res = await client.GetAsync(organizersURL);


                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    organizerInfo = JsonConvert.DeserializeObject<List<Organizer>>(response);

                }
             
                return organizerInfo;
            }
        }
        public async Task<List<Place>> GetPlaceList()
        {
            List<Place> PlaceInfo = new List<Place>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(organiserBaseURL);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  

                HttpResponseMessage Res = await client.GetAsync(placeURL);


                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    PlaceInfo = JsonConvert.DeserializeObject<List<Place>>(response);

                }
                return PlaceInfo;
            }
        }
        public async Task<List<FacilitiesBooked>> GetFacilitiesBookedList()
        {
            List<FacilitiesBooked> facilitiesBooked = new List<FacilitiesBooked>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(organiserBaseURL);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(facilitiesBookedURL);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    facilitiesBooked = JsonConvert.DeserializeObject<List<FacilitiesBooked>>(response);

                }

                return facilitiesBooked;
            }
        }
        public async Task<List<Event>> GetEventList()
        {
    

            List<Event> eventList = new List<Event>();


            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(eventBaseURL);

                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.GetAsync(eventAPI);

                    if (Res.IsSuccessStatusCode)
                    {
                        var response = Res.Content.ReadAsStringAsync().Result;
                        eventList = JsonConvert.DeserializeObject<List<Event>>(response); 
                    }
                }

                return eventList;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /* --- Get by ID --- */
        public async Task<Place> GetPlaceByID(int id) 
        {
            Place place = new Place();
            HttpClient client = new HttpClient();

            string URL = organiserBaseURL + placeURL +"/" + id.ToString();
            
            var response = await client.GetAsync(new Uri(URL));

            if (response.IsSuccessStatusCode)
            {

                var content = await response.Content.ReadAsStringAsync();
                place = JsonConvert.DeserializeObject<Place>(content);

            }
                return place;
        }
        public async Task<Facility> GetFacilityByID(int id)
        {
            Facility facility = new Facility();
            HttpClient client = new HttpClient();
            
            string URL = organiserBaseURL + facilityURL + "/" + id.ToString();

            var response = await client.GetAsync(new Uri(URL));

            if (response.IsSuccessStatusCode)
            {                
                var content = await response.Content.ReadAsStringAsync();
                facility = JsonConvert.DeserializeObject<Facility>(content);
            }
            return facility;
        }
        public async Task<Organizer> GetOrganizerByID(int id)
        {
            Organizer organizer = new Organizer();
            HttpClient client = new HttpClient();

            string URL = organiserBaseURL + organizersURL + "/" + id.ToString();

            var response = await client.GetAsync(new Uri(URL));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                organizer = JsonConvert.DeserializeObject<Organizer>(content);
            }
            return organizer;
        }
        public async Task<FacilitiesBooked> GetFacilitiesBookedByID(int id)
        {
            FacilitiesBooked facilitiesBooked = new FacilitiesBooked();
            HttpClient client = new HttpClient();

            string URL = organiserBaseURL + facilitiesBookedURL + "/" + id.ToString();

            var response = await client.GetAsync(new Uri(URL));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                facilitiesBooked = JsonConvert.DeserializeObject<FacilitiesBooked>(content);
            }
            return facilitiesBooked;
        }
        #endregion
        #region Add
        public async Task AddOrganizer(Organizer newOrganizer)
        {
            try
            {
                HttpClient client = new HttpClient();

                // Using jsonconvert and creates content 
                string jsonString = JsonConvert.SerializeObject(newOrganizer); // Lägg in ny objekt
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                // URL vart datan ska skickas

                string URL = organiserBaseURL + organizersURL;

                // Connecting webapi
                var response = await client.PostAsync(URL, content);
                var responseString = await response.Content.ReadAsStringAsync(); 

            }
            catch (Exception ex)
            {
                
            }
        }
        public async Task AddEvent(Event newEvent)
        {
            try
            {
                HttpClient client = new HttpClient();

                // Using jsonconvert and creates content 
                string jsonString = JsonConvert.SerializeObject(newEvent); // Lägg in ny objekt
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                // URL vart datan ska skickas

                string URL = eventBaseURL + eventAPI;

                // Connecting webapi
                var response = await client.PostAsync(URL, content);
                var responseString = await response.Content.ReadAsStringAsync();

            }
            catch (Exception e)
            {
                
            }
        }
        public async Task AddFacility(Facility newFacility)
        {
            try
            {
                HttpClient client = new HttpClient();

                // Using jsonconvert and creates content 
                string jsonString = JsonConvert.SerializeObject(newFacility); // Lägg in ny objekt
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                // URL vart datan ska skickas
                string URL = organiserBaseURL + facilityURL;

                // Connecting webapi
                var response = await client.PostAsync(URL, content);
                var responseString = await response.Content.ReadAsStringAsync(); 

            }
            catch (Exception ex)
            {
            
            }
        }
        public async Task AddPlace(Place newPlace)
        {
            try
            {
                HttpClient client = new HttpClient();

                // Using jsonconvert and creates content 
                string jsonString = JsonConvert.SerializeObject(newPlace); // Lägg in ny objekt
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                // URL vart datan ska skickas
                string URL = organiserBaseURL + placeURL;

                // Connecting webapi
                var response = await client.PostAsync(URL, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync(); 
                }
              

            }
            catch (Exception ex)
            {

            }
        }
        public async Task AddFacilitiesBooked(FacilitiesBooked newFacilitiesBooked)
        {
            try
            {
                HttpClient client = new HttpClient();

                // Using jsonconvert and creates content 
                string jsonString = JsonConvert.SerializeObject(newFacilitiesBooked); // Lägg in ny objekt
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                // URL vart datan ska skickas
                string URL = organiserBaseURL + facilitiesBookedURL;

                // Connecting webapi
                var response = await client.PostAsync(URL, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync(); 
                }
              

            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region Delete
        public async Task DeleteFacility(int id)
        {
            try
            {
                HttpClient client = new HttpClient();

                // By ID
                string URL = organiserBaseURL + facilityURL + "/" + id.ToString();

                var response = await client.GetAsync(new Uri(URL));

                if (response.IsSuccessStatusCode)
                {
                    // delete by ID
                    var respons = await client.DeleteAsync(new Uri(URL));
                }


            }
            catch (Exception ex)
            {


            }
        }
        public async Task DeleteFacilitiesBooked(int id)
        {
            try
            {
                HttpClient client = new HttpClient();

                // By ID
                string URL = organiserBaseURL + facilitiesBookedURL + "/" + id.ToString();

                var response = await client.GetAsync(new Uri(URL));

                if (response.IsSuccessStatusCode)
                {
                    // delete by ID
                    var respons = await client.DeleteAsync(new Uri(URL));
                }

            }
            catch (Exception ex)
            {

            }
        }
        public async Task DeletePlace(int id)
        {
            try
            {
                HttpClient client = new HttpClient();

                // By ID
                string URL = organiserBaseURL + placeURL + "/" + id.ToString();

                var response = await client.GetAsync(new Uri(URL));

                if (response.IsSuccessStatusCode)
                {
                    // delete by ID
                    var respons = await client.DeleteAsync(new Uri(URL));
                }

            }
            catch (Exception ex)
            {

            }
        }
        public async Task DeleteOrganizer(int id)
        {
            try
            {
                HttpClient client = new HttpClient();

                // By ID
                string URL = organiserBaseURL + organizersURL + "/" + id.ToString();

                var response = await client.GetAsync(new Uri(URL));

                if (response.IsSuccessStatusCode)
                {
                    // delete by ID
                    var respons = await client.DeleteAsync(new Uri(URL));
                }

            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region Update
        public async Task UpdateFacility(Facility updatedFacility)
        {
            HttpClient client = new HttpClient();

            // URL for customer id selected by user
            string URL = organiserBaseURL + facilityURL + "/" + updatedFacility.Id.ToString();

            var response = await client.GetAsync(new Uri(URL));

            if (response.IsSuccessStatusCode)
            {
                // Json and webapi
                string jsonstring = JsonConvert.SerializeObject(updatedFacility);
                var content = new StringContent(jsonstring, Encoding.UTF8, "Application/json");
                var responsupdate = await client.PutAsync(URL, content);
            }
        }
        public async Task UpdateFacilitiesBooked(FacilitiesBooked updatedFacilitiesBooked)
        {
            HttpClient client = new HttpClient();

            // URL for customer id selected by user
            string URL = organiserBaseURL + facilitiesBookedURL + "/" + updatedFacilitiesBooked.Id.ToString();

            var response = await client.GetAsync(new Uri(URL));

            if (response.IsSuccessStatusCode)
            {
                // Json and webapi
                string jsonstring = JsonConvert.SerializeObject(updatedFacilitiesBooked);
                var content = new StringContent(jsonstring, Encoding.UTF8, "Application/json");
                var responsupdate = await client.PutAsync(URL, content);
            }
        }
        public async Task UpdatePlace(Place updatedPlace)
        {
            HttpClient client = new HttpClient();

            // URL for customer id selected by user
            string URL = organiserBaseURL + placeURL + "/" + updatedPlace.Id.ToString();

            var response = await client.GetAsync(new Uri(URL));

            if (response.IsSuccessStatusCode)
            {
                // Json and webapi
                string jsonstring = JsonConvert.SerializeObject(updatedPlace);
                var content = new StringContent(jsonstring, Encoding.UTF8, "Application/json");
                var responsupdate = await client.PutAsync(URL, content);
            }
        }
        public async Task UpdateOrganizer(Organizer updatedOrganizer)
        {
            HttpClient client = new HttpClient();

            // URL for customer id selected by user
            string URL = organiserBaseURL + organizersURL + "/" + updatedOrganizer.Id.ToString();

            var response = await client.GetAsync(new Uri(URL));

            if (response.IsSuccessStatusCode)
            {
                // Json and webapi
                string jsonstring = JsonConvert.SerializeObject(updatedOrganizer);
                var content = new StringContent(jsonstring, Encoding.UTF8, "Application/json");
                var responsupdate = await client.PutAsync(URL, content);
            }
        }
        #endregion
    }
}