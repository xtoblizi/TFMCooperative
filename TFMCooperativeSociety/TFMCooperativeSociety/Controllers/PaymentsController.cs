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
using Microsoft.AspNet.Identity;

namespace TFMCooperativeSociety.Controllers
{
    [Authorize]
    public class PaymentsController : Controller
    {
        private TFMCooperativeDB db = new TFMCooperativeDB();

        // GET: Payments

        [Authorize(Roles ="Administrators")]
        public async Task<ActionResult> Index()
        {
            var payments = db.Payments.Include(path => path.Member);
            return View(await payments.ToListAsync());

        }

        [Authorize(Roles = "Members")]
        public async Task<ActionResult> MemberPayments()
        {
            var userId = User.Identity.GetUserId();
            var payments = db.Payments.Include(p => p.Member).Where(p => p.MemberId == userId );
            return View(await payments.ToListAsync());
        }


        // GET: Payments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = await db.Payments.FindAsync(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Payments/Create

        public async Task<ActionResult> Create()
        {
            var userId = User.Identity.GetUserId();
            // var memberDeatails = db.Members.SingleOrDefault(m => m.MemberId == userId).FirstName;
            if (userId != null)
            {
                //var user = await db.Payments.AsNoTracking().Where(u => u.MemberId.Equals(userId))
                //       .Select(s => s.MemberId).FirstOrDefaultAsync();

                //ViewBag.MemberID = new SelectList(db.Members.Where(m => m.MemberId.Equals(user)),
                //       "MemberId", "FirstName");

                ViewBag.MemberId = new SelectList(db.Members.Where(m => m.MemberId == userId), "MemberId", "FirstName");
                return View();
            }

               return RedirectToAction("Login", "Account");

        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Payment payment)
        {
            var userId = User.Identity.GetUserId();
            //var retrievdMemberId = db.Members.SingleOrDefault(m => m.MemberId == userId).MemberId;


            if (ModelState.IsValid)
            {
                //payment.MemberId = retrievdMemberId;

                db.Payments.Add(payment);
                await db.SaveChangesAsync();

                ViewBag.Message = "Payment detail recorded and delivered, /n Your Payment would be confirmed in 24hours. /n Thank You";
               return RedirectToAction ("Dashboard","Home");
            }

            ViewBag.MemberID = new SelectList(db.Members.Where(m => m.MemberId == userId), "MemberId", "FirstName");
            return View(payment);
        }

        [Authorize(Roles ="Administrators")]
        // Get Paymet for approval
        public async Task<ActionResult> _ApprovePayment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = await db.Payments.FindAsync(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberID = new SelectList(db.Members, "MemberId", "FirstName", payment.MemberId);
            ViewBag.Message = "";
            return View(payment);
        }

        [Authorize(Roles = "Administrators")]
        // Action Perform Approval Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _ApprovePayment(Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                await db.SaveChangesAsync();

                ViewBag.Message = "Payment Approved";
                return RedirectToAction("Index");
            }
            ViewBag.MemberID = new SelectList(db.Members, "MemberId", "FirstName", payment.MemberId);
            ViewBag.Message = " Payment Approval not succesful, Try again";
            return View(payment);
        }


        // GET: Payments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = await db.Payments.FindAsync(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberID = new SelectList(db.Members, "MemberId", "FirstName", payment.MemberId);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MemberID = new SelectList(db.Members, "MemberId", "FirstName", payment.MemberId);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = await db.Payments.FindAsync(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Payment payment = await db.Payments.FindAsync(id);
            db.Payments.Remove(payment);
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

        public ActionResult Approve()
        {
            throw new NotImplementedException();
        }
    }
}
