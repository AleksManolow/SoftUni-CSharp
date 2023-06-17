using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly HomiesDbContext context;

        public EventController(HomiesDbContext context)
        {
            this.context = context;
        }
        [Authorize]
        public IActionResult All()
        {
            var events = context.Events
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                })
                .ToList();

            return View(events);

        }
        [Authorize]
        public IActionResult Joined()
        {
            string currentUserId = GetUserId();
            var currentUser = context.Users.Find(currentUserId);

            var events = context.EventParticipants
                .Where(ep => ep.Helper == currentUser)
                .Select(ep => new EventViewModel
                {
                    Id = ep.Event.Id,
                    Name = ep.Event.Name,
                    Start = ep.Event.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = ep.Event.Type.Name,
                    Organiser = GetUserId() 
                })
                .ToList();    
                

            return View(events);
        }

        public IActionResult Add()
        {
            EventFormViewModel eventModel = new()
            {
                Types = context.Types
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                }
                )
                .ToList()
            };

            return View(eventModel);
        }

        [HttpPost]
        public IActionResult Add(EventFormViewModel eventModel)
        {
            if (!ModelState.IsValid)
            {
                return View(eventModel);
            }

            var ev = new Event()
            {
                Name = eventModel.Name,
                Description = eventModel.Description,
                OrganiserId = GetUserId(),
                Start = DateTime.ParseExact(eventModel.Start, "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture),
                End = DateTime.ParseExact(eventModel.End, "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture),
                TypeId = eventModel.TypeId,
            };

            context.Events.Add(ev);
            context.SaveChanges();

            return RedirectToAction("All", "Event");
        }
        public IActionResult Edit(int id)
        {
            var eventInDb = context.Events.Find(id);

            if (eventInDb == null)
            {
                return BadRequest();
            }

            EventFormViewModel eventModel = new EventFormViewModel()
            {
                Name = eventInDb.Name,
                Description = eventInDb.Description,
                Start = eventInDb.Start.ToString("yyyy-MM-dd H:mm"),
                End = eventInDb.End.ToString("yyyy-MM-dd H:mm"),
                TypeId = eventInDb.TypeId,
                Types = context.Types
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                }
                )
                .ToList()
            };

            return View(eventModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, EventFormViewModel eventModel)
        {
            var eventNew = context.Events.Find(id);
            if (eventNew == null)
            {
                return BadRequest();
            }

            eventNew.Name = eventModel.Name;
            eventNew.Description = eventModel.Description;
            eventNew.Start = DateTime.ParseExact(eventModel.Start, "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture);
            eventNew.End = DateTime.ParseExact(eventModel.End, "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture);
            eventNew.TypeId = eventModel.TypeId;
            
            context.SaveChanges();
            return RedirectToAction("All", "Event");
        }
        [Authorize]
        [HttpPost]
        public IActionResult Join(int id)
        {
            var eventInDb = context.Events.Find(id);

            if (eventInDb == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            var entry = new EventParticipant()
            {
                EventId = eventInDb.Id,
                HelperId = currentUserId
            };

            if (context.EventParticipants.Contains(entry))
            {
                return RedirectToAction("All", "Event");
            }

            context.EventParticipants.Add(entry);
            context.SaveChanges();
            return RedirectToAction("Joined", "Event");
        }
        [Authorize]
        [HttpPost]
        public IActionResult Leave(int id)
        {

            var currentUser = GetUserId();
            var eventInDb = context.Events.Find(id);

            if (eventInDb == null)
            {
                return BadRequest();
            }

            var entry = context.EventParticipants.FirstOrDefault(um => um.HelperId == currentUser && um.EventId == id);
            context.EventParticipants.Remove(entry);
            context.SaveChanges();

            return RedirectToAction("Joined", "Event");
        }
        [Authorize]
        public IActionResult Details(int id)
        {
            var eventInDb = context.Events.Find(id);

            if (eventInDb == null)
            {
                return BadRequest();
            }

            var eventView = new EventViewModel()
            {
                Id = eventInDb.Id,
                Name = eventInDb.Name,
                Description = eventInDb.Description,
                Start = eventInDb.Start.ToString("yyyy-MM-dd H:mm"),
                End = eventInDb.End.ToString("yyyy-MM-dd H:mm"),
                CreatedOn = eventInDb.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                Type = context.Types.Find(eventInDb.TypeId).Name,
                Organiser = context.Users.Find(eventInDb.OrganiserId).UserName,
            };
            return View(eventView);
        }
        private string GetUserId()
           => this.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}