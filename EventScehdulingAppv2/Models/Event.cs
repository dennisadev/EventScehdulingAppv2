﻿namespace EventScehdulingAppv2.Models
{

    //Contains the properties of an event as in the database
    public class Event
    {
        public int EventID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime EventDate { get; set; }
        public string? EventDescription { get; set; }
        public bool Contract { get; set; }
    }
}
