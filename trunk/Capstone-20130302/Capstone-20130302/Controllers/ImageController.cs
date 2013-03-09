using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_20130302.Models;

namespace Capstone_20130302.Controllers
{
    public class ImageController : Controller
    {
        private SocialBuyContext db = new SocialBuyContext();
        //
        // GET: /Image/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Image/Details/5

        public ActionResult Details(int id)
        {
            string root = Server.MapPath("~/App_Data/Images/");
            Image image = db.Images.Find(id);
            if (image != null)
            {
                try
                {
                    return new FileStreamResult(new FileStream(root + image.Path, FileMode.Open), "image/jpeg");
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    return RedirectToAction("Error");
                }
            }
            else
            {
                return RedirectToAction("Error");
            }
            
        }

        //
        // GET: /Image/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Image/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Image/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Image/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Image/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Image/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
