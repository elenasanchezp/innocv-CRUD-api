using innocv_crud.Api.Context;
using innocv_crud.Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace innocv_crud.Api.Controllers
{
    public class HomeController : Controller
    {
        // Url where it´s the Api
        string BaseUrl = "http://localhost:44382";

        // Database context
        private DatabaseContext db = new DatabaseContext();

        // GET: /Home/Index
        public async Task<ActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
        }

        // GET: /Home/Details/1
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User usersModel = db.Users.Find(id);            
            return View(usersModel);
        }

        // GET: /Home/Add/1
        [HttpGet]
        public ActionResult Add()
        {
           return View();
        }

        // POST: /Home/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(User item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(item);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException  ex)
            {
                ModelState.AddModelError("", "Unable to save the changes.");
            }

            return View(item);
        }

        // GET: /Home/Edit/1
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User usersModel = db.Users.Find(id);
            return View(usersModel);
        }

        // POST: /Home/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(User item)
        {           
            if (ModelState.IsValid)
            {
                try
                {
                    var userModel = db.Users.Find(item.Id);
                    TryUpdateModel(userModel);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save then changes." );
                }
            }

            return View(item);
        }

        // GET: /Home/Delete/1
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User usersModel = db.Users.Find(id);
            return View(usersModel);
        }

        // POST: /Home/Delete
        [HttpPost]
        public async Task<ActionResult> Delete(User item, int id)
       {
            var userModel = await db.Users.FindAsync(id);
            if (userModel == null)
            {
                return View();
            }

            try
            {
                db.Users.Remove(userModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
               ModelState.AddModelError("", "Unable to delete the item. Try again, and if the problem persists see your system administrator.");
               return View();
            }
        }       
    }
}
