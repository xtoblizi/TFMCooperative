using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TFMCooperativeSociety.Models;

namespace TFMCooperativeSociety.Controllers
{
    public class MemberBankDetailsController : Controller
    {
        private TFMCooperativeDB db = new TFMCooperativeDB();

        // GET: MemberBankDetails
        public async Task<ActionResult> Index()
        {
            var memberBankDetails = db.MemberBankDetails.Include(m => m.Member);
            return View(await memberBankDetails.ToListAsync());
        }
        public async Task<ActionResult> MemberIndex()
        {
            var userId = User.Identity.GetUserId();

            var memberBankDetails = db.MemberBankDetails.Include(m => m.Member)?.Where(m=>m.MemberId.Equals(userId));
            return View(await memberBankDetails.ToListAsync());
        }
        // GET: MemberBankDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberBankDetail memberBankDetail = await db.MemberBankDetails.FindAsync(id);
            if (memberBankDetail == null)
            {
                return HttpNotFound();
            }
            return View(memberBankDetail);
        }

        // GET: MemberBankDetails/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();


            ViewBag.MemberId = new SelectList(db.Members.Where(u => u.MemberId.Equals(userId)), "MemberId", "FirstName");
            return View();
        }

        // POST: MemberBankDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( MemberBankDetail memberBankDetail)
        {
            if (ModelState.IsValid)
            {
                db.MemberBankDetails.Add(memberBankDetail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var userId = User.Identity.GetUserId();

            ViewBag.MemberId = new SelectList(db.Members.Where(u=>u.MemberId.Equals(userId)), "MemberId", "FirstName", memberBankDetail.MemberId);
            return View(memberBankDetail);
        }

        // GET: MemberBankDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberBankDetail memberBankDetail = await db.MemberBankDetails.FindAsync(id);
            if (memberBankDetail == null)
            {
                return HttpNotFound();
            }
            var userId = User.Identity.GetUserId();

            ViewBag.MemberId = new SelectList(db.Members.Where(u => u.MemberId.Equals(userId)), "MemberId", "FirstName", memberBankDetail.MemberId);
            return View(memberBankDetail);
        }

        // POST: MemberBankDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MemberBankDetail memberBankDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberBankDetail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            var userId = User.Identity.GetUserId();

            ViewBag.MemberId = new SelectList(db.Members.Where(u => u.MemberId.Equals(userId)), "MemberId", "BusinessStreet", memberBankDetail.MemberId);
            return View(memberBankDetail);
        }

        // GET: MemberBankDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberBankDetail memberBankDetail = await db.MemberBankDetails.FindAsync(id);
            if (memberBankDetail == null)
            {
                return HttpNotFound();
            }
            return View(memberBankDetail);
        }

        // POST: MemberBankDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MemberBankDetail memberBankDetail = await db.MemberBankDetails.FindAsync(id);
            db.MemberBankDetails.Remove(memberBankDetail);
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
