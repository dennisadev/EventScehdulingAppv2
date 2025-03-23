using EventScehdulingAppv2.Models;
using System.Collections.Generic;

namespace EventScehdulingAppv2.Models
{

    //Interface for the EventRepository class with stubs for the methods
    public interface IEventRepository
    {
        public IEnumerable<Event> GetAllEvents();
        public Event GetEventById(int eventId);
        public void UpdateEvent(Event evt);
        public void DeleteEvent(int eventId);
        public void AddEvent(Event evt);
    }
}
