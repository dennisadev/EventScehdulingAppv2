using EventScehdulingAppv2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventScehdulingAppv2.Controllers
{
    public class EventController : Controller
    {
        //Configure event controller and setup the repository
        private readonly IEventRepository repo;
        public EventController(IEventRepository repo)
        {
            this.repo = repo;
        }

        //Index method to display all events
        public IActionResult Index()
        {
            var events = repo.GetAllEvents();
            return View(events);
        }

        //Details method to display details of a specific event
        public IActionResult Details(int id)
        {
            var events = repo.GetEventById(id);
            return View(events);
        }

        //Update method to update an event
        public IActionResult Update(int id)
        {
            Event evt = repo.GetEventById(id);
            return View(evt);
        }

        //UpdateToDatabase method to call update method and update the event in the database
        public IActionResult UpdateToDatabase(Event evt) 
        {
            repo.UpdateEvent(evt);
            return RedirectToAction("Index");
        }

        //Delete method to delete an event
        public IActionResult Delete(int id)
        {
            repo.DeleteEvent(id);
            return RedirectToAction("Index");
        }

        //Add method to add an event
        public IActionResult Add()
        {

            var events = new Event();
            return View(events);
        }

        //AddEventToDatabase method to call add method and add the event to the database
        public IActionResult AddEventToDatabase(Event evt)
        {
            repo.AddEvent(evt);
            return RedirectToAction("Index", "Home");
        }

    }
}
