using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace TFMCooperativeSociety.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        [StringLength(100, ErrorMessage = "First name cannot be longer than 100 characters.")]
        public string FirstName { get; set; }

        [StringLength(100, ErrorMessage = "Middle name cannot be longer than 100 characters.")]
        public string LastName { get; set; }

        [StringLength(100, ErrorMessage = "Last name cannot be longer than 100 characters.")]
        public string MiddleName { get; set; }

       // public virtual ICollection<ImageFile> ImageFiles  { get; set; }

 

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class TFMCooperativeDB : IdentityDbContext<ApplicationUser>
    {
        public TFMCooperativeDB()
            : base("TFMCooperativeDB", throwIfV1Schema: false)
        {
        }

        public static TFMCooperativeDB Create()
        {
            return new TFMCooperativeDB();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ApplicationUser>().ToTable("User");

            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");

            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");

            modelBuilder.Entity<IdentityRole>().ToTable("Role");

            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");

        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<MemberBankDetail> MemberBankDetails { get; set; }

        public DbSet<CooperativeBankDetail> CooperativeBankDetails { get; set; }

        public DbSet<LoanStatus> LoanStatus { get; set; }

        public DbSet<Contact> Contacts { get; set; }


    }
}