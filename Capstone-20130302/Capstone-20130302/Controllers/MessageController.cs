using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_20130302.Models;
using Capstone_20130302.Logic;
using WebMatrix.WebData;

namespace Capstone_20130302.Controllers
{
    public class MessageController : Controller
    {
        private SocialBuyContext db = new SocialBuyContext();

        //
        // GET: /Message/

        public ActionResult Index()
        {
            var messages = db.Messages.Include(m => m.SubjectType).Include(m => m.ObjectType).Include(m => m.MessageType);
            return View(messages.ToList());
        }

        public ActionResult MarkAsRead(int MessageId)
        {
            try
            {
                MessageRecipient rep = db.Messages.Find(MessageId).Recipients.Where(r => r.RecipientId == WebSecurity.CurrentUserId).FirstOrDefault();

                rep.IsRead = true;
                db.Entry(rep).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
            return Json("true", JsonRequestBehavior.AllowGet);
            
        }

        public ActionResult GetNewsFeed(int LastMessageId = 0)
        {
            List<MessageJson> messages = Message_Logic.GetNewsFeed(WebSecurity.CurrentUserId, LastMessageId);
            return Json(messages, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Message/Details/5

        public ActionResult Details(int id = 0)
        {
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        //
        // GET: /Message/Create

        public ActionResult Create()
        {
            ViewBag.SubjectTypeId = new SelectList(db.PronounsTypes, "PronounsTypeId", "PronounsTypeName");
            ViewBag.ObjectTypeId = new SelectList(db.PronounsTypes, "PronounsTypeId", "PronounsTypeName");
            ViewBag.MessageTypeId = new SelectList(db.MessageTypes, "MessageTypeId", "MessageTypeName");
            return View();
        }

        //
        // POST: /Message/Create

        [HttpPost]
        public ActionResult Create(Message message)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectTypeId = new SelectList(db.PronounsTypes, "PronounsTypeId", "PronounsTypeName", message.SubjectTypeId);
            ViewBag.ObjectTypeId = new SelectList(db.PronounsTypes, "PronounsTypeId", "PronounsTypeName", message.ObjectTypeId);
            ViewBag.MessageTypeId = new SelectList(db.MessageTypes, "MessageTypeId", "MessageTypeName", message.MessageTypeId);
            return View(message);
        }

        //
        // GET: /Message/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectTypeId = new SelectList(db.PronounsTypes, "PronounsTypeId", "PronounsTypeName", message.SubjectTypeId);
            ViewBag.ObjectTypeId = new SelectList(db.PronounsTypes, "PronounsTypeId", "PronounsTypeName", message.ObjectTypeId);
            ViewBag.MessageTypeId = new SelectList(db.MessageTypes, "MessageTypeId", "MessageTypeName", message.MessageTypeId);
            return View(message);
        }

        //
        // POST: /Message/Edit/5

        [HttpPost]
        public ActionResult Edit(Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectTypeId = new SelectList(db.PronounsTypes, "PronounsTypeId", "PronounsTypeName", message.SubjectTypeId);
            ViewBag.ObjectTypeId = new SelectList(db.PronounsTypes, "PronounsTypeId", "PronounsTypeName", message.ObjectTypeId);
            ViewBag.MessageTypeId = new SelectList(db.MessageTypes, "MessageTypeId", "MessageTypeName", message.MessageTypeId);
            return View(message);
        }

        //
        // GET: /Message/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        //
        // POST: /Message/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}