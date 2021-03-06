﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UAIVeterinaria.Models;
using UAIVeterinaria.Data;

namespace UAIVeterinaria.Controllers
{
    public class OwnerController : Controller
    {
        OwnerRepository repo = new OwnerRepository();
        // GET: Owner
        public ActionResult Index()
        {
            return View(repo.List());
        }

        //GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Owner owner)
        {
            repo.Insert(owner);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var owner = repo.GetById(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        [HttpPost]
        public ActionResult Edit(Owner owner)
        {
            repo.Update(owner);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var owner = repo.GetById(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }
    }
}