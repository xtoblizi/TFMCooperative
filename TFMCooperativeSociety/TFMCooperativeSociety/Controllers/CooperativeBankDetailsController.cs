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
    public class CooperativeBankDetailsController : Controller
    {
        private TFMCooperativeDB db = new TFMCooperativeDB();

        // GET: CooperativeBankDetails
        public async Task<ActionResult> Index()
        {
            return View(await db.CooperativeBankDetails.ToListAsync());
        }


        // GET: CooperativeBankDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CooperativeBankDetail cooperativeBankDetail = await db.CooperativeBankDetails.FindAsync(id);
            if (cooperativeBankDetail == null)
            {
                return HttpNotFound();
            }
            return View(cooperativeBankDetail);
        }

        // GET: CooperativeBankDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CooperativeBankDetailId,DateCreated,Active,BankName,AccountNumber,AccounName,BVN,SortCode")] CooperativeBankDetail cooperativeBankDetail)
        {
            if (ModelState.IsValid)
            {
                db.CooperativeBankDetails.Add(cooperativeBankDetail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cooperativeBankDetail);
        }

        // GET: CooperativeBankDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CooperativeBankDetail cooperativeBankDetail = await db.CooperativeBankDetails.FindAsync(id);
            if (cooperativeBankDetail == null)
            {
                return HttpNotFound();
            }
            return View(cooperativeBankDetail);
        }

        // POST: CooperativeBankDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CooperativeBankDetailId,DateCreated,Active,BankName,AccountNumber,AccounName,BVN,SortCode")] CooperativeBankDetail cooperativeBankDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cooperativeBankDetail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cooperativeBankDetail);
        }

        // GET: CooperativeBankDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CooperativeBankDetail cooperativeBankDetail = await db.CooperativeBankDetails.FindAsync(id);
            if (cooperativeBankDetail == null)
            {
                return HttpNotFound();
            }
            return View(cooperativeBankDetail);
        }

        // POST: CooperativeBankDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CooperativeBankDetail cooperativeBankDetail = await db.CooperativeBankDetails.FindAsync(id);
            db.CooperativeBankDetails.Remove(cooperativeBankDetail);
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
