using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Controllers.Participant
{
    public class ParticipantObecnosciController : Controller
    {
        // GET: ParticipantObecnosciController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ParticipantObecnosciController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ParticipantObecnosciController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParticipantObecnosciController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParticipantObecnosciController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ParticipantObecnosciController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParticipantObecnosciController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ParticipantObecnosciController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
