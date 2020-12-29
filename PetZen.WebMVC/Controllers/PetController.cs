using Microsoft.AspNet.Identity;
using PetZen.Data;
using PetZen.Models;
using PetZen.Models.PetModels;
using PetZen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetZen.WebMVC.Controllers
{
    public class PetController : Controller
    {

        // GET: Pet
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PetService(userId);
            var model = service.GetPets();

            return View(model);
        }

        //GET: PET/CREATE
        public ActionResult Create()
        {
            return View();
        }

        //POST: Pet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PetCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateNoteService();

            if (service.CreatePet(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);

        }



        private PetService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PetService(userId);
            return service;
        }
    }

    
}