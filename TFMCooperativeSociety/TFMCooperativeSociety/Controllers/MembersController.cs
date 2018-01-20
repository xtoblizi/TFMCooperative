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
using Microsoft.AspNet.Identity.Owin;

namespace TFMCooperativeSociety.Controllers
{
    public class MembersController : Controller
    {
        private TFMCooperativeDB db = new TFMCooperativeDB();
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Members
        public async Task<ActionResult> Index()
        {
            return View(await db.Members.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = await db.Members.FindAsync(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Member model)
        {
            if (ModelState.IsValid)
            {
                if (!db.Users.Any(u => u.Email == model.Email))
                {
                    try
                    {
                        var user = new ApplicationUser
                        {
                            UserName = model.Email,
                            Email = model.Email,
                            FirstName = model.FirstName,
                            MiddleName = model.MiddleName,
                            LastName = model.FirstName,

                        };
                        var result = await UserManager.CreateAsync(user, model.Password);

                        if (result.Succeeded)
                        {
                            var member = new Member
                            {
                                MemberId = user.Id,
                                Email = model.Email,
                                FirstName = model.FirstName,
                                MiddleName = model.MiddleName,
                                LastName = model.LastName,
                                Passport = model.Passport,
                                ImageUrl = model.ImageUrl

                            };

                            db.Members.Add(member);
                            await db.SaveChangesAsync();

                            await this.UserManager.AddToRoleAsync(user.Id, "Members");

                            // For more information on how to enable account confirmation and password reset please visit
                            // http://go.microsoft.com/fwlink/?LinkID=320771
                            // Send an email with this link
                            // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                            // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                            // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>")

                            // await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: true);

                            ViewBag.Message = "Registration Successful Sign In Now, To Continue";
                            return View();
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "Registration was NOT Succesul, Try again " + "" + ex;
                        return View(model);
                    }
                }
                ViewBag.Message = "This Email" + "" + "" + model.Email + "" + " already exist, Login or use another email address";
                return View();
            }

            ViewBag.Message = "Verify your entry ";
            return View(model);
        }

        // GET: Members/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                id = User.Identity.GetUserId();
            }
            Member member = await db.Members.FindAsync(id);


            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( Member member)
        {
            if (ModelState.IsValid)
            {
                member.Gender = member.GenderList.ToString();
                member.StateOfOrigin = member.StateOfOriginList.ToString();

                if (
                       member.DateOfBirth != null && member.BusinessStreet != null && member.Gender != null &&
                       member.PhoneNumber != null && member.BusinessCity != null && member.BusinessState != null
                    )
                {
                    member.CompletedRegistration = true;

                }

                db.Entry(member).State = EntityState.Modified;

                await db.SaveChangesAsync();

                ViewBag.Message = "Profile registration details successfully captured.";
                return View();
            }

            ViewBag.Message = "Profile Registration details was not captured successfully, Try again ";
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = await db.Members.FindAsync(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Member member = await db.Members.FindAsync(id);
            db.Members.Remove(member);
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
