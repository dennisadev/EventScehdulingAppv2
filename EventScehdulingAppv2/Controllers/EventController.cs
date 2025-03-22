using EventScehdulingAppv2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventScehdulingAppv2.Controllers
{
    public class EventController : Controller
    {
        //Configure Event Controller
        private readonly IEventRepository repo;
        public EventController(IEventRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var events = repo.GetAllEvents();
            return View(events);
        }
        public IActionResult Details(int id)
        {
            var events = repo.GetEventById(id);
            return View(events);
        }
        public IActionResult Update(int id)
        {
            Event evt = repo.GetEventById(id);
            return View(evt);
        }
        public IActionResult UpdateToDatabase(Event evt) 
        {
            repo.UpdateEvent(evt);
            //return RedirectToAction("Details", new { id = evt.EventID }); **Option to return to Details page for event
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            repo.DeleteEvent(id);
            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            var events = new Event();
            return View(events);
        }
        public IActionResult AddEventToDatabase(Event evt)
        {
            repo.AddEvent(evt);
            return RedirectToAction("Index");
        }

    }
}
