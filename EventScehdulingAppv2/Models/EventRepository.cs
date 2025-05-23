﻿using System.Data;
using Dapper;

namespace EventScehdulingAppv2.Models
{
    public class EventRepository : IEventRepository
    {
        //IDb Connection for class
        private readonly IDbConnection _conn;

        //Constructor to accept the IDbConnection to private variable
        public EventRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        //Method to interact with the database and return the results
        public IEnumerable<Event> GetAllEvents()
        {
            return _conn.Query<Event>("SELECT * FROM tblevent ORDER BY EventDate DESC");
        }

        //Method to interact with the database and return the results of a specific event
        public Event GetEventById(int eventId)
        {
            return _conn.QuerySingle<Event>("SELECT * FROM tblevent WHERE EventID = @id", new { id = eventId });
        }

        //Method to interact with the database and update the event
        public void UpdateEvent(Event evt)
        {
            _conn.Execute("UPDATE tblevent " +
                "SET FirstName = @firstName, " +
                "LastName = @lastName, " +
                "EmailAddress = @emailAddress, " +
                "PhoneNumber = @phoneNumber, " +
                "EventDate = @eventDate, " +
                "EventDescription = @eventDescription, " +
                "Contract = @contract " +
                "WHERE EventID = @eventID",
            new
            {
                firstName = evt.FirstName,
                lastName = evt.LastName,
                emailAddress = evt.EmailAddress,
                phoneNumber = evt.PhoneNumber,
                eventDate = evt.EventDate,
                eventDescription = evt.EventDescription,
                contract = evt.Contract,
                eventID = evt.EventID
            });
        }

        //Method to interact with the database and delete the event
        public void DeleteEvent(int eventId)
        {
            _conn.Execute("DELETE FROM tblevent WHERE EventID = @id", new { id = eventId });
        }

        //Method to interact with the database and add an event
        public void AddEvent(Event evt)
        {
            _conn.Execute("INSERT INTO tblevent" +
                "(FirstName, LastName, EmailAddress, PhoneNumber, EventDate, EventDescription, Contract) " +
                "VALUES (@firstName, @lastName, @emailAddress, @phoneNumber, @eventDate, @eventDescription, @contract)",
            new
            {
                firstName = evt.FirstName,
                lastName = evt.LastName,
                emailAddress = evt.EmailAddress,
                phoneNumber = evt.PhoneNumber,
                eventDate = evt.EventDate,
                eventDescription = evt.EventDescription,
                contract = evt.Contract
            });
        }
    }
}
