using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TFMCooperativeSociety.Models;

namespace TFMCooperativeSociety.Controllers
{
    public class LoanStatusController : Controller
    {
        private TFMCooperativeDB db = new TFMCooperativeDB();

        // GET: LoanStatus
        public async Task<ActionResult> Index()
        {
            return View(await db.LoanStatus.ToListAsync());
        }

        // GET: LoanStatus/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanStatus loanStatus = await db.LoanStatus.FindAsync(id);
            if (loanStatus == null)
            {
                return HttpNotFound();
            }
            return View(loanStatus);
        }

        // GET: LoanStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LoanStatusId,Title,DateCreated,MessageContent")] LoanStatus loanStatus)
        {
            if (ModelState.IsValid)
            {
                db.LoanStatus.Add(loanStatus);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(loanStatus);
        }

        // GET: LoanStatus/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanStatus loanStatus = await db.LoanStatus.FindAsync(id);
            if (loanStatus == null)
            {
                return HttpNotFound();
            }
            return View(loanStatus);
        }

        // POST: LoanStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LoanStatusId,Title,DateCreated,MessageContent")] LoanStatus loanStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loanStatus).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(loanStatus);
        }

        // GET: LoanStatus/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanStatus loanStatus = await db.LoanStatus.FindAsync(id);
            if (loanStatus == null)
            {
                return HttpNotFound();
            }
            return View(loanStatus);
        }

        // POST: LoanStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LoanStatus loanStatus = await db.LoanStatus.FindAsync(id);
            db.LoanStatus.Remove(loanStatus);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
